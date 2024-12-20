using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
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
        /// Allows admins to delete user.
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
                if (currentUserId != id)
                {
                    return Unauthorized("Kan de gebruiker niet vinden");
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
    }
}
