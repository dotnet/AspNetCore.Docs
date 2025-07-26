---
uid: fundamentals/servers/yarp/timeouts
title: YARP Request Timeouts
description: YARP Request Timeouts
author: wadepickett
ms.author: wpickett
ms.date: 2/6/2025
ms.topic: article
content_well_notification: AI-contribution
ai-usage: ai-assisted
---

# YARP Request Timeouts

## Introduction

.NET 8 introduced the [Request Timeouts Middleware](/aspnet/core/performance/timeouts) to enable configuring request timeouts globally as well as per endpoint. This functionality is also available in YARP 2.1 when running on .NET 8 or newer.

## Defaults
Requests do not have any timeouts by default, other than the [Activity Timeout](xref:fundamentals/servers/yarp/http-client-config#HttpRequest) used to clean up idle requests. A default policy specified in [RequestTimeoutOptions](/dotnet/api/microsoft.aspnetcore.http.timeouts.requesttimeoutoptions) will apply to proxied requests as well.

## Configuration
Timeouts and Timeout Policies can be specified per route via [RouteConfig](xref:Yarp.ReverseProxy.Configuration.RouteConfig) and can be bound from the `Routes` sections of the config file. As with other route properties, this can be modified and reloaded without restarting the proxy. Policy names are case insensitive.

Timeouts are specified in a TimeSpan format (HH:MM:SS). Specifying both a Timeout and a TimeoutPolicy on the same route is invalid and will cause the configuration to be rejected.

Note that request timeouts do not apply when a debugger is attached to the process.

Example:
```json
{
  "ReverseProxy": {
    "Routes": {
      "route1" : {
        "ClusterId": "cluster1",
        "TimeoutPolicy": "customPolicy",
        "Match": {
          "Hosts": [ "localhost" ]
        }
      }
      "route2" : {
        "ClusterId": "cluster1",
        "Timeout": "00:01:00",
        "Match": {
          "Hosts": [ "localhost2" ]
        }
      }
    },
    "Clusters": {
      "cluster1": {
        "Destinations": {
          "cluster1/destination1": {
            "Address": "https://localhost:10001/"
          }
        }
      }
    }
  }
}
```

Timeout policies and the default policy can be configured in the service collection and the middleware can be added as follows:
```csharp
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddRequestTimeouts(options =>
{
    options.AddPolicy("customPolicy", TimeSpan.FromSeconds(20));
});

var app = builder.Build();

app.UseRequestTimeouts();

app.MapReverseProxy();

app.Run();
```

### Disable timeouts

Specifying the value `disable` in a route's `TimeoutPolicy` parameter means the request timeout middleware will not apply timeouts to this route.

### WebSockets

Request timeouts are disabled after the initial WebSocket handshake.
