
using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Identity;

namespace backend;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<RentalContext>();

        AddLocalConfig(builder);
        
        // Add services to the container.
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();


        // Add identity tokens.
        builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<RentalContext>().AddDefaultTokenProviders();

        // Add identity endpoints.
        builder.Services.AddIdentityApiEndpoints<Admin>().AddEntityFrameworkStores<RentalContext>();
        builder.Services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<RentalContext>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        // Add registering, login and logout endpoints.
        app.MapIdentityApi<Admin>();
        app.MapIdentityApi<User>();

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
