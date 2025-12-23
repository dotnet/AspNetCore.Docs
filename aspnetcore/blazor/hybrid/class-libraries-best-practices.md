---
title: Combine Blazor Hybrid with .NET MAUI and Razor class libraries (RCLs)
author: guardrex
description: This guide demonstrates the recommended pattern for creating Razpr class libraries (RCLs) that combine .NET MAUI and Razor functionality.
monikerRange: '>= aspnetcore-6.0'
ms.author: wpickett
ms.custom: mvc
ms.date: 12/23/2025
uid: blazor/hybrid/class-libraries-best-practices
---
# Combine Blazor Hybrid with .NET MAUI and Razor class libraries (RCLs)

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains the recommended pattern for creating [Razor class libraries (RCLs)](xref:blazor/components/class-libraries) that combine .NET MAUI and Razor functionality. The architecture explained in this article is adopted by the [.NET MAUI Blazor Hybrid and Web solution template](xref:blazor/hybrid/tutorials/maui-blazor-web-app).

The key principle is **host-agnostic design**: RCLs should remain independent of the hosting environment, allowing them to run seamlessly across different platforms and app types.

RCLs are designed to be reusable UI component packages that work across different Blazor hosting models&mdash;Blazor Server, Blazor WebAssembly, Blazor Hybrid (MAUI)&mdash;and even static server-side rendering. To maintain this flexibility, RCLs shouldn't depend on specific hosting infrastructure or platform APIs:

* **Universal component reuse**: Each component works in web apps, desktop apps, and mobile apps.
* **Clean architecture**: UI concerns are separated from platform-specific implementation details.
* **Testability**: Components can be tested without platform dependencies.
* **Future-proof**: Components adapt to new hosting models without modification.

Keep Razor components platform-agnostic in the RCL, and provide platform-specific implementations through dependency injection (DI).

## Architecture

The following sections demonstrate how to adopt the following example app architecture:

* `MyLib` (RCL)
  * Razor components
  * Static web assets
  * Abstractions (interfaces) for platform functionality

* `MyLib.Maui` (MAUI Class Library)
  * References `MyLib`
  * MAUI-specific implementations
  * Uses MAUI APIs (examples: `DeviceInfo`, `Permissions`)

* `MyMauiApp` (MAUI Blazor Application)
  * References both `MyLib` and `MyLib.Maui`
  * Registers MAUI implementations in the DI container

## Step 1: Create the RCL

Create a RCL **without** `<UseMaui>`:

```dotnetcli
dotnet new razorclasslib -o MyLib
```

Key characteristics:

* Uses the `Microsoft.NET.Sdk.Razor` SDK.
* Targets `net10.0` (or your target framework).
* No MAUI dependencies.
* Contains only Razor components and web assets.

### Define platform abstractions

In `MyLib/IDeviceInfoService.cs`:

```csharp
namespace MyLib;

/// <summary>
/// Abstraction for retrieving device-specific information.
/// This interface should be implemented by platform-specific libraries (e.g., MAUI).
/// </summary>
public interface IDeviceInfoService
{
    /// <summary>
    /// Gets the name of the platform (e.g., "Android", "iOS", "Windows").
    /// </summary>
    string Platform { get; }

    /// <summary>
    /// Gets the device model (e.g., "iPhone 14 Pro", "Samsung Galaxy S23").
    /// </summary>
    string DeviceModel { get; }

    /// <summary>
    /// Gets the operating system version.
    /// </summary>
    string OSVersion { get; }
}
```

### Create components using abstractions

In `MyLib/Component1.razor`:

```razor
@inject IDeviceInfoService DeviceInfo

<div class="my-component">
    <h3>Device Information</h3>
    <p><strong>Platform:</strong> @DeviceInfo.Platform</p>
    <p><strong>Device Model:</strong> @DeviceInfo.DeviceModel</p>
    <p><strong>OS Version:</strong> @DeviceInfo.OSVersion</p>
</div>
```

## Step 2: Create the MAUI class library

Create a MAUI class library with `<UseMaui>true</UseMaui>`:

```dotnetcli
dotnet new classlib -o MyLib.Maui
```

### Configure as MAUI class library

