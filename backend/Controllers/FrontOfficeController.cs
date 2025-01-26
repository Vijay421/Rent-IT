using backend.Data;
using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
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

        [HttpGet("voertuig_uitgave")]
        public async Task<ActionResult<IEnumerable<FrontofficeUitgaveDTO>>> GetFrontofficeUitgaveDTO()
        {
            var huuraanvragen = await _context
                .Huuraanvragen
                .Include(h => h.Voertuig)
                .Where(h => h.Geaccepteerd == true)
                .Where(h => !_context.Voertuigregistraties.Any(v => v.HuuraanvraagId == h.Id))
                .ToListAsync();

            var frontofficeUitgave = new List<FrontofficeUitgaveDTO>();

            foreach(var huuraanvraag in huuraanvragen)
            {
                var frontofficeUitgaveDTO = new FrontofficeUitgaveDTO();
                frontofficeUitgaveDTO.Id = huuraanvraag.Id;
                frontofficeUitgaveDTO.Startdatum = huuraanvraag.Startdatum;
                frontofficeUitgaveDTO.Rijbewijsnummer = huuraanvraag.Rijbewijsnummer;
                frontofficeUitgaveDTO.WettelijkeNaam = huuraanvraag.Wettelijke_naam;
                frontofficeUitgaveDTO.Einddatum = huuraanvraag.Einddatum;
                frontofficeUitgaveDTO.Kenteken = huuraanvraag.Voertuig.Kenteken;
                frontofficeUitgaveDTO.Merk = huuraanvraag.Voertuig.Merk;
                frontofficeUitgaveDTO.Type = huuraanvraag.Voertuig.Type;
                frontofficeUitgaveDTO.VoertuigId = huuraanvraag.VoertuigId;

                frontofficeUitgave.Add(frontofficeUitgaveDTO);
            }
            
            return Ok(frontofficeUitgave);
        }

        [Authorize(Roles = "frontoffice_medewerker")]
        [HttpPost("uitgave/{id}")]
        public async Task<ActionResult<Voertuigregistratie>> RegistreerVoertuigUitgave(int id, VoertuigRegistratieDTO createVoertuigRegistratieDTO)
        {
            var huuraanvraag = await _context.Huuraanvragen.FindAsync(id);
            if (huuraanvraag == null)
            {
                return NotFound($"Geen huuraanvraag gevonden met id: '{id}'");
            }

            if (huuraanvraag.VoertuigId == null)
            {
                return NotFound($"geen id gevonden voor de huuraanvraag");
            }
            var voertuigregistratie = new Voertuigregistratie()
            {
                HuuraanvraagId = id,
                VoertuigId = (int)huuraanvraag.VoertuigId,
                Omschrijving = createVoertuigRegistratieDTO.Omschrijving,
            };

            _context.Voertuigregistraties.Add(voertuigregistratie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(RegistreerVoertuigUitgave), new { id = voertuigregistratie.Id }, voertuigregistratie);
        }
    }
}