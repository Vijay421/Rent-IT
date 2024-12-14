using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    using System.Text.Json.Serialization;

    public class Huuraanvraag
    {
        public int Id { get; set; }
        public int? ParticuliereHuurderId { get; set; }

        [JsonPropertyName("voertuig")]
        public Voertuig? Voertuig { get; set; }

        [JsonPropertyName("startdatum")]
        public DateOnly Startdatum { get; set; }

        [JsonPropertyName("einddatum")]
        public DateOnly Einddatum { get; set; }

        [JsonPropertyName("wettelijke_naam")]
        public string Wettelijke_naam { get; set; }

        [JsonPropertyName("adresgegevens")]
        public string Adresgegevens { get; set; }

        [JsonPropertyName("rijbewijsnummer")]
        public string Rijbewijsnummer { get; set; }

        [JsonPropertyName("reisaard")]
        public string Reisaard { get; set; }

        [JsonPropertyName("vereiste_bestemming")]
        public string Vereiste_bestemming { get; set; }

        [JsonPropertyName("verwachte_km")]
        [Range(1, int.MaxValue, ErrorMessage = "Verwachte_km must be greater than 0.")]
        public int Verwachte_km { get; set; }

        public bool? Geaccepteerd { get; set; }
        public string? Reden { get; set; }
        public DateTime VeranderDatum { get; set; }
        public bool Gezien { get; set; }

        public Huuraanvraag() { }

        public Huuraanvraag(int id, int? particuliereHuurderId, Voertuig? voertuig, DateOnly startdatum, DateOnly einddatum, string? wettelijke_naam, string? adresgegevens, string? rijbewijsnummer, string? reisaard, string? vereiste_bestemming, int verwachte_km, bool? geaccepteerd, string? reden, DateTime veranderDatum, bool gezien)
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
