---
title: ASP.NET Core Blazor cascading values and parameters
author: guardrex
description: Learn how to flow data from an ancestor Razor component to descendent components.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/components/cascading-values-and-parameters
---
# ASP.NET Core Blazor cascading values and parameters

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to flow data from an ancestor Razor component to descendent components.

*Cascading values and parameters* provide a convenient way to flow data down a component hierarchy from an ancestor component to any number of descendent components. Unlike [Component parameters](xref:blazor/components/index#component-parameters), cascading values and parameters don't require an attribute assignment for each descendent component where the data is consumed. Cascading values and parameters also allow components to coordinate with each other across a component hierarchy.

> [!NOTE]
> The code examples in this article adopt [nullable reference types (NRTs) and .NET compiler null-state static analysis](xref:migration/50-to-60#nullable-reference-types-nrts-and-net-compiler-null-state-static-analysis), which are supported in ASP.NET Core 6.0 or later. When targeting ASP.NET Core 5.0 or earlier, remove the null type designation (`?`) from the `CascadingType?`, `@ActiveTab?`, `RenderFragment?`, `ITab?`, `TabSet?`, and `string?` types in the article's examples.

:::moniker range=">= aspnetcore-8.0"

## Root-level cascading values

Root-level cascading values can be registered for the entire component hierarchy. Named cascading values and subscriptions for update notifications are supported.

The following class is used in this section's examples.

`Daleks.cs`:

```csharp
// "Dalek" ©Terry Nation https://www.imdb.com/name/nm0622334/
// "Doctor Who" ©BBC https://www.bbc.co.uk/programmes/b006q2x0

public class Daleks
{
    public int Units { get; set; }
}
```

The following registrations are made in the app's `Program` file:

* `Daleks` with a property value for `Units` is registered as a fixed cascading value.
* A second `Daleks` registration with a different property value for `Units` is named "`AlphaGroup`".

```csharp
builder.Services.AddCascadingValue(sp => new Daleks { Units = 123 });
builder.Services.AddCascadingValue("AlphaGroup", sp => new Daleks { Units = 456 });
```

The following `Daleks` component displays the cascaded values.

`Daleks.razor`:

```razor
@page "/daleks"
@rendermode RenderMode.InteractiveServer

<h1>Root-level cascading value registration example</h1>

<ul>
    <li>Dalek Units: @Daleks?.Units</li>
    <li>Alpha Group Dalek Units: @AlphaGroupDaleks?.Units</li>
</ul>

<p>
    Dalek ©<a href="https://www.imdb.com/name/nm0622334/">Terry Nation</a><br>
    Doctor Who ©<a href="https://www.bbc.co.uk/programmes/b006q2x0">BBC</a>
</p>

@code {
    [CascadingParameter]
    public Daleks? Daleks { get; set; }

    [CascadingParameter(Name = "AlphaGroup")]
    public Daleks? AlphaGroupDaleks { get; set; }
}
```

In the following example, `Daleks` is registered as a cascading value using `CascadingValueSource<T>`, where `<T>` is the type. The `isFixed` flag indicates whether the value is fixed. If false, all receipients are subscribed for update notifications, which are issued by calling `NotifyChangedAsync`. Subscriptions create overhead and reduce performance, so set `isFixed` to `true` if the value doesn't change.

```csharp
builder.Services.AddCascadingValue(sp =>
{
    var daleks = new Daleks { Units = 789 };
    var source = new CascadingValueSource<Daleks>(daleks, isFixed: false);
    return source;
});
```

:::moniker-end

## `CascadingValue` component

An ancestor component provides a cascading value using the Blazor framework's [`CascadingValue`](xref:Microsoft.AspNetCore.Components.CascadingValue%601) component, which wraps a subtree of a component hierarchy and supplies a single value to all of the components within its subtree.

The following example demonstrates the flow of theme information down the component hierarchy to provide a CSS style class to buttons in child components.

The following `ThemeInfo` C# class is placed in a folder named `UIThemeClasses` and specifies the theme information.

> [!NOTE]
> For the examples in this section, the app's namespace is `BlazorSample`. When experimenting with the code in your own sample app, change the app's namespace to your sample app's namespace.

`UIThemeClasses/ThemeInfo.cs`:

:::moniker range=">= aspnetcore-7.0"

:::code language="csharp" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/UIThemeClasses/ThemeInfo.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="csharp" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/UIThemeClasses/ThemeInfo.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="csharp" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/UIThemeClasses/ThemeInfo.cs":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="csharp" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/UIThemeClasses/ThemeInfo.cs":::

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

Wrap the markup of the `Routes` component in a [`CascadingValue`](xref:Microsoft.AspNetCore.Components.CascadingValue%601) component to specify theme information (`ThemeInfo`) as a cascading value for all of the app's components.

`Components/Routes.razor`:

```razor
@using BlazorSample.UIThemeClasses

<CascadingValue Value="@theme">
    <Router AppAssembly="@typeof(Program).Assembly">
        <Found Context="routeData">
            <RouteView RouteData="@routeData" DefaultLayout="@typeof(Layout.MainLayout)" />
            <FocusOnNavigate RouteData="@routeData" Selector="h1" />
        </Found>
    </Router>
</CascadingValue>

@code {
    private ThemeInfo theme = new() { ButtonClass = "btn-success" };
}
```

In the `App` component (`Components/App.razor`), adopt an interactive render mode for the entire app. The following example adopts Interactive Server rendering:

```razor
<Routes @rendermode="RenderMode.InteractiveServer" />
```

> [!NOTE]
> The alternative to adopting an interactive render mode for the entire app via the `Routes` component is to specify a *root-level cascading value* for the theme information (`ThemeInfo`) as a service. For more information, see the [Root-level cascading values](#root-level-cascading-values) section.
>
> The following example demonstrates passing theme information in the app's `Program` file:
>
> ```csharp
> builder.Services.AddCascadingValue(sp => 
>     new ThemeInfo() { ButtonClass = "btn-primary" });
> ```
>
> If you adopt this approach, you don't need to set the render mode for the entire app on the `Routes` component or use a [`CascadingValue`](xref:Microsoft.AspNetCore.Components.CascadingValue%601) component in the `Routes` component to pass the theme information to [cascading parameters](#cascadingparameter-attribute).
>
> For more information, see the [Cascading values/parameters and render mode boundaries](#cascading-valuesparameters-and-render-mode-boundaries) section.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

The following [layout component](xref:blazor/components/layouts) specifies theme information (`ThemeInfo`) as a cascading value for all components that make up the layout body of the <xref:Microsoft.AspNetCore.Components.LayoutComponentBase.Body> property. `ButtonClass` is assigned a value of [`btn-success`](https://getbootstrap.com/docs/5.0/components/buttons/), which is a Bootstrap button style. Any descendent component in the component hierarchy can use the `ButtonClass` property through the `ThemeInfo` cascading value.

`MainLayout.razor`:

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/MainLayout.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/MainLayout.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/MainLayout.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/MainLayout.razor":::

:::moniker-end

## `[CascadingParameter]` attribute

To make use of cascading values, descendent components declare cascading parameters using the [`[CascadingParameter]` attribute](xref:Microsoft.AspNetCore.Components.CascadingParameterAttribute). Cascading values are bound to cascading parameters **by type**. Cascading multiple values of the same type is covered in the [Cascade multiple values](#cascade-multiple-values) section later in this article.

The following component binds the `ThemeInfo` cascading value to a cascading parameter, optionally using the same name of `ThemeInfo`. The parameter is used to set the CSS class for the **`Increment Counter (Themed)`** button.

`ThemedCounter.razor`:

:::moniker range=">= aspnetcore-8.0"

```razor
@page "/themed-counter"
@rendermode RenderMode.InteractiveServer
@using BlazorSample.UIThemeClasses

<h1>Themed Counter</h1>

<p>Current count: @currentCount</p>

<p>
    <button @onclick="IncrementCount">
        Increment Counter (Unthemed)
    </button>
</p>

<p>
    <button 
        class="btn @(ThemeInfo is not null ? ThemeInfo.ButtonClass : string.Empty)"
            @onclick="IncrementCount">
        Increment Counter (Themed)
    </button>
</p>

@code {
    private int currentCount = 0;

    [CascadingParameter]
    protected ThemeInfo? ThemeInfo { get; set; }

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/ThemedCounter.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/ThemedCounter.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/ThemedCounter.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/ThemedCounter.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

Similar to a regular component parameter, components accepting a cascading parameter are rerendered when the cascading value is changed. For instance, configuring a different theme instance causes the `ThemedCounter` component from the [`CascadingValue` component](#cascadingvalue-component) section to rerender.

`MainLayout.razor`:

```razor
<main>
    <div class="top-row px-4">
        <a href="https://docs.microsoft.com/aspnet/" target="_blank">About</a>
    </div>

    <CascadingValue Value="@theme">
        <article class="content px-4">
            @Body
        </article>
    </CascadingValue>
    <button @onclick="ChangeToDarkTheme">Dark mode</button>
</main>

@code {
    private ThemeInfo theme = new() { ButtonClass = "btn-success" };
    
    private void ChangeToDarkTheme()
    {
        theme = new() { ButtonClass = "btn-darkmode-success" };
    }
}
```

<xref:Microsoft.AspNetCore.Components.CascadingValue%601.IsFixed%2A?displayProperty=nameWithType> can be used to indicate that a cascading parameter doesn't change after initialization. 

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

## Cascading values/parameters and render mode boundaries

Cascading parameters don't pass data across render mode boundaries:

* Interactive sessions run in a different context than the Static Server-rendered pages. There's no requirement that the server producing the page is even the same machine that hosts some later Interactive Server session, including for WebAssembly components where the server is a different machine to the client. The benefit of Static Server rendering is to gain the full performance of pure stateless HTML rendering.

* State crossing the boundary between static and interactive rendering must be serializable. Components are arbitrary objects that reference a vast chain of other objects, including the renderer, the DI container, and every DI service instance. You must explicitly cause state to be serialized from Static Server rendering to make it available in subsequent interactively-rendered components. Two approaches are adopted:
  * Via the Blazor framework, parameters passed across a Static Server rendering to interactive boundary are serialized automatically if they're JSON-serializable, or an error is thrown.
  * State stored in [`PersistentComponentState`](xref:blazor/components/prerendering-and-integration#persist-prerendered-state) is serialized and recovered automatically if it's JSON-serializable, or an error is thrown.

Cascading parameters aren't JSON-serialize because the typical usage patterns for cascading parameters are somewhat like DI services. There are often platform-specific variants of cascading parameters, so it would be unhelpful to developers if the framework stopped developers from having server-interactive-specific versions or WebAssembly-specific versions. Also, many cascading parameter values in general aren't serializable, so it would be impractical to update existing apps if you had to stop using all nonserializable cascading parameter values.

Recommendations:

* If you need to make state available to all interactive components as a cascading parameter, we recommend using [root-level cascading values](#root-level-cascading-values). A factory pattern is available, and the app can emit updated values after app startup. Root-level cascading values are available to all components, including interactive components, since they're processed as DI services.

* For component library authors, you can create an extension method for library consumers similar to the following:

  ```csharp
  builder.Services.AddLibraryCascadingParameters();
  ```

  Instruct developers to call your extension method. This is a sound alternative to instructed them to add a `<RootComponent>` component in their `MainLayout` component.

:::moniker-end

## Cascade multiple values

To cascade multiple values of the same type within the same subtree, provide a unique <xref:Microsoft.AspNetCore.Components.CascadingValue%601.Name%2A> string to each [`CascadingValue`](xref:Microsoft.AspNetCore.Components.CascadingValue%601) component and their corresponding [`[CascadingParameter]` attributes](xref:Microsoft.AspNetCore.Components.CascadingParameterAttribute).

In the following example, two [`CascadingValue`](xref:Microsoft.AspNetCore.Components.CascadingValue%601) components cascade different instances of `CascadingType`:

```razor
<CascadingValue Value="@parentCascadeParameter1" Name="CascadeParam1">
    <CascadingValue Value="@ParentCascadeParameter2" Name="CascadeParam2">
        ...
    </CascadingValue>
</CascadingValue>

@code {
    private CascadingType? parentCascadeParameter1;

    [Parameter]
    public CascadingType? ParentCascadeParameter2 { get; set; }
}
```

In a descendant component, the cascaded parameters receive their cascaded values from the ancestor component by <xref:Microsoft.AspNetCore.Components.CascadingValue%601.Name%2A>:

```razor
@code {
    [CascadingParameter(Name = "CascadeParam1")]
    protected CascadingType? ChildCascadeParameter1 { get; set; }

    [CascadingParameter(Name = "CascadeParam2")]
    protected CascadingType? ChildCascadeParameter2 { get; set; }
}
```

## Pass data across a component hierarchy

Cascading parameters also enable components to pass data across a component hierarchy. Consider the following UI tab set example, where a tab set component maintains a series of individual tabs.

> [!NOTE]
> For the examples in this section, the app's namespace is `BlazorSample`. When experimenting with the code in your own sample app, change the namespace to your sample app's namespace.

Create an `ITab` interface that tabs implement in a folder named `UIInterfaces`.

`UIInterfaces/ITab.cs`:

```csharp
using Microsoft.AspNetCore.Components;

namespace BlazorSample.UIInterfaces;

public interface ITab
{
    RenderFragment ChildContent { get; }
}
```

> [!NOTE]
> For more information on <xref:Microsoft.AspNetCore.Components.RenderFragment>, see <xref:blazor/components/index#child-content-render-fragments>.

The following `TabSet` component maintains a set of tabs. The tab set's `Tab` components, which are created later in this section, supply the list items (`<li>...</li>`) for the list (`<ul>...</ul>`).

Child `Tab` components aren't explicitly passed as parameters to the `TabSet`. Instead, the child `Tab` components are part of the child content of the `TabSet`. However, the `TabSet` still needs a reference each `Tab` component so that it can render the headers and the active tab. To enable this coordination without requiring additional code, the `TabSet` component *can provide itself as a cascading value* that is then picked up by the descendent `Tab` components.

`TabSet.razor`:

```razor
@using BlazorSample.UIInterfaces

<!-- Display the tab headers -->

<CascadingValue Value="this">
    <ul class="nav nav-tabs">
        @ChildContent
    </ul>
</CascadingValue>

<!-- Display body for only the active tab -->

<div class="nav-tabs-body p-4">
    @ActiveTab?.ChildContent
</div>

@code {
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    public ITab? ActiveTab { get; private set; }

    public void AddTab(ITab tab)
    {
        if (ActiveTab is null)
        {
            SetActiveTab(tab);
        }
    }

    public void SetActiveTab(ITab tab)
    {
        if (ActiveTab != tab)
        {
            ActiveTab = tab;
            StateHasChanged();
        }
    }
}
```

Descendent `Tab` components capture the containing `TabSet` as a cascading parameter. The `Tab` components add themselves to the `TabSet` and coordinate to set the active tab.

`Tab.razor`:

```razor
@using BlazorSample.UIInterfaces
@implements ITab

<li>
    <a @onclick="ActivateTab" class="nav-link @TitleCssClass" role="button">
        @Title
    </a>
</li>

@code {
    [CascadingParameter]
    public TabSet? ContainerTabSet { get; set; }

    [Parameter]
    public string? Title { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    private string? TitleCssClass => 
        ContainerTabSet?.ActiveTab == this ? "active" : null;

    protected override void OnInitialized()
    {
        ContainerTabSet?.AddTab(this);
    }

    private void ActivateTab()
    {
        ContainerTabSet?.SetActiveTab(this);
    }
}
```

The following `ExampleTabSet` component uses the `TabSet` component, which contains three `Tab` components.

`ExampleTabSet.razor`:

```razor
@page "/example-tab-set"

<TabSet>
    <Tab Title="First tab">
        <h4>Greetings from the first tab!</h4>

        <label>
            <input type="checkbox" @bind="showThirdTab" />
            Toggle third tab
        </label>
    </Tab>

    <Tab Title="Second tab">
        <h4>Hello from the second tab!</h4>
    </Tab>

    @if (showThirdTab)
    {
        <Tab Title="Third tab">
            <h4>Welcome to the disappearing third tab!</h4>
            <p>Toggle this tab from the first tab.</p>
        </Tab>
    }
</TabSet>

@code {
    private bool showThirdTab;
}
```
