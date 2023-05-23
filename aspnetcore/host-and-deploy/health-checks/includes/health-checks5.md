:::moniker range="= aspnetcore-5.0"

ASP.NET Core offers Health Checks Middleware and libraries for reporting the health of app infrastructure components.

Health checks are exposed by an app as HTTP endpoints. Health check endpoints can be configured for various real-time monitoring scenarios:

* Health probes can be used by container orchestrators and load balancers to check an app's status. For example, a container orchestrator may respond to a failing health check by halting a rolling deployment or restarting a container. A load balancer might react to an unhealthy app by routing traffic away from the failing instance to a healthy instance.
* Use of memory, disk, and other physical server resources can be monitored for healthy status.
* Health checks can test an app's dependencies, such as databases and external service endpoints, to confirm availability and normal functioning.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/host-and-deploy/health-checks/samples) ([how to download](xref:index#how-to-download-a-sample))

The sample app includes examples of the scenarios described in this article. To run the sample app for a given scenario, use the [dotnet run](/dotnet/core/tools/dotnet-run) command from the project's folder in a command shell. See the sample app's `README.md` file and the scenario descriptions in this article for details on how to use the sample app.

## Prerequisites

Health checks are typically used with an external monitoring service or container orchestrator to check the status of an app. Before adding health checks to an app, decide on which monitoring system to use. The monitoring system dictates what types of health checks to create and how to configure their endpoints.

