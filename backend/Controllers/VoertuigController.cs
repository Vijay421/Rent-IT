using System.Collections;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VoertuigController : ControllerBase
{
    private readonly RentalContext _rentalContext;

    public VoertuigController(RentalContext context)
    {
        _rentalContext = context;
    }

    [HttpGet("get/")]
    public async Task<List<Voertuig>> GetAllCars()
    {
        return await _rentalContext.Voertuigen.ToListAsync();
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<Voertuig>> GetOneCar(int id)
    {
        var car = await _rentalContext.Voertuigen.FindAsync(id);

        if (car == null)
        {
            return NotFound();
        }
        
        return car;
    }
}