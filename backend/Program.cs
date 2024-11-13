
using backend.Data;
using backend.Models;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

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

        // Add identity store.
        builder.Services.AddIdentityApiEndpoints<User>().AddEntityFrameworkStores<RentalContext>();

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
