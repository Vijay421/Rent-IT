using System.Security.Claims;
using backend.Data;
using backend.Models;
using backend.Rollen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;
[Authorize(Roles = "particuliere_huurder, zakelijke_huurder, backoffice_medewerker")]
[ApiController]
[Route("api/[controller]")]
public class HuurController : ControllerBase
{
    private readonly RentalContext _context;
    private readonly UserManager<User> _userManager;

    
    public HuurController(RentalContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Huuraanvraag>>> GetHuuraanvragen()
    {
        var huuraanvragen = await _context.Huuraanvragen
            .Include(h => h.Voertuig)
            .ToListAsync();

        return Ok(huuraanvragen.Select(h => new
        {
            Voertuig = new
            {
                Merk = h.Voertuig.Merk,
                Type = h.Voertuig.Type,
                Kenteken = h.Voertuig.Kenteken,
                Kleur = h.Voertuig.Kleur,
                Aanschafjaar = h.Voertuig.Aanschafjaar,
                Soort = h.Voertuig.Soort,
                Status = h.Voertuig.Status,
                Prijs = h.Voertuig.Prijs,
                StartDatum = h.Startdatum,
                EindDatum = h.Einddatum,
            },
            Wettelijke_naam = h.Wettelijke_naam
        }));
    }
    
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Huuraanvraag>>> GetHuuraanvraag()
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
        
        var CurrentUserRole = User.FindFirstValue(ClaimTypes.Role);
        if (CurrentUserRole == null)
        {
            return Unauthorized("Kan rol niet vinden");
        }

        var huuraanvragen = new List<Huuraanvraag>();
        
        if (CurrentUserRole == "particuliere_huurder")
        {
            _context.Entry(user).Reference(u => u.ParticuliereHuurder).Load();
            if (user.ParticuliereHuurder == null)
            {
                return Unauthorized("Verkeerde rol");
            }

            huuraanvragen = await _context.Huuraanvragen
                .Where(h => h.ParticuliereHuurderId == user.ParticuliereHuurder.Id)
                .Include(h => h.Voertuig)
                .ToListAsync();

        }
        
        if (CurrentUserRole == "zakelijke_huurder")
        {
            _context.Entry(user).Reference(u => u.ZakelijkeHuurder).Load();
            if (user.ZakelijkeHuurder == null)
            {
                return Unauthorized("Verkeerde rol");
            }

            huuraanvragen = await _context.Huuraanvragen
                .Where(h => h.ZakelijkeHuurder == user.ZakelijkeHuurder.Id)
                .Include(h => h.Voertuig)
                .ToListAsync();
        }

        return Ok(huuraanvragen);
    }

    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHuuraanvraag(int id, Huuraanvraag updatedHuuraanvraag)
    {
        if (id != updatedHuuraanvraag.Id)
        {
            return BadRequest();
        }

        var currentHuuraanvraag = await _context.Huuraanvragen
            .Include(h => h.Voertuig)
            .FirstOrDefaultAsync(h => h.Id == id);

        if (currentHuuraanvraag == null)
        {
            return NotFound("Huuraanvraag not found");
        }

        if (currentHuuraanvraag.VoertuigId != updatedHuuraanvraag.VoertuigId)
        {
            var previousVehicle = await _context.Voertuigen.FindAsync(currentHuuraanvraag.VoertuigId);
            var newVehicle = await _context.Voertuigen.FindAsync(updatedHuuraanvraag.VoertuigId);

            if (previousVehicle != null)
            {
                previousVehicle.Status = "Verhuurbaar";
                _context.Voertuigen.Update(previousVehicle);
            }

            if (newVehicle != null)
            {
                newVehicle.Status = "Onverhuurbaar";
                _context.Voertuigen.Update(newVehicle);
            }
        }

        _context.Entry(currentHuuraanvraag).CurrentValues.SetValues(updatedHuuraanvraag);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!HuuraanvraagExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }


