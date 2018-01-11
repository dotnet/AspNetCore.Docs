---
title: Add app features from an external assembly using IHostingStartup in ASP.NET Core
author: guardrex
description: Discover how to add features to an ASP.NET Core app from an external assembly using an IHostingStartup implementation.
ms.author: riande
manager: wpickett
ms.custom: mvc
ms.date: 12/07/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: host-and-deploy/ihostingstartup
---
# Add app features from an external assembly using IHostingStartup in ASP.NET Core

By [Luke Latham](https://github.com/guardrex)

An [IHostingStartup](/dotnet/api/microsoft.aspnetcore.hosting.ihostingstartup) implementation allows adding features to an app at startup from outside of the app's `Startup` class. For example, an external tooling library can use an `IHostingStartup` implementation to provide additional configuration providers or services to an app. `IHostingStartup` *is available in ASP.NET Core 2.0 and later.*

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/host-and-deploy/ihostingstartup/sample/) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Discover loaded hosting startup assemblies

To discover hosting startup assemblies loaded by the app or by libraries, enable logging and check the application logs. Errors that occur when loading assemblies are logged. Loaded hosting startup assemblies are logged at the Debug level, and all errors are logged.

The sample app reads the the [HostingStartupAssembliesKey](/dotnet/api/microsoft.aspnetcore.hosting.webhostdefaults.hostingstartupassemblieskey) into a `string` array and displays the result in the app's Index page:

[!code-csharp[Main](ihostingstartup/sample/HostingStartupSample/Pages/Index.cshtml.cs?name=snippet1&highlight=14-16)]

## Disable automatic loading of hosting startup assemblies

There are two ways to disable the automatic loading of hosting startup assemblies:

