---
title: ASP.NET Core metrics
description: Metrics for ASP.NET Core apps
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-8.0'
ms.date: 6/30/2023
ms.topic: article
ms.prod: aspnet-core
uid: log-mon/metrics
---

# ASP.NET Core metrics

Metrics are numerical measurements reported over time. They are typically used to monitor the health of an app and generate alerts. For example, a web service might track how many:

* Requests it received per second.
* Milliseconds it took to respond.
* Responses sent an error.

These metrics can be reported to a monitoring system at regular intervals. If the web service is intended to respond to requests within 400 ms and starts responding in 600 ms, the monitoring system can notify engineers that the app response is slower than normal.

## Using metrics

There are two parts to using metrics in a .NET app:

* **Instrumentation:** Code in .NET libraries takes measurements and associates these measurements with a metric name.
* **Collection:** A .NET app configures named metrics to be transmitted from the app for external storage and analysis. Some tools may perform configuration outside the app using configuration files or a UI tool.

Instrumented code can record numeric measurements, but the measurements need to be aggregated, transmitted, and stored to create useful metrics for monitoring. The process of aggregating, transmitting, and storing data is called collection. This tutorial shows several examples of collecting metrics:

* Populating metrics in [Grafana](https://grafana.com/) with [OpenTelemetry](https://opentelemetry.io/) and [Prometheus](https://prometheus.io/).
* Viewing metrics in real time with [`dotnet-counters`](/dotnet/core/diagnostics/dotnet-counters)

## Create the starter app

Create a new ASP.NET Core app with the following command:

```dotnetcli
dotnet new web -o WebMetric
cd WebMetric
dotnet add package OpenTelemetry.Exporter.Prometheus.AspNetCore --prerelease
dotnet add package OpenTelemetry.Extensions.Hosting
```

Replace the contents of `Program.cs` with the following code:

:::code language="csharp" source="~/log-mon\metrics\samples\Program.cs":::

View metrics with dotnet-counters

## View metrics with dotnet-counters

[dotnet-counters](/dotnet/core/diagnostics/dotnet-counters) is a command-line tool that can view live metrics for .NET Core apps on demand. It doesn't require setup, making it useful for ad-hoc investigations or verifying that metric instrumentation is working. It works with both <xref:System.Diagnostics.Metrics?displayProperty=nameWithType> based APIs and [EventCounters](/dotnet/core/diagnostics/event-counters).

If the [dotnet-counters](/dotnet/core/diagnostics/dotnet-counters) tool isn't installed, run the following command:

```dotnetcli
dotnet tool update -g dotnet-counters
```

While the test app is running, launch [dotnet-counters](/dotnet/core/diagnostics/dotnet-counters).
The following command shows an example of `dotnet-counters` monitoring all metrics from the `Microsoft-AspNetCore-Server-Kestrel` meter.

```dotnetcli
dotnet-counters monitor -n WebMetric --counters Microsoft-AspNetCore-Server-Kestrel
```

Output similar to the following is displayed:

```dotnetcli
Press p to pause, r to resume, q to quit.
    Status: Running

[Microsoft-AspNetCore-Server-Kestrel]
    Connection Queue Length                                                0
    Connection Rate (Count / 1 sec)                                        0
    Current Connections                                                    1
    Current TLS Handshakes                                                 0
    Current Upgraded Requests (WebSockets)                                 0
    Failed TLS Handshakes                                                  2
    Request Queue Length                                                   0
    TLS Handshake Rate (Count / 1 sec)                                     0
    Total Connections                                                      3
    Total TLS Handshakes                                                   3                       4
```

`WebMetric>dotnet-counters list` shows all available metrics.

The following command shows the `Microsoft-AspNetCore-Server-Kestrel` meter with the `connections-per-second` and `total-connections` counters.

```dotnetcli
dotnet-counters monitor -n WebMetric --counters Microsoft-AspNetCore-Server-Kestrel[connections-per-second,total-connections]
```

For more information, see [dotnet-counters](/dotnet/core/diagnostics/dotnet-counters). To learn more about metrics in .NET, see [built-in metrics](/dotnet/core/diagnostics/available-counters).

## View metrics in Grafana with OpenTelemetry and Prometheus

### Overview