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
