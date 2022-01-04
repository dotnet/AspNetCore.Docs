// Set preprocessor directive(s) to enable the scenarios you want to test.
// For more information on preprocessor directives and sample apps, see:
// https://docs.microsoft.com/aspnet/core/introduction-to-aspnet-core#preprocessor-directives-in-sample-code
//
// DefaultBehavior - default ControllerBase and ApiController behavior.
// SuppressApiControllerBehavior - use 2.1 behaviors although compat version is 2.2.

#define DefaultBehavior // or SuppressApiControllerBehavior, or AutomaticBadRequestLogging

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

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
#if SuppressApiControllerBehavior
            #region snippet_ConfigureApiBehaviorOptions
            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressConsumesConstraintForFormFileParameters = true;
                    options.SuppressInferBindingSourcesForParameters = true;
                    options.SuppressModelStateInvalidFilter = true;
                    options.SuppressMapClientErrors = true;
                    options.ClientErrorMapping[StatusCodes.Status404NotFound].Link =
                        "https://httpstatuses.com/404";
                });
            #endregion
#endif
#if AutomaticBadRequestLogging
            #region snippet_AutomaticBadRequestLogging
            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    // If preserving of the original behavior is desired, get a reference to the delegate.
                    var builtInFactory = options.InvalidModelStateResponseFactory;

                    options.InvalidModelStateResponseFactory = context =>
                    {
                        // As an example, we will get an instance of ILogger with the category "Startup".
                        var logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<Startup>>();

                        // Log accordingly.

                        // By using the original delegate, we preserve the default behavior.
                        // Alternatively, you can take full control and simply construct the ValidationProblemDetails object yourself,
                        // or even use a custom object.
                        var result = builtInFactory(context);

                        // If accessing the returned ValidationProblemDetails object is required, get a reference to it.
                        var problemDetails = (ValidationProblemDetails)((ObjectResult)result).Value;

                        // Modify & Log accordingly.

                        return result;
                    };
                });
            #endregion
#endif
#if DefaultBehavior
            services.AddControllers();
#endif
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
