using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;

namespace CorsExample3
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
        }

        // Shows fluent API
        public void Configure(IApplicationBuilder app)
        {
            app.UseCors(builder =>
                builder.WithOrigins("http://example.com")
                       .AllowAnyHeader()
                );

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
