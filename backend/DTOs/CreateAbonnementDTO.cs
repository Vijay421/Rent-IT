using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class CreateAbonnementDTO
    {
        [StringLength(50, MinimumLength = 2)]
        public required string Naam { get; set; }

        //[Range(1.0, 1_000_000.0)]
        //public required double Prijs_per_maand { get; set; }


        [Range(1, 1000)]
        public required int Max_huurders { get; set; }
        public required DateOnly Einddatum { get; set; }
        public required string Soort { get; set; } // pay as you go / prepaid
    }
}
