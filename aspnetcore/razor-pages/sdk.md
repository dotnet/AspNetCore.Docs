---
title: ASP.NET Core Razor SDK
author: Rick-Anderson
description: Learn how Razor Pages in ASP.NET Core makes coding page-focused scenarios easier and more productive than using MVC.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.custom: "mvc, seodec18"
ms.date: 03/26/2020
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: razor-pages/sdk
---
# ASP.NET Core Razor SDK

By [Rick Anderson](https://twitter.com/RickAndMSFT)

## Overview

:::moniker range=">= aspnetcore-6.0"

The [!INCLUDE[](~/includes/6.0-SDK.md)] includes the `Microsoft.NET.Sdk.Razor` MSBuild SDK (Razor SDK). The Razor SDK:

* Is required to build, package, and publish projects containing [Razor](xref:mvc/views/razor) files for ASP.NET Core MVC-based or [Blazor](xref:blazor/index) projects.
* Includes a set of predefined properties, and items that allow customizing the compilation of Razor (`.cshtml` or `.razor`) files.

The Razor SDK includes `Content` items with `Include` attributes set to the `**\*.cshtml` and `**\*.razor` globbing patterns. Matching files are published.

## Prerequisites

[!INCLUDE[](~/includes/6.0-SDK.md)]

## Use the Razor SDK

Most web apps aren't required to explicitly reference the Razor SDK.

To use the Razor SDK to build class libraries containing Razor views or Razor Pages, we recommend starting with the Razor class library (RCL) project template. An RCL that's used to build Blazor (`.razor`) files minimally requires a reference to the [Microsoft.AspNetCore.Components](https://www.nuget.org/packages/Microsoft.AspNetCore.Components) package. An RCL that's used to build Razor views or pages (`.cshtml` files) minimally requires targeting `netcoreapp3.0` or later and has a `FrameworkReference` to the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app) in its project file.

### Properties

The following properties control the Razor's SDK behavior as part of a project build:

* `RazorCompileOnBuild`: When `true`, compiles and emits the Razor assembly as part of building the project. Defaults to `true`.
* `RazorCompileOnPublish`: When `true`, compiles and emits the Razor assembly as part of publishing the project. Defaults to `true`.

The properties and items in the following table are used to configure inputs and output to the Razor SDK.

| Items | Description |
| ----- | ----------- |
| `RazorGenerate` | Item elements (`.cshtml` files) that are inputs to code generation. |
| `RazorComponent` | Item elements (`.razor` files) that are inputs to Razor component code generation. |
| `RazorCompile` | Item elements (`.cs` files) that are inputs to Razor compilation targets. Use this `ItemGroup` to specify additional files to be compiled into the Razor assembly. |
| `RazorEmbeddedResource` | Item elements added as embedded resources to the generated Razor assembly. |

<!-- In the following table, should the entry for 'GenerateRazorTargetAssemblyInfo' be deleted? -->

