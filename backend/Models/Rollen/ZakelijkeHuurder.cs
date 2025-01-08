using backend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Rollen
{
    public class ZakelijkeHuurder
    {
        public int Id { get; set; }

        public User? User { get; set; }

        public int? HuurbeheerderId { get; set; }
        public int? AbonnementId { get; set; }
        public Abonnement? Abonnement { get; set; }

        [MinLength(2)]
        public required string Factuuradres{get;set;}
        
    }
}
