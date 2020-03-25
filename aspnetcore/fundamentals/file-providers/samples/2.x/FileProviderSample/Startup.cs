using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace FileProviderSample
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            #region snippet1
            var physicalProvider = _env.ContentRootFileProvider;
            var manifestEmbeddedProvider = 
                new ManifestEmbeddedFileProvider(typeof(Program).Assembly);
            var compositeProvider = 
                new CompositeFileProvider(physicalProvider, manifestEmbeddedProvider);

            services.AddSingleton<IFileProvider>(compositeProvider);
            #endregion
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}