| Property | Description |
| -------- | ----------- |
| `RazorOutputPath` | The Razor output directory. |
| `RazorCompileToolset` | Used to determine the toolset used to build the Razor assembly. Valid values are `Implicit`, `RazorSDK`, and `PrecompilationTool`. |
| [EnableDefaultContentItems](https://github.com/aspnet/websdk/blob/rel-2.0.0/src/ProjectSystem/Microsoft.NET.Sdk.Web.ProjectSystem.Targets/netstandard1.0/Microsoft.NET.Sdk.Web.ProjectSystem.targets#L21) | Default is `true`. When `true`, includes *web.config*, `.json`, and `.cshtml` files as content in the project. When referenced via `Microsoft.NET.Sdk.Web`, files under *wwwroot* and config files are also included. |
| `EnableDefaultRazorGenerateItems` | When `true`, includes `.cshtml` files from `Content` items in `RazorGenerate` items. |
| `GenerateRazorTargetAssemblyInfo` | Not used in .NET 6 and later. |
| `EnableDefaultRazorTargetAssemblyInfoAttributes` | Not used in .NET 6 and later. |
| `CopyRazorGenerateFilesToPublishDirectory` | When `true`, copies `RazorGenerate` items (`.cshtml`) files to the publish directory. Typically, Razor files aren't required for a published app if they participate in compilation at build-time or publish-time. Defaults to `false`. |
| `PreserveCompilationReferences` | When `true`, copy reference assembly items to the publish directory. Typically, reference assemblies aren't required for a published app if Razor compilation occurs at build-time or publish-time. Set to `true` if your published app requires runtime compilation. For example, set the value to `true` if the app modifies `.cshtml` files at runtime or uses embedded views. Defaults to `false`. |
| `IncludeRazorContentInPack` | When `true`, all Razor content items (`.cshtml` files) are marked for inclusion in the generated NuGet package. Defaults to `false`. |
| `EmbedRazorGenerateSources` | When `true`, adds RazorGenerate (`.cshtml`) items as embedded files to the generated Razor assembly. Defaults to `false`. |
| `GenerateMvcApplicationPartsAssemblyAttributes` | Not used in .NET 6 and later. |
| `DefaultWebContentItemExcludes` | A globbing pattern for item elements that are to be excluded from the `Content` item group in projects targeting the Web or Razor SDK |
| `ExcludeConfigFilesFromBuildOutput` | When `true`, *.config* and `.json` files do not get copied to the build output directory. |
| `AddRazorSupportForMvc` | When `true`, configures the Razor SDK to add support for the MVC configuration that is required when building applications containing MVC views or Razor Pages. This property is implicitly set for .NET Core 3.0 or later projects targeting the Web SDK |
| `RazorLangVersion` | The version of the Razor Language to target. |
| `EmitCompilerGeneratedFiles` | When set to `true`, the generated source files are written to disk. Setting to `true` is useful when debugging the compiler. The default is `false`. |

For more information on properties, see [MSBuild properties](/visualstudio/msbuild/msbuild-properties).

### Runtime compilation of Razor views

* By default, the Razor SDK doesn't publish reference assemblies that are required to perform runtime compilation. This results in compilation failures when the application model relies on runtime compilation&mdash;for example, the app uses embedded views or changes views after the app is published. Set `CopyRefAssembliesToPublishDirectory` to `true` to continue publishing reference assemblies. Both code generation and compilation are supported by a single call to the compiler. A single assembly is produced that contains the app types and the generated views.

* For a web app, ensure your app is targeting the `Microsoft.NET.Sdk.Web` SDK.

## Razor language version

When targeting the `Microsoft.NET.Sdk.Web` SDK, the Razor language version is inferred from the app's target framework version. For projects targeting the `Microsoft.NET.Sdk.Razor` SDK or in the rare case that the app requires a different Razor language version than the inferred value, a version can be configured by setting the `<RazorLangVersion>` property in the app's project file:

```xml
<PropertyGroup>
  <RazorLangVersion>{VERSION}</RazorLangVersion>
</PropertyGroup>
```

Razor's language version is tightly integrated with the version of the runtime that it was built for. Targeting a language version that isn't designed for the runtime is unsupported and likely produces build errors.

## Additional resources

* [Additions to the csproj format for .NET Core](/dotnet/core/tools/csproj)
* [Common MSBuild project items](/visualstudio/msbuild/common-msbuild-project-items)

:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-6.0"

The [!INCLUDE[](~/includes/2.1-SDK.md)] includes the `Microsoft.NET.Sdk.Razor` MSBuild SDK (Razor SDK). The Razor SDK:

* Is required to build, package, and publish projects containing [Razor](xref:mvc/views/razor) files for ASP.NET Core MVC-based or [Blazor](xref:blazor/index) projects.
* Includes a set of predefined targets, properties, and items that allow customizing the compilation of Razor (`.cshtml` or `.razor`) files.

The Razor SDK includes `Content` items with `Include` attributes set to the `**\*.cshtml` and `**\*.razor` globbing patterns. Matching files are published.

## Prerequisites

[!INCLUDE[](~/includes/2.1-SDK.md)]

## Use the Razor SDK

Most web apps aren't required to explicitly reference the Razor SDK.

To use the Razor SDK to build class libraries containing Razor views or Razor Pages, we recommend starting with the Razor class library (RCL) project template. An RCL that's used to build Blazor (`.razor`) files minimally requires a reference to the [Microsoft.AspNetCore.Components](https://www.nuget.org/packages/Microsoft.AspNetCore.Components) package. An RCL that's used to build Razor views or pages (`.cshtml` files) minimally requires targeting `netcoreapp3.0` or later and has a `FrameworkReference` to the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app) in its project file.

