#define IIS2  // DEF LATIN DIAG DCRT JSONB FDRS IIS2
#if DEF
#elif NEVER
#region snippet_1
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
#endregion
#elif LATIN
#region snippet_latin
var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseHttpSys(o => o.UseLatin1RequestHeaders = true);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion
#elif DIAG
#region snippet_diag
using Microsoft.AspNetCore.Http.Features;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
var diagnosticSource = app.Services.GetRequiredService<DiagnosticListener>();
using var badRequestListener = new BadRequestEventListener(diagnosticSource,
    (badRequestExceptionFeature) =>
{
    app.Logger.LogError(badRequestExceptionFeature.Error, "Bad request received");
});
app.MapGet("/", () => "Hello world");

app.Run();

class BadRequestEventListener : IObserver<KeyValuePair<string, object>>, IDisposable
{
    private readonly IDisposable _subscription;
    private readonly Action<IBadRequestExceptionFeature> _callback;

    public BadRequestEventListener(DiagnosticListener diagnosticListener,
                                   Action<IBadRequestExceptionFeature> callback)
    {
        _subscription = diagnosticListener.Subscribe(this!, IsEnabled);
        _callback = callback;
    }
    private static readonly Predicate<string> IsEnabled = (provider) => provider switch
    {
        "Microsoft.AspNetCore.Server.Kestrel.BadRequest" => true,
        _ => false
    };
    public void OnNext(KeyValuePair<string, object> pair)
    {
        if (pair.Value is IFeatureCollection featureCollection)
        {
            var badRequestFeature = featureCollection.Get<IBadRequestExceptionFeature>();

            if (badRequestFeature is not null)
            {
                _callback(badRequestFeature);
            }
        }
    }
    public void OnError(Exception error) { }
    public void OnCompleted() { }
    public virtual void Dispose() => _subscription.Dispose();
}

#endregion
#elif DCRT
#region snippert_dcrt
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.AspNetCore.WebUtilities;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseKestrel(options =>
{
    options.ConfigureHttpsDefaults(adapterOptions =>
    {
        adapterOptions.ClientCertificateMode = ClientCertificateMode.DelayCertificate;
    });
});

var app = builder.Build();
app.Use(async (context, next) =>
{
    bool desiredState = GetDesiredState();
    // Check if your desired criteria is met
    if (desiredState == true)
    {
        // Buffer the request body
        context.Request.EnableBuffering();
        var body = context.Request.Body;
        await body.DrainAsync(context.RequestAborted);
        body.Position = 0;

        // Request client certificate
        var cert = await context.Connection.GetClientCertificateAsync();

        //  Disable buffering on future requests if the client doesn't provide a cert
    }
    await next(context);
});


app.MapGet("/", () => "Hello World!");
app.Run();
#endregion

bool GetDesiredState()
{
    throw new NotImplementedException();
}
#elif JSONB
#region snippet_jsonb
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages()
            .AddNewtonsoftJson(options =>
            { 
                options.InputFormatterMemoryBufferThreshold = 48 * 1024;
            });

var app = builder.Build();
#endregion

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
#elif FDRS
#region snippet_hdrs
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Use(async (context, next) =>
{
    var hostHeader = context.Request.Headers.Host;
    app.Logger.LogInformation("Host header: {host}", hostHeader);
    context.Response.Headers.XPoweredBy = "ASP.NET Core 6.0";
    await next.Invoke(context);
    var dateHeader = context.Response.Headers.Date;
    app.Logger.LogInformation("Response date: {date}", dateHeader);
});

app.Run();
#endregion
#elif IIS2
#region snippet_iis2
var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<IISServerOptions>(
        options =>
        {
            options.MaxRequestBodySize = 64 * 1024;
        }
    );

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion
#endif