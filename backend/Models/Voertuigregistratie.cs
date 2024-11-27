namespace backend.Models
{
    public class Voertuigregistratie
    {
        public int Id { get; set; }

        public Voertuig voertuig { get; set; }
        public DateTime Inname {get;set;}
    }
}
