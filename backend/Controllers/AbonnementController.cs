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

    
    [HttpGet("get")]
    public async Task<ActionResult<IEnumerable<Abonnement>>> GetAllAbonnementen()
    {
        return await _context.Abonnementen.ToListAsync();
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<AbonnementDTO>> GetAbonnement(int id)
    {
        var abonnement = await _context.Abonnementen.FindAsync(id);
        if (abonnement == null) return NotFound();

        return new AbonnementDTO{
            Naam = abonnement.Naam,
            PrijsPerMaand = abonnement.Prijs_per_maand,
            MaxHuurders = abonnement.Max_huurders,
            Soort = abonnement.Soort
        };
    }
    [Authorize]
    [HttpPost("create")]
    public async Task<ActionResult<AbonnementDTO>> CreateAbonnement(CreateAbonnementDTO abonnementDTO)
    {
        if (abonnementDTO.Soort != "prepaid" || abonnementDTO.Soort != "pay_as_you_go")
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
    [Authorize]
    [HttpPost("{id}/update")]
    public async Task<IActionResult> UpdateAbonnement(int id){
        var abonnement = await _context.Abonnementen.FindAsync(id);
        if (abonnement == null) return NotFound();

        //if (!abonnementDTO.HasData())
        //     {
        //         return BadRequest();
        //     }

        //     if (abonnementDTO.Id != id)
        //     {
        //         return BadRequest();
        //     } 
        // abonnement.Naam = abonnement.Naam;
        // abonnement.Max_huurders = abonnement.Max_huurders;
        // abonnement.Prijs_per_maand = abonnement.Prijs_per_maand;
        // abonnement.Soort = abonnement.Soort;

        // _context.Entry(abonnement).State = EntityState.Modified;

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

    [HttpDelete("{id}/delete")]
    public async Task<IActionResult> DeleteAbonnement(int id)
    {
        var abonnement = await _context.Abonnementen.FindAsync(id);
        if (abonnement == null) return NotFound();

        _context.Remove(abonnement);

        await _context.SaveChangesAsync();
        return NoContent();
    }
}

//async function callBedrijfAbonnementAanmaken(setResponse) {
//     debugger;
//     const request = {
//         method: 'POST',
//         credentials: 'include', // TODO: change to 'same-origin' when in production.
//         headers: {
//             'Content-Type': 'application/json',
//         },
//     };

//     try {
//         const response = await fetch(`https://localhost:53085/api/Abonnement/create`, request);

//         if (response.ok) {
//             setResponse({
//                 msg: 'Abonnement aangemaakt',
//                 isError: false,
//             });

//             return true;
//         } else {
//             setResponse({
//                 msg: await response.text(),
//                 isError: true,
//             });
//         }
//     } catch {
//         setResponse({
//             msg: 'Er is een servererror opgetreden',
//             isError: true,
//         });
//     }

//     return false;
// }