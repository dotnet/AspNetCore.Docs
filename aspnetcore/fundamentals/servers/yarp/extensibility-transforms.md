---
uid: fundamentals/servers/yarp/transform-extensibility
title: YARP Extensibility - Request and Response Transforms
description: YARP Extensibility - Request and Response Transforms
author: tdykstra
ms.author: tdykstra
ms.date: 2/14/2025
ms.topic: concept-article
content_well_notification: AI-contribution
ai-usage: ai-assisted
---
# Request and Response Transform Extensibility

## Introduction

When proxying a request it's common to modify parts of the request or response to adapt to the destination server's requirements or to flow additional data such as the client's original IP address. This process is implemented via Transforms. Types of transforms are defined globally for the application and then individual routes supply the parameters to enable and configure those transforms. The original request objects are not modified by these transforms, only the proxy requests.

YARP includes a set of built-in request and response transforms that can be used. For more information, see <xref:fundamentals/servers/yarp/transforms>. If those transforms are not sufficient, then custom transforms can be added.

## `RequestTransform`

All request transforms must derive from the abstract base class [`RequestTransform`](xref:fundamentals/servers/yarp/transforms). These can freely modify the proxy `HttpRequestMessage`. Avoid reading or modifying the request body as this may disrupt the proxying flow. Consider also adding a parametrized extension method on `TransformBuilderContext` for discoverability and ease of use.

A request transform may conditionally produce an immediate response such as for error conditions. This prevents any remaining transforms from running and the request from being proxied. This is indicated by setting the `HttpResponse.StatusCode` to a value other than 200, or calling `HttpResponse.StartAsync()`, or writing to the `HttpResponse.Body` or `BodyWriter`.

<xref:Yarp.ReverseProxy.Transforms.TransformBuilderContextFuncExtensions.AddRequestTransform%2A> is a `TransformBuilderContext` extension method that defines a request transform as a `Func<RequestTransformContext, ValueTask>`. This allows creating a custom request transform without implementing a `RequestTransform` derived class.

## `ResponseTransform`

All response transforms must derive from the abstract base class <xref:Yarp.ReverseProxy.Transforms.ResponseTransform>. These can freely modify the client `HttpResponse`. Avoid reading or modifying the response body as this may disrupt the proxying flow. Consider also adding a parametrized extension method on `TransformBuilderContext` for discoverability and easy of use.

<xref:Yarp.ReverseProxy.Transforms.TransformBuilderContextFuncExtensions.AddResponseTransform%2A> is a `TransformBuilderContext` extension method that defines a response transform as a `Func<ResponseTransformContext, ValueTask>`. This allows creating a custom response transform without implementing a `ResponseTransform` derived class.

## `ResponseTrailersTransform`

All response trailers transforms must derive from the abstract base class <xref:Yarp.ReverseProxy.Transforms.ResponseTrailersTransform>. These can freely modify the client HttpResponse trailers. These run after the response body and should not attempt to modify the response headers or body. Consider also adding a parametrized extension method on `TransformBuilderContext` for discoverability and easy of use.

<xref:Yarp.ReverseProxy.Transforms.TransformBuilderContextFuncExtensions.AddResponseTrailersTransform%2A> is a `TransformBuilderContext` extension method that defines a response trailers transform as a `Func<ResponseTrailersTransformContext, ValueTask>`. This allows creating a custom response trailers transform without implementing a `ResponseTrailersTransform` derived class.

## Request body transforms

YARP does not provide any built in transforms for modifying the request body. However, the body can be modified by custom transforms.

Be careful about which kinds of requests are modified, how much data gets buffered, enforcing timeouts, parsing untrusted input, and updating the body-related headers like `Content-Length`.

The below example uses simple, inefficient buffering to transform requests. A more efficient implementation would wrap and replace `HttpContext.Request.Body` with a stream that performed the needed modifications as data was proxied from client to server. That would also require removing the Content-Length header since the final length would not be known in advance.

This sample requires YARP 1.1, see https://github.com/microsoft/reverse-proxy/pull/1569.

