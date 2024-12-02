using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Abonnement
    {
        public int Id { get; set; }

        [MinLength(2)]
        public string Naam { get; set; }
        [MinLength(2)]
        public float Prijs_per_maand { get; set; }
        public int Max_huurders { get; set; }
        public TimeOnly Duur { get; set; }
        [MinLength(2)]
        public string Soort { get; set; } // pay as you go / maandabonnement
    }
}
