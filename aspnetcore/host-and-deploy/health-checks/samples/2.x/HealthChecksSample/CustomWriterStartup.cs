using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SampleApp
{
    // Use the `--scenario writer` switch to run this version of the sample.
    //
    // This is an example of registering a custom health check as a service. All IHealthCheck services are available to the health check service and middleware. We recommend registering all health checks as Singleton services.
    //
    // Register Health Check Middleware at the URL: /health
    // 
    // This example overrides the HealthCheckOptions.ResponseWriter to write a custom health check result.

    public class CustomWriterStartup
    {
        #region snippet_ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks()
                .AddMemoryHealthCheck("memory");
        }
        #endregion

        #region snippet_Configure
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHealthChecks("/health", new HealthCheckOptions()
            {
                // This custom writer formats the detailed status as JSON.
                ResponseWriter = WriteResponse
            });
        #endregion

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync(
                    "Navigate to /health to see the health status.");
            });
        }

        #region snippet_WriteResponse
        private static Task WriteResponse(HttpContext httpContext, 
            HealthReport result)
        {
            httpContext.Response.ContentType = "application/json";

            var json = new JObject(
                new JProperty("status", result.Status.ToString()),
                new JProperty("results", new JObject(result.Entries.Select(pair =>
                    new JProperty(pair.Key, new JObject(
                        new JProperty("status", pair.Value.Status.ToString()),
                        new JProperty("description", pair.Value.Description),
                        new JProperty("data", new JObject(pair.Value.Data.Select(
                            p => new JProperty(p.Key, p.Value))))))))));
            return httpContext.Response.WriteAsync(
                json.ToString(Formatting.Indented));
        }
        #endregion
    }
}
