#define I0 // Default CREATE P1 PM PE I1 I0 IP
#if Default
#region snippet_default
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion
#elif CREATE
#region snippet_create
var app = WebApplication.Create(args);

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion
#elif P1 // P for Port
#region snippet_p1
var app = WebApplication.Create(args);

app.MapGet("/", () => "Hello World!");

app.Run("http://localhost:3000");
#endregion
#elif PM // P for Port
#region snippet_pm
var app = WebApplication.Create(args);

app.Urls.Add("http://localhost:3000");
app.Urls.Add("http://localhost:4000");

app.MapGet("/", () => "Hello World");

app.Run();
#endregion
#elif PE // P for Port
#region snippet_pe
var app = WebApplication.Create(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "3000";

app.MapGet("/", () => "Hello World");

app.Run($"http://localhost:{port}");
#endregion
#elif I1
#region snippet_i1
var app = WebApplication.Create(args);

app.Urls.Add("http://*:3000");

app.MapGet("/", () => "Hello World");

app.Run();
#endregion
#elif IP
#region snippet_ip
var app = WebApplication.Create(args);

app.Urls.Add("http://+:3000");

app.MapGet("/", () => "Hello World");

app.Run();
#endregion
#elif I0
#region snippet_i0
var app = WebApplication.Create(args);

app.Urls.Add("http://0.0.0.0:3000");

app.MapGet("/", () => "Hello World");

app.Run();
#endregion
#endif