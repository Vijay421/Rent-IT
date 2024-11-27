namespace backend.Models
{
    public class Abonnement
    {
        public int Id { get; set; }

        public string naam { get; set; }
        public float prijs_per_maand { get; set; }
        public int max_huurders { get; set; }
        public TimeOnly duur { get; set; }
        public string soort { get; set; } // pay as you go / maandabonnement
    }
}
