using backend.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Data.Common;

namespace BackendTestProject
{
    public class AppFactory<T> : WebApplicationFactory<T>
        where T : class
    {
        // Source: https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-9.0#customize-webapplicationfactory
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContextDescriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<RentalContext>));

                services.Remove(dbContextDescriptor);

                var dbConnectionDescriptor = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbConnection));

                services.Remove(dbConnectionDescriptor);

                services.RemoveAll(typeof(DbContextOptions<RentalContext>));
                services.RemoveAll(typeof(RentalContext));

                // Get a unique in memory database for each integration test.
                var guid = Guid.NewGuid().ToString();
                services.AddDbContext<RentalContext>(options =>
                {
                    options.UseSqlServer($"Server=(localdb)\\MSSQLLocalDB;Database=RentIT_Test-{guid};Trusted_Connection=True;");
                });

                var serviceProvider = services.BuildServiceProvider();
                using (var scope = serviceProvider.CreateScope())
                {
                    var context = scope.ServiceProvider.GetRequiredService<RentalContext>();
                    context.Database.EnsureDeleted();
                    context.Database.Migrate();
                    context.SaveChanges();
                }
            });

            builder.UseEnvironment("Test");
        }
    }
}
