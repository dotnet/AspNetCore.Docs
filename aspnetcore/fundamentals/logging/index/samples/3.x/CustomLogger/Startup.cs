using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CustomLogger.ColoredConsoleLogger;

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
            loggerFactory.AddProvider(new ColoredConsoleLoggerProvider(
                                      new ColoredConsoleLoggerConfiguration
            {
                LogLevel = LogLevel.Error,
                Color = ConsoleColor.Red
            }));

            // Custom registration with default values.
            loggerFactory.AddColoredConsoleLogger();

            // Custom registration with a new configuration instance.
            loggerFactory.AddColoredConsoleLogger(new ColoredConsoleLoggerConfiguration
            {
                LogLevel = LogLevel.Debug,
                Color = ConsoleColor.Gray
            });

            // Custom registration with a configuration object.
            loggerFactory.AddColoredConsoleLogger(c =>
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