The [`Microsoft.AspNetCore.Diagnostics.HealthChecks`](https://www.nuget.org/packages/Microsoft.AspNetCore.Diagnostics.HealthChecks) package is referenced implicitly for ASP.NET Core apps. To run health checks using Entity Framework Core, add a reference to the [`Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore`](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore) package.

The sample app provides startup code to demonstrate health checks for several scenarios. The [database probe](#database-probe) scenario checks the health of a database connection using [`AspNetCore.Diagnostics.HealthChecks`](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks). The [DbContext probe](#entity-framework-core-dbcontext-probe) scenario checks a database using an EF Core `DbContext`. To explore the database scenarios, the sample app:

* Creates a database and provides its connection string in the `appsettings.json` file.
* Has the following package references in its project file:
  * [`AspNetCore.HealthChecks.SqlServer`](https://www.nuget.org/packages/AspNetCore.HealthChecks.SqlServer)
  * [`Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore`](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore)

> [!NOTE]
> [`AspNetCore.Diagnostics.HealthChecks`](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks) isn't maintained or supported by Microsoft.

Another health check scenario demonstrates how to filter health checks to a management port. The sample app requires you to create a `Properties/launchSettings.json` file that includes the management URL and management port. For more information, see the [Filter by port](#filter-by-port) section.

## Basic health probe

For many apps, a basic health probe configuration that reports the app's availability to process requests (*liveness*) is sufficient to discover the status of the app.

The basic configuration registers health check services and calls the Health Checks Middleware to respond at a URL endpoint with a health response. By default, no specific health checks are registered to test any particular dependency or subsystem. The app is considered healthy if it can respond at the health endpoint URL. The default response writer writes the status (<xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus>) as a plaintext response back to the client, indicating either a <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Healthy?displayProperty=nameWithType>, <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Degraded?displayProperty=nameWithType>, or <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy?displayProperty=nameWithType> status.

Register health check services with <xref:Microsoft.Extensions.DependencyInjection.HealthCheckServiceCollectionExtensions.AddHealthChecks%2A> in `Startup.ConfigureServices`. Create a health check endpoint by calling `MapHealthChecks` in `Startup.Configure`.

In the sample app, the health check endpoint is created at `/health` (`BasicStartup.cs`):

```csharp
public class BasicStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHealthChecks();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHealthChecks("/health");
        });
    }
}
```

To run the basic configuration scenario using the sample app, execute the following command from the project's folder in a command shell:

```dotnetcli
dotnet run --scenario basic
```

### Docker example

[Docker](xref:host-and-deploy/docker/index) offers a built-in `HEALTHCHECK` directive that can be used to check the status of an app that uses the basic health check configuration:

```
HEALTHCHECK CMD curl --fail http://localhost:5000/health || exit
```

## Create health checks

Health checks are created by implementing the <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck> interface. The <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck.CheckHealthAsync%2A> method returns a <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult> that indicates the health as `Healthy`, `Degraded`, or `Unhealthy`. The result is written as a plaintext response with a configurable status code (configuration is described in the [Health check options](#health-check-options) section). <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult> can also return optional key-value pairs.

The following `ExampleHealthCheck` class demonstrates the layout of a health check. The health checks logic is placed in the `CheckHealthAsync` method. The following example sets a dummy variable, `healthCheckResultHealthy`, to `true`. If the value of `healthCheckResultHealthy` is set to `false`, the <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckRegistration.FailureStatus?displayProperty=nameWithType> status is returned.

```csharp
public class ExampleHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default(CancellationToken))
    {
        var healthCheckResultHealthy = true;

        if (healthCheckResultHealthy)
        {
            return Task.FromResult(
                HealthCheckResult.Healthy("A healthy result."));
        }

        return Task.FromResult(
            new HealthCheckResult(context.Registration.FailureStatus, 
            "An unhealthy result."));
    }
}
```

If <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck.CheckHealthAsync%2A> throws an exception during the check, a new <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthReportEntry> is returned with its <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthReportEntry.Status?displayProperty=nameWithType> set to the <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckRegistration.FailureStatus>, which is defined by <xref:Microsoft.Extensions.DependencyInjection.HealthChecksBuilderAddCheckExtensions.AddCheck%2A> (see the [Register health check services](#register-health-check-services) section) and includes the [inner exception](xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthReportEntry.Exception) that initially caused the check failure. The <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthReportEntry.Description> is set to the exception's message.

## Register health check services

The `ExampleHealthCheck` type is added to health check services with <xref:Microsoft.Extensions.DependencyInjection.HealthChecksBuilderAddCheckExtensions.AddCheck%2A> in `Startup.ConfigureServices`:

```csharp
services.AddHealthChecks()
    .AddCheck<ExampleHealthCheck>("example_health_check");
```

The <xref:Microsoft.Extensions.DependencyInjection.HealthChecksBuilderAddCheckExtensions.AddCheck%2A> overload shown in the following example sets the failure status (<xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus>) to report when the health check reports a failure. If the failure status is set to `null` (default), <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy?displayProperty=nameWithType> is reported. This overload is a useful scenario for library authors, where the failure status indicated by the library is enforced by the app when a health check failure occurs if the health check implementation honors the setting.

*Tags* can be used to filter health checks (described further in the [Filter health checks](#filter-health-checks) section).

```csharp
services.AddHealthChecks()
    .AddCheck<ExampleHealthCheck>(
        "example_health_check",
        failureStatus: HealthStatus.Degraded,
        tags: new[] { "example" });
```

<xref:Microsoft.Extensions.DependencyInjection.HealthChecksBuilderAddCheckExtensions.AddCheck%2A> can also execute a lambda function. In the following example, the health check name is specified as `Example` and the check always returns a healthy state:

```csharp
services.AddHealthChecks()
    .AddCheck("Example", () =>
        HealthCheckResult.Healthy("Example is OK!"), tags: new[] { "example" });
```

Call <xref:Microsoft.Extensions.DependencyInjection.HealthChecksBuilderAddCheckExtensions.AddTypeActivatedCheck%2A> to pass arguments to a health check implementation. In the following example, `TestHealthCheckWithArgs` accepts an integer and a string for use when <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck.CheckHealthAsync%2A> is called:

```csharp
private class TestHealthCheckWithArgs : IHealthCheck
{
    public TestHealthCheckWithArgs(int i, string s)
    {
        I = i;
        S = s;
    }

    public int I { get; set; }

    public string S { get; set; }

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, 
        CancellationToken cancellationToken = default)
    {
        ...
    }
}
```

`TestHealthCheckWithArgs` is registered by calling `AddTypeActivatedCheck` with the integer and string passed to the implementation:

```csharp
services.AddHealthChecks()
    .AddTypeActivatedCheck<TestHealthCheckWithArgs>(
        "test", 
        failureStatus: HealthStatus.Degraded, 
        tags: new[] { "example" }, 
        args: new object[] { 5, "string" });
```

## Use Health Checks Routing

In `Startup.Configure`, call `MapHealthChecks` on the endpoint builder with the endpoint URL or relative path:

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health");
});
```

### Require host

Call `RequireHost` to specify one or more permitted hosts for the health check endpoint. Hosts should be Unicode rather than punycode and may include a port. If a collection isn't supplied, any host is accepted.

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health").RequireHost("www.contoso.com:5001");
});
```

For more information, see the [Filter by port](#filter-by-port) section.

### Require authorization

Call `RequireAuthorization` to run Authorization Middleware on the health check request endpoint. A `RequireAuthorization` overload accepts one or more authorization policies. If a policy isn't provided, the default authorization policy is used.

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health").RequireAuthorization();
});
```

### Enable Cross-Origin Requests (CORS)

Although running health checks manually from a browser isn't a common use scenario, CORS Middleware can be enabled by calling `RequireCors` on health checks endpoints. A `RequireCors` overload accepts a CORS policy builder delegate (`CorsPolicyBuilder`) or a policy name. If a policy isn't provided, the default CORS policy is used. For more information, see <xref:security/cors>.

## Health check options

<xref:Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions> provide an opportunity to customize health check behavior:

* [Filter health checks](#filter-health-checks)
* [Customize the HTTP status code](#customize-the-http-status-code)
* [Suppress cache headers](#suppress-cache-headers)
* [Customize output](#customize-output)

### Filter health checks

By default, Health Checks Middleware runs all registered health checks. To run a subset of health checks, provide a function that returns a boolean to the <xref:Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions.Predicate> option. In the following example, the `Bar` health check is filtered out by its tag (`bar_tag`) in the function's conditional statement, where `true` is only returned if the health check's <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckRegistration.Tags> property matches `foo_tag` or `baz_tag`:

In `Startup.ConfigureServices`:

```csharp
services.AddHealthChecks()
    .AddCheck("Foo", () =>
        HealthCheckResult.Healthy("Foo is OK!"), tags: new[] { "foo_tag" })
    .AddCheck("Bar", () =>
        HealthCheckResult.Unhealthy("Bar is unhealthy!"), tags: new[] { "bar_tag" })
    .AddCheck("Baz", () =>
        HealthCheckResult.Healthy("Baz is OK!"), tags: new[] { "baz_tag" });
```

In `Startup.Configure`, the `Predicate` filters out the 'Bar' health check. Only Foo and Baz execute:

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health", new HealthCheckOptions()
    {
        Predicate = (check) => check.Tags.Contains("foo_tag") ||
            check.Tags.Contains("baz_tag")
    });
});
```

### Customize the HTTP status code

Use <xref:Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions.ResultStatusCodes> to customize the mapping of health status to HTTP status codes. The following <xref:Microsoft.AspNetCore.Http.StatusCodes> assignments are the default values used by the middleware. Change the status code values to meet your requirements.

In `Startup.Configure`:

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health", new HealthCheckOptions()
    {
        ResultStatusCodes =
        {
            [HealthStatus.Healthy] = StatusCodes.Status200OK,
            [HealthStatus.Degraded] = StatusCodes.Status200OK,
            [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
        }
    });
});
```

### Suppress cache headers

<xref:Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions.AllowCachingResponses> controls whether the Health Checks Middleware adds HTTP headers to a probe response to prevent response caching. If the value is `false` (default), the middleware sets or overrides the `Cache-Control`, `Expires`, and `Pragma` headers to prevent response caching. If the value is `true`, the middleware doesn't modify the cache headers of the response.

In `Startup.Configure`:

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health", new HealthCheckOptions()
    {
        AllowCachingResponses = true
    });
});
```

### Customize output

In `Startup.Configure`, set the <xref:Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions.ResponseWriter%2A?displayProperty=nameWithType> option to a delegate for writing the response:

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health", new HealthCheckOptions()
    {
        ResponseWriter = WriteResponse
    });
});
```

The default delegate writes a minimal plaintext response with the string value of [`HealthReport.Status`](xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthReport.Status). The following custom delegates output a custom JSON response.

The first example from the sample app demonstrates how to use <xref:System.Text.Json?displayProperty=fullName>:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/5.x/HealthChecksSample/CustomWriterStartup.cs" id="snippet_WriteResponse_SystemTextJson":::

The second example demonstrates how to use [`Newtonsoft.Json`](https://www.nuget.org/packages/Newtonsoft.Json):

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/5.x/HealthChecksSample/CustomWriterStartup.cs" id="snippet_WriteResponse_NewtonSoftJson":::

In the sample app, comment out the `SYSTEM_TEXT_JSON` [preprocessor directive](xref:index#preprocessor-directives-in-sample-code) in `CustomWriterStartup.cs` to enable the `Newtonsoft.Json` version of `WriteResponse`.

The health checks API doesn't provide built-in support for complex JSON return formats because the format is specific to your choice of monitoring system. Customize the response in the preceding examples as needed. For more information on JSON serialization with `System.Text.Json`, see [How to serialize and deserialize JSON in .NET](/dotnet/standard/serialization/system-text-json-how-to).

## Database probe

A health check can specify a database query to run as a boolean test to indicate if the database is responding normally.

The sample app uses [`AspNetCore.Diagnostics.HealthChecks`](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks), a health check library for ASP.NET Core apps, to run a health check on a SQL Server database. `AspNetCore.Diagnostics.HealthChecks` executes a `SELECT 1` query against the database to confirm the connection to the database is healthy.

> [!WARNING]
> When checking a database connection with a query, choose a query that returns quickly. The query approach runs the risk of overloading the database and degrading its performance. In most cases, running a test query isn't necessary. Merely making a successful connection to the database is sufficient. If you find it necessary to run a query, choose a simple SELECT query, such as `SELECT 1`.

Include a package reference to [`AspNetCore.HealthChecks.SqlServer`](https://www.nuget.org/packages/AspNetCore.HealthChecks.SqlServer).

Supply a valid database connection string in the `appsettings.json` file of the sample app. The app uses a SQL Server database named `HealthCheckSample`:

:::code language="json" source="~/host-and-deploy/health-checks/samples/5.x/HealthChecksSample/appsettings.json" highlight="3":::

Register health check services with <xref:Microsoft.Extensions.DependencyInjection.HealthCheckServiceCollectionExtensions.AddHealthChecks%2A> in `Startup.ConfigureServices`. The sample app calls the `AddSqlServer` method with the database's connection string (`DbHealthStartup.cs`):

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/5.x/HealthChecksSample/DbHealthStartup.cs" id="snippet_ConfigureServices":::

A health check endpoint is created by calling `MapHealthChecks` in `Startup.Configure`:

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health");
}
```

To run the database probe scenario using the sample app, execute the following command from the project's folder in a command shell:

```dotnetcli
dotnet run --scenario db
```

> [!NOTE]
> [`AspNetCore.Diagnostics.HealthChecks`](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks) isn't maintained or supported by Microsoft.

## Entity Framework Core DbContext probe

The `DbContext` check confirms that the app can communicate with the database configured for an EF Core `DbContext`. The `DbContext` check is supported in apps that:

* Use [Entity Framework (EF) Core](/ef/core/).
* Include a package reference to [`Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore`](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore).

`AddDbContextCheck<TContext>` registers a health check for a `DbContext`. The `DbContext` is supplied as the `TContext` to the method. An overload is available to configure the failure status, tags, and a custom test query.

By default:

* The `DbContextHealthCheck` calls EF Core's `CanConnectAsync` method. You can customize what operation is run when checking health using `AddDbContextCheck` method overloads.
* The name of the health check is the name of the `TContext` type.

In the sample app, `AppDbContext` is provided to `AddDbContextCheck` and registered as a service in `Startup.ConfigureServices` (`DbContextHealthStartup.cs`):

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/5.x/HealthChecksSample/DbContextHealthStartup.cs" id="snippet_ConfigureServices":::

A health check endpoint is created by calling `MapHealthChecks` in `Startup.Configure`:

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health");
}
```

To run the `DbContext` probe scenario using the sample app, confirm that the database specified by the connection string doesn't exist in the SQL Server instance. If the database exists, delete it.

Execute the following command from the project's folder in a command shell:

```dotnetcli
dotnet run --scenario dbcontext
```

After the app is running, check the health status by making a request to the `/health` endpoint in a browser. The database and `AppDbContext` don't exist, so app provides the following response:

```
Unhealthy
```

Trigger the sample app to create the database. Make a request to `/createdatabase`. The app responds:

```
Creating the database...
Done!
Navigate to /health to see the health status.
```

Make a request to the `/health` endpoint. The database and context exist, so app responds:

```
Healthy
```

Trigger the sample app to delete the database. Make a request to `/deletedatabase`. The app responds:

```
Deleting the database...
Done!
Navigate to /health to see the health status.
```

Make a request to the `/health` endpoint. The app provides an unhealthy response:

```
Unhealthy
```

## Separate readiness and liveness probes

In some hosting scenarios, a pair of health checks is used to distinguish two app states:

* *Readiness* indicates if the app is running normally but isn't ready to receive requests.
* *Liveness* indicates if an app has crashed and must be restarted.

Consider the following example: An app must download a large configuration file before it's ready to process requests. We don't want the app to be restarted if the initial download fails because the app can retry downloading the file several times. We use a *liveness probe* to describe the liveness of the process, no other checks are run. We also want to prevent requests from being sent to the app before the configuration file download has succeeded. We use a *readiness probe* to indicate a "not ready" state until the download succeeds and the app is ready to receive requests.

The sample app contains a health check to report the completion of long-running startup task in a [Hosted Service](xref:fundamentals/host/hosted-services). The `StartupHostedServiceHealthCheck` exposes a property, `StartupTaskCompleted`, that the hosted service can set to `true` when its long-running task is finished (`StartupHostedServiceHealthCheck.cs`):

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/5.x/HealthChecksSample/StartupHostedServiceHealthCheck.cs" id="snippet1" highlight="7-11":::

The long-running background task is started by a [Hosted Service](xref:fundamentals/host/hosted-services) (`Services/StartupHostedService`). At the conclusion of the task, `StartupHostedServiceHealthCheck.StartupTaskCompleted` is set to `true`:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/5.x/HealthChecksSample/Services/StartupHostedService.cs" id="snippet1" highlight="23":::

The health check is registered with <xref:Microsoft.Extensions.DependencyInjection.HealthChecksBuilderAddCheckExtensions.AddCheck%2A> in `Startup.ConfigureServices` along with the hosted service. Because the hosted service must set the property on the health check, the health check is also registered in the service container (`LivenessProbeStartup.cs`):

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/5.x/HealthChecksSample/LivenessProbeStartup.cs" id="snippet_ConfigureServices":::

A health check endpoint is created by calling `MapHealthChecks` in `Startup.Configure`. In the sample app, the health check endpoints are created at:

* `/health/ready` for the readiness check. The readiness check filters health checks to the health check with the `ready` tag.
* `/health/live` for the liveness check. The liveness check filters out the `StartupHostedServiceHealthCheck` by returning `false` in the [`HealthCheckOptions.Predicate`](xref:Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions.Predicate) (for more information, see [Filter health checks](#filter-health-checks))

In the following example code:

* The readiness check uses all registered checks with the 'ready' tag.
* The `Predicate` excludes all checks and returns a 200-Ok.

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions()
    {
        Predicate = (check) => check.Tags.Contains("ready"),
    });

    endpoints.MapHealthChecks("/health/live", new HealthCheckOptions()
    {
        Predicate = (_) => false
    });
}
```

To run the readiness/liveness configuration scenario using the sample app, execute the following command from the project's folder in a command shell:

```dotnetcli
dotnet run --scenario liveness
```

In a browser, visit `/health/ready` several times until 15 seconds have passed. The health check reports `Unhealthy` for the first 15 seconds. After 15 seconds, the endpoint reports `Healthy`, which reflects the completion of the long-running task by the hosted service.

This example also creates a Health Check Publisher (<xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> implementation) that runs the first readiness check with a two-second delay. For more information, see the [Health Check Publisher](#health-check-publisher) section.

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
        path: /health/ready
        port: 80
      # length of time to wait for a pod to initialize
      # after pod startup, before applying health checking
      initialDelaySeconds: 30
      timeoutSeconds: 1
    ports:
      - containerPort: 80
```

## Metric-based probe with a custom response writer

The sample app demonstrates a memory health check with a custom response writer.

`MemoryHealthCheck` reports a degraded status if the app uses more than a given threshold of memory (1 GB in the sample app). The <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult> includes Garbage Collector (GC) information for the app (`MemoryHealthCheck.cs`):

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/5.x/HealthChecksSample/MemoryHealthCheck.cs" id="snippet1":::

Register health check services with <xref:Microsoft.Extensions.DependencyInjection.HealthCheckServiceCollectionExtensions.AddHealthChecks%2A> in `Startup.ConfigureServices`. Instead of enabling the health check by passing it to <xref:Microsoft.Extensions.DependencyInjection.HealthChecksBuilderAddCheckExtensions.AddCheck%2A>, the `MemoryHealthCheck` is registered as a service. All <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck> registered services are available to the health check services and middleware. We recommend registering health check services as Singleton services.

In `CustomWriterStartup.cs` of the sample app:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/5.x/HealthChecksSample/CustomWriterStartup.cs" id="snippet_ConfigureServices" highlight="4":::

A health check endpoint is created by calling `MapHealthChecks` in `Startup.Configure`. A `WriteResponse` delegate is provided to the <xref:Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions.ResponseWriter> property to output a custom JSON response when the health check executes:

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health", new HealthCheckOptions()
    {
        ResponseWriter = WriteResponse
    });
}
```

The `WriteResponse` delegate formats the `CompositeHealthCheckResult` into a JSON object and yields JSON output for the health check response. For more information, see the [Customize output](#customize-output) section.

To run the metric-based probe with custom response writer output using the sample app, execute the following command from the project's folder in a command shell:

```dotnetcli
dotnet run --scenario writer
```

> [!NOTE]
> [`AspNetCore.Diagnostics.HealthChecks`](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks) includes metric-based health check scenarios, including disk storage and maximum value liveness checks.
>
> [`AspNetCore.Diagnostics.HealthChecks`](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks) isn't maintained or supported by Microsoft.

## Filter by port

Call `RequireHost` on `MapHealthChecks` with a URL pattern that specifies a port to restrict health check requests to the port specified. This approach is typically used in a container environment to expose a port for monitoring services.

The sample app configures the port using the [Environment Variable Configuration Provider](xref:fundamentals/configuration/index#environment-variables). The port is set in the `launchSettings.json` file and passed to the configuration provider via an environment variable. You must also configure the server to listen to requests on the management port.

To use the sample app to demonstrate management port configuration, create the `launchSettings.json` file in a `Properties` folder.

The following `Properties/launchSettings.json` file in the sample app isn't included in the sample app's project files and must be created manually:

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

Register health check services with <xref:Microsoft.Extensions.DependencyInjection.HealthCheckServiceCollectionExtensions.AddHealthChecks%2A> in `Startup.ConfigureServices`. Create a health check endpoint by calling `MapHealthChecks` in `Startup.Configure`.

In the sample app, a call to `RequireHost` on the endpoint in `Startup.Configure` specifies the management port from configuration:

```csharp
endpoints.MapHealthChecks("/health")
    .RequireHost($"*:{Configuration["ManagementPort"]}");
```

Endpoints are created in the sample app in `Startup.Configure`. In the following example code:

* The readiness check uses all registered checks with the 'ready' tag.
* The `Predicate` excludes all checks and returns a 200-Ok.

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions()
    {
        Predicate = (check) => check.Tags.Contains("ready"),
    });

    endpoints.MapHealthChecks("/health/live", new HealthCheckOptions()
    {
        Predicate = (_) => false
    });
}
```

> [!NOTE]
> You can avoid creating the `launchSettings.json` file in the sample app by setting the management port explicitly in code. In `Program.cs` where the <xref:Microsoft.Extensions.Hosting.HostBuilder> is created, add a call to <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenAnyIP%2A> and provide the app's management port endpoint. In `Configure` of `ManagementPortStartup.cs`, specify the management port with `RequireHost`:
>
> `Program.cs`:
>
> ```csharp
> return new HostBuilder()
>     .ConfigureWebHostDefaults(webBuilder =>
>     {
>         webBuilder.UseKestrel()
>             .ConfigureKestrel(serverOptions =>
>             {
>                 serverOptions.ListenAnyIP(5001);
>             })
>             .UseStartup(startupType);
>     })
>     .Build();
> ```
>
> `ManagementPortStartup.cs`:
>
> ```csharp
> app.UseEndpoints(endpoints =>
> {
>     endpoints.MapHealthChecks("/health").RequireHost("*:5001");
> });
> ```

To run the management port configuration scenario using the sample app, execute the following command from the project's folder in a command shell:

```dotnetcli
dotnet run --scenario port
```

## Distribute a health check library

To distribute a health check as a library:

1. Write a health check that implements the <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck> interface as a standalone class. The class can rely on [dependency injection (DI)](xref:fundamentals/dependency-injection), type activation, and [named options](xref:fundamentals/configuration/options) to access configuration data.

   In the health checks logic of `CheckHealthAsync`:

   * `data1` and `data2` are used in the method to run the probe's health check logic.
   * `AccessViolationException` is handled.

   When an <xref:System.AccessViolationException> occurs, the <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckRegistration.FailureStatus> is returned with the <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult> to allow users to configure the health checks failure status.

   ```csharp
   using System;
   using System.Threading;
   using System.Threading.Tasks;
   using Microsoft.Extensions.Diagnostics.HealthChecks;

   namespace SampleApp
   {
       public class ExampleHealthCheck : IHealthCheck
       {
           private readonly string _data1;
           private readonly int? _data2;

           public ExampleHealthCheck(string data1, int? data2)
           {
               _data1 = data1 ?? throw new ArgumentNullException(nameof(data1));
               _data2 = data2 ?? throw new ArgumentNullException(nameof(data2));
           }

           public async Task<HealthCheckResult> CheckHealthAsync(
               HealthCheckContext context, CancellationToken cancellationToken)
           {
               try
               {
                   return HealthCheckResult.Healthy();
               }
               catch (AccessViolationException ex)
               {
                   return new HealthCheckResult(
                       context.Registration.FailureStatus,
                       description: "An access violation occurred during the check.",
                       exception: ex,
                       data: null);
               }
           }
       }
   }
   ```

1. Write an extension method with parameters that the consuming app calls in its `Startup.Configure` method. In the following example, assume the following health check method signature:

   ```csharp
   ExampleHealthCheck(string, string, int )
   ```

   The preceding signature indicates that the `ExampleHealthCheck` requires additional data to process the health check probe logic. The data is provided to the delegate used to create the health check instance when the health check is registered with an extension method. In the following example, the caller specifies optional:

   * health check name (`name`). If `null`, `example_health_check` is used.
   * string data point for the health check (`data1`).
   * integer data point for the health check (`data2`). If `null`, `1` is used.
   * failure status (<xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus>). The default is `null`. If `null`, <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy?displayProperty=nameWithType> is reported for a failure status.
   * tags (`IEnumerable<string>`).

   ```csharp
   using System.Collections.Generic;
   using Microsoft.Extensions.Diagnostics.HealthChecks;

   public static class ExampleHealthCheckBuilderExtensions
   {
       const string DefaultName = "example_health_check";

       public static IHealthChecksBuilder AddExampleHealthCheck(
           this IHealthChecksBuilder builder,
           string name = default,
           string data1,
           int data2 = 1,
           HealthStatus? failureStatus = default,
           IEnumerable<string> tags = default)
       {
           return builder.Add(new HealthCheckRegistration(
               name ?? DefaultName,
               sp => new ExampleHealthCheck(data1, data2),
               failureStatus,
               tags));
       }
   }
   ```

## Health Check Publisher

When an <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> is added to the service container, the health check system periodically executes your health checks and calls `PublishAsync` with the result. This is useful in a push-based health monitoring system scenario that expects each process to call the monitoring system periodically in order to determine health.

The <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> interface has a single method:

```csharp
Task PublishAsync(HealthReport report, CancellationToken cancellationToken);
```

<xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckPublisherOptions> allow you to set:

* <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckPublisherOptions.Delay>: The initial delay applied after the app starts before executing <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> instances. The delay is applied once at startup and doesn't apply to subsequent iterations. The default value is five seconds.
* <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckPublisherOptions.Period>: The period of <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> execution. The default value is 30 seconds.
* <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckPublisherOptions.Predicate>: If <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckPublisherOptions.Predicate> is `null` (default), the health check publisher service runs all registered health checks. To run a subset of health checks, provide a function that filters the set of checks. The predicate is evaluated each period.
* <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckPublisherOptions.Timeout>: The timeout for executing the health checks for all <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> instances. Use <xref:System.Threading.Timeout.InfiniteTimeSpan> to execute without a timeout. The default value is 30 seconds.

In the sample app, `ReadinessPublisher` is an <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> implementation. The health check status is logged for each check at a log level of:

* Information (<xref:Microsoft.Extensions.Logging.LoggerExtensions.LogInformation%2A>) if the health checks status is <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Healthy>.
* Error (<xref:Microsoft.Extensions.Logging.LoggerExtensions.LogError%2A>) if the status is either <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Degraded> or <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy>.

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/5.x/HealthChecksSample/ReadinessPublisher.cs" id="snippet_ReadinessPublisher" highlight="18-27":::

In the sample app's `LivenessProbeStartup` example, the `StartupHostedService` readiness check has a two second startup delay and runs the check every 30 seconds. To activate the <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> implementation, the sample registers `ReadinessPublisher` as a singleton service in the [dependency injection (DI)](xref:fundamentals/dependency-injection) container:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/5.x/HealthChecksSample/LivenessProbeStartup.cs" id="snippet_ConfigureServices":::

> [!NOTE]
> [`AspNetCore.Diagnostics.HealthChecks`](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks) includes publishers for several systems, including [Application Insights](/azure/application-insights/app-insights-overview).
>
> [`AspNetCore.Diagnostics.HealthChecks`](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks) isn't maintained or supported by Microsoft.

## Restrict health checks with MapWhen

Use <xref:Microsoft.AspNetCore.Builder.MapWhenExtensions.MapWhen%2A> to conditionally branch the request pipeline for health check endpoints.

In the following example, `MapWhen` branches the request pipeline to activate Health Checks Middleware if a GET request is received for the `api/HealthCheck` endpoint:

```csharp
app.MapWhen(
    context => context.Request.Method == HttpMethod.Get.Method && 
        context.Request.Path.StartsWith("/api/HealthCheck"),
    builder => builder.UseHealthChecks());

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});
```

For more information, see <xref:fundamentals/middleware/index#branch-the-middleware-pipeline>.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

ASP.NET Core offers Health Checks Middleware and libraries for reporting the health of app infrastructure components.

Health checks are exposed by an app as HTTP endpoints. Health check endpoints can be configured for various real-time monitoring scenarios:

* Health probes can be used by container orchestrators and load balancers to check an app's status. For example, a container orchestrator may respond to a failing health check by halting a rolling deployment or restarting a container. A load balancer might react to an unhealthy app by routing traffic away from the failing instance to a healthy instance.
* Use of memory, disk, and other physical server resources can be monitored for healthy status.
* Health checks can test an app's dependencies, such as databases and external service endpoints, to confirm availability and normal functioning.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/host-and-deploy/health-checks/samples) ([how to download](xref:index#how-to-download-a-sample))

The sample app includes examples of the scenarios described in this article. To run the sample app for a given scenario, use the [dotnet run](/dotnet/core/tools/dotnet-run) command from the project's folder in a command shell. See the sample app's `README.md` file and the scenario descriptions in this article for details on how to use the sample app.

## Prerequisites

Health checks are typically used with an external monitoring service or container orchestrator to check the status of an app. Before adding health checks to an app, decide on which monitoring system to use. The monitoring system dictates what types of health checks to create and how to configure their endpoints.

The [`Microsoft.AspNetCore.Diagnostics.HealthChecks`](https://www.nuget.org/packages/Microsoft.AspNetCore.Diagnostics.HealthChecks) package is referenced implicitly for ASP.NET Core apps. To run health checks using Entity Framework Core, add a package reference to the [`Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore`](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore) package.

The sample app provides startup code to demonstrate health checks for several scenarios. The [database probe](#database-probe) scenario checks the health of a database connection using [`AspNetCore.Diagnostics.HealthChecks`](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks). The [DbContext probe](#entity-framework-core-dbcontext-probe) scenario checks a database using an EF Core `DbContext`. To explore the database scenarios, the sample app:

* Creates a database and provides its connection string in the `appsettings.json` file.
* Has the following package references in its project file:
  * [`AspNetCore.HealthChecks.SqlServer`](https://www.nuget.org/packages/AspNetCore.HealthChecks.SqlServer)
  * [`Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore`](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore)

> [!NOTE]
> [`AspNetCore.Diagnostics.HealthChecks`](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks) isn't maintained or supported by Microsoft.

Another health check scenario demonstrates how to filter health checks to a management port. The sample app requires you to create a `Properties/launchSettings.json` file that includes the management URL and management port. For more information, see the [Filter by port](#filter-by-port) section.

## Basic health probe

For many apps, a basic health probe configuration that reports the app's availability to process requests (*liveness*) is sufficient to discover the status of the app.

The basic configuration registers health check services and calls the Health Checks Middleware to respond at a URL endpoint with a health response. By default, no specific health checks are registered to test any particular dependency or subsystem. The app is considered healthy if it can respond at the health endpoint URL. The default response writer writes the status (<xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus>) as a plaintext response back to the client, indicating either a <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Healthy?displayProperty=nameWithType>, <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Degraded?displayProperty=nameWithType>, or <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy?displayProperty=nameWithType> status.

Register health check services with <xref:Microsoft.Extensions.DependencyInjection.HealthCheckServiceCollectionExtensions.AddHealthChecks%2A> in `Startup.ConfigureServices`. Create a health check endpoint by calling `MapHealthChecks` in `Startup.Configure`.

In the sample app, the health check endpoint is created at `/health` (`BasicStartup.cs`):

```csharp
public class BasicStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHealthChecks();
    }

    public void Configure(IApplicationBuilder app)
    {
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapHealthChecks("/health");
        });
    }
}
```

To run the basic configuration scenario using the sample app, execute the following command from the project's folder in a command shell:

```dotnetcli
dotnet run --scenario basic
```

### Docker example

[Docker](xref:host-and-deploy/docker/index) offers a built-in `HEALTHCHECK` directive that can be used to check the status of an app that uses the basic health check configuration:

```
HEALTHCHECK CMD curl --fail http://localhost:5000/health || exit
```

## Create health checks

Health checks are created by implementing the <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck> interface. The <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck.CheckHealthAsync%2A> method returns a <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult> that indicates the health as `Healthy`, `Degraded`, or `Unhealthy`. The result is written as a plaintext response with a configurable status code (configuration is described in the [Health check options](#health-check-options) section). <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult> can also return optional key-value pairs.

The following `ExampleHealthCheck` class demonstrates the layout of a health check. The health checks logic is placed in the `CheckHealthAsync` method. The following example sets a dummy variable, `healthCheckResultHealthy`, to `true`. If the value of `healthCheckResultHealthy` is set to `false`, the [`HealthCheckResult.Unhealthy`](xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult.Unhealthy%2A) status is returned.

```csharp
public class ExampleHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default(CancellationToken))
    {
        var healthCheckResultHealthy = true;

        if (healthCheckResultHealthy)
        {
            return Task.FromResult(
                HealthCheckResult.Healthy("A healthy result."));
        }

        return Task.FromResult(
            HealthCheckResult.Unhealthy("An unhealthy result."));
    }
}
```

## Register health check services

The `ExampleHealthCheck` type is added to health check services with <xref:Microsoft.Extensions.DependencyInjection.HealthChecksBuilderAddCheckExtensions.AddCheck%2A> in `Startup.ConfigureServices`:

```csharp
services.AddHealthChecks()
    .AddCheck<ExampleHealthCheck>("example_health_check");
