using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class UpdateVoertuigDTO
    {
        [StringLength(25, MinimumLength = 2)]
        public string? Merk { get; set; }

        [StringLength(25, MinimumLength = 2)]
        public string? Type { get; set; }

        [StringLength(9, MinimumLength = 8)]
        public string? Kenteken { get; set; }

        [StringLength(25, MinimumLength = 2)]
        public string? Kleur { get; set; }

        [Range(1700, 3000)]
        public int? Aanschafjaar { get; set; }

        [StringLength(10, MinimumLength = 2)]
        public string? Soort { get; set; }

        [StringLength(500)]
        public string? Opmerking { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string? Status { get; set; }

        [Range(1, 1_000_00)]
        public double? Prijs { get; set; }

        public DateOnly? StartDatum { get; set; }

        public DateOnly? EindDatum { get; set; }

    }
}
