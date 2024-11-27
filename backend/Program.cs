
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.AspNetCore.SpaServices.Extensions;
using Microsoft.Extensions.Configuration;

namespace backend;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddAuthorization(); // Originates from: https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity-api-authorization?view=aspnetcore-9.0#add-identity-services-to-the-container
        builder.Services.AddDbContext<RentalContext>();

        // Serve react frontend static files.
        builder.Services.AddSpaStaticFiles(configuration =>
        {
            configuration.RootPath = "../frontend/Rent-IT/dist";
        });

        // Adds CORS services
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins",
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });

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

        // Use the CORS policy.
        app.UseCors("AllowAllOrigins");

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        // Add identity endpoints.
        app.MapGroup("/auth").MapIdentityApi<User>();

        await SeedUsers(app);

        ServeSpa(app, builder);

        app.Run();
    }

    /// <summary>
    /// Adds the local config file to the provided builder. Will throw an error if there is no file named: 'local_config.json'.
    /// </summary>
    private static void AddLocalConfig(WebApplicationBuilder builder)
    {
        string configFile = "local_config.json";
        if (!File.Exists(configFile))
        {
            throw new Exception($"error: could not find local config file: '{configFile}'");
        }

        builder.Configuration.AddJsonFile(configFile);
    }

    /// <summary>
    /// Creates default user accounts.
    /// </summary>
    private static async Task SeedUsers(WebApplication app)
    {
        // The usage of 'scope' originates from: https://stackoverflow.com/questions/71882183/net-6-inject-service-into-program-cs
        using (var scope = app.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;

            var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            var signInManager = serviceProvider.GetRequiredService<SignInManager<User>>();
            var config = serviceProvider.GetRequiredService<IConfiguration>();

            var userSeeder = new UserSeeder();
            await userSeeder.Seed(userManager, config);
        }
    }

    private static void ServeSpa(WebApplication app, WebApplicationBuilder builder)
    {
        // This code originates from: https://medium.com/@rewal34/how-to-serve-your-net-web-api-and-spa-at-same-port-4706b77a50ad
        // Serve the frontend in both dev and prod environments.
        app.UseSpa(spa =>
        {
            spa.Options.SourcePath = "../frontend/Rent-IT";

            bool shouldServeFrontend;
            string? value = builder.Configuration.GetSection("serve_frontend").Value;
            try
            {
                shouldServeFrontend = Convert.ToBoolean(value);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Invalid value for 'serve_frontend' in local_config.json, expected a boolean value got: '{value}'.");
                throw;
            }

            if (builder.Environment.IsProduction())
            {
                app.UseSpaStaticFiles();
            }
            else
            {
                if (shouldServeFrontend)
                {
                    // Serve the Vite dev server from the backend.
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:5173");
                }
            }
        });
    }
}
