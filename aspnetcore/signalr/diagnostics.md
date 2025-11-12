---
title: Logging and diagnostics in ASP.NET Core SignalR
author: wadepickett
description: Learn how to gather diagnostics from your ASP.NET Core SignalR app.
monikerRange: '>= aspnetcore-2.1'
ms.author: wpickett
ms.custom: devx-track-csharp, signalr, linux-related-content
ms.date: 06/20/2025
uid: signalr/diagnostics
---
# Logging and diagnostics in ASP.NET Core SignalR

By [Andrew Stanton-Nurse](https://twitter.com/anurse)

This article provides guidance for gathering diagnostics from your ASP.NET Core SignalR app to help troubleshoot issues.

## Server-side logging

> [!WARNING]
> Server-side logs may contain sensitive information from your app. **Never** post raw logs from production apps to public forums like GitHub.

Since SignalR is part of ASP.NET Core, it uses the ASP.NET Core logging system. In the default configuration, SignalR logs minimal information, but the logging level can be configured. See the documentation on [ASP.NET Core logging](xref:fundamentals/logging/index) for details on configuring ASP.NET Core logging.

SignalR uses two logger categories:

* `Microsoft.AspNetCore.SignalR`: For logs related to Hub Protocols, activating Hubs, invoking methods, and other Hub-related activities.
* `Microsoft.AspNetCore.Http.Connections`: For logs related to transports, such as WebSockets, Long Polling, Server-Sent Events, and low-level SignalR infrastructure.

To enable detailed logs from SignalR, configure both of the preceding prefixes to the `Debug` level in your `appsettings.json` file by adding the following items to the `LogLevel` subsection in `Logging`:

[!code-json[](diagnostics/logging-config.json?highlight=7-8)]

The logging levels for the SignalR logger categories can also be configured in code within the `CreateWebHostBuilder` method:

[!code-csharp[](diagnostics/logging-config-code.cs?highlight=5-6)]

If you aren't using JSON-based configuration, set the following configuration values in your configuration system:

* `Logging:LogLevel:Microsoft.AspNetCore.SignalR` = `Debug`
* `Logging:LogLevel:Microsoft.AspNetCore.Http.Connections` = `Debug`

Check the documentation for your configuration system to determine how to specify nested configuration values. For example, when using environment variables, two `_` characters are used instead of the `:` (for example, `Logging__LogLevel__Microsoft.AspNetCore.SignalR`).

We recommend using the `Debug` level when gathering more detailed diagnostics for your app. The `Trace` level produces low-level diagnostics and is rarely needed to diagnose issues in your app.

## Access server-side logs

How server-side logs are accessed depends on the environment in which the app is running.

### As a console app outside IIS

If you're running in a console app, the [Console logger](xref:fundamentals/logging/index#console) should be enabled by default. SignalR logs appear in the console.

### Within IIS Express from Visual Studio

Visual Studio displays the log output in the **Output** window. Select the **ASP.NET Core Web Server** drop down option.

### Azure App Service

Enable the **Application Logging (Filesystem)** option in the **Diagnostics logs** section of the Azure App Service portal and configure the **Level** to `Verbose`. Logs should be available from the **Log streaming** service and in logs on the file system of the App Service. For more information, see [Azure log streaming](xref:fundamentals/logging/index#azure-log-streaming).

### Other environments

For more information on configuring logging providers suitable for different deployment environments, such as Docker, Kubernetes, or Windows Service, see <xref:fundamentals/logging/index>.

## JavaScript client logging

> [!WARNING]
> Client-side logs may contain sensitive information from your app. **Never** post raw logs from production apps to public forums like GitHub.

When using the JavaScript client, you can configure logging options using the `configureLogging` method on `HubConnectionBuilder`:

[!code-javascript[](diagnostics/logging-config-js.js?highlight=3)]

Disable framework logging by specifying `signalR.LogLevel.None` in the `configureLogging` method. Note that some logging is emitted directly by the browser and can't be disabled via setting the log level.

The following table shows log levels available to the JavaScript client. Setting the log level to one of these values enables logging at that level and all levels above it in the table.

| Level | Description |
| ----- | ----------- |
| `None` | No messages are logged. |
| `Critical` | Messages that indicate a failure in the entire app. |
| `Error` | Messages that indicate a failure in the current operation. |
| `Warning` | Messages that indicate a non-fatal problem. |
| `Information` | Informational messages. |
| `Debug` | Diagnostic messages useful for debugging. |
| `Trace` | Very detailed diagnostic messages designed for diagnosing specific issues. |

Once you've configured the verbosity, the logs will be written to the Browser Console (or Standard Output in a NodeJS app).

If you want to send logs to a custom logging system, you can provide a JavaScript object implementing the `ILogger` interface. The only method that needs to be implemented is `log`, which takes the level of the event and the message associated with the event. For example:

:::moniker range=">= aspnetcore-3.0"

[!code-typescript[](diagnostics/3.x/custom-logger.ts?highlight=3-7,13)]

:::moniker-end

:::moniker range="< aspnetcore-3.0"

[!code-typescript[](diagnostics/2.x/custom-logger.ts?highlight=3-7,13)]

:::moniker-end

## .NET client logging

> [!WARNING]
> Client-side logs may contain sensitive information from your app. **Never** post raw logs from production apps to public forums like GitHub.

To get logs from the .NET client, you can use the `ConfigureLogging` method on `HubConnectionBuilder`. This works the same way as the `ConfigureLogging` method on `WebHostBuilder` and `HostBuilder`. You can configure the same logging providers you use in ASP.NET Core. However, you have to manually install and enable the NuGet packages for the individual logging providers.

To add .NET client logging to a Blazor WebAssembly app, see <xref:blazor/fundamentals/logging#signalr-net-client-logging>.

### Console logging

In order to enable Console logging, add the [Microsoft.Extensions.Logging.Console](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Console) package. Then, use the `AddConsole` method to configure the console logger:

[!code-csharp[](diagnostics/net-client-console-log.cs?highlight=6)]

### Debug output window logging

Logs can be configured to go to the **Output** window in Visual Studio. Install the [Microsoft.Extensions.Logging.Debug](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Debug) package and use the `AddDebug` method:

[!code-csharp[](diagnostics/net-client-debug-log.cs?highlight=6)]

### Other logging providers

SignalR supports other logging providers such as Serilog, Seq, NLog, or any other logging system that integrates with `Microsoft.Extensions.Logging`. If your logging system provides an `ILoggerProvider`, you can register it with `AddProvider`:

[!code-csharp[](diagnostics/net-client-custom-log.cs?highlight=6)]

### Control verbosity

When logging from other places in the app, changing the default level to `Debug` may be too verbose. A Filter can be used to configure the logging level for SignalR logs. This can be done in code, in much the same way as on the server:

[!code-csharp[Controlling verbosity in .NET client](diagnostics/logging-config-client-code.cs?highlight=9-10)]

## Tracing in SignalR

SignalR hub server and the SignalR client provide information about SignalR connections and messages using <xref:System.Diagnostics.DiagnosticSource> and <xref:System.Diagnostics.Activity>. SignalR has an ActivitySource for both the hub server and client, avaialble starting with .NET 9.

An ActivitySource is a component used in distributed tracing to create and manage activities (or spans) that represent operations in your application. These activities can be used to:

* Track the flow of requests and operations across different components and services. 
* Provide valuable insights into the performance and behavior of your application.

### .NET SignalR server ActivitySource

The SignalR ActivitySource named `Microsoft.AspNetCore.SignalR.Server` emits events for hub method calls:

* Every method is its own activity, so anything that emits an activity during the hub method call is under the hub method activity.
* Hub method activities don't have a parent. This means they aren't bundled under the long-running SignalR connection.

The following example uses the [Aspire dashboard](/dotnet/aspire/fundamentals/dashboard/overview?tabs=bash#use-the-dashboard-with-aspire-projects) and the [OpenTelemetry](https://www.nuget.org/packages/OpenTelemetry.Extensions.Hosting) packages:

```xml
<PackageReference Include="OpenTelemetry.Exporter.OpenTelemetryProtocol" Version="1.9.0" />
<PackageReference Include="OpenTelemetry.Extensions.Hosting" Version="1.9.0" />
<PackageReference Include="OpenTelemetry.Instrumentation.AspNetCore" Version="1.9.0" />
```

Add the following startup code to the `Program.cs` file:

[!code-csharp[](~/signalr/diagnostics/samples/9.x/SignalRChatTraceExample/Program.cs?name=snippet_trace_signalr_server&highlight=1,10-23)]

The following example output is from the Aspire Dashboard:

:::image type="content" source="~/signalr/diagnostics/_static/9.x/signalr-activities-events.png" alt-text="Activity list for SignalR Hub method call events":::

ASP.NET Core also provides its own metrics on `Microsoft.AspNetCore.Hosting` event source.

### .NET SignalR client ActivitySource

The SignalR `ActivitySource` named `Microsoft.AspNetCore.SignalR.Client` emits events for a SignalR client:

* Hub invocations create a client span. Other SignalR clients, such as the JavaScript client, don't support tracing. This feature will be added to more clients in future releases.
* Hub invocations on the client and server support [context propagation](https://opentelemetry.io/docs/concepts/context-propagation/). Propagating the trace context enables true distributed tracing. It's now possible to see invocations flow from the client to the server and back.

Here's how these new activities look in the [Aspire dashboard](/dotnet/aspire/fundamentals/dashboard/overview?tabs=bash#standalone-mode):

![SignalR distributed tracing in Aspire dashboard](~/signalr/diagnostics/_static/9.x/signalr-distributed-tracing-aspire-dashboard.png) 

## Network traces

> [!WARNING]
> A network trace contains the full contents of every message sent by your app. **Never** post raw network traces from production apps to public forums like GitHub.

If you encounter an issue, a network trace can sometimes provide a valuable information. This is especially helpful when filing an issue on our issue tracker.

## Collect a network trace with Fiddler (preferred option)

This method works for all apps.

Fiddler is a powerful tool for collecting HTTP traces. Install it from [telerik.com/fiddler](https://www.telerik.com/fiddler), launch it, and then run your app and reproduce the issue. Fiddler is available for Windows, and there are beta versions for macOS and Linux.

If you connect using HTTPS, there are some extra steps to ensure Fiddler can decrypt the HTTPS traffic. For more information, see the [Fiddler documentation](https://docs.telerik.com/fiddler/Configure-Fiddler/Tasks/DecryptHTTPS).

After collecting the trace, export it by selecting **File** > **Save** > **All Sessions** from the menu bar

![Exporting all sessions from Fiddler](diagnostics/fiddler-export.png)

## Collect a network trace with tcpdump (macOS and Linux only)

This method works for all apps.

Raw TCP traces can be collected using tcpdump by running the following command from a command shell. You may need to be `root` or prefix the command with `sudo` if you get a permissions error:

```console
tcpdump -i [interface] -w trace.pcap
```

Replace `[interface]` with the network interface you wish to capture on. Usually, this is something like `/dev/eth0` (for a standard Ethernet interface) or `/dev/lo0` (for localhost traffic). For more information, see the `tcpdump` manual page on your host system.

## Collect a network trace in the browser

This method only works for browser-based apps.

Most browser developer tools consoles have a "Network" tab that allows network activity to be captured between the browser and the server. However, these traces don't include WebSocket and Server-Sent Event messages. When using those transports, using a tool like Fiddler or TcpDump is a better approach, as described later in this article.

### Microsoft Edge and Internet Explorer

(The instructions are the same for both Microsoft Edge and Internet Explorer)

1. Open the Dev Tools by pressing F12
1. Select the Network Tab
1. Refresh the page (if needed) and reproduce the problem
1. Select the Save icon in the toolbar to export the trace as a "HAR" file:

![The Save Icon on the Microsoft Edge Dev Tools Network Tab](diagnostics/ie-edge-har-export.png)

### Google Chrome

1. Open the Dev Tools by pressing F12
1. Select the Network Tab
1. Refresh the page (if needed) and reproduce the problem
1. Right click anywhere in the list of requests and choose "Save as HAR with content":

!["Save as HAR with Content" option in Google Chrome Dev Tools Network Tab](diagnostics/chrome-har-export.png)

### Mozilla Firefox

1. Open the Dev Tools by pressing F12
1. Select the Network Tab
1. Refresh the page (if needed) and reproduce the problem
1. Right click anywhere in the list of requests and choose "Save All As HAR"

!["Save All As HAR" option in Mozilla Firefox Dev Tools Network Tab](diagnostics/firefox-har-export.png)

## Attach diagnostics files to GitHub issues

Diagnostics files can be attached to GitHub issues by renaming them so they have a `.txt` extension and then dragging and dropping them on to the issue.

> [!NOTE]
> Please don't paste the content of log files or network traces into a GitHub issue. These logs and traces can be large, and GitHub usually truncates them.

![Dragging log files on to a GitHub issue](diagnostics/attaching-diagnostics-files.png)

## Metrics

Metrics are a representation of data measures over intervals of time. For example, requests per second. Metrics data allows observation of the state of an app at a high level. .NET gRPC metrics are emitted using <xref:System.Diagnostics.Tracing.EventCounter>.

### SignalR server metrics

SignalR server metrics are reported on the <xref:Microsoft.AspNetCore.Http.Connections> event source.

| Name                    | Description                 |
|-------------------------|-----------------------------|
| `connections-started`   | Total connections started   |
| `connections-stopped`   | Total connections stopped   |
| `connections-timed-out` | Total connections timed out |
| `current-connections`   | Current connections         |
| `connections-duration`  | Average connection duration |


### Observe metrics

[dotnet-counters](/dotnet/core/diagnostics/dotnet-counters) is a performance monitoring tool for ad-hoc health monitoring and first-level performance investigation. Monitor a .NET app with `Microsoft.AspNetCore.Http.Connections` as the provider name. For example:

```console
> dotnet-counters monitor --process-id 37016 --counters Microsoft.AspNetCore.Http.Connections

Press p to pause, r to resume, q to quit.
    Status: Running
[Microsoft.AspNetCore.Http.Connections]
    Average Connection Duration (ms)       16,040.56
    Current Connections                         1
    Total Connections Started                   8
    Total Connections Stopped                   7
    Total Connections Timed Out                 0
```

## Additional resources

* <xref:signalr/configuration>
* <xref:signalr/javascript-client>
* <xref:signalr/dotnet-client>
