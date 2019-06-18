---
title: ASP.NET Core Razor SDK
author: Rick-Anderson
description: Learn how Razor Pages in ASP.NET Core makes coding page-focused scenarios easier and more productive than using MVC.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.custom: "mvc, seodec18"
ms.date: 06/18/2019
uid: razor-pages/sdk
---

# ASP.NET Core Razor SDK

By [Rick Anderson](https://twitter.com/RickAndMSFT)

## Overview

The [!INCLUDE[](~/includes/2.1-SDK.md)] includes the `Microsoft.NET.Sdk.Razor` MSBuild SDK (Razor SDK). The Razor SDK:

* Standardizes the experience around building, packaging, and publishing projects containing [Razor](xref:mvc/views/razor) files for ASP.NET Core MVC-based projects.
* Includes a set of predefined targets, properties, and items that allow customizing the compilation of Razor files.

::: moniker range=">= aspnetcore-2.1 <= aspnetcore-2.2"

The Razor SDK includes a `<Content>` element with an `Include` attribute set to the `**\*.cshtml` globbing pattern. Matching files are published.

::: moniker-end

::: moniker range=">= aspnetcore-3.0"

The Razor SDK includes `<Content>` elements with `Include` attributes set to the `**\*.cshtml` and `**\*.razor` globbing patterns. Matching files are published.

::: moniker-end

## Prerequisites

[!INCLUDE[](~/includes/2.1-SDK.md)]

## Using the Razor SDK

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

::: moniker range="= aspnetcore-2.1"

> [!WARNING]
> The `Microsoft.AspNetCore.Razor.Design` and `Microsoft.AspNetCore.Mvc.Razor.Extensions` packages are included in the [Microsoft.AspNetCore.App metapackage](xref:fundamentals/metapackage-app). However, the version-less `Microsoft.AspNetCore.App` package reference provides a metapackage to the app that doesn't include the latest version of `Microsoft.AspNetCore.Razor.Design`. Projects must reference a consistent version of `Microsoft.AspNetCore.Razor.Design` (or `Microsoft.AspNetCore.Mvc`) so that the latest build-time fixes for Razor are included. For more information, see [this GitHub issue](https://github.com/aspnet/Razor/issues/2553).

::: moniker-end

### Properties

The following properties control the Razor's SDK behavior as part of a project build:

* `RazorCompileOnBuild` &ndash; When `true`, compiles and emits the Razor assembly as part of building the project. Defaults to `true`.
* `RazorCompileOnPublish` &ndash; When `true`, compiles and emits the Razor assembly as part of publishing the project. Defaults to `true`.

The properties and items in the following table are used to configure inputs and output to the Razor SDK.

| Items | Description |
| ----- | ----------- |
| `RazorGenerate` | Item elements (*.cshtml* files) that are inputs to code generation targets. |
| `RazorCompile` | Item elements (*.cs* files) that are inputs to Razor compilation targets. Use this ItemGroup to specify additional files to be compiled into the Razor assembly. |
| `RazorTargetAssemblyAttribute` | Item elements used to code generate attributes for the Razor assembly. For example:  <br>`RazorAssemblyAttribute`<br>`Include="System.Reflection.AssemblyMetadataAttribute"`<br>`_Parameter1="BuildSource" _Parameter2="https://docs.microsoft.com/">` |
| `RazorEmbeddedResource` | Item elements added as embedded resources to the generated Razor assembly. |

| Property | Description |
| -------- | ----------- |
| `RazorTargetName` | File name (without extension) of the assembly produced by Razor. | 
| `RazorOutputPath` | The Razor output directory. |
| `RazorCompileToolset` | Used to determine the toolset used to build the Razor assembly. Valid values are `Implicit`, `RazorSDK`, and `PrecompilationTool`. |
| [EnableDefaultContentItems](https://github.com/aspnet/websdk/blob/rel-2.0.0/src/ProjectSystem/Microsoft.NET.Sdk.Web.ProjectSystem.Targets/netstandard1.0/Microsoft.NET.Sdk.Web.ProjectSystem.targets#L21) | Default is `true`. When `true`, includes *web.config*, *.json*, and *.cshtml* files as content in the project. When referenced via `Microsoft.NET.Sdk.Web`, files under *wwwroot* and config files are also included. |
| `EnableDefaultRazorGenerateItems` | When `true`, includes *.cshtml* files from `Content` items in `RazorGenerate` items. |
| `GenerateRazorTargetAssemblyInfo` | When `true`, generates a *.cs* file containing attributes specified by `RazorAssemblyAttribute` and includes the file in the compile output. |
| `EnableDefaultRazorTargetAssemblyInfoAttributes` | When `true`, adds a default set of assembly attributes to `RazorAssemblyAttribute`. |
| `CopyRazorGenerateFilesToPublishDirectory` | When `true`, copies `RazorGenerate` items (*.cshtml*) files to the publish directory. Typically, Razor files aren't required for a published app if they participate in compilation at build-time or publish-time. Defaults to `false`. |
| `CopyRefAssembliesToPublishDirectory` | When `true`, copy reference assembly items to the publish directory. Typically, reference assemblies aren't required for a published app if Razor compilation occurs at build-time or publish-time. Set to `true` if your published app requires runtime compilation. For example, set the value to `true` if the app modifies *.cshtml* files at runtime or uses embedded views. Defaults to `false`. |
| `IncludeRazorContentInPack` | When `true`, all Razor content items (*.cshtml* files) are marked for inclusion in the generated NuGet package. Defaults to `false`. |
| `EmbedRazorGenerateSources` | When `true`, adds RazorGenerate (*.cshtml*) items as embedded files to the generated Razor assembly. Defaults to `false`. |
| `UseRazorBuildServer` | When `true`, uses a persistent build server process to offload code generation work. Defaults to the value of `UseSharedCompilation`. |

For more information on properties, see [MSBuild properties](/visualstudio/msbuild/msbuild-properties).

### Targets

The Razor SDK defines two primary targets:

* `RazorGenerate` &ndash; Code generates *.cs* files from `RazorGenerate` item elements. Use `RazorGenerateDependsOn` property to specify additional targets that can run before or after this target.
* `RazorCompile` &ndash; Compiles generated *.cs* files in to a Razor assembly. Use `RazorCompileDependsOn` to specify additional targets that can run before or after this target.

### Runtime compilation of Razor views

* By default, the Razor SDK doesn't publish reference assemblies that are required to perform runtime compilation. This results in compilation failures when the application model relies on runtime compilation&mdash;for example, the app uses embedded views or changes views after the app is published. Set `CopyRefAssembliesToPublishDirectory` to `true` to continue publishing reference assemblies.

* For a web app, ensure your app is targeting the `Microsoft.NET.Sdk.Web` SDK.

## Razor language version

When targeting the `Microsoft.NET.Sdk.Web` SDK, the Razor language version is inferred from the the app's target framework version. For projects targeting the `Microsoft.NET.Sdk.Razor` SDK or in the rare case that the app requires a different Razor language version than the inferred value, a version can be configured by setting the `<RazorLangVersion>` property in the app's project file:

```xml
<PropertyGroup>
  <RazorLangVersion>{VERSION}</RazorLangVersion>
</PropertyGroup>
```

## Additional resources

* [Additions to the csproj format for .NET Core](/dotnet/core/tools/csproj)
* [Common MSBuild project items](/visualstudio/msbuild/common-msbuild-project-items)
