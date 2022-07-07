---
title: Share assets across web and native clients using a Razor class library (RCL)
author: guardrex
description: Learn how to share Razor components, C# code, and static assets web and native clients from a Razor class library (RCL).
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 07/07/2022
uid: blazor/hybrid/class-libraries
---
# Share assets across web and native clients using a Razor class library (RCL)

Use a Razor class library (RCL) to share Razor components, C# code, and static assets across web and native client projects.

This article builds on the general concepts found in the following articles:

* <xref:blazor/components/class-libraries>
* <xref:razor-pages/ui-class>

The examples in this article share assets between a Blazor Server app and a .NET MAUI Blazor app in the same solution:

* Although a Blazor Server app is used in examples and described by the text as the "web" client, the guidance applies equally to Blazor WebAssembly apps.
* The example projects are in the same solution, but an RCL can supply shared assets to projects outside of the same solution.
* The RCL example is added as a project to the solution, but any RCL can be published as a NuGet package. A NuGet package can supply shared assets to web and native client projects.
* The order that the projects are created isn't important. However, projects that rely on an RCL for assets must create a project reference to the RCL *after* the RCL is created.
* The following project names are used for the projects in this article, which become part of namespace and assembly references in the examples:
  * RCL: `SharedLibrary`
  * Blazor Hybrid (.NET MAUI Blazor): `BlazorNative`
  * Blazor Server: `BlazorWeb`

For guidance on creating an RCL, see <xref:blazor/components/class-libraries>. Optionally, access the additional guidance on RCLs that apply broadly to ASP.NET Core apps in <xref:razor-pages/ui-class>.

## Advanced sample app

For an advanced example of the scenarios described in this article, see the .NET Podcasts sample app:

