namespace backend.Models
{
    public class Voertuigregistratie
    {
        public int Id { get; set; }

        public required Voertuig voertuig { get; set; }
        public DateTime Inname {get;set;}
    }
}
