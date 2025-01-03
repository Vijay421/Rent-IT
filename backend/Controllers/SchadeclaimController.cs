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

    [HttpGet("get")]
    public async Task<List<Schadeclaim>> GetAllSchadeclaims()
    {
        var claims = await _context.Schadeclaims.ToListAsync();

        return claims;
    }
    [HttpGet("get/{id}")]
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
    public async Task<ActionResult<IEnumerable<Schadeclaim>>> UpdateSchadeclaim(int id)
    {
        var schadeclaim = await _context.Schadeclaims.FindAsync(id);
        if (schadeclaim == null)
        {
            return NotFound($"Geen schadeclaim gevonden met id: '{id}'");
        }

        // TO-DO: Add update logic
        // await _context.SaveChangesAsync();


        return NoContent();
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
    public async Task<ActionResult<Schadeclaim>> CreateSchadeclaim(int id, Schadeclaim schadeclaimDto)
    {
        var voertuig = await _context.Voertuigen.FindAsync(id);
        if (voertuig == null)
        {
            return NotFound($"Geen voertuig gevonden met id: '{id}'");
        }

        voertuig.Status = "Onverhuurbaar";
        await _context.SaveChangesAsync();

        _context.Entry(voertuig).State = EntityState.Modified;


        var schadeclaim = new Schadeclaim
        {
            Voertuig = schadeclaimDto.Voertuig,
            Datum = DateTime.Today,
            Beschrijving = schadeclaimDto.Beschrijving,
            Foto = schadeclaimDto.Foto
        };

        _context.Schadeclaims.Add(schadeclaim);
        await _context.SaveChangesAsync();

        _context.Entry(schadeclaim).Reference(v => v.Voertuig).Load();

        return CreatedAtAction(nameof(CreateSchadeclaim), schadeclaim);
    }
    
    [HttpPut("/voertuig-accepteren/{id}")]
    public async Task<ActionResult> UpdateVoertuig(int id)
    {
        var voertuig = await _context.Voertuigen.FindAsync(id);
        if (voertuig == null)
        {
            return NotFound($"Geen voertuig gevonden met id: '{id}'");
        }

        voertuig.Status = "Verhuurbaar";

        _context.Entry(voertuig).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }
}