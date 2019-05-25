using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace GrcpService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
            webBuilder.ConfigureKestrel((context, options) =>
            {
                options.Limits.MinRequestBodyDataRate = null;
            });
        });
    }
}
