using backend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
    public class RentalContext : IdentityDbContext<User>
    {
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;
        private readonly UserSeeder _userSeeder;
        public DbSet<User> Users { get; set; }

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
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var dbUrl = _configuration.GetSection("db")["url"];
            optionsBuilder.UseSqlServer(dbUrl);
        }
    }
}
