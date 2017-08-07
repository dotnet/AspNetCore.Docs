#define BaseSample // or ProviderFilter or FactoryFilter or TraceSource or Scopes

using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TodoApi.Core.Interfaces;
using TodoApi.Infrastructure;

namespace TodoApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Add our repository type
            services.AddScoped<ITodoRepository, TodoRepository>();
        }

#if BaseSample
        #region snippet_AddConsoleAndDebug
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            loggerFactory
                .AddConsole()
                .AddDebug();
            #endregion

            app.UseStaticFiles();

            app.UseMvc();

            app.Run(async (context) =>
            {
                var logger = loggerFactory.CreateLogger("TodoApi.Startup");
                logger.LogInformation("No endpoint found for request {path}", context.Request.Path);
                await context.Response.WriteAsync("No endpoint found - try /api/todo.");
            });
        }
#elif ProviderFilter
        #region snippet_AddConsoleAndDebugWithFilter
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            loggerFactory
                .AddConsole(LogLevel.Warning)
                .AddDebug((category, logLevel) => (category.Contains("TodoApi") && logLevel >= LogLevel.Trace));
        #endregion

            app.UseStaticFiles();

            app.UseMvc();

            app.Run(async (context) =>
            {
                var logger = loggerFactory.CreateLogger("TodoApi.Startup");
                logger.LogInformation("No endpoint found for request {path}", context.Request.Path);
                await context.Response.WriteAsync("No endpoint found - try /api/todo.");
            });
        }
#elif FactoryFilter
        #region snippet_FactoryFilter
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            loggerFactory
                .WithFilter(new FilterLoggerSettings
                {
                    { "Microsoft", LogLevel.Warning },
                    { "System", LogLevel.Warning },
                    { "ToDoApi", LogLevel.Debug }
                })
                .AddConsole()
                .AddDebug();
        #endregion

            app.UseStaticFiles();

            app.UseMvc();

            app.Run(async (context) =>
            {
                var logger = loggerFactory.CreateLogger("TodoApi.Startup");
                logger.LogInformation("No endpoint found for request {path}", context.Request.Path);
                await context.Response.WriteAsync("No endpoint found - try /api/todo.");
            });
        }
#elif TraceSource
        #region snippet_TraceSource
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            loggerFactory
                .AddDebug();

            // add Trace Source logging
            var testSwitch = new SourceSwitch("sourceSwitch", "Logging Sample");
            testSwitch.Level = SourceLevels.Warning;
            loggerFactory.AddTraceSource(testSwitch,
                new TextWriterTraceListener(writer: Console.Out));
        #endregion

            app.UseStaticFiles();

            app.UseMvc();

            app.Run(async (context) =>
            {
                var logger = loggerFactory.CreateLogger("TodoApi.Startup");
                logger.LogInformation("No endpoint found for request {path}", context.Request.Path);
                await context.Response.WriteAsync("No endpoint found - try /api/todo.");
            });
        }
#elif Scopes
        #region snippet_Scopes
        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            loggerFactory
                .AddConsole(includeScopes: true)
                .AddDebug();
        #endregion

            app.UseStaticFiles();

            app.UseMvc();

            app.Run(async (context) =>
            {
                var logger = loggerFactory.CreateLogger("TodoApi.Startup");
                logger.LogInformation("No endpoint found for request {path}", context.Request.Path);
                await context.Response.WriteAsync("No endpoint found - try /api/todo.");
            });
        }

#endif
    }
}
