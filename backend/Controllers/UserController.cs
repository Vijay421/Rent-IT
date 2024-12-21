using backend.Data;
using backend.DTOs;
using backend.Models;
using backend.Rollen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace backend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly RentalContext _context;

        public UserController(SignInManager<User> signInManager, UserManager<User> userManager, RentalContext context)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        /// <summary>
        /// Allows signed in users to logout.
        /// </summary>
        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("Uitgelogd");
        }

        /// <summary>
        /// Attempts to return the claims of the current logged in user.
        /// </summary>
        [HttpGet("claims")]
        public async Task<ActionResult> GetClaims()
        {
            var CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (CurrentUserId == null)
            {
                return Unauthorized("Kan gebruiker niet vinden");
            }

            var CurrentUserName = User.FindFirstValue(ClaimTypes.Name);
            var CurrentUserRole = User.FindFirstValue(ClaimTypes.Role);

            return Ok(new
            {
                UserId = CurrentUserId,
                UserName = CurrentUserName,
                Role = CurrentUserRole,
            });
        }

        /// <summary>
        /// Allows admins to delete users.
        /// Other users can only delete themselves.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id?}")]
        public async Task<ActionResult> Delete(string? id = null)
        {
            string userToDelete;
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId == null)
            {
                return NotFound("Kan de gebruiker niet vinden");
            }
            var role = User.FindFirstValue(ClaimTypes.Role);

            if (role == "admin")
            {
                if (id == null)
                {
                    return NotFound("Kan de gebruiker niet vinden");
                }

                userToDelete = id;
            } else
            {
                if (currentUserId != id && id != null)
                {
                    return NotFound("Kan de gebruiker niet vinden");
                }

                userToDelete = currentUserId;
            }

            var user = await _userManager.FindByIdAsync(userToDelete);
            if (user == null)
            {
                return NotFound("Kan de gebruiker niet vinden");
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                var errorMsg = string.Join(", ", result.Errors.Select(e => e.Description));
                Console.Error.WriteLine(errorMsg);

                return BadRequest("Kon de gebruiker niet verwijderen.");
            }

            return NoContent();
        }

        /// <summary>
        /// Will update all logged-in roles.
        /// Allows addresses to be updated as wel, when logged-in as particuliere_huurder.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateUserDTO"></param>
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, UpdateUserDTO updateUserDTO)
        {
            if (!updateUserDTO.HasData())
            {
                return BadRequest("Geen data ontvangen");
            }

            if (updateUserDTO.Id != id)
            {
                return BadRequest("Incorrecte id");
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound("Kan gebruiker niet vinden");
            }

            var CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (CurrentUserId == null)
            {
                return NotFound("Kan gebruiker niet vinden");
            }
            var role = User.FindFirstValue(ClaimTypes.Role);

            if (CurrentUserId != id)
            {
                return Unauthorized("Kan gebruiker niet vinden");
            }

            user.UserName = updateUserDTO.UserName ?? user.UserName;
            user.Email = updateUserDTO.Email ?? user.Email;
            user.PhoneNumber = updateUserDTO.PhoneNumber ?? user.PhoneNumber;

            if (updateUserDTO.UserName != null)
            {
                if (await _userManager.FindByNameAsync(updateUserDTO.UserName) != null)
                {
                    return UnprocessableEntity($"Naam: '{updateUserDTO.UserName}' is al in gebruik");
                }
            }

            if (updateUserDTO.Email != null)
            {
                if (await _userManager.FindByEmailAsync(updateUserDTO.Email) != null)
                {
                    return UnprocessableEntity($"E-mail: '{updateUserDTO.Email}' is al in gebruik");
                }
            }

            if (role == "particuliere_huurder" && updateUserDTO.Address != null)
            {
                await _context.Entry(user).Reference(u => u.ParticuliereHuurder).LoadAsync();
                if (user.ParticuliereHuurder != null)
                {
                    user.ParticuliereHuurder.Address = updateUserDTO.Address;
                }
            }

            if (updateUserDTO.Password != null)
            {
                if (updateUserDTO.CurrentPassword == null)
                {
                    return UnprocessableEntity("Vul het huidige wachtwoord in");
                }

                var pasChangeResult = await _userManager.ChangePasswordAsync(user, updateUserDTO.CurrentPassword, updateUserDTO.Password);
                if (!pasChangeResult.Succeeded)
                {
                    return UnprocessableEntity("Incorrect wachtwoord");
                }
            }

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                await _userManager.UpdateNormalizedEmailAsync(user);
                await _userManager.UpdateNormalizedUserNameAsync(user);
            }
            else
            {
                var errorSet = new HashSet<string>();
                var errorMsg = string.Join(", ", result.Errors.Select(e =>
                {
                    errorSet.Add(e.Code);
                    return e.Description;
                }));
                Console.Error.WriteLine($"error: {errorMsg}");

                if (errorSet.Contains("InvalidUserName"))
                {
                    return UnprocessableEntity("De naam kan alleen letters of getallen bevatten");
                }

                return UnprocessableEntity("Kan de gebruiker niet updaten");
            }

            return Ok(new
            {
                UserId = CurrentUserId,
                UserName = User.FindFirstValue(ClaimTypes.Name),
                Role = User.FindFirstValue(ClaimTypes.Role),
            });
        }

        [Authorize(Roles = "admin")]
        [HttpPost("employee")]
        public async Task<ActionResult<UserDTO>> CreateEmployee(CreateEmployeeDTO createEmployeeDTO)
        {
            if (createEmployeeDTO.Role != "backoffice_medewerker" && createEmployeeDTO.Role != "frontoffice_medewerker")
            {
                return UnprocessableEntity($"Verkeerde rol; verwacht: backoffice of frontoffice, ontvangen: '{createEmployeeDTO.Role}'");
            }

            var user = new User
            {
                UserName = createEmployeeDTO.Name.Trim(),
                Email = createEmployeeDTO.Email.ToLower().Trim(),
                PhoneNumber = createEmployeeDTO.PhoneNumber.Trim(),
            };

            if (await _userManager.FindByNameAsync(createEmployeeDTO.Name) != null)
            {
                return Conflict($"Naam: '{createEmployeeDTO.Name}' is al in gebruik");
            }

            var userWithEmail = await _userManager.FindByEmailAsync(createEmployeeDTO.Email);
            if (userWithEmail != null)
            {
                return Conflict($"E-mail: '{createEmployeeDTO.Email}' is al in gebruik");
            }

            var result = await _userManager.CreateAsync(user, createEmployeeDTO.Password.Trim());

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "particuliere_huurder");
                await _userManager.UpdateAsync(user);
            }
            else
            {
                if (result.Errors.Any(e => e.Code == "DuplicateUserName"))
                {
                    return Conflict($"Naam '{createEmployeeDTO.Name}' is al in gebruikt");
                }

                var passwordErrors = result.Errors.Where(e => e.Code.StartsWith("Password"));
                if (passwordErrors.Any())
                {
                    return UnprocessableEntity($"Ongeldig wachtwoord: het moet minimaal 1 hoofdletter, een getal en een niet alfanumeriek character bevatten");
                }

                var errorMsg = string.Join(", ", result.Errors.Select(e => e.Description));
                Console.Error.WriteLine($"error: {errorMsg}");

                return BadRequest("Kan de medewerker niet aanmaken");
            }

            return CreatedAtAction(nameof(CreateEmployee), new { id = user.Id }, new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Role = createEmployeeDTO.Role,
            });
        }
    }
}
