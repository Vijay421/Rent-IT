using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Huurbeheerder
    {
        public int Id { get; set; }
        [MinLength(2)]
        public required string Bedrijfsrol{get;set;}
    }
}
