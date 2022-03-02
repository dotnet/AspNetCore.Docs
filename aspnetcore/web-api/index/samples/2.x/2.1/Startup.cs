// Set preprocessor directive(s) to enable the scenarios you want to test.
// For more information on preprocessor directives and sample apps, see:
// https://docs.microsoft.com/aspnet/core/introduction-to-aspnet-core#preprocessor-directives-in-sample-code
//
// SuppressApiControllerBehavior - disable settings that are enabled when using [ApiController].

//#define SuppressApiControllerBehavior

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#region snippet_Assembly
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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

#if SuppressApiControllerBehavior
            #region snippet_ConfigureApiBehaviorOptions
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressConsumesConstraintForFormFileParameters = true;
                options.SuppressInferBindingSourcesForParameters = true;
                options.SuppressModelStateInvalidFilter = true;
            });
            #endregion
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
