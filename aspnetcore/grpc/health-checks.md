---
title: gRPC health checks in ASP.NET Core
author: jamesnk
description: Learn how to use gRPC health checks in ASP.NET Core.
monikerRange: '>= aspnetcore-3.1'
ms.author: jamesnk
ms.date: 01/16/2022
uid: grpc/health-checks
---
# gRPC health checks in ASP.NET Core

:::moniker range=">= aspnetcore-6.0"

By [James Newton-King](https://twitter.com/jamesnk)

The [gRPC health checking protocol](https://github.com/grpc/grpc/blob/master/doc/health-checking.md) is a standard for reporting the health of gRPC server apps.

Health checks are exposed by an app as a gRPC service. They are typically used with an external monitoring service to check the status of an app. The service can be configured for various real-time monitoring scenarios:

* Health probes can be used by container orchestrators and load balancers to check an app's status. For example, Kubernetes supports [gRPC liveness, readiness and startup probes](https://kubernetes.io/docs/tasks/configure-pod-container/configure-liveness-readiness-startup-probes/#define-a-grpc-liveness-probe). Kubernetes can be configured to reroute traffic or restart unhealthy containers based on gRPC health check results.
* Use of memory, disk, and other physical server resources can be monitored for healthy status.
* Health checks can test an app's dependencies, such as databases and external service endpoints, to confirm availability and normal functioning.

## Set up gRPC health checks

gRPC ASP.NET Core has built-in support for gRPC health checks with the [`Grpc.AspNetCore.HealthChecks`](https://www.nuget.org/packages/Grpc.AspNetCore.HealthChecks) package. Results from [.NET health checks](xref:host-and-deploy/health-checks) are reported to callers.

To set up gRPC health checks in an app:

* Add a `Grpc.AspNetCore.HealthChecks` package reference.
* Register gRPC health checks service:
  * `AddGrpcHealthChecks` to register services that enable health checks.
  * `MapGrpcHealthChecksService` to add a health checks service endpoint.
* Add health checks by implementing <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck> or using the <xref:Microsoft.Extensions.DependencyInjection.HealthChecksBuilderAddCheckExtensions.AddCheck%2A> method.

[!code-csharp[](~/grpc/health-checks/samples-6/GrpcServiceHC/Program.cs?name=snippet&highlight=2,7-8,13)]

When health checks is set up:

* The health checks service is added to the server app.
* .NET health checks registered with the app are periodically executed for health results. By default, there is a 5 second delay after app startup, and then health checks are executed every 30 seconds. Health check execution interval [can be customized with `HealthCheckPublisherOptions`](#configure-health-checks-execution-interval).
* Health results determine what the gRPC service reports:
  * `Unknown` is reported when there are no health results.
  * `NotServing` is reported when there are any health results of <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy?displayProperty=nameWithType>.
  * Otherwise, `Serving` is reported.

### Configure `Grpc.AspNetCore.HealthChecks`

By default, the gRPC health checks service uses all registered health checks to determine health status. gRPC health checks can be customized when registered to use a subset of health checks. The `MapService` method is used to map health results to service names, along with a predicate for filtering health results:

[!code-csharp[](~/grpc/health-checks/samples-6/GrpcServiceHC/Program.cs?name=snippet2&highlight=4-7)]

The preceding code overrides the default service (`""`) to only use health results with the "public" tag.

gRPC health checks supports the client specifying a service name argument when checking health. Multiple services are supported by providing a service name to `MapService`:

[!code-csharp[](~/grpc/health-checks/samples-6/GrpcServiceHC/Program.cs?name=snippet3&highlight=4-8)]

The service name specified by the client is usually the default (`""`) or a package-qualified name of a service in your app. However, nothing prevents the client using arbitrary values to check app health.

### Configure health checks execution interval

Health checks are run immediately when `Check` is called. `Watch` is a streaming method and has a different behavior than `Check`: The long running stream reports health checks results over time by periodically executing <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> to gather health results. By default, the publisher:

* Waits 5 seconds after app startup before running health checks.
* Runs health checks every 30 seconds.

Publisher intervals can be configured using <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckPublisherOptions> at startup:

```csharp
builder.Services.Configure<HealthCheckPublisherOptions>(options =>
{
    options.Delay = TimeSpan.Zero;
    options.Period = TimeSpan.FromSeconds(10);
});
```

## Call gRPC health checks service

The [`Grpc.HealthCheck`](https://www.nuget.org/packages/Grpc.HealthCheck) package includes a client for gRPC health checks:

```csharp
var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new Health.HealthClient(channel);

var response = await client.CheckAsync(new HealthCheckRequest());
var status = response.Status;
```

There are two methods on the `Health` service:

* `Check` is a unary method for getting the current health status. Health checks are executed immediately when `Check` is called. The server returns a `NOT_FOUND` error response if the client requests an unknown service name. This can happen at app startup if health results haven't been published yet.
* `Watch` is a streaming method that reports changes in health status over time. <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> is periodically executed to gather health results. The server returns an `Unknown` status if the client requests an unknown service name.

## Additional resources

* <xref:host-and-deploy/health-checks>
* [gRPC health checking protocol](https://github.com/grpc/grpc/blob/master/doc/health-checking.md)
* [`Grpc.AspNetCore.HealthChecks`](https://www.nuget.org/packages/Grpc.AspNetCore.HealthChecks)
* [`Grpc.HealthCheck`](https://www.nuget.org/packages/Grpc.HealthCheck)

:::moniker-end

:::moniker range="< aspnetcore-6.0"

By [James Newton-King](https://twitter.com/jamesnk)

The [gRPC health checking protocol](https://github.com/grpc/grpc/blob/master/doc/health-checking.md) is a standard for reporting the health of gRPC server apps.

Health checks are exposed by an app as a gRPC service. They are typically used with an external monitoring service to check the status of an app. The service can be configured for various real-time monitoring scenarios:

* Health probes can be used by container orchestrators and load balancers to check an app's status. For example, Kubernetes supports [gRPC liveness, readiness and startup probes](https://kubernetes.io/docs/tasks/configure-pod-container/configure-liveness-readiness-startup-probes/#define-a-grpc-liveness-probe). Kubernetes can be configured to reroute traffic or restart unhealthy containers based on gRPC health check results.
* Use of memory, disk, and other physical server resources can be monitored for healthy status.
* Health checks can test an app's dependencies, such as databases and external service endpoints, to confirm availability and normal functioning.

## Set up gRPC health checks

gRPC ASP.NET Core has built-in support for gRPC health checks with the [`Grpc.AspNetCore.HealthChecks`](https://www.nuget.org/packages/Grpc.AspNetCore.HealthChecks) package. Results from [.NET health checks](xref:host-and-deploy/health-checks) are reported to callers.

To set up gRPC health checks in an app:

* Add a `Grpc.AspNetCore.HealthChecks` package reference.
* Register gRPC health checks service in `Startup.cs`:
  * `AddGrpcHealthChecks` to register services that enable health checks.
  * `MapGrpcHealthChecksService` to add a health checks service endpoint.
* Add health checks by implementing <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck> or using the <xref:Microsoft.Extensions.DependencyInjection.HealthChecksBuilderAddCheckExtensions.AddCheck%2A> method.

[!code-csharp[](~/grpc/health-checks/Startup.cs?highlight=4-6,16)]

When health checks is set up:

* The health checks service is added to the server app.
* .NET health checks registered with the app are periodically executed for health results. By default, there is a 5 second delay after app startup, and then health checks are executed every 30 seconds. Health check execution interval [can be customized with `HealthCheckPublisherOptions`](#configure-health-checks-execution-interval).
* Health results determine what the gRPC service reports:
  * `Unknown` is reported when there are no health results.
  * `NotServing` is reported when there are any health results of <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy?displayProperty=nameWithType>.
  * Otherwise, `Serving` is reported.

### Configure `Grpc.AspNetCore.HealthChecks`

By default, the gRPC health checks service uses all registered health checks to determine health status. gRPC health checks can be customized when registered to use a subset of health checks. The `MapService` method is used to map health results to service names, along with a predicate for filtering health results:

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
    o.Services.MapService("greet.Greeter", r => r.Tags.Contains("greeter"));
    o.Services.MapService("count.Counter", r => r.Tags.Contains("counter"));
});
```

The service name specified by the client is usually the default (`""`) or a package-qualified name of a service in your app. However, nothing prevents the client using arbitrary values to check app health.

### Configure health checks execution interval

Health checks are run immediately when `Check` is called. `Watch` is a streaming method and has a different behavior than `Check`: The long running stream reports health checks results over time by periodically executing <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> to gather health results. By default, the publisher:

* Waits 5 seconds after app startup before running health checks.
* Runs health checks every 30 seconds.

Publisher intervals can be configured using <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckPublisherOptions> at startup:

```csharp
services.Configure<HealthCheckPublisherOptions>(options =>
{
    options.Delay = TimeSpan.Zero;
    options.Period = TimeSpan.FromSeconds(10);
});
```

## Call gRPC health checks service

The [`Grpc.HealthCheck`](https://www.nuget.org/packages/Grpc.HealthCheck) package includes a client for gRPC health checks:

```csharp
var channel = GrpcChannel.ForAddress("https://localhost:5001");
var client = new Health.HealthClient(channel);

var response = client.CheckAsync(new HealthCheckRequest());
var status = response.Status;
```

There are two methods on the `Health` service:

* `Check` is a unary method for getting the current health status. Health checks are executed immediately when `Check` is called. The server returns a `NOT_FOUND` error response if the client requests an unknown service name. This can happen at app startup if health results haven't been published yet.
* `Watch` is a streaming method that reports changes in health status over time. <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> is periodically executed to gather health results. The server returns an `Unknown` status if the client requests an unknown service name.

## Additional resources

* <xref:host-and-deploy/health-checks>
* [gRPC health checking protocol](https://github.com/grpc/grpc/blob/master/doc/health-checking.md)
* [`Grpc.AspNetCore.HealthChecks`](https://www.nuget.org/packages/Grpc.AspNetCore.HealthChecks)
* [`Grpc.HealthCheck`](https://www.nuget.org/packages/Grpc.HealthCheck)

:::moniker-end
