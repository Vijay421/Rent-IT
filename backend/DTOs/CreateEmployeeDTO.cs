using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class CreateEmployeeDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 5)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 8)]
        public string Password { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Role { get; set; }
    }
}
