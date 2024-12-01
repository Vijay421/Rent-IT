using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Huuraanvraag
    {
        public int Id { get; set; }
        
        [Required]
        public required Voertuig Voertuig {get;set;}
        [Required]
        public DateTime Startdatum { get; set; }
        [Required]
        public DateTime Einddatum { get; set; }
        [Required]
        public string Wettelijke_naam { get; set; }
        [Required]
        public string Adresgegevens { get; set; }
        [Required]
        public string Rijbewijsnummer{ get; set; }
        public string Reisaard { get; set; }
        public string Vereiste_bestemming{ get; set; }
        public int Verwachte_km{ get; set; }
        public bool Geaccepteerd { get; set; }

    }
}
