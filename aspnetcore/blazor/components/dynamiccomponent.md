---
title: Dynamically-rendered ASP.NET Core Razor components
author: guardrex
description: Learn how to use dynamically-rendered Razor components in Blazor apps.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/components/dynamiccomponent
---
# Dynamically-rendered ASP.NET Core Razor components

[!INCLUDE[](~/includes/not-latest-version.md)]

By [Dave Brock](https://twitter.com/daveabrock)

Use the built-in <xref:Microsoft.AspNetCore.Components.DynamicComponent> component to render components by type.

A <xref:Microsoft.AspNetCore.Components.DynamicComponent> is useful for rendering components without iterating through possible types or using conditional logic. For example, <xref:Microsoft.AspNetCore.Components.DynamicComponent> can render a component based on a user selection from a dropdown list.

In the following example:

* `componentType` specifies the type.
* `parameters` specifies component parameters to pass to the `componentType` component.

```razor
<DynamicComponent Type="@componentType" Parameters="@parameters" />

@code {
    private Type componentType = ...;
    private IDictionary<string, object> parameters = ...;
}
```

For more information on passing parameter values, see the [Pass parameters](#pass-parameters) section later in this article.

Use the <xref:Microsoft.AspNetCore.Components.DynamicComponent.Instance> property to access the dynamically-created component instance:

```razor
<DynamicComponent Type="@typeof({COMPONENT})" @ref="dc" />

<button @onclick="Refresh">Refresh</button>

@code {
    private DynamicComponent? dc;

    private Task Refresh()
    {
        return (dc?.Instance as IRefreshable)?.Refresh();
    }
}
```

In the preceding example:

* The `{COMPONENT}` placeholder is the dynamically-created component type.
* `IRefreshable` is an example interface provided by the developer for the dynamic component instance.

## Example

In the following example, a Razor component renders a component based on the user's selection from a dropdown list of four possible values.

| User spaceflight carrier selection | Shared Razor component to render    |
| ---------------------------------- | ----------------------------------- |
| Rocket Lab&reg;                    | `RocketLab.razor`            |
| SpaceX&reg;                        | `SpaceX.razor`               |
| ULA&reg;                           | `UnitedLaunchAlliance.razor` |
| Virgin Galactic&reg;               | `VirginGalactic.razor`       |

:::moniker range=">= aspnetcore-7.0"

`RocketLab.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/RocketLab.razor":::

`SpaceX.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/SpaceX.razor":::

`UnitedLaunchAlliance.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/UnitedLaunchAlliance.razor":::

`VirginGalactic.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/VirginGalactic.razor":::

`DynamicComponentExample1.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/dynamiccomponent/DynamicComponentExample1.razor":::

:::moniker-end

:::moniker range="< aspnetcore-7.0"

`RocketLab.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/RocketLab.razor":::

`SpaceX.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/SpaceX.razor":::

`UnitedLaunchAlliance.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/UnitedLaunchAlliance.razor":::

`VirginGalactic.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/VirginGalactic.razor":::

`DynamicComponentExample1.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/dynamiccomponent/DynamicComponentExample1.razor":::

:::moniker-end

In the preceding example:

* Component names are used as the option values using the [`nameof` operator](/dotnet/csharp/language-reference/operators/nameof), which returns component names as constant strings.
* The namespace of the app is `BlazorSample`. ***Change the namespace to match your app's namespace.***

## Pass parameters

If dynamically-rendered components have [component parameters](xref:blazor/components/index#component-parameters), pass them into the <xref:Microsoft.AspNetCore.Components.DynamicComponent> as an `IDictionary<string, object>`. The `string` is the name of the parameter, and the `object` is the parameter's value.

The following example configures a component metadata object (`ComponentMetadata`) to supply parameter values to dynamically-rendered components based on the type name. The example is just one of several approaches that you can adopt. Parameter data can also be provided from a web API, a database, or a method. The only requirement is that the approach returns an `IDictionary<string, object>`.

`ComponentMetadata.cs`:

:::moniker range=">= aspnetcore-7.0"

:::code language="csharp" source="~/../blazor-samples/7.0/BlazorSample_Server/ComponentMetadata.cs":::

:::moniker-end

:::moniker range="< aspnetcore-7.0"

:::code language="csharp" source="~/../blazor-samples/6.0/BlazorSample_Server/ComponentMetadata.cs":::

:::moniker-end

The following `RocketLabWithWindowSeat` component (`RocketLabWithWindowSeat.razor`) has been updated from the preceding example to include a component parameter named `WindowSeat` to specify if the passenger prefers a window seat on their flight:

`RocketLabWithWindowSeat.razor`:

:::moniker range=">= aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/RocketLabWithWindowSeat.razor" highlight="13-14":::

:::moniker-end

:::moniker range="< aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/RocketLabWithWindowSeat.razor" highlight="13-14":::

:::moniker-end

In the following example:

* Only the `RocketLabWithWindowSeat` component's parameter for a window seat (`WindowSeat`) receives the value of the **`Window Seat`** checkbox.
* The namespace of the app is `BlazorSample`. ***Change the namespace to match your app's namespace.***
* The dynamically-rendered components are shared components:
  * Shown in this article section: `RocketLabWithWindowSeat` (`RocketLabWithWindowSeat.razor`)
  * Components shown in the [Example](#example) section earlier in this article:
    * `SpaceX` (`SpaceX.razor`)
    * `UnitedLaunchAlliance` (`UnitedLaunchAlliance.razor`)
    * `VirginGalactic` (`VirginGalactic.razor`)

`DynamicComponentExample2.razor`:

:::moniker range=">= aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/dynamiccomponent/DynamicComponentExample2.razor":::

:::moniker-end

:::moniker range="< aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/dynamiccomponent/DynamicComponentExample2.razor":::

:::moniker-end

## Event callbacks (`EventCallback`)

Event callbacks (<xref:Microsoft.AspNetCore.Components.EventCallback>) can be passed to a <xref:Microsoft.AspNetCore.Components.DynamicComponent> in its parameter dictionary.

`ComponentMetadata.cs`:

:::moniker range=">= aspnetcore-7.0"

:::code language="csharp" source="~/../blazor-samples/7.0/BlazorSample_Server/ComponentMetadata.cs":::

:::moniker-end

:::moniker range="< aspnetcore-7.0"

:::code language="csharp" source="~/../blazor-samples/6.0/BlazorSample_Server/ComponentMetadata.cs":::

:::moniker-end

Implement an event callback parameter (<xref:Microsoft.AspNetCore.Components.EventCallback>) within each dynamically-rendered component.

`RocketLab2.razor`:

:::moniker range=">= aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_Server/Shared/dynamiccomponent/RocketLab2.razor":::

:::moniker-end

:::moniker range="< aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_Server/Shared/dynamiccomponent/RocketLab2.razor":::

:::moniker-end

`SpaceX2.razor`:

:::moniker range=">= aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_Server/Shared/dynamiccomponent/SpaceX2.razor":::

:::moniker-end

:::moniker range="< aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_Server/Shared/dynamiccomponent/SpaceX2.razor":::

:::moniker-end

`UnitedLaunchAlliance2.razor`:

:::moniker range=">= aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_Server/Shared/dynamiccomponent/UnitedLaunchAlliance2.razor":::

:::moniker-end

:::moniker range="< aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_Server/Shared/dynamiccomponent/UnitedLaunchAlliance2.razor":::

:::moniker-end

`VirginGalactic2.razor`:

:::moniker range=">= aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_Server/Shared/dynamiccomponent/VirginGalactic2.razor":::

:::moniker-end

:::moniker range="< aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_Server/Shared/dynamiccomponent/VirginGalactic2.razor":::

:::moniker-end

In the following parent component example, the `ShowDTMessage` method assigns a string with the current time to `message`, and the value of `message` is rendered.

The parent component passes the callback method, `ShowDTMessage` in the parameter dictionary:

* The `string` key is the callback method's name, `OnClickCallback`.
* The `object` value is created by <xref:Microsoft.AspNetCore.Components.EventCallbackFactory.Create%2A?displayProperty=nameWithType> for the parent callback method, `ShowDTMessage`. Note that the [`this` keyword](/dotnet/csharp/language-reference/keywords/this) isn't supported in C# fields, so a C# property is used for the parameter dictionary.

> [!IMPORTANT]
> For the following `DynamicComponentExample3` component, modify the code in the `OnDropdownChange` method. Change the namespace name of "`BlazorSample`" in the `Type.GetType()` argument to match your app's namespace.

`DynamicComponentExample3.razor`:

:::moniker range=">= aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_Server/Pages/dynamiccomponent/DynamicComponentExample3.razor":::

:::moniker-end

:::moniker range="< aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_Server/Pages/dynamiccomponent/DynamicComponentExample3.razor":::

:::moniker-end

## Avoid catch-all parameters

Avoid the use of [catch-all parameters](xref:blazor/fundamentals/routing#catch-all-route-parameters). If catch-all parameters are used, every explicit parameter on <xref:Microsoft.AspNetCore.Components.DynamicComponent> effectively is a reserved word that you can't pass to a dynamic child. Any new parameters passed to <xref:Microsoft.AspNetCore.Components.DynamicComponent> are a breaking change, as they start shadowing child component parameters that happen to have the same name. It's unlikely that the caller always knows a fixed set of parameter names to pass to all possible dynamic children.

## Trademarks

Rocket Lab is a registered trademark of [Rocket Lab USA Inc.](https://www.rocketlabusa.com/) SpaceX is a registered trademark of [Space Exploration Technologies Corp.](https://www.spacex.com/) United Launch Alliance and ULA are registered trademarks of [United Launch Alliance, LLC](https://www.ulalaunch.com/). Virgin Galactic is a registered trademark of [Galactic Enterprises, LLC](https://www.virgingalactic.com/).

## Additional resources

* <xref:blazor/components/event-handling#eventcallback>
