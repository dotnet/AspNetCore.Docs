#define MID // MID RT
#if MID
#region snippet_mid
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();

app.Run();
#endregion
#elif RT
#region snippet_rt
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion
#endif
