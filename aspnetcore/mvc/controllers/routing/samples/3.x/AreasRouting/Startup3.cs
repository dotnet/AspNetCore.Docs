using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AreasRouting
{
    public class Startup3
    {
        public Startup3(IConfiguration configuration)
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
                endpoints.MapAreaControllerRoute("duck_route", "Duck",
                                                 "Manage/{controller}/{action}/{id?}");
                endpoints.MapControllerRoute("default",
                                             "Manage/{controller=Home}/{action=Index}/{id?}");
            });
            #endregion
        }
    }
}