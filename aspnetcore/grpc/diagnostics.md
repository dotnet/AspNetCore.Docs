---
title: Logging and diagnostics in gRPC on .NET
author: jamesnk
description: Learn how to gather diagnostics from your gRPC app on .NET.
monikerRange: '>= aspnetcore-3.0'
ms.author: jamesnk
ms.date: 09/23/2019
uid: grpc/diagnostics
---
# Logging and diagnostics in gRPC on .NET

By [James Newton-King](https://twitter.com/jamesnk)

This article provides guidance for gathering diagnostics from your gRPC app to help troubleshoot issues. Topics covered include:

* **Logging** - Structured logs written to [.NET Core logging](xref:fundamentals/logging/index). `ILogger` is also often used by apps to write logs.
* **Events** - Events with rich data payloads written using `DiaganosticSource`. Events from diagnostic source are commonly used to collect app telemetry by libraries like [Application Insights](https://docs.microsoft.com/azure/azure-monitor/app/asp-net-core) and [OpenTelemetry](https://github.com/open-telemetry/opentelemetry-dotnet).
* **Metrics** - Representation of data measures over intervals of time, e.g. requests per second. Metrics are emitted using `EventCounter` and can be observed using [dotnet-counters](https://docs.microsoft.com/dotnet/core/diagnostics/dotnet-counters) command line tool.

## Logging

gRPC services and the gRPC client write logs using [.NET Core logging](xref:fundamentals/logging/index). Logs are a good place to start when you need to debug unexpected behavior in your apps.

### gRPC services logging

> [!WARNING]
> Server-side logs may contain sensitive information from your app. **Never** post raw logs from production apps to public forums like GitHub.

Since gRPC services are hosted on ASP.NET Core, it uses the ASP.NET Core logging system. In the default configuration, gRPC logs very little information, but this can configured. See the documentation on [ASP.NET Core logging](xref:fundamentals/logging/index#configuration) for details on configuring ASP.NET Core logging.

gRPC adds logs under the `Grpc` category. To enable detailed logs from gRPC, configure the `Grpc` prefixes to the `Debug` level in your *appsettings.json* file by adding the following items to the `LogLevel` sub-section in `Logging`:

[!code-json[](diagnostics/sample/logging-config.json?highlight=7)]

You can also configure this in *Startup.cs* with `ConfigureLogging`:

[!code-csharp[](diagnostics/sample/logging-config-code.cs?highlight=5)]

If you aren't using JSON-based configuration, set the following configuration value in your configuration system:

* `Logging:LogLevel:Grpc` = `Debug`

Check the documentation for your configuration system to determine how to specify nested configuration values. For example, when using environment variables, two `_` characters are used instead of the `:` (for example, `Logging__LogLevel__Grpc`).

We recommend using the `Debug` level when gathering more detailed diagnostics for your app. The `Trace` level produces very low-level diagnostics and is rarely needed to diagnose issues in your app.

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

If you're running in a console app, the [Console logger](xref:fundamentals/logging/index#console-provider) should be enabled by default. gRPC logs will appear in the console.

#### Other environments

If the app is deployed to another environment (for example, Docker, Kubernetes, or Windows Service), see <xref:fundamentals/logging/index> for more information on how to configure logging providers suitable for the environment.

### gRPC client logging

> [!WARNING]
> Client-side logs may contain sensitive information from your app. **Never** post raw logs from production apps to public forums like GitHub.

To get logs from the .NET client, you can set the `GrpcChannelOptions.LoggerFactory` property when the client's channel is created. If you are calling a gRPC service from an ASP.NET Core app then the logger factory can be resolved from dependency injection (DI):

[!code-csharp[](diagnostics/sample/net-client-dependency-injection.cs?highlight=7,16)]

An alternative way to enable client logging is to use the [gRPC client factory](xref:grpc/clientfactory) to create the client. A gRPC client registered with the client factory and resolved from DI will automatically use the app's configured logging.

If your app isn't using DI then you can create a new `ILoggerFactory` instance with [LoggerFactory.Create](xref:Microsoft.Extensions.Logging.LoggerFactory.Create*). To access this method add the [Microsoft.Extensions.Logging](https://www.nuget.org/packages/microsoft.extensions.logging/) package to your app.

[!code-csharp[](diagnostics/sample/net-client-loggerfactory-create.cs?highlight=1,8)]

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

## Events

gRPC services and the gRPC client provide information about gRPC calls using [DiagnosticSource](https://docs.microsoft.com/dotnet/api/system.diagnostics.diagnosticsource) and [Activity](https://docs.microsoft.com/dotnet/api/system.diagnostics.activity). A start and stop event for the activity is written to the diagnostic source. These diagnostic APIs are typically used by a telemetry library you have configured your app to use to report gRPC events about your app.

### gRPC service events

gRPC services are hosted on ASP.NET Core which reports events about incoming HTTP requests. gRPC specific metadata is added to the existing HTTP request diagnostics that ASP.NET Core provides.

* Diagnostic source name is `Microsoft.AspNetCore`.
* Activity name is `Microsoft.AspNetCore.Hosting.HttpRequestIn`.
  * Name of the gRPC method invoked by the gRPC call is added as a tag with the name `grpc.method`.
  * Status code of the gRPC call when it is complete is added as a tag with the name `grpc.status_code`.

### gRPC client events

The .NET gRPC client uses `HttpClient` to make gRPC calls. Although `HttpClient` writes diagnostic events, the .NET gRPC client provides a custom diagnostic source, activity and events so that complete information about a gRPC call is reported.

* Diagnostic source name is `Grpc.Net.Client`.
* Activity name is `Grpc.Net.Client.GrpcOut`.
  * Name of the gRPC method invoked by the gRPC call is added as a tag with the name `grpc.method`.
  * Status code of the gRPC call when it is complete is added as a tag with the name `grpc.status_code`.

### Capturing events

The easist way to use `DiagnosticSource` is to configure a telemetry library such as [Application Insights](https://docs.microsoft.com/azure/azure-monitor/app/asp-net-core) or [OpenTelemetry](https://github.com/open-telemetry/opentelemetry-dotnet) in your app. The library will collect information about gRPC calls along-side other app telemetry.

You can also listen to `DiagnosticSource` events in code using `DiagnosticListener`. For information about listening to a diagnostic source with code, visit the [DiagnosticSource user's guide](https://github.com/dotnet/corefx/blob/d3942d4671919edb0cca6ddc1840190f524a809d/src/System.Diagnostics.DiagnosticSource/src/DiagnosticSourceUsersGuide.md#consuming-data-with-diagnosticlistener).

## Metrics

Metrics is a representation of data measures over intervals of time, e.g. requests per second. Metrics data allows you to observe the state of your app at a high-level. .NET gRPC metrics are emitted using `EventCounter`.

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

[dotnet-counters](https://docs.microsoft.com/dotnet/core/diagnostics/dotnet-counters) is a performance monitoring tool for ad-hoc health monitoring and first-level performance investigation. Monitor your .NET app with either `Grpc.AspNetCore.Server` or `Grpc.Net.Client` as the provider name.

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

## Additional resources

* <xref:fundamentals/logging/index>
* <xref:grpc/configuration>
* <xref:grpc/clientfactory>
