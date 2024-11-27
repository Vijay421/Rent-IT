using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class UpdateParticuliereHuurderDTO
    {
        public string Id { get; set; }

        [MinLength(2)]
        [MaxLength(50)]
        public string? UserName { get; set; }

        [MinLength(5)]
        [MaxLength(255)]
        [EmailAddress]
        public string? Email { get; set; }

        [MinLength(5)]
        [MaxLength(255)]
        public string? Address { get; set; }

        [MinLength(5)]
        [MaxLength(15)]
        public string? PhoneNumber { get; set; }

        [MinLength(8)]
        [MaxLength(50)]
        public string? Password { get; set; }

        [MinLength(8)]
        [MaxLength(50)]
        public string? CurrentPassword { get; set; }

        public bool HasData()
        {
            return Id != null || UserName != null || Email != null || Address != null || PhoneNumber != null || Password != null;
        }
    }
}
