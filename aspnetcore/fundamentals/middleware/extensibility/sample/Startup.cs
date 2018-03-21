using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MiddlewareExtensibilitySample.Data;
using MiddlewareExtensibilitySample.Middleware;

namespace MiddlewareExtensibilitySample
{
    public class Startup
    {
        #region snippet1
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDb"));

            services.AddTransient<IMiddlewareMiddleware>();

            services.AddMvc();
        }
        #endregion

        #region snippet2
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

            app.UseConventionalMiddleware();
            app.UseIMiddlewareMiddleware();

            app.UseStaticFiles();
            app.UseMvc();
        }
        #endregion
    }
}
