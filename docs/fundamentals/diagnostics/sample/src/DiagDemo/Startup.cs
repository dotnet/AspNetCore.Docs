using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Framework.DependencyInjection;
using System;

namespace DiagDemo
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (string.Equals(env.EnvironmentName, "Development", StringComparison.OrdinalIgnoreCase))
            {
                app.UseErrorPage(ErrorPageOptions.ShowAll);

                app.UseRuntimeInfoPage(); // default path is /runtimeinfo
            }
            else
            {
                // specify production behavior for error handling, for example:
                // app.UseErrorHandler("/Home/Error");
                // if nothing is set here, web server error page will be displayed
            }

            app.UseWelcomePage(new WelcomePageOptions() { Path = new PathString("/welcome") });

            app.Run(async (context) =>
            {
                if(context.Request.Query.ContainsKey("throw")) throw new Exception("Exception triggered!");
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
