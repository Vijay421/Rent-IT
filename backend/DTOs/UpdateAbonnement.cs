using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class UpdateAbonnement
    {
        [StringLength(50, MinimumLength = 2)]
        public string? Naam { get; set; }

        [Range(1.0, 1_000_000.0)]
        public double? Prijs_per_maand { get; set; }

        [Range(1, 1000)]
        public int? Max_huurders { get; set; }
        public DateOnly? Einddatum { get; set; }
        public string? Soort { get; set; }
    }
}
