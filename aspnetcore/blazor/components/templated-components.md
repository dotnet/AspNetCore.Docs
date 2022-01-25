---
title: ASP.NET Core Blazor templated components
author: guardrex
description: Learn how templated components can accept one or more UI templates as parameters, which can then be used as part of the component's rendering logic.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/components/templated-components
---
# ASP.NET Core Blazor templated components

:::moniker range=">= aspnetcore-6.0"

Templated components are components that accept one or more UI templates as parameters, which can then be used as part of the component's rendering logic. Templated components allow you to author higher-level components that are more reusable than regular components. A couple of examples include:

* A table component that allows a user to specify templates for the table's header, rows, and footer.
* A list component that allows a user to specify a template for rendering items in a list.

A templated component is defined by specifying one or more component parameters of type <xref:Microsoft.AspNetCore.Components.RenderFragment> or <xref:Microsoft.AspNetCore.Components.RenderFragment%601>. A render fragment represents a segment of UI to render. <xref:Microsoft.AspNetCore.Components.RenderFragment%601> takes a type parameter that can be specified when the render fragment is invoked.

Often, templated components are generically typed, as the following `TableTemplate` component demonstrates. The generic type `<T>` in this example is used to render `IReadOnlyList<T>` values, which in this case is a series of pet rows in a component that displays a table of pets.

`Shared/TableTemplate.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/templated-components/TableTemplate.razor)]

When using a templated component, the template parameters can be specified using child elements that match the names of the parameters. In the following example, `<TableHeader>...</TableHeader>` and `<RowTemplate>...<RowTemplate>` supply <xref:Microsoft.AspNetCore.Components.RenderFragment%601> templates for `TableHeader` and `RowTemplate` of the `TableTemplate` component.

Specify the `Context` attribute on the component element when you want to specify the content parameter name for implicit child content (without any wrapping child element). In the following example, the `Context` attribute appears on the `TableTemplate` element and applies to all <xref:Microsoft.AspNetCore.Components.RenderFragment%601> template parameters.

`Pages/Pets1.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/templated-components/Pets1.razor)]

Alternatively, you can change the parameter name using the `Context` attribute on the <xref:Microsoft.AspNetCore.Components.RenderFragment%601> child element. In the following example, the `Context` is set on `RowTemplate` rather than `TableTemplate`:

`Pages/Pets2.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/templated-components/Pets2.razor?highlight=10)]

Component arguments of type <xref:Microsoft.AspNetCore.Components.RenderFragment%601> have an implicit parameter named `context`, which can be used. In the following example, `Context` isn't set. `@context.{PROPERTY}` supplies pet values to the template, where `{PROPERTY}` is a `Pet` property:

`Pages/Pets3.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/templated-components/Pets3.razor?highlight=11-12)]

When using generic-typed components, the type parameter is inferred if possible. However, you can explicitly specify the type with an attribute that has a name matching the type parameter, which is `TItem` in the preceding example:

`Pages/Pets4.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/templated-components/Pets4.razor?highlight=5)]

## Infer generic types based on ancestor components

An ancestor component can cascade a type parameter by name to descendants using the [`[CascadingTypeParameter]` attribute](xref:Microsoft.AspNetCore.Components.CascadingTypeParameterAttribute). This attribute allows a generic type inference to use the specified type parameter automatically with descendants that have a type parameter with the same name.

The following shared `ListDisplay` component is used in the upcoming demonstration of cascading types. The component receives and renders list data and is generically typed as `TExample`.

`Shared/ListDisplay.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/templated-components/ListDisplay.razor)]

> [!NOTE]
> The examples in this section have names that include the number "2" in order to avoid name conflicts with the example shown in <xref:blazor/components/index#generic-type-parameter-support>. You can place both examples into the same local test app for experimentation.

The following `ListGenericTypeItems2` component receives data and cascades a generic type parameter named `TExample` to its descendent components. In the upcoming parent component, the `ListGenericTypeItems2` component is used to display list data with the preceding `ListDisplay` component.

