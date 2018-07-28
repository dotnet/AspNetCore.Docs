---
title: Enhance an app from an external assembly in ASP.NET Core with IHostingStartup
author: guardrex
description: Discover how to enhance an ASP.NET Core app from a class library or external assembly using an IHostingStartup implementation.
monikerRange: '>= aspnetcore-2.0'
ms.author: riande
ms.custom: mvc
ms.date: 07/27/2018
uid: fundamentals/configuration/platform-specific-configuration
---
# Enhance an app from an external assembly in ASP.NET Core with IHostingStartup

By [Luke Latham](https://github.com/guardrex)

An [IHostingStartup](/dotnet/api/microsoft.aspnetcore.hosting.ihostingstartup) (hosting startup) implementation adds enhancements to an app at startup from an external assembly from outside of the app's `Startup` class. For example, an external tooling library can use a hosting startup implementation to provide additional configuration providers or services to an app. `IHostingStartup` *is available in ASP.NET Core 2.0 or later.*

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/host/platform-specific-configuration/samples/) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Discover loaded hosting startup assemblies

To discover loaded hosting startup assemblies, enable logging and check the application logs. Errors that occur when loading assemblies are logged. Loaded hosting startup assemblies are logged at the Debug level, and all errors are logged.

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

## HostingStartup attribute

A [HostingStartup](/dotnet/api/microsoft.aspnetcore.hosting.hostingstartupattribute) attribute indicates the presence of a hosting startup assembly to activate at runtime.

