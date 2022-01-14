#define Default // or Limits

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;

namespace KestrelSample
{
    public class Startup
    {
#if Default
        // <snippet_Configure>
        public void Configure(IApplicationBuilder app)
        {
            var serverAddressesFeature =
                app.ServerFeatures.Get<IServerAddressesFeature>();

            app.UseStaticFiles();

            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/html";
                await context.Response
                    .WriteAsync("<!DOCTYPE html><html lang=\"en\"><head>" +
                        "<title></title></head><body><p>Hosted by Kestrel</p>");

                if (serverAddressesFeature != null)
                {
                    await context.Response
                        .WriteAsync("<p>Listening on the following addresses: " +
                            string.Join(", ", serverAddressesFeature.Addresses) +
                            "</p>");
                }

                await context.Response.WriteAsync("<p>Request URL: " +
                    $"{context.Request.GetDisplayUrl()}<p>");
            });
        }
        // </snippet_Configure>
#elif Limits
        public void Configure(IApplicationBuilder app)
        {
            var serverAddressesFeature = app.ServerFeatures.Get<IServerAddressesFeature>();

            app.UseStaticFiles();

            // <snippet_Limits>
            app.Run(async (context) =>
            {
                context.Features.Get<IHttpMaxRequestBodySizeFeature>()
                    .MaxRequestBodySize = 10 * 1024;

                var minRequestRateFeature =
                    context.Features.Get<IHttpMinRequestBodyDataRateFeature>();
                var minResponseRateFeature =
                    context.Features.Get<IHttpMinResponseDataRateFeature>();

                if (minRequestRateFeature != null)
                {
                    minRequestRateFeature.MinDataRate = new MinDataRate(
                        bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
                }

                if (minResponseRateFeature != null)
                {
                    minResponseRateFeature.MinDataRate = new MinDataRate(
                        bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
                }
            // </snippet_Limits>
                context.Response.ContentType = "text/html";
                await context.Response
                    .WriteAsync("<!DOCTYPE html><html lang=\"en\"><head>" +
                        "<title></title></head><body><p>Hosted by Kestrel</p>");

                if (serverAddressesFeature != null)
                {
                    await context.Response
                        .WriteAsync("<p>Listening on the following addresses: " +
                            string.Join(", ", serverAddressesFeature.Addresses) +
                            "</p>");
                }

                await context.Response.WriteAsync("<p>Request URL: " +
                    $"{context.Request.GetDisplayUrl()}<p>");
            });
        }
#endif
    }
}
