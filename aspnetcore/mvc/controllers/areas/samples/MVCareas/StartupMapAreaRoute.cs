using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MVCareas
{
    public class StartupMapAreaRoute
    {
        public StartupMapAreaRoute(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
                   options.EnableEndpointRouting = false)
                   .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        #region snippet
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

            app.UseMvc(routes =>
            {
                routes.MapAreaRoute(
                    name: "MyAreaProducts",
                    areaName:"Products",
                    template: "Products/{controller=Home}/{action=Index}/{id?}");

                routes.MapAreaRoute(
                    name: "MyAreaServices",
                    areaName: "Services",
                    template: "Services/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        #endregion
    }
}
