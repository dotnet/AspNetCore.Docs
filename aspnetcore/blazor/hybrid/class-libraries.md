---
title: Share assets across web and native clients using a Razor class library (RCL)
author: guardrex
description: Learn how to share Razor components for UI across web and native clients from an external Razor class library (RCL).
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 06/27/2022
uid: blazor/hybrid/class-libraries
---
# Share assets across web and native clients using a Razor class library (RCL)

Use a [Razor class library (RCL)](xref:razor-pages/ui-class) to share the following assets across web and native client projects:

* Razor components for common UI.
* Classes and code.
* Static assets.

Before consuming the guidance in this article, we recommend reading <xref:blazor/components/class-libraries> because this article builds on the general concepts found in the *Class libraries* article.

A common use case for RCLs with Blazor Hybrid apps is to share components and code across a Blazor Server web app and a Blazor Hybrid mobile and desktop app (.NET MAUI, WPF, or Windows Forms) in a hosting model agnostic way.

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

## Create an RCL

To create an RCL, follow the guidance in <xref:blazor/components/class-libraries>.

Optionally, access the additional guidance that applies broadly to ASP.NET Core apps in <xref:razor-pages/ui-class>.

## Share web UI Razor components, code, and static assets

The guidance in <xref:blazor/components/class-libraries> explains how to share Razor components using an RCL but focuses on sharing developer-authored Razor components that aren't foundational to the functioning of a typical Blazor app, such as the following components:

* [`Index`](xref:blazor/project-structure)
* [`App`](xref:blazor/project-structure)
* [`MainLayout`](xref:blazor/components/layouts#mainlayout-component)
* [`NavMenu`](xref:blazor/fundamentals/routing#navlink-and-navmenu-components)

In principle, sharing the preceding components follows the guidance found in the <xref:blazor/components/class-libraries>:

* Create an RCL in the solution side-by-side with the Blazor Server and Blazor Hybrid projects.
* Create project references for the RCL in the Blazor Server and Blazor Hybrid projects.
* Place `Index.razor` in the `Pages` folder of the RCL. Create the `Pages` folder manually if it doesn't already exist in the RCL project. You can move the existing `Index.razor` file from the `Pages` folder of the Blazor Server app to the RCL and then delete the `Index` component from the Blazor Server app.
* Place the `App` component at the root of the RCL.
* Place the `MainLayout.razor`/`MainLayout.razor.css` and `NavMenu.razor`/`NavMenu.razor.css` in a `Shared` folder of the RCL. Create the `Shared` folder manually if it doesn't already exist in the RCL project. You can move the entire `Shared` folder from the Blazor Server project to the RCL if all of the components in the `Shared` folder will be shared. For any shared components that are only used by the Blazor Server project, leave them in the Blazor Server project's `Shared` folder and only move the `MainLayout` and `NavMenu` components to the RCL's `Shared` folder.
* Update the RCL's `_Imports.razor` file to include the typical namespaces that Blazor Server apps use. The following example is a good starting point, and additional namespaces can be added as required:

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

  The `{PACKAGE ID/ASSEMBLY}` placeholder is the library's [package ID](/nuget/create-packages/creating-a-package-msbuild#set-properties). The package ID defaults to the project's assembly name if `<PackageId>` isn't specified in the project file. For example, an RCL named `SharedLibrary` without a different `PackageId` setting in the project file imports namespaces for `SharedLibrary` and `SharedLibrary.Shared`:

  ```razor
  ...
  @using SharedLibrary
  @using SharedLibrary.Shared
  ```

* Set the Blazor Hybrid's root component namespace and assembly in the `<ContentPage>` tag of `MainPage.xaml`:

  ```xml
  xmlns:bc="clr-namespace:{PACKAGE ID/ASSEMBLY};assembly={PACKAGE ID/ASSEMBLY}"
  ```

  For example, an RCL with the package ID/assembly name of `SharedLibrary`:

  ```xml
  xmlns:bc="clr-namespace:SharedLibrary;assembly=SharedLibrary"
  ```

* Place additional shared code and static assets in the RCL:

  * Images, JavaScript, and stylesheets: Place shared static assets into the RCL's `wwwroot` folder, typically as they would be laid out in a Blazor Server app: The app's stylesheet (`wwwroot/css/app.css`) can be moved from the Blazor Server project to the RCL, as can the Bootstrap assets (`wwwroot/css/bootstrap` folder).

    The Blazor Server app's `Pages/_Layout.cshtml` file and the Blazor Hybrid app's `wwwroot/index.html` file are updated to access these assets from the RCL:

    ```html
    <link rel="stylesheet" href="_content/{PACKAGE ID/ASSEMBLY}/css/bootstrap/bootstrap.min.css" />
    <link href="_content/{PACKAGE ID/ASSEMBLY}/css/app.css" rel="stylesheet" />
    ```

    For example, an RCL with the assembly name/package ID of `SharedLibrary`:

    ```html
    <link rel="stylesheet" href="_content/SharedLibrary/css/bootstrap/bootstrap.min.css" />
    <link href="_content/SharedLibrary/css/app.css" rel="stylesheet" />
    ```

  * Additional hosting model agnostic components and code: For example, an app created from the Blazor Server project template includes a `FetchData` component that obtains weather data from a registered service. If the `FetchData` component is placed in the RCL's `Pages` folder and shared between the Blazor Server and Blazor Hybrid projects, the `WeatherForecast` class (`Data/WeatherForecast.cs` file) and the `WeatherForecastService` class (`Data/WeatherForecastService.cs` file) are moved from the Blazor Server project to the RCL. You can move the entire `Data` folder to move these class files if there are no classes in the `Data` folder specific to the Blazor Server project.

    The Blazor Server and the Blazor Hybrid service registrations register the same service when the RCL provides a common service that's agnostic to the hosting model. For example, the `WeatherForecastService` can be used across hosting models. Each of the solution's projects register the same service from the RCL:

    ```csharp
    builder.Services.AddSingleton<WeatherForecastService>();
    ```

## Provide hosting model agnostic code

When component code must differ for hosting models across platforms, the hosting model-specific functionality is typically abstracted as interfaces and then injected as service implementations for each platform.

In the following example, `CustomService` must be implemented for each platform because the code for the service differs for each platform: Blazor Server, Android, macOS, Windows, and iOS.

An interface for the service is placed in the RCL, which is named `SharedLibrary` in the following example. The interface defines a method unique to each platform that logs a message:

`ICustomService.cs` placed in the root folder of the RCL:

```csharp
public interface ICustomService
{
    void LogMessage();
}
```

The RCL implements the `ICustomService` interface for each platform in a `Platforms` folder at the root of the RCL:

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

The following example is for a .NET MAUI app that:

* References the `SharedLibrary` project in its project file.
* Registers the appropriate implmentation for each platform.

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

XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

BLAZOR SERVER EXAMPLE USE HERE

XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX


Regardless of where a component resides, in the `SharedLibrary` or in the .NET MAUI app (`Pages` folder), it can inject the `CustomService` and call the `LogMessage` method:

```razor
@inject CustomService CustomService
```

In a component `@code` method:

```csharp
CustomService.LogMessage();
```

Regardless of where a C# class resides, in the library or in the app, it can inject the `CustomService` and call `LogMessage`:

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
