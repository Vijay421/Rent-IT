using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class UpdateEmployeeDTO
    {
        [StringLength(50, MinimumLength = 2)]
        public string? UserName { get; set; }

        [StringLength(255, MinimumLength = 5)]
        [EmailAddress]
        public string? Email { get; set; }

        [StringLength(15, MinimumLength = 5)]
        public string? PhoneNumber { get; set; }

        [StringLength(50, MinimumLength = 8)]
        public string? Password { get; set; }

        [StringLength(50, MinimumLength = 8)]
        public string? CurrentPassword { get; set; }

        [StringLength(50, MinimumLength = 5)]
        public string? Role { get; set; }
    }
}
