using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class HuuraanvraagBeoordelingDTO
    {

        [StringLength(500, MinimumLength = 2)]
        public string? Reden { get; set; }
        public required  bool Beoordeling {  get; set; }
    }
}
