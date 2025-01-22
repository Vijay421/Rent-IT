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

        [HttpGet("profiel")]
        public async Task<ActionResult> Profile()
        {
            var CurrentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (CurrentUserId == null)
            {
                return Unauthorized("Kan gebruiker niet vinden");
            }

            var user = await _userManager.FindByIdAsync(CurrentUserId);
            if (user == null)
            {
                return NotFound("Kan gebruiker niet vinden");
            }

            _context.Entry(user).Reference(u => u.ParticuliereHuurder).Load();
            
            _context.Entry(user).Reference(u => u.ZakelijkeHuurder).Load();
            if (user.ZakelijkeHuurder != null)
            {
                _context.Entry(user.ZakelijkeHuurder).Reference(h => h.Abonnement).Load();
            }
            
            _context.Entry(user).Reference(u => u.Huurbeheerder).Load();
            if (user.Huurbeheerder != null)
            {
                _context.Entry(user.Huurbeheerder).Reference(h => h.Bedrijf).Load();
            }
            
            _context.Entry(user).Reference(u => u.Bedrijf).Load();
            
            _context.Entry(user).Reference(u => u.BackOffice).Load();
            
            _context.Entry(user).Reference(u => u.Frontoffice).Load();

            return Ok(new
            {
                UserName = user.UserName ?? null,
                Email = user.Email ?? null,
                PhoneNumber = user.PhoneNumber ?? null,
        
                BedrijfName = user.Bedrijf?.Name ?? null,
                BedrijfAddress = user.Bedrijf?.Address ?? null,
                BedrijfKVKNumber = user.Bedrijf?.KvK_nummer ?? null,
                BedrijfPhoneNumber = user.Bedrijf?.PhoneNumber ?? null,
                BedrijfDomein = user.Bedrijf?.Domein ?? null,
        
                ZhuurderAbonnement = user.ZakelijkeHuurder?.Abonnement?.Naam ?? null,
                ZhuurderFactuurAddress = user.ZakelijkeHuurder?.Factuuradres ?? null,
        
                PhuurderAddress = user.ParticuliereHuurder?.Address ?? null,
        
                ZbeheerderBedrijfsrol = user.Huurbeheerder?.Bedrijfsrol ?? null,
                ZbeheerderBedrijf = user.Huurbeheerder?.Bedrijf?.Name ?? null,  
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

            if (role == "admin" || role == "backoffice_medewerker")
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

            if (role == "bedrijf")
            {
                await _context.Entry(user).Reference(u => u.Bedrijf).LoadAsync();
                if (user.Bedrijf != null)
                {
                    user.Bedrijf.Name = updateUserDTO.CompanyName?? user.Bedrijf.Name;
                    user.Bedrijf.Address = updateUserDTO.CompanyAddress ?? user.Bedrijf.Address;
                    user.Bedrijf.KvK_nummer= updateUserDTO.CompanyNumber ?? user.Bedrijf.KvK_nummer;
                    user.Bedrijf.PhoneNumber = updateUserDTO.CompanyPhoneNumber ?? user.Bedrijf.PhoneNumber;
                    user.Bedrijf.Domein = updateUserDTO.Domein ?? user.Bedrijf.Domein;
                }
            }
            
            if (role == "zakelijke_beheerder")
            {
                await _context.Entry(user).Reference(u => u.Huurbeheerder).LoadAsync();
                if (user.Huurbeheerder != null)
                {
                    user.Huurbeheerder.Bedrijfsrol = updateUserDTO.Bedrijfsrol ?? user.Huurbeheerder.Bedrijfsrol;
                }
            }

            if (role == "zakelijke_huurder")
            {
                await _context.Entry(user).Reference(u => u.ZakelijkeHuurder).LoadAsync();
                if (user.ZakelijkeHuurder != null)
                {
                    user.ZakelijkeHuurder.Factuuradres = updateUserDTO.Factuuradres ?? user.ZakelijkeHuurder.Factuuradres;
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

        /// <summary>
        /// Returns users who are renters.
        /// </summary>
        [Authorize(Roles = "zakelijke_beheerder")]
        [HttpGet("huurders")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetRenters()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (id == null)
            {
                return NotFound("Kan de gebruiker niet vinden");
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound("Kan de gebruiker niet vinden");
            }

            _context.Entry(user).Reference(u => u.Huurbeheerder).Load();
            if (user.Huurbeheerder == null)
            {
                return Unauthorized("Incorrecte gebruiker");
            }

            _context.Entry(user.Huurbeheerder).Reference(h => h.Bedrijf).Load();
            if (user.Huurbeheerder.Bedrijf == null)
            {
                return UnprocessableEntity("Huidige gebruiker is niet gekoppeld aan een bedrijf");
            }

            var domein = user.Huurbeheerder.Bedrijf.Domein;

            var huurders = await _context
                .Users
                .Include(u => u.ParticuliereHuurder)
                .Include(u => u.ZakelijkeHuurder)
                .Where(u => (u.ParticuliereHuurder != null || u.ZakelijkeHuurder != null) && u.Email.Contains(domein))
                .Select(u => new UserDTO
                {
                    Id = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                })
                .ToListAsync();

            return Ok(huurders);
        }

        /// <summary>
        /// Returns the rent history of the current logged-in user.
        /// </summary>
        [Authorize(Roles = "particuliere_huurder, zakelijke_huurder")]
        [HttpGet("rent-history")]
        public async Task<ActionResult<IEnumerable<HuuraanvraagGeschiedenisDTO>>> GetRentHistory()
        {
            var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (currentUserId == null)
            {
                return NotFound("Kan de gebruiker niet vinden");
            }

            var user = await _userManager.FindByIdAsync(currentUserId);
            if (user == null)
            {
                return NotFound("Kan de gebruiker niet vinden");
            }

            await _context.Entry(user).Reference(u => u.ParticuliereHuurder).LoadAsync();
            await _context.Entry(user).Reference(u => u.ZakelijkeHuurder).LoadAsync();
            if (user.ParticuliereHuurder == null && user.ZakelijkeHuurder == null)
            {
                return Ok(new Huuraanvraag[] { });
            }

            var pId = user.ParticuliereHuurder?.Id;
            var zId = user.ZakelijkeHuurder?.Id;

            var huuraanvragen = await _context
                .Huuraanvragen
                .Where(h => h.ParticuliereHuurderId == pId || h.ZakelijkeHuurder == zId)
                .Include(h => h.Voertuig)
                .ToListAsync();

            var huuraanvragenDTOs = huuraanvragen.Select(h => new HuuraanvraagGeschiedenisDTO
            {
                Startdatum = h.Startdatum,
                Einddatum = h.Einddatum,
                Reisaard = h.Reisaard,
                Merk = h.Voertuig.Merk,
                Type = h.Voertuig.Type,
                Kenteken = h.Voertuig.Kenteken,
                Kleur = h.Voertuig.Kleur,
                Aanschafjaar = h.Voertuig.Aanschafjaar,
                Soort = h.Voertuig.Soort,
                Prijs = h.Voertuig.Prijs,
            });

            return Ok(huuraanvragenDTOs);
        }
    }
}
