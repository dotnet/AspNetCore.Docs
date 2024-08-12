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
// <snippet_2>
using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// Middleware that conditionally opts-out HTTP requests.
app.Use(async (context, next) =>
{
    if (context.Request.Headers.ContainsKey("x-disable-metrics"))
    {
        context.Features.Get<IHttpMetricsTagsFeature>()?.MetricsDisabled = true;
    }

    await next(context);
});
// </snippet_2>

app.Run();
#endif
