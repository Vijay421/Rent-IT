using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

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

        [HttpPut("huuraanvragen-beoordelen/{id}")]
        public async Task<ActionResult<IEnumerable<Huuraanvraag>>> ReviewHuuraanvragen(int id, HuuraanvraagBeoordelingDTO beoordeling)
        {
            var huuraanvraag = await _context.Huuraanvragen.FindAsync(id);
            if (huuraanvraag == null)
            {
                return NotFound($"Geen huuraanvraag gevonden met id: '{id}'");
            }

            if (!beoordeling.Beoordeling)
            {
                if (beoordeling.Reden == null)
                {
                    return BadRequest("Geen reden meegegeven tijdens het afkeuren");
                }

                huuraanvraag.Reden = beoordeling.Reden;
            } else
            {
                // Remove the reason when it has been accepted.
                huuraanvraag.Reden = null;
            }
            huuraanvraag.Geaccepteerd = beoordeling.Beoordeling;

            _context.Entry(huuraanvraag).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var huuraanvraagUpdated = await _context.Huuraanvragen.FindAsync(id);
            if (huuraanvraagUpdated == null)
            {
                return NotFound($"Geen huuraanvraag gevonden met id: '{id}'");
            }

            _context.Entry(huuraanvraagUpdated).Reference(h => h.Voertuig).Load();

            return CreatedAtAction(nameof(ReviewHuuraanvragen), new { id = huuraanvraag.Id }, huuraanvraagUpdated);
        }
    }
}
