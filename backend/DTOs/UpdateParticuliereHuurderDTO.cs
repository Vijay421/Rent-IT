using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class UpdateParticuliereHuurderDTO
    {
        [Required]
        public string Id { get; set; }

        // TODO: figure out if MinLength still works when its null.
        //[MinLength(2)]
        [MaxLength(50)]
        //[Required(AllowEmptyStrings = true)]
        public string? UserName { get; set; }

        //[MinLength(5)]
        [MaxLength(255)]
        [EmailAddress]
        //[Required(AllowEmptyStrings = true)]
        public string? Email { get; set; }

        //[MinLength(5)]
        [MaxLength(255)]
        //[Required(AllowEmptyStrings = true)]
        public string? Address { get; set; }

        //[MinLength(5)]
        [MaxLength(15)]
        //[Required(AllowEmptyStrings = true)]
        public string? PhoneNumber { get; set; }

        //[MinLength(8)]
        [MaxLength(50)]
        //[Required(AllowEmptyStrings = true)]
        public string? Password { get; set; }

        //[MinLength(8)]
        [MaxLength(50)]
        //[Required(AllowEmptyStrings = true)]
        public string? CurrentPassword { get; set; }

        public bool HasData()
        {
            return Id != null || UserName != null || Email != null || Address != null || PhoneNumber != null || Password != null;
        }
    }
}
