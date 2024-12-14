using System.ComponentModel.DataAnnotations;

namespace backend.Rollen
{
    public class ZakelijkeHuurder
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int? HuurbeheerderId { get; set; }

        [MinLength(2)]
        public required string Factuuradres{get;set;}
        
    }
}
