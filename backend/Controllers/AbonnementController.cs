using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[Route("[controller]")]
[ApiController]
public class AbonnementController : ControllerBase
{
    private readonly RentalContext _context;
    
    public AbonnementController(RentalContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    //[HttpGet("get/all")]
    //public async Task<ActionResult<IEnumerable<Bedrijf>>> GetAllBedrijven()
    //{
    //    return await _context.Bedrijven.ToListAsync();
    //}

    [HttpGet("get/abonnementen")]
    public async Task<ActionResult<IEnumerable<Abonnement>>> GetAllAbonnementen()
    {
        return await _context.Abonnementen.ToListAsync();
    }

    [HttpGet("get/abonnement/{id}")]
    public async Task<ActionResult<AbonnementDTO>> GetAbonnement(int id)
    {
        var abonnement = await _context.Abonnementen.FindAsync(id);
        if (abonnement == null) return NotFound();

        return new AbonnementDTO{
            Id = abonnement.Id,
            naam = abonnement.naam,
            prijs_per_maand = abonnement.prijs_per_maand,
            max_huurders = abonnement.max_huurders,
            soort = abonnement.soort
        };
    }

    [HttpGet("everyone")]
    public string EveryoneCouldAccesthis()
    {
        return "hello everyone";
    }

    [Authorize]
    [HttpGet("users-only")]
    public string OnlyUsersCanAccessThis()
    {
        return "hello user";
    }

    [Authorize(Roles = "admin")]
    [HttpGet("admins-only")]
    public string OnlyAdminsCanAccessThis()
    {
        return "hello admin";
    }
}
