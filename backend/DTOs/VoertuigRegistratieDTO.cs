using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using backend.Models;

namespace backend.DTOs
{
    public class VoertuigRegistratieDTO
    {
        // [Required]
        // public int VoertuigId { get; set; }

        // //[JsonIgnore]
        // public Voertuig? Voertuig { get; set; }

        // public DateOnly Inname { get; set; }

        // [Required]
        // public required int HuuraanvraagId { get; set; }

        // public Huuraanvraag? Huuraanvraag { get; set; }
        public string Omschrijving { get; set; }
    }
}