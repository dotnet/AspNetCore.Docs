using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace StartupFilterSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            #region snippet1
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<IStartupFilter, 
                        RequestSetOptionsStartupFilter>();
                })
                .UseStartup<Startup>()
                .Build();
            #endregion
    }
}
