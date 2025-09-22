---
title: Configure the Trimmer for ASP.NET Core Blazor
author: guardrex
description: Learn how to control the Intermediate Language (IL) Trimmer when building a Blazor app.
monikerRange: '>= aspnetcore-5.0'
ms.author: wpickett
ms.custom: mvc
ms.date: 09/19/2025
uid: blazor/host-and-deploy/configure-trimmer
---
# Configure the Trimmer for ASP.NET Core Blazor

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to control the Intermediate Language (IL) Trimmer when building a Blazor app.

Blazor WebAssembly performs [Intermediate Language (IL)](/dotnet/standard/glossary#il) trimming to reduce the size of the published output. Trimming occurs when publishing an app.

## Default trimmer granularity

<!-- UPDATE 10.0 - HOLD until https://github.com/dotnet/aspnetcore/issues/49409
                   is addressed.

The default trimmer granularity for Blazor apps is `partial`. To trim all assemblies, change the granularity to `full` in the app's project file:

```xml
<PropertyGroup>
  <TrimMode>full</TrimMode>
</PropertyGroup>
```

-->

The default trimmer granularity for Blazor apps is `partial`, which means that only core framework libraries and libraries that have explicitly enabled trimming support are trimmed. Full trimming isn't supported.

For more information, see [Trimming options (.NET documentation)](/dotnet/core/deploying/trimming/trimming-options#trimming-granularity).

## Configuration

To configure the IL Trimmer, see the [Trimming options](/dotnet/core/deploying/trimming/trimming-options) article in the .NET Fundamentals documentation, which includes guidance on the following subjects:

* Disable trimming for the entire app with the `<PublishTrimmed>` property in the project file.
* Control how aggressively unused IL is discarded by the IL Trimmer.
* Stop the IL Trimmer from trimming specific assemblies.
* "Root" assemblies for trimming.
* Surface warnings for reflected types by setting the `<SuppressTrimAnalysisWarnings>` property to `false` in the project file.
* Control symbol trimming and debugger support.
* Set IL Trimmer features for trimming framework library features.

When the [trimmer granularity](#default-trimmer-granularity) is `partial`, which is the default value, the IL Trimmer trims the base class library and any other assemblies marked as trimmable. To opt into trimming in any of the app's class library projects, set the `<IsTrimmable>` MSBuild property to `true` in those projects:

```xml
<PropertyGroup>
  <IsTrimmable>true</IsTrimmable>
</PropertyGroup>
```

For guidance that pertains to .NET libraries, see [Prepare .NET libraries for trimming](/dotnet/core/deploying/trimming/prepare-libraries-for-trimming).

## Failure to preserve types used by a published app

Trimming may have detrimental effects for a published app leading to runtime errors, even in spite of setting the [`<PublishTrimmed>` property](#configuration) to `false` in the project file. In apps that use [reflection](/dotnet/csharp/advanced-topics/reflection-and-attributes/), the IL Trimmer often can't determine the required types for runtime reflection and trims them away or trims away parameter names from methods. This can happen with complex framework types used for JS interop, JSON serialization/deserialization, and other operations.

The IL Trimmer is also unable to react to an app's dynamic behavior at runtime. To ensure the trimmed app works correctly once deployed, test published output frequently while developing.

Consider the following example that performs JSON deserialization into a <xref:System.Tuple%602> collection (`List<Tuple<string, string>>`).

`TrimExample.razor`:

```razor
@page "/trim-example"
@using System.Diagnostics.CodeAnalysis
@using System.Text.Json

<h1>Trim Example</h1>

<ul>
    @foreach (var item in @items)
    {
        <li>@item.Item1, @item.Item2</li>
    }
</ul>

@code {
    private List<Tuple<string, string>> items = [];

    [StringSyntax(StringSyntaxAttribute.Json)]
    private const string data =
        """[{"item1":"1:T1","item2":"1:T2"},{"item1":"2:T1","item2":"2:T2"}]""";

    protected override void OnInitialized()
    {
        JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };

        items = JsonSerializer
            .Deserialize<List<Tuple<string, string>>>(data, options)!;
    }
}
```

The preceding component executes normally when the app is run locally and produces the following rendered list:

> • 1:T1, 1:T2  
> • 2:T2, 2:T2

When the app is published, <xref:System.Tuple%602> is trimmed from the app, even in spite of setting the `<PublishTrimmed>` property to `false` in the project file. Accessing the component throws the following exception:

> :::no-loc text="crit: Microsoft.AspNetCore.Components.WebAssembly.Rendering.WebAssemblyRenderer[100]":::  
> :::no-loc text="Unhandled exception rendering component: ConstructorContainsNullParameterNames, System.Tuple`2[System.String,System.String]":::  
> :::no-loc text="System.NotSupportedException: ConstructorContainsNullParameterNames, System.Tuple`2[System.String,System.String]":::

To address lost types, consider adopting one of the following approaches.

### Custom types

To avoid issues with .NET trimming in scenarios that rely on reflection, such as JS interop and JSON serialization, use custom types defined in non-trimmable libraries or preserve the types via linker configuration.

The following modifications create a `StringTuple` type for use by the component.

`StringTuple.cs`:

```csharp
[method: SetsRequiredMembers]
public sealed class StringTuple(string item1, string item2)
{
    public required string Item1 { get; init; } = item1;
    public required string Item2 { get; init; } = item2;
}
```

The component is modified to use the `StringTuple` type:

```diff
- private List<Tuple<string, string>> items = [];
+ private List<StringTuple> items = [];
```

```diff
- items = JsonSerializer.Deserialize<List<Tuple<string, string>>>(data, options)!;
+ items = JsonSerializer.Deserialize<List<StringTuple>>(data, options)!;
```

Because custom types defined in non-trimmable assemblies aren't trimmed by Blazor when an app is published, the component works as designed after the app is published.

:::moniker range=">= aspnetcore-10.0"

If you prefer to use framework types in spite of our recommendation, use either of the following approaches:

* [Preserve the type as a dynamic dependency](#preserve-the-type-as-a-dynamic-dependency)
* [Use a Root Descriptor](#use-a-root-descriptor)

:::moniker-end

:::moniker range="< aspnetcore-10.0"

If you prefer to use framework types in spite of our recommendation, [preserve the type as a dynamic dependency](#preserve-the-type-as-a-dynamic-dependency).

:::moniker-end

### Preserve the type as a dynamic dependency

Create a dynamic dependency to preserve the type with the [`[DynamicDependency]` attribute](xref:System.Diagnostics.CodeAnalysis.DynamicDependencyAttribute).

If not already present, add an `@using` directive for <xref:System.Diagnostics.CodeAnalysis?displayProperty=fullName>:

```razor
@using System.Diagnostics.CodeAnalysis
```

Add a [`[DynamicDependency]` attribute](xref:System.Diagnostics.CodeAnalysis.DynamicDependencyAttribute) to preserve the <xref:System.Tuple%602>:

```diff
+ [DynamicDependency(DynamicallyAccessedMemberTypes.PublicConstructors, 
+     typeof(Tuple<string, string>))]
private List<Tuple<string, string>> items = [];
```

:::moniker range=">= aspnetcore-10.0"

### Use a Root Descriptor

A [Root Descriptor](/dotnet/core/deploying/trimming/trimming-options#root-descriptors) can preserve the type.

Add an `ILLink.Descriptors.xml` file to the root of the app&dagger; with the type:

```xml
<linker>
  <assembly fullname="System.Private.CoreLib">
    <type fullname="System.Tuple`2" preserve="all" />
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
* [Prepare .NET libraries for trimming](/dotnet/core/deploying/trimming/prepare-libraries-for-trimming)
* <xref:blazor/performance/app-download-size#intermediate-language-il-trimming>
