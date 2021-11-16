using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RoutingSample
{
    public class StartupUnsupported
    {
        public StartupUnsupported(IConfiguration configuration)
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

            // <snippet>
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", 
                                                 "{culture}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("blog", "{culture}/{**slug}", 
                                                  new { controller = "Blog", action = "ReadPost", });
            });
            // </snippet>
        }
    }
}
