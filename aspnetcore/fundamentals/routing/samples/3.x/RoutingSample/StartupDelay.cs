using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace RoutingSample
{
    public class StartupDelay
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization();
        }

        // <snippet>
        public void Configure(IApplicationBuilder app, ILogger<Startup> logger)
        {
            app.Use(next => async context =>
            {
                var sw = Stopwatch.StartNew();
                await next(context);
                sw.Stop();

                logger.LogInformation("Time 1: {ElapsedMilliseconds}ms", sw.ElapsedMilliseconds);
            });

            app.UseRouting();

            app.Use(next => async context =>
            {
                var sw = Stopwatch.StartNew();
                await next(context);
                sw.Stop();

                logger.LogInformation("Time 2: {ElapsedMilliseconds}ms", sw.ElapsedMilliseconds);
            });

            app.UseAuthorization();

            app.Use(next => async context =>
            {
                var sw = Stopwatch.StartNew();
                await next(context);
                sw.Stop();

                logger.LogInformation("Time 3: {ElapsedMilliseconds}ms", sw.ElapsedMilliseconds);
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Timing test.");
                });
            });
        }
        // </snippet>
    }
}
