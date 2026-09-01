---
title: ASP.NET Core built-in metrics
ai-usage: ai-assisted
author: guardrex
description: Learn about built-in metrics for ASP.NET Core apps.
ms.author: wpickett
ms.date: 09/01/2026
ms.topic: reference
uid: metrics/built-in
---
# ASP.NET Core built-in metrics

This article is the entry point for the built-in metrics that ASP.NET Core produces using the <xref:System.Diagnostics.Metrics?displayProperty=nameWithType> API. The metrics reference is organized into focused pages by topic. Use the following pages to find the instruments, attributes, and usage guidance for each area. For a listing of metrics based on the older [EventCounters](/dotnet/core/diagnostics/event-counters) API, see [Available counters](/dotnet/core/diagnostics/available-counters).

For information on how to collect, report, enrich, and test with ASP.NET Core metrics, see <xref:metrics/overview>.

:::moniker range=">= aspnetcore-11.0"

> [!NOTE]
> Starting in .NET 11, the built-in HTTP server meters cataloged in these reference pages (most notably `Microsoft.AspNetCore.Hosting` and `Microsoft.AspNetCore.Server.Kestrel`) emit data compliant with the required parts of the [OpenTelemetry HTTP server semantic conventions](https://opentelemetry.io/docs/specs/semconv/http/). The [`OpenTelemetry.Instrumentation.AspNetCore`](https://www.nuget.org/packages/OpenTelemetry.Instrumentation.AspNetCore) package is optional for HTTP server metrics—register these meters directly with the OpenTelemetry SDK. For more information, see <xref:metrics/overview>.

:::moniker-end

## Metrics reference pages

Page | Namespaces | Example metrics
--- | --- | ---
[HTTP metrics](xref:metrics/http) | `Microsoft.AspNetCore.Hosting`, `Microsoft.AspNetCore.Routing`, `Microsoft.AspNetCore.RateLimiting`, `Microsoft.AspNetCore.HeaderParsing`, `Microsoft.AspNetCore.Server.Kestrel`, `Microsoft.AspNetCore.Http.Connections` (SignalR) | `http.server.request.duration`, `aspnetcore.routing.match_attempts`, `kestrel.active_connections`, `signalr.server.active_connections`
[Diagnostics metrics](xref:metrics/diagnostics) | `Microsoft.AspNetCore.Diagnostics` | `aspnetcore.diagnostics.exceptions`
[Blazor (Components) metrics](xref:metrics/blazor) | `Microsoft.AspNetCore.Components`, `Microsoft.AspNetCore.Components.Lifecycle`, `Microsoft.AspNetCore.Components.Server.Circuits` | `aspnetcore.components.navigation`, `aspnetcore.components.circuit.active`
[Authentication and authorization metrics](xref:metrics/security) | `Microsoft.AspNetCore.Authorization`, `Microsoft.AspNetCore.Authentication` | `aspnetcore.authorization.attempts`, `aspnetcore.authentication.challenges`

The Blazor (Components) and authentication and authorization metrics pages describe metrics available in ASP.NET Core 10.0 or later. Select ASP.NET Core 10.0 (or a later version) with the version selector to view that content.

## How metrics are grouped

Metrics are grouped by audience and topic. Because some namespaces don't map cleanly to a single topic, the following placement rules apply:

* HTTP request handling, routing, rate limiting, header parsing, the Kestrel web server, and SignalR (`Microsoft.AspNetCore.Http.Connections`) are grouped together on the HTTP metrics page, because they all relate to serving HTTP and real-time connections.
* Error handling middleware metrics are on the diagnostics metrics page.
* Blazor (Components) metrics are grouped by their component, lifecycle, and server circuit namespaces.
* Authentication, authorization, and Identity metrics are grouped together as security-related metrics.

## How to read this reference

Each metric on the reference pages is documented with the following information:

* **Name**: The metric (instrument) name.
* **Instrument Type**: The kind of instrument, such as `Counter`, `UpDownCounter`, or `Histogram`.
* **Unit (UCUM)**: The unit of measurement, expressed using the [Unified Code for Units of Measure (UCUM)](https://ucum.org/), for example `s` for seconds.
* **Attribute**: The dimensions (tags) reported with the metric.
* **Presence**: When the attribute is present, for example `Always` or only under specific conditions.
* **Usage**: Example questions the metric helps answer.

For guidance on how to collect, report, enrich, and test with these metrics, see <xref:metrics/overview>.
