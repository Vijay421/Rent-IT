using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class AbonnementDTO
    {
        public int Id { get; set; }

        public required string Naam { get; set; }
        public double PrijsPerMaand { get; set; }
        public int MaxHuurders { get; set; }
        public required DateOnly Einddatum { get; set; }
        public required string Soort { get; set; } // pay as you go / maandabonnement

        public bool? Geaccepteerd { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string? Reden { get; set; }


        public AbonnementDTO() {}
    }
}
