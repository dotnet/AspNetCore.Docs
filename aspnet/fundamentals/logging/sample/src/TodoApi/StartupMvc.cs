using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Framework.DependencyInjection;
using Microsoft.Framework.Logging;
using TodoApi.Core.Interfaces;
using TodoApi.Infrastructure;

namespace TodoApi
{
    public class StartupMvc
    { 
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Add our repository type
            services.AddScoped<ITodoRepository, TodoRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}