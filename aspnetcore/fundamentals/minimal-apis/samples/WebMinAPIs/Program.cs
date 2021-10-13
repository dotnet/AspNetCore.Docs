#define LOG // Default CREATE P1 PM PE I1 I0 IP CERT CERT2 CERT3 RE CONFIG LOG
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
#elif CERT
#region snippet_cert
var app = WebApplication.Create(args);

app.Urls.Add("https://localhost:3000");

app.MapGet("/", () => "Hello World");

app.Run();
#endregion
#elif CERT2
// Warning. The following code writes to the configuration system and
// sets the Cert path and key. If those values are invalid, Kestrel won't run
// for that project, even if you remove the following code.
#region snippet_cert2
var builder = WebApplication.CreateBuilder(args);

// Configure the cert and the key
builder.Configuration["Kestrel:Certificates:Default:Path"] = "cert.pem";
builder.Configuration["Kestrel:Certificates:Default:KeyPath"] = "key.pem";

var app = builder.Build();

app.Urls.Add("https://localhost:3000");

app.MapGet("/", () => "Hello World");

app.Run();
#endregion
#elif CERT3
#region snippet_cert3
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureKestrel(options =>
{
    options.ConfigureHttpsDefaults(httpsOptions =>
    {
        var certPath = Path.Combine(builder.Environment.ContentRootPath, "cert.pem");
        var keyPath = Path.Combine(builder.Environment.ContentRootPath, "key.pem");

        httpsOptions.ServerCertificate = X509Certificate2.CreateFromPemFile(certPath, 
                                         keyPath);
    });
});

var app = builder.Build();

app.Urls.Add("https://localhost:3000");

app.MapGet("/", () => "Hello World");

app.Run();
#endregion
#elif RE
#region snippet_re
var app = WebApplication.Create(args);

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/oops");
}

app.MapGet("/", () => "Hello World");
app.MapGet("/oops", () => "Oops! An error happened.");

app.Run();
#endregion
#elif CONFIG
#region snippet_log
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var message = app.Configuration["HelloKey"] ?? "Hello";

app.MapGet("/", () => message);

app.Run();
#endregion
#elif LOG
#region snippet_config
var app = WebApplication.Create(args);

app.Logger.LogInformation("The app started");

app.MapGet("/", () => "Hello World");

app.Run();
#endregion
#endif