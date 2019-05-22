// This file, StartupGF (for Global Filters) is used only to provide a snippet showing
// Global filters

using FiltersSample.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FiltersSample
{
    public class StartupGF
    {
        public StartupGF(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        #region snippet_ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(new AddHeaderAttribute("GlobalAddHeader",
                    "Result filter added to MvcOptions.Filters"));         // An instance
                options.Filters.Add(typeof(MySampleActionFilter));         // By type
                options.Filters.Add(new SampleGlobalActionFilter());       // An instance
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
        #endregion

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
