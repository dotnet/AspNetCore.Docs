---
title: ASP.NET Core built-in Blazor (Components) metrics
ai-usage: ai-assisted
author: guardrex
description: Learn about built-in Blazor (Components) metrics for ASP.NET Core apps, including component, lifecycle, and server circuit metrics.
monikerRange: '>= aspnetcore-10.0'
ms.author: wpickett
ms.date: 08/05/2026
ms.topic: reference
uid: log-mon/metrics/built-in-components
---
# ASP.NET Core built-in Blazor (Components) metrics

This article describes the built-in Blazor (Components) metrics for ASP.NET Core produced using the <xref:System.Diagnostics.Metrics?displayProperty=nameWithType> API. These metrics cover Razor component route changes and browser events, component lifecycle events, and server-side Blazor circuits. They're available in ASP.NET Core 10.0 or later.

For an overview of all built-in metrics reference pages and how to read this reference, see <xref:log-mon/metrics/built-in>. For information on how to collect, report, enrich, and test with ASP.NET Core metrics, see <xref:log-mon/metrics/metrics>.

## `Microsoft.AspNetCore.Components`

The `Microsoft.AspNetCore.Components` metrics report information on Razor component route changes and browser events:

* [`aspnetcore.components.navigation`](#metric-aspnetcorecomponentsnavigation)
* [`aspnetcore.components.event_handler`](#metric-aspnetcorecomponentsevent_handler)

### Metric: `aspnetcore.components.navigation`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.components.navigation`<!--](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-http-metrics/#metric-aspnetcorecomponentsnavigation)--> | Counter | `{route}` | Tracks the total number of route changes in the app.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.components.type` | string | Component navigated to. | `TestComponent` | Always
`aspnetcore.components.route` | string | The component's route. | `/test-route` | Always
`error.type` | string | The full name of exception type. | `System.InvalidOperationException`; `Contoso.MyException` | If an exception is thrown.

Usage: How many different Blazor pages did users visit?

### Metric: `aspnetcore.components.event_handler`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.components.event_handler`<!--](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-http-metrics/#metric-aspnetcorecomponentsevent_handler)--> | Histogram | `s` | Measures the duration of processing browser events, including business logic of the component, excluding the duration of child component event handling.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.components.type` | string | Component type handling the event. | `TestComponent` | Always
`aspnetcore.components.method` | string | C# method handling the event. | `OnClick` | Always
`aspnetcore.components.attribute.name` | string | Component attribute name handling the event. | `onclick` | Always
`error.type` | string | The full name of exception type. | `System.InvalidOperationException`; `Contoso.MyException` | If an exception is thrown.

Usage:

* Which component's click event handler is slow?
* Which buttons are selected often?

## `Microsoft.AspNetCore.Components.Lifecycle`

The `Microsoft.AspNetCore.Components.Lifecycle` metrics report information on Razor component lifecycle events:

* [`aspnetcore.components.update_parameters`](#metric-aspnetcorecomponentsupdate_parameters)
* [`aspnetcore.components.render_diff`](#metric-aspnetcorecomponentsrender_diff)

### Metric: `aspnetcore.components.update_parameters`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.components.update_parameters`<!--](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-http-metrics/#metric-aspnetcorecomponentsupdate_parameters)--> | Histogram | `s` | Measures the duration of processing component parameters, including business logic.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.components.type` | string | Component type handling the event. | `TestComponent` | Always
`error.type` | string | The full name of exception type. | `System.InvalidOperationException`; `Contoso.MyException` | If an exception is thrown.

Usage:

* Which components are slow to update?
* Which components are updated often?

### Metric: `aspnetcore.components.render_diff`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.components.render_diff`<!--](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-http-metrics/#metric-aspnetcorecomponentsrender_diff)--> | Histogram | `s` | Tracks the duration of rendering batches.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.components.diff.length` | int | The length of the render diff/size of the batch (bucketed). | 50 | Always
`error.type` | string | The full name of exception type. | `System.InvalidOperationException`; `Contoso.MyException` | If an exception is thrown.

Usage:

* Is server rendering slow?
* Do I render diffs that are too large? (network bandwidth, DOM update)

## `Microsoft.AspNetCore.Components.Server.Circuits`

The `Microsoft.AspNetCore.Components.Server.Circuits` metrics report information on server-side Blazor circuits in Blazor Server and Blazor Web Apps:

* [`aspnetcore.components.circuit.active`](#metric-aspnetcorecomponentscircuitactive)
* [`aspnetcore.components.circuit.connected`](#metric-aspnetcorecomponentscircuitconnected)
* [`aspnetcore.components.circuit.duration`](#metric-aspnetcorecomponentscircuitduration)

### Metric: `aspnetcore.components.circuit.active`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.components.circuit.active`<!--](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-http-metrics/#metric-aspnetcorecomponentscircuitactive)--> | UpDownCounter | `{circuit}` | Shows the number of active circuits currently in memory.

Usage: How much memory does the session state hold?

### Metric: `aspnetcore.components.circuit.connected`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.components.circuit.connected`<!--](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-http-metrics/#metric-aspnetcorecomponentscircuitconnected)--> | UpDownCounter | `{circuit}` | Tracks the number of circuits connected to clients.

Usage: How many SignalR connections are open?

### Metric: `aspnetcore.components.circuit.duration`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
`aspnetcore.components.circuit.duration`<!--](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-http-metrics/#metric-aspnetcorecomponentscircuitduration)--> | Histogram | `s` | Measures circuit lifetime duration and provides total circuit count.

Usage:

* How many sessions processed?
* How long do users keep the session/tab open?

## See also

* <xref:log-mon/metrics/built-in>
* <xref:log-mon/metrics/built-in-http>
* <xref:log-mon/metrics/built-in-diagnostics>
* <xref:log-mon/metrics/built-in-security>
* <xref:log-mon/metrics/metrics>
