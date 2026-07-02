using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using System;

// This file used only for snippets

namespace WebAPI
{
    public class StartupAllowSubdomain
    {
        public StartupAllowSubdomain(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                #region snippet
                options.AddPolicy("MyAllowSubdomainPolicy",
                    policy =>
                    {
                        policy.WithOrigins("https://*.example.com")
                            .SetIsOriginAllowedToAllowWildcardSubdomains();
                    });
                #endregion

                #region snippet2
                options.AddPolicy("MyAllowHeadersPolicy",
                    policy =>
                    {
                        // requires using Microsoft.Net.Http.Headers;
                        policy.WithOrigins("http://example.com")
                               .WithHeaders(HeaderNames.ContentType, "x-custom-header");
                    });
                #endregion

                #region snippet3
                options.AddPolicy("MyAllowAllHeadersPolicy",
                    policy =>
                    {
                        policy.WithOrigins("https://*.example.com")
                               .AllowAnyHeader();
                    });
                #endregion

                #region snippet5
                options.AddPolicy("MyExposeResponseHeadersPolicy",
                    policy =>
                    {
                        policy.WithOrigins("https://*.example.com")
                               .WithExposedHeaders("x-custom-header");
                    });
                #endregion

                #region snippet6
                options.AddPolicy("MyMyAllowCredentialsPolicy",
                    policy =>
                    {
                        policy.WithOrigins("http://example.com")
                               .AllowCredentials();
                    });
                #endregion

                #region snippet7
                options.AddPolicy("MySetPreflightExpirationPolicy",
                    policy =>
                    {
                        policy.WithOrigins("http://example.com")
                               .SetPreflightMaxAge(TimeSpan.FromSeconds(2520));
                    });
                #endregion

            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            #region snippet4
            app.UseCors(policy => policy.WithHeaders(HeaderNames.CacheControl));
            #endregion

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
