using System.ComponentModel.DataAnnotations;

public class UpdateHuuraanvraagDTO
{
    public int Id { get; set; }
    
    public int? ParticuliereHuurderId { get; set; }
    
    public int? VoertuigId { get; set; }
    
    public DateOnly Startdatum { get; set; }
    
    public DateOnly Einddatum { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Wettelijke_naam { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Adresgegevens { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Reisaard { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Vereiste_bestemming { get; set; }
    
    [Range(1, int.MaxValue, ErrorMessage = "Verwachte_km must be greater than 0.")]
    public int Verwachte_km { get; set; }
    
    public bool? Geaccepteerd { get; set; }
    
    [MaxLength(100)]
    public string? Reden { get; set; }
    
    public DateTime VeranderDatum { get; set; }
    
    public bool Gezien { get; set; }
}