using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;

namespace StartupDemo
{
    public class Startup
    {
        private readonly string _environment;
        public Startup(IHostingEnvironment env)
        {
            _environment = env.EnvironmentName;
        }

        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void ConfigureEnvironmentOne(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from " + _environment);
            });
        }

        public void ConfigureEnvironmentTwo(IApplicationBuilder app)
        {
            app.Use(next => async context =>
            {
                await context.Response.WriteAsync("Hello from " + _environment);
            });
        }
    }
}
