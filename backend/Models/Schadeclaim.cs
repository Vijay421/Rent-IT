using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Schadeclaim
    {
        public int Id { get; set; }
        [Required]
        public Voertuig voertuig { get; set; }
        [Required]
        public DateTime datum {get;set;}
        [Required]
        public required string beschrijving {get;set;}
        public string? foto {get;set;}
    }
}
