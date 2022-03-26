---
title: ASP.NET Core Razor components
author: guardrex
description: Learn how to create and use Razor components in Blazor apps, including guidance on Razor syntax, component naming, namespaces, and component parameters.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/09/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/components/index
---
# ASP.NET Core Razor components

This article explains how to create and use Razor components in Blazor apps, including guidance on Razor syntax, component naming, namespaces, and component parameters.

:::moniker range=">= aspnetcore-6.0"

Blazor apps are built using *Razor components*, informally known as *Blazor components*. A component is a self-contained portion of user interface (UI) with processing logic to enable dynamic behavior. Components can be nested, reused, shared among projects, and [used in MVC and Razor Pages apps](xref:blazor/components/prerendering-and-integration).

## Component classes

Components are implemented using a combination of C# and HTML markup in [Razor](xref:mvc/views/razor) component files with the `.razor` file extension.

### Razor syntax

Components use [Razor syntax](xref:mvc/views/razor). Two Razor features are extensively used by components, *directives* and *directive attributes*. These are reserved keywords prefixed with `@` that appear in Razor markup:

* [Directives](xref:mvc/views/razor#directives): Change the way component markup is parsed or functions. For example, the [`@page`][9] directive specifies a routable component with a route template and can be reached directly by a user's request in the browser at a specific URL.
* [Directive attributes](xref:mvc/views/razor#directive-attributes): Change the way a component element is parsed or functions. For example, the [`@bind`][10] directive attribute for an `<input>` element binds data to the element's value.

Directives and directive attributes used in components are explained further in this article and other articles of the Blazor documentation set. For general information on Razor syntax, see <xref:mvc/views/razor>.

### Names

A component's name must start with an uppercase character:

* `ProductDetail.razor` is valid.
* `productDetail.razor` is invalid.

Common Blazor naming conventions used throughout the Blazor documentation include:

* Component file paths use Pascal case&dagger; and appear before showing component code examples. Paths indicate typical folder locations. For example, `Pages/ProductDetail.razor` indicates that the `ProductDetail` component has a file name of `ProductDetail.razor` and resides in the `Pages` folder of the app.
* Component file paths for routable components match their URLs with hyphens appearing for spaces between words in a component's route template. For example, a `ProductDetail` component with a route template of `/product-detail` (`@page "/product-detail"`) is requested in a browser at the relative URL `/product-detail`.

&dagger;Pascal case (upper camel case) is a naming convention without spaces and punctuation and with the first letter of each word capitalized, including the first word.

### Routing

Routing in Blazor is achieved by providing a route template to each accessible component in the app with an [`@page`][9] directive. When a Razor file with an [`@page`][9] directive is compiled, the generated class is given a <xref:Microsoft.AspNetCore.Mvc.RouteAttribute> specifying the route template. At runtime, the router searches for component classes with a <xref:Microsoft.AspNetCore.Mvc.RouteAttribute> and renders whichever component has a route template that matches the requested URL.

The following `HelloWorld` component uses a route template of `/hello-world`. The rendered webpage for the component is reached at the relative URL `/hello-world`. When running a Blazor app locally with the default protocol, host, and port, the `HelloWorld` component is requested in the browser at `https://localhost:5001/hello-world`. Components that produce webpages usually reside in the `Pages` folder, but you can use any folder to hold components, including within nested folders.

`Pages/HelloWorld.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/index/HelloWorld.razor)]

The preceding component loads in the browser at `/hello-world` regardless of whether or not you add the component to the app's UI navigation. Optionally, components can be added to the `NavMenu` component so that a link to the component appears in the app's UI-based navigation.

For the preceding `HelloWorld` component, you can add a `NavLink` component to the `NavMenu` component in the `Shared` folder. For more information, including descriptions of the `NavLink` and `NavMenu` components, see <xref:blazor/fundamentals/routing>.

### Markup

A component's UI is defined using [Razor syntax](xref:mvc/views/razor), which consists of Razor markup, C#, and HTML. When an app is compiled, the HTML markup and C# rendering logic are converted into a component class. The name of the generated class matches the name of the file.

Members of the component class are defined in one or more [`@code`][1] blocks. In [`@code`][1] blocks, component state is specified and processed with C#:

* Property and field initializers.
* Parameter values from arguments passed by parent components and route parameters.
* Methods for user event handling, lifecycle events, and custom component logic.

Component members are used in rendering logic using C# expressions that start with the `@` symbol. For example, a C# field is rendered by prefixing `@` to the field name. The following `Markup` component evaluates and renders:

* `headingFontStyle` for the CSS property value `font-style` of the heading element.
* `headingText` for the content of the heading element.

`Pages/Markup.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/index/Markup.razor)]

> [!NOTE]
> Examples throughout the Blazor documentation specify the [`private` access modifier](/dotnet/csharp/language-reference/keywords/private) for private members. Private members are scoped to a component's class. However, C# assumes the `private` access modifier when no access modifier is present, so explicitly marking members "`private`" in your own code is optional. For more information on access modifiers, see [Access Modifiers (C# Programming Guide)](/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers).

The Blazor framework processes a component internally as a [*render tree*](https://developer.mozilla.org/docs/Web/Performance/How_browsers_work#render), which is the combination of a component's [Document Object Model (DOM)](https://developer.mozilla.org/docs/Web/API/Document_Object_Model/Introduction) and [Cascading Style Sheet Object Model (CSSOM)](https://developer.mozilla.org/docs/Web/API/CSS_Object_Model). After the component is initially rendered, the component's render tree is regenerated in response to events. Blazor compares the new render tree against the previous render tree and applies any modifications to the browser's DOM for display. For more information, see <xref:blazor/components/rendering>.

Components are ordinary [C# classes](/dotnet/csharp/programming-guide/classes-and-structs/classes) and can be placed anywhere within a project. Components that produce webpages usually reside in the `Pages` folder. Non-page components are frequently placed in the `Shared` folder or a custom folder added to the project.

### Asynchronous methods (`async`) don't support returning `void`

The Blazor framework doesn't track `void`-returning asynchronous methods (`async`). As a result, exceptions aren't caught if `void` is returned. Always return a <xref:System.Threading.Tasks.Task> from asynchronous methods.

### Nested components

Components can include other components by declaring them using HTML syntax. The markup for using a component looks like an HTML tag where the name of the tag is the component type.

Consider the following `Heading` component, which can be used by other components to display a heading.

`Shared/Heading.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/index/Heading.razor)]

The following markup in the `HeadingExample` component renders the preceding `Heading` component at the location where the `<Heading />` tag appears.

`Pages/HeadingExample.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/index/HeadingExample.razor)]

If a component contains an HTML element with an uppercase first letter that doesn't match a component name within the same namespace, a warning is emitted indicating that the element has an unexpected name. Adding an [`@using`][2] directive for the component's namespace makes the component available, which resolves the warning. For more information, see the [Namespaces](#namespaces) section.

The `Heading` component example shown in this section doesn't have an [`@page`][9] directive, so the `Heading` component isn't directly accessible to a user via a direct request in the browser. However, any component with an [`@page`][9] directive can be nested in another component. If the `Heading` component was directly accessible by including `@page "/heading"` at the top of its Razor file, then the component would be rendered for browser requests at both `/heading` and `/heading-example`.

### Namespaces

Typically, a component's namespace is derived from the app's root namespace and the component's location (folder) within the app. If the app's root namespace is `BlazorSample` and the `Counter` component resides in the `Pages` folder:

* The `Counter` component's namespace is `BlazorSample.Pages`.
* The fully qualified type name of the component is `BlazorSample.Pages.Counter`.

For custom folders that hold components, add an [`@using`][2] directive to the parent component or to the app's `_Imports.razor` file. The following example makes components in the `Components` folder available:

```razor
@using BlazorSample.Components
```

> [!NOTE]
> [`@using`][2] directives in the `_Imports.razor` file are only applied to Razor files (`.razor`), not C# files (`.cs`).

Components can also be referenced using their fully qualified names, which doesn't require an [`@using`][2] directive. The following example directly references the `ProductDetail` component in the `Components` folder of the app:

```razor
<BlazorSample.Components.ProductDetail />
```

The namespace of a component authored with Razor is based on the following (in priority order):

* The [`@namespace`][8] directive in the Razor file's markup (for example, `@namespace BlazorSample.CustomNamespace`).
* The project's `RootNamespace` in the project file (for example, `<RootNamespace>BlazorSample</RootNamespace>`).
* The project name, taken from the project file's file name (`.csproj`), and the path from the project root to the component. For example, the framework resolves `{PROJECT ROOT}/Pages/Index.razor` with a project namespace of `BlazorSample` (`BlazorSample.csproj`) to the namespace `BlazorSample.Pages` for the `Index` component. `{PROJECT ROOT}` is the project root path. Components follow C# name binding rules. For the `Index` component in this example, the components in scope are all of the components:
  * In the same folder, `Pages`.
  * The components in the project's root that don't explicitly specify a different namespace.

The following are **not** supported:

* The [`global::`](/dotnet/csharp/language-reference/operators/namespace-alias-qualifier) qualification.
* Importing components with aliased [`using`](/dotnet/csharp/language-reference/keywords/using-statement) statements. For example, `@using Foo = Bar` isn't supported.
* Partially-qualified names. For example, you can't add `@using BlazorSample` to a component and then reference the `NavMenu` component in the app's `Shared` folder (`Shared/NavMenu.razor`) with `<Shared.NavMenu></Shared.NavMenu>`.

### Partial class support

Components are generated as [C# partial classes](/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods) and are authored using either of the following approaches:

* A single file contains C# code defined in one or more [`@code`][1] blocks, HTML markup, and Razor markup. Blazor project templates define their components using this single-file approach.
* HTML and Razor markup are placed in a Razor file (`.razor`). C# code is placed in a code-behind file defined as a partial class (`.cs`).

> [!NOTE]
> A component stylesheet that defines component-specific styles is a separate file (`.css`). Blazor CSS isolation is described later in <xref:blazor/components/css-isolation>.

The following example shows the default `Counter` component with an [`@code`][1] block in an app generated from a Blazor project template. Markup and C# code are in the same file. This is the most common approach taken in component authoring.

`Pages/Counter.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/Counter.razor)]

The following `Counter` component splits HTML and Razor markup from  C# code using a code-behind file with a partial class:

`Pages/CounterPartialClass.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/index/CounterPartialClass.razor)]

`Pages/CounterPartialClass.razor.cs`:

[!code-csharp[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/index/CounterPartialClass.razor.cs)]

[`@using`][2] directives in the `_Imports.razor` file are only applied to Razor files (`.razor`), not C# files (`.cs`). Add namespaces to a partial class file as needed.

Typical namespaces used by components:

```csharp
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
```

Typical namespaces also include the namespace of the app and the namespace corresponding to the app's `Shared` folder:

```csharp
using BlazorSample;
using BlazorSample.Shared;
```

### Specify a base class

The [`@inherits`][6] directive is used to specify a base class for a component. The following example shows how a component can inherit a base class to provide the component's properties and methods. The `BlazorRocksBase` base class derives from <xref:Microsoft.AspNetCore.Components.ComponentBase>.

`Pages/BlazorRocks.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/index/BlazorRocks.razor)]

`BlazorRocksBase.cs`:

[!code-csharp[](~/blazor/samples/6.0/BlazorSample_WebAssembly/BlazorRocksBase.cs)]

## Component parameters

*Component parameters* pass data to components and are defined using public [C# properties](/dotnet/csharp/programming-guide/classes-and-structs/properties) on the component class with the [`[Parameter]` attribute](xref:Microsoft.AspNetCore.Components.ParameterAttribute). In the following example, a built-in reference type (<xref:System.String?displayProperty=fullName>) and a user-defined reference type (`PanelBody`) are passed as component parameters.

`PanelBody.cs`:

[!code-csharp[](~/blazor/samples/6.0/BlazorSample_WebAssembly/PanelBody.cs)]

`Shared/ParameterChild.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/index/ParameterChild.razor)]

> [!WARNING]
> Providing initial values for component parameters is supported, but don't create a component that writes to its own parameters after the component is rendered for the first time. For more information, see the [Overwritten parameters](#overwritten-parameters) section of this article.

The `Title` and `Body` component parameters of the `ParameterChild` component are set by arguments in the HTML tag that renders the instance of the component. The following `ParameterParent` component renders two `ParameterChild` components:

* The first `ParameterChild` component is rendered without supplying parameter arguments.
* The second `ParameterChild` component receives values for `Title` and `Body` from the `ParameterParent` component, which uses an [explicit C# expression](xref:mvc/views/razor#explicit-razor-expressions) to set the values of the `PanelBody`'s properties.

`Pages/ParameterParent.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/index/ParameterParent.razor)]

The following rendered HTML markup from the `ParameterParent` component shows `ParameterChild` component default values when the `ParameterParent` component doesn't supply component parameter values. When the `ParameterParent` component provides component parameter values, they replace the `ParameterChild` component's default values.

> [!NOTE]
> For clarity, rendered CSS style classes aren't shown in the following rendered HTML markup.

```html
<h1>Child component (without attribute values)</h1>

<div>
    <div>Set By Child</div>
    <div>Set by child.</div>
</div>

<h1>Child component (with attribute values)</h1>

<div>
    <div>Set by Parent</div>
    <div>Set by parent.</div>
</div>
```

Assign a C# field, property, or result of a method to a component parameter as an HTML attribute value using [Razor's reserved `@` symbol](xref:mvc/views/razor#razor-syntax). The following `ParameterParent2` component displays four instances of the preceding `ParameterChild` component and sets their `Title` parameter values to:

* The value of the `title` field.
* The result of the `GetTitle` C# method.
* The current local date in long format with <xref:System.DateTime.ToLongDateString%2A>, which uses an [implicit C# expression](xref:mvc/views/razor#implicit-razor-expressions).
* The `panelData` object's `Title` property.

The `@` prefix is required for string parameters. Otherwise, the framework assumes that a string literal is set.

Outside of string parameters, we recommend use the use of the `@` prefix for nonliterals, even when they aren't strictly required.

We don't recommend the use of the `@` prefix for literals (for example, boolean values), keywords (for example, `this`), or `null`, but you can choose to use them if you wish. For example, `IsFixed="@true"` is uncommon but supported.

Quotes around parameter attribute values are optional in most cases per the HTML5 specification. For example, `Value=this` is supported, instead of `Value="this"`. However, we recommend using quotes because it's easier to remember and widely adopted across web-based technologies.

Throughout the documentation, code examples:

* Always use quotes. Example: `Value="this"`.
* Nonliterals always use the `@` prefix, even when it's optional. Examples: `Title="@title"`, where `title` is a string-typed variable. `Count="@ct"`, where `ct` is a number-typed variable.
* Literals, outside of Razor expressions, always avoid `@`. Example: `IsFixed="true"`.

`Pages/ParameterParent2.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/index/ParameterParent2.razor)]

> [!NOTE]
> When assigning a C# member to a component parameter, prefix the member with the `@` symbol and never prefix the parameter's HTML attribute.
>
> Correct:
>
> ```razor
> <ParameterChild Title="@title" />
> ```
>
> Incorrect:
>
> ```razor
> <ParameterChild @Title="title" />
> ```

Unlike in Razor pages (`.cshtml`), Blazor can't perform asynchronous work in a Razor expression while rendering a component. This is because Blazor is designed for rendering interactive UIs. In an interactive UI, the screen must always display something, so it doesn't make sense to block the rendering flow. Instead, asynchronous work is performed during one of the [asynchronous lifecycle events](xref:blazor/components/lifecycle). After each asynchronous lifecycle event, the component may render again. The following Razor syntax is **not** supported:

```razor
<ParameterChild Title="@await ..." />
```

The code in the preceding example generates a *compiler error* when the app is built:

> The 'await' operator can only be used within an async method. Consider marking this method with the 'async' modifier and changing its return type to 'Task'.

