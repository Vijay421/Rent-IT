using backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

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

            modelBuilder.Entity<Voertuig>().HasData(
                new Voertuig(1,"Toyota", "Corolla", "AB-123-CD", "Red", 2018, "Auto", "", "Verhuurbaar"),
                new Voertuig(2,"Ford", "Focus", "EF-456-GH", "Blue", 2019, "Auto", "", "Verhuurbaar")
            );
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var dbUrl = _configuration.GetSection("db")["url"];
            optionsBuilder.UseSqlServer(dbUrl);
        }
    }
}