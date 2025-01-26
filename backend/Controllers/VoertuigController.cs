using System.Collections;
using System.Security.Claims;
using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VoertuigController : ControllerBase
{
    private readonly RentalContext _context;
    private readonly UserManager<User> _userManager;

    public VoertuigController(RentalContext context, UserManager<User> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<List<Voertuig>> GetAllCars()
    {
       
        var vehicles = await _context
            .Voertuigen
            .Where(v => v.VerwijderdDatum == null)
            .ToListAsync();

        var role = User.FindFirstValue(ClaimTypes.Role);
        if (role == null)
        {
            return vehicles;
        }

        if (role == "zakelijke_huurder")
        {
            return vehicles.Where(c => c.Soort == "Auto").ToList();
        }

        return vehicles;
    }
//    [HttpGet]
//     public async Task<List<Voertuig>> GetAllCarsFrontOffice()
//     {
       
//         var cars = await _rentalContext.Voertuigen
//         // .Where(Voertuig goedgekeurd moet worden door FrontOffice)
//         .ToListAsync();

//         var role = User.FindFirstValue(ClaimTypes.Role);
//         if (role == null)
//         {
//             return cars;
//         }

//         if (role == "zakelijke_huurder")
//         {
//             return cars.Where(c => c.Soort == "Auto").ToList();
//         }

//         return cars;
//     }
    [HttpGet("{id}")]
    public async Task<ActionResult<Voertuig>> GetOneCar(int id)
    {
        var vehicle = await _context.Voertuigen.FindAsync(id);

        if (vehicle == null)
        {
            return NotFound();
        }

        return vehicle;
    }


    // [HttpGet("registraties")]
    // public async Task<List<Voertuig>> GetAllCarsInname()
    // {
    //     var cars = await _rentalContext.Voertuigen
    //     // .Join(Voertuigregistratie)
    //     .ToListAsync();

    //     var role = User.FindFirstValue(ClaimTypes.Role);
    //     if (role == null)
    //     {
    //         return cars;
    //     }

    //     if (role == "zakelijke_huurder")
    //     {
    //         return cars.Where(c => c.Soort == "Auto").ToList();
    //     }

    //     return cars;
    // }

    [Authorize(Roles = "backoffice_medewerker")]
    [HttpPost]
    public async Task<ActionResult<Voertuig>> Create(Voertuig voertuig)
    {
        if (voertuig.Aanschafjaar > DateTime.Now.Year)
        {
            return UnprocessableEntity("Aanschafjaar kan niet later plaatsvinden dan dit jaar.");
        }

        if (voertuig.StartDatum > voertuig.EindDatum)
        {
            return UnprocessableEntity("Einddatum kan niet eerder zijn dan startdatum.");
        }

        _context.Voertuigen.Add(voertuig);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Create), new { id = voertuig.Id }, voertuig);
    }

    [Authorize(Roles = "backoffice_medewerker")]
    [HttpPut("{id}")]
    public async Task<ActionResult<Voertuig>> Update(int id, UpdateVoertuigDTO voertuigDTO)
    {
        var voertuig = await _context.Voertuigen.FindAsync(id);
        if (voertuig == null)
        {
            return NotFound($"Geen voertuig gevonden met id: '{id}'");
        }

        if (voertuigDTO.Aanschafjaar != null)
        {
            if (voertuigDTO.Aanschafjaar > DateTime.Now.Year)
            {
                return UnprocessableEntity("Aanschafjaar kan niet later plaatsvinden dan dit jaar.");
            }
        }

        if (voertuigDTO.StartDatum != null && voertuigDTO.EindDatum != null)
        {
            if (voertuigDTO.StartDatum > voertuigDTO.EindDatum)
            {
                return UnprocessableEntity("Einddatum kan niet eerder zijn dan startdatum.");
            }
        }

        if (voertuigDTO.StartDatum != null && voertuigDTO.EindDatum == null)
        {
            if (voertuigDTO.StartDatum > voertuig.EindDatum)
            {
                return UnprocessableEntity("Einddatum kan niet eerder zijn dan startdatum.");
            }
        }

        if (voertuigDTO.StartDatum == null && voertuigDTO.EindDatum != null)
        {
            if (voertuig.StartDatum > voertuigDTO.EindDatum)
            {
                return UnprocessableEntity("Einddatum kan niet eerder zijn dan startdatum.");
            }
        }

        voertuig.Merk = voertuigDTO.Merk ?? voertuig.Merk;
        voertuig.Type = voertuigDTO.Type ?? voertuig.Type;
        voertuig.Kenteken = voertuigDTO.Kenteken ?? voertuig.Kenteken;
        voertuig.Kleur = voertuigDTO.Kleur ?? voertuig.Kleur;
        voertuig.Aanschafjaar = voertuigDTO.Aanschafjaar ?? voertuig.Aanschafjaar;
        voertuig.Soort = voertuigDTO.Soort ?? voertuig.Soort;
        voertuig.Opmerking = voertuigDTO.Opmerking ?? voertuig.Opmerking;
        voertuig.Status = voertuigDTO.Status ?? voertuig.Status;
        voertuig.Prijs = voertuigDTO.Prijs ?? voertuig.Prijs;
        voertuig.StartDatum = voertuigDTO.StartDatum ?? voertuig.StartDatum;
        voertuig.EindDatum = voertuigDTO.EindDatum ?? voertuig.EindDatum;

        try
        {
            _context.Update(voertuig);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Voertuigen.Any(a => a.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return Ok(voertuig);
    }

    /// <summary>
    /// Will soft delete the vehicle, which means that the vehicle will be excluded from renting but its data is available in the database.
    /// </summary>
    /// <param name="id"></param>
    [Authorize(Roles = "backoffice_medewerker")]
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var voertuig = await _context.Voertuigen.FindAsync(id);
        if (voertuig == null) return NotFound();

        if (voertuig.VerwijderdDatum != null) return NoContent();

        voertuig.VerwijderdDatum = DateOnly.FromDateTime(DateTime.Now);
        _context.Entry(voertuig).State = EntityState.Modified;

        await _context.SaveChangesAsync();
        return NoContent();
    }
}