Edit `MyLib.Maui/MyLib.Maui.csproj`:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFrameworks>net10.0-android;net10.0-ios;net10.0-maccatalyst</TargetFrameworks>
    <TargetFrameworks Condition="$([MSBuild]::IsOSPlatform('windows'))">$(TargetFrameworks);net10.0-windows10.0.19041.0</TargetFrameworks>
    <UseMaui>true</UseMaui>
    <SingleProject>true</SingleProject>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>

    <SupportedOSPlatformVersion Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'ios'">15.0</SupportedOSPlatformVersion>
    <SupportedOSPlatformVersion Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'maccatalyst'">15.0</SupportedOSPlatformVersion>
    <SupportedOSPlatformVersion Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'android'">21.0</SupportedOSPlatformVersion>
    <SupportedOSPlatformVersion Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'windows'">10.0.17763.0</SupportedOSPlatformVersion>
    <TargetPlatformMinVersion Condition="$([MSBuild]::GetTargetPlatformIdentifier('$(TargetFramework)')) == 'windows'">10.0.17763.0</TargetPlatformMinVersion>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.Maui.Controls" Version="$(MauiVersion)" />
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\MyLib\MyLib.csproj" />
  </ItemGroup>

</Project>
```

Key properties:

* `<UseMaui>true</UseMaui>` enables MAUI functionality.
* `<SingleProject>true</SingleProject>` uses single-project MAUI structure.
* Multi-targets MAUI platforms (Android, iOS, macOS, Windows).
* References the `MyLib` RCL.

### Implement platform-specific functionality

In `MyLib.Maui/MauiDeviceInfoService.cs`:

```csharp
using MyLib;

namespace MyLib.Maui;

/// <summary>
/// MAUI-specific implementation of IDeviceInfoService.
/// Uses Microsoft.Maui.Devices.DeviceInfo to retrieve platform information.
/// </summary>
public class MauiDeviceInfoService : IDeviceInfoService
{
    public string Platform => Microsoft.Maui.Devices.DeviceInfo.Platform.ToString();

    public string DeviceModel => Microsoft.Maui.Devices.DeviceInfo.Model;

    public string OSVersion => $"{Microsoft.Maui.Devices.DeviceInfo.VersionString}";
}
```

## Step 3: Create the MAUI Blazor app

Create a MAUI Blazor app that consumes both libraries:

```dotnetcli
dotnet new maui-blazor -o MyMauiApp
```

### Add library references

Edit `MyMauiApp/MyMauiApp.csproj` to add project references:

```xml
<ItemGroup>
    <ProjectReference Include="..\MyLib\MyLib.csproj" />
    <ProjectReference Include="..\MyLib.Maui\MyLib.Maui.csproj" />
</ItemGroup>
```

### Register services

In `MyMauiApp/MauiProgram.cs`, register the MAUI implementation:

```csharp
using Microsoft.Extensions.Logging;
using MyLib;
using MyLib.Maui;

namespace MyMauiApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

        // Register the MAUI-specific implementation of IDeviceInfoService
        builder.Services.AddSingleton<IDeviceInfoService, MauiDeviceInfoService>();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
```

### Use RCL components

In `MyMauiApp/Components/Pages/Home.razor`:

```razor
@page "/"
@using MyLib

<h1>Hello, world!</h1>

<p>Welcome to your new app demonstrating the RCL + MAUI library pattern.</p>

<h2>Device Information Component</h2>

<p>
    This component is defined in the MyLib RCL and uses the IDeviceInfoService 
    abstraction, which is implemented by MyLib.Maui.
</p>

<Component1 />
```

## Step 4: Build and run

Create a solution file and build:

```dotnetcli
dotnet new sln -n MauiClassLibrarySample
dotnet sln add MyLib\MyLib.csproj MyLib.Maui\MyLib.Maui.csproj MyMauiApp\MyMauiApp.csproj
dotnet build
```

## Key advantages

This pattern has the following advantages:

* Host independence

  * The RCL works across Blazor Server, Blazor WebAssembly, .NET MAUI, and other hosting models.
  * Same components, different platform implementations.
  * No coupling to specific hosting infrastructure.

* Clean dependency flow

  * The RCL defines abstractions (interfaces).
  * MAUI library implements abstractions using MAUI APIs.
  * The app activates implementations via DI.
  * There are no circular dependencies.

* Testability

  * The RCL can be tested independently without MAUI dependencies.
  * Mock implementations of `IDeviceInfoService` for unit testing.
  * MAUI library tests can focus on platform-specific logic.

* Maximum reusability

  * The RCL works seamlessly in:
    * MAUI Blazor apps (`MyLib.Maui` provides native device APIs).
    * Blazor Web Apps (web-based `IDeviceInfoService` uses browser APIs).
    * Blazor Server (server-side implementations).
    * Blazor WebAssembly (client-side implementations).
  * A single codebase serves all platforms.

## When to Use MAUI APIs

Use abstractions in the RCL for any functionality that requires MAUI APIs.

### Common Scenarios

Functionality | Pattern
--- | ---
Device information | Define `IDeviceInfoService` in the RCL, implement in MAUI library.
Permissions | Define `IPermissionsService` in the RCL, use `Permissions` API in MAUI library.
File system access | Define `IFileService` in the RCL, use `FileSystem` API in MAUI library.
Connectivity | Define `IConnectivityService` in the RCL, use `Connectivity` API in MAUI library.
Geolocation | Define `ILocationService` in the RCL, use `Geolocation` API in MAUI library.

### Example: Adding permissions service

In the RCL (`MyLib`):

```csharp
public interface IPermissionsService
{
    Task<bool> CheckCameraPermissionAsync();
    Task<bool> RequestCameraPermissionAsync();
}
```

In the MAUI Library (`MyLib.Maui`):

```csharp
public class MauiPermissionsService : IPermissionsService
{
    public async Task<bool> CheckCameraPermissionAsync()
    {
        var status = await Permissions.CheckStatusAsync<Permissions.Camera>();
        return status == PermissionStatus.Granted;
    }

