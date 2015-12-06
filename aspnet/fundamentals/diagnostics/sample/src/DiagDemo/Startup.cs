using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Diagnostics;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using System;
using Microsoft.Extensions.DependencyInjection;

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
                app.UseDeveloperExceptionPage();

                app.UseRuntimeInfoPage(); // default path is /runtimeinfo
            }
            else
            {
                // specify production behavior for error handling, for example:
                // app.UseExceptionHandler("/Home/Error");
                // if nothing is set here, exception will not be handled.
            }

            app.UseWelcomePage("/welcome");

            app.Run(async (context) =>
            {
                if(context.Request.Query.ContainsKey("throw")) throw new Exception("Exception triggered!");
                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("<html><body>Hello World!");
                await context.Response.WriteAsync("<ul>");
                await context.Response.WriteAsync("<li><a href=\"/welcome\">Welcome Page</a></li>");
                await context.Response.WriteAsync("<li><a href=\"/?throw=true\">Throw Exception</a></li>");
                await context.Response.WriteAsync("</ul>");
                await context.Response.WriteAsync("</body></html>");
            });
        }
    }
}
