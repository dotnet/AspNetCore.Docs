---
title: Component Tag Helper in ASP.NET Core
author: guardrex
ms.author: riande
description: Learn how to use the ASP.NET Core Component Tag Helper to render Razor components in pages and views.
monikerRange: '>= aspnetcore-3.1'
ms.custom: mvc
ms.date: 09/25/2023
uid: mvc/views/tag-helpers/builtin-th/component-tag-helper
---
# Component Tag Helper in ASP.NET Core

The Component Tag Helper renders a Razor component in a Razor Pages page or MVC view.

## Prerequisites

:::moniker range=">= aspnetcore-8.0"

Follow the guidance in the *Use non-routable components in pages or views* section of the <xref:blazor/components/integration#use-non-routable-components-in-pages-or-views> article.

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-8.0"

Follow the guidance in the *Configuration* section for either:

* [Blazor Server](xref:blazor/components/prerendering-and-integration?pivots=server): Integrate routable and non-routable Razor components into Razor Pages and MVC apps.
* [Blazor WebAssembly](xref:blazor/components/prerendering-and-integration?pivots=webassembly): Integrate Razor components from a hosted Blazor WebAssembly solution into Razor Pages and MVC apps.

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Follow the guidance in the *Configuration* section of the <xref:blazor/components/prerendering-and-integration?pivots=server> article.

:::moniker-end

## Component Tag Helper

To render a component from a page or view, use the [Component Tag Helper](xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper) (`<component>` tag).

:::moniker range="< aspnetcore-8.0"

> [!NOTE]
> Integrating Razor components into Razor Pages and MVC apps in a *hosted Blazor WebAssembly app* is supported in ASP.NET Core in .NET 5.0 or later.

:::moniker-end

<xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode> configures whether the component:

* Is prerendered into the page.
* Is rendered as static HTML on the page or if it includes the necessary information to bootstrap a Blazor app from the user agent.

:::moniker range=">= aspnetcore-5.0"

Blazor WebAssembly app render modes are shown in the following table.

| Render Mode | Description |
| ----------- | ----------- |
| `WebAssembly` | Renders a marker for a Blazor WebAssembly app for use to include an interactive component when loaded in the browser. The component isn't prerendered. This option makes it easier to render different Blazor WebAssembly components on different pages. |
| `WebAssemblyPrerendered` | Prerenders the component into static HTML and includes a marker for a Blazor WebAssembly app for later use to make the component interactive when loaded in the browser. |

Render modes are shown in the following table.

| Render Mode | Description |
| ----------- | ----------- |
| <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.ServerPrerendered> | Renders the component into static HTML and includes a marker for a server-side Blazor app. When the user-agent starts, this marker is used to bootstrap a Blazor app. |
| <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.Server> | Renders a marker for a server-side Blazor app. Output from the component isn't included. When the user-agent starts, this marker is used to bootstrap a Blazor app. |
| <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.Static> | Renders the component into static HTML. |

:::moniker-end

:::moniker range="< aspnetcore-5.0"

App render modes are shown in the following table.

| Render Mode | Description |
| ----------- | ----------- |
| <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.ServerPrerendered> | Renders the component into static HTML and includes a marker for a server-side Blazor app. When the user-agent starts, this marker is used to bootstrap a Blazor app. |
| <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.Server> | Renders a marker for a server-side Blazor app. Output from the component isn't included. When the user-agent starts, this marker is used to bootstrap a Blazor app. |
| <xref:Microsoft.AspNetCore.Mvc.Rendering.RenderMode.Static> | Renders the component into static HTML. |

:::moniker-end

Additional characteristics include:

* Multiple Component Tag Helpers rendering multiple Razor components is allowed.
* Components can't be dynamically rendered after the app has started.
* While pages and views can use components, the converse isn't true. Components can't use view- and page-specific features, such as partial views and sections. To use logic from a partial view in a component, factor out the partial view logic into a component.
* Rendering server components from a static HTML page isn't supported.

