---
title: Dynamically-rendered ASP.NET Core Razor components
author: daveabrock
description: Learn how to use dynamically-rendered Razor components in Blazor apps.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/components/dynamiccomponent
---
# Dynamically-rendered ASP.NET Core Razor components

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
| Rocket Lab&reg;                    | `Shared/RocketLab.razor`            |
| SpaceX&reg;                        | `Shared/SpaceX.razor`               |
| ULA&reg;                           | `Shared/UnitedLaunchAlliance.razor` |
| Virgin Galactic&reg;               | `Shared/VirginGalactic.razor`       |

`Shared/RocketLab.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/RocketLab.razor)]

`Shared/SpaceX.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/SpaceX.razor)]

`Shared/UnitedLaunchAlliance.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/UnitedLaunchAlliance.razor)]

`Shared/VirginGalactic.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/VirginGalactic.razor)]

`Pages/DynamicComponentExample1.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/dynamiccomponent/DynamicComponentExample1.razor)]

In the preceding example:

* Component names are used as the option values using the [`nameof` operator](/dotnet/csharp/language-reference/operators/nameof), which returns component names as constant strings.
* The `{APP NAMESPACE}` placeholder is the namespace of the app (for example, `BlazorSample`).

## Pass parameters

If dynamically-rendered components have [component parameters](xref:blazor/components/index#component-parameters), pass them into the <xref:Microsoft.AspNetCore.Components.DynamicComponent> as an `IDictionary<string, object>`. The `string` is the name of the parameter, and the `object` is the parameter's value.

The following example configures a component metadata object (`ComponentMetadata`) to supply parameter values to dynamically-rendered components based on the type name. The example is just one of several approaches that you can adopt. Parameter data can also be provided from a web API, a database, or a method. The only requirement is that the approach returns an `IDictionary<string, object>`.

`ComponentMetadata.cs`:

```csharp
public class ComponentMetadata
{
    public string? Name { get; set; }
    public Dictionary<string, object> Parameters { get; set; } = 
        new Dictionary<string, object>();
}
```

The following `RocketLabWithWindowSeat` component (`Shared/RocketLabWithWindowSeat.razor`) has been updated from the preceding example to include a component parameter named `WindowSeat` to specify if the passenger prefers a window seat on their flight:

`Shared/RocketLabWithWindowSeat.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/RocketLabWithWindowSeat.razor?highlight=13-14)]

In the following example:

* Only the `RocketLabWithWindowSeat` component's parameter for a window seat (`WindowSeat`) receives the value of the **`Window Seat`** checkbox.
* The `{APP NAMESPACE}` placeholder is the namespace of the app (for example, `BlazorSample`).
* The dynamically-rendered components are shared components in the app's `Shared` folder:
  * Shown in this article section: `RocketLabWithWindowSeat` (`Shared/RocketLabWithWindowSeat.razor`)
  * Components shown in the [Example](#example) section earlier in this article:
    * `SpaceX` (`Shared/SpaceX.razor`)
    * `UnitedLaunchAlliance` (`Shared/UnitedLaunchAlliance.razor`)
    * `VirginGalactic` (`Shared/VirginGalactic.razor`)

`Pages/DynamicComponentExample2.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/dynamiccomponent/DynamicComponentExample2.razor)]

## Avoid catch-all parameters

Avoid the use of [catch-all parameters](xref:blazor/fundamentals/routing#catch-all-route-parameters). If catch-all parameters are used, every explicit parameter on <xref:Microsoft.AspNetCore.Components.DynamicComponent> effectively is a reserved word that you can't pass to a dynamic child. Any new parameters passed to <xref:Microsoft.AspNetCore.Components.DynamicComponent> are a breaking change, as they start shadowing child component parameters that happen to have the same name. It's unlikely that the caller always knows a fixed set of parameter names to pass to all possible dynamic children.

## Trademarks

Rocket Lab is a registered trademark of [Rocket Lab USA Inc.](https://www.rocketlabusa.com/) SpaceX is a registered trademark of [Space Exploration Technologies Corp.](https://www.spacex.com/) United Launch Alliance and ULA are registered trademarks of [United Launch Alliance, LLC](https://www.ulalaunch.com/). Virgin Galactic is a registered trademark of [Galactic Enterprises, LLC](https://www.virgingalactic.com/).
