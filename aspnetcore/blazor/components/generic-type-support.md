---
title: ASP.NET Core Razor component generic type support
author: guardrex
description: Learn about generic type support in ASP.NET Core Razor components.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/components/generic-type-support
---
# ASP.NET Core Razor component generic type support

[!INCLUDE[](~/includes/not-latest-version.md)]

This article describes generic type support in Razor components.

[!INCLUDE[](~/blazor/includes/location-client-and-server-pre-net8.md)]

## Generic type parameter support

The [`@typeparam`](xref:mvc/views/razor#typeparam) directive declares a [generic type parameter](/dotnet/csharp/programming-guide/generics/generic-type-parameters) for the generated component class:

```razor
@typeparam TItem
```

C# syntax with [`where`](/dotnet/csharp/language-reference/keywords/where-generic-type-constraint) type constraints is supported:

```razor
@typeparam TEntity where TEntity : IEntity
```

In the following example, the `ListGenericTypeItems1` component is generically typed as `TExample`.

`ListGenericTypeItems1.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/ListGenericTypeItems1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/generic-type-support/ListGenericTypeItems1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/generic-type-support/ListGenericTypeItems1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/generic-type-support/ListGenericTypeItems1.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/generic-type-support/ListGenericTypeItems1.razor":::

:::moniker-end

The following component renders two `ListGenericTypeItems1` components:

* String or integer data is assigned to the `ExampleList` parameter of each component.
* Type `string` or `int` that matches the type of the assigned data is set for the type parameter (`TExample`) of each component.

:::moniker range=">= aspnetcore-8.0"

`GenericType1.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/GenericType1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`GenericTypeExample1.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/generic-type-support/GenericTypeExample1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

`GenericTypeExample1.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/generic-type-support/GenericTypeExample1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

`GenericTypeExample1.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/generic-type-support/GenericTypeExample1.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

`GenericTypeExample1.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/generic-type-support/GenericTypeExample1.razor":::

:::moniker-end

For more information, see <xref:mvc/views/razor#typeparam>. For an example of generic typing with templated components, see <xref:blazor/components/templated-components>.

:::moniker range=">= aspnetcore-6.0"

## Cascaded generic type support

An ancestor component can cascade a type parameter by name to descendants using the [`[CascadingTypeParameter]` attribute](xref:Microsoft.AspNetCore.Components.CascadingTypeParameterAttribute). This attribute allows a generic type inference to use the specified type parameter automatically with descendants that have a type parameter with the same name.

By adding `@attribute [CascadingTypeParameter(...)]` to a component, the specified generic type argument is automatically used by descendants that:

* Are nested as child content for the component in the same `.razor` document.
* Also declare a [`@typeparam`](xref:mvc/views/razor#typeparam) with the exact same name.
* Don't have another value explicitly supplied or implicitly inferred for the type parameter. If another value is supplied or inferred, it takes precedence over the cascaded generic type.

When receiving a cascaded type parameter, components obtain the parameter value from the closest ancestor that has a [`[CascadingTypeParameter]` attribute](xref:Microsoft.AspNetCore.Components.CascadingTypeParameterAttribute) with a matching name. Cascaded generic type parameters are overridden within a particular subtree.

Matching is only performed by name. Therefore, we recommend avoiding a cascaded generic type parameter with a generic name, for example `T` or `TItem`. If a developer opts into cascading a type parameter, they're implicitly promising that its name is unique enough not to clash with other cascaded type parameters from unrelated components.

Generic types can be cascaded to child components in either of the following approaches with ancestor (parent) components, which are demonstrated in the following two sub-sections:

* Explicitly set the cascaded generic type.
* Infer the cascaded generic type.

The following subsections provide examples of the preceding approaches using the following two `ListDisplay` components. The components receive and render list data and are generically typed as `TExample`. These components are for demonstration purposes and only differ in the color of text that the list is rendered. If you wish to experiment with the components in the following sub-sections in a local test app, add the following two components to the app first.

`ListDisplay1.razor`:

```razor
@typeparam TExample

@if (ExampleList is not null)
{
    <ul style="color:blue">
        @foreach (var item in ExampleList)
        {
            <li>@item</li>
        }
    </ul>
}

@code {
    [Parameter]
    public IEnumerable<TExample>? ExampleList { get; set; }
}
```

`ListDisplay2.razor`:

```razor
@typeparam TExample

@if (ExampleList is not null)
{
    <ul style="color:red">
        @foreach (var item in ExampleList)
        {
            <li>@item</li>
        }
    </ul>
}

@code {
    [Parameter]
    public IEnumerable<TExample>? ExampleList { get; set; }
}
```

### Explicit generic types based on ancestor components

The demonstration in this section cascades a type explicitly for `TExample`.

> [!NOTE]
> This section uses the two `ListDisplay` components in the [Cascaded generic type support](#cascaded-generic-type-support) section.

The following `ListGenericTypeItems2` component receives data and cascades a generic type parameter named `TExample` to its descendent components. In the upcoming parent component, the `ListGenericTypeItems2` component is used to display list data with the preceding `ListDisplay` component.

`ListGenericTypeItems2.razor`:

```razor
@attribute [CascadingTypeParameter(nameof(TExample))]
@typeparam TExample

<h2>List Generic Type Items 2</h2>

@ChildContent

@code {
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
```

The following parent component sets the child content (<xref:Microsoft.AspNetCore.Components.RenderFragment>) of two `ListGenericTypeItems2` components specifying the `ListGenericTypeItems2` types (`TExample`), which are cascaded to child components. `ListDisplay` components are rendered with the list item data shown in the example. String data is used with the first `ListGenericTypeItems2` component, and integer data is used with the second `ListGenericTypeItems2` component.

`GenericType2.razor`:

```razor
@page "/generic-type-2"

<h1>Generic Type Example 2</h1>

<ListGenericTypeItems2 TExample="string">
    <ListDisplay1 ExampleList="@(new List<string> { "Item 1", "Item 2" })" />
    <ListDisplay2 ExampleList="@(new List<string> { "Item 3", "Item 4" })" />
</ListGenericTypeItems2>

<ListGenericTypeItems2 TExample="int">
    <ListDisplay1 ExampleList="@(new List<int> { 1, 2, 3 })" />
    <ListDisplay2 ExampleList="@(new List<int> { 4, 5, 6 })" />
</ListGenericTypeItems2>
```

Specifying the type explicitly also allows the use of [cascading values and parameters](xref:blazor/components/cascading-values-and-parameters) to provide data to child components, as the following demonstration shows.

`ListDisplay3.razor`:

```razor
@typeparam TExample

@if (ExampleList is not null)
{
    <ul style="color:blue">
        @foreach (var item in ExampleList)
        {
            <li>@item</li>
        }
    </ul>
}

@code {
    [CascadingParameter]
    protected IEnumerable<TExample>? ExampleList { get; set; }
}
```

`ListDisplay4.razor`:

```razor
@typeparam TExample

@if (ExampleList is not null)
{
    <ul style="color:red">
        @foreach (var item in ExampleList)
        {
            <li>@item</li>
        }
    </ul>
}

@code {
    [CascadingParameter]
    protected IEnumerable<TExample>? ExampleList { get; set; }
}
```

`ListGenericTypeItems3.razor`:

```razor
@attribute [CascadingTypeParameter(nameof(TExample))]
@typeparam TExample

<h2>List Generic Type Items 3</h2>

@ChildContent

@if (ExampleList is not null)
{
    <ul style="color:green">
        @foreach(var item in ExampleList)
        {
            <li>@item</li>
        }
    </ul>

    <p>
        Type of <code>TExample</code>: @typeof(TExample)
    </p>
}

@code {
    [CascadingParameter]
    protected IEnumerable<TExample>? ExampleList { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
```

When cascading the data in the following example, the type must be provided to the component.

`GenericType3.razor`:

```razor
@page "/generic-type-3"

<h1>Generic Type Example 3</h1>

<CascadingValue Value="@stringData">
    <ListGenericTypeItems3 TExample="string">
        <ListDisplay3 />
        <ListDisplay4 />
    </ListGenericTypeItems3>
</CascadingValue>

<CascadingValue Value="@integerData">
    <ListGenericTypeItems3 TExample="int">
        <ListDisplay3 />
        <ListDisplay4 />
    </ListGenericTypeItems3>
</CascadingValue>

@code {
    private List<string> stringData = new() { "Item 1", "Item 2" };
    private List<int> integerData = new() { 1, 2, 3 };
}
```

When multiple generic types are cascaded, values for all generic types in the set must be passed. In the following example, `TItem`, `TValue`, and `TEdit` are `GridColumn` generic types, but the parent component that places `GridColumn` doesn't specify the `TItem` type:

```razor
<GridColumn TValue="string" TEdit="@TextEdit" />
```

The preceding example generates a compile-time error that the `GridColumn` component is missing the `TItem` type parameter. Valid code specifies all of the types:

```razor
<GridColumn TValue="string" TEdit="@TextEdit" TItem="@User" />
```

### Infer generic types based on ancestor components

The demonstration in this section cascades a type inferred for `TExample`.

> [!NOTE]
> This section uses the two `ListDisplay` components in the [Cascaded generic type support](#cascaded-generic-type-support) section.

`ListGenericTypeItems4.razor`:

```razor
@attribute [CascadingTypeParameter(nameof(TExample))]
@typeparam TExample

<h2>List Generic Type Items 4</h2>

@ChildContent

@if (ExampleList is not null)
{
    <ul style="color:green">
        @foreach(var item in ExampleList)
        {
            <li>@item</li>
        }
    </ul>

    <p>
        Type of <code>TExample</code>: @typeof(TExample)
    </p>
}

@code {
    [Parameter]
    public IEnumerable<TExample>? ExampleList { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
```

The following component with inferred cascaded types provides different data for display.

`GenericType4.razor`:

```razor
@page "/generic-type-4"

<h1>Generic Type Example 4</h1>

<ListGenericTypeItems4 ExampleList="@(new List<string> { "Item 5", "Item 6" })">
    <ListDisplay1 ExampleList="@(new List<string> { "Item 1", "Item 2" })" />
    <ListDisplay2 ExampleList="@(new List<string> { "Item 3", "Item 4" })" />
</ListGenericTypeItems4>

<ListGenericTypeItems4 ExampleList="@(new List<int> { 7, 8, 9 })">
    <ListDisplay1 ExampleList="@(new List<int> { 1, 2, 3 })" />
    <ListDisplay2 ExampleList="@(new List<int> { 4, 5, 6 })" />
</ListGenericTypeItems4>
```

The following component with inferred cascaded types provides the same data for display. The following example directly assigns the data to the components.

`GenericType5.razor`:

```razor
@page "/generic-type-5"

<h1>Generic Type Example 5</h1>

<ListGenericTypeItems4 ExampleList="@stringData">
    <ListDisplay1 ExampleList="@stringData" />
    <ListDisplay2 ExampleList="@stringData" />
</ListGenericTypeItems4>

<ListGenericTypeItems4 ExampleList="@integerData">
    <ListDisplay1 ExampleList="@integerData" />
    <ListDisplay2 ExampleList="@integerData" />
</ListGenericTypeItems4>

@code {
    private List<string> stringData = new() { "Item 1", "Item 2" };
    private List<int> integerData = new() { 1, 2, 3 };
}
```

:::moniker-end
