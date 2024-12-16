using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AbonnementController : ControllerBase
{
    private readonly RentalContext _context;
    private readonly UserManager<User> _userManager;

    public AbonnementController(RentalContext context, UserManager<User> userManager)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _userManager = userManager;
    }

    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AbonnementDTO>>> GetAllAbonnementen()
    {
        return await _context
            .Abonnementen
            .Select(a => new AbonnementDTO
            {
                Id = a.Id,
                Naam = a.Naam,
                PrijsPerMaand = a.Prijs_per_maand,
                MaxHuurders = a.Max_huurders,
                Einddatum = a.Einddatum,
                Soort = a.Soort
            })
            .ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AbonnementDTO>> GetAbonnement(int id)
    {
        var abonnement = await _context.Abonnementen.FindAsync(id);
        if (abonnement == null) return NotFound();

        return new AbonnementDTO
        {
            Id = abonnement.Id,
            Naam = abonnement.Naam,
            PrijsPerMaand = abonnement.Prijs_per_maand,
            MaxHuurders = abonnement.Max_huurders,
            Einddatum = abonnement.Einddatum,
            Soort = abonnement.Soort
        };
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<Abonnement>> CreateAbonnement(CreateAbonnementDTO abonnementDTO)
    {
        var today = DateOnly.FromDateTime(DateTime.Today);
        if (abonnementDTO.Einddatum < today)
        {
            return BadRequest("Kan geen abonnement instellen in het verleden");
        }

        if (abonnementDTO.Soort != "prepaid" && abonnementDTO.Soort != "pay_as_you_go")
        {
            return BadRequest("Soort moet gelijk zijn aan 'prepaid' of 'pay as you go'");
        }

        var abonnement = new Abonnement
        {
            Id = 0,
            Naam = abonnementDTO.Naam,
            // TODO: figure out what Prijs_per_maand should be.
            //Prijs_per_maand = abonnementDTO.Prijs_per_maand,
            Prijs_per_maand = 100.0,
            Max_huurders = abonnementDTO.Max_huurders,
            Einddatum = abonnementDTO.Einddatum,
            Soort = abonnementDTO.Soort,
        };

        _context.Abonnementen.Add(abonnement);
        await _context.SaveChangesAsync();

        var role = User.FindFirstValue(ClaimTypes.Role);
        if (role == null)
        {
            return Unauthorized("Kan de gebruiker niet vinden");
        }

        var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (id == null)
        {
            return Unauthorized("Kan de gebruiker niet vinden");
        }

        // Add Abonnement to Huurbeheerder, if the current user is a Huurbeheerder.
        if (role == "zakelijke_beheerder")
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound("Kan de gebruiker niet vinden");
            }

            _context.Entry(user).Reference(u => u.Huurbeheerder).Load();
            if (user.Huurbeheerder != null)
            {
                user.Huurbeheerder.Abonnement.Add(abonnement);
                _context.Entry(user.Huurbeheerder).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        return CreatedAtAction(nameof(CreateAbonnement), new {id = abonnement.Id}, abonnement);
    }

    [Authorize(Roles = "zakelijke_beheerder")]
    [HttpGet("company")]
    public async Task<ActionResult<IEnumerable<AbonnementPerZakelijkeHuurderDTO>>> GetCompanyAbonnementen()
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

        var abonnementen = await _context
            .Abonnementen
            .Where(a => a.HuurbeheerderId == user.Huurbeheerder.Id)
            .Include(a => a.ZakelijkeHuurders)
            .Select(a => new AbonnementPerZakelijkeHuurderDTO
                {
                    Id = a.Id,
                    Naam = a.Naam,
                    PrijsPerMaand = a.Prijs_per_maand,
                    MaxHuurders = a.Max_huurders,
                    Einddatum = a.Einddatum,
                    Soort = a.Soort,
                    ZakelijkeHuurders = a.ZakelijkeHuurders.Select(z => z.UserId).ToList(),
                }
            )
            .ToListAsync();

        return Ok(abonnementen);
    }

    [Authorize(Roles = "zakelijke_beheerder")]
    [HttpPut("renters/{abonnementId}")]
    public async Task<ActionResult> UpdateRenters(int abonnementId, List<string> renters)
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

        var abonnement = await _context.Abonnementen.FindAsync(abonnementId);
        if (abonnement == null)
        {
            return NotFound("Geen abonnement gevonden");
        }
        _context.Entry(abonnement).Collection(a => a.ZakelijkeHuurders).Load();

        _context.Entry(user.Huurbeheerder).Collection(z => z.ZakelijkeHuurders).Load();

        foreach (var renter in renters)
        {
            var isRenterOfUser = user
                .Huurbeheerder
                .ZakelijkeHuurders
                .Any(z => z.UserId == renter);

            if (!isRenterOfUser)
            {
                return BadRequest($"Zakelijke huurder met id '{renter}' hoort niet bij de huidige beheerder");
            }
        }

        var huuders = await _context.ZakelijkeHuurders.Where(z => renters.Contains(z.UserId)).ToListAsync();
        if (huuders.Count() > abonnement.Max_huurders)
        {
            return BadRequest($"Maximum aantal huurders overschreden, maximum: {abonnement.Max_huurders}, geselecteerd aantal huurders: {huuders.Count()}");
        }

        abonnement.ZakelijkeHuurders = huuders;
        _context.Entry(abonnement).State = EntityState.Modified;

        try
        {
            _context.Update(abonnement);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Abonnementen.Any(a => a.Id == abonnementId))
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

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAbonnement(int id, UpdateAbonnementDTO abonnementDTO)
    {
        if (abonnementDTO.Einddatum != null)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            if (abonnementDTO.Einddatum < today)
            {
                return BadRequest("Kan geen abonnement instellen in het verleden");
            }
        }

        if (abonnementDTO.Soort != null)
        {
            if (abonnementDTO.Soort != "prepaid" && abonnementDTO.Soort != "pay_as_you_go")
            {
                return BadRequest("Soort moet gelijk zijn aan 'prepaid' of 'pay as you go'");
            }
        }

        var abonnement = await _context.Abonnementen.FindAsync(id);
        if (abonnement == null) return NotFound();

        abonnement.Naam = abonnementDTO.Naam ?? abonnement.Naam;
        abonnement.Prijs_per_maand = abonnementDTO.Prijs_per_maand ?? abonnement.Prijs_per_maand;
        abonnement.Einddatum = abonnementDTO.Einddatum ?? abonnement.Einddatum;
        abonnement.Soort = abonnementDTO.Soort ?? abonnement.Soort;

        _context.Entry(abonnement).State = EntityState.Modified;

        try
        {
            _context.Update(abonnement);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Abonnementen.Any(a => a.Id == id))
            {
                return NotFound();
            } else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAbonnement(int id)
    {
        var abonnement = await _context.Abonnementen.FindAsync(id);
        if (abonnement == null) return NotFound();

        _context.Remove(abonnement);

        await _context.SaveChangesAsync();
        return NoContent();
    }
}
