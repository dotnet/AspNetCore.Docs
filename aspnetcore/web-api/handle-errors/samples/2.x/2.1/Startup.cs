// Set preprocessor directive(s) to enable the scenarios you want to test.
// For more information on preprocessor directives and sample apps, see:
// https://docs.microsoft.com/aspnet/core/#preprocessor-directives-in-sample-code
//
// InvalidModelStateResponseFactory - customize response for automatic 400 on validation error
// ExceptionFilter - adds a custom exception filter to the filters collection

#define InvalidModelStateResponseFactory
//#define ExceptionFilter

#if InvalidModelStateResponseFactory
using System.Net.Mime;
#endif

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#if ExceptionFilter
using WebApiSample.Filters;
#endif

namespace WebApiSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
#if InvalidModelStateResponseFactory
            #region snippet_DisableProblemDetailsInvalidModelStateResponseFactory
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var result = new BadRequestObjectResult(context.ModelState);

                    // TODO: add `using using System.Net.Mime;` to resolve MediaTypeNames
                    result.ContentTypes.Add(MediaTypeNames.Application.Json);
                    result.ContentTypes.Add(MediaTypeNames.Application.Xml);

                    return result;
                };
            });
            #endregion
#endif

#if ExceptionFilter
            #region snippet_AddExceptionFilter
            services.AddMvc(options =>
                    options.Filters.Add(new HttpResponseExceptionFilter()))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            #endregion
#endif
        }

        #region snippet_UseExceptionHandler
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
        #endregion
    }
}
