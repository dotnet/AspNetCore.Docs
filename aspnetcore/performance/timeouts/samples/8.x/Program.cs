#define policies2 // oneendpoint / policies1 / policies2

#if oneendpoint
// <<oneendpoint>
using Microsoft.AspNetCore.Http.Timeouts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRequestTimeouts();

var app = builder.Build();
app.UseRequestTimeouts();

app.MapGet("/", async (HttpContext context) => {
    await Task.Delay(TimeSpan.FromSeconds(2));

    if (context.RequestAborted.IsCancellationRequested) {
        return Results.Content("Timeout!", "text/plain");
    }

    return Results.Content("No timeout!", "text/plain");
}).WithRequestTimeout(TimeSpan.FromSeconds(1));
// Returns "Timeout!"

app.MapGet("/attribute",
    [RequestTimeout(milliseconds: 1000)] async (HttpContext context) => {
        await Task.Delay(TimeSpan.FromSeconds(2));

        if (context.RequestAborted.IsCancellationRequested) {
            return Results.Content("Timeout!", "text/plain");
        }

        return Results.Content("No timeout!", "text/plain");
    });
// Returns "Timeout!"

app.Run();
// </oneendpoint>
#endif

#if policies1
using Microsoft.AspNetCore.Http.Timeouts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRequestTimeouts();

// <definepolicies1>
builder.Services.AddRequestTimeouts(options => {
    options.DefaultPolicy =
        new RequestTimeoutPolicy { Timeout = TimeSpan.FromMilliseconds(1500) };
    options.AddPolicy("MyPolicy", TimeSpan.FromSeconds(1));
});
// <//definepolicies1>

var app = builder.Build();
app.UseRequestTimeouts();

// <<usepolicy>
app.MapGet("/namedpolicy", async (HttpContext context) => {
    await Task.Delay(TimeSpan.FromSeconds(2));

    if (context.RequestAborted.IsCancellationRequested) {
        return Results.Content("Timeout!", "text/plain");
    }

    return Results.Content("No timeout!", "text/plain");
}).WithRequestTimeout("MyPolicy");
// Returns "Timeout!"
// </usepolicy>

// <<usedefault>
app.MapGet("/", async (HttpContext context) => {
    await Task.Delay(TimeSpan.FromSeconds(2));

    if (context.RequestAborted.IsCancellationRequested) {
        return Results.Content("Timeout!", "text/plain");
    }

    return Results.Content("No timeout!", "text/plain");
});
// Returns "Timeout!" due to default policy.
// </usedefault>

// <<disableall>
app.MapGet("/disableall", [DisableRequestTimeout] async (HttpContext context) => {
    await Task.Delay(TimeSpan.FromSeconds(2));

    return Results.Content("No timeout!", "text/plain");
});
// Returns "No timeout!", ignores default timeout.
// </disableall>
app.Run();
#endif

#if policies2
using Microsoft.AspNetCore.Http.Timeouts;

var builder = WebApplication.CreateBuilder(args);

// <definepolicies2>
builder.Services.AddRequestTimeouts(options =>
{
    options.DefaultPolicy =
        new RequestTimeoutPolicy
        {
            Timeout = TimeSpan.FromMilliseconds(1000),
            TimeoutStatusCode = 504
        };
    options.AddPolicy("MyPolicy2",
        new RequestTimeoutPolicy
        {
            Timeout = TimeSpan.FromMilliseconds(1000),
            WriteTimeoutResponse = async (HttpContext context) =>
            {
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Timeout!");
            }
        });
});
// </definepolicies2>

var app = builder.Build();
app.UseRequestTimeouts();

// <<usedefault2>
app.MapGet("/", async (HttpContext context) => {
    await Task.Delay(TimeSpan.FromSeconds(2));

    context.RequestAborted.ThrowIfCancellationRequested();

    return Results.Content("No timeout!", "text/plain");
});
// </usedefault2>

// <<usepolicy2>
app.MapGet("/usepolicy", async (HttpContext context) =>
{
    await Task.Delay(TimeSpan.FromSeconds(2));

    context.RequestAborted.ThrowIfCancellationRequested();

    return Results.Content("No timeout!", "text/plain");
}).WithRequestTimeout("MyPolicy2");
// </usepolicy2>

// <<canceltimeout>
app.MapGet("/canceltimeout", async (HttpContext context) =>
{
    await Task.Delay(TimeSpan.FromSeconds(2));

    if (context.RequestAborted.IsCancellationRequested)
    {
        var timeoutFeature = context.Features.Get<IHttpRequestTimeoutFeature>();
        timeoutFeature?.DisableTimeout();
    }

    return Results.Content("No timeout!", "text/plain");
});
// </canceltimeout>

app.Run();
#endif

