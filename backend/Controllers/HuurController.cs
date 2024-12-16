using System.Security.Claims;
using backend.Data;
using backend.Models;
using backend.Rollen;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

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

    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<Huuraanvraag>>> GetHuuraanvragen()
    // {
    //     return await _context.Huuraanvragen.ToListAsync();
    // }
    //
    // [HttpGet("{id}")]
    // public async Task<ActionResult<Huuraanvraag>> GetHuuraanvraag(int id)
    // {
    //     var huuraanvraag = await _context.Huuraanvragen.FindAsync(id);
    //
    //     if (huuraanvraag == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     return huuraanvraag;
    // }
    //
    // [HttpPut("{id}")]
    // public async Task<IActionResult> PutHuuraanvraag(int id, Huuraanvraag huuraanvraag)
    // {
    //     if (id != huuraanvraag.Id)
    //     {
    //         return BadRequest();
    //     }
    //
    //     _context.Entry(huuraanvraag).State = EntityState.Modified;
    //
    //     try
    //     {
    //         await _context.SaveChangesAsync();
    //     }
    //     catch (DbUpdateConcurrencyException)
    //     {
    //         if (!HuuraanvraagExists(id))
    //         {
    //             return NotFound();
    //         }
    //         else
    //         {
    //             throw;
    //         }
    //     }
    //
    //     return NoContent();
    // }

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

            if (user.ZakelijkeHuurder.AbonnementId == null)
            {
                return Unauthorized("U bent niet gekoppeld aan een abonnementen. Bij problemen vraag, uw huurbeheerder om hulp.");
            }
        } else
        {
            _context.Entry(user).Reference((u => u.ParticuliereHuurder)).Load();
            if (user.ParticuliereHuurder == null)
            {
                return Unauthorized("Incorrecte gebruiker");
            }
        }

        if (huuraanvraagDto.VoertuigId > 0)
        {
            var vehicle = new Voertuig { Id = huuraanvraagDto.VoertuigId };
            _context.Voertuigen.Attach(vehicle);
            huuraanvraagDto.Voertuig = vehicle;
        }

        var huuraanvraag = new Huuraanvraag
        {
            Id = huuraanvraagDto.Id,
            ParticuliereHuurderId = user.ParticuliereHuurder?.Id,
            ZakelijkeHuurder = user.ZakelijkeHuurder?.Id,
            Voertuig = huuraanvraagDto.Voertuig,
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

        return CreatedAtAction(nameof(PostHuuraanvraag), new { id = huuraanvraagDto.Id }, huuraanvraagDto);
    }

    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteHuuraanvraag(int id)
    // {
    //     var huuraanvraag = await _context.Huuraanvragen.FindAsync(id);
    //     if (huuraanvraag == null)
    //     {
    //         return NotFound();
    //     }
    //
    //     _context.Huuraanvragen.Remove(huuraanvraag);
    //     await _context.SaveChangesAsync();
    //
    //     return NoContent();
    // }

    private bool HuuraanvraagExists(int id)
    {
        return _context.Huuraanvragen.Any(e => e.Id == id);
    }
}