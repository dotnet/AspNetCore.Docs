using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

namespace RoutingSample
{
    public class TerminalMiddlewareStartup
    {
        // <snippet>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Approach 1: Writing a terminal middleware.
            app.Use(next => async context =>
            {
                if (context.Request.Path == "/")
                {
                    await context.Response.WriteAsync("Hello terminal middleware!");
                    return;
                }

                await next(context);
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                // Approach 2: Using routing.
                endpoints.MapGet("/Movie", async context =>
                {
                    await context.Response.WriteAsync("Hello routing!");
                });
            });
        }
        // </snippet>
    }
}
