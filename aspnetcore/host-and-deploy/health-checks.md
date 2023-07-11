---
title: Health checks in ASP.NET Core
author: rick-anderson
description: Learn how to set up health checks for ASP.NET Core infrastructure, such as apps and databases.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 07/11/2023
uid: host-and-deploy/health-checks
---
# Health checks in ASP.NET Core

By [Glenn Condron](https://github.com/glennc) and [Juergen Gutsch](https://twitter.com/sharpcms)

:::moniker range="< aspnetcore-6.0"
[!INCLUDE[](~/includes/not-latest-version.md)]
:::moniker-end

:::moniker range=">= aspnetcore-8.0"

ASP.NET Core offers Health Checks Middleware and libraries for reporting the health of app infrastructure components.

Health checks are exposed by an app as HTTP endpoints. Health check endpoints can be configured for various real-time monitoring scenarios:

* Health probes can be used by container orchestrators and load balancers to check an app's status. For example, a container orchestrator may respond to a failing health check by halting a rolling deployment or restarting a container. A load balancer might react to an unhealthy app by routing traffic away from the failing instance to a healthy instance.
* Use of memory, disk, and other physical server resources can be monitored for healthy status.
* Health checks can test an app's dependencies, such as databases and external service endpoints, to confirm availability and normal functioning.

Health checks are typically used with an external monitoring service or container orchestrator to check the status of an app. Before adding health checks to an app, decide on which monitoring system to use. The monitoring system dictates what types of health checks to create and how to configure their endpoints.

## Basic health probe

For many apps, a basic health probe configuration that reports the app's availability to process requests (*liveness*) is sufficient to discover the status of the app.

The basic configuration registers health check services and calls the Health Checks Middleware to respond at a URL endpoint with a health response. By default, no specific health checks are registered to test any particular dependency or subsystem. The app is considered healthy if it can respond at the health endpoint URL. The default response writer writes <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus> as a plaintext response to the client. The `HealthStatus` is <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Healthy?displayProperty=nameWithType>, <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Degraded?displayProperty=nameWithType>, or <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy?displayProperty=nameWithType>.

Register health check services with <xref:Microsoft.Extensions.DependencyInjection.HealthCheckServiceCollectionExtensions.AddHealthChecks%2A> in `Program.cs`. Create a health check endpoint by calling <xref:Microsoft.AspNetCore.Builder.HealthCheckEndpointRouteBuilderExtensions.MapHealthChecks%2A>.

The following example creates a health check endpoint at `/healthz`:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/Snippets/Program.cs" id="snippet_MapHealthChecksComplete" highlight="3,7":::

### Docker `HEALTHCHECK`

[Docker](xref:host-and-deploy/docker/index) offers a built-in `HEALTHCHECK` directive that can be used to check the status of an app that uses the basic health check configuration:

```dockerfile
HEALTHCHECK CMD curl --fail http://localhost:5000/healthz || exit
```

The preceding example uses `curl` to make an HTTP request to the health check endpoint at `/healthz`. `curl` isn't included in the .NET Linux container images, but it can be added by installing the required package in the Dockerfile. Containers that use images based on Alpine Linux can use the included `wget` in place of `curl`.

## Create health checks

Health checks are created by implementing the <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck> interface. The <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck.CheckHealthAsync%2A> method returns a <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult> that indicates the health as `Healthy`, `Degraded`, or `Unhealthy`. The result is written as a plaintext response with a configurable status code. Configuration is described in the [Health check options](#health-check-options) section. <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult> can also return optional key-value pairs.

The following example demonstrates the layout of a health check: 

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/HealthChecks/SampleHealthCheck.cs" id="snippet_Class":::

The health check's logic is placed in the <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck.CheckHealthAsync%2A> method. The preceding example sets a dummy variable, `isHealthy`, to `true`. If the value of `isHealthy` is set to `false`, the <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckRegistration.FailureStatus?displayProperty=nameWithType> status is returned.

If <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck.CheckHealthAsync%2A> throws an exception during the check, a new <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthReportEntry> is returned with its <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthReportEntry.Status?displayProperty=nameWithType> set to the <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckRegistration.FailureStatus>. This status is defined by <xref:Microsoft.Extensions.DependencyInjection.HealthChecksBuilderAddCheckExtensions.AddCheck%2A> (see the [Register health check services](#register-health-check-services) section) and includes the [inner exception](xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthReportEntry.Exception) that caused the check failure. The <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthReportEntry.Description> is set to the exception's message.

## Register health check services

To register a health check service, call <xref:Microsoft.Extensions.DependencyInjection.HealthChecksBuilderAddCheckExtensions.AddCheck%2A> in `Program.cs`:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/Snippets/Program.cs" id="snippet_AddHealthChecks":::

The <xref:Microsoft.Extensions.DependencyInjection.HealthChecksBuilderAddCheckExtensions.AddCheck%2A> overload shown in the following example sets the failure status (<xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus>) to report when the health check reports a failure. If the failure status is set to `null` (default), <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy?displayProperty=nameWithType> is reported. This overload is a useful scenario for library authors, where the failure status indicated by the library is enforced by the app when a health check failure occurs if the health check implementation honors the setting.

*Tags* can be used to filter health checks. Tags are described in the [Filter health checks](#filter-health-checks) section.

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/Snippets/Program.cs" id="snippet_AddHealthChecksExtended":::

<xref:Microsoft.Extensions.DependencyInjection.HealthChecksBuilderDelegateExtensions.AddCheck%2A> can also execute a lambda function. In the following example, the health check always returns a healthy result:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/Snippets/Program.cs" id="snippet_AddHealthChecksDelegate":::

Call <xref:Microsoft.Extensions.DependencyInjection.HealthChecksBuilderAddCheckExtensions.AddTypeActivatedCheck%2A> to pass arguments to a health check implementation. In the following example, a type-activated health check accepts an integer and a string in its constructor:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/HealthChecks/SampleHealthCheckWithArgs.cs" id="snippet_Class" highlight="6":::

To register the preceding health check, call `AddTypeActivatedCheck` with the integer and string passed as arguments:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/Snippets/Program.cs" id="snippet_AddHealthChecksTypeActivated":::

## Use Health Checks Routing

In `Program.cs`, call `MapHealthChecks` on the endpoint builder with the endpoint URL or relative path:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/Snippets/Program.cs" id="snippet_MapHealthChecks":::

### Require host

Call `RequireHost` to specify one or more permitted hosts for the health check endpoint. Hosts should be Unicode rather than punycode and may include a port. If a collection isn't supplied, any host is accepted:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/Snippets/Program.cs" id="snippet_MapHealthChecksRequireHost":::

To restrict the health check endpoint to respond only on a specific port, specify a port in the call to `RequireHost`. This approach is typically used in a container environment to expose a port for monitoring services:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/Snippets/Program.cs" id="snippet_MapHealthChecksRequireHostPort":::

[!INCLUDE[](~/includes/spoof.md)]

To prevent unauthorized clients from spoofing the port, call <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A>:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/7.x/HealthChecksSample/Snippets/Program.cs" id="snippet_MapHealthChecksRequireHostPortAuth":::

For more information, see [Host matching in routes with RequireHost](xref:fundamentals/routing#host-matching-in-routes-with-requirehost).

### Require authorization

Call <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A> to run Authorization Middleware on the health check request endpoint. A `RequireAuthorization` overload accepts one or more authorization policies. If a policy isn't provided, the default authorization policy is used:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/Snippets/Program.cs" id="snippet_MapHealthChecksRequireAuthorization":::

### Enable Cross-Origin Requests (CORS)

Although running health checks manually from a browser isn't a common scenario, CORS Middleware can be enabled by calling [`RequireCors`](https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/CORS/src/Infrastructure/CorsEndpointConventionBuilderExtensions.cs#L20-#L40) on the health checks endpoints. The [`RequireCors`](/dotnet/api/microsoft.aspnetcore.builder.corsendpointconventionbuilderextensions.requirecors) overload accepts a CORS policy builder delegate (`CorsPolicyBuilder`) or a policy name. For more information, see <xref:security/cors>.

## Health check options

<xref:Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions> provide an opportunity to customize health check behavior:

* [Filter health checks](#filter-health-checks)
* [Customize the HTTP status code](#customize-the-http-status-code)
* [Suppress cache headers](#suppress-cache-headers)
* [Customize output](#customize-output)

### Filter health checks

By default, the Health Checks Middleware runs all registered health checks. To run a subset of health checks, provide a function that returns a boolean to the <xref:Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions.Predicate> option.

The following example filters the health checks so that only those tagged with `sample` run:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/Snippets/Program.cs" id="snippet_MapHealthChecksFilterTags":::

### Customize the HTTP status code

Use <xref:Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions.ResultStatusCodes> to customize the mapping of health status to HTTP status codes. The following <xref:Microsoft.AspNetCore.Http.StatusCodes> assignments are the default values used by the middleware. Change the status code values to meet your requirements:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/Snippets/Program.cs" id="snippet_MapHealthChecksResultStatusCodes":::

### Suppress cache headers

<xref:Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions.AllowCachingResponses> controls whether the Health Checks Middleware adds HTTP headers to a probe response to prevent response caching. If the value is `false` (default), the middleware sets or overrides the `Cache-Control`, `Expires`, and `Pragma` headers to prevent response caching. If the value is `true`, the middleware doesn't modify the cache headers of the response:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/Snippets/Program.cs" id="snippet_MapHealthChecksAllowCachingResponses":::

### Customize output

To customize the output of a health checks report, set the <xref:Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions.ResponseWriter%2A?displayProperty=nameWithType> property to a delegate that writes the response:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/Snippets/Program.cs" id="snippet_MapHealthChecksResponseWriter":::

The default delegate writes a minimal plaintext response with the string value of [`HealthReport.Status`](xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthReport.Status). The following custom delegate outputs a custom JSON response using <xref:System.Text.Json?displayProperty=fullName>:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/Snippets/Program.cs" id="snippet_WriteResponse":::

The health checks API doesn't provide built-in support for complex JSON return formats because the format is specific to your choice of monitoring system. Customize the response in the preceding examples as needed. For more information on JSON serialization with `System.Text.Json`, see [How to serialize and deserialize JSON in .NET](/dotnet/standard/serialization/system-text-json-how-to).

## Database probe

A health check can specify a database query to run as a boolean test to indicate if the database is responding normally.

[`AspNetCore.Diagnostics.HealthChecks`](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks), a health check library for ASP.NET Core apps, includes a health check that runs against a SQL Server database. `AspNetCore.Diagnostics.HealthChecks` executes a `SELECT 1` query against the database to confirm the connection to the database is healthy.

> [!WARNING]
> When checking a database connection with a query, choose a query that returns quickly. The query approach runs the risk of overloading the database and degrading its performance. In most cases, running a test query isn't necessary. Merely making a successful connection to the database is sufficient. If you find it necessary to run a query, choose a simple SELECT query, such as `SELECT 1`.

To use this SQL Server health check, include a package reference to the [`AspNetCore.HealthChecks.SqlServer`](https://www.nuget.org/packages/AspNetCore.HealthChecks.SqlServer) NuGet package. The following example registers the SQL Server health check:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/Snippets/Program.cs" id="snippet_AddHealthChecksSqlServer":::

> [!NOTE]
> [`AspNetCore.Diagnostics.HealthChecks`](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks) isn't maintained or supported by Microsoft.

## Entity Framework Core DbContext probe

The `DbContext` check confirms that the app can communicate with the database configured for an EF Core `DbContext`. The `DbContext` check is supported in apps that:

* Use [Entity Framework (EF) Core](/ef/core/).
* Include a package reference to the [`Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore`](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore) NuGet package.

<xref:Microsoft.Extensions.DependencyInjection.EntityFrameworkCoreHealthChecksBuilderExtensions.AddDbContextCheck%2A> registers a health check for a <xref:Microsoft.EntityFrameworkCore.DbContext>. The `DbContext` is supplied to the method as the `TContext`. An overload is available to configure the failure status, tags, and a custom test query.

By default:

* The `DbContextHealthCheck` calls EF Core's `CanConnectAsync` method. You can customize what operation is run when checking health using `AddDbContextCheck` method overloads.
* The name of the health check is the name of the `TContext` type.

The following example registers a `DbContext` and an associated `DbContextHealthCheck`:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/Snippets/Program.cs" id="snippet_AddHealthChecksDbContext":::

## Separate readiness and liveness probes

In some hosting scenarios, a pair of health checks is used to distinguish two app states:

* *Readiness* indicates if the app is running normally but isn't ready to receive requests.
* *Liveness* indicates if an app has crashed and must be restarted.

Consider the following example: An app must download a large configuration file before it's ready to process requests. We don't want the app to be restarted if the initial download fails because the app can retry downloading the file several times. We use a *liveness probe* to describe the liveness of the process, no other checks are run. We also want to prevent requests from being sent to the app before the configuration file download has succeeded. We use a *readiness probe* to indicate a "not ready" state until the download succeeds and the app is ready to receive requests.

The following background task simulates a startup process that takes roughly 15 seconds. Once it completes, the task sets the `StartupHealthCheck.StartupCompleted` property to true:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/Services/StartupBackgroundService.cs" id="snippet_Class" highlight="13":::

The `StartupHealthCheck` reports the completion of the long-running startup task and exposes the `StartupCompleted` property that gets set by the background service:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/HealthChecks/StartupHealthCheck.cs" id="snippet_Class" highlight="5-9":::

The health check is registered with <xref:Microsoft.Extensions.DependencyInjection.HealthChecksBuilderAddCheckExtensions.AddCheck%2A> in `Program.cs` along with the hosted service. Because the hosted service must set the property on the health check, the health check is also registered in the service container as a singleton:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/Snippets/Program.cs" id="snippet_AddHealthChecksReadinessLiveness":::

To create two different health check endpoints, call `MapHealthChecks` twice:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/Snippets/Program.cs" id="snippet_MapHealthChecksReadinessLiveness":::

The preceding example creates the following health check endpoints:

* `/healthz/ready` for the readiness check. The readiness check filters health checks to those tagged with `ready`.
* `/healthz/live` for the liveness check. The liveness check filters out all health checks by returning `false` in the <xref:Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions.Predicate%2A?displayProperty=nameWithType> delegate. For more information on filtering health checks, see [Filter health checks](#filter-health-checks) in this article.

Before the startup task completes, the `/healthz/ready` endpoint reports an `Unhealthy` status. Once the startup task completes, this endpoint reports a `Healthy` status. The `/healthz/live` endpoint excludes all checks and reports a `Healthy` status for all calls.

### Kubernetes example

Using separate readiness and liveness checks is useful in an environment such as [Kubernetes](https://kubernetes.io/). In Kubernetes, an app might be required to run time-consuming startup work before accepting requests, such as a test of the underlying database availability. Using separate checks allows the orchestrator to distinguish whether the app is functioning but not yet ready or if the app has failed to start. For more information on readiness and liveness probes in Kubernetes, see [Configure Liveness and Readiness Probes](https://kubernetes.io/docs/tasks/configure-pod-container/configure-liveness-readiness-probes/) in the Kubernetes documentation.

The following example demonstrates a Kubernetes readiness probe configuration:

```yaml
spec:
  template:
  spec:
    readinessProbe:
      # an http probe
      httpGet:
        path: /healthz/ready
        port: 80
      # length of time to wait for a pod to initialize
      # after pod startup, before applying health checking
      initialDelaySeconds: 30
      timeoutSeconds: 1
    ports:
      - containerPort: 80
```

## Distribute a health check library

To distribute a health check as a library:

1. Write a health check that implements the <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck> interface as a standalone class. The class can rely on [dependency injection (DI)](xref:fundamentals/dependency-injection), type activation, and [named options](xref:fundamentals/configuration/options) to access configuration data.

1. Write an extension method with parameters that the consuming app calls in its `Program.cs` method. Consider the following example health check, which accepts `arg1` and `arg2` as constructor parameters:

   :::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/HealthChecks/SampleHealthCheckWithArgs.cs" id="snippet_ctor":::

   The preceding signature indicates that the health check requires custom data to process the health check probe logic. The data is provided to the delegate used to create the health check instance when the health check is registered with an extension method. In the following example, the caller specifies:

   * `arg1`: An integer data point for the health check.
   * `arg2`: A string argument for the health check.
   * `name`: An optional health check name. If `null`, a default value is used.
   * `failureStatus`: An optional <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus>, which is reported for a failure status. If `null`, <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy?displayProperty=nameWithType> is used.
   * `tags`: An optional `IEnumerable<string>` collection of tags.

   :::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/Extensions/SampleHealthCheckBuilderExtensions.cs" id="snippet_Class":::

## Health Check Publisher

When an <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> is added to the service container, the health check system periodically executes your health checks and calls <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher.PublishAsync%2A> with the result. This process is useful in a push-based health monitoring system scenario that expects each process to call the monitoring system periodically to determine health.

<xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckPublisherOptions> allow you to set the:

* <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckPublisherOptions.Delay>: The initial delay applied after the app starts before executing <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> instances. The delay is applied once at startup and doesn't apply to later iterations. The default value is five seconds.
* <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckPublisherOptions.Period>: The period of <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> execution. The default value is 30 seconds.
* <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckPublisherOptions.Predicate>: If <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckPublisherOptions.Predicate> is `null` (default), the health check publisher service runs all registered health checks. To run a subset of health checks, provide a function that filters the set of checks. The predicate is evaluated each period.
* <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckPublisherOptions.Timeout>: The timeout for executing the health checks for all <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> instances. Use <xref:System.Threading.Timeout.InfiniteTimeSpan> to execute without a timeout. The default value is 30 seconds.

The following example demonstrates the layout of a health publisher:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/HealthCheckPublishers/SampleHealthCheckPublisher.cs" id="snippet_Class":::

The <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckPublisherOptions> class provides properties for configuring the behavior of the health check publisher.

The following example registers a health check publisher as a singleton and configures <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckPublisherOptions>:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/6.x/HealthChecksSample/Snippets/Program.cs" id="snippet_HealthCheckPublisherOptionsService":::

> [!NOTE]
> [`AspNetCore.Diagnostics.HealthChecks`](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks) includes publishers for several systems, including [Application Insights](/azure/application-insights/app-insights-overview).
>
> [`AspNetCore.Diagnostics.HealthChecks`](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks) isn't maintained or supported by Microsoft.

## Dependency Injection and Health Checks

It's possible to use dependency injection to consume an instance of a specific `Type` inside a Health Check class. Dependency injection can be useful to inject options or a global configuration to a Health Check. Using dependency injection is ***not*** a common scenario to configure Health Checks. Usually, each Health Check is quite specific to the actual test and is configured using `IHealthChecksBuilder` extension methods.

The following example shows a sample Health Check that retrieves a configuration object via dependency injection:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/7.x/HealthChecksSample/HealthChecks/SampleHealthCheckWithDI.cs" id="snippet_Class":::

The `SampleHealthCheckWithDiConfig` and the Health check needs to be added to the service container :

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/7.x/HealthChecksSample/Snippets/Program.cs" id="snippet_MapHealthChecksUsingDependencyInjection":::

## UseHealthChecks vs. MapHealthChecks

There are two ways to make health checks accessible to callers:

* <xref:Microsoft.AspNetCore.Builder.HealthCheckApplicationBuilderExtensions.UseHealthChecks%2A> registers middleware for handling health checks requests in the middleware pipeline.
* <xref:Microsoft.AspNetCore.Builder.HealthCheckEndpointRouteBuilderExtensions.MapHealthChecks%2A> registers a health checks endpoint. The endpoint is matched and executed along with other endpoints in the app.

The advantage of using `MapHealthChecks` over `UseHealthChecks` is the ability to use endpoint aware middleware, such as authorization, and to have greater fine-grained control over the matching policy. The primary advantage of using `UseHealthChecks` over `MapHealthChecks` is controlling exactly where health checks runs in the middleware pipeline.

<xref:Microsoft.AspNetCore.Builder.HealthCheckApplicationBuilderExtensions.UseHealthChecks%2A>:
* Terminates the pipeline when a request matches the health check endpoint. [Short-circuiting](xref:fundamentals/middleware/index) is often desirable because it avoids unnecessary work, such as logging and other middleware.
* Is primarily used for configuring the health check middleware in the pipeline.
* Can match any path on a port with a `null` or empty `PathString`. Allows performing a health check on any request made to the specified port.
* [Source code](https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/HealthChecks/src/Builder/HealthCheckApplicationBuilderExtensions.cs)

<xref:Microsoft.AspNetCore.Builder.HealthCheckEndpointRouteBuilderExtensions.MapHealthChecks%2A> allows:
* Terminating the pipeline when a request matches the health check endpoint, by calling <xref:Microsoft.AspNetCore.Builder.RouteShortCircuitEndpointConventionBuilderExtensions.ShortCircuit%2A>. For example, `app.MapHealthChecks("/healthz").ShortCircuit();`. For more information, see [Short-circuit middleware after routing](../fundamentals/routing.md#short-circuit-middleware-after-routing).
* Mapping specific routes or endpoints for health checks.
* Customization of the URL or path where the health check endpoint is accessible.
* Mapping multiple health check endpoints with different routes or configurations. Multiple endpoint support:
  * Enables separate endpoints for different types of health checks or components.
  * Is used to differentiate between different aspects of the app's health or apply specific configurations to subsets of health checks.
* [Source code](https://github.com/dotnet/aspnetcore/blob/main/src/Middleware/HealthChecks/src/Builder/HealthCheckEndpointRouteBuilderExtensions.cs)

## Additional resources

* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/host-and-deploy/health-checks/samples) ([how to download](xref:index#how-to-download-a-sample))

> [!NOTE]
> This article was partially created with the help of artificial intelligence. Before publishing, an author reviewed and revised the content as needed. See [Our principles for using AI-generated content in Microsoft Learn](https://aka.ms/ai-content-principles).

:::moniker-end

[!INCLUDE[](~/host-and-deploy/health-checks/includes/health-checks5.md)]
[!INCLUDE[](~/host-and-deploy/health-checks/includes/health-checks6-7.md)]
