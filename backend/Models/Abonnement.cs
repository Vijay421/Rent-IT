using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Abonnement
    {
        public int Id { get; set; }

        [MinLength(2)]
        public string Naam { get; set; }
        [MinLength(2)]
        public double Prijs_per_maand { get; set; }
        public int Max_huurders { get; set; }
        public TimeOnly Duur { get; set; }
        [MinLength(2)]
        public string Soort { get; set; } // pay as you go / maandabonnement

        
        public Abonnement(int id, string naam, double prijs_per_maand, int Max_huurders, TimeOnly duur, string soort) {
            Id = id;
            Naam = naam;
            Prijs_per_maand = prijs_per_maand;
            Max_huurders = Max_huurders;
            Duur = duur;
            Soort = soort;
        }
        
        public Abonnement() {}
    }
}
