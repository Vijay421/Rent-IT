using backend.Models;
using backend.Rollen;
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
        private readonly IConfiguration? _configuration;
        private readonly IServiceProvider? _serviceProvider;
        private readonly UserSeeder? _userSeeder;
        public DbSet<User> Users { get; set; }
        public DbSet<Abonnement> Abonnementen { get; set; }
        public DbSet<Huuraanvraag> Huuraanvragen{ get; set; }
        public DbSet<Schadeclaim> Schadeclaims{ get; set; }
        public DbSet<BackOfficeMedewerker> BackOfficeMedewerkers { get; set; }
        public DbSet<FrontOfficeMedewerker> FrontOfficeMedewerkers { get; set; }
        public DbSet<ParticuliereHuurder> ParticuliereHuurders { get; set; }
        public DbSet<ZakelijkeHuurder> ZakelijkeHuurders { get; set; }
        public DbSet<Huurbeheerder> Huurbeheerders { get; set; }
        public DbSet<Voertuig> Voertuigen { get; set; }
        public DbSet<Bedrijf> Bedrijven { get; set; }
        public DbSet<Voertuigregistratie> Voertuigregistraties { get; set; }

        public RentalContext(DbContextOptions<RentalContext> contextOptions, IConfiguration configuration, IServiceProvider serviceProvider) : base(contextOptions)
        {
            _configuration = configuration;
            _serviceProvider = serviceProvider;
            _userSeeder = new UserSeeder();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            /* Only uncomment the following when adding, removing or changing seeding data. Otherwise duplicate data will be created when migrating.*/
            
            /*
            var roleConfig = new RoleConfiguration();
            modelBuilder.ApplyConfiguration(roleConfig);
            
            var voertuigSeeder = new VoertuigSeeder();
            voertuigSeeder.Seed(modelBuilder);
            var abonnementSeeder = new AbonnementSeeder(); 
            abonnementSeeder.Seed(modelBuilder);
            */
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (_configuration != null)
            {
                var dbUrl = _configuration.GetSection("db")["url"];
                optionsBuilder.UseSqlServer(dbUrl);
            }
        }
    }
}