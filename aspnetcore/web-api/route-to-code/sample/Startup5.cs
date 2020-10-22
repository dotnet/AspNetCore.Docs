using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebR2C
{
    public class Startup5
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

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
            #region snippet
            app.UseEndpoints(endpoints =>
            {
                // Route-based APIs
                UserApi.Map(endpoints);
                ProductApi.Map(endpoints);

                // Map other endpoints...
                endpoints.MapRazorPages();
            });
            #endregion

        }

        private static class ProductApi
        {
            public static void Map(IEndpointRouteBuilder endpoints)
            {
            }
        }
    }
}
