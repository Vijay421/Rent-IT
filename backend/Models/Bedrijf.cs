using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Bedrijf
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
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