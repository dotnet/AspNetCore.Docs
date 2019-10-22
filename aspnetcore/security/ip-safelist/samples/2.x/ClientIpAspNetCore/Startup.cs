using System.IO;
using System.Linq;
using ClientIpAspNetCore.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using NLog.Targets;

namespace ClientIpAspNetCore
{
    public class Startup
    {
        ILoggerFactory _loggerFactory;
      
        public Startup(ILoggerFactory loggerFactory, IHostingEnvironment env)
        {
            _loggerFactory = loggerFactory;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        
        #region snippet_ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ClientIpCheckFilter>();

            services.AddMvc(options =>
            {
                options.Filters.Add
                    (new ClientIpCheckPageFilter
                        (_loggerFactory, Configuration));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
        #endregion
        
        #region snippet_Configure
        public void Configure(
            IApplicationBuilder app, 
            IHostingEnvironment env, 
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();

            app.UseStaticFiles();

            app.UseMiddleware<AdminSafeListMiddleware>(Configuration["AdminSafeList"]);
            app.UseMvc();
        }
        #endregion
    }
}
