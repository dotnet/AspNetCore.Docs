// Set the preprocessor directive to enable one of the following scenarios:
//
// StatusCodePages - Status code pages with UseStatusCodePages and a lambda.
// StatusCodePagesWithRedirect - Executes a redirect to an endpoint for status code pages.
// StatusCodePagesWithReExecute - Executes an endpoint for status code pages without redirecting.
//
#define StatusCodePages  // or StatusCodePagesWithRedirect or StatusCodePagesWithReExecute

// Set the preprocessor directive to enable either of the following scenarios:
//
// PageErrorHandler - Executes an endpoint with UseExceptionHandler.
//                    Run the app in the Production environment for this scenario.
//
// LambdaErrorHandler - Passes a lambda to UseExceptionHandler.
//                      Run the app in the Production environment for this scenario.
//
#define PageErrorHandler // or LambdaErrorHandler

// For more information on preprocessor directives and sample apps, see:
//  https://docs.microsoft.com/aspnet/core/#preprocessor-directives-in-sample-code

using System.IO;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ErrorHandlingSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (false)
            {
                #region snippet_UseDeveloperExceptionPage
                app.UseDeveloperExceptionPage();
                #endregion
            }
            else
            {
#if PageErrorHandler
                #region snippet_UseExceptionHandler1
                app.UseExceptionHandler("/Error");
                #endregion
#endif
#if LambdaErrorHandler
                #region snippet_UseExceptionHandler2
                // using Microsoft.AspNetCore.Diagnostics;

                app.UseExceptionHandler(errorApp =>
                {
                    errorApp.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "text/html";

                        await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
                        await context.Response.WriteAsync("ERROR!<br><br>\r\n");

                        var exceptionHandlerPathFeature = 
                            context.Features.Get<IExceptionHandlerPathFeature>();

                        // Use exceptionHandlerPathFeature to process the exception (for example, 
                        // logging), but do NOT expose sensitive error information directly to 
                        // the client.

                        if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
                        {
                            await context.Response.WriteAsync("File error thrown!<br><br>\r\n");
                        }

                        await context.Response.WriteAsync("<a href=\"/\">Home</a><br>\r\n");
                        await context.Response.WriteAsync("</body></html>\r\n");
                        await context.Response.WriteAsync(new string(' ', 512)); // IE padding
                    });
                });
                #endregion
#endif
            }

#if StatusCodePages
            #region snippet_StatusCodePages
            // using Microsoft.AspNetCore.Http;

            app.UseStatusCodePages(async context =>
            {
                context.HttpContext.Response.ContentType = "text/plain";

                await context.HttpContext.Response.WriteAsync(
                    "Status code page, status code: " + 
                    context.HttpContext.Response.StatusCode);
            });
            #endregion
#endif

#if StatusCodePagesWithRedirect
            #region snippet_StatusCodePagesWithRedirect
            app.UseStatusCodePagesWithRedirects("/Error/{0}");
            #endregion
#endif

#if StatusCodePagesWithReExecute
            #region snippet_StatusCodePagesWithReExecute
            app.UseStatusCodePagesWithReExecute("/Error/{0}");
            #endregion
#endif

            app.MapWhen(context => context.Request.Path == "/missingpage", builder => { });

            app.Map("/error", error =>
            {
                error.Run(async context =>
                {
                    var builder = new StringBuilder();

                    builder.AppendLine("<html lang=\"en\"><body>");
                    builder.AppendLine("An error occurred.<br>");

                    var path = context.Request.Path.ToString();

                    if (path.Length > 1)
                    {
                        builder.AppendLine("Status Code: " +
                            HtmlEncoder.Default.Encode(path.Substring(1)) + "<br>");
                    }

                    var referrer = context.Request.Headers["referer"];

                    if (!string.IsNullOrEmpty(referrer))
                    {
                        builder.AppendLine("Return to <a href=\"" +
                            HtmlEncoder.Default.Encode(referrer) + "\">" +
                            WebUtility.HtmlEncode(referrer) + "</a><br>");
                    }

#if StatusCodePagesWithReExecute
                    var feature = context.Features.Get<IStatusCodeReExecuteFeature>();
                    if (feature != null)
                    {
                        builder.AppendLine("OriginalPathBase: "
                            + WebUtility.HtmlEncode(feature.OriginalPathBase) + "<br>");
                        builder.AppendLine("OriginalPath: "
                            + WebUtility.HtmlEncode(feature.OriginalPath) + "<br>");
                        builder.AppendLine("OriginalQueryString: "
                            + WebUtility.HtmlEncode(feature.OriginalQueryString) + "<br>");
                    }
#endif

                    builder.AppendLine("</body></html>");

                    context.Response.ContentType = "text/html";

                    await context.Response.WriteAsync(builder.ToString());
                });
            });

            app.Run(async (context) =>
            {
                if (context.Request.Query.ContainsKey("throw"))
                {
                    throw new FileNotFoundException("File Not Found Exception triggered!");
                }

                var builder = new StringBuilder();

                builder.AppendLine("<html><body>Hello World!");
                builder.AppendLine("<ul>");
                builder.AppendLine("<li><a href=\"/?throw=true\">Throw Exception</a></li>");
                builder.AppendLine("<li><a href=\"/missingpage\">Missing Page</a></li>");
                builder.AppendLine("</ul>");
                builder.AppendLine("</body></html>");

                context.Response.ContentType = "text/html";

                await context.Response.WriteAsync(builder.ToString());
            });
        }
    }
}
