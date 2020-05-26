using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SampleApp.Models;

namespace SampleApp
{
    public class Startup1
    {
        public Startup1(IConfiguration config)
        {
            Configuration = config;
        }

        public IConfiguration Configuration { get; set; }

        // No special config needed.
        #region snippet_Example2
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }
        #endregion

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
