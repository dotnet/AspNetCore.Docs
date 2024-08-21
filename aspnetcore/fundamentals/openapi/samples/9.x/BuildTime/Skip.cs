#if NEVER
#region snippet_1
using ControllerApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

if (Assembly.GetEntryAssembly()?.GetName().Name != "MyTestApi")
{
    var schemeName = builder.Configuration.GetValue<string>("Authentication:SchemeName");
    builder.Services.AddAuthentication(schemeName);
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
#endregion
#endif