The following Component Tag Helper renders the `EmbeddedCounter` component in a page or view in a server-side Blazor app with `ServerPrerendered`:

:::moniker range=">= aspnetcore-8.0"

```cshtml
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
@using {APP ASSEMBLY}.Components

...

<component type="typeof(EmbeddedCounter)" render-mode="ServerPrerendered" />
```

The preceding example assumes that the `EmbeddedCounter` component is in the app's `Components` folder. The placeholder `{APP ASSEMBLY}` is the app's assembly name (for example, `@using BlazorSample.Components`).

The Component Tag Helper can also pass parameters to components. Consider the following `ColorfulCheckbox` component that sets the checkbox label's color and size.

`Components/ColorfulCheckbox.razor`:

```razor
<label style="font-size:@(Size)px;color:@Color">
    <input @bind="Value"
           id="survey" 
           name="blazor" 
           type="checkbox" />
    Enjoying Blazor?
</label>

@code {
    [Parameter]
    public bool Value { get; set; }

    [Parameter]
    public int Size { get; set; } = 8;

    [Parameter]
    public string? Color { get; set; }

    protected override void OnInitialized()
    {
        Size += 10;
    }
}
```

The `Size` (`int`) and `Color` (`string`) [component parameters](xref:blazor/components/index#component-parameters) can be set by the Component Tag Helper:

```cshtml
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
@using {APP ASSEMBLY}.Components

...

<component type="typeof(ColorfulCheckbox)" render-mode="ServerPrerendered" 
    param-Size="14" param-Color="@("blue")" />
```

The preceding example assumes that the `ColorfulCheckbox` component is in the `Components` folder. The placeholder `{APP ASSEMBLY}` is the app's assembly name (for example, `@using BlazorSample.Components`).

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```cshtml
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
@using {APP ASSEMBLY}.Shared

...

<component type="typeof(EmbeddedCounter)" render-mode="ServerPrerendered" />
```

The preceding example assumes that the `EmbeddedCounter` component is in the app's `Shared` folder. The placeholder `{APP ASSEMBLY}` is the app's assembly name (for example, `@using BlazorSample.Shared` or `@using BlazorSample.Client.Shared` in a hosted Blazor solution).

The Component Tag Helper can also pass parameters to components. Consider the following `ColorfulCheckbox` component that sets the checkbox label's color and size.

`Shared/ColorfulCheckbox.razor`:

```razor
<label style="font-size:@(Size)px;color:@Color">
    <input @bind="Value"
           id="survey" 
           name="blazor" 
           type="checkbox" />
    Enjoying Blazor?
</label>

@code {
    [Parameter]
    public bool Value { get; set; }

    [Parameter]
    public int Size { get; set; } = 8;

    [Parameter]
    public string? Color { get; set; }

    protected override void OnInitialized()
    {
        Size += 10;
    }
}
```

The `Size` (`int`) and `Color` (`string`) [component parameters](xref:blazor/components/index#component-parameters) can be set by the Component Tag Helper:

```cshtml
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
@using {APP ASSEMBLY}.Shared

...

<component type="typeof(ColorfulCheckbox)" render-mode="ServerPrerendered" 
    param-Size="14" param-Color="@("blue")" />
```

The preceding example assumes that the `ColorfulCheckbox` component is in the `Shared` folder. The placeholder `{APP ASSEMBLY}` is the app's assembly name (for example, `@using BlazorSample.Shared`).

:::moniker-end

The following HTML is rendered in the page or view:

```html
<label style="font-size:24px;color:blue">
    <input id="survey" name="blazor" type="checkbox">
    Enjoying Blazor?
</label>
```

Passing a quoted string requires an [explicit Razor expression](xref:mvc/views/razor#explicit-razor-expressions), as shown for `param-Color` in the preceding example. The Razor parsing behavior for a `string` type value doesn't apply to a `param-*` attribute because the attribute is an `object` type.

All types of parameters are supported, except:

* Generic parameters.
* Non-serializable parameters.
* Inheritance in collection parameters.
* Parameters whose type is defined outside of the Blazor WebAssembly app or within a lazily-loaded assembly.
* For receiving a [`RenderFragment` delegate for child content](xref:blazor/components/index#child-content) (for example, `param-ChildContent="..."`). For this scenario, we recommend creating a Razor component (`.razor`) that references the component you want to render with the child content you want to pass and then invoke the Razor component from the page or view with the Component Tag Helper.

The parameter type must be JSON serializable, which typically means that the type must have a default constructor and settable properties. For example, you can specify a value for `Size` and `Color` in the preceding example because the types of `Size` and `Color` are primitive types (`int` and `string`), which are supported by the JSON serializer.

In the following example, a class object is passed to the component:

`MyClass.cs`:

```csharp
public class MyClass
{
    public MyClass()
    {
    }

    public int MyInt { get; set; } = 999;
    public string MyString { get; set; } = "Initial value";
}
```

**The class must have a public parameterless constructor.**

:::moniker range=">= aspnetcore-8.0"

`Components/ParameterComponent.razor`:

```razor
<h2>ParameterComponent</h2>

<p>Int: @MyObject?.MyInt</p>
<p>String: @MyObject?.MyString</p>

@code
{
    [Parameter]
    public MyClass? MyObject { get; set; }
}
```

`Pages/MyPage.cshtml`:

```cshtml
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
@using {APP ASSEMBLY}
@using {APP ASSEMBLY}.Components

...

@{
    var myObject = new MyClass();
    myObject.MyInt = 7;
    myObject.MyString = "Set by MyPage";
}

<component type="typeof(ParameterComponent)" render-mode="ServerPrerendered" 
    param-MyObject="@myObject" />
```

The preceding example assumes that the `ParameterComponent` component is in the app's `Components` folder. The placeholder `{APP ASSEMBLY}` is the app's assembly name (for example, `@using BlazorSample` and `@using BlazorSample.Components`). `MyClass` is in the app's namespace.

:::moniker-end

:::moniker range="< aspnetcore-8.0"

`Shared/ParameterComponent.razor`:

```razor
<h2>ParameterComponent</h2>

<p>Int: @MyObject?.MyInt</p>
<p>String: @MyObject?.MyString</p>

@code
{
    [Parameter]
    public MyClass? MyObject { get; set; }
}
```

`Pages/MyPage.cshtml`:

```cshtml
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
@using {APP ASSEMBLY}
@using {APP ASSEMBLY}.Shared

...

@{
    var myObject = new MyClass();
    myObject.MyInt = 7;
    myObject.MyString = "Set by MyPage";
}

<component type="typeof(ParameterComponent)" render-mode="ServerPrerendered" 
    param-MyObject="@myObject" />
```

The preceding example assumes that the `ParameterComponent` component is in the app's `Shared` folder. The placeholder `{APP ASSEMBLY}` is the app's assembly name (for example, `@using BlazorSample` and `@using BlazorSample.Shared`). `MyClass` is in the app's namespace.

:::moniker-end

## Additional resources

:::moniker range=">= aspnetcore-8.0"

* <xref:mvc/views/tag-helpers/builtin-th/persist-component-state-tag-helper>
* <xref:blazor/components/prerender>
* <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper>
* <xref:mvc/views/tag-helpers/intro>
* <xref:blazor/components/index>

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

* <xref:mvc/views/tag-helpers/builtin-th/persist-component-state-tag-helper>
* <xref:blazor/components/prerendering-and-integration>
* <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper>
* <xref:mvc/views/tag-helpers/intro>
* <xref:blazor/components/index>

:::moniker-end

:::moniker range="< aspnetcore-6.0"

* <xref:blazor/components/prerendering-and-integration>
* <xref:Microsoft.AspNetCore.Mvc.TagHelpers.ComponentTagHelper>
* <xref:mvc/views/tag-helpers/intro>
* <xref:blazor/components/index>

:::moniker-end