To obtain a value for the `Title` parameter in the preceding example asynchronously, the component can use the [`OnInitializedAsync` lifecycle event](xref:blazor/components/lifecycle#component-initialization-oninitializedasync), as the following example demonstrates:

```razor
<ParameterChild Title="@title" />

@code {
    private string? title;
    
    protected override async Task OnInitializedAsync()
    {
        title = await ...;
    }
}
```

For more information, see <xref:blazor/components/lifecycle>.

Use of an explicit Razor expression to concatenate text with an expression result for assignment to a parameter is **not** supported. The following example seeks to concatenate the text "`Set by `" with an object's property value. Although this syntax is supported in a Razor page (`.cshtml`), it isn't valid for assignment to the child's `Title` parameter in a component. The following Razor syntax is **not** supported:

```razor
<ParameterChild Title="Set by @(panelData.Title)" />
```

The code in the preceding example generates a *compiler error* when the app is built:

> Component attributes do not support complex content (mixed C# and markup).

To support the assignment of a composed value, use a method, field, or property. The following example performs the concatenation of "`Set by `" and an object's property value in the C# method `GetTitle`:

`Pages/ParameterParent3.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/index/ParameterParent3.razor)]

For more information, see <xref:mvc/views/razor>.

> [!WARNING]
> Providing initial values for component parameters is supported, but don't create a component that writes to its own parameters after the component is rendered for the first time. For more information, see the [Overwritten parameters](#overwritten-parameters) section of this article.

Component parameters should be declared as *auto-properties*, meaning that they shouldn't contain custom logic in their `get` or `set` accessors. For example, the following `StartData` property is an auto-property:

```csharp
[Parameter]
public DateTime StartData { get; set; }
```

Don't place custom logic in the `get` or `set` accessor because component parameters are purely intended for use as a channel for a parent component to flow information to a child component. If a `set` accessor of a child component property contains logic that causes rerendering of the parent component, an infinite rendering loop results.

To transform a received parameter value:

* Leave the parameter property as an auto-property to represent the supplied raw data.
* Create a different property or method to supply the transformed data based on the parameter property.

Override [`OnParametersSetAsync`](xref:blazor/components/lifecycle#after-parameters-are-set-onparameterssetasync) to transform a received parameter each time new data is received.

Writing an initial value to a component parameter is supported because initial value assignments don't interfere with the Blazor's automatic component rendering. The following assignment of the current local <xref:System.DateTime> with <xref:System.DateTime.Now?displayProperty=nameWithType> to `StartData` is valid syntax in a component:

```csharp
[Parameter]
public DateTime StartData { get; set; } = DateTime.Now;
```

After the initial assignment of <xref:System.DateTime.Now?displayProperty=nameWithType>, do **not** assign a value to `StartData` in developer code. For more information, see the [Overwritten parameters](#overwritten-parameters) section of this article.

Apply the [`[EditorRequired]` attribute](xref:Microsoft.AspNetCore.Components.EditorRequiredAttribute) to specify a required component parameter. If a parameter value isn't provided, editors or build tools may display warnings to the user. This attribute is only valid on properties also marked with the [`[Parameter]` attribute](xref:Microsoft.AspNetCore.Components.ParameterAttribute). The <xref:Microsoft.AspNetCore.Components.EditorRequiredAttribute> is enforced at design-time and when the app is built. The attribute isn't enforced at runtime, and it doesn't guarantee a non-`null` parameter value.

```csharp
[Parameter]
[EditorRequired]
public string? Title { get; set; }
```

Single-line attribute lists are also supported:

```csharp
[Parameter, EditorRequired]
public string? Title { get; set; }
```

[`Tuples`](/dotnet/csharp/language-reference/builtin-types/value-tuples) ([API documentation](xref:System.Tuple)) are supported for component parameters and [`RenderFragment`](#child-content) types. The following component parameter example passes three values in a `Tuple`:

`Shared/RenderTupleChild.razor`:

```csharp
<div class="card w-50" style="margin-bottom:15px">
    <div class="card-header font-weight-bold"><code>Tuple</code> Card</div>
    <div class="card-body">
        <ul>
            <li>Integer: @Data?.Item1</li>
            <li>String: @Data?.Item2</li>
            <li>Boolean: @Data?.Item3</li>
        </ul>
    </div>
</div>

@code {
    [Parameter]
    public Tuple<int, string, bool>? Data { get; set; }
}
```

`Pages/RenderTupleParent.razor`:

```csharp
@page "/render-tuple-parent"

<h1>Render <code>Tuple</code> Parent</h1>

<RenderTupleChild Data="@data" />

@code {
    private Tuple<int, string, bool> data = new(999, "I aim to misbehave.", true);
}
```
    
Only ***unnamed tuples*** are supported for C# 7.0 or later in Razor components. [Named tuples](/dotnet/csharp/language-reference/builtin-types/value-tuples#tuple-field-names) support in Razor components is planned for a future ASP.NET Core release. For more information, see [Blazor Transpiler issue with named Tuples (dotnet/aspnetcore #28982)](https://github.com/dotnet/aspnetcore/issues/28982).

Quote &copy;2005 [Universal Pictures](https://www.uphe.com): [Serenity](https://www.uphe.com/movies/serenity-2005) ([Nathan Fillion](https://www.imdb.com/name/nm0277213/))

## Route parameters

Components can specify route parameters in the route template of the [`@page`][9] directive. The [Blazor router](xref:blazor/fundamentals/routing) uses route parameters to populate corresponding component parameters.

Optional route parameters are supported. In the following example, the `text` optional parameter assigns the value of the route segment to the component's `Text` property. If the segment isn't present, the value of `Text` is set to "`fantastic`" in the [`OnInitialized` lifecycle method](xref:blazor/components/lifecycle#component-initialization-oninitializedasync).

`Pages/RouteParameter.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/index/RouteParameter.razor?highlight=1,6-7)]

For information on catch-all route parameters (`{*pageRoute}`), which capture paths across multiple folder boundaries, see <xref:blazor/fundamentals/routing#catch-all-route-parameters>.

## Overwritten parameters

The Blazor framework generally imposes safe parent-to-child parameter assignment:

* Parameters aren't overwritten unexpectedly.
* Side-effects are minimized. For example, additional renders are avoided because they may create infinite rendering loops.

A child component receives new parameter values that possibly overwrite existing values when the parent component rerenders. Accidentally overwriting parameter values in a child component often occurs when developing the component with one or more data-bound parameters and the developer writes directly to a parameter in the child:

* The child component is rendered with one or more parameter values from the parent component.
* The child writes directly to the value of a parameter.
* The parent component rerenders and overwrites the value of the child's parameter.

The potential for overwriting parameter values extends into the child component's property `set` accessors, too.

> [!IMPORTANT]
> Our general guidance is not to create components that directly write to their own parameters after the component is rendered for the first time.

Consider the following faulty `Expander` component that:

* Renders child content.
* Toggles showing child content with a component parameter (`Expanded`).
* The component writes directly to the `Expanded` parameter, which demonstrates the problem with overwritten parameters and should be avoided.

After the following `Expander` component demonstrates the incorrect approach for this scenario, a modified `Expander` component is shown to demonstrate the correct approach. The following examples can be placed in a local sample app to experience the behaviors described.

`Shared/Expander.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/index/BadExpander.razor)]

The `Expander` component is added to the following `ExpanderExample` parent component that may call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A>:

* Calling <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> in developer code notifies a component that its state has changed and typically triggers component rerendering to update the UI. <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> is covered in more detail later in <xref:blazor/components/lifecycle> and <xref:blazor/components/rendering>.
* The button's `@onclick` directive attribute attaches an event handler to the button's `onclick` event. Event handling is covered in more detail later in <xref:blazor/components/event-handling>.

`Pages/ExpanderExample.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/index/ExpanderExample.razor)]

Initially, the `Expander` components behave independently when their `Expanded` properties are toggled. The child components maintain their states as expected. When <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> is called in the parent, the `Expanded` parameter of the first child component is reset back to its initial value (`true`). The second `Expander` component's `Expanded` value isn't reset because no child content is rendered in the second component.

To maintain state in the preceding scenario, use a *private field* in the `Expander` component to maintain its toggled state.

The following revised `Expander` component:

* Accepts the `Expanded` component parameter value from the parent.
* Assigns the component parameter value to a *private field* (`expanded`) in the [`OnInitialized` event](xref:blazor/components/lifecycle#component-initialization-oninitializedasync).
* Uses the private field to maintain its internal toggle state, which demonstrates how to avoid writing directly to a parameter.

> [!NOTE]
> The advice in this section extends to similar logic in component parameter `set` accessors, which can result in similar undesirable side-effects.

`Shared/Expander.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/index/Expander.razor)]

For two-way parent-child binding examples, see <xref:blazor/components/data-binding#binding-with-component-parameters>. For additional information, see [Blazor Two Way Binding Error (dotnet/aspnetcore #24599)](https://github.com/dotnet/aspnetcore/issues/24599).

## Child content

Components can set the content of another component. The assigning component provides the content between the child component's opening and closing tags.

In the following example, the `RenderFragmentChild` component has a `ChildContent` property that represents a segment of the UI to render as a <xref:Microsoft.AspNetCore.Components.RenderFragment>. The position of `ChildContent` in the component's Razor markup is where the content is rendered in the final HTML output.

`Shared/RenderFragmentChild.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/index/RenderFragmentChild.razor)]

> [!IMPORTANT]
> The property receiving the <xref:Microsoft.AspNetCore.Components.RenderFragment> content must be named `ChildContent` by convention.
>
> [Event callbacks](xref:blazor/components/event-handling#eventcallback) aren't supported for <xref:Microsoft.AspNetCore.Components.RenderFragment>.

The following `RenderFragmentParent` component provides content for rendering the `RenderFragmentChild` by placing the content inside the child component's opening and closing tags.

`Pages/RenderFragmentParent.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/index/RenderFragmentParent.razor)]

Due to the way that Blazor renders child content, rendering components inside a [`for`](/dotnet/csharp/language-reference/keywords/for) loop requires a local index variable if the incrementing loop variable is used in the `RenderFragmentChild` component's content. The following example can be added to the preceding `RenderFragmentParent` component:

```razor
<h1>Three children with an index variable</h1>

@for (int c = 0; c < 3; c++)
{
    var current = c;

    <RenderFragmentChild>
        Count: @current
    </RenderFragmentChild>
}
```

Alternatively, use a [`foreach`](/dotnet/csharp/language-reference/keywords/foreach-in) loop with <xref:System.Linq.Enumerable.Range%2A?displayProperty=nameWithType> instead of a [`for`](/dotnet/csharp/language-reference/keywords/for) loop. The following example can be added to the preceding `RenderFragmentParent` component:

```razor
<h1>Second example of three children with an index variable</h1>

@foreach (var c in Enumerable.Range(0,3))
{
    <RenderFragmentChild>
        Count: @c
    </RenderFragmentChild>
}
```

> [!NOTE]
> Assignment to a <xref:Microsoft.AspNetCore.Components.RenderFragment> delegate is only supported in Razor component files (`.razor`):
> 
> ```razor
> private RenderFragment RenderWelcomeInfo = __builder =>
> {
>     <p>Welcome to your new app!</p>
> };
> ```
>
> For more information, see <xref:blazor/performance#define-reusable-renderfragments-in-code>.

For information on how a <xref:Microsoft.AspNetCore.Components.RenderFragment> can be used as a template for component UI, see the following articles:

* <xref:blazor/components/templated-components>
* <xref:blazor/performance#define-reusable-renderfragments-in-code>

## Attribute splatting and arbitrary parameters

Components can capture and render additional attributes in addition to the component's declared parameters. Additional attributes can be captured in a dictionary and then *splatted* onto an element when the component is rendered using the [`@attributes`][3] Razor directive attribute. This scenario is useful for defining a component that produces a markup element that supports a variety of customizations. For example, it can be tedious to define attributes separately for an `<input>` that supports many parameters.

In the following `Splat` component:

* The first `<input>` element (`id="useIndividualParams"`) uses individual component parameters.
* The second `<input>` element (`id="useAttributesDict"`) uses attribute splatting.

`Pages/Splat.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/index/Splat.razor)]

The rendered `<input>` elements in the webpage are identical:

```html
<input id="useIndividualParams"
       maxlength="10"
       placeholder="Input placeholder text"
       required="required"
       size="50">

<input id="useAttributesDict"
       maxlength="10"
       placeholder="Input placeholder text"
       required="required"
       size="50">
```

To accept arbitrary attributes, define a [component parameter](#component-parameters) with the <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues> property set to `true`:

```razor
@code {
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object>? InputAttributes { get; set; }
}
```

The <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues> property on [`[Parameter]`](xref:Microsoft.AspNetCore.Components.ParameterAttribute) allows the parameter to match all attributes that don't match any other parameter. A component can only define a single parameter with <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues>. The property type used with <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues> must be assignable from [`Dictionary<string, object>`](xref:System.Collections.Generic.Dictionary%602) with string keys. Use of [`IEnumerable<KeyValuePair<string, object>>`](xref:System.Collections.Generic.IEnumerable%601) or [`IReadOnlyDictionary<string, object>`](xref:System.Collections.Generic.IReadOnlyDictionary%602) are also options in this scenario.

The position of [`@attributes`][3] relative to the position of element attributes is important. When [`@attributes`][3] are splatted on the element, the attributes are processed from right to left (last to first). Consider the following example of a parent component that consumes a child component:

`Shared/AttributeOrderChild1.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/index/AttributeOrderChild1.razor)]

`Pages/AttributeOrderParent1.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/index/AttributeOrderParent1.razor)]

The `AttributeOrderChild1` component's `extra` attribute is set to the right of [`@attributes`][3]. The `AttributeOrderParent1` component's rendered `<div>` contains `extra="5"` when passed through the additional attribute because the attributes are processed right to left (last to first):

```html
<div extra="5" />
```

In the following example, the order of `extra` and [`@attributes`][3] is reversed in the child component's `<div>`:

`Shared/AttributeOrderChild2.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/index/AttributeOrderChild2.razor)]

`Pages/AttributeOrderParent2.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/index/AttributeOrderParent2.razor)]

The `<div>` in the parent component's rendered webpage contains `extra="10"` when passed through the additional attribute:

```html
<div extra="10" />
```

## Capture references to components

Component references provide a way to reference a component instance for issuing commands. To capture a component reference:

* Add an [`@ref`][4] attribute to the child component.
* Define a field with the same type as the child component.

When the component is rendered, the field is populated with the component instance. You can then invoke .NET methods on the instance.

Consider the following `ReferenceChild` component that logs a message when its `ChildMethod` is called.

`Shared/ReferenceChild.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/index/ReferenceChild.razor)]

A component reference is only populated after the component is rendered and its output includes `ReferenceChild`'s element. Until the component is rendered, there's nothing to reference.

To manipulate component references after the component has finished rendering, use the [`OnAfterRender` or `OnAfterRenderAsync` methods](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync).

To use a reference variable with an event handler, use a lambda expression or assign the event handler delegate in the [`OnAfterRender` or `OnAfterRenderAsync` methods](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync). This ensures that the reference variable is assigned before the event handler is assigned.

The following lambda approach uses the preceding `ReferenceChild` component.

`Pages/ReferenceParent1.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/index/ReferenceParent1.razor)]

The following delegate approach uses the preceding `ReferenceChild` component.

`Pages/ReferenceParent2.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/index/ReferenceParent2.razor)]

While capturing component references use a similar syntax to [capturing element references](xref:blazor/js-interop/call-javascript-from-dotnet#capture-references-to-elements), capturing component references isn't a JavaScript interop feature. Component references aren't passed to JavaScript code. Component references are only used in .NET code.

> [!IMPORTANT]
> Do **not** use component references to mutate the state of child components. Instead, use normal declarative component parameters to pass data to child components. Use of component parameters result in child components that rerender at the correct times automatically. For more information, see the [component parameters](#component-parameters) section and the <xref:blazor/components/data-binding> article.

## Synchronization context

Blazor uses a synchronization context (<xref:System.Threading.SynchronizationContext>) to enforce a single logical thread of execution. A component's [lifecycle methods](xref:blazor/components/lifecycle) and event callbacks raised by Blazor are executed on the synchronization context.

Blazor Server's synchronization context attempts to emulate a single-threaded environment so that it closely matches the WebAssembly model in the browser, which is single threaded. At any given point in time, work is performed on exactly one thread, which yields the impression of a single logical thread. No two operations execute concurrently.

### Avoid thread-blocking calls

Generally, don't call the following methods in components. The following methods block the execution thread and thus block the app from resuming work until the underlying <xref:System.Threading.Tasks.Task> is complete:

* <xref:System.Threading.Tasks.Task%601.Result%2A>
* <xref:System.Threading.Tasks.Task.Wait%2A>
* <xref:System.Threading.Tasks.Task.WaitAny%2A>
* <xref:System.Threading.Tasks.Task.WaitAll%2A>
* <xref:System.Threading.Thread.Sleep%2A>
* <xref:System.Runtime.CompilerServices.TaskAwaiter.GetResult%2A>

> [!NOTE]
> Blazor documentation examples that use the thread-blocking methods mentioned in this section are only using the methods for demonstration purposes, not as recommended coding guidance. For example, a few component code demonstrations simulate a long-running process by calling <xref:System.Threading.Thread.Sleep%2A?displayProperty=nameWithType>.

### Invoke component methods externally to update state

In the event a component must be updated based on an external event, such as a timer or other notification, use the `InvokeAsync` method, which dispatches code execution to Blazor's synchronization context. For example, consider the following *notifier service* that can notify any listening component about updated state. The `Update` method can be called from anywhere in the app.

`TimerService.cs`:

[!code-csharp[](~/blazor/samples/6.0/BlazorSample_WebAssembly/TimerService.cs)]

`NotifierService.cs`:

[!code-csharp[](~/blazor/samples/6.0/BlazorSample_WebAssembly/NotifierService.cs)]

Register the services:

* In a Blazor WebAssembly app, register the services as singletons in `Program.cs`:

  ```csharp
  builder.Services.AddSingleton<NotifierService>();
  builder.Services.AddSingleton<TimerService>();
  ```

* In a Blazor Server app, register the services as scoped in `Program.cs`:

  ```csharp
  builder.Services.AddScoped<NotifierService>();
  builder.Services.AddScoped<TimerService>();
  ```

Use the `NotifierService` to update a component.

`Pages/ReceiveNotifications.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/index/ReceiveNotifications.razor)]

In the preceding example:

* `NotifierService` invokes the component's `OnNotify` method outside of Blazor's synchronization context. `InvokeAsync` is used to switch to the correct context and queue a render. For more information, see <xref:blazor/components/rendering>.
* The component implements <xref:System.IDisposable>. The `OnNotify` delegate is unsubscribed in the `Dispose` method, which is called by the framework when the component is disposed. For more information, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>.

## Use `@key` to control the preservation of elements and components

When rendering a list of elements or components and the elements or components subsequently change, Blazor must decide which of the previous elements or components can be retained and how model objects should map to them. Normally, this process is automatic and can be ignored, but there are cases where you may want to control the process.

Consider the following `Details` and `People` components:

* The `Details` component receives data (`Data`) from the parent `People` component, which is displayed in an `<input>` element. Any given displayed `<input>` element can receive the focus of the page from the user when they select one of the `<input>` elements.
* The `People` component creates a list of person objects for display using the `Details` component. Every three seconds, a new person is added to the collection.

This demonstration allows you to:

* Select an `<input>` from among several rendered `Details` components.
* Study the behavior of the page's focus as the people collection automatically grows.

`Shared/Details.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/index/Details.razor)]

In the following `People` component, each iteration of adding a person in `OnTimerCallback` results in Blazor rebuilding the entire collection. The page's focus remains on the *same index* position of `<input>` elements, so the focus shifts each time a person is added. *Shifting the focus away from what the user selected isn't desirable behavior.* After demonstrating the poor behavior with the following component, the [`@key`][5] directive attribute is used to improve the user's experience.

`Pages/People.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/index/People.razor)]

The contents of the `people` collection changes with inserted, deleted, or re-ordered entries. Rerendering can lead to visible behavior differences. Each time a person is inserted into the `people` collection, the *preceding element* of the currently focused element receives the focus. The user's focus is lost.

The mapping process of elements or components to a collection can be controlled with the [`@key`][5] directive attribute. Use of [`@key`][5] guarantees the preservation of elements or components based on the key's value. If the `Details` component in the preceding example is keyed on the `person` item, Blazor ignores rerendering `Details` components that haven't changed.

To modify the `People` component to use the [`@key`][5] directive attribute with the `people` collection, update the `<Details>` element to the following:

```razor
<Details @key="person" Data="@person.Data" />
```

When the `people` collection changes, the association between `Details` instances and `person` instances is retained. When a `Person` is inserted at the beginning of the collection, one new `Details` instance is inserted at that corresponding position. Other instances are left unchanged. Therefore, the user's focus isn't lost as people are added to the collection.

Other collection updates exhibit the same behavior when the [`@key`][5] directive attribute is used:

* If an instance is deleted from the collection, only the corresponding component instance is removed from the UI. Other instances are left unchanged.
* If collection entries are re-ordered, the corresponding component instances are preserved and re-ordered in the UI.

