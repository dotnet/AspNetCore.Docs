---
title: Blazor components
author: guardrex
description: Learn how to create and use Blazor components, the fundamental building blocks of Blazor apps provided by compiled Razor or C# files.
manager: wpickett
ms.author: riande
ms.custom: mvc
ms.date: 03/31/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: client-side/blazor/components/index
---
# Blazor components

By [Luke Latham](https://github.com/guardrex)

[!INCLUDE[](~/includes/blazor-preview-notice.md)]

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/client-side/blazor/components/common/samples/) ([how to download](xref:tutorials/index#how-to-download-a-sample))

A Blazor *component* represents any feature or collection of features that can be represented by a [Razor file (\*.cshtml)](xref:mvc/views/razor) or a [C# file (\*.cs)](/dotnet/csharp/getting-started/) compiled into a C# class assembly. Components are typical features found in web app client UIs, such as a page, dialog, or form, along with its processing logic. A component can also consist entirely of programming logic without UI elements. Components are the fundamental building blocks of Blazor apps and can be nested, reused, and shared between projects.

## Use of Razor

Razor is a syntax for embedding C# code into HTML markup files. Files containing Razor generally have a *\*.cshtml* file extension. We recommend that you become familiar with Razor while working with Blazor. For more information, see the [Razor syntax reference](xref:mvc/views/razor). Note that not all of the features of Razor are available in Blazor at this time.

The following pair of Blazor components demonstrates how Blazor takes advantage of features in Razor, C#, and HTML. Many of these features are described in more detail later in this topic.

Index page component (*Index.cshtml*):

[!code-cshtml[](common/samples/2.x/ComponentsSample/Pages/Index.cshtml?start=1&end=11)]

When the index page loads, the `HeadingComponent` loads. The component:

* Displays a heading on the page.
* Presents a form that allows the user to change the heading text and control its font style.

Heading component (*HeadingComponent.cshtml*):

[!code-cshtml[](common/samples/2.x/ComponentsSample/Pages/HeadingComponent.cshtml)]

For more information on HTML encoding with WebUtility, see [WebUtility.HtmlEncode](/dotnet/api/system.net.webutility.htmlencode?view=netframework-4.7.1#System_Net_WebUtility_HtmlEncode_System_String_).

## Razor directives

A Razor file for Blazor specifies [Razor directives](xref:mvc/views/razor#directives) at the top of the file using the `@` symbol to distinguish Razor code from HTML markup. Razor directives supported by Blazor are shown in the table. `@model`, `@section`, and Tag Helper directives aren't supported at this time.

| Directive | Description |
| --------- | ----------- |
| [@using](xref:mvc/views/razor#using) | Adds the C# `using` directive to the generated view. |
| [@inherits](xref:mvc/views/razor#inherits) | Provides full control of the class that the component inherits. |
| [@inject](xref:mvc/views/razor#inject) | Enables service injection from the [service container](xref:fundamentals/dependency-injection). For more information, see [Dependency injection into views](xref:mvc/views/dependency-injection). |
| [@functions](xref:mvc/views/razor#functions) | Adds function-level content to a component. Functions include properties and methods accessible to the component. |
| [@page](xref:mvc/razor-pages/index#razor-pages) | Specifies that the component should handle requests directly. The `@page` directive can be specified with a route and optional parameters. Unlike Razor Pages, the `@page` directive doesn't need to be the first directive at the top of the file. |

## Component classes

Blazor's Razor files (*\*.cshtml*) mix HTML markup and C# in the same file, as shown in the sample `HeadingComponent` component above. Blazor doesn't currently support `partial` component classes. However, the `@inherits` directive can be used to provide a Blazor "code-behind" experience.

The [Components Sample app](https://github.com/aspnet/Docs/tree/master/aspnetcore/client-side/blazor/components/common/samples/) shows how a component can inherit a base class, `BlazorRocksBase`, to provide its properties and methods:

*BlazorRocks.cshtml*:

[!code-cshtml[](common/samples/2.x/ComponentsSample/Pages/BlazorRocks.cshtml?start=1&end=8)]

*BlazorRocksBase.cs*:

[!code-cshtml[](common/samples/2.x/ComponentsSample/Pages/BlazorRocksBase.cs)]

The base class must derive from `BlazorComponent` (or implement `IComponent` directly) in the `Microsoft.AspNetCore.Blazor.Components` namespace for this approach to work.

## Data binding

### One-way databinding

One-way databinding is accomplished by prefixing the `@` symbol to any available property. The following example binds:

* The `HeadingFontStyle` property to the CSS property value for `font-style`.
* `HeadingText` to the content of the `<h1>` element.

```cshtml
<h1 style="font-style:@HeadingFontStyle">@HeadingText</h1>
```

### Two-way databinding

Two-way databinding to both components and DOM elements is accomplished with the `bind` attribute. The following example binds the `ItalicsCheck` property to the checkbox's `checked` attribute:

```cshtml
<input type="checkbox" class="form-check-input" 
    id="italicsCheck" bind="@ItalicsCheck">
```

Selecting the checkbox in the UI updates the property's value. Updating the property value in C# code updates the checkbox in the UI.

**Format strings**

Two-way databinding works with DateTime format stings (but not other format expressions at this time, such as currency or number formats):

```cshtml
<input type="date" bind="@StartDate" format="yyyy-MM-dd">

@functions {
    public DateTime StartDate { get; set; } = 
        new DateTime(2020, 1, 1);
}
```

**Component attributes**

Binding also recognizes component attributes, where `bind-{property}` can bind a property value across components.

The following parent component uses `ChildComponent` and binds the value `1979` from `ParentYear` to the child component's `Year` property:

Parent component:

```cshtml
<ChildComponent bind-Year="@ParentYear" />

@functions {
    public int ParentYear { get; set; } = 1979;
}
```

Child component:

```cshtml
<div> ... </div>

@functions {
    public int Year { get; set; }
    public Action<int> ValueChanged { get; set; }
}
```

**User-defined binding**

Other mappings for `bind` can be created:

```cshtml
[BindElement("ul", "foo", "myvalue", "myevent")]
public class BindAttributes
{
}
```

*MyComponent.cshtml*:

```cshtml
<ul bind-foo="@SomeExpression" />
```

**Bind value and change handler attributes**

`bind` can be specified with any value attribute name and change handler attribute name. The following example binds the current value of `SomeExpression` to `myvalue` and a change handler lambda to `myevent`:

```cshtml
<ul bind-myvalue-myevent="@SomeExpression">
    ...
</ul>
```

## Event handling

Blazor offers two event handling features, `@onclick` and `@onchange`. The following code calls the `UpdateHeading` method when the button is selected in the UI:

```cshtml
<button class="btn btn-primary" @onclick(UpdateHeading)>
    Update heading
</button>
```

The following code calls the `CheckboxChanged` method when the checkbox is changed in the UI:

```cshtml
<input type="checkbox" class="form-check-input" 
    id="callsMethodCheck" @onchange(CheckboxChanged)>
```

`OnInit` and `OnInitAsync` execute code after the component has been initialized:

```csharp
protected override void OnInit()
{
    ...
}
```

```csharp
protected override async Task OnInitAsync()
{
    ...
}
```

`OnParametersSet` and `OnParametersSetAsync` are called when a component has received parameters from its parent and the values are assigned to properties. These methods are executed after `OnInit` during component initialization.

```csharp
protected override void OnParametersSet()
{
    ...
}
```

```csharp
protected override async Task OnParametersSetAsync()
{
    ...
}
```

`SetParameters` can be overridden to execute code before parameters are set:

```csharp
public override void SetParameters(ParameterCollection parameters)
{
    ...
    
    base.SetParameters(parameters);
}
```

`ShouldRender` can be overridden to suppress refreshing of the UI. If the implementation returns `true`, the UI is refreshed. Even if `ShouldRender` is overridden, the component is always initially rendered.

```csharp
protected override bool ShouldRender()
{
    var renderUI = true;

    return renderUI;
}
```

## Component disposal with IDisposable

If a component implements [IDisposable](/dotnet/api/system.idisposable), the router disposes the component when the user navigates away from the component. A component can implement `IDisposable` in a C# base class that implements `BlazorComponent` (or `IComponent` directly). The following component uses `@implements IDisposable` and the `Dispose` method:

```csharp
@using System
@implements IDisposable

...

@functions {
    public void Dispose()
    {
        ...
    }
}
```

## Render child content

Blazor components can render child content with an element that matches the child component's name. The following Index page renders the content of the `HeadingComponent` (*HeadingComponent.cshtml*):

[!code-cshtml[](common/samples/2.x/ComponentsSample/Pages/Index.cshtml?start=1&end=11)]

A child component can receive property assignments from their calling parent. In the following example, the `ParentComponent` sets the value of the `Title` property in the `ChildComponent`:

*ParentComponent.cshtml*:

[!code-cshtml[](common/samples/2.x/ComponentsSample/Pages/ParentComponent.cshtml?start=1&end=7)]

*ChildComponent.cshtml*:

[!code-cshtml[](common/samples/2.x/ComponentsSample/Pages/ChildComponent.cshtml)]

The body of the Bootstrap-styled panel is provided by `ChildContent`. `ChildContent` is bound to the `<ChildComponent>` element's content in the parent component by convention.

## Routing

Routing in Blazor is achieved by providing a route template to each accessible component in the app. Route templates are converted into [RouteAttribute](/dotnet/api/microsoft.aspnetcore.mvc.routeattribute) implementations. Multiple route templates can be applied to a component. The following component responds to requests for `/BlazorRoute` and `/DifferentBlazorRoute`:

[!code-cshtml[](common/samples/2.x/ComponentsSample/Pages/BlazorRoute.cshtml?start=1&end=4)]

## Route parameters

Blazor components can receive and use route parameters from the route template provided in the `@page` directive:

*RouteParameter.cshtml*:

[!code-cshtml[](common/samples/2.x/ComponentsSample/Pages/RouteParameter.cshtml?start=1&end=8)]

Not all route parameter constraints are supported at this time. Optional parameters aren't currently supported, so two `@page` directives are applied in the example above. The first permits navigation to the component without a parameter. The second `@page` directive takes the `{text}` route parameter and assigns the value to the `Text` property.

For more information on attribute routing, see [Routing](xref:fundamentals/routing).

## JavaScript/TypeScript interop

To call JavaScript libraries or custom JavaScript/TypeScript code from .NET, the current approach is to register a named function in a JavaScript/TypeScript file:

```javascript
Blazor.registerFunction('doPrompt', message => {
  return prompt(message);
});
```

Wrap the named function for calls from .NET:

```csharp
public static bool DoPrompt(string message)
{
    return RegisteredFunction.Invoke<bool>("doPrompt", message);
}
```

This approach has the benefit of working with JavaScript build tools, such as [webpack](https://webpack.js.org/).

The Mono team is working on a library that exposes standard browser APIs to .NET.
