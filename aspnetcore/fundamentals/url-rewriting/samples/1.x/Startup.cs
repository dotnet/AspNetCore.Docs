using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using RewriteRules;

namespace UrlRewritingSample
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            #region snippet1
            var options = new RewriteOptions()
                .AddRedirect("redirect-rule/(.*)", "redirected/$1")
                .AddRewrite(@"^rewrite-rule/(\d+)/(\d+)", "rewritten?var1=$1&var2=$2", skipRemainingRules: true)
                .AddApacheModRewrite(env.ContentRootFileProvider, "ApacheModRewrite.txt")
                .AddIISUrlRewrite(env.ContentRootFileProvider, "IISUrlRewrite.xml")
                .Add(RedirectXMLRequests)
                .Add(new RedirectImageRequests(".png", "/png-images"))
                .Add(new RedirectImageRequests(".jpg", "/jpg-images"));

            app.UseRewriter(options);
            #endregion

            app.Run(context => context.Response.WriteAsync($"Rewritten or Redirected Url: {context.Request.Path + context.Request.QueryString}"));
        }

        #region snippet2
        public static void RedirectXMLRequests(RewriteContext context)
        {
            var request = context.HttpContext.Request;

            // Because we're redirecting back to the same app, stop 
            // processing if the request has already been redirected
            if (request.Path.StartsWithSegments(new PathString("/xmlfiles")))
            {
                return;
            }

            if (request.Path.Value.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
            {
                var response = context.HttpContext.Response;
                response.StatusCode = StatusCodes.Status301MovedPermanently;
                context.Result = RuleResult.EndResponse;
                response.Headers[HeaderNames.Location] = 
                    "/xmlfiles" + request.Path + request.QueryString;
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
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseKestrel(options =>
                {
                    options.UseHttps("testCert.pfx", "testPassword");
                })
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5000", "https://localhost", "https://localhost:5001")
                .Build();

            host.Run();
        }
    }
}
