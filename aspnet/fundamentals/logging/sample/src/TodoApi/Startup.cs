using System;
using System.Diagnostics;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using TodoApi.Middleware;

namespace TodoApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app,
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.Run(async (context) =>
            {
                var logger = loggerFactory.CreateLogger("LoggingSample.Startup");
                logger.LogInformation("Writing output.");
                await context.Response.WriteAsync("Hello World!");
            });
        }

        public void ConfigureLogMiddleware(IApplicationBuilder app,
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(minLevel: LogLevel.Debug);
            app.UseRequestLogger();

            app.Run(async context =>
            {
                if (context.Request.Path.Value.Contains("boom"))
                {
                    throw new Exception("boom!");
                }
                await context.Response.WriteAsync("Hello World!");
            });
        }

        public void ConfigureTraceLogging(IApplicationBuilder app,
            ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Debug;

#if DNX451
            var sourceSwitch = new SourceSwitch("LoggingSample");
            sourceSwitch.Level = SourceLevels.Critical;
            loggerFactory.AddTraceSource(sourceSwitch,
                new ConsoleTraceListener(false));
            loggerFactory.AddTraceSource(sourceSwitch,
                new EventLogTraceListener("Application"));
#endif

            app.UseRequestLogger();

            app.Run(async context =>
            {
                if (context.Request.Path.Value.Contains("boom"))
                {
                    throw new Exception("boom!");
                }
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
