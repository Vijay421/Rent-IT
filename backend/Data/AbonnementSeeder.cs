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
                new Abonnement(1, "abba", 12.20, 1, new TimeOnly(4, 20), "prepaid")
            );
        }
    }
}