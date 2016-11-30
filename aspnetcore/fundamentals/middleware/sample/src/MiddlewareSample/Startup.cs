using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MiddlewareSample
{
    /// <summary>
    /// Sync
    /// </summary>
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

        //public void Configure(IApplicationBuilder app)
        //{
        //    app.Run(async context =>
        //    {
        //        await context.Response.WriteAsync("Hello, World!");
        //    });

        //    app.Run(async context =>
        //    {
        //        await context.Response.WriteAsync("Hello, World, Again!");
        //    });
        //}

        /// <summary>
        /// ConfigureLogInline
        /// </summary>
        /// <param name="app"></param>
        /// <param name="loggerfactory"></param>
        //public void Configure(IApplicationBuilder app, ILoggerFactory loggerfactory)
        //{
        //    loggerfactory.AddConsole(minLevel: LogLevel.Information);
        //    var logger = loggerfactory.CreateLogger(_environment);
        //    app.Use(async (context, next) =>
        //    {
        //        logger.LogInformation("Handling request.");
        //        await next.Invoke();
        //        logger.LogInformation("Finished handling request.");
        //    });

        //    app.Run(async context =>
        //    {
        //        await context.Response.WriteAsync("Hello from " + _environment);
        //    });
        //}

        //ConfigureLogMiddleware
        //public void Configure(IApplicationBuilder app,
        //    ILoggerFactory loggerfactory)
        //{
        //    loggerfactory.AddConsole(minLevel: LogLevel.Information);

        //    app.UseRequestLogger();

        //    app.Run(async context =>
        //    {
        //        await context.Response.WriteAsync("Hello from " + _environment);
        //    });
        //}

        //ConfigureEnvironmentOne
        //public void Configure(IApplicationBuilder app)
        //{
        //    app.Run(async context =>
        //    {
        //        await context.Response.WriteAsync("Hello from " + _environment);
        //    });
        //}

        //ConfigureEnvironmentTwo
        //public void Configure(IApplicationBuilder app)
        //{
        //    app.Use(async (context, next) =>
        //    {
        //        await context.Response.WriteAsync("Hello from " + _environment);
        //    });
        //}

        private static void HandleMapTest(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test Successful");
            });
        }
        //ConfigureMapping
        //public void Configure(IApplicationBuilder app)
        //{
        //    app.Map("/maptest", HandleMapTest);

        //}

        private static void HandleBranch(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Branch used.");
            });
        }
        //ConfigureMapWhen
        public void Configure(IApplicationBuilder app)
        {
            app.MapWhen(context => {
                return context.Request.Query.ContainsKey("branch");
            }, HandleBranch);

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from " + _environment);
            });
        }
    }
}
