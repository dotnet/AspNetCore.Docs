// Set preprocessor directive(s) to enable the scenarios you want to test.
// For more information on preprocessor directives and sample apps, see:
// https://docs.microsoft.com/aspnet/core/#preprocessor-directives-in-sample-code
//
// DefaultBehavior - default ControllerBase and ApiController behavior.
// InvalidModelStateResponseFactory - customize response for automatic 400 on validation error.
// SuppressApiControllerBehavior - use 2.1 behaviors although compat version is 2.2.

#define DefaultBehavior // or InvalidModelStateResponseFactory or SuppressApiControllerBehavior or DisableProblemDetailsInvalidModelStateResponseFactory

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#region snippet_Assembly
[assembly: ApiController]
namespace WebApiSample
{
    public class Startup
    #endregion snippet_Assembly
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
#if SuppressApiControllerBehavior
            #region snippet_ConfigureApiBehaviorOptions
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressConsumesConstraintForFormFileParameters = true;
                    options.SuppressInferBindingSourcesForParameters = true;
                    options.SuppressModelStateInvalidFilter = true;
                    options.SuppressMapClientErrors = true;
                    options.ClientErrorMapping[404].Link =
                        "https://httpstatuses.com/404";
                });
            #endregion
#endif
#if InvalidModelStateResponseFactory             
            #region snippet_ConfigureBadRequestResponse
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = context =>
                    {
                        var problemDetails = 
                            new ValidationProblemDetails(context.ModelState)
                        {
                            Type = "https://contoso.com/probs/modelvalidation",
                            Title = "One or more model validation errors occurred.",
                            Status = StatusCodes.Status400BadRequest,
                            Detail = "See the errors property for details.",
                            Instance = context.HttpContext.Request.Path
                        };

                        return new BadRequestObjectResult(problemDetails)
                        {
                            ContentTypes = { "application/problem+json" }
                        };
                    };
                });
            #endregion
#endif
#if DisableProblemDetailsInvalidModelStateResponseFactory
            #region snippet_DisableProblemDetailsInvalidModelStateResponseFactory
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .ConfigureApiBehaviorOptions(options =>
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
#if DefaultBehavior
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
#endif
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
