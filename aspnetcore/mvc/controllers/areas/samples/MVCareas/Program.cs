#define DEFAULT

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MVCareas
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
#if DEFAULT
                     .UseStartup<Startup>();
#else
                     .UseStartup<StartupMapAreaRoute>();
#endif
    }
}