The entry assembly or the assembly containing the `Startup` class is automatically scanned for the `HostingStartup` attribute. The list of assemblies to search for `HostingStartup` attributes is loaded at runtime from configuration from the [WebHostDefaults.HostingStartupAssembliesKey](/dotnet/api/microsoft.aspnetcore.hosting.webhostdefaults.hostingstartupassemblieskey). The list of assemblies to exclude from discovery is loaded from the [WebHostDefaults.HostingStartupExcludeAssembliesKey](/dotnet/api/microsoft.aspnetcore.hosting.webhostdefaults.hostingstartupexcludeassemblieskey). For more information, see [Web Host: Hosting Startup Assemblies](xref:fundamentals/host/web-host#hosting-startup-assemblies) and [Web Host: Hosting Startup Exclude Assemblies](xref:fundamentals/host/web-host#hosting-startup-exclude-assemblies).

In the following example, the namespace of the hosting startup assembly is `StartupEnhancement`, and the class containing the hosting startup code is `StartupEnhancementHostingStartup`:

[!code-csharp[](platform-specific-configuration/samples-snapshot/2.x/StartupEnhancement.cs?name=snippet1)]

The `HostingStartup` attribute is typically located in the hosting startup assembly's `IHostingStartup` implementation class file.

## Activation approaches

There are three approaches that you can take to deliver and activate a hosting startup assembly:

| Approach | Compile-time reference required |
| -------- | ------------------------------- |
| [NuGet package](#nuget-package-activation) | Yes |
| [Class library](#class-library-activation-bin-deployment) *bin*-deployed | Yes |
| [Class library](#class-library-activation-runtimestoredeployment) runtime store-deployed | No |
| [Assembly](#assembly-activation) | No |

When a compile-time reference is required, the app receiving the hosting startup enhancement must reference the assembly providing the enhancement. With the compile-time reference in place, the hosting startup assembly and all of its dependencies are incorporated into the app's dependency file (*.\*.deps.json*).

When a compile-time reference isn't provided, the hosting startup assembly's dependency file must be provided to the app.

## NuGet package activation

A hosting startup enhancement can be provided in a NuGet package (the package has a `HostingStartup` attribute). The hosting startup types provided by the package are made available to the app via a package reference in the app's project file with the assembly name listed in the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` environment variable.

The [sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/host/platform-specific-configuration/samples/) includes a Razor Pages app, *HostingStartupApp*, and a NuGet package, *HostingStartupPackage*. The package:

* Contains a hosting startup class, `ServiceKeyInjection`, which implements `IHostingStartup`. `ServiceKeyInjection` adds a pair of service strings to the app's configuration using the in-memory configuration provider ([AddInMemoryCollection](/dotnet/api/microsoft.extensions.configuration.memoryconfigurationbuilderextensions.addinmemorycollection)).
* Includes a `HostingStartup` attribute that identifies the hosting startup's namespace and class.

The `ServiceKeyInjection` class's [Configure](/dotnet/api/microsoft.aspnetcore.hosting.ihostingstartup.configure) method uses an [IWebHostBuilder](/dotnet/api/microsoft.aspnetcore.hosting.iwebhostbuilder) to add enhancements to an app. `IHostingStartup.Configure` in the hosting startup assembly is called by the runtime before `Startup.Configure` in user code, which allows user code to overwrite any configuration provided by the hosting startup assembly.

*HostingStartupPackage/ServiceKeyInjection.cs*:

[!code-csharp[](platform-specific-configuration/samples/2.x/HostingStartupPackage/ServiceKeyInjection.cs?name=snippet1)]

The app's Index page reads the configuration values for the two keys set by the package's hosting startup assembly. The configuration values for these keys are displayed when the page is rendered.

*HostingStartupApp/Pages/Index.cshtml.cs*:

[!code-csharp[](platform-specific-configuration/samples/2.x/HostingStartupApp/Pages/Index.cshtml.cs?name=snippet1&highlight=5-6,11-12)]

The NuGet package is listed as a package reference in the app's project file, and the package's assembly name is listed in the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` environment variable. The environment variable is a semicolon-delimited list of assemblies that contain a `HostingStartup` attribute that identifies a hosting startup enhancement to load.

The package's assembly name can also be provided using the [Hosting Startup Assemblies](xref:fundamentals/host/web-host#hosting-startup-assemblies) host configuration setting.

When multiple hosting startup assembles are present, their [Configure](/dotnet/api/microsoft.aspnetcore.hosting.ihostingstartup.configure) methods are executed in the order that the assemblies are listed.

## Class library activation (bin-deployment)

A hosting startup enhancement can be provided in a class library (the library has a `HostingStartup` attribute). The hosting startup types provided by the library can be made available to the app via a *bin*-deployed assembly with the assembly name listed in the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` environment variable.

The [sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/host/platform-specific-configuration/samples/) includes a Razor Pages app, *HostingStartupApp*, and a class library, *HostingStartupLibrary*. The class library:

* Contains a hosting startup class, `ServiceKeyInjection`, which implements `IHostingStartup`. `ServiceKeyInjection` adds a pair of service strings to the app's configuration using the in-memory configuration provider ([AddInMemoryCollection](/dotnet/api/microsoft.extensions.configuration.memoryconfigurationbuilderextensions.addinmemorycollection)).
* Includes a `HostingStartup` attribute that identifies the hosting startup's namespace and class.

The `ServiceKeyInjection` class's [Configure](/dotnet/api/microsoft.aspnetcore.hosting.ihostingstartup.configure) method uses an [IWebHostBuilder](/dotnet/api/microsoft.aspnetcore.hosting.iwebhostbuilder) to add enhancements to an app. `IHostingStartup.Configure` in the hosting startup assembly is called by the runtime before `Startup.Configure` in user code, which allows user code to overwrite any configuration provided by the hosting startup assembly.

*HostingStartupLibrary/ServiceKeyInjection.cs*:

[!code-csharp[](platform-specific-configuration/samples/2.x/HostingStartupLibrary/ServiceKeyInjection.cs?name=snippet1)]

The app's Index page reads the configuration values for the two keys set by the class library's hosting startup assembly. The configuration values for these keys are displayed when the page is rendered.

*HostingStartupApp/Pages/Index.cshtml.cs*:

[!code-csharp[](platform-specific-configuration/samples/2.x/HostingStartupApp/Pages/Index.cshtml.cs?name=snippet1&highlight=7-8,13-14)]

The app requires a compile-time reference to the assembly. Use one of the following approaches:

* *bin*-deploy the assembly.
* Provide a compile-time reference to the assembly.

In the sample app, the compiled class library is *bin*-deployed.

The class library's assembly name is listed in the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` environment variable. The environment variable is a semicolon-delimited list of assemblies that contain a `HostingStartup` attribute that identifies a hosting startup enhancement to load.

The class library's assembly name can also be provided using the [Hosting Startup Assemblies](xref:fundamentals/host/web-host#hosting-startup-assemblies) host configuration setting.

When multiple hosting startup assembles are present, their [Configure](/dotnet/api/microsoft.aspnetcore.hosting.ihostingstartup.configure) methods are executed in the order that the assemblies are listed.

## Class library activation (runtime store deployment)

A hosting startup enhancement can be provided in a class library (the library has a `HostingStartup` attribute). The hosting startup types provided by the library can be made available to the app via a runtime store-deployed assembly with:

* The assembly name listed in the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` environment variable.
* The hosting startup's dependencies file 

The [sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/host/platform-specific-configuration/samples/) includes a Razor Pages app, *HostingStartupApp*, and a class library, *HostingStartupLibrary*. The class library:

* Contains a hosting startup class, `ServiceKeyInjection`, which implements `IHostingStartup`. `ServiceKeyInjection` adds a pair of service strings to the app's configuration using the in-memory configuration provider ([AddInMemoryCollection](/dotnet/api/microsoft.extensions.configuration.memoryconfigurationbuilderextensions.addinmemorycollection)).
* Includes a `HostingStartup` attribute that identifies the hosting startup's namespace and class.

The `ServiceKeyInjection` class's [Configure](/dotnet/api/microsoft.aspnetcore.hosting.ihostingstartup.configure) method uses an [IWebHostBuilder](/dotnet/api/microsoft.aspnetcore.hosting.iwebhostbuilder) to add enhancements to an app. `IHostingStartup.Configure` in the hosting startup assembly is called by the runtime before `Startup.Configure` in user code, which allows user code to overwrite any configuration provided by the hosting startup assembly.

*HostingStartupLibrary/ServiceKeyInjection.cs*:

[!code-csharp[](platform-specific-configuration/samples/2.x/HostingStartupLibrary/ServiceKeyInjection.cs?name=snippet1)]

The app's Index page reads the configuration values for the two keys set by the class library's hosting startup assembly. The configuration values for these keys are displayed when the page is rendered.

*HostingStartupApp/Pages/Index.cshtml.cs*:

[!code-csharp[](platform-specific-configuration/samples/2.x/HostingStartupApp/Pages/Index.cshtml.cs?name=snippet1&highlight=7-8,13-14)]

The app requires a compile-time reference to the assembly. Use one of the following approaches:

* *bin*-deploy the assembly.
* Provide a compile-time reference to the assembly.
* Place the assembly into the [runtime store](/dotnet/core/deploying/runtime-store). When placed into the runtime store 

In the sample app, the compiled class library is *bin*-deployed.

The class library's assembly name is listed in the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` environment variable. The environment variable is a semicolon-delimited list of assemblies that contain a `HostingStartup` attribute that identifies a hosting startup enhancement to load.

The class library's assembly name can also be provided using the [Hosting Startup Assemblies](xref:fundamentals/host/web-host#hosting-startup-assemblies) host configuration setting.

When multiple hosting startup assembles are present, their [Configure](/dotnet/api/microsoft.aspnetcore.hosting.ihostingstartup.configure) methods are executed in the order that the assemblies are listed.

## Assembly activation

This section describes how to activate a hosting startup from an assembly that doesn't have a compile-time reference. The following approach is only available for .NET Core apps, not .NET Framework.

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

When deploying the assembly to the runtime store, the symbols file may be deployed as well but isn't required for the enhancement to function.

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

Only hosting startup assemblies are scanned for the `HostingStartup` attribute. The assembly name of the implementation is provided in this environment variable. The sample app sets this value to `StartupDiagnostics`.

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

## Sample code

The [sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/host/platform-specific-configuration/samples/) ([how to download](xref:tutorials/index#how-to-download-a-sample)) demonstrates the three hosting startup scenarios described earlier in this topic:

* A hosting startup assembly provided by a *NuGet package* that sets a pair of in-memory configuration key-value pairs.
* A hosting startup assembly provided by a *class library* that sets a pair of in-memory configuration key-value pairs.
* Hosting startup activated from a *runtime store-deployed assembly*. The assembly adds two middlewares to the app at startup that provide diagnostic information on:
  - Registered services
  - Address (scheme, host, path base, path, query string)
  - Connection (remote IP, remote port, local IP, local port, client certificate)
  - Request headers
  - Environment variables

To run the sample:

**Activation from a NuGet package**

1. Compile the *HostingStartupPackage* package with the [dotnet pack](/dotnet/core/tools/dotnet-pack) command.
1. Add the `PackageId` of *HostingStartupPackage* to the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` environment variable.
1. Compile and run the app. A **&lt;PropertyGroup&gt;** in the app's project file specifies the package project's output (*../HostingStartupPackage/bin/Debug*) as a package source. This allows the app to use the package without uploading the package to nuget.org.

   ```xml
   <PropertyGroup>
     <RestoreSources>$(RestoreSources);https://api.nuget.org/v3/index.json;../HostingStartupPackage/bin/Debug</RestoreSources>
   </PropertyGroup>
   ```
1. Observe that the service configuration key values rendered by the Index page match the values set by the package's `ServiceKeyInjection.Configure` method.

**Activation from a class library**

1. Compile the *HostingStartupLibrary* class library with the [dotnet build](/dotnet/core/tools/dotnet-build) command.
1. Add the class library's assembly name of *HostingStartupLibrary* to the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` environment variable.
1. *bin*-deploy the class library's assembly to the app. **Copy the *HostingStartupLibrary.dll* file from the class library's compiled output to the app's _bin_ folder.**
1. Compile and run the app. An **&lt;ItemGroup&gt;** in the app's project file references the class library's assembly (*.\bin\Debug\netcoreapp2.1\HostingStartupLibrary.dll*):

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

1. The Startup Diagnostic project uses [PowerShell](/powershell/scripting/powershell-scripting) to modify its *StartupDiagnostics.deps.json* file. PowerShell is installed by default on Windows OS starting with Windows 7 SP1 and Windows Server 2008 R2 SP1. To obtain PowerShell on other platforms, see [Installing Windows PowerShell](/powershell/scripting/setup/installing-windows-powershell).
1. Build the Startup Diagnostic project. When the project is built, a build target in the project file automatically:
   * Moves the assembly and symbols files to the user profile's runtime store.
   * Triggers the PowerShell script to modify the *StartupDiagnostics.deps.json* file.
   * Moves the *StartupDiagnostics.deps.json* file to the user profile's `additionalDeps` folder.
1. Set the environment variables:
   * Add the assembly name of *StartupDiagnostics* to the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` environment variable.
   * Set the `DOTNET_ADDITIONAL_DEPS` environment variable to `%UserProfile%\.dotnet\x64\additionalDeps\StartupDiagnostics\`.
1. Run the sample app.
1. Request the `/services` endpoint to see the app's registered services. Request the `/diag` endpoint to see the diagnostic information.