> [!IMPORTANT]
> Keys are local to each container element or component. Keys aren't compared globally across the document.

### When to use `@key`

Typically, it makes sense to use [`@key`][5] whenever a list is rendered (for example, in a [`foreach`](/dotnet/csharp/language-reference/keywords/foreach-in) block) and a suitable value exists to define the [`@key`][5].

You can also use [`@key`][5] to preserve an element or component subtree when an object doesn't change, as the following examples show.

Example 1:

```razor
<li @key="person">
    <input value="@person.Data" />
</li>
```

Example 2:

```razor
<div @key="person">
    @* other HTML elements *@
</div>
```

If an `person` instance changes, the [`@key`][5] attribute directive forces Blazor to:

* Discard the entire `<li>` or `<div>` and their descendants.
* Rebuild the subtree within the UI with new elements and components.

This is useful to guarantee that no UI state is preserved when the collection changes within a subtree.

### Scope of `@key`

The [`@key`][5] attribute directive is scoped to its own siblings within its parent.

Consider the following example. The `first` and `second` keys are compared against each other within the same scope of the outer `<div>` element:

```razor
<div>
    <div @key="first">...</div>
    <div @key="second">...</div>
</div>
```

The following example demonstrates `first` and `second` keys in their own scopes, unrelated to each other and without influence on each other. Each [`@key`][5] scope only applies to its parent `<div>` element, not across the parent `<div>` elements:

```razor
<div>
    <div @key="first">...</div>
</div>
<div>
    <div @key="second">...</div>
</div>
```

For the `Details` component shown earlier, the following examples render `person` data within the same [`@key`][5] scope and demonstrate typical use cases for [`@key`][5]:

```razor
<div>
    @foreach (var person in people)
    {
        <Details @key="person" Data="@person.Data" />
    }
</div>
```

```razor
@foreach (var person in people)
{
    <div @key="person">
        <Details Data="@person.Data" />
    </div>
}
```

```razor
<ol>
    @foreach (var person in people)
    {
        <li @key="person">
            <Details Data="@person.Data" />
        </li>
    }
</ol>
```

The following examples only scope [`@key`][5] to the `<div>` or `<li>` element that surrounds each `Details` component instance. Therefore, `person` data for each member of the `people` collection is **not** keyed on each `person` instance across the rendered `Details` components. Avoid the following patterns when using [`@key`][5]:

```razor
@foreach (var person in people)
{
    <div>
        <Details @key="person" Data="@person.Data" />
    </div>
}
```

```razor
<ol>
    @foreach (var person in people)
    {
        <li>
            <Details @key="person" Data="@person.Data" />
        </li>
    }
</ol>
```

### When not to use `@key`

There's a performance cost when rendering with [`@key`][5]. The performance cost isn't large, but only specify [`@key`][5] if preserving the element or component benefits the app.

Even if [`@key`][5] isn't used, Blazor preserves child element and component instances as much as possible. The only advantage to using [`@key`][5] is control over *how* model instances are mapped to the preserved component instances, instead of Blazor selecting the mapping.

### Values to use for `@key`

Generally, it makes sense to supply one of the following values for [`@key`][5]:

* Model object instances. For example, the `Person` instance (`person`) was used in the earlier example. This ensures preservation based on object reference equality.
* Unique identifiers. For example, unique identifiers can be based on primary key values of type `int`, `string`, or `Guid`.

Ensure that values used for [`@key`][5] don't clash. If clashing values are detected within the same parent element, Blazor throws an exception because it can't deterministically map old elements or components to new elements or components. Only use distinct values, such as object instances or primary key values.

## Apply an attribute

Attributes can be applied to components with the [`@attribute`][7] directive. The following example applies the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) to the component's class:

```razor
@page "/"
@attribute [Authorize]
```

## Conditional HTML element attributes

HTML element attribute properties are conditionally set based on the .NET value. If the value is `false` or `null`, the property isn't set. If the value is `true`, the property is set.

In the following example, `IsCompleted` determines if the `<input>` element's `checked` property is set.

`Pages/ConditionalAttribute.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/index/ConditionalAttribute.razor)]

For more information, see <xref:mvc/views/razor>.

> [!WARNING]
> Some HTML attributes, such as [`aria-pressed`](https://developer.mozilla.org/docs/Web/Accessibility/ARIA/Roles/button_role#Toggle_buttons), don't function properly when the .NET type is a `bool`. In those cases, use a `string` type instead of a `bool`.

## Raw HTML

Strings are normally rendered using DOM text nodes, which means that any markup they may contain is ignored and treated as literal text. To render raw HTML, wrap the HTML content in a <xref:Microsoft.AspNetCore.Components.MarkupString> value. The value is parsed as HTML or SVG and inserted into the DOM.

> [!WARNING]
> Rendering raw HTML constructed from any untrusted source is a **security risk** and should **always** be avoided.

The following example shows using the <xref:Microsoft.AspNetCore.Components.MarkupString> type to add a block of static HTML content to the rendered output of a component.

`Pages/MarkupStringExample.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/index/MarkupStringExample.razor)]

## Razor templates

Render fragments can be defined using Razor template syntax to define a UI snippet. Razor templates use the following format:

```razor
@<{HTML tag}>...</{HTML tag}>
```

The following example illustrates how to specify <xref:Microsoft.AspNetCore.Components.RenderFragment> and <xref:Microsoft.AspNetCore.Components.RenderFragment%601> values and render templates directly in a component. Render fragments can also be passed as arguments to [templated components](xref:blazor/components/templated-components).

`Pages/RazorTemplate.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/index/RazorTemplate.razor)]

Rendered output of the preceding code:

```html
<p>The time is 4/19/2021 8:54:46 AM.</p>
<p>Pet: Nutty Rex</p>
```

## Static assets

Blazor follows the convention of ASP.NET Core apps for static assets. Static assets are located in the project's [`web root` (`wwwroot`) folder](xref:fundamentals/index#web-root) or folders under the `wwwroot` folder.

Use a base-relative path (`/`) to refer to the web root for a static asset. In the following example, `logo.png` is physically located in the `{PROJECT ROOT}/wwwroot/images` folder. `{PROJECT ROOT}` is the app's project root.

```razor
<img alt="Company logo" src="/images/logo.png" />
```

Components do **not** support tilde-slash notation (`~/`).

For information on setting an app's base path, see <xref:blazor/host-and-deploy/index#app-base-path>.

## Tag Helpers aren't supported in components

[`Tag Helpers`](xref:mvc/views/tag-helpers/intro) aren't supported in components. To provide Tag Helper-like functionality in Blazor, create a component with the same functionality as the Tag Helper and use the component instead.

## Scalable Vector Graphics (SVG) images

Since Blazor renders HTML, browser-supported images, including [Scalable Vector Graphics (SVG) images (`.svg`)](https://developer.mozilla.org/docs/Web/SVG), are supported via the `<img>` tag:

```html
<img alt="Example image" src="image.svg" />
```

Similarly, SVG images are supported in the CSS rules of a stylesheet file (`.css`):

```css
.element-class {
    background-image: url("image.svg");
}
```

Blazor supports the [`<foreignObject>`](https://developer.mozilla.org/docs/Web/SVG/Element/foreignObject) element to display arbitrary HTML within an SVG. The markup can represent arbitrary HTML, a <xref:Microsoft.AspNetCore.Components.RenderFragment>, or a Razor component.

The following example demonstrates:

* Display of a `string` (`@message`).
* Two-way binding with an `<input>` element and a `value` field.
* A `Robot` component.

```razor
<svg width="200" height="200" xmlns="http://www.w3.org/2000/svg">
    <rect x="0" y="0" rx="10" ry="10" width="200" height="200" stroke="black" 
        fill="none" />
    <foreignObject x="20" y="20" width="160" height="160">
        <p>@message</p>
    </foreignObject>
</svg>

<svg xmlns="http://www.w3.org/2000/svg">
    <foreignObject width="200" height="200">
        <label>
            Two-way binding:
            <input @bind="value" @bind:event="oninput" />
        </label>
    </foreignObject>
</svg>

<svg xmlns="http://www.w3.org/2000/svg">
    <foreignObject>
        <Robot />
    </foreignObject>
</svg>

@code {
    private string message = "Lorem ipsum dolor sit amet, consectetur adipiscing " +
        "elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.";

    private string? value;
}
```

## Whitespace rendering behavior

Unless the [`@preservewhitespace`](xref:mvc/views/razor#preservewhitespace) directive is used with a value of `true`, extra whitespace is removed by default if:

* Leading or trailing within an element.
* Leading or trailing within a <xref:Microsoft.AspNetCore.Components.RenderFragment>/<xref:Microsoft.AspNetCore.Components.RenderFragment%601> parameter (for example, child content passed to another component).
* It precedes or follows a C# code block, such as `@if` or `@foreach`.

Whitespace removal might affect the rendered output when using a CSS rule, such as `white-space: pre`. To disable this performance optimization and preserve the whitespace, take one of the following actions:

* Add the `@preservewhitespace true` directive at the top of the Razor file (`.razor`) to apply the preference to a specific component.
* Add the `@preservewhitespace true` directive inside an `_Imports.razor` file to apply the preference to a subdirectory or to the entire project.

In most cases, no action is required, as apps typically continue to behave normally (but faster). If stripping whitespace causes a rendering problem for a particular component, use `@preservewhitespace true` in that component to disable this optimization.

## Generic type parameter support

The [`@typeparam`][11] directive declares a [generic type parameter](/dotnet/csharp/programming-guide/generics/generic-type-parameters) for the generated component class:

```razor
@typeparam TItem
```

C# syntax with [`where`](/dotnet/csharp/language-reference/keywords/where-generic-type-constraint) type constraints is supported:

```razor
@typeparam TEntity where TEntity : IEntity
```

In the following example, the `ListGenericTypeItems1` component is generically typed as `TExample`.

`Shared/ListGenericTypeItems1.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Shared/index/ListGenericTypeItems1.razor)]

The following `GenericTypeExample1` component renders two `ListGenericTypeItems1` components:

* String or integer data is assigned to the `ExampleList` parameter of each component.
* Type `string` or `int` that matches the type of the assigned data is set for the type parameter (`TExample`) of each component.

`Pages/GenericTypeExample1.razor`:

[!code-razor[](~/blazor/samples/6.0/BlazorSample_WebAssembly/Pages/index/GenericTypeExample1.razor)]

For more information, see <xref:mvc/views/razor#typeparam>. For an example of generic typing with templated components, see <xref:blazor/components/templated-components>.

## Cascaded generic type support

An ancestor component can cascade a type parameter by name to descendants using the [`[CascadingTypeParameter]` attribute](xref:Microsoft.AspNetCore.Components.CascadingTypeParameterAttribute). This attribute allows a generic type inference to use the specified type parameter automatically with descendants that have a type parameter with the same name.

By adding `@attribute [CascadingTypeParameter(...)]` to a component, the specified generic type argument is automatically used by descendants that:

