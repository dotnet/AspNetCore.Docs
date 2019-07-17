// Set preprocessor directive(s) to enable the scenarios you want to test.
// For more information on preprocessor directives and sample apps, see:
//  https://docs.microsoft.com/aspnet/core/#preprocessor-directives-in-sample-code
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

#define StatusCodePages // or StatusCodePagesWithLambda or // StatusCodePagesWithFormatString or StatusCodePagesWithRedirect or StatusCodePagesWithReExecute
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
            #region snippet_DevPageAndHandlerPage
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            #endregion
#endif
#if ErrorHandlerLambda
            #region snippet_HandlerPageLambda
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
                app.UseHsts();
            }
            #endregion
#endif

#if StatusCodePages
            #region snippet_StatusCodePages
            app.UseStatusCodePages();
            #endregion
#endif
#if StatusCodePagesWithFormatString
            #region snippet_StatusCodePagesFormatString
            app.UseStatusCodePages(
                "text/plain", "Status code page, status code: {0}");            
            #endregion
#endif
#if StatusCodePagesWithLambda
            #region snippet_StatusCodePagesLambda

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
            app.UseStatusCodePagesWithRedirects("/StatusCode?code={0}");
            #endregion
#endif

#if StatusCodePagesWithReExecute
            #region snippet_StatusCodePagesWithReExecute
            app.UseStatusCodePagesWithReExecute("/StatusCode","?code={0}");
            #endregion
#endif

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}
