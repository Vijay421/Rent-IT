using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class CreateBedrijfDTO
    {
        [StringLength(50, MinimumLength = 2)]
        public required string BedrijfsNaam { get; set; }

        [StringLength(50, MinimumLength = 8)]
        public required string Address { get; set; }

        public required long KvK_nummer { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string? PhoneNumber { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public required string Domein { get; set; }


        [StringLength(50, MinimumLength = 2)]
        public required string UserName { get; set; }

        [StringLength(255, MinimumLength = 5)]
        public required string Email { get; set; }

        [StringLength(50, MinimumLength = 8)]
        public required string Password { get; set; }
    }
}
