#define SECOND // FIRST SECOND
#if NEVER
#elif FIRST
// <snippet_1>
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHealthChecks();

var app = builder.Build();
app.MapHealthChecks("/healthz").DisableHttpMetrics();
app.Run();
// </snippet_1>
#elif SECOND

using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

/*
app.Use(async (context, next) =>
{
    if (context.Request.Headers.ContainsKey("x-disable-metrics"))
    {
        // CS0131 The left-hand side of an assignment must be a variable, property or indexer
        context.Features.Get<IHttpMetricsTagsFeature>()?.MetricsDisabled = true;
    }

    await next(context);
});
*/

// <snippet_2>
// Middleware that conditionally opts-out HTTP requests.
app.Use(async (context, next) =>
{
    var metricsFeature = context.Features.Get<IHttpMetricsTagsFeature>();
    if (context.Request.Headers.ContainsKey("x-disable-metrics") 
                                      && metricsFeature != null)
    {
        metricsFeature.MetricsDisabled = true;
    }

    await next(context);
});

app.Run();
// </snippet_2>
#endif