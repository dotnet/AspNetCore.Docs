//#define MAINcolor
//#define MAIN
//#define MAIN2
//#define MyCusomPrefix_

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
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

#if MAINcolor
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
                   // webBuilder.UseStartup<Startup2>();
                   // webBuilder.UseStartup<Startup3>();
                    webBuilder.UseStartup<Startup4>();


                });
    }
}
#endif

// Use this to test reading config keys in Startup
// And anything else that doesn't add 
// services.Configure<PositionOptions>(Configuration.GetSection(PositionOptions.Position));
// to startup
// remove comments from  webBuilder.UseStartup<ConfigSampleKey.Startup>();
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
                 //   webBuilder.UseStartup<ConfigSampleKey.Startup>();
                    webBuilder.UseStartup<StartupMVC>();

                });
    }
}
#endif

#if MyCusomPrefix_

namespace ConfigSample
{
#region snippet4
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddEnvironmentVariables(prefix: "MyCustomPrefix_");
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
#endregion
}
#endif