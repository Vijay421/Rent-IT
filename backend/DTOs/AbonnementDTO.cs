namespace backend.DTOs
{
    public class AbonnementDTO
    {
        public int Id { get; set; }

        public required string Naam { get; set; }
        public float PrijsPerMaand { get; set; }
        public int MaxHuurders { get; set; }
        public TimeOnly Duur { get; set; }
        public required string Soort { get; set; } // pay as you go / maandabonnement
    }
}
