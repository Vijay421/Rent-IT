﻿using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Schadeclaim
    {
        public int Id { get; set; }
        [Required]
        public required Voertuig Voertuig { get; set; }
        [Required]
        public DateTime Datum {get;set;}
        [Required]
        [MinLength(5)]
        public required string Beschrijving {get;set;}
        public string? Foto {get;set;}
    }
}
