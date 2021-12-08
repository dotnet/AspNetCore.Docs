using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
// <snippet_InfoClassNamespace>
using Microsoft.OpenApi.Models;
// </snippet_InfoClassNamespace>
using TodoApi.Models;
// <snippet_PreReqNamespaces>
using System;
using System.Reflection;
using System.IO;
// </snippet_PreReqNamespaces>
namespace TodoApi
{
    public class Startup2
    {
        // <snippet_ConfigureServices>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt =>
                opt.UseInMemoryDatabase("TodoList"));
            services.AddMvc();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen();
        }
        // </snippet_ConfigureServices>

        // <snippet_Configure>
        public void Configure(IApplicationBuilder app)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
        }
        // </snippet_Configure>
    }
}
