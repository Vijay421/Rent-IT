using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Bedrijf
    {
        public int Id { get; set; }
        [MinLength(2)]
        public string Name { get; set; }
        [MinLength(8)]
        public string Address { get; set; }
        [MinLength(2)]
        public int KvK_nummer { get; set; }
        [MinLength(2)]
        public string? PhoneNumber { get; set; }

        public Bedrijf(int id, string name, string? phoneNumber)
        {
            Id = id;
            Name = name;
            PhoneNumber = phoneNumber;
        }

        public Bedrijf() {}
    }
}