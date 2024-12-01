using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class ParticuliereHuurderDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ParticuliereHuurderDTO(string id, RegisterParticuliereHuurderDTO huurderDTO)
        {
            Id = id;
            Name = huurderDTO.Name;
            Email = huurderDTO.Email;
        }
    }
}
