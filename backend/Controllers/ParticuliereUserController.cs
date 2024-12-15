using backend.Data;
using backend.DTOs;
using backend.Models;
using backend.Rollen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            if (await _userManager.FindByNameAsync(huurderDTO.Name) != null)
            {
                return UnprocessableEntity($"Naam: '{huurderDTO.Name}' is al in gebruik");
            }

            var userWithEmail = await _userManager.FindByEmailAsync(huurderDTO.Email);
            if (userWithEmail != null)
            {
                return UnprocessableEntity($"E-mail: '{huurderDTO.Email}' is al in gebruik");
            }

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
        /// Returns the rent history of the current logged-in user.
        /// </summary>
        [Authorize(Roles = "particuliere_huurder")]
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
            if (user.ParticuliereHuurder == null)
            {
                return Ok(new Huuraanvraag[] { });
            }

            var huuraanvragen = await _context
                .Huuraanvragen
                .Where(h => h.ParticuliereHuurderId == user.ParticuliereHuurder.Id)
                .Include(h => h.Voertuig)
                .ToListAsync();

            var huuraanvragenDTOs = huuraanvragen.Select(h => new HuuraanvraagGeschiedenisDTO
            {
                Startdatum = h.Startdatum.ToString("dd-MM-yyyy"),
                Einddatum = h.Einddatum.ToString("dd-MM-yyyy"),
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

        [Authorize(Roles = "particuliere_huurder")]
        [HttpGet("notifications")]
        public async Task<ActionResult<List<NotificatieDTO>>> GetNotifications()
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

            _context.Entry(user).Reference(u => u.ParticuliereHuurder).Load();
            if (user.ParticuliereHuurder == null)
            {
                return Unauthorized("Verwacht particuliere gebruiker");
            }

            var aanvragen = await _context
                .Huuraanvragen
                // Only get the aanvragen from the current user if the user has not seen them yet.
                .Where(h => h.ParticuliereHuurderId == user.ParticuliereHuurder.Id && !h.Gezien)
                .Include(h => h.Voertuig)
                .ToListAsync();

            var notificaties = aanvragen
                .Select(h =>
                {
                    return new NotificatieDTO
                    {
                        Titel = "Omtrent: beoordeling over huuraavraag",
                        Melding = $"De huuraavraag over de {h.Voertuig.Merk} {h.Voertuig.Type} is beoordeeld: uw huuraanvraag is {(h.Geaccepteerd == true ? "geaccepteerd" : "geweigerd")}",
                    };
                })
                .ToList();

            return Ok(notificaties);
        }

        /// <summary>
        /// Will update the given user fields including the address and password fields, when the current password is provided.
        /// </summary>
        [Authorize(Roles = "particuliere_huurder")]
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
                if (await _userManager.FindByEmailAsync(huurderDTO.Email) != null)
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
                    return UnprocessableEntity("Vul het huidige wachtwoord in");
                }

                var pasChangeResult = await _userManager.ChangePasswordAsync(user, huurderDTO.CurrentPassword, huurderDTO.Password);
                
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
            } else
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

            return NoContent();
        }
    }
}
