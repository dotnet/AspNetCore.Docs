---
title: ASP.NET Core Blazor Hybrid routing and navigation
author: guardrex
description: Learn how to manage request routing and navigation in Blazor Hybrid apps.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: "mvc"
ms.date: 11/08/2022
uid: blazor/hybrid/routing
zone_pivot_groups: blazor-hybrid-frameworks
---
# ASP.NET Core Blazor Hybrid routing and navigation

This article explains how to manage request routing and navigation in Blazor Hybrid apps.

:::moniker range=">= aspnetcore-7.0"

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

The <xref:Microsoft.AspNetCore.Components.WebView?displayProperty=fullName> namespace is required for the examples in this article:

```csharp
using Microsoft.AspNetCore.Components.WebView;
```

## Internal navigation

:::zone pivot="maui"

Add the following event handler to the constructor of the `Page` where the `BlazorWebView` is created, which is `MainPage.xaml.cs` in an app created from the .NET MAUI project template.

```csharp
blazorWebView.UrlLoading += 
    (sender, urlLoadingEventArgs) =>
    {
        if (urlLoadingEventArgs.Url.Host != "0.0.0.0")
        {
            urlLoadingEventArgs.UrlLoadingStrategy = 
                UrlLoadingStrategy.OpenInWebView;
        }
    };
```

:::zone-end

:::zone pivot="wpf"

Add the `UrlLoading="Handle_UrlLoading"` attribute to the `BlazorWebView` control in the `.xaml` file:

```xaml
<blazor:BlazorWebView HostPage="wwwroot\index.html" 
    Services="{StaticResource services}" 
    x:Name="blazorWebView" 
    UrlLoading="Handle_UrlLoading">
```

Add the event handler in the `.xaml.cs` file:

```csharp
private void Handle_UrlLoading(object sender, 
    UrlLoadingEventArgs urlLoadingEventArgs)
{
    if (urlLoadingEventArgs.Url.Host != "0.0.0.0")
    {
        urlLoadingEventArgs.UrlLoadingStrategy = UrlLoadingStrategy.OpenInWebView;
    }
}
```

:::zone-end

:::zone pivot="winforms"

In the constructor of the form containing the `BlazorWebView` control, add the following event registration:

```csharp
blazorWebView.UrlLoading += 
    (sender, urlLoadingEventArgs) =>
    {
        if (urlLoadingEventArgs.Url.Host != "0.0.0.0")
        {
            urlLoadingEventArgs.UrlLoadingStrategy = 
                UrlLoadingStrategy.OpenInWebView;
        }
    };
```

:::zone-end

## External navigation

Register to the `ExternalNavigationStarting` event and set the `ExternalLinkNavigationEventArgs.ExternalLinkNavigationPolicy` property to change navigation behavior.

The `ExternalLinkNavigationPolicy` enumeration sets the navigation behavior:
        
* `OpenInExternalBrowser`: Navigate to external links using the device's default browser. This is the default navigation policy.
* `InsecureOpenInWebView`: Navigate to external links within the Blazor WebView. This navigation policy can introduce security concerns and shouldn't be enabled unless you can ensure that all external links are fully trusted.
* `CancelNavigation`: Cancels the current navigation attempt.

The `ExternalLinkNavigationEventArgs.Uri` property contains the destination URI.

> [!WARNING]
> By default, external links are opened in the device's default browser. Opening external links within the Blazor WebView (`InsecureOpenInWebView`) is ***not recommended*** unless the content is fully trusted.

:::zone pivot="maui"

Add the event handler to the constructor of the page where the `BlazorWebView` is constructed:

```csharp
blazorWebView.ExternalNavigationStarting += 
    (sender, externalLinkNavigationEventArgs) =>
    {
	    externalLinkNavigationEventArgs.ExternalLinkNavigationPolicy = 
            ExternalLinkNavigationPolicy.OpenInExternalBrowser;
    };
```

:::zone-end

:::zone pivot="wpf"

Add the `ExternalNavigationStarting="Handle_ExternalNavigationStarting"` attribute to the `BlazorWebView` control in the `.xaml` file:

```xaml
<blazor:BlazorWebView HostPage="wwwroot\index.html" 
    Services="{StaticResource services}" 
    x:Name="blazorWebView" 
    ExternalNavigationStarting="Handle_ExternalNavigationStarting">
```

Add the event handler in the `.xaml.cs` file:

```csharp
private void Handle_ExternalNavigationStarting(object sender, 
    ExternalLinkNavigationEventArgs externalLinkNavigationEventArgs)
{
	externalLinkNavigationEventArgs.ExternalLinkNavigationPolicy = 
        ExternalLinkNavigationPolicy.OpenInExternalBrowser;
}
```

:::zone-end

:::zone pivot="winforms"

In the constructor of the form containing the `BlazorWebView` control, add the following event registration:

```csharp
blazorWebView.ExternalNavigationStarting += 
    (sender, externalLinkNavigationEventArgs) =>
    {
        externalLinkNavigationEventArgs.ExternalLinkNavigationPolicy = 
            ExternalLinkNavigationPolicy.OpenInExternalBrowser;
    };
```

:::zone-end

:::moniker-end

:::moniker range="< aspnetcore-7.0"

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

The <xref:Microsoft.AspNetCore.Components.WebView?displayProperty=fullName> namespace is required for the examples in this article:

```csharp
using Microsoft.AspNetCore.Components.WebView;
```

:::zone pivot="maui"

Add the following event handler to the constructor of the `Page` where the `BlazorWebView` is created, which is `MainPage.xaml.cs` in an app created from the .NET MAUI project template. The following example assumes an `x:Name="blazorWebView"` ([`x:Name` directive](/dotnet/desktop/xaml-services/xname-directive)) on the `BlazorWebView` within the `.xaml` file.

```csharp
blazorWebView.UrlLoading += 
    (sender, urlLoadingEventArgs) =>
    {
        if (urlLoadingEventArgs.Url.Host != "0.0.0.0")
        {
            urlLoadingEventArgs.UrlLoadingStrategy = UrlLoadingStrategy.OpenInWebView;
        }
    };
```

:::zone-end

:::zone pivot="wpf"

Add the `UrlLoading="Handle_UrlLoading"` attribute to the `BlazorWebView` control in the `.xaml` file:

```xaml
<blazor:BlazorWebView HostPage="wwwroot\index.html" 
    Services="{StaticResource services}" 
    x:Name="blazorWebView" 
    UrlLoading="Handle_UrlLoading">
```

Add the event handler in the `.xaml.cs` file:

```csharp
private void Handle_UrlLoading(object sender, 
    UrlLoadingEventArgs urlLoadingEventArgs)
{
    if (urlLoadingEventArgs.Url.Host != "0.0.0.0")
    {
        urlLoadingEventArgs.UrlLoadingStrategy = UrlLoadingStrategy.OpenInWebView;
    }
}
```

:::zone-end

:::zone pivot="winforms"

In the constructor of the form containing the `BlazorWebView` control, add the following event registration:

```csharp
blazorWebView.UrlLoading += 
    (sender, urlLoadingEventArgs) =>
    {
        if (urlLoadingEventArgs.Url.Host != "0.0.0.0")
        {
            urlLoadingEventArgs.UrlLoadingStrategy = UrlLoadingStrategy.OpenInWebView;
        }
    };
```

:::zone-end

:::moniker-end
