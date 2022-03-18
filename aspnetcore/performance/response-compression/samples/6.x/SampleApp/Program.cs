#define FIRST // FIRST
#if NEVER
#elif FIRST
#region snippet
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponseCompression();

var app = builder.Build();

app.UseResponseCompression();

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion
#endif
