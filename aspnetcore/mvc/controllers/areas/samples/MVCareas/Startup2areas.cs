using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MVCareas
{
    public class Startup2areas
    {
        public Startup2areas(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
                routes.MapRoute(
                      name: "MyAreaP",
                      template: "{area:Products}/{controller=Home}/{action=Index}/{id?}"
                    );
                routes.MapRoute(
                  name: "MyAreaS",
                  template: "{area:Services}/{controller=Home}/{action=Index}/{id?}"
                );
                routes.MapRoute(
                   name: "default",
                   template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        #endregion
    }
}
