---
title: Troubleshoot ASP.NET Core Blazor Hybrid
author: guardrex
description: Learn how to troubleshoot issues in ASP.NET Core Blazor Hybrid with BlazorWebView logging.
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: "mvc"
ms.date: 11/14/2023
uid: blazor/hybrid/troubleshoot
---
# Troubleshoot ASP.NET Core Blazor Hybrid

<!-- UPDATE 9.0 Activate after release and INCLUDE is updated

[!INCLUDE[](~/includes/not-latest-version.md)]

-->

<xref:Microsoft.AspNetCore.Components.WebView.Maui.BlazorWebView> has built-in logging that can help you diagnose problems in your Blazor Hybrid app.

This article explains the steps to use <xref:Microsoft.AspNetCore.Components.WebView.Maui.BlazorWebView> logging:

* Enable <xref:Microsoft.AspNetCore.Components.WebView.Maui.BlazorWebView> and related components to log diagnostic information.
* Configure logging providers.
* View logger output.

## Enable `BlazorWebView` logging

Enable logging configuration during service registration. To enable maximum logging for <xref:Microsoft.AspNetCore.Components.WebView.Maui.BlazorWebView> and related components under the <xref:Microsoft.AspNetCore.Components.WebView?displayProperty=fullName> namespace, add the following code in the `Program` file:

```csharp
services.AddLogging(logging =>
{
    logging.AddFilter("Microsoft.AspNetCore.Components.WebView", LogLevel.Trace);
});
```

Alternatively, use the following code to enable maximum logging for every component that uses <xref:Microsoft.Extensions.Logging?displayProperty=fullName>:

```csharp
services.AddLogging(logging =>
{
    logging.SetMinimumLevel(LogLevel.Trace);
});
```

## Configure logging providers

After configuring components to write log information, configure where the loggers should write log information.

The **Debug** logging providers write the output [using `Debug` statements](xref:fundamentals/logging/index#debug).

To configure the **Debug** logging provider, add a reference to the [`Microsoft.Extensions.Logging.Debug`](https://www.nuget.org/packages/Microsoft.Extensions.Logging.Debug) NuGet package.

[!INCLUDE[](~/includes/package-reference.md)]

Register the provider inside the call to <xref:Microsoft.Extensions.DependencyInjection.LoggingServiceCollectionExtensions.AddLogging%2A> added in the previous step by calling the <xref:Microsoft.Extensions.Logging.DebugLoggerFactoryExtensions.AddDebug%2A> extension method:

```csharp
services.AddLogging(logging =>
{
    logging.AddFilter("Microsoft.AspNetCore.Components.WebView", LogLevel.Trace);
    logging.AddDebug();
});
```

## View logger output

When the app is run from Visual Studio with debugging enabled, the debug output appears in Visual Studio's **Output** window.

## Additional resources

* [Logging in C# and .NET](/dotnet/core/extensions/logging)
* <xref:fundamentals/logging/index#debug>
