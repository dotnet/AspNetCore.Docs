using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RoutingSample
{
    public class EndpointInspectorStartup
    {
        // <snippet>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.Use(next => context =>
            {
                var endpoint = context.GetEndpoint();
                if (endpoint is null)
                {
                    return Task.CompletedTask;
                }
                
                Console.WriteLine($"Endpoint: {endpoint.DisplayName}");

                if (endpoint is RouteEndpoint routeEndpoint)
                {
                    Console.WriteLine("Endpoint has route pattern: " +
                        routeEndpoint.RoutePattern.RawText);
                }

                foreach (var metadata in endpoint.Metadata)
                {
                    Console.WriteLine($"Endpoint has metadata: {metadata}");
                }

                return Task.CompletedTask;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
        // </snippet>
    }
}
