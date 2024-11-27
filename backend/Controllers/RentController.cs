using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[Route("[controller]")]
[ApiController]
public class RentController : ControllerBase
{
    private readonly RentalContext _context;
    
    public RentController(RentalContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }
    
    //[HttpGet("get/all")]
    //public async Task<ActionResult<IEnumerable<Bedrijf>>> GetAllBedrijven()
    //{
    //    return await _context.Bedrijven.ToListAsync();
    //}

    // [Authorize(Roles = "admin")]
    [HttpGet("get/users")]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    // [Authorize(Roles = "backoffice, admin")]
    [HttpGet("get/huuraanvragen")]
    public async Task<ActionResult<IEnumerable<Huuraanvraag>>> GetAllHuuraanvragen()
    {
        return await _context.Huuraanvragen.ToListAsync();
    }

        // [Authorize(Roles = "backoffice_medewerker", "admin")]
    [HttpGet("get/huuraanvraag/{id}")]
    public async Task<ActionResult<Huuraanvraag>> GetHuuraanvraag(int id)
    {
        var Huuraanvraag = await _context.Huuraanvragen.FindAsync(id);
        if (Huuraanvraag == null) return NotFound();

        return Huuraanvraag;
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