    public async Task<bool> RequestCameraPermissionAsync()
    {
        var status = await Permissions.RequestAsync<Permissions.Camera>();
        return status == PermissionStatus.Granted;
    }
}
```

In the app (`MyMauiApp`):

```csharp
builder.Services.AddSingleton<IPermissionsService, MauiPermissionsService>();
```

## Project Structure Summary

```
MauiClassLibrarySample.sln
├── MyLib/                          # RCL
│   ├── MyLib.csproj                # Microsoft.NET.Sdk.Razor, net10.0
│   ├── IDeviceInfoService.cs       # Platform abstraction
│   ├── Component1.razor            # Razor component using abstraction
│   └── wwwroot/
│       └── mylib.js                # JS initializer
│
├── MyLib.Maui/                     # MAUI Class Library
│   ├── MyLib.Maui.csproj           # Microsoft.NET.Sdk, multi-targeted, UseMaui=true
│   └── MauiDeviceInfoService.cs    # MAUI implementation of IDeviceInfoService
│
└── MyMauiApp/                      # MAUI Blazor Application
    ├── MyMauiApp.csproj            # References both MyLib and MyLib.Maui
    ├── MauiProgram.cs              # Registers services
    └── Components/Pages/
        └── Home.razor              # Uses Component1 from RCL
```

## Troubleshoot

### MA002 warnings about implicit package references

**Symptom:** Build warnings suggesting to add explicit `<PackageReference>` for MAUI packages.

**Solution:** These warnings are informational. The packages are added implicitly when `<UseMaui>true</UseMaui>` is set.

### Dependency injection fails

**Symptom:** `InvalidOperationException: Unable to resolve service for type 'MyLib.IDeviceInfoService'`

**Solution:** Register the service in `MauiProgram.cs`:

```csharp
builder.Services.AddSingleton<IDeviceInfoService, MauiDeviceInfoService>();
```

## Best practices

* Keep RCL platform-agnostic

   * No MAUI dependencies are in the RCL.
   * Define abstractions for all platform-specific functionality.
   * Use dependency injection to provide implementations.

* The MAUI library references RCL. The RCL doesn't reference the MAUI library:

   * Dependency flow: App → MAUI Library → RCL.
   * Never reference the MAUI library from RCL.

* Use interfaces for abstractions

   * Prefer interfaces over abstract classes for flexibility.
   * Document expected behavior in XML comments.
   * Consider async methods for I/O operations.

* Register services appropriately

   * Singleton: Device info, connectivity (stateless services)
   * Scoped: User-specific services
   * Transient: Stateful operations

* Test independently

   * Unit test RCL components with mocked interfaces.
   * Integration test MAUI implementations on devices/emulators.
   * Use DI to swap implementations for testing.

## Conclusion

The pattern descreibed by this article and demonstrated by the [.NET MAUI Blazor Hybrid and Web solution template](xref:blazor/hybrid/tutorials/maui-blazor-web-app) embodies the principle of host-agnostic design for RCLs. By keeping RCLs independent of platform-specific concerns and using dependency injection to provide implementations, you create truly reusable component libraries that adapt to any hosting environment&mdash;whether web, desktop, or mobile. This architectural approach ensures that Razor components remain flexible, testable, and future-proof across the evolving Blazor ecosystem.

## Additional Resources

* <xref:blazor/components/class-libraries>
* [.NET MAUI Class Libraries](/dotnet/maui/platform-integration/)
* [.NET MAUI Dependency Injection](/dotnet/maui/fundamentals/dependency-injection)
* <xref:blazor/hybrid/reuse-razor-components>
