using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;

namespace ResponseCompressionSample
{
    public class BasicWebHost
    {
        public static IWebHost BuildBasicWebHost(string[] args) =>
            #region snippet1
            WebHost.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddResponseCompression();
                })
                .Configure(app =>
                {
                    app.UseResponseCompression();

                    app.Run(async context =>
                    {
                        context.Response.ContentType = "text/plain";
                        await context.Response.WriteAsync(LoremIpsum.Text);
                    });
                })
                .Build();
            #endregion
    }
}
