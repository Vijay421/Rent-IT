using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    using System.Text.Json.Serialization;

    public class Huuraanvraag
    {
        [Key]
        public int Id { get; set; }
        
        public int? ParticuliereHuurderId { get; set; }
        public int? ZakelijkeHuurder { get; set; }

        public int? VoertuigId { get; set; }

        public Voertuig? Voertuig { get; set; }

        [Required]
        [JsonPropertyName("startdatum")]
        public DateOnly Startdatum { get; set; }

        [Required]
        [JsonPropertyName("einddatum")]
        public DateOnly Einddatum { get; set; }

        [Required]
        [MaxLength(50)]
        [JsonPropertyName("wettelijke_naam")]
        public string Wettelijke_naam { get; set; }

        [Required]
        [MaxLength(50)]
        [JsonPropertyName("adresgegevens")]
        public string Adresgegevens { get; set; }

        [Required]
        [MaxLength(10)]
        [JsonPropertyName("rijbewijsnummer")]
        public string Rijbewijsnummer { get; set; }

        [Required]
        [MaxLength(100)]
        [JsonPropertyName("reisaard")]
        public string Reisaard { get; set; }

        [Required]
        [MaxLength(50)]
        [JsonPropertyName("vereiste_bestemming")]
        public string Vereiste_bestemming { get; set; }

        [Required]
        [JsonPropertyName("verwachte_km")]
        [Range(1, int.MaxValue, ErrorMessage = "Verwachte_km must be greater than 0.")]
        public int Verwachte_km { get; set; }

        public bool? Geaccepteerd { get; set; }
        
        [MaxLength(100)]
        public string? Reden { get; set; }
        
        [Required]
        public DateTime VeranderDatum { get; set; }
        
        [Required]
        public bool Gezien { get; set; }

        public Huuraanvraag() { }
    
        public Huuraanvraag(int id, int? particuliereHuurderId, DateOnly startdatum, DateOnly einddatum, string? wettelijke_naam, string? adresgegevens, string? rijbewijsnummer, string? reisaard, string? vereiste_bestemming, int verwachte_km, bool? geaccepteerd, string? reden, DateTime veranderDatum, bool gezien, Voertuig? voertuig = null)
        {
            Id = id;
            ParticuliereHuurderId = particuliereHuurderId;
            Voertuig = voertuig;
            Startdatum = startdatum;
            Einddatum = einddatum;
            Wettelijke_naam = wettelijke_naam;
            Adresgegevens = adresgegevens;
            Rijbewijsnummer = rijbewijsnummer;
            Reisaard = reisaard;
            Vereiste_bestemming = vereiste_bestemming;
            Verwachte_km = verwachte_km;
            Geaccepteerd = geaccepteerd;
            Reden = reden;
            VeranderDatum = veranderDatum;
            Gezien = gezien;
        }
    }
}
