// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Net.Http.Headers;
using RewriteRules;

namespace URLRewritingSample
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            /*
                Examples in this sample
                -----------------------

                AddRedirect("redirect-rule/(.*)", "$1")
                Success status code: 302 (Found)
                Example (redirect): /redirect-rule/{capture_group} to /redirected/{capture_group}

                AddRewrite(@"^rewrite-rule/(\d+)/(\d+)", "rewritten?var1=$1&var2=$2", skipRemainingRules: true)
                Success status code: 200 (OK)
                Example (rewrite): /rewrite-rule/{capture_group_1}/{capture_group_2} to /rewritten?var1={capture_group_1}&var2={capture_group_2}

                AddApacheModRewrite(env.ContentRootFileProvider, "ApacheModRewrite.txt")
                Success status code: 302 (Found)
                Example (redirect): /apache-mod-rules-redirect/{capture_group} to /redirected?id={capture_group}

                AddIISUrlRewrite(env.ContentRootFileProvider, "IISUrlRewrite.xml")
                Success status code: 200 (OK)
                Example (rewrite): /iis-rules-rewrite/{capture_group} to /rewritten?id={capture_group}

                Add(RedirectXMLRequests)
                Success status code: 301 (Moved Permanently)
                Example (redirect): /file.xml to /xmlfiles/file.xml

                Add(new RedirectPNGRequests(".png", new Uri("http://localhost:5000/png-image")))
                Add(new RedirectPNGRequests(".jpg", new Uri("http://localhost:5000/jpg-image")))
                Success status code: 301 (Moved Permanently)
                Example (redirect): /image.png to /png-images/image.png
                Example (redirect): /image.jpg to /jpg-images/image.jpg

                Using a PhysicalFileProvider
                ----------------------------
                You can also obtain an IFileProvider by creating a PhysicalFileProvider to pass into the
                AddApacheModRewrite() and AddIISUrlRewrite() methods:

                using Microsoft.Extensions.FileProviders;
                PhysicalFileProvider fileProvider = new PhysicalFileProvider(Directory.GetCurrentDirectory());

                Secure redirection extensions
                -----------------------------
                            METHOD              STATUS CODE     PORT
                .AddRedirectToHttpsPermanent()      301      null (465)
                .AddRedirectToHttps()               302      null (465)
                .AddRedirectToHttps(301)            301      null (465)
                .AddRedirectToHttps(301, 5001)      301         5001

                This sample includes WebHostBuilder configuration for the app to 
                use URLs https://localhost:5001, https://localhost and a test 
                certificate (testCert.pfx) to assist you in exploring these
                redirect methods.
            */
            
            #region snippet1
            var options = new RewriteOptions()
                .AddRedirect("redirect-rule/(.*)", "redirected/$1")
                .AddRewrite(@"^rewrite-rule/(\d+)/(\d+)", "rewritten?var1=$1&var2=$2", skipRemainingRules: true)
                .AddApacheModRewrite(env.ContentRootFileProvider, "ApacheModRewrite.txt")
                .AddIISUrlRewrite(env.ContentRootFileProvider, "IISUrlRewrite.xml")
                .Add(RedirectXMLRequests)
                .Add(new RedirectImageRequests(".png", new Uri("http://localhost:5000/png-images")))
                .Add(new RedirectImageRequests(".jpg", new Uri("http://localhost:5000/jpg-images")));

            app.UseRewriter(options);
            #endregion

            app.Run(context => context.Response.WriteAsync($"Rewritten or Redirected Url: {context.Request.Path + context.Request.QueryString}"));
        }

        #region snippet2
        static void RedirectXMLRequests(RewriteContext context)
        {
            var request = context.HttpContext.Request;
            var path = request.Path.Value;

            // Because we're redirecting back to the same app, stop processing 
            // if this request has already been redirected
            if (path.StartsWith("/xmlfiles/"))
            {
                return;
            }

            if (path.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
            {
                var response = context.HttpContext.Response;
                response.StatusCode = StatusCodes.Status301MovedPermanently;
                context.Result = RuleResult.EndResponse;
                response.Headers[HeaderNames.Location] = "/xmlfiles" + path + request.QueryString;
            }
        }
        #endregion

        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel(options =>
                {
                    options.UseHttps("testCert.pfx", "testPassword");
                })
                .UseUrls("http://localhost:5000", "https://localhost", "https://localhost:5001")
                .UseStartup<Startup>()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .Build();

            host.Run();
        }
    }
}
