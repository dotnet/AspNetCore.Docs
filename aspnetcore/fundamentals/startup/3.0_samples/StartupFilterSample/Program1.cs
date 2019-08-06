//#define B
#if B
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace StartupFilterSample
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
               .ConfigureAppConfiguration((hostingContext, config) =>
               {
               })
            .ConfigureServices(services =>
            {
                services.AddControllersWithViews();

            }).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.Configure(app =>
                {
                    var loggerFactory = app.ApplicationServices
                            .GetRequiredService<ILoggerFactory>();
                    var logger = loggerFactory.CreateLogger<Program>();
                    var env = app.ApplicationServices.GetRequiredService<IWebHostEnvironment>();
                    var config = app.ApplicationServices.GetRequiredService<IConfiguration>();

                    logger.LogInformation("Logged in Configure");

                    if (env.IsDevelopment())
                    {
                        app.UseDeveloperExceptionPage();
                    }
                    else
                    {
                        app.UseExceptionHandler("/Home/Error");
                        app.UseHsts();
                    }

                    var configValue = config["MyConfigKey"];
                }
                );
            });
    }
#endregion
}
#endif
