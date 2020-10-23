using System;
using System.Threading.Tasks;
using BlazorServerDbContextExample.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BlazorServerDbContextExample
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // this section sets up and seeds the database. It would NOT normally
            // be done this way in production. It is here to make the sample easier,
            // i.e. clone, set connection string and run.
            var sp = host.Services.GetService<IServiceScopeFactory>()
                .CreateScope()
                .ServiceProvider;
            var options = sp.GetRequiredService<DbContextOptions<ContactContext>>();
            await EnsureDbCreatedAndSeedWithCountOfAsync(options, 500);
            // back to your regularly scheduled program

            await host.RunAsync();
        }
        
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        /// <summary>
        /// Method to see the database. Should not be used in production: demo purposes only.
        /// </summary>
        /// <param name="options">The configured options.</param>
        /// <param name="count">The number of contacts to seed.</param>
        /// <returns>The <see cref="Task"/>.</returns>
        private static async Task EnsureDbCreatedAndSeedWithCountOfAsync(DbContextOptions<ContactContext> options, int count)
        {
            // empty to avoid logging while inserting (otherwise will flood console)
            var factory = new LoggerFactory();
            var builder = new DbContextOptionsBuilder<ContactContext>(options)
                .UseLoggerFactory(factory);

            using var context = new ContactContext(builder.Options);
            // result is true if the database had to be created
            if (await context.Database.EnsureCreatedAsync())
            {
                var seed = new SeedContacts();
                await seed.SeedDatabaseWithContactCountOfAsync(context, count);
            }
        }
    }
}
