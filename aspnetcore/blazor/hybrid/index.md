---
title: ASP.NET Core Blazor Hybrid
author: guardrex
description: Explore ASP.NET Core Blazor Hybrid, a way to build interactive client-side web UI with .NET in an ASP.NET Core app.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: "mvc"
ms.date: 02/10/2021
uid: blazor/hybrid/index
---
# ASP.NET Core Blazor Hybrid

This article explains ASP.NET Core Blazor Hybrid, a way to build interactive client-side web UI with .NET in an ASP.NET Core app.

Use *Blazor Hybrid* to blend desktop and mobile native client frameworks with .NET and Blazor.

In a Blazor Hybrid app, [Razor components](xref:blazor/components/index) run natively on the device. Components render to an embedded Web View control through a local interop channel. Components don't run in the browser, and WebAssembly isn't involved. Razor components load and execute code quickly, and components have full access to the native capabilities of the device through the .NET platform.

Blazor Hybrid articles cover subjects pertaining to integrating [Razor components](xref:blazor/components/index) into native client frameworks.

## Blazor Hybrid apps with .NET MAUI

Blazor Hybrid support is built into the [.NET Multi-platform App UI (.NET MAUI)](/dotnet/maui/what-is-maui) framework. .NET MAUI includes the `BlazorWebView` control that permits rendering [Razor components](xref:blazor/components/index) into an embedded Web View. By using .NET MAUI and Blazor together, you can reuse one set of web UI components across mobile, desktop, and web.

## Blazor Hybrid apps with WPF and Windows Forms

Blazor Hybrid apps can be built with [Windows Presentation Foundation (WPF)](/dotnet/desktop/wpf/overview/) and [Windows Forms](/dotnet/desktop/winforms/overview/). Blazor provides `BlazorWebView` controls for both of these frameworks. Razor components run natively in the Windows desktop and render to an embedded Web View. Using Blazor in WPF and Windows Forms enables you to add new UI to your existing Windows desktop apps that can be reused across platforms with .NET MAUI or on the web.

## Web View configuration

Blazor Hybrid exposes the underlying Web View configuration for different platforms through events of the `BlazorWebView` control:

* `BlazorWebViewInitializing` provides access to the settings used to create the Web View on each platform, if settings are available.
* `BlazorWebViewInitialized` provides access to the Web View to allow further configuration of the settings.

Use the preferred patterns on each platform to attach event handlers to the events to execute your custom code.

## Additional resources

* <xref:blazor/hybrid/tutorials/index>
* [.NET Multi-platform App UI (.NET MAUI)](/dotnet/maui/what-is-maui)
* [Windows Presentation Foundation (WPF)](/dotnet/desktop/wpf/overview/)
* [Windows Forms](/dotnet/desktop/winforms/overview/)
