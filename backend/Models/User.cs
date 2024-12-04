using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace backend.Models
{
    public class User : IdentityUser
    {
        public BackOfficeMedewerker? BackOffice { get; set; }
        public FrontOfficeMedewerker? FrontOffice { get; set; }
        public ZakelijkeHuurder? ZakelijkeHuurder { get; set; }
        public ParticuliereHuurder? ParticuliereHuurder { get; set; }
    }
}
