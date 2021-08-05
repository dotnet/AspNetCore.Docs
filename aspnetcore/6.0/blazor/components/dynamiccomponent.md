---
title: Dynamically-rendered ASP.NET Core Razor components
author: guardrex
description: Learn how to use dynamically-rendered Razor components in Blazor apps.
monikerRange: 'aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 08/05/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/components/dynamiccomponent
---
# Dynamically-rendered ASP.NET Core Razor components

By [Dave Brock](https://twitter.com/daveabrock)

Use the `DynamicComponent` component to render components by type.

A `DynamicComponent` is useful for rendering components without having to iterate through possible types or use a lot of conditional logic to render a specific component. For example, `DynamicComponent` can render a component based on a user selection from a drop-down list.

In the following example:

* `componentType` specifies the type.
* `parameterDictionary` specifies component parameters to pass to the `componentType` component.

```razor
<DynamicComponent Type="@componentType" Parameters="@parameterDictionary" />

@code {
    private Type componentType = ...;
    private IDictionary<string, object> parameterDictionary = ...;
}
```

For more information on passing parameter values, see the [Pass parameters](#pass-parameters) section later in this article.

## Example

In the following example, a [Blazor form](xref:blazor/forms-validation) renders a component based on the user's selection from a drop-down list of four possible values. 

| User selection  | Razor component to render    |
| --------------- | ---------------------------- |
| Rocket Lab      | `RocketLab.razor`            |
| Virgin Galactic | `VirginGalactic.razor`       |
| SpaceX          | `SpaceX.razor`               |
| ULA             | `UnitedLaunchAlliance.razor` |

`Shared/RocketLab.razor`:

```razor
<h2>Rocket Lab</h2>

<p>
    Rocket Lab is a trademark of 
    <a href="https://www.rocketlabusa.com/">Rocket Lab USA Inc.</a>.
</p>
```

`Shared/VirginGalactic.razor`:

```razor
<h2>Virgin Galactic</h2>

<p>
    Virgin Galactic is a trademark of 
    <a href="https://www.virgingalactic.com/">Galactic Enterprises, LLC</a>.
</p>
```

`Shared/UnitedLaunchAlliance.razor`:

```razor
<h2>United Launch Alliance</h2>

<p>
    United Launch Alliance is a trademark of
    <a href="https://www.ulalaunch.com/">United Launch Alliance, LLC</a>.
</p>
```

`Shared/SpaceX.razor`:

```razor
<h2>SpaceX</h2>

<p>
    SpaceX is a trademark of 
    <a href="https://www.spacex.com/">Space Exploration Technologies Corp.</a>.
</p>
```

`Pages/DynamicComponentExample1.razor`:

```razor
@page "/dynamiccomponent-example-1"

<h1><code>DynamicComponent</code> Component Example 1</h1>

<p>
    <label>
        Select your transport:
        <select @onchange="OnDropdownChange">
            <option value="">Select a value</option>
            <option value="@nameof(RocketLab)">Rocket Lab</option>
            <option value="@nameof(VirginGalactic)">Virgin Galactic</option>
            <option value="@nameof(UnitedLaunchAlliance)">ULA</option>
            <option value="@nameof(SpaceX)">SpaceX</option>
        </select>
    </label>
</p>

@if (selectedType is not null)
{
    <div class="border border-primary my-1 p-1">
        <DynamicComponent Type="@selectedType" />
    </div>
}

@code {
    private Type selectedType;

    private void OnDropdownChange(ChangeEventArgs e)
    {
        selectedType = e.Value.ToString().Length > 0 ? 
            Type.GetType($"{APP NAMESPACE}.Shared.{e.Value}") : null;
    }
}
```

In the `DynamicComponentExample` component:

* Component names are used as the option values using the [`nameof` operator](/dotnet/csharp/language-reference/operators/nameof), which returns component names as constant strings.
* The `{APP NAMESPACE}` placeholder is the namespace of the app (for example, `BlazorSample`).
* The components to render dynamically are shared components in the app's `Shared` folder:
  * `RocketLab` (`Shared/RocketLab.razor`)
  * `VirginGalactic` (`Shared/VirginGalactic.razor`)
  * `UnitedLaunchAlliance` (`Shared/UnitedLaunchAlliance.razor`)
  * `SpaceX` (`Shared/SpaceX.razor`)

## Pass parameters

If dynamically-rendered components have [component parameters](xref:blazor/components/index#component-parameters), pass them into the `DynamicComponent` as an `IDictionary<string, object>`. The `string` is the name of the parameter, and the `object` is the parameter's value.

The following example configures `ComponentMetadata` for dynamically-rendered components.

`ComponentMetadata.cs`:

```csharp
using System;
using System.Collections.Generic;

public class ComponentMetadata
{
    public Type ComponentType { get; set; }
    public Dictionary<string, object> ComponentParameters { get; set; }
}
```

A dictionary is created for any components with [component parameters](xref:blazor/components/index#component-parameters). In the following example, only the `RocketLab` component has a parameter, which assigns a value for a window seat (`WindowSeat`) on a spaceflight.

Logic can filter and pass in a `ComponentParameters` instance to the `DynamicComponent`, depending on the type passed. Data can be passed from an API, a database, or a function, as long as it returns an `IDictionary<string, object>`.

`Pages/DynamicComponentExample2.razor`:

```razor
@page "/dynamiccomponent-example-2"

<h1><code>DynamicComponent</code> Component Example 2</h1>

<p>
    <label>
        <input type="checkbox" @bind="WindowSeat" />
        Window Seat (Rocket Lab only)
    </label>
</p>

<p>
    <label>
        Select your transport:
        <select @onchange="OnDropdownChange">
            <option value="">Select a value</option>
            <option value="@nameof(RocketLab)">Rocket Lab</option>
            <option value="@nameof(VirginGalactic)">Virgin Galactic</option>
            <option value="@nameof(UnitedLaunchAlliance)">ULA</option>
            <option value="@nameof(SpaceX)">SpaceX</option>
        </select>
    </label>
</p>

@if (selectedType is not null)
{
    <div class="border border-primary my-1 p-1">
        <DynamicComponent Type="@selectedType" 
            Parameters="@paramDictionaries[selectedType.Name].ComponentParameters" />
    </div>
}

@code {
    private bool windowSeat;
    private Type selectedType;
    private Dictionary<string, ComponentMetadata> paramDictionaries =
        new()
        {
            {
                "RocketLab",
                new ComponentMetadata
                {
                    ComponentType = typeof(RocketLab),
                    ComponentParameters = 
                        new()
                        {
                            { "WindowSeat", false }
                        }
                }
            },
            {
                "VirginGalactic",
                new ComponentMetadata { ComponentType = typeof(VirginGalactic) }
            },
            {
                "UnitedLaunchAlliance",
                new ComponentMetadata { ComponentType = typeof(UnitedLaunchAlliance) }
            },
            {
                "SpaceX",
                new ComponentMetadata { ComponentType = typeof(SpaceX) }
            }
        };

    private bool WindowSeat
    {
        get { return windowSeat; }
        set
        {
            windowSeat = value;
            paramDictionaries[nameof(RocketLab)].ComponentParameters["WindowSeat"] = 
                windowSeat;
        }
    }

    private void OnDropdownChange(ChangeEventArgs e)
    {
        selectedType = e.Value.ToString().Length > 0 ? 
            Type.GetType($"{APP NAMESPACE}.Shared.{e.Value}") : null;
    }
}
```

In the preceding example:

* The `{APP NAMESPACE}` placeholder is the namespace of the app (for example, `BlazorSample`).
* The components to render dynamically are shared components in the app's `Shared` folder. For examples, see the [Example](#example) section earlier in this article:
  * `RocketLab` (`Shared/RocketLab.razor`)
  * `VirginGalactic` (`Shared/VirginGalactic.razor`)
  * `UnitedLaunchAlliance` (`Shared/UnitedLaunchAlliance.razor`) 
  * `SpaceX` (`Shared/SpaceX.razor`)

The `RocketLab` component (`Shared/RocketLab.razor`) includes a component parameter named `WindowSeat`:

`Shared/RocketLab.razor`:

```razor
<h2>Rocket Lab</h2>

<p>
    User selected a window seat: @WindowSeat
</p>

<p>
    Rocket Lab is a trademark of 
    <a href="https://www.rocketlabusa.com/">Rocket Lab USA Inc.</a>.
</p>

@code {
    [Parameter]
    public bool WindowSeat { get; set; }
}
```

## Avoid catch-all parameters

Avoid the use of [catch-all parameters](xref:blazor/fundamentals/routing#catch-all-route-parameters). If catch-all parameters are used, every explicit parameter on `DynamicComponent`, now and in the future, effectively is a reserved word that you can't pass to a dynamic child. Any new parameters passed to `DynamicComponent` are a breaking change, as they start shadowing child component parameters that happen to have the same name. It's unlikely that the caller always knows a fixed set of parameter names to pass to all possible dynamic children.
