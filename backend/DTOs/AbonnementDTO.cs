namespace backend.DTOs
{
    public class AbonnementDTO
    {
        public int Id { get; set; }

        public required string Naam { get; set; }
        public float Prijs_per_maand { get; set; }
        public int Max_huurders { get; set; }
        public TimeOnly Duur { get; set; }
        public required string Soort { get; set; } // pay as you go / maandabonnement
    }
}
