using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace performance_best_practices
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
/*
#if BAD
            #region snippet1
            app.Use(async (next, context) =>
            {
                await context.Response.WriteAsync("Hello ");
    
                await next();
    
                // This may fail if next() already wrote to the response
                context.Response.Headers["test"] = "value";    
            });
            #endregion
#else
            #region snippet2
            app.Use(async (next, context) =>
            {
                await context.Response.WriteAsync("Hello ");

                await next();

                // Check if the response has already started before adding header and writing
                if (!context.Response.HasStarted)
                {
                    context.Response.Headers["test"] = "value";
                }
            });
            #endregion
            #region snippet3
            app.Use(async (next, context) =>
            {
                // Wire up the callback that will fire just before the response headers are sent to the client.
                context.Response.OnStarting(() =>
                {
                    context.Response.Headers["someheader"] = "somevalue";
                    return Task.CompletedTask;
                });

                await next();
            });
            #endregion
#endif
*/
        }
    }
}
