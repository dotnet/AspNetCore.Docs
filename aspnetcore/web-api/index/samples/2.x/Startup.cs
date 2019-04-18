// Set preprocessor directive(s) to enable the scenarios you want to test.
// For more information on preprocessor directives and sample apps, see:
//  https://docs.microsoft.com/aspnet/core/#preprocessor-directives-in-sample-code
//
// DefaultBehavior - default ControllerBase and ApiController behavior.
// InvalidModelStateResponseFactory - customize response for automatic 400 on validation error.
// SuppressApiControllerBehavior - use 2.1 behaviors although compat version is 2.2.

#define DefaultBehavior // or InvalidModelStateResponseFactory or SuppressApiControllerBehavior

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using WebApiSample.DataAccess;
using WebApiSample.DataAccess.Repositories;

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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ProductsRepository>();
            services.AddScoped<PetsRepository>();

            services.AddDbContext<ProductContext>(opt =>
                opt.UseInMemoryDatabase("ProductInventory"));
            services.AddDbContext<PetContext>(opt =>
                opt.UseInMemoryDatabase("PetInventory"));

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
                    options.SuppressUseValidationProblemDetailsForInvalidModelStateResponses = true;
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
                        var problemDetails = new ValidationProblemDetails(context.ModelState)
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
#if DefaultBehavior
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
#endif
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
