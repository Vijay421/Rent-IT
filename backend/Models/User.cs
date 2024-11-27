using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace backend.Models
{
    public class User : IdentityUser
    {
        // id en email worden door IdentityUser al behandeld
        public required string Gebruikersnaam {get;set;}
   
        public required string Telefoonnummer {get;set;}
      
        public required string Rol {get;set;}

        public BackOfficeMedewerker? BackOffice { get; set; }
        public FrontOfficeMedewerker? FrontOffice { get; set; }
        public ZakelijkeHuurder? ZakelijkeHuurder { get; set; }
        public ParticuliereHuurder? ParticuliereHuurder { get; set; }
    }
}