* Are nested as child content for the component in the same `.razor` document.
* Also declare a [`@typeparam`](xref:mvc/views/razor#typeparam) with the exact same name.
* Don't have another value explicitly supplied or implicitly inferred for the type parameter. If another value is supplied or inferred, it takes precedence over the cascaded generic type.

When receiving a cascaded type parameter, components obtain the parameter value from the closest ancestor that has a <xref:Microsoft.AspNetCore.Components.CascadingTypeParameterAttribute> with a matching name. Cascaded generic type parameters are overridden within a particular subtree.

Matching is only performed by name. Therefore, we recommend avoiding a cascaded generic type parameter with a generic name, for example `T` or `TItem`. If a developer opts into cascading a type parameter, they're implicitly promising that its name is unique enough not to clash with other cascaded type parameters from unrelated components.

Generic types can be cascaded to child components in either of the following approaches with ancestor (parent) components, which are demonstrated in the following two sub-sections:

* Explicitly set the cascaded generic type.
* Infer the cascaded generic type.

The following subsections provide examples of the preceding approaches using the following two `ListDisplay` components. The components receive and render list data and are generically typed as `TExample`. These components are for demonstration purposes and only differ in the color of text that the list is rendered. If you wish to experiment with the components in the following sub-sections in a local test app, add the following two components to the app first.

`Shared/ListDisplay1.razor`:

```razor
@typeparam TExample

@if (ExampleList is not null)
{
    <ul style="color:blue">
        @foreach (var item in ExampleList)
        {
            <li>@item</li>
        }
    </ul>
}

@code {
    [Parameter]
    public IEnumerable<TExample>? ExampleList { get; set; }
}
```

`Shared/ListDisplay2.razor`:

```razor
@typeparam TExample

@if (ExampleList is not null)
{
    <ul style="color:red">
        @foreach (var item in ExampleList)
        {
            <li>@item</li>
        }
    </ul>
}

@code {
    [Parameter]
    public IEnumerable<TExample>? ExampleList { get; set; }
}
```

### Explicit generic types based on ancestor components

The demonstration in this section cascades a type explicitly for `TExample`.

> [!NOTE]
> This section uses the two `ListDisplay` components in the [Cascaded generic type support](#cascaded-generic-type-support) section.

The following `ListGenericTypeItems2` component receives data and cascades a generic type parameter named `TExample` to its descendent components. In the upcoming parent component, the `ListGenericTypeItems2` component is used to display list data with the preceding `ListDisplay` component.

`Shared/ListGenericTypeItems2.razor`:

```razor
@attribute [CascadingTypeParameter(nameof(TExample))]
@typeparam TExample

<h2>List Generic Type Items 2</h2>

@ChildContent

@code {
    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
```

The following `GenericTypeExample2` parent component sets the child content (<xref:Microsoft.AspNetCore.Components.RenderFragment>) of two `ListGenericTypeItems2` components specifying the `ListGenericTypeItems2` types (`TExample`), which are cascaded to child components. `ListDisplay` components are rendered with the list item data shown in the example. String data is used with the first `ListGenericTypeItems2` component, and integer data is used with the second `ListGenericTypeItems2` component.

`Pages/GenericTypeExample2.razor`:

```razor
@page "/generic-type-example-2"

<h1>Generic Type Example 2</h1>

<ListGenericTypeItems2 TExample="string">
    <ListDisplay1 ExampleList="@(new List<string> { "Item 1", "Item 2" })" />
    <ListDisplay2 ExampleList="@(new List<string> { "Item 3", "Item 4" })" />
</ListGenericTypeItems2>

<ListGenericTypeItems2 TExample="int">
    <ListDisplay1 ExampleList="@(new List<int> { 1, 2, 3 })" />
    <ListDisplay2 ExampleList="@(new List<int> { 4, 5, 6 })" />
</ListGenericTypeItems2>
```

Specifying the type explicitly also allows the use of [cascading values and parameters](xref:blazor/components/cascading-values-and-parameters) to provide data to child components, as the following demonstration shows.

`Shared/ListDisplay3.razor`:

```razor
@typeparam TExample

@if (ExampleList is not null)
{
    <ul style="color:blue">
        @foreach (var item in ExampleList)
        {
            <li>@item</li>
        }
    </ul>
}

@code {
    [CascadingParameter]
    protected IEnumerable<TExample>? ExampleList { get; set; }
}
```

`Shared/ListDisplay4.razor`:

```razor
@typeparam TExample

@if (ExampleList is not null)
{
    <ul style="color:red">
        @foreach (var item in ExampleList)
        {
            <li>@item</li>
        }
    </ul>
}

@code {
    [CascadingParameter]
    protected IEnumerable<TExample>? ExampleList { get; set; }
}
```

`Shared/ListGenericTypeItems3.razor`:

```razor
@attribute [CascadingTypeParameter(nameof(TExample))]
@typeparam TExample

<h2>List Generic Type Items 3</h2>

@ChildContent

@if (ExampleList is not null)
{
    <ul style="color:green">
        @foreach(var item in ExampleList)
        {
            <li>@item</li>
        }
    </ul>

    <p>
        Type of <code>TExample</code>: @typeof(TExample)
    </p>
}

@code {
    [CascadingParameter]
    protected IEnumerable<TExample>? ExampleList { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
```

When cascading the data in the following example, the type must be provided to the `ListGenericTypeItems3` component.

`Pages/GenericTypeExample3.razor`:

```razor
@page "/generic-type-example-3"

<h1>Generic Type Example 3</h1>

<CascadingValue Value="@stringData">
    <ListGenericTypeItems3 TExample="string">
        <ListDisplay3 />
        <ListDisplay4 />
    </ListGenericTypeItems3>
</CascadingValue>

<CascadingValue Value="@integerData">
    <ListGenericTypeItems3 TExample="int">
        <ListDisplay3 />
        <ListDisplay4 />
    </ListGenericTypeItems3>
</CascadingValue>

@code {
    private List<string> stringData = new() { "Item 1", "Item 2" };
    private List<int> integerData = new() { 1, 2, 3 };
}
```

When multiple generic types are cascaded, values for all generic types in the set must be passed. In the following example, `TItem`, `TValue`, and `TEdit` are `GridColumn` generic types, but the parent component that places `GridColumn` doesn't specify the `TItem` type:

```razor
<GridColumn TValue="string" TEdit="@TextEdit" />
```

The preceding example generates a compile-time error that the `GridColumn` component is missing the `TItem` type parameter. Valid code specifies all of the types:

```razor
<GridColumn TValue="string" TEdit="@TextEdit" TItem="@User" />
```

### Infer generic types based on ancestor components

The demonstration in this section cascades a type inferred for `TExample`.

> [!NOTE]
> This section uses the two `ListDisplay` components in the [Cascaded generic type support](#cascaded-generic-type-support) section.

`Shared/ListGenericTypeItems4.razor`:

```razor
@attribute [CascadingTypeParameter(nameof(TExample))]
@typeparam TExample

<h2>List Generic Type Items 4</h2>

@ChildContent

@if (ExampleList is not null)
{
    <ul style="color:green">
        @foreach(var item in ExampleList)
        {
            <li>@item</li>
        }
    </ul>

    <p>
        Type of <code>TExample</code>: @typeof(TExample)
    </p>
}

@code {
    [Parameter]
    public IEnumerable<TExample>? ExampleList { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }
}
```

The following `GenericTypeExample4` component with inferred cascaded types provides different data for display.

`Pages/GenericTypeExample4.razor`:

```razor
@page "/generic-type-example-4"

<h1>Generic Type Example 4</h1>

<ListGenericTypeItems4 ExampleList="@(new List<string> { "Item 5", "Item 6" })">
    <ListDisplay1 ExampleList="@(new List<string> { "Item 1", "Item 2" })" />
    <ListDisplay2 ExampleList="@(new List<string> { "Item 3", "Item 4" })" />
</ListGenericTypeItems4>

<ListGenericTypeItems4 ExampleList="@(new List<int> { 7, 8, 9 })">
    <ListDisplay1 ExampleList="@(new List<int> { 1, 2, 3 })" />
    <ListDisplay2 ExampleList="@(new List<int> { 4, 5, 6 })" />
</ListGenericTypeItems4>
```

The following `GenericTypeExample5` component with inferred cascaded types provides the same data for display. The following example directly assigns the data to the components.

`Pages/GenericTypeExample5.razor`:

```razor
@page "/generic-type-example-5"

<h1>Generic Type Example 5</h1>

<ListGenericTypeItems4 ExampleList="@stringData">
    <ListDisplay1 ExampleList="@stringData" />
    <ListDisplay2 ExampleList="@stringData" />
</ListGenericTypeItems4>

<ListGenericTypeItems4 ExampleList="@integerData">
    <ListDisplay1 ExampleList="@integerData" />
    <ListDisplay2 ExampleList="@integerData" />
</ListGenericTypeItems4>

@code {
    private List<string> stringData = new() { "Item 1", "Item 2" };
    private List<int> integerData = new() { 1, 2, 3 };
}
```

## Render Razor components from JavaScript

Razor components can be dynamically-rendered from JavaScript (JS) for existing JS apps.

To render a Razor component from JS, register the component as a root component for JS rendering and assign the component an identifier:

* In a Blazor Server app, modify the call to <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A> in `Program.cs`:

  ```csharp
  builder.Services.AddServerSideBlazor(options =>
  {
      options.RootComponents.RegisterForJavaScript<Counter>(identifier: "counter");
  });
  ```
  
  > [!NOTE]
  > The preceding code example requires a namespace for the app's components (for example, `using BlazorSample.Pages;`) in the `Program.cs` file.

* In a Blazor WebAssembly app, call <xref:Microsoft.AspNetCore.Components.Web.JSComponentConfigurationExtensions.RegisterForJavaScript%2A> on <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.RootComponents> in `Program.cs`:

  ```csharp
  builder.RootComponents.RegisterForJavaScript<Counter>(identifier: "counter");
  ```
  
  > [!NOTE]
  > The preceding code example requires a namespace for the app's components (for example, `using BlazorSample.Pages;`) in the `Program.cs` file.

Load Blazor into the JS app (`blazor.server.js` or `blazor.webassembly.js`). Render the component from JS into a container element using the registered identifier, passing component parameters as needed:

```javascript
let containerElement = document.getElementById('my-counter');
await Blazor.rootComponents.add(containerElement, 'counter', { incrementAmount: 10 });
```

## Blazor custom elements

*Experimental* support is available for building custom elements using the [`Microsoft.AspNetCore.Components.CustomElements` NuGet package](https://www.nuget.org/packages/microsoft.aspnetcore.components.customelements). Custom elements use standard HTML interfaces to implement custom HTML elements.

> [!WARNING]
> Experimental features are provided for the purpose of exploring feature viability and may not ship in a stable version.

Register a root component as a custom element:

* In a Blazor Server app, modify the call to <xref:Microsoft.Extensions.DependencyInjection.ComponentServiceCollectionExtensions.AddServerSideBlazor%2A> in `Program.cs`:

  ```csharp
  builder.Services.AddServerSideBlazor(options =>
  {
      options.RootComponents.RegisterAsCustomElement<Counter>("my-counter");
  });
  ```
  
  > [!NOTE]
  > The preceding code example requires a namespace for the app's components (for example, `using BlazorSample.Pages;`) in the `Program.cs` file.

* In a Blazor WebAssembly app, call `RegisterAsCustomElement` on <xref:Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyHostBuilder.RootComponents> in `Program.cs`:

  ```csharp
  builder.RootComponents.RegisterAsCustomElement<Counter>("my-counter");
  ```
  
  > [!NOTE]
  > The preceding code example requires a namespace for the app's components (for example, `using BlazorSample.Pages;`) in the `Program.cs` file.

Include the following `<script>` tag in the app's HTML ***before*** the Blazor script tag:

```html
<script src="/_content/Microsoft.AspNetCore.Components.CustomElements/BlazorCustomElements.js"></script>
```

Use the custom element with any web framework. For example, the preceding counter custom element is used in a React app with the following markup:

```html
<my-counter increment-amount={incrementAmount}></my-counter>
```

For a complete example of how to create custom elements with Blazor, see the [Blazor Custom Elements sample project](https://github.com/aspnet/AspLabs/tree/main/src/BlazorCustomElements).

> [!WARNING]
> The custom elements feature is currently **experimental, unsupported, and subject to change or be removed at any time**. We welcome your feedback on how well this particular approach meets your requirements.

## Generate Angular and React components

Generate framework-specific JavaScript (JS) components from Razor components for web frameworks, such as Angular or React. This capability isn't included with .NET 6, but is enabled by the new support for rendering Razor components from JS. The [JS component generation sample on GitHub](https://github.com/aspnet/samples/tree/main/samples/aspnetcore/blazor/JSComponentGeneration) demonstrates how to generate Angular and React components from Razor components. See the GitHub sample app's `README.md` file for additional information.

> [!WARNING]
> The Angular and React component features are currently **experimental, unsupported, and subject to change or be removed at any time**. We welcome your feedback on how well this particular approach meets your requirements.

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

Blazor apps are built using *Razor components*, informally known as *Blazor components*. A component is a self-contained portion of user interface (UI) with processing logic to enable dynamic behavior. Components can be nested, reused, shared among projects, and [used in MVC and Razor Pages apps](xref:blazor/components/prerendering-and-integration).

## Component classes

Components are implemented using a combination of C# and HTML markup in [Razor](xref:mvc/views/razor) component files with the `.razor` file extension.

### Razor syntax

Components use [Razor syntax](xref:mvc/views/razor). Two Razor features are extensively used by components, *directives* and *directive attributes*. These are reserved keywords prefixed with `@` that appear in Razor markup:

* [Directives](xref:mvc/views/razor#directives): Change the way component markup is parsed or functions. For example, the [`@page`][9] directive specifies a routable component with a route template and can be reached directly by a user's request in the browser at a specific URL.
* [Directive attributes](xref:mvc/views/razor#directive-attributes): Change the way a component element is parsed or functions. For example, the [`@bind`][10] directive attribute for an `<input>` element binds data to the element's value.

Directives and directive attributes used in components are explained further in this article and other articles of the Blazor documentation set. For general information on Razor syntax, see <xref:mvc/views/razor>.

### Names

A component's name must start with an uppercase character:

* `ProductDetail.razor` is valid.
* `productDetail.razor` is invalid.

Common Blazor naming conventions used throughout the Blazor documentation include:

* Component file paths use Pascal case&dagger; and appear before showing component code examples. Paths indicate typical folder locations. For example, `Pages/ProductDetail.razor` indicates that the `ProductDetail` component has a file name of `ProductDetail.razor` and resides in the `Pages` folder of the app.
* Component file paths for routable components match their URLs with hyphens appearing for spaces between words in a component's route template. For example, a `ProductDetail` component with a route template of `/product-detail` (`@page "/product-detail"`) is requested in a browser at the relative URL `/product-detail`.

&dagger;Pascal case (upper camel case) is a naming convention without spaces and punctuation and with the first letter of each word capitalized, including the first word.

### Routing

Routing in Blazor is achieved by providing a route template to each accessible component in the app with an [`@page`][9] directive. When a Razor file with an [`@page`][9] directive is compiled, the generated class is given a <xref:Microsoft.AspNetCore.Mvc.RouteAttribute> specifying the route template. At runtime, the router searches for component classes with a <xref:Microsoft.AspNetCore.Mvc.RouteAttribute> and renders whichever component has a route template that matches the requested URL.

The following `HelloWorld` component uses a route template of `/hello-world`. The rendered webpage for the component is reached at the relative URL `/hello-world`. When running a Blazor app locally with the default protocol, host, and port, the `HelloWorld` component is requested in the browser at `https://localhost:5001/hello-world`. Components that produce webpages usually reside in the `Pages` folder, but you can use any folder to hold components, including within nested folders.

`Pages/HelloWorld.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/index/HelloWorld.razor)]

The preceding component loads in the browser at `/hello-world` regardless of whether or not you add the component to the app's UI navigation. Optionally, components can be added to the `NavMenu` component so that a link to the component appears in the app's UI-based navigation.

For the preceding `HelloWorld` component, you can add a `NavLink` component to the `NavMenu` component in the `Shared` folder. For more information, including descriptions of the `NavLink` and `NavMenu` components, see <xref:blazor/fundamentals/routing>.

### Markup

A component's UI is defined using [Razor syntax](xref:mvc/views/razor), which consists of Razor markup, C#, and HTML. When an app is compiled, the HTML markup and C# rendering logic are converted into a component class. The name of the generated class matches the name of the file.

Members of the component class are defined in one or more [`@code`][1] blocks. In [`@code`][1] blocks, component state is specified and processed with C#:

* Property and field initializers.
* Parameter values from arguments passed by parent components and route parameters.
* Methods for user event handling, lifecycle events, and custom component logic.

Component members are used in rendering logic using C# expressions that start with the `@` symbol. For example, a C# field is rendered by prefixing `@` to the field name. The following `Markup` component evaluates and renders:

* `headingFontStyle` for the CSS property value `font-style` of the heading element.
* `headingText` for the content of the heading element.

`Pages/Markup.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/index/Markup.razor)]

> [!NOTE]
> Examples throughout the Blazor documentation specify the [`private` access modifier](/dotnet/csharp/language-reference/keywords/private) for private members. Private members are scoped to a component's class. However, C# assumes the `private` access modifier when no access modifier is present, so explicitly marking members "`private`" in your own code is optional. For more information on access modifiers, see [Access Modifiers (C# Programming Guide)](/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers).

The Blazor framework processes a component internally as a [*render tree*](https://developer.mozilla.org/docs/Web/Performance/How_browsers_work#render), which is the combination of a component's [Document Object Model (DOM)](https://developer.mozilla.org/docs/Web/API/Document_Object_Model/Introduction) and [Cascading Style Sheet Object Model (CSSOM)](https://developer.mozilla.org/docs/Web/API/CSS_Object_Model). After the component is initially rendered, the component's render tree is regenerated in response to events. Blazor compares the new render tree against the previous render tree and applies any modifications to the browser's DOM for display. For more information, see <xref:blazor/components/rendering>.

Components are ordinary [C# classes](/dotnet/csharp/programming-guide/classes-and-structs/classes) and can be placed anywhere within a project. Components that produce webpages usually reside in the `Pages` folder. Non-page components are frequently placed in the `Shared` folder or a custom folder added to the project.

### Asynchronous methods (`async`) don't support returning `void`

The Blazor framework doesn't track `void`-returning asynchronous methods (`async`). As a result, exceptions aren't caught if `void` is returned. Always return a <xref:System.Threading.Tasks.Task> from asynchronous methods.

### Nested components

Components can include other components by declaring them using HTML syntax. The markup for using a component looks like an HTML tag where the name of the tag is the component type.

Consider the following `Heading` component, which can be used by other components to display a heading.

`Shared/Heading.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Shared/index/Heading.razor)]

The following markup in the `HeadingExample` component renders the preceding `Heading` component at the location where the `<Heading />` tag appears.

`Pages/HeadingExample.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/index/HeadingExample.razor)]

If a component contains an HTML element with an uppercase first letter that doesn't match a component name within the same namespace, a warning is emitted indicating that the element has an unexpected name. Adding an [`@using`][2] directive for the component's namespace makes the component available, which resolves the warning. For more information, see the [Namespaces](#namespaces) section.

The `Heading` component example shown in this section doesn't have an [`@page`][9] directive, so the `Heading` component isn't directly accessible to a user via a direct request in the browser. However, any component with an [`@page`][9] directive can be nested in another component. If the `Heading` component was directly accessible by including `@page "/heading"` at the top of its Razor file, then the component would be rendered for browser requests at both `/heading` and `/heading-example`.

### Namespaces

Typically, a component's namespace is derived from the app's root namespace and the component's location (folder) within the app. If the app's root namespace is `BlazorSample` and the `Counter` component resides in the `Pages` folder:

* The `Counter` component's namespace is `BlazorSample.Pages`.
* The fully qualified type name of the component is `BlazorSample.Pages.Counter`.

For custom folders that hold components, add an [`@using`][2] directive to the parent component or to the app's `_Imports.razor` file. The following example makes components in the `Components` folder available:

```razor
@using BlazorSample.Components
```

> [!NOTE]
> [`@using`][2] directives in the `_Imports.razor` file are only applied to Razor files (`.razor`), not C# files (`.cs`).

Components can also be referenced using their fully qualified names, which doesn't require an [`@using`][2] directive. The following example directly references the `ProductDetail` component in the `Components` folder of the app:

```razor
<BlazorSample.Components.ProductDetail />
```

The namespace of a component authored with Razor is based on the following (in priority order):

* The [`@namespace`][8] directive in the Razor file's markup (for example, `@namespace BlazorSample.CustomNamespace`).
* The project's `RootNamespace` in the project file (for example, `<RootNamespace>BlazorSample</RootNamespace>`).
* The project name, taken from the project file's file name (`.csproj`), and the path from the project root to the component. For example, the framework resolves `{PROJECT ROOT}/Pages/Index.razor` with a project namespace of `BlazorSample` (`BlazorSample.csproj`) to the namespace `BlazorSample.Pages` for the `Index` component. `{PROJECT ROOT}` is the project root path. Components follow C# name binding rules. For the `Index` component in this example, the components in scope are all of the components:
  * In the same folder, `Pages`.
  * The components in the project's root that don't explicitly specify a different namespace.

The following are **not** supported:

* The [`global::`](/dotnet/csharp/language-reference/operators/namespace-alias-qualifier) qualification.
* Importing components with aliased [`using`](/dotnet/csharp/language-reference/keywords/using-statement) statements. For example, `@using Foo = Bar` isn't supported.
* Partially-qualified names. For example, you can't add `@using BlazorSample` to a component and then reference the `NavMenu` component in the app's `Shared` folder (`Shared/NavMenu.razor`) with `<Shared.NavMenu></Shared.NavMenu>`.

### Partial class support

Components are generated as [C# partial classes](/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods) and are authored using either of the following approaches:

* A single file contains C# code defined in one or more [`@code`][1] blocks, HTML markup, and Razor markup. Blazor project templates define their components using this single-file approach.
* HTML and Razor markup are placed in a Razor file (`.razor`). C# code is placed in a code-behind file defined as a partial class (`.cs`).

> [!NOTE]
> A component stylesheet that defines component-specific styles is a separate file (`.css`). Blazor CSS isolation is described later in <xref:blazor/components/css-isolation>.

The following example shows the default `Counter` component with an [`@code`][1] block in an app generated from a Blazor project template. Markup and C# code are in the same file. This is the most common approach taken in component authoring.

`Pages/Counter.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/Counter.razor)]

The following `Counter` component splits HTML and Razor markup from  C# code using a code-behind file with a partial class:

`Pages/CounterPartialClass.razor`:

```razor
@page "/counter-partial-class"

<h1>Counter</h1>

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>
```

`Pages/CounterPartialClass.razor.cs`:

```csharp
namespace BlazorSample.Pages
{
    public partial class CounterPartialClass
    {
        private int currentCount = 0;

        void IncrementCount()
        {
            currentCount++;
        }
    }
}
```

[`@using`][2] directives in the `_Imports.razor` file are only applied to Razor files (`.razor`), not C# files (`.cs`). Add namespaces to a partial class file as needed.

Typical namespaces used by components:

```csharp
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.JSInterop;
```

Typical namespaces also include the namespace of the app and the namespace corresponding to the app's `Shared` folder:

```csharp
using BlazorSample;
using BlazorSample.Shared;
```

### Specify a base class

The [`@inherits`][6] directive is used to specify a base class for a component. The following example shows how a component can inherit a base class to provide the component's properties and methods. The `BlazorRocksBase` base class derives from <xref:Microsoft.AspNetCore.Components.ComponentBase>.

`Pages/BlazorRocks.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/index/BlazorRocks.razor)]

`BlazorRocksBase.cs`:

[!code-csharp[](~/blazor/samples/5.0/BlazorSample_WebAssembly/BlazorRocksBase.cs)]

## Component parameters

*Component parameters* pass data to components and are defined using public [C# properties](/dotnet/csharp/programming-guide/classes-and-structs/properties) on the component class with the [`[Parameter]` attribute](xref:Microsoft.AspNetCore.Components.ParameterAttribute). In the following example, a built-in reference type (<xref:System.String?displayProperty=fullName>) and a user-defined reference type (`PanelBody`) are passed as component parameters.

`PanelBody.cs`:

[!code-csharp[](~/blazor/samples/5.0/BlazorSample_WebAssembly/PanelBody.cs)]

`Shared/ParameterChild.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Shared/index/ParameterChild.razor)]

> [!WARNING]
> Providing initial values for component parameters is supported, but don't create a component that writes to its own parameters after the component is rendered for the first time. For more information, see the [Overwritten parameters](#overwritten-parameters) section of this article.

The `Title` and `Body` component parameters of the `ParameterChild` component are set by arguments in the HTML tag that renders the instance of the component. The following `ParameterParent` component renders two `ParameterChild` components:

* The first `ParameterChild` component is rendered without supplying parameter arguments.
* The second `ParameterChild` component receives values for `Title` and `Body` from the `ParameterParent` component, which uses an [explicit C# expression](xref:mvc/views/razor#explicit-razor-expressions) to set the values of the `PanelBody`'s properties.

`Pages/ParameterParent.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/index/ParameterParent.razor)]

The following rendered HTML markup from the `ParameterParent` component shows `ParameterChild` component default values when the `ParameterParent` component doesn't supply component parameter values. When the `ParameterParent` component provides component parameter values, they replace the `ParameterChild` component's default values.

> [!NOTE]
> For clarity, rendered CSS style classes aren't shown in the following rendered HTML markup.

```html
<h1>Child component (without attribute values)</h1>

<div>
    <div>Set By Child</div>
    <div>Set by child.</div>
</div>

<h1>Child component (with attribute values)</h1>

<div>
    <div>Set by Parent</div>
    <div>Set by parent.</div>
</div>
```

Assign a C# field, property, or result of a method to a component parameter as an HTML attribute value using [Razor's reserved `@` symbol](xref:mvc/views/razor#razor-syntax). The following `ParameterParent2` component displays four instances of the preceding `ParameterChild` component and sets their `Title` parameter values to:

* The value of the `title` field.
* The result of the `GetTitle` C# method.
* The current local date in long format with <xref:System.DateTime.ToLongDateString%2A>, which uses an [implicit C# expression](xref:mvc/views/razor#implicit-razor-expressions).
* The `panelData` object's `Title` property.

The `@` prefix is required for string parameters. Otherwise, the framework assumes that a string literal is set.

Outside of string parameters, we recommend use the use of the `@` prefix for nonliterals, even when they aren't strictly required.

We don't recommend the use of the `@` prefix for literals (for example, boolean values), keywords (for example, `this`), or `null`, but you can choose to use them if you wish. For example, `IsFixed="@true"` is uncommon but supported.

Quotes around parameter attribute values are optional in most cases per the HTML5 specification. For example, `Value=this` is supported, instead of `Value="this"`. However, we recommend using quotes because it's easier to remember and widely adopted across web-based technologies.

Throughout the documentation, code examples:

* Always use quotes. Example: `Value="this"`.
* Nonliterals always use the `@` prefix, even when it's optional. Examples: `Title="@title"`, where `title` is a string-typed variable. `Count="@ct"`, where `ct` is a number-typed variable.
* Literals, outside of Razor expressions, always avoid `@`. Example: `IsFixed="true"`.

`Pages/ParameterParent2.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/index/ParameterParent2.razor)]

> [!NOTE]
> When assigning a C# member to a component parameter, prefix the member with the `@` symbol and never prefix the parameter's HTML attribute.
>
> Correct:
>
> ```razor
> <ParameterChild Title="@title" />
> ```
>
> Incorrect:
>
> ```razor
> <ParameterChild @Title="title" />
> ```

Unlike in Razor pages (`.cshtml`), Blazor can't perform asynchronous work in a Razor expression while rendering a component. This is because Blazor is designed for rendering interactive UIs. In an interactive UI, the screen must always display something, so it doesn't make sense to block the rendering flow. Instead, asynchronous work is performed during one of the [asynchronous lifecycle events](xref:blazor/components/lifecycle). After each asynchronous lifecycle event, the component may render again. The following Razor syntax is **not** supported:

```razor
<ParameterChild Title="@await ..." />
```

The code in the preceding example generates a *compiler error* when the app is built:

> The 'await' operator can only be used within an async method. Consider marking this method with the 'async' modifier and changing its return type to 'Task'.

To obtain a value for the `Title` parameter in the preceding example asynchronously, the component can use the [`OnInitializedAsync` lifecycle event](xref:blazor/components/lifecycle#component-initialization-oninitializedasync), as the following example demonstrates:

```razor
<ParameterChild Title="@title" />

@code {
    private string title;
    
    protected override async Task OnInitializedAsync()
    {
        title = await ...;
    }
}
```

For more information, see <xref:blazor/components/lifecycle>.

Use of an explicit Razor expression to concatenate text with an expression result for assignment to a parameter is **not** supported. The following example seeks to concatenate the text "`Set by `" with an object's property value. Although this syntax is supported in a Razor page (`.cshtml`), it isn't valid for assignment to the child's `Title` parameter in a component. The following Razor syntax is **not** supported:

```razor
<ParameterChild Title="Set by @(panelData.Title)" />
```

The code in the preceding example generates a *compiler error* when the app is built:

> Component attributes do not support complex content (mixed C# and markup).

To support the assignment of a composed value, use a method, field, or property. The following example performs the concatenation of "`Set by `" and an object's property value in the C# method `GetTitle`:

`Pages/ParameterParent3.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/index/ParameterParent3.razor)]

For more information, see <xref:mvc/views/razor>.

> [!WARNING]
> Providing initial values for component parameters is supported, but don't create a component that writes to its own parameters after the component is rendered for the first time. For more information, see the [Overwritten parameters](#overwritten-parameters) section of this article.

Component parameters should be declared as *auto-properties*, meaning that they shouldn't contain custom logic in their `get` or `set` accessors. For example, the following `StartData` property is an auto-property:

```csharp
[Parameter]
public DateTime StartData { get; set; }
```

Don't place custom logic in the `get` or `set` accessor because component parameters are purely intended for use as a channel for a parent component to flow information to a child component. If a `set` accessor of a child component property contains logic that causes rerendering of the parent component, an infinite rendering loop results.

To transform a received parameter value:

* Leave the parameter property as an auto-property to represent the supplied raw data.
* Create a different property or method to supply the transformed data based on the parameter property.

Override [`OnParametersSetAsync`](xref:blazor/components/lifecycle#after-parameters-are-set-onparameterssetasync) to transform a received parameter each time new data is received.

Writing an initial value to a component parameter is supported because initial value assignments don't interfere with the Blazor's automatic component rendering. The following assignment of the current local <xref:System.DateTime> with <xref:System.DateTime.Now?displayProperty=nameWithType> to `StartData` is valid syntax in a component:

```csharp
[Parameter]
public DateTime StartData { get; set; } = DateTime.Now;
```

After the initial assignment of <xref:System.DateTime.Now?displayProperty=nameWithType>, do **not** assign a value to `StartData` in developer code. For more information, see the [Overwritten parameters](#overwritten-parameters) section of this article.

## Route parameters

Components can specify route parameters in the route template of the [`@page`][9] directive. The [Blazor router](xref:blazor/fundamentals/routing) uses route parameters to populate corresponding component parameters.

Optional route parameters are supported. In the following example, the `text` optional parameter assigns the value of the route segment to the component's `Text` property. If the segment isn't present, the value of `Text` is set to "`fantastic`" in the [`OnInitialized` lifecycle method](xref:blazor/components/lifecycle#component-initialization-oninitializedasync).

`Pages/RouteParameter.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/index/RouteParameter.razor?highlight=1,6-7)]

For information on catch-all route parameters (`{*pageRoute}`), which capture paths across multiple folder boundaries, see <xref:blazor/fundamentals/routing#catch-all-route-parameters>.

## Overwritten parameters

The Blazor framework generally imposes safe parent-to-child parameter assignment:

* Parameters aren't overwritten unexpectedly.
* Side-effects are minimized. For example, additional renders are avoided because they may create infinite rendering loops.

A child component receives new parameter values that possibly overwrite existing values when the parent component rerenders. Accidentally overwriting parameter values in a child component often occurs when developing the component with one or more data-bound parameters and the developer writes directly to a parameter in the child:

* The child component is rendered with one or more parameter values from the parent component.
* The child writes directly to the value of a parameter.
* The parent component rerenders and overwrites the value of the child's parameter.

The potential for overwriting parameter values extends into the child component's property `set` accessors, too.

> [!IMPORTANT]
> Our general guidance is not to create components that directly write to their own parameters after the component is rendered for the first time.

Consider the following faulty `Expander` component that:

* Renders child content.
* Toggles showing child content with a component parameter (`Expanded`).
* The component writes directly to the `Expanded` parameter, which demonstrates the problem with overwritten parameters and should be avoided.

After the following `Expander` component demonstrates the incorrect approach for this scenario, a modified `Expander` component is shown to demonstrate the correct approach. The following examples can be placed in a local sample app to experience the behaviors described.

`Shared/Expander.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Shared/index/BadExpander.razor)]

The `Expander` component is added to the following `ExpanderExample` parent component that may call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A>:

* Calling <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> in developer code notifies a component that its state has changed and typically triggers component rerendering to update the UI. <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> is covered in more detail later in <xref:blazor/components/lifecycle> and <xref:blazor/components/rendering>.
* The button's `@onclick` directive attribute attaches an event handler to the button's `onclick` event. Event handling is covered in more detail later in <xref:blazor/components/event-handling>.

`Pages/ExpanderExample.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/index/ExpanderExample.razor)]

Initially, the `Expander` components behave independently when their `Expanded` properties are toggled. The child components maintain their states as expected. When <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> is called in the parent, the `Expanded` parameter of the first child component is reset back to its initial value (`true`). The second `Expander` component's `Expanded` value isn't reset because no child content is rendered in the second component.

To maintain state in the preceding scenario, use a *private field* in the `Expander` component to maintain its toggled state.

The following revised `Expander` component:

* Accepts the `Expanded` component parameter value from the parent.
* Assigns the component parameter value to a *private field* (`expanded`) in the [`OnInitialized` event](xref:blazor/components/lifecycle#component-initialization-oninitializedasync).
* Uses the private field to maintain its internal toggle state, which demonstrates how to avoid writing directly to a parameter.

> [!NOTE]
> The advice in this section extends to similar logic in component parameter `set` accessors, which can result in similar undesirable side-effects.

`Shared/Expander.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Shared/index/Expander.razor)]

For additional information, see [Blazor Two Way Binding Error (dotnet/aspnetcore #24599)](https://github.com/dotnet/aspnetcore/issues/24599).

## Child content

Components can set the content of another component. The assigning component provides the content between the child component's opening and closing tags.

In the following example, the `RenderFragmentChild` component has a `ChildContent` property that represents a segment of the UI to render as a <xref:Microsoft.AspNetCore.Components.RenderFragment>. The position of `ChildContent` in the component's Razor markup is where the content is rendered in the final HTML output.

`Shared/RenderFragmentChild.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Shared/index/RenderFragmentChild.razor)]

> [!IMPORTANT]
> The property receiving the <xref:Microsoft.AspNetCore.Components.RenderFragment> content must be named `ChildContent` by convention.
>
> [Event callbacks](xref:blazor/components/event-handling#eventcallback) aren't supported for <xref:Microsoft.AspNetCore.Components.RenderFragment>.

The following `RenderFragmentParent` component provides content for rendering the `RenderFragmentChild` by placing the content inside the child component's opening and closing tags.

`Pages/RenderFragmentParent.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/index/RenderFragmentParent.razor)]

Due to the way that Blazor renders child content, rendering components inside a [`for`](/dotnet/csharp/language-reference/keywords/for) loop requires a local index variable if the incrementing loop variable is used in the `RenderFragmentChild` component's content. The following example can be added to the preceding `RenderFragmentParent` component:

```razor
<h1>Three children with an index variable</h1>

@for (int c = 0; c < 3; c++)
{
    var current = c;

    <RenderFragmentChild>
        Count: @current
    </RenderFragmentChild>
}
```

Alternatively, use a [`foreach`](/dotnet/csharp/language-reference/keywords/foreach-in) loop with <xref:System.Linq.Enumerable.Range%2A?displayProperty=nameWithType> instead of a [`for`](/dotnet/csharp/language-reference/keywords/for) loop. The following example can be added to the preceding `RenderFragmentParent` component:

```razor
<h1>Second example of three children with an index variable</h1>

@foreach (var c in Enumerable.Range(0,3))
{
    <RenderFragmentChild>
        Count: @c
    </RenderFragmentChild>
}
```

> [!NOTE]
> Assignment to a <xref:Microsoft.AspNetCore.Components.RenderFragment> delegate is only supported in Razor component files (`.razor`):
> 
> ```razor
> private RenderFragment RenderWelcomeInfo = __builder =>
> {
>     <p>Welcome to your new app!</p>
> };
> ```
>
> For more information, see <xref:blazor/performance#define-reusable-renderfragments-in-code>.

For information on how a <xref:Microsoft.AspNetCore.Components.RenderFragment> can be used as a template for component UI, see the following articles:

* <xref:blazor/components/templated-components>
* <xref:blazor/performance#define-reusable-renderfragments-in-code>

## Attribute splatting and arbitrary parameters

Components can capture and render additional attributes in addition to the component's declared parameters. Additional attributes can be captured in a dictionary and then *splatted* onto an element when the component is rendered using the [`@attributes`][3] Razor directive attribute. This scenario is useful for defining a component that produces a markup element that supports a variety of customizations. For example, it can be tedious to define attributes separately for an `<input>` that supports many parameters.

In the following `Splat` component:

* The first `<input>` element (`id="useIndividualParams"`) uses individual component parameters.
* The second `<input>` element (`id="useAttributesDict"`) uses attribute splatting.

`Pages/Splat.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/index/Splat.razor)]

The rendered `<input>` elements in the webpage are identical:

```html
<input id="useIndividualParams"
       maxlength="10"
       placeholder="Input placeholder text"
       required="required"
       size="50">

<input id="useAttributesDict"
       maxlength="10"
       placeholder="Input placeholder text"
       required="required"
       size="50">
```

To accept arbitrary attributes, define a [component parameter](#component-parameters) with the <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues> property set to `true`:

```razor
@code {
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> InputAttributes { get; set; }
}
```

The <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues> property on [`[Parameter]`](xref:Microsoft.AspNetCore.Components.ParameterAttribute) allows the parameter to match all attributes that don't match any other parameter. A component can only define a single parameter with <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues>. The property type used with <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues> must be assignable from [`Dictionary<string, object>`](xref:System.Collections.Generic.Dictionary%602) with string keys. Use of [`IEnumerable<KeyValuePair<string, object>>`](xref:System.Collections.Generic.IEnumerable%601) or [`IReadOnlyDictionary<string, object>`](xref:System.Collections.Generic.IReadOnlyDictionary%602) are also options in this scenario.

The position of [`@attributes`][3] relative to the position of element attributes is important. When [`@attributes`][3] are splatted on the element, the attributes are processed from right to left (last to first). Consider the following example of a parent component that consumes a child component:

`Shared/AttributeOrderChild1.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Shared/index/AttributeOrderChild1.razor)]

