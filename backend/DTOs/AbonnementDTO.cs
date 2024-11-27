namespace backend.DTOs
{
    public class AbonnementDTO
    {
        public int Id { get; set; }

        public required string naam { get; set; }
        public float prijs_per_maand { get; set; }
        public int max_huurders { get; set; }
        public TimeOnly duur { get; set; }
        public required string soort { get; set; } // pay as you go / maandabonnement
    }
}