```

The <xref:Microsoft.Extensions.DependencyInjection.HealthChecksBuilderAddCheckExtensions.AddCheck%2A> overload shown in the following example sets the failure status (<xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus>) to report when the health check reports a failure. If the failure status is set to `null` (default), <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy?displayProperty=nameWithType> is reported. This overload is a useful scenario for library authors, where the failure status indicated by the library is enforced by the app when a health check failure occurs if the health check implementation honors the setting.

*Tags* can be used to filter health checks (described further in the [Filter health checks](#filter-health-checks) section).

```csharp
services.AddHealthChecks()
    .AddCheck<ExampleHealthCheck>(
        "example_health_check",
        failureStatus: HealthStatus.Degraded,
        tags: new[] { "example" });
```

<xref:Microsoft.Extensions.DependencyInjection.HealthChecksBuilderAddCheckExtensions.AddCheck%2A> can also execute a lambda function. In the following example, the health check name is specified as `Example` and the check always returns a healthy state:

```csharp
services.AddHealthChecks()
    .AddCheck("Example", () =>
        HealthCheckResult.Healthy("Example is OK!"), tags: new[] { "example" });
```

Call <xref:Microsoft.Extensions.DependencyInjection.HealthChecksBuilderAddCheckExtensions.AddTypeActivatedCheck%2A> to pass arguments to a health check implementation. In the following example, `TestHealthCheckWithArgs` accepts an integer and a string for use when <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck.CheckHealthAsync%2A> is called:

```csharp
private class TestHealthCheckWithArgs : IHealthCheck
{
    public TestHealthCheckWithArgs(int i, string s)
    {
        I = i;
        S = s;
    }

