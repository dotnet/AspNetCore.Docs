---
uid: fundamentals/servers/yarp/httpsys-delegation
title: YARP HTTP.sys Delegation
description: YARP HTTP.sys Delegation
author: wpickett
ms.author: wadepickett
ms.date: 04/03/2025
ms.topic: article
content_well_notification: AI-contribution
ai-usage: ai-assisted
---
# YARP HTTP.sys Delegation

## Introduction

HTTP.sys delegation is a kernel level feature added into newer versions of Windows which allows a request to be transferred from the receiving process's HTTP.sys queue to a target process's HTTP.sys queue with very little overhead or added latency. For this delegation to work, the receiving process is only allowed to read the request headers. If the body has started to be read or a response has started, trying to delegate the request will fail. The response will not be visible to the proxy after delegation, which limits the functionality of the session affinity and passive health checks components, as well as some of the load balancing algorithms. Internally, YARP leverages ASP.NET Core's [IHttpSysRequestDelegationFeature](/dotnet/api/microsoft.aspnetcore.server.httpsys.ihttpsysrequestdelegationfeature) 

## Requirements

HTTP.sys delegation requires:

* [ASP.NET Core's HTTP.sys server](/aspnet/core/fundamentals/servers/httpsys)
* Windows Server 2019 or Windows 10 (build number 1809) or newer.

## Defaults

HTTP.sys delegation won't be used unless added to the proxy pipeline and enabled in the destination configuration. 

## Configuration

HTTP.sys delegation can be enabled per destination by adding the `HttpSysDelegationQueue` metadata to the destination. The value of this metadata should be the target HTTP.sys queue name. The destination's Address is used to specify the url prefix of the HTTP.sys queue.

```json
{
  "ReverseProxy": {
    "Routes": {
      "route1" : {
        "ClusterId": "cluster1",
        "Match": {
          "Path": "{**catch-all}"
        }
      }
    },
    "Clusters": {
      "cluster1": {
        "Destinations": {
          "cluster1/destination1": {
            "Address": "http://*:80/",
            "Metadata": {
              "HttpSysDelegationQueue": "TargetHttpSysQueueName"
            }
          }
        }
      }
    }
  }
}
```

In host configuration, configure the host to use the HTTP.sys server:

```csharp
webBuilder.UseHttpSys();
```

In application configuration, use the `MapReverseProxy` overload that allows you to customize the pipeline and add HTTP.sys delegation by calling `UseHttpSysDelegation`:

```csharp
app.MapReverseProxy(proxyPipeline =>
{
    // Add the three middleware YARP adds by default plus the HTTP.sys
    // delegation middleware
    proxyPipeline.UseSessionAffinity(); // No affect on delegation destinations
    proxyPipeline.UseLoadBalancing();
    proxyPipeline.UsePassiveHealthChecks();
    proxyPipeline.UseHttpSysDelegation();
});
```

## Delegation queue lifetime

When YARP is configured to use delegation for a destination, a handle is created to the specified HTTP.sys queue. This handle is kept alive as long as the destinations referencing it exist. Clean up of these handles is done during GC, so it's possible cleanup of the handle is delayed if it ends up in Gen2. This may cause issues for some receivers during process restart because if they try to create the queue during startup it fails because it still exists since YARP has a handle to it. The receivers must be smart enough to attach instead and properly re-setup the queue. ASP.NET Core's HTTP.sys server has this issue. For more information, see [Http.sys server should support setting up URL groups when attaching to an existing queue (`dotnet/aspnetcore` #40359)](https://github.com/dotnet/aspnetcore/issues/40359).

YARP exposes a way to reset its handle to the queue. This allows consumers to write custom logic to determine when the handle to the queue should be cleaned up.

Example:

```csharp
var delegator = app.Services.GetRequiredService<IHttpSysDelegator>();
delegator.ResetQueue("TargetHttpSysQueueName", "http://*:80");
```
