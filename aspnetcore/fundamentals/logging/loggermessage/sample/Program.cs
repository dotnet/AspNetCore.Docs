using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace LoggerMessageSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        #region snippet1
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        #endregion
    }
}
