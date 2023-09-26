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

// <snippet_Middleware>
if (app.Environment.IsDevelopment())
{
    // Add OpenAPI 3.0 document serving middleware
    // Available at: http://localhost:<port>/swagger/v1/swagger.json
    app.UseOpenApi();

    // Add web UIs to interact with the document
    // Available at: http://localhost:<port>/swagger
    app.UseSwaggerUi3();
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
