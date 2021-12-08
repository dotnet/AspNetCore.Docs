using HttpClientFactorySample.GitHub;
using HttpClientFactorySample.Handlers;
using HttpClientFactorySample.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using System;
using System.Net.Http;

namespace HttpClientFactorySample
{
    public class Startup2
    {
        public Startup2(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // <snippet1>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ValidateHeaderHandler>();

            services.AddHttpClient("externalservice", c =>
            {
                // Assume this is an "external" service which requires an API KEY
                c.BaseAddress = new Uri("https://localhost:5001/");
            })
            .AddHttpMessageHandler<ValidateHeaderHandler>();

            // Remaining code deleted for brevity.
            // </snippet1>

            services.AddControllers();
            services.AddRazorPages();
        }
        
        // This method gets called by the runtime. Use this method to configure 
        // the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
