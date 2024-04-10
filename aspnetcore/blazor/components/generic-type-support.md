---
title: ASP.NET Core Razor component generic type support
author: guardrex
description: Learn about generic type support in ASP.NET Core Razor components.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 04/10/2024
uid: blazor/components/generic-type-support
---
# ASP.NET Core Razor component generic type support

[!INCLUDE[](~/includes/not-latest-version.md)]

This article describes generic type support in Razor components.

If you're new to generic types, see [Generic classes and methods (C# Guide)](/dotnet/csharp/fundamentals/types/generics) for general guidance on the use of generics before reading this article.

The example code in this article is only available for the latest .NET release in the [Blazor sample apps](xref:blazor/fundamentals/index#sample-apps).

## Generic type parameter support

The [`@typeparam`](xref:mvc/views/razor#typeparam) directive declares a [generic type parameter](/dotnet/csharp/programming-guide/generics/generic-type-parameters) for the generated component class:

```razor
@typeparam TItem
```

C# syntax with [`where`](/dotnet/csharp/language-reference/keywords/where-generic-type-constraint) type constraints is supported:

```razor
@typeparam TEntity where TEntity : IEntity
```

In the following example, the `ListItems1` component is generically typed as `TExample`, which represents the type of the `ExampleList` collection.

`ListItems1.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/ListItems1.razor":::

The following component renders two `ListItems1` components:

* String or integer data is assigned to the `ExampleList` parameter of each component.
* Type `string` or `int` that matches the type of the assigned data is set for the type parameter (`TExample`) of each component.

`Generics1.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Generics1.razor":::

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

Generic types can be cascaded to child components with either of the following approaches for ancestor (parent) components, which are demonstrated in the following two sub-sections:

* Explicitly set the cascaded generic type.
* Infer the cascaded generic type.

The following subsections provide examples of the preceding approaches using the following `ListDisplay1` component. The component receives and renders list data generically typed as `TExample`. To make each instance of `ListDisplay1` stand out, an additional component parameter controls the color of the list.

`ListDisplay1.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/ListDisplay1.razor":::

### Explicit generic types based on ancestor components

The demonstration in this section cascades a type explicitly for `TExample`.

> [!NOTE]
> This section uses the preceding `ListDisplay1` component in the [Cascaded generic type support](#cascaded-generic-type-support) section.

The following `ListItems2` component receives data and cascades a generic type parameter named `TExample` to its descendent components. In the upcoming parent component, the `ListItems2` component is used to display list data with the preceding `ListDisplay1` component.

`ListItems2.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/ListItems2.razor":::

The following parent component sets the child content (<xref:Microsoft.AspNetCore.Components.RenderFragment>) of two `ListItems2` components specifying the `ListItems2` types (`TExample`), which are cascaded to child components. `ListDisplay1` components are rendered with the list item data shown in the example. String data is used with the first `ListItems2` component, and integer data is used with the second `ListItems2` component.

`Generics2.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Generics2.razor":::

Specifying the type explicitly also allows the use of [cascading values and parameters](xref:blazor/components/cascading-values-and-parameters) to provide data to child components, as the following demonstration shows.

`ListDisplay2.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/ListDisplay2.razor":::

`ListItems3.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/ListItems3.razor":::

When cascading the data in the following example, the type must be provided to the component.

`Generics3.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Generics3.razor":::

When multiple generic types are cascaded, values for all generic types in the set must be passed. In the following example, `TItem`, `TValue`, and `TEdit` are `GridColumn` generic types, but the parent component that places `GridColumn` doesn't specify the `TItem` type:

```razor
<GridColumn TValue="string" TEdit="TextEdit" />
```

The preceding example generates a compile-time error that the `GridColumn` component is missing the `TItem` type parameter. Valid code specifies all of the types:

```razor
<GridColumn TValue="string" TEdit="TextEdit" TItem="User" />
```

### Infer generic types based on ancestor components

The demonstration in this section cascades a type inferred for `TExample`.

> [!NOTE]
> This section uses the `ListDisplay` component in the [Cascaded generic type support](#cascaded-generic-type-support) section.

`ListItems4.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/ListItems4.razor":::

The following component with inferred cascaded types provides different data for display.

`Generics4.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Generics4.razor":::

The following component with inferred cascaded types provides the same data for display. The following example directly assigns the data to the components.

`Generics5.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Generics5.razor":::

:::moniker-end
