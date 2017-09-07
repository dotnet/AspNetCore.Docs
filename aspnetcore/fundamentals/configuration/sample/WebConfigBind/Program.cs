using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebConfigBind
{
    public class Program
    {
        public static IConfiguration Configuration { get; set; }
        public static IHostingEnvironment Environment { get; set; }

        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    Configuration = config.Build();
                    Environment = hostingContext.HostingEnvironment;
                })
                #region snippet1
                .ConfigureServices(services =>
                {
                    services.Configure<MyWindow>(
                        Configuration.GetSection("AppConfiguration:MainWindow"));
                    services.AddMvc();
                })
                #endregion
                .Configure(app =>
                {
                    if (Environment.IsDevelopment())
                    {
                        app.UseDeveloperExceptionPage();
                        app.UseBrowserLink();
                    }
                    else
                    {
                        app.UseExceptionHandler("/Home/Error");
                    }

                    app.UseStaticFiles();
                    app.UseMvcWithDefaultRoute();
                })
                .Build();
    }
}
