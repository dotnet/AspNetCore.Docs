using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;

namespace MethodConventions
{
    #region snippet
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private void StartupConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
        }

        public void ConfigureStagingServices(IServiceCollection services)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
            StartupConfigureServices(services);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);
            StartupConfigureServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }

        public void ConfigureStaging(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Console.WriteLine(MethodBase.GetCurrentMethod().Name);

            if (!env.IsStaging())
            {
                throw new Exception("Not staging.");
            }

            app.UseExceptionHandler("/Error");
            app.UseHsts();


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
    #endregion
}