using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class UpdateBedrijfDTO
    {
        [StringLength(50, MinimumLength = 2)]
        public string? Name { get; set; }

        [StringLength(100, MinimumLength = 8)]
        public string? Address { get; set; }

        [MinLength(2)]
        public long? KvK_nummer { get; set; }

        [StringLength(30, MinimumLength = 2)]
        public string? PhoneNumber { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string? Domein { get; set; }


        [StringLength(50, MinimumLength = 2)]
        public string? UserName { get; set; }

        [StringLength(255, MinimumLength = 5)]
        public string? Email { get; set; }

        [StringLength(50, MinimumLength = 8)]
        public string? Password { get; set; }
    }
}
