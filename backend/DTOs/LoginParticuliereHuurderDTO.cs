using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;

public class LoginParticuliereHuurderDTO
{
    [Required]
    [MinLength(5)]
    [MaxLength(255)]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [MinLength(8)]
    [MaxLength(50)]
    public string Password { get; set; }
}