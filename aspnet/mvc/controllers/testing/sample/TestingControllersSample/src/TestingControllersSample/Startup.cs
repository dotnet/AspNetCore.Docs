using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TestingControllersSample.Core.Interfaces;
using TestingControllersSample.Infrastructure;

namespace TestingControllersSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddEntityFramework()
                .AddInMemoryDatabase()
                .AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase());

            services.AddMvc();
            services.AddScoped<IBrainStormSessionRepository, EfStormSessionRepository>();
        }

        public void Configure(IApplicationBuilder app, 
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Verbose);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseRuntimeInfoPage(); // default path is /runtimeinfo
            }
            app.UseIISPlatformHandler();
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();

        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
