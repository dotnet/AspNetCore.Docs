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

namespace W3CLoggerSample
{
    public class Startup
    {
        #region configureservices
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddW3CLogging(logging =>
            {
                // Log all W3C fields
                logging.LoggingFields = W3CLoggingFields.All;
                logging.FileSizeLimit = 5 * 1024 * 1024;
                logging.RetainedFileCountLimit = 2;
                logging.FileName = "MyLogFile";
                logging.LogDirectory = @"C:\logs";
                logging.FlushInterval = TimeSpan.FromSeconds(2);
            });
        }
        #endregion

        #region snippet
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseW3CLogging();

            app.UseRouting();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.Map("/", async context =>
                {
                    context.Response.ContentType = "text/plain";
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
        #endregion
    }
}
