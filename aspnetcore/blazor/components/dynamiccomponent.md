---
title: Dynamically-rendered ASP.NET Core Razor components
author: guardrex
description: Learn how to use dynamically-rendered Razor components in Blazor apps.
monikerRange: '>= aspnetcore-6.0'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
uid: blazor/components/dynamiccomponent
---
# Dynamically-rendered ASP.NET Core Razor components

By [Dave Brock](https://twitter.com/daveabrock)

Use the built-in <xref:Microsoft.AspNetCore.Components.DynamicComponent> component to render components by type.

:::moniker range="< aspnetcore-7.0"

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

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/RocketLab.razor":::

`Shared/SpaceX.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/SpaceX.razor":::

`Shared/UnitedLaunchAlliance.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/UnitedLaunchAlliance.razor":::

`Shared/VirginGalactic.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/VirginGalactic.razor":::

`Pages/DynamicComponentExample1.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/dynamiccomponent/DynamicComponentExample1.razor":::

In the preceding example:

* Component names are used as the option values using the [`nameof` operator](/dotnet/csharp/language-reference/operators/nameof), which returns component names as constant strings.
* The namespace of the app is `BlazorSample`. Change the namespace to match your app's namespace.

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

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/RocketLabWithWindowSeat.razor" highlight="13-14":::

In the following example:

* Only the `RocketLabWithWindowSeat` component's parameter for a window seat (`WindowSeat`) receives the value of the **`Window Seat`** checkbox.
* The namespace of the app is `BlazorSample`. Change the namespace to match your app's namespace.
* The dynamically-rendered components are shared components in the app's `Shared` folder:
  * Shown in this article section: `RocketLabWithWindowSeat` (`Shared/RocketLabWithWindowSeat.razor`)
  * Components shown in the [Example](#example) section earlier in this article:
    * `SpaceX` (`Shared/SpaceX.razor`)
    * `UnitedLaunchAlliance` (`Shared/UnitedLaunchAlliance.razor`)
    * `VirginGalactic` (`Shared/VirginGalactic.razor`)

`Pages/DynamicComponentExample2.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/dynamiccomponent/DynamicComponentExample2.razor":::

## Event callbacks (`EventCallback`)

Event callbacks (<xref:Microsoft.AspNetCore.Components.EventCallback>) can be passed to a <xref:Microsoft.AspNetCore.Components.DynamicComponent> in its parameter dictionary.

`ComponentMetadata.cs`:

```csharp
public class ComponentMetadata
{
    public string? Name { get; set; }
    public Dictionary<string, object> Parameters { get; set; } =
        new Dictionary<string, object>();
}
```

Implement an event callback parameter (<xref:Microsoft.AspNetCore.Components.EventCallback>) within each dynamically-rendered component.

`Shared/RocketLab2.razor`:

```razor
<h2>Rocket Lab®</h2>

<p>
    Rocket Lab is a registered trademark of
    <a href="https://www.rocketlabusa.com/">Rocket Lab USA Inc.</a>
</p>

<button @onclick="OnClickCallback">
    Trigger a Parent component method
</button>

@code {
    [Parameter]
    public EventCallback<MouseEventArgs> OnClickCallback { get; set; }
}
```

`Shared/SpaceX2.razor`:

```razor
<h2>SpaceX®</h2>

<p>
    SpaceX is a registered trademark of
    <a href="https://www.spacex.com/">Space Exploration Technologies Corp.</a>
</p>

<button @onclick="OnClickCallback">
    Trigger a Parent component method
</button>

@code {
    [Parameter]
    public EventCallback<MouseEventArgs> OnClickCallback { get; set; }
}
```

`Shared/UnitedLaunchAlliance2.razor`:

```razor
<h2>United Launch Alliance®</h2>

<p>
    United Launch Alliance and ULA are registered trademarks of
    <a href="https://www.ulalaunch.com/">United Launch Alliance, LLC</a>.
</p>

<button @onclick="OnClickCallback">
    Trigger a Parent component method
</button>

@code {
    [Parameter]
    public EventCallback<MouseEventArgs> OnClickCallback { get; set; }
}
```

`Shared/VirginGalactic2.razor`:

```razor
<h2>Virgin Galactic®</h2>

<p>
    Virgin Galactic is a registered trademark of
    <a href="https://www.virgingalactic.com/">Galactic Enterprises, LLC</a>.
</p>

<button @onclick="OnClickCallback">
    Trigger a Parent component method
</button>

@code {
    [Parameter]
    public EventCallback<MouseEventArgs> OnClickCallback { get; set; }
}
```

In the following parent component example, the `ShowDTMessage` method assigns a string with the current time to `message`, and the value of `message` is rendered.

The parent component passes the callback method, `ShowDTMessage` in the parameter dictionary:

* The `string` key is the callback method's name, `OnClickCallback`.
* The `object` value is created by <xref:Microsoft.AspNetCore.Components.EventCallbackFactory.Create%2A?displayProperty=nameWithType> for the parent callback method, `ShowDTMessage`. Note that the [`this` keyword](/dotnet/csharp/language-reference/keywords/this) isn't supported in C# fields, so a C# property is used for the parameter dictionary.

**For the following component, change the namespace name of `BlazorSample` in the `OnDropdownChange` method to match your app's namespace.**

`Pages/DynamicComponentExample3.razor`:

```razor
@page "/dynamiccomponent-example-3"

<h1><code>DynamicComponent</code> Component Example 3</h1>

<p>
    <label>
        Select your transport:
        <select @onchange="OnDropdownChange">
            <option value="">Select a value</option>
            <option value="@nameof(RocketLab2)">Rocket Lab</option>
            <option value="@nameof(SpaceX2)">SpaceX</option>
            <option value="@nameof(UnitedLaunchAlliance2)">ULA</option>
            <option value="@nameof(VirginGalactic2)">Virgin Galactic</option>
        </select>
    </label>
</p>

@if (selectedType is not null)
{
    <div class="border border-primary my-1 p-1">
        <DynamicComponent Type="@selectedType"
            Parameters="@Components[selectedType.Name].Parameters" />
    </div>
}

<p>
    @message
</p>

@code {
    private Type? selectedType;
    private string? message;

    private Dictionary<string, ComponentMetadata> Components
    {
        get
        {
            return new Dictionary<string, ComponentMetadata>()
            {
                {
                    "RocketLab2",
                    new ComponentMetadata
                    {
                        Name = "Rocket Lab",
                        Parameters =
                            new()
                            {
                                {
                                    "OnClickCallback",
                                    EventCallback.Factory.Create<MouseEventArgs>(
                                        this, ShowDTMessage)
                                }
                            }
                    }
                },
                {
                    "VirginGalactic2",
                    new ComponentMetadata
                    {
                        Name = "Virgin Galactic",
                        Parameters =
                            new()
                            {
                                {
                                    "OnClickCallback",
                                    EventCallback.Factory.Create<MouseEventArgs>(
                                        this, ShowDTMessage)
                                }
                            }
                    }
                },
                {
                    "UnitedLaunchAlliance2",
                    new ComponentMetadata
                    {
                        Name = "ULA",
                        Parameters =
                            new()
                            {
                                {
                                    "OnClickCallback",
                                    EventCallback.Factory.Create<MouseEventArgs>(
                                        this, ShowDTMessage)
                                }
                            }
                    }
                },
                {
                    "SpaceX2",
                    new ComponentMetadata
                    {
                        Name = "SpaceX",
                        Parameters =
                            new()
                            {
                                {
                                    "OnClickCallback",
                                    EventCallback.Factory.Create<MouseEventArgs>(
                                        this, ShowDTMessage)
                                }
                            }
                    }
                }
            };
        }
    }

    private void OnDropdownChange(ChangeEventArgs e)
    {
        selectedType = e.Value?.ToString()?.Length > 0 ?
            Type.GetType($"BlazorSample.Shared.{e.Value}") : null;
    }

    private void ShowDTMessage(MouseEventArgs e) =>
        message = $"The current DT is: {DateTime.Now}.";
}
```

## Avoid catch-all parameters

Avoid the use of [catch-all parameters](xref:blazor/fundamentals/routing#catch-all-route-parameters). If catch-all parameters are used, every explicit parameter on <xref:Microsoft.AspNetCore.Components.DynamicComponent> effectively is a reserved word that you can't pass to a dynamic child. Any new parameters passed to <xref:Microsoft.AspNetCore.Components.DynamicComponent> are a breaking change, as they start shadowing child component parameters that happen to have the same name. It's unlikely that the caller always knows a fixed set of parameter names to pass to all possible dynamic children.

## Trademarks

Rocket Lab is a registered trademark of [Rocket Lab USA Inc.](https://www.rocketlabusa.com/) SpaceX is a registered trademark of [Space Exploration Technologies Corp.](https://www.spacex.com/) United Launch Alliance and ULA are registered trademarks of [United Launch Alliance, LLC](https://www.ulalaunch.com/). Virgin Galactic is a registered trademark of [Galactic Enterprises, LLC](https://www.virgingalactic.com/).

## Additional resources

* <xref:blazor/components/event-handling#eventcallback>

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

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

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/RocketLab.razor":::

`Shared/SpaceX.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/SpaceX.razor":::

`Shared/UnitedLaunchAlliance.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/UnitedLaunchAlliance.razor":::

`Shared/VirginGalactic.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/VirginGalactic.razor":::

`Pages/DynamicComponentExample1.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/dynamiccomponent/DynamicComponentExample1.razor":::

In the preceding example:

* Component names are used as the option values using the [`nameof` operator](/dotnet/csharp/language-reference/operators/nameof), which returns component names as constant strings.
* The namespace of the app is `BlazorSample`. Change the namespace to match your app's namespace.

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

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/dynamiccomponent/RocketLabWithWindowSeat.razor" highlight="13-14":::

In the following example:

* Only the `RocketLabWithWindowSeat` component's parameter for a window seat (`WindowSeat`) receives the value of the **`Window Seat`** checkbox.
* The namespace of the app is `BlazorSample`. Change the namespace to match your app's namespace.
* The dynamically-rendered components are shared components in the app's `Shared` folder:
  * Shown in this article section: `RocketLabWithWindowSeat` (`Shared/RocketLabWithWindowSeat.razor`)
  * Components shown in the [Example](#example) section earlier in this article:
    * `SpaceX` (`Shared/SpaceX.razor`)
    * `UnitedLaunchAlliance` (`Shared/UnitedLaunchAlliance.razor`)
    * `VirginGalactic` (`Shared/VirginGalactic.razor`)

`Pages/DynamicComponentExample2.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/dynamiccomponent/DynamicComponentExample2.razor":::

## Event callbacks (`EventCallback`)

Event callbacks (<xref:Microsoft.AspNetCore.Components.EventCallback>) can be passed to a <xref:Microsoft.AspNetCore.Components.DynamicComponent> in its parameter dictionary.

`ComponentMetadata.cs`:

```csharp
public class ComponentMetadata
{
    public string? Name { get; set; }
    public Dictionary<string, object> Parameters { get; set; } =
        new Dictionary<string, object>();
}
```

Implement an event callback parameter (<xref:Microsoft.AspNetCore.Components.EventCallback>) within each dynamically-rendered component.

`Shared/RocketLab2.razor`:

```razor
<h2>Rocket Lab®</h2>

<p>
    Rocket Lab is a registered trademark of
    <a href="https://www.rocketlabusa.com/">Rocket Lab USA Inc.</a>
</p>

<button @onclick="OnClickCallback">
    Trigger a Parent component method
</button>

@code {
    [Parameter]
    public EventCallback<MouseEventArgs> OnClickCallback { get; set; }
}
```

`Shared/SpaceX2.razor`:

```razor
<h2>SpaceX®</h2>

<p>
    SpaceX is a registered trademark of
    <a href="https://www.spacex.com/">Space Exploration Technologies Corp.</a>
</p>

<button @onclick="OnClickCallback">
    Trigger a Parent component method
</button>

@code {
    [Parameter]
    public EventCallback<MouseEventArgs> OnClickCallback { get; set; }
}
```

`Shared/UnitedLaunchAlliance2.razor`:

```razor
<h2>United Launch Alliance®</h2>

<p>
    United Launch Alliance and ULA are registered trademarks of
    <a href="https://www.ulalaunch.com/">United Launch Alliance, LLC</a>.
</p>

<button @onclick="OnClickCallback">
    Trigger a Parent component method
</button>

@code {
    [Parameter]
    public EventCallback<MouseEventArgs> OnClickCallback { get; set; }
}
```

`Shared/VirginGalactic2.razor`:

```razor
<h2>Virgin Galactic®</h2>

<p>
    Virgin Galactic is a registered trademark of
    <a href="https://www.virgingalactic.com/">Galactic Enterprises, LLC</a>.
</p>

<button @onclick="OnClickCallback">
    Trigger a Parent component method
</button>

@code {
    [Parameter]
    public EventCallback<MouseEventArgs> OnClickCallback { get; set; }
}
```

In the following parent component example, the `ShowDTMessage` method assigns a string with the current time to `message`, and the value of `message` is rendered.

The parent component passes the callback method, `ShowDTMessage` in the parameter dictionary:

* The `string` key is the callback method's name, `OnClickCallback`.
* The `object` value is created by <xref:Microsoft.AspNetCore.Components.EventCallbackFactory.Create%2A?displayProperty=nameWithType> for the parent callback method, `ShowDTMessage`. Note that the [`this` keyword](/dotnet/csharp/language-reference/keywords/this) isn't supported in C# fields, so a C# property is used for the parameter dictionary.

**For the following component, change the namespace name of `BlazorSample` in the `OnDropdownChange` method to match your app's namespace.**

`Pages/DynamicComponentExample3.razor`:

```razor
@page "/dynamiccomponent-example-3"

<h1><code>DynamicComponent</code> Component Example 3</h1>

<p>
    <label>
        Select your transport:
        <select @onchange="OnDropdownChange">
            <option value="">Select a value</option>
            <option value="@nameof(RocketLab2)">Rocket Lab</option>
            <option value="@nameof(SpaceX2)">SpaceX</option>
            <option value="@nameof(UnitedLaunchAlliance2)">ULA</option>
            <option value="@nameof(VirginGalactic2)">Virgin Galactic</option>
        </select>
    </label>
</p>

@if (selectedType is not null)
{
    <div class="border border-primary my-1 p-1">
        <DynamicComponent Type="@selectedType"
            Parameters="@Components[selectedType.Name].Parameters" />
    </div>
}

<p>
    @message
</p>

@code {
    private Type? selectedType;
    private string? message;

    private Dictionary<string, ComponentMetadata> Components
    {
        get
        {
            return new Dictionary<string, ComponentMetadata>()
            {
                {
                    "RocketLab2",
                    new ComponentMetadata
                    {
                        Name = "Rocket Lab",
                        Parameters =
                            new()
                            {
                                {
                                    "OnClickCallback",
                                    EventCallback.Factory.Create<MouseEventArgs>(
                                        this, ShowDTMessage)
                                }
                            }
                    }
                },
                {
                    "VirginGalactic2",
                    new ComponentMetadata
                    {
                        Name = "Virgin Galactic",
                        Parameters =
                            new()
                            {
                                {
                                    "OnClickCallback",
                                    EventCallback.Factory.Create<MouseEventArgs>(
                                        this, ShowDTMessage)
                                }
                            }
                    }
                },
                {
                    "UnitedLaunchAlliance2",
                    new ComponentMetadata
                    {
                        Name = "ULA",
                        Parameters =
                            new()
                            {
                                {
                                    "OnClickCallback",
                                    EventCallback.Factory.Create<MouseEventArgs>(
                                        this, ShowDTMessage)
                                }
                            }
                    }
                },
                {
                    "SpaceX2",
                    new ComponentMetadata
                    {
                        Name = "SpaceX",
                        Parameters =
                            new()
                            {
                                {
                                    "OnClickCallback",
                                    EventCallback.Factory.Create<MouseEventArgs>(
                                        this, ShowDTMessage)
                                }
                            }
                    }
                }
            };
        }
    }

    private void OnDropdownChange(ChangeEventArgs e)
    {
        selectedType = e.Value?.ToString()?.Length > 0 ?
            Type.GetType($"BlazorSample.Shared.{e.Value}") : null;
    }

    private void ShowDTMessage(MouseEventArgs e) =>
        message = $"The current DT is: {DateTime.Now}.";
}
```

## Avoid catch-all parameters

Avoid the use of [catch-all parameters](xref:blazor/fundamentals/routing#catch-all-route-parameters). If catch-all parameters are used, every explicit parameter on <xref:Microsoft.AspNetCore.Components.DynamicComponent> effectively is a reserved word that you can't pass to a dynamic child. Any new parameters passed to <xref:Microsoft.AspNetCore.Components.DynamicComponent> are a breaking change, as they start shadowing child component parameters that happen to have the same name. It's unlikely that the caller always knows a fixed set of parameter names to pass to all possible dynamic children.

## Trademarks

Rocket Lab is a registered trademark of [Rocket Lab USA Inc.](https://www.rocketlabusa.com/) SpaceX is a registered trademark of [Space Exploration Technologies Corp.](https://www.spacex.com/) United Launch Alliance and ULA are registered trademarks of [United Launch Alliance, LLC](https://www.ulalaunch.com/). Virgin Galactic is a registered trademark of [Galactic Enterprises, LLC](https://www.virgingalactic.com/).

## Additional resources

* <xref:blazor/components/event-handling#eventcallback>

:::moniker-end
