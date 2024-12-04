using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Eventing.Reader;
using System.Security.Claims;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticuliereUserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RentalContext _context;
        private readonly ILogger<ParticuliereUserController> _logger;

        public ParticuliereUserController(RentalContext context, UserManager<User> userManager, ILogger<ParticuliereUserController> logger)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Creates a new user with a relation to the ParticuliereHuurders table and the particuliere_huurder role.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult> Register(RegisterParticuliereHuurderDTO huurderDTO)
        {
            var user = new User
            {
                UserName = huurderDTO.Name.Trim(),
                Email = huurderDTO.Email.ToLower().Trim(),
                PhoneNumber = huurderDTO.PhoneNumber.Trim(),
            };

            var result = await _userManager.CreateAsync(user, huurderDTO.Password.Trim());

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "particuliere_huurder");

                // When the user has been created: make a ParticuliereHuurder.
                var particuliereHuurder = new ParticuliereHuurder
                {
                    Id = 0, // The orm will define the id for us.
                    Address = huurderDTO.Address,
                };
                await _context.ParticuliereHuurders.AddAsync(particuliereHuurder);
                await _context.SaveChangesAsync();

                user.ParticuliereHuurder = particuliereHuurder;
                await _userManager.UpdateAsync(user);
            }
            else
            {
                if (result.Errors.Any(e => e.Code == "DuplicateUserName"))
                {
                    return BadRequest($"Naam '{huurderDTO.Name}' is al in gebruikt");
                }

                var passwordErrors = result.Errors.Where(e => e.Code.StartsWith("Password"));
                if (passwordErrors.Any())
                {
                    return BadRequest($"Ongeldig wachtwoord: het moet minimaal 1 hoofdletter, een getal en een niet alfanumeriek character bevatten");
                }

                var errorMsg = string.Join(", ", result.Errors.Select(e => e.Description));
                Console.Error.WriteLine($"error: {errorMsg}");

                return BadRequest("Kan de gebruikern niet aanmaken");
            }

            return CreatedAtAction(nameof(Register), new { id = user.Id }, new ParticuliereHuurderDTO(user.Id, huurderDTO));
        }

        /// <summary>
        /// Will delete the user and related data.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await _context.Entry(user).Reference(u => u.ParticuliereHuurder).LoadAsync();

            if (user.ParticuliereHuurder != null)
            {
                _context.ParticuliereHuurders.Remove(user.ParticuliereHuurder);
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                await _context.SaveChangesAsync(); // Remove related data.
                return NoContent();
            }

            return BadRequest();
        }

        // TODO: replace this endpoint to a user controller, for all users.
        /// <summary>
        /// Attempts to return the user data of the current logged in user.
        /// </summary>
        [Authorize]
        [HttpGet("user")]
        public async Task<ActionResult> GetUserInfo()
        {
            var CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (CurrentUserId == null)
            {
                return Unauthorized("Kan gebruiker niet vinden");
            }

            var CurrentUserName = User.FindFirstValue(ClaimTypes.Name);
            var CurrentUserRole= User.FindFirstValue(ClaimTypes.Role);

            return Ok(new
            {
                UserId = CurrentUserId,
                UserName = CurrentUserName,
                Role = CurrentUserRole,
            });
        }

        /// <summary>
        /// Will update the given user fields including the address and password fields, when the current password is provided.
        /// </summary>
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(string id, UpdateParticuliereHuurderDTO huurderDTO)
        {
            if (!huurderDTO.HasData())
            {
                return BadRequest("Geen data ontvangen");
            }

            if (huurderDTO.Id != id)
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

            if (CurrentUserId != id)
            {
                return Unauthorized("Kan gebruiker niet vinden");
            }

            user.UserName = huurderDTO.UserName ?? user.UserName;
            user.Email = huurderDTO.Email ?? user.Email;
            user.PhoneNumber = huurderDTO.PhoneNumber ?? user.PhoneNumber;

            if (huurderDTO.UserName != null)
            {
                if (await _userManager.FindByNameAsync(huurderDTO.UserName) != null)
                {
                    return UnprocessableEntity($"Naam: '{huurderDTO.UserName}' is al in gebruik");
                }
            }

            if (huurderDTO.Email != null)
            {
                if (await _userManager.FindByNameAsync(huurderDTO.Email) != null)
                {
                    return UnprocessableEntity($"E-mail: '{huurderDTO.Email}' is al in gebruik");
                }
            }

            if (huurderDTO.Address != null)
            {
                await _context.Entry(user).Reference(u => u.ParticuliereHuurder).LoadAsync();
                if (user.ParticuliereHuurder != null)
                {
                    user.ParticuliereHuurder.Address = huurderDTO.Address;
                }
            }

            if (huurderDTO.Password != null)
            {
                if (huurderDTO.CurrentPassword == null)
                {
                    return BadRequest("Vul het huidige wachtwoord in");
                }

                // TODO: return password mismatch error and other errors.
                await _userManager.ChangePasswordAsync(user, huurderDTO.CurrentPassword, huurderDTO.Password);
            }

            // TODO: figure out if this should be replaced with the _userManager.
            //_context.Entry(user).State = EntityState.Modified;
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                await _userManager.UpdateNormalizedEmailAsync(user);
                await _userManager.UpdateNormalizedUserNameAsync(user);
            } else
            {
                var errorMsg = string.Join(", ", result.Errors.Select(e => e.Description));
                Console.Error.WriteLine($"error: {errorMsg}");

                return BadRequest("Kan de gebruiker niet updaten");
            }

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!_context.Users.Any(u => u.Id == id))
            //    {
            //        return NotFound();
            //    } else
            //    {
            //        throw;
            //    }
            //}

            return NoContent();
        }
    }
}
