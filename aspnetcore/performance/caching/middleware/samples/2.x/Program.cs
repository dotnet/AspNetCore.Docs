using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCaching;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;

namespace ResponseCachingSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            #region snippet1
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddResponseCaching();
                })
                .Configure(app =>
                {
                    app.UseResponseCaching();

                    app.Run(async (context) =>
                    {
                        context.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue()
                        {
                            Public = true,
                            MaxAge = TimeSpan.FromSeconds(10)
                        };
                        context.Response.Headers[HeaderNames.Vary] = new string[] { "Accept-Encoding" };

                        await context.Response.WriteAsync($"Hello World! {DateTime.UtcNow}");
                    });
                })
                .Build();
            #endregion
    }
}
