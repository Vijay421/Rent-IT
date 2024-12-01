namespace backend.Models
{
    public class Abonnement
    {
        public int Id { get; set; }

        public string Naam { get; set; }
        public float Prijs_per_maand { get; set; }
        public int Max_huurders { get; set; }
        public TimeOnly Duur { get; set; }
        public string Soort { get; set; } // pay as you go / maandabonnement
    }
}
