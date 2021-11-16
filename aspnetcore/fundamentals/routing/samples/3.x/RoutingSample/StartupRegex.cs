using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
            
           // Using an inline-constraint to specify a regex constraint.

            // <snippet>
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("{message:regex(^\\d{{3}}-\\d{{2}}-\\d{{4}}$)}",
                    context => 
                    {
                        return context.Response.WriteAsync("inline-constraint match");
                    });
             });
            // </snippet>
         

        }
    }
}