    public int I { get; set; }

    public string S { get; set; }

    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, 
        CancellationToken cancellationToken = default)
    {
        ...
    }
}
```

`TestHealthCheckWithArgs` is registered by calling `AddTypeActivatedCheck` with the integer and string passed to the implementation:

```csharp
services.AddHealthChecks()
    .AddTypeActivatedCheck<TestHealthCheckWithArgs>(
        "test", 
        failureStatus: HealthStatus.Degraded, 
        tags: new[] { "example" }, 
        args: new object[] { 5, "string" });
```

## Use Health Checks Routing

In `Startup.Configure`, call `MapHealthChecks` on the endpoint builder with the endpoint URL or relative path:

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health");
});
```

### Require host

Call `RequireHost` to specify one or more permitted hosts for the health check endpoint. Hosts should be Unicode rather than punycode and may include a port. If a collection isn't supplied, any host is accepted.

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health").RequireHost("www.contoso.com:5001");
});
```

For more information, see the [Filter by port](#filter-by-port) section.

### Require authorization

Call `RequireAuthorization` to run Authorization Middleware on the health check request endpoint. A `RequireAuthorization` overload accepts one or more authorization policies. If a policy isn't provided, the default authorization policy is used.

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health").RequireAuthorization();
});
```

### Enable Cross-Origin Requests (CORS)

