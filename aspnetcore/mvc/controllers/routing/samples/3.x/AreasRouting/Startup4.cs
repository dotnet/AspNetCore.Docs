using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AreasRouting
{
    public class Startup4
    {
        public Startup4(IConfiguration configuration)
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

            #region snippet1
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute("blog_route", "Blog",
                    "Manage/{controller}/{action}/{id?}");
                endpoints.MapAreaControllerRoute("zebra_route", "Zebra",
                   "Zebra/{controller}/{action}/{id?}");
                endpoints.MapAreaControllerRoute("duck_route", "Duck",
                   "Duck/{controller}/{action}/{id?}");
                endpoints.MapControllerRoute("default_route", "{controller}/{action}/{id?}");
            });
            #endregion
        }
    }
}
