---
title: ASP.NET Core Blazor Hybrid routing and navigation
author: guardrex
description: Learn how to manage request routing and navigation in Blazor Hybrid apps.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: "mvc"
ms.date: 04/14/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/hybrid/routing
---
# ASP.NET Core Blazor Hybrid routing and navigation

This article explains how to manage request routing and navigation in Blazor Hybrid apps.

[!INCLUDE[](~/blazor/includes/blazor-hybrid-preview-notice.md)]

[!INCLUDE[](~/blazor/includes/net-maui-release-candidate-notice.md)]

Default URI request routing behavior:

* A link is *internal* if the host name and scheme match between the app's origin URI and the request URI. When the host names and schemes don't match or if the link sets `target="_blank"`, the link is considered *external*.
* If the link is internal, the link is opened in the `BlazorWebView` by the app.
* If the link is external, the link is opened by an app determined by the device based on the device's registered handler for the link's scheme.
* For internal links that appear to request a file because the last segment of the URI uses dot notation (for example, `/file.x`, `/Maryia.Melnyk`, `/image.gif`) but don't point to any static content:
  * WPF and Windows Forms: The host page content is returned.
  * .NET MAUI: A 404 response is returned.

To change the link handling behavior for links that don't set `target="_blank"`, register the `UrlLoading` event and set the `UrlLoadingEventArgs.UrlLoadingStrategy` property. The `UrlLoadingStrategy` enumeration allows setting link handling behavior to any of the following values:

* `OpenExternally`: Load the URL using an app determined by the device. This is the default strategy for URIs with an external host.
* `OpenInWebView`: Load the URL within the `BlazorWebView`. This is the default strategy for URLs with a host matching the app origin. ***Don't use this strategy for external links unless you can ensure the destination URI is fully trusted.***
* `CancelLoad`: Cancels the current URL loading attempt.

The `UrlLoadingEventArgs.Url` property is used to get or dynamically set the URL.

> [!WARNING]
> By default, external links are opened in an app determined by the device. Opening external links within a `BlazorWebView` can introduce security vulnerabilities and should ***not*** be enabled unless you can ensure that the external links are fully trusted.

## Namespace

The `Microsoft.AspNetCore.Components.WebView` namespace is required for the examples in this article:

```csharp
using Microsoft.AspNetCore.Components.WebView;
```
  
## .NET MAUI

Add the event handler to the constructor of the `Page` where the `BlazorWebView` is constructed:

```csharp
blazorWebView.UrlLoading += 
    (sender, urlLoadingEventArgs) =>
    {
        urlLoadingEventArgs.UrlLoadingStrategy = UrlLoadingStrategy.OpenInWebView;
    };
```

## WPF

Add the `UrlLoading="Handle_UrlLoading"` attribute to the `BlazorWebView` control in the `.xaml` file:

```xaml
<blazor:BlazorWebView HostPage="wwwroot\index.html" 
    Services="{StaticResource services}" 
    x:Name="blazorWebView" 
    UrlLoading="Handle_UrlLoading" >
```

Add the event handler in the `.xaml.cs` file:

```csharp
private void Handle_UrlLoading(object sender, 
    UrlLoadingEventArgs urlLoadingEventArgs)
{
    urlLoadingEventArgs.UrlLoadingStrategy = UrlLoadingStrategy.OpenInWebView;
}
```

## Windows Forms

In the constructor of the form containing the `BlazorWebView` control, add the following event registration:

```csharp
blazorWebView.UrlLoading += 
    (sender, urlLoadingEventArgs) =>
    {
        urlLoadingEventArgs.UrlLoadingStrategy = UrlLoadingStrategy.OpenInWebView;
    };
```
