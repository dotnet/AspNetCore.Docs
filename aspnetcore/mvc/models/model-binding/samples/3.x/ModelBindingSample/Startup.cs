using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ModelBindingSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // <snippet_ValueProvider>
            services.AddRazorPages()
                .AddMvcOptions(options =>
            {
                options.ValueProviderFactories.Add(new CookieValueProviderFactory());
                options.ModelMetadataDetailsProviders.Add(
                    new ExcludeBindingMetadataProvider(typeof(System.Version)));
                options.ModelMetadataDetailsProviders.Add(
                    new SuppressChildValidationMetadataProvider(typeof(System.Guid)));
            })
            .AddXmlSerializerFormatters();
            // </snippet_ValueProvider>

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
