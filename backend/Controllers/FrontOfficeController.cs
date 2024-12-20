﻿using backend.Data;
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
public class FrontOfficeController : ControllerBase
{
    private readonly RentalContext _context;

    public FrontOfficeController(RentalContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<List<Schadeclaim>> GetAllSchadeclaims()
    {
        var claims = await _context.Schadeclaims.ToListAsync();

        // var role = User.FindFirstValue(ClaimTypes.Role);
        // if (role == null)
        // {
        //     return NoContent();
        // }

        
        return claims;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<Schadeclaim>> GetSchadeclaim(int id)
    {
        var schadeclaim = await _context.Schadeclaims.FindAsync(id);

        if (schadeclaim == null)
        {
            return NotFound();
        }

        return schadeclaim;
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<IEnumerable<Schadeclaim>>> UpdateSchadeclaim(int id)
    {
        var schadeclaim = await _context.Schadeclaims.FindAsync(id);
        if (schadeclaim == null)
        {
            return NotFound($"Geen schadeclaim gevonden met id: '{id}'");
        }

        // TO-DO: Add update logic


        return NoContent();
    }

    [HttpDelete("{id}")]
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
}
