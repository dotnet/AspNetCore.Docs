using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace RoutingSample
{
    public class StartupRegex2
    {

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            // Using an object literal to specify a regex constraint.

            // <snippet>
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "people",
                    pattern: "People/{ssn}",
                    constraints: new { ssn = "^\\d{3}-\\d{2}-\\d{4}$", },
                    defaults: new { controller = "People", action = "List", });
            });
            // </snippet>
        }
    }
}
