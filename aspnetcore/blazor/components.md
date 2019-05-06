---
title: Create and use Razor components
author: guardrex
description: Learn how to create and use Razor components, including how to bind to data, handle events, and manage component life cycles.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 05/02/2019
uid: blazor/components
---
# Create and use Razor components

By [Luke Latham](https://github.com/guardrex), [Daniel Roth](https://github.com/danroth27), and [Morné Zaayman](https://github.com/MorneZaayman)

[View or download sample code](https://github.com/aspnet/AspNetCore.Docs/tree/master/aspnetcore/blazor/common/samples/) ([how to download](xref:index#how-to-download-a-sample))

Blazor apps are built using *components*. A component is a self-contained chunk of user interface (UI), such as a page, dialog, or form. A component includes HTML markup and the processing logic required to inject data or respond to UI events. Components are flexible and lightweight. They can be nested, reused, and shared among projects.

## Component classes

Components are implemented in [Razor](xref:mvc/views/razor) component files (*.razor*) using a combination of C# and HTML markup.

Components can be authored using the *.cshtml* file extension as long as the files are identified as Razor component files using the `_RazorComponentInclude` MSBuild property. For example, an app that specifies that all *.cshtml* files under the *Pages* folder should be treated as Razor components files:

```xml
<_RazorComponentInclude>Pages\**\*.cshtml</_RazorComponentInclude>
```

The UI for a component is defined using HTML. Dynamic rendering logic (for example, loops, conditionals, expressions) is added using an embedded C# syntax called [Razor](xref:mvc/views/razor). When an app is compiled, the HTML markup and C# rendering logic are converted into a component class. The name of the generated class matches the name of the file.

Members of the component class are defined in an `@functions` block (more than one `@functions` block is permissible). In the `@functions` block, component state (properties, fields) is specified with methods for event handling or for defining other component logic.

Component members can then be used as part of the component's rendering logic using C# expressions that start with `@`. For example, a C# field is rendered by prefixing `@` to the field name. The following example evaluates and renders:

* `_headingFontStyle` to the CSS property value for `font-style`.
* `_headingText` to the content of the `<h1>` element.

```cshtml
<h1 style="font-style:@_headingFontStyle">@_headingText</h1>

@functions {
    private string _headingFontStyle = "italic";
    private string _headingText = "Put on your new Blazor!";
}
```

After the component is initially rendered, the component regenerates its render tree in response to events. Blazor then compares the new render tree against the previous one and applies any modifications to the browser's Document Object Model (DOM).

## Integrate components into Razor Pages and MVC apps

Use components with existing Razor Pages and MVC apps. There's no need to rewrite existing pages or views to use Razor components. When the page or view is rendered, components are prerendered&dagger; at the same time. 

> [!NOTE]
> &dagger;Server-side prerendering is enabled for Blazor server-side apps by default. Client-side Blazor apps will support prerendering in the upcoming Preview 5 release. For more information, see [Update templates/middleware to use MapFallbackToPage/File](https://github.com/aspnet/AspNetCore/issues/8852).

To render a component from a page or view, use the `RenderComponentAsync<TComponent>` HTML helper method:

```cshtml
<div id="Counter">
    @(await Html.RenderComponentAsync<Counter>(new { IncrementAmount = 10 }))
</div>
```

While pages and views can use components, the converse isn't true. Components can't use view- and page-specific scenarios, such as partial views and sections. To use logic from partial view in a component, factor out the partial view logic into a component.

For more information on how components are rendered and component state is managed in Blazor server-side apps, see the <xref:blazor/hosting-models> article.

## Using components

Components can include other components by declaring them using HTML element syntax. The markup for using a component looks like an HTML tag where the name of the tag is the component type.

The following markup in *Index.razor* renders a `HeadingComponent` instance, which exists in another file, *HeadingComponent.razor*:

[!code-cshtml[](common/samples/3.x/BlazorSample/Pages/Index.razor?name=snippet_HeadingComponent)]

## Component parameters

Components can have *component parameters*, which are defined using *non-public* properties on the component class with the `[Parameter]` attribute. Use attributes to specify arguments for a component in markup.

In the following example, the `ParentComponent` sets the value of the `Title` property of the `ChildComponent`:

*Parent component*:

[!code-cshtml[](common/samples/3.x/BlazorSample/Pages/ParentComponent.razor?name=snippet_ParentComponent&highlight=5-6)]

*Child component*:

[!code-cshtml[](common/samples/3.x/BlazorSample/Pages/ChildComponent.razor?highlight=11-12)]

## Child content

Components can set the content of another component. The assigning component provides the content between the tags that specify the receiving component. For example, a `ParentComponent` can provide content for rendering by a Child component by placing the content inside `<ChildComponent>` tags.

*Parent component*:

[!code-cshtml[](common/samples/3.x/BlazorSample/Pages/ParentComponent.razor?name=snippet_ParentComponent&highlight=7-8)]

The Child component has a `ChildContent` property that represents a `RenderFragment`. The value of `ChildContent` is positioned in the child component's markup where the content should be rendered. In the following example, the value of `ChildContent` is received from the parent component and rendered inside the Bootstrap panel's `panel-body`.

*Child component*:

[!code-cshtml[](common/samples/3.x/BlazorSample/Pages/ChildComponent.razor?highlight=3,14-15)]

> [!NOTE]
> The property receiving the `RenderFragment` content must be named `ChildContent` by convention.

## Data binding

Data binding to both components and DOM elements is accomplished with the `bind` attribute. The following example binds the `_italicsCheck` field to the check box's checked state:

```cshtml
<input type="checkbox" class="form-check-input" id="italicsCheck" 
    bind="@_italicsCheck">
```

When the check box is selected and cleared, the property's value is updated to `true` and `false`, respectively.

The check box is updated in the UI only when the component is rendered, not in response to changing the property's value. Since components render themselves after event handler code executes, property updates are usually reflected in the UI immediately.

Using `bind` with a `CurrentValue` property (`<input bind="@CurrentValue">`) is essentially equivalent to the following:

```cshtml
<input value="@CurrentValue" 
    onchange="@((UIChangeEventArgs __e) => CurrentValue = __e.Value)">
```

When the component is rendered, the `value` of the input element comes from the `CurrentValue` property. When the user types in the text box, the `onchange` event is fired and the `CurrentValue` property is set to the changed value. In reality, the code generation is a little more complex because `bind` handles a few cases where type conversions are performed. In principle, `bind` associates the current value of an expression with a `value` attribute and handles changes using the registered handler.

In addition to `onchange`, the property can be bound using other events like `oninput` by being more explicit about what to bind to:

```cshtml
<input type="text" bind-value-oninput="@CurrentValue">
```

Unlike `onchange`, `oninput` fires for every character that is input into the text box.

**Format strings**

Data binding works with <xref:System.DateTime> format strings. Other format expressions, such as currency or number formats, aren't available at this time.

```cshtml
<input bind="@StartDate" format-value="yyyy-MM-dd">

@functions {
    [Parameter]
    private DateTime StartDate { get; set; } = new DateTime(2020, 1, 1);
}
```

The `format-value` attribute specifies the date format to apply to the `value` of the `input` element. The format is also used to parse the value when an `onchange` event occurs.

**Component parameters**

Binding also recognizes component parameters, where `bind-{property}` can bind a property value across components.

The following component uses `ChildComponent` and binds the `ParentYear` parameter from the parent to the `Year` parameter on the child component:

Parent component:

```cshtml
@page "/ParentComponent"

<h1>Parent Component</h1>

<p>ParentYear: @ParentYear</p>

<ChildComponent bind-Year="@ParentYear" />

<button class="btn btn-primary" onclick="@ChangeTheYear">
    Change Year to 1986
</button>

@functions {
    [Parameter]
    private int ParentYear { get; set; } = 1978;

    private void ChangeTheYear()
    {
        ParentYear = 1986;
    }
}
```

Child component:

```cshtml
<h2>Child Component</h2>

<p>Year: @Year</p>

@functions {
    [Parameter]
    private int Year { get; set; }

    [Parameter]
    private EventCallback<int> YearChanged { get; set; }
}
```

`EventCallback<T>` is explained in the [EventCallback](#eventcallback) section.

Loading the `ParentComponent` produces the following markup:

```html
<h1>Parent Component</h1>

<p>ParentYear: 1978</p>

<h2>Child Component</h2>

<p>Year: 1978</p>
```

If the value of the `ParentYear` property is changed by selecting the button in the `ParentComponent`, the `Year` property of the `ChildComponent` is updated. The new value of `Year` is rendered in the UI when the `ParentComponent` is rerendered:

```html
<h1>Parent Component</h1>

<p>ParentYear: 1986</p>

<h2>Child Component</h2>

<p>Year: 1986</p>
```

The `Year` parameter is bindable because it has a companion `YearChanged` event that matches the type of the `Year` parameter.

By convention, `<ChildComponent bind-Year="@ParentYear" />` is essentially equivalent to writing,

```cshtml
<ChildComponent bind-Year-YearChanged="@ParentYear" />
```

In general, a property can be bound to a corresponding event handler using `bind-property-event` attribute.

## Event handling

Razor components provide event handling features. For an HTML element attribute named `on<event>` (for example, `onclick`, `onsubmit`) with a delegate-typed value, Razor components treats the attribute's value as an event handler. The attribute's name always starts with `on`.

The following code calls the `UpdateHeading` method when the button is selected in the UI:

```cshtml
<button class="btn btn-primary" onclick="@UpdateHeading">
    Update heading
</button>

@functions {
    private void UpdateHeading(UIMouseEventArgs e)
    {
        ...
    }
}
```

The following code calls the `CheckboxChanged` method when the check box is changed in the UI:

```cshtml
<input type="checkbox" class="form-check-input" onchange="@CheckboxChanged">

@functions {
    private void CheckboxChanged()
    {
        ...
    }
}
```

Event handlers can also be asynchronous and return a <xref:System.Threading.Tasks.Task>. There's no need to manually call `StateHasChanged()`. Exceptions are logged when they occur.

```cshtml
<button class="btn btn-primary" onclick="@UpdateHeading">
    Update heading
</button>

@functions {
    private async Task UpdateHeading(UIMouseEventArgs e)
    {
        ...
    }
}
```

For some events, event-specific event argument types are permitted. If access to one of these event types isn't necessary, it isn't required in the method call.

The list of supported event arguments is:

* UIEventArgs
* UIChangeEventArgs
* UIKeyboardEventArgs
* UIMouseEventArgs

Lambda expressions can also be used:

```cshtml
<button onclick="@(e => Console.WriteLine("Hello, world!"))">Say hello</button>
```

It's often convenient to close over additional values, such as when iterating over a set of elements. The following example creates three buttons, each of which calls `UpdateHeading` passing an event argument (`UIMouseEventArgs`) and its button number (`buttonNumber`) when selected in the UI:

```cshtml
<h2>@message</h2>

@for (var i = 1; i < 4; i++)
{
    var buttonNumber = i;

    <button class="btn btn-primary"
            onclick="@(e => UpdateHeading(e, buttonNumber))">
        Button #@i
    </button>
}

@functions {
    private string message = "Select a button to learn its position.";

    private void UpdateHeading(UIMouseEventArgs e, int buttonNumber)
    {
        message = $"You selected Button #{buttonNumber} at " +
            $"mouse position: {e.ClientX} X {e.ClientY}.";
    }
}
```

> [!NOTE]
> Do **not** use the loop variable (`i`) in a `for` loop directly in a lambda expression. Otherwise the same variable is used by all lambda expressions causing `i`'s value to be the same in all lambdas. Always capture its value in a local variable (`buttonNumber` in the preceding example) and then use it.

### EventCallback

A common scenario with nested components is the desire to run a parent component's method when a child component event occurs&mdash;for example, when an `onclick` event occurs in the child. To expose events across components, use an `EventCallback`. A parent component can assign a callback method to a child component's `EventCallback`.

The Child component in the sample app demonstrates how a button's `onclick` handler is set up to receive an `EventCallback` delegate from the sample's Parent component. The `EventCallback` is typed with `UIMouseEventArgs`, which is appropriate for an `onclick` event from a peripheral device:

[!code-cshtml[](common/samples/3.x/BlazorSample/Pages/ChildComponent.razor?highlight=5-7,17-18)]

The Parent component sets the child's `EventCallback<T>` to its `ShowMessage` method:

[!code-cshtml[](common/samples/3.x/BlazorSample/Pages/ParentComponent.razor?name=snippet_ParentComponent&highlight=6,16-19)]

When the button is selected in the Child component:

* The Parent component's `ShowMessage` method is called. `messageText` is updated and displayed in the Parent component.
* A call to `StateHasChanged` isn't required in the callback's method (`ShowMessage`). `StateHasChanged` is called automatically to rerender the Parent component, just as child events trigger component rerendering in event handlers that execute within the child.

`EventCallback` and `EventCallback<T>` permit asynchronous delegates. `EventCallback<T>` is strongly typed and requires a specific argument type. `EventCallback` is weakly typed and allows any argument type.

```cshtml
<p><b>@messageText</b></p>

@{ var message = "Default Text"; }

<ChildComponent 
    OnClick="@(async () => { await Task.Yield(); messageText = "Blaze It!"; }" />

@function {
    private string messageText;
}
```

Invoke an `EventCallback` or `EventCallback<T>` with `InvokeAsync` and await the <xref:System.Threading.Tasks.Task>:

```csharp
await callback.InvokeAsync(arg);
```

Use `EventCallback` and `EventCallback<T>` for event handling and binding component parameters. Don't use `EventCallback` and `EventCallback<T>` for child content&mdash;continue to use `RenderFragment` and `RenderFragment<T>` for child content.

Prefer the strongly typed `EventCallback<T>`, which provides better error feedback to users of the component. Similar to other UI event handlers, specifying the event parameter is optional. Use `EventCallback` when there's no value passed to the callback.

## Capture references to components

Component references provide a way to reference a component instance so that you can issue commands to that instance, such as `Show` or `Reset`. To capture a component reference, add a `ref` attribute to the child component and then define a field with the same name and the same type as the child component.

```cshtml
<MyLoginDialog ref="loginDialog" ... />

@functions {
    private MyLoginDialog loginDialog;

    private void OnSomething()
    {
        loginDialog.Show();
    }
}
```

When the component is rendered, the `loginDialog` field is populated with the `MyLoginDialog` child component instance. You can then invoke .NET methods on the component instance.

> [!IMPORTANT]
> The `loginDialog` variable is only populated after the component is rendered and its output includes the `MyLoginDialog` element. Until that point, there's nothing to reference. To manipulate components references after the component has finished rendering, use the `OnAfterRenderAsync` or `OnAfterRender` methods.

While capturing component references use a similar syntax to [capturing element references](xref:blazor/javascript-interop#capture-references-to-elements), it isn't a [JavaScript interop](xref:blazor/javascript-interop) feature. Component references aren't passed to JavaScript code&mdash;they're only used in .NET code.

> [!NOTE]
> Do **not** use component references to mutate the state of child components. Instead, use normal declarative parameters to pass data to child components. This causes child components to rerender at the correct times automatically.

## Lifecycle methods

`OnInitAsync` and `OnInit` execute code to initialize the component. To perform an asynchronous operation, use `OnInitAsync` and the `await` keyword on the operation:

```csharp
protected override async Task OnInitAsync()
{
    await ...
}
```

For a synchronous operation, use `OnInit`:

```csharp
protected override void OnInit()
{
    ...
}
```

`OnParametersSetAsync` and `OnParametersSet` are called when a component has received parameters from its parent and the values are assigned to properties. These methods are executed after component initialization and each time the component is rendered:

```csharp
protected override async Task OnParametersSetAsync()
{
    await ...
}
```

```csharp
protected override void OnParametersSet()
{
    ...
}
```

`OnAfterRenderAsync` and `OnAfterRender` are called after a component has finished rendering. Element and component references are populated at this point. Use this stage to perform additional initialization steps using the rendered content, such as activating third-party JavaScript libraries that operate on the rendered DOM elements.

```csharp
protected override async Task OnAfterRenderAsync()
{
    await ...
}
```

```csharp
protected override void OnAfterRender()
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

If `base.SetParameters` isn't invoked, the custom code can interpret the incoming parameters value in any way required. For example, the incoming parameters aren't required to be assigned to the properties on the class.

`ShouldRender` can be overridden to suppress refreshing of the UI. If the implementation returns `true`, the UI is refreshed. Even if `ShouldRender` is overridden, the component is always initially rendered.

```csharp
protected override bool ShouldRender()
{
    var renderUI = true;

    return renderUI;
}
```

## Component disposal with IDisposable

If a component implements <xref:System.IDisposable>, the [Dispose method](/dotnet/standard/garbage-collection/implementing-dispose) is called when the component is removed from the UI. The following component uses `@implements IDisposable` and the `Dispose` method:

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

## Routing

Routing in Blazor is achieved by providing a route template to each accessible component in the app.

When a Razor file with an `@page` directive is compiled, the generated class is given a <xref:Microsoft.AspNetCore.Mvc.RouteAttribute> specifying the route template. At runtime, the router looks for component classes with a `RouteAttribute` and renders whichever component has a route template that matches the requested URL.

Multiple route templates can be applied to a component. The following component responds to requests for `/BlazorRoute` and `/DifferentBlazorRoute`:

[!code-cshtml[](common/samples/3.x/BlazorSample/Pages/BlazorRoute.razor?name=snippet_BlazorRoute)]

## Route parameters

Components can receive route parameters from the route template provided in the `@page` directive. The router uses route parameters to populate the corresponding component parameters.

*Route Parameter component*:

[!code-cshtml[](common/samples/3.x/BlazorSample/Pages/RouteParameter.razor?name=snippet_RouteParameter)]

Optional parameters aren't supported, so two `@page` directives are applied in the example above. The first permits navigation to the component without a parameter. The second `@page` directive takes the `{text}` route parameter and assigns the value to the `Text` property.

## Base class inheritance for a "code-behind" experience

Component files mix HTML markup and C# processing code in the same file. The `@inherits` directive can be used to provide Blazor apps with a "code-behind" experience that separates component markup from processing code.

The [sample app](https://github.com/aspnet/AspNetCore.Docs/tree/master/aspnetcore/blazor/common/samples/) shows how a component can inherit a base class, `BlazorRocksBase`, to provide the component's properties and methods.

*Blazor Rocks component*:

[!code-cshtml[](common/samples/3.x/BlazorSample/Pages/BlazorRocks.razor?name=snippet_BlazorRocks)]

*BlazorRocksBase.cs*:

[!code-csharp[](common/samples/3.x/BlazorSample/Pages/BlazorRocksBase.cs)]

The base class should derive from `ComponentBase`.

## Import components

The namespace of a component authored with Razor is based on:

* The project's `RootNamespace`.
* The path from the project root to the component. For example, `ComponentsSample/Pages/Index.razor` is in the namespace `ComponentsSample.Pages`. Components follow C# name binding rules. In the case of *Index.razor*, all components in the same folder, *Pages*, and the parent folder, *ComponentsSample*, are in scope.

Components defined in a different namespace can be brought into scope using Razor's [\@using](xref:mvc/views/razor#using) directive.

If another component, `NavMenu.razor`, exists in the folder `ComponentsSample/Shared/`, the component can be used in `Index.razor` with the following `@using` statement:

```cshtml
@using ComponentsSample.Shared

This is the Index page.

<NavMenu></NavMenu>
```

Components can also be referenced using their fully qualified names, which removes the need for the [\@using](xref:mvc/views/razor#using) directive:

```cshtml
This is the Index page.

<ComponentsSample.Shared.NavMenu></ComponentsSample.Shared.NavMenu>
```

> [!NOTE]
> The `global::` qualification isn't supported.
>
> Importing components with aliased `using` statements (for example, `@using Foo = Bar`) isn't supported.
>
> Partially qualified names aren't supported. For example, adding `@using ComponentsSample` and referencing `NavMenu.razor` with `<Shared.NavMenu></Shared.NavMenu>` isn't supported.

## Razor support

**Razor directives**

Razor directives are shown in the following table.

| Directive | Description |
| --------- | ----------- |
| [\@functions](xref:mvc/views/razor#section-5) | Adds a C# code block to a component. |
| `@implements` | Implements an interface for the generated component class. |
| [\@inherits](xref:mvc/views/razor#section-3) | Provides full control of the class that the component inherits. |
| [\@inject](xref:mvc/views/razor#section-4) | Enables service injection from the [service container](xref:fundamentals/dependency-injection). For more information, see [Dependency injection into views](xref:mvc/views/dependency-injection). |
| `@layout` | Specifies a layout component. Layout components are used to avoid code duplication and inconsistency. |
| [\@page](xref:razor-pages/index#razor-pages) | Specifies that the component should handle requests directly. The `@page` directive can be specified with a route and optional parameters. Unlike Razor Pages, the `@page` directive doesn't need to be the first directive at the top of the file. For more information, see [Routing](xref:blazor/routing). |
| [\@using](xref:mvc/views/razor#using) | Adds the C# `using` directive to the generated component class. This also brings all the components defined in that namespace into scope. |

**Conditional attributes**

Attributes are conditionally rendered based on the .NET value. If the value is `false` or `null`,  the attribute isn't rendered. If the value is `true`, the attribute is rendered minimized.

In the following example, `IsCompleted` determines if `checked` is rendered in the control's markup:

```cshtml
<input type="checkbox" checked="@IsCompleted">

@functions {
    [Parameter]
    private bool IsCompleted { get; set; }
}
```

If `IsCompleted` is `true`, the check box is rendered as:

```html
<input type="checkbox" checked>
```

If `IsCompleted` is `false`, the check box is rendered as:

```html
<input type="checkbox">
```

**Additional information on Razor**

For more information on Razor, see the [Razor syntax reference](xref:mvc/views/razor).

## Raw HTML

Strings are normally rendered using DOM text nodes, which means that any markup they may contain is ignored and treated as literal text. To render raw HTML, wrap the HTML content in a `MarkupString` value. The value is parsed as HTML or SVG and inserted into the DOM.

> [!WARNING]
> Rendering raw HTML constructed from any untrusted source is a **security risk** and should be avoided!

The following example shows using the `MarkupString` type to add a block of static HTML content to the rendered output of a component:

```html
@((MarkupString)myMarkup)

@functions {
    private string myMarkup = 
        "<p class='markup'>This is a <em>markup string</em>.</p>";
}
```

## Templated components

Templated components are components that accept one or more UI templates as parameters, which can then be used as part of the component's rendering logic. Templated components allow you to author higher-level components that are more reusable than regular components. A couple of examples include:

* A table component that allows a user to specify templates for the table's header, rows, and footer.
* A list component that allows a user to specify a template for rendering items in a list.

### Template parameters

A templated component is defined by specifying one or more component parameters of type `RenderFragment` or `RenderFragment<T>`. A render fragment represents a segment of UI that is rendered by the component. A render fragment optionally takes a parameter that can be specified when the render fragment is invoked.

*Table Template component*:

[!code-cshtml[](common/samples/3.x/BlazorSample/Components/TableTemplate.razor)]

When using a templated component, the template parameters can be specified using child elements that match the names of the parameters (`TableHeader` and `RowTemplate` in the following example):

```cshtml
<TableTemplate Items="@pets">
    <TableHeader>
        <th>ID</th>
        <th>Name</th>
    </TableHeader>
    <RowTemplate>
        <td>@context.PetId</td>
        <td>@context.Name</td>
    </RowTemplate>
</TableTemplate>
```

### Template context parameters

Component arguments of type `RenderFragment<T>` passed as elements have an implicit parameter named `context` (for example from the preceding code sample, `@context.PetId`), but you can change the parameter name using the `Context` attribute on the child element. In the following example, the `RowTemplate` element's `Context` attribute specifies the `pet` parameter:

```cshtml
<TableTemplate Items="@pets">
    <TableHeader>
        <th>ID</th>
        <th>Name</th>
    </TableHeader>
    <RowTemplate Context="pet">
        <td>@pet.PetId</td>
        <td>@pet.Name</td>
    </RowTemplate>
</TableTemplate>
```

Alternatively, you can specify the `Context` attribute on the component element. The specified `Context` attribute applies to all specified template parameters. This can be useful when you want to specify the content parameter name for implicit child content (without any wrapping child element). In the following example, the `Context` attribute appears on the `TableTemplate` element and applies to all template parameters:

```cshtml
<TableTemplate Items="@pets" Context="pet">
    <TableHeader>
        <th>ID</th>
        <th>Name</th>
    </TableHeader>
    <RowTemplate>
        <td>@pet.PetId</td>
        <td>@pet.Name</td>
    </RowTemplate>
</TableTemplate>
```

### Generic-typed components

Templated components are often generically typed. For example, a generic List View Template component can be used to render `IEnumerable<T>` values. To define a generic component, use the `@typeparam` directive to specify type parameters.

*ListView Template component*:

[!code-cshtml[](common/samples/3.x/BlazorSample/Components/ListViewTemplate.razor)]

When using generic-typed components, the type parameter is inferred if possible:

```cshtml
<ListViewTemplate Items="@pets">
    <ItemTemplate Context="pet">
        <li>@pet.Name</li>
    </ItemTemplate>
</ListViewTemplate>
```

Otherwise, the type parameter must be explicitly specified using an attribute that matches the name of the type parameter. In the following example, `TItem="Pet"` specifies the type:

```cshtml
<ListViewTemplate Items="@pets" TItem="Pet">
    <ItemTemplate Context="pet">
        <li>@pet.Name</li>
    </ItemTemplate>
</ListViewTemplate>
```

## Cascading values and parameters

In some scenarios, it's inconvenient to flow data from an ancestor component to a descendent component using [component parameters](#component-parameters), especially when there are several component layers. Cascading values and parameters solve this problem by providing a convenient way for an ancestor component to provide a value to all of its descendent components. Cascading values and parameters also provide an approach for components to coordinate.

### Theme example

In the following *Theme* example from the sample app, the `ThemeInfo` class specifies the theme information to flow down the component hierarchy so that all of the buttons within a given part of the app share the same style.

*UIThemeClasses/ThemeInfo.cs*:

```csharp
public class ThemeInfo
{
    public string ButtonClass { get; set; }
}
```

An ancestor component can provide a cascading value using the Cascading Value component. The Cascading Value component wraps a subtree of the component hierarchy and supplies a single value to all components within that subtree.

For example, the sample app specifies theme information (`ThemeInfo`) in one of the app's layouts as a cascading parameter for all components that make up the layout body of the `@Body` property. `ButtonClass` is assigned a value of `btn-success` in the layout component. Any descendent component can consume this property through the `ThemeInfo` cascading object.

*Cascading Values Parameters Layout component*:

```cshtml
@inherits LayoutComponentBase
@using BlazorSample.UIThemeClasses

<div class="container-fluid">
    <div class="row">
        <div class="col-sm-3">
            <NavMenu />
        </div>
        <div class="col-sm-9">
            <CascadingValue Value="@theme">
                <div class="content px-4">
                    @Body
                </div>
            </CascadingValue>
        </div>
    </div>
</div>

@functions {
    private ThemeInfo theme = new ThemeInfo { ButtonClass = "btn-success" };
}
```

To make use of cascading values, components declare cascading parameters using the `[CascadingParameter]` attribute or based on a string name value:

```cshtml
<CascadingValue Value=@PermInfo Name="UserPermissions">...</CascadingValue>

[CascadingParameter(Name = "UserPermissions")]
private PermInfo Permissions { get; set; }
```

Binding with a string name value is relevant if you have multiple cascading values of the same type and need to differentiate them within the same subtree.

Cascading values are bound to cascading parameters by type.

In the sample app, the Cascading Values Parameters Theme component binds the `ThemeInfo` cascading value to a cascading parameter. The parameter is used to set the CSS class for one of the buttons displayed by the component.

*Cascading Values Parameters Theme component*:

```cshtml
@page "/cascadingvaluesparameterstheme"
@layout CascadingValuesParametersLayout
@using BlazorSample.UIThemeClasses

<h1>Cascading Values & Parameters</h1>

<p>Current count: @currentCount</p>

<p>
    <button class="btn" onclick="@IncrementCount">
        Increment Counter (Unthemed)
    </button>
</p>

<p>
    <button class="btn @ThemeInfo.ButtonClass" onclick="@IncrementCount">
        Increment Counter (Themed)
    </button>
</p>

@functions {
    private int currentCount = 0;

    [CascadingParameter] protected ThemeInfo ThemeInfo { get; set; }

    private void IncrementCount()
    {
        currentCount++;
    }
}
```

### TabSet example

Cascading parameters also enable components to collaborate across the component hierarchy. For example, consider the following *TabSet* example in the sample app.

The sample app has an `ITab` interface that tabs implement:

[!code-cs[](common/samples/3.x/BlazorSample/UIInterfaces/ITab.cs)]

The Cascading Values Parameters TabSet component uses the Tab Set component, which contains several Tab components:

[!code-cshtml[](common/samples/3.x/BlazorSample/Pages/CascadingValuesParametersTabSet.razor?name=snippet_TabSet)]

The child Tab components aren't explicitly passed as parameters to the Tab Set. Instead, the child Tab components are part of the child content of the Tab Set. However, the Tab Set still needs to know about each Tab component so that it can render the headers and the active tab. To enable this coordination without requiring additional code, the Tab Set component *can provide itself as a cascading value* that is then picked up by the descendent Tab components.

*TabSet component*:

[!code-cshtml[](common/samples/3.x/BlazorSample/Components/TabSet.razor)]

The descendent Tab components capture the containing Tab Set as a cascading parameter, so the Tab components add themselves to the Tab Set and coordinate on which tab is active.

*Tab component*:

[!code-cshtml[](common/samples/3.x/BlazorSample/Components/Tab.razor)]

## Razor templates

Render fragments can be defined using Razor template syntax. Razor templates are a way to define a UI snippet and assume the following format:

```cshtml
@<tag>...</tag>
```

The following example illustrates how to specify `RenderFragment` and `RenderFragment<T>` values.

*Razor Templates component*:

```cshtml
@{
    RenderFragment template = @<p>The time is @DateTime.Now.</p>;
    RenderFragment<Pet> petTemplate = (pet) => @<p>Your pet's name is @pet.Name.</p>;
}
```

Render fragments defined using Razor templates can be passed as arguments to templated components or rendered directly. For example, the previous templates are directly rendered with the following Razor markup:

```cshtml
@template

@petTemplate(new Pet { Name = "Rex" })
```

Rendered output:

```
The time is 10/04/2018 01:26:52.

Your pet's name is Rex.
```

## Manual RenderTreeBuilder logic

`Microsoft.AspNetCore.Components.RenderTree` provides methods for manipulating components and elements, including building components manually in C# code.

> [!NOTE]
> Use of `RenderTreeBuilder` to create components is an advanced scenario. A malformed component (for example, an unclosed markup tag) can result in undefined behavior.

Consider the following Pet Details component, which can be manually built into another component:

```cshtml
<h2>Pet Details Component</h2>

<p>@PetDetailsQuote<p>

@functions
{
    [Parameter]
    string PetDetailsQuote { get; set; }
}
```

In the following example, the loop in the `CreateComponent` method generates three Pet Details components. When calling `RenderTreeBuilder` methods to create the components (`OpenComponent` and `AddAttribute`), sequence numbers are source code line numbers. The Blazor difference algorithm relies on the sequence numbers corresponding to distinct lines of code, not distinct call invocations. When creating a component with `RenderTreeBuilder` methods, hardcode the arguments for sequence numbers. **Using a calculation or counter to generate the sequence number can lead to poor performance.**

*Built Content component*:

```cshtml
@page "/BuiltContent"

<h1>Build a component</h1>

@CustomRender

<button type="button" onclick="@RenderComponent">
    Create three Pet Details components
</button>

@functions {
    private RenderFragment CustomRender { get; set; }
    
    private RenderFragment CreateComponent() => builder =>
    {
        for (var i = 0; i < 3; i++) 
        {
            builder.OpenComponent(0, typeof(PetDetails));
            builder.AddAttribute(1, "PetDetailsQuote", "Someone's best friend!");
            builder.CloseComponent();
        }
    };    
    
    private void RenderComponent()
    {
        CustomRender = CreateComponent();
    }
}
```
