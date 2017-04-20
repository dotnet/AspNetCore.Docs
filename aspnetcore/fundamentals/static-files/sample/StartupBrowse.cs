using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;

namespace StaticFiles
{
    public class StartupBrowse
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        #region snippet2
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();
        }
        #endregion

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        #region snippet1
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles(); // For the wwwroot folder

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", "images")),
                RequestPath = new PathString("/MyImages")
            });

            app.UseDirectoryBrowser(new DirectoryBrowserOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", "images")),
                RequestPath = new PathString("/MyImages")
            });
        }
        #endregion
    }
}
