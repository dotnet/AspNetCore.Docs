# Middleware

## Introduction

ASP.NET Core uses a [middleware pipeline](https://docs.microsoft.com/aspnet/core/fundamentals/middleware/) to divide request processing into discrete steps. The app developer can add and order middleware as needed. ASP.NET Core middleware is also used to implement and customize reverse proxy functionality.

## Defaults
The [getting started](getting-started.md) sample shows the following Configure method. This sets up a middleware pipeline with development tools, routing, and proxy configured endpoints (`MapReverseProxy`).

```C#
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));
var app = builder.Build();
app.MapReverseProxy();
app.Run();
```

The parmeterless `MapReverseProxy()` in [ReverseProxyIEndpointRouteBuilderExtensions](xref:Microsoft.AspNetCore.Builder.ReverseProxyIEndpointRouteBuilderExtensions) overload includes all standard proxy middleware for [session affinity](session-affinity.md), [load balancing](load-balancing.md), [passive health checks](dests-health-checks.md#passive-health-checks), and the final proxying of the request. Each of these check the configuration of the matched route, cluster, and destination and perform their task accordingly.

## Adding Middleware

Middleware added to your application pipeline will see the request in different states of processing depending on where the middleware is added. Middleware added before `UseRouting` will see all requests and can manipulate them before any routing takes place. Middleware added between `UseRouting` and `UseEndpoints` can call `HttpContext.GetEndpoint()` to check which endpoint routing matched the request to (if any), and use any metadata that was associated with that endpoint. This is how [Authentication, Authorization](authn-authz.md) and [CORS](cors.md) are handled.

[ReverseProxyIEndpointRouteBuilderExtensions](xref:Microsoft.AspNetCore.Builder.ReverseProxyIEndpointRouteBuilderExtensions) provides an overload of `MapReverseProxy` that lets you build a middleware pipeline that will run only for requests matched to proxy configured routes.

```
app.MapReverseProxy(proxyPipeline =>
{
    proxyPipeline.Use((context, next) =>
    {
        // Custom inline middleware

        return next();
    });
    proxyPipeline.UseSessionAffinity();
    proxyPipeline.UseLoadBalancing();
    proxyPipeline.UsePassiveHealthChecks();
});
```

By default this overload of `MapReverseProxy` only includes the minimal setup, proxying logic, and limit enforcement at the start and end of its pipeline. Middleware for session affinity, load balancing, and passive health checks are not included by default so that you can exclude, replace, or control their ordering with any additional middleware.

## Custom Proxy Middleware

Middleware inside the `MapReverseProxy` pipeline have access to all of the proxy data and state associated with a request (the route, cluster, destinations, etc.) through the [IReverseProxyFeature](xref:Yarp.ReverseProxy.Model.IReverseProxyFeature). This is available from `HttpContext.Features` or the extension method `HttpContext.GetReverseProxyFeature()`.

The data in `IReverseProxyFeature` are snapshotted from the proxy configuration at the start of the proxy pipeline and will not be affected by proxy configuration changes that occur while the request is being processed.

```C#
proxyPipeline.Use((context, next) =>
{
    var proxyFeature = context.GetReverseProxyFeature();
    var cluster = proxyFeature.Cluster;
    var destinations = proxyFeature.AvailableDestinations;

    return next();
});
```

## What to do with middleware

Middleware can generate logs, control if a request gets proxied or not, influence where it's proxied to, and add additional features like error handling, retries, etc..

### Logs and Metrics

Middleware can inspect request and response fields to generate logs and aggregate metrics. See the note about bodies under "What not to do with middleware" below.

```C#
proxyPipeline.Use(async (context, next) =>
{
    LogRequest(context);
    await next();
    LogResponse(context);
});
```

### Send an immediate response

If a middleware inspects a request and determines that it should not be proxied, it may generate its own response and return control to the server without calling `next()`.

```C#
proxyPipeline.Use((context, next) =>
{
    if (!CheckAllowedRequest(context, out var reason))
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        return context.Response.WriteAsync(reason);
    }

    return next();
});
```

### Filter destinations

Middleware like session affinity and load balancing examine the `IReverseProxyFeature` and the cluster configuration to decide which destination a request should be sent to.

`AllDestinations` lists all destinations in the selected cluster.

`AvailableDestinations` lists the destinations currently considered eligible to handle the request. It is initialized to `AllDestinations`, excluding unhealthy ones if health checks are enabled. `AvailableDestinations` should be reduced to a single destination by the end of the pipeline or else one will be selected randomly from the remainder.

`ProxiedDestination` is set by the proxy logic at the end of the pipeline to indicate which destination was ultimately used.  If there are no available destinations remaining then a 503 error response is sent.

```C#
proxyPipeline.Use(async (context, next) =>
{
    var proxyFeature = context.GetReverseProxyFeature();
    proxyFeature.AvailableDestinations = Filter(proxyFeature.AvailableDestinations);

    await next();

    Report(proxyFeature.ProxiedDestination);
});
```

`DestinationState` implements `IReadOnlyList<DestinationState>` so a single destination can be assigned to `AvailableDestinations` without creating a new list.

### Error handling

Middleware can wrap the call to `await next()` in a try/catch block to handle exceptions from later components.

The proxy logic at the end of the pipeline ([IHttpForwarder](direct-forwarding.md)) does not throw exceptions for common request proxy errors. These are captured and reported in the [IForwarderErrorFeature](xref:Yarp.ReverseProxy.Forwarder.IForwarderErrorFeature) available from `HttpContext.Features` or the `HttpContext.GetForwarderErrorFeature()` extension method.

```C#
proxyPipeline.Use(async (context, next) =>
{
    await next();

    var errorFeature = context.GetForwarderErrorFeature();
    if (errorFeature is not null)
    {
        Report(errorFeature.Error, errorFeature.Exception);
    }
});
```

If the response has not started (`HttpResponse.HasStarted`) it can be cleared (`HttpResponse.Clear()`) and an alternate response sent, or the proxy feature fields may be reset and the request retried.

## What not to do with middleware

Middleware should be cautious about modifying request fields such as headers in order to affect the outgoing proxied request. Such modifications may interfere with features like retries and may be better handled by [transforms](transforms.md).

Middleware MUST check `HttpResponse.HasStarted` before modifying response fields after calling `next()`. If the response has already started being sent to the client then the middleware can no longer modify it (except maybe Trailers). [Transforms](transforms.md) can be used to inspect and suppress unwanted responses. Otherwise see the next note.

Middleware should avoid interacting with the request or response bodies. Bodies are not buffered by default, so interacting with them can prevent them from reaching their destinations. While enabling buffering is possible, it's discouraged as it can add significant memory and latency overhead. Using a wrapped, streaming approach is recommended if the body must be examined or modified. See the [ResponseCompression](https://github.com/dotnet/aspnetcore/blob/24588220006bc164b63293129cc94ac6292250e4/src/Middleware/ResponseCompression/src/ResponseCompressionMiddleware.cs#L55-L73) middleware for an example.

Middleware MUST NOT do any multi-threaded work on an individual request, `HttpContext` and its associated members are not thread safe.
