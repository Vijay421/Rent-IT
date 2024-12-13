﻿using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Abonnement
    {
        public required int Id { get; set; }

        [StringLength(50, MinimumLength = 2)]
        public required string Naam { get; set; }

        [Range(1.0, 1_000_000.0)]
        public required double Prijs_per_maand { get; set; }

        [Range(1, 1000)]
        public required int Max_huurders { get; set; }

        public required DateOnly Einddatum { get; set; }

        [MinLength(2)]
        public required string Soort { get; set; } // pay as you go / prepaid

        public Abonnement() {}
    }
}
