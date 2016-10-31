using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CorsExample4
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                // BEGIN01
                options.AddPolicy("AllowSpecificOrigins",
                builder =>
                {
                    builder.WithOrigins("http://example.com", "http://www.contoso.com");
                });
                // END01

                // BEGIN02
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                    });
                // END02

                // BEGIN03
                options.AddPolicy("AllowSpecificMethods",
                    builder =>
                    {
                        builder.WithOrigins("http://example.com")
                               .WithMethods("GET", "POST", "HEAD");
                    });
                // END03

                // BEGIN04
                options.AddPolicy("AllowAllMethods",
                    builder =>
                    {
                        builder.WithOrigins("http://example.com")
                               .AllowAnyMethod();
                    });
                // END04

                // BEGIN05
                options.AddPolicy("AllowHeaders",
                    builder =>
                    {
                        builder.WithOrigins("http://example.com")
                               .WithHeaders("accept", "content-type", "origin", "x-custom-header");
                    });
                // END05

                // BEGIN06
                options.AddPolicy("AllowAllHeaders",
                    builder =>
                    {
                        builder.WithOrigins("http://example.com")
                               .AllowAnyHeader();
                    });
                // END06

                // BEGIN07
                options.AddPolicy("ExposeResponseHeaders",
                    builder =>
                    {
                        builder.WithOrigins("http://example.com")
                               .WithExposedHeaders("x-custom-header");
                    });
                // END07

                // BEGIN08
                options.AddPolicy("AllowCredentials",
                    builder =>
                    {
                        builder.WithOrigins("http://example.com")
                               .AllowCredentials();
                    });
                // END08

                // BEGIN09
                options.AddPolicy("SetPreflightExpiration",
                    builder =>
                    {
                        builder.WithOrigins("http://example.com")
                               .SetPreflightMaxAge(TimeSpan.FromSeconds(2520));
                    });
                // END09
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowSpecificOrigins");
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
