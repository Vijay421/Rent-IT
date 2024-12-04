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

    [HttpGet("get/")]
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
            Id = abonnement.Id,
            Naam = abonnement.Naam,
            Prijs_per_maand = abonnement.Prijs_per_maand,
            Max_huurders = abonnement.Max_huurders,
            Soort = abonnement.Soort
        };
    }
}
