using System.ComponentModel.DataAnnotations;
using backend.Models;
using backend.Models.Rollen;

namespace backend.Rollen
{
    public class Huurbeheerder
    {
        public required int Id { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public required string Bedrijfsrol { get;set; }

        public List<Abonnement> Abonnement { get; set; }
        public List<ZakelijkeHuurder> ZakelijkeHuurders { get; set; }

        public int BedrijfId { get; set; }
        public Bedrijf Bedrijf { get; set; }

        public User? User { get; set; }

        public Huurbeheerder()
        {
            Abonnement = new List<Abonnement>();
            ZakelijkeHuurders = new List<ZakelijkeHuurder>();
        }
    }
}
