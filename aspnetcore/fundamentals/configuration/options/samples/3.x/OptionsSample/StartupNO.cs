using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SampleApp.Models;

namespace SampleApp
{
    public class StartupNO
    {
        public StartupNO(IConfiguration config)
        {
            Configuration = config;
        }

        public IConfiguration Configuration { get; set; }

        // Used in TestNO and set StartupNO in main.
        // <snippet_Example2>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<TopItemSettings>(TopItemSettings.Month,
                                               Configuration.GetSection("TopItem:Month"));
            services.Configure<TopItemSettings>(TopItemSettings.Year,
                                                Configuration.GetSection("TopItem:Year"));

            services.AddRazorPages();
        }
        // </snippet_Example2>

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
