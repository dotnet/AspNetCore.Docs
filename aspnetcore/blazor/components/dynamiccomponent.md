---
title: Dynamically-rendered ASP.NET Core Razor components
author: daveabrock
description: Learn how to use dynamically-rendered Razor components in Blazor apps.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/components/dynamiccomponent
---
# Dynamically-rendered ASP.NET Core Razor components

By [Dave Brock](https://twitter.com/daveabrock)

Use the built-in `DynamicComponent` component to render components by type.

A `DynamicComponent` is useful for rendering components without iterating through possible types or using conditional logic. For example, `DynamicComponent` can render a component based on a user selection from a dropdown list.

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

Use the `Instance` property to access the dynamically-created component instance:

```razor
<DynamicComponent Type="@typeof({COMPONENT})" @ref="dc" />

<button @onclick="Refresh">Refresh</button>

@code {
    private DynamicComponent dc;

    private Task Refresh()
    {
        return (dc.Instance as IRefreshable)?.Refresh();
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

```razor
<h2>Rocket Lab&reg;</h2>

<p>
    Rocket Lab is a registered trademark of 
    <a href="https://www.rocketlabusa.com/">Rocket Lab USA Inc.</a>
</p>
```

`Shared/SpaceX.razor`:

```razor
<h2>SpaceX&reg;</h2>

<p>
    SpaceX is a registered trademark of 
    <a href="https://www.spacex.com/">Space Exploration Technologies Corp.</a>
</p>
```

`Shared/UnitedLaunchAlliance.razor`:

```razor
<h2>United Launch Alliance&reg;</h2>

<p>
    United Launch Alliance and ULA are registered trademarks of
    <a href="https://www.ulalaunch.com/">United Launch Alliance, LLC</a>.
</p>
```

`Shared/VirginGalactic.razor`:

```razor
<h2>Virgin Galactic&reg;</h2>

<p>
    Virgin Galactic is a registered trademark of 
    <a href="https://www.virgingalactic.com/">Galactic Enterprises, LLC</a>.
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
            <option value="@nameof(SpaceX)">SpaceX</option>
            <option value="@nameof(UnitedLaunchAlliance)">ULA</option>
            <option value="@nameof(VirginGalactic)">Virgin Galactic</option>
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

In the preceding example:

* Component names are used as the option values using the [`nameof` operator](/dotnet/csharp/language-reference/operators/nameof), which returns component names as constant strings.
* The `{APP NAMESPACE}` placeholder is the namespace of the app (for example, `BlazorSample`).

## Pass parameters

If dynamically-rendered components have [component parameters](xref:blazor/components/index#component-parameters), pass them into the `DynamicComponent` as an `IDictionary<string, object>`. The `string` is the name of the parameter, and the `object` is the parameter's value.

The following example configures a component metadata object (`ComponentMetadata`) to supply parameter values to dynamically-rendered components based on the type name. The example is just one of several approaches that you can adopt. Parameter data can also be provided from a web API, a database, or a method. The only requirement is that the approach returns an `IDictionary<string, object>`.

`ComponentMetadata.cs`:

```csharp
using System;
using System.Collections.Generic;

public class ComponentMetadata
{
    public string Name { get; set; }
    public Dictionary<string, object> Parameters { get; set; }
}
```

In the following example, only the `RocketLab` component has a parameter, which assigns a value for a window seat (`WindowSeat`) on a spaceflight.

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
            @foreach (var c in components)
            {
                <option value="@c.Key">@c.Value.Name</option>
            }
        </select>
    </label>
</p>

@if (selectedType is not null)
{
    <div class="border border-primary my-1 p-1">
        <DynamicComponent Type="@selectedType" 
            Parameters="@components[selectedType.Name].Parameters" />
    </div>
}

@code {
    private Dictionary<string, ComponentMetadata> components =
        new()
        {
            {
                "RocketLab",
                new ComponentMetadata
                {
                    Name = "Rocket Lab",
                    Parameters = new() { { "WindowSeat", false } }
                }
            },
            {
                "VirginGalactic",
                new ComponentMetadata { Name = "Virgin Galactic" }
            },
            {
                "UnitedLaunchAlliance",
                new ComponentMetadata { Name = "ULA" }
            },
            {
                "SpaceX",
                new ComponentMetadata { Name = "SpaceX" }
            }
        };
    private Type selectedType;
    private bool windowSeat;

    private bool WindowSeat
    {
        get { return windowSeat; }
        set
        {
            windowSeat = value;
            components[nameof(RocketLab)].Parameters["WindowSeat"] = windowSeat;
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
* The dynamically-rendered components are shared components in the app's `Shared` folder:
  * Shown in this article section: `RocketLab` (`Shared/RocketLab.razor`)
  * Components shown in the [Example](#example) section earlier in this article:
    * `SpaceX` (`Shared/SpaceX.razor`)
    * `UnitedLaunchAlliance` (`Shared/UnitedLaunchAlliance.razor`)
    * `VirginGalactic` (`Shared/VirginGalactic.razor`)

The `RocketLab` component (`Shared/RocketLab.razor`) includes a component parameter named `WindowSeat`:

`Shared/RocketLab.razor`:

```razor
<h2>Rocket Lab&reg;</h2>

<p>
    User selected a window seat: @WindowSeat
</p>

<p>
    Rocket Lab is a trademark of 
    <a href="https://www.rocketlabusa.com/">Rocket Lab USA Inc.</a>
</p>

@code {
    [Parameter]
    public bool WindowSeat { get; set; }
}
```

## Avoid catch-all parameters

Avoid the use of [catch-all parameters](xref:blazor/fundamentals/routing#catch-all-route-parameters). If catch-all parameters are used, every explicit parameter on `DynamicComponent` effectively is a reserved word that you can't pass to a dynamic child. Any new parameters passed to `DynamicComponent` are a breaking change, as they start shadowing child component parameters that happen to have the same name. It's unlikely that the caller always knows a fixed set of parameter names to pass to all possible dynamic children.

## Trademarks

Rocket Lab is a registered trademark of [Rocket Lab USA Inc.](https://www.rocketlabusa.com/) SpaceX is a registered trademark of [Space Exploration Technologies Corp.](https://www.spacex.com/) United Launch Alliance and ULA are registered trademarks of [United Launch Alliance, LLC](https://www.ulalaunch.com/). Virgin Galactic is a registered trademark of [Galactic Enterprises, LLC](https://www.virgingalactic.com/).
