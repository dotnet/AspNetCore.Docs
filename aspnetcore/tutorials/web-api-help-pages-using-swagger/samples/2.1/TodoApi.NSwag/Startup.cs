using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
#region snippet_StartupConfigureImports
using NJsonSchema;
using NSwag.AspNetCore;
using System.Reflection;
#endregion
using TodoApi.Models;

namespace TodoApi
{
    public class Startup
    {
        #region snippet_ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt => 
                opt.UseInMemoryDatabase("TodoList"));
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register the Swagger services
            services.AddSwagger();
        }
        #endregion snippet_ConfigureServices

        #region snippet_Configure
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseSwaggerUi3WithApiExplorer(settings =>
            {
                settings.GeneratorSettings.DefaultPropertyNameHandling = 
                    PropertyNameHandling.CamelCase;
            });

            app.UseMvc();
        }
        #endregion snippet_Configure
    }
}