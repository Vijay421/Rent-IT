using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class AbonnementPerZakelijkeHuurderDTO
    {
        public int Id { get; set; }

        public required string Naam { get; set; }
        public double PrijsPerMaand { get; set; }
        public int MaxHuurders { get; set; }
        public required DateOnly Startdatum { get; set; }
        public required DateOnly Einddatum { get; set; }
        public required string Soort { get; set; }
        public List<string> ZakelijkeHuurders { get; set; }

        public bool? Geaccepteerd { get; set; }

        [StringLength(100, MinimumLength = 2)]
        public string? Reden { get; set; }
    }
}
