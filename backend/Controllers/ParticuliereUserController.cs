﻿using backend.Data;
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
                    string message;
                    if (h.Geaccepteerd == null)
                    {
                        message = "in behandiling";
                    } else if (h.Geaccepteerd == true)
                    {
                        message = "geaccepteerd";
                    }
                    else
                    {
                        message = "geweigerd";
                    }
                    return new NotificatieDTO
                    {
                        Titel = "Omtrent: beoordeling over huuraavraag",
                        Melding = $"De huuraavraag over de {h.Voertuig.Merk} {h.Voertuig.Type} is beoordeeld: uw huuraanvraag is {message}",
                    };
                })
                .ToList();

            return Ok(notificaties);
        }
    }
}
