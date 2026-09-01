---
title: ASP.NET Core built-in diagnostics metrics
ai-usage: ai-assisted
author: guardrex
description: Learn about built-in diagnostics metrics for ASP.NET Core apps, reported by the error handling middleware.
ms.author: wpickett
ms.date: 08/05/2026
ms.topic: reference
uid: metrics/diagnostics
---
# ASP.NET Core built-in diagnostics metrics

This article describes the built-in diagnostics metrics for ASP.NET Core produced using the <xref:System.Diagnostics.Metrics?displayProperty=nameWithType> API. These metrics report diagnostics information from the ASP.NET Core error handling middleware.

For an overview of all built-in metrics reference pages and how to read this reference, see <xref:metrics/built-in>. For information on how to collect, report, enrich, and test with ASP.NET Core metrics, see <xref:metrics/overview>.

## `Microsoft.AspNetCore.Diagnostics`

The `Microsoft.AspNetCore.Diagnostics` metrics report diagnostics information from [ASP.NET Core error handling middleware](/aspnet/core/fundamentals/error-handling):

* [`aspnetcore.diagnostics.exceptions`](#metric-aspnetcorediagnosticsexceptions)

### Metric: `aspnetcore.diagnostics.exceptions`

Name | Instrument Type | Unit (UCUM) | Description
--- | --- | --- | ---
[`aspnetcore.diagnostics.exceptions`](https://opentelemetry.io/docs/specs/semconv/dotnet/dotnet-aspnetcore-metrics/#metric-aspnetcorediagnosticsexceptions) | Counter | `{exception}` | Number of exceptions caught by exception handling middleware.

Attribute | Type | Description | Examples | Presence
--- | --- | --- | --- | ---
`aspnetcore.diagnostics.exception.result` | string | ASP.NET Core exception middleware handling result. | `handled`; `unhandled` | Always
`aspnetcore.diagnostics.handler.type` | string | Full type name of the [`IExceptionHandler`](/dotnet/api/microsoft.aspnetcore.diagnostics.iexceptionhandler) implementation that handled the exception. | `Contoso.MyHandler` | If the exception was handled by this handler.
`exception.type` | string | The full name of exception type. | `System.OperationCanceledException`; `Contoso.MyException` | Always

## Additional resources

* <xref:metrics/built-in>
* <xref:metrics/http>
* <xref:metrics/blazor>
* <xref:metrics/security>
* <xref:metrics/overview>
