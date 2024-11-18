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
        public DbSet<Bedrijf> Bedrijven { get; set; }

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

            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = "1",
                    UserName = "user1",
                    NormalizedUserName = "USER1",
                    Email = "test@email.com",
                    NormalizedEmail = "TEST@EMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAEAACcQAAAAEJ9Z",
                    SecurityStamp = "QJ9Z",
                    ConcurrencyStamp = "QJ9Z",
                    PhoneNumber = "1234567890",
                    PhoneNumberConfirmed = true,
                    TwoFactorEnabled = false,
                    LockoutEnd = null,
                    LockoutEnabled = true,
                    AccessFailedCount = 0,
                }
            );

            modelBuilder.Entity<Bedrijf>().HasData(
                new Bedrijf(1, "Bedrijf1", "1234567890"),
                new Bedrijf(2, "Bedrijf2", "1234567891"),
                new Bedrijf(3, "Bedrijf3", "1234567892")
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