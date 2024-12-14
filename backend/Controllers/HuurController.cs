using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HuurController : ControllerBase
{
    private readonly RentalContext _context;

    public HuurController(RentalContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Huuraanvraag>>> GetHuuraanvragen()
    {
        return await _context.Huuraanvragen.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Huuraanvraag>> GetHuuraanvraag(int id)
    {
        var huuraanvraag = await _context.Huuraanvragen.FindAsync(id);

        if (huuraanvraag == null)
        {
            return NotFound();
        }

        return huuraanvraag;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutHuuraanvraag(int id, Huuraanvraag huuraanvraag)
    {
        if (id != huuraanvraag.Id)
        {
            return BadRequest();
        }

        _context.Entry(huuraanvraag).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!HuuraanvraagExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Huuraanvraag>> PostHuuraanvraag(Huuraanvraag huuraanvraag)
    {
        _context.Huuraanvragen.Add(huuraanvraag);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetHuuraanvraag", new { id = huuraanvraag.Id }, huuraanvraag);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHuuraanvraag(int id)
    {
        var huuraanvraag = await _context.Huuraanvragen.FindAsync(id);
        if (huuraanvraag == null)
        {
            return NotFound();
        }

        _context.Huuraanvragen.Remove(huuraanvraag);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool HuuraanvraagExists(int id)
    {
        return _context.Huuraanvragen.Any(e => e.Id == id);
    }
}