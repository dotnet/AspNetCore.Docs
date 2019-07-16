//#define DisableValidation

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.Extensions.DependencyInjection;
using ValidationSample.Controllers;
using ValidationSample.Data;
using ValidationSample;
using ValidationSample.Attributes;

namespace ValidationSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new MovieContext());
            services.AddSingleton<IUserRepository>(new UserRepository());
#if DisableValidation
            #region snippet_DisableValidation
            // There is only one `IObjectModelValidator` object,
            // so AddSingleton replaces the default one.
            services.AddSingleton<IObjectModelValidator>(new NullObjectModelValidator());
            #endregion
#endif
            #region snippet_MaxModelValidationErrors
            services.AddMvc(options => 
                {
                    options.MaxModelValidationErrors = 50;
                    options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
                        (_) => "The field is required.");
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSingleton
                <IValidationAttributeAdapterProvider, 
                 CustomValidationAttributeAdapterProvider>();
            #endregion
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();
            app.UseMvc(routes => routes.MapRoute(
                name: "default",
                template: "{controller=Movies}/{action=Index}/{id:int?}"));
        }
    }
}
