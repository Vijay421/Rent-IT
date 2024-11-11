using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace backend.Data
{
    public class RentalContext : IdentityDbContext<IdentityUser>
    {
        private readonly IConfiguration _configuration;

        public DbSet<ElevatedUser> ElevatedUsers { get; set; }
        public DbSet<User> Users { get; set; }

        public RentalContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ElevatedUser>().ToTable("ElevatedUsers");
            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<ElevatedUser>().HasData(new ElevatedUser() { Id = "1", UserName = "admin1", NormalizedUserName = "ADMIN1", Email = "test@email.com", NormalizedEmail = "TEST@EMAIL.COM", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAEJ9Z", SecurityStamp = "QJ9Z", ConcurrencyStamp = "QJ9Z", PhoneNumber = "1234567890", PhoneNumberConfirmed = true, TwoFactorEnabled = false, LockoutEnd = null, LockoutEnabled = true, AccessFailedCount = 0, });
            modelBuilder.Entity<User>().HasData(new User() { Id = "2", UserName = "user1", NormalizedUserName = "USER1", Email = "test@email.com", NormalizedEmail = "TEST@EMAIL.COM", EmailConfirmed = true, PasswordHash = "AQAAAAEAACcQAAAAEJ9Z", SecurityStamp = "QJ9Z", ConcurrencyStamp = "QJ9Z", PhoneNumber = "1234567890", PhoneNumberConfirmed = true, TwoFactorEnabled = false, LockoutEnd = null, LockoutEnabled = true, AccessFailedCount = 0, });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var dbUrl = _configuration.GetSection("db")["url"];
            optionsBuilder.UseSqlServer(dbUrl);
        }
    }
}
