using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebR2C
{
    public class Startup4
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
                var logger = endpoints.ServiceProvider.GetService<ILogger<Startup>>();

                endpoints.MapGet("/user/{id}", async context =>
                {
                    var repository = context.RequestServices.GetService<UserRepository>();

                    var id = context.Request.RouteValues["id"];

                    logger.LogDebug($"Getting user {id}");
                    await context.Response.WriteAsJsonAsync(repository.GetUser(id));
                });
            });
            #endregion

        }

        private class UserRepository
        {
            public object GetUser(object id) => new object();
            public object GetAllUsers() => new object();
        }
    }
}
