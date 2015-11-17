using CachingSample.Abstractions;
using CachingSample.Services;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.Caching.Memory;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;

namespace CachingSample
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCaching();

            services.AddTransient<ITimeService, TimeService>();
            services.AddTransient<IGreetingService, GreetingService>();
        }

        public void Configure(IApplicationBuilder app,
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            // Add the platform handler to the request pipeline.
            app.UseIISPlatformHandler();

            app.UseGreetingMiddleware();
        }
    }
}
