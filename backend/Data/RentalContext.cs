using backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections;
using System.Text.Json;
using System.Text.Json.Nodes;
namespace backend.Data
{
    public class RentalContext : IdentityDbContext<User>
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;
        private readonly UserSeeder _userSeeder;
        public DbSet<User> Users { get; set; }
        public DbSet<Abonnement> Abonnementen { get; set; }
        public DbSet<Huuraanvraag> Huuraanvragen{ get; set; }
        //public DbSet<Bedrijf> Bedrijven { get; set; }
        public DbSet<ParticuliereHuurder> ParticuliereHuurders { get; set; }
        public DbSet<Voertuig> Voertuigen { get; set; }

        public RentalContext(IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _configuration = configuration;
            _serviceProvider = serviceProvider;
            _userSeeder = new UserSeeder();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var roleConfig = new RoleConfiguration();
            modelBuilder.ApplyConfiguration(roleConfig);
            var jsonString = File.ReadAllText("Data/Voertuigen.json");
            var voertuigen = JsonSerializer.Deserialize<List<Voertuig>>(jsonString);
            if (voertuigen != null){
                modelBuilder.Entity<Voertuig>().HasData(voertuigen);

                //     x => {
                //     for(int i = 0; i <= voertuigen.Count; i++){
                //         new Voertuig(
                //             voertuigen[i].Id,
                //             voertuigen[i].Merk,
                //             voertuigen[i].Type,
                //             voertuigen[i].Kenteken,
                //             voertuigen[i].Kleur,
                //             voertuigen[i].Aanschafjaar,
                //             voertuigen[i].Soort,
                //             voertuigen[i].Opmerking,
                //             voertuigen[i].Status);
                //     }
                //     return 
                // } 
            }

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var dbUrl = _configuration.GetSection("db")["url"];
            optionsBuilder.UseSqlServer(dbUrl);
        }
    }
}