---
title: Enhance an app from an external assembly in ASP.NET Core with IHostingStartup
author: guardrex
description: Discover how to enhance an ASP.NET Core app from a class library or external assembly using an IHostingStartup implementation.
monikerRange: '>= aspnetcore-2.0'
ms.author: riande
ms.custom: mvc
ms.date: 07/18/2018
uid: fundamentals/configuration/platform-specific-configuration
---
# Enhance an app from an external assembly in ASP.NET Core with IHostingStartup

By [Luke Latham](https://github.com/guardrex)

An [IHostingStartup](/dotnet/api/microsoft.aspnetcore.hosting.ihostingstartup) implementation allows adding enhancements to an app at startup from an external assembly outside of the app's `Startup` class. For example, an external tooling library can use an `IHostingStartup` implementation to provide additional configuration providers or services to an app. `IHostingStartup` *is available in ASP.NET Core 2.0 or later.*

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/host/platform-specific-configuration/samples/) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Hosting startup activated from an existing class library

When an `IHostingStartup` enhancement is available in an existing library, the hosting startup types provided by the library can be made available to the app with a [HostingStartup](/dotnet/api/microsoft.aspnetcore.hosting.hostingstartupattribute) attribute. The entry assembly or the assembly containing the `Startup` class is automatically scanned for the `HostingStartup` attribute.

The [sample app](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/host/platform-specific-configuration/samples/2.x/HostingStartupSample) includes a Razor Pages app, *HostingStartupApp*, and a class library, *HostingStartupLib*. The class library contains a hosting startup class, `ServiceKeyInjection`, which implements `IHostingStartup`.

`ServiceKeyInjection` adds a pair of service strings to the app's configuration using the in-memory configuration provider ([AddInMemoryCollection](/dotnet/api/microsoft.extensions.configuration.memoryconfigurationbuilderextensions.addinmemorycollection)).

*HostingStartupSample/HostingStartupLib/ServiceKeyInjection.cs*:

[!code-csharp[](platform-specific-configuration/samples/2.x/HostingStartupSample/HostingStartupLib/ServiceKeyInjection.cs?name=snippet1)]

The app's `Startup` class file specifies a [HostingStartup](/dotnet/api/microsoft.aspnetcore.hosting.hostingstartupattribute) attribute for the class library's `ServiceKeyInjection` class.

*HostingStartupSample/HostingStartupApp/Startup.cs*:

[!code-csharp[](platform-specific-configuration/samples/2.x/HostingStartupSample/HostingStartupApp/Startup.cs?name=snippet1&highlight=1)]

The app's Index page reads the configuration values for the two keys set by the class library's hosting startup assembly. The configuration values for these keys are displayed when the page is rendered.

*HostingStartupApp/Pages/Index.cshtml.cs*:

[!code-csharp[](platform-specific-configuration/samples/2.x/HostingStartupSample/HostingStartupApp/Pages/Index.cshtml.cs?name=snippet1&highlight=5-6,9-10)]

## Discover loaded hosting startup assemblies

To discover hosting startup assemblies loaded by the app or by libraries, enable logging and check the application logs. Errors that occur when loading assemblies are logged. Loaded hosting startup assemblies are logged at the Debug level, and all errors are logged.

