---
title: Build a .NET MAUI Blazor Hybrid app with a Blazor Web App
author: guardrex
description: Learn how to build a .NET MAUI Blazor Hybrid app with a Blazor Web App that uses a shared user interface via a Razor class library (RCL).
monikerRange: '>= aspnetcore-8.0'
ms.author: riande
ms.custom: mvc
ms.date: 04/25/2024
uid: blazor/hybrid/tutorials/maui-blazor-web-app
---
# Build a .NET MAUI Blazor Hybrid app with a Blazor Web App

This article shows you how to build a .NET MAUI Blazor Hybrid app with a Blazor Web App that uses a shared user interface via a Razor class library (RCL).

## Prerequisites and preliminary steps

For prerequisites and preliminary steps, see <xref:blazor/hybrid/tutorials/maui>. We recommend using the .NET MAUI Blazor Hybrid tutorial to set up your local system for .NET MAUI development before using the guidance in this article.

## .NET MAUI Blazor Web App sample app

[Obtain the sample app](xref:blazor/fundamentals/index#sample-apps) named `MauiBlazorWeb` from the [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples) (.NET 8 or later).

The sample app is a starter solution that contains a .NET MAUI Blazor Hybrid (native, cross-platform) app, a Blazor Web App, and a Razor class library (RCL) that contains the shared UI (Razor components) used by the native and web apps.

## Migrating a .NET MAUI Blazor Hybrid solution

Instead of [using the sample app](#net-maui-blazor-web-app-sample-app), you can migrate an existing .NET MAUI Blazor Hybrid app with the guidance in this section using Visual Studio.

Add new project to the solution with the **Blazor Web App** project template. Select the following options:    

* **Project name**: Use the solution's name with `.Web` appended. The examples in this article assume the following naming:
  * Solution: `MauiBlazorWeb`
  * MAUI project: `MauiBlazorWeb.Maui`
  * Blazor Web App: `MauiBlazorWeb.Web`
  * Razor class library (RCL) (added in a later step): `MauiBlazorWeb.Shared`
* **Authentication type**: **None**
* **Configure for HTTPS**: Selected (enabled)
* **Interactive render mode**: **Server**
* **Interactivity location**: **Global**
* **Sample pages**: Unselected (disabled)

<!-- UPDATE 9.0 Check on PU issue and revise the following
                for >=9.0 accordingly -->

The **Interactivity location** setting to **Global** is important because MAUI apps always run interactively and throw errors on Razor component pages that explicitly specify a render mode. If you don't use a global render mode, you must implement the approach described in the [Use Blazor render modes](#use-blazor-render-modes) section after following the guidance in this section. For more information, see [BlazorWebView needs a way to enable overriding ResolveComponentForRenderMode (`dotnet/aspnetcore` #51235)](https://github.com/dotnet/aspnetcore/issues/51235).

Add new **Razor class library** (RCL) project to the solution. The examples in this article assume that the project is named `MauiBlazorWeb.Shared`. Don't select **Support pages and views** when you add the project to the solution.

Add project references to the RCL from both MAUI project and the Blazor Web App project.

Move the `Components` folder and all of its contents from the MAUI project to the RCL. Confirm that the `Components` folder is deleted from the MAUI project.

> [!TIP]
> When moving a folder or file in Visual Studio, either use keyboard commands or the shortcut menu by right-clicking for a cut and paste operation. Dragging the folder in Visual Studio only copies from one location to another, which requires an extra step to delete the original.

Move the `css` folder from the `wwwroot` folder of the MAUI project to the RCL's `wwwroot` folder.

Delete the following files from the RCL's `wwwroot` folder:

* `background.png`
* `exampleJsInterop.js`

In the RCL, replace the root `_Imports.razor` file with the one in the RCL's `Components` folder, overwriting the existing file in the RCL and deleting the original in the `Components` folder. After moving the file, open it and rename the last two `@using` statements to match the RCL's namespace. In the following example, the RCL's namespace is `MauiBlazorWeb.Shared`:

```razor
@using MauiBlazorWeb.Shared
@using MauiBlazorWeb.Shared.Components
```

In the root of the RCL project, delete the following files:

* `Component1.razor`
* `ExampleJsInterop.cs`

In the RCL, open the `Components/Routes.razor` file and change `MauiProgram` to `Routes`:

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

In the MAUI project, open the `wwwroot/index.html` file and change stylesheets to point to the RCL's static asset path.

Remove the following lines:

```diff
- <link rel="stylesheet" href="css/bootstrap/bootstrap.min.css" />
- <link rel="stylesheet" href="css/app.css" />
```

Replace the preceding lines with the following markup. In the following example, the RCL's static asset path is `_content/MauiBlazorWeb.Shared/`:

```razor
<link rel="stylesheet" href="_content/MauiBlazorWeb.Shared/css/bootstrap/bootstrap.min.css" />
<link rel="stylesheet" href="_content/MauiBlazorWeb.Shared/css/app.css" />
```

In the Blazor Web App, open the `_Imports.razor` file and add the following two `@using` statements for the RCL. In the following example, the RCL's namespace is `MauiBlazorWeb.Shared`:

```razor
@using MauiBlazorWeb.Shared
@using MauiBlazorWeb.Shared.Components
```

In the Blazor Web App project, open the `App` component (`Components/App.razor`). Remove the `app.css` stylesheet:

```diff
- <link rel="stylesheet" href="app.css" />
```

Replace the preceding line with the RCL's static asset stylesheet references. In the following example, the RCL's static asset path is `_content/MauiBlazorWeb.Shared/`:

```
<link rel="stylesheet" href="_content/MauiBlazorWeb.Shared/css/bootstrap/bootstrap.min.css" />
<link rel="stylesheet" href="_content/MauiBlazorWeb.Shared/css/app.css" />
```

In the Blazor Web App project, delete the following folder and files:

* `Components/Layout` folder
* `Components/Routes.razor`
* `Components/Pages/Home.razor`
* `wwwroot/app.css`

Open the Blazor Web App's `Program.cs` file and add an additional assembly for the RCL to the app. In the following example, the RCL's namespace is `MauiBlazorWeb.Shared`:

```csharp
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(MauiBlazorWeb.Shared._Imports).Assembly);
```

Run the MAUI project by selecting the project in **Solution Explorer** and using Visual Studio's start button.

Run the Blazor Web App project by selecting the Blazor Web App project in **Solution Explorer** and using Visual Studio's start button with the `https` build configuration.

If you receive a build error that the RCL's assembly can't be resolved, build the RCL project first. If any MAUI project resource errors occur on build, rebuild the MAUI project to clear the errors.

## Use Blazor render modes

Follow the guidance in this section and either of the following two subsections to apply Blazor [render modes](xref:blazor/components/render-modes) in the Blazor Web App but ignore them in the MAUI project. 

Add the following `InteractiveRenderSettings` class is added to the RCL. The class properties are used to set component render modes.

For the Blazor Web App on the web client, the property values are assigned from <xref:Microsoft.AspNetCore.Components.Web.RenderMode>. When the components are loaded into a <xref:Microsoft.AspNetCore.Components.WebView.Maui.BlazorWebView> for the MAUI project's native client, the render modes are unassigned (`null`) because the MAUI project explicitly sets the render mode properties to `null` when `ConfigureBlazorHybridRenderModes` is called.

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

In summary:

* For components rendered by MAUI for the native client, RCL component render modes are `null`. The components are interactive by default.
* For components rendered by the Blazor Web App for the web client, RCL component render modes are inherited from the global setting in the `App` component.

### Per-page/component rendering

The MAUI project is interactive by default, so no action is taken at the project level in the MAUI project other than calling `InteractiveRenderSettings.ConfigureBlazorHybridRenderModes`.

When Auto or WebAssembly global interactivity is used, the solution also receives a `.Client` project:

* Add a project reference to the `.Client` project for the RCL.
* Add an `@using` statement to the `.Client` project's `_Imports.razor` file for the RCL: `@using MauiBlazorWeb.Shared`.
* Create a second RCL to maintain the Auto or WebAssembly components (for example: `MauiBlazorWeb.Shared.Client`). Move the `Components` folder of the `.Client` project into the second RCL. Create a project reference in the first RCL (`MauiBlazorWeb.Shared`) to the second RCL that maintains the components (`MauiBlazorWeb.Shared.Client`). Add `@using static InteractiveRenderSettings` to the second RCL's `_Imports.razor` file.

Don't set an `@rendermode` directive attribute on the `HeadOutlet` and `Routes` components of the Blazor Web App's `App` component (`Components/App.razor`):

```razor
<HeadOutlet />

...

<Routes />
```

Apply render modes to individual components in the RCLs.

The RCLs contain a global static `@using` directive (`@using static InteractiveRenderSettings`) to reference `InteractiveRenderSettings` class properties in the RCLs' components. A component adopts a given render mode by assigning the render mode from `InteractiveRenderSettings` at the top of its component definition file (`.razor`) under its `@page` directive:

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

In summary:

* For components rendered by MAUI for the native client, RCL component render modes are `null`. The components are interactive by default.
* For components rendered by the Blazor Web App for the web client, RCL component render modes are set on a per-component basis from `InteractiveRenderSettings`.

> [!NOTE]
> The assignment of render modes via the `InteractiveRenderSettings` class properties in the RCLs differ from a typical standalone Blazor Web App. In a Blazor Web App, the render modes are normally provided by <xref:Microsoft.AspNetCore.Components.Web.RenderMode> via the `@using static Microsoft.AspNetCore.Components.Web.RenderMode` statement in the Blazor Web App's `_Import` file.

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
