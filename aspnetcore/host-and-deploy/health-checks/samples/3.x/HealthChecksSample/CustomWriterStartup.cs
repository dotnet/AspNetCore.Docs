#define SYSTEM_TEXT_JSON

using System;
using System.IO;
using System.Linq;
#if SYSTEM_TEXT_JSON
using System.Text;
using System.Text.Json;
#endif
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
#if !SYSTEM_TEXT_JSON
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
#endif

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
        public void ConfigureServices(IServiceCollection services)
        {
            // <snippet_ConfigureServices>
            services.AddHealthChecks()
                .AddMemoryHealthCheck("memory");
            // </snippet_ConfigureServices>
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    // This custom writer formats the detailed status as JSON.
                    ResponseWriter = WriteResponse
                });

                endpoints.MapGet("/{**path}", async context =>
                {
                    await context.Response.WriteAsync(
                        "Navigate to /health to see the health status.");
                });
            });
        }

#if SYSTEM_TEXT_JSON
        // <snippet_WriteResponse_SystemTextJson>
        private static Task WriteResponse(HttpContext context, HealthReport result)
        {
            context.Response.ContentType = "application/json; charset=utf-8";

            var options = new JsonWriterOptions
            {
                Indented = true
            };

            using (var stream = new MemoryStream())
            {
                using (var writer = new Utf8JsonWriter(stream, options))
                {
                    writer.WriteStartObject();
                    writer.WriteString("status", result.Status.ToString());
                    writer.WriteStartObject("results");
                    foreach (var entry in result.Entries)
                    {
                        writer.WriteStartObject(entry.Key);
                        writer.WriteString("status", entry.Value.Status.ToString());
                        writer.WriteString("description", entry.Value.Description);
                        writer.WriteStartObject("data");
                        foreach (var item in entry.Value.Data)
                        {
                            writer.WritePropertyName(item.Key);
                            JsonSerializer.Serialize(
                                writer, item.Value, item.Value?.GetType() ??
                                typeof(object));
                        }
                        writer.WriteEndObject();
                        writer.WriteEndObject();
                    }
                    writer.WriteEndObject();
                    writer.WriteEndObject();
                }

                var json = Encoding.UTF8.GetString(stream.ToArray());

                return context.Response.WriteAsync(json);
            }
        }
        // </snippet_WriteResponse_SystemTextJson>
#else
        // <snippet_WriteResponse_NewtonSoftJson>
        private static Task WriteResponse(HttpContext context, HealthReport result)
        {
            context.Response.ContentType = "application/json";

            var json = new JObject(
                new JProperty("status", result.Status.ToString()),
                new JProperty("results", new JObject(result.Entries.Select(pair =>
                    new JProperty(pair.Key, new JObject(
                        new JProperty("status", pair.Value.Status.ToString()),
                        new JProperty("description", pair.Value.Description),
                        new JProperty("data", new JObject(pair.Value.Data.Select(
                            p => new JProperty(p.Key, p.Value))))))))));

            return context.Response.WriteAsync(
                json.ToString(Formatting.Indented));
        }
        // </snippet_WriteResponse_NewtonSoftJson>
#endif
    }
}
