// ASP.NET Core Startup class

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MyApp.Middleware;

namespace Asp.Net.Core
{
    public class Startup
    {
        #region snippet_Ctor
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        #endregion

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        #region snippet_ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        {
            // Setup options service
            services.AddOptions();

            // Load options from section "MyMiddlewareOptionsSection"
            services.Configure<MyMiddlewareOptions>(
                Configuration.GetSection("MyMiddlewareOptionsSection"));

            // Add framework services.
            services.AddMvc();
        }
        #endregion

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        #region snippet_Configure
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseMyMiddleware();

            app.UseMyMiddlewareWithParams();

            var myMiddlewareOptions = Configuration.GetSection("MyMiddlewareOptionsSection").Get<MyMiddlewareOptions>();
            var myMiddlewareOptions2 = Configuration.GetSection("MyMiddlewareOptionsSection2").Get<MyMiddlewareOptions>();
            app.UseMyMiddlewareWithParams(myMiddlewareOptions);
            app.UseMyMiddlewareWithParams(myMiddlewareOptions2);

            app.UseMyTerminatingMiddleware();

            // Create branch to the MyHandlerMiddleware. 
            // All requests ending in .report will follow this branch.
            app.MapWhen(
                context => context.Request.Path.ToString().EndsWith(".report"),
                appBranch => {
                    // ... optionally add more middleware to this branch
                    appBranch.UseMyHandler();
                });

            app.MapWhen(
                context => context.Request.Path.ToString().EndsWith(".context"),
                appBranch => {
                    appBranch.UseHttpContextDemoMiddleware();
                });

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
        #endregion
    }
}




















//