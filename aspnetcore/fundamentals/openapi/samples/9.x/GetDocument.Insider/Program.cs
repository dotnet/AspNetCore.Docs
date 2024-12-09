using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

if (Assembly.GetEntryAssembly()?.GetName().Name != "GetDocument.Insider")
{
   // 'IServiceCollection' does not contain a definition for 'AddDefaults' 
   // builder.Services.AddDefaults();
}
var app = builder.Build();

var myKeyValue = app.Configuration["MyKey"];

app.MapGet("/", () => myKeyValue);

app.Run();