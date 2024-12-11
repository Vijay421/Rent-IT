using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class HuuraanvraagGeschiedenisDTO
    {
        public string Startdatum { get; set; }
        public string Einddatum { get; set; }
        public string Reisaard { get; set; }
        public string Merk { get; set; }
        public string Type { get; set; }
        public string Kenteken { get; set; }
        public string Kleur { get; set; }
        public int Aanschafjaar { get; set; }
        public string Soort { get; set; }
        public double Prijs { get; set; }
    }
}
