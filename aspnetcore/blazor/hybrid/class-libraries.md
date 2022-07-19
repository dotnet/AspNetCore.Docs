---
title: Share assets across web and native clients using a Razor class library (RCL)
author: guardrex
description: Learn how to share Razor components, C# code, and static assets across web and native clients using a Razor class library (RCL).
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 07/19/2022
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
* The RCL examples name the project `SharedLibrary`, which becomes part of namespace and assembly references in the examples.

For guidance on creating an RCL, see <xref:blazor/components/class-libraries>. Optionally, access the additional guidance on RCLs that apply broadly to ASP.NET Core apps in <xref:razor-pages/ui-class>.

## Sample app

For an example of the scenarios described in this article, see the .NET Podcasts sample app:

* [GitHub repository (`microsoft/dotnet-podcasts`)](https://github.com/microsoft/dotnet-podcasts)
* [Running sample app (Azure Container Apps Service)](https://dotnetpodcasts.azurewebsites.net/)

The .NET Podcasts app showcases the following technologies:

* [.NET](https://dotnet.microsoft.com/download/dotnet)
* [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet)
* [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor)
* [.NET MAUI](https://dotnet.microsoft.com/apps/maui)
* [Azure Container Apps](https://azure.microsoft.com/services/container-apps/)
* [Orleans](/dotnet/orleans/overview)

## Share web UI Razor components, code, and static assets

Components from an RCL can be simultaneously shared by web and native client apps built using Blazor. The guidance in <xref:blazor/components/class-libraries> explains how to share Razor components using a Razor class library (RCL). The same guidance applies to reusing Razor components from an RCL in a Blazor Hybrid app.

Component namespaces are derived from the RCL's package ID or assembly name and the component's folder path within the RCL. For more information, see <xref:blazor/components/index#namespaces>. [`@using`](xref:mvc/views/razor#using) directives can be placed in `_Imports.razor` files for components and code, as the following example deomonstrates for an RCL named `SharedLibrary` with a `Shared` folder of shared Razor components and a `Data` folder of shared data classes:

```razor
@using SharedLibrary
@using SharedLibrary.Shared
@using SharedLibrary.Data
```

Place shared static assets in the RCL's `wwwroot` folder and update `<link>` element paths:

> :::no-loc text="_content/{PACKAGE ID/ASSEMBLY}/{PATH}/{FILENAME}":::

Placeholders:

* `{PACKAGE ID/ASSEMBLY}`: The package ID or assembly name of the RCL.
* `{PATH}`: Optional path within the RCL's `wwwroot` folder.
* `{FILENAME}`: The filename of the static asset.

For an RCL named `SharedLibrary` and using the minified Bootstrap stylesheet as an example:

> :::no-loc text="_content/SharedLibrary/css/bootstrap/bootstrap.min.css":::

For additional information on how to share static assets across projects, see the following articles:

* <xref:blazor/components/class-libraries>
* <xref:razor-pages/ui-class>

The root `index.html` file is specific to the app and should remain in the Blazor Hybrid app.

The root Razor Component (`App.razor` or `Main.razor`) can be shared, but often might need to be specific to the hosting app. For example, `App.razor` is different in the Blazor Server and Blazor WebAssembly project templates when authentication is enabled for apps. You can add the [`AdditionalAssemblies` parameter](xref:blazor/fundamentals/routing#route-to-components-from-multiple-assemblies) to specify the location of any shared routable components, and you can specify a [shared default layout component for the router](xref:blazor/fundamentals/routing#route-templates) by type name.

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

Regardless of where a C# class resides, a class can inject the `CustomService` and call `GetMessage`:

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
