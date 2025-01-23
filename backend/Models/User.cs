using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using backend.Rollen;
using System.ComponentModel.DataAnnotations.Schema;
using backend.Models.Rollen;

namespace backend.Models
{
    public class User : IdentityUser
    {
        public int? BackOfficeId { get; set; }
        public BackOfficeMedewerker? BackOffice { get; set; }

        public int? FrontOfficeId { get; set; }
        public FrontOfficeMedewerker? Frontoffice { get; set; }

        public int? BedrijfId { get; set; }
        public Bedrijf? Bedrijf { get; set; }

        public int? ZakelijkeHuurderId { get; set; }
        public ZakelijkeHuurder? ZakelijkeHuurder { get; set; }

        public int? ParticuliereHuurderId { get; set; }
        public ParticuliereHuurder? ParticuliereHuurder { get; set; }

        public int? HuurbeheerderId { get; set; }
        public Huurbeheerder? Huurbeheerder { get; set; }
    }
}
