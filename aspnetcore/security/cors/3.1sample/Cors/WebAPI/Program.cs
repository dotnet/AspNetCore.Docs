#define StartupTest

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WebAPI
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
#if StartupTest
                    // Deploy to Cors1
                    webBuilder.UseStartup<StartupTest2>();

#else
                    // Use StartupEndPointBugTest with Test2 to repo 
                    // https://github.com/dotnet/aspnetcore/issues/18665
                    // Deploy to Cors3
                    webBuilder.UseStartup<StartupEndPointBugTest>();
#endif
                });
    }
}