Although running health checks manually from a browser isn't a common use scenario, CORS Middleware can be enabled by calling `RequireCors` on health checks endpoints. A `RequireCors` overload accepts a CORS policy builder delegate (`CorsPolicyBuilder`) or a policy name. If a policy isn't provided, the default CORS policy is used. For more information, see <xref:security/cors>.

## Health check options

<xref:Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions> provide an opportunity to customize health check behavior:

* [Filter health checks](#filter-health-checks)
* [Customize the HTTP status code](#customize-the-http-status-code)
* [Suppress cache headers](#suppress-cache-headers)
* [Customize output](#customize-output)

### Filter health checks

By default, Health Checks Middleware runs all registered health checks. To run a subset of health checks, provide a function that returns a boolean to the <xref:Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions.Predicate> option. In the following example, the `Bar` health check is filtered out by its tag (`bar_tag`) in the function's conditional statement, where `true` is only returned if the health check's <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckRegistration.Tags> property matches `foo_tag` or `baz_tag`:

In `Startup.ConfigureServices`:

```csharp
services.AddHealthChecks()
    .AddCheck("Foo", () =>
        HealthCheckResult.Healthy("Foo is OK!"), tags: new[] { "foo_tag" })
    .AddCheck("Bar", () =>
        HealthCheckResult.Unhealthy("Bar is unhealthy!"), tags: new[] { "bar_tag" })
    .AddCheck("Baz", () =>
        HealthCheckResult.Healthy("Baz is OK!"), tags: new[] { "baz_tag" });
```

In `Startup.Configure`, the `Predicate` filters out the 'Bar' health check. Only Foo and Baz execute:

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health", new HealthCheckOptions()
    {
        Predicate = (check) => check.Tags.Contains("foo_tag") ||
            check.Tags.Contains("baz_tag")
    });
});
```

### Customize the HTTP status code

Use <xref:Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions.ResultStatusCodes> to customize the mapping of health status to HTTP status codes. The following <xref:Microsoft.AspNetCore.Http.StatusCodes> assignments are the default values used by the middleware. Change the status code values to meet your requirements.

In `Startup.Configure`:

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health", new HealthCheckOptions()
    {
        ResultStatusCodes =
        {
            [HealthStatus.Healthy] = StatusCodes.Status200OK,
            [HealthStatus.Degraded] = StatusCodes.Status200OK,
            [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable
        }
    });
});
```

### Suppress cache headers

<xref:Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions.AllowCachingResponses> controls whether the Health Checks Middleware adds HTTP headers to a probe response to prevent response caching. If the value is `false` (default), the middleware sets or overrides the `Cache-Control`, `Expires`, and `Pragma` headers to prevent response caching. If the value is `true`, the middleware doesn't modify the cache headers of the response.

In `Startup.Configure`:

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health", new HealthCheckOptions()
    {
        AllowCachingResponses = true
    });
});
```

### Customize output

In `Startup.Configure`, set the <xref:Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions.ResponseWriter%2A?displayProperty=nameWithType> option to a delegate for writing the response:

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health", new HealthCheckOptions()
    {
        ResponseWriter = WriteResponse
    });
});
```

