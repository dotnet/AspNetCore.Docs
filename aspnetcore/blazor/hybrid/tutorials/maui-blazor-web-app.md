---
title: Build a .NET MAUI Blazor Hybrid app with a Blazor Web App
author: guardrex
description: Learn how to build a .NET MAUI Blazor Hybrid app with a Blazor Web App that uses a shared user interface via a Razor class library (RCL).
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 04/24/2024
uid: blazor/hybrid/tutorials/maui-blazor-web-app
---
# Build a .NET MAUI Blazor Hybrid app with a Blazor Web App

This article shows you how to build and run a .NET MAUI Blazor Hybrid app based on a Blazor Web App with a shared UI via a Razor class library (RCL).

## Prerequisites and preliminary steps

For prerequisites and preliminary steps, see <xref:blazor/hybrid/tutorials/maui>. We recommend using the .NET MAUI Blazor Hybrid tutorial to set up your local system for .NET MAUI development before using the guidance in this article.

## .NET MAUI Blazor Web App sample app

[Obtain the sample app](xref:blazor/fundamentals/index#sample-apps) named `MauiBlazorWeb` from the [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples) (.NET 8 or later).

The sample app is a starter solution that contains a .NET MAUI Hybrid (native, cross-platform) app, a Blazor Web App, and a Razor class library (RCL) that contains the shared UI (Razor components) used by the native and web apps.

## Migrating a .NET MAUI Blazor Hybrid solution

Instead of [using the sample app](#net-maui-blazor-web-app-sample-app), you can migrate an existing .NET MAUI Blazor Hybrid app with the guidance in this section using Visual Studio.

Add new project to the solution with the **Blazor Web App** project template. Select the following options:    

* **Authentication type**: **None**
* **Configure for HTTPS**: Selected (enabled)
* **Interactive render mode**: **Server**
* **Interactivity location**: **Global**
* **Sample pages**: Unselected (disabled)

<!-- UPDATE 9.0 Check on PU issue and revise the following
                for >=9.0 accordingly -->

The **Interactivity location** setting to **Global** is important because MAUI apps always run interactively and throw errors on component pages that explicitly specify a render mode. If you don't use a global render mode, you must implement the approach described in the [Use Blazor render modes](#use-blazor-render-modes) section. For more information, see [BlazorWebView needs a way to enable overriding ResolveComponentForRenderMode (`dotnet/aspnetcore` #51235)](https://github.com/dotnet/aspnetcore/issues/51235).

Add new Razor class library (RCL) project to the solution. Don't select **Support pages and views**.

Add project references to the RCL from both MAUI project and the Blazor Web App project.

Move the `Components` folder and all of its contents from the MAUI project to the shared project. Confirm that the `Components` folder is deleted from the MAUI project.

Move the `wwwroot/css` folder and all of its contents from from the MAUI project to the shared project. Confirm that the `wwwroot/css` folder is deleted from the MAUI project.

Move the `_Imports.razor` file from the MAUI project to the RCL, overwriting the existing file in the RCL. Confirm that the `_Imports` file is deleted from the MAUI project. After moving the file, open it and rename the last two `@using` statements to match the RCL's namespace. In the following example, the RCL is named `MauiBlazorWeb.Shared`:

```razor
@using MauiBlazorWeb.Shared
@using MauiBlazorWeb.Shared.Components
```

Open the `_Imports.razor` file in the Blazor Web App and add an `@using` statement for the RCL. In the following example, the RCL's namespace is `MauiBlazorWeb.Shared`:

```razor
@using MauiBlazorWeb.Shared
```

Move the `Routes.razor` file from MAUI project to the RCL. Confirm that the `Routes.razor` file is deleted from the MAUI project. Open the `Routes.razor` file and change `MauiProgram` to `Routes`:

```diff
- <Router AppAssembly="@typeof(MauiProgram).Assembly">
+ <Router AppAssembly="@typeof(Routes).Assembly">
```

Open the `MainPage.xaml` file in the MAUI project. Add an `xmlns:shared` reference to the RCL in the <xref:Microsoft.Maui.Controls.ContentPage> attributes. In the following example, the RCL's namespace is `MauiBlazorWeb.Shared`. Set the correct value for both the `clr-namespace` and the `assembly`:

```xml
xmlns:shared="clr-namespace:MauiBlazorWeb.Shared;assembly=MauiBlazorWeb.Shared" 
```

Also in the `MainPage.xaml` file, update the <xref:Microsoft.AspNetCore.Components.WebView.Maui.BlazorWebView> root component <xref:Microsoft.AspNetCore.Components.WebView.Maui.RootComponent.ComponentType> from `local` to `shared`:

```diff
- <RootComponent Selector="#app" ComponentType="{x:Type local:Routes}" />
+ <RootComponent Selector="#app" ComponentType="{x:Type shared:Routes}" />
```

In the MAUI project, open the `wwwroot/index.html` file and change stylesheets to point to the RCL's static asset path. In the following example, the RCL's static asset path is `_content/MauiBlazorWeb.Shared/`:

```diff
- <link rel="stylesheet" href="css/bootstrap/bootstrap.min.css" />
- <link rel="stylesheet" href="css/app.css" />
+ <link rel="stylesheet" href="_content/MauiBlazorWeb.Shared/css/bootstrap/bootstrap.min.css" />
+ <link rel="stylesheet" href="_content/MauiBlazorWeb.Shared/css/app.css" />
```

Open the `App` component (`Components/App.razor`) in the Blazor Web App project. Remove the `app.css` stylesheet:

```diff
- <link rel="stylesheet" href="app.css" />
```

Replace the preceding line with the RCL's static asset stylesheet references. In the following example, the RCL's static asset path is `_content/MauiBlazorWeb.Shared/`:

```
<link rel="stylesheet" href="_content/MauiBlazorWeb.Shared/css/bootstrap/bootstrap.min.css" />
<link rel="stylesheet" href="_content/MauiBlazorWeb.Shared/css/app.css" />   
```

In the Blazor Web App project, delete the following folder and files:

* `Components/Layouts` folder
* `Components/Routes.razor`
* `Components/Pages/Home.razor`
* `wwwroot/app.css`

Open the Blazor Web App's `Program.cs` file and add an additional assembly for the RCL to the app. In the following example, the RCL's namespace is `MauiBlazorWeb.Shared`:

```csharp
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(MauiBlazorWeb.Shared._Imports).Assembly);
```

## Use Blazor render modes

To use Blazor [render modes](xref:blazor/components/render-modes) in the Blazor Web App but ignore them in the MAUI app, the following `InteractiveRenderSettings` class is added to the RCL. The class properties are used to set component render modes in the RCL.

`InteractiveRenderSettings.cs`:

:::code language="csharp" source="~/../blazor-samples/8.0/MauiBlazorWeb/MauiBlazorWeb.Shared/InteractiveRenderSettings.cs":::

In `MauiProgram.CreateMauiApp` of `MauiProgram.cs`, call `ConfigureBlazorHybridRenderModes`:

```csharp 
InteractiveRenderSettings.ConfigureBlazorHybridRenderModes();
```

In the RCL's `_Imports.razor` file, add the following global static `@using` directive to make the properties of the class available to components:

```razor
@using static InteractiveRenderSettings
```

For the Blazor Web App on the web client, the property values are assigned from <xref:Microsoft.AspNetCore.Components.Web.RenderMode>. When the components are loaded into a <xref:Microsoft.AspNetCore.Components.WebView.Maui.BlazorWebView> for the MAUI project's native client, the render mode is unassigned (`null`) because the MAUI project explicitly sets the render mode properties to `null` when `ConfigureBlazorHybridRenderModes` is called.

At this point, you can adopt either:

* [Global interactive rendering](#global-interactive-rendering)
* [Per-page/component rendering](#per-pagecomponent-rendering)

### Global interactive rendering

The MAUI project is interactive by default, so no action is taken at the project level in the MAUI project other than calling `InteractiveRenderSettings.ConfigureBlazorHybridRenderModes`.

The Blazor Web App sets a global interactive render mode normally in the `App` component (`Components/App.razor`). In the following example, the `HeadOutlet` and `Routes` components assign `InteractiveServer` from <xref:Microsoft.AspNetCore.Components.Web.RenderMode> via the Blazor Web App's `@using static Microsoft.AspNetCore.Components.Web.RenderMode` directive in the project's `_Imports` file:

```razor
<HeadOutlet @rendermode="InteractiveServer" />

...

<Routes @rendermode="InteractiveServer" />
```

At this point, no component in the RCL sets a render mode. A component's render mode is inherited from the global setting.

To recap:

* For components rendered by MAUI for the native client, RCL component render modes are `null`. The components are interactive by default.
* For components rendered by the Blazor Web App for the web client, RCL component render modes are inherited from the global setting in the `App` component.

### Per-page/component rendering

The MAUI project is interactive by default, so no action is taken at the project level in the MAUI project other than calling `InteractiveRenderSettings.ConfigureBlazorHybridRenderModes`.

Don't set an `@rendermode` directive attribute on the `HeadOutlet` and `Routes` components of the Blazor Web App's `App` component (`Components/App.razor`):

```razor
<HeadOutlet />

...

<Routes />
```

Apply render modes to individual components in the RCL.

The Razor class library (RCL) contains a global static `@using` directive (`@using static InteractiveRenderSettings`) to reference `InteractiveRenderSettings` class properties in the RCL's components. A component adopts a given render mode by assigning the render mode from `InteractiveRenderSettings` at the top of its component definition file (`.razor`) under its `@page` directive:

Interactive Server:

```razor
@rendermode InteractiveServer
```

Interactive Auto:

```razor
@rendermode InteractiveAuto
```

Interactive WebAssembly:

```razor
@rendermode InteractiveWebAssembly
```

To recap:

* For components rendered by MAUI for the native client, RCL component render modes are `null`. The components are interactive by default.
* For components rendered by the Blazor Web App for the web client, RCL component render modes are set on a per-component basis from `InteractiveRenderSettings`.

> [!NOTE]
> The assignment of render modes via the `InteractiveRenderSettings` class properties in the RCL differs from a typical standalone Blazor Web App. In a Blazor Web App, the render modes are normally provided by <xref:Microsoft.AspNetCore.Components.Web.RenderMode> via the `@using static Microsoft.AspNetCore.Components.Web.RenderMode` statement in the Blazor Web App's `_Import` file.

## Using interfaces to support different device implementations

The following example demonstrates how to use an interface to call into different implementations across the web app and the native (MAUI) app. The following example creates a component that displays the device form factor. Use the MAUI abstraction layer for native apps and provide an implementation for the web app.

In the Razor class library (RCL), create an `Interfaces` folder and add file named `IFormFactor.cs` with the following code.

`Interfaces/IFormFactor.cs`:

:::code language="csharp" source="~/../blazor-samples/8.0/MauiBlazorWeb/MauiBlazorWeb.Shared/Interfaces/IFormFactor.cs":::

In the RCL's `Components` folder, add the following `DeviceFormFactor` component.

`Components/Pages/DeviceFormFactor.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/MauiBlazorWeb/MauiBlazorWeb.Shared/Components/Pages/DeviceFormFactor.razor":::

In the RCL, add an entry for the `DeviceFormFactor` component to the navigation menu.

In `Components/Layout/NavMenu.razor`:

```razor
<div class="nav-item px-3">
    <NavLink class="nav-link" href="device-form-factor">
        <span class="bi bi-list-nested-nav-menu" aria-hidden="true"></span> Form Factor
    </NavLink>
</div>
```

Provide implementations in the web and native apps.

In the Blazor Web App, add a folder named `Services`. Add a file to the `Services` folder named `FormFactor.cs` with the following code.

`Services/FormFactor.cs` (Blazor Web App project):

:::code language="csharp" source="~/../blazor-samples/8.0/MauiBlazorWeb/MauiBlazorWeb.Web/Services/FormFactor.cs":::

In the MAUI project, add a folder named `Services` and add a file named `FormFactor.cs`. The MAUI abstractions layer is used to write code that works on all native device platforms.

`Services/FormFactor.cs` (MAUI project):
 
:::code language="csharp" source="~/../blazor-samples/8.0/MauiBlazorWeb/MauiBlazorWeb.Maui/Services/FormFactor.cs":::

Use dependency injection to obtain the implementations of these services.

In the MAUI project, open the `MauiProgram.cs` file and add the following `using` statements to the top of the file:

```csharp
using MauiBlazorWeb.Maui.Services;
using MauiBlazorWeb.Shared.Interfaces;
```

Immediately before the call to `builder.Build()`, add the following code to add device-specific services used by the RCL:

```csharp
builder.Services.AddSingleton<IFormFactor, FormFactor>();
```

In the Blazor Web App, open the `Program` file and add the following `using` statements to the top of the file:

```csharp
using MauiBlazorWeb.Shared.Interfaces;
using MauiBlazorWeb.Web.Services;  
```

Immediately before the call to `builder.Build()`, add the following code to add device-specific services used by the RCL:

```csharp
builder.Services.AddScoped<IFormFactor, FormFactor>();
```

You can also use compiler preprocessor directives in your RCL to implement different UI depending on the device the app is running on. For this scenario, the app must multi-target the RCL just like the MAUI app does. For an example, see the [`BethMassi/BethTimeUntil` GitHub repository](https://github.com/BethMassi/BethTimeUntil). 
