#define first1

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DIsample2
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
#if first
                    webBuilder.UseStartup<Startup>();
#else
                    webBuilder.UseStartup<Startup2>();
#endif

                });
    }
}
