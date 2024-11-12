using Microsoft.AspNetCore.Identity;

namespace backend.Models
{
    public class User : IdentityUser
    {
        public BackOffice? BackOffice { get; set; }
        public FrontOffice? FrontOffice { get; set; }
    }
}
