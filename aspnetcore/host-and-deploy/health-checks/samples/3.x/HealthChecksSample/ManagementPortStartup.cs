using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SampleApp
{
    // Use the `--scenario port` switch to run this version of the sample.
    //
    // RequireHost with a port only processes health checks requests on a connection to the specified URI. This is typically used in a container environment to expose a port for monitoring services.
    //  The management port is configured in the launchSettings.json file and passed through an environment variable.
    //  The server must also be configured to listen to requests on the management port.

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

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health")
                    .RequireHost($"*:{Configuration["ManagementPort"]}");

                endpoints.MapGet("/{**path}", async context =>
                {
                    await context.Response.WriteAsync(
                        "Navigate to " + 
                        $"http://localhost:{Configuration["ManagementPort"]}/health " +
                        "to see the health status.");
                });
            });
        }
    }
    
}
