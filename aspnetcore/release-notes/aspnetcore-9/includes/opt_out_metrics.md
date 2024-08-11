<!-- 
[!INCLUDE[](~/release-notes/aspnetcore-9/includes/opt_out_metrics.md)]
-->
### Opt-out of HTTP metrics on certain endpoints and requests

.NET 9 adds the ability to opt-out of HTTP metrics and not record a value for certain endpoints and requests. It's common for apps to have endpoints that are frequently called by automated systems, such as a health checks endpoint. Recording information about those requests generally isn't useful.

HTTP requests to an endpoint can be excluded from metrics by adding metadata. Either:

* Add the [`[DisableHttpMetrics]`](https://source.dot.net/#Microsoft.AspNetCore.Http.Extensions/DisableHttpMetricsAttribute.cs,258cd11ebe5f2ee1) attribute to the Web API controller, SignalR hub or gRPC service.
* Call [DisableHttpMetrics](https://source.dot.net/#Microsoft.AspNetCore.Http.Extensions/HttpMetricsEndpointConventionBuilderExtensions.cs,7537104878c6f44a) when mapping endpoints in app startup:

:::code language="csharp" source="~/release-notes/aspnetcore-9/samples/Metrics/Program.cs" id="snippet_1" highlight="5":::

```cs
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHealthChecks();

var app = builder.Build();
app.MapHealthChecks("/healthz").DisableHttpMetrics();
app.Run();
```

The `MetricsDisabled` property has been added to `IHttpMetricsTagsFeature` for:

* Advanced scenarios where a request doesn't map to an endpoint.
* Dynamically opting-out of HTTP requests.

:::code language="csharp" source="~/release-notes/aspnetcore-9/samples/Metrics/Program.cs" id="snippet_2":::

```cs
// Middleware that conditionally opts-out HTTP requests.
app.Use(async (context, next) =>
{
    if (context.Request.Headers.ContainsKey("x-disable-metrics"))
    {
        context.Features.Get<IHttpMetricsTagsFeature>()?.MetricsDisabled = true;
    }

    await next(context);
});
```