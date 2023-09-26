---
title: Reuse Razor components in ASP.NET Core Blazor Hybrid apps
author: guardrex
description: Learn how to author and organize Razor components for the web and Web Views in Blazor Hybrid apps.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: "mvc"
ms.date: 11/08/2022
uid: blazor/hybrid/reuse-razor-components
---
# Reuse Razor components in ASP.NET Core Blazor Hybrid

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to author and organize Razor components for the web and :::no-loc text="Web Views"::: in Blazor Hybrid apps.

Razor components work across hosting models (Blazor WebAssembly, Blazor Server, and in the Web View of Blazor Hybrid) and across platforms (Android, iOS, and Windows). Hosting models and platforms have unique capabilities that components can leverage, but components executing across hosting models and platforms must leverage unique capabilities separately, which the following examples demonstrate:

* Blazor WebAssembly supports synchronous JavaScript (JS) interop, which isn't supported by the strictly asynchronous JS interop communication channel in Blazor Server and :::no-loc text="Web Views"::: of Blazor Hybrid apps.
* Components in a Blazor Server app can access services that are only available on the server, such as an Entity Framework database context.
* Components in a `BlazorWebView` can directly access native desktop and mobile device features, such as geolocation services. Blazor Server and Blazor WebAssembly apps must rely upon web API interfaces of apps on external servers to provide similar features.

## Design principles

In order to author Razor components that can seamlessly work across hosting models and platforms, adhere to the following design principles:

* Place shared UI code in Razor class libraries (RCLs), which are containers designed to maintain reusable pieces of UI for use across different hosting models and platforms.
* Implementations of unique features shouldn't exist in RCLs. Instead, the RCL should define abstractions (interfaces and base classes) that hosting models and platforms implement.
* Only opt-in to unique features by hosting model or platform. For example, Blazor WebAssembly supports the use of <xref:Microsoft.JSInterop.IJSInProcessRuntime> and <xref:Microsoft.JSInterop.IJSInProcessObjectReference> in a component as an optimization, but only use them with conditional casts and fallback implementations that rely on the universal <xref:Microsoft.JSInterop.IJSRuntime> and <xref:Microsoft.JSInterop.IJSObjectReference> abstractions that all hosting models and platforms support. For more information on <xref:Microsoft.JSInterop.IJSInProcessRuntime>, see <xref:blazor/js-interop/call-javascript-from-dotnet#synchronous-js-interop-in-client-side-components>. For more information on <xref:Microsoft.JSInterop.IJSInProcessObjectReference>, see <xref:blazor/js-interop/call-dotnet-from-javascript#synchronous-js-interop-in-client-side-components>.
* As a general rule, use CSS for HTML styling in components. The most common case is for consistency in the look and feel of an app. In places where UI styles must differ across hosting models or platforms, use CSS to style the differences.
* If some part of the UI requires additional or different content for a target hosting model or platform, the content can be encapsulated inside a component and rendered inside the RCL using [`DynamicComponent`](xref:blazor/components/dynamiccomponent). Additional UI can also be provided to components via <xref:Microsoft.AspNetCore.Components.RenderFragment> instances. For more information on <xref:Microsoft.AspNetCore.Components.RenderFragment>, see [Child content render fragments](xref:blazor/components/index#child-content-render-fragments) and [Render fragments for reusable rendering logic](xref:blazor/components/index#render-fragments-for-reusable-rendering-logic).

## Project code organization

As much as possible, place code and static content in Razor class libraries (RCLs). Each hosting model or platform references the RCL and registers individual implementations in the app's service collection that a Razor component might require.

Each target assembly should contain only the code that is specific to that hosting model or platform along with the code that helps bootstrap the app.

![Blazor WebAssembly, Blazor Server, and WebView each have a project reference for the Razor class library (RCL).](~/blazor/hybrid/reuse-razor-components/_static/diagram1.png)

## Use abstractions for unique features

The following example demonstrates how to use an abstraction for a geolocation service by hosting model and platform.

* In a Razor class library (RCL) used by the app to obtain geolocation data for the user's location on a map, the `MapComponent` Razor component injects an `ILocationService` service abstraction.
* `App.Web` for Blazor WebAssembly and Blazor Server projects implement `ILocationService` as `WebLocationService`, which uses web API calls to obtain geolocation data.
* `App.Desktop` for .NET MAUI, WPF, and Windows Forms, implement `ILocationService` as `DesktopLocationService`. `DesktopLocationService` uses platform-specific device features to obtain geolocation data.

![In a Razor class library (RCL), MapComponent injects an ILocationService service. Separately, App.Web (Blazor WebAssembly and Blazor Server projects) implement ILocationService as WebLocationService. Separately, App.Desktop (.NET MAUI, WPF, Windows Forms) implement ILocationService as DesktopLocationService.](~/blazor/hybrid/reuse-razor-components/_static/diagram2.png)

## .NET MAUI Blazor platform-specific code

A common pattern in .NET MAUI is to create separate implementations for different platforms, such as defining partial classes with platform-specific implementations. For example, see the following diagram, where partial classes for `CameraService` are implemented in each of `CameraService.Windows.cs`, `CameraService.iOS.cs`, `CameraService.Android.cs`, and `CameraService.cs`:

![Partial classes for CameraService are implemented in each of CameraService.Windows.cs, CameraService.iOS.cs, CameraService.Android.cs, and CameraService.cs.](~/blazor/hybrid/reuse-razor-components/_static/diagram3.png)

Where you want to pack platform-specific features into a class library that can be consumed by other apps, we recommend that you follow a similar approach to the one described in the preceding example and create an abstraction for the Razor component:

* Place the component in a Razor class library (RCL).
* From a .NET MAUI class library, reference the RCL and create the platform-specific implementations.
* Within the consuming app, reference the .NET MAUI class library.

The following example demonstrates the concepts for images in an app that organizes photographs:

* A .NET MAUI Blazor Hybrid app uses `InputPhoto` from an RCL that it references.
* The .NET MAUI app also references a .NET MAUI class library.
* `InputPhoto` in the RCL injects an `ICameraService` interface, which is defined in the RCL.
* `CameraService` partial class implementations for `ICameraService` are in the .NET MAUI class library (`CameraService.Windows.cs`, `CameraService.iOS.cs`, `CameraService.Android.cs`), which references the RCL.

![A .NET MAUI Blazor Hybrid app uses InputPhoto from a Razor class library (RCL) that it references. The .NET MAUI app also references a .NET MAUI class library. InputPhoto in the RCL injects an ICameraService interface defined in the RCL. CameraService partial class implementations for ICameraService are in the .NET MAUI class library (CameraService.Windows.cs, CameraService.iOS.cs, CameraService.Android.cs), which references the RCL.](~/blazor/hybrid/reuse-razor-components/_static/diagram4.png)

## Additional resources

* .NET MAUI Blazor podcast sample app
  * [Source code (`microsoft/dotnet-podcasts` GitHub repository)](https://github.com/microsoft/dotnet-podcasts)
  * [Live app](https://dotnetpodcasts.azurewebsites.net/)
