---
title: Reuse Razor components in ASP.NET Core Blazor Hybrid apps
author: guardrex
description: Learn how to author and organize Razor components for the web and and Web Views in Blazor Hybrid apps.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: "mvc"
ms.date: 05/13/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/hybrid/reuse-razor-components
---
# Reuse Razor components in ASP.NET Core Blazor Hybrid

This article explains how to author and organize Razor components for the web and and :::no-loc text="Web Views"::: in Blazor Hybrid apps.

[!INCLUDE[](~/blazor/includes/blazor-hybrid-preview-notice.md)]

## Author Razor components for the web and :::no-loc text="Web Views":::

Blazor runs in multiple environments or hosts: Blazor WebAssembly, Blazor Server, and :::no-loc text="Web Views":::. Each host has unique capabilities in the framework and in the platform that components can leverage but that can come at the cost of not working well in other hosts.

For example, Blazor WebAssembly supports synchronous interop which isn't supported in other hosts, such as Blazor Server or :::no-loc text="Web Views":::, as the communication channel between JavaScript and .NET is strictly asynchronous. Another example can be how a component in Blazor Server can access services that are only available on the server, such as an Entity Framework database context (<xref:Microsoft.EntityFrameworkCore.DbContext>). Similarly, a Razor component in a `BlazorWebView` can access functionality on the device, such as geolocation services or other native functionality offered by the platform, that Blazor Server and Blazor WebAssembly must rely upon web API interfaces to implement.

## Common patterns

In order to author components that can seamlessly work across different hosts, we need to follow some design principles to make it easier for us to adapt Razor components to each specific host:

* Shared UI code belongs in Razor class libraries (RCLs): These are designed to be containers of reusable pieces of UI across different targets.
* Platform specific functionality shouldn't exist in the RCL. Instead, the RCL should define abstractions (interfaces, base classes) that different target platforms (your web, native app, and other platforms) should provide an implementation for.
* Enhanced functionality should be opt-in. For example, it's permissable to use `IJsInProcessRuntime` in a Razor component as an optimization, but you should do so with a conditional cast with a fallback implementation that relies on the most basic and common `IJSRuntime` abstraction that all platforms support.
* As a general rule, use CSS for styling in Razor components. The most common case is for consistency in the look and feel of the app across different platforms. In places where the UI must differ across platforms, use CSS to style the differences.
* If some part of the UI requires additional or different content for a target platform, the additional or different content can be encapsulated inside a component and rendered inside the RCL using [`DynamicComponent`](xref:blazor/components/dynamiccomponent).
* Additional UI can also be provided to components via <xref:Microsoft.AspNetCore.Components.RenderFragment> instances.

### Project code organization

As much as possible, the code and static content should be inside a Razor class library (RCL). Each target platform (Blazor WebAssembly, Blazor Server, or :::no-loc text="Web View":::) references the RCL and registers on the DI container implementations specific for that platform that a component might require.

Each target platform assembly should contain only the code that is specific to that platform along with the code that helps bootstrap the app.

![Blazor WebAssembly, Blazor Server, and WebView each have a project reference for the Razor class library (RCL).](~/blazor/hybrid/reuse-razor-components/_static/diagram1.png)

### Abstract platform-specific functionality

![In a Razor class library (RCL), MapComponent injects an ILocationService service. Separately, App.Web (Blazor WebAssembly and Blazor Server projects) implement ILocationService as WebLocationService. Separately, App.Desktop (.NET MAUI, WPF, Windows Forms) implement ILocationService as DesktopLocationService.](~/blazor/hybrid/reuse-razor-components/_static/diagram2.png)

## .NET MAUI Blazor app platform-specific code

A common pattern in .NET MAUI involves having different implementations for different platforms following several patterns, such as defining partial classes with platform specific implementations. For example, see the following diagram, where partial classes for `CameraService` are implemented in each of `CameraService.Windows.cs`, `CameraService.iOS.cs`, `CameraService.Android.cs`, and `CameraService.cs`:

![Partial classes for CameraService are implemented in each of CameraService.Windows.cs, CameraService.iOS.cs, CameraService.Android.cs, and CameraService.cs.](~/blazor/hybrid/reuse-razor-components/_static/diagram3.png)

In these cases, where you want to pack the functionality in a class library that can be consumed by other apps using .NET MAUI Blazor, we recommend that you follow a similar approach to the one described above and create an abstraction for your component:

* Place the component in a Razor class library (RCL).
* From a .NET MAUI class library, reference the RCL and create your platform specific implementations.
* Within the consuming app, reference the .NET MAUI class library.

![A .NET MAUI Blazor app uses InputPhoto from a Razor class library (RCL) that it references. The .NET MAUI app also references a .NET MAUI class library. InputPhoto in the RCL injects an ICameraService interface defined in the RCL. CameraService partial class implementations for ICameraService are in the .NET MAUI class library (CameraService.Windows.cs, CameraService.iOS.cs, CameraService.Android.cs), which references the RCL.](~/blazor/hybrid/reuse-razor-components/_static/diagram4.png)

## Additional resources

* .NET MAUI Blazor podcast sample app
  * [Source code (`microsoft/dotnet-podcasts` GitHub repository)](https://github.com/microsoft/dotnet-podcasts)
  * [Live app](https://dotnetpodcasts.azurewebsites.net/)
