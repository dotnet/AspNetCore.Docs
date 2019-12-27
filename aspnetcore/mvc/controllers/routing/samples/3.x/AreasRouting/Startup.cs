//#define First
#define Third

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AreasRouting
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

#if First
            #region snippet1
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute("blog_route", "Blog",
                    "Manage/{controller}/{action}/{id?}");
                endpoints.MapControllerRoute("default_route", "{controller}/{action}/{id?}");
            });
            #endregion
#else
            #region snippet2
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("blog_route", "Manage/{controller}/{action}/{id?}",
                    defaults: new { area = "Blog" }, constraints: new { area = "Blog" });
                endpoints.MapControllerRoute("default_route", "{controller}/{action}/{id?}");
            });
            #endregion
#endif
#if Third
            #region snippet3
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute("duck_route", "Duck",
                    "Manage/{controller}/{action}/{id?}");
                endpoints.MapControllerRoute("default", "Manage/{controller=Home}/{action=Index}/{id?}");
            });
            #endregion
#endif

        }
    }
}
