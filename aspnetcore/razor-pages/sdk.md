---
title: ASP.NET Core Razor SDK
author: Rick-Anderson
description: Learn how Razor Pages in ASP.NET Core makes coding page-focused scenarios easier and more productive than using MVC.
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.date: 04/12/2018
uid: razor-pages/sdk
---
# ASP.NET Core Razor SDK

By [Rick Anderson](https://twitter.com/RickAndMSFT)

The [!INCLUDE[](~/includes/2.1-SDK.md)] includes the `Microsoft.NET.Sdk.Razor` MSBuild SDK (Razor SDK). The Razor SDK:

* Standardizes the experience around building, packaging, and publishing projects containing [Razor](xref:mvc/views/razor) files for ASP.NET Core MVC-based projects.
* Includes a set of predefined targets, properties, and items that allow customizing the compilation of Razor files.

## Prerequisites

[!INCLUDE[](~/includes/2.1-SDK.md)]

## Using the Razor SDK

Most web apps don't need to expressly reference the Razor SDK. 

To use the Razor SDK to build class libraries containing Razor views or Razor Pages:

* Use `Microsoft.NET.Sdk.Razor` instead of `Microsoft.NET.Sdk`:
```xml
<Project SDK="Microsoft.NET.Sdk.Razor">
  ...
</Project>
```

* Typically a package reference to `Microsoft.AspNetCore.Mvc` is required to bring in additional dependencies required to build and compile Razor Pages and Razor views. At minimum, your project needs to add package references to:

    * `Microsoft.AspNetCore.Razor.Design` 
    * `Microsoft.AspNetCore.Mvc.Razor.Extensions`
    
 The preceding packages are included in `Microsoft.AspNetCore.Mvc`. The following markup shows a basic *.csproj* file that uses the Razor SDK to build Razor files for an ASP.NET Core Razor Pages app:
    
 [!code-xml[Main](sdk/sample/RazorSDK.csproj)]

### Properties

The following properties control the Razor's SDK behavior as part of a project build:

* `RazorCompileOnBuild` : When `true`, compiles and emits the Razor assembly as part of building the project. Defaults to `true`.
* `RazorCompileOnPublish` : When `true`, compiles and emits the Razor assembly as part of publishing the project. Defaults to `true`.

The following properties and items are used to configure inputs and output to the Razor SDK:

| Items                                         | Description                                                                   |
| ------------                                  | -------------                                                                 |
| RazorGenerate                                 | Item elements (*.cshtml* files) that are inputs to code generation targets. |
| RazorCompile                                  | Item elements (.cs files) that are inputs to  Razor compilation targets. Use this ItemGroup to specify additional files to be compiled into the Razor assembly. |
| RazorTargetAssemblyAttribute                  | Item elements used to code generate attributes for the Razor assembly. For example:  <br />`<RazorAssemblyAttribute ` <br />  `Include="System.Reflection.AssemblyMetadataAttribute"`<br />`  _Parameter1="BuildSource" _Parameter2="https://docs.asp.net/">` |
| RazorEmbeddedResource                         | Item elements added as embedded resources to the generated Razor assembly |

| Property                                      | Description                                                                   |
| ------------                                  | -------------                                                                 |
| RazorTargetName                               | File name (without extension) of the assembly produced by Razor. | 
| RazorOutputPath                               | The Razor output directory.                                      |
| RazorCompileToolset                           | Used to determine the toolset used to build the Razor assembly. Valid values are `Implicit`, , and `PrecompilationTool`. |
| EnableDefaultContentItems                     | When `true`, includes certain file types, such as *.cshtml* files, as content in the project. When referenced via Microsoft.NET.Sdk.Web, also includes all files under *wwwroot*, and config files.         |
| EnableDefaultRazorGenerateItems               | When `true`, includes *.cshtml* files from `Content` items in `RazorGenerate` items. |
| GenerateRazorTargetAssemblyInfo               | When `true`, generates a *.cs* file containing attributes specified by `RazorAssemblyAttribute` and includes it in the compile output. |
| EnableDefaultRazorTargetAssemblyInfoAttributes | When `true`, adds a default set of assembly attributes to `RazorAssemblyAttribute`. |
| CopyRazorGenerateFilesToPublishDirectory       | When `true`, copies RazorGenerate items (*.cshtml*) files to the publish directory. Typically Razor files are not needed for a published application if they participate in compilation at build-time or publish-time. Defaults to `false`. |
| CopyRefAssembliesToPublishDirectory            | When `true`, copy reference assembly items to the publish directory. Typically reference assemblies are not needed for a published application if Razor compilation occurs at build-time or publish-time. Set to `true`, if your published application requires runtime compilation, for example, modifies cshtml files at runtime, or uses embedded views. Defaults to `false`. |
| IncludeRazorContentInPack                      | When `true`, all Razor content items (*.cshtml* files) will be marked for inclusion in the generated NuGet package. Defaults to `false`. |
| EmbedRazorGenerateSources | When `true`, adds RazorGenerate (*.cshtml*) items as embedded files to the generated Razor assembly. Defaults to `false`. |
| UseRazorBuildServer                           | When `true`, uses a persistent build server process to offload code generation work. Defaults to the value of `UseSharedCompilation`. |

### Targets
The Razor SDK defines two primary targets:

* `RazorGenerate` - Code generates *.cs* files from RazorGenerate item elements. Use `RazorGenerateDependsOn` property to specify additional targets that can run before or after this target.
* `RazorCompile` - Compiles generated *.cs* files in to a Razor assembly. Use `RazorCompileDependsOn` to specify additional targets that can run before or after this target.

### Runtime compilation of Razor views

* By default, the Razor SDK doesn't publish reference assemblies that are required to perform runtime compilation. This results in compilation failures when the application model relies on runtime compilation&mdash;for example, the app uses embedded views or changes views after the app is published. Set `CopyRefAssembliesToPublishDirectory` to `true` to continue publishing reference assemblies.

* For web applications, ensure your app is targeting `Microsoft.NET.Sdk.Web` SDK.
