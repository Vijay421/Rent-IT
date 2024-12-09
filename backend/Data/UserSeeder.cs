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
            await Seed(userManager, config, configName: "admin", role: "admin");
            await Seed(userManager, config, configName: "beheerder", role: "zakelijke_beheerder");
        }

        /// <summary>
        /// Creates a user if the name is not taken already.
        /// </summary>
        /// <param name="userManager"></param>
        /// <param name="config"></param>
        /// <param name="configName">Corresponds to the name of the key in the 'accounts' object in local_config.json.</param>
        /// <param name="role"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task Seed(UserManager<User> userManager, IConfiguration config, string configName, string role)
        {
            var userConfig = config.GetSection("accounts").GetSection(configName);
            if (!userConfig.Exists())
            {
                return;
            }

            var userName = userConfig["userName"] ?? throw new Exception($"no userName field for '{role}' in local_config.json");

            // Create the user only when it does not exists already.
            var user = await userManager.FindByNameAsync(userName);
            if (user != null)
            {
                return;
            }

            user = new User
            {
                UserName = userName,
                Email = userConfig["email"] ?? throw new Exception($"no email field for '{role}' in local_config.json"),
                EmailConfirmed = true,
            };
            var result = await userManager.CreateAsync(user, userConfig["password"] ?? throw new Exception("no password field for admin in local_config.json"));

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, role);
            }
            else
            {
                var errorText = string.Join(", ", result.Errors.Select(e => e.Description));
                Console.Error.WriteLine($"error: {errorText}");
            }
        }
    }
}
