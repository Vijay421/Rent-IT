using backend.Data;
using backend.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendTestProject
{
    public class AppFactory<T> : WebApplicationFactory<T>
        where T : class
    {
        // Source: https://learn.microsoft.com/en-us/aspnet/core/test/integration-tests?view=aspnetcore-9.0#customize-webapplicationfactory
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
/*            builder.ConfigureServices(services =>
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

                // Create open SqliteConnection so EF won't automatically close it.
                services.AddSingleton<DbConnection>(container =>
                {
                    var connection = new SqliteConnection("DataSource=:memory:");
                    connection.Open();

                    return connection;
                });

                *//*services.RemoveAll(typeof(DbContextOptions<RentalContext>));*//*

                services.AddDbContext<RentalContext>((container, options) =>
                {
                    var connection = container.GetRequiredService<DbConnection>();
                    options.UseSqlite(connection);
                });

                var serviceProvider = services.BuildServiceProvider();
                var scope = serviceProvider.CreateScope();
                var context = scope.ServiceProvider.GetService<RentalContext>();

                context.Database.EnsureDeleted();
                *//*context.Database.Migrate();*//*
                context.Database.EnsureCreated();
                context.Voertuigen.Add(new Voertuig(1, "Toyota", "Corolla", "AB-123-CD", "Red", 2018, "Auto", "", "Verhuurbaar", 50.00, new DateOnly(2025, 1, 1), new DateOnly(2025, 1, 4), null));
                context.SaveChanges();
            });*/

            builder.UseEnvironment("Test");
        }
    }
}
