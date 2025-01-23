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
    [Authorize(Roles = "zakelijke_beheerder")]
    [Route("api/[controller]")]
    [ApiController]
    public class HuurBeheerderController : ControllerBase
    {
        private readonly RentalContext _context;
        private readonly UserManager<User> _userManager;

        public HuurBeheerderController(RentalContext context, UserManager<User> userManager)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userManager = userManager;
        }

        [HttpGet("bedrijf")]
        public async Task<ActionResult<string>> GetBedrijfsnaam()
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

            _context.Entry(user).Reference(u => u.Huurbeheerder).Load();
            _context.Entry(user.Huurbeheerder).Reference(h => h.Bedrijf).Load();

            return Ok(new
            {
                Bedrijfsnaam = user.Huurbeheerder.Bedrijf.Name,
                Kvk = user.Huurbeheerder.Bedrijf.KvK_nummer,
                Adres = user.Huurbeheerder.Bedrijf.Address,
            });
        }
        
        [HttpGet("werknemer_geschiedenis")]
        public async Task<ActionResult<IEnumerable<Huuraanvraag>>> GetHuuraanvraagGeschiedenis()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null)
            {
                return NotFound("Kan de gebruiker niet vinden");
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("Kan de gebruiker niet vinden");
            }

            _context.Entry(user).Reference(u => u.Huurbeheerder).Load();
            if (user.Huurbeheerder == null)
            {
                return Unauthorized("Incorrecte gebruiker");
            }

            var huurbeheerderId = user.Huurbeheerder.Id;
            
            var zakelijkeHuurders = await _context.ZakelijkeHuurders
                .Include(zh => zh.Abonnement)
                .Where(zh => zh.HuurbeheerderId == huurbeheerderId)
                .ToListAsync();

            if (!zakelijkeHuurders.Any())
            {
                return NotFound("Geen zakelijke huurders gevonden voor de huurbeheerder");
            }
            
            var zakelijkeHuurderIds = zakelijkeHuurders.Select(zh => zh.Id).ToList();

            var huuraanvragen = await _context.Huuraanvragen
                .Where(ha => zakelijkeHuurderIds.Contains(ha.ZakelijkeHuurder ?? 0))
                .Include(ha => ha.Voertuig)
                .OrderByDescending(ha => ha.VeranderDatum)
                .ToListAsync();

            if (!huuraanvragen.Any())
            {
                return NotFound("Geen huuraanvragen gevonden voor de zakelijke huurders");
            }

            return Ok(huuraanvragen);
        }
    }
}
