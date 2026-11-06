using Microsoft.EntityFrameworkCore;
using NSwagSample.Models;
// <snippet_Services>
using NSwag;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApiDocument(options => {
     options.PostProcess = document =>
     {
         document.Info = new OpenApiInfo
         {
             Version = "v1",
             Title = "ToDo API",
             Description = "An ASP.NET Core Web API for managing ToDo items",
             TermsOfService = "https://example.com/terms",
             Contact = new OpenApiContact
             {
                 Name = "Example Contact",
                 Url = "https://example.com/contact"
             },
             License = new OpenApiLicense
             {
                 Name = "Example License",
                 Url = "https://example.com/license"
             }
         };
     };
});
// </snippet_Services>

builder.Services.AddDbContext<TodoContext>(options =>
    options.UseInMemoryDatabase("Todo"));

builder.Services.AddControllers();

var app = builder.Build();

// <snippet_Middleware>
if (app.Environment.IsDevelopment())
{
    // Add OpenAPI 3.0 document serving middleware
    // Available at: http://localhost:<port>/swagger/v1/swagger.json
    app.UseOpenApi();

    // Add web UIs to interact with the document
    // Available at: http://localhost:<port>/swagger
    app.UseSwaggerUi(); // UseSwaggerUI is called only in Development.
    
    // Add ReDoc UI to interact with the document
    // Available at: http://localhost:<port>/redoc
    app.UseReDoc(options =>
    {
        options.Path = "/redoc";
    });
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
using Microsoft.EntityFrameworkCore;
using NSwag;
using NSwagSample.Models;

// <snippet_ServicesDefault>
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApiDocument();
// </snippet_ServicesDefault>

builder.Services.AddDbContext<TodoContext>(options =>
    options.UseInMemoryDatabase("Todo"));

var app = builder.Build();

// <snippet_MiddlewareDefault>
if (app.Environment.IsDevelopment())
{
    // Add OpenAPI 3.0 document serving middleware
    // Available at: http://localhost:<port>/swagger/v1/swagger.json
    app.UseOpenApi();

    // Add web UIs to interact with the document
    // Available at: http://localhost:<port>/swagger
    app.UseSwaggerUi(); // UseSwaggerUI Protected by if (env.IsDevelopment())
}
// </snippet_MiddlewareDefault>

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
#endif
