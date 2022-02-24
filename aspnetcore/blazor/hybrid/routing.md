---
title: ASP.NET Core Blazor Hybrid routing and navigation
author: guardrex
description: Learn how to manage request routing and navigation in Blazor Hybrid apps.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: "mvc"
ms.date: 02/24/2022
no-loc: ["Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/hybrid/routing
---
# ASP.NET Core Blazor Hybrid routing and navigation

[!INCLUDE[](~/blazor/includes/blazor-hybrid-preview-notice.md)]

Register to the `ExternalNavigationStarting` event and set the `ExternalLinkNavigationEventArgs.ExternalLinkNavigationPolicy` property to change link handling behavior. The `ExternalLinkNavigationPolicy` enumeration (`enum`) allows setting link handling behavior to `OpenInExternalBrowser`, `OpenInWebView`, and `CancelNavigation`. The `ExternalLinkNavigationEventArgs.Uri` property can be used to dynamically set link handling behavior.

External links are opened in the device default browser by default. Opening external links within the Blazor WebView isn't recommended unless the content is fully trusted.

## .NET MAUI

Add the event handler to the constructor of the `Page` where the `BlazorWebView` is constructed:

```csharp
blazorWebView.ExternalNavigationStarting += 
    (sender, externalLinkNavigationEventArgs) =>
    {
        externalLinkNavigationEventArgs.ExternalLinkNavigationPolicy = 
            ExternalLinkNavigationPolicy.OpenInWebView;
    };
```

## WPF

Add the `ExternalNavigationStarting="Handle_ExternalNavigationStarting"` attribute to the `BlazorWebView` control in the `.xaml` file:

```xaml
<blazor:BlazorWebView HostPage="wwwroot\index.html" 
    Services="{StaticResource services}" 
    x:Name="blazorWebView" 
    ExternalNavigationStarting="Handle_ExternalNavigationStarting" >
```

Add the event handler in the `.xaml.cs` file:

```csharp
private void Handle_ExternalNavigationStarting(
    object sender, ExternalLinkNavigationEventArgs externalLinkNavigationEventArgs)
{
    externalLinkNavigationEventArgs.ExternalLinkNavigationPolicy = 
        ExternalLinkNavigationPolicy.OpenInWebView;
}
```

## Winforms

In the constructor of the form containing the `BlazorWebView` control, add the following event registration:

```csharp
blazorWebView.ExternalNavigationStarting += 
    (sender, externalLinkNavigationEventArgs) =>
    {
        externalLinkNavigationEventArgs.ExternalLinkNavigationPolicy = 
            ExternalLinkNavigationPolicy.OpenInWebView;
    };
```
