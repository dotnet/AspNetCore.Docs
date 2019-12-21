using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace FiltersSample
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
                    //webBuilder.UseStartup<StartupAsync>();
                    //webBuilder.UseStartup<StartupAsync>();
                    //webBuilder.UseStartup<StartupAsync>();
                    //webBuilder.UseStartup<StartupAsync>();
                });
    }
}
