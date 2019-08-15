using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace EnvironmentsSample
{
    #region snippet_Program
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseSetting("https_port", "8080")
                .UseStartup<Startup>();
    }
    #endregion
}
