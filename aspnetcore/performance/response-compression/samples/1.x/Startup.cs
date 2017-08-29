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
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace ResponseCompressionSample
{
    public class Startup
    {
        #region snippet2
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<GzipCompressionProvider>();
                options.Providers.Add<CustomCompressionProvider>();
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "image/svg+xml" });
            });

            services.Configure<GzipCompressionProviderOptions>(options => 
            {
                options.Level = CompressionLevel.Fastest;
            });
        }
        #endregion
        
        public void Configure(IApplicationBuilder app)
        {
            app.UseResponseCompression();

            app.Map("/testfile1kb.txt", fileApp =>
            {
                fileApp.Run(context =>
                {
                    ManageVaryHeader(context);
                    context.Response.ContentType = "text/plain";
                    return context.Response.SendFileAsync("testfile1kb.txt");
                });
            });

            app.Map("/trickle", trickleApp =>
            {
                trickleApp.Run(async context =>
                {
                    ManageVaryHeader(context);
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
                    ManageVaryHeader(context);
                    context.Response.ContentType = "image/svg+xml";
                    return context.Response.SendFileAsync("banner.svg");
                });
            });

            app.Run(async context =>
            {
                ManageVaryHeader(context);
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync(LoremIpsum.Text);
            });
        }

        #region snippet1
        // ONLY REQUIRED FOR ASP.NET CORE 1.x APPS
        private void ManageVaryHeader(HttpContext context)
        {
            // If the Accept-Encoding header is present, add the Vary header
            var accept = context.Request.Headers[HeaderNames.AcceptEncoding];
            if (!StringValues.IsNullOrEmpty(accept))
            {
                context.Response.Headers.Append(HeaderNames.Vary, HeaderNames.AcceptEncoding);
            }
        }
        #endregion
    }
}
