using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace backend.Controllers;
[Authorize(Roles = "frontoffice_medewerker")]
[Route("api/[controller]")]
[ApiController]
public class SchadeclaimController : ControllerBase
{
    private readonly RentalContext _context;

    public SchadeclaimController(RentalContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<List<Schadeclaim>> GetAllSchadeclaims()
    {
        var claims = await _context.Schadeclaims.ToListAsync();

        return claims;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Schadeclaim>> GetSchadeclaim(int id)
    {
        var schadeclaim = await _context.Schadeclaims.FindAsync(id);
        if (schadeclaim == null)
        {
            return NotFound($"Geen schadeclaim gevonden met id: '{id}'");
        }

        return schadeclaim;
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<Schadeclaim>> UpdateSchadeclaim(int id, SchadeclaimDTO schadeclaimDTO)
    {
        var schadeclaim = await _context.Schadeclaims.FindAsync(id);
        if (schadeclaim == null)
        {
            return NotFound($"Geen schadeclaim gevonden met id: '{id}'");
        }

        schadeclaim.Voertuig = schadeclaimDTO.Voertuig ?? schadeclaim.Voertuig;
        schadeclaim.Datum = schadeclaimDTO.Datum ?? schadeclaim.Datum;
        schadeclaim.Beschrijving = schadeclaimDTO.Beschrijving ?? schadeclaim.Beschrijving;
        schadeclaim.Foto = schadeclaimDTO.Foto ??  schadeclaim.Foto;

        try
        {
            _context.Update(schadeclaim);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Schadeclaims.Any(z => z.Id == id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return Ok(schadeclaim);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteSchadeclaim(int id)
    {
        var schadeclaim = await _context.Schadeclaims.FindAsync(id);
        if (schadeclaim == null)
        {
            return NotFound();
        }

        _context.Schadeclaims.Remove(schadeclaim);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost("create")]
    public async Task<ActionResult<Schadeclaim>> CreateSchadeclaim(Schadeclaim schadeclaimDto)
    {
        var voertuig = await _context.Voertuigen.FindAsync(schadeclaimDto.Voertuig.Id);
        if (voertuig == null)
        {
            return NotFound($"Geen voertuig gevonden met id: '{schadeclaimDto.Voertuig.Id}'");
        }

        voertuig.Status = "Onverhuurbaar";
        await _context.SaveChangesAsync();

        _context.Entry(voertuig).State = EntityState.Modified;


        var schadeclaim = new Schadeclaim
        {
            Voertuig = voertuig,
            Datum = schadeclaimDto.Datum,
            Beschrijving = schadeclaimDto.Beschrijving,
            Foto = schadeclaimDto.Foto
        };

        _context.Schadeclaims.Add(schadeclaim);
        await _context.SaveChangesAsync();

        _context.Entry(schadeclaim).Reference(v => v.Voertuig).Load();

        return CreatedAtAction(nameof(CreateSchadeclaim), schadeclaim);
    }
    
    [HttpPut("voertuig-accepteren/{id}")]
    public async Task<ActionResult> UpdateVoertuig(int id)
    {
        var voertuig = await _context.Voertuigen.FindAsync(id);
        if (voertuig == null)
        {
            return NotFound($"Geen voertuig gevonden met id: '{id}'");
        }
        
        if(voertuig.Status == "Verhuurbaar") return NoContent();
        voertuig.Status = "Verhuurbaar";

        _context.Entry(voertuig).State = EntityState.Modified;
        _context.Update(voertuig);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}