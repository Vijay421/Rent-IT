﻿using System.ComponentModel.DataAnnotations;

namespace backend.Rollen
{
    public class ZakelijkeHuurder
    {
        public int Id { get; set; }
        
        [MinLength(2)]
        public required string Factuuradres{get;set;}
        
    }
}