### Properties

The following properties control the Razor's SDK behavior as part of a project build:

* `RazorCompileOnBuild`: When `true`, compiles and emits the Razor assembly as part of building the project. Defaults to `true`.
* `RazorCompileOnPublish`: When `true`, compiles and emits the Razor assembly as part of publishing the project. Defaults to `true`.

The properties and items in the following table are used to configure inputs and output to the Razor SDK.

> [!WARNING]
> Starting with ASP.NET Core 3.0, MVC Views or Razor Pages aren't served by default if the `RazorCompileOnBuild` or `RazorCompileOnPublish` MSBuild properties in the project file are disabled. Applications must add an explicit reference to the [Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation) package if the app relies on runtime compilation to process `.cshtml` files.

| Items | Description |
| ----- | ----------- |
| `RazorGenerate` | Item elements (`.cshtml` files) that are inputs to code generation. |
| `RazorComponent` | Item elements (`.razor` files) that are inputs to Razor component code generation. |
| `RazorCompile` | Item elements (`.cs` files) that are inputs to Razor compilation targets. Use this `ItemGroup` to specify additional files to be compiled into the Razor assembly. |
| `RazorTargetAssemblyAttribute` | Item elements used to code generate attributes for the Razor assembly. For example:  <br>`RazorAssemblyAttribute`<br>`Include="System.Reflection.AssemblyMetadataAttribute"`<br>`_Parameter1="BuildSource" _Parameter2="https://docs.microsoft.com/">` |
| `RazorEmbeddedResource` | Item elements added as embedded resources to the generated Razor assembly. |

