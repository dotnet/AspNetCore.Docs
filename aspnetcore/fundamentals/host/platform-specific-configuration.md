---
title: Use hosting startup assemblies in ASP.NET Core
author: tdykstra
description: Discover how to enhance an ASP.NET Core app from an external assembly using an IHostingStartup implementation.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.custom: "mvc, seodec18"
ms.date: 09/26/2019
uid: fundamentals/configuration/platform-specific-configuration
---
# Use hosting startup assemblies in ASP.NET Core

By [Pavel Krymets](https://github.com/pakrym)

:::moniker range=">= aspnetcore-3.0"

An <xref:Microsoft.AspNetCore.Hosting.IHostingStartup> (hosting startup) implementation adds enhancements to an app at startup from an external assembly. For example, an external library can use a hosting startup implementation to provide additional configuration providers or services to an app.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/host/platform-specific-configuration/samples/) ([how to download](xref:index#how-to-download-a-sample))

## HostingStartup attribute

A [HostingStartup](xref:Microsoft.AspNetCore.Hosting.HostingStartupAttribute) attribute indicates the presence of a hosting startup assembly to activate at runtime.

The entry assembly or the assembly containing the `Startup` class is automatically scanned for the `HostingStartup` attribute. The list of assemblies to search for `HostingStartup` attributes is loaded at runtime from configuration in the [WebHostDefaults.HostingStartupAssembliesKey](xref:Microsoft.AspNetCore.Hosting.WebHostDefaults.HostingStartupAssembliesKey). The list of assemblies to exclude from discovery is loaded from the [WebHostDefaults.HostingStartupExcludeAssembliesKey](xref:Microsoft.AspNetCore.Hosting.WebHostDefaults.HostingStartupExcludeAssembliesKey).

In the following example, the namespace of the hosting startup assembly is `StartupEnhancement`. The class containing the hosting startup code is `StartupEnhancementHostingStartup`:

[!code-csharp[](platform-specific-configuration/samples-snapshot/3.x/StartupEnhancement.cs?name=snippet1)]

The `HostingStartup` attribute is typically located in the hosting startup assembly's `IHostingStartup` implementation class file.

## Discover loaded hosting startup assemblies

To discover loaded hosting startup assemblies, enable logging and check the app's logs. Errors that occur when loading assemblies are logged. Loaded hosting startup assemblies are logged at the Debug level, and all errors are logged.

## Disable automatic loading of hosting startup assemblies

To disable automatic loading of hosting startup assemblies, use one of the following approaches:

* To prevent all hosting startup assemblies from loading, set one of the following to `true` or `1`:

  * Prevent Hosting Startup host configuration setting:

    ```csharp
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseSetting(
                        WebHostDefaults.PreventHostingStartupKey, "true")
                    .UseStartup<Startup>();
            });
    ```

  * `ASPNETCORE_PREVENTHOSTINGSTARTUP` environment variable.

* To prevent specific hosting startup assemblies from loading, set one of the following to a semicolon-delimited string of hosting startup assemblies to exclude at startup:

  * Hosting Startup Exclude Assemblies host configuration setting:

    ```csharp
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseSetting(
                        WebHostDefaults.HostingStartupExcludeAssembliesKey, 
                        "{ASSEMBLY1;ASSEMBLY2; ...}")
                    .UseStartup<Startup>();
            });
    ```
    
    The `{ASSEMBLY1;ASSEMBLY2; ...}` placeholder represents the semicolon-separated list of assemblies.

  * `ASPNETCORE_HOSTINGSTARTUPEXCLUDEASSEMBLIES` environment variable.

If both the host configuration setting and the environment variable are set, the host setting controls the behavior.

Disabling hosting startup assemblies using the host setting or environment variable disables the assembly globally and may disable several characteristics of an app.

## Project

Create a hosting startup with either of the following project types:

* [Class library](#class-library)
* [Console app without an entry point](#console-app-without-an-entry-point)

### Class library

A hosting startup enhancement can be provided in a class library. The library contains a `HostingStartup` attribute.

The [sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/host/platform-specific-configuration/samples/) includes a Razor Pages app, *HostingStartupApp*, and a class library, *HostingStartupLibrary*. The class library:

* Contains a hosting startup class, `ServiceKeyInjection`, which implements `IHostingStartup`. `ServiceKeyInjection` adds a pair of service strings to the app's configuration using the in-memory configuration provider ([AddInMemoryCollection](xref:Microsoft.Extensions.Configuration.MemoryConfigurationBuilderExtensions.AddInMemoryCollection*)).
* Includes a `HostingStartup` attribute that identifies the hosting startup's namespace and class.

The `ServiceKeyInjection` class's <xref:Microsoft.AspNetCore.Hosting.IHostingStartup.Configure*> method uses an <xref:Microsoft.AspNetCore.Hosting.IWebHostBuilder> to add enhancements to an app.

`HostingStartupLibrary/ServiceKeyInjection.cs`:

[!code-csharp[](platform-specific-configuration/samples/3.x/HostingStartupLibrary/ServiceKeyInjection.cs?name=snippet1)]

The app's Index page reads and renders the configuration values for the two keys set by the class library's hosting startup assembly:

`HostingStartupApp/Pages/Index.cshtml.cs`:

[!code-csharp[](platform-specific-configuration/samples/3.x/HostingStartupApp/Pages/Index.cshtml.cs?name=snippet1&highlight=5-6,11-12)]

The [sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/host/platform-specific-configuration/samples/) also includes a NuGet package project that provides a separate hosting startup, *HostingStartupPackage*. The package has the same characteristics of the class library described earlier. The package:

* Contains a hosting startup class, `ServiceKeyInjection`, which implements `IHostingStartup`. `ServiceKeyInjection` adds a pair of service strings to the app's configuration.
* Includes a `HostingStartup` attribute.

`HostingStartupPackage/ServiceKeyInjection.cs`:

[!code-csharp[](platform-specific-configuration/samples/3.x/HostingStartupPackage/ServiceKeyInjection.cs?name=snippet1)]

The app's Index page reads and renders the configuration values for the two keys set by the package's hosting startup assembly:

`HostingStartupApp/Pages/Index.cshtml.cs`:

[!code-csharp[](platform-specific-configuration/samples/3.x/HostingStartupApp/Pages/Index.cshtml.cs?name=snippet1&highlight=7-8,13-14)]

### Console app without an entry point

*This approach is only available for .NET Core apps, not .NET Framework.*

A dynamic hosting startup enhancement that doesn't require a compile-time reference for activation can be provided in a console app without an entry point that contains a `HostingStartup` attribute. Publishing the console app produces a hosting startup assembly that can be consumed from the runtime store.

A console app without an entry point is used in this process because:

* A dependencies file is required to consume the hosting startup in the hosting startup assembly. A dependencies file is a runnable app asset that's produced by publishing an app, not a library.
* A library can't be added directly to the [runtime package store](/dotnet/core/deploying/runtime-store), which requires a runnable project that targets the shared runtime.

In the creation of a dynamic hosting startup:

* A hosting startup assembly is created from the console app without an entry point that:
  * Includes a class that contains the `IHostingStartup` implementation.
  * Includes a [HostingStartup](xref:Microsoft.AspNetCore.Hosting.HostingStartupAttribute) attribute to identify the `IHostingStartup` implementation class.
* The console app is published to obtain the hosting startup's dependencies. A consequence of publishing the console app is that unused dependencies are trimmed from the dependencies file.
* The dependencies file is modified to set the runtime location of the hosting startup assembly.
* The hosting startup assembly and its dependencies file is placed into the runtime package store. To discover the hosting startup assembly and its dependencies file, they're listed in a pair of environment variables.

The console app references the [Microsoft.AspNetCore.Hosting.Abstractions](https://www.nuget.org/packages/Microsoft.AspNetCore.Hosting.Abstractions/) package:

[!code-xml[](platform-specific-configuration/samples-snapshot/3.x/StartupEnhancement.csproj)]

A [HostingStartup](xref:Microsoft.AspNetCore.Hosting.HostingStartupAttribute) attribute identifies a class as an implementation of `IHostingStartup` for loading and execution when building the <xref:Microsoft.AspNetCore.Hosting.IWebHost>. In the following example, the namespace is `StartupEnhancement`, and the class is `StartupEnhancementHostingStartup`:

[!code-csharp[](platform-specific-configuration/samples-snapshot/3.x/StartupEnhancement.cs?name=snippet1)]

A class implements `IHostingStartup`. The class's <xref:Microsoft.AspNetCore.Hosting.IHostingStartup.Configure*> method uses an <xref:Microsoft.AspNetCore.Hosting.IWebHostBuilder> to add enhancements to an app. `IHostingStartup.Configure` in the hosting startup assembly is called by the runtime before `Startup.Configure` in user code, which allows user code to overwrite any configuration provided by the hosting startup assembly.

[!code-csharp[](platform-specific-configuration/samples-snapshot/3.x/StartupEnhancement.cs?name=snippet2&highlight=3,5)]

When building an `IHostingStartup` project, the dependencies file (`.deps.json`) sets the `runtime` location of the assembly to the *bin* folder:

[!code-json[](platform-specific-configuration/samples-snapshot/3.x/StartupEnhancement1.deps.json?range=2-13&highlight=8)]

Only part of the file is shown. The assembly name in the example is `StartupEnhancement`.

## Configuration provided by the hosting startup

There are two approaches to handling configuration depending on whether you want the hosting startup's configuration to take precedence or the app's configuration to take precedence:

1. Provide configuration to the app using <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder.ConfigureAppConfiguration*> to load the configuration after the app's <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder.ConfigureAppConfiguration*> delegates execute. Hosting startup configuration takes priority over the app's configuration using this approach.
1. Provide configuration to the app using <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseConfiguration*> to load the configuration before the app's <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder.ConfigureAppConfiguration*> delegates execute. The app's configuration values take priority over those provided by the hosting startup using this approach.

```csharp
public class ConfigurationInjection : IHostingStartup
{
    public void Configure(IWebHostBuilder builder)
    {
        Dictionary<string, string> dict;

        builder.ConfigureAppConfiguration(config =>
        {
            dict = new Dictionary<string, string>
            {
                {"ConfigurationKey1", 
                    "From IHostingStartup: Higher priority " +
                    "than the app's configuration."},
            };

            config.AddInMemoryCollection(dict);
        });

        dict = new Dictionary<string, string>
        {
            {"ConfigurationKey2", 
                "From IHostingStartup: Lower priority " +
                "than the app's configuration."},
        };

        var builtConfig = new ConfigurationBuilder()
            .AddInMemoryCollection(dict)
            .Build();

        builder.UseConfiguration(builtConfig);
    }
}
```

## Specify the hosting startup assembly

For either a class library- or console app-supplied hosting startup, specify the hosting startup assembly's name in the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` environment variable. The environment variable is a semicolon-delimited list of assemblies.

Only hosting startup assemblies are scanned for the `HostingStartup` attribute. For the sample app, *HostingStartupApp*, to discover the hosting startups described earlier, the environment variable is set to the following value:

```
HostingStartupLibrary;HostingStartupPackage;StartupDiagnostics
```

A hosting startup assembly can also be set using the Hosting Startup Assemblies host configuration setting:

```csharp
public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseSetting(
                    WebHostDefaults.HostingStartupAssembliesKey, 
                    "{ASSEMBLY1;ASSEMBLY2; ...}")
                .UseStartup<Startup>();
        });
```

The `{ASSEMBLY1;ASSEMBLY2; ...}` placeholder represents the semicolon-separated list of assemblies.

When multiple hosting startup assembles are present, their <xref:Microsoft.AspNetCore.Hosting.IHostingStartup.Configure*> methods are executed in the order that the assemblies are listed.

## Activation

Options for hosting startup activation are:

* [Runtime store](#runtime-store): Activation doesn't require a compile-time reference for activation. The sample app places the hosting startup assembly and dependencies files into a folder, *deployment*, to facilitate deployment of the hosting startup in a multimachine environment. The *deployment* folder also includes a PowerShell script that creates or modifies environment variables on the deployment system to enable the hosting startup.
* Compile-time reference required for activation
  * [NuGet package](#nuget-package)
  * [Project bin folder](#project-bin-folder)

### Runtime store

The hosting startup implementation is placed in the [runtime store](/dotnet/core/deploying/runtime-store). A compile-time reference to the assembly isn't required by the enhanced app.

After the hosting startup is built, a runtime store is generated using the manifest project file and the [dotnet store](/dotnet/core/tools/dotnet-store) command.

```dotnetcli
dotnet store --manifest {MANIFEST FILE} --runtime {RUNTIME IDENTIFIER} --output {OUTPUT LOCATION} --skip-optimization
```

In the sample app (*RuntimeStore* project) the following command is used:

```dotnetcli
dotnet store --manifest store.manifest.csproj --runtime win7-x64 --output ./deployment/store --skip-optimization
```

For the runtime to discover the runtime store, the runtime store's location is added to the `DOTNET_SHARED_STORE` environment variable.

**Modify and place the hosting startup's dependencies file**

To activate the enhancement without a package reference to the enhancement, specify additional dependencies to the runtime with `additionalDeps`. `additionalDeps` allows you to:

* Extend the app's library graph by providing a set of additional `.deps.json` files to merge with the app's own `.deps.json` file on startup.
* Make the hosting startup assembly discoverable and loadable.

The recommended approach for generating the additional dependencies file is to:

 1. Execute `dotnet publish` on the runtime store manifest file referenced in the previous section.
 1. Remove the manifest reference from libraries and the `runtime` section of the resulting `.deps.json` file.

In the example project, the `store.manifest/1.0.0` property is removed from the `targets` and `libraries` section:

```json
{
  "runtimeTarget": {
    "name": ".NETCoreApp,Version=v3.0",
    "signature": ""
  },
  "compilationOptions": {},
  "targets": {
    ".NETCoreApp,Version=v3.0": {
      "store.manifest/1.0.0": {
        "dependencies": {
          "StartupDiagnostics": "1.0.0"
        },
        "runtime": {
          "store.manifest.dll": {}
        }
      },
      "StartupDiagnostics/1.0.0": {
        "runtime": {
          "lib/netcoreapp3.0/StartupDiagnostics.dll": {
            "assemblyVersion": "1.0.0.0",
            "fileVersion": "1.0.0.0"
          }
        }
      }
    }
  },
  "libraries": {
    "store.manifest/1.0.0": {
      "type": "project",
      "serviceable": false,
      "sha512": ""
    },
    "StartupDiagnostics/1.0.0": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-xrhzuNSyM5/f4ZswhooJ9dmIYLP64wMnqUJSyTKVDKDVj5T+qtzypl8JmM/aFJLLpYrf0FYpVWvGujd7/FfMEw==",
      "path": "startupdiagnostics/1.0.0",
      "hashPath": "startupdiagnostics.1.0.0.nupkg.sha512"
    }
  }
}
```

Place the `.deps.json` file into the following location:

```
{ADDITIONAL DEPENDENCIES PATH}/shared/{SHARED FRAMEWORK NAME}/{SHARED FRAMEWORK VERSION}/{ENHANCEMENT ASSEMBLY NAME}.deps.json
```

* `{ADDITIONAL DEPENDENCIES PATH}`: Location added to the `DOTNET_ADDITIONAL_DEPS` environment variable.
* `{SHARED FRAMEWORK NAME}`: Shared framework required for this additional dependencies file.
* `{SHARED FRAMEWORK VERSION}`: Minimum shared framework version.
* `{ENHANCEMENT ASSEMBLY NAME}`: The enhancement's assembly name.

In the sample app (*RuntimeStore* project), the additional dependencies file is placed into the following location:

```
deployment/additionalDeps/shared/Microsoft.AspNetCore.App/3.0.0/StartupDiagnostics.deps.json
```

For runtime to discover the runtime store location, the additional dependencies file location is added to the `DOTNET_ADDITIONAL_DEPS` environment variable.

In the sample app (*RuntimeStore* project), building the runtime store and generating the additional dependencies file is accomplished using a [PowerShell](/powershell/scripting/overview) script.

For examples of how to set environment variables for various operating systems, see [Use multiple environments](xref:fundamentals/environments).

**Deployment**

To facilitate the deployment of a hosting startup in a multimachine environment, the sample app creates a *deployment* folder in published output that contains:

* The hosting startup runtime store.
* The hosting startup dependencies file.
* A PowerShell script that creates or modifies the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES`, `DOTNET_SHARED_STORE`, and `DOTNET_ADDITIONAL_DEPS` to support the activation of the hosting startup. Run the script from an administrative PowerShell command prompt on the deployment system.

### NuGet package

A hosting startup enhancement can be provided in a NuGet package. The package has a `HostingStartup` attribute. The hosting startup types provided by the package are made available to the app using either of the following approaches:

* The enhanced app's project file makes a package reference for the hosting startup in the app's project file (a compile-time reference). With the compile-time reference in place, the hosting startup assembly and all of its dependencies are incorporated into the app's dependency file (`.deps.json`). This approach applies to a hosting startup assembly package published to [nuget.org](https://www.nuget.org/).
* The hosting startup's dependencies file is made available to the enhanced app as described in the [Runtime store](#runtime-store) section (without a compile-time reference).

For more information on NuGet packages and the runtime store, see the following topics:

* [How to Create a NuGet Package with Cross Platform Tools](/dotnet/core/deploying/creating-nuget-packages)
* [Publishing packages](/nuget/create-packages/publish-a-package)
* [Runtime package store](/dotnet/core/deploying/runtime-store)

### Project bin folder

A hosting startup enhancement can be provided by a *bin*-deployed assembly in the enhanced app. The hosting startup types provided by the assembly are made available to the app using one of the following approaches:

* The enhanced app's project file makes an assembly reference to the hosting startup (a compile-time reference). With the compile-time reference in place, the hosting startup assembly and all of its dependencies are incorporated into the app's dependency file (`.deps.json`). This approach applies when the deployment scenario calls for making a compile-time reference to the hosting startup's assembly (*.dll* file) and moving the assembly to either:
  * The consuming project.
  * A location accessible by the consuming project.
* The hosting startup's dependencies file is made available to the enhanced app as described in the [Runtime store](#runtime-store) section (without a compile-time reference).
* When targeting the .NET Framework, the assembly is loadable in the default load context, which on .NET Framework means that the assembly is located at either of the following locations:
  * Application base path: The *bin* folder where the app's executable (*.exe*) is located.
  * Global Assembly Cache (GAC): The GAC stores assemblies that several .NET Framework apps share. For more information, see [How to: Install an assembly into the global assembly cache](/dotnet/framework/app-domains/how-to-install-an-assembly-into-the-gac) in the .NET Framework documentation.

## Sample code

The [sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/host/platform-specific-configuration/samples/) ([how to download](xref:index#how-to-download-a-sample)) demonstrates hosting startup implementation scenarios:

* Two hosting startup assemblies (class libraries) set a pair of in-memory configuration key-value pairs each:
  * NuGet package (*HostingStartupPackage*)
  * Class library (*HostingStartupLibrary*)
* A hosting startup is activated from a runtime store-deployed assembly (*StartupDiagnostics*). The assembly adds two middlewares to the app at startup that provide diagnostic information on:
  * Registered services
  * Address (scheme, host, path base, path, query string)
  * Connection (remote IP, remote port, local IP, local port, client certificate)
  * Request headers
  * Environment variables

To run the sample:

**Activation from a NuGet package**

1. Compile the *HostingStartupPackage* package with the [dotnet pack](/dotnet/core/tools/dotnet-pack) command.
1. Add the package's assembly name of the *HostingStartupPackage* to the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` environment variable.
1. Compile and run the app. A package reference is present in the enhanced app (a compile-time reference). A `<PropertyGroup>` in the app's project file specifies the package project's output (*../HostingStartupPackage/bin/Debug*) as a package source. This allows the app to use the package without uploading the package to [nuget.org](https://www.nuget.org/). For more information, see the notes in the HostingStartupApp's project file.

   ```xml
   <PropertyGroup>
     <RestoreSources>$(RestoreSources);https://api.nuget.org/v3/index.json;../HostingStartupPackage/bin/Debug</RestoreSources>
   </PropertyGroup>
   ```

1. Observe that the service configuration key values rendered by the Index page match the values set by the package's `ServiceKeyInjection.Configure` method.

If you make changes to the *HostingStartupPackage* project and recompile it, clear the local NuGet package caches to ensure that the *HostingStartupApp* receives the updated package and not a stale package from the local cache. To clear the local NuGet caches, execute the following [dotnet nuget locals](/dotnet/core/tools/dotnet-nuget-locals) command:

```dotnetcli
dotnet nuget locals all --clear
```

**Activation from a class library**

1. Compile the *HostingStartupLibrary* class library with the [dotnet build](/dotnet/core/tools/dotnet-build) command.
1. Add the class library's assembly name of *HostingStartupLibrary* to the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` environment variable.
1. *bin*-deploy the class library's assembly to the app by copying the *HostingStartupLibrary.dll* file from the class library's compiled output to the app's *bin/Debug* folder.
1. Compile and run the app. An `<ItemGroup>` in the app's project file references the class library's assembly (*.\bin\Debug\netcoreapp3.0\HostingStartupLibrary.dll*) (a compile-time reference). For more information, see the notes in the HostingStartupApp's project file.

   ```xml
   <ItemGroup>
     <Reference Include=".\\bin\\Debug\\netcoreapp3.0\\HostingStartupLibrary.dll">
       <HintPath>.\bin\Debug\netcoreapp3.0\HostingStartupLibrary.dll</HintPath>
       <SpecificVersion>False</SpecificVersion> 
     </Reference>
   </ItemGroup>
   ```

1. Observe that the service configuration key values rendered by the Index page match the values set by the class library's `ServiceKeyInjection.Configure` method.

**Activation from a runtime store-deployed assembly**

1. The *StartupDiagnostics* project uses [PowerShell](/powershell/scripting/overview) to modify its `StartupDiagnostics.deps.json` file. PowerShell is installed by default on Windows starting with Windows 7 SP1 and Windows Server 2008 R2 SP1. To obtain PowerShell on other platforms, see [Installing various versions of PowerShell](/powershell/scripting/install/installing-powershell).
1. Execute the *build.ps1* script in the *RuntimeStore* folder. The script:
   * Generates the `StartupDiagnostics` package in the *obj\packages* folder.
   * Generates the runtime store for `StartupDiagnostics` in the *store* folder. The `dotnet store` command in the script uses the `win7-x64` [runtime identifier (RID)](/dotnet/core/rid-catalog) for a hosting startup deployed to Windows. When providing the hosting startup for a different runtime, substitute the correct RID on line 37 of the script. The runtime store for `StartupDiagnostics` would later be moved to the user's or system's runtime store on the machine where the assembly will be consumed. The user runtime store install location for the `StartupDiagnostics` assembly is *.dotnet/store/x64/netcoreapp3.0/startupdiagnostics/1.0.0/lib/netcoreapp3.0/StartupDiagnostics.dll*.
   * Generates the `additionalDeps` for `StartupDiagnostics` in the *additionalDeps* folder. The additional dependencies would later be moved to the user's or system's additional dependencies. The user `StartupDiagnostics` additional dependencies install location is `.dotnet/x64/additionalDeps/StartupDiagnostics/shared/Microsoft.NETCore.App/3.0.0/StartupDiagnostics.deps.json`.
   * Places the *deploy.ps1* file in the *deployment* folder.
1. Run the *deploy.ps1* script in the *deployment* folder. The script appends:
   * `StartupDiagnostics` to the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` environment variable.
   * The hosting startup dependencies path (in the RuntimeStore project's *deployment* folder) to the `DOTNET_ADDITIONAL_DEPS` environment variable.
   * The runtime store path (in the RuntimeStore project's *deployment* folder) to the `DOTNET_SHARED_STORE` environment variable.
1. Run the sample app.
1. Request the `/services` endpoint to see the app's registered services. Request the `/diag` endpoint to see the diagnostic information.

:::moniker-end

:::moniker range="< aspnetcore-3.0"

An <xref:Microsoft.AspNetCore.Hosting.IHostingStartup> (hosting startup) implementation adds enhancements to an app at startup from an external assembly. For example, an external library can use a hosting startup implementation to provide additional configuration providers or services to an app.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/host/platform-specific-configuration/samples/) ([how to download](xref:index#how-to-download-a-sample))

## HostingStartup attribute

A [HostingStartup](xref:Microsoft.AspNetCore.Hosting.HostingStartupAttribute) attribute indicates the presence of a hosting startup assembly to activate at runtime.

The entry assembly or the assembly containing the `Startup` class is automatically scanned for the `HostingStartup` attribute. The list of assemblies to search for `HostingStartup` attributes is loaded at runtime from configuration in the [WebHostDefaults.HostingStartupAssembliesKey](xref:Microsoft.AspNetCore.Hosting.WebHostDefaults.HostingStartupAssembliesKey). The list of assemblies to exclude from discovery is loaded from the [WebHostDefaults.HostingStartupExcludeAssembliesKey](xref:Microsoft.AspNetCore.Hosting.WebHostDefaults.HostingStartupExcludeAssembliesKey). For more information, see [Web Host: Hosting Startup Assemblies](xref:fundamentals/host/web-host#hosting-startup-assemblies) and [Web Host: Hosting Startup Exclude Assemblies](xref:fundamentals/host/web-host#hosting-startup-exclude-assemblies).

In the following example, the namespace of the hosting startup assembly is `StartupEnhancement`. The class containing the hosting startup code is `StartupEnhancementHostingStartup`:

[!code-csharp[](platform-specific-configuration/samples-snapshot/2.x/StartupEnhancement.cs?name=snippet1)]

The `HostingStartup` attribute is typically located in the hosting startup assembly's `IHostingStartup` implementation class file.

## Discover loaded hosting startup assemblies

To discover loaded hosting startup assemblies, enable logging and check the app's logs. Errors that occur when loading assemblies are logged. Loaded hosting startup assemblies are logged at the Debug level, and all errors are logged.

## Disable automatic loading of hosting startup assemblies

To disable automatic loading of hosting startup assemblies, use one of the following approaches:

* To prevent all hosting startup assemblies from loading, set one of the following to `true` or `1`:
  * [Prevent Hosting Startup](xref:fundamentals/host/web-host#prevent-hosting-startup) host configuration setting.
  * `ASPNETCORE_PREVENTHOSTINGSTARTUP` environment variable.
* To prevent specific hosting startup assemblies from loading, set one of the following to a semicolon-delimited string of hosting startup assemblies to exclude at startup:
  * [Hosting Startup Exclude Assemblies](xref:fundamentals/host/web-host#hosting-startup-exclude-assemblies) host configuration setting.
  * `ASPNETCORE_HOSTINGSTARTUPEXCLUDEASSEMBLIES` environment variable.

If both the host configuration setting and the environment variable are set, the host setting controls the behavior.

Disabling hosting startup assemblies using the host setting or environment variable disables the assembly globally and may disable several characteristics of an app.

## Project

Create a hosting startup with either of the following project types:

* [Class library](#class-library)
* [Console app without an entry point](#console-app-without-an-entry-point)

### Class library

A hosting startup enhancement can be provided in a class library. The library contains a `HostingStartup` attribute.

The [sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/host/platform-specific-configuration/samples/) includes a Razor Pages app, *HostingStartupApp*, and a class library, *HostingStartupLibrary*. The class library:

* Contains a hosting startup class, `ServiceKeyInjection`, which implements `IHostingStartup`. `ServiceKeyInjection` adds a pair of service strings to the app's configuration using the in-memory configuration provider ([AddInMemoryCollection](xref:Microsoft.Extensions.Configuration.MemoryConfigurationBuilderExtensions.AddInMemoryCollection*)).
* Includes a `HostingStartup` attribute that identifies the hosting startup's namespace and class.

The `ServiceKeyInjection` class's <xref:Microsoft.AspNetCore.Hosting.IHostingStartup.Configure*> method uses an <xref:Microsoft.AspNetCore.Hosting.IWebHostBuilder> to add enhancements to an app.

`HostingStartupLibrary/ServiceKeyInjection.cs`:

[!code-csharp[](platform-specific-configuration/samples/2.x/HostingStartupLibrary/ServiceKeyInjection.cs?name=snippet1)]

The app's Index page reads and renders the configuration values for the two keys set by the class library's hosting startup assembly:

`HostingStartupApp/Pages/Index.cshtml.cs`:

[!code-csharp[](platform-specific-configuration/samples/2.x/HostingStartupApp/Pages/Index.cshtml.cs?name=snippet1&highlight=5-6,11-12)]

The [sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/host/platform-specific-configuration/samples/) also includes a NuGet package project that provides a separate hosting startup, *HostingStartupPackage*. The package has the same characteristics of the class library described earlier. The package:

* Contains a hosting startup class, `ServiceKeyInjection`, which implements `IHostingStartup`. `ServiceKeyInjection` adds a pair of service strings to the app's configuration.
* Includes a `HostingStartup` attribute.

`HostingStartupPackage/ServiceKeyInjection.cs`:

[!code-csharp[](platform-specific-configuration/samples/2.x/HostingStartupPackage/ServiceKeyInjection.cs?name=snippet1)]

The app's Index page reads and renders the configuration values for the two keys set by the package's hosting startup assembly:

`HostingStartupApp/Pages/Index.cshtml.cs`:

[!code-csharp[](platform-specific-configuration/samples/2.x/HostingStartupApp/Pages/Index.cshtml.cs?name=snippet1&highlight=7-8,13-14)]

### Console app without an entry point

*This approach is only available for .NET Core apps, not .NET Framework.*

A dynamic hosting startup enhancement that doesn't require a compile-time reference for activation can be provided in a console app without an entry point that contains a `HostingStartup` attribute. Publishing the console app produces a hosting startup assembly that can be consumed from the runtime store.

A console app without an entry point is used in this process because:

* A dependencies file is required to consume the hosting startup in the hosting startup assembly. A dependencies file is a runnable app asset that's produced by publishing an app, not a library.
* A library can't be added directly to the [runtime package store](/dotnet/core/deploying/runtime-store), which requires a runnable project that targets the shared runtime.

In the creation of a dynamic hosting startup:

* A hosting startup assembly is created from the console app without an entry point that:
  * Includes a class that contains the `IHostingStartup` implementation.
  * Includes a [HostingStartup](xref:Microsoft.AspNetCore.Hosting.HostingStartupAttribute) attribute to identify the `IHostingStartup` implementation class.
* The console app is published to obtain the hosting startup's dependencies. A consequence of publishing the console app is that unused dependencies are trimmed from the dependencies file.
* The dependencies file is modified to set the runtime location of the hosting startup assembly.
* The hosting startup assembly and its dependencies file is placed into the runtime package store. To discover the hosting startup assembly and its dependencies file, they're listed in a pair of environment variables.

The console app references the [Microsoft.AspNetCore.Hosting.Abstractions](https://www.nuget.org/packages/Microsoft.AspNetCore.Hosting.Abstractions/) package:

[!code-xml[](platform-specific-configuration/samples-snapshot/2.x/StartupEnhancement.csproj)]

A [HostingStartup](xref:Microsoft.AspNetCore.Hosting.HostingStartupAttribute) attribute identifies a class as an implementation of `IHostingStartup` for loading and execution when building the <xref:Microsoft.AspNetCore.Hosting.IWebHost>. In the following example, the namespace is `StartupEnhancement`, and the class is `StartupEnhancementHostingStartup`:

[!code-csharp[](platform-specific-configuration/samples-snapshot/2.x/StartupEnhancement.cs?name=snippet1)]

A class implements `IHostingStartup`. The class's <xref:Microsoft.AspNetCore.Hosting.IHostingStartup.Configure*> method uses an <xref:Microsoft.AspNetCore.Hosting.IWebHostBuilder> to add enhancements to an app. `IHostingStartup.Configure` in the hosting startup assembly is called by the runtime before `Startup.Configure` in user code, which allows user code to overwrite any configuration provided by the hosting startup assembly.

[!code-csharp[](platform-specific-configuration/samples-snapshot/2.x/StartupEnhancement.cs?name=snippet2&highlight=3,5)]

When building an `IHostingStartup` project, the dependencies file (`.deps.json`) sets the `runtime` location of the assembly to the *bin* folder:

[!code-json[](platform-specific-configuration/samples-snapshot/2.x/StartupEnhancement1.deps.json?range=2-13&highlight=8)]

Only part of the file is shown. The assembly name in the example is `StartupEnhancement`.

## Configuration provided by the hosting startup

There are two approaches to handling configuration depending on whether you want the hosting startup's configuration to take precedence or the app's configuration to take precedence:

1. Provide configuration to the app using <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder.ConfigureAppConfiguration*> to load the configuration after the app's <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder.ConfigureAppConfiguration*> delegates execute. Hosting startup configuration takes priority over the app's configuration using this approach.
1. Provide configuration to the app using <xref:Microsoft.AspNetCore.Hosting.HostingAbstractionsWebHostBuilderExtensions.UseConfiguration*> to load the configuration before the app's <xref:Microsoft.AspNetCore.Hosting.WebHostBuilder.ConfigureAppConfiguration*> delegates execute. The app's configuration values take priority over those provided by the hosting startup using this approach.

```csharp
public class ConfigurationInjection : IHostingStartup
{
    public void Configure(IWebHostBuilder builder)
    {
        Dictionary<string, string> dict;

        builder.ConfigureAppConfiguration(config =>
        {
            dict = new Dictionary<string, string>
            {
                {"ConfigurationKey1", 
                    "From IHostingStartup: Higher priority " +
                    "than the app's configuration."},
            };

            config.AddInMemoryCollection(dict);
        });

        dict = new Dictionary<string, string>
        {
            {"ConfigurationKey2", 
                "From IHostingStartup: Lower priority " +
                "than the app's configuration."},
        };

        var builtConfig = new ConfigurationBuilder()
            .AddInMemoryCollection(dict)
            .Build();

        builder.UseConfiguration(builtConfig);
    }
}
```

## Specify the hosting startup assembly

For either a class library- or console app-supplied hosting startup, specify the hosting startup assembly's name in the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` environment variable. The environment variable is a semicolon-delimited list of assemblies.

Only hosting startup assemblies are scanned for the `HostingStartup` attribute. For the sample app, *HostingStartupApp*, to discover the hosting startups described earlier, the environment variable is set to the following value:

```
HostingStartupLibrary;HostingStartupPackage;StartupDiagnostics
```

A hosting startup assembly can also be set using the [Hosting Startup Assemblies](xref:fundamentals/host/web-host#hosting-startup-assemblies) host configuration setting.

When multiple hosting startup assembles are present, their <xref:Microsoft.AspNetCore.Hosting.IHostingStartup.Configure*> methods are executed in the order that the assemblies are listed.

## Activation

Options for hosting startup activation are:

* [Runtime store](#runtime-store): Activation doesn't require a compile-time reference for activation. The sample app places the hosting startup assembly and dependencies files into a folder, *deployment*, to facilitate deployment of the hosting startup in a multimachine environment. The *deployment* folder also includes a PowerShell script that creates or modifies environment variables on the deployment system to enable the hosting startup.
* Compile-time reference required for activation
  * [NuGet package](#nuget-package)
  * [Project bin folder](#project-bin-folder)

### Runtime store

The hosting startup implementation is placed in the [runtime store](/dotnet/core/deploying/runtime-store). A compile-time reference to the assembly isn't required by the enhanced app.

After the hosting startup is built, a runtime store is generated using the manifest project file and the [dotnet store](/dotnet/core/tools/dotnet-store) command.

```dotnetcli
dotnet store --manifest {MANIFEST FILE} --runtime {RUNTIME IDENTIFIER} --output {OUTPUT LOCATION} --skip-optimization
```

In the sample app (*RuntimeStore* project) the following command is used:

```dotnetcli
dotnet store --manifest store.manifest.csproj --runtime win7-x64 --output ./deployment/store --skip-optimization
```

For the runtime to discover the runtime store, the runtime store's location is added to the `DOTNET_SHARED_STORE` environment variable.

**Modify and place the hosting startup's dependencies file**

To activate the enhancement without a package reference to the enhancement, specify additional dependencies to the runtime with `additionalDeps`. `additionalDeps` allows you to:

* Extend the app's library graph by providing a set of additional `.deps.json` files to merge with the app's own `.deps.json` file on startup.
* Make the hosting startup assembly discoverable and loadable.

The recommended approach for generating the additional dependencies file is to:

 1. Execute `dotnet publish` on the runtime store manifest file referenced in the previous section.
 1. Remove the manifest reference from libraries and the `runtime` section of the resulting `.deps.json` file.

In the example project, the `store.manifest/1.0.0` property is removed from the `targets` and `libraries` section:

```json
{
  "runtimeTarget": {
    "name": ".NETCoreApp,Version=v2.1",
    "signature": "4ea77c7b75ad1895ae1ea65e6ba2399010514f99"
  },
  "compilationOptions": {},
  "targets": {
    ".NETCoreApp,Version=v2.1": {
      "store.manifest/1.0.0": {
        "dependencies": {
          "StartupDiagnostics": "1.0.0"
        },
        "runtime": {
          "store.manifest.dll": {}
        }
      },
      "StartupDiagnostics/1.0.0": {
        "runtime": {
          "lib/netcoreapp2.1/StartupDiagnostics.dll": {
            "assemblyVersion": "1.0.0.0",
            "fileVersion": "1.0.0.0"
          }
        }
      }
    }
  },
  "libraries": {
    "store.manifest/1.0.0": {
      "type": "project",
      "serviceable": false,
      "sha512": ""
    },
    "StartupDiagnostics/1.0.0": {
      "type": "package",
      "serviceable": true,
      "sha512": "sha512-oiQr60vBQW7+nBTmgKLSldj06WNLRTdhOZpAdEbCuapoZ+M2DJH2uQbRLvFT8EGAAv4TAKzNtcztpx5YOgBXQQ==",
      "path": "startupdiagnostics/1.0.0",
      "hashPath": "startupdiagnostics.1.0.0.nupkg.sha512"
    }
  }
}
```

Place the `.deps.json` file into the following location:

```
{ADDITIONAL DEPENDENCIES PATH}/shared/{SHARED FRAMEWORK NAME}/{SHARED FRAMEWORK VERSION}/{ENHANCEMENT ASSEMBLY NAME}.deps.json
```

* `{ADDITIONAL DEPENDENCIES PATH}`: Location added to the `DOTNET_ADDITIONAL_DEPS` environment variable.
* `{SHARED FRAMEWORK NAME}`: Shared framework required for this additional dependencies file.
* `{SHARED FRAMEWORK VERSION}`: Minimum shared framework version.
* `{ENHANCEMENT ASSEMBLY NAME}`: The enhancement's assembly name.

In the sample app (*RuntimeStore* project), the additional dependencies file is placed into the following location:

```
deployment/additionalDeps/shared/Microsoft.AspNetCore.App/2.1.0/StartupDiagnostics.deps.json
```

For runtime to discover the runtime store location, the additional dependencies file location is added to the `DOTNET_ADDITIONAL_DEPS` environment variable.

In the sample app (*RuntimeStore* project), building the runtime store and generating the additional dependencies file is accomplished using a [PowerShell](/powershell/scripting/overview) script.

For examples of how to set environment variables for various operating systems, see [Use multiple environments](xref:fundamentals/environments).

**Deployment**

To facilitate the deployment of a hosting startup in a multimachine environment, the sample app creates a *deployment* folder in published output that contains:

* The hosting startup runtime store.
* The hosting startup dependencies file.
* A PowerShell script that creates or modifies the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES`, `DOTNET_SHARED_STORE`, and `DOTNET_ADDITIONAL_DEPS` to support the activation of the hosting startup. Run the script from an administrative PowerShell command prompt on the deployment system.

### NuGet package

A hosting startup enhancement can be provided in a NuGet package. The package has a `HostingStartup` attribute. The hosting startup types provided by the package are made available to the app using either of the following approaches:

* The enhanced app's project file makes a package reference for the hosting startup in the app's project file (a compile-time reference). With the compile-time reference in place, the hosting startup assembly and all of its dependencies are incorporated into the app's dependency file (`.deps.json`). This approach applies to a hosting startup assembly package published to [nuget.org](https://www.nuget.org/).
* The hosting startup's dependencies file is made available to the enhanced app as described in the [Runtime store](#runtime-store) section (without a compile-time reference).

For more information on NuGet packages and the runtime store, see the following topics:

* [How to Create a NuGet Package with Cross Platform Tools](/dotnet/core/deploying/creating-nuget-packages)
* [Publishing packages](/nuget/create-packages/publish-a-package)
* [Runtime package store](/dotnet/core/deploying/runtime-store)

### Project bin folder

A hosting startup enhancement can be provided by a *bin*-deployed assembly in the enhanced app. The hosting startup types provided by the assembly are made available to the app using one of the following approaches:

* The enhanced app's project file makes an assembly reference to the hosting startup (a compile-time reference). With the compile-time reference in place, the hosting startup assembly and all of its dependencies are incorporated into the app's dependency file (`.deps.json`). This approach applies when the deployment scenario calls for making a compile-time reference to the hosting startup's assembly (*.dll* file) and moving the assembly to either:
  * The consuming project.
  * A location accessible by the consuming project.
* The hosting startup's dependencies file is made available to the enhanced app as described in the [Runtime store](#runtime-store) section (without a compile-time reference).
* When targeting the .NET Framework, the assembly is loadable in the default load context, which on .NET Framework means that the assembly is located at either of the following locations:
  * Application base path: The *bin* folder where the app's executable (*.exe*) is located.
  * Global Assembly Cache (GAC): The GAC stores assemblies that several .NET Framework apps share. For more information, see [How to: Install an assembly into the global assembly cache](/dotnet/framework/app-domains/how-to-install-an-assembly-into-the-gac) in the .NET Framework documentation.

## Sample code

The [sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/host/platform-specific-configuration/samples/) ([how to download](xref:index#how-to-download-a-sample)) demonstrates hosting startup implementation scenarios:

* Two hosting startup assemblies (class libraries) set a pair of in-memory configuration key-value pairs each:
  * NuGet package (*HostingStartupPackage*)
  * Class library (*HostingStartupLibrary*)
* A hosting startup is activated from a runtime store-deployed assembly (*StartupDiagnostics*). The assembly adds two middlewares to the app at startup that provide diagnostic information on:
  * Registered services
  * Address (scheme, host, path base, path, query string)
  * Connection (remote IP, remote port, local IP, local port, client certificate)
  * Request headers
  * Environment variables

To run the sample:

**Activation from a NuGet package**

1. Compile the *HostingStartupPackage* package with the [dotnet pack](/dotnet/core/tools/dotnet-pack) command.
1. Add the package's assembly name of the *HostingStartupPackage* to the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` environment variable.
1. Compile and run the app. A package reference is present in the enhanced app (a compile-time reference). A `<PropertyGroup>` in the app's project file specifies the package project's output (*../HostingStartupPackage/bin/Debug*) as a package source. This allows the app to use the package without uploading the package to [nuget.org](https://www.nuget.org/). For more information, see the notes in the HostingStartupApp's project file.

   ```xml
   <PropertyGroup>
     <RestoreSources>$(RestoreSources);https://api.nuget.org/v3/index.json;../HostingStartupPackage/bin/Debug</RestoreSources>
   </PropertyGroup>
   ```

1. Observe that the service configuration key values rendered by the Index page match the values set by the package's `ServiceKeyInjection.Configure` method.

If you make changes to the *HostingStartupPackage* project and recompile it, clear the local NuGet package caches to ensure that the *HostingStartupApp* receives the updated package and not a stale package from the local cache. To clear the local NuGet caches, execute the following [dotnet nuget locals](/dotnet/core/tools/dotnet-nuget-locals) command:

```dotnetcli
dotnet nuget locals all --clear
```

**Activation from a class library**

1. Compile the *HostingStartupLibrary* class library with the [dotnet build](/dotnet/core/tools/dotnet-build) command.
1. Add the class library's assembly name of *HostingStartupLibrary* to the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` environment variable.
1. *bin*-deploy the class library's assembly to the app by copying the *HostingStartupLibrary.dll* file from the class library's compiled output to the app's *bin/Debug* folder.
1. Compile and run the app. An `<ItemGroup>` in the app's project file references the class library's assembly (*.\bin\Debug\netcoreapp2.1\HostingStartupLibrary.dll*) (a compile-time reference). For more information, see the notes in the HostingStartupApp's project file.

   ```xml
   <ItemGroup>
     <Reference Include=".\\bin\\Debug\\netcoreapp2.1\\HostingStartupLibrary.dll">
       <HintPath>.\bin\Debug\netcoreapp2.1\HostingStartupLibrary.dll</HintPath>
       <SpecificVersion>False</SpecificVersion>
     </Reference>
   </ItemGroup>
   ```

1. Observe that the service configuration key values rendered by the Index page match the values set by the class library's `ServiceKeyInjection.Configure` method.

**Activation from a runtime store-deployed assembly**

1. The *StartupDiagnostics* project uses [PowerShell](/powershell/scripting/overview) to modify its `StartupDiagnostics.deps.json` file. PowerShell is installed by default on Windows starting with Windows 7 SP1 and Windows Server 2008 R2 SP1. To obtain PowerShell on other platforms, see [Installing various versions of PowerShell](/powershell/scripting/install/installing-powershell).
1. Execute the *build.ps1* script in the *RuntimeStore* folder. The script:
   * Generates the `StartupDiagnostics` package in the *obj\packages* folder.
   * Generates the runtime store for `StartupDiagnostics` in the *store* folder. The `dotnet store` command in the script uses the `win7-x64` [runtime identifier (RID)](/dotnet/core/rid-catalog) for a hosting startup deployed to Windows. When providing the hosting startup for a different runtime, substitute the correct RID on line 37 of the script. The runtime store for `StartupDiagnostics` would later be moved to the user's or system's runtime store on the machine where the assembly will be consumed. The user runtime store install location for the `StartupDiagnostics` assembly is *.dotnet/store/x64/netcoreapp2.2/startupdiagnostics/1.0.0/lib/netcoreapp2.2/StartupDiagnostics.dll*.
   * Generates the `additionalDeps` for `StartupDiagnostics` in the *additionalDeps* folder. The additional dependencies would later be moved to the user's or system's additional dependencies. The user `StartupDiagnostics` additional dependencies install location is `.dotnet/x64/additionalDeps/StartupDiagnostics/shared/Microsoft.NETCore.App/2.2.0/StartupDiagnostics.deps.json`.
   * Places the *deploy.ps1* file in the *deployment* folder.
1. Run the *deploy.ps1* script in the *deployment* folder. The script appends:
   * `StartupDiagnostics` to the `ASPNETCORE_HOSTINGSTARTUPASSEMBLIES` environment variable.
   * The hosting startup dependencies path (in the RuntimeStore project's *deployment* folder) to the `DOTNET_ADDITIONAL_DEPS` environment variable.
   * The runtime store path (in the RuntimeStore project's *deployment* folder) to the `DOTNET_SHARED_STORE` environment variable.
1. Run the sample app.
1. Request the `/services` endpoint to see the app's registered services. Request the `/diag` endpoint to see the diagnostic information.

:::moniker-end
