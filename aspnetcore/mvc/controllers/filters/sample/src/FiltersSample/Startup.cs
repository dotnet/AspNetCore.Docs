using FiltersSample.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FiltersSample
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        #region snippet_ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.Filters.Add(new AddHeaderAttribute("GlobalAddHeader", 
                    "Result filter added to MvcOptions.Filters")); // an instance
                options.Filters.Add(typeof(SampleActionFilter)); // by type
                options.Filters.Add(new SampleGlobalActionFilter()); // an instance
            });

            services.AddScoped<AddHeaderFilterWithDi>();
        }
        #endregion

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(minLevel: LogLevel.Debug)
                .AddDebug(minLevel: LogLevel.Debug);

            app.UseMvcWithDefaultRoute();
        }
    }
}
