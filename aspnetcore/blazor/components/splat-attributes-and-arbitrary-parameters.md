---
title: ASP.NET Core Blazor attribute splatting and arbitrary parameters
author: guardrex
description: Learn how components can capture and render additional attributes in addition to the component's declared parameters.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/components/attribute-splatting
---
# ASP.NET Core Blazor attribute splatting and arbitrary parameters

Components can capture and render additional attributes in addition to the component's declared parameters. Additional attributes can be captured in a dictionary and then *splatted* onto an element when the component is rendered using the [`@attributes`](xref:mvc/views/razor#attributes) Razor directive attribute. This scenario is useful for defining a component that produces a markup element that supports a variety of customizations. For example, it can be tedious to define attributes separately for an `<input>` that supports many parameters.

[!INCLUDE[](~/blazor/includes/location-client-and-server-pre-net8.md)]

## Attribute splatting

In the following `Splat` component:

* The first `<input>` element (`id="useIndividualParams"`) uses individual component parameters.
* The second `<input>` element (`id="useAttributesDict"`) uses attribute splatting.

`Splat.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Splat.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/splat-attributes-and-arbitrary-parameters/Splat.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/splat-attributes-and-arbitrary-parameters/Splat.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/splat-attributes-and-arbitrary-parameters/Splat.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/splat-attributes-and-arbitrary-parameters/Splat.razor":::

:::moniker-end

The rendered `<input>` elements in the webpage are identical:

```html
<input id="useIndividualParams"
       maxlength="10"
       placeholder="Input placeholder text"
       required="required"
       size="50">

<input id="useAttributesDict"
       maxlength="10"
       placeholder="Input placeholder text"
       required="required"
       size="50">
```

## Arbitrary attributes

To accept arbitrary attributes, define a [component parameter](xref:blazor/components/index#component-parameters) with the <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues> property set to `true`:

```razor
@code {
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? InputAttributes { get; set; }
}
```

The <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues> property on [`[Parameter]`](xref:Microsoft.AspNetCore.Components.ParameterAttribute) allows the parameter to match all attributes that don't match any other parameter. A component can only define a single parameter with <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues>. The property type used with <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues> must be assignable from [`Dictionary<string, object>`](xref:System.Collections.Generic.Dictionary%602) with string keys. Use of [`IEnumerable<KeyValuePair<string, object>>`](xref:System.Collections.Generic.IEnumerable%601) or [`IReadOnlyDictionary<string, object>`](xref:System.Collections.Generic.IReadOnlyDictionary%602) are also options in this scenario.

The position of [`@attributes`](xref:mvc/views/razor#attributes) relative to the position of element attributes is important. When [`@attributes`](xref:mvc/views/razor#attributes) are splatted on the element, the attributes are processed from right to left (last to first). Consider the following example of a parent component that consumes a child component:

`AttributeOrderChild1.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/AttributeOrderChild1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/splat-attributes-and-arbitrary-parameters/AttributeOrderChild1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/splat-attributes-and-arbitrary-parameters/AttributeOrderChild1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/splat-attributes-and-arbitrary-parameters/AttributeOrderChild1.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/splat-attributes-and-arbitrary-parameters/AttributeOrderChild1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

`AttributeOrder1.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/AttributeOrder1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`AttributeOrderParent1.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/splat-attributes-and-arbitrary-parameters/AttributeOrderParent1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

`AttributeOrderParent1.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/splat-attributes-and-arbitrary-parameters/AttributeOrderParent1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

`AttributeOrderParent1.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/splat-attributes-and-arbitrary-parameters/AttributeOrderParent1.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

`AttributeOrderParent1.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/splat-attributes-and-arbitrary-parameters/AttributeOrderParent1.razor":::

:::moniker-end

The `AttributeOrderChild1` component's `extra` attribute is set to the right of [`@attributes`](xref:mvc/views/razor#attributes). The `AttributeOrderParent1` component's rendered `<div>` contains `extra="5"` when passed through the additional attribute because the attributes are processed right to left (last to first):

```html
<div extra="5" />
```

In the following example, the order of `extra` and [`@attributes`](xref:mvc/views/razor#attributes) is reversed in the child component's `<div>`:

`AttributeOrderChild2.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/AttributeOrderChild2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/splat-attributes-and-arbitrary-parameters/AttributeOrderChild2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/splat-attributes-and-arbitrary-parameters/AttributeOrderChild2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/splat-attributes-and-arbitrary-parameters/AttributeOrderChild2.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/splat-attributes-and-arbitrary-parameters/AttributeOrderChild2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

`AttributeOrder2.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/AttributeOrder2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`AttributeOrderParent2.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/splat-attributes-and-arbitrary-parameters/AttributeOrderParent2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

`AttributeOrderParent2.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/splat-attributes-and-arbitrary-parameters/AttributeOrderParent2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

`AttributeOrderParent2.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/splat-attributes-and-arbitrary-parameters/AttributeOrderParent2.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

`AttributeOrderParent2.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/splat-attributes-and-arbitrary-parameters/AttributeOrderParent2.razor":::

:::moniker-end

The `<div>` in the parent component's rendered webpage contains `extra="10"` when passed through the additional attribute:

```html
<div extra="10" />
```
