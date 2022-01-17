---
title: gRPC health checks in ASP.NET Core
author: jamesnk
description: Learn how to use gRPC health checks in ASP.NET Core.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 01/16/2022
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: grpc/health-checks
---
# gRPC health checks in ASP.NET Core

By [James Newton-King](https://twitter.com/jamesnk)

The [gRPC health checking protocol](https://github.com/grpc/grpc/blob/master/doc/health-checking.md) is a standard for reporting the health of gRPC server apps.

Health checks are exposed by an app as a gRPC service and are typically used with an external monitoring service to check the status of an app. The health checks service can be configured for various real-time monitoring scenarios:

* Health probes can be used by container orchestrators and load balancers to check an app's status. For example, a container orchestrator may respond to a failing health check by halting a rolling deployment or restarting a container. A load balancer might react to an unhealthy app by routing traffic away from the failing instance to a healthy instance.
* Use of memory, disk, and other physical server resources can be monitored for healthy status.
* Health checks can test an app's dependencies, such as databases and external service endpoints, to confirm availability and normal functioning.

## Set up gRPC health checks

gRPC ASP.NET Core has built-in support for gRPC health checks with the [`Grpc.AspNetCore.HealthChecks`](https://www.nuget.org/packages/Grpc.AspNetCore.HealthChecks) package. Results from [.NET health checks](xref:host-and-deploy/health-checks) are reported to service callers. To set up gRPC health checks in an app:

* Add a `Grpc.AspNetCore.HealthChecks` package reference.
* Register health checks in `Startup.cs`:
  * `AddGrpcHealthChecks` to register services that enable health checks.
  * `MapGrpcHealthChecksService` to add a health checks service endpoint.

[!code-csharp[](~/grpc/health-checks/Startup.cs?name=snippet_1&highlight=4,14)]

When health checks is set up:

* The health checks service is added to the server app.
* .NET health checks registered with the app are periodically executed for health results. gRPC health checks reports based on health results:
  * `Unknown` reported when there are no health results.
  * `NotServing` reported when there are any health results of `HealthStatus.Unhealthy`.
  * Otherwise, `Serving` is reported.
* Client apps that support gRPC health checks can call the service to monitor server health.

## Configure `Grpc.AspNetCore.HealthChecks`

By default, the gRPC health checks service uses all registered health checks to determine health status. To run a subset of health checks, configure gRPC health checks when registering services. The  `MapService` is used to map health results to service names. `MapService` has an argument for filtering health results with a predicate:

```csharp
services.AddGrpcHealthChecks(o =>
{
    o.Services.MapService("", r => r.Tags.Contains("public"));
});
```

The preceding code overrides the default service (`""`) to only use health results with the "public" tag.

gRPC health checks supports the client specifying a service name argument when checking health. Multiple services are supported by providing a service name to `MapService`:

```csharp
services.AddGrpcHealthChecks(o =>
{
    o.Services.MapService("", r => r.Tags.Contains("public"));
    o.Services.MapService("greet.Greeter", r => r.Tags.Contains("public") && r.Tags.Contains("greeter"));
    o.Services.MapService("count.Counter", r => r.Tags.Contains("public") && r.Tags.Contains("counter"));
});
```

The service name is usually the package qualified name of services in your app. However, there is nothing that prevents using arbitrary values to check app health.

## Call gRPC health checks service

The [`Grpc.HealthCheck`](https://www.nuget.org/packages/Grpc.HealthCheck) package includes a client for gRPC health checks.

```csharp
var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new Health.HealthClient(channel);

var response = client.CheckAsync(new HealthCheckRequest());
var status = response.Status;
```

## Additional resources

* <xref:host-and-deploy/health-checks>
* [gRPC health checking protocol](https://github.com/grpc/grpc/blob/master/doc/health-checking.md)
* [`Grpc.AspNetCore.HealthChecks`](https://www.nuget.org/packages/Grpc.AspNetCore.HealthChecks)
* [`Grpc.HealthCheck`](https://www.nuget.org/packages/Grpc.HealthCheck)
