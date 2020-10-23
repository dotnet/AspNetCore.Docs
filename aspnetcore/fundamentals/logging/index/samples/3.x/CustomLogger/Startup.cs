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
    public class Startup
    {
        public Startup(IConfiguration configuration)
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
            // Default registration.
            loggerFactory.AddProvider(new ColorConsoleLoggerProvider(
                                      new ColorConsoleLoggerConfiguration
            {
                LogLevel = LogLevel.Error,
                Color = ConsoleColor.Red
            }));

            // Custom registration with default values.
            loggerFactory.AddColorConsoleLogger();

            // Custom registration with a new configuration instance.
            loggerFactory.AddColorConsoleLogger(new ColorConsoleLoggerConfiguration
            {
                LogLevel = LogLevel.Debug,
                Color = ConsoleColor.Gray
            });

            // Custom registration with a configuration object.
            loggerFactory.AddColorConsoleLogger(c =>
            {
                c.LogLevel = LogLevel.Information;
                c.Color = ConsoleColor.Blue;
            });

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
        #endregion
    }
}
