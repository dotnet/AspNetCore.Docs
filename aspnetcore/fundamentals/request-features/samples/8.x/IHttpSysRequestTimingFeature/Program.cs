#define WithTimestamps // WithTimestamps, WithTryGetTimestamp, WithTryGetElapsedTime

using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Server.HttpSys;

#if WithTimestamps
#region snippet_WithTimestamps
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseHttpSys();

var app = builder.Build();

app.Use((context, next) =>
{
    var feature = context.Features.GetRequiredFeature<IHttpSysRequestTimingFeature>();
    
    var loggerFactory = context.RequestServices.GetRequiredService<ILoggerFactory>();
    var logger = loggerFactory.CreateLogger("Sample");

    var timestamps = feature.Timestamps;

    for (var i = 0; i < timestamps.Length; i++)
    {
        var timestamp = timestamps[i];
        var timingType = (HttpSysRequestTimingType)i;

        logger.LogInformation("Timestamp {timingType}: {timestamp}", timingType, timestamp);
    }

    return next(context);
});

app.MapGet("/", () => Results.Ok());

app.Run();
#endregion
#elif WithTryGetTimestamp
#region snippet_WithTryGetTimestamp
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseHttpSys();

var app = builder.Build();

app.Use((context, next) =>
{
    var feature = context.Features.GetRequiredFeature<IHttpSysRequestTimingFeature>();

    var loggerFactory = context.RequestServices.GetRequiredService<ILoggerFactory>();
    var logger = loggerFactory.CreateLogger("Sample");

    var timingType = HttpSysRequestTimingType.RequestRoutingEnd;

    if (feature.TryGetTimestamp(timingType, out var timestamp))
    {
        logger.LogInformation("Timestamp {timingType}: {timestamp}", timingType, timestamp);
    }
    else
    {
        logger.LogInformation("Timestamp {timingType}: not available for the current request", timingType);
    }

    return next(context);
});

app.MapGet("/", () => Results.Ok());

app.Run();
#endregion
#elif WithTryGetElapsedTime
#region snippet_WithTryGetElapsedTime
var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseHttpSys();

var app = builder.Build();

app.Use((context, next) =>
{
    var feature = context.Features.GetRequiredFeature<IHttpSysRequestTimingFeature>();

    var loggerFactory = context.RequestServices.GetRequiredService<ILoggerFactory>();
    var logger = loggerFactory.CreateLogger("Sample");

    var startingTimingType = HttpSysRequestTimingType.RequestRoutingStart;
    var endingTimingType = HttpSysRequestTimingType.RequestRoutingEnd;

    if (feature.TryGetElapsedTime(startingTimingType, endingTimingType, out var elapsed))
    {
        logger.LogInformation("Elapsed time {startingTimingType} to {endingTimingType}: {elapsed}",
            startingTimingType,
            endingTimingType,
            elapsed);
    }
    else
    {
        logger.LogInformation("Elapsed time {startingTimingType} to {endingTimingType}: not available for the current request.",
            startingTimingType,
            endingTimingType);
    }

    return next(context);
});

app.MapGet("/", () => Results.Ok());

app.Run();
#endregion
#endif
