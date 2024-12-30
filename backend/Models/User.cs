using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using backend.Rollen;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class User : IdentityUser
    {
        [ForeignKey("BackOfficeMedewerkers")]
        public int? BackOfficeId { get; set; }
        public BackOfficeMedewerker? BackOffice { get; set; }

        [ForeignKey("FrontOfficeMedewerkers")]
        public int? FrontOfficeId { get; set; }
        public FrontOfficeMedewerker? FrontOffice { get; set; }

        [ForeignKey("ZakelijkeHuurders")]
        public int? ZakelijkeHuurderId { get; set; }
        public ZakelijkeHuurder? ZakelijkeHuurder { get; set; }

        [ForeignKey("ParticuliereHuurders")]
        public int? ParticuliereHuurderId { get; set; }
        public ParticuliereHuurder? ParticuliereHuurder { get; set; }

        [ForeignKey("Huurbeheerders")]
        public int? HuurbeheerderId { get; set; }
        public Huurbeheerder? Huurbeheerder { get; set; }
    }
}
