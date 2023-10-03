---
title: ASP.NET Core Blazor Hybrid routing and navigation
author: guardrex
description: Learn how to manage request routing and navigation in Blazor Hybrid apps.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: "mvc"
ms.date: 01/18/2023
uid: blazor/hybrid/routing
zone_pivot_groups: blazor-hybrid-frameworks
---
# ASP.NET Core Blazor Hybrid routing and navigation

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to manage request routing and navigation in Blazor Hybrid apps.

## URI request routing behavior

Default URI request routing behavior:

* A link is *internal* if the host name and scheme match between the app's origin URI and the request URI. When the host names and schemes don't match or if the link sets `target="_blank"`, the link is considered *external*.
* If the link is internal, the link is opened in the `BlazorWebView` by the app.
* If the link is external, the link is opened by an app determined by the device based on the device's registered handler for the link's scheme.
* For internal links that appear to request a file because the last segment of the URI uses dot notation (for example, `/file.x`, `/Maryia.Melnyk`, `/image.gif`) but don't point to any static content:
  * WPF and Windows Forms: The host page content is returned.
  * .NET MAUI: A 404 response is returned.

To change the link handling behavior for links that don't set `target="_blank"`, register the `UrlLoading` event and set the <xref:Microsoft.AspNetCore.Components.WebView.UrlLoadingEventArgs.UrlLoadingStrategy?displayProperty=nameWithType> property. The <xref:Microsoft.AspNetCore.Components.WebView.UrlLoadingEventArgs.UrlLoadingStrategy> enumeration allows setting link handling behavior to any of the following values:

* <xref:Microsoft.AspNetCore.Components.WebView.UrlLoadingStrategy.OpenExternally>: Load the URL using an app determined by the device. This is the default strategy for URIs with an external host.
* <xref:Microsoft.AspNetCore.Components.WebView.UrlLoadingStrategy.OpenInWebView>: Load the URL within the `BlazorWebView`. This is the default strategy for URLs with a host matching the app origin. ***Don't use this strategy for external links unless you can ensure the destination URI is fully trusted.***
* <xref:Microsoft.AspNetCore.Components.WebView.UrlLoadingStrategy.CancelLoad>: Cancels the current URL loading attempt.

The <xref:Microsoft.AspNetCore.Components.WebView.UrlLoadingEventArgs.Url?displayProperty=nameWithType> property is used to get or dynamically set the URL.

> [!WARNING]
> By default, external links are opened in an app determined by the device. Opening external links within a `BlazorWebView` can introduce security vulnerabilities and should ***not*** be enabled unless you can ensure that the external links are fully trusted.

API documentation:

* .NET MAUI: <xref:Microsoft.AspNetCore.Components.WebView.Maui.BlazorWebView.UrlLoading?displayProperty=nameWithType>
* WPF: <xref:Microsoft.AspNetCore.Components.WebView.Wpf.BlazorWebView.UrlLoading?displayProperty=nameWithType>
* Windows Forms: <xref:Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView.UrlLoading?displayProperty=nameWithType>

The <xref:Microsoft.AspNetCore.Components.WebView?displayProperty=fullName> namespace is required for the following examples:

```csharp
using Microsoft.AspNetCore.Components.WebView;
```

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
        urlLoadingEventArgs.UrlLoadingStrategy = 
            UrlLoadingStrategy.OpenInWebView;
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

:::moniker range=">= aspnetcore-8.0"

## Get or set a path for initial navigation

Use the `BlazorWebView.StartPath` property to get or set the path for initial navigation within the Blazor navigation context when the Razor component is finished loading. The default start path is the relative root URL path (`/`).

:::zone pivot="maui"

In the `MainPage` XAML markup (`MainPage.xaml`), specify the start path. The following example sets the path to a welcome page at `/welcome`:

```xaml
<BlazorWebView ... StartPath="/welcome" ...>
    ...
<BlazorWebView>
```

:::zone-end

:::zone pivot="wpf"

In the `MainWindow` designer (`MainWindow.xaml`), specify the start path. The following example sets the path to a welcome page at `/welcome`:

```xaml
<blazor:BlazorWebView ... StartPath="/welcome" ...>
    ...
</blazor:BlazorWebView>
```

:::zone-end

:::zone pivot="winforms"

Inside the `Form1` constructor of the `Form1.cs` file, specify the start path. The following example sets the path to a welcome page at `/welcome`:

```csharp
blazorWebView1.StartPath = "/welcome";
```

:::zone-end

:::moniker-end

:::zone pivot="maui"