Hosting startup assemblies are listed in the [WebHostDefaults.HostingStartupAssembliesKey](/dotnet/api/microsoft.aspnetcore.hosting.webhostdefaults.hostingstartupassemblieskey). Excluded assemblies are listed in the [WebHostDefaults.HostingStartupExcludeAssembliesKey](/dotnet/api/microsoft.aspnetcore.hosting.webhostdefaults.hostingstartupexcludeassemblieskey). For more information, see [Web Host: Hosting Startup Assemblies](xref:fundamentals/host/web-host#hosting-startup-assemblies) and [Web Host: Hosting Startup Exclude Assemblies](xref:fundamentals/host/web-host#hosting-startup-exclude-assemblies).

## Disable automatic loading of hosting startup assemblies

::: moniker range=">= aspnetcore-2.1"

To disable automatic loading of hosting startup assemblies, use one of the following approaches:

* To prevent all hosting startup assemblies from loading, set one of the following to `true` or `1`:
  - [Prevent Hosting Startup](xref:fundamentals/host/web-host#prevent-hosting-startup) host configuration setting.
  - `ASPNETCORE_PREVENTHOSTINGSTARTUP` environment variable.
* To prevent specific hosting startup assemblies from loading, set one of the following to a semicolon-delimited string of hosting startup assemblies to exclude from startup:
  - [Hosting Startup Exclude Assemblies](xref:fundamentals/host/web-host#hosting-startup-exclude-assemblies) host configuration setting.
  - `ASPNETCORE_HOSTINGSTARTUPEXCLUDEASSEMBLIES` environment variable.

::: moniker-end

::: moniker range="= aspnetcore-2.0"

To disable automatic loading of hosting startup assemblies, set one of the following to `true` or `1`:

* [Prevent Hosting Startup](xref:fundamentals/host/web-host#prevent-hosting-startup) host configuration setting.
* `ASPNETCORE_PREVENTHOSTINGSTARTUP` environment variable.

::: moniker-end

If both the host configuration setting and the environment variable are set, the host setting controls the behavior.

Disabling hosting startup assemblies using the host setting or environment variable disables the assembly globally and may disable several characteristics of an app.

## Hosting startup activated dynamically from a bin-deployed or runtime store-deployed assembly

### Create the assembly

An `IHostingStartup` enhancement is deployed as an assembly based on a console app without an entry point. The assembly references the [Microsoft.AspNetCore.Hosting.Abstractions](https://www.nuget.org/packages/Microsoft.AspNetCore.Hosting.Abstractions/) package:

[!code-xml[](platform-specific-configuration/samples-snapshot/2.x/StartupEnhancement.csproj)]

A [HostingStartup](/dotnet/api/microsoft.aspnetcore.hosting.hostingstartupattribute) attribute identifies a class as an implementation of `IHostingStartup` for loading and execution when building the [IWebHost](/dotnet/api/microsoft.aspnetcore.hosting.iwebhost). The entry assembly or the assembly containing the `Startup` class is automatically scanned for the `HostingStartup` attribute. In the following example, the namespace is `StartupEnhancement`, and the class is `StartupEnhancementHostingStartup`:

[!code-csharp[](platform-specific-configuration/samples-snapshot/2.x/StartupEnhancement.cs?name=snippet1)]

A class implements `IHostingStartup`. The class's [Configure](/dotnet/api/microsoft.aspnetcore.hosting.ihostingstartup.configure) method uses an [IWebHostBuilder](/dotnet/api/microsoft.aspnetcore.hosting.iwebhostbuilder) to add enhancements to an app. `IHostingStartup.Configure` in the hosting startup assembly is called by the runtime before `Startup.Configure` in user code, which allows user code to overwrite any configuration provided by the hosting startup assembly.

[!code-csharp[](platform-specific-configuration/samples-snapshot/2.x/StartupEnhancement.cs?name=snippet2&highlight=3,5)]

When building an `IHostingStartup` project, the dependencies file (*\*.deps.json*) sets the `runtime` location of the assembly to the *bin* folder:

[!code-json[](platform-specific-configuration/samples-snapshot/2.x/StartupEnhancement1.deps.json?range=2-13&highlight=8)]

Only part of the file is shown. The assembly name in the example is `StartupEnhancement`.

### Update the dependencies file

The runtime location is specified in the *\*.deps.json* file. To active the enhancement, the `runtime` element must specify the location of the enhancement's runtime assembly. Prefix the `runtime` location with `lib/<TARGET_FRAMEWORK_MONIKER>/`:

[!code-json[](platform-specific-configuration/samples-snapshot/2.x/StartupEnhancement2.deps.json?range=2-13&highlight=8)]

In the sample app, modification of the *\*.deps.json* file is performed by a [PowerShell](/powershell/scripting/powershell-scripting) script. The PowerShell script is automatically triggered by a build target in the project file.

### Enhancement activation

**Place the assembly file**

The `IHostingStartup` implementation's assembly file must be *bin*-deployed in the app or placed in the [runtime store](/dotnet/core/deploying/runtime-store):

For per-user use, place the assembly in the user profile's runtime store at:

```
<DRIVE>\Users\<USER>\.dotnet\store\x64\<TARGET_FRAMEWORK_MONIKER>\<ENHANCEMENT_ASSEMBLY_NAME>\<ENHANCEMENT_VERSION>\lib\<TARGET_FRAMEWORK_MONIKER>\
```

For global use, place the assembly in the .NET Core installation's runtime store:

```
<DRIVE>\Program Files\dotnet\store\x64\<TARGET_FRAMEWORK_MONIKER>\<ENHANCEMENT_ASSEMBLY_NAME>\<ENHANCEMENT_VERSION>\lib\<TARGET_FRAMEWORK_MONIKER>\
```

When deploying the assembly to the runtime store, the symbols file may be deployed as well but isn't required for the enhancement to work.

**Place the dependencies file**

The implementation's *\*.deps.json* file must be in an accessible location.

For per-user use, place the file in the `additonalDeps` folder of the user profile's `.dotnet` settings:

```
<DRIVE>\Users\<USER>\.dotnet\x64\additionalDeps\<ENHANCEMENT_ASSEMBLY_NAME>\shared\Microsoft.NETCore.App\<SHARED_FRAMEWORK_VERSION>\
```

For global use, place the file in the `additonalDeps` folder of the .NET Core installation:

```
<DRIVE>\Program Files\dotnet\additionalDeps\<ENHANCEMENT_ASSEMBLY_NAME>\shared\Microsoft.NETCore.App\<SHARED_FRAMEWORK_VERSION>\
```

The shared framework version reflects the version of the shared runtime that the target app uses. The shared runtime is shown in the *\*.runtimeconfig.json* file. In the sample app, the shared runtime is specified in the *HostingStartupSample.runtimeconfig.json* file.

**Set environment variables**

Set the following environment variables in the context of the app that uses the enhancement.

ASPNETCORE_HOSTINGSTARTUPASSEMBLIES

Only hosting startup assemblies are scanned for the `HostingStartupAttribute`. The assembly name of the implementation is provided in this environment variable. The sample app sets this value to `StartupDiagnostics`.

The value can also be set using the [Hosting Startup Assemblies](xref:fundamentals/host/web-host#hosting-startup-assemblies) host configuration setting.

When multiple hosting startup assembles are present, their [Configure](/dotnet/api/microsoft.aspnetcore.hosting.ihostingstartup.configure) methods are executed in the order that the assemblies are listed.

DOTNET_ADDITIONAL_DEPS

The location of the implementation's *\*.deps.json* file.

If the file is placed in the user profile's *.dotnet* folder for per-user use:

```
<DRIVE>\Users\<USER>\.dotnet\x64\additionalDeps\
```

If the file is placed in the .NET Core installation for global use, provide the full path to the file:

```
<DRIVE>\Program Files\dotnet\additionalDeps\<ENHANCEMENT_ASSEMBLY_NAME>\shared\Microsoft.NETCore.App\<SHARED_FRAMEWORK_VERSION>\<ENHANCEMENT_ASSEMBLY_NAME>.deps.json
```

The sample app sets this value to:

```
%UserProfile%\.dotnet\x64\additionalDeps\StartupDiagnostics\
```

For examples of how to set environment variables for various operating systems, see [Use multiple environments](xref:fundamentals/environments).

## Sample app

The [sample app](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/host/platform-specific-configuration/samples/) ([how to download](xref:tutorials/index#how-to-download-a-sample)) demonstrates two hosting startup scenarios:

* A hosting startup assembly provided by a class library that sets a pair of in-memory configuration key-value pairs.
* Hosting startup activated dynamically from a runtime store-deployed assembly. The assembly adds two middlewares to the app at startup that provide diagnostic information on:
  - Registered services
  - Address (scheme, host, path base, path, query string)
  - Connection (remote IP, remote port, local IP, local port, client certificate)
  - Request headers
  - Environment variables

To run the sample:

**Hosting startup activated from an existing class library**

1. Run the sample app.
1. Observe that the service configuration key values rendered by the Index page match the values set by the class library's `ServiceKeyInjection.Configure` method.

**Hosting startup activated dynamically from a runtime store-deployed assembly**

1. The Startup Diagnostic project uses [PowerShell](/powershell/scripting/powershell-scripting) to modify its *StartupDiagnostics.deps.json* file. PowerShell is installed by default on Windows OS starting with Windows 7 SP1 and Windows Server 2008 R2 SP1. To obtain PowerShell on other platforms, see [Installing Windows PowerShell](/powershell/scripting/setup/installing-windows-powershell).
1. Build the Startup Diagnostic project. A build target in the project file:
   * Moves the assembly and symbols files to the user profile's runtime store.
   * Triggers the PowerShell script to modify the *StartupDiagnostics.deps.json* file.
   * Moves the *StartupDiagnostics.deps.json* file to the user profile's `additionalDeps` folder.
1. Set the environment variables:
    * `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES`: `StartupDiagnostics`
    * `DOTNET_ADDITIONAL_DEPS`: `%UserProfile%\.dotnet\x64\additionalDeps\StartupDiagnostics\`
1. Run the sample app.
1. Request the `/services` endpoint to see the app's registered services. Request the `/diag` endpoint to see the diagnostic information.
