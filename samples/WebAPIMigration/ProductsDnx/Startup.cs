using System;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;

namespace ProductsDnx
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
        }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            // Add MVC to the request pipeline.
            app.UseMvc();

            // Add routes from ProductsApp
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "DefaultApi",
            //        template: "api/{controller}/{action}/{id:int?}",
            //        defaults: new { controller = "Products", action = "GetAllProducts" });
            //});
        }
    }
}
