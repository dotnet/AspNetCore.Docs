#nullable enable

using Microsoft.AspNetCore.Server.HttpSys;

var builder = WebApplication.CreateBuilder(args);

// <snippet_hardening>
builder.WebHost.UseHttpSys(options =>
{
    options.HttpAuthenticationHardeningLevel =
        HttpAuthenticationHardeningLevel.Strict;
});
// </snippet_hardening>

var app = builder.Build();

app.MapGet("/", () => "HTTP.sys feature examples");
app.MapGet("/tls", (HttpContext context, ILoggerFactory loggerFactory) =>
{
    if (!context.Request.IsHttps)
    {
        return Results.BadRequest("Configure an HTTPS binding and enable native TLS ClientHello caching before using this endpoint.");
    }

    var logger = loggerFactory.CreateLogger("HttpSysFeatures");
    HttpSysFeatureExamples.LogCipherSuite(context, logger);
    HttpSysFeatureExamples.LogChannelBinding(context, logger);
    HttpSysFeatureExamples.LogClientHello(context, logger);
    HttpSysFeatureExamples.LogRequestProperty(context, logger);
    return Results.Ok("TLS feature information was written to the application log.");
});

app.Run();
