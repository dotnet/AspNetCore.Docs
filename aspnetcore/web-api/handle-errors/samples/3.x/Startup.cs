// Set preprocessor directive(s) to enable the scenarios you want to test.
// For more information on preprocessor directives and sample apps, see:
// https://docs.microsoft.com/aspnet/core/introduction-to-aspnet-core#preprocessor-directives-in-sample-code
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
using Microsoft.Extensions.Hosting;

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
            // <snippet_DisableProblemDetailsInvalidModelStateResponseFactory>
            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        var result = new BadRequestObjectResult(context.ModelState);

                        // TODO: add `using System.Net.Mime;` to resolve MediaTypeNames
                        result.ContentTypes.Add(MediaTypeNames.Application.Json);
                        result.ContentTypes.Add(MediaTypeNames.Application.Xml);

                        return result;
                    };
                });
            // </snippet_DisableProblemDetailsInvalidModelStateResponseFactory>
#endif

#if ExceptionFilter
            // <snippet_AddExceptionFilter>
            services.AddControllers(options =>
                options.Filters.Add(new HttpResponseExceptionFilter()));
            // </snippet_AddExceptionFilter>
#endif
        }

        // <snippet_UseExceptionHandler>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        // </snippet_UseExceptionHandler>
    }
}
