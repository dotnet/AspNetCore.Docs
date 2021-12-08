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
    public class Startup4
    {
        public Startup4(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // <snippet1>
        public void ConfigureServices(IServiceCollection services)
        {           
            var timeout = Policy.TimeoutAsync<HttpResponseMessage>(
                TimeSpan.FromSeconds(10));
            var longTimeout = Policy.TimeoutAsync<HttpResponseMessage>(
                TimeSpan.FromSeconds(30));
            
            var registry = services.AddPolicyRegistry();

            registry.Add("regular", timeout);
            registry.Add("long", longTimeout);
            
            services.AddHttpClient("regularTimeoutHandler")
                .AddPolicyHandlerFromRegistry("regular");

            services.AddHttpClient("longTimeoutHandler")
               .AddPolicyHandlerFromRegistry("long");

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
