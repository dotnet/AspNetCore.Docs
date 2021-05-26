using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HttpLoggingSample
{
    public class Startup
    {
        #region configureservices
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpLogging(logging =>
            {
                // Customize HTTP logging here.
                logging.LoggingFields = HttpLoggingFields.All;
                logging.RequestHeaders.Add("My-Request-Header");
                logging.ResponseHeaders.Add("My-Response-Header");
                logging.MediaTypeOptions.AddText("application/javascript");
                logging.RequestBodyLogLimit = 4096;
                logging.ResponseBodyLogLimit = 4096;
            });
        }
        #endregion

        #region snippet
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHttpLogging();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
        #endregion
    }
}