```csharp
.AddTransforms(context =>
{
    context.AddRequestTransform(async requestContext =>
    {
        using var reader =
            new StreamReader(requestContext.HttpContext.Request.Body);
        // TODO: size limits, timeouts
        var body = await reader.ReadToEndAsync();
        if (!string.IsNullOrEmpty(body))
        {
            body = body.Replace("Alpha", "Charlie");
            var bytes = Encoding.UTF8.GetBytes(body);
            // Change Content-Length to match the modified body, or remove it
            requestContext.HttpContext.Request.Body = new MemoryStream(bytes);
            // Request headers are copied before transforms are invoked, update any
            // needed headers on the ProxyRequest
            requestContext.ProxyRequest.Content.Headers.ContentLength =
                bytes.Length;
        }
    });
});
```

Custom transforms can only modify a request body if one is already present. They can't add a new body to a request that doesn't have one (for example, a POST request without a body or a GET request). If you need to add a body for a specific HTTP method and route, you must do so in [middleware](xref:fundamentals/middleware/index) that runs before YARP, not in a transform.

The following middleware demonstrates how to add a body to a request that doesn't have one:

```csharp
public class AddRequestBodyMiddleware
{
    private readonly RequestDelegate _next;

    public AddRequestBodyMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Only modify specific route and method
        if (context.Request.Method == HttpMethods.Get &&
            context.Request.Path == "/special-route")
        {
            var bodyContent = "key=value";
            var bodyBytes = Encoding.UTF8.GetBytes(bodyContent);

            // Create a new request body
            context.Request.Body = new MemoryStream(bodyBytes);
            context.Request.ContentLength = bodyBytes.Length;

            // Replace IHttpRequestBodyDetectionFeature so YARP knows
            // a body is present
            context.Features.Set<IHttpRequestBodyDetectionFeature>(
                new CustomBodyDetectionFeature());
        }

        await _next(context);
    }

    // Helper class to indicate the request can have a body
    private class CustomBodyDetectionFeature : IHttpRequestBodyDetectionFeature
    {
        public bool CanHaveBody => true;
    }
}
```

> [!NOTE] 
> You can use `context.GetRouteModel().Config.RouteId` in middleware to conditionally apply this logic for specific YARP routes.

## Response body transforms

YARP does not provide any built in transforms for modifying the response body. However, the body can be modified by custom transforms.

Be careful about which kinds of responses are modified, how much data gets buffered, enforcing timeouts, parsing untrusted input, and updating the body-related headers like `Content-Length`. You may need to decompress content before modifying it, as indicated by the Content-Encoding header, and afterwards re-compress it or remove the header.

The below example uses simple, inefficient buffering to transform responses. A more efficient implementation would wrap the stream returned by `ReadAsStreamAsync()` with a stream that performed the needed modifications as data was proxied from client to server. That would also require removing the Content-Length header since the final length would not be known in advance.

```csharp
.AddTransforms(context =>
{
    context.AddResponseTransform(async responseContext =>
    {
        var stream =
            await responseContext.ProxyResponse.Content.ReadAsStreamAsync();
        using var reader = new StreamReader(stream);
        // TODO: size limits, timeouts
        var body = await reader.ReadToEndAsync();

        if (!string.IsNullOrEmpty(body))
        {
            responseContext.SuppressResponseBody = true;

            body = body.Replace("Bravo", "Charlie");
            var bytes = Encoding.UTF8.GetBytes(body);
            // Change Content-Length to match the modified body, or remove it
            responseContext.HttpContext.Response.ContentLength = bytes.Length;
            // Response headers are copied before transforms are invoked, update
            // any needed headers on the HttpContext.Response
            await responseContext.HttpContext.Response.Body.WriteAsync(bytes);
        }
    });
});
```

## `ITransformProvider`

<xref:Yarp.ReverseProxy.Transforms.Builder.ITransformProvider> provides the functionality of `AddTransforms` described above as well as DI integration and validation support.

`ITransformProvider`'s can be registered in DI by calling <xref:Microsoft.Extensions.DependencyInjection.ReverseProxyServiceCollectionExtensions.AddTransforms%2A>. Multiple `ITransformProvider` implementations can be registered and all will be run.

`ITransformProvider` has two methods, `Validate` and `Apply`. `Validate` gives you the opportunity to inspect the route for any parameters that are needed to configure a transform, such as custom metadata, and to return validation errors on the context if any needed values are missing or invalid. The `Apply` method provides the same functionality as AddTransform as discussed above, adding and configuring transforms per route.

