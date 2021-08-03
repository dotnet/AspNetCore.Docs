---
title: Dynamically-rendered ASP.NET Core Razor components
author: guardrex
description: Learn how to use dynamically-rendered Razor components in Blazor apps.
monikerRange: 'aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 08/03/2021
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/components/dynamic-component
---
# Dynamically-rendered ASP.NET Core Razor components

By [Dave Brock](https://twitter.com/daveabrock)

Use the `DynamicComponent` component to render components by type. Supply the dynamic component's [component parameters](xref:blazor/components/index#component-parameters) in a dictionary to the `Parameters` attribute.

## `DynamicComponent` component

In the following example, `componentType` specifies the type, and `parameterDictionary` specifies the component parameters to pass to the component of `@componentType` type.

```razor
<DynamicComponent Type="@componentType" Parameters="@parameterDictionary" />

@code {
    private Type componentType = ...;
    private IDictionary<string, object> parameterDictionary = ...;
}
```

`DynamicComponent` is useful when rendering components without having to iterate through possible types. For example, `DynamicComponent` can render a component based on a user selection from a drop-down list.

In the following example, a [Blazor form](xref:blazor/forms-validation) renders a component based on the user's selection from a drop-down list of four possible values. 

| User selection  | Razor component to render    |
| --------------- | ---------------------------- |
| Rocket Lab      | `RocketLab.razor`            |
| Virgin Galactic | `VirginGalactic.razor`       |
| SpaceX          | `SpaceX.razor`               |
| ULA             | `UnitedLaunchAlliance.razor` |

To generate the drop-down list for this example, component names are used as the option value using the `nameof` keyword, which returns component names as constant strings.

```razor
<p>
    <label>
        Select your transport:
        <select @onchange="OnDropdownChange">
            <option value="">Select a value</option>
            <option value="@nameof(RocketLab)">Rocket Lab</option>
            <option value="@nameof(VirginGalactic)">Virgin Galactic</option>
            <option value="@nameof(SpaceX)">SpaceX</option>
            <option value="@nameof(UnitedLaunchAlliance)">ULA</option>
        </select>
    </label>
</p>

@if (selectedType is not null)
{
    <DynamicComponent Type="@selectedType" />
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

* The `{APP NAMESPACE}` placeholder is the namespace of the app (for example, `BlazorSample`).
* The components to render dynamically are shared components in the app's `Shared` folder.

## Pass parameters

If dynamically-rendered components have [component parameters](xref:blazor/components/index#component-parameters), pass them into the `DynamicComponent` as an `IDictionary<string, object>`. The `string` is the name of the parameter, and the `object` is its value.

The following example configures `ComponentMetadata`:

```csharp
private class ComponentMetadata
{
    public Type ComponentType { get; set; }
    public Dictionary<string, object> ComponentParameters { get; set; }
}
```

A dictionary is created for components like this (only one component has a parameter):

```csharp
private Dictionary<string, ComponentMetadata> paramsDictionaries = new()
{
    {
        "DefaultDropdownComponent",
        new ComponentMetadata { ComponentType = typeof(DefaultDropdownComponent)}
    },
    {
        "RentComponent",
        new ComponentMetadata { ComponentType = typeof(RentComponent)}
    },
    {
        "OwnCondoComponent",
         new ComponentMetadata { ComponentType = typeof(OwnCondoComponent)}
    },
    {
        "DaveRoommate",
        new ComponentMetadata
        {
            ComponentType = typeof(OwnCondoComponent),
            ComponentParameters = new Dictionary<string, object>()
            {
                { "WindowSeat", "Ooh, no." }
            }
        }
    }
};
```

Logic can filter and pass in a `ComponentParameters` instance to the `DynamicComponent`, depending on the type passed. Data can be passed from an API, a database, or a function, as long as it returns an `IDictionary<string, object>`.

```razor
<p>
    <label>
        <InputCheckbox @bind-Value="airsicknessBags" />
        Provide additional airsickness bags
    </label>
</p>

<p>
    <label>
        Select your transport:
        <select @onchange="OnDropdownChange">
            <option value="">Select a value</option>
            <option value="@nameof(RocketLab)">Rocket Lab</option>
            <option value="@nameof(VirginGalactic)">Virgin Galactic</option>
            <option value="@nameof(SpaceX)">SpaceX</option>
            <option value="@nameof(UnitedLaunchAlliance)">ULA</option>
        </select>
    </label>
</p>

<DynamicComponent Type="selectedType" />

@code {
    private bool airsicknessBags;
    private Type selectedType = typeof(DefaultDropdownComponent);

    private void OnDropdownChange(ChangeEventArgs e)
    {
        selectedType = Type.GetType($"DynamicComponentDemo.Shared.{e.Value}");
    }
}
```

## Avoid catch-all parameters

[Catch-all parameters](xref:blazor/fundamentals/routing#catch-all-route-parameters) should be avoided. If catch-all parameters are used, then every explicit parameter on `DynamicComponent` itself, now and in the future, effectively becomes a reserved word that you can't pass to a dynamic child. Any new parameters passed to `DynamicComponent` are a breaking change, as they start shadowing child component parameters that happen to have the same name. It's unlikely that the caller always knows a fixed set of parameter names to pass to all possible dynamic children.
