using System;
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
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(options =>
                options.UseInMemoryDatabase("TodoItems"));

            services.AddHttpContextAccessor();

            services.AddHttpClient<TodoClient>((sp, httpClient) =>
            {
                // For sample purposes, assume TodoClient is used in the context of an incoming request.
                var httpRequest = sp.GetRequiredService<IHttpContextAccessor>().HttpContext.Request;

                httpClient.BaseAddress = new Uri(UriHelper.BuildAbsolute(httpRequest.Scheme, httpRequest.Host, httpRequest.PathBase));
                httpClient.Timeout = TimeSpan.FromSeconds(5);
            });

            services.AddControllers();
            services.AddRazorPages();
        }

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