`Pages/AttributeOrderParent1.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/index/AttributeOrderParent1.razor)]

The `AttributeOrderChild1` component's `extra` attribute is set to the right of [`@attributes`][3]. The `AttributeOrderParent1` component's rendered `<div>` contains `extra="5"` when passed through the additional attribute because the attributes are processed right to left (last to first):

```html
<div extra="5" />
```

In the following example, the order of `extra` and [`@attributes`][3] is reversed in the child component's `<div>`:

`Shared/AttributeOrderChild2.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Shared/index/AttributeOrderChild2.razor)]

`Pages/AttributeOrderParent2.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/index/AttributeOrderParent2.razor)]

The `<div>` in the parent component's rendered webpage contains `extra="10"` when passed through the additional attribute:

```html
<div extra="10" />
```

## Capture references to components

Component references provide a way to reference a component instance for issuing commands. To capture a component reference:

* Add an [`@ref`][4] attribute to the child component.
* Define a field with the same type as the child component.

When the component is rendered, the field is populated with the component instance. You can then invoke .NET methods on the instance.

Consider the following `ReferenceChild` component that logs a message when its `ChildMethod` is called.

`Shared/ReferenceChild.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Shared/index/ReferenceChild.razor)]

A component reference is only populated after the component is rendered and its output includes `ReferenceChild`'s element. Until the component is rendered, there's nothing to reference.

To manipulate component references after the component has finished rendering, use the [`OnAfterRender` or `OnAfterRenderAsync` methods](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync).

To use a reference variable with an event handler, use a lambda expression or assign the event handler delegate in the [`OnAfterRender` or `OnAfterRenderAsync` methods](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync). This ensures that the reference variable is assigned before the event handler is assigned.

The following lambda approach uses the preceding `ReferenceChild` component.

`Pages/ReferenceParent1.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/index/ReferenceParent1.razor)]

The following delegate approach uses the preceding `ReferenceChild` component.

`Pages/ReferenceParent2.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/index/ReferenceParent2.razor)]

While capturing component references use a similar syntax to [capturing element references](xref:blazor/js-interop/call-javascript-from-dotnet#capture-references-to-elements), capturing component references isn't a JavaScript interop feature. Component references aren't passed to JavaScript code. Component references are only used in .NET code.

> [!IMPORTANT]
> Do **not** use component references to mutate the state of child components. Instead, use normal declarative component parameters to pass data to child components. Use of component parameters result in child components that rerender at the correct times automatically. For more information, see the [component parameters](#component-parameters) section and the <xref:blazor/components/data-binding> article.

## Synchronization context

Blazor uses a synchronization context (<xref:System.Threading.SynchronizationContext>) to enforce a single logical thread of execution. A component's [lifecycle methods](xref:blazor/components/lifecycle) and event callbacks raised by Blazor are executed on the synchronization context.

Blazor Server's synchronization context attempts to emulate a single-threaded environment so that it closely matches the WebAssembly model in the browser, which is single threaded. At any given point in time, work is performed on exactly one thread, which yields the impression of a single logical thread. No two operations execute concurrently.

### Avoid thread-blocking calls

Generally, don't call the following methods in components. The following methods block the execution thread and thus block the app from resuming work until the underlying <xref:System.Threading.Tasks.Task> is complete:

* <xref:System.Threading.Tasks.Task%601.Result%2A>
* <xref:System.Threading.Tasks.Task.Wait%2A>
* <xref:System.Threading.Tasks.Task.WaitAny%2A>
* <xref:System.Threading.Tasks.Task.WaitAll%2A>
* <xref:System.Threading.Thread.Sleep%2A>
* <xref:System.Runtime.CompilerServices.TaskAwaiter.GetResult%2A>

> [!NOTE]
> Blazor documentation examples that use the thread-blocking methods mentioned in this section are only using the methods for demonstration purposes, not as recommended coding guidance. For example, a few component code demonstrations simulate a long-running process by calling <xref:System.Threading.Thread.Sleep%2A?displayProperty=nameWithType>.

### Invoke component methods externally to update state

In the event a component must be updated based on an external event, such as a timer or other notification, use the `InvokeAsync` method, which dispatches code execution to Blazor's synchronization context. For example, consider the following *notifier service* that can notify any listening component about updated state. The `Update` method can be called from anywhere in the app.

`TimerService.cs`:

[!code-csharp[](~/blazor/samples/5.0/BlazorSample_WebAssembly/TimerService.cs)]

`NotifierService.cs`:

[!code-csharp[](~/blazor/samples/5.0/BlazorSample_WebAssembly/NotifierService.cs)]

Register the services:

* In a Blazor WebAssembly app, register the services as singletons in `Program.cs`:

  ```csharp
  builder.Services.AddSingleton<NotifierService>();
  builder.Services.AddSingleton<TimerService>();
  ```

* In a Blazor Server app, register the services as scoped in `Startup.ConfigureServices`:

  ```csharp
  services.AddScoped<NotifierService>();
  services.AddScoped<TimerService>();
  ```

Use the `NotifierService` to update a component.

`Pages/ReceiveNotifications.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/index/ReceiveNotifications.razor)]

In the preceding example:

* `NotifierService` invokes the component's `OnNotify` method outside of Blazor's synchronization context. `InvokeAsync` is used to switch to the correct context and queue a render. For more information, see <xref:blazor/components/rendering>.
* The component implements <xref:System.IDisposable>. The `OnNotify` delegate is unsubscribed in the `Dispose` method, which is called by the framework when the component is disposed. For more information, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>.

## Use `@key` to control the preservation of elements and components

When rendering a list of elements or components and the elements or components subsequently change, Blazor must decide which of the previous elements or components can be retained and how model objects should map to them. Normally, this process is automatic and can be ignored, but there are cases where you may want to control the process.

Consider the following `Details` and `People` components:

* The `Details` component receives data (`Data`) from the parent `People` component, which is displayed in an `<input>` element. Any given displayed `<input>` element can receive the focus of the page from the user when they select one of the `<input>` elements.
* The `People` component creates a list of person objects for display using the `Details` component. Every three seconds, a new person is added to the collection.

This demonstration allows you to:

* Select an `<input>` from among several rendered `Details` components.
* Study the behavior of the page's focus as the people collection automatically grows.

`Shared/Details.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Shared/index/Details.razor)]

