#define FIRST // FIRST
#if NEVER
#elif FIRST
#region snippet1
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddResponseCompression();

var app = builder.Build();

app.UseResponseCompression();

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion
#endif
