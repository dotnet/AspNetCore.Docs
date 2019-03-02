#define StatusCodePages  // or StatusCodePagesWithRedirect
#define PageErrorHandler // or LambdaErrorHandler

using System;
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
            if (env.IsDevelopment())
            {
                #region snippet_UseDeveloperExceptionPage
                app.UseDeveloperExceptionPage();
                #endregion
            }
            else
            {
#if ErrorPageHandler
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

                        var error = context.Features.Get<IExceptionHandlerFeature>();

                        if (error != null)
                        {
                            // FOR DEMONSTRATION PURPOSES ONLY!
                            // Do NOT expose an error message to the client 
                            // with the following code.
                            await context.Response.WriteAsync("Error: " + 
                                HtmlEncoder.Default.Encode(error.Error.Message) + 
                                "<br><br>\r\n");
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

                    builder.AppendLine("</body></html>");

                    context.Response.ContentType = "text/html";

                    await context.Response.WriteAsync(builder.ToString());
                });
            });

            app.Run(async (context) =>
            {
                if (context.Request.Query.ContainsKey("throw"))
                {
                    throw new Exception("Exception triggered!");
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
