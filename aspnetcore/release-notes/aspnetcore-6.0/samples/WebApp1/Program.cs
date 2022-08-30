#define JSONB  // DEF LATIN DIAG DCRT JSONB FDRS IIS2 HTTPLG ICSF RED
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
    if (desiredState)
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
// Doesn't compile with RC2
#region snippet_jsonb
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages()
            .AddNewtonsoftJson(options =>
            { 
                options.OutputFormatterMemoryBufferThreshold = 48 * 1024;
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
#elif HTTPLG
#region snippet_httplg
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();
app.UseHttpLogging();

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion
#elif HTTPLG2
#region snippet_httplg2
using Microsoft.AspNetCore.HttpLogging;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpLogging(logging =>
{
    // Customize HTTP logging.
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("My-Request-Header");
    logging.ResponseHeaders.Add("My-Response-Header");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
});

var app = builder.Build();
app.UseHttpLogging();

app.MapGet("/", () => "Hello World!");

app.Run();
#endregion
#elif ICSF
#region snippet_icsf
var builder = WebApplication.CreateBuilder(args);
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ConfigureEndpointDefaults(listenOptions => listenOptions.Use((connection, next) =>
    {
        var socketFeature = connection.Features.Get<IConnectionSocketFeature>();
        socketFeature.Socket.LingerState = new LingerOption(true, seconds: 10);
        return next();
    }));
});
var app = builder.Build();
app.MapGet("/", (Func<string>)(() => "Hello world"));
await app.RunAsync();
#endregion
#elif RED
#region snippet_red
using StackExchange.Redis.Profiling;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.ProfilingSession = () => new ProfilingSession();
});
#endregion

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

#endif
