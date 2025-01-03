using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using backend.Rollen;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    public class User : IdentityUser
    {
        public int? BackOfficeId { get; set; }
        public BackOfficeMedewerker? BackOffice { get; set; }

        public int? FrontOfficeId { get; set; }
        public FrontOfficeMedewerker? FrontOffice { get; set; }

        public int? ZakelijkeHuurderId { get; set; }
        public ZakelijkeHuurder? ZakelijkeHuurder { get; set; }

        public int? ParticuliereHuurderId { get; set; }
        public ParticuliereHuurder? ParticuliereHuurder { get; set; }

        public int? HuurbeheerderId { get; set; }
        public Huurbeheerder? Huurbeheerder { get; set; }
    }
}