In the following `People` component, each iteration of adding a person in `OnTimerCallback` results in Blazor rebuilding the entire collection. The page's focus remains on the *same index* position of `<input>` elements, so the focus shifts each time a person is added. *Shifting the focus away from what the user selected isn't desirable behavior.* After demonstrating the poor behavior with the following component, the [`@key`][5] directive attribute is used to improve the user's experience.

`Pages/People.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/index/People.razor)]

The contents of the `people` collection changes with inserted, deleted, or re-ordered entries. Rerendering can lead to visible behavior differences. Each time a person is inserted into the `people` collection, the *preceding element* of the currently focused element receives the focus. The user's focus is lost.

The mapping process of elements or components to a collection can be controlled with the [`@key`][5] directive attribute. Use of [`@key`][5] guarantees the preservation of elements or components based on the key's value. If the `Details` component in the preceding example is keyed on the `person` item, Blazor ignores rerendering `Details` components that haven't changed.

To modify the `People` component to use the [`@key`][5] directive attribute with the `people` collection, update the `<Details>` element to the following:

```razor
<Details @key="person" Data="@person.Data" />
```

When the `people` collection changes, the association between `Details` instances and `person` instances is retained. When a `Person` is inserted at the beginning of the collection, one new `Details` instance is inserted at that corresponding position. Other instances are left unchanged. Therefore, the user's focus isn't lost as people are added to the collection.

Other collection updates exhibit the same behavior when the [`@key`][5] directive attribute is used:

* If an instance is deleted from the collection, only the corresponding component instance is removed from the UI. Other instances are left unchanged.
* If collection entries are re-ordered, the corresponding component instances are preserved and re-ordered in the UI.

> [!IMPORTANT]
> Keys are local to each container element or component. Keys aren't compared globally across the document.

### When to use `@key`

Typically, it makes sense to use [`@key`][5] whenever a list is rendered (for example, in a [`foreach`](/dotnet/csharp/language-reference/keywords/foreach-in) block) and a suitable value exists to define the [`@key`][5].

You can also use [`@key`][5] to preserve an element or component subtree when an object doesn't change, as the following examples show.

Example 1:

```razor
<li @key="person">
    <input value="@person.Data" />
</li>
```

Example 2:

```razor
<div @key="person">
    @* other HTML elements *@
</div>
```

If an `person` instance changes, the [`@key`][5] attribute directive forces Blazor to:

* Discard the entire `<li>` or `<div>` and their descendants.
* Rebuild the subtree within the UI with new elements and components.

This is useful to guarantee that no UI state is preserved when the collection changes within a subtree.

### Scope of `@key`

The [`@key`][5] attribute directive is scoped to its own siblings within its parent.

Consider the following example. The `first` and `second` keys are compared against each other within the same scope of the outer `<div>` element:

```razor
<div>
    <div @key="first">...</div>
    <div @key="second">...</div>
</div>
```

The following example demonstrates `first` and `second` keys in their own scopes, unrelated to each other and without influence on each other. Each [`@key`][5] scope only applies to its parent `<div>` element, not across the parent `<div>` elements:

```razor
<div>
    <div @key="first">...</div>
</div>
<div>
    <div @key="second">...</div>
</div>
```

For the `Details` component shown earlier, the following examples render `person` data within the same [`@key`][5] scope and demonstrate typical use cases for [`@key`][5]:

```razor
<div>
    @foreach (var person in people)
    {
        <Details @key="person" Data="@person.Data" />
    }
</div>
```

```razor
@foreach (var person in people)
{
    <div @key="person">
        <Details Data="@person.Data" />
    </div>
}
```

```razor
<ol>
    @foreach (var person in people)
    {
        <li @key="person">
            <Details Data="@person.Data" />
        </li>
    }
</ol>
```

The following examples only scope [`@key`][5] to the `<div>` or `<li>` element that surrounds each `Details` component instance. Therefore, `person` data for each member of the `people` collection is **not** keyed on each `person` instance across the rendered `Details` components. Avoid the following patterns when using [`@key`][5]:

```razor
@foreach (var person in people)
{
    <div>
        <Details @key="person" Data="@person.Data" />
    </div>
}
```

```razor
<ol>
    @foreach (var person in people)
    {
        <li>
            <Details @key="person" Data="@person.Data" />
        </li>
    }
</ol>
```

### When not to use `@key`

There's a performance cost when rendering with [`@key`][5]. The performance cost isn't large, but only specify [`@key`][5] if preserving the element or component benefits the app.

Even if [`@key`][5] isn't used, Blazor preserves child element and component instances as much as possible. The only advantage to using [`@key`][5] is control over *how* model instances are mapped to the preserved component instances, instead of Blazor selecting the mapping.

### Values to use for `@key`

Generally, it makes sense to supply one of the following values for [`@key`][5]:

* Model object instances. For example, the `Person` instance (`person`) was used in the earlier example. This ensures preservation based on object reference equality.
* Unique identifiers. For example, unique identifiers can be based on primary key values of type `int`, `string`, or `Guid`.

Ensure that values used for [`@key`][5] don't clash. If clashing values are detected within the same parent element, Blazor throws an exception because it can't deterministically map old elements or components to new elements or components. Only use distinct values, such as object instances or primary key values.

## Apply an attribute

Attributes can be applied to components with the [`@attribute`][7] directive. The following example applies the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) to the component's class:

```razor
@page "/"
@attribute [Authorize]
```

## Conditional HTML element attributes

HTML element attribute properties are conditionally set based on the .NET value. If the value is `false` or `null`, the property isn't set. If the value is `true`, the property is set.

In the following example, `IsCompleted` determines if the `<input>` element's `checked` property is set.

`Pages/ConditionalAttribute.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/index/ConditionalAttribute.razor)]

For more information, see <xref:mvc/views/razor>.

> [!WARNING]
> Some HTML attributes, such as [`aria-pressed`](https://developer.mozilla.org/docs/Web/Accessibility/ARIA/Roles/button_role#Toggle_buttons), don't function properly when the .NET type is a `bool`. In those cases, use a `string` type instead of a `bool`.

## Raw HTML

Strings are normally rendered using DOM text nodes, which means that any markup they may contain is ignored and treated as literal text. To render raw HTML, wrap the HTML content in a <xref:Microsoft.AspNetCore.Components.MarkupString> value. The value is parsed as HTML or SVG and inserted into the DOM.

> [!WARNING]
> Rendering raw HTML constructed from any untrusted source is a **security risk** and should **always** be avoided.

The following example shows using the <xref:Microsoft.AspNetCore.Components.MarkupString> type to add a block of static HTML content to the rendered output of a component.

`Pages/MarkupStringExample.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/index/MarkupStringExample.razor)]

## Razor templates

Render fragments can be defined using Razor template syntax to define a UI snippet. Razor templates use the following format:

```razor
@<{HTML tag}>...</{HTML tag}>
```

The following example illustrates how to specify <xref:Microsoft.AspNetCore.Components.RenderFragment> and <xref:Microsoft.AspNetCore.Components.RenderFragment%601> values and render templates directly in a component. Render fragments can also be passed as arguments to [templated components](xref:blazor/components/templated-components).

`Pages/RazorTemplate.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/index/RazorTemplate.razor)]

Rendered output of the preceding code:

```html
<p>The time is 4/19/2021 8:54:46 AM.</p>
<p>Pet: Nutty Rex</p>
```

## Static assets

Blazor follows the convention of ASP.NET Core apps for static assets. Static assets are located in the project's [`web root` (`wwwroot`) folder](xref:fundamentals/index#web-root) or folders under the `wwwroot` folder.

Use a base-relative path (`/`) to refer to the web root for a static asset. In the following example, `logo.png` is physically located in the `{PROJECT ROOT}/wwwroot/images` folder. `{PROJECT ROOT}` is the app's project root.

```razor
<img alt="Company logo" src="/images/logo.png" />
```

Components do **not** support tilde-slash notation (`~/`).

For information on setting an app's base path, see <xref:blazor/host-and-deploy/index#app-base-path>.

## Tag Helpers aren't supported in components

[`Tag Helpers`](xref:mvc/views/tag-helpers/intro) aren't supported in components. To provide Tag Helper-like functionality in Blazor, create a component with the same functionality as the Tag Helper and use the component instead.

## Scalable Vector Graphics (SVG) images

Since Blazor renders HTML, browser-supported images, including [Scalable Vector Graphics (SVG) images (`.svg`)](https://developer.mozilla.org/docs/Web/SVG), are supported via the `<img>` tag:

```html
<img alt="Example image" src="image.svg" />
```

Similarly, SVG images are supported in the CSS rules of a stylesheet file (`.css`):

```css
.element-class {
    background-image: url("image.svg");
}
```

## Whitespace rendering behavior

Unless the [`@preservewhitespace`](xref:mvc/views/razor#preservewhitespace) directive is used with a value of `true`, extra whitespace is removed by default if:

* Leading or trailing within an element.
* Leading or trailing within a <xref:Microsoft.AspNetCore.Components.RenderFragment>/<xref:Microsoft.AspNetCore.Components.RenderFragment%601> parameter (for example, child content passed to another component).
* It precedes or follows a C# code block, such as `@if` or `@foreach`.

Whitespace removal might affect the rendered output when using a CSS rule, such as `white-space: pre`. To disable this performance optimization and preserve the whitespace, take one of the following actions:

* Add the `@preservewhitespace true` directive at the top of the Razor file (`.razor`) to apply the preference to a specific component.
* Add the `@preservewhitespace true` directive inside an `_Imports.razor` file to apply the preference to a subdirectory or to the entire project.

In most cases, no action is required, as apps typically continue to behave normally (but faster). If stripping whitespace causes a rendering problem for a particular component, use `@preservewhitespace true` in that component to disable this optimization.

## Generic type parameter support

The [`@typeparam`][11] directive declares a [generic type parameter](/dotnet/csharp/programming-guide/generics/generic-type-parameters) for the generated component class:

```razor
@typeparam TItem
```

In the following example, the `ListGenericTypeItems1` component is generically typed as `TExample`.

`Shared/ListGenericTypeItems1.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Shared/index/ListGenericTypeItems1.razor)]

The following `GenericTypeExample1` component renders two `ListGenericTypeItems1` components:

* String or integer data is assigned to the `ExampleList` parameter of each component.
* Type `string` or `int` that matches the type of the assigned data is set for the type parameter (`TExample`) of each component.

`Pages/GenericTypeExample1.razor`:

[!code-razor[](~/blazor/samples/5.0/BlazorSample_WebAssembly/Pages/index/GenericTypeExample1.razor)]

For more information, see the following articles:

* <xref:mvc/views/razor#typeparam>
* <xref:blazor/components/templated-components>

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Blazor apps are built using *Razor components*, informally known as *Blazor components*. A component is a self-contained portion of user interface (UI) with processing logic to enable dynamic behavior. Components can be nested, reused, shared among projects, and [used in MVC and Razor Pages apps](xref:blazor/components/prerendering-and-integration).

## Component classes

Components are implemented using a combination of C# and HTML markup in [Razor](xref:mvc/views/razor) component files with the `.razor` file extension.

### Razor syntax

Components use [Razor syntax](xref:mvc/views/razor). Two Razor features are extensively used by components, *directives* and *directive attributes*. These are reserved keywords prefixed with `@` that appear in Razor markup:

* [Directives](xref:mvc/views/razor#directives): Change the way component markup is parsed or functions. For example, the [`@page`][9] directive specifies a routable component with a route template and can be reached directly by a user's request in the browser at a specific URL.
* [Directive attributes](xref:mvc/views/razor#directive-attributes): Change the way a component element is parsed or functions. For example, the [`@bind`][10] directive attribute for an `<input>` element binds data to the element's value.

Directives and directive attributes used in components are explained further in this article and other articles of the Blazor documentation set. For general information on Razor syntax, see <xref:mvc/views/razor>.

### Names

A component's name must start with an uppercase character:

* `ProductDetail.razor` is valid.
* `productDetail.razor` is invalid.

Common Blazor naming conventions used throughout the Blazor documentation include:

* Component file paths use Pascal case&dagger; and appear before showing component code examples. Paths indicate typical folder locations. For example, `Pages/ProductDetail.razor` indicates that the `ProductDetail` component has a file name of `ProductDetail.razor` and resides in the `Pages` folder of the app.
* Component file paths for routable components match their URLs with hyphens appearing for spaces between words in a component's route template. For example, a `ProductDetail` component with a route template of `/product-detail` (`@page "/product-detail"`) is requested in a browser at the relative URL `/product-detail`.

&dagger;Pascal case (upper camel case) is a naming convention without spaces and punctuation and with the first letter of each word capitalized, including the first word.

### Routing

Routing in Blazor is achieved by providing a route template to each accessible component in the app with an [`@page`][9] directive. When a Razor file with an [`@page`][9] directive is compiled, the generated class is given a <xref:Microsoft.AspNetCore.Mvc.RouteAttribute> specifying the route template. At runtime, the router searches for component classes with a <xref:Microsoft.AspNetCore.Mvc.RouteAttribute> and renders whichever component has a route template that matches the requested URL.

The following `HelloWorld` component uses a route template of `/hello-world`. The rendered webpage for the component is reached at the relative URL `/hello-world`. When running a Blazor app locally with the default protocol, host, and port, the `HelloWorld` component is requested in the browser at `https://localhost:5001/hello-world`. Components that produce webpages usually reside in the `Pages` folder, but you can use any folder to hold components, including within nested folders.

`Pages/HelloWorld.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/index/HelloWorld.razor)]

The preceding component loads in the browser at `/hello-world` regardless of whether or not you add the component to the app's UI navigation. Optionally, components can be added to the `NavMenu` component so that a link to the component appears in the app's UI-based navigation.

For the preceding `HelloWorld` component, you can add a `NavLink` component to the `NavMenu` component in the `Shared` folder. For more information, including descriptions of the `NavLink` and `NavMenu` components, see <xref:blazor/fundamentals/routing>.

### Markup

A component's UI is defined using [Razor syntax](xref:mvc/views/razor), which consists of Razor markup, C#, and HTML. When an app is compiled, the HTML markup and C# rendering logic are converted into a component class. The name of the generated class matches the name of the file.

Members of the component class are defined in one or more [`@code`][1] blocks. In [`@code`][1] blocks, component state is specified and processed with C#:

* Property and field initializers.
* Parameter values from arguments passed by parent components and route parameters.
* Methods for user event handling, lifecycle events, and custom component logic.

Component members are used in rendering logic using C# expressions that start with the `@` symbol. For example, a C# field is rendered by prefixing `@` to the field name. The following `Markup` component evaluates and renders:

* `headingFontStyle` for the CSS property value `font-style` of the heading element.
* `headingText` for the content of the heading element.

`Pages/Markup.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/index/Markup.razor)]

> [!NOTE]
> Examples throughout the Blazor documentation specify the [`private` access modifier](/dotnet/csharp/language-reference/keywords/private) for private members. Private members are scoped to a component's class. However, C# assumes the `private` access modifier when no access modifier is present, so explicitly marking members "`private`" in your own code is optional. For more information on access modifiers, see [Access Modifiers (C# Programming Guide)](/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers).

The Blazor framework processes a component internally as a [*render tree*](https://developer.mozilla.org/docs/Web/Performance/How_browsers_work#render), which is the combination of a component's [Document Object Model (DOM)](https://developer.mozilla.org/docs/Web/API/Document_Object_Model/Introduction) and [Cascading Style Sheet Object Model (CSSOM)](https://developer.mozilla.org/docs/Web/API/CSS_Object_Model). After the component is initially rendered, the component's render tree is regenerated in response to events. Blazor compares the new render tree against the previous render tree and applies any modifications to the browser's DOM for display. For more information, see <xref:blazor/components/rendering>.

Components are ordinary [C# classes](/dotnet/csharp/programming-guide/classes-and-structs/classes) and can be placed anywhere within a project. Components that produce webpages usually reside in the `Pages` folder. Non-page components are frequently placed in the `Shared` folder or a custom folder added to the project.

### Asynchronous methods (`async`) don't support returning `void`

The Blazor framework doesn't track `void`-returning asynchronous methods (`async`). As a result, exceptions aren't caught if `void` is returned. Always return a <xref:System.Threading.Tasks.Task> from asynchronous methods.

### Nested components

Components can include other components by declaring them using HTML syntax. The markup for using a component looks like an HTML tag where the name of the tag is the component type.

Consider the following `Heading` component, which can be used by other components to display a heading.

`Shared/Heading.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Shared/index/Heading.razor)]

The following markup in the `HeadingExample` component renders the preceding `Heading` component at the location where the `<Heading />` tag appears.

`Pages/HeadingExample.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/index/HeadingExample.razor)]

