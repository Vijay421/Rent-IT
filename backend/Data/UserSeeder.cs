using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class UserSeeder
    {
          public async Task Seed(UserManager<User> userManager)
        {
            var admin = await userManager.FindByNameAsync("admin");
            if (admin != null)
            {
                return;
            }

            Console.WriteLine("Will crete the admin user");
            admin = new User
            {
                UserName = "admin",
                Email = "admin@carandall.com",
                EmailConfirmed = true,
            };
            var result = await userManager.CreateAsync(admin, "Qwerty123!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "admin");
            }
            else
            {
                var errorText = string.Join(", ", result.Errors.Select(e => e.Description));
                Console.WriteLine($"error: {errorText}");
            }

            return;

            /*var adminId = Guid.NewGuid().ToString();
            var passwordHasher = new PasswordHasher<User>();

            var admin = new User
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                EmailConfirmed = true,
                PasswordHash = passwordHasher.HashPassword(null, "Qwerty123!") // TODO: figure out how this works.
            };

            modelBuilder.Entity<User>().HasData(admin);

            // TODO: add link to fluent api.
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                UserId = adminId,
                RoleId = roleIds[RoleName.ADMIN],
            });*/
        }
    }
}
