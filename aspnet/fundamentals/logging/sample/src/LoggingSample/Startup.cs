using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;

namespace LoggingSample
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
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
            ILoggerFactory loggerfactory)
        {
            loggerfactory.AddConsole(minLevel: LogLevel.Information);

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