If a component contains an HTML element with an uppercase first letter that doesn't match a component name within the same namespace, a warning is emitted indicating that the element has an unexpected name. Adding an [`@using`][2] directive for the component's namespace makes the component available, which resolves the warning. For more information, see the [Namespaces](#namespaces) section.

The `Heading` component example shown in this section doesn't have an [`@page`][9] directive, so the `Heading` component isn't directly accessible to a user via a direct request in the browser. However, any component with an [`@page`][9] directive can be nested in another component. If the `Heading` component was directly accessible by including `@page "/heading"` at the top of its Razor file, then the component would be rendered for browser requests at both `/heading` and `/heading-example`.

### Namespaces

Typically, a component's namespace is derived from the app's root namespace and the component's location (folder) within the app. If the app's root namespace is `BlazorSample` and the `Counter` component resides in the `Pages` folder:

* The `Counter` component's namespace is `BlazorSample.Pages`.
* The fully qualified type name of the component is `BlazorSample.Pages.Counter`.

For custom folders that hold components, add an [`@using`][2] directive to the parent component or to the app's `_Imports.razor` file. The following example makes components in the `Components` folder available:

```razor
@using BlazorSample.Components
```

> [!NOTE]
> [`@using`][2] directives in the `_Imports.razor` file are only applied to Razor files (`.razor`), not C# files (`.cs`).

Components can also be referenced using their fully qualified names, which doesn't require an [`@using`][2] directive. The following example directly references the `ProductDetail` component in the `Components` folder of the app:

```razor
<BlazorSample.Components.ProductDetail />
```

The namespace of a component authored with Razor is based on the following (in priority order):

* The [`@namespace`][8] directive in the Razor file's markup (for example, `@namespace BlazorSample.CustomNamespace`).
* The project's `RootNamespace` in the project file (for example, `<RootNamespace>BlazorSample</RootNamespace>`).
* The project name, taken from the project file's file name (`.csproj`), and the path from the project root to the component. For example, the framework resolves `{PROJECT ROOT}/Pages/Index.razor` with a project namespace of `BlazorSample` (`BlazorSample.csproj`) to the namespace `BlazorSample.Pages` for the `Index` component. `{PROJECT ROOT}` is the project root path. Components follow C# name binding rules. For the `Index` component in this example, the components in scope are all of the components:
  * In the same folder, `Pages`.
  * The components in the project's root that don't explicitly specify a different namespace.

The following are **not** supported:

* The [`global::`](/dotnet/csharp/language-reference/operators/namespace-alias-qualifier) qualification.
* Importing components with aliased [`using`](/dotnet/csharp/language-reference/keywords/using-statement) statements. For example, `@using Foo = Bar` isn't supported.
* Partially-qualified names. For example, you can't add `@using BlazorSample` to a component and then reference the `NavMenu` component in the app's `Shared` folder (`Shared/NavMenu.razor`) with `<Shared.NavMenu></Shared.NavMenu>`.

### Partial class support

Components are generated as [C# partial classes](/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods) and are authored using either of the following approaches:

* A single file contains C# code defined in one or more [`@code`][1] blocks, HTML markup, and Razor markup. Blazor project templates define their components using this single-file approach.
* HTML and Razor markup are placed in a Razor file (`.razor`). C# code is placed in a code-behind file defined as a partial class (`.cs`).

The following example shows the default `Counter` component with an [`@code`][1] block in an app generated from a Blazor project template. Markup and C# code are in the same file. This is the most common approach taken in component authoring.

`Pages/Counter.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/Counter.razor)]

The following `Counter` component splits HTML and Razor markup from  C# code using a code-behind file with a partial class:

`Pages/CounterPartialClass.razor`:

```razor
@page "/counter-partial-class"

<h1>Counter</h1>

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>
```

`Pages/CounterPartialClass.razor.cs`:

```csharp
namespace BlazorSample.Pages
{
    public partial class CounterPartialClass
    {
        private int currentCount = 0;

        void IncrementCount()
        {
            currentCount++;
        }
    }
}
```

[`@using`][2] directives in the `_Imports.razor` file are only applied to Razor files (`.razor`), not C# files (`.cs`). Add namespaces to a partial class file as needed.

Typical namespaces used by components:

```csharp
using System.Net.Http;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;
```

Typical namespaces also include the namespace of the app and the namespace corresponding to the app's `Shared` folder:

```csharp
using BlazorSample;
using BlazorSample.Shared;
```

### Specify a base class

The [`@inherits`][6] directive is used to specify a base class for a component. The following example shows how a component can inherit a base class to provide the component's properties and methods. The `BlazorRocksBase` base class derives from <xref:Microsoft.AspNetCore.Components.ComponentBase>.

`Pages/BlazorRocks.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/index/BlazorRocks.razor)]

`BlazorRocksBase.cs`:

[!code-csharp[](~/blazor/samples/3.1/BlazorSample_WebAssembly/BlazorRocksBase.cs)]

## Component parameters

*Component parameters* pass data to components and are defined using public [C# properties](/dotnet/csharp/programming-guide/classes-and-structs/properties) on the component class with the [`[Parameter]` attribute](xref:Microsoft.AspNetCore.Components.ParameterAttribute). In the following example, a built-in reference type (<xref:System.String?displayProperty=fullName>) and a user-defined reference type (`PanelBody`) are passed as component parameters.

`PanelBody.cs`:

[!code-csharp[](~/blazor/samples/3.1/BlazorSample_WebAssembly/PanelBody.cs)]

`Shared/ParameterChild.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Shared/index/ParameterChild.razor)]

> [!WARNING]
> Providing initial values for component parameters is supported, but don't create a component that writes to its own parameters after the component is rendered for the first time. For more information, see the [Overwritten parameters](#overwritten-parameters) section of this article.

The `Title` and `Body` component parameters of the `ParameterChild` component are set by arguments in the HTML tag that renders the instance of the component. The following `ParameterParent` component renders two `ParameterChild` components:

* The first `ParameterChild` component is rendered without supplying parameter arguments.
* The second `ParameterChild` component receives values for `Title` and `Body` from the `ParameterParent` component, which uses an [explicit C# expression](xref:mvc/views/razor#explicit-razor-expressions) to set the values of the `PanelBody`'s properties.

`Pages/ParameterParent.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/index/ParameterParent.razor)]

The following rendered HTML markup from the `ParameterParent` component shows `ParameterChild` component default values when the `ParameterParent` component doesn't supply component parameter values. When the `ParameterParent` component provides component parameter values, they replace the `ParameterChild` component's default values.

> [!NOTE]
> For clarity, rendered CSS style classes aren't shown in the following rendered HTML markup.

```html
<h1>Child component (without attribute values)</h1>

<div>
    <div>Set By Child</div>
    <div>Set by child.</div>
</div>

<h1>Child component (with attribute values)</h1>

<div>
    <div>Set by Parent</div>
    <div>Set by parent.</div>
</div>
```

Assign a C# field, property, or result of a method to a component parameter as an HTML attribute value using [Razor's reserved `@` symbol](xref:mvc/views/razor#razor-syntax). The following `ParameterParent2` component displays four instances of the preceding `ParameterChild` component and sets their `Title` parameter values to:

* The value of the `title` field.
* The result of the `GetTitle` C# method.
* The current local date in long format with <xref:System.DateTime.ToLongDateString%2A>, which uses an [implicit C# expression](xref:mvc/views/razor#implicit-razor-expressions).
* The `panelData` object's `Title` property.

The `@` prefix is required for string parameters. Otherwise, the framework assumes that a string literal is set.

Outside of string parameters, we recommend use the use of the `@` prefix for nonliterals, even when they aren't strictly required.

We don't recommend the use of the `@` prefix for literals (for example, boolean values), keywords (for example, `this`), or `null`, but you can choose to use them if you wish. For example, `IsFixed="@true"` is uncommon but supported.

Quotes around parameter attribute values are optional in most cases per the HTML5 specification. For example, `Value=this` is supported, instead of `Value="this"`. However, we recommend using quotes because it's easier to remember and widely adopted across web-based technologies.

Throughout the documentation, code examples:

* Always use quotes. Example: `Value="this"`.
* Nonliterals always use the `@` prefix, even when it's optional. Examples: `Title="@title"`, where `title` is a string-typed variable. `Count="@ct"`, where `ct` is a number-typed variable.
* Literals, outside of Razor expressions, always avoid `@`. Example: `IsFixed="true"`.

`Pages/ParameterParent2.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/index/ParameterParent2.razor)]

> [!NOTE]
> When assigning a C# member to a component parameter, prefix the member with the `@` symbol and never prefix the parameter's HTML attribute.
>
> Correct:
>
> ```razor
> <ParameterChild Title="@title" />
> ```
>
> Incorrect:
>
> ```razor
> <ParameterChild @Title="title" />
> ```

Unlike in Razor pages (`.cshtml`), Blazor can't perform asynchronous work in a Razor expression while rendering a component. This is because Blazor is designed for rendering interactive UIs. In an interactive UI, the screen must always display something, so it doesn't make sense to block the rendering flow. Instead, asynchronous work is performed during one of the [asynchronous lifecycle events](xref:blazor/components/lifecycle). After each asynchronous lifecycle event, the component may render again. The following Razor syntax is **not** supported:

```razor
<ParameterChild Title="@await ..." />
```

The code in the preceding example generates a *compiler error* when the app is built:

> The 'await' operator can only be used within an async method. Consider marking this method with the 'async' modifier and changing its return type to 'Task'.

To obtain a value for the `Title` parameter in the preceding example asynchronously, the component can use the [`OnInitializedAsync` lifecycle event](xref:blazor/components/lifecycle#component-initialization-oninitializedasync), as the following example demonstrates:

```razor
<ParameterChild Title="@title" />

@code {
    private string title;
    
    protected override async Task OnInitializedAsync()
    {
        title = await ...;
    }
}
```

For more information, see <xref:blazor/components/lifecycle>.

Use of an explicit Razor expression to concatenate text with an expression result for assignment to a parameter is **not** supported. The following example seeks to concatenate the text "`Set by `" with an object's property value. Although this syntax is supported in a Razor page (`.cshtml`), it isn't valid for assignment to the child's `Title` parameter in a component. The following Razor syntax is **not** supported:

```razor
<ParameterChild Title="Set by @(panelData.Title)" />
```

The code in the preceding example generates a *compiler error* when the app is built:

> Component attributes do not support complex content (mixed C# and markup).

To support the assignment of a composed value, use a method, field, or property. The following example performs the concatenation of "`Set by `" and an object's property value in the C# method `GetTitle`:

`Pages/ParameterParent3.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/index/ParameterParent3.razor)]

For more information, see <xref:mvc/views/razor>.

> [!WARNING]
> Providing initial values for component parameters is supported, but don't create a component that writes to its own parameters after the component is rendered for the first time. For more information, see the [Overwritten parameters](#overwritten-parameters) section of this article.

Component parameters should be declared as *auto-properties*, meaning that they shouldn't contain custom logic in their `get` or `set` accessors. For example, the following `StartData` property is an auto-property:

```csharp
[Parameter]
public DateTime StartData { get; set; }
```

Don't place custom logic in the `get` or `set` accessor because component parameters are purely intended for use as a channel for a parent component to flow information to a child component. If a `set` accessor of a child component property contains logic that causes rerendering of the parent component, an infinite rendering loop results.

To transform a received parameter value:

* Leave the parameter property as an auto-property to represent the supplied raw data.
* Create a different property or method to supply the transformed data based on the parameter property.

Override [`OnParametersSetAsync`](xref:blazor/components/lifecycle#after-parameters-are-set-onparameterssetasync) to transform a received parameter each time new data is received.

Writing an initial value to a component parameter is supported because initial value assignments don't interfere with the Blazor's automatic component rendering. The following assignment of the current local <xref:System.DateTime> with <xref:System.DateTime.Now?displayProperty=nameWithType> to `StartData` is valid syntax in a component:

```csharp
[Parameter]
public DateTime StartData { get; set; } = DateTime.Now;
```

After the initial assignment of <xref:System.DateTime.Now?displayProperty=nameWithType>, do **not** assign a value to `StartData` in developer code. For more information, see the [Overwritten parameters](#overwritten-parameters) section of this article.

## Route parameters

Components can specify route parameters in the route template of the [`@page`][9] directive. The [Blazor router](xref:blazor/fundamentals/routing) uses route parameters to populate corresponding component parameters.

`Pages/RouteParameter.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/index/RouteParameter.razor?highlight=2,7-8)]

Optional route parameters aren't supported, so two [`@page`][9] directives are applied in the preceding example. The first [`@page`][9] directive permits navigation to the component without a route parameter. The second [`@page`][9] directive receives the `{text}` route parameter and assigns the value to the `Text` property.

For information on catch-all route parameters (`{*pageRoute}`), which capture paths across multiple folder boundaries, see <xref:blazor/fundamentals/routing#catch-all-route-parameters>.

## Overwritten parameters

The Blazor framework generally imposes safe parent-to-child parameter assignment:

* Parameters aren't overwritten unexpectedly.
* Side-effects are minimized. For example, additional renders are avoided because they may create infinite rendering loops.

A child component receives new parameter values that possibly overwrite existing values when the parent component rerenders. Accidentally overwriting parameter values in a child component often occurs when developing the component with one or more data-bound parameters and the developer writes directly to a parameter in the child:

* The child component is rendered with one or more parameter values from the parent component.
* The child writes directly to the value of a parameter.
* The parent component rerenders and overwrites the value of the child's parameter.

The potential for overwriting parameter values extends into the child component's property `set` accessors, too.

> [!IMPORTANT]
> Our general guidance is not to create components that directly write to their own parameters after the component is rendered for the first time.

Consider the following faulty `Expander` component that:

* Renders child content.
* Toggles showing child content with a component parameter (`Expanded`).
* The component writes directly to the `Expanded` parameter, which demonstrates the problem with overwritten parameters and should be avoided.

After the following `Expander` component demonstrates the incorrect approach for this scenario, a modified `Expander` component is shown to demonstrate the correct approach. The following examples can be placed in a local sample app to experience the behaviors described.

`Shared/Expander.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Shared/index/BadExpander.razor)]

The `Expander` component is added to the following `ExpanderExample` parent component that may call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A>:

* Calling <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> in developer code notifies a component that its state has changed and typically triggers component rerendering to update the UI. <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> is covered in more detail later in <xref:blazor/components/lifecycle> and <xref:blazor/components/rendering>.
* The button's `@onclick` directive attribute attaches an event handler to the button's `onclick` event. Event handling is covered in more detail later in <xref:blazor/components/event-handling>.

`Pages/ExpanderExample.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/index/ExpanderExample.razor)]

Initially, the `Expander` components behave independently when their `Expanded` properties are toggled. The child components maintain their states as expected. When <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> is called in the parent, the `Expanded` parameter of the first child component is reset back to its initial value (`true`). The second `Expander` component's `Expanded` value isn't reset because no child content is rendered in the second component.

To maintain state in the preceding scenario, use a *private field* in the `Expander` component to maintain its toggled state.

The following revised `Expander` component:

* Accepts the `Expanded` component parameter value from the parent.
* Assigns the component parameter value to a *private field* (`expanded`) in the [`OnInitialized` event](xref:blazor/components/lifecycle#component-initialization-oninitializedasync).
* Uses the private field to maintain its internal toggle state, which demonstrates how to avoid writing directly to a parameter.

> [!NOTE]
> The advice in this section extends to similar logic in component parameter `set` accessors, which can result in similar undesirable side-effects.

`Shared/Expander.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Shared/index/Expander.razor)]

For additional information, see [Blazor Two Way Binding Error (dotnet/aspnetcore #24599)](https://github.com/dotnet/aspnetcore/issues/24599).

## Child content

Components can set the content of another component. The assigning component provides the content between the child component's opening and closing tags.

In the following example, the `RenderFragmentChild` component has a `ChildContent` property that represents a segment of the UI to render as a <xref:Microsoft.AspNetCore.Components.RenderFragment>. The position of `ChildContent` in the component's Razor markup is where the content is rendered in the final HTML output.

`Shared/RenderFragmentChild.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Shared/index/RenderFragmentChild.razor)]

> [!IMPORTANT]
> The property receiving the <xref:Microsoft.AspNetCore.Components.RenderFragment> content must be named `ChildContent` by convention.
>
> [Event callbacks](xref:blazor/components/event-handling#eventcallback) aren't supported for <xref:Microsoft.AspNetCore.Components.RenderFragment>.

The following `RenderFragmentParent` component provides content for rendering the `RenderFragmentChild` by placing the content inside the child component's opening and closing tags.

`Pages/RenderFragmentParent.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/index/RenderFragmentParent.razor)]

Due to the way that Blazor renders child content, rendering components inside a [`for`](/dotnet/csharp/language-reference/keywords/for) loop requires a local index variable if the incrementing loop variable is used in the `RenderFragmentChild` component's content. The following example can be added to the preceding `RenderFragmentParent` component:

```razor
<h1>Three children with an index variable</h1>

@for (int c = 0; c < 3; c++)
{
    var current = c;

    <RenderFragmentChild>
        Count: @current
    </RenderFragmentChild>
}
```

Alternatively, use a [`foreach`](/dotnet/csharp/language-reference/keywords/foreach-in) loop with <xref:System.Linq.Enumerable.Range%2A?displayProperty=nameWithType> instead of a [`for`](/dotnet/csharp/language-reference/keywords/for) loop. The following example can be added to the preceding `RenderFragmentParent` component:

```razor
<h1>Second example of three children with an index variable</h1>

@foreach (var c in Enumerable.Range(0,3))
{
    <RenderFragmentChild>
        Count: @c
    </RenderFragmentChild>
}
```

> [!NOTE]
> Assignment to a <xref:Microsoft.AspNetCore.Components.RenderFragment> delegate is only supported in Razor component files (`.razor`):
> 
> ```razor
> private RenderFragment RenderWelcomeInfo = __builder =>
> {
>     <p>Welcome to your new app!</p>
> };
> ```
>
> For more information, see <xref:blazor/performance#define-reusable-renderfragments-in-code>.

For information on how a <xref:Microsoft.AspNetCore.Components.RenderFragment> can be used as a template for component UI, see the following articles:

* <xref:blazor/components/templated-components>
* <xref:blazor/performance#define-reusable-renderfragments-in-code>

## Attribute splatting and arbitrary parameters

Components can capture and render additional attributes in addition to the component's declared parameters. Additional attributes can be captured in a dictionary and then *splatted* onto an element when the component is rendered using the [`@attributes`][3] Razor directive attribute. This scenario is useful for defining a component that produces a markup element that supports a variety of customizations. For example, it can be tedious to define attributes separately for an `<input>` that supports many parameters.

In the following `Splat` component:

* The first `<input>` element (`id="useIndividualParams"`) uses individual component parameters.
* The second `<input>` element (`id="useAttributesDict"`) uses attribute splatting.

`Pages/Splat.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/index/Splat.razor)]

The rendered `<input>` elements in the webpage are identical:

```html
<input id="useIndividualParams"
       maxlength="10"
       placeholder="Input placeholder text"
       required="required"
       size="50">

