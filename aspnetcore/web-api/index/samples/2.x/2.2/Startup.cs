// Set preprocessor directive(s) to enable the scenarios you want to test.
// For more information on preprocessor directives and sample apps, see:
// https://docs.microsoft.com/aspnet/core/introduction-to-aspnet-core#preprocessor-directives-in-sample-code
//
// DefaultBehavior - default ControllerBase and ApiController behavior.
// SuppressApiControllerBehavior - use 2.1 behaviors although compat version is 2.2.

#define DefaultBehavior // or SuppressApiControllerBehavior

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
