using backend.Rollen;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
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
        public int KvK_nummer { get; set; }

        [MinLength(2)]
        [Required]
        public string? PhoneNumber { get; set; }

        public List<Huurbeheerder> Huurbeheerders { get; set; }

        public Bedrijf()
        {
            Huurbeheerders = new List<Huurbeheerder>();
        }
    }
}