<input id="useAttributesDict"
       maxlength="10"
       placeholder="Input placeholder text"
       required="required"
       size="50">
```

To accept arbitrary attributes, define a [component parameter](#component-parameters) with the <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues> property set to `true`:

```razor
@code {
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> InputAttributes { get; set; }
}
```

The <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues> property on [`[Parameter]`](xref:Microsoft.AspNetCore.Components.ParameterAttribute) allows the parameter to match all attributes that don't match any other parameter. A component can only define a single parameter with <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues>. The property type used with <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues> must be assignable from [`Dictionary<string, object>`](xref:System.Collections.Generic.Dictionary%602) with string keys. Use of [`IEnumerable<KeyValuePair<string, object>>`](xref:System.Collections.Generic.IEnumerable%601) or [`IReadOnlyDictionary<string, object>`](xref:System.Collections.Generic.IReadOnlyDictionary%602) are also options in this scenario.

The position of [`@attributes`][3] relative to the position of element attributes is important. When [`@attributes`][3] are splatted on the element, the attributes are processed from right to left (last to first). Consider the following example of a parent component that consumes a child component:

`Shared/AttributeOrderChild1.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Shared/index/AttributeOrderChild1.razor)]

`Pages/AttributeOrderParent1.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/index/AttributeOrderParent1.razor)]

The `AttributeOrderChild1` component's `extra` attribute is set to the right of [`@attributes`][3]. The `AttributeOrderParent1` component's rendered `<div>` contains `extra="5"` when passed through the additional attribute because the attributes are processed right to left (last to first):

```html
<div extra="5" />
```

In the following example, the order of `extra` and [`@attributes`][3] is reversed in the child component's `<div>`:

`Shared/AttributeOrderChild2.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Shared/index/AttributeOrderChild2.razor)]

`Pages/AttributeOrderParent2.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/index/AttributeOrderParent2.razor)]

The `<div>` in the parent component's rendered webpage contains `extra="10"` when passed through the additional attribute:

```html
<div extra="10" />
```

## Capture references to components

Component references provide a way to reference a component instance for issuing commands. To capture a component reference:

* Add an [`@ref`][4] attribute to the child component.
* Define a field with the same type as the child component.

When the component is rendered, the field is populated with the component instance. You can then invoke .NET methods on the instance.

Consider the following `ReferenceChild` component that logs a message when its `ChildMethod` is called.

`Shared/ReferenceChild.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Shared/index/ReferenceChild.razor)]

A component reference is only populated after the component is rendered and its output includes `ReferenceChild`'s element. Until the component is rendered, there's nothing to reference.

To manipulate component references after the component has finished rendering, use the [`OnAfterRender` or `OnAfterRenderAsync` methods](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync).

To use a reference variable with an event handler, use a lambda expression or assign the event handler delegate in the [`OnAfterRender` or `OnAfterRenderAsync` methods](xref:blazor/components/lifecycle#after-component-render-onafterrenderasync). This ensures that the reference variable is assigned before the event handler is assigned.

The following lambda approach uses the preceding `ReferenceChild` component.

`Pages/ReferenceParent1.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/index/ReferenceParent1.razor)]

The following delegate approach uses the preceding `ReferenceChild` component.

`Pages/ReferenceParent2.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/index/ReferenceParent2.razor)]

While capturing component references use a similar syntax to [capturing element references](xref:blazor/js-interop/call-javascript-from-dotnet#capture-references-to-elements), capturing component references isn't a JavaScript interop feature. Component references aren't passed to JavaScript code. Component references are only used in .NET code.

> [!IMPORTANT]
> Do **not** use component references to mutate the state of child components. Instead, use normal declarative component parameters to pass data to child components. Use of component parameters result in child components that rerender at the correct times automatically. For more information, see the [component parameters](#component-parameters) section and the <xref:blazor/components/data-binding> article.

## Synchronization context

Blazor uses a synchronization context (<xref:System.Threading.SynchronizationContext>) to enforce a single logical thread of execution. A component's [lifecycle methods](xref:blazor/components/lifecycle) and event callbacks raised by Blazor are executed on the synchronization context.

Blazor Server's synchronization context attempts to emulate a single-threaded environment so that it closely matches the WebAssembly model in the browser, which is single threaded. At any given point in time, work is performed on exactly one thread, which yields the impression of a single logical thread. No two operations execute concurrently.

### Avoid thread-blocking calls

Generally, don't call the following methods in components. The following methods block the execution thread and thus block the app from resuming work until the underlying <xref:System.Threading.Tasks.Task> is complete:

* <xref:System.Threading.Tasks.Task%601.Result%2A>
* <xref:System.Threading.Tasks.Task.Wait%2A>
* <xref:System.Threading.Tasks.Task.WaitAny%2A>
* <xref:System.Threading.Tasks.Task.WaitAll%2A>
* <xref:System.Threading.Thread.Sleep%2A>
* <xref:System.Runtime.CompilerServices.TaskAwaiter.GetResult%2A>

> [!NOTE]
> Blazor documentation examples that use the thread-blocking methods mentioned in this section are only using the methods for demonstration purposes, not as recommended coding guidance. For example, a few component code demonstrations simulate a long-running process by calling <xref:System.Threading.Thread.Sleep%2A?displayProperty=nameWithType>.

### Invoke component methods externally to update state

In the event a component must be updated based on an external event, such as a timer or other notification, use the `InvokeAsync` method, which dispatches code execution to Blazor's synchronization context. For example, consider the following *notifier service* that can notify any listening component about updated state. The `Update` method can be called from anywhere in the app.

`TimerService.cs`:

[!code-csharp[](~/blazor/samples/3.1/BlazorSample_WebAssembly/TimerService.cs)]

`NotifierService.cs`:

[!code-csharp[](~/blazor/samples/3.1/BlazorSample_WebAssembly/NotifierService.cs)]

Register the services:

* In a Blazor WebAssembly app, register the services as singletons in `Program.cs`:

  ```csharp
  builder.Services.AddSingleton<NotifierService>();
  builder.Services.AddSingleton<TimerService>();
  ```

* In a Blazor Server app, register the services as scoped in `Startup.ConfigureServices`:

  ```csharp
  services.AddScoped<NotifierService>();
  services.AddScoped<TimerService>();
  ```

Use the `NotifierService` to update a component.

`Pages/ReceiveNotifications.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/index/ReceiveNotifications.razor)]

In the preceding example:

* `NotifierService` invokes the component's `OnNotify` method outside of Blazor's synchronization context. `InvokeAsync` is used to switch to the correct context and queue a render. For more information, see <xref:blazor/components/rendering>.
* The component implements <xref:System.IDisposable>. The `OnNotify` delegate is unsubscribed in the `Dispose` method, which is called by the framework when the component is disposed. For more information, see <xref:blazor/components/lifecycle#component-disposal-with-idisposable-and-iasyncdisposable>.

## Use `@key` to control the preservation of elements and components

When rendering a list of elements or components and the elements or components subsequently change, Blazor must decide which of the previous elements or components can be retained and how model objects should map to them. Normally, this process is automatic and can be ignored, but there are cases where you may want to control the process.

Consider the following `Details` and `People` components:

* The `Details` component receives data (`Data`) from the parent `People` component, which is displayed in an `<input>` element. Any given displayed `<input>` element can receive the focus of the page from the user when they select one of the `<input>` elements.
* The `People` component creates a list of person objects for display using the `Details` component. Every three seconds, a new person is added to the collection.

This demonstration allows you to:

* Select an `<input>` from among several rendered `Details` components.
* Study the behavior of the page's focus as the people collection automatically grows.

`Shared/Details.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Shared/index/Details.razor)]

In the following `People` component, each iteration of adding a person in `OnTimerCallback` results in Blazor rebuilding the entire collection. The page's focus remains on the *same index* position of `<input>` elements, so the focus shifts each time a person is added. *Shifting the focus away from what the user selected isn't desirable behavior.* After demonstrating the poor behavior with the following component, the [`@key`][5] directive attribute is used to improve the user's experience.

`Pages/People.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/index/People.razor)]

The contents of the `people` collection changes with inserted, deleted, or re-ordered entries. Rerendering can lead to visible behavior differences. Each time a person is inserted into the `people` collection, the *preceding element* of the currently focused element receives the focus. The user's focus is lost.

The mapping process of elements or components to a collection can be controlled with the [`@key`][5] directive attribute. Use of [`@key`][5] guarantees the preservation of elements or components based on the key's value. If the `Details` component in the preceding example is keyed on the `person` item, Blazor ignores rerendering `Details` components that haven't changed.

To modify the `People` component to use the [`@key`][5] directive attribute with the `people` collection, update the `<Details>` element to the following:

```razor
<Details @key="person" Data="@person.Data" />
```

When the `people` collection changes, the association between `Details` instances and `person` instances is retained. When a `Person` is inserted at the beginning of the collection, one new `Details` instance is inserted at that corresponding position. Other instances are left unchanged. Therefore, the user's focus isn't lost as people are added to the collection.

Other collection updates exhibit the same behavior when the [`@key`][5] directive attribute is used:

* If an instance is deleted from the collection, only the corresponding component instance is removed from the UI. Other instances are left unchanged.
* If collection entries are re-ordered, the corresponding component instances are preserved and re-ordered in the UI.

> [!IMPORTANT]
> Keys are local to each container element or component. Keys aren't compared globally across the document.

### When to use `@key`

Typically, it makes sense to use [`@key`][5] whenever a list is rendered (for example, in a [`foreach`](/dotnet/csharp/language-reference/keywords/foreach-in) block) and a suitable value exists to define the [`@key`][5].

You can also use [`@key`][5] to preserve an element or component subtree when an object doesn't change, as the following examples show.

Example 1:

```razor
<li @key="person">
    <input value="@person.Data" />
</li>
```

Example 2:

```razor
<div @key="person">
    @* other HTML elements *@
</div>
```

If an `person` instance changes, the [`@key`][5] attribute directive forces Blazor to:

* Discard the entire `<li>` or `<div>` and their descendants.
* Rebuild the subtree within the UI with new elements and components.

This is useful to guarantee that no UI state is preserved when the collection changes within a subtree.

### Scope of `@key`

The [`@key`][5] attribute directive is scoped to its own siblings within its parent.

Consider the following example. The `first` and `second` keys are compared against each other within the same scope of the outer `<div>` element:

```razor
<div>
    <div @key="first">...</div>
    <div @key="second">...</div>
</div>
```

The following example demonstrates `first` and `second` keys in their own scopes, unrelated to each other and without influence on each other. Each [`@key`][5] scope only applies to its parent `<div>` element, not across the parent `<div>` elements:

```razor
<div>
    <div @key="first">...</div>
</div>
<div>
    <div @key="second">...</div>
</div>
```

For the `Details` component shown earlier, the following examples render `person` data within the same [`@key`][5] scope and demonstrate typical use cases for [`@key`][5]:

```razor
<div>
    @foreach (var person in people)
    {
        <Details @key="person" Data="@person.Data" />
    }
</div>
```

```razor
@foreach (var person in people)
{
    <div @key="person">
        <Details Data="@person.Data" />
    </div>
}
```

```razor
<ol>
    @foreach (var person in people)
    {
        <li @key="person">
            <Details Data="@person.Data" />
        </li>
    }
</ol>
```

The following examples only scope [`@key`][5] to the `<div>` or `<li>` element that surrounds each `Details` component instance. Therefore, `person` data for each member of the `people` collection is **not** keyed on each `person` instance across the rendered `Details` components. Avoid the following patterns when using [`@key`][5]:

```razor
@foreach (var person in people)
{
    <div>
        <Details @key="person" Data="@person.Data" />
    </div>
}
```

```razor
<ol>
    @foreach (var person in people)
    {
        <li>
            <Details @key="person" Data="@person.Data" />
        </li>
    }
</ol>
```

### When not to use `@key`

There's a performance cost when rendering with [`@key`][5]. The performance cost isn't large, but only specify [`@key`][5] if preserving the element or component benefits the app.

Even if [`@key`][5] isn't used, Blazor preserves child element and component instances as much as possible. The only advantage to using [`@key`][5] is control over *how* model instances are mapped to the preserved component instances, instead of Blazor selecting the mapping.

### Values to use for `@key`

Generally, it makes sense to supply one of the following values for [`@key`][5]:

* Model object instances. For example, the `Person` instance (`person`) was used in the earlier example. This ensures preservation based on object reference equality.
* Unique identifiers. For example, unique identifiers can be based on primary key values of type `int`, `string`, or `Guid`.

Ensure that values used for [`@key`][5] don't clash. If clashing values are detected within the same parent element, Blazor throws an exception because it can't deterministically map old elements or components to new elements or components. Only use distinct values, such as object instances or primary key values.

## Apply an attribute

Attributes can be applied to components with the [`@attribute`][7] directive. The following example applies the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) to the component's class:

```razor
@page "/"
@attribute [Authorize]
```

## Conditional HTML element attributes

HTML element attribute properties are conditionally set based on the .NET value. If the value is `false` or `null`, the property isn't set. If the value is `true`, the property is set.

In the following example, `IsCompleted` determines if the `<input>` element's `checked` property is set.

`Pages/ConditionalAttribute.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/index/ConditionalAttribute.razor)]

For more information, see <xref:mvc/views/razor>.

> [!WARNING]
> Some HTML attributes, such as [`aria-pressed`](https://developer.mozilla.org/docs/Web/Accessibility/ARIA/Roles/button_role#Toggle_buttons), don't function properly when the .NET type is a `bool`. In those cases, use a `string` type instead of a `bool`.

## Raw HTML

Strings are normally rendered using DOM text nodes, which means that any markup they may contain is ignored and treated as literal text. To render raw HTML, wrap the HTML content in a <xref:Microsoft.AspNetCore.Components.MarkupString> value. The value is parsed as HTML or SVG and inserted into the DOM.

> [!WARNING]
> Rendering raw HTML constructed from any untrusted source is a **security risk** and should **always** be avoided.

The following example shows using the <xref:Microsoft.AspNetCore.Components.MarkupString> type to add a block of static HTML content to the rendered output of a component.

`Pages/MarkupStringExample.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/index/MarkupStringExample.razor)]

## Razor templates

Render fragments can be defined using Razor template syntax to define a UI snippet. Razor templates use the following format:

```razor
@<{HTML tag}>...</{HTML tag}>
```

The following example illustrates how to specify <xref:Microsoft.AspNetCore.Components.RenderFragment> and <xref:Microsoft.AspNetCore.Components.RenderFragment%601> values and render templates directly in a component. Render fragments can also be passed as arguments to [templated components](xref:blazor/components/templated-components).

`Pages/RazorTemplate.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/index/RazorTemplate.razor)]

Rendered output of the preceding code:

```html
<p>The time is 4/19/2021 8:54:46 AM.</p>
<p>Pet: Nutty Rex</p>
```

## Static assets

Blazor follows the convention of ASP.NET Core apps for static assets. Static assets are located in the project's [`web root` (`wwwroot`) folder](xref:fundamentals/index#web-root) or folders under the `wwwroot` folder.

Use a base-relative path (`/`) to refer to the web root for a static asset. In the following example, `logo.png` is physically located in the `{PROJECT ROOT}/wwwroot/images` folder. `{PROJECT ROOT}` is the app's project root.

```razor
<img alt="Company logo" src="/images/logo.png" />
```

Components do **not** support tilde-slash notation (`~/`).

For information on setting an app's base path, see <xref:blazor/host-and-deploy/index#app-base-path>.

## Tag Helpers aren't supported in components

[`Tag Helpers`](xref:mvc/views/tag-helpers/intro) aren't supported in components. To provide Tag Helper-like functionality in Blazor, create a component with the same functionality as the Tag Helper and use the component instead.

## Scalable Vector Graphics (SVG) images

Since Blazor renders HTML, browser-supported images, including [Scalable Vector Graphics (SVG) images (`.svg`)](https://developer.mozilla.org/docs/Web/SVG), are supported via the `<img>` tag:

```html
<img alt="Example image" src="image.svg" />
```

Similarly, SVG images are supported in the CSS rules of a stylesheet file (`.css`):

```css
.element-class {
    background-image: url("image.svg");
}
```

## Whitespace rendering behavior

Whitespace is retained in a component's source markup. Whitespace-only text renders in the browser's DOM even when there's no visual effect.

Consider the following component markup:

```razor
<ul>
    @foreach (var item in Items)
    {
        <li>
            @item.Text
        </li>
    }
</ul>
```

The preceding example renders the following unnecessary whitespace:

* Outside of the `@foreach` code block.
* Around the `<li>` element.
* Around the `@item.Text` output.

A list of 100 items results in over 400 areas of whitespace. None of the extra whitespace visually affects the rendered output.

When rendering static HTML for components, whitespace inside a tag isn't preserved. For example, view the rendered output of the following `<img>` tag in a component Razor file (`.razor`):

```razor
<img     alt="Example image"   src="img.png"     />
```

Whitespace isn't preserved from the preceding markup:

```razor
<img alt="Example image" src="img.png" />
```

## Generic type parameter support

The [`@typeparam`][11] directive declares a [generic type parameter](/dotnet/csharp/programming-guide/generics/generic-type-parameters) for the generated component class:

```razor
@typeparam TItem
```

In the following example, the `ListGenericTypeItems1` component is generically typed as `TExample`.

`Shared/ListGenericTypeItems1.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Shared/index/ListGenericTypeItems1.razor)]

The following `GenericTypeExample1` component renders two `ListGenericTypeItems1` components:

* String or integer data is assigned to the `ExampleList` parameter of each component.
* Type `string` or `int` that matches the type of the assigned data is set for the type parameter (`TExample`) of each component.

`Pages/GenericTypeExample1.razor`:

[!code-razor[](~/blazor/samples/3.1/BlazorSample_WebAssembly/Pages/index/GenericTypeExample1.razor)]

For more information, see the following articles:

* <xref:mvc/views/razor#typeparam>
* <xref:blazor/components/templated-components>

:::moniker-end

<!--Reference links in article-->
[1]: <xref:mvc/views/razor#code>
[2]: <xref:mvc/views/razor#using>
[3]: <xref:mvc/views/razor#attributes>
[4]: <xref:mvc/views/razor#ref>
[5]: <xref:mvc/views/razor#key>
[6]: <xref:mvc/views/razor#inherits>
[7]: <xref:mvc/views/razor#attribute>
[8]: <xref:mvc/views/razor#namespace>
[9]: <xref:mvc/views/razor#page>
[10]: <xref:mvc/views/razor#bind>
[11]: <xref:mvc/views/razor#typeparam>
