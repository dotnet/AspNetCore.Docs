---
title: Enhance an app from an external assembly in ASP.NET Core with IHostingStartup
author: guardrex
description: Discover how to enhance an ASP.NET Core app from an external assembly using an IHostingStartup implementation.
monikerRange: '>= aspnetcore-2.0'
ms.author: riande
ms.custom: mvc
ms.date: 08/13/2018
uid: fundamentals/configuration/platform-specific-configuration
---
# Enhance an app from an external assembly in ASP.NET Core with IHostingStartup

By [Luke Latham](https://github.com/guardrex)

An [IHostingStartup](/dotnet/api/microsoft.aspnetcore.hosting.ihostingstartup) (hosting startup) implementation adds enhancements to an app at startup from an external assembly. For example, an external library can use a hosting startup implementation to provide additional configuration providers or services to an app. `IHostingStartup` *is available in ASP.NET Core 2.0 or later.*

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/host/platform-specific-configuration/samples/) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## HostingStartup attribute

A [HostingStartup](/dotnet/api/microsoft.aspnetcore.hosting.hostingstartupattribute) attribute indicates the presence of a hosting startup assembly to activate at runtime.

The entry assembly or the assembly containing the `Startup` class is automatically scanned for the `HostingStartup` attribute. The list of assemblies to search for `HostingStartup` attributes is loaded at runtime from configuration in the [WebHostDefaults.HostingStartupAssembliesKey](/dotnet/api/microsoft.aspnetcore.hosting.webhostdefaults.hostingstartupassemblieskey). The list of assemblies to exclude from discovery is loaded from the [WebHostDefaults.HostingStartupExcludeAssembliesKey](/dotnet/api/microsoft.aspnetcore.hosting.webhostdefaults.hostingstartupexcludeassemblieskey). For more information, see [Web Host: Hosting Startup Assemblies](xref:fundamentals/host/web-host#hosting-startup-assemblies) and [Web Host: Hosting Startup Exclude Assemblies](xref:fundamentals/host/web-host#hosting-startup-exclude-assemblies).

In the following example, the namespace of the hosting startup assembly is `StartupEnhancement`. The class containing the hosting startup code is `StartupEnhancementHostingStartup`:

[!code-csharp[](platform-specific-configuration/samples-snapshot/2.x/StartupEnhancement.cs?name=snippet1)]

The `HostingStartup` attribute is typically located in the hosting startup assembly's `IHostingStartup` implementation class file.

## Discover loaded hosting startup assemblies

To discover loaded hosting startup assemblies, enable logging and check the app's logs. Errors that occur when loading assemblies are logged. Loaded hosting startup assemblies are logged at the Debug level, and all errors are logged.

## Disable automatic loading of hosting startup assemblies

::: moniker range=">= aspnetcore-2.1"

To disable automatic loading of hosting startup assemblies, use one of the following approaches:

* To prevent all hosting startup assemblies from loading, set one of the following to `true` or `1`:
  - [Prevent Hosting Startup](xref:fundamentals/host/web-host#prevent-hosting-startup) host configuration setting.
  - `ASPNETCORE_PREVENTHOSTINGSTARTUP` environment variable.
* To prevent specific hosting startup assemblies from loading, set one of the following to a semicolon-delimited string of hosting startup assemblies to exclude at startup:
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

## Project

Create a hosting startup with either of the following project types:

* [Class library](#class-library)
* [Console app without an entry point](#console-app-without-an-entry-point)

### Class library

A hosting startup enhancement can be provided in a class library. The library contains a `HostingStartup` attribute.

The [sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/host/platform-specific-configuration/samples/) includes a Razor Pages app, *HostingStartupApp*, and a class library, *HostingStartupLibrary*. The class library:

* Contains a hosting startup class, `ServiceKeyInjection`, which implements `IHostingStartup`. `ServiceKeyInjection` adds a pair of service strings to the app's configuration using the in-memory configuration provider ([AddInMemoryCollection](/dotnet/api/microsoft.extensions.configuration.memoryconfigurationbuilderextensions.addinmemorycollection)).
* Includes a `HostingStartup` attribute that identifies the hosting startup's namespace and class.

The `ServiceKeyInjection` class's [Configure](/dotnet/api/microsoft.aspnetcore.hosting.ihostingstartup.configure) method uses an [IWebHostBuilder](/dotnet/api/microsoft.aspnetcore.hosting.iwebhostbuilder) to add enhancements to an app. `IHostingStartup.Configure` in the hosting startup assembly is called by the runtime before `Startup.Configure` in user code, which allows user code to overwrite any configuration provided by the hosting startup assembly.

*HostingStartupLibrary/ServiceKeyInjection.cs*:

[!code-csharp[](platform-specific-configuration/samples/2.x/HostingStartupLibrary/ServiceKeyInjection.cs?name=snippet1)]

The app's Index page reads and renders the configuration values for the two keys set by the class library's hosting startup assembly:

*HostingStartupApp/Pages/Index.cshtml.cs*:

[!code-csharp[](platform-specific-configuration/samples/2.x/HostingStartupApp/Pages/Index.cshtml.cs?name=snippet1&highlight=5-6,11-12)]

The [sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/host/platform-specific-configuration/samples/) also includes a NuGet package project that provides a separate hosting startup, *HostingStartupPackage*. The package has the same characteristics of the class library described earlier. The package:

* Contains a hosting startup class, `ServiceKeyInjection`, which implements `IHostingStartup`. `ServiceKeyInjection` adds a pair of service strings to the app's configuration.
* Includes a `HostingStartup` attribute.

*HostingStartupPackage/ServiceKeyInjection.cs*:

[!code-csharp[](platform-specific-configuration/samples/2.x/HostingStartupPackage/ServiceKeyInjection.cs?name=snippet1)]

The app's Index page reads and renders the configuration values for the two keys set by the package's hosting startup assembly:

*HostingStartupApp/Pages/Index.cshtml.cs*:

[!code-csharp[](platform-specific-configuration/samples/2.x/HostingStartupApp/Pages/Index.cshtml.cs?name=snippet1&highlight=7-8,13-14)]

### Console app without an entry point

*This approach is only available for .NET Core apps, not .NET 4.x.*

A dynamic hosting startup enhancement that doesn't require a compile-time reference for activation can be provided in a console app without an entry point. The app contains a `HostingStartup` attribute. To create a dynamic hosting startup:

1. An implementation library is created from the class that contains the `IHostingStartup` implementation. The implementation library is treated as a normal package.
1. A console app without an entry point references the implementation library package. A console app is used because:
   - A dependencies file is a runnable app asset, so a library can't furnish a dependencies file.
   - A library can't be added directly to the [runtime package store](/dotnet/core/deploying/runtime-store), which requires a runnable project that targets the shared runtime.
1. The console app is published to obtain the hosting startup's dependencies. A consequence of publishing the console app is that unused dependencies are trimmed from the dependencies file.
1. The app and its dependencies file is placed into the runtime package store. To discover the hosting startup assembly and its dependencies file, they're referenced in a pair of environment variables.

The console app references the [Microsoft.AspNetCore.Hosting.Abstractions](https://www.nuget.org/packages/Microsoft.AspNetCore.Hosting.Abstractions/) package:

[!code-xml[](platform-specific-configuration/samples-snapshot/2.x/StartupEnhancement.csproj)]

A [HostingStartup](/dotnet/api/microsoft.aspnetcore.hosting.hostingstartupattribute) attribute identifies a class as an implementation of `IHostingStartup` for loading and execution when building the [IWebHost](/dotnet/api/microsoft.aspnetcore.hosting.iwebhost). In the following example, the namespace is `StartupEnhancement`, and the class is `StartupEnhancementHostingStartup`:

[!code-csharp[](platform-specific-configuration/samples-snapshot/2.x/StartupEnhancement.cs?name=snippet1)]

A class implements `IHostingStartup`. The class's [Configure](/dotnet/api/microsoft.aspnetcore.hosting.ihostingstartup.configure) method uses an [IWebHostBuilder](/dotnet/api/microsoft.aspnetcore.hosting.iwebhostbuilder) to add enhancements to an app. `IHostingStartup.Configure` in the hosting startup assembly is called by the runtime before `Startup.Configure` in user code, which allows user code to overwrite any configuration provided by the hosting startup assembly.

[!code-csharp[](platform-specific-configuration/samples-snapshot/2.x/StartupEnhancement.cs?name=snippet2&highlight=3,5)]

When building an `IHostingStartup` project, the dependencies file (*\*.deps.json*) sets the `runtime` location of the assembly to the *bin* folder:

[!code-json[](platform-specific-configuration/samples-snapshot/2.x/StartupEnhancement1.deps.json?range=2-13&highlight=8)]

Only part of the file is shown. The assembly name in the example is `StartupEnhancement`.

## Specify the hosting startup assembly

For either a class library- or console app-supplied hosting startup, specify the hosting startup assembly's name in the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` environment variable. The environment variable is a semicolon-delimited list of assemblies.

Only hosting startup assemblies are scanned for the `HostingStartup` attribute. For the sample app, *HostingStartupApp*, to discover the hosting startups described earlier, the environment variable is set to the following value:

```
HostingStartupLibrary;HostingStartupPackage;StartupDiagnostics
```

A hosting startup assembly can also be set using the [Hosting Startup Assemblies](xref:fundamentals/host/web-host#hosting-startup-assemblies) host configuration setting.

When multiple hosting startup assembles are present, their [Configure](/dotnet/api/microsoft.aspnetcore.hosting.ihostingstartup.configure) methods are executed in the order that the assemblies are listed.

## Activation

Three options for hosting startup activation are:

* [Runtime store](#runtime-store) &ndash; Activation doesn't require a compile-time reference for activation. The sample app places the hosting startup assembly and dependencies files into a folder, *deployment*, to facilitate deployment of the hosting startup in a multi-machine environment. The *deployment* folder also includes a PowerShell script that creates or modifies environment variables on the deployment system to enable the hosting startup.
* Compile-time reference required for activation
  - [NuGet package](#nuget-package)
  - [Project bin folder](#project-bin-folder)

### Runtime store

The hosting startup implementation is placed in the [runtime store](/dotnet/core/deploying/runtime-store). A compile-time reference to the assembly isn't required by the enhanced app.

After the hosting startup is built, the hosting startup's project file serves as the manifest file for the [dotnet store](/dotnet/core/tools/dotnet-store) command.

```console
dotnet store --manifest <PROJECT_FILE> --runtime <RUNTIME_IDENTIFIER>
```

This command places the hosting startup assembly and other dependencies that aren't part of the shared framework in the user profile's runtime store at:

```
<DRIVE>\Users\<USER>\.dotnet\store\x64\<TARGET_FRAMEWORK_MONIKER>\<ENHANCEMENT_ASSEMBLY_NAME>\<ENHANCEMENT_VERSION>\lib\<TARGET_FRAMEWORK_MONIKER>\
```

If you desire to place the assembly and dependencies for global use, add the `-o|--output` switch to the `dotnet store` command with the following path:

```
<DRIVE>\Program Files\dotnet\store\x64\<TARGET_FRAMEWORK_MONIKER>\<ENHANCEMENT_ASSEMBLY_NAME>\<ENHANCEMENT_VERSION>\lib\<TARGET_FRAMEWORK_MONIKER>\
```

**Modify and place the hosting startup's dependencies file**

The runtime location is specified in the *\*.deps.json* file. To activate the enhancement, the `runtime` element must specify the location of the enhancement's runtime assembly. Prefix the `runtime` location with `lib/<TARGET_FRAMEWORK_MONIKER>/`:

[!code-json[](platform-specific-configuration/samples-snapshot/2.x/StartupEnhancement2.deps.json?range=2-13&highlight=8)]

In the sample code (*StartupDiagnostics* project), modification of the *\*.deps.json* file is performed by a [PowerShell](/powershell/scripting/powershell-scripting) script. The PowerShell script is automatically triggered by a build target in the project file.

The implementation's *\*.deps.json* file must be in an accessible location.

For per-user use, place the file in the *additonalDeps* folder of the user profile's `.dotnet` settings:

```
<DRIVE>\Users\<USER>\.dotnet\x64\additionalDeps\<ENHANCEMENT_ASSEMBLY_NAME>\shared\Microsoft.NETCore.App\<SHARED_FRAMEWORK_VERSION>\
```

For global use, place the file in the *additonalDeps* folder of the .NET Core installation:

```
<DRIVE>\Program Files\dotnet\additionalDeps\<ENHANCEMENT_ASSEMBLY_NAME>\shared\Microsoft.NETCore.App\<SHARED_FRAMEWORK_VERSION>\
```

The shared framework version reflects the version of the shared runtime that the target app uses. The shared runtime is shown in the *\*.runtimeconfig.json* file. In the sample app (*HostingStartupApp*), the shared runtime is specified in the *HostingStartupApp.runtimeconfig.json* file.

**List the hosting startup's dependencies file**

The location of the implementation's *\*.deps.json* file is listed in the `DOTNET_ADDITIONAL_DEPS` environment variable.

If the file is placed in the user profile's *.dotnet* folder for per-user use, set the environment variable's value to:

```
<DRIVE>\Users\<USER>\.dotnet\x64\additionalDeps\
```

If the file is placed in the .NET Core installation for global use, provide the full path to the file:

```
<DRIVE>\Program Files\dotnet\additionalDeps\<ENHANCEMENT_ASSEMBLY_NAME>\shared\Microsoft.NETCore.App\<SHARED_FRAMEWORK_VERSION>\<ENHANCEMENT_ASSEMBLY_NAME>.deps.json
```

For the sample app (*HostingStartupApp*) to find the dependencies file (*HostingStartupApp.runtimeconfig.json*), the dependencies file is placed in the user's profile and the `DOTNET_ADDITIONAL_DEPS` environment variable is set to the following value:

```
%UserProfile%\.dotnet\x64\additionalDeps\StartupDiagnostics\
```

For examples of how to set environment variables for various operating systems, see [Use multiple environments](xref:fundamentals/environments).

**Deployment**

To facilitate the deployment of a hosting startup in a multi-machine environment, the sample app creates a *deployment* folder in published output that contains:

* The hosting startup assembly.
* The hosting startup dependencies file.
* A PowerShell script that creates or modifies the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` and `DOTNET_ADDITIONAL_DEPS` to support the activation of the hosting startup. Run the script from an administrative PowerShell command prompt on the deployment system.

### NuGet package

A hosting startup enhancement can be provided in a NuGet package. The package has a `HostingStartup` attribute. The hosting startup types provided by the package are made available to the app using either of the following approaches:

* The enhanced app's project file makes a package reference for the hosting startup in the app's project file (a compile-time reference). With the compile-time reference in place, the hosting startup assembly and all of its dependencies are incorporated into the app's dependency file (*\*.deps.json*).
* The hosting startup's dependencies file is made available to the enhanced app as described in the [Runtime store](#runtime-store) section (without a compile-time reference).

For more information on NuGet packages and the runtime store, see the following topics:

* [How to Create a NuGet Package with Cross Platform Tools](https://docs.microsoft.com/dotnet/core/deploying/creating-nuget-packages)
* [Publishing packages](https://docs.microsoft.com/nuget/create-packages/publish-a-package)
* [Runtime package store](https://docs.microsoft.com/dotnet/core/deploying/runtime-store)

### Project bin folder

A hosting startup enhancement can be provided by a *bin*-deployed assembly in the enhanced app. The hosting startup types provided by the assembly are made available to the app using either of the following approaches:

* The enhanced app's project file makes an assembly reference to the hosting startup (a compile-time reference). With the compile-time reference in place, the hosting startup assembly and all of its dependencies are incorporated into the app's dependency file (*\*.deps.json*).
* The hosting startup's dependencies file is made available to the enhanced app as described in the [Runtime store](#runtime-store) section (without a compile-time reference).

## Sample code

The [sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/host/platform-specific-configuration/samples/) ([how to download](xref:tutorials/index#how-to-download-a-sample)) demonstrates three hosting startup implementation scenarios:

* Two hosting startup assemblies (class libraries) set a pair of in-memory configuration key-value pairs each:
  - NuGet package (*HostingStartupPackage*)
  - Class library (*HostingStartupLibrary*)
* A hosting startup is activated from a runtime store-deployed assembly (*StartupDiagnostics*). The assembly adds two middlewares to the app at startup that provide diagnostic information on:
  - Registered services
  - Address (scheme, host, path base, path, query string)
  - Connection (remote IP, remote port, local IP, local port, client certificate)
  - Request headers
  - Environment variables

To run the sample:

**Activation from a NuGet package**

1. Compile the *HostingStartupPackage* package with the [dotnet pack](/dotnet/core/tools/dotnet-pack) command.
1. Add the package's assembly name of the *HostingStartupPackage* to the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` environment variable.
1. Compile and run the app. A package reference is present in the enhanced app (a compile-time reference). A `<PropertyGroup>` in the app's project file specifies the package project's output (*../HostingStartupPackage/bin/Debug*) as a package source. This allows the app to use the package without uploading the package to [nuget.org](https://www.nuget.org/).

   ```xml
   <PropertyGroup>
     <RestoreSources>$(RestoreSources);https://api.nuget.org/v3/index.json;../HostingStartupPackage/bin/Debug</RestoreSources>
   </PropertyGroup>
   ```
1. Observe that the service configuration key values rendered by the Index page match the values set by the package's `ServiceKeyInjection.Configure` method.

**Activation from a class library**

1. Compile the *HostingStartupLibrary* class library with the [dotnet build](/dotnet/core/tools/dotnet-build) command.
1. Add the class library's assembly name of *HostingStartupLibrary* to the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` environment variable.
1. *bin*-deploy the class library's assembly to the app by copying the *HostingStartupLibrary.dll* file from the class library's compiled output to the app's *bin* folder.
1. Compile and run the app. An `<ItemGroup>` in the app's project file references the class library's assembly (*.\bin\Debug\netcoreapp2.1\HostingStartupLibrary.dll*) (a compile-time reference):

   ```xml
   <ItemGroup>
     <Reference Include=".\bin\Debug\netcoreapp2.1\HostingStartupLibrary.dll">
       <HintPath>.\bin\Debug\netcoreapp2.1\HostingStartupLibrary.dll</HintPath>
       <SpecificVersion>False</SpecificVersion>
     </Reference>
   </ItemGroup>
   ```
1. Observe that the service configuration key values rendered by the Index page match the values set by the class library's `ServiceKeyInjection.Configure` method.

**Activation from a runtime store-deployed assembly**

1. The *StartupDiagnostics* project uses [PowerShell](/powershell/scripting/powershell-scripting) to modify its *StartupDiagnostics.deps.json* file. PowerShell is installed by default on Windows OS starting with Windows 7 SP1 and Windows Server 2008 R2 SP1. To obtain PowerShell on other platforms, see [Installing Windows PowerShell](/powershell/scripting/setup/installing-windows-powershell).
1. Build the *StartupDiagnostics* project. After the project is built, a build target in the project file automatically:
   * Triggers the PowerShell script to modify the *StartupDiagnostics.deps.json* file.
   * Moves the *StartupDiagnostics.deps.json* file to the user profile's *additionalDeps* folder.
1. Execute the `dotnet store` command at a command prompt in the hosting startup's directory to store the assembly and its dependencies in the user profile's runtime store:

   ```console
   dotnet store --manifest StartupDiagnostics.csproj --runtime win7-x64
   ```
   For Windows, the command uses the `win7-x64` runtime identifier (RID). When providing the hosting startup for a different runtime, substitute the correct RID.
1. Set the environment variables:
   * Add the assembly name of *StartupDiagnostics* to the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` environment variable.
   * Set the `DOTNET_ADDITIONAL_DEPS` environment variable to `%UserProfile%\.dotnet\x64\additionalDeps\StartupDiagnostics\`.
1. Run the sample app.
1. Request the `/services` endpoint to see the app's registered services. Request the `/diag` endpoint to see the diagnostic information.
