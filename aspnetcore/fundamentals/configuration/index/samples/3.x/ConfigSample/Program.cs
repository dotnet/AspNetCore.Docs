//#define MAIN
#define MAIN2
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

#if MAIN
namespace ConfigSample
{
#region snippet
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
                });
    }
#endregion
}
#endif

// Use this to test reading config keys in Startup
#if MAIN2
namespace ConfigSample
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
                    webBuilder.UseStartup<ConfigSampleKey.Startup>();
                });
    }
}
#endif
