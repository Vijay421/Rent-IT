using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class ParticuliereHuurder
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(255)]
        // TODO: change Address to Dutch: 'adres'.
        public string Address { get; set; }
    }
}
