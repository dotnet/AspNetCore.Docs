using System.Diagnostics;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
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

        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(minLevel:LogLevel.Verbose);

            app.UseStaticFiles();

            app.UseMvc();

            // Create a catch-all response
            app.Run(async (context) =>
            {
                var logger = loggerFactory.CreateLogger("Catchall Endpoint");
                logger.LogInformation("No endpoint found for request {path}", context.Request.Path);
                await context.Response.WriteAsync("No endpoint found - try /api/todo.");
            });

            loggerFactory.MinimumLevel = LogLevel.Debug;
#if DNX451
            var sourceSwitch = new SourceSwitch("LoggingSample");
            sourceSwitch.Level = SourceLevels.Critical;
            loggerFactory.AddTraceSource(sourceSwitch,
                new ConsoleTraceListener(false));
            loggerFactory.AddTraceSource(sourceSwitch,
                new EventLogTraceListener("Application"));
#endif

        }
    }
}