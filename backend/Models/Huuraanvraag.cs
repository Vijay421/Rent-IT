using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Huuraanvraag
    {
        public int Id { get; set; }
        
        [Required]
        public Voertuig voertuig {get;set;}
        [Required]
        public DateTime startdatum { get; set; }
        [Required]
        public DateTime einddatum { get; set; }
        [Required]
        public string wettelijke_naam { get; set; }
        [Required]
        public string adresgegevens { get; set; }
        [Required]
        public string rijbewijsnummer{ get; set; }
        public string reisaard { get; set; }
        public string vereiste_bestemming{ get; set; }
        public int verwachte_km{ get; set; }
        public bool geaccepteerd { get; set; }

    }
}
