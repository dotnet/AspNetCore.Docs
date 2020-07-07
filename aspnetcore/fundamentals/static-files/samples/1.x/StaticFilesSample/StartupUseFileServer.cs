using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace StaticFiles
{
    public class StartupUseFileServer
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        #region snippet_ConfigureServicesMethod
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();
        }
        #endregion

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        #region snippet_ConfigureMethod
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles(); // For the wwwroot folder

            app.UseFileServer(new FileServerOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "MyStaticFiles")),
                RequestPath = "/StaticFiles",
                EnableDirectoryBrowsing = true
            });
        }
        #endregion
    }
}
