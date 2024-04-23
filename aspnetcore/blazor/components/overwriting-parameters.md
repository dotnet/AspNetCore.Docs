---
title: Avoid overwriting parameters in ASP.NET Core Blazor
author: guardrex
description: Learn how to avoid overwriting parameters in Blazor apps during rerendering.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 03/08/2024
uid: blazor/components/overwriting-parameters
---
# Avoid overwriting parameters in ASP.NET Core Blazor

[!INCLUDE[](~/includes/not-latest-version.md)]

By [Robert Haken](https://havit.blazor.eu)

This article explains how to avoid overwriting parameters in Blazor apps during rerendering.

## Overwritten parameters

The Blazor framework generally imposes safe parent-to-child parameter assignment:

* Parameters aren't overwritten unexpectedly.
* Side effects are minimized. For example, additional renders are avoided because they may create infinite rendering loops.

A child component receives new parameter values that possibly overwrite existing values when the parent component rerenders. Accidentally overwriting parameter values in a child component often occurs when developing the component with one or more data-bound parameters and the developer writes directly to a parameter in the child:

* The child component is rendered with one or more parameter values from the parent component.
* The child writes directly to the value of a parameter.
* The parent component rerenders and overwrites the value of the child's parameter.

The potential for overwriting parameter values extends into the child component's property `set` accessors, too.

> [!IMPORTANT]
> Our general guidance is not to create components that directly write to their own parameters after the component is rendered for the first time.

Consider the following `ShowMoreExpander` component that:

* Renders the title.
* Shows the child content when selected.
* Allows you to set initial state with a component parameter (`InitiallyExpanded`).

After the following `ShowMoreExpander` component demonstrates an overwritten parameter, a modified `ShowMoreExpander` component is shown to demonstrate the correct approach for this scenario. The following examples can be placed in a local sample app to experience the behaviors described.

`ShowMoreExpander.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/BadShowMoreExpander.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/overwriting-parameters/BadShowMoreExpander.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/overwriting-parameters/BadShowMoreExpander.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/overwriting-parameters/BadShowMoreExpander.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/overwriting-parameters/BadShowMoreExpander.razor":::

:::moniker-end

The `ShowMoreExpander` component is added to the following `Expanders` parent component that may call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A>:

* Calling <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> in developer code notifies a component that its state has changed and typically triggers component rerendering to update the UI. <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> is covered in more detail later in <xref:blazor/components/lifecycle> and <xref:blazor/components/rendering>.
* The button's `@onclick` directive attribute attaches an event handler to the button's `onclick` event. Event handling is covered in more detail later in <xref:blazor/components/event-handling>.

`Expanders.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Expanders.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/overwriting-parameters/Expanders.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/overwriting-parameters/Expanders.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/overwriting-parameters/Expanders.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/overwriting-parameters/Expanders.razor":::

:::moniker-end

Initially, the `ShowMoreExpander` components behave independently when their `InitiallyExpanded` properties are set. The child components maintain their states as expected.

If <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> is called in a parent component, the Blazor framework rerenders child components if their parameters might have changed:

* For a group of parameter types that Blazor explicitly checks, Blazor rerenders a child component if it detects that any of the parameters have changed.
* For unchecked parameter types, Blazor rerenders the child component *regardless of whether or not the parameters have changed*. Child content falls into this category of parameter types because child content is of type <xref:Microsoft.AspNetCore.Components.RenderFragment>, which is a delegate that refers to other mutable objects.

For the `Expanders` component:

* The first `ShowMoreExpander` component sets child content in a potentially mutable <xref:Microsoft.AspNetCore.Components.RenderFragment>, so a call to <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> in the parent component automatically rerenders the component and potentially overwrites the value of `InitiallyExpanded` to its initial value of `false`.
* The second `ShowMoreExpander` component doesn't set child content. Therefore, a potentially mutable <xref:Microsoft.AspNetCore.Components.RenderFragment> doesn't exist. A call to <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> in the parent component doesn't automatically rerender the child component, so the component's `InitiallyExpanded` value isn't overwritten.

To maintain state in the preceding scenario, use a *private field* in the `ShowMoreExpander` component to maintain its state.

The following revised `ShowMoreExpander` component:

* Accepts the `InitiallyExpanded` component parameter value from the parent.
* Assigns the component parameter value to a *private field* (`expanded`) in the [`OnInitialized` event](xref:blazor/components/lifecycle#component-initialization-oninitializedasync).
* Uses the private field to maintain its internal toggle state, which demonstrates how to avoid writing directly to a parameter.

> [!NOTE]
> The advice in this section extends to similar logic in component parameter `set` accessors, which can result in similar undesirable side effects.

`ShowMoreExpander.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/ShowMoreExpander.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/overwriting-parameters/ShowMoreExpander.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/overwriting-parameters/ShowMoreExpander.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/overwriting-parameters/ShowMoreExpander.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/overwriting-parameters/ShowMoreExpander.razor":::

:::moniker-end

> [!NOTE]
> The revised `ShowMoreExpander` doesn't reflect changes to the `InitiallyExpanded` parameter after initialization (`OnInitialized`). In certain scenarios, an already initialized component might receive new parameter values. This can happen, for example, in a master-detail view where the same component is used to render different detail views or when the `/item/{id}` route parameter changes to display a different item.

Consider following `ToggleExpander` component that:

* Allows you to change the state both from inside and outside.
* Handles new parameter values even if the same component instance is reused.

`ToggleExpander.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/ToggleExpander.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/overwriting-parameters/ToggleExpander.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/overwriting-parameters/ToggleExpander.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/overwriting-parameters/ToggleExpander.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/overwriting-parameters/ToggleExpander.razor":::

:::moniker-end

The `ToggleExpander` component should be used with the `@bind-Expanded="{field}"` binding syntax, allowing two-way synchronization of the parameter.

`ExpandersToggle.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/ExpandersToggle.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/overwriting-parameters/ExpandersToggle.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/overwriting-parameters/ExpandersToggle.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/overwriting-parameters/ExpandersToggle.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/overwriting-parameters/ExpandersToggle.razor":::

:::moniker-end

For more information on parent-child binding, see the following resources:

* [Binding with component parameters](xref:blazor/components/data-binding#binding-with-component-parameters)
* [Bind across more than two components](xref:blazor/components/data-binding#bind-across-more-than-two-components)
* [Blazor Two Way Binding Error (dotnet/aspnetcore #24599)](https://github.com/dotnet/aspnetcore/issues/24599)

For more information on change detection, including information on the exact types that Blazor checks, see <xref:blazor/components/rendering#rendering-conventions-for-componentbase>.
