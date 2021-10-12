#define CREATE // Default CREATE
#if Default
#region snippet_default
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion
#elif CREATE
#region snippet_default
var app = WebApplication.Create(args);

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion
#endif