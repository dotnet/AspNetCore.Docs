using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoApi.Models;

namespace TodoApi
{
    public class Startup
    {
        // <snippet_ConfigureServices>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt =>
                opt.UseInMemoryDatabase("TodoList"));
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register the Swagger services
            services.AddSwaggerDocument();
        }
        // </snippet_ConfigureServices>

        // <snippet_Configure>
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseMvc();
        }
        // </snippet_Configure>
    }
}