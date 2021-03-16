---
title: ASP.NET Core Blazor templated components
author: guardrex
description: Learn how templated components can accept one or more UI templates as parameters, which can then be used as part of the component's rendering logic.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 03/04/2021
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/components/templated-components
---
# ASP.NET Core Blazor templated components

Templated components are components that accept one or more UI templates as parameters, which can then be used as part of the component's rendering logic. Templated components allow you to author higher-level components that are more reusable than regular components. A couple of examples include:

* A table component that allows a user to specify templates for the table's header, rows, and footer.
* A list component that allows a user to specify a template for rendering items in a list.

A templated component is defined by specifying one or more component parameters of type <xref:Microsoft.AspNetCore.Components.RenderFragment> or <xref:Microsoft.AspNetCore.Components.RenderFragment%601>. A render fragment represents a segment of UI to render. <xref:Microsoft.AspNetCore.Components.RenderFragment%601> takes a type parameter that can be specified when the render fragment is invoked.

Often, templated components are generically typed, as the following `TableTemplate` component demonstrates. The generic type `<T>` in this example is used to render `IReadOnlyList<T>` values, which in this case is a series of pet rows in a component that displays a table of pets.

`Shared/TableTemplate.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Shared/templated-components/TableTemplate.razor)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/3.x/BlazorSample_WebAssembly/Shared/templated-components/TableTemplate.razor)]

::: moniker-end

When using a templated component, the template parameters can be specified using child elements that match the names of the parameters. In the following example, `<TableHeader>...</TableHeader>` and `<RowTemplate>...<RowTemplate>` supply <xref:Microsoft.AspNetCore.Components.RenderFragment%601> templates for `TableHeader` and `RowTemplate` of the `TableTemplate` component.

Specify the `Context` attribute on the component element when you want to specify the content parameter name for implicit child content (without any wrapping child element). In the following example, the `Context` attribute appears on the `TableTemplate` element and applies to all <xref:Microsoft.AspNetCore.Components.RenderFragment%601> template parameters.

`Pages/Pets.razor`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/templated-components/Pets1.razor)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/templated-components/Pets1.razor)]

::: moniker-end

Alternatively, you can change the parameter name using the `Context` attribute on the <xref:Microsoft.AspNetCore.Components.RenderFragment%601> child element. In the following example, the `Context` is set on `RowTemplate` rather than `TableTemplate`:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/templated-components/Pets2.razor?name=snippet&highlight=6)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/templated-components/Pets2.razor?name=snippet&highlight=6)]

::: moniker-end

Component arguments of type <xref:Microsoft.AspNetCore.Components.RenderFragment%601> have an implicit parameter named `context`, which can be used. In the following example, `Context` isn't set. `@context.{PROPERTY}` supplies pet values to the template, where `{PROPERTY}` is a `Pet` property:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/templated-components/Pets3.razor?name=snippet&highlight=7-8)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/templated-components/Pets3.razor?name=snippet&highlight=7-8)]

::: moniker-end

When using generic-typed components, the type parameter is inferred if possible. However, you can explicitly specify the type with an attribute that has a name matching the type parameter, which is `TItem` in the preceding example:

::: moniker range=">= aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/templated-components/Pets4.razor?name=snippet&highlight=1)]

::: moniker-end

::: moniker range="< aspnetcore-5.0"

[!code-razor[](~/blazor/common/samples/5.x/BlazorSample_WebAssembly/Pages/templated-components/Pets4.razor?name=snippet&highlight=1)]

::: moniker-end

## Infer generic types based on ancestor components

::: moniker range=">= aspnetcore-5.0"

Ancestor components must opt in to this behavior. An ancestor component can cascade a type parameter by name to descendants using the `CascadingTypeParameter` attribute. This attribute allows a generic type inference to use the specified type parameter automatically with descendants that have a type parameter with the same name.

For example, define `Grid` and `Column` components.

`Shared/Grid.razor`:

```razor
@typeparam TItem
@attribute [CascadingTypeParameter(nameof(TItem))]

<table class="table">
    <thead>
        <tr>
            @ChildContent
        </tr>
    </thead>
    <tbody>
        @foreach (var item in Items)
        {
            <tr>
                <td>@item.Name</td>
                <td>@item.Quantity</td>
            </tr>
        }
    </tbody>
</table>

@code {
    [Parameter]
    public IEnumerable<TItem> Items { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }
}
```

`Shared/Column.razor`:

```razor
@typeparam TItem

<th>@Title</th>

@code {
    [Parameter]
    public string Title { get; set; }
}
```

Use the `Grid` and `Column` components.

`Pages/GenericCascadedType.razor`:

```razor
@page "/generic-cascaded-type"

<Grid Items="@GetSaleRecords()">
    <Column Title="Product name" />
    <Column Title="Number of sales" />
</Grid>

@code {
    private IEnumerable<SaleRecord> GetSaleRecords()
    {
        return new List<SaleRecord>()
            {
                new SaleRecord() { Name = "Product 1", Quantity = 100 },
                new SaleRecord() { Name = "Product 2", Quantity = 200 },
                new SaleRecord() { Name = "Product 3", Quantity = 50 },
            };
    }

    private class SaleRecord
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
    }
}
```

> [!NOTE]
> The Razor support in Visual Studio Code has not yet been updated to support this feature, so you may get incorrect errors even though the project correctly builds. This will be addressed in an upcoming tooling release.

::: moniker-end

::: moniker range="< aspnetcore-5.0"

> [!NOTE]
> Generic type constraints are supported in ASP.NET Core 6.0. For more information, see [the 6.0 version of this article](?view=aspnetcore-6.0).

::: moniker-end

## Additional resources

* <xref:blazor/webassembly-performance-best-practices#define-reusable-renderfragments-in-code>
