---
title: Configure the Trimmer for ASP.NET Core Blazor
author: guardrex
description: Learn how to control the Intermediate Language (IL) Trimmer when building a Blazor app.
monikerRange: '>= aspnetcore-5.0'
ms.author: riande
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
<ItemGroup>
  <TrimMode>full</TrimMode>
</ItemGroup>
```

For more information, see [Trimming options (.NET documentation)](/dotnet/core/deploying/trimming/trimming-options#trimming-granularity).

## Failure to preserve types used by a published app

Trimming may have detrimental effects for a published app. In apps that use [reflection](/dotnet/csharp/advanced-topics/reflection-and-attributes/), the IL Trimmer often can't determine the required types for runtime reflection and trims them away. This can happen for types used for JS interop and JSON serialization/deserialization. For example, complex framework types, such as <xref:System.Collections.Generic.KeyValuePair>, might be trimmed and not available at runtime.

Consider the following client-side component in a Blazor Web App (ASP.NET Core 8.0 or later) that deserializes a <xref:System.Collections.Generic.KeyValuePair> collection (`List<KeyValuePair<string, string>>`):

```razor
@rendermode @(new InteractiveWebAssemblyRenderMode(false))
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

    protected override void OnInitialized()
    {
        var data = "[ { \"key\" : \"key 1\", \"value\" : \"value 1\" }, " +
            "{ \"key\" : \"key 2\", \"value\" : \"value 2\" } ]";

        JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };

        items = JsonSerializer
            .Deserialize<List<KeyValuePair<string, string>>>(data, options)!;
    }
}
```

The preceding component executes normally when the app is run locally:

> **:::no-loc text="key 1":::**  
> :::no-loc text="value 1":::  
> **:::no-loc text="key 2":::**  
> :::no-loc text="value 2":::

When the app is published, <xref:System.Collections.Generic.KeyValuePair> is trimmed from the app, even in spite of setting the [`<PublishTrimmed>` property](#configuration) to `false` in the project file. Accessing the component throws the following exception:

> :::no-loc text="Unhandled exception rendering component: ConstructorContainsNullParameterNames, System.Collections.Generic.KeyValuePair`2[System.String,System.String]":::

In these cases, we recommend creating a custom type. The following modifications create a `StringKeyValuePair` type for use by the component.

`StringKeyValuePair.cs`:

```csharp
[method: SetsRequiredMembers]
public sealed class StringKeyValuePair(string key, string value)
{
    public required string Key { get; init; } = key;
    public required string Value { get; init; } = value;
}
```

The component is modified to use the `StringKeyValuePair` type. Because custom types are never trimmed by Blazor when an app is published, the component works as designed:

```razor
@using System.Diagnostics.CodeAnalysis

...

@code {
    private List<StringKeyValuePair> items = [];

    protected override void OnInitialized()
    {
        var data = "[ { \"key\" : \"key 1\", \"value\" : \"value 1\" }, " +
            "{ \"key\" : \"key 2\", \"value\" : \"value 2\" } ]";

        JsonSerializerOptions options = new() { PropertyNameCaseInsensitive = true };

        items = JsonSerializer
            .Deserialize<List<StringKeyValuePair>>(data, options)!;
    }
}
```

The IL Trimmer is also unable to react to an app's dynamic behavior at runtime. To ensure the trimmed app works correctly once deployed, test published output frequently while developing.

## Additional resources

* [Trim self-contained deployments and executables](/dotnet/core/deploying/trimming/trim-self-contained)
* <xref:blazor/performance#intermediate-language-il-trimming>
