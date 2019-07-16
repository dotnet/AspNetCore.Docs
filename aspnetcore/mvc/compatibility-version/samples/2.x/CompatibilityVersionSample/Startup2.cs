using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.DependencyInjection;

namespace CompatibilityVersionSample
{
    public class Startup2
    {
        #region snippet1
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                // Include the 2.2 behaviors
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                // Except for the following.
                .AddMvcOptions(options =>
                {
                    // Don't combine authorize filters (keep 2.0 behavior).
                    options.AllowCombiningAuthorizeFilters = false;
                    // All exceptions thrown by an IInputFormatter are treated
                    // as model state errors (keep 2.0 behavior).
                    options.InputFormatterExceptionPolicy =
                        InputFormatterExceptionPolicy.AllExceptions;
                });
        }
        #endregion

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
