// #define DisableValidation
// #define DisableClientValidation

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ValidationSample.Data;
using ValidationSample.Services;
using ValidationSample.Validation;

namespace ValidationSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MovieContext>(options =>
                options.UseInMemoryDatabase("Movies"));

            services.AddSingleton<IUserService, UserService>();

            // <snippet_Configuration>
            services.AddRazorPages()
                .AddMvcOptions(options =>
                {
                    options.MaxModelValidationErrors = 50;
                    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                        _ => "The field is required.");
                });

            services.AddSingleton<IValidationAttributeAdapterProvider,
                CustomValidationAttributeAdapterProvider>();
            // </snippet_Configuration>

            services.AddControllersWithViews();

#if DisableValidation
            // <snippet_DisableValidation>
            services.AddSingleton<IObjectModelValidator, NullObjectModelValidator>();
            // </snippet_DisableValidation>
#endif

#if DisableClientValidation
            // <snippet_DisableClientValidation>
            services.AddRazorPages()
                .AddViewOptions(options =>
                {
                    options.HtmlHelperOptions.ClientValidationEnabled = false;
                });
            // </snippet_DisableClientValidation>
#endif
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
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}
