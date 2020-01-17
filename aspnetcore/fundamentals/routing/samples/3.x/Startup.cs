using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebApplication67
{
    public class Startup
    {
        #region snippet
        public void Configure(IApplicationBuilder app)
        {
            // Matches request to an endpoint.
            app.UseRouting();

            // Endpoint aware middleware. 
            // Middleware can use metadata from the matched endpoint.
            app.UseAuthorization();

            // Execute the matched endpoint.
            app.UseEndpoints(endpoints =>
            {
                // Configuration of app endpoints.
                endpoints.MapRazorPages();
                endpoints.MapGet("/", context => context.Response.WriteAsync("Hello world"));
                endpoints.MapHealthChecks("/healthz");
            });
        }
        #endregion

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
