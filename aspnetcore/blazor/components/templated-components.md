---
title: ASP.NET Core Blazor templated components
author: guardrex
description: Learn how templated components can accept one or more UI templates as parameters, which can then be used as part of the component's rendering logic.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/components/templated-components
---
# ASP.NET Core Blazor templated components

[!INCLUDE[](~/includes/not-latest-version.md)]

Templated components are components that receive one or more UI templates as parameters, which can be utilized in the rendering logic of the component. By using templated components, you can create higher-level components that are more reusable. A couple of examples include:

* A table component that allows a user to specify templates for the table's header, rows, and footer.
* A list component that allows a user to specify a template for rendering items in a list.

A templated component is defined by specifying one or more component parameters of type <xref:Microsoft.AspNetCore.Components.RenderFragment> or <xref:Microsoft.AspNetCore.Components.RenderFragment%601>. A render fragment represents a segment of UI to render. <xref:Microsoft.AspNetCore.Components.RenderFragment%601> takes a type parameter that can be specified when the render fragment is invoked.

> [!NOTE]
> For more information on <xref:Microsoft.AspNetCore.Components.RenderFragment>, see <xref:blazor/components/index#child-content-render-fragments>.

Often, templated components are generically typed, as the following `TableTemplate` component demonstrates. The generic type `<T>` in this example is used to render `IReadOnlyList<T>` values, which in this case is a series of pet rows in a component that displays a table of pets.

`TableTemplate.razor`:

:::moniker range=">= aspnetcore-7.0"

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

When using a templated component, the template parameters can be specified using child elements that match the names of the parameters. In the following example, `<TableHeader>...</TableHeader>` and `<RowTemplate>...<RowTemplate>` supply <xref:Microsoft.AspNetCore.Components.RenderFragment%601> templates for `TableHeader` and `RowTemplate` of the `TableTemplate` component.

Specify the `Context` attribute on the component element when you want to specify the content parameter name for implicit child content (without any wrapping child element). In the following example, the `Context` attribute appears on the `TableTemplate` element and applies to all <xref:Microsoft.AspNetCore.Components.RenderFragment%601> template parameters.

`Pets1.razor`:

:::moniker range=">= aspnetcore-7.0"

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

Alternatively, you can change the parameter name using the `Context` attribute on the <xref:Microsoft.AspNetCore.Components.RenderFragment%601> child element. In the following example, the `Context` is set on `RowTemplate` rather than `TableTemplate`:

`Pets2.razor`:

:::moniker range=">= aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/templated-components/Pets2.razor" highlight="10":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/templated-components/Pets2.razor" highlight="10":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/templated-components/Pets2.razor" highlight="10":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/templated-components/Pets2.razor" highlight="10":::

:::moniker-end

Component arguments of type <xref:Microsoft.AspNetCore.Components.RenderFragment%601> have an implicit parameter named `context`, which can be used. In the following example, `Context` isn't set. `@context.{PROPERTY}` supplies pet values to the template, where `{PROPERTY}` is a `Pet` property:

`Pets3.razor`:

:::moniker range=">= aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/templated-components/Pets3.razor" highlight="11-12":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/templated-components/Pets3.razor" highlight="11-12":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/templated-components/Pets3.razor" highlight="11-12":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/templated-components/Pets3.razor" highlight="11-12":::

:::moniker-end

When using generic-typed components, the type parameter is inferred if possible. However, you can explicitly specify the type with an attribute that has a name matching the type parameter, which is `TItem` in the preceding example:

`Pets4.razor`:

:::moniker range=">= aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/templated-components/Pets4.razor" highlight="5":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/templated-components/Pets4.razor" highlight="5":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/templated-components/Pets4.razor" highlight="5":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/templated-components/Pets4.razor" highlight="5":::

:::moniker-end

## Additional resources

* <xref:blazor/performance#define-reusable-renderfragments-in-code>
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)