The default delegate writes a minimal plaintext response with the string value of [`HealthReport.Status`](xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthReport.Status). The following custom delegates output a custom JSON response.

The first example from the sample app demonstrates how to use <xref:System.Text.Json?displayProperty=fullName>:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/3.x/HealthChecksSample/CustomWriterStartup.cs" id="snippet_WriteResponse_SystemTextJson":::

The second example demonstrates how to use [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json):

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/3.x/HealthChecksSample/CustomWriterStartup.cs" id="snippet_WriteResponse_NewtonSoftJson":::

In the sample app, comment out the `SYSTEM_TEXT_JSON` [preprocessor directive](xref:index#preprocessor-directives-in-sample-code) in `CustomWriterStartup.cs` to enable the `Newtonsoft.Json` version of `WriteResponse`.

The health checks API doesn't provide built-in support for complex JSON return formats because the format is specific to your choice of monitoring system. Customize the response in the preceding examples as needed. For more information on JSON serialization with `System.Text.Json`, see [How to serialize and deserialize JSON in .NET](/dotnet/standard/serialization/system-text-json-how-to).

## Database probe

A health check can specify a database query to run as a boolean test to indicate if the database is responding normally.

The sample app uses [`AspNetCore.Diagnostics.HealthChecks`](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks), a health check library for ASP.NET Core apps, to run a health check on a SQL Server database. `AspNetCore.Diagnostics.HealthChecks` executes a `SELECT 1` query against the database to confirm the connection to the database is healthy.

> [!WARNING]
> When checking a database connection with a query, choose a query that returns quickly. The query approach runs the risk of overloading the database and degrading its performance. In most cases, running a test query isn't necessary. Merely making a successful connection to the database is sufficient. If you find it necessary to run a query, choose a simple SELECT query, such as `SELECT 1`.

Include a package reference to [`AspNetCore.HealthChecks.SqlServer`](https://www.nuget.org/packages/AspNetCore.HealthChecks.SqlServer).

Supply a valid database connection string in the `appsettings.json` file of the sample app. The app uses a SQL Server database named `HealthCheckSample`:

:::code language="json" source="~/host-and-deploy/health-checks/samples/3.x/HealthChecksSample/appsettings.json" highlight="3":::

Register health check services with <xref:Microsoft.Extensions.DependencyInjection.HealthCheckServiceCollectionExtensions.AddHealthChecks%2A> in `Startup.ConfigureServices`. The sample app calls the `AddSqlServer` method with the database's connection string (`DbHealthStartup.cs`):

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/3.x/HealthChecksSample/DbHealthStartup.cs" id="snippet_ConfigureServices":::

A health check endpoint is created by calling `MapHealthChecks` in `Startup.Configure`:

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health");
}
```

To run the database probe scenario using the sample app, execute the following command from the project's folder in a command shell:

```dotnetcli
dotnet run --scenario db
```

> [!NOTE]
> [`AspNetCore.Diagnostics.HealthChecks`](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks) isn't maintained or supported by Microsoft.

## Entity Framework Core DbContext probe

The `DbContext` check confirms that the app can communicate with the database configured for an EF Core `DbContext`. The `DbContext` check is supported in apps that:

* Use [Entity Framework (EF) Core](/ef/core/).
* Include a package reference to [`Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore`](https://www.nuget.org/packages/Microsoft.Extensions.Diagnostics.HealthChecks.EntityFrameworkCore).

`AddDbContextCheck<TContext>` registers a health check for a `DbContext`. The `DbContext` is supplied as the `TContext` to the method. An overload is available to configure the failure status, tags, and a custom test query.

By default:

* The `DbContextHealthCheck` calls EF Core's `CanConnectAsync` method. You can customize what operation is run when checking health using `AddDbContextCheck` method overloads.
* The name of the health check is the name of the `TContext` type.

In the sample app, `AppDbContext` is provided to `AddDbContextCheck` and registered as a service in `Startup.ConfigureServices` (`DbContextHealthStartup.cs`):

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/3.x/HealthChecksSample/DbContextHealthStartup.cs" id="snippet_ConfigureServices":::

A health check endpoint is created by calling `MapHealthChecks` in `Startup.Configure`:

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health");
}
```

To run the `DbContext` probe scenario using the sample app, confirm that the database specified by the connection string doesn't exist in the SQL Server instance. If the database exists, delete it.

Execute the following command from the project's folder in a command shell:

```dotnetcli
dotnet run --scenario dbcontext
```

After the app is running, check the health status by making a request to the `/health` endpoint in a browser. The database and `AppDbContext` don't exist, so app provides the following response:

```
Unhealthy
```

Trigger the sample app to create the database. Make a request to `/createdatabase`. The app responds:

```
Creating the database...
Done!
Navigate to /health to see the health status.
```

Make a request to the `/health` endpoint. The database and context exist, so app responds:

```
Healthy
```

Trigger the sample app to delete the database. Make a request to `/deletedatabase`. The app responds:

```
Deleting the database...
Done!
Navigate to /health to see the health status.
```

Make a request to the `/health` endpoint. The app provides an unhealthy response:

```
Unhealthy
```

## Separate readiness and liveness probes

In some hosting scenarios, a pair of health checks is used to distinguish two app states:

* *Readiness* indicates if the app is running normally but isn't ready to receive requests.
* *Liveness* indicates if an app has crashed and must be restarted.

Consider the following example: An app must download a large configuration file before it's ready to process requests. We don't want the app to be restarted if the initial download fails because the app can retry downloading the file several times. We use a *liveness probe* to describe the liveness of the process, no other checks are run. We also want to prevent requests from being sent to the app before the configuration file download has succeeded. We use a *readiness probe* to indicate a "not ready" state until the download succeeds and the app is ready to receive requests.

The sample app contains a health check to report the completion of long-running startup task in a [Hosted Service](xref:fundamentals/host/hosted-services). The `StartupHostedServiceHealthCheck` exposes a property, `StartupTaskCompleted`, that the hosted service can set to `true` when its long-running task is finished (`StartupHostedServiceHealthCheck.cs`):

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/3.x/HealthChecksSample/StartupHostedServiceHealthCheck.cs" id="snippet1" highlight="7-11":::

The long-running background task is started by a [Hosted Service](xref:fundamentals/host/hosted-services) (`Services/StartupHostedService`). At the conclusion of the task, `StartupHostedServiceHealthCheck.StartupTaskCompleted` is set to `true`:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/3.x/HealthChecksSample/Services/StartupHostedService.cs" id="snippet1" highlight="23":::

The health check is registered with <xref:Microsoft.Extensions.DependencyInjection.HealthChecksBuilderAddCheckExtensions.AddCheck%2A> in `Startup.ConfigureServices` along with the hosted service. Because the hosted service must set the property on the health check, the health check is also registered in the service container (`LivenessProbeStartup.cs`):

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/3.x/HealthChecksSample/LivenessProbeStartup.cs" id="snippet_ConfigureServices":::

A health check endpoint is created by calling `MapHealthChecks` in `Startup.Configure`. In the sample app, the health check endpoints are created at:

* `/health/ready` for the readiness check. The readiness check filters health checks to the health check with the `ready` tag.
* `/health/live` for the liveness check. The liveness check filters out the `StartupHostedServiceHealthCheck` by returning `false` in the [`HealthCheckOptions.Predicate`](xref:Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions.Predicate) (for more information, see [Filter health checks](#filter-health-checks))

In the following example code:

* The readiness check uses all registered checks with the 'ready' tag.
* The `Predicate` excludes all checks and returns a 200-Ok.

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions()
    {
        Predicate = (check) => check.Tags.Contains("ready"),
    });

    endpoints.MapHealthChecks("/health/live", new HealthCheckOptions()
    {
        Predicate = (_) => false
    });
}
```

To run the readiness/liveness configuration scenario using the sample app, execute the following command from the project's folder in a command shell:

```dotnetcli
dotnet run --scenario liveness
```

In a browser, visit `/health/ready` several times until 15 seconds have passed. The health check reports `Unhealthy` for the first 15 seconds. After 15 seconds, the endpoint reports `Healthy`, which reflects the completion of the long-running task by the hosted service.

This example also creates a Health Check Publisher (<xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> implementation) that runs the first readiness check with a two-second delay. For more information, see the [Health Check Publisher](#health-check-publisher) section.

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
        path: /health/ready
        port: 80
      # length of time to wait for a pod to initialize
      # after pod startup, before applying health checking
      initialDelaySeconds: 30
      timeoutSeconds: 1
    ports:
      - containerPort: 80
```

## Metric-based probe with a custom response writer

The sample app demonstrates a memory health check with a custom response writer.

`MemoryHealthCheck` reports a degraded status if the app uses more than a given threshold of memory (1 GB in the sample app). The <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult> includes Garbage Collector (GC) information for the app (`MemoryHealthCheck.cs`):

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/3.x/HealthChecksSample/MemoryHealthCheck.cs" id="snippet1":::

Register health check services with <xref:Microsoft.Extensions.DependencyInjection.HealthCheckServiceCollectionExtensions.AddHealthChecks%2A> in `Startup.ConfigureServices`. Instead of enabling the health check by passing it to <xref:Microsoft.Extensions.DependencyInjection.HealthChecksBuilderAddCheckExtensions.AddCheck%2A>, the `MemoryHealthCheck` is registered as a service. All <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck> registered services are available to the health check services and middleware. We recommend registering health check services as Singleton services.

In `CustomWriterStartup.cs` of the sample app:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/3.x/HealthChecksSample/CustomWriterStartup.cs" id="snippet_ConfigureServices" highlight="4":::

A health check endpoint is created by calling `MapHealthChecks` in `Startup.Configure`. A `WriteResponse` delegate is provided to the <xref:Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions.ResponseWriter> property to output a custom JSON response when the health check executes:

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health", new HealthCheckOptions()
    {
        ResponseWriter = WriteResponse
    });
}
```

The `WriteResponse` delegate formats the `CompositeHealthCheckResult` into a JSON object and yields JSON output for the health check response. For more information, see the [Customize output](#customize-output) section.

To run the metric-based probe with custom response writer output using the sample app, execute the following command from the project's folder in a command shell:

```dotnetcli
dotnet run --scenario writer
```

> [!NOTE]
> [`AspNetCore.Diagnostics.HealthChecks`](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks) includes metric-based health check scenarios, including disk storage and maximum value liveness checks.
>
> [`AspNetCore.Diagnostics.HealthChecks`](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks) isn't maintained or supported by Microsoft.

## Filter by port

Call `RequireHost` on `MapHealthChecks` with a URL pattern that specifies a port to restrict health check requests to the port specified. This approach is typically used in a container environment to expose a port for monitoring services.

The sample app configures the port using the [Environment Variable Configuration Provider](xref:fundamentals/configuration/index#environment-variables). The port is set in the `launchSettings.json` file and passed to the configuration provider via an environment variable. You must also configure the server to listen to requests on the management port.

To use the sample app to demonstrate management port configuration, create the `launchSettings.json` file in a `Properties` folder.

The following `Properties/launchSettings.json` file in the sample app isn't included in the sample app's project files and must be created manually:

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

Register health check services with <xref:Microsoft.Extensions.DependencyInjection.HealthCheckServiceCollectionExtensions.AddHealthChecks%2A> in `Startup.ConfigureServices`. Create a health check endpoint by calling `MapHealthChecks` in `Startup.Configure`.

In the sample app, a call to `RequireHost` on the endpoint in `Startup.Configure` specifies the management port from configuration:

```csharp
endpoints.MapHealthChecks("/health")
    .RequireHost($"*:{Configuration["ManagementPort"]}");
