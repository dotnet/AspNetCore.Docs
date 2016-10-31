using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using ViewComponentSample.Models;

namespace ViewComponentSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
               .AddInMemoryDatabase()
               .AddDbContext<ToDoContext>( options => 
                options.UseInMemoryDatabase());

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage(); 
            app.UseIISPlatformHandler();
            app.UseMvcWithDefaultRoute();
            SeedData.Initialize(app.ApplicationServices);
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
