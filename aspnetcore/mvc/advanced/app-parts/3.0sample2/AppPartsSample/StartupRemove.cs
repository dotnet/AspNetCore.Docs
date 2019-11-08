using AppPartsSample;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Reflection;

namespace WebAppParts
{
    public class StartupRemove
    {
        public StartupRemove(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        #region snippet
        public void ConfigureServices(IServiceCollection services)
        {
            var pluginAssembly = Assembly.Load(new AssemblyName("Plugin"));
            services.AddControllersWithViews()
                .AddApplicationPart(pluginAssembly)
                .ConfigureApplicationPartManager(p =>
                {
                    var dependentLibrary = p.ApplicationParts
                                .FirstOrDefault(part => part.Name == "DependentLibrary");
                    if (dependentLibrary != null)
                    {
                        p.ApplicationParts.Remove(dependentLibrary);
                    }
                })
                .ConfigureApplicationPartManager(p =>
                   p.FeatureProviders.Add(new GenericControllerFeatureProvider()));
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