* Set the [Prevent Hosting Startup](xref:fundamentals/hosting#prevent-hosting-startup) host configuration setting.
* Set the `ASPNETCORE_preventHostingStartup` environment variable.

When either the host setting or the environment variable is set to `true` or `1`, hosting startup assemblies aren't automatically loaded. If both are set, the host setting controls the behavior.

Disabling hosting startup assemblies using the host setting or environment variable disables them globally and may disable several features of an app. It isn't currently possible to selectively disable a hosting startup assembly added by a library unless the library offers its own configuration option. A future release will offer the ability to selectively disable hosting startup assemblies (see [GitHub issue aspnet/Hosting #1243](https://github.com/aspnet/Hosting/pull/1243)).

## Implement IHostingStartup features

### Create the assembly

An `IHostingStartup` feature is deployed as an assembly based on a console app without an entry point. The assembly references the [Microsoft.AspNetCore.Hosting.Abstractions](https://www.nuget.org/packages/Microsoft.AspNetCore.Hosting.Abstractions/) package:

[!code-xml[Main](ihostingstartup/snapshot_sample/StartupFeature.csproj)]

A [HostingStartup](/dotnet/api/microsoft.aspnetcore.hosting.hostingstartupattribute) attribute identifies a class as an implementation of `IHostingStartup` for loading and execution when building the [IWebHost](/dotnet/api/microsoft.aspnetcore.hosting.iwebhost). In the following example, the namespace is `StartupFeature`, and the class is `StartupFeatureHostingStartup`:

[!code-csharp[Main](ihostingstartup/snapshot_sample/StartupFeature.cs?name=snippet1)]

A class implements `IHostingStartup`. The class's [Configure](/dotnet/api/microsoft.aspnetcore.hosting.ihostingstartup.configure) method uses an [IWebHostBuilder](/dotnet/api/microsoft.aspnetcore.hosting.iwebhostbuilder) to add features to an app:

[!code-csharp[Main](ihostingstartup/snapshot_sample/StartupFeature.cs?name=snippet2&highlight=3,5)]

When building an `IHostingStartup` project, the dependencies file (*\*.deps.json*) sets the `runtime` location of the assembly to the *bin* folder:

[!code-json[Main](ihostingstartup/snapshot_sample/StartupFeature1.deps.json?range=2-13&highlight=8)]

Only part of the file is shown. The assembly name in the example is `StartupFeature`.

### Update the dependencies file

The runtime location is specified in the *\*.deps.json* file. To active the feature, the `runtime` element must specify the location of the feature's runtime assembly. Prefix the `runtime` location with `lib/netcoreapp2.0/`:

[!code-json[Main](ihostingstartup/snapshot_sample/StartupFeature2.deps.json?range=2-13&highlight=8)]

In the sample app, modification of the *\*.deps.json* file is performed by a [PowerShell](/powershell/scripting/powershell-scripting) script. The PowerShell script is automatically triggered by a build target in the project file.

### Feature activation

**Place the assembly file**

The `IHostingStartup` implementation's assembly file must be *bin*-deployed in the app or placed in the [runtime store](/dotnet/core/deploying/runtime-store):

For per-user use, place the assembly in the user profile's runtime store at:

```
<DRIVE>\Users\<USER>\.dotnet\store\x64\netcoreapp2.0\<FEATURE_ASSEMBLY_NAME>\<FEATURE_VERSION>\lib\netcoreapp2.0\
```

For global use, place the assembly in the .NET Core installation's runtime store:

```
<DRIVE>\Program Files\dotnet\store\x64\netcoreapp2.0\<FEATURE_ASSEMBLY_NAME>\<FEATURE_VERSION>\lib\netcoreapp2.0\
```

When deploying the assembly to the runtime store, the symbols file may be deployed as well but isn't required for the feature to work.

**Place the dependencies file**

The implementation's *\*.deps.json* file must be in an accessible location.

For per-user use, place the file in the `additonalDeps` folder of the user profile's `.dotnet` settings: 

```
<DRIVE>\Users\<USER>\.dotnet\x64\additionalDeps\<FEATURE_ASSEMBLY_NAME>\shared\Microsoft.NETCore.App\2.0.0\
```

For global use, place the file in the `additonalDeps` folder of the .NET Core installation:

```
<DRIVE>\Program Files\dotnet\additionalDeps\<FEATURE_ASSEMBLY_NAME>\shared\Microsoft.NETCore.App\2.0.0\
```

Note the version, `2.0.0`, reflects the version of the shared runtime that the target app uses. The shared runtime is shown in the *\*.runtimeconfig.json* file. In the sample app, the shared runtime is specified in the *HostingStartupSample.runtimeconfig.json* file.

**Set environment variables**

Set the following environment variables in the context of the app that uses the feature.

ASPNETCORE\_HOSTINGSTARTUPASSEMBLIES

Only hosting startup assemblies are scanned for the `HostingStartupAttribute`. The assembly name of the implementation is provided in this environment variable. The sample app sets this value to `StartupDiagnostics`.

The value can also be set using the [Hosting Startup Assemblies](xref:fundamentals/hosting#hosting-startup-assemblies) host configuration setting.

DOTNET\_ADDITIONAL\_DEPS

The location of the implementation's *\*.deps.json* file.

If the file is placed in the user profile's *.dotnet* folder for per-user use:

```
<DRIVE>\Users\<USER>\.dotnet\x64\additionalDeps\
```

If the file is placed in the .NET Core installation for global use, provide the full path to the file:

```
<DRIVE>\Program Files\dotnet\additionalDeps\<FEATURE_ASSEMBLY_NAME>\shared\Microsoft.NETCore.App\2.0.0\<FEATURE_ASSEMBLY_NAME>.deps.json
```

The sample app sets this value to:

```
%UserProfile%\.dotnet\x64\additionalDeps\StartupDiagnostics\
```

For examples of how to set environment variables for various operating systems, see [Working with multiple environments](xref:fundamentals/environments).

## Sample app

The [sample app](https://github.com/aspnet/Docs/tree/master/aspnetcore/host-and-deploy/ihostingstartup/sample/) ([how to download](xref:tutorials/index#how-to-download-a-sample)) uses `IHostingStartup` to create a diagnostics tool. The tool adds two middlewares to the app at startup that provide diagnostic information:

* Registered services
* Address: scheme, host, path base, path, query string
* Connection: remote IP, remote port, local IP, local port, client certificate
* Request headers
* Environment variables

To run the sample:

1. The Startup Diagnostic project uses [PowerShell](/powershell/scripting/powershell-scripting) to modify its *StartupDiagnostics.deps.json* file. PowerShell is installed by default on Windows OS starting with Windows 7 SP1 and Windows Server 2008 R2 SP1. To obtain PowerShell on other platforms, see [Installing Windows PowerShell](/powershell/scripting/setup/installing-windows-powershell).
2. Build the Startup Diagnostic project. A build target in the project file:
   * Moves the assembly and symbols files to the user profile's runtime store.
   * Triggers the PowerShell script to modify the *StartupDiagnostics.deps.json* file.
   * Moves the *StartupDiagnostics.deps.json* file to the user profile's `additionalDeps` folder.
3. Set the environment variables:
    * `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES`: `StartupDiagnostics`
    * `DOTNET_ADDITIONAL_DEPS`: `%UserProfile%\.dotnet\x64\additionalDeps\StartupDiagnostics\`
4. Run the sample app.
5. Request the `/services` endpoint to see the app's registered services. Request the `/diag` endpoint to see the diagnostic information.
