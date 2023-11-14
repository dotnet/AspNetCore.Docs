---
title: Share assets across web and native clients using a Razor class library (RCL)
author: guardrex
description: Learn how to share Razor components, C# code, and static assets across web and native clients using a Razor class library (RCL).
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/hybrid/class-libraries
---
# Share assets across web and native clients using a Razor class library (RCL)

[!INCLUDE[](~/includes/not-latest-version.md)]

Use a Razor class library (RCL) to share Razor components, C# code, and static assets across web and native client projects.

This article builds on the general concepts found in the following articles:

* <xref:blazor/components/class-libraries>
* <xref:razor-pages/ui-class>

The examples in this article share assets between a Blazor Server app and a .NET MAUI Blazor Hybrid app in the same solution:

* Although a Blazor Server app is used, the guidance applies equally to Blazor WebAssembly apps sharing assets with a Blazor Hybrid app.
* Projects are in the same [solution](/visualstudio/ide/solutions-and-projects-in-visual-studio#solutions), but an RCL can supply shared assets to projects outside of a solution.
* The RCL is added as a project to the solution, but any RCL can be published as a NuGet package. A NuGet package can supply shared assets to web and native client projects.
* The order that the projects are created isn't important. However, projects that rely on an RCL for assets must create a project reference to the RCL *after* the RCL is created.

For guidance on creating an RCL, see <xref:blazor/components/class-libraries>. Optionally, access the additional guidance on RCLs that apply broadly to ASP.NET Core apps in <xref:razor-pages/ui-class>.

:::moniker range="= aspnetcore-6.0"

## Target frameworks for ClickOnce deployments

To publish a WPF or Windows Forms project with a Razor class library (RCL) in .NET 6 with [ClickOnce](/visualstudio/deployment/clickonce-security-and-deployment), the RCL must target `net6.0-windows` in addition to `net6.0`.

Example:

```xml
<TargetFrameworks>net6.0;net6.0-windows</TargetFrameworks>
```

For more information, see the following articles:

* [Target frameworks in SDK-style projects](/dotnet/standard/frameworks)
* [ClickOnce security and deployment](/visualstudio/deployment/clickonce-security-and-deployment)
* [Publish ClickOnce applications](/visualstudio/deployment/publishing-clickonce-applications)

:::moniker-end

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

Component namespaces are derived from the RCL's package ID or assembly name and the component's folder path within the RCL. For more information, see <xref:blazor/components/index#class-name-and-namespace>. [`@using`](xref:mvc/views/razor#using) directives can be placed in `_Imports.razor` files for components and code, as the following example demonstrates for an RCL named `SharedLibrary` with a `Shared` folder of shared Razor components and a `Data` folder of shared data classes:

```razor
@using SharedLibrary
@using SharedLibrary.Shared
@using SharedLibrary.Data
```

Place shared static assets in the RCL's `wwwroot` folder and update static asset paths in the app to use the following path format:

> :::no-loc text="_content/{PACKAGE ID/ASSEMBLY NAME}/{PATH}/{FILE NAME}":::

Placeholders:

* `{PACKAGE ID/ASSEMBLY NAME}`: The package ID or assembly name of the RCL.
* `{PATH}`: Optional path within the RCL's `wwwroot` folder.
* `{FILE NAME}`: The file name of the static asset.

The preceding path format is also used in the app for static assets supplied by a NuGet package added to the RCL.

For an RCL named `SharedLibrary` and using the minified Bootstrap stylesheet as an example:

> :::no-loc text="_content/SharedLibrary/css/bootstrap/bootstrap.min.css":::

For additional information on how to share static assets across projects, see the following articles:

* <xref:blazor/components/class-libraries>
* <xref:razor-pages/ui-class>

The root `index.html` file is usually specific to the app and should remain in the Blazor Hybrid app or the Blazor WebAssembly app. The `index.html` file typically isn't shared.

The root Razor Component (`App.razor` or `Main.razor`) can be shared, but often might need to be specific to the hosting app. For example, `App.razor` is different in the Blazor Server and Blazor WebAssembly project templates when authentication is enabled. You can add the [`AdditionalAssemblies` parameter](xref:blazor/fundamentals/routing#route-to-components-from-multiple-assemblies) to specify the location of any shared routable components, and you can specify a [shared default layout component for the router](xref:blazor/fundamentals/routing#route-templates) by type name.

## Provide code and services independent of hosting model

When code must differ across hosting models or target platforms, abstract the code as interfaces and inject the service implementations in each project.

The following weather data example abstracts different weather forecast service implementations:

* Using an HTTP request for Blazor Hybrid and Blazor WebAssembly.
* Requesting data directly for Blazor Server.

The example uses the following specifications and conventions:

* The RCL is named `SharedLibrary` and contains the following folders and namespaces:
  * `Data`: Contains the `WeatherForecast` class, which serves as a model for weather data.
  * `Interfaces`: Contains the service interface for the service implementations, named `IWeatherForecastService`.
* The `FetchData` component is maintained in the `Pages` folder of the RCL, which is routable by any of the apps consuming the RCL.
* Each Blazor app maintains a service implementation that implements the `IWeatherForecastService` interface.

`Data/WeatherForecast.cs` in the RCL:

```csharp
namespace SharedLibrary.Data;

public class WeatherForecast
{
    public DateTime Date { get; set; }
    public int TemperatureC { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    public string? Summary { get; set; }
}
```

`Interfaces/IWeatherForecastService.cs` in the RCL:

```csharp
using SharedLibrary.Data;

namespace SharedLibrary.Interfaces;

public interface IWeatherForecastService
{
    Task<WeatherForecast[]?> GetForecastAsync(DateTime startDate);
}
```

The `_Imports.razor` file in the RCL includes the following added namespaces:

```razor
@using SharedLibrary.Data
@using SharedLibrary.Interfaces
```

`Services/WeatherForecastService.cs` in the Blazor Hybrid and Blazor WebAssembly apps:

```csharp
using System.Net.Http.Json;
using SharedLibrary.Data;
using SharedLibrary.Interfaces;

namespace {APP NAMESPACE}.Services;

public class WeatherForecastService : IWeatherForecastService
{
    private readonly HttpClient http;

    public WeatherForecastService(HttpClient http)
    {
        this.http = http;
    }

    public async Task<WeatherForecast[]?> GetForecastAsync(DateTime startDate) =>
        await http.GetFromJsonAsync<WeatherForecast[]?>("WeatherForecast");
}
```

In the preceding example, the `{APP NAMESPACE}` placeholder is the app's namespace.

`Services/WeatherForecastService.cs` in the Blazor Server app:

```csharp
using SharedLibrary.Data;
using SharedLibrary.Interfaces;

namespace {APP NAMESPACE}.Services;

public class WeatherForecastService : IWeatherForecastService
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot"
    };

    public async Task<WeatherForecast[]?> GetForecastAsync(DateTime startDate) =>
        await Task.FromResult(Enumerable.Range(1, 5)
            .Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray());
}
```

In the preceding example, the `{APP NAMESPACE}` placeholder is the app's namespace.

The Blazor Hybrid, Blazor WebAssembly, and Blazor Server apps register their weather forecast service implementations (`Services.WeatherForecastService`) for `IWeatherForecastService`.

The Blazor WebAssembly project also registers an <xref:System.Net.Http.HttpClient>. The <xref:System.Net.Http.HttpClient> registered by default in an app created from the Blazor WebAssembly project template is sufficient for this purpose. For more information, see <xref:blazor/call-web-api>.

`Pages/FetchData.razor` in the RCL:

```razor
@page "/fetchdata"
@inject IWeatherForecastService ForecastService

<PageTitle>Weather forecast</PageTitle>

<h1>Weather forecast</h1>

@if (forecasts == null)
{
    <p><em>Loading...</em></p>
}
else
{
    <table class="table">
        <thead>
            <tr>
                <th>Date</th>
                <th>Temp. (C)</th>
                <th>Temp. (F)</th>
                <th>Summary</th>
            </tr>
        </thead>
        <tbody>
            @foreach (var forecast in forecasts)
            {
                <tr>
                    <td>@forecast.Date.ToShortDateString()</td>
                    <td>@forecast.TemperatureC</td>
                    <td>@forecast.TemperatureF</td>
                    <td>@forecast.Summary</td>
                </tr>
            }
        </tbody>
    </table>
}

@code {
    private WeatherForecast[]? forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
    }
}
```

<!--

HELD PER https://github.com/dotnet/AspNetCore.Docs/pull/26331#discussion_r927174745

### Example 2

The following example:

* Assumes that a `CustomService` class must be implemented for each hosting model, including the platforms of a .NET MAUI Blazor Hybrid app, because the code for the service differs for each platform (Android, macOS, Windows, iOS) and a Blazor Server/Blazor WebAssembly app.
* Places an interface for the service in the Razor class library (RCL). The RCL is named `SharedLibrary`. The interface defines a method that returns a message.

`Interfaces/ICustomService.cs` in the RCL:

```csharp
namespace SharedLibrary.Interfaces;

public interface ICustomService
{
    string GetMessage();
}
```

In the following examples, the RCL implements the `ICustomService` interface for each platform in a `Platforms` folder at the root of the RCL.

`Platforms/Android/CustomService.cs`:

```csharp
using SharedLibrary.Interfaces;

namespace SharedLibrary.Platforms.Android;

public class CustomService : ICustomService
{
    public string GetMessage()
    {
        return "Android implementation of ICustomService.";
    }
}
```

`Platforms/MacCatalyst/CustomService.cs`:

```csharp
using SharedLibrary.Interfaces;

namespace SharedLibrary.Platforms.MacCatalyst;

public class CustomService : ICustomService
{
    public string GetMessage()
    {
        return "Mac Catalyst implementation of ICustomService.";
    }
}
```

`Platforms/Windows/CustomService.cs`:

```csharp
using SharedLibrary.Interfaces;

namespace SharedLibrary.Platforms.Windows;

public class CustomService : ICustomService
{
    public string GetMessage()
    {
        return "Windows implementation of ICustomService.";
    }
}
```

`Platforms/iOS/CustomService.cs`:

```csharp
using SharedLibrary.Interfaces;

namespace SharedLibrary.Platforms.iOS;

public class CustomService : ICustomService
{
    public string GetMessage()
    {
        return "iOS implementation of ICustomService.";
    }
}
```

In the following example, the RCL implements the `ICustomService` interface for the web (Blazor Server or Blazor WebAssembly) in a `Web` folder at the root of the RCL:

`Web/CustomService.cs`:

```csharp
using SharedLibrary.Interfaces;

namespace SharedLibrary.Web;

public class CustomService : ICustomService
{
    public string GetMessage()
    {
        return "Web implementation of ICustomService.";
    }
}
```

The following example is for a .NET MAUI app in the solution that:

* Has a project reference for the `SharedLibrary` project.
* Registers the appropriate `CustomService` implementation for each platform.

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
> Windows Forms Blazor projects register services in `Form1`'s constructor (`Form1.cs`). WPF Blazor projects register services in `MainWindow`'s constructor (`MainWindow.xaml`).

The following example for a Blazor Server or Blazor WebAssembly project:

* Has a project reference for the `SharedLibrary` project.
* Registers the appropriate `CustomService` implementation for web-based clients.

In `Program.cs`:

```csharp
builder.Services.AddSingleton<SharedLibrary.Interfaces.ICustomService, 
    SharedLibrary.Web.CustomService>();
```

A component can inject the `CustomService` and call the `GetMessage` method. Add the following `TestCustomService` component to the RCL.

`Pages/TestCustomService.razor`:

```razor
@page "/test-custom-service"
@using SharedLibrary.Interfaces;
@inject ICustomService CustomService

<PageTitle>Test Service</PageTitle>

<h1>Test Service</h1>

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

-->

## Additional resources

* <xref:blazor/components/class-libraries>
* <xref:razor-pages/ui-class>
* [CSS isolation support with Razor class libraries](xref:blazor/components/css-isolation#razor-class-library-rcl-support)
