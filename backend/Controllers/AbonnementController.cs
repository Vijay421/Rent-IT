using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AbonnementController : ControllerBase
{
    private readonly RentalContext _context;
    
    public AbonnementController(RentalContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
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

    //TODO add: [Authorize(Roles = "zakelijke_beheerder")]
    [HttpPost]
    public async Task<ActionResult<AbonnementDTO>> CreateAbonnement(CreateAbonnementDTO abonnementDTO)
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
            Prijs_per_maand = abonnementDTO.Prijs_per_maand,
            Max_huurders = abonnementDTO.Max_huurders,
            Einddatum = abonnementDTO.Einddatum,
            Soort = abonnementDTO.Soort,
        };

        _context.Abonnementen.Add(abonnement);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(CreateAbonnement), new {id = abonnement.Id}, abonnement);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAbonnement(int id, UpdateAbonnement abonnementDTO)
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
            if (!_context.Abonnementen.Any(u => u.Id == id))
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
