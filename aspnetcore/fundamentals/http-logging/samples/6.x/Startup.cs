using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HttpLoggingSample
{
    public class Startup
    {
        #region configureservices
        public void ConfigureServices(IServiceCollection services)
        {
            services.AppHttpLogging(logging =>
            {
                // Customize HTTP logging here.
            });
        }
        #endregion

        #region loggingfields
        public void ConfigureServices(IServiceCollection services)
        {
            services.AppHttpLogging(logging =>
            {
                logging.LoggingFields = HttpLoggingFields.All;
            });
        }
        #endregion

        #region requestheaders
        public void ConfigureServices(IServiceCollection services)
        {
            services.AppHttpLogging(logging =>
            {
                logging.RequestHeaders.Add("My-Request-Header");
            });
        }
        #endregion

        #region responseheaders
        public void ConfigureServices(IServiceCollection services)
        {
            services.AppHttpLogging(logging =>
            {
                logging.ResponseHeaders.Add("My-Response-Header");
            });
        }
        #endregion

        #region mediatypeoptions
        public void ConfigureServices(IServiceCollection services)
        {
            services.AppHttpLogging(logging =>
            {
                logging.MediaTypeOptions.Add("application/javascript");
            });
        }
        #endregion

        #region requestbodyloglimit
        public void ConfigureServices(IServiceCollection services)
        {
            services.AppHttpLogging(logging =>
            {
                logging.RequestBodyLogLimit = 4096;
            });
        }
        #endregion

        
        #region responsebodyloglimit
        public void ConfigureServices(IServiceCollection services)
        {
            services.AppHttpLogging(logging =>
            {
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
