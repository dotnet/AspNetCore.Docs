using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace RoutingSample
{
    public class StartupSW
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization();
        }

        // <snippet>
        public void Configure(IApplicationBuilder app, ILogger<Startup> logger)
        {
            int count = 0;
            app.Use(next => async context =>
            {
                using (new MyStopwatch(logger, $"Time {++count}"))
                {
                    await next(context);
                }

            });

            app.UseRouting();

            app.Use(next => async context =>
            {
                using (new MyStopwatch(logger, $"Time {++count}"))
                {
                    await next(context);
                }
            });

            app.UseAuthorization();

            app.Use(next => async context =>
            {
                using (new MyStopwatch(logger, $"Time {++count}"))
                {
                    await next(context);
                }
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

    // <snippetSW>
    public sealed class MyStopwatch : IDisposable
    {
        ILogger<Startup> _logger;
        string _message;
        Stopwatch _sw;

        public MyStopwatch(ILogger<Startup> logger, string message)
        {
            _logger = logger;
            _message = message;
            _sw = Stopwatch.StartNew();
        }

        private bool disposed = false;


        public void Dispose()
        {
            if (!disposed)
            {
                _logger.LogInformation("{Message }: {ElapsedMilliseconds}ms",
                                        _message, _sw.ElapsedMilliseconds);

                disposed = true;
            }
        }
    }
    // </snippetSW>
}