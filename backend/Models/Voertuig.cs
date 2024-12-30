using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace backend.Models;

public class Voertuig
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MinLength(2)]
    [MaxLength(25)]
    public string Merk { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(25)]
    public string Type { get; set; }

    [Required]
    [MinLength(8)]
    [MaxLength(9)]
    public string Kenteken { get; set; }

    [Required]
    [MinLength(2)]
    [MaxLength(25)]
    public string Kleur { get; set; }

    [Required]
    public int Aanschafjaar { get; set; }
    
    [Required]
    [MinLength(2)]
    [MaxLength(10)]
    public string Soort { get; set; }
    
    [MaxLength(500)]
    public string Opmerking { get; set; }
    
    [Required]
    [MinLength(2)]
    [MaxLength(50)]
    public string Status { get; set; }
    
    [Required]
    public double Prijs { get; set; }
    
    [Required]
    public DateOnly StartDatum { get; set; }
    
    [Required]
    public DateOnly EindDatum { get; set; }
    public Voertuig (int id, string merk, string type, string kenteken, string kleur, int aanschafjaar, string soort, string opmerking,
        string status, double prijs, DateOnly startDatum, DateOnly eindDatum)
    {
        Id = id;
        Merk = merk;
        Type = type;
        Kenteken = kenteken;
        Kleur = kleur;
        Aanschafjaar = aanschafjaar;
        Soort = soort;
        Opmerking = opmerking;
        Status = status;
        Prijs = prijs;
        StartDatum = startDatum;
        EindDatum = eindDatum;
    }
    
    public Voertuig() {}
}
