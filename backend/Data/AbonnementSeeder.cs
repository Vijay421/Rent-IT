using System.Runtime.InteropServices.JavaScript;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace backend.Data
{
    public class AbonnementSeeder
    {
        public void Seed(ModelBuilder builder)
        {
            builder.Entity<Abonnement>().HasData(
                new Abonnement { Id = 1, Naam = "abbo", Prijs_per_maand = 12.20, Max_huurders = 10, Startdatum = new DateOnly(2025, 5, 12), Einddatum = new DateOnly(2026, 1, 1), Soort = "prepaid" }
            );
        }
    }
}