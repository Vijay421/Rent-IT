using backend.Models;

namespace backend.Rollen
{
    public class BackOfficeMedewerker
    {
        public int Id { get; set; }
        public User? User { get; set; }
    }
}
