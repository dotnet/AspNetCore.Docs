---
title: Combine Blazor Hybrid with .NET MAUI and Razor class libraries (RCLs)
author: guardrex
description: This guide demonstrates the recommended pattern for creating Razor class libraries (RCLs) that combine .NET MAUI and Razor functionality.
monikerRange: '>= aspnetcore-6.0'
ms.author: wpickett
ms.custom: mvc
ms.date: 01/05/2026
uid: blazor/hybrid/class-libraries-best-practices
---
# Combine Blazor Hybrid with .NET MAUI and Razor class libraries (RCLs)

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains the recommended pattern for creating [Razor class libraries (RCLs)](xref:blazor/components/class-libraries) that combine .NET MAUI and Razor functionality. The architecture explained in this article is adopted by the [.NET MAUI Blazor Hybrid and Web solution template](xref:blazor/hybrid/tutorials/maui-blazor-web-app).

RCLs should adopt *host-agnostic design*, where libraries are reusable UI component packages that work across different platforms, app types, Blazor hosting models (Blazor Server, Blazor WebAssembly, Blazor Hybrid/MAUI), and static server-side rendering. To maintain this flexibility, RCLs shouldn't depend on specific hosting infrastructure or platform APIs:

* **Universal component reuse**: Component work in web apps, desktop apps, and mobile apps.
* **Clean architecture**: UI concerns are separated from platform-specific implementation details.
* **Testability**: Components are tested without platform dependencies.
* **Future-proof**: Components adapt to new hosting models without modification.

These goals are accomplished by:

* Keeping Razor components platform-agnostic in the RCL.
* Providing platform-specific implementations through dependency injection (DI).

## Key advantages

*Host-agnostic design* has the following advantages:

* Host independence

  * The RCL works across Blazor Server, Blazor WebAssembly, .NET MAUI, and other hosting models.
  * The components are the same but have different platform implementations.
  * There's no coupling to specific hosting infrastructure.

* Clean dependency flow

  * The RCL defines abstractions (interfaces).
  * The MAUI library implements abstractions using MAUI APIs.
  * The app activates implementations via DI.
  * There are no circular dependencies.

* Testability

  * The RCL can be tested independently without MAUI dependencies.
  * Implementations of `IDeviceInfoService` are mocked for unit testing.
  * MAUI library tests focus on platform-specific logic.

* Maximum reusability

  * The RCL works seamlessly in:
    * MAUI Blazor apps (`Lib.Maui` provides native device APIs).
    * Blazor Web Apps (web-based `IDeviceInfoService` uses browser APIs).
    * Blazor Server (server-side implementations).
    * Blazor WebAssembly (client-side implementations).
  * A single codebase serves all platforms.

  ## Best practices

* Keep the RCL platform-agnostic.

  * No MAUI dependencies are in the RCL.
  * Define abstractions for all platform-specific functionality.
  * Use dependency injection (DI) to provide implementations.

* The MAUI library references RCL. The RCL doesn't reference the MAUI library:

  * Dependency flow: App → MAUI Library → RCL.
  * Never reference the MAUI library from RCL.

* Use interfaces for abstractions.

  * Prefer interfaces over abstract classes for flexibility.
  * Document expected behavior in XML comments.
  * Consider asynchronous methods for I/O operations.

* Register services appropriately.

  * Use singleton services for stateless services, such as device info and connectivity.
  * Use scoped services for user-specific services.
  * Use transient servies for stateful operations.

* Test independently

  * Unit test RCL components with mocked interfaces.
  * Integration test MAUI implementations on devices/emulators.
  * Use DI to swap implementations for testing.

## Architecture

The following sections demonstrate how to adopt the following example app architecture:

* `Lib` (RCL)
  * Razor components
  * Static web assets
  * Abstractions (interfaces) for platform functionality

* `Lib.Maui` (MAUI Class Library)
  * References `Lib`
  * MAUI-specific implementations
  * Uses MAUI APIs (examples: `DeviceInfo`, `Permissions`)

* `MauiApp` (MAUI Blazor Application)
  * References both `Lib` and `Lib.Maui`
  * Registers MAUI implementations in the DI container

Project structure summary:

```
MauiClassLibrarySample.sln
├── Lib/                          # RCL
│   ├── Lib.csproj                # Microsoft.NET.Sdk.Razor, net10.0
│   ├── IDeviceInfoService.cs       # Platform abstraction
│   ├── Component1.razor            # Razor component using abstraction
│   └── wwwroot/
│       └── lib.js                # JS initializer
│
├── Lib.Maui/                     # MAUI Class Library
│   ├── Lib.Maui.csproj           # Microsoft.NET.Sdk, multi-targeted, UseMaui=true
│   └── MauiDeviceInfoService.cs    # MAUI implementation of IDeviceInfoService
│
└── MauiApp/                      # MAUI Blazor Application
    ├── MauiApp.csproj            # References both Lib and Lib.Maui
    ├── MauiProgram.cs              # Registers services
    └── Components/Pages/
        └── Home.razor              # Uses Component1 from RCL
```

