using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Huurbeheerder
    {
        public required int Id { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public required string Bedrijfsrol{ get;set; }

        public Abonnement? Abonnement { get; set; }
    }
}
