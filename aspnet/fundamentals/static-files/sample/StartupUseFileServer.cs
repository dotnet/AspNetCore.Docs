using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;

namespace StaticFiles
{
    public class StartupUseFileServer
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // >Services
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDirectoryBrowser();
        }
        // <Services

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // >Configure
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseStaticFiles();

            app.UseFileServer(new FileServerOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"MyStaticFiles")),
                RequestPath = new PathString("/StaticFiles"),
                EnableDirectoryBrowsing = true
            });
        }
        // <Configure
    }
}