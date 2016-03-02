// ASP.NET 5 Startup class

using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using MyApp.Middleware;


namespace Asp.Net5
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Setup options service
            services.AddOptions();

            // ...

            // Load options from section "MyMiddlewareOptionsSection"
            services.Configure<MyMiddlewareOptions>(
                Configuration.GetSection("MyMiddlewareOptionsSection"));

            // ...

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseDeveloperExceptionPage();

            // ...

            app.UseMyMiddleware();

            // ...

            app.UseMyMiddlewareWithParams();

            var myMiddlewareOptions = 
                Configuration.Get<MyMiddlewareOptions>("MyMiddlewareOptionsSection");

            var myMiddlewareOptions2 = 
                Configuration.Get<MyMiddlewareOptions>("MyMiddlewareOptionsSection2");

            app.UseMyMiddlewareWithParams(myMiddlewareOptions);

            // ...

            app.UseMyMiddlewareWithParams(myMiddlewareOptions2);

            app.UseMyTerminatingMiddleware();

            app.UseIISPlatformHandler();

            

            // Create branch to the MyHandlerMiddleware. 
            // All requests ending in .report will follow this branch.
            app.MapWhen(
                context => context.Request.Path.ToString().EndsWith(".report"),
                appBranch => {
                    // ... optionally add more middleware to this branch
                    appBranch.UseMyHandler();
                });

            app.MapWhen(
                context => context.Request.Path.ToString().EndsWith(".context"),
                appBranch => {
                    appBranch.UseHttpContextDemoMiddleware();
                });

            

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
