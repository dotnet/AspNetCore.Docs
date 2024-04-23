---
title: ASP.NET Core Blazor templated components
author: guardrex
description: Learn how templated components can accept one or more UI templates as parameters, which can then be used as part of the component's rendering logic.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 02/09/2024
uid: blazor/components/templated-components
---
# ASP.NET Core Blazor templated components

[!INCLUDE[](~/includes/not-latest-version.md)]

By [Robert Haken](https://havit.blazor.eu)

This article explains how templated components can accept one or more UI templates as parameters, which can then be used as part of the component's rendering logic.

## Templated components

Templated components are components that receive one or more UI templates as parameters, which can be utilized in the rendering logic of the component. By using templated components, you can create higher-level components that are more reusable. Examples include:

* A table component that allows a user to specify templates for the table's header, rows, and footer.
* A list component that allows a user to specify a template for rendering items in a list.
* A navigation bar component that allows a user to specify a template for start content and navigation links.

A templated component is defined by specifying one or more component parameters of type <xref:Microsoft.AspNetCore.Components.RenderFragment> or <xref:Microsoft.AspNetCore.Components.RenderFragment%601>. A render fragment represents a segment of UI to render. <xref:Microsoft.AspNetCore.Components.RenderFragment%601> takes a type parameter that can be specified when the render fragment is invoked.

> [!NOTE]
> For more information on <xref:Microsoft.AspNetCore.Components.RenderFragment>, see <xref:blazor/components/index#child-content-render-fragments>.

Often, templated components are generically typed, as the following `TemplatedNavBar` component (`TemplatedNavBar.razor`) demonstrates. The generic type (`<T>`) in the following example is used to render <xref:System.Collections.Generic.IReadOnlyList%601> values, which in this case is a list of pets for a component that displays a navigation bar with links to a pet detail component.

`TemplatedNavBar.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/TemplatedNavBar.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/templated-components/TemplatedNavBar.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/templated-components/TemplatedNavBar.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/templated-components/TemplatedNavBar.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/templated-components/TemplatedNavBar.razor":::

:::moniker-end

When using a templated component, the template parameters can be specified using child elements that match the names of the parameters. In the following example, `<StartContent>...</StartContent>` and `<ItemTemplate>...</ItemTemplate>` supply <xref:Microsoft.AspNetCore.Components.RenderFragment%601> templates for `StartContent` and `ItemTemplate` of the `TemplatedNavBar` component.

Specify the `Context` attribute on the component element when you want to specify the content parameter name for implicit child content (without any wrapping child element). In the following example, the `Context` attribute appears on the `TemplatedNavBar` element and applies to all <xref:Microsoft.AspNetCore.Components.RenderFragment%601> template parameters.

`Pets1.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Pets1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/templated-components/Pets1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/templated-components/Pets1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/templated-components/Pets1.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/templated-components/Pets1.razor":::

:::moniker-end

Alternatively, you can change the parameter name using the `Context` attribute on the <xref:Microsoft.AspNetCore.Components.RenderFragment%601> child element. In the following example, the `Context` is set on `ItemTemplate` rather than `TemplatedNavBar`.

`Pets2.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Pets2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/templated-components/Pets2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/templated-components/Pets2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/templated-components/Pets2.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/templated-components/Pets2.razor":::

:::moniker-end

Component arguments of type <xref:Microsoft.AspNetCore.Components.RenderFragment%601> have an implicit parameter named `context`, which can be used. In the following example, `Context` isn't set. `@context.{PROPERTY}` supplies pet values to the template, where `{PROPERTY}` is a `Pet` property:

`Pets3.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Pets3.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/templated-components/Pets3.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/templated-components/Pets3.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/templated-components/Pets3.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/templated-components/Pets3.razor":::

:::moniker-end

When using generic-typed components, the type parameter is inferred if possible. However, you can explicitly specify the type with an attribute that has a name matching the type parameter, which is `TItem` in the preceding example:

`Pets4.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Pets4.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/templated-components/Pets4.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/templated-components/Pets4.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/templated-components/Pets4.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/templated-components/Pets4.razor":::

:::moniker-end

The example provided in the `TemplatedNavBar` component (`TemplatedNavBar.razor`) assumes that the `Items` collection doesn't change after the initial render; or that if it does change, maintaining the state of components/elements used in `ItemTemplate` isn't necessary. For templated components where such usage can't be anticipated, see the [Preserve relationships with `@key`](#preserve-relationships-with-key) section.

## Preserve relationships with `@key`

Templated components are often used to render collections of items, such as tables or lists. In such general scenarios, we can't assume that the user will avoid stateful components/elements in the item template definition or that there won't be additional changes to the `Items` collection. For such templated components, it's necessary to preserve the relationships with the `@key` directive attribute.

> [!NOTE]
> For more information on the `@key` directive attribute, see <xref:blazor/components/key>.

The following `TableTemplate` component (`TableTemplate.razor`) demonstrates a templated component that preserves relationships with `@key`.

`TableTemplate.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/TableTemplate.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/templated-components/TableTemplate.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/templated-components/TableTemplate.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/templated-components/TableTemplate.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/templated-components/TableTemplate.razor":::

:::moniker-end

Consider the following `Pets5` component (`Pets5.razor`), which demonstrates the importance of keying data to preserve model relationships. In the component, each iteration of adding a pet in [`OnAfterRenderAsync`](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync) results in Blazor rerendering the `TableTemplate` component.

`Pets5.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Pets5.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/templated-components/Pets5.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/templated-components/Pets5.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/templated-components/Pets5.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/templated-components/Pets5.razor":::

:::moniker-end

This demonstration allows you to:

* Select an `<input>` from among several rendered table rows.
* Study the behavior of the page's focus as the pets collection automatically grows.

Without using the `@key` directive attribute in the `TableTemplate` component, the page's focus remains on the same index position (row) of the table, causing the focus to shift each time a pet is added. To demonstrate this, remove the `@key` directive attribute and value, restart the app, and attempt to modify a field value as items are added.

## Additional resources

* <xref:blazor/performance#define-reusable-renderfragments-in-code>
* <xref:blazor/components/key>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples) ([how to download](xref:blazor/fundamentals/index#sample-apps))
