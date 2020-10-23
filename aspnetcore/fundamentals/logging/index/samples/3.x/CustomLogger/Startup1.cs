using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CustomLogger.ColorConsoleLogger;

namespace CustomLogger
{
    public class Startup1
    {
        public Startup1(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        #region snippet
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, 
                              ILoggerFactory loggerFactory)
        {
            loggerFactory.AddProvider(new ColorConsoleLoggerProvider(
                                      new ColorConsoleLoggerConfiguration
            {
                LogLevel = LogLevel.Information,
                Color = ConsoleColor.Blue
            }));

            loggerFactory.AddProvider(new ColorConsoleLoggerProvider(
                                      new ColorConsoleLoggerConfiguration
            {
                LogLevel = LogLevel.Debug,
                Color = ConsoleColor.Gray
            }));

            // Remaining code ommited for brevity.
            #endregion

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
