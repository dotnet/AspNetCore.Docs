using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SampleApp.Models;

namespace SampleApp
{
    public class StartupAll
    {
        public StartupAll(IConfiguration config)
        {
            Configuration = config;
        }

        public IConfiguration Configuration { get; set; }

        // Used in TestAll
        // <snippet_Example2>
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureAll<TopItemSettings>(options =>
            {
                options.Model = "ConfigureAll replacement value";
            });

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
