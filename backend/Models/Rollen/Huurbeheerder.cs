using System.ComponentModel.DataAnnotations;
using backend.Models;

namespace backend.Rollen
{
    public class Huurbeheerder
    {
        public required int Id { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public required string Bedrijfsrol{ get;set; }

        public Abonnement? Abonnement { get; set; }
    }
}
