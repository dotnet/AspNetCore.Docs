// Set preprocessor directive(s) to enable the scenarios you want to test.
// For more information on preprocessor directives and sample apps, see:
//  https://docs.microsoft.com/aspnet/core/introduction-to-aspnet-core#preprocessor-directives-in-sample-code
//
// StatusCodePages
// StatusCodePagesWithLambda
// StatusCodePagesWithFormatString
// StatusCodePagesWithRedirect
// StatusCodePagesWithReExecute
// ErrorHandlerPage
// ErrorHandlerLambda
// ProdEnvironment or DevEnvironment
//
// The ErrorHandler directives must be used along with the ProdEnvironment directive.
// The DeveloperExceptionPage is seen only when the DevEnvironment directive is used.

#define StatusCodePagesWithRedirect // StatusCodePages // or StatusCodePagesWithLambda or // StatusCodePagesWithFormatString or StatusCodePagesWithRedirect or StatusCodePagesWithReExecute
#define ErrorHandlerPage // or ErrorHandlerLambda
#define ProdEnvironment // or DevEnvironment

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ErrorHandlingSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
#if ProdEnvironment
            env.EnvironmentName = "Production";
#endif            
#if DevEnvironment
            env.EnvironmentName = "Development";
#endif
#if ErrorHandlerPage
            // <snippet_DevPageAndHandlerPage>
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            // </snippet_DevPageAndHandlerPage>
#endif
#if ErrorHandlerLambda
            // <snippet_HandlerPageLambda>
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
               app.UseExceptionHandler(errorApp =>
               {
                    errorApp.Run(async context =>
                    {
                        context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "text/html";

                        await context.Response.WriteAsync("<html lang=\"en\"><body>\r\n");
                        await context.Response.WriteAsync("ERROR!<br><br>\r\n");

                        var exceptionHandlerPathFeature = 
                            context.Features.Get<IExceptionHandlerPathFeature>();

                        if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
                        {
                            await context.Response.WriteAsync("File error thrown!<br><br>\r\n");
                        }

                        await context.Response.WriteAsync("<a href=\"/\">Home</a><br>\r\n");
                        await context.Response.WriteAsync("</body></html>\r\n");
                        await context.Response.WriteAsync(new string(' ', 512)); // IE padding
                    });
                });
                app.UseHsts();
            }
            // </snippet_HandlerPageLambda>
#endif

#if StatusCodePages
            // <snippet_StatusCodePages>
            app.UseStatusCodePages();
            // </snippet_StatusCodePages>
#endif
#if StatusCodePagesWithFormatString
            // <snippet_StatusCodePagesFormatString>
            app.UseStatusCodePages(
                "text/plain", "Status code page, status code: {0}");            
            // </snippet_StatusCodePagesFormatString>
#endif
#if StatusCodePagesWithLambda
            // <snippet_StatusCodePagesLambda>
            app.UseStatusCodePages(async context =>
            {
                context.HttpContext.Response.ContentType = "text/plain";

                await context.HttpContext.Response.WriteAsync(
                    "Status code page, status code: " + 
                    context.HttpContext.Response.StatusCode);
            });
            // </snippet_StatusCodePagesLambda>
#endif
#if StatusCodePagesWithRedirect
            // <snippet_StatusCodePagesWithRedirect>
            app.UseStatusCodePagesWithRedirects("/StatusCode?code={0}");
            // </snippet_StatusCodePagesWithRedirect>
#endif

#if StatusCodePagesWithReExecute
            // <snippet_StatusCodePagesWithReExecute>
            app.UseStatusCodePagesWithReExecute("/StatusCode","?code={0}");
            // </snippet_StatusCodePagesWithReExecute>
#endif

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
