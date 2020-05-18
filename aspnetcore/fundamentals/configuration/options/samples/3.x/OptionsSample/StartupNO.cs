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

        // Used in Test3
        #region snippet_Example2
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MyOptions>("named_options_1", Configuration);
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
