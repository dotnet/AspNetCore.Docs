using ClientIpSafelistComponents.Filters;
using ClientIpSafelistComponents.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ClientIpAspNetCore
{
    public class Startup
    {
        private readonly ILoggerFactory _loggerFactory;
      
        public Startup(
            ILoggerFactory loggerFactory,
            IConfiguration configuration)
        {
            _loggerFactory = loggerFactory;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region snippet_ConfigureServicesActionFilter
            services.AddScoped<ClientIpCheckActionFilter>(_ =>
            {
                var logger = _loggerFactory.CreateLogger<ClientIpCheckActionFilter>();
                
                return new ClientIpCheckActionFilter(
                    Configuration["AdminSafeList"], logger);
            });
            #endregion snippet_ConfigureServicesActionFilter

            #region snippet_ConfigureServicesPageFilter
            services.AddMvc(options =>
            {
                var logger = _loggerFactory.CreateLogger<ClientIpCheckPageFilter>();
                var clientIpCheckPageFilter = new ClientIpCheckPageFilter(
                    Configuration["AdminSafeList"], logger);
                
                options.Filters.Add(clientIpCheckPageFilter);
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            #endregion snippet_ConfigureServicesPageFilter
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            #region snippet_ConfigureAddMiddleware
            app.UseMiddleware<AdminSafeListMiddleware>(Configuration["AdminSafeList"]);
            #endregion snippet_ConfigureAddMiddleware
            app.UseMvc();
        }
    }
}
