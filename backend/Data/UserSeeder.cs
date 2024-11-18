using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using Microsoft.Extensions.Configuration;

namespace backend.Data
{
    public class UserSeeder
    {
          public async Task Seed(UserManager<User> userManager, IConfiguration config)
          {
            await SeedAdmin(userManager, config);
          }

        private async Task SeedAdmin(UserManager<User> userManager, IConfiguration config)
        {
            var adminConfig = config.GetSection("accounts").GetSection("admin");
            if (!adminConfig.Exists())
            {
                return;
            } 

            // Create the admin only when it does not exists already.
            var admin = await userManager.FindByNameAsync("admin");
            if (admin != null)
            {
                return;
            }

            admin = new User
            {
                UserName = adminConfig["userName"] ?? throw new Exception("no userName field for admin in local_config.json"),
                Email = adminConfig["email"] ?? throw new Exception("no email field for admin in local_config.json"),
                EmailConfirmed = true,
            };
            var result = await userManager.CreateAsync(admin, adminConfig["password"] ?? throw new Exception("no password field for admin in local_config.json"));

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "admin");
            }
            else
            {
                var errorText = string.Join(", ", result.Errors.Select(e => e.Description));
                Console.Error.WriteLine($"error: {errorText}");
            }
        }
    }
}
