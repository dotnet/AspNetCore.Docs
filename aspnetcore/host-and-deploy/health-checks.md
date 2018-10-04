---
title: Health checks in ASP.NET Core
author: guardrex
description: Learn how to set up health checks for ASP.NET Core infrastructure, such as apps and databases.
monikerRange: '>= aspnetcore-2.2'
ms.author: riande
ms.custom: mvc
ms.date: 10/10/2018
uid: host-and-deploy/health-checks
---
# Health checks in ASP.NET Core

By [Luke Latham](https://github.com/guardrex) and [Glenn Condron](https://github.com/glennc)

ASP.NET Core offers Health Check Middleware and libraries for reporting the health of app infrastructure components.

Health checks are exposed by an app as HTTP endpoints. Health check endpoints can be configured for a variety of real-time monitoring scenarios:

* Health probes can be used by container orchestrators and load balancers to check an app's status. For example, a container orchestrator may respond to a failing health check by halting a rolling deployment or restarting a container. A load balancer might react to an unhealthy app by routing traffic away from the failing instance to a healthy instance.
* Use of memory, disk, and other physical server resources can be monitored for healthy status.
* Health checks can test an app's dependencies, such as databases and external service endpoints, to confirm availability and normal functioning.

> [!WARNING]
> Health Check Middleware doesn't disable caching of health check responses. This scenario is planned for a future release.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/host-and-deploy/health-checks/samples) ([how to download](xref:tutorials/index#how-to-download-a-sample))

The sample app includes examples of the scenarios described in this topic. To run the sample app for a given scenario, use the [dotnet run](/dotnet/core/tools/dotnet-run) command from the project's folder in a command shell. See the sample app's *README.md* file and the scenario descriptions in this topic for details on how to use the sample app.

## Prerequisites

Reference the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app) or add a package reference to the [Microsoft.AspNetCore.Diagnostics.HealthChecks](https://www.nuget.org/packages/Microsoft.AspNetCore.Diagnostics.HealthChecks) package.

The sample app provides start-up code to demonstrate health checks for several scenarios. One of the scenarios checks the health of a database connection. To explore the database scenario using the sample app, create a database and provide its connection string in the *appsettings.json* file of the app. For more information, see the [Database probe](#database-probe) section. Another scenario demonstrates how to filter health checks to a management port. The sample app requires you to create a *Properties/launchSettings.json* file that includes the management URL and management port. For more information, see the [Filter by port](#filter-by-port) section.

## Basic health probe

For many apps, a basic health probe configuration that reports the app's availability to process requests (*liveness*) is sufficient to discover the status of the app.

The basic configuration registers health check services and calls the Health Check Middleware to respond at a URL endpoint with a health response. By default, no specific health checks are registered to test any particular dependency or subsystem. The app is considered healthy if it's capable of responding at the health endpoint URL. The default response writer writes the status (`HealthCheckStatus`) as `text/plain` content back to the client. The response is a *200 Ok* status code, and the content is either healthy (`HealthCheckResult.Healthy`) or unhealthy (`HealthCheckResult.Unhealthy`).

Register health check services with `AddHealthChecks` in `Startup.ConfigureServices`. Call Health Check Middleware in the app processing pipeline in `Startup.Configure`.

In the sample app, the health check endpoint is created at `/health` (*BasicStartup.cs*):

[!code-csharp[](health-checks/samples/2.x/HealthChecksSample/BasicStartup.cs?name=snippet1&highlight=5,10)]

To run the basic configuration scenario using the sample app, execute the following command from the project's folder in a command shell:

```console
dotnet run --scenario basic
```

### Docker example

[Docker](xref:host-and-deploy/docker/index) offers a built-in `HEALTHCHECK` directive that can be used to check the status of an app that uses the basic health check configuration:

```
HEALTHCHECK CMD curl --fail http://localhost:5000/health || exit
```

## Create health checks

Health checks are created by implementing the `IHealthCheck` interface. The `IHealthCheck.CheckHealthAsync` method returns a `Task<HealthCheckResult>` of either `Healthy`, `Unhealthy`, `Degraded`, or `Failed`. The result is written as a plain text response with a configurable status code (configuration is described in the [Health check options](#health-check-options) section).

The following `ExampleHealthCheck` class demonstrates the layout of a health check:

```csharp
public class ExampleHealthCheck : IHealthCheck
{
    public ExampleHealthCheck()
    {
        // Use DI to supply any required services to the health check.
    }

    public string Name => "example_check";

    public Task<HealthCheckResult> CheckHealthAsync(
        CancellationToken cancellationToken = default(CancellationToken))
    {
        // Execute health check logic here. This example sets a dummy
        // variable to true.
        var healthCheckResultHealthy = true;

        // Return a HealthCheckResult value depending on the outcome of the
        // check(s). Other HealthCheckResult outcomes not shown in this
        // example are Degraded and Failed.
        if (healthCheckResultHealthy)
        {
            return Task.FromResult(
                HealthCheckResult.Healthy("The check indicates a healthy state."));
        }

        return Task.FromResult(
            HealthCheckResult.Unhealthy("The check indicates an unhealthy state."));
    }
}
```

Add the `ExampleHealthCheck` with `AddCheck` and call `UseHealthChecks` in the processing pipeline with the endpoint URL:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddHealthChecks()
        .AddCheck(new ExampleHealthCheck);
}

public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    app.UseHealthChecks("/health");
}
```

`AddCheck` can also execute a lambda function. In the following example, the health check name is specified as `Foo` and the check always returns a healthy state:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddHealthChecks()
        .AddCheck("Foo", () => Task.FromResult(
            HealthCheckResult.Healthy("Foo is OK!")));
}
```

## Health check options

`HealthCheckOptions` provide an opportunity to customize health check behavior:

* [Filter health checks](#filter-health-checks)
* [Customize the HTTP status code](#customize-the-http-status-code)

### Filter health checks

By default, Health Check Middleware runs all registered health checks. To run a subset of health checks, provide a function that returns a boolean to the `Predicate` option. In the following example, the `Bar` health check is filtered out by the function's conditional statement, where `true` is only returned if the health check's `Name` property matches `Foo` or `Baz`:

```csharp
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

public void ConfigureServices(IServiceCollection services)
{
    services.AddHealthChecks()
        .AddCheck("Foo", () => 
            Task.FromResult(HealthCheckResult.Healthy("Foo is OK!")))
        .AddCheck("Bar", () => 
            Task.FromResult(HealthCheckResult.Unhealthy("Bar is OK!")))
        .AddCheck("Baz", () => 
            Task.FromResult(HealthCheckResult.Healthy("Baz is OK!")));
}

public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    app.UseHealthChecks("/health", new HealthCheckOptions()
    {
        // Filter out the 'Bar' health check. Only Foo and Baz execute.
        Predicate = (check) => check.Name == "Foo" || check.Name == "Baz"
    });
}
```

### Customize the HTTP status code

Use `ResultStatusCodes` to customize the mapping of health status to HTTP status codes. The following `StatusCode` assignments are the default values used by the middleware. Change the status code values to meet your requirements.

```csharp
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;

public void Configure(IApplicationBuilder app, IHostingEnvironment env)
{
    app.UseHealthChecks("/health", new HealthCheckOptions()
    {
        // The following StatusCodes are the default assignments for
        // the HealthCheckStatus properties.
        ResultStatusCodes =
        {
            [HealthCheckStatus.Healthy] = StatusCodes.Status200OK,
            [HealthCheckStatus.Degraded] = StatusCodes.Status200OK,
            [HealthCheckStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable,
            [HealthCheckStatus.Failed] = StatusCodes.Status500InternalServerError
        }
    });
}
```

## Database probe

A health check can specify a database query to run as a boolean test to indicate if the database is responding normally.

When using a database health check approach that relies on querying the database, choose a query that returns quickly. The query approach runs the risk of overloading the database and degrading its performance. In most cases, running a test query isn't necessary. Merely making a successful connection to the database is sufficient. If you find it necessary to run a query, choose a simple SELECT query, such as `SELECT 1`.

In the sample app, `CheckHealthAsync` executes the query to determine the health of the database (*DbConnectionHealthCheck.cs*):

[!code-csharp[](health-checks/samples/2.x/HealthChecksSample/DbConnectionHealthCheck.cs?name=snippet1&highlight=15,20,24)]

`SqlConnectionHealthCheck` uses a default query or passes a query into `DbConnectionHealthCheck` (*SqlConnectionHealthCheck.cs*):

[!code-csharp[](health-checks/samples/2.x/HealthChecksSample/SqlConnectionHealthCheck.cs?name=snippet1&highlight=3)]

Supply a valid database connection string in the *appsettings.json* file of the sample app. The app uses a SQL Server database named `HealthCheckSample`:

[!code-json[](health-checks/samples/2.x/HealthChecksSample/appsettings.json?highlight=3)]

Register health check services with `AddHealthChecks` in `Startup.ConfigureServices`. The sample app adds the `SqlConnectionHealthCheck` with the `AddCheck` extension method (*DbHealthStartup.cs*):

[!code-csharp[](health-checks/samples/2.x/HealthChecksSample/DbHealthStartup.cs?name=snippet_ConfigureServices)]

Call Health Check Middleware in the app processing pipeline in `Startup.Configure`:

[!code-csharp[](health-checks/samples/2.x/HealthChecksSample/DbHealthStartup.cs?name=snippet_Configure&highlight=3)]

To run the database probe scenario using the sample app, execute the following command from the project's folder in a command shell:

```console
dotnet run --scenario db
```

## Separate readiness and liveness probes

In some hosting scenarios, a pair of health checks are used that distinguish two app states:

* The app is functioning but not yet ready to receive requests. This state is the app's *readiness*.
* The app is functioning and responding to requests. This state is the app's *liveness*.

The readiness check usually performs a more extensive and time-consuming set of checks to determine if all of the app's subsystems and resources are available. A liveness check merely performs a quick check to determine if the app is available to process requests. After the app passes its readiness check, there's no need to burden the app further with the expensive set of readiness checks&mdash;further checks only require checking for liveness.

The sample app includes a `SlowDependencyHealthCheck` that creates a contrived 15 second delay when the check is executed. During the delay, `HealthCheckResult.Unhealthy` is returned by the readiness check. After the delay, `HealthCheckResult.Healthy` is returned (*SlowDependencyHealthCheck.cs*):

[!code-csharp[](health-checks/samples/2.x/HealthChecksSample/SlowDependencyHealthCheck.cs?name=snippet1&highlight=7,15-22)]

Register health check services with `AddHealthChecks` in `Startup.ConfigureServices`. Register `SlowDependencyHealthCheck` with `AddCheck` (*LivenessProbeStartup.cs*):

[!code-csharp[](health-checks/samples/2.x/HealthChecksSample/LivenessProbeStartup.cs?name=snippet_ConfigureServices)]

Call Health Check Middleware in the app processing pipeline in `Startup.Configure`. In the sample app, the health check endpoints are created at `/health/ready` for the readiness check and `/health/live` for the liveness check. The liveness check filters out the `SlowDependencyHealthCheck` by returning `false` in the `HealthCheckOptions.Predicate` (for more information, see [Filter health checks](#filter-health-checks)):

[!code-csharp[](health-checks/samples/2.x/HealthChecksSample/LivenessProbeStartup.cs?name=snippet_Configure&highlight=3,5-9)]

To run the readiness/liveness configuration scenario using the sample app, execute the following command from the project's folder in a command shell:

```console
dotnet run --scenario liveness
```

### Kubernetes example

Using separate readiness and liveness checks is useful in an environment such as [Kubernetes](https://kubernetes.io/). In Kubernetes, an app might be required to perform time-consuming startup work before accepting requests, such as a test of the underlying database availability. Using separate checks allows the orchestrator to distinguish whether the app is functioning but not yet ready or if the app has failed to start. For more information on readiness and liveness probes in Kubernetes, see [Configure Liveness and Readiness Probes](https://kubernetes.io/docs/tasks/configure-pod-container/configure-liveness-readiness-probes/) in the Kubernetes documentation.

The following example demonstrates a Kubernetes readiness probe configuration:

```
spec:
  template:
  spec:
    readinessProbe:
      # an http probe
      httpGet:
        path: /health/ready
        port: 80
      # length of time to wait for a pod to initialize
      # after pod startup, before applying health checking
      initialDelaySeconds: 30
      timeoutSeconds: 1
    ports:
      - containerPort: 80
```

## Metric-based probe (memory) with a custom response writer

The sample app demonstrates a memory health check with a custom response writer.

`MemoryHealthCheck` reports a degraded status if the app is using more than 1 GB of memory. The `HealthCheckResult` includes Garbage Collector (GC) information for the app (*MemoryHealthCheck.cs*):

[!code-csharp[](health-checks/samples/2.x/HealthChecksSample/MemoryHealthCheck.cs?name=snippet1&highlight=9-16,19-27)]

Register health check services with `AddHealthChecks` in `Startup.ConfigureServices`. Instead of enabling the health check by passing it to `AddCheck`, the `MemoryHealthCheck` is registered as a service. All `IHealthCheck` registered services are available to the health check services and middleware. We recommend registering health check services as Singleton services.

*CustomWriterStartup.cs*:

[!code-csharp[](health-checks/samples/2.x/HealthChecksSample/CustomWriterStartup.cs?name=snippet_ConfigureServices&highlight=4)]

Call Health Check Middleware in the app processing pipeline in `Startup.Configure`. A `WriteResponse` delegate is provided to the `ResponseWriter` property to output a custom JSON response when the health check executes:

[!code-csharp[](health-checks/samples/2.x/HealthChecksSample/CustomWriterStartup.cs?name=snippet_Configure&highlight=6)]

The `WriteResponse` method formats the `CompositeHealthCheckResult` into a JSON object and yields JSON output for the health check response:

[!code-csharp[](health-checks/samples/2.x/HealthChecksSample/CustomWriterStartup.cs?name=snippet_WriteResponse)]

To run the metric-based probe with custom response writer output using the sample app, execute the following command from the project's folder in a command shell:

```console
dotnet run --scenario writer
```

## Filter by port

Calling `UseHealthChecks` with a port restricts health check requests to the port specified. This is typically used in a container environment to expose a port for monitoring services.

The sample app configures the port using the [Environment Variable Configuration Provider](xref:fundamentals/configuration/index#environment-variables-configuration-provider). The port is set in the *launchSettings.json* file and passed to the configuration provider via an environment variable. You must also configure the server to listen to requests on the management port.

To use the sample app to demonstrate management port configuration, create the *launchSettings.json* file in a *Properties* folder.

The following *launchSettings.json* file isn't included in the sample app's project files and must be created manually.

*Properties/launchSettings.json*:

```json
{
  "profiles": {
    "SampleApp": {
      "commandName": "Project",
      "commandLineArgs": "",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development",
        "ASPNETCORE_URLS": "http://localhost:5000/;http://localhost:5001/",
        "ASPNETCORE_MANAGEMENTPORT": "5001"
      },
      "applicationUrl": "http://localhost:5000/"
    }
  }
}
```

Register health check services with `AddHealthChecks` in `Startup.ConfigureServices`. The call to `UseHealthChecks` specifies the management port (*ManagementPortStartup.cs*):

[!code-csharp[](health-checks/samples/2.x/HealthChecksSample/ManagementPortStartup.cs?name=snippet1&highlight=12,18)]

> [!NOTE]
> You can avoid creating the *launchSettings.json* file in the sample app by setting the URLs and management port explicitly in code. In *Program.cs* where the `WebHostBuilder` is created, add a call to `UseUrls` and provide the app's normal response endpoint and the management port endpoint. In *ManagementPortStartup.cs* where `UseHealthChecks` is called, specify the management port explicitly.
>
> *Program.cs*:
>
> ```csharp
> return new WebHostBuilder()
>     .UseConfiguration(config)
>     .UseUrls("http://localhost:5000/;http://localhost:5001/")
>     .ConfigureLogging(builder =>
>     {
>         builder.SetMinimumLevel(LogLevel.Trace);
>         builder.AddConfiguration(config);
>         builder.AddConsole();
>     })
>     .UseKestrel()
>     .UseStartup(startupType)
>     .Build();
> ```
>
> *ManagementPortStartup.cs*:
>
> ```csharp
> app.UseHealthChecks("/health", port: 5001);
> ```

To run the management port configuration scenario using the sample app, execute the following command from the project's folder in a command shell:

```console
dotnet run --scenario port
```
