using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AreasRouting
{
    public class Startup6
    {
        public Startup6(IConfiguration configuration)
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

            #region snippet3
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(name: "duck_route", 
                                                 areaName: "Duck",
                                                 pattern: "{area}/{controller}/{action}/{id?}");
                endpoints.MapControllerRoute(name: "default",
                                             pattern: "{area=Duck}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default_route", "{controller}/{action}/{id?}");
            });
            #endregion
        }
    }
}