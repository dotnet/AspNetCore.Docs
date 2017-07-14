using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace RazorPagesIntro
{
    #region Startup
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // Includes support for Razor Pages and controllers.
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
    #endregion
}
