using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using backend.Models;
using backend.Rollen;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace backend.Data
{
    public class UserSeeder
    {
        public async Task Seed(UserManager<User> userManager, IConfiguration config, RentalContext context, bool isDev)
        {
            await SeedAdmin(userManager, config);

            // Should only be run in dev environments because the data is hard coded (no data from a config).
            if (isDev)
            {
                await SeedParticuliereUser(userManager, config, context);
                await SeedBackofficeUser(userManager, config, context);
            }
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

        private async Task SeedBackofficeUser(UserManager<User> userManager, IConfiguration config, RentalContext context)
        {
            // Create the backoffice user only when it does not exists already.
            var user = await userManager.FindByNameAsync("b-user");
            if (user != null)
            {
                return;
            }

            var backoffice = new BackOfficeMedewerker();
            context.BackOfficeMedewerkers.Add(backoffice);
            await context.SaveChangesAsync();

            var bUser = new User
            {
                UserName = "b-user",
                Email = "buser@user.com",
                EmailConfirmed = true,
                BackOffice = backoffice,
            };
            var result = await userManager.CreateAsync(bUser, "Qwerty123!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(bUser, "backoffice_medewerker");
                context.Entry(bUser).State = EntityState.Modified;
                await context.SaveChangesAsync(); // Adds the relation to BackOfficeMedewerker.
            }
            else
            {
                var errorText = string.Join(", ", result.Errors.Select(e => e.Description));
                Console.Error.WriteLine($"error: {errorText}");
            }
        }

        private async Task SeedParticuliereUser(UserManager<User> userManager, IConfiguration config, RentalContext context)
        {
            // Create the particuliere user only when it does not exists already.
            var admin = await userManager.FindByNameAsync("p-user");
            if (admin != null)
            {
                return;
            }

            var pHuurder = new ParticuliereHuurder
            {
                Address = "Johanna Westerdijkplein 75, 2521 EP Den Haag"
            };
            context.ParticuliereHuurders.Add(pHuurder);
            await context.SaveChangesAsync();

            var voertuig1 = await context.Voertuigen.FindAsync(1);
            if (voertuig1 == null)
            {
                throw new Exception("could not find voertuig with id 1, expected in the user seeder for ParticuliereHuurder");
            }

            var huuraanvraag1 = new Huuraanvraag
            {
                Voertuig = voertuig1,
                ParticuliereHuurderId = pHuurder.Id,
                Startdatum = new DateTime(2012, 2, 24),
                Einddatum = new DateTime(2016, 4, 12),
                Wettelijke_naam = "test particuliere huurder",
                Adresgegevens = "Johanna Westerdijkplein 75, 2521 EP Den Haag",
                Rijbewijsnummer = "5910738311",
                Reisaard = "Kestvakantie",
                Vereiste_bestemming = "Groningen",
                Verwachte_km = 500,
                Geaccepteerd = true,
            };
            context.Huuraanvragen.Add(huuraanvraag1);
            await context.SaveChangesAsync();

            var voertuig2 = await context.Voertuigen.FindAsync(105);
            if (voertuig1 == null)
            {
                throw new Exception("could not find voertuig with id 105, expected in the user seeder for ParticuliereHuurder");
            }

            var huuraanvraag2 = new Huuraanvraag
            {
                Voertuig = voertuig2,
                ParticuliereHuurderId = pHuurder.Id,
                Startdatum = new DateTime(2014, 1, 1),
                Einddatum = new DateTime(2018, 1, 1),
                Wettelijke_naam = "test particuliere huurder",
                Adresgegevens = "Johanna Westerdijkplein 75, 2521 EP Den Haag",
                Rijbewijsnummer = "5910738311",
                Reisaard = "Herfstvakantie",
                Vereiste_bestemming = "Utrecht",
                Verwachte_km = 220,
                Geaccepteerd = true,
            };
            context.Huuraanvragen.Add(huuraanvraag2);
            await context.SaveChangesAsync();

            var voertuig3 = await context.Voertuigen.FindAsync(185);
            if (voertuig1 == null)
            {
                throw new Exception("could not find voertuig with id 185, expected in the user seeder for ParticuliereHuurder");
            }

            var huuraanvraag3 = new Huuraanvraag
            {
                Voertuig = voertuig3,
                ParticuliereHuurderId = pHuurder.Id,
                Startdatum = new DateTime(2018, 1, 1),
                Einddatum = new DateTime(2022, 1, 1),
                Wettelijke_naam = "test particuliere huurder",
                Adresgegevens = "Johanna Westerdijkplein 75, 2521 EP Den Haag",
                Rijbewijsnummer = "5910738311",
                Reisaard = "Zomervakantie",
                Vereiste_bestemming = "Den Haag",
                Verwachte_km = 110,
                Geaccepteerd = true,
            };
            context.Huuraanvragen.Add(huuraanvraag3);
            await context.SaveChangesAsync();

            var user = new User
            {
                UserName = "p-user",
                Email = "puser@user.com",
                EmailConfirmed = true,
                ParticuliereHuurder = pHuurder,
            };
            var result = await userManager.CreateAsync(user, "Qwerty123!");

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "particuliere_huurder");
                context.Entry(user).State = EntityState.Modified;
                await context.SaveChangesAsync(); // Adds the ParticuliereHuurder relation.
            }
            else
            {
                var errorText = string.Join(", ", result.Errors.Select(e => e.Description));
                Console.Error.WriteLine($"error: {errorText}");
            }
        }
    }
}
