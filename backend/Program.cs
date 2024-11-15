
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

namespace backend;

public class Program
{
    public static async Task Main(string[] args)
    {
        /*var passwordHasher = new PasswordHasher<User>();
        var result = passwordHasher.VerifyHashedPassword(null, "AQAAAAIAAYagAAAAEPIhXVL5igU8vnYKZ1IV1+bZqayZkl6ZnE/5WwBiwSdBXpvyXLDoGgDD1V75eLiSgQ==", "Qwerty123!");
        Console.WriteLine(result); // Should be Success if hashes match

        return;*/
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddAuthorization(); // Originates from: https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity-api-authorization?view=aspnetcore-9.0#add-identity-services-to-the-container
        builder.Services.AddDbContext<RentalContext>();

        AddLocalConfig(builder);
        
        // Add services to the container.
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(options =>
        {
            // The following code (in this lambda function) has been taken from: https://youtu.be/8J3nuUegtL4?si=IjVjG_w903US27EH
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
            });

            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });

        // Configure the identity user with roles and a token provider.
        builder.Services.AddIdentityCore<User>()
            .AddRoles<IdentityRole>() // This codes originates from: https://learn.microsoft.com/en-us/aspnet/core/security/authorization/roles?view=aspnetcore-8.0#add-role-services-to-identity
            .AddEntityFrameworkStores<RentalContext>()
            .AddDefaultTokenProviders();

        // Add identity endpoints.
        builder.Services.AddIdentityApiEndpoints<User>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        // Add identity endpoints.
        app.MapGroup("/auth").MapIdentityApi<User>();

        using (var scope = app.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;

            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var signInManager = serviceProvider.GetRequiredService<SignInManager<User>>();

            var result = await signInManager.PasswordSignInAsync("admin", "Qwerty123!", false, false);
            //var result = await signInManager.PasswordSignInAsync("email@email.com", "Qwerty123!", false, false);

            //var errorText = string.Join(", ", result.Errors.Select(e => e.Description));
            //Console.WriteLine($"error: {errorText}");

            Console.WriteLine(result.ToString());
            // TODO: delete the unnecessary migrations files.
            return;


            var userSeeder = new UserSeeder();
            await userSeeder.Seed(userManager);
        }

        app.Run();
    }

    /// <summary>
    /// Adds the local config file to the provided builder. Will throw an error if there is no file named: 'local_config.json'.
    /// </summary>
    /// <param name="builder"></param>
    /// <exception cref="Exception"></exception>
    private static void AddLocalConfig(WebApplicationBuilder builder)
    {
        string configFile = "local_config.json";
        if (!File.Exists(configFile))
        {
            throw new Exception($"error: could not find local config file: '{configFile}'");
        }

        builder.Configuration.AddJsonFile(configFile);
    }
}
