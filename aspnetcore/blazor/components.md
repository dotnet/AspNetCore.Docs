---
title: Create and use ASP.NET Core Razor components
author: guardrex
description: Learn how to create and use Razor components, including how to bind to data, handle events, and manage component life cycles.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 05/14/2020
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/components
---
# Create and use ASP.NET Core Razor components

By [Luke Latham](https://github.com/guardrex), [Daniel Roth](https://github.com/danroth27), and [Tobias Bartsch](https://www.aveo-solutions.com/)

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/blazor/common/samples/) ([how to download](xref:index#how-to-download-a-sample))

Blazor apps are built using *components*. A component is a self-contained chunk of user interface (UI), such as a page, dialog, or form. A component includes HTML markup and the processing logic required to inject data or respond to UI events. Components are flexible and lightweight. They can be nested, reused, and shared among projects.

## Component classes

Components are implemented in [Razor](xref:mvc/views/razor) component files (*.razor*) using a combination of C# and HTML markup. A component in Blazor is formally referred to as a *Razor component*.

A component's name must start with an uppercase character. For example, *MyCoolComponent.razor* is valid, and *myCoolComponent.razor* is invalid.

The UI for a component is defined using HTML. Dynamic rendering logic (for example, loops, conditionals, expressions) is added using an embedded C# syntax called *Razor*. When an app is compiled, the HTML markup and C# rendering logic are converted into a component class. The name of the generated class matches the name of the file.

Members of the component class are defined in an [`@code`][1] block. In the [`@code`][1] block, component state (properties, fields) is specified with methods for event handling or for defining other component logic. More than one [`@code`][1] block is permissible.

Component members can be used as part of the component's rendering logic using C# expressions that start with `@`. For example, a C# field is rendered by prefixing `@` to the field name. The following example evaluates and renders:

* `headingFontStyle` to the CSS property value for `font-style`.
* `headingText` to the content of the `<h1>` element.

```razor
<h1 style="font-style:@headingFontStyle">@headingText</h1>

@code {
    private string headingFontStyle = "italic";
    private string headingText = "Put on your new Blazor!";
}
```

After the component is initially rendered, the component regenerates its render tree in response to events. Blazor then compares the new render tree against the previous one and applies any modifications to the browser's Document Object Model (DOM).

Components are ordinary C# classes and can be placed anywhere within a project. Components that produce webpages usually reside in the *Pages* folder. Non-page components are frequently placed in the *Shared* folder or a custom folder added to the project.

Typically, a component's namespace is derived from the app's root namespace and the component's location (folder) within the app. If the app's root namespace is `BlazorApp` and the `Counter` component resides in the *Pages* folder:

* The `Counter` component's namespace is `BlazorApp.Pages`.
* The fully qualified type name of the component is `BlazorApp.Pages.Counter`.

For custom folders that hold components, add a `using` statement to the parent component or to the app's *_Imports.razor* file. The following example makes components in the *Components* folder available:

```razor
@using BlazorApp.Components
```

Alternatively, a component can be directly referenced:

```razor
<BlazorApp.Components.MyCoolComponent />
```

For more information, see the [Import components](#import-components) section.

## Razor syntax

Razor components in Blazor apps extensively use Razor syntax. If you aren't familiar with the Razor markup language, we recommend reading <xref:mvc/views/razor> before proceeding.

When accessing the content on Razor syntax, pay special attention to the following sections:

* [Directives](xref:mvc/views/razor#directives): `@`-prefixed reserved keywords that typically change the way component markup is parsed or function.
* [Directive attributes](xref:mvc/views/razor#directive-attributes): `@`-prefixed reserved keywords that typically change the way component elements are parsed or function.

## Static assets

Blazor follows the convention of ASP.NET Core apps placing static assets under the project's [web root (wwwroot) folder](xref:fundamentals/index#web-root).

Use a base-relative path (`/`) to refer to the web root for a static asset. In the following example, *logo.png* is physically located in the *{PROJECT ROOT}/wwwroot/images* folder:

```razor
<img alt="Company logo" src="/images/logo.png" />
```

Razor components do **not** support tilde-slash notation (`~/`).

For information on setting an app's base path, see <xref:host-and-deploy/blazor/index#app-base-path>.

## Tag Helpers aren't supported in components

[Tag Helpers](xref:mvc/views/tag-helpers/intro) aren't supported in Razor components (*.razor* files). To provide Tag Helper-like functionality in Blazor, create a component with the same functionality as the Tag Helper and use the component instead.

## Use components

Components can include other components by declaring them using HTML element syntax. The markup for using a component looks like an HTML tag where the name of the tag is the component type.

The following markup in *Index.razor* renders a `HeadingComponent` instance:

```razor
<HeadingComponent />
```

*Components/HeadingComponent.razor*:

[!code-razor[](common/samples/3.x/BlazorWebAssemblySample/Components/HeadingComponent.razor)]

If a component contains an HTML element with an uppercase first letter that doesn't match a component name, a warning is emitted indicating that the element has an unexpected name. Adding an [`@using`][2] directive for the component's namespace makes the component available, which resolves the warning.

## Routing

Routing in Blazor is achieved by providing a route template to each accessible component in the app.

When a Razor file with an [`@page`][9] directive is compiled, the generated class is given a <xref:Microsoft.AspNetCore.Mvc.RouteAttribute> specifying the route template. At runtime, the router looks for component classes with a <xref:Microsoft.AspNetCore.Mvc.RouteAttribute> and renders whichever component has a route template that matches the requested URL.

```razor
@page "/ParentComponent"

...
```

For more information, see <xref:blazor/routing>.

## Parameters

### Route parameters

Components can receive route parameters from the route template provided in the [`@page`][9] directive. The router uses route parameters to populate the corresponding component parameters.

*Pages/RouteParameter.razor*:

[!code-razor[](components/samples_snapshot/RouteParameter.razor?highlight=2,7-8)]

Optional parameters aren't supported, so two [`@page`][9] directives are applied in the preceding example. The first permits navigation to the component without a parameter. The second [`@page`][9] directive receives the `{text}` route parameter and assigns the value to the `Text` property.

*Catch-all* parameter syntax (`*`/`**`), which captures the path across multiple folder boundaries, is **not** supported in Razor components (*.razor*).

### Component parameters

Components can have *component parameters*, which are defined using public properties on the component class with the [`[Parameter]`](xref:Microsoft.AspNetCore.Components.ParameterAttribute) attribute. Use attributes to specify arguments for a component in markup.

*Components/ChildComponent.razor*:

[!code-razor[](common/samples/3.x/BlazorWebAssemblySample/Components/ChildComponent.razor?highlight=2,11-12)]

In the following example from the sample app, the `ParentComponent` sets the value of the `Title` property of the `ChildComponent`.

*Pages/ParentComponent.razor*:

[!code-razor[](components/samples_snapshot/ParentComponent.razor?highlight=5-6)]

> [!WARNING]
> Don't create components that write to their own *component parameters*, use a private field instead. For more information, see the [Don't create components that write to their own parameter properties](#dont-create-components-that-write-to-their-own-parameter-properties) section.

## Child content

Components can set the content of another component. The assigning component provides the content between the tags that specify the receiving component.

In the following example, the `ChildComponent` has a `ChildContent` property that represents a <xref:Microsoft.AspNetCore.Components.RenderFragment>, which represents a segment of UI to render. The value of `ChildContent` is positioned in the component's markup where the content should be rendered. The value of `ChildContent` is received from the parent component and rendered inside the Bootstrap panel's `panel-body`.

*Components/ChildComponent.razor*:

[!code-razor[](common/samples/3.x/BlazorWebAssemblySample/Components/ChildComponent.razor?highlight=3,14-15)]

> [!NOTE]
> The property receiving the <xref:Microsoft.AspNetCore.Components.RenderFragment> content must be named `ChildContent` by convention.

The `ParentComponent` in the sample app can provide content for rendering the `ChildComponent` by placing the content inside the `<ChildComponent>` tags.

*Pages/ParentComponent.razor*:

[!code-razor[](components/samples_snapshot/ParentComponent.razor?highlight=7-8)]

## Attribute splatting and arbitrary parameters

Components can capture and render additional attributes in addition to the component's declared parameters. Additional attributes can be captured in a dictionary and then *splatted* onto an element when the component is rendered using the [`@attributes`][3] Razor directive. This scenario is useful when defining a component that produces a markup element that supports a variety of customizations. For example, it can be tedious to define attributes separately for an `<input>` that supports many parameters.

In the following example, the first `<input>` element (`id="useIndividualParams"`) uses individual component parameters, while the second `<input>` element (`id="useAttributesDict"`) uses attribute splatting:

```razor
<input id="useIndividualParams"
       maxlength="@Maxlength"
       placeholder="@Placeholder"
       required="@Required"
       size="@Size" />

<input id="useAttributesDict"
       @attributes="InputAttributes" />

@code {
    [Parameter]
    public string Maxlength { get; set; } = "10";

    [Parameter]
    public string Placeholder { get; set; } = "Input placeholder text";

    [Parameter]
    public string Required { get; set; } = "required";

    [Parameter]
    public string Size { get; set; } = "50";

    [Parameter]
    public Dictionary<string, object> InputAttributes { get; set; } =
        new Dictionary<string, object>()
        {
            { "maxlength", "10" },
            { "placeholder", "Input placeholder text" },
            { "required", "required" },
            { "size", "50" }
        };
}
```

The type of the parameter must implement `IEnumerable<KeyValuePair<string, object>>` with string keys. Using `IReadOnlyDictionary<string, object>` is also an option in this scenario.

The rendered `<input>` elements using both approaches is identical:

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

To accept arbitrary attributes, define a component parameter using the [`[Parameter]`](xref:Microsoft.AspNetCore.Components.ParameterAttribute) attribute with the <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues> property set to `true`:

```razor
@code {
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> InputAttributes { get; set; }
}
```

The <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues> property on [`[Parameter]`](xref:Microsoft.AspNetCore.Components.ParameterAttribute) allows the parameter to match all attributes that don't match any other parameter. A component can only define a single parameter with <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues>. The property type used with <xref:Microsoft.AspNetCore.Components.ParameterAttribute.CaptureUnmatchedValues> must be assignable from `Dictionary<string, object>` with string keys. `IEnumerable<KeyValuePair<string, object>>` or `IReadOnlyDictionary<string, object>` are also options in this scenario.

The position of [`@attributes`][3] relative to the position of element attributes is important. When [`@attributes`][3] are splatted on the element, the attributes are processed from right to left (last to first). Consider the following example of a component that consumes a `Child` component:

*ParentComponent.razor*:

```razor
<ChildComponent extra="10" />
```

*ChildComponent.razor*:

```razor
<div @attributes="AdditionalAttributes" extra="5" />

[Parameter(CaptureUnmatchedValues = true)]
public IDictionary<string, object> AdditionalAttributes { get; set; }
```

The `Child` component's `extra` attribute is set to the right of [`@attributes`][3]. The `Parent` component's rendered `<div>` contains `extra="5"` when passed through the additional attribute because the attributes are processed right to left (last to first):

```html
<div extra="5" />
```

In the following example, the order of `extra` and [`@attributes`][3] is reversed in the `Child` component's `<div>`:

*ParentComponent.razor*:

```razor
<ChildComponent extra="10" />
```

*ChildComponent.razor*:

```razor
<div extra="5" @attributes="AdditionalAttributes" />

[Parameter(CaptureUnmatchedValues = true)]
public IDictionary<string, object> AdditionalAttributes { get; set; }
```

The rendered `<div>` in the `Parent` component contains `extra="10"` when passed through the additional attribute:

```html
<div extra="10" />
```

## Capture references to components

Component references provide a way to reference a component instance so that you can issue commands to that instance, such as `Show` or `Reset`. To capture a component reference:

* Add an [`@ref`][4] attribute to the child component.
* Define a field with the same type as the child component.

```razor
<MyLoginDialog @ref="loginDialog" ... />

@code {
    private MyLoginDialog loginDialog;

    private void OnSomething()
    {
        loginDialog.Show();
    }
}
```

When the component is rendered, the `loginDialog` field is populated with the `MyLoginDialog` child component instance. You can then invoke .NET methods on the component instance.

> [!IMPORTANT]
> The `loginDialog` variable is only populated after the component is rendered and its output includes the `MyLoginDialog` element. Until that point, there's nothing to reference. To manipulate components references after the component has finished rendering, use the [OnAfterRenderAsync or OnAfterRender methods](xref:blazor/lifecycle#after-component-render).

To reference components in a loop, see [Capture references to multiple similar child-components (dotnet/aspnetcore #13358)](https://github.com/dotnet/aspnetcore/issues/13358).

While capturing component references use a similar syntax to [capturing element references](xref:blazor/call-javascript-from-dotnet#capture-references-to-elements), it isn't a JavaScript interop feature. Component references aren't passed to JavaScript code. Component references are only used in .NET code.

> [!NOTE]
> Do **not** use component references to mutate the state of child components. Instead, use normal declarative parameters to pass data to child components. Use of normal declarative parameters result in child components that rerender at the correct times automatically.

## Invoke component methods externally to update state

Blazor uses a synchronization context (<xref:System.Threading.SynchronizationContext>) to enforce a single logical thread of execution. A component's [lifecycle methods](xref:blazor/lifecycle) and any event callbacks that are raised by Blazor are executed on the synchronization context.

Blazor Server's synchronization context attempts to emulate a single-threaded environment so that it closely matches the WebAssembly model in the browser, which is single threaded. At any given point in time, work is performed on exactly one thread, giving the impression of a single logical thread. No two operations execute concurrently.

In the event a component must be updated based on an external event, such as a timer or other notifications, use the `InvokeAsync` method, which dispatches to Blazor's synchronization context. For example, consider a *notifier service* that can notify any listening component of the updated state:

```csharp
public class NotifierService
{
    // Can be called from anywhere
    public async Task Update(string key, int value)
    {
        if (Notify != null)
        {
            await Notify.Invoke(key, value);
        }
    }

    public event Func<string, int, Task> Notify;
}
```

Register the `NotifierService` as a singletion:

* In Blazor WebAssembly, register the service in `Program.Main`:

  ```csharp
  builder.Services.AddSingleton<NotifierService>();
  ```

* In Blazor Server, register the service in `Startup.ConfigureServices`:

  ```csharp
  services.AddSingleton<NotifierService>();
  ```

Use the `NotifierService` to update a component:

```razor
@page "/"
@inject NotifierService Notifier
@implements IDisposable

<p>Last update: @lastNotification.key = @lastNotification.value</p>

@code {
    private (string key, int value) lastNotification;

    protected override void OnInitialized()
    {
        Notifier.Notify += OnNotify;
    }

    public async Task OnNotify(string key, int value)
    {
        await InvokeAsync(() =>
        {
            lastNotification = (key, value);
            StateHasChanged();
        });
    }

    public void Dispose()
    {
        Notifier.Notify -= OnNotify;
    }
}
```

In the preceding example, `NotifierService` invokes the component's `OnNotify` method outside of Blazor's synchronization context. `InvokeAsync` is used to switch to the correct context and queue a render.

## Use \@key to control the preservation of elements and components

When rendering a list of elements or components and the elements or components subsequently change, Blazor's diffing algorithm must decide which of the previous elements or components can be retained and how model objects should map to them. Normally, this process is automatic and can be ignored, but there are cases where you may want to control the process.

Consider the following example:

```csharp
@foreach (var person in People)
{
    <DetailsEditor Details="@person.Details" />
}

@code {
    [Parameter]
    public IEnumerable<Person> People { get; set; }
}
```

The contents of the `People` collection may change with inserted, deleted, or re-ordered entries. When the component rerenders, the `<DetailsEditor>` component may change to receive different `Details` parameter values. This may cause more complex rerendering than expected. In some cases, rerendering can lead to visible behavior differences, such as lost element focus.

The mapping process can be controlled with the [`@key`][5] directive attribute. [`@key`][5] causes the diffing algorithm to guarantee preservation of elements or components based on the key's value:

```csharp
@foreach (var person in People)
{
    <DetailsEditor @key="person" Details="@person.Details" />
}

@code {
    [Parameter]
    public IEnumerable<Person> People { get; set; }
}
```

When the `People` collection changes, the diffing algorithm retains the association between `<DetailsEditor>` instances and `person` instances:

* If a `Person` is deleted from the `People` list, only the corresponding `<DetailsEditor>` instance is removed from the UI. Other instances are left unchanged.
* If a `Person` is inserted at some position in the list, one new `<DetailsEditor>` instance is inserted at that corresponding position. Other instances are left unchanged.
* If `Person` entries are re-ordered, the corresponding `<DetailsEditor>` instances are preserved and re-ordered in the UI.

In some scenarios, use of [`@key`][5] minimizes the complexity of rerendering and avoids potential issues with stateful parts of the DOM changing, such as focus position.

> [!IMPORTANT]
> Keys are local to each container element or component. Keys aren't compared globally across the document.

### When to use \@key

Typically, it makes sense to use [`@key`][5] whenever a list is rendered (for example, in a [foreach](/dotnet/csharp/language-reference/keywords/foreach-in) block) and a suitable value exists to define the [`@key`][5].

You can also use [`@key`][5] to prevent Blazor from preserving an element or component subtree when an object changes:

```razor
<div @key="currentPerson">
    ... content that depends on currentPerson ...
</div>
```

If `@currentPerson` changes, the [`@key`][5] attribute directive forces Blazor to discard the entire `<div>` and its descendants and rebuild the subtree within the UI with new elements and components. This can be useful if you need to guarantee that no UI state is preserved when `@currentPerson` changes.

### When not to use \@key

There's a performance cost when diffing with [`@key`][5]. The performance cost isn't large, but only specify [`@key`][5] if controlling the element or component preservation rules benefit the app.

Even if [`@key`][5] isn't used, Blazor preserves child element and component instances as much as possible. The only advantage to using [`@key`][5] is control over *how* model instances are mapped to the preserved component instances, instead of the diffing algorithm selecting the mapping.

### What values to use for \@key

Generally, it makes sense to supply one of the following kinds of value for [`@key`][5]:

* Model object instances (for example, a `Person` instance as in the earlier example). This ensures preservation based on object reference equality.
* Unique identifiers (for example, primary key values of type `int`, `string`, or `Guid`).

Ensure that values used for [`@key`][5] don't clash. If clashing values are detected within the same parent element, Blazor throws an exception because it can't deterministically map old elements or components to new elements or components. Only use distinct values, such as object instances or primary key values.

## Don't create components that write to their own parameter properties

Parameters are overwritten under the following conditions:

* A child component's content is rendered with a <xref:Microsoft.AspNetCore.Components.RenderFragment>.
* <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> is called in the parent component.

Parameters are reset because the parent component rerenders when <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> is called and new parameter values are supplied to the child component.

Consider the following `Expander` component that:

* Renders child content.
* Toggles showing child content with a component parameter.

```razor
<div @onclick="@Toggle">
    Toggle (Expanded = @Expanded)

    @if (Expanded)
    {
        @ChildContent
    }
</div>

@code {
    [Parameter]
    public bool Expanded { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    private void Toggle()
    {
        Expanded = !Expanded;
    }
}
```

The `Expander` component is added to a parent component that may call <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A>:

```razor
<Expander Expanded="true">
    <h1>Hello, world!</h1>
</Expander>

<Expander Expanded="true" />

<button @onclick="@(() => StateHasChanged())">
    Call StateHasChanged
</button>
```

Initially, the `Expander` components behave independently when their `Expanded` properties are toggled. The child components maintain their states as expected. When <xref:Microsoft.AspNetCore.Components.ComponentBase.StateHasChanged%2A> is called in the parent, the `Expanded` parameter of the first child component is reset back to its initial value (`true`). The second `Expander` component's `Expanded` value isn't reset because no child content is rendered in the second component.

To maintain state in the preceding scenario, use a *private field* in the `Expander` component to maintain its toggled state.

The following `Expander` component:

* Accepts the `Expanded` component parameter value from the parent.
* Assigns the component parameter value to a *private field* (`expanded`) in the [OnInitialized event](xref:blazor/lifecycle#component-initialization-methods).
* Uses the private field to maintain its internal toggle state.

```razor
<div @onclick="@Toggle">
    Toggle (Expanded = @expanded)

    @if (expanded)
    {
        @ChildContent
    }
</div>

@code {
    [Parameter]
    public bool Expanded { get; set; }

    [Parameter]
    public RenderFragment ChildContent { get; set; }

    private bool expanded;

    protected override void OnInitialized()
    {
        expanded = Expanded;
    }

    private void Toggle()
    {
        expanded = !expanded;
    }
}
```

## Partial class support

Razor components are generated as partial classes. Razor components are authored using either of the following approaches:

* C# code is defined in an [`@code`][1] block with HTML markup and Razor code in a single file. Blazor templates define their Razor components using this approach.
* C# code is placed in a code-behind file defined as a partial class.

The following example shows the default `Counter` component with an [`@code`][1] block in an app generated from a Blazor template. HTML markup, Razor code, and C# code are in the same file:

*Counter.razor*:

```razor
@page "/counter"

<h1>Counter</h1>

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    private int currentCount = 0;

    void IncrementCount()
    {
        currentCount++;
    }
}
```

The `Counter` component can also be created using a code-behind file with a partial class:

*Counter.razor*:

```razor
@page "/counter"

<h1>Counter</h1>

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>
```

*Counter.razor.cs*:

```csharp
namespace BlazorApp.Pages
{
    public partial class Counter
    {
        private int currentCount = 0;

        void IncrementCount()
        {
            currentCount++;
        }
    }
}
```

Add any required namespaces to the partial class file as needed. Typical namespaces used by Razor components include:

```csharp
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
```

## Specify a base class

The [`@inherits`][6] directive can be used to specify a base class for a component. The following example shows how a component can inherit a base class, `BlazorRocksBase`, to provide the component's properties and methods. The base class should derive from <xref:Microsoft.AspNetCore.Components.ComponentBase>.

*Pages/BlazorRocks.razor*:

```razor
@page "/BlazorRocks"
@inherits BlazorRocksBase

<h1>@BlazorRocksText</h1>
```

*BlazorRocksBase.cs*:

```csharp
using Microsoft.AspNetCore.Components;

namespace BlazorSample
{
    public class BlazorRocksBase : ComponentBase
    {
        public string BlazorRocksText { get; set; } = 
            "Blazor rocks the browser!";
    }
}
```

## Specify an attribute

Attributes can be specified in Razor components with the [`@attribute`][7] directive. The following example applies the [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute to the component class:

```razor
@page "/"
@attribute [Authorize]
```

## Import components

The namespace of a component authored with Razor is based on (in priority order):

* [`@namespace`][8] designation in Razor file (*.razor*) markup (`@namespace BlazorSample.MyNamespace`).
* The project's `RootNamespace` in the project file (`<RootNamespace>BlazorSample</RootNamespace>`).
* The project name, taken from the project file's file name (*.csproj*), and the path from the project root to the component. For example, the framework resolves *{PROJECT ROOT}/Pages/Index.razor* (*BlazorSample.csproj*) to the namespace `BlazorSample.Pages`. Components follow C# name binding rules. For the `Index` component in this example, the components in scope are all of the components:
  * In the same folder, *Pages*.
  * The components in the project's root that don't explicitly specify a different namespace.

Components defined in a different namespace are brought into scope using Razor's [`@using`][2] directive.

If another component, `NavMenu.razor`, exists in the *BlazorSample/Shared/* folder, the component can be used in `Index.razor` with the following [`@using`][2] statement:

```razor
@using BlazorSample.Shared

This is the Index page.

<NavMenu></NavMenu>
```

Components can also be referenced using their fully qualified names, which doesn't require the [`@using`][2] directive:

```razor
This is the Index page.

<BlazorSample.Shared.NavMenu></BlazorSample.Shared.NavMenu>
```

> [!NOTE]
> The `global::` qualification isn't supported.
>
> Importing components with aliased [using](/dotnet/csharp/language-reference/keywords/using-statement) statements (for example, `@using Foo = Bar`) isn't supported.
>
> Partially qualified names aren't supported. For example, adding `@using BlazorSample` and referencing the `NavMenu` component (`NavMenu.razor`) with `<Shared.NavMenu></Shared.NavMenu>` isn't supported.

## Conditional HTML element attributes

HTML element attributes are conditionally rendered based on the .NET value. If the value is `false` or `null`, the attribute isn't rendered. If the value is `true`, the attribute is rendered minimized.

In the following example, `IsCompleted` determines if `checked` is rendered in the element's markup:

```razor
<input type="checkbox" checked="@IsCompleted" />

@code {
    [Parameter]
    public bool IsCompleted { get; set; }
}
```

If `IsCompleted` is `true`, the check box is rendered as:

```html
<input type="checkbox" checked />
```

If `IsCompleted` is `false`, the check box is rendered as:

```html
<input type="checkbox" />
```

For more information, see <xref:mvc/views/razor>.

> [!WARNING]
> Some HTML attributes, such as [aria-pressed](https://developer.mozilla.org/docs/Web/Accessibility/ARIA/Roles/button_role#Toggle_buttons), don't function properly when the .NET type is a `bool`. In those cases, use a `string` type instead of a `bool`.

## Raw HTML

Strings are normally rendered using DOM text nodes, which means that any markup they may contain is ignored and treated as literal text. To render raw HTML, wrap the HTML content in a `MarkupString` value. The value is parsed as HTML or SVG and inserted into the DOM.

> [!WARNING]
> Rendering raw HTML constructed from any untrusted source is a **security risk** and should be avoided!

The following example shows using the `MarkupString` type to add a block of static HTML content to the rendered output of a component:

```html
@((MarkupString)myMarkup)

@code {
    private string myMarkup = 
        "<p class='markup'>This is a <em>markup string</em>.</p>";
}
```

## Cascading values and parameters

In some scenarios, it's inconvenient to flow data from an ancestor component to a descendent component using [component parameters](#component-parameters), especially when there are several component layers. Cascading values and parameters solve this problem by providing a convenient way for an ancestor component to provide a value to all of its descendent components. Cascading values and parameters also provide an approach for components to coordinate.

### Theme example

In the following example from the sample app, the `ThemeInfo` class specifies the theme information to flow down the component hierarchy so that all of the buttons within a given part of the app share the same style.

*UIThemeClasses/ThemeInfo.cs*:

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
<CascadingValue Value=@parentCascadeParameter1 Name="CascadeParam1">
    <CascadingValue Value=@ParentCascadeParameter2 Name="CascadeParam2">
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

Cascading parameters also enable components to collaborate across the component hierarchy. For example, consider the following *TabSet* example in the sample app.

The sample app has an `ITab` interface that tabs implement:

[!code-csharp[](common/samples/3.x/BlazorWebAssemblySample/UIInterfaces/ITab.cs)]

The `CascadingValuesParametersTabSet` component uses the `TabSet` component, which contains several `Tab` components:

```razor
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
```

The child `Tab` components aren't explicitly passed as parameters to the `TabSet`. Instead, the child `Tab` components are part of the child content of the `TabSet`. However, the `TabSet` still needs to know about each `Tab` component so that it can render the headers and the active tab. To enable this coordination without requiring additional code, the `TabSet` component *can provide itself as a cascading value* that is then picked up by the descendent `Tab` components.

`TabSet` component:

[!code-razor[](common/samples/3.x/BlazorWebAssemblySample/Components/TabSet.razor)]

The descendent `Tab` components capture the containing `TabSet` as a cascading parameter, so the `Tab` components add themselves to the `TabSet` and coordinate on which tab is active.

`Tab` component:

[!code-razor[](common/samples/3.x/BlazorWebAssemblySample/Components/Tab.razor)]

## Razor templates

Render fragments can be defined using Razor template syntax. Razor templates are a way to define a UI snippet and assume the following format:

```razor
@<{HTML tag}>...</{HTML tag}>
```

The following example illustrates how to specify <xref:Microsoft.AspNetCore.Components.RenderFragment> and <xref:Microsoft.AspNetCore.Components.RenderFragment%601> values and render templates directly in a component. Render fragments can also be passed as arguments to [templated components](xref:blazor/templated-components).

```razor
@timeTemplate

@petTemplate(new Pet { Name = "Rex" })

@code {
    private RenderFragment timeTemplate = @<p>The time is @DateTime.Now.</p>;
    private RenderFragment<Pet> petTemplate = (pet) => @<p>Pet: @pet.Name</p>;

    private class Pet
    {
        public string Name { get; set; }
    }
}
```

Rendered output of the preceding code:

```html
<p>The time is 10/04/2018 01:26:52.</p>

<p>Pet: Rex</p>
```

## Scalable Vector Graphics (SVG) images

Since Blazor renders HTML, browser-supported images, including Scalable Vector Graphics (SVG) images (*.svg*), are supported via the `<img>` tag:

```html
<img alt="Example image" src="some-image.svg" />
```

Similarly, SVG images are supported in the CSS rules of a stylesheet file (*.css*):

```css
.my-element {
    background-image: url("some-image.svg");
}
```

However, inline SVG markup isn't supported in all scenarios. If you place an `<svg>` tag directly into a component file (*.razor*), basic image rendering is supported but many advanced scenarios aren't yet supported. For example, `<use>` tags aren't currently respected, and [`@bind`][10] can't be used with some SVG tags. For more information, see [SVG support in Blazor (dotnet/aspnetcore #18271)](https://github.com/dotnet/aspnetcore/issues/18271).

## Additional resources

* <xref:security/blazor/server/threat-mitigation>: Includes guidance on building Blazor Server apps that must contend with resource exhaustion.

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
