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

    [HttpGet("get/all2")]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
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
