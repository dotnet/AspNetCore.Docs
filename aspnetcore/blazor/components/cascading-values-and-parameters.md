---
title: ASP.NET Core Blazor cascading values and parameters
author: guardrex
description: Learn how to flow data from an ancestor component to descendent components.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 07/06/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/components/cascading-values-and-parameters
---
# ASP.NET Core Blazor cascading values and parameters

By [Luke Latham](https://github.com/guardrex) and [Daniel Roth](https://github.com/danroth27)

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/blazor/common/samples/) ([how to download](xref:index#how-to-download-a-sample))

In some scenarios, it's inconvenient to flow data from an ancestor component to a descendent component using [component parameters](xref:blazor/components/index#component-parameters), especially when there are several component layers. Cascading values and parameters solve this problem by providing a convenient way for an ancestor component to provide a value to all of its descendent components. Cascading values and parameters also provide an approach for components to coordinate.

### Theme example

In the following example from the sample app, the `ThemeInfo` class specifies the theme information to flow down the component hierarchy so that all of the buttons within a given part of the app share the same style.

`UIThemeClasses/ThemeInfo.cs`:

```csharp
public class ThemeInfo
{
    public string ButtonClass { get; set; }
}
```

An ancestor component can provide a cascading value using the Cascading Value component. The <xref:Microsoft.AspNetCore.Components.CascadingValue%601> component wraps a subtree of the component hierarchy and supplies a single value to all components within that subtree.

For example, the sample app specifies theme information (`ThemeInfo`) in one of the app's layouts as a cascading parameter for all components that make up the layout body of the `@Body` property. `ButtonClass` is assigned a value of `btn-success` in the layout component. Any descendent component can consume this property through the `ThemeInfo` cascading object.

`CascadingValuesParametersLayout` component:

```razor
@inherits LayoutComponentBase
@using BlazorSample.UIThemeClasses

<div class="container-fluid">
    <div class="row">
        <div class="col-sm-3">
            <NavMenu />
        </div>
        <div class="col-sm-9">
            <CascadingValue Value="theme">
                <div class="content px-4">
                    @Body
                </div>
            </CascadingValue>
        </div>
    </div>
</div>

@code {
    private ThemeInfo theme = new ThemeInfo { ButtonClass = "btn-success" };
}
```

To make use of cascading values, components declare cascading parameters using the [`[CascadingParameter]`](xref:Microsoft.AspNetCore.Components.CascadingParameterAttribute) attribute. Cascading values are bound to cascading parameters by type.

In the sample app, the `CascadingValuesParametersTheme` component binds the `ThemeInfo` cascading value to a cascading parameter. The parameter is used to set the CSS class for one of the buttons displayed by the component.

`CascadingValuesParametersTheme` component:

```razor
@page "/cascadingvaluesparameterstheme"
@layout CascadingValuesParametersLayout
@using BlazorSample.UIThemeClasses

<h1>Cascading Values & Parameters</h1>

<p>Current count: @currentCount</p>

<p>
    <button class="btn" @onclick="IncrementCount">
        Increment Counter (Unthemed)
    </button>
</p>

<p>
    <button class="btn @ThemeInfo.ButtonClass" @onclick="IncrementCount">
        Increment Counter (Themed)
    </button>
</p>

@code {
    private int currentCount = 0;

    [CascadingParameter]
    protected ThemeInfo ThemeInfo { get; set; }

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

To cascade multiple values of the same type within the same subtree, provide a unique <xref:Microsoft.AspNetCore.Components.CascadingValue%601.Name%2A> string to each <xref:Microsoft.AspNetCore.Components.CascadingValue%601> component and its corresponding [`[CascadingParameter]`](xref:Microsoft.AspNetCore.Components.CascadingParameterAttribute) attribute. In the following example, two <xref:Microsoft.AspNetCore.Components.CascadingValue%601> components cascade different instances of `MyCascadingType` by name:

```razor
<CascadingValue Value="@parentCascadeParameter1" Name="CascadeParam1">
    <CascadingValue Value="@ParentCascadeParameter2" Name="CascadeParam2">
        ...
    </CascadingValue>
</CascadingValue>

@code {
    private MyCascadingType parentCascadeParameter1;

    [Parameter]
    public MyCascadingType ParentCascadeParameter2 { get; set; }

    ...
}
```

In a descendant component, the cascaded parameters receive their values from the corresponding cascaded values in the ancestor component by name:

```razor
...

@code {
    [CascadingParameter(Name = "CascadeParam1")]
    protected MyCascadingType ChildCascadeParameter1 { get; set; }
    
    [CascadingParameter(Name = "CascadeParam2")]
    protected MyCascadingType ChildCascadeParameter2 { get; set; }
}
```

### TabSet example

Cascading parameters also enable components to collaborate across the component hierarchy. For example, consider the following `TabSet` example in the sample app.

The sample app has an `ITab` interface that tabs implement:

[!code-csharp[](../common/samples/3.x/BlazorWebAssemblySample/UIInterfaces/ITab.cs)]

The `CascadingValuesParametersTabSet` component uses the `TabSet` component, which contains several `Tab` components:

```razor
@page "/CascadingValuesParametersTabSet"

<TabSet>
    <Tab Title="First tab">
        <h4>Greetings from the first tab!</h4>

        <label>
            <input type="checkbox" @bind="showThirdTab" />
            Toggle third tab
        </label>
    </Tab>
    <Tab Title="Second tab">
        <h4>The second tab says Hello World!</h4>
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

The child `Tab` components aren't explicitly passed as parameters to the `TabSet`. Instead, the child `Tab` components are part of the child content of the `TabSet`. However, the `TabSet` still needs to know about each `Tab` component so that it can render the headers and the active tab. To enable this coordination without requiring additional code, the `TabSet` component *can provide itself as a cascading value* that is then picked up by the descendent `Tab` components.

`TabSet` component:

[!code-razor[](../common/samples/3.x/BlazorWebAssemblySample/Components/TabSet.razor)]

The descendent `Tab` components capture the containing `TabSet` as a cascading parameter, so the `Tab` components add themselves to the `TabSet` and coordinate on which tab is active.

`Tab` component:

[!code-razor[](../common/samples/3.x/BlazorWebAssemblySample/Components/Tab.razor)]
