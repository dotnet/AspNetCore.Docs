using Microsoft.OpenApi.Models;

namespace SwashbuckleSample.Snippets;

public static class Program
{
    public static void Snippet1(WebApplicationBuilder builder)
    {
        // <snippet_ServicesDefault>
        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        // </snippet_ServicesDefault>

        var app = builder.Build();

        // <snippet_MiddlewareJsonV2>
        app.UseSwagger(options =>
        {
            options.SerializeAsV2 = true;
        });
        // </snippet_MiddlewareJsonV2>

        // <snippet_MiddlewareRoutePrefix>
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        });
        // </snippet_MiddlewareRoutePrefix>
    }

    private static void Snippet2(WebApplicationBuilder builder)
    {
        // <snippet_ServicesOpenApiInfo>
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
        // </snippet_ServicesOpenApiInfo>
    }

    private static void Snippet3(WebApplication app)
    {
        // <snippet_MiddlewareInjectStylesheet>
        app.UseSwaggerUI(options =>
        {
            options.InjectStylesheet("/swagger-ui/custom.css");
        });
        // </snippet_MiddlewareInjectStylesheet>

        // <snippet_MiddlewareStaticFiles>
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.MapControllers();
        // </snippet_MiddlewareStaticFiles>
    }
}
