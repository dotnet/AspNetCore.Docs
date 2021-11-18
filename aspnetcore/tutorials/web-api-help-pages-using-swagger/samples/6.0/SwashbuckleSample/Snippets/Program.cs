using Microsoft.OpenApi.Models;

namespace SwashbuckleSample.Snippets
{
    public static class Program
    {
#pragma warning disable CS7022
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region snippet_ServicesDefault
            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            var app = builder.Build();

            #region snippet_MiddlewareJsonV2
            app.UseSwagger(options =>
            {
                options.SerializeAsV2 = true;
            });
            #endregion

            #region snippet_MiddlewareRoutePrefix
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
            #endregion
        }

        private static void Snippet1(WebApplicationBuilder builder)
        {
            #region snippet_ServicesOpenApiInfo
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "An ASP.NET Core Web API for managing ToDo items",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Example Contact",
                        Url = new Uri("https://example.com/contact")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Example License",
                        Url = new Uri("https://example.com/license")
                    }
                });
            });
            #endregion
        }

        private static void Snippet2(WebApplication app)
        {
            #region snippet_MiddlewareInjectStylesheet
            app.UseSwaggerUI(options =>
            {
                options.InjectStylesheet("/swagger-ui/custom.css");
            });
            #endregion

            #region snippet_MiddlewareStaticFiles
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.MapControllers();
            #endregion
        }
#pragma warning restore CS7022
    }
}
