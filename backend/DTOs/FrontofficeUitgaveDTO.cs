using System.ComponentModel.DataAnnotations;

namespace backend.DTOs
{
    public class FrontofficeUitgaveDTO
    {
        public int Id { get; set; }
        [MaxLength(10)]
        public string Rijbewijsnummer {get; set;}
        public string WettelijkeNaam {get; set;}
        public string Kenteken {get; set;}
        public string Merk {get; set;}
        public string Type {get; set;}
        public DateOnly Startdatum {get; set;}
        public DateOnly Einddatum {get; set;}

        public FrontofficeUitgaveDTO(){}
    }

}