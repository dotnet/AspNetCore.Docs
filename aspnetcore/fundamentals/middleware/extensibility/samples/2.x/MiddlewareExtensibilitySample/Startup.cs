using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MiddlewareExtensibilitySample.Data;
using MiddlewareExtensibilitySample.Middleware;

namespace MiddlewareExtensibilitySample
{
    public class Startup
    {
        // <snippet1>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDb"));

            services.AddTransient<FactoryActivatedMiddleware>();

            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
        // </snippet1>

        // <snippet2>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseConventionalMiddleware();
            app.UseFactoryActivatedMiddleware();

            app.UseStaticFiles();
            app.UseMvc();
        }
        // </snippet2>
    }
}
