using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Voertuigregistratie
    {
        public int Id { get; set; }
        [Required]
        public required Voertuig Voertuig { get; set; }
        public DateTime Inname {get;set;}
    }
}