Although the `ListGenericTypeItems2` component is used in this demonstration with only one "list item" child component (the `ListDisplay` component), the `ListGenericTypeItems2` component can display any `TExample` generically-typed "list item" component. An app can have several shared "list display" components used for different data display purposes.

`Shared/ListGenericTypeItems2.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/templated-components/ListGenericTypeItems2.razor)]

The following `GenericTypeExample2` parent component sets the child content (<xref:Microsoft.AspNetCore.Components.RenderFragment>) of two `ListGenericTypeItems2` components specifying the `ListGenericTypeItems2` types (`TExample`), which are cascaded to child components. `ListDisplay` components are rendered with the list item data shown in the example. String data is used with the first `ListGenericTypeItems2` component, and integer data is used with the second `ListGenericTypeItems2` component.

As previously mentioned, the parent component in this example isn't limited to using a single "list item" display component. Any shared child component can be rendered using the cascaded type if they use the same generic type name ("`TExample`").

`Pages/GenericTypeExample2.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/templated-components/GenericTypeExample2.razor)]

By adding `@attribute [CascadingTypeParameter(...)]` to a component, the specified generic type argument is automatically used by descendants that:

* Are nested as child content for the component in the same `.razor` document.
* Also declare a [`@typeparam`](xref:mvc/views/razor#typeparam) with the exact same name.
* Don't have another value supplied or inferred for the type parameter. If another value is supplied or inferred, it takes precedence over the cascaded generic type.

When receiving a cascaded type parameter, components obtain the parameter value from the closest ancestor that has a <xref:Microsoft.AspNetCore.Components.CascadingTypeParameterAttribute> with a matching name. Cascaded generic type parameters are overridden within a particular subtree.

Matching is only performed by name. Therefore, we recommend avoiding a cascaded generic type parameter with a generic name, for example `T` or `TItem`. If a developer opts into cascading a type parameter, they're implicitly promising that its name is unique enough not to clash with other cascaded type parameters from unrelated components.

Generic types with [`where`](/dotnet/csharp/language-reference/keywords/where-generic-type-constraint) type constraints are supported:

```razor
@typeparam TEntity where TEntity : IEntity
```

For more information, see the following articles:

* <xref:mvc/views/razor#typeparam>
* <xref:blazor/components/index#generic-type-parameter-support>

## Additional resources

* <xref:blazor/performance#define-reusable-renderfragments-in-code>

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

Templated components are components that accept one or more UI templates as parameters, which can then be used as part of the component's rendering logic. Templated components allow you to author higher-level components that are more reusable than regular components. A couple of examples include:

* A table component that allows a user to specify templates for the table's header, rows, and footer.
* A list component that allows a user to specify a template for rendering items in a list.

A templated component is defined by specifying one or more component parameters of type <xref:Microsoft.AspNetCore.Components.RenderFragment> or <xref:Microsoft.AspNetCore.Components.RenderFragment%601>. A render fragment represents a segment of UI to render. <xref:Microsoft.AspNetCore.Components.RenderFragment%601> takes a type parameter that can be specified when the render fragment is invoked.

Often, templated components are generically typed, as the following `TableTemplate` component demonstrates. The generic type `<T>` in this example is used to render `IReadOnlyList<T>` values, which in this case is a series of pet rows in a component that displays a table of pets.

`Shared/TableTemplate.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Shared/templated-components/TableTemplate.razor)]

When using a templated component, the template parameters can be specified using child elements that match the names of the parameters. In the following example, `<TableHeader>...</TableHeader>` and `<RowTemplate>...<RowTemplate>` supply <xref:Microsoft.AspNetCore.Components.RenderFragment%601> templates for `TableHeader` and `RowTemplate` of the `TableTemplate` component.

Specify the `Context` attribute on the component element when you want to specify the content parameter name for implicit child content (without any wrapping child element). In the following example, the `Context` attribute appears on the `TableTemplate` element and applies to all <xref:Microsoft.AspNetCore.Components.RenderFragment%601> template parameters.

`Pages/Pets1.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/templated-components/Pets1.razor)]

