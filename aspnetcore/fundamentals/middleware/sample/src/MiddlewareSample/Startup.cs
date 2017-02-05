using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MiddlewareSample
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

        public void Configure(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello, World!");
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello, World, Again!");
            });
        }

         /// <summary>
         /// 1.Comment Previous methods Configure
         /// 2.Rename this methode to "configure" & Run Project
         /// </summary>
        public void ConfigureLogInline(IApplicationBuilder app, ILoggerFactory loggerfactory)
        {
            loggerfactory.AddConsole(minLevel: LogLevel.Information);
            var logger = loggerfactory.CreateLogger(_environment);
            app.Use(async (context, next) =>
            {
                logger.LogInformation("Handling request.");
                await next.Invoke();
                logger.LogInformation("Finished handling request.");
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from " + _environment);
            });
        }

         /// <summary>
         /// 1.Comment Previous methods Configure
         /// 2.Rename this methode to "configure" & Run Project
         /// </summary>
        public void ConfigureLogMiddleware(IApplicationBuilder app,
            ILoggerFactory loggerfactory)
        {
            loggerfactory.AddConsole(minLevel: LogLevel.Information);

            app.UseRequestLogger();

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from " + _environment);
            });
        }


        /// <summary>
        /// 1.Comment Previous methods Configure
        /// 2.Rename this methode to "configure" & Run Project
        /// </summary>
        public void ConfigureEnvironmentOne(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello from " + _environment);
            });
        }

        /// <summary>
        /// 1.Comment Previous methods Configure
        /// 2.Rename this methode to "configure" & Run Project
        /// </summary>
        public void ConfigureEnvironmentTwo(IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Hello from " + _environment);
            });
        }

        /// <summary>
        /// Do not comment!
        /// </summary>
        private static void HandleMapTest(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Map Test Successful");
            });
        }

        /// <summary>
        /// 1.Comment Previous methods Configure
        /// 2.Rename this methode to "configure" & Run Project
        /// </summary>
        public void ConfigureMapping(IApplicationBuilder app)
        {
            app.Map("/maptest", HandleMapTest);

        }

        /// <summary>
        /// Do not comment!
        /// </summary>
        private static void HandleBranch(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Branch used.");
            });
        }

        /// <summary>
        /// 1.Comment Previous methods Configure
        /// 2.Rename this methode to "configure" & Run Project
        /// </summary>
        public void ConfigureMapWhen(IApplicationBuilder app)
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
