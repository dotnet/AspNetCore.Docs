using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using TodoApi.Models;
using NSwag.AspNetCore;
using System.Reflection;
using NJsonSchema;

namespace TodoApi
{
    public class Startup
    {
        #region snippet_ConfigureServices

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            services.AddMvc();
        }

        #endregion snippet_ConfigureServices

        #region snippet_Configure

        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            // Enable the Swagger UI middleware and the Swagger generator
            app.UseSwaggerUi(typeof(Startup).GetTypeInfo().Assembly, settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling = PropertyNameHandling.CamelCase;
            });

            app.UseMvc();
        }

        #endregion snippet_Configure
    }
}