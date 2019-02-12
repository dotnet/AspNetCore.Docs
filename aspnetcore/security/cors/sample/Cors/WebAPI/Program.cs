using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                //.UseStartup<Startup>();
                //.UseStartup<Startup2>();
                //.UseStartup<Startup3>();
                .UseStartup<StartupMultiPolicy>();
       // .UseStartup<StartupAttributeTest>();
    }
}