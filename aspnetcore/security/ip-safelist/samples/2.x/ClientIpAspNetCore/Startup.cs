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

        #region snippet_ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        {
            #region snippet_ConfigureServicesActionFilter
            services.AddScoped<ClientIpCheckActionFilter>(_ =>
                new ClientIpCheckActionFilter(Configuration)
                {
                    Logger = _loggerFactory.CreateLogger<ClientIpCheckActionFilter>()
                });
            #endregion snippet_ConfigureServicesActionFilter

            #region snippet_ConfigureServicesPageFilter
            services.AddMvc(options => {
                var clientIpCheckPageFilter = new ClientIpCheckPageFilter(Configuration)
                {
                    Logger = _loggerFactory.CreateLogger<ClientIpCheckPageFilter>()
                };
                options.Filters.Add(clientIpCheckPageFilter);
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            #endregion snippet_ConfigureServicesPageFilter
        }
        #endregion

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
