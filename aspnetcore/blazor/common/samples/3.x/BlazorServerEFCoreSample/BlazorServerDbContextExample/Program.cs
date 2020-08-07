using System.Threading.Tasks;
using BlazorServerDbContextExample.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            var options = host.Services.GetService<IServiceScopeFactory>()
                .CreateScope()
                .ServiceProvider
                .GetRequiredService<DbContextOptions<ContactContext>>();
            await options.EnsureDbCreatedAndSeedWithCountOfAsync(500);
            // back to your regularly scheduled program

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
