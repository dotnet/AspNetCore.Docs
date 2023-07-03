---
title: Configure the Linker for ASP.NET Core Blazor
author: guardrex
description: Learn how to control the Intermediate Language (IL) Linker when building a Blazor app.
monikerRange: '= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/host-and-deploy/configure-linker
---
# Configure the Linker for ASP.NET Core Blazor

This article explains how to control the Intermediate Language (IL) Linker when building a Blazor app.

Blazor WebAssembly performs [Intermediate Language (IL)](/dotnet/standard/glossary#il) linking during a build to trim unnecessary IL from the app's output assemblies. The linker is disabled when building in Debug configuration. Apps must build in Release configuration to enable the linker. We recommend building in Release when deploying your Blazor WebAssembly apps. 

Linking an app optimizes for size but may have detrimental effects. Apps that use [reflection](/dotnet/csharp/advanced-topics/reflection-and-attributes/) or related dynamic features may break when trimmed because the linker doesn't know about this dynamic behavior and can't determine in general which types are required for reflection at runtime. To trim such apps, the linker must be informed about any types required by reflection in the code and in packages or frameworks that the app depends on.

To ensure the trimmed app works correctly once deployed, it's important to test Release builds of the app frequently while developing.

Linking for Blazor apps can be configured using these MSBuild features:

* Configure linking globally with a [MSBuild property](#control-linking-with-an-msbuild-property).
* Control linking on a per-assembly basis with a [configuration file](#control-linking-with-a-configuration-file).

## Control linking with an MSBuild property

Linking is enabled when an app is built in `Release` configuration. To change this, configure the `BlazorWebAssemblyEnableLinking` MSBuild property in the project file:

```xml
<PropertyGroup>
  <BlazorWebAssemblyEnableLinking>false</BlazorWebAssemblyEnableLinking>
</PropertyGroup>
```

## Control linking with a configuration file

Control linking on a per-assembly basis by providing an XML configuration file and specifying the file as a MSBuild item in the project file:

```xml
<ItemGroup>
  <BlazorLinkerDescriptor Include="LinkerConfig.xml" />
</ItemGroup>
```

`LinkerConfig.xml`:

```xml
<?xml version="1.0" encoding="UTF-8" ?>
<!--
  This file specifies which parts of the BCL or Blazor packages must not be
  stripped by the IL Linker even if they aren't referenced by user code.
-->
<linker>
  <assembly fullname="mscorlib">
    <!--
      Preserve the methods in WasmRuntime because its methods are called by 
      JavaScript client-side code to implement timers.
      Fixes: https://github.com/dotnet/blazor/issues/239
    -->
    <type fullname="System.Threading.WasmRuntime" />
  </assembly>
  <assembly fullname="System.Core">
    <!--
      System.Linq.Expressions* is required by Json.NET and any 
      expression.Compile caller. The assembly isn't stripped.
    -->
    <type fullname="System.Linq.Expressions*" />
  </assembly>
  <!--
    In this example, the app's entry point assembly is listed. The assembly
    isn't stripped by the IL Linker.
  -->
  <assembly fullname="MyCoolBlazorApp" />
</linker>
```

For more information and examples, see [Data Formats (dotnet/linker GitHub repository)](https://github.com/dotnet/linker/blob/main/docs/data-formats.md).

## Add an XML linker configuration file to a library

To configure the linker for a specific library, add an XML linker configuration file into the library as an embedded resource. The embedded resource must have the same name as the assembly.

In the following example, the `LinkerConfig.xml` file is specified as an embedded resource that has the same name as the library's assembly:

```xml
<ItemGroup>
  <EmbeddedResource Include="LinkerConfig.xml">
    <LogicalName>$(MSBuildProjectName).xml</LogicalName>
  </EmbeddedResource>
</ItemGroup>
```

### Configure the linker for internationalization

By default, Blazor's linker configuration for Blazor WebAssembly apps strips out internationalization information except for locales explicitly requested. Removing these assemblies minimizes the app's size.

To control which I18N assemblies are retained, set the `<BlazorWebAssemblyI18NAssemblies>` MSBuild property in the project file:

```xml
<PropertyGroup>
  <BlazorWebAssemblyI18NAssemblies>{all|none|REGION1,REGION2,...}</BlazorWebAssemblyI18NAssemblies>
</PropertyGroup>
```

| Region Value     | Mono region assembly    |
| ---------------- | ----------------------- |
| `all`            | All assemblies included |
| `cjk`            | `I18N.CJK.dll`          |
| `mideast`        | `I18N.MidEast.dll`      |
| `none` (default) | None                    |
| `other`          | `I18N.Other.dll`        |
| `rare`           | `I18N.Rare.dll`         |
| `west`           | `I18N.West.dll`         |

Use a comma to separate multiple values (for example, `mideast,west`).

For more information, see [I18N: Pnetlib Internationalization Framework Library (mono/mono GitHub repository)](https://github.com/mono/mono/tree/main/mcs/class/I18N).

## Additional resources

* <xref:blazor/performance#intermediate-language-il-linking>
