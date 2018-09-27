using Microsoft.AspNetCore.Builder;
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
    public class Startup2
    {
        #region snippet_ConfigureServices
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt =>
                opt.UseInMemoryDatabase("TodoList"));
            services.AddMvc();

            // Register the Swagger services
            services.AddSwagger();
        }
        #endregion snippet_ConfigureServices

        #region snippet_Configure
        public void Configure(IApplicationBuilder app)
        {
            app.UseStaticFiles();

            #region snippet_UseSwagger
            // Register the Swagger generator middleware
            app.UseSwaggerWithApiExplorer(settings =>
            {
                settings.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "ToDo API";
                    document.Info.Description = "A simple ASP.NET Core web API";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.SwaggerContact
                    {
                        Name = "Shayne Boyer",
                        Email = string.Empty,
                        Url = "https://twitter.com/spboyer"
                    };
                    document.Info.License = new NSwag.SwaggerLicense
                    {
                        Name = "Use under LICX",
                        Url = "https://example.com/license"
                    };
                };
            });
            #endregion snippet_UseSwagger

            // Register the Swagger UI middleware
            app.UseSwaggerUi3();

            app.UseMvc();
        }
        #endregion snippet_Configure
    }
}