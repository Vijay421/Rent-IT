using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class UpdateParticuliereHuurderDTO
    {
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [MinLength(5)]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [MinLength(5)]
        [MaxLength(255)]
        public string Address { get; set; }

        [MinLength(5)]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [MinLength(8)]
        [MaxLength(50)]
        public string Password { get; set; }

        public bool HasData()
        {
            return Name != null && Email != null && Address != null && PhoneNumber != null && Password != null;
        }
    }
}