## Navigation among pages and Razor components

This section explains how to navigate among .NET MAUI content pages and Razor components.

The .NET MAUI Blazor hybrid project template isn't a [Shell-based app](/dotnet/maui/fundamentals/shell/), so the [URI-based navigation for Shell-based apps](/dotnet/maui/fundamentals/shell/navigation) isn't suitable for a project based on the project template. The examples in this section use a <xref:Microsoft.Maui.Controls.NavigationPage> to perform modeless or modal navigation.

In the following example:

* The namespace of the app is `MauiBlazor`, which matches the suggested project name of the <xref:blazor/hybrid/tutorials/maui> tutorial.
* A <xref:Microsoft.Maui.Controls.ContentPage> is placed in a new folder added to the app named `Views`.

In `App.xaml.cs`, create the `MainPage` as a <xref:Microsoft.Maui.Controls.NavigationPage> by making the following change:

```diff
- MainPage = new MainPage();
+ MainPage = new NavigationPage(new MainPage());
```

`Views/NavigationExample.xaml`:

```xaml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:MauiBlazor"
             x:Class="MauiBlazor.Views.NavigationExample"
             Title="Navigation Example"
             BackgroundColor="{DynamicResource PageBackgroundColor}">
    <StackLayout>
        <Label Text="Navigation Example"
               VerticalOptions="Center"
               HorizontalOptions="Center"
               FontSize="24" />
        <Button x:Name="CloseButton" 
                Clicked="CloseButton_Clicked" 
                Text="Close" />
    </StackLayout>
</ContentPage>
```

In the following `NavigationExample` code file, the `CloseButton_Clicked` event handler for the close button calls <xref:Microsoft.Maui.Controls.INavigation.PopAsync%2A> to pop the <xref:Microsoft.Maui.Controls.ContentPage> off of the navigation stack.

`Views/NavigationExample.xaml.cs`:

```csharp
namespace MauiBlazor.Views;

public partial class NavigationExample : ContentPage
{
    public NavigationExample()
    {
        InitializeComponent();
    }

    private async void CloseButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
```

In a Razor component:

* Add the namespace for the app's content pages. In the following example, the namespace is `MauiBlazor.Views`.
* Add an HTML `button` element with an [`@onclick` event handler](xref:blazor/components/event-handling) to open the content page. The event handler method is named `OpenPage`.
* In the event handler, call <xref:Microsoft.Maui.Controls.INavigation.PushAsync%2A> to push the <xref:Microsoft.Maui.Controls.ContentPage>, `NavigationExample`, onto the navigation stack.

The following example is based on the `Index` component in the .NET MAUI Blazor project template.

`Pages/Index.razor`:

```razor
@page "/"
@using MauiBlazor.Views

<h1>Hello, world!</h1>

Welcome to your new app.

<SurveyPrompt Title="How is Blazor working for you?" />

<button class="btn btn-primary" @onclick="OpenPage">Open</button>

@code {
    private async void OpenPage()
    {
        await App.Current.MainPage.Navigation.PushAsync(new NavigationExample());
    }
}
```

To change the preceding example to modal navigation:

* In the `CloseButton_Clicked` method (`Views/NavigationExample.xaml.cs`), change <xref:Microsoft.Maui.Controls.INavigation.PopAsync%2A> to <xref:Microsoft.Maui.Controls.INavigation.PopModalAsync%2A>:

  ```diff
  - await Navigation.PopAsync();
  + await Navigation.PopModalAsync();
  ```

* In the `OpenPage` method (`Pages/Index.razor`), change <xref:Microsoft.Maui.Controls.INavigation.PushAsync%2A> to <xref:Microsoft.Maui.Controls.INavigation.PushModalAsync%2A>:

  ```diff
  - await App.Current.MainPage.Navigation.PushAsync(new NavigationExample());
  + await App.Current.MainPage.Navigation.PushModalAsync(new NavigationExample());
  ```

For more information, see the following resources:

* [`NavigationPage` article (.NET MAUI documentation)](/dotnet/maui/user-interface/pages/navigationpage)
* [`NavigationPage` (API documentation)](xref:Microsoft.Maui.Controls.NavigationPage)

:::zone-end

:::moniker range=">= aspnetcore-8.0"

:::zone pivot="maui"

## Deep linking

Deep linking support is planned for .NET 9 in late 2024. For more information, see [Support deep linking into .NET MAUI Blazor apps (dotnet/maui #3788)](https://github.com/dotnet/maui/issues/3788#issuecomment-1421550198).

:::zone-end

:::moniker-end
