using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MVCMovie.Controllers;

namespace MVCMovie
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services, IHostingEnvironment env)
        {
            services.AddSingleton(new MVCMovieContext());
            services.AddSingleton<IUserRepository>(new UserRepository());
            #region snippet_DisableClientValidation
            services.Configure<HtmlHelperOptions>(o => o.ClientValidationEnabled = false);
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
