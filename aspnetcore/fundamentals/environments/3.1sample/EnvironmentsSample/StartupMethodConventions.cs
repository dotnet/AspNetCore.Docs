using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

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
            MyTrace.TraceMessage();
            StartupConfigureServices(services);
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {
            MyTrace.TraceMessage();
            StartupConfigureServices(services);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            MyTrace.TraceMessage();
            StartupConfigureServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            MyTrace.TraceMessage();

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
            MyTrace.TraceMessage();

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

    public static class MyTrace
    {
        public static void TraceMessage([System.Runtime.CompilerServices.CallerMemberName] 
                                        string memberName = "")
        {
            Console.WriteLine($"Method: {memberName}");
        }
    }
    #endregion
}