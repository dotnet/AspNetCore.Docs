---
title: ASP.NET Core built-in diagnostics metrics
ai-usage: ai-assisted
description: Learn about built-in diagnostics metrics for ASP.NET Core apps, reported by the error handling middleware.
ms.date: 08/05/2026
ms.topic: reference
---
# ASP.NET Core built-in diagnostics metrics

This article describes the built-in diagnostics metrics for ASP.NET Core produced using the <xref:System.Diagnostics.Metrics?displayProperty=nameWithType> API. These metrics report diagnostics information from the ASP.NET Core error handling middleware.

For an overview of all built-in metrics reference pages and how to read this reference, see [ASP.NET Core built-in metrics](built-in.md). For information on how to collect, report, enrich, and test with ASP.NET Core metrics, see [ASP.NET Core metrics](overview.md).

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

## Related content

* [ASP.NET Core built-in metrics](built-in.md)
* [ASP.NET Core built-in HTTP metrics](http.md)
* [ASP.NET Core built-in Blazor (Razor components) metrics](blazor.md)
* [ASP.NET Core built-in authentication and authorization metrics](security.md)
* [ASP.NET Core metrics](overview.md)
