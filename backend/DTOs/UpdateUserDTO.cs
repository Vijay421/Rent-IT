using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class UpdateUserDTO
    {
        [Required]
        public string Id { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string? UserName { get; set; }

        [StringLength(255, MinimumLength = 5)]
        [EmailAddress]
        public string? Email { get; set; }

        // Only used by: particuliere_huurder
        [StringLength(255, MinimumLength = 5)]
        public string? Address { get; set; }

        [StringLength(15, MinimumLength = 5)]
        public string? PhoneNumber { get; set; }

        [StringLength(50, MinimumLength = 8)]
        public string? Password { get; set; }

        [StringLength(50, MinimumLength = 8)]
        public string? CurrentPassword { get; set; }

        // Company fields START
        [StringLength(50, MinimumLength = 2)]
        public string? CompanyName { get; set; }

        [StringLength(50, MinimumLength = 8)]
        public string? CompanyAddress { get; set; }

        public long? CompanyNumber { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string? CompanyPhoneNumber { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string? Domein { get; set; }
        // Company fields END
        
        // Only used by: zakelijke_huurder
        [MinLength(2)]
        public string? Factuuradres { get; set; }
        
        // Only used by: huurbeheerders
        [MinLength(2)]
        [StringLength(50, MinimumLength = 2)]
        public string? Bedrijfsrol { get; set; }
        

        public bool HasData()
        {
            return 
                Id != null || 
                UserName != null || 
                Email != null || 
                PhoneNumber != null || 
                Password != null ||
                CompanyName != null ||
                CompanyAddress != null ||
                CompanyNumber != null ||
                CompanyPhoneNumber != null ||
                Domein != null ||
                Factuuradres != null ||
                Bedrijfsrol != null;
        }
    }
}
