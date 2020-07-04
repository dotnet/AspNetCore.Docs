using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace StaticFiles
{
    public class StartupStaticFiles
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        #region snippet_ConfigureMethod
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
        }
        #endregion
    }
}