* [GitHub repository (`microsoft/dotnet-podcasts`)](https://github.com/microsoft/dotnet-podcasts)
* [Running sample app (Azure Container Apps Service)](https://dotnetpodcasts.azurewebsites.net/)

The .NET Podcasts app showcases the following technologies:

* [.NET](https://dotnet.microsoft.com/download/dotnet)
* [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet)
* [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
* [.NET MAUI](https://dotnet.microsoft.com/apps/maui)
* [Azure Container Apps](https://azure.microsoft.com/services/container-apps/)
* [Orleans](https://docs.microsoft.com/dotnet/orleans/overview)

## Share web UI Razor components, code, and static assets

The guidance in <xref:blazor/components/class-libraries> explains how to share Razor components using a Razor class library (RCL) but focuses on sharing developer-authored Razor components. Components provided by a Blazor project template can also be shared via an RCL across native and web projects:

* [`Index`](xref:blazor/project-structure)
* [`App`](xref:blazor/project-structure)
* [`MainLayout`](xref:blazor/components/layouts#mainlayout-component)
* [`NavMenu`](xref:blazor/fundamentals/routing#navlink-and-navmenu-components)

The Blazor Server and Blazor Hybrid projects are provided a project reference to the RCL. Use Visual Studio's built-in **Add** > **Project Reference** gesture, the .NET CLI's [`dotnet add reference` command](/dotnet/core/tools/dotnet-add-reference), or manually add the following to the project file:

```xml
<ItemGroup>
  <ProjectReference Include="{PATH TO RCL}" />
</ItemGroup>
```

The `{PATH TO RCL}` placeholder is the relative path to the RCL project from either the .NET MAUI Blazor or Blazor Server projects. For an RCL named `SharedLibrary` with a relative path:

```xml
<ItemGroup>
  <ProjectReference Include="..\SharedLibrary\SharedLibrary.csproj" />
</ItemGroup>
```

Create a `Pages` folder in the RCL project if it doesn't exist. Place `Index.razor` in the `Pages` folder. You can move the existing `Index.razor` file from the `Pages` folder of the Blazor Server app to the RCL. If the Blazor Hybrid app is a .NET MAUI Blazor app, you can also delete the `Pages/Index.razor` file in the .NET MAUI Blazor project.

Move the `App` component from the Blazor Server project to the root of the RCL. Add the RCL's namespace to the Blazor Server app's `Pages/_Host.cshtml` file:

```cshtml
@using SharedLibrary
```

If the Blazor Hybrid app is a .NET MAUI app:

* The analogous component to the `App` component of a Blazor Server app is the `Main` component.
* You can delete the `Main` component from the .NET MAUI Blazor app.

The .NET MAUI Blazor project's root component namespace and assembly are added to the `<ContentPage>` tag of `MainPage.xaml`:

```xaml
xmlns:{NAMESPACE}="clr-namespace:{PACKAGE ID/ASSEMBLY};assembly={PACKAGE ID/ASSEMBLY}"
```

Placeholders in the preceding example:

* `{NAMESPACE}`: The XML namespace.
* `{PACKAGE ID/ASSEMBLY}`: The library's [package ID](/nuget/create-packages/creating-a-package-msbuild#set-properties). The package ID defaults to the project's assembly name if `<PackageId>` isn't specified in the project file.

Using the `SharedLibrary` RCL with an XML namespace of `sharedLib`:

```xaml
xmlns:sharedLib="clr-namespace:SharedLibrary;assembly=SharedLibrary"
```

Also in `MainPage.xaml` with the revised XML namespace (`sharedLib`), the root component is updated from `Main` to `App`:

```diff
- <RootComponent Selector="#app" ComponentType="{x:Type local:Main}" />
+ <RootComponent Selector="#app" ComponentType="{x:Type sharedLib:App}" />
```

> [!NOTE]
> Windows Forms apps set the root component inside `Form1`'s constructor (`Form1.cs`):
>
> ```csharp
> using SharedLibrary;
>
> ...
>
> blazorWebView1.RootComponents.Add<SharedLibrary.App>("#app");
> ```
>
> WPF apps set the root component in the `MainWindow.xaml` file:
>
> ```xaml
> xmlns:sharedLib="clr-namespace:SharedLibrary;assembly=SharedLibrary"
>
> ...
>
> <blazor:RootComponent Selector="#app" ComponentType="{x:Type sharedLib:App}" />
> ```

Create a `Shared` folder in the RCL project if it doesn't exist, or move the entire `Shared` folder from the Blazor Server project to the RCL if you plan to share all of the components in the `Shared` folder. Place the `MainLayout.razor`/`MainLayout.razor.css` and `NavMenu.razor`/`NavMenu.razor.css` in the `Shared` folder. For any shared components that are only used by the Blazor Server project, leave them in the Blazor Server project's `Shared` folder and only move the `MainLayout` and `NavMenu` components to the RCL's `Shared` folder. If the Blazor Hybrid project is a .NET MAUI Blazor app, remove the shared `Shared` folder assets from the .NET MAUI Blazor project as well.

Update the RCL's `_Imports.razor` file to include the typical namespaces that Blazor Server apps use. The following example is a good starting point, and additional namespaces can be added as needed:

`_Imports.razor` of the RCL:

```razor
@using System.Net.Http
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Components.Forms
@using Microsoft.AspNetCore.Components.Routing
@using Microsoft.AspNetCore.Components.Web
@using Microsoft.AspNetCore.Components.Web.Virtualization
@using Microsoft.JSInterop
@using {PACKAGE ID/ASSEMBLY}
@using {PACKAGE ID/ASSEMBLY}.Shared
```

As noted earlier, the `{PACKAGE ID/ASSEMBLY}` placeholder is the RCL's [package ID](/nuget/create-packages/creating-a-package-msbuild#set-properties). The package ID defaults to the project's assembly name if `<PackageId>` isn't specified in the project file. For an RCL named `SharedLibrary`, import namespaces for `SharedLibrary` and `SharedLibrary.Shared`.

In `_Imports.razor` of the RCL after the `System` and `Microsoft` namespaces:

```razor
...
@using SharedLibrary
@using SharedLibrary.Shared
```

Update or add the namespace of the RCL in the Blazor Server's `_Imports.razor` file:

* If the Blazor Server app's `Shared` folder remains in the app because the project exclusively uses remaining components in the folder, then *add* the RCL's `Shared` folder namespace to the file, along with adding the RCL's namespace:

  ```diff
  + @using {RCL PACKAGE ID/ASSEMBLY}
  + @using {RCL PACKAGE ID/ASSEMBLY}.Shared
  ```

* If the Blazor Server app's `Shared` folder is empty because all of the assets are moved to the RCL, *update* the `Shared` folder namespace to the RCL's `Shared` folder namespace, along with adding the RCL's namespace:

  ```diff
  - @using {BLAZOR SERVER ASSEMBLY}.Shared
  + @using {RCL PACKAGE ID/ASSEMBLY}
  + @using {RCL PACKAGE ID/ASSEMBLY}.Shared
  ```

For example:

```razor
...
@using SharedLibrary
@using SharedLibrary.Shared
```

Update or add the namespace of the RCL in the Blazor Hybrid's `_Imports.razor` file:

* If the Blazor Hybrid app's `Shared` folder remains in the app because the project exclusively uses remaining components in the folder, then *add* the RCL's `Shared` folder namespace to the file, along with adding the RCL's namespace:

  ```diff
  + @using {RCL PACKAGE ID/ASSEMBLY}
  + @using {RCL PACKAGE ID/ASSEMBLY}.Shared
  ```

* If the Blazor Hybrid app's `Shared` folder is empty because all of the assets are moved to the RCL, *update* the `Shared` folder namespace to the RCL's `Shared` folder namespace, along with adding the RCL's namespace:

  ```diff
  - @using {BLAZOR HYBRID ASSEMBLY}.Shared
  + @using {RCL PACKAGE ID/ASSEMBLY}
  + @using {RCL PACKAGE ID/ASSEMBLY}.Shared
  ```

For example:

```razor
...
@using SharedLibrary
@using SharedLibrary.Shared
```

Place additional shared code and static assets in the RCL:

* Images, JavaScript (`.js`), and stylesheets (`.css`): Place shared static assets into the RCL's `wwwroot` folder.

  The app's stylesheet (`wwwroot/css/app.css` or `wwwroot/css/site.css`) can be moved from the Blazor Hybrid project or the Blazor Server project to the RCL, as can the Bootstrap assets (`wwwroot/css/bootstrap` folder) and open iconic assets (`wwwroot/css/open-iconic` folder). After placing the shared assets into the RCL, they can be removed from the Blazor Hybrid and Blazor Server projects if they aren't referenced further by the apps.

  The Blazor Server app's `Pages/_Layout.cshtml` file and the Blazor Hybrid app's `wwwroot/index.html` file are updated to access these assets from the RCL. Remove the existing entries in the files for the local Bootstrap and stylesheet assets, as they're no longer in the individual apps after they're moved to the RCL.

  ```html
  <link rel="stylesheet" href="_content/{PACKAGE ID/ASSEMBLY}/css/bootstrap/bootstrap.min.css" />
  <link href="_content/{PACKAGE ID/ASSEMBLY}/css/app.css" rel="stylesheet" />
  ```

  For an RCL named `SharedLibrary`:

  ```html
  <link rel="stylesheet" href="_content/SharedLibrary/css/bootstrap/bootstrap.min.css" />
  <link href="_content/SharedLibrary/css/app.css" rel="stylesheet" />
  ```

  > [!NOTE]
  > In a Blazor WebAssembly app, the preceding `<link>` tags are in the `wwwroot/index.html` file.

* Place additional shared components and C# code into the RCL.

  > [!IMPORTANT]
  > A service can only be moved to the RCL and registered without further changes *if the service doesn't rely on hosting model-specific API*. If a service must be implemented independently by hosting model, see the guidance in the [Provide code and services independent of hosting model](#provide-code-and-services-independent-of-hosting-model) section.

  Apps created from the Blazor Server and .NET MAUI Blazor project templates include a `Pages/FetchData` component that obtains weather data from a registered service. Components can be placed into the RCL's `Pages` folder and shared between the Blazor Server and Blazor Hybrid projects, along with associated C# code, such as the `WeatherForecast` class (`Data/WeatherForecast.cs`) and the `WeatherForecastService` class (`Data/WeatherForecastService.cs`).
  
  Update the namespaces to match the RCL (for example, `namespace SharedLibrary.Data`). The shared `FetchData` component in the RCL is updated to use the namespace of the RCL's `Data` folder to access the `WeatherForecastService`. The following example assumes that the `FetchData` component is moved from the Blazor Server app to the RCL with a Blazor Server project name of `BlazorWeb`:

  ```diff
  - @using BlazorWeb.Data
  + @using SharedLibrary.Data
  ```
  
  You can move the entire `Data` folder to move the class files if there are no classes in the `Data` folder specific to the Blazor Server project. Each of the projects consuming the RCL in the solution can drop their `Data` folder assets and the components moved to the RCL.

  The Blazor Server and the Blazor Hybrid service registrations register the same service when the RCL provides a common service. In both .NET MAUI Blazor's `MauiProgram.cs` and Blazor Server's `Program.cs`, add the namespace for the RCL's `Data` folder assets and register the RCL's `WeatherForecastService`:

  ```csharp
  using SharedLibrary.Data;

  ...

  builder.Services.AddSingleton<WeatherForecastService>();
  ```

  > [!NOTE]
  > Windows Forms Blazor projects register services in `Form1`'s contstructor (`Form1.cs`). WPF Blazor projects register services in `MainWindow`'s constructor (`MainWindow.xaml`).

  Remove the `Data` folder namespace in the Blazor Hybrid and Blazor Server projects:

  ```diff
  - using BlazorNative.Data;
  ```

  ```diff
  - using BlazorWeb.Data;
  ```

  For additinal information on how to share static assets across projects, see the following articles:

  * <xref:blazor/components/class-libraries>
  * <xref:razor-pages/ui-class>

## Provide code and services independent of hosting model

When code must differ for across hosting models, abstract the code as interfaces and inject the service implementations into each project.

For demonstration purposes, the following example:

* Assumes that a `CustomService` class must be implemented for each hosting model, including the platforms of a .NET MAUI Blazor app, because the code for the service differs for each platform (Android, macOS, Windows, iOS) and a Blazor Server/Blazor WebAssembly app.
* Places an interface for the service in the Razor class library (RCL). The RCL is named `SharedLibrary`. The interface defines a method that returns a message.

`Interfaces/ICustomService.cs` in the RCL:

```csharp
namespace SharedLibrary.Interfaces
{
    public interface ICustomService
    {
        string GetMessage();
    }
}
```

In the following examples, the RCL implements the `ICustomService` interface for each platform in a `Platforms` folder at the root of the RCL.

`Platforms/Android/CustomService.cs`:

```csharp
using SharedLibrary.Interfaces;

namespace SharedLibrary.Platforms.Android
{
    public class CustomService : ICustomService
    {
        public string GetMessage()
        {
            return "Android implementation of ICustomService.";
        }
    }
}
```

`Platforms/MacCatalyst/CustomService.cs`:

```csharp
using SharedLibrary.Interfaces;

namespace SharedLibrary.Platforms.MacCatalyst
{
    public class CustomService : ICustomService
    {
        public string GetMessage()
        {
            return "Mac Catalyst implementation of ICustomService.";
        }
    }
}
```

`Platforms/Windows/CustomService.cs`:

```csharp
using SharedLibrary.Interfaces;

namespace SharedLibrary.Platforms.Windows
{
    public class CustomService : ICustomService
    {
        public string GetMessage()
        {
            return "Windows implementation of ICustomService.";
        }
    }
}
```

`Platforms/iOS/CustomService.cs`:

```csharp
using SharedLibrary.Interfaces;

namespace SharedLibrary.Platforms.iOS
{
    public class CustomService : ICustomService
    {
        public string GetMessage()
        {
            return "iOS implementation of ICustomService.";
        }
    }
}
```

In the following example, the RCL implements the `ICustomService` interface for the web (Blazor Server or Blazor WebAssembly) in a `Web` folder at the root of the RCL:

`Web/CustomService.cs`:

```csharp
using SharedLibrary.Interfaces;

namespace SharedLibrary.Web
{
    public class CustomService : ICustomService
    {
        public string GetMessage()
        {
            return "Web implementation of ICustomService.";
        }
    }
}
```

The following example is for a .NET MAUI app in the solution that:

* References the `SharedLibrary` project in its project file.
* Registers the appropriate `CustomService` implmentation for each platform.

In the app's project file (`.csproj`):

```xml
<ItemGroup>
  <ProjectReference Include="..\SharedLibrary\SharedLibrary.csproj" />
</ItemGroup>
```

In `MauiProgram` (`MauiProgram.cs`):

```csharp
using SharedLibrary.Interfaces;

...

#if WINDOWS
    builder.Services.AddSingleton<SharedLibrary.ICustomService, 
        SharedLibrary.Platforms.Windows.CustomService>();
#elif ANDROID
    builder.Services.AddSingleton<SharedLibrary.ICustomService, 
        SharedLibrary.Platforms.Android.CustomService>();
#elif MACCATALYST
    builder.Services.AddSingleton<SharedLibrary.ICustomService, 
        SharedLibrary.Platforms.MacCatalyst.CustomService>();
#elif IOS
    builder.Services.AddSingleton<SharedLibrary.ICustomService, 
        SharedLibrary.Platforms.iOS.CustomService>();
#endif
```

> [!NOTE]
> Windows Forms Blazor projects register services in `Form1`'s contstructor (`Form1.cs`). WPF Blazor projects register services in `MainWindow`'s constructor (`MainWindow.xaml`).

The following example for a Blazor Server or Blazor WebAssembly project:

* References the `SharedLibrary` project in its project file.
* Registers the appropriate `CustomService` implmentation for web-based clients.

In the Blazor Server or Blazor WebAssembly app's project file (`.csproj`):

```xml
<ItemGroup>
  <ProjectReference Include="..\SharedLibrary\SharedLibrary.csproj" />
</ItemGroup>
```

In `Program.cs`, the project registers the custom service, `SharedLibrary.Web.CustomService`:

```csharp
builder.Services.AddSingleton<SharedLibrary.Interfaces.ICustomService, 
    SharedLibrary.Web.CustomService>();
```

A component can inject the `CustomService` and call the `GetMessage` method. Add the following `TestCustomService` component to the shared `Pages` folder of the RCL.

`Pages/TestCustomService.razor` in the RCL:

```razor
@page "/test-custom-service"
@using SharedLibrary.Interfaces;
@inject ICustomService CustomService

<PageTitle>Test Service</PageTitle>

<h3>Test Service</h3>

<p>
    <button class="btn btn-primary" @onclick="GetMessage">Get Message</button>
</p>

<p>
    @message
</p>

@code {
    private string message = string.Empty;

    private void GetMessage()
    {
        message = CustomService.GetMessage();
    }
}
```

Add navigation for the `TestCustomService` component.

In the `Shared/NavMenu.razor` file of the RCL:

```razor
<div class="nav-item px-3">
    <NavLink class="nav-link" href="test-custom-service">
        <span class="oi oi-list-rich" aria-hidden="true"></span> Test service
    </NavLink>
</div>
```

Regardless of where a C# class resides, a class can inject the `CustomService` and call `LogMessage`:

```csharp
using SharedLibrary.Interfaces;

public class ExampleClass
{
    private readonly ICustomService customService;

    public ExampleClass(ICustomService customService)
    {
        this.customService = customService;
    }
}
```

In an `ExampleClass` method:

```csharp
var message = customService.GetMessage();
```

## Additional resources

* <xref:blazor/components/class-libraries>
* <xref:razor-pages/ui-class>
* [CSS isolation support with Razor class libraries](xref:blazor/components/css-isolation#razor-class-library-rcl-support)
