using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

if (Assembly.GetEntryAssembly()?.GetName().Name != "GetDocument.Insider")
{
   // 'IServiceCollection' does not contain a definition for 'AddDefaults' 
    builder.Services.AddDefaults();
}
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

var myKeyValue = app.Configuration["MyKey"];

app.MapGet("/", () => { 
    return Results.Ok($"The value of MyKey is: {myKeyValue}"); 
})
.WithName("TestKey");

app.Run();
