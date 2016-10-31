using CachingSample.Abstractions;
using CachingSample.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CachingSample
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMemoryCache();

            services.AddTransient<ITimeService, TimeService>();
            services.AddTransient<IGreetingService, GreetingService>();
        }

        public void Configure(IApplicationBuilder app,
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseGreetingMiddleware();
        }
    }
}