    [Authorize(Roles = "particuliere_huurder, zakelijke_huurder")]
    [HttpPost]
    public async Task<ActionResult<Huuraanvraag>> PostHuuraanvraag(HuuraanvraagDTO huuraanvraagDto)
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

        var role = User.FindFirstValue(ClaimTypes.Role);
        if (role == null)
        {
            return Unauthorized("Incorrecte gebruiker");
        }
        if (role == "zakelijke_huurder")
        {
            _context.Entry(user).Reference((u => u.ZakelijkeHuurder)).Load();
            if (user.ZakelijkeHuurder == null)
            {
                return Unauthorized("Incorrecte gebruiker");
            }

            _context.Entry(user.ZakelijkeHuurder).Reference((z => z.Abonnement)).Load();
            if (user.ZakelijkeHuurder.Abonnement == null)
            {
                return Unauthorized("U bent niet gekoppeld aan een abonnementen. Bij problemen vraag, uw huurbeheerder om hulp.");
            }

            // Explicit check, which has to happen because Geaccepteerd is nullable.
            var accepted = user.ZakelijkeHuurder.Abonnement.Geaccepteerd;
            if (accepted == null)
            {
                return Unauthorized("Het gekoppelde abonnement is (nog) niet goed gekeurd.");
            }
            if (accepted == false)
            {
                return Unauthorized("Kan geen voertuig huren met een afgekeurd abonnement.");
            }
        }
        else
        {
            _context.Entry(user).Reference((u => u.ParticuliereHuurder)).Load();
            if (user.ParticuliereHuurder == null)
            {
                return Unauthorized("Incorrecte gebruiker");
            }
        }

        if (huuraanvraagDto.VoertuigId > 0)
        {
            var vehicle = await _context.Voertuigen.FindAsync(huuraanvraagDto.VoertuigId);
            if (vehicle == null || vehicle.VerwijderdDatum != null)
            {
                return NotFound("Voertuig niet gevonden.");
            }

            vehicle.Status = "Onverhuurbaar";
            _context.Voertuigen.Update(vehicle);
        }

        var huuraanvraag = new Huuraanvraag
        {
            Id = huuraanvraagDto.Id,
            ParticuliereHuurderId = user.ParticuliereHuurder?.Id,
            ZakelijkeHuurder = user.ZakelijkeHuurder?.Id,
            VoertuigId = huuraanvraagDto.VoertuigId,
            Startdatum = huuraanvraagDto.Startdatum,
            Einddatum = huuraanvraagDto.Einddatum,
            Wettelijke_naam = huuraanvraagDto.Wettelijke_naam,
            Adresgegevens = huuraanvraagDto.Adresgegevens,
            Rijbewijsnummer = huuraanvraagDto.Rijbewijsnummer,
            Reisaard = huuraanvraagDto.Reisaard,
            Vereiste_bestemming = huuraanvraagDto.Vereiste_bestemming,
            Verwachte_km = huuraanvraagDto.Verwachte_km,
            Geaccepteerd = huuraanvraagDto.Geaccepteerd,
            Reden = huuraanvraagDto.Reden,
            VeranderDatum = huuraanvraagDto.VeranderDatum,
            Gezien = huuraanvraagDto.Gezien
        };

        _context.Huuraanvragen.Add(huuraanvraag);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(PostHuuraanvraag), new { id = huuraanvraag.Id }, huuraanvraag);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHuuraanvraag(int id)
    {
        var huuraanvraag = await _context.Huuraanvragen.FindAsync(id);
        if (huuraanvraag == null)
        {
            return NotFound();
        }
    
        _context.Huuraanvragen.Remove(huuraanvraag);
        await _context.SaveChangesAsync();
    
        return NoContent();
    }

    private bool HuuraanvraagExists(int id)
    {
        return _context.Huuraanvragen.Any(e => e.Id == id);
    }
    
    
}