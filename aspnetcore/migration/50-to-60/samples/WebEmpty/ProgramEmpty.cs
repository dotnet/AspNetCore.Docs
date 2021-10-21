#define ORG  // ORG COMMENTS
#if ORG
#region snippet1
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion
#elif COMMENTS
#region snippet2
var builder = WebApplication.CreateBuilder(args);
// CreateBuilder returns a WebApplicationBuilder
var app = builder.Build();
// Build returns a WebApplication

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion
#endif