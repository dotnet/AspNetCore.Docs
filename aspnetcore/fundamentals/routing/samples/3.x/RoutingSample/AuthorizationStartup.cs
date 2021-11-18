using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace RoutingSample
{
    public class AuthorizationStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization();
        }

        // <snippet>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Matches request to an endpoint.
            app.UseRouting();

            // Endpoint aware middleware. 
            // Middleware can use metadata from the matched endpoint.
            app.UseAuthentication();
            app.UseAuthorization();

            // Execute the matched endpoint.
            app.UseEndpoints(endpoints =>
            {
                // Configure the Health Check endpoint and require an authorized user.
                endpoints.MapHealthChecks("/healthz").RequireAuthorization();

                // Configure another endpoint, no authorization requirements.
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
        // </snippet>
    }
}
