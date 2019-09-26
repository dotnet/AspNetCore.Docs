using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace aspnetcoreapp
{
    #region snippet
    // requires using Microsoft.AspNetCore.Hosting;
    // requires using Microsoft.Extensions.Hosting;
    
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
