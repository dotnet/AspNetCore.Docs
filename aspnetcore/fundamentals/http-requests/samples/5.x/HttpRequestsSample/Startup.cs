using System;
using HttpRequestsSample.Handlers;
using HttpRequestsSample.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HttpRequestsSample
{
    public class Startup
    {
        // <snippet_IOperationScoped>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(options =>
                options.UseInMemoryDatabase("TodoItems"));

            services.AddHttpContextAccessor();

            services.AddHttpClient<TodoClient>((sp, httpClient) =>
            {
                var httpRequest = sp.GetRequiredService<IHttpContextAccessor>().HttpContext.Request;

                // For sample purposes, assume TodoClient is used in the context of an incoming request.
                httpClient.BaseAddress = new Uri(UriHelper.BuildAbsolute(httpRequest.Scheme,
                                                 httpRequest.Host, httpRequest.PathBase));
                httpClient.Timeout = TimeSpan.FromSeconds(5);
            });

            services.AddScoped<IOperationScoped, OperationScoped>();
            
            services.AddTransient<OperationHandler>();
            services.AddTransient<OperationResponseHandler>();

            services.AddHttpClient("Operation")
                .AddHttpMessageHandler<OperationHandler>()
                .AddHttpMessageHandler<OperationResponseHandler>()
                .SetHandlerLifetime(TimeSpan.FromSeconds(5));

            services.AddControllers();
            services.AddRazorPages();
        }
        // </snippet_IOperationScoped>

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

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
