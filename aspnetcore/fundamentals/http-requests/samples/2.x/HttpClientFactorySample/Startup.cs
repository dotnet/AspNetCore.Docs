using HttpClientFactorySample.GitHub;
using HttpClientFactorySample.Handlers;
using HttpClientFactorySample.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using System;
using System.Net.Http;

namespace HttpClientFactorySample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // basic usage
            // <snippet1>
            services.AddHttpClient();
            // </snippet1>

            // named client
            // <snippet2>
            services.AddHttpClient("github", c =>
            {
                c.BaseAddress = new Uri("https://api.github.com/");
                // Github API versioning
                c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                // Github requires a user-agent
                c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            });
            // </snippet2>

            // typed client where configuration occurs in ctor
            // <snippet3>
            services.AddHttpClient<GitHubService>();
            // </snippet3>

            // typed client where configuration occurs during registration
            // <snippet4>
            services.AddHttpClient<RepoService>(c =>
            {
                c.BaseAddress = new Uri("https://api.github.com/");
                c.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json");
                c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactory-Sample");
            });
            // </snippet4>

            // <snippet5>
            services.AddTransient<ValidateHeaderHandler>();

            services.AddHttpClient("externalservice", c =>
            {
                // Assume this is an "external" service which requires an API KEY
                c.BaseAddress = new Uri("https://localhost:5000/");
            })
            .AddHttpMessageHandler<ValidateHeaderHandler>();
            // </snippet5>

            // <snippet6>
            services.AddTransient<SecureRequestHandler>();
            services.AddTransient<RequestDataHandler>();

            services.AddHttpClient("clientwithhandlers")
                // This handler is on the outside and called first during the 
                // request, last during the response.
                .AddHttpMessageHandler<SecureRequestHandler>()
                // This handler is on the inside, closest to the request being 
                // sent.
                .AddHttpMessageHandler<RequestDataHandler>();
            // </snippet6>

            // <snippet7>
            services.AddHttpClient<UnreliableEndpointCallerService>()
                .AddTransientHttpErrorPolicy(p => 
                    p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600)));
            // </snippet7>

            // <snippet8>
            var timeout = Policy.TimeoutAsync<HttpResponseMessage>(
                TimeSpan.FromSeconds(10));
            var longTimeout = Policy.TimeoutAsync<HttpResponseMessage>(
                TimeSpan.FromSeconds(30));

            services.AddHttpClient("conditionalpolicy")
            // Run some code to select a policy based on the request
                .AddPolicyHandler(request => 
                    request.Method == HttpMethod.Get ? timeout : longTimeout);
            // </snippet8>

            // <snippet9>
            services.AddHttpClient("multiplepolicies")
                .AddTransientHttpErrorPolicy(p => p.RetryAsync(3))
                .AddTransientHttpErrorPolicy(
                    p => p.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));
            // </snippet9>

            // <snippet10>
            var registry = services.AddPolicyRegistry();

            registry.Add("regular", timeout);
            registry.Add("long", longTimeout);
            
            services.AddHttpClient("regulartimeouthandler")
                .AddPolicyHandlerFromRegistry("regular");
            // </snippet10>

            // <snippet11>
            services.AddHttpClient("extendedhandlerlifetime")
                .SetHandlerLifetime(TimeSpan.FromMinutes(5));
            // </snippet11>

            // <snippet12>
            services.AddHttpClient("configured-inner-handler")
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    return new HttpClientHandler()
                    {
                        AllowAutoRedirect = false,
                        UseDefaultCredentials = true
                    };
                });
            // </snippet12>

            // <snippet13>
            services.AddHttpClient("configured-disable-automatic-cookies")
                .ConfigurePrimaryHttpMessageHandler(() =>
                {
                    return new HttpClientHandler()
                    {
                        UseCookies = false,
                    };
                });
            // </snippet13>

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
        
        // This method gets called by the runtime. Use this method to configure 
        // the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseMvc();
        }
    }
}
