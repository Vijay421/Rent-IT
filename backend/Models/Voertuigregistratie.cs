using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Voertuigregistratie
    {
        [Key]
        public int Id { get; set; }

        public Voertuig? Voertuig { get; set; }

        [Required]
        public required int VoertuigId { get; set; }

        public DateOnly? Inname {get;set;}

        [Required]
        public required int HuuraanvraagId { get; set; }

        public Huuraanvraag? Huuraanvraag { get; set; }

        [Required]
        public string Omschrijving { get; set;}
    }
}
