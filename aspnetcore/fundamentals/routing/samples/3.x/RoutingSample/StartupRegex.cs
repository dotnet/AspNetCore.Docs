using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace RoutingSample
{
    public class StartupRegex
    {

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            /*
            #region snippet
            app.UseEndpoints(endpoints =>
            {
                // Using an inline-constraint to specify a regex constraint.
                endpoints.MapGet("{message:regex(^\\d{{3}}-\\d{{2}}-\\d{{4}}$)}",
                    context => { ... });

                // Using an object literal to specify a regex constraint.
                endpoints.MapControllerRoute(
                    "people",
                    "People/{ssn}",
                    constraints: new { controller = "^\\d{3}-\\d{2}-\\d{4}$", },
                    defaults: new { controller = "People", action = "List", });
            }
            #endregion
            */

        }
    }
}
