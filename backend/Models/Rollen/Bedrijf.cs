using backend.Rollen;
using System.ComponentModel.DataAnnotations;

namespace backend.Models.Rollen
{
    public class Bedrijf
    {
        public int Id { get; set; }

        [MinLength(2)]
        [Required]
        public required string Name { get; set; }

        [MinLength(8)]
        [Required]
        public string Address { get; set; }

        [MinLength(2)]
        [Required]
        public long KvK_nummer { get; set; }

        [MinLength(2)]
        [Required]
        public string? PhoneNumber { get; set; }

        public List<Huurbeheerder> Huurbeheerders { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public string Domein { get; set; }

        public Bedrijf()
        {
            Huurbeheerders = new List<Huurbeheerder>();
        }
    }
}