Alternatively, you can change the parameter name using the `Context` attribute on the <xref:Microsoft.AspNetCore.Components.RenderFragment%601> child element. In the following example, the `Context` is set on `RowTemplate` rather than `TableTemplate`:

`Pages/Pets2.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/templated-components/Pets2.razor?highlight=10)]

Component arguments of type <xref:Microsoft.AspNetCore.Components.RenderFragment%601> have an implicit parameter named `context`, which can be used. In the following example, `Context` isn't set. `@context.{PROPERTY}` supplies pet values to the template, where `{PROPERTY}` is a `Pet` property:

`Pages/Pets3.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/templated-components/Pets3.razor?highlight=11-12)]

When using generic-typed components, the type parameter is inferred if possible. However, you can explicitly specify the type with an attribute that has a name matching the type parameter, which is `TItem` in the preceding example:

`Pages/Pets4.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/templated-components/Pets4.razor?highlight=5)]

## Additional resources

* <xref:blazor/performance#define-reusable-renderfragments-in-code>

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Templated components are components that accept one or more UI templates as parameters, which can then be used as part of the component's rendering logic. Templated components allow you to author higher-level components that are more reusable than regular components. A couple of examples include:

* A table component that allows a user to specify templates for the table's header, rows, and footer.
* A list component that allows a user to specify a template for rendering items in a list.

A templated component is defined by specifying one or more component parameters of type <xref:Microsoft.AspNetCore.Components.RenderFragment> or <xref:Microsoft.AspNetCore.Components.RenderFragment%601>. A render fragment represents a segment of UI to render. <xref:Microsoft.AspNetCore.Components.RenderFragment%601> takes a type parameter that can be specified when the render fragment is invoked.

Often, templated components are generically typed, as the following `TableTemplate` component demonstrates. The generic type `<T>` in this example is used to render `IReadOnlyList<T>` values, which in this case is a series of pet rows in a component that displays a table of pets.

`Shared/TableTemplate.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Shared/templated-components/TableTemplate.razor)]

When using a templated component, the template parameters can be specified using child elements that match the names of the parameters. In the following example, `<TableHeader>...</TableHeader>` and `<RowTemplate>...<RowTemplate>` supply <xref:Microsoft.AspNetCore.Components.RenderFragment%601> templates for `TableHeader` and `RowTemplate` of the `TableTemplate` component.

Specify the `Context` attribute on the component element when you want to specify the content parameter name for implicit child content (without any wrapping child element). In the following example, the `Context` attribute appears on the `TableTemplate` element and applies to all <xref:Microsoft.AspNetCore.Components.RenderFragment%601> template parameters.

`Pages/Pets1.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/templated-components/Pets1.razor)]

Alternatively, you can change the parameter name using the `Context` attribute on the <xref:Microsoft.AspNetCore.Components.RenderFragment%601> child element. In the following example, the `Context` is set on `RowTemplate` rather than `TableTemplate`:

`Pages/Pets2.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/templated-components/Pets2.razor?highlight=10)]

Component arguments of type <xref:Microsoft.AspNetCore.Components.RenderFragment%601> have an implicit parameter named `context`, which can be used. In the following example, `Context` isn't set. `@context.{PROPERTY}` supplies pet values to the template, where `{PROPERTY}` is a `Pet` property:

`Pages/Pets3.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/templated-components/Pets3.razor?highlight=11-12)]

When using generic-typed components, the type parameter is inferred if possible. However, you can explicitly specify the type with an attribute that has a name matching the type parameter, which is `TItem` in the preceding example:

`Pages/Pets4.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/templated-components/Pets4.razor?highlight=5)]

## Additional resources

* <xref:blazor/performance#define-reusable-renderfragments-in-code>

:::moniker-end