## Step 1: Create the RCL

Create a RCL *without* `<UseMaui>`:

```dotnetcli
dotnet new razorclasslib -o Lib
```

Key characteristics:

* Uses the `Microsoft.NET.Sdk.Razor` SDK.
* Targets `net10.0` (or your target framework).
* No MAUI dependencies.
* Contains only Razor components and web assets.

### Define platform abstractions

In `Lib/IDeviceInfoService.cs`:

```csharp
namespace Lib;

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

In `Lib/Component1.razor`:

```razor
@inject IDeviceInfoService DeviceInfo

<div class="component">
    <h3>Device Information</h3>
    <p><strong>Platform:</strong> @DeviceInfo.Platform</p>
    <p><strong>Device Model:</strong> @DeviceInfo.DeviceModel</p>
    <p><strong>OS Version:</strong> @DeviceInfo.OSVersion</p>
</div>
```

## Step 2: Create the MAUI class library

Create a MAUI class library with `<UseMaui>true</UseMaui>`:

```dotnetcli
dotnet new classlib -o Lib.Maui
```

### Configure as a MAUI class library

Edit `Lib.Maui/Lib.Maui.csproj`:

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
    <ProjectReference Include="..\Lib\Lib.csproj" />
  </ItemGroup>

</Project>
```

Key properties:

* `<UseMaui>true</UseMaui>` enables MAUI functionality.
* `<SingleProject>true</SingleProject>` uses single-project MAUI structure.
* Multi-targets MAUI platforms (Android, iOS, macOS, Windows).
* References the `Lib` RCL.

### Implement platform-specific functionality

In `Lib.Maui/MauiDeviceInfoService.cs`:

```csharp
using Lib;

namespace Lib.Maui;

/// <summary>
/// MAUI-specific implementation of IDeviceInfoService.
/// Uses Microsoft.Maui.Devices.DeviceInfo to retrieve platform information.
/// </summary>
public class MauiDeviceInfoService : IDeviceInfoService
{
    public string Platform => Microsoft.Maui.Devices.DeviceInfo.Platform.ToString();

    public string DeviceModel => Microsoft.Maui.Devices.DeviceInfo.Model;

    public string OSVersion => Microsoft.Maui.Devices.DeviceInfo.VersionString;
}
```

## Step 3: Create the MAUI Blazor app

Create a MAUI Blazor app to consume both libraries:

```dotnetcli
dotnet new maui-blazor -o MauiApp
```

### Add library references

Add `Lib` and `Lib.Maui` project references to the `MauiApp` project:

```xml
<ItemGroup>
  <ProjectReference Include="..\Lib\Lib.csproj" />
  <ProjectReference Include="..\Lib.Maui\Lib.Maui.csproj" />
</ItemGroup>
```

### Register services

In `MauiApp/MauiProgram.cs`, register the MAUI implementation:

```csharp
using Microsoft.Extensions.Logging;
using Lib;
using Lib.Maui;

namespace MauiApp;

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

In `MauiApp/Components/Pages/Home.razor`:

```razor
@page "/"
@using Lib

<h1>Hello, world!</h1>

<p>Welcome to your new app demonstrating the RCL + MAUI library pattern.</p>

<h2>Device Information Component</h2>

<p>
    This component is defined in the Lib RCL and uses the IDeviceInfoService 
    abstraction, which is implemented by Lib.Maui.
</p>

<Component1 />
```

## Step 4: Build and run

Create a solution file and build:

```dotnetcli
dotnet new sln -n MauiClassLibrarySample
dotnet sln add Lib\Lib.csproj Lib.Maui\Lib.Maui.csproj MauiApp\MauiApp.csproj
dotnet build
```

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

In the RCL (`Lib`):

```csharp
public interface IPermissionsService
{
    Task<bool> CheckCameraPermissionAsync();
    Task<bool> RequestCameraPermissionAsync();
}
```

In the MAUI Library (`Lib.Maui`):

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

In the app (`MauiApp`):

```csharp
builder.Services.AddSingleton<IPermissionsService, MauiPermissionsService>();
```

## Troubleshoot

### MA002 warnings about implicit package references

**Symptom:** Build warnings suggesting to add explicit `<PackageReference>` for MAUI packages.

**Solution:** These warnings are informational. The packages are added implicitly when `<UseMaui>true</UseMaui>` is set.

### Dependency injection fails

**Symptom:** `InvalidOperationException: Unable to resolve service for type 'Lib.IDeviceInfoService'`

**Solution:** Register the service in `MauiProgram.cs`:

```csharp
builder.Services.AddSingleton<IDeviceInfoService, MauiDeviceInfoService>();
```

## Additional Resources

* <xref:blazor/components/class-libraries>
* [.NET MAUI Class Libraries](/dotnet/maui/platform-integration/)
* [.NET MAUI Dependency Injection](/dotnet/maui/fundamentals/dependency-injection)
* <xref:blazor/hybrid/reuse-razor-components>
