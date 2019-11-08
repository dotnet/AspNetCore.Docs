using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SampleApp
{
    // Use the `--scenario port` switch to run this version of the sample.
    //
    // UseHealthChecks with a port only processes health checks requests on a connection to the specified port. This is typically used in a container environment to expose a port for monitoring services.
    //  The management port is configured in the launchSettings.json file and passed through an environment variable.
    //  The server must also be configured to listen to requests on the management port.

    #region snippet1
    public class ManagementPortStartup
    {
        public ManagementPortStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHealthChecks("/health", port: Configuration["ManagementPort"]);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(
                    "Navigate to " + 
                    $"http://localhost:{Configuration["ManagementPort"]}/health " +
                    "to see the health status.");
            });
        }
    }
    #endregion
}
