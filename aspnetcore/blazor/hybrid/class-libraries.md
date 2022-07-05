---
title: Share assets across web and native clients using a Razor class library (RCL)
author: guardrex
description: Learn how to share Razor components for UI across web and native clients from an external Razor class library (RCL).
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 07/06/2022
uid: blazor/hybrid/class-libraries
---
# Share assets across web and native clients using a Razor class library (RCL)

Use a [Razor class library (RCL)](xref:razor-pages/ui-class) to share the following assets across web and native client projects:

* Razor components for common UI.
* Classes and code.
* Static assets.

A common use case for RCLs with Blazor Hybrid apps is to share components and code across a Blazor Server web app and a Blazor Hybrid mobile and desktop app (.NET MAUI, WPF, or Windows Forms) in a hosting model agnostic way. This article builds on the general concepts found in <xref:blazor/components/class-libraries>.

## Advanced sample app

For an advanced example of the scenarios described in this article, see the .NET Podcasts sample app:

* [GitHub repository (`microsoft/dotnet-podcasts`)](https://github.com/microsoft/dotnet-podcasts)
* [Running sample app (Azure Container Apps Service)](https://dotnetpodcasts.azurewebsites.net/)

The .NET Podcasts app showcases the following technologies:

* [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0)
* [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet)
* [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
* [.NET MAUI](https://dotnet.microsoft.com/apps/maui)
* [Azure Container Apps](https://azure.microsoft.com/services/container-apps/#overview)
* [Orleans](https://docs.microsoft.com/dotnet/orleans/overview)

## Share web UI Razor components, code, and static assets

The guidance in <xref:blazor/components/class-libraries> explains how to share Razor components using an RCL but focuses on sharing developer-authored Razor components. Components provided by a Blazor project template of a more general nature can also be shared via an RCL, such as the following components:

* [`Index`](xref:blazor/project-structure)
* [`App`](xref:blazor/project-structure)
* [`MainLayout`](xref:blazor/components/layouts#mainlayout-component)
* [`NavMenu`](xref:blazor/fundamentals/routing#navlink-and-navmenu-components)

Sharing the preceding components follows the guidance found in the <xref:blazor/components/class-libraries>. The following example shares components between a Blazor Server app and a .NET MAUI Blazor app in the same solution.

Create an RCL in the solution side-by-side with the Blazor Server and Blazor Hybrid projects. To create an RCL for a solution of web and native client projects, follow the guidance in <xref:blazor/components/class-libraries>. Optionally, access the additional guidance on RCLs that apply broadly to ASP.NET Core apps in <xref:razor-pages/ui-class>.

The examples in this article use the following project names:

* RCL: `SharedLibrary`
* Blazor Hybrid (.NET MAUI Blazor): `BlazorNative`
* Blazor Server: `BlazorWeb`

Create project references for the RCL in the Blazor Server and Blazor Hybrid projects.

Create a `Pages` folder in the RCL project if it doesn't exist. Place `Index.razor` in the `Pages` folder. You can move the existing `Index.razor` file from the `Pages` folder of the Blazor Server app to the RCL. If the Blazor Hybrid app is a .NET MAUI Blazor app, you can also delete the `Pages/Index.razor` file in the .NET MAUI Blazor project.

Move the `App` component from the Blazor Server project to the root of the RCL. Add the RCL's namespace to the Blazor Server app's `Pages/_Host.cshtml` file:

```cshtml
@using SharedLibrary
```

If the Blazor Hybrid app is a .NET MAUI app, the analogous component to the `App` component is the `Main` component, and you can delete the `Main` component from the .NET MAUI Blazor app.

The Blazor Hybrid's root component namespace and assembly are added to the `<ContentPage>` tag of `MainPage.xaml`:

```xml
xmlns:{NAMESPACE}="clr-namespace:{PACKAGE ID/ASSEMBLY};assembly={PACKAGE ID/ASSEMBLY}"
```

The `{NAMESPACE}` placeholder is the XML namespace. The `{PACKAGE ID/ASSEMBLY}` placeholder is the library's [package ID](/nuget/create-packages/creating-a-package-msbuild#set-properties). The package ID defaults to the project's assembly name if `<PackageId>` isn't specified in the project file. For example using `SharedLibrary` with an XML namespace of `sharedLib`:

```xml
xmlns:sharedLib="clr-namespace:SharedLibrary;assembly=SharedLibrary"
```

Also in `MainPage.xaml`, update the root component in the .NET MAUI app (`Mainpage.xaml`) from `Main` to `App` with the revised XML namespace (`sharedLib`):

```diff
- <RootComponent Selector="#app" ComponentType="{x:Type local:Main}" />
+ <RootComponent Selector="#app" ComponentType="{x:Type sharedLib:App}" />
```

Create a `Shared` folder in the RCL project if it doesn't exist, or you can move the entire `Shared` folder from the Blazor Server project to the RCL if all of the components in the `Shared` folder will be shared. Place the `MainLayout.razor`/`MainLayout.razor.css` and `NavMenu.razor`/`NavMenu.razor.css` in the `Shared` folder. For any shared components that are only used by the Blazor Server project, leave them in the Blazor Server project's `Shared` folder and only move the `MainLayout` and `NavMenu` components to the RCL's `Shared` folder. Remove the `Shared` folder assets in the .NET MAUI Blazor project as well.

Update the RCL's `_Imports.razor` file to include the typical namespaces that Blazor Server apps use. The following example is a good starting point, and additional namespaces can be added as required:

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

As noted earlier, the package ID/assembly placeholder is the library's [package ID](/nuget/create-packages/creating-a-package-msbuild#set-properties). The package ID defaults to the project's assembly name if `<PackageId>` isn't specified in the project file. For an RCL named `SharedLibrary`, import namespaces for `SharedLibrary` and `SharedLibrary.Shared`.

In `_Imports.razor` of the RCL:

```razor
...
@using SharedLibrary
@using SharedLibrary.Shared
```

Update or add the namespace of the the RCL in the Blazor Server's `_Imports.razor` file. The `Shared` folder remains in the app because the project exclusively uses components in the folder, then add the RCL's `Shared` folder namespace to the file:

```diff
+ @using {RCL PACKAGE ID/ASSEMBLY}
+ @using {RCL PACKAGE ID/ASSEMBLY}.Shared
```

If the Blazor Server app's `Shared` folder is empty because all of the assets are moved to the RCL, update the `Shared` folder namespace to the RCL's `Shared` folder namespace:

```diff
- @using {BLAZOR SERVER ASSEMBLY}.Shared
+ @using {RCL PACKAGE ID/ASSEMBLY}
+ @using {RCL PACKAGE ID/ASSEMBLY}.Shared
```

For example:

```razor
@using SharedLibrary
@using SharedLibrary.Shared
```

If the .NET MAUI Blazor app's `Shared` folder is empty because all of the assets are moved to the RCL, update the `Shared` folder namespace to the RCL's `Shared` folder namespace:

```diff
- @using {.NET MAUI BLAZOR ASSEMBLY}.Shared
+ @using {RCL PACKAGE ID/ASSEMBLY}
+ @using {RCL PACKAGE ID/ASSEMBLY}.Shared
```

For example:

```razor
@using SharedLibrary
@using SharedLibrary.Shared
```

Place additional shared code and static assets in the RCL:

* Images, JavaScript, and stylesheets: Place shared static assets into the RCL's `wwwroot` folder, typically as they would be laid out in a Blazor Server app: The app's stylesheet (`wwwroot/css/app.css` or `wwwroot/css/site.css`) can be moved from the Blazor Hybrid project or the Blazor Server project to the RCL, as can the Bootstrap assets (`wwwroot/css/bootstrap` folder) and open iconic assets (`wwwroot/css/open-iconic` folder). After placing the shared assets into the RCL, they can be removed from the Blazor Hybrid and Blazor Server projects if they aren't referenced further by the apps.

  The Blazor Server app's `Pages/_Layout.cshtml` file and the Blazor Hybrid app's `wwwroot/index.html` file are updated to access these assets from the RCL:

  ```html
  <link rel="stylesheet" href="_content/{PACKAGE ID/ASSEMBLY}/css/bootstrap/bootstrap.min.css" />
  <link href="_content/{PACKAGE ID/ASSEMBLY}/css/app.css" rel="stylesheet" />
  ```

  For an RCL named `SharedLibrary`:

  ```html
  <link rel="stylesheet" href="_content/SharedLibrary/css/bootstrap/bootstrap.min.css" />
  <link href="_content/SharedLibrary/css/app.css" rel="stylesheet" />
  ```

* Place additional hosting model agnostic components and code into the RCL.

  For example, apps created from the Blazor Server and .NET MAUI Blazor project templates include a `Pages/FetchData` component that obtains weather data from a registered service.
  
  If the `FetchData` component is placed in the RCL's `Pages` folder and shared between the Blazor Server and Blazor Hybrid projects, the `WeatherForecast` class (`Data/WeatherForecast.cs` file) and the `WeatherForecastService` class (`Data/WeatherForecastService.cs` file) are moved from the Blazor Server project to the RCL.
  
  Update the namespaces to match the RCL (for example, `namespace SharedLibrary.Data`). The shared `FetchData` component in the RCL is updated to use the namespace of the RCL's `Data` folder to access the `WeatherForecastService`. The following example assumes that the `FetchData` component is moved from the Blazor Server app to the RCL, and the Blazor Server project is named `BlazorWeb`:

  ```diff
  - @using BlazorWeb.Data
  + @using SharedLibrary.Data
  ```
  
  You can move the entire `Data` folder to move these class files if there are no classes in the `Data` folder specific to the Blazor Server project. Each of the apps consuming the RCL can drop the `Data` assets and their `FetchData` components.

  The Blazor Server and the Blazor Hybrid service registrations register the same service when the RCL provides a common service that's agnostic to the hosting model. In both `MauiProgram.cs` (.NET MAUI Blazor) and `Program.cs`, add the namespace for the `Data` folder assets of the RCL and register `WeatherForecastService`:

  ```csharp
  using SharedLibrary.Data;

  ...

  builder.Services.AddSingleton<WeatherForecastService>();
  ```

  Remove the `Data` folder namespace in the .NET MAUI Blazor app and the Blazor Server app:

  ```diff
  - using BlazorNative.Data;
  ```

  ```diff
  - using BlazorWeb.Data;
  ```

## Provide hosting model agnostic code

When component code must differ for hosting models, the hosting model-specific functionality is typically abstracted as interfaces and then injected as service implementations for each project.

In the following example, `CustomService` must be implemented for each platform and the web because the code for the service differs for each platform (Android, macOS, Windows, iOS) and a Blazor Server app for web-based clients.

An interface for the service is placed in the RCL, which is named `SharedLibrary` in the following example. The interface defines a method unique to each platform and the web that logs a message:

In the root folder of the RCL, `ICustomService.cs`:

```csharp
public interface ICustomService
{
    void LogMessage();
}
```

In the following examples, the RCL implements the `ICustomService` interface for each platform in a `Platforms` folder at the root of the RCL.

`Platforms/Android/CustomService.cs`:

```csharp
using Microsoft.Extensions.Logging;

namespace SharedLibrary.Platforms.Android
{
    public class CustomService : ICustomService
    {
        private ILogger<CustomService> logger;

        public CustomService(ILogger<CustomService> logger)
        {
            this.logger = logger;
        }

        public void LogMessage()
        {
            logger.LogInformation("Android implementation of ICustomService.");
        }
    }
}
```

`Platforms/MacCatalyst/CustomService.cs`:

```csharp
using Microsoft.Extensions.Logging;

namespace SharedLibrary.Platforms.MacCatalyst
{
    public class CustomService : ICustomService
    {
        private ILogger<CustomService> logger;

        public CustomService(ILogger<CustomService> logger)
        {
            this.logger = logger;
        }

        public void LogMessage()
        {
            logger.LogInformation("Mac Catalyst implementation of ICustomService.");
        }
    }
}
```

`Platforms/Windows/CustomService.cs`:

```csharp
using Microsoft.Extensions.Logging;

namespace SharedLibrary.Platforms.Windows
{
    public class CustomService : ICustomService
    {
        private ILogger<CustomService> logger;

        public CustomService(ILogger<CustomService> logger)
        {
            this.logger = logger;
        }

        public void LogMessage()
        {
            logger.LogInformation("Windows implementation of ICustomService.");
        }
    }
}
```

`Platforms/iOS/CustomService.cs`:

```csharp
using Microsoft.Extensions.Logging;

namespace SharedLibrary.Platforms.iOS
{
    public class CustomService : ICustomService
    {
        private ILogger<CustomService> logger;

        public CustomService(ILogger<CustomService> logger)
        {
            this.logger = logger;
        }

        public void LogMessage()
        {
            logger.LogInformation("iOS implementation of ICustomService.");
        }
    }
}
```

In the following example, the RCL implements the `ICustomService` interface for the web (Blazor Server) in a `Web` folder at the root of the RCL:

`Web/CustomService.cs`:

```csharp
using Microsoft.Extensions.Logging;

namespace SharedLibrary.Web
{
    public class CustomService : ICustomService
    {
        private ILogger<CustomService> logger;

        public CustomService(ILogger<CustomService> logger)
        {
            this.logger = logger;
        }

        public void LogMessage()
        {
            logger.LogInformation("Web implementation of ICustomService.");
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

The following example is for a Blazor Server app in the same solution as the .NET MAUI project that:

* References the `SharedLibrary` project in its project file.
* Registers the appropriate `CustomService` implmentation for the web-based clients of the Blazor Server app.

In the Blazor Server app's project file (`.csproj`):

```xml
<ItemGroup>
  <ProjectReference Include="..\SharedLibrary\SharedLibrary.csproj" />
</ItemGroup>
```

In `Program.cs`, the Blazor Server app registers the custom logging service, `SharedLibrary.Web.CustomService`:

```csharp
builder.Services.AddSingleton<SharedLibrary.ICustomService, 
    SharedLibrary.Web.CustomService>();
```

A component can inject the `CustomService` and call the `LogMessage` method. Add the following `TestCustomService` component to either the shared `Pages` folder in the solutions's RCL or to each app's `Pages` folder when it won't be shared across apps:

`Pages/TestCustomService.razor`:

```razor
@page "/test-custom-service"
@inject ICustomService CustomService

<h3>Test Service</h3>

<button class="btn btn-primary" @onclick="LogIt">Log IT!</button>

@code {
    private void LogIt()
    {
        CustomService.LogMessage();
    }
}
```

Add the component to either the shared `NavMenu` component in the solution's RCL or to the `NavMenu` component of each app when the navigation menu isn't shared across apps:

```razor
<div class="nav-item px-3">
    <NavLink class="nav-link" href="test-custom-service">
        <span class="oi oi-list-rich" aria-hidden="true"></span> Test service
    </NavLink>
</div>
```

Regardless of where a C# class resides, a class can inject the `CustomService` and call `LogMessage`:

```csharp
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
customService.LogMessage();
```

## Additional resources

* <xref:blazor/components/class-libraries>
* <xref:razor-pages/ui-class>
* [CSS isolation support with Razor class libraries](xref:blazor/components/css-isolation#razor-class-library-rcl-support)
