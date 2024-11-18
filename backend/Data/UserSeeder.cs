using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class UserSeeder
    {
          public async Task Seed(UserManager<User> userManager)
          {
            // Create the admin only when it does not exists already.
            var admin = await userManager.FindByNameAsync("admin");
            if (admin != null)
            {
                return;
            }

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
                Console.Error.WriteLine($"error: {errorText}");
            }
        }
    }
}
