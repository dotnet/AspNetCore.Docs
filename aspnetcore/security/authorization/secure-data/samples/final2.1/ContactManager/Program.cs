using ContactManager.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace ContactManager
{
    #region snippet
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();

                // requires using Microsoft.Extensions.Configuration;
                var config = host.Services.GetRequiredService<IConfiguration>();
                // Set password with the Secret Manager tool.
                // dotnet user-secrets set SeedUserPW <pw>

                var testUserPw = config["SeedUserPW"];
                try
                {
                    SeedData.Initialize(services, testUserPw).Wait();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex.Message, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
    #endregion
}