---
title: ASP.NET Core Blazor Hybrid routing and navigation
author: guardrex
description: Learn how to manage request routing and navigation in Blazor Hybrid apps.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: "mvc"
ms.date: 11/14/2023
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

Alternatively, the start path can be set in the `MainPage` constructor (`MainPage.xaml.cs`):

```csharp
blazorWebView.StartPath = "/welcome";
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

The guidance in this section describes deep linking approaches for Android and iOS devices.

### Sample app

For an example implementation of the following guidance, see the [`MAUI.AppLinks.Sample` app](https://github.com/redth/maui.applinks.sample).

### Android

Android supports [handling Android app links](https://developer.android.com/training/app-links) with `Intent` filters on activities.

Links can be based on a custom scheme (for example, `myappname://`) or use an `http`/`https` scheme. Writing custom code isn't required to handle custom scheme links. The following approach shows how to support handling `http`/`https` URLs. A well-known association file is hosted on the domain that describes the domain's relationship to the app.

Hosting the association file:

* Proves ownership of the domain.
* Permits Android to verify that the app seeking to handle the URL has ownership of the URL's domain. This prevents an arbitrary app from intercepting links.

#### Verify domain ownership

Verify ownership of the domain in the [Google Search Console](https://search.google.com/search-console).

#### Host a `.well-known` association file

Create an `assetlinks.json` file hosted on the domain's server under the `/.well-known/` folder. The URL should look like `https://redth.dev/.well-known/assetlinks.json`.

The following is an example of the file's content:

```json
[
  {
    "relation": ["delegate_permission/common.handle_all_urls"],
    "target": {
      "namespace": "android_app",
      "package_name": "dev.redth.applinkssample",
      "sha256_cert_fingerprints":
      [
        "AA:BB:CC:DD:EE:FF:00:11:22:33:44:55:66:77:88:99:10:11:12:13:14:15:16:17:18:19:20:21:22:23:24:25"
      ]
    }
  }
]
```

Find the `.keystore SHA256` fingerprints for the app. In this example, only the `androiddebug.keystore` file's fingerprint is included, which is used by default to sign .NET Android apps.

You can use the [Statement List Generator Tool](https://developers.google.com/digital-asset-links/tools/generator) to help generate and validate the file.

#### Setup the Android `Activity`

Reuse `Platforms/Android/MainActivity.cs` in the .NET MAUI app by adding the following class attribute to it. Update the `DataHost` parameter for your app:

```csharp
[IntentFilter(
    new string[] { Intent.ActionView },
    AutoVerify = true,
    Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
    DataScheme = "https",
    DataHost = "redth.dev")]
```

Use your own data scheme and host values. It's possible to associate multiple schemes/hosts.

To mark the activity as exportable, add the `Exported = true` property to the existing `[Activity(...)]` attribute.

#### Handle the lifecycle events for the `Intent` activation

In the `MauiProgram.cs` file, set up the lifecycle events with the app builder:

```csharp
builder.ConfigureLifecycleEvents(lifecycle =>
{
    #if IOS || MACCATALYST
        // ...
    #elif ANDROID
    lifecycle.AddAndroid(android => {
        android.OnCreate((activity, bundle) =>
        {
            var action = activity.Intent?.Action;
            var data = activity.Intent?.Data?.ToString();

            if (action == Intent.ActionView && data is not null)
            {
                HandleAppLink(data);
            }
        });
    });
    #endif
});
```

#### Test a URL

Use `adb` to simulate opening a URL to ensure the app's links work correctly, as the following example shell command demonstrates. Update the data URI (`-d`) to match a link in the app for testing:

```shell
adb shell am start -a android.intent.action.VIEW -c android.intent.category.BROWSABLE -d "https://redth.dev/items/1234"
```

Intent arguments in the preceding command:

* `-a`: Action
* `-c`: Category
* `-d`: Data URI

For more information, see [Android Debug Bridge (adb) (Android Developer documentation)](https://developer.android.com/tools/adb#IntentSpec).

### iOS

Apple supports registering an app to handle both custom URI schemes (for example, `myappname://`) and `http`/`https` schemes. The example in this section focuses on `http`/`https`. Custom schemes require additional configuration in the `Info.plist` file, which isn't covered here.

Apple refers to handling `http`/`https` URLs as [*supporting universal links*](https://developer.apple.com/documentation/xcode/supporting-universal-links-in-your-app). Apple requires that you host a well-known `apple-app-site-association` file at the domain that describes the domain's relationship to the app.

Hosting the association file:

* Proves ownership of the domain.
* Permits Apple to verify that the app seeking to handle the URL has ownership of the URL's domain. This prevents an arbitrary app from intercepting links.

#### Host a `.well-known` association File

Create a `apple-app-site-association` JSON file hosted on the domain's server under the `/.well-known/` folder. The URL should look like `https://redth.dev/.well-known/apple-app-site-association`.

The file contents must include the following JSON. Replace the app identifiers with the correct values for your app:

```json
{
  "activitycontinuation": {
    "apps": [ "85HMA3YHJX.dev.redth.applinkssample" ]
  },
  "applinks": {
    "apps": [],
    "details": [
      {
        "appID": "85HMA3YHJX.dev.redth.applinkssample",
        "paths": [ "*", "/*" ]
      }
    ]
  }
}
```

This step may require some trial and error to get working. Public implementation guidance indicates that the `activitycontinuation` property is required.

#### Add domain association entitlements to the app

Add custom entitlements to the app to declare one or more associated domains. Accomplish this either by adding an `Entitlements.plist` file to the app or by adding the following `<ItemGroup>` to the app's project file (`.csproj`) file.

Replace `applinks:redth.dev` with the correct domain value. Note that the `Condition` only includes the entitlement when the app is built for iOS or MacCatalyst.

```xml
<ItemGroup Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'ios' Or $([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'maccatalyst'">

    <!-- For debugging, use '?mode=developer' for debug to bypass apple's CDN cache -->
    <CustomEntitlements
        Condition="$(Configuration) == 'Debug'"
        Include="com.apple.developer.associated-domains"
        Type="StringArray"
        Value="applinks:redth.dev?mode=developer" />

    <!-- Non debugging, use normal applinks:url value -->
    <CustomEntitlements
        Condition="$(Configuration) != 'Debug'"
        Include="com.apple.developer.associated-domains"
        Type="StringArray"
        Value="applinks:redth.dev" />

</ItemGroup>
```

#### Add lifecycle handlers

In the `MauiProgram.cs` file, add lifecycle events with the `builder`. If the app doesn't use `Scenes` for multi-window support, omit the lifecycle handlers for `Scene` methods.

```csharp
builder.ConfigureLifecycleEvents(lifecycle =>
{
    #if IOS || MACCATALYST
    lifecycle.AddiOS(ios =>
    {
        ios.FinishedLaunching((app, data)
            => HandleAppLink(app.UserActivity));

        ios.ContinueUserActivity((app, userActivity, handler)
            => HandleAppLink(userActivity));

        if (OperatingSystem.IsIOSVersionAtLeast(13) || 
            OperatingSystem.IsMacCatalystVersionAtLeast(13))
        {
            ios.SceneWillConnect((scene, sceneSession, sceneConnectionOptions)
                => HandleAppLink(sceneConnectionOptions.UserActivities.ToArray()
                    .FirstOrDefault(
                        a => a.ActivityType == NSUserActivityType.BrowsingWeb)));

            ios.SceneContinueUserActivity((scene, userActivity)
                => HandleAppLink(userActivity));
        }
    });
    #elif ANDROID
        // ...
    #endif
});
```

#### Test a URL

Testing on iOS might be more tedious than testing on Android. There are many public reports of mixed results with iOS simulators working. For example, Simulator didn't work when this guidance was tested. Even if an arbitrary simulator works during testing, testing with an iOS device is recommended.

After the app is deployed to a device, test the URLs by going to **Settings** > **Developer** > **Universal Links** and enable **Associated Domains Development**. Open **Diagnostics**. Enter the URL to test. For the demonstration in this section, the test URL is `https://redth.dev`. You should see a green checkmark with **Opens Installed Application** and the App ID of the app.

It's also worth noting from the [Add domain association entitlements to the app](#add-domain-association-entitlements-to-the-app) step that adding the `applink` entitlement with `?mode=developer` to the app results in the app bypassing Apple's CDN cache when testing and debugging, which is helpful for iterating on your `apple-app-site-association` JSON file.

### Apps launched via a deep link

If the app is launched via a deep link, set the path for initial navigation in the [`BlazorWebView.StartPath` property](#get-or-set-a-path-for-initial-navigation).

:::zone-end

:::moniker-end