```

Endpoints are created in the sample app in `Startup.Configure`. In the following example code:

* The readiness check uses all registered checks with the 'ready' tag.
* The `Predicate` excludes all checks and returns a 200-Ok.

```csharp
app.UseEndpoints(endpoints =>
{
    endpoints.MapHealthChecks("/health/ready", new HealthCheckOptions()
    {
        Predicate = (check) => check.Tags.Contains("ready"),
    });

    endpoints.MapHealthChecks("/health/live", new HealthCheckOptions()
    {
        Predicate = (_) => false
    });
}
```

> [!NOTE]
> You can avoid creating the `launchSettings.json` file in the sample app by setting the management port explicitly in code. In `Program.cs` where the <xref:Microsoft.Extensions.Hosting.HostBuilder> is created, add a call to <xref:Microsoft.AspNetCore.Server.Kestrel.Core.KestrelServerOptions.ListenAnyIP%2A> and provide the app's management port endpoint. In `Configure` of `ManagementPortStartup.cs`, specify the management port with `RequireHost`:
>
> `Program.cs`:
>
> ```csharp
> return new HostBuilder()
>     .ConfigureWebHostDefaults(webBuilder =>
>     {
>         webBuilder.UseKestrel()
>             .ConfigureKestrel(serverOptions =>
>             {
>                 serverOptions.ListenAnyIP(5001);
>             })
>             .UseStartup(startupType);
>     })
>     .Build();
> ```
>
> `ManagementPortStartup.cs`:
>
> ```csharp
> app.UseEndpoints(endpoints =>
> {
>     endpoints.MapHealthChecks("/health").RequireHost("*:5001");
> });
> ```

To run the management port configuration scenario using the sample app, execute the following command from the project's folder in a command shell:

```dotnetcli
dotnet run --scenario port
```

## Distribute a health check library

To distribute a health check as a library:

1. Write a health check that implements the <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheck> interface as a standalone class. The class can rely on [dependency injection (DI)](xref:fundamentals/dependency-injection), type activation, and [named options](xref:fundamentals/configuration/options) to access configuration data.

   In the health checks logic of `CheckHealthAsync`:

   * `data1` and `data2` are used in the method to run the probe's health check logic.
   * `AccessViolationException` is handled.

   When an <xref:System.AccessViolationException> occurs, the <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckRegistration.FailureStatus> is returned with the <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckResult> to allow users to configure the health checks failure status.

   ```csharp
   using System;
   using System.Threading;
   using System.Threading.Tasks;
   using Microsoft.Extensions.Diagnostics.HealthChecks;

   namespace SampleApp
   {
       public class ExampleHealthCheck : IHealthCheck
       {
           private readonly string _data1;
           private readonly int? _data2;

           public ExampleHealthCheck(string data1, int? data2)
           {
               _data1 = data1 ?? throw new ArgumentNullException(nameof(data1));
               _data2 = data2 ?? throw new ArgumentNullException(nameof(data2));
           }

           public async Task<HealthCheckResult> CheckHealthAsync(
               HealthCheckContext context, CancellationToken cancellationToken)
           {
               try
               {
                   return HealthCheckResult.Healthy();
               }
               catch (AccessViolationException ex)
               {
                   return new HealthCheckResult(
                       context.Registration.FailureStatus,
                       description: "An access violation occurred during the check.",
                       exception: ex,
                       data: null);
               }
           }
       }
   }
   ```

1. Write an extension method with parameters that the consuming app calls in its `Startup.Configure` method. In the following example, assume the following health check method signature:

   ```csharp
   ExampleHealthCheck(string, string, int )
   ```

   The preceding signature indicates that the `ExampleHealthCheck` requires additional data to process the health check probe logic. The data is provided to the delegate used to create the health check instance when the health check is registered with an extension method. In the following example, the caller specifies optional:

   * health check name (`name`). If `null`, `example_health_check` is used.
   * string data point for the health check (`data1`).
   * integer data point for the health check (`data2`). If `null`, `1` is used.
   * failure status (<xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus>). The default is `null`. If `null`, <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy?displayProperty=nameWithType> is reported for a failure status.
   * tags (`IEnumerable<string>`).

   ```csharp
   using System.Collections.Generic;
   using Microsoft.Extensions.Diagnostics.HealthChecks;

   public static class ExampleHealthCheckBuilderExtensions
   {
       const string DefaultName = "example_health_check";

       public static IHealthChecksBuilder AddExampleHealthCheck(
           this IHealthChecksBuilder builder,
           string name = default,
           string data1,
           int data2 = 1,
           HealthStatus? failureStatus = default,
           IEnumerable<string> tags = default)
       {
           return builder.Add(new HealthCheckRegistration(
               name ?? DefaultName,
               sp => new ExampleHealthCheck(data1, data2),
               failureStatus,
               tags));
       }
   }
   ```

## Health Check Publisher

When an <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> is added to the service container, the health check system periodically executes your health checks and calls `PublishAsync` with the result. This is useful in a push-based health monitoring system scenario that expects each process to call the monitoring system periodically in order to determine health.

The <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> interface has a single method:

```csharp
Task PublishAsync(HealthReport report, CancellationToken cancellationToken);
```

<xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckPublisherOptions> allow you to set:

* <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckPublisherOptions.Delay>: The initial delay applied after the app starts before executing <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> instances. The delay is applied once at startup and doesn't apply to subsequent iterations. The default value is five seconds.
* <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckPublisherOptions.Period>: The period of <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> execution. The default value is 30 seconds.
* <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckPublisherOptions.Predicate>: If <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckPublisherOptions.Predicate> is `null` (default), the health check publisher service runs all registered health checks. To run a subset of health checks, provide a function that filters the set of checks. The predicate is evaluated each period.
* <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthCheckPublisherOptions.Timeout>: The timeout for executing the health checks for all <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> instances. Use <xref:System.Threading.Timeout.InfiniteTimeSpan> to execute without a timeout. The default value is 30 seconds.

In the sample app, `ReadinessPublisher` is an <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> implementation. The health check status is logged for each check at a log level of:

* Information (<xref:Microsoft.Extensions.Logging.LoggerExtensions.LogInformation%2A>) if the health checks status is <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Healthy>.
* Error (<xref:Microsoft.Extensions.Logging.LoggerExtensions.LogError%2A>) if the status is either <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Degraded> or <xref:Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Unhealthy>.

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/3.x/HealthChecksSample/ReadinessPublisher.cs" id="snippet_ReadinessPublisher" highlight="18-27":::

In the sample app's `LivenessProbeStartup` example, the `StartupHostedService` readiness check has a two second startup delay and runs the check every 30 seconds. To activate the <xref:Microsoft.Extensions.Diagnostics.HealthChecks.IHealthCheckPublisher> implementation, the sample registers `ReadinessPublisher` as a singleton service in the [dependency injection (DI)](xref:fundamentals/dependency-injection) container:

:::code language="csharp" source="~/host-and-deploy/health-checks/samples/3.x/HealthChecksSample/LivenessProbeStartup.cs" id="snippet_ConfigureServices":::

> [!NOTE]
> [`AspNetCore.Diagnostics.HealthChecks`](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks) includes publishers for several systems, including [Application Insights](/azure/application-insights/app-insights-overview).
>
> [`AspNetCore.Diagnostics.HealthChecks`](https://github.com/Xabaril/AspNetCore.Diagnostics.HealthChecks) isn't maintained or supported by Microsoft.

## Restrict health checks with MapWhen

Use <xref:Microsoft.AspNetCore.Builder.MapWhenExtensions.MapWhen%2A> to conditionally branch the request pipeline for health check endpoints.

In the following example, `MapWhen` branches the request pipeline to activate Health Checks Middleware if a GET request is received for the `api/HealthCheck` endpoint:

```csharp
app.MapWhen(
    context => context.Request.Method == HttpMethod.Get.Method && 
        context.Request.Path.StartsWith("/api/HealthCheck"),
    builder => builder.UseHealthChecks());

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});
```

For more information, see <xref:fundamentals/middleware/index#branch-the-middleware-pipeline>.

:::moniker-end
