namespace backend.DTOs
{
    public class AbonnementDTO
    {
        public int Id { get; set; }

        public required string Naam { get; set; }
        public double PrijsPerMaand { get; set; }
        public int MaxHuurders { get; set; }
        public TimeOnly Duur { get; set; }
        public required string Soort { get; set; } // pay as you go / maandabonnement

        public AbonnementDTO(int id, string naam, double prijs_per_maand, int Max_huurders, TimeOnly duur, string soort) {
            Id = id;
            Naam = naam;
            PrijsPerMaand = prijs_per_maand;
            MaxHuurders = Max_huurders;
            Duur = duur;
            Soort = soort;
        }
        
        public AbonnementDTO() {}
    }
}