```csharp
services.AddReverseProxy()
    .LoadFromConfig(_configuration.GetSection("ReverseProxy"))
    .AddTransforms<MyTransformProvider>();
```

```csharp
internal class MyTransformProvider : ITransformProvider
{
    public void ValidateRoute(TransformRouteValidationContext context)
    {
        // Check all routes for a custom property and validate the associated
        // transform data
        if (context.Route.Metadata?.TryGetValue("CustomMetadata", out var value) ??
            false)
        {
            if (string.IsNullOrEmpty(value))
            {
                context.Errors.Add(new ArgumentException(
                    "A non-empty CustomMetadata value is required"));
            }
        }
    }

    public void ValidateCluster(TransformClusterValidationContext context)
    {
        // Check all clusters for a custom property and validate the associated
        // transform data.
        if (context.Cluster.Metadata?.TryGetValue("CustomMetadata", out var value)
            ?? false)
        {
            if (string.IsNullOrEmpty(value))
            {
                context.Errors.Add(new ArgumentException(
                    "A non-empty CustomMetadata value is required"));
            }
        }
    }

    public void Apply(TransformBuilderContext transformBuildContext)
    {
        // Check all routes for a custom property and add the associated transform.
        if ((transformBuildContext.Route.Metadata?.TryGetValue("CustomMetadata",
            out var value) ?? false)
            || (transformBuildContext.Cluster?.Metadata?.TryGetValue(
            "CustomMetadata", out value) ?? false))
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(
                    "A non-empty CustomMetadata value is required");
            }

            transformBuildContext.AddRequestTransform(transformContext =>
            {
                transformContext.ProxyRequest.Options.Set(
                    new HttpRequestOptionsKey<string>("CustomMetadata"), value);

                return default;
            });
        }
    }
}
```

## `ITransformFactory`

Developers that want to integrate their custom transforms with the `Transforms` section of configuration can implement an <xref:Yarp.ReverseProxy.Transforms.Builder.ITransformFactory>. This should be registered in DI using the `AddTransformFactory<T>()` method. Multiple factories can be registered and all will be used.

`ITransformFactory` provides two methods, `Validate` and `Build`. These process one set of transform values at a time, represented by a `IReadOnlyDictionary<string, string>`.

The `Validate` method is called when loading a configuration to verify the contents and report all errors. Any reported errors will prevent the configuration from being applied.

The `Build` method takes the given configuration and produces the associated transform instances for the route.

```csharp
services.AddReverseProxy()
    .LoadFromConfig(_configuration.GetSection("ReverseProxy"))
    .AddTransformFactory<MyTransformFactory>();
```

```csharp
internal class MyTransformFactory : ITransformFactory
{
    public bool Validate(TransformRouteValidationContext context,
        IReadOnlyDictionary<string, string> transformValues)
    {
        if (transformValues.TryGetValue("CustomTransform", out var value))
        {
            if (string.IsNullOrEmpty(value))
            {
                context.Errors.Add(new ArgumentException(
                    "A non-empty CustomTransform value is required"));
            }

            return true; // Matched
        }

        return false;
    }

    public bool Build(TransformBuilderContext context,
        IReadOnlyDictionary<string, string> transformValues)
    {
        if (transformValues.TryGetValue("CustomTransform", out var value))
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException(
                    "A non-empty CustomTransform value is required");
            }

            context.AddRequestTransform(transformContext =>
            {
                transformContext.ProxyRequest.Options.Set(
                    new HttpRequestOptionsKey<string>("CustomTransform"), value);
                return default;
            });

            return true;
        }

        return false;
    }
}
```

`Validate` and `Build` return `true` if they've identified the given transform configuration as one that they own. A `ITransformFactory` may implement multiple transforms. Any `RouteConfig.Transforms` entries not handled by any `ITransformFactory` will be considered configuration errors and prevent the configuration from being applied.

Consider also adding parametrized extension methods on `RouteConfig` like `WithTransformQueryValue` to facilitate programmatic route construction.

```csharp
public static RouteConfig WithTransformQueryValue(this RouteConfig routeConfig,
    string queryKey, string value, bool append = true)
{
    var type = append ? QueryTransformFactory.AppendKey :
        QueryTransformFactory.SetKey;
    return routeConfig.WithTransform(transform =>
    {
        transform[QueryTransformFactory.QueryValueParameterKey] = queryKey;
        transform[type] = value;
    });
}
```
