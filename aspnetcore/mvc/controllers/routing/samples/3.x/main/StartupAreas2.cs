using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebMvcRouting
{
    public class StartupAreas2
    {
        public StartupAreas2(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseRouting();

            app.UseAuthorization();

            #region snippet_1
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("Zebra_route", "Manage/{controller}/{action}/{id?}",
                    defaults: new { area = "Zebra" }, constraints: new { area = "Zebra" });
                endpoints.MapControllerRoute("default_route", "{controller}/{action}/{id?}");
            });
            #endregion
        }
    }
}