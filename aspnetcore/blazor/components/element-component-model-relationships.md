---
title: Retain element, component, and model relationships in ASP.NET Core Blazor
author: guardrex
description: Learn how to use the @key directive attribute to retain element, component, and model relationships when rendering and the elements or components subsequently change.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/14/2023
uid: blazor/components/key
---
# Retain element, component, and model relationships in ASP.NET Core Blazor

This article explains how to use the `@key` directive attribute to retain element, component, and model relationships when rendering and the elements or components subsequently change.

[!INCLUDE[](~/blazor/includes/location-client-and-server-pre-net8.md)]

## Use of the `@key` directive attribute

When rendering a list of elements or components and the elements or components subsequently change, Blazor must decide which of the previous elements or components are retained and how model objects should map to them. Normally, this process is automatic and sufficient for general rendering, but there are often cases where controlling the process using the [`@key`](xref:mvc/views/razor#key) directive attribute is required.

Consider the following example that demonstrates a collection mapping problem that's solved by using [`@key`](xref:mvc/views/razor#key).

For the following components:

* The `Details` component receives data (`Data`) from the parent component, which is displayed in an `<input>` element. Any given displayed `<input>` element can receive the focus of the page from the user when they select one of the `<input>` elements.
* The parent component creates a list of person objects for display using the `Details` component. Every three seconds, a new person is added to the collection.

This demonstration allows you to:

* Select an `<input>` from among several rendered `Details` components.
* Study the behavior of the page's focus as the people collection automatically grows.

`Details.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Details.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/element-component-model-relationships/Details.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/element-component-model-relationships/Details.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/element-component-model-relationships/Details.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/element-component-model-relationships/Details.razor":::

:::moniker-end

In the following parent component, each iteration of adding a person in `OnTimerCallback` results in Blazor rebuilding the entire collection. The page's focus remains on the *same index* position of `<input>` elements, so the focus shifts each time a person is added. *Shifting the focus away from what the user selected isn't desirable behavior.* After demonstrating the poor behavior with the following component, the [`@key`](xref:mvc/views/razor#key) directive attribute is used to improve the user's experience.

:::moniker range=">= aspnetcore-8.0"

`People.razor`:

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/People.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

`PeopleExample.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/element-component-model-relationships/PeopleExample.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

`PeopleExample.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/element-component-model-relationships/PeopleExample.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

`PeopleExample.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/element-component-model-relationships/PeopleExample.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

`PeopleExample.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/element-component-model-relationships/PeopleExample.razor":::

:::moniker-end

The contents of the `people` collection changes with inserted, deleted, or re-ordered entries. Rerendering can lead to visible behavior differences. For example, each time a person is inserted into the `people` collection, the user's focus is lost.

The mapping process of elements or components to a collection can be controlled with the [`@key`](xref:mvc/views/razor#key) directive attribute. Use of [`@key`](xref:mvc/views/razor#key) guarantees the preservation of elements or components based on the key's value. If the `Details` component in the preceding example is keyed on the `person` item, Blazor ignores rerendering `Details` components that haven't changed.

To modify the parent component to use the [`@key`](xref:mvc/views/razor#key) directive attribute with the `people` collection, update the `<Details>` element to the following:

```razor
<Details @key="person" Data="@person.Data" />
```

When the `people` collection changes, the association between `Details` instances and `person` instances is retained. When a `Person` is inserted at the beginning of the collection, one new `Details` instance is inserted at that corresponding position. Other instances are left unchanged. Therefore, the user's focus isn't lost as people are added to the collection.

Other collection updates exhibit the same behavior when the [`@key`](xref:mvc/views/razor#key) directive attribute is used:

* If an instance is deleted from the collection, only the corresponding component instance is removed from the UI. Other instances are left unchanged.
* If collection entries are re-ordered, the corresponding component instances are preserved and re-ordered in the UI.

> [!IMPORTANT]
> Keys are local to each container element or component. Keys aren't compared globally across the document.

## When to use `@key`

Typically, it makes sense to use [`@key`](xref:mvc/views/razor#key) whenever a list is rendered (for example, in a [`foreach`](/dotnet/csharp/language-reference/keywords/foreach-in) block) and a suitable value exists to define the [`@key`](xref:mvc/views/razor#key).

You can also use [`@key`](xref:mvc/views/razor#key) to preserve an element or component subtree when an object doesn't change, as the following examples show.

Example 1:

```razor
<li @key="person">
    <input value="@person.Data" />
</li>
```

Example 2:

```razor
<div @key="person">
    @* other HTML elements *@
</div>
```

If an `person` instance changes, the [`@key`](xref:mvc/views/razor#key) attribute directive forces Blazor to:

* Discard the entire `<li>` or `<div>` and their descendants.
* Rebuild the subtree within the UI with new elements and components.

This is useful to guarantee that no UI state is preserved when the collection changes within a subtree.

## Scope of `@key`

The [`@key`](xref:mvc/views/razor#key) attribute directive is scoped to its own siblings within its parent.

Consider the following example. The `first` and `second` keys are compared against each other within the same scope of the outer `<div>` element:

```razor
<div>
    <div @key="first">...</div>
    <div @key="second">...</div>
</div>
```

The following example demonstrates `first` and `second` keys in their own scopes, unrelated to each other and without influence on each other. Each [`@key`](xref:mvc/views/razor#key) scope only applies to its parent `<div>` element, not across the parent `<div>` elements:

```razor
<div>
    <div @key="first">...</div>
</div>
<div>
    <div @key="second">...</div>
</div>
```

For the `Details` component shown earlier, the following examples render `person` data within the same [`@key`](xref:mvc/views/razor#key) scope and demonstrate typical use cases for [`@key`](xref:mvc/views/razor#key):

```razor
<div>
    @foreach (var person in people)
    {
        <Details @key="person" Data="@person.Data" />
    }
</div>
```

```razor
@foreach (var person in people)
{
    <div @key="person">
        <Details Data="@person.Data" />
    </div>
}
```

```razor
<ol>
    @foreach (var person in people)
    {
        <li @key="person">
            <Details Data="@person.Data" />
        </li>
    }
</ol>
```

The following examples only scope [`@key`](xref:mvc/views/razor#key) to the `<div>` or `<li>` element that surrounds each `Details` component instance. Therefore, `person` data for each member of the `people` collection is **not** keyed on each `person` instance across the rendered `Details` components. Avoid the following patterns when using [`@key`](xref:mvc/views/razor#key):

```razor
@foreach (var person in people)
{
    <div>
        <Details @key="person" Data="@person.Data" />
    </div>
}
```

```razor
<ol>
    @foreach (var person in people)
    {
        <li>
            <Details @key="person" Data="@person.Data" />
        </li>
    }
</ol>
```

## When not to use `@key`

There's a performance cost when rendering with [`@key`](xref:mvc/views/razor#key). The performance cost isn't large, but only specify [`@key`](xref:mvc/views/razor#key) if preserving the element or component benefits the app.

Even if [`@key`](xref:mvc/views/razor#key) isn't used, Blazor preserves child element and component instances as much as possible. The only advantage to using [`@key`](xref:mvc/views/razor#key) is control over *how* model instances are mapped to the preserved component instances, instead of Blazor selecting the mapping.

## Values to use for `@key`

Generally, it makes sense to supply one of the following values for [`@key`](xref:mvc/views/razor#key):

* Model object instances. For example, the `Person` instance (`person`) was used in the earlier example. This ensures preservation based on object reference equality.
* Unique identifiers. For example, unique identifiers can be based on primary key values of type `int`, `string`, or `Guid`.

Ensure that values used for [`@key`](xref:mvc/views/razor#key) don't clash. If clashing values are detected within the same parent element, Blazor throws an exception because it can't deterministically map old elements or components to new elements or components. Only use distinct values, such as object instances or primary key values.
