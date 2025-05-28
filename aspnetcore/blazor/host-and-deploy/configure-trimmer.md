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

Trimming may have detrimental effects for a published app leading to runtime errors. In apps that use [reflection](/dotnet/csharp/advanced-topics/reflection-and-attributes/), the IL Trimmer often can't determine the required types for runtime reflection and trims them away or trims away parameter names from methods. This can happen with complex framework types used for JS interop, JSON serialization/deserialization, and other operations.

The IL Trimmer is also unable to react to an app's dynamic behavior at runtime. To ensure the trimmed app works correctly once deployed, test published output frequently while developing.

Consider the following client-side component in a Blazor Web App (.NET 8 or later) that deserializes a <xref:System.Collections.Generic.KeyValuePair> collection (`List<KeyValuePair<string, string>>`):

```razor
@rendermode @(new InteractiveWebAssemblyRenderMode(false))
@using System.Diagnostics.CodeAnalysis
@using System.Text.Json

<dl>
    @foreach (var item in @items)
    {
        <dt>@item.Key</dt>
        <dd>@item.Value</dd>
    }
</dl>

@code {
    private List<KeyValuePair<string, string>> items = [];

    [StringSyntax(StringSyntaxAttribute.Json)]
    private const string data =
        """[{"key":"key 1","value":"value 1"},{"key":"key 2","value":"value 2"}]""";

    protected override void OnInitialized()
    {
        JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };

        items = JsonSerializer
            .Deserialize<List<KeyValuePair<string, string>>>(data, options)!;
    }
}
```

The preceding component executes normally when the app is run locally and produces the following rendered definition list (`<dl>`):

> **:::no-loc text="key 1":::**  
> :::no-loc text="value 1":::  
> **:::no-loc text="key 2":::**  
> :::no-loc text="value 2":::

When the app is published, <xref:System.Collections.Generic.KeyValuePair> is trimmed from the app, even in spite of setting the [`<PublishTrimmed>` property](#configuration) to `false` in the project file. Accessing the component throws the following exception:

> :::no-loc text="Unhandled exception rendering component: ConstructorContainsNullParameterNames, System.Collections.Generic.KeyValuePair`2[System.String,System.String]":::

To address lost types, consider the following approaches.

### Preserve the type as a dynamic dependency

We recommend creating a dynamic dependency to preserve the type with the [`[DynamicDependency]` attribute](xref:System.Diagnostics.CodeAnalysis.DynamicDependencyAttribute).

If not already present, add an `@using` directive for <xref:System.Diagnostics.CodeAnalysis?displayProperty=fullName>:

```razor
@using System.Diagnostics.CodeAnalysis
```

Add a [`[DynamicDependency]` attribute](xref:System.Diagnostics.CodeAnalysis.DynamicDependencyAttribute) to preserve the <xref:System.Collections.Generic.KeyValuePair>:

```diff
+ [DynamicDependency(DynamicallyAccessedMemberTypes.PublicConstructors, typeof(KeyValuePair<string, string>))]
private List<KeyValuePair<string, string>> items = [];
```

<!-- UPDATE 10.0 - Hold this for https://github.com/dotnet/aspnetcore/issues/52947

### Use a Root Descriptor

A [Root Descriptor](/dotnet/core/deploying/trimming/trimming-options#root-descriptors) can preserve the type.

Add an `ILLink.Descriptors.xml` file to the root of the app&dagger; with the type:

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

-->

### Custom types

<!-- UPDATE 10.0 - We'll hold this for when the file descriptor approach comes back.

Custom types aren't trimmed by Blazor when an app is published, but we recommend [preserving types as dynamic dependencies](#preserve-the-type-as-a-dynamic-dependency) instead of creating custom types.

-->

The following modifications create a `StringKeyValuePair` type for use by the component.

`StringKeyValuePair.cs`:

```csharp
[method: SetsRequiredMembers]
public sealed class StringKeyValuePair(string key, string value)
{
    public required string Key { get; init; } = key;
    public required string Value { get; init; } = value;
}
```

The component is modified to use the `StringKeyValuePair` type:

```diff
- private List<KeyValuePair<string, string>> items = [];
+ private List<StringKeyValuePair> items = [];
```

```diff
- items = JsonSerializer.Deserialize<List<KeyValuePair<string, string>>>(data, options)!;
+ items = JsonSerializer.Deserialize<List<StringKeyValuePair>>(data, options)!;
```

Because custom types are never trimmed by Blazor when an app is published, the component works as designed after the app is published.

## Additional resources

* [Trim self-contained deployments and executables](/dotnet/core/deploying/trimming/trim-self-contained)
* <xref:blazor/performance/app-download-size#intermediate-language-il-trimming>
