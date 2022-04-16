---
title: ASP.NET Core Blazor Hybrid
author: guardrex
description: Explore ASP.NET Core Blazor Hybrid, a way to build interactive client-side web UI with .NET in an ASP.NET Core app.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: "mvc"
ms.date: 02/10/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/hybrid/index
---
# ASP.NET Core Blazor Hybrid

This article explains ASP.NET Core Blazor Hybrid, a way to build interactive client-side web UI with .NET in an ASP.NET Core app.

Use *Blazor Hybrid* to blend desktop and mobile native client frameworks with .NET and Blazor.

In a Blazor Hybrid app, [Razor components](xref:blazor/components/index) run natively on the device. Components render to an embedded :::no-loc text="Web View"::: control through a local interop channel. Components don't run in the browser, and WebAssembly isn't involved. Razor components load and execute code quickly, and components have full access to the native capabilities of the device through the .NET platform.

Blazor Hybrid articles cover subjects pertaining to integrating [Razor components](xref:blazor/components/index) into native client frameworks.

[!INCLUDE[](~/blazor/includes/blazor-hybrid-preview-notice.md)]

## Blazor Hybrid apps with .NET MAUI

Blazor Hybrid support is built into the [.NET Multi-platform App UI (.NET MAUI)](/dotnet/maui/what-is-maui) framework. .NET MAUI includes the `BlazorWebView` control that permits rendering [Razor components](xref:blazor/components/index) into an embedded :::no-loc text="Web View":::. By using .NET MAUI and Blazor together, you can reuse one set of web UI components across mobile, desktop, and web.

## Blazor Hybrid apps with WPF and Windows Forms

Blazor Hybrid apps can be built with [Windows Presentation Foundation (WPF)](/dotnet/desktop/wpf/overview/) and [Windows Forms](/dotnet/desktop/winforms/overview/). Blazor provides `BlazorWebView` controls for both of these frameworks. Razor components run natively in the Windows desktop and render to an embedded :::no-loc text="Web View":::. Using Blazor in WPF and Windows Forms enables you to add new UI to your existing Windows desktop apps that can be reused across platforms with .NET MAUI or on the web.

## Additional resources

* <xref:blazor/hybrid/tutorials/index>
* [.NET Multi-platform App UI (.NET MAUI)](/dotnet/maui/what-is-maui)
* [Windows Presentation Foundation (WPF)](/dotnet/desktop/wpf/overview/)
* [Windows Forms](/dotnet/desktop/winforms/overview/)
