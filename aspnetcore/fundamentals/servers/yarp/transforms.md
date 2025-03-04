---
uid: fundamentals/servers/yarp/transforms
title: YARP Request and Response Transforms
description: YARP Request and Response Transforms
author: samsp-msft
ms.author: samsp
ms.date: 2/6/2025
ms.topic: article
content_well_notification: AI-contribution
ai-usage: ai-assisted
---

# YARP Request and Response Transforms

## Introduction
When proxying a request it's common to modify parts of the request or response to adapt to the destination server's requirements or to flow additional data such as the client's original IP address. This process is implemented via Transforms. Types of transforms are defined globally for the application and then individual routes supply the parameters to enable and configure those transforms. The original request objects are not modified by these transforms, only the proxy requests.

Request and response body transforms are not provided by YARP but you can write middleware to do this.

## Defaults
The following transforms are enabled by default for all routes. They can be configured or disabled as shown later in this document.
- Host - Suppress the incoming request's Host header. The proxy request will default to the host name specified in the destination server address. See `RequestHeaderOriginalHost`<!--](-bad bookmark#requestheaderoriginalhost)--> below.
- X-Forwarded-For - Sets the client's IP address to the X-Forwarded-For header. See <!-- fix [X-Forwarded](#x-forwarded) --> `X-Forwarded` below.
- X-Forwarded-Proto - Sets the request's original scheme (http/https) to the X-Forwarded-Proto header. See <!-- fix [X-Forwarded](#x-forwarded) --> `X-Forwarded` below.
- X-Forwarded-Host - Sets the request's original Host to the X-Forwarded-Host header. See <!-- fix [X-Forwarded](#x-forwarded) --> `X-Forwarded` below.
- X-Forwarded-Prefix - Sets the request's original PathBase, if any, to the X-Forwarded-Prefix header. See <!-- fix [X-Forwarded](#x-forwarded) --> `X-Forwarded` below.

For example the following incoming request to `http://IncomingHost:5000/path`:
```
GET /path HTTP/1.1
Host: IncomingHost:5000
Accept: */*
header1: foo
```
would be transformed and proxied to the destination server `https://DestinationHost:6000/` as follows using these defaults:
```
GET /path HTTP/1.1
Host: DestinationHost:6000
Accept: */*
header1: foo
X-Forwarded-For: 5.5.5.5
X-Forwarded-Proto: http
X-Forwarded-Host: IncomingHost:5000
```

## Transform Categories

Transforms fall into a few categories: [Request](./transforms-request.md), [Response](./transforms-response.md), and [Response Trailers](./transforms-response.md#responsetrailer).  Request trailers are not supported because they are not supported by the underlying HttpClient.

If the built-in set of transforms is insufficient, then custom transforms can be added via [extensibility](./extensibility-transforms.md).

## Adding transforms

Transforms can be added to routes either through configuration or programmatically.

### From Configuration

Transforms can be configured on [RouteConfig.Transforms](xref:Yarp.ReverseProxy.Configuration.RouteConfig) and can be bound from the `Routes` sections of the config file. These can be modified and reloaded without restarting the proxy. A transform is configured using one or more key-value string pairs.

Here is an example of common transforms:
```JSON
{
  "ReverseProxy": {
    "Routes": {
      "route1" : {
        "ClusterId": "cluster1",
        "Match": {
          "Hosts": [ "localhost" ]
        },
        "Transforms": [
          { "PathPrefix": "/apis" },
          {
            "RequestHeader": "header1",
            "Append": "bar"
          },
          {
            "ResponseHeader": "header2",
            "Append": "bar",
            "When": "Always"
          },
          { "ClientCert": "X-Client-Cert" },
          { "RequestHeadersCopy": "true" },
          { "RequestHeaderOriginalHost": "true" },
          {
            "X-Forwarded": "Append",
            "HeaderPrefix": "X-Forwarded-"
          }
        ]
      },
      "route2" : {
        "ClusterId": "cluster1",
        "Match": {
          "Path": "/api/{plugin}/stuff/{**remainder}"
        },
        "Transforms": [
          { "PathPattern": "/foo/{plugin}/bar/{**remainder}" },
          {
            "QueryValueParameter": "q",
            "Append": "plugin"
          }
        ]
      }
    },
    "Clusters": {
      "cluster1": {
        "Destinations": {
          "cluster1/destination1": {
            "Address": "https://localhost:10001/Path/Base"
          }
        }
      }
    }
  }
}
```

All configuration entries are treated as case-insensitive, though the destination server may treat the resulting values as case sensitive or insensitive such as the path.

The details for these transforms are covered later in this document.

Developers that want to integrate their custom transforms with the `Transforms` section of configuration can do so using `ITransformFactory`<!--](#itransformfactory)--> described below.

### From Code

Transforms can be added to routes programmatically by calling the [AddTransforms](xref:Microsoft.Extensions.DependencyInjection.ReverseProxyServiceCollectionExtensions.AddTransforms*) method.

`AddTransforms` can be called after `AddReverseProxy` to provide a callback for configuring transforms. This callback is invoked each time a route is built or rebuilt and allows the developer to inspect the [RouteConfig](xref:Yarp.ReverseProxy.Configuration.RouteConfig) information and conditionally add transforms for it.

The `AddTransforms` callback provides a [TransformBuilderContext](xref:Yarp.ReverseProxy.Transforms.Builder.TransformBuilderContext) where transforms can be added or configured. Most transforms provide `TransformBuilderContext` extension methods to make them easier to add. These are extensions documented below with the individual transform descriptions.

The `TransformBuilderContext` also includes an `IServiceProvider` for access to any needed services.

```C#
services.AddReverseProxy()
    .LoadFromConfig(_configuration.GetSection("ReverseProxy"))
    .AddTransforms(builderContext =>
    {
        // Added to all routes.
        builderContext.AddPathPrefix("/prefix");

        // Conditionally add a transform for routes that require auth.
        if (!string.IsNullOrEmpty(builderContext.Route.AuthorizationPolicy))
        {
            builderContext.AddRequestTransform(async transformContext =>
            {
                transformContext.ProxyRequest.Headers.Add("CustomHeader", "CustomValue");
            });
        }
    });
```

For more advanced control see `ITransformProvider`<!-- fix #x-forwarded#itransformprovider) --> described below.
