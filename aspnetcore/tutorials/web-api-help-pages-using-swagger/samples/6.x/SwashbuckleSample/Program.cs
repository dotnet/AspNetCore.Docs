using System.Reflection;
using Microsoft.EntityFrameworkCore;
// <snippet_UsingOpenApiModels>
using Microsoft.OpenApi.Models;
// </snippet_UsingOpenApiModels>
using SwashbuckleSample.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<TodoContext>(options =>
    options.UseInMemoryDatabase("Todo"));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

// <snippet_Services>
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

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
// </snippet_Services>

var app = builder.Build();

// Configure the HTTP request pipeline.
// <snippet_Middleware>
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// </snippet_Middleware>

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var serviceScope = app.Services.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<TodoContext>();

    context.TodoItems.Add(new TodoItem { Name = "Item #1" });
    await context.SaveChangesAsync();
}

app.Run();

#if false
// The following code is only for article snippets.
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
        if (builder.Environment.IsDevelopment())
        {
            app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
        }
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
        if (app.Environment.IsDevelopment())
        {
            app.UseSwaggerUI(options => // UseSwaggerUI is called only in Development.
            {
                options.InjectStylesheet("/swagger-ui/custom.css");
            });
        }
        // </snippet_MiddlewareInjectStylesheet>

        // <snippet_MiddlewareStaticFiles>
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.MapControllers();
        // </snippet_MiddlewareStaticFiles>
    }
}
#endif
