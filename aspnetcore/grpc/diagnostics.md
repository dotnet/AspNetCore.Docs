---
title: Logging and diagnostics in gRPC on .NET
author: jamesnk
description: Learn how to gather diagnostics from your gRPC app on .NET.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 10/01/2021
uid: grpc/diagnostics
---
# Logging and diagnostics in gRPC on .NET

By [James Newton-King](https://twitter.com/jamesnk)

:::moniker range=">= aspnetcore-6.0"
This article provides guidance for gathering diagnostics from a gRPC app to help troubleshoot issues. Topics covered include:

* **Logging** - Structured logs written to [.NET Core logging](xref:fundamentals/logging/index). <xref:Microsoft.Extensions.Logging.ILogger> is used by app frameworks to write logs, and by users for their own logging in an app.
* **Tracing** - Events related to an operation written using `DiaganosticSource` and `Activity`. Traces from diagnostic source are commonly used to collect app telemetry by libraries such as [Application Insights](/azure/azure-monitor/app/asp-net-core) and [OpenTelemetry](https://github.com/open-telemetry/opentelemetry-dotnet).
* **Metrics** - Representation of data measures over intervals of time, for example, requests per second. Metrics are emitted using `EventCounter` and can be observed using [dotnet-counters](/dotnet/core/diagnostics/dotnet-counters) command-line tool or with [Application Insights](/azure/azure-monitor/app/eventcounters).

## Logging

gRPC services and the gRPC client write logs using [.NET Core logging](xref:fundamentals/logging/index). Logs are a good place to start when debugging unexpected behavior in service and client apps.

### gRPC services logging

> [!WARNING]
> Server-side logs may contain sensitive information from your app. **Never** post raw logs from production apps to public forums like GitHub.

Since gRPC services are hosted on ASP.NET Core, it uses the ASP.NET Core logging system. In the default configuration, gRPC logs minimal information, but logging can be configured. See the documentation on [ASP.NET Core logging](xref:fundamentals/logging/index) for details on configuring ASP.NET Core logging.

gRPC adds logs under the `Grpc` category. To enable detailed logs from gRPC, configure the `Grpc` prefixes to the `Debug` level in the `appsettings.json` file by adding the following items to the `LogLevel` subsection in `Logging`:

[!code-json[](diagnostics/sample/logging-config.json?highlight=7)]

Logging can also be configured in `Program.cs` with `ConfigureLogging`:

[!code-csharp[](diagnostics/sample/logging-config-code.cs?highlight=5)]

When not using JSON-based configuration, set the following configuration value in the configuration system:

* `Logging:LogLevel:Grpc` = `Debug`

Check the documentation for your configuration system to determine how to specify nested configuration values. For example, when using environment variables, two `_` characters are used instead of the `:` (for example, `Logging__LogLevel__Grpc`).

We recommend using the `Debug` level when gathering detailed diagnostics for an app. The `Trace` level produces low-level diagnostics and is rarely needed to diagnose issues.

#### Sample logging output

Here is an example of console output at the `Debug` level of a gRPC service:

```console
info: Microsoft.AspNetCore.Hosting.Diagnostics[1]
      Request starting HTTP/2 POST https://localhost:5001/Greet.Greeter/SayHello application/grpc
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[0]
      Executing endpoint 'gRPC - /Greet.Greeter/SayHello'
dbug: Grpc.AspNetCore.Server.ServerCallHandler[1]
      Reading message.
info: GrpcService.GreeterService[0]
      Hello World
dbug: Grpc.AspNetCore.Server.ServerCallHandler[6]
      Sending message.
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[1]
      Executed endpoint 'gRPC - /Greet.Greeter/SayHello'
info: Microsoft.AspNetCore.Hosting.Diagnostics[2]
      Request finished in 1.4113ms 200 application/grpc
```

### Access server-side logs

How server-side logs are accessed depends on the app's environment.

#### As a console app

If you're running in a console app, the [Console logger](xref:fundamentals/logging/index#console) should be enabled by default. gRPC logs will appear in the console.

#### Other environments

If the app is deployed to another environment (for example, Docker, Kubernetes, or Windows Service), see <xref:fundamentals/logging/index> for more information on how to configure logging providers suitable for the environment.

### gRPC client logging

> [!WARNING]
> Client-side logs may contain sensitive information from your app. **Never** post raw logs from production apps to public forums like GitHub.

To get logs from the .NET client, set the `GrpcChannelOptions.LoggerFactory` property when the client's channel is created.  When calling a gRPC service from an ASP.NET Core app, the logger factory can be resolved from dependency injection (DI):

[!code-csharp[](diagnostics/sample/net-client-dependency-injection.cs?highlight=7,16)]

An alternative way to enable client logging is to use the [gRPC client factory](xref:grpc/clientfactory) to create the client. A gRPC client registered with the client factory and resolved from DI will automatically use the app's configured logging.

If the app isn't using DI, then create a new `ILoggerFactory` instance with <xref:Microsoft.Extensions.Logging.LoggerFactory.Create%2A?displayProperty=nameWithType>. To access this method, add the [Microsoft.Extensions.Logging](https://www.nuget.org/packages/microsoft.extensions.logging/) package to your app.

[!code-csharp[](diagnostics/sample/net-client-loggerfactory-create.cs?highlight=1,8)]

#### gRPC client log scopes

The gRPC client adds a [logging scope](../fundamentals/logging/index.md#log-scopes) to logs made during a gRPC call. The scope has metadata related to the gRPC call:

* **GrpcMethodType** - The gRPC method type. Possible values are names from `Grpc.Core.MethodType` enum. For example, `Unary`.
* **GrpcUri** - The relative URI of the gRPC method. For example, */greet.Greeter/SayHellos*.

#### Sample logging output

Here is an example of console output at the `Debug` level of a gRPC client:

```console
dbug: Grpc.Net.Client.Internal.GrpcCall[1]
      Starting gRPC call. Method type: 'Unary', URI: 'https://localhost:5001/Greet.Greeter/SayHello'.
dbug: Grpc.Net.Client.Internal.GrpcCall[6]
      Sending message.
dbug: Grpc.Net.Client.Internal.GrpcCall[1]
      Reading message.
dbug: Grpc.Net.Client.Internal.GrpcCall[4]
      Finished gRPC call.
```

## Tracing

gRPC services and the gRPC client provide information about gRPC calls using <xref:System.Diagnostics.DiagnosticSource> and <xref:System.Diagnostics.Activity>.

* .NET gRPC uses an activity to represent a gRPC call.
* Tracing events are written to the diagnostic source at the start and stop of the gRPC call activity.
* Tracing doesn't capture information about when messages are sent over the lifetime of gRPC streaming calls.

### gRPC service tracing

gRPC services are hosted on ASP.NET Core, which reports events about incoming HTTP requests. gRPC specific metadata is added to the existing HTTP request diagnostics that ASP.NET Core provides.

* Diagnostic source name is `Microsoft.AspNetCore`.
* Activity name is `Microsoft.AspNetCore.Hosting.HttpRequestIn`.
  * Name of the gRPC method invoked by the gRPC call is added as a tag with the name `grpc.method`.
  * Status code of the gRPC call when it is complete is added as a tag with the name `grpc.status_code`.

### gRPC client tracing

The .NET gRPC client uses `HttpClient` to make gRPC calls. Although `HttpClient` writes diagnostic events, the .NET gRPC client provides a custom diagnostic source, activity, and events so that complete information about a gRPC call can be collected.

* Diagnostic source name is `Grpc.Net.Client`.
* Activity name is `Grpc.Net.Client.GrpcOut`.
  * Name of the gRPC method invoked by the gRPC call is added as a tag with the name `grpc.method`.
  * Status code of the gRPC call when it is complete is added as a tag with the name `grpc.status_code`.

### Collecting tracing

The easiest way to use `DiagnosticSource` is to configure a telemetry library such as [Application Insights](/azure/azure-monitor/app/asp-net-core) or [OpenTelemetry](https://github.com/open-telemetry/opentelemetry-dotnet) in your app. The library will process information about gRPC calls along-side other app telemetry.

Tracing can be viewed in a managed service like Application Insights, or run as your own distributed tracing system. OpenTelemetry supports exporting tracing data to [Jaeger](https://www.jaegertracing.io/) and [Zipkin](https://zipkin.io/).

`DiagnosticSource` can consume tracing events in code using `DiagnosticListener`. For information about listening to a diagnostic source with code, see the [DiagnosticSource user's guide](https://github.com/dotnet/corefx/blob/d3942d4671919edb0cca6ddc1840190f524a809d/src/System.Diagnostics.DiagnosticSource/src/DiagnosticSourceUsersGuide.md#consuming-data-with-diagnosticlistener).

> [!NOTE]
> Telemetry libraries do not capture gRPC specific `Grpc.Net.Client.GrpcOut` telemetry currently. Work to improve telemetry libraries capturing this tracing is ongoing.

## Metrics

Metrics is a representation of data measures over intervals of time, for example, requests per second. Metrics data allows observation of the state of an app at a high level. .NET gRPC metrics are emitted using `EventCounter`.

### gRPC service metrics

gRPC server metrics are reported on `Grpc.AspNetCore.Server` event source.

| Name                      | Description                   |
| --------------------------|-------------------------------|
| `total-calls`             | Total Calls                   |
| `current-calls`           | Current Calls                 |
| `calls-failed`            | Total Calls Failed            |
| `calls-deadline-exceeded` | Total Calls Deadline Exceeded |
| `messages-sent`           | Total Messages Sent           |
| `messages-received`       | Total Messages Received       |
| `calls-unimplemented`     | Total Calls Unimplemented     |

ASP.NET Core also provides its own metrics on `Microsoft.AspNetCore.Hosting` event source.

### gRPC client metrics

gRPC client metrics are reported on `Grpc.Net.Client` event source.

| Name                      | Description                   |
| --------------------------|-------------------------------|
| `total-calls`             | Total Calls                   |
| `current-calls`           | Current Calls                 |
| `calls-failed`            | Total Calls Failed            |
| `calls-deadline-exceeded` | Total Calls Deadline Exceeded |
| `messages-sent`           | Total Messages Sent           |
| `messages-received`       | Total Messages Received       |

### Observe metrics

[dotnet-counters](/dotnet/core/diagnostics/dotnet-counters) is a performance monitoring tool for ad-hoc health monitoring and first-level performance investigation. Monitor a .NET app with either `Grpc.AspNetCore.Server` or `Grpc.Net.Client` as the provider name.

```console
> dotnet-counters monitor --process-id 1902 Grpc.AspNetCore.Server

Press p to pause, r to resume, q to quit.
    Status: Running
[Grpc.AspNetCore.Server]
    Total Calls                                 300
    Current Calls                               5
    Total Calls Failed                          0
    Total Calls Deadline Exceeded               0
    Total Messages Sent                         295
    Total Messages Received                     300
    Total Calls Unimplemented                   0
```

Another way to observe gRPC metrics is to capture counter data using Application Insights's [Microsoft.ApplicationInsights.EventCounterCollector package](/azure/azure-monitor/app/eventcounters). Once setup, Application Insights collects common .NET counters at runtime. gRPC's counters are not collected by default, but App Insights can be [customized to include additional counters](/azure/azure-monitor/app/eventcounters#customizing-counters-to-be-collected).

Specify the gRPC counters for Application Insight to collect in `Startup.cs`:

```csharp
    using Microsoft.ApplicationInsights.Extensibility.EventCounterCollector;

    public void ConfigureServices(IServiceCollection services)
    {
        //... other code...

        services.ConfigureTelemetryModule<EventCounterCollectionModule>(
            (module, o) =>
            {
                // Configure App Insights to collect gRPC counters gRPC services hosted in an ASP.NET Core app
                module.Counters.Add(new EventCounterCollectionRequest("Grpc.AspNetCore.Server", "current-calls"));
                module.Counters.Add(new EventCounterCollectionRequest("Grpc.AspNetCore.Server", "total-calls"));
                module.Counters.Add(new EventCounterCollectionRequest("Grpc.AspNetCore.Server", "calls-failed"));
            }
        );
    }
```

## Additional resources

* <xref:fundamentals/logging/index>
* <xref:grpc/configuration>
* <xref:grpc/clientfactory>

:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-6.0"
This article provides guidance for gathering diagnostics from a gRPC app to help troubleshoot issues. Topics covered include:

* **Logging** - Structured logs written to [.NET Core logging](xref:fundamentals/logging/index). <xref:Microsoft.Extensions.Logging.ILogger> is used by app frameworks to write logs, and by users for their own logging in an app.
* **Tracing** - Events related to an operation written using `DiaganosticSource` and `Activity`. Traces from diagnostic source are commonly used to collect app telemetry by libraries such as [Application Insights](/azure/azure-monitor/app/asp-net-core) and [OpenTelemetry](https://github.com/open-telemetry/opentelemetry-dotnet).
* **Metrics** - Representation of data measures over intervals of time, for example, requests per second. Metrics are emitted using `EventCounter` and can be observed using [dotnet-counters](/dotnet/core/diagnostics/dotnet-counters) command line tool or with [Application Insights](/azure/azure-monitor/app/eventcounters).

## Logging

gRPC services and the gRPC client write logs using [.NET Core logging](xref:fundamentals/logging/index). Logs are a good place to start when debugging unexpected behavior in service and client apps.

### gRPC services logging

> [!WARNING]
> Server-side logs may contain sensitive information from your app. **Never** post raw logs from production apps to public forums like GitHub.

Since gRPC services are hosted on ASP.NET Core, it uses the ASP.NET Core logging system. In the default configuration, gRPC logs minimal information, but logging can be configured. See the documentation on [ASP.NET Core logging](xref:fundamentals/logging/index) for details on configuring ASP.NET Core logging.

gRPC adds logs under the `Grpc` category. To enable detailed logs from gRPC, configure the `Grpc` prefixes to the `Debug` level in your `appsettings.json` file by adding the following items to the `LogLevel` subsection in `Logging`:

[!code-json[](diagnostics/sample/logging-config.json?highlight=7)]

You can also configure this in `Startup.cs` with `ConfigureLogging`:

[!code-csharp[](diagnostics/sample/logging-config-code.cs?highlight=5)]

If you aren't using JSON-based configuration, set the following configuration value in your configuration system:

* `Logging:LogLevel:Grpc` = `Debug`

Check the documentation for your configuration system to determine how to specify nested configuration values. For example, when using environment variables, two `_` characters are used instead of the `:` (for example, `Logging__LogLevel__Grpc`).

We recommend using the `Debug` level when gathering detailed diagnostics for an app. The `Trace` level produces low-level diagnostics and is rarely needed to diagnose issues.

#### Sample logging output

Here is an example of console output at the `Debug` level of a gRPC service:

```console
info: Microsoft.AspNetCore.Hosting.Diagnostics[1]
      Request starting HTTP/2 POST https://localhost:5001/Greet.Greeter/SayHello application/grpc
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[0]
      Executing endpoint 'gRPC - /Greet.Greeter/SayHello'
dbug: Grpc.AspNetCore.Server.ServerCallHandler[1]
      Reading message.
info: GrpcService.GreeterService[0]
      Hello World
dbug: Grpc.AspNetCore.Server.ServerCallHandler[6]
      Sending message.
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[1]
      Executed endpoint 'gRPC - /Greet.Greeter/SayHello'
info: Microsoft.AspNetCore.Hosting.Diagnostics[2]
      Request finished in 1.4113ms 200 application/grpc
```

### Access server-side logs

How you access server-side logs depends on the environment in which you're running.

#### As a console app

If you're running in a console app, the [Console logger](xref:fundamentals/logging/index#console) should be enabled by default. gRPC logs will appear in the console.

#### Other environments

If the app is deployed to another environment (for example, Docker, Kubernetes, or Windows Service), see <xref:fundamentals/logging/index> for more information on how to configure logging providers suitable for the environment.

### gRPC client logging

> [!WARNING]
> Client-side logs may contain sensitive information from your app. **Never** post raw logs from production apps to public forums like GitHub.

To get logs from the .NET client, set the `GrpcChannelOptions.LoggerFactory` property when the client's channel is created.  When calling a gRPC service from an ASP.NET Core app, the logger factory can be resolved from dependency injection (DI):

[!code-csharp[](diagnostics/sample/net-client-dependency-injection.cs?highlight=7,16)]

An alternative way to enable client logging is to use the [gRPC client factory](xref:grpc/clientfactory) to create the client. A gRPC client registered with the client factory and resolved from DI will automatically use the app's configured logging.

If your app isn't using DI, then you can create a new `ILoggerFactory` instance with <xref:Microsoft.Extensions.Logging.LoggerFactory.Create%2A?displayProperty=nameWithType>. To access this method, add the [Microsoft.Extensions.Logging](https://www.nuget.org/packages/microsoft.extensions.logging/) package to your app.

[!code-csharp[](diagnostics/sample/net-client-loggerfactory-create.cs?highlight=1,8)]

#### gRPC client log scopes

The gRPC client adds a [logging scope](../fundamentals/logging/index.md#log-scopes) to logs made during a gRPC call. The scope has metadata related to the gRPC call:

* **GrpcMethodType** - The gRPC method type. Possible values are names from `Grpc.Core.MethodType` enum. For example, `Unary`.
* **GrpcUri** - The relative URI of the gRPC method. For example, */greet.Greeter/SayHellos*.

#### Sample logging output

Here is an example of console output at the `Debug` level of a gRPC client:

```console
dbug: Grpc.Net.Client.Internal.GrpcCall[1]
      Starting gRPC call. Method type: 'Unary', URI: 'https://localhost:5001/Greet.Greeter/SayHello'.
dbug: Grpc.Net.Client.Internal.GrpcCall[6]
      Sending message.
dbug: Grpc.Net.Client.Internal.GrpcCall[1]
      Reading message.
dbug: Grpc.Net.Client.Internal.GrpcCall[4]
      Finished gRPC call.
```

## Tracing

gRPC services and the gRPC client provide information about gRPC calls using <xref:System.Diagnostics.DiagnosticSource> and <xref:System.Diagnostics.Activity>.

* .NET gRPC uses an activity to represent a gRPC call.
* Tracing events are written to the diagnostic source at the start and stop of the gRPC call activity.
* Tracing doesn't capture information about when messages are sent over the lifetime of gRPC streaming calls.

### gRPC service tracing

gRPC services are hosted on ASP.NET Core, which reports events about incoming HTTP requests. gRPC specific metadata is added to the existing HTTP request diagnostics that ASP.NET Core provides.

* Diagnostic source name is `Microsoft.AspNetCore`.
* Activity name is `Microsoft.AspNetCore.Hosting.HttpRequestIn`.
  * Name of the gRPC method invoked by the gRPC call is added as a tag with the name `grpc.method`.
  * Status code of the gRPC call when it is complete is added as a tag with the name `grpc.status_code`.

### gRPC client tracing

The .NET gRPC client uses `HttpClient` to make gRPC calls. Although `HttpClient` writes diagnostic events, the .NET gRPC client provides a custom diagnostic source, activity, and events so that complete information about a gRPC call can be collected.

* Diagnostic source name is `Grpc.Net.Client`.
* Activity name is `Grpc.Net.Client.GrpcOut`.
  * Name of the gRPC method invoked by the gRPC call is added as a tag with the name `grpc.method`.
  * Status code of the gRPC call when it is complete is added as a tag with the name `grpc.status_code`.

### Collecting tracing

The easiest way to use `DiagnosticSource` is to configure a telemetry library such as [Application Insights](/azure/azure-monitor/app/asp-net-core) or [OpenTelemetry](https://github.com/open-telemetry/opentelemetry-dotnet) in your app. The library will process information about gRPC calls along-side other app telemetry.

Tracing can be viewed in a managed service like Application Insights, or you can choose to run your own distributed tracing system. OpenTelemetry supports exporting tracing data to [Jaeger](https://www.jaegertracing.io/) and [Zipkin](https://zipkin.io/).

`DiagnosticSource` can consume tracing events in code using `DiagnosticListener`. For information about listening to a diagnostic source with code, see the [DiagnosticSource user's guide](https://github.com/dotnet/corefx/blob/d3942d4671919edb0cca6ddc1840190f524a809d/src/System.Diagnostics.DiagnosticSource/src/DiagnosticSourceUsersGuide.md#consuming-data-with-diagnosticlistener).

> [!NOTE]
> Telemetry libraries do not capture gRPC specific `Grpc.Net.Client.GrpcOut` telemetry currently. Work to improve telemetry libraries capturing this tracing is ongoing.

## Metrics

Metrics is a representation of data measures over intervals of time, for example, requests per second. Metrics data allows observation of the state of an app at a high level. .NET gRPC metrics are emitted using `EventCounter`.

### gRPC service metrics

gRPC server metrics are reported on `Grpc.AspNetCore.Server` event source.

| Name                      | Description                   |
| --------------------------|-------------------------------|
| `total-calls`             | Total Calls                   |
| `current-calls`           | Current Calls                 |
| `calls-failed`            | Total Calls Failed            |
| `calls-deadline-exceeded` | Total Calls Deadline Exceeded |
| `messages-sent`           | Total Messages Sent           |
| `messages-received`       | Total Messages Received       |
| `calls-unimplemented`     | Total Calls Unimplemented     |

ASP.NET Core also provides its own metrics on `Microsoft.AspNetCore.Hosting` event source.

### gRPC client metrics

gRPC client metrics are reported on `Grpc.Net.Client` event source.

| Name                      | Description                   |
| --------------------------|-------------------------------|
| `total-calls`             | Total Calls                   |
| `current-calls`           | Current Calls                 |
| `calls-failed`            | Total Calls Failed            |
| `calls-deadline-exceeded` | Total Calls Deadline Exceeded |
| `messages-sent`           | Total Messages Sent           |
| `messages-received`       | Total Messages Received       |

### Observe metrics

[dotnet-counters](/dotnet/core/diagnostics/dotnet-counters) is a performance monitoring tool for ad-hoc health monitoring and first-level performance investigation. Monitor a .NET app with either `Grpc.AspNetCore.Server` or `Grpc.Net.Client` as the provider name.

```console
> dotnet-counters monitor --process-id 1902 Grpc.AspNetCore.Server

Press p to pause, r to resume, q to quit.
    Status: Running
[Grpc.AspNetCore.Server]
    Total Calls                                 300
    Current Calls                               5
    Total Calls Failed                          0
    Total Calls Deadline Exceeded               0
    Total Messages Sent                         295
    Total Messages Received                     300
    Total Calls Unimplemented                   0
```

Another way to observe gRPC metrics is to capture counter data using Application Insights's [Microsoft.ApplicationInsights.EventCounterCollector package](/azure/azure-monitor/app/eventcounters). Once setup, Application Insights collects common .NET counters at runtime. gRPC's counters are not collected by default, but App Insights can be [customized to include additional counters](/azure/azure-monitor/app/eventcounters#customizing-counters-to-be-collected).

Specify the gRPC counters for Application Insight to collect in `Startup.cs`:

```csharp
    using Microsoft.ApplicationInsights.Extensibility.EventCounterCollector;

    public void ConfigureServices(IServiceCollection services)
    {
        //... other code...

        services.ConfigureTelemetryModule<EventCounterCollectionModule>(
            (module, o) =>
            {
                // Configure App Insights to collect gRPC counters gRPC services hosted in an ASP.NET Core app
                module.Counters.Add(new EventCounterCollectionRequest("Grpc.AspNetCore.Server", "current-calls"));
                module.Counters.Add(new EventCounterCollectionRequest("Grpc.AspNetCore.Server", "total-calls"));
                module.Counters.Add(new EventCounterCollectionRequest("Grpc.AspNetCore.Server", "calls-failed"));
            }
        );
    }
```

## Additional resources

* <xref:fundamentals/logging/index>
* <xref:grpc/configuration>
* <xref:grpc/clientfactory>

:::moniker-end