| Property | Description |
| -------- | ----------- |
| `RazorTargetName` | File name (without extension) of the assembly produced by Razor. |
| `RazorOutputPath` | The Razor output directory. |
| `RazorCompileToolset` | Used to determine the toolset used to build the Razor assembly. Valid values are `Implicit`, `RazorSDK`, and `PrecompilationTool`. |
| [EnableDefaultContentItems](https://github.com/aspnet/websdk/blob/rel-2.0.0/src/ProjectSystem/Microsoft.NET.Sdk.Web.ProjectSystem.Targets/netstandard1.0/Microsoft.NET.Sdk.Web.ProjectSystem.targets#L21) | Default is `true`. When `true`, includes *web.config*, `.json`, and `.cshtml` files as content in the project. When referenced via `Microsoft.NET.Sdk.Web`, files under *wwwroot* and config files are also included. |
| `EnableDefaultRazorGenerateItems` | When `true`, includes `.cshtml` files from `Content` items in `RazorGenerate` items. |
| `GenerateRazorTargetAssemblyInfo` | When `true`, generates a `.cs` file containing attributes specified by `RazorAssemblyAttribute` and includes the file in the compile output. |
| `EnableDefaultRazorTargetAssemblyInfoAttributes` | When `true`, adds a default set of assembly attributes to `RazorAssemblyAttribute`. |
| `CopyRazorGenerateFilesToPublishDirectory` | When `true`, copies `RazorGenerate` items (`.cshtml`) files to the publish directory. Typically, Razor files aren't required for a published app if they participate in compilation at build-time or publish-time. Defaults to `false`. |
| `PreserveCompilationReferences` | When `true`, copy reference assembly items to the publish directory. Typically, reference assemblies aren't required for a published app if Razor compilation occurs at build-time or publish-time. Set to `true` if your published app requires runtime compilation. For example, set the value to `true` if the app modifies `.cshtml` files at runtime or uses embedded views. Defaults to `false`. |
| `IncludeRazorContentInPack` | When `true`, all Razor content items (`.cshtml` files) are marked for inclusion in the generated NuGet package. Defaults to `false`. |
| `EmbedRazorGenerateSources` | When `true`, adds RazorGenerate (`.cshtml`) items as embedded files to the generated Razor assembly. Defaults to `false`. |
| `UseRazorBuildServer` | When `true`, uses a persistent build server process to offload code generation work. Defaults to the value of `UseSharedCompilation`. |
| `GenerateMvcApplicationPartsAssemblyAttributes` | When `true`, the SDK generates additional attributes used by MVC at runtime to perform application part discovery. |
| `DefaultWebContentItemExcludes` | A globbing pattern for item elements that are to be excluded from the `Content` item group in projects targeting the Web or Razor SDK |
| `ExcludeConfigFilesFromBuildOutput` | When `true`, *.config* and `.json` files do not get copied to the build output directory. |
| `AddRazorSupportForMvc` | When `true`, configures the Razor SDK to add support for the MVC configuration that is required when building applications containing MVC views or Razor Pages. This property is implicitly set for .NET Core 3.0 or later projects targeting the Web SDK |
| `RazorLangVersion` | The version of the Razor Language to target. |

For more information on properties, see [MSBuild properties](/visualstudio/msbuild/msbuild-properties).

### Targets

The Razor SDK defines two primary targets:

* `RazorGenerate`: Code generates `.cs` files from `RazorGenerate` item elements. Use the `RazorGenerateDependsOn` property to specify additional targets that can run before or after this target.
* `RazorCompile`: Compiles generated `.cs` files in to a Razor assembly. Use the `RazorCompileDependsOn` to specify additional targets that can run before or after this target.
* `RazorComponentGenerate`: Code generates `.cs` files for `RazorComponent` item elements. Use the `RazorComponentGenerateDependsOn` property to specify additional targets that can run before or after this target.

### Runtime compilation of Razor views

* By default, the Razor SDK doesn't publish reference assemblies that are required to perform runtime compilation. This results in compilation failures when the application model relies on runtime compilation&mdash;for example, the app uses embedded views or changes views after the app is published. Set `CopyRefAssembliesToPublishDirectory` to `true` to continue publishing reference assemblies.

* For a web app, ensure your app is targeting the `Microsoft.NET.Sdk.Web` SDK.

## Razor language version

When targeting the `Microsoft.NET.Sdk.Web` SDK, the Razor language version is inferred from the app's target framework version. For projects targeting the `Microsoft.NET.Sdk.Razor` SDK or in the rare case that the app requires a different Razor language version than the inferred value, a version can be configured by setting the `<RazorLangVersion>` property in the app's project file:

```xml
<PropertyGroup>
  <RazorLangVersion>{VERSION}</RazorLangVersion>
</PropertyGroup>
```

Razor's language version is tightly integrated with the version of the runtime that it was built for. Targeting a language version that isn't designed for the runtime is unsupported and likely produces build errors.

## Additional resources

* [Additions to the csproj format for .NET Core](/dotnet/core/tools/csproj)
* [Common MSBuild project items](/visualstudio/msbuild/common-msbuild-project-items)

:::moniker-end

:::moniker range="< aspnetcore-3.0"



* Standardizes the experience around building, packaging, and publishing projects containing [Razor](xref:mvc/views/razor) files for ASP.NET Core MVC-based projects.
* Includes a set of predefined targets, properties, and items that allow customizing the compilation of Razor files.

The Razor SDK includes a `Content` item with an `Include` attribute set to the `**\*.cshtml` globbing pattern. Matching files are published.


## Prerequisites

[!INCLUDE[](~/includes/2.1-SDK.md)]

## Use the Razor SDK

Most web apps aren't required to explicitly reference the Razor SDK.


To use the Razor SDK to build class libraries containing Razor views or Razor Pages:

* Use `Microsoft.NET.Sdk.Razor` instead of `Microsoft.NET.Sdk`:

  ```xml
  <Project SDK="Microsoft.NET.Sdk.Razor">
    <!-- omitted for brevity -->
  </Project>
  ```

* Typically, a package reference to `Microsoft.AspNetCore.Mvc` is required to receive additional dependencies that are required to build and compile Razor Pages and Razor views. At a minimum, your project should add package references to:

  * `Microsoft.AspNetCore.Razor.Design`
  * `Microsoft.AspNetCore.Mvc.Razor.Extensions`
  * `Microsoft.AspNetCore.Mvc.Razor`

  The `Microsoft.AspNetCore.Razor.Design` package provides the Razor compilation tasks and targets for the project.

  The preceding packages are included in `Microsoft.AspNetCore.Mvc`. The following markup shows a project file that uses the Razor SDK to build Razor files for an ASP.NET Core Razor Pages app:

  [!code-xml[](sdk/sample/RazorSDK.csproj)]

> [!WARNING]
> The `Microsoft.AspNetCore.Razor.Design` and `Microsoft.AspNetCore.Mvc.Razor.Extensions` packages are included in the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app). However, the version-less `Microsoft.AspNetCore.App` package reference provides a metapackage to the app that doesn't include the latest version of `Microsoft.AspNetCore.Razor.Design`. Projects must reference a consistent version of `Microsoft.AspNetCore.Razor.Design` (or `Microsoft.AspNetCore.Mvc`) so that the latest build-time fixes for Razor are included. For more information, see [this GitHub issue](https://github.com/aspnet/Razor/issues/2553).

