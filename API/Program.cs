using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // Purpose of 'using': once the Main method is finished, the the scope is to be disposed of by the framework
            // This scope hosts any services that we create inside this particular method
            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;

            try
            {
                // Get hold of data context
                var context = services.GetRequiredService<DataContext>();
                // Apply migration
                await context.Database.MigrateAsync();
                await Seed.SeedData(context);

            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occured during migration");
            }

            // Start the application
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
