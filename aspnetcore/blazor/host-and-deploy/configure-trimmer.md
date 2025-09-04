---
title: Configure the Trimmer for ASP.NET Core Blazor
author: guardrex
description: Learn how to control the Intermediate Language (IL) Trimmer when building a Blazor app.
monikerRange: '>= aspnetcore-5.0'
ms.author: wpickett
ms.custom: mvc
ms.date: 11/12/2024
uid: blazor/host-and-deploy/configure-trimmer
---
# Configure the Trimmer for ASP.NET Core Blazor

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to control the Intermediate Language (IL) Trimmer when building a Blazor app.

Blazor WebAssembly performs [Intermediate Language (IL)](/dotnet/standard/glossary#il) trimming to reduce the size of the published output. Trimming occurs when publishing an app.

## Configuration

To configure the IL Trimmer, see the [Trimming options](/dotnet/core/deploying/trimming/trimming-options) article in the .NET Fundamentals documentation, which includes guidance on the following subjects:

* Disable trimming for the entire app with the `<PublishTrimmed>` property in the project file.
* Control how aggressively unused IL is discarded by the IL Trimmer.
* Stop the IL Trimmer from trimming specific assemblies.
* "Root" assemblies for trimming.
* Surface warnings for reflected types by setting the `<SuppressTrimAnalysisWarnings>` property to `false` in the project file.
* Control symbol trimming and debugger support.
* Set IL Trimmer features for trimming framework library features.

## Default trimmer granularity

The default trimmer granularity for Blazor apps is `partial`. To trim all assemblies, change the granularity to `full` in the app's project file:

```xml
<PropertyGroup>
  <TrimMode>full</TrimMode>
</PropertyGroup>
```

For more information, see [Trimming options (.NET documentation)](/dotnet/core/deploying/trimming/trimming-options#trimming-granularity).

## Failure to preserve types used by a published app

Trimming may have detrimental effects for a published app leading to runtime errors, even in spite of setting the [`<PublishTrimmed>` property](#configuration) to `false` in the project file. In apps that use [reflection](/dotnet/csharp/advanced-topics/reflection-and-attributes/), the IL Trimmer often can't determine the required types for runtime reflection and trims them away or trims away parameter names from methods. This can happen with complex framework types used for JS interop, JSON serialization/deserialization, and other operations.

The IL Trimmer is also unable to react to an app's dynamic behavior at runtime. To ensure the trimmed app works correctly once deployed, test published output frequently while developing.

To address lost types, consider the following approaches.

### Custom types

Custom types aren't trimmed by Blazor when an app is published, so we recommend using custom types for JS interop, JSON serialization/deserialization, and other operations that rely on reflection.

If you prefer to use framework types in spite of our recommendation, use either of the following approaches:

* [Preserve the type as a dynamic dependency](#preserve-the-type-as-a-dynamic-dependency)
* [Use a Root Descriptor](#use-a-root-descriptor)

### Preserve the type as a dynamic dependency

We recommend creating a dynamic dependency to preserve the type with the [`[DynamicDependency]` attribute](xref:System.Diagnostics.CodeAnalysis.DynamicDependencyAttribute).

If not already present, add an `@using` directive for <xref:System.Diagnostics.CodeAnalysis?displayProperty=fullName>:

```razor
@using System.Diagnostics.CodeAnalysis
```

<!-- REVIEW NOTE: We need a different type here than KeyValuePair that will continue to be trimmed away in 
                  10.0 or later. What would be good as a replacement? Whatever you pick, I'll also 
                  update the Root Descriptor section to use it.
-->

Add a [`[DynamicDependency]` attribute](xref:System.Diagnostics.CodeAnalysis.DynamicDependencyAttribute) to preserve the <xref:System.Collections.Generic.KeyValuePair>:

```diff
+ [DynamicDependency(DynamicallyAccessedMemberTypes.PublicConstructors, typeof(KeyValuePair<string, string>))]
private List<KeyValuePair<string, string>> items = [];
```

:::moniker range=">= aspnetcore-10.0"

### Use a Root Descriptor

<!-- REVIEW NOTE: Per https://github.com/dotnet/aspnetcore/issues/52947#issuecomment-3165135697, 
                  we have coverage for the ILLink file. We also have [DynamicDependency] covered.
                  
                  However, we don't have coverage on 'rd.xml'. Is that file something we need to cover here?
-->

A [Root Descriptor](/dotnet/core/deploying/trimming/trimming-options#root-descriptors) can preserve the type.

Add an `ILLink.Descriptors.xml` file to the root of the app&dagger; with the type:

<!-- NOTE TO SELF: Also update the KeyValuePair here. -->

```xml
<linker>
  <assembly fullname="System.Runtime">
    <type fullname="System.Collections.Generic.KeyValuePair`2">
      <method signature="System.Void .ctor(TKey,TValue)" />
    </type>
  </assembly>
</linker>
```

&dagger;The root of the app refers to the root of the Blazor WebAssembly app or the root of the `.Client` project of a Blazor Web App (.NET 8 or later).

Add a `TrimmerRootDescriptor` item to the app's project file&Dagger; referencing the `ILLink.Descriptors.xml` file:

```xml
<ItemGroup>
  <TrimmerRootDescriptor Include="$(MSBuildThisFileDirectory)ILLink.Descriptors.xml" />
</ItemGroup>
```

&Dagger;The project file is either the project file of the Blazor WebAssembly app or the project file of the `.Client` project of a Blazor Web App (.NET 8 or later).

:::moniker-end

:::moniker range="= aspnetcore-8.0"

### Workaround in .NET 8

As a workaround in .NET 8, you can add the `_ExtraTrimmerArgs` MSBuild property set to `--keep-metadata parametername` in the app's project file to preserve parameter names during trimming:

```xml
<PropertyGroup>
  <_ExtraTrimmerArgs>--keep-metadata parametername</_ExtraTrimmerArgs>
</PropertyGroup>
```

:::moniker-end

## Additional resources

* [Trim self-contained deployments and executables](/dotnet/core/deploying/trimming/trim-self-contained)
* <xref:blazor/performance/app-download-size#intermediate-language-il-trimming>