### Properties

The following properties control the Razor's SDK behavior as part of a project build:

* `RazorCompileOnBuild`: When `true`, compiles and emits the Razor assembly as part of building the project. Defaults to `true`.
* `RazorCompileOnPublish`: When `true`, compiles and emits the Razor assembly as part of publishing the project. Defaults to `true`.

The properties and items in the following table are used to configure inputs and output to the Razor SDK.

| Items | Description |
| ----- | ----------- |
| `RazorGenerate` | Item elements (`.cshtml` files) that are inputs to code generation. |
| `RazorComponent` | Item elements (`.razor` files) that are inputs to Razor component code generation. |
| `RazorCompile` | Item elements (`.cs` files) that are inputs to Razor compilation targets. Use this `ItemGroup` to specify additional files to be compiled into the Razor assembly. |
| `RazorTargetAssemblyAttribute` | Item elements used to code generate attributes for the Razor assembly. For example:  <br>`RazorAssemblyAttribute`<br>`Include="System.Reflection.AssemblyMetadataAttribute"`<br>`_Parameter1="BuildSource" _Parameter2="https://docs.microsoft.com/">` |
| `RazorEmbeddedResource` | Item elements added as embedded resources to the generated Razor assembly. |

| Property | Description |
| -------- | ----------- |
| `RazorTargetName` | File name (without extension) of the assembly produced by Razor. |
| `RazorOutputPath` | The Razor output directory. |
| `RazorCompileToolset` | Used to determine the toolset used to build the Razor assembly. Valid values are `Implicit`, `RazorSDK`, and `PrecompilationTool`. |
| [EnableDefaultContentItems](https://github.com/aspnet/websdk/blob/rel-2.0.0/src/ProjectSystem/Microsoft.NET.Sdk.Web.ProjectSystem.Targets/netstandard1.0/Microsoft.NET.Sdk.Web.ProjectSystem.targets#L21) | Default is `true`. When `true`, includes *web.config*, `.json`, and `.cshtml` files as content in the project. When referenced via `Microsoft.NET.Sdk.Web`, files under *wwwroot* and config files are also included. |
| `EnableDefaultRazorGenerateItems` | When `true`, includes `.cshtml` files from `Content` items in `RazorGenerate` items. |
| `GenerateRazorTargetAssemblyInfo` | When `true`, generates a `.cs` file containing attributes specified by `RazorAssemblyAttribute` and includes the file in the compile output. |
| `EnableDefaultRazorTargetAssemblyInfoAttributes` | When `true`, adds a default set of assembly attributes to `RazorAssemblyAttribute`. |
| `CopyRazorGenerateFilesToPublishDirectory` | When `true`, copies `RazorGenerate` items (`.cshtml`) files to the publish directory. Typically, Razor files aren't required for a published app if they participate in compilation at build-time or publish-time. Defaults to `false`. |
| `CopyRefAssembliesToPublishDirectory` | When `true`, copy reference assembly items to the publish directory. Typically, reference assemblies aren't required for a published app if Razor compilation occurs at build-time or publish-time. Set to `true` if your published app requires runtime compilation. For example, set the value to `true` if the app modifies `.cshtml` files at runtime or uses embedded views. Defaults to `false`. |
| `IncludeRazorContentInPack` | When `true`, all Razor content items (`.cshtml` files) are marked for inclusion in the generated NuGet package. Defaults to `false`. |
| `EmbedRazorGenerateSources` | When `true`, adds RazorGenerate (`.cshtml`) items as embedded files to the generated Razor assembly. Defaults to `false`. |
| `UseRazorBuildServer` | When `true`, uses a persistent build server process to offload code generation work. Defaults to the value of `UseSharedCompilation`. |
| `GenerateMvcApplicationPartsAssemblyAttributes` | When `true`, the SDK generates additional attributes used by MVC at runtime to perform application part discovery. |
| `DefaultWebContentItemExcludes` | A globbing pattern for item elements that are to be excluded from the `Content` item group in projects targeting the Web or Razor SDK |
| `ExcludeConfigFilesFromBuildOutput` | When `true`, *.config* and `.json` files do not get copied to the build output directory. |
| `AddRazorSupportForMvc` | When `true`, configures the Razor SDK to add support for the MVC configuration that is required when building applications containing MVC views or Razor Pages. This property is implicitly set for .NET Core 3.0 or later projects targeting the Web SDK |
| `RazorLangVersion` | The version of the Razor Language to target. |


For more information on properties, see [MSBuild properties](/visualstudio/msbuild/msbuild-properties).

### Targets

The Razor SDK defines two primary targets:

* `RazorGenerate`: Code generates `.cs` files from `RazorGenerate` item elements. Use the `RazorGenerateDependsOn` property to specify additional targets that can run before or after this target.
* `RazorCompile`: Compiles generated `.cs` files in to a Razor assembly. Use the `RazorCompileDependsOn` to specify additional targets that can run before or after this target.
* `RazorComponentGenerate`: Code generates `.cs` files for `RazorComponent` item elements. Use the `RazorComponentGenerateDependsOn` property to specify additional targets that can run before or after this target.

### Runtime compilation of Razor views

* By default, the Razor SDK doesn't publish reference assemblies that are required to perform runtime compilation. This results in compilation failures when the application model relies on runtime compilation&mdash;for example, the app uses embedded views or changes views after the app is published. Set `CopyRefAssembliesToPublishDirectory` to `true` to continue publishing reference assemblies.

* For a web app, ensure your app is targeting the `Microsoft.NET.Sdk.Web` SDK.

## Razor language version

When targeting the `Microsoft.NET.Sdk.Web` SDK, the Razor language version is inferred from the app's target framework version. For projects targeting the `Microsoft.NET.Sdk.Razor` SDK or in the rare case that the app requires a different Razor language version than the inferred value, a version can be configured by setting the `<RazorLangVersion>` property in the app's project file:

```xml
<PropertyGroup>
  <RazorLangVersion>{VERSION}</RazorLangVersion>
</PropertyGroup>
```

Razor's language version is tightly integrated with the version of the runtime that it was built for. Targeting a language version that isn't designed for the runtime is unsupported and likely produces build errors.

## Additional resources

* [Additions to the csproj format for .NET Core](/dotnet/core/tools/csproj)
* [Common MSBuild project items](/visualstudio/msbuild/common-msbuild-project-items)

:::moniker-end
