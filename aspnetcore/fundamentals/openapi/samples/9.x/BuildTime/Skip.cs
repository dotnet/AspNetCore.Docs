#if NEVER
// <snippet_1>
using ControllerApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

if (Assembly.GetEntryAssembly()?.GetName().Name != "MyTestApi")
{
    builder.Services.AddDbContext<ControllerApiContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ControllerApiContext")
        ?? throw new InvalidOperationException("Connection string 'ControllerApiContext' not found.")));
}

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
// </snippet_1>
#endif
