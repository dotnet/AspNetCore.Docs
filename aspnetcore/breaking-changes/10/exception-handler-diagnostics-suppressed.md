---
title: "Breaking change: Exception diagnostics are suppressed when IExceptionHandler.TryHandleAsync returns true"
description: Learn about the breaking change in ASP.NET Core 10 where exception diagnostics are no longer recorded when IExceptionHandler.TryHandleAsync returns true.
ms.date: 08/08/2025
ms.custom: https://github.com/aspnet/Announcements/issues/524
---

# Exception diagnostics are suppressed when IExceptionHandler.TryHandleAsync returns true

The ASP.NET Core exception handler middleware no longer records diagnostics for exceptions handled by <xref:Microsoft.AspNetCore.Diagnostics.IExceptionHandler> by default.

## Version introduced

.NET 10 Preview 7

## Previous behavior

Previously, the exception handler middleware recorded diagnostics about exceptions handled by <xref:Microsoft.AspNetCore.Diagnostics.IExceptionHandler>.

The exception diagnostics are:

- Logging `UnhandledException` to <xref:Microsoft.Extensions.Logging.ILogger>.
- Writing the `Microsoft.AspNetCore.Diagnostics.HandledException` event to <xref:Microsoft.Extensions.Logging.EventSource>.
- Adding the `error.type` tag to the `http.server.request.duration` metric.

## New behavior

Starting in .NET 10, if <xref:Microsoft.AspNetCore.Diagnostics.IExceptionHandler.TryHandleAsync%2A?displayProperty=nameWithType> returns `true`, then exception diagnostics are no longer recorded by default.

## Type of breaking change

This change is a [behavioral change](/dotnet/core/compatibility/categories#behavioral-change).

## Reason for change

ASP.NET Core users have given feedback that the previous behavior was undesirable. Their <xref:Microsoft.AspNetCore.Diagnostics.IExceptionHandler> implementation reported that the exception was handled, but the error handling middleware still recorded the error in the app's telemetry.

ASP.NET Core now follows the behavior expected by users by suppressing diagnostics when <xref:Microsoft.AspNetCore.Diagnostics.IExceptionHandler> handles the exception. Configuration options are also available to customize exception diagnostics behavior if needed.

## Recommended action

If you want handled exceptions to continue to record telemetry, you can use the new `ExceptionHandlerOptions.SuppressDiagnosticsCallback` option:

```csharp
app.UseExceptionHandler(new ExceptionHandlerOptions
{
    SuppressDiagnosticsCallback = context => false;
});
```

The `context` passed to the callback includes information about the exception, the request, and whether the exception was handled. The callback returns `false` to indicate that diagnostics shouldn't be suppressed, thus restoring the previous behavior.

## Affected APIs

- <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Diagnostics.IExceptionHandler?displayProperty=fullName>
