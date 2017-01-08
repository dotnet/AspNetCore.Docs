// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace ResponseCompressionSample
{
    public class Startup
    {
        #region snippet2
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<GzipCompressionProviderOptions>(options => 
            {
                options.Level = CompressionLevel.Fastest;
            });
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.Providers.Add<CustomCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "image/svg+xml" });
            });
        }
        #endregion

        #region snippet3
        public void Configure(IApplicationBuilder app)
        {
            app.UseResponseCompression();

            app.Map("/testfile1kb.txt", fileApp =>
            {
                fileApp.Run(context =>
                {
                    ManageVaryHeader(ref context);
                    context.Response.ContentType = "text/plain";
                    return context.Response.SendFileAsync("testfile1kb.txt");
                });
            });

            app.Map("/trickle", trickleApp =>
            {
                trickleApp.Run(async context =>
                {
                    ManageVaryHeader(ref context);
                    context.Response.ContentType = "text/plain";
                    // Disables compression on net451 because that GZipStream does not implement Flush
                    context.Features.Get<IHttpBufferingFeature>()?.DisableResponseBuffering();

                    for (int i = 0; i < 20; i++)
                    {
                        await context.Response.WriteAsync("a");
                        await context.Response.Body.FlushAsync();
                        await Task.Delay(TimeSpan.FromSeconds(1));
                    }
                });
            });

            app.Map("/banner.svg", fileApp =>
            {
                fileApp.Run(context =>
                {
                    ManageVaryHeader(ref context);
                    context.Response.ContentType = "image/svg+xml";
                    return context.Response.SendFileAsync("banner.svg");
                });
            });

            app.Run(async context =>
            {
                ManageVaryHeader(ref context);
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(LoremIpsum.Text);
            });
        }
        #endregion

        #region snippet1
        private void ManageVaryHeader(ref HttpContext context)
        {
            // If the Accept-Encoding header is present, always add the Vary header
            var accept = context.Request.Headers[HeaderNames.AcceptEncoding];
            if (!StringValues.IsNullOrEmpty(accept))
            {
                context.Response.Headers[HeaderNames.Vary] = HeaderNames.AcceptEncoding;
            }
        }
        #endregion

        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .ConfigureLogging(factory =>
                {
                    factory.AddConsole(LogLevel.Debug);
                })
                .UseKestrel()
                .UseStartup<Startup>()
                .Build();

            host.Run();
        }
    }
}