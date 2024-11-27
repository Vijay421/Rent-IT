using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class RegisterParticuliereHuurderDTO
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name {  get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(255)]
        public string Address { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
