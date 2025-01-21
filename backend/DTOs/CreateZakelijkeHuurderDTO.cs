using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class CreateZakelijkeHuurderDTO
    {
        [StringLength(50, MinimumLength = 2)]
        public required string Name { get; set; }

        [StringLength(255, MinimumLength = 5)]
        public required string Email { get; set; }

        [StringLength(50, MinimumLength = 8)]
        public required string Password { get; set; }

        [StringLength(15, MinimumLength = 5)]
        public required string PhoneNumber { get; set; }


        [StringLength(255, MinimumLength = 5)]
        public required string Address { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public required string Factuuradres { get; set; }

        public required int HuurbeheerderId {  get; set; }
    }
}
