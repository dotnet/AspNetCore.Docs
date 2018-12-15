using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MVCMovie.Controllers;

namespace MVCMovie
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new MVCMovieContext());
            services.AddSingleton<IUserRepository>(new UserRepository());
            services.AddMvc(options => options.MaxModelValidationErrors = 50)
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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
