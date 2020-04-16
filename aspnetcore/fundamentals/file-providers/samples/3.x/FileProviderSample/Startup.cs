using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace FileProviderSample
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;

        public Startup(IWebHostEnvironment env)
        {
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            #region snippet1
            var physicalProvider = _env.ContentRootFileProvider;
            var manifestEmbeddedProvider = 
                new ManifestEmbeddedFileProvider(typeof(Program).Assembly);
            var compositeProvider = 
                new CompositeFileProvider(physicalProvider, manifestEmbeddedProvider);

            services.AddSingleton<IFileProvider>(compositeProvider);
            #endregion
        }

        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
