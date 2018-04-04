using System;
using System.Net.Http;
using HttpClientFactorySample.GitHub;
using HttpClientFactorySample.Handlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;

namespace HttpClientFactorySample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        #region snippet1
        public void ConfigureServices(IServiceCollection services)
        {
            // basic usage
            services.AddHttpClient();

            // named client
            services.AddHttpClient("github", c =>
            {
                c.BaseAddress = new Uri("https://api.github.com/");

                c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json"); // Github API versioning
                c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample"); // Github requires a user-agent
            });

            services.AddTransient<RequestDataHandler>();
            services.AddTransient<SecureRequestHandler>();

            // configuration occurs in ctor
            services.AddHttpClient<GitHubService>();

            // named client with a handler
            services.AddHttpClient("clientwithhandler", c =>
            {
                c.BaseAddress = new Uri("https://localhost:5000/");
            })
            .AddHttpMessageHandler<RequestDataHandler>();

            // configuring during registration
            services.AddHttpClient<ValuesService>(c =>
            {
                c.BaseAddress = new Uri("https://api.github.com/");
                c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            });

            #region snippet2
            services.AddHttpClient("regulartimeouthandler", c =>
            {
                c.BaseAddress = new Uri("https://localhost:5000/");
            })
            .AddTransientHttpErrorPolicy(p => p.RetryAsync(3));
            #endregion
            
            #region snippet3
            var timeout = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(10));
            var longTimeout = Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(30));

            services.AddHttpClient("example", c =>
            {
                c.BaseAddress = new Uri("https://localhost:5000/");
            })

            // Build a custom policy using any criteria
            .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(10)))

            // Run some code to select a policy based on the request
            .AddPolicyHandler(request => request.Method == HttpMethod.Get ? timeout : longTimeout);
            #endregion

            var registry = services.AddPolicyRegistry();

            registry.Add("regular", timeout);
            registry.Add("long", longTimeout);
            
            services.AddHttpClient("regulartimeouthandler", c =>
            {
                c.BaseAddress = new Uri("https://localhost:5000/");
            })
            .AddPolicyHandlerFromRegistry("regular");
            
            
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
        #endregion

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
