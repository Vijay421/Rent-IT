using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Authorize(Roles = "backoffice_medewerker")]
    [Route("api/[controller]")]
    [ApiController]
    public class BackOfficeController : ControllerBase
    {
        private readonly RentalContext _context;

        public BackOfficeController(RentalContext context)
        {
            _context = context;
        }

        [HttpGet("huuraanvragen")]
        public async Task<ActionResult<IEnumerable<Huuraanvraag>>> GetHuuraanvragen()
        {
            var huuraanvraagen = await _context
                .Huuraanvragen
                .Include(h => h.Voertuig)
                .ToListAsync();

            return Ok(huuraanvraagen);
        }
    }
}
