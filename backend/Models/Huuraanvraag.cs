using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Huuraanvraag
    {
        public int Id { get; set; }
        public int? ParticuliereHuurderId { get; set; }

        [Required]
        public required Voertuig Voertuig {get;set;}
        [Required]
        public DateTime Startdatum { get; set; }
        [Required]
        public DateTime Einddatum { get; set; }
        [Required]
        [MinLength(2)]
        public string Wettelijke_naam { get; set; }
        [Required]
        [MinLength(2)]
        public string Adresgegevens { get; set; }
        [Required]
        [MinLength(2)]
        public string Rijbewijsnummer{ get; set; }
        [MinLength(2)]
        public string Reisaard { get; set; }
        [MinLength(2)]
        public string Vereiste_bestemming{ get; set; }
        [MinLength(2)]
        public int Verwachte_km{ get; set; }
        public bool? Geaccepteerd { get; set; }
        public string? Reden {  get; set; }

        /// <summary>
        /// Shows the datum when the row got updated.
        /// </summary>
        public DateTime VeranderDatum { get; set; }

        /// <summary>
        /// whether  the user has seen the notification.
        /// </summary>
        public bool Gezien { get; set; }

        public Huuraanvraag()
        {

        }
    }
}
