using System.Collections;
using System.Security.Claims;
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VoertuigController : ControllerBase
{
    private readonly RentalContext _rentalContext;
    private readonly UserManager<User> _userManager;

    public VoertuigController(RentalContext context, UserManager<User> userManager)
    {
        _rentalContext = context;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<List<Voertuig>> GetAllCars()
    {
       
        var cars = await _rentalContext.Voertuigen.ToListAsync();

        var role = User.FindFirstValue(ClaimTypes.Role);
        if (role == null)
        {
            return cars;
        }

        if (role == "zakelijke_huurder")
        {
            return cars.Where(c => c.Soort == "Auto").ToList();
        }

        return cars;
    }

    [HttpGet("{id}")]
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
