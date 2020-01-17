---
title: Create and use ASP.NET Core Razor components
author: guardrex
description: Learn how to create and use Razor components, including how to bind to data, handle events, and manage component life cycles.
monikerRange: '>= aspnetcore-3.0'
ms.author: riande
ms.custom: mvc
ms.date: 12/28/2019
no-loc: [Blazor]
uid: blazor/components
---
# Create and use ASP.NET Core Razor components

By [Luke Latham](https://github.com/guardrex) and [Daniel Roth](https://github.com/danroth27)

[View or download sample code](https://github.com/aspnet/AspNetCore.Docs/tree/master/aspnetcore/blazor/common/samples/) ([how to download](xref:index#how-to-download-a-sample))

Blazor apps are built using *components*. A component is a self-contained chunk of user interface (UI), such as a page, dialog, or form. A component includes HTML markup and the processing logic required to inject data or respond to UI events. Components are flexible and lightweight. They can be nested, reused, and shared among projects.

## Component classes

Components are implemented in [Razor](xref:mvc/views/razor) component files (*.razor*) using a combination of C# and HTML markup. A component in Blazor is formally referred to as a *Razor component*.

A component's name must start with an uppercase character. For example, *MyCoolComponent.razor* is valid, and *myCoolComponent.razor* is invalid.

The UI for a component is defined using HTML. Dynamic rendering logic (for example, loops, conditionals, expressions) is added using an embedded C# syntax called [Razor](xref:mvc/views/razor). When an app is compiled, the HTML markup and C# rendering logic are converted into a component class. The name of the generated class matches the name of the file.

Members of the component class are defined in an `@code` block. In the `@code` block, component state (properties, fields) is specified with methods for event handling or for defining other component logic. More than one `@code` block is permissible.

> [!NOTE]
> In prior previews of ASP.NET Core 3.0, `@functions` blocks were used for the same purpose as `@code` blocks in Razor components. `@functions` blocks continue to function in Razor components, but we recommend using the `@code` block in ASP.NET Core 3.0 Preview 6 or later.

Component members can be used as part of the component's rendering logic using C# expressions that start with `@`. For example, a C# field is rendered by prefixing `@` to the field name. The following example evaluates and renders:

* `_headingFontStyle` to the CSS property value for `font-style`.
* `_headingText` to the content of the `<h1>` element.

```razor
<h1 style="font-style:@_headingFontStyle">@_headingText</h1>

@code {
    private string _headingFontStyle = "italic";
    private string _headingText = "Put on your new Blazor!";
}
```

After the component is initially rendered, the component regenerates its render tree in response to events. Blazor then compares the new render tree against the previous one and applies any modifications to the browser's Document Object Model (DOM).

Components are ordinary C# classes and can be placed anywhere within a project. Components that produce webpages usually reside in the *Pages* folder. Non-page components are frequently placed in the *Shared* folder or a custom folder added to the project. To use a custom folder, add the custom folder's namespace to either the parent component or to the app's *_Imports.razor* file. For example, the following namespace makes components in a *Components* folder available when the app's root namespace is `WebApplication`:

```razor
@using WebApplication.Components
```

## Integrate components into Razor Pages and MVC apps

Use components with existing Razor Pages and MVC apps. There's no need to rewrite existing pages or views to use Razor components. When the page or view is rendered, components are prerendered at the same time.

::: moniker range=">= aspnetcore-3.1"

To render a component from a page or view, use the `Component` Tag Helper:

```cshtml
<component type="typeof(Counter)" render-mode="ServerPrerendered" 
    param-IncrementAmount="10" />
```

Passing parameters (for example, `IncrementAmount` in the preceding example) is supported.

`RenderMode` configures whether the component:

* Is prerendered into the page.
* Is rendered as static HTML on the page or if it includes the necessary information to bootstrap a Blazor app from the user agent.

| `RenderMode`        | Description |
| ------------------- | ----------- |
| `ServerPrerendered` | Renders the component into static HTML and includes a marker for a Blazor Server app. When the user-agent starts, this marker is used to bootstrap a Blazor app. |
| `Server`            | Renders a marker for a Blazor Server app. Output from the component isn't included. When the user-agent starts, this marker is used to bootstrap a Blazor app. |
| `Static`            | Renders the component into static HTML. |

While pages and views can use components, the converse isn't true. Components can't use view- and page-specific scenarios, such as partial views and sections. To use logic from partial view in a component, factor out the partial view logic into a component.

Rendering server components from a static HTML page isn't supported.

For more information on how components are rendered, component state, and the `Component` Tag Helper, see <xref:blazor/hosting-models>.

::: moniker-end

::: moniker range="< aspnetcore-3.1"

To render a component from a page or view, use the `RenderComponentAsync<TComponent>` HTML helper method:

```cshtml
@(await Html.RenderComponentAsync<MyComponent>(RenderMode.ServerPrerendered))
```

`RenderMode` configures whether the component:

* Is prerendered into the page.
* Is rendered as static HTML on the page or if it includes the necessary information to bootstrap a Blazor app from the user agent.

| `RenderMode`        | Description |
| ------------------- | ----------- |
| `ServerPrerendered` | Renders the component into static HTML and includes a marker for a Blazor Server app. When the user-agent starts, this marker is used to bootstrap a Blazor app. Parameters aren't supported. |
| `Server`            | Renders a marker for a Blazor Server app. Output from the component isn't included. When the user-agent starts, this marker is used to bootstrap a Blazor app. Parameters aren't supported. |
| `Static`            | Renders the component into static HTML. Parameters are supported. |

While pages and views can use components, the converse isn't true. Components can't use view- and page-specific scenarios, such as partial views and sections. To use logic from partial view in a component, factor out the partial view logic into a component.

Rendering server components from a static HTML page isn't supported.

For more information on how components are rendered, component state, and the `RenderComponentAsync` HTML Helper, see <xref:blazor/hosting-models>.

::: moniker-end

## Use components

Components can include other components by declaring them using HTML element syntax. The markup for using a component looks like an HTML tag where the name of the tag is the component type.

Attribute binding is case sensitive. For example, `@bind` is valid, and `@Bind` is invalid.

The following markup in *Index.razor* renders a `HeadingComponent` instance:

```razor
<HeadingComponent />
```

*Components/HeadingComponent.razor*:

[!code-razor[](common/samples/3.x/BlazorWebAssemblySample/Components/HeadingComponent.razor)]

If a component contains an HTML element with an uppercase first letter that doesn't match a component name, a warning is emitted indicating that the element has an unexpected name. Adding an `@using` statement for the component's namespace makes the component available, which removes the warning.

## Component parameters

Components can have *component parameters*, which are defined using public properties on the component class with the `[Parameter]` attribute. Use attributes to specify arguments for a component in markup.

*Components/ChildComponent.razor*:

[!code-razor[](common/samples/3.x/BlazorWebAssemblySample/Components/ChildComponent.razor?highlight=11-12)]

In the following example from the sample app, the `ParentComponent` sets the value of the `Title` property of the `ChildComponent`.

*Pages/ParentComponent.razor*:

```razor
@page "/ParentComponent"

<h1>Parent-child example</h1>

<ChildComponent Title="Panel Title from Parent"
                OnClick="@ShowMessage">
    Content of the child component is supplied
    by the parent component.
</ChildComponent>

...
```

## Child content

Components can set the content of another component. The assigning component provides the content between the tags that specify the receiving component.

In the following example, the `ChildComponent` has a `ChildContent` property that represents a `RenderFragment`, which represents a segment of UI to render. The value of `ChildContent` is positioned in the component's markup where the content should be rendered. The value of `ChildContent` is received from the parent component and rendered inside the Bootstrap panel's `panel-body`.

*Components/ChildComponent.razor*:

[!code-razor[](common/samples/3.x/BlazorWebAssemblySample/Components/ChildComponent.razor?highlight=3,14-15)]

> [!NOTE]
> The property receiving the `RenderFragment` content must be named `ChildContent` by convention.

The `ParentComponent` in the sample app can provide content for rendering the `ChildComponent` by placing the content inside the `<ChildComponent>` tags.

*Pages/ParentComponent.razor*:

```razor
@page "/ParentComponent"

<h1>Parent-child example</h1>

<ChildComponent Title="Panel Title from Parent"
                OnClick="@ShowMessage">
    Content of the child component is supplied
    by the parent component.
</ChildComponent>

...
```

## Attribute splatting and arbitrary parameters

Components can capture and render additional attributes in addition to the component's declared parameters. Additional attributes can be captured in a dictionary and then *splatted* onto an element when the component is rendered using the [`@attributes`](xref:mvc/views/razor#attributes) Razor directive. This scenario is useful when defining a component that produces a markup element that supports a variety of customizations. For example, it can be tedious to define attributes separately for an `<input>` that supports many parameters.

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

To accept arbitrary attributes, define a component parameter using the `[Parameter]` attribute with the `CaptureUnmatchedValues` property set to `true`:

```razor
@code {
    [Parameter(CaptureUnmatchedValues = true)]
    public Dictionary<string, object> InputAttributes { get; set; }
}
```

The `CaptureUnmatchedValues` property on `[Parameter]` allows the parameter to match all attributes that don't match any other parameter. A component can only define a single parameter with `CaptureUnmatchedValues`. The property type used with `CaptureUnmatchedValues` must be assignable from `Dictionary<string, object>` with string keys. `IEnumerable<KeyValuePair<string, object>>` or `IReadOnlyDictionary<string, object>` are also options in this scenario.

The position of `@attributes` relative to the position of element attributes is important. When `@attributes` are splatted on the element, the attributes are processed from right to left (last to first). Consider the following example of a component that consumes a `Child` component:

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

The `Child` component's `extra` attribute is set to the right of `@attributes`. The `Parent` component's rendered `<div>` contains `extra="5"` when passed through the additional attribute because the attributes are processed right to left (last to first):

```html
<div extra="5" />
```

In the following example, the order of `extra` and `@attributes` is reversed in the `Child` component's `<div>`:

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

## Data binding

Data binding to both components and DOM elements is accomplished with the [`@bind`](xref:mvc/views/razor#bind) attribute. The following example binds a `CurrentValue` property to the text box's value:

```razor
<input @bind="CurrentValue" />

@code {
    private string CurrentValue { get; set; }
}
```

When the text box loses focus, the property's value is updated.

The text box is updated in the UI only when the component is rendered, not in response to changing the property's value. Since components render themselves after event handler code executes, property updates are *usually* reflected in the UI immediately after an event handler is triggered.

Using `@bind` with the `CurrentValue` property (`<input @bind="CurrentValue" />`) is essentially equivalent to the following:

```razor
<input value="@CurrentValue"
    @onchange="@((ChangeEventArgs __e) => CurrentValue = 
        __e.Value.ToString())" />
        
@code {
    private string CurrentValue { get; set; }
}
```

When the component is rendered, the `value` of the input element comes from the `CurrentValue` property. When the user types in the text box and changes element focus, the `onchange` event is fired and the `CurrentValue` property is set to the changed value. In reality, the code generation is more complex because `@bind` handles cases where type conversions are performed. In principle, `@bind` associates the current value of an expression with a `value` attribute and handles changes using the registered handler.

In addition to handling `onchange` events with `@bind` syntax, a property or field can be bound using other events by specifying an [`@bind-value`](xref:mvc/views/razor#bind) attribute with an `event` parameter ([`@bind-value:event`](xref:mvc/views/razor#bind)). The following example binds the `CurrentValue` property for the `oninput` event:

```razor
<input @bind-value="CurrentValue" @bind-value:event="oninput" />

@code {
    private string CurrentValue { get; set; }
}
```

Unlike `onchange`, which fires when the element loses focus, `oninput` fires when the value of the text box changes.

**Unparsable values**

When a user provides an unparsable value to a databound element, the unparsable value is automatically reverted to its previous value when the bind event is triggered.

Consider the following scenario:

* An `<input>` element is bound to an `int` type with an initial value of `123`:

  ```razor
  <input @bind="MyProperty" />

  @code {
      [Parameter]
      public int MyProperty { get; set; } = 123;
  }
  ```
* The user updates the value of the element to `123.45` in the page and changes the element focus.

In the preceding scenario, the element's value is reverted to `123`. When the value `123.45` is rejected in favor of the original value of `123`, the user understands that their value wasn't accepted.

By default, binding applies to the element's `onchange` event (`@bind="{PROPERTY OR FIELD}"`). Use `@bind-value="{PROPERTY OR FIELD}" @bind-value:event={EVENT}` to set a different event. For the `oninput` event (`@bind-value:event="oninput"`), the reversion occurs after any keystroke that introduces an unparsable value. When targeting the `oninput` event with an `int`-bound type, a user is prevented from typing a `.` character. A `.` character is immediately removed, so the user receives immediate feedback that only whole numbers are permitted. There are scenarios where reverting the value on the `oninput` event isn't ideal, such as when the user should be allowed to clear an unparsable `<input>` value. Alternatives include:

* Don't use the `oninput` event. Use the default `onchange` event (`@bind="{PROPERTY OR FIELD}"`), where an invalid value isn't reverted until the element loses focus.
* Bind to a nullable type, such as `int?` or `string`, and provide custom logic to handle invalid entries.
* Use a [form validation component](xref:blazor/forms-validation), such as `InputNumber` or `InputDate`. Form validation components have built-in support to manage invalid inputs. Form validation components:
  * Permit the user to provide invalid input and receive validation errors on the associated `EditContext`.
  * Display validation errors in the UI without interfering with the user entering additional webform data.

**Globalization**

`@bind` values are formatted for display and parsed using the current culture's rules.

The current culture can be accessed from the <xref:System.Globalization.CultureInfo.CurrentCulture?displayProperty=fullName> property.

[CultureInfo.InvariantCulture](xref:System.Globalization.CultureInfo.InvariantCulture) is used for the following field types (`<input type="{TYPE}" />`):

* `date`
* `number`

The preceding field types:

* Are displayed using their appropriate browser-based formatting rules.
* Can't contain free-form text.
* Provide user interaction characteristics based on the browser's implementation.

The following field types have specific formatting requirements and aren't currently supported by Blazor because they aren't supported by all major browsers:

* `datetime-local`
* `month`
* `week`

`@bind` supports the `@bind:culture` parameter to provide a <xref:System.Globalization.CultureInfo?displayProperty=fullName> for parsing and formatting a value. Specifying a culture isn't recommended when using the `date` and `number` field types. `date` and `number` have built-in Blazor support that provides the required culture.

For information on how to set the user's culture, see the [Localization](#localization) section.

**Format strings**

Data binding works with <xref:System.DateTime> format strings using [`@bind:format`](xref:mvc/views/razor#bind). Other format expressions, such as currency or number formats, aren't available at this time.

```razor
<input @bind="StartDate" @bind:format="yyyy-MM-dd" />

@code {
    [Parameter]
    public DateTime StartDate { get; set; } = new DateTime(2020, 1, 1);
}
```

In the preceding code, the `<input>` element's field type (`type`) defaults to `text`. `@bind:format` is supported for binding the following .NET types:

* <xref:System.DateTime?displayProperty=fullName>
* <xref:System.DateTime?displayProperty=fullName>?
* <xref:System.DateTimeOffset?displayProperty=fullName>
* <xref:System.DateTimeOffset?displayProperty=fullName>?

The `@bind:format` attribute specifies the date format to apply to the `value` of the `<input>` element. The format is also used to parse the value when an `onchange` event occurs.

Specifying a format for the `date` field type isn't recommended because Blazor has built-in support to format dates. In spite of the recommendation, only use the `yyyy-MM-dd` date format for binding to work correctly if a format is supplied with the `date` field type:

```razor
<input type="date" @bind="StartDate" @bind:format="yyyy-MM-dd">
```

**Component parameters**

Binding recognizes component parameters, where `@bind-{property}` can bind a property value across components.

The following child component (`ChildComponent`) has a `Year` component parameter and `YearChanged` callback:

```razor
<h2>Child Component</h2>

<p>Year: @Year</p>

@code {
    [Parameter]
    public int Year { get; set; }

    [Parameter]
    public EventCallback<int> YearChanged { get; set; }
}
```

`EventCallback<T>` is explained in the [EventCallback](#eventcallback) section.

The following parent component uses `ChildComponent` and binds the `ParentYear` parameter from the parent to the `Year` parameter on the child component:

```razor
@page "/ParentComponent"

<h1>Parent Component</h1>

<p>ParentYear: @ParentYear</p>

<ChildComponent @bind-Year="ParentYear" />

<button class="btn btn-primary" @onclick="ChangeTheYear">
    Change Year to 1986
</button>

@code {
    [Parameter]
    public int ParentYear { get; set; } = 1978;

    private void ChangeTheYear()
    {
        ParentYear = 1986;
    }
}
```

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

By convention, `<ChildComponent @bind-Year="ParentYear" />` is essentially equivalent to writing:

```razor
<ChildComponent @bind-Year="ParentYear" @bind-Year:event="YearChanged" />
```

In general, a property can be bound to a corresponding event handler using `@bind-property:event` attribute. For example, the property `MyProp` can be bound to `MyEventHandler` using the following two attributes:

```razor
<MyComponent @bind-MyProp="MyValue" @bind-MyProp:event="MyEventHandler" />
```

## Event handling

Razor components provide event handling features. For an HTML element attribute named `on{EVENT}` (for example, `onclick` and `onsubmit`) with a delegate-typed value, Razor components treats the attribute's value as an event handler. The attribute's name is always formatted [`@on{EVENT}`](xref:mvc/views/razor#onevent).

The following code calls the `UpdateHeading` method when the button is selected in the UI:

```razor
<button class="btn btn-primary" @onclick="UpdateHeading">
    Update heading
</button>

@code {
    private void UpdateHeading(MouseEventArgs e)
    {
        ...
    }
}
```

The following code calls the `CheckChanged` method when the check box is changed in the UI:

```razor
<input type="checkbox" class="form-check-input" @onchange="CheckChanged" />

@code {
    private void CheckChanged()
    {
        ...
    }
}
```

Event handlers can also be asynchronous and return a <xref:System.Threading.Tasks.Task>. There's no need to manually call [StateHasChanged](xref:blazor/lifecycle#state-changes). Exceptions are logged when they occur.

In the following example, `UpdateHeading` is called asynchronously when the button is selected:

```razor
<button class="btn btn-primary" @onclick="UpdateHeading">
    Update heading
</button>

@code {
    private async Task UpdateHeading(MouseEventArgs e)
    {
        ...
    }
}
```

### Event argument types

For some events, event argument types are permitted. If access to one of these event types isn't necessary, it isn't required in the method call.

Supported `EventArgs` are shown in the following table.

| Event            | Class                | DOM events and notes |
| ---------------- | -------------------- | -------------------- |
| Clipboard        | `ClipboardEventArgs` | `oncut`, `oncopy`, `onpaste` |
| Drag             | `DragEventArgs`      | `ondrag`, `ondragstart`, `ondragenter`, `ondragleave`, `ondragover`, `ondrop`, `ondragend`<br><br>`DataTransfer` and `DataTransferItem` hold dragged item data. |
| Error            | `ErrorEventArgs`     | `onerror` |
| Event            | `EventArgs`          | *General*<br>`onactivate`, `onbeforeactivate`, `onbeforedeactivate`, `ondeactivate`, `onended`, `onfullscreenchange`, `onfullscreenerror`, `onloadeddata`, `onloadedmetadata`, `onpointerlockchange`, `onpointerlockerror`, `onreadystatechange`, `onscroll`<br><br>*Clipboard*<br>`onbeforecut`, `onbeforecopy`, `onbeforepaste`<br><br>*Input*<br>`oninvalid`, `onreset`, `onselect`, `onselectionchange`, `onselectstart`, `onsubmit`<br><br>*Media*<br>`oncanplay`, `oncanplaythrough`, `oncuechange`, `ondurationchange`, `onemptied`, `onpause`, `onplay`, `onplaying`, `onratechange`, `onseeked`, `onseeking`, `onstalled`, `onstop`, `onsuspend`, `ontimeupdate`, `onvolumechange`, `onwaiting` |
| Focus            | `FocusEventArgs`     | `onfocus`, `onblur`, `onfocusin`, `onfocusout`<br><br>Doesn't include support for `relatedTarget`. |
| Input            | `ChangeEventArgs`    | `onchange`, `oninput` |
| Keyboard         | `KeyboardEventArgs`  | `onkeydown`, `onkeypress`, `onkeyup` |
| Mouse            | `MouseEventArgs`     | `onclick`, `oncontextmenu`, `ondblclick`, `onmousedown`, `onmouseup`, `onmouseover`, `onmousemove`, `onmouseout` |
| Mouse pointer    | `PointerEventArgs`   | `onpointerdown`, `onpointerup`, `onpointercancel`, `onpointermove`, `onpointerover`, `onpointerout`, `onpointerenter`, `onpointerleave`, `ongotpointercapture`, `onlostpointercapture` |
| Mouse wheel      | `WheelEventArgs`     | `onwheel`, `onmousewheel` |
| Progress         | `ProgressEventArgs`  | `onabort`, `onload`, `onloadend`, `onloadstart`, `onprogress`, `ontimeout` |
| Touch            | `TouchEventArgs`     | `ontouchstart`, `ontouchend`, `ontouchmove`, `ontouchenter`, `ontouchleave`, `ontouchcancel`<br><br>`TouchPoint` represents a single contact point on a touch-sensitive device. |

For information on the properties and event handling behavior of the events in the preceding table, see [EventArgs classes in the reference source (dotnet/AspNetCore release/3.0 branch)](https://github.com/dotnet/AspNetCore/tree/release/3.0/src/Components/Web/src/Web).

### Lambda expressions

Lambda expressions can also be used:

```razor
<button @onclick="@(e => Console.WriteLine("Hello, world!"))">Say hello</button>
```

It's often convenient to close over additional values, such as when iterating over a set of elements. The following example creates three buttons, each of which calls `UpdateHeading` passing an event argument (`MouseEventArgs`) and its button number (`buttonNumber`) when selected in the UI:

```razor
<h2>@message</h2>

@for (var i = 1; i < 4; i++)
{
    var buttonNumber = i;

    <button class="btn btn-primary"
            @onclick="@(e => UpdateHeading(e, buttonNumber))">
        Button #@i
    </button>
}

@code {
    private string message = "Select a button to learn its position.";

    private void UpdateHeading(MouseEventArgs e, int buttonNumber)
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

The `ChildComponent` in the sample app (*Components/ChildComponent.razor*) demonstrates how a button's `onclick` handler is set up to receive an `EventCallback` delegate from the sample's `ParentComponent`. The `EventCallback` is typed with `MouseEventArgs`, which is appropriate for an `onclick` event from a peripheral device:

[!code-razor[](common/samples/3.x/BlazorWebAssemblySample/Components/ChildComponent.razor?highlight=5-7,17-18)]

The `ParentComponent` sets the child's `EventCallback<T>` to its `ShowMessage` method.

*Pages/ParentComponent.razor*:

```razor
@page "/ParentComponent"

<h1>Parent-child example</h1>

<ChildComponent Title="Panel Title from Parent"
                OnClick="@ShowMessage">
    Content of the child component is supplied
    by the parent component.
</ChildComponent>

<p><b>@messageText</b></p>

@code {
    private string messageText;

    private void ShowMessage(MouseEventArgs e)
    {
        messageText = $"Blaze a new trail with Blazor! ({e.ScreenX}, {e.ScreenY})";
    }
}
```

When the button is selected in the `ChildComponent`:

* The `ParentComponent`'s `ShowMessage` method is called. `messageText` is updated and displayed in the `ParentComponent`.
* A call to [StateHasChanged](xref:blazor/lifecycle#state-changes) isn't required in the callback's method (`ShowMessage`). `StateHasChanged` is called automatically to rerender the `ParentComponent`, just as child events trigger component rerendering in event handlers that execute within the child.

`EventCallback` and `EventCallback<T>` permit asynchronous delegates. `EventCallback<T>` is strongly typed and requires a specific argument type. `EventCallback` is weakly typed and allows any argument type.

```razor
<p><b>@messageText</b></p>

@{ var message = "Default Text"; }

<ChildComponent 
    OnClick="@(async () => { await Task.Yield(); messageText = "Blaze It!"; })" />

@code {
    private string messageText;
}
```

Invoke an `EventCallback` or `EventCallback<T>` with `InvokeAsync` and await the <xref:System.Threading.Tasks.Task>:

```csharp
await callback.InvokeAsync(arg);
```

Use `EventCallback` and `EventCallback<T>` for event handling and binding component parameters.

Prefer the strongly typed `EventCallback<T>` over `EventCallback`. `EventCallback<T>` provides better error feedback to users of the component. Similar to other UI event handlers, specifying the event parameter is optional. Use `EventCallback` when there's no value passed to the callback.

::: moniker range=">= aspnetcore-3.1"

### Prevent default actions

Use the [`@on{EVENT}:preventDefault`](xref:mvc/views/razor#oneventpreventdefault) directive attribute to prevent the default action for an event.

When a key is selected on an input device and the element focus is on a text box, a browser normally displays the key's character in the text box. In the following example, the default behavior is prevented by specifying the `@onkeypress:preventDefault` directive attribute. The counter increments, and the **+** key isn't captured into the `<input>` element's value:

```razor
<input value="@_count" @onkeypress="KeyHandler" @onkeypress:preventDefault />

@code {
    private int _count = 0;

    private void KeyHandler(KeyboardEventArgs e)
    {
        if (e.Key == "+")
        {
            _count++;
        }
    }
}
```

Specifying the `@on{EVENT}:preventDefault` attribute without a value is equivalent to `@on{EVENT}:preventDefault="true"`.

The value of the attribute can also be an expression. In the following example, `_shouldPreventDefault` is a `bool` field set to either `true` or `false`:

```razor
<input @onkeypress:preventDefault="_shouldPreventDefault" />
```

An event handler isn't required to prevent the default action. The event handler and prevent default action scenarios can be used independently.

### Stop event propagation

Use the [`@on{EVENT}:stopPropagation`](xref:mvc/views/razor#oneventstoppropagation) directive attribute to stop event propagation.

In the following example, selecting the check box prevents click events from the second child `<div>` from propagating to the parent `<div>`:

```razor
<label>
    <input @bind="_stopPropagation" type="checkbox" />
    Stop Propagation
</label>

<div @onclick="OnSelectParentDiv">
    <h3>Parent div</h3>

    <div @onclick="OnSelectChildDiv">
        Child div that doesn't stop propagation when selected.
    </div>

    <div @onclick="OnSelectChildDiv" @onclick:stopPropagation="_stopPropagation">
        Child div that stops propagation when selected.
    </div>
</div>

@code {
    private bool _stopPropagation = false;

    private void OnSelectParentDiv() => 
        Console.WriteLine($"The parent div was selected. {DateTime.Now}");
    private void OnSelectChildDiv() => 
        Console.WriteLine($"A child div was selected. {DateTime.Now}");
}
```

::: moniker-end

## Chained bind

A common scenario is chaining a data-bound parameter to a page element in the component's output. This scenario is called a *chained bind* because multiple levels of binding occur simultaneously.

A chained bind can't be implemented with `@bind` syntax in the page's element. The event handler and value must be specified separately. A parent component, however, can use `@bind` syntax with the component's parameter.

The following `PasswordField` component (*PasswordField.razor*):

* Sets an `<input>` element's value to a `Password` property.
* Exposes changes of the `Password` property to a parent component with an [EventCallback](#eventcallback).

```razor
Password: 

<input @oninput="OnPasswordChanged" 
       required 
       type="@(showPassword ? "text" : "password")" 
       value="@Password" />

<button class="btn btn-primary" @onclick="ToggleShowPassword">
    Show password
</button>

@code {
    private bool showPassword;

    [Parameter]
    public string Password { get; set; }

    [Parameter]
    public EventCallback<string> PasswordChanged { get; set; }

    private Task OnPasswordChanged(ChangeEventArgs e)
    {
        Password = e.Value.ToString();

        return PasswordChanged.InvokeAsync(Password);
    }

    private void ToggleShowPassword()
    {
        showPassword = !showPassword;
    }
}
```

The `PasswordField` component is used in another component:

```razor
<PasswordField @bind-Password="password" />

@code {
    private string password;
}
```

To perform checks or trap errors on the password in the preceding example:

* Create a backing field for `Password` (`password` in the following example code).
* Perform the checks or trap errors in the `Password` setter.

The following example provides immediate feedback to the user if a space is used in the password's value:

```razor
Password: 

<input @oninput="OnPasswordChanged" 
       required 
       type="@(showPassword ? "text" : "password")" 
       value="@Password" />

<button class="btn btn-primary" @onclick="ToggleShowPassword">
    Show password
</button>

<span class="text-danger">@validationMessage</span>

@code {
    private bool showPassword;
    private string password;
    private string validationMessage;

    [Parameter]
    public string Password
    {
        get { return password ?? string.Empty; }
        set
        {
            if (password != value)
            {
                if (value.Contains(' '))
                {
                    validationMessage = "Spaces not allowed!";
                }
                else
                {
                    password = value;
                    validationMessage = string.Empty;
                }
            }
        }
    }

    [Parameter]
    public EventCallback<string> PasswordChanged { get; set; }

    private Task OnPasswordChanged(ChangeEventArgs e)
    {
        Password = e.Value.ToString();

        return PasswordChanged.InvokeAsync(Password);
    }

    private void ToggleShowPassword()
    {
        showPassword = !showPassword;
    }
}
```

## Capture references to components

Component references provide a way to reference a component instance so that you can issue commands to that instance, such as `Show` or `Reset`. To capture a component reference:

* Add an [`@ref`](xref:mvc/views/razor#ref) attribute to the child component.
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

While capturing component references use a similar syntax to [capturing element references](xref:blazor/javascript-interop#capture-references-to-elements), it isn't a [JavaScript interop](xref:blazor/javascript-interop) feature. Component references aren't passed to JavaScript code&mdash;they're only used in .NET code.

> [!NOTE]
> Do **not** use component references to mutate the state of child components. Instead, use normal declarative parameters to pass data to child components. Use of normal declarative parameters result in child components that rerender at the correct times automatically.

## Invoke component methods externally to update state

Blazor uses a `SynchronizationContext` to enforce a single logical thread of execution. A component's [lifecycle methods](xref:blazor/lifecycle) and any event callbacks that are raised by Blazor are executed on this `SynchronizationContext`. In the event a component must be updated based on an external event, such as a timer or other notifications, use the `InvokeAsync` method, which will dispatch to Blazor's `SynchronizationContext`.

For example, consider a *notifier service* that can notify any listening component of the updated state:

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

Usage of the `NotifierService` to update a component:

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

In the preceding example, `NotifierService` invokes the component's `OnNotify` method outside of Blazor's `SynchronizationContext`. `InvokeAsync` is used to switch to the correct context and queue a render.

## Use \@key to control the preservation of elements and components

When rendering a list of elements or components and the elements or components subsequently change, Blazor's diffing algorithm must decide which of the previous elements or components can be retained and how model objects should map to them. Normally, this process is automatic and can be ignored, but there are cases where you may want to control the process.

Consider the following example:

```csharp
@foreach (var person in People)
{
    <DetailsEditor Details="person.Details" />
}

@code {
    [Parameter]
    public IEnumerable<Person> People { get; set; }
}
```

The contents of the `People` collection may change with inserted, deleted, or re-ordered entries. When the component rerenders, the `<DetailsEditor>` component may change to receive different `Details` parameter values. This may cause more complex rerendering than expected. In some cases, rerendering can lead to visible behavior differences, such as lost element focus.

The mapping process can be controlled with the `@key` directive attribute. `@key` causes the diffing algorithm to guarantee preservation of elements or components based on the key's value:

```csharp
@foreach (var person in People)
{
    <DetailsEditor @key="person" Details="person.Details" />
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

In some scenarios, use of `@key` minimizes the complexity of rerendering and avoids potential issues with stateful parts of the DOM changing, such as focus position.

> [!IMPORTANT]
> Keys are local to each container element or component. Keys aren't compared globally across the document.

### When to use \@key

Typically, it makes sense to use `@key` whenever a list is rendered (for example, in a `@foreach` block) and a suitable value exists to define the `@key`.

You can also use `@key` to prevent Blazor from preserving an element or component subtree when an object changes:

```razor
<div @key="currentPerson">
    ... content that depends on currentPerson ...
</div>
```

If `@currentPerson` changes, the `@key` attribute directive forces Blazor to discard the entire `<div>` and its descendants and rebuild the subtree within the UI with new elements and components. This can be useful if you need to guarantee that no UI state is preserved when `@currentPerson` changes.

### When not to use \@key

There's a performance cost when diffing with `@key`. The performance cost isn't large, but only specify `@key` if controlling the element or component preservation rules benefit the app.

Even if `@key` isn't used, Blazor preserves child element and component instances as much as possible. The only advantage to using `@key` is control over *how* model instances are mapped to the preserved component instances, instead of the diffing algorithm selecting the mapping.

### What values to use for \@key

Generally, it makes sense to supply one of the following kinds of value for `@key`:

* Model object instances (for example, a `Person` instance as in the earlier example). This ensures preservation based on object reference equality.
* Unique identifiers (for example, primary key values of type `int`, `string`, or `Guid`).

Ensure that values used for `@key` don't clash. If clashing values are detected within the same parent element, Blazor throws an exception because it can't deterministically map old elements or components to new elements or components. Only use distinct values, such as object instances or primary key values.

## Routing

Routing in Blazor is achieved by providing a route template to each accessible component in the app.

When a Razor file with an `@page` directive is compiled, the generated class is given a <xref:Microsoft.AspNetCore.Mvc.RouteAttribute> specifying the route template. At runtime, the router looks for component classes with a `RouteAttribute` and renders whichever component has a route template that matches the requested URL.

Multiple route templates can be applied to a component. The following component responds to requests for `/BlazorRoute` and `/DifferentBlazorRoute`.

*Pages/BlazorRoute.razor*:

```razor
@page "/BlazorRoute"
@page "/DifferentBlazorRoute"

<h1>Blazor routing</h1>
```

## Route parameters

Components can receive route parameters from the route template provided in the `@page` directive. The router uses route parameters to populate the corresponding component parameters.

*Pages/RouteParameter.razor*:

```razor
@page "/RouteParameter"
@page "/RouteParameter/{text}"

<h1>Blazor is @Text!</h1>

@code {
    [Parameter]
    public string Text { get; set; }

    protected override void OnInitialized()
    {
        Text = Text ?? "fantastic";
    }
}
```

Optional parameters aren't supported, so two `@page` directives are applied in the example above. The first permits navigation to the component without a parameter. The second `@page` directive takes the `{text}` route parameter and assigns the value to the `Text` property.

*Catch-all* parameter syntax (`*`/`**`), which captures the path across multiple folder boundaries, is **not** supported in Razor components (*.razor*).

::: moniker range=">= aspnetcore-3.1"

## Partial class support

Razor components are generated as partial classes. Razor components are authored using either of the following approaches:

* C# code is defined in an [`@code`](xref:mvc/views/razor#code) block with HTML markup and Razor code in a single file. Blazor templates define their Razor components using this approach.
* C# code is placed in a code-behind file defined as a partial class.

The following example shows the default `Counter` component with an `@code` block in an app generated from a Blazor template. HTML markup, Razor code, and C# code are in the same file:

*Counter.razor*:

```razor
@page "/counter"

<h1>Counter</h1>

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

@code {
    int currentCount = 0;

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
        int currentCount = 0;

        void IncrementCount()
        {
            currentCount++;
        }
    }
}
```

::: moniker-end

::: moniker range="< aspnetcore-3.1"

## Specify a component base class

The `@inherits` directive can be used to specify a base class for a component.

The [sample app](https://github.com/aspnet/AspNetCore.Docs/tree/master/aspnetcore/blazor/common/samples/) shows how a component can inherit a base class, `BlazorRocksBase`, to provide the component's properties and methods.

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

The base class should derive from `ComponentBase`.

::: moniker-end

## Import components

The namespace of a component authored with Razor is based on (in priority order):

* [`@namespace`](xref:mvc/views/razor#namespace) designation in Razor file (*.razor*) markup (`@namespace BlazorSample.MyNamespace`).
* The project's `RootNamespace` in the project file (`<RootNamespace>BlazorSample</RootNamespace>`).
* The project name, taken from the project file's file name (*.csproj*), and the path from the project root to the component. For example, the framework resolves *{PROJECT ROOT}/Pages/Index.razor* (*BlazorSample.csproj*) to the namespace `BlazorSample.Pages`. Components follow C# name binding rules. For the `Index` component in this example, the components in scope are all of the components:
  * In the same folder, *Pages*.
  * The components in the project's root that don't explicitly specify a different namespace.

Components defined in a different namespace are brought into scope using Razor's [`@using`](xref:mvc/views/razor#using) directive.

If another component, `NavMenu.razor`, exists in the *BlazorSample/Shared/* folder, the component can be used in `Index.razor` with the following `@using` statement:

```razor
@using BlazorSample.Shared

This is the Index page.

<NavMenu></NavMenu>
```

Components can also be referenced using their fully qualified names, which doesn't require the [`@using`](xref:mvc/views/razor#using) directive:

```razor
This is the Index page.

<BlazorSample.Shared.NavMenu></BlazorSample.Shared.NavMenu>
```

> [!NOTE]
> The `global::` qualification isn't supported.
>
> Importing components with aliased `using` statements (for example, `@using Foo = Bar`) isn't supported.
>
> Partially qualified names aren't supported. For example, adding `@using BlazorSample` and referencing `NavMenu.razor` with `<Shared.NavMenu></Shared.NavMenu>` isn't supported.

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

## Templated components

Templated components are components that accept one or more UI templates as parameters, which can then be used as part of the component's rendering logic. Templated components allow you to author higher-level components that are more reusable than regular components. A couple of examples include:

* A table component that allows a user to specify templates for the table's header, rows, and footer.
* A list component that allows a user to specify a template for rendering items in a list.

### Template parameters

A templated component is defined by specifying one or more component parameters of type `RenderFragment` or `RenderFragment<T>`. A render fragment represents a segment of UI to render. `RenderFragment<T>` takes a type parameter that can be specified when the render fragment is invoked.

`TableTemplate` component:

[!code-razor[](common/samples/3.x/BlazorWebAssemblySample/Components/TableTemplate.razor)]

When using a templated component, the template parameters can be specified using child elements that match the names of the parameters (`TableHeader` and `RowTemplate` in the following example):

```razor
<TableTemplate Items="pets">
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

```razor
<TableTemplate Items="pets">
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

```razor
<TableTemplate Items="pets" Context="pet">
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

Templated components are often generically typed. For example, a generic `ListViewTemplate` component can be used to render `IEnumerable<T>` values. To define a generic component, use the [`@typeparam`](xref:mvc/views/razor#typeparam) directive to specify type parameters:

[!code-razor[](common/samples/3.x/BlazorWebAssemblySample/Components/ListViewTemplate.razor)]

When using generic-typed components, the type parameter is inferred if possible:

```razor
<ListViewTemplate Items="pets">
    <ItemTemplate Context="pet">
        <li>@pet.Name</li>
    </ItemTemplate>
</ListViewTemplate>
```

Otherwise, the type parameter must be explicitly specified using an attribute that matches the name of the type parameter. In the following example, `TItem="Pet"` specifies the type:

```razor
<ListViewTemplate Items="pets" TItem="Pet">
    <ItemTemplate Context="pet">
        <li>@pet.Name</li>
    </ItemTemplate>
</ListViewTemplate>
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

An ancestor component can provide a cascading value using the Cascading Value component. The `CascadingValue` component wraps a subtree of the component hierarchy and supplies a single value to all components within that subtree.

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

To make use of cascading values, components declare cascading parameters using the `[CascadingParameter]` attribute. Cascading values are bound to cascading parameters by type.

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

To cascade multiple values of the same type within the same subtree, provide a unique `Name` string to each `CascadingValue` component and its corresponding `CascadingParameter`. In the following example, two `CascadingValue` components cascade different instances of `MyCascadingType` by name:

```razor
<CascadingValue Value=@ParentCascadeParameter1 Name="CascadeParam1">
    <CascadingValue Value=@ParentCascadeParameter2 Name="CascadeParam2">
        ...
    </CascadingValue>
</CascadingValue>

@code {
    private MyCascadingType ParentCascadeParameter1;

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

The following example illustrates how to specify `RenderFragment` and `RenderFragment<T>` values and render templates directly in a component. Render fragments can also be passed as arguments to [templated components](#templated-components).

```razor
@timeTemplate

@petTemplate(new Pet { Name = "Rex" })

@code {
    private RenderFragment timeTemplate = @<p>The time is @DateTime.Now.</p>;
    private RenderFragment<Pet> petTemplate = 
        (pet) => @<p>Your pet's name is @pet.Name.</p>;

    private class Pet
    {
        public string Name { get; set; }
    }
}
```

Rendered output of the preceding code:

```html
<p>The time is 10/04/2018 01:26:52.</p>

<p>Your pet's name is Rex.</p>
```

## Manual RenderTreeBuilder logic

`Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder` provides methods for manipulating components and elements, including building components manually in C# code.

> [!NOTE]
> Use of `RenderTreeBuilder` to create components is an advanced scenario. A malformed component (for example, an unclosed markup tag) can result in undefined behavior.

Consider the following `PetDetails` component, which can be manually built into another component:

```razor
<h2>Pet Details Component</h2>

<p>@PetDetailsQuote</p>

@code
{
    [Parameter]
    public string PetDetailsQuote { get; set; }
}
```

In the following example, the loop in the `CreateComponent` method generates three `PetDetails` components. When calling `RenderTreeBuilder` methods to create the components (`OpenComponent` and `AddAttribute`), sequence numbers are source code line numbers. The Blazor difference algorithm relies on the sequence numbers corresponding to distinct lines of code, not distinct call invocations. When creating a component with `RenderTreeBuilder` methods, hardcode the arguments for sequence numbers. **Using a calculation or counter to generate the sequence number can lead to poor performance.** For more information, see the [Sequence numbers relate to code line numbers and not execution order](#sequence-numbers-relate-to-code-line-numbers-and-not-execution-order) section.

`BuiltContent` component:

```razor
@page "/BuiltContent"

<h1>Build a component</h1>

@CustomRender

<button type="button" @onclick="RenderComponent">
    Create three Pet Details components
</button>

@code {
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

> [!WARNING]
> The types in `Microsoft.AspNetCore.Components.RenderTree` allow processing of the *results* of rendering operations. These are internal details of the Blazor framework implementation. These types should be considered *unstable* and subject to change in future releases.

### Sequence numbers relate to code line numbers and not execution order

Blazor `.razor` files are always compiled. This is potentially a great advantage for `.razor` because the compile step can be used to inject information that improve app performance at runtime.

A key example of these improvements involve *sequence numbers*. Sequence numbers indicate to the runtime which outputs came from which distinct and ordered lines of code. The runtime uses this information to generate efficient tree diffs in linear time, which is far faster than is normally possible for a general tree diff algorithm.

Consider the following Razor component (*.razor*) file:

```razor
@if (someFlag)
{
    <text>First</text>
}

Second
```

The preceding code compiles to something like the following:

```csharp
if (someFlag)
{
    builder.AddContent(0, "First");
}

builder.AddContent(1, "Second");
```

When the code executes for the first time, if `someFlag` is `true`, the builder receives:

| Sequence | Type      | Data   |
| :------: | --------- | :----: |
| 0        | Text node | First  |
| 1        | Text node | Second |

Imagine that `someFlag` becomes `false`, and the markup is rendered again. This time, the builder receives:

| Sequence | Type       | Data   |
| :------: | ---------- | :----: |
| 1        | Text node  | Second |

When the runtime performs a diff, it sees that the item at sequence `0` was removed, so it generates the following trivial *edit script*:

* Remove the first text node.

#### What goes wrong if you generate sequence numbers programmatically

Imagine instead that you wrote the following render tree builder logic:

```csharp
var seq = 0;

if (someFlag)
{
    builder.AddContent(seq++, "First");
}

builder.AddContent(seq++, "Second");
```

Now, the first output is:

| Sequence | Type      | Data   |
| :------: | --------- | :----: |
| 0        | Text node | First  |
| 1        | Text node | Second |

This outcome is identical to the prior case, so no negative issues exist. `someFlag` is `false` on the second rendering, and the output is:

| Sequence | Type      | Data   |
| :------: | --------- | ------ |
| 0        | Text node | Second |

This time, the diff algorithm sees that *two* changes have occurred, and the algorithm generates the following edit script:

* Change the value of the first text node to `Second`.
* Remove the second text node.

Generating the sequence numbers has lost all the useful information about where the `if/else` branches and loops were present in the original code. This results in a diff **twice as long** as before.

This is a trivial example. In more realistic cases with complex and deeply nested structures, and especially with loops, the performance cost is more severe. Instead of immediately identifying which loop blocks or branches have been inserted or removed, the diff algorithm has to recurse deeply into the render trees and usually build far longer edit scripts because it is misinformed about how the old and new structures relate to each other.

#### Guidance and conclusions

* App performance suffers if sequence numbers are generated dynamically.
* The framework can't create its own sequence numbers automatically at runtime because the necessary information doesn't exist unless it's captured at compile time.
* Don't write long blocks of manually-implemented `RenderTreeBuilder` logic. Prefer `.razor` files and allow the compiler to deal with the sequence numbers. If you're unable to avoid manual `RenderTreeBuilder` logic, split long blocks of code into smaller pieces wrapped in `OpenRegion`/`CloseRegion` calls. Each region has its own separate space of sequence numbers, so you can restart from zero (or any other arbitrary number) inside each region.
* If sequence numbers are hardcoded, the diff algorithm only requires that sequence numbers increase in value. The initial value and gaps are irrelevant. One legitimate option is to use the code line number as the sequence number, or start from zero and increase by ones or hundreds (or any preferred interval). 
* Blazor uses sequence numbers, while other tree-diffing UI frameworks don't use them. Diffing is far faster when sequence numbers are used, and Blazor has the advantage of a compile step that deals with sequence numbers automatically for developers authoring *.razor* files.

## Localization

Blazor Server apps are localized using [Localization Middleware](xref:fundamentals/localization#localization-middleware). The middleware selects the appropriate culture for users requesting resources from the app.

The culture can be set using one of the following approaches:

* [Cookies](#cookies)
* [Provide UI to choose the culture](#provide-ui-to-choose-the-culture)

For more information and examples, see <xref:fundamentals/localization>.

### Configure the linker for internationalization (Blazor WebAssembly)

By default, Blazor's linker configuration for Blazor WebAssembly apps strips out internationalization information except for locales explicitly requested. For more information and guidance on controlling the linker's behavior, see <xref:host-and-deploy/blazor/configure-linker#configure-the-linker-for-internationalization>.

### Cookies

A localization culture cookie can persist the user's culture. The cookie is created by the `OnGet` method of the app's host page (*Pages/Host.cshtml.cs*). The Localization Middleware reads the cookie on subsequent requests to set the user's culture. 

Use of a cookie ensures that the WebSocket connection can correctly propagate the culture. If localization schemes are based on the URL path or query string, the scheme might not be able to work with WebSockets, thus fail to persist the culture. Therefore, use of a localization culture cookie is the recommended approach.

Any technique can be used to assign a culture if the culture is persisted in a localization cookie. If the app already has an established localization scheme for server-side ASP.NET Core, continue to use the app's existing localization infrastructure and set the localization culture cookie within the app's scheme.

The following example shows how to set the current culture in a cookie that can be read by the Localization Middleware. Create a *Pages/Host.cshtml.cs* file with the following contents in the Blazor Server app:

```csharp
public class HostModel : PageModel
{
    public void OnGet()
    {
        HttpContext.Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(
                new RequestCulture(
                    CultureInfo.CurrentCulture,
                    CultureInfo.CurrentUICulture)));
    }
}
```

Localization is handled in the app:

1. The browser sends an initial HTTP request to the app.
1. The culture is assigned by the Localization Middleware.
1. The `OnGet` method in *_Host.cshtml.cs* persists the culture in a cookie as part of the response.
1. The browser opens a WebSocket connection to create an interactive Blazor Server session.
1. The Localization Middleware reads the cookie and assigns the culture.
1. The Blazor Server session begins with the correct culture.

### Provide UI to choose the culture

To provide UI to allow a user to select a culture, a *redirect-based approach* is recommended. The process is similar to what happens in a web app when a user attempts to access a secure resource&mdash;the user is redirected to a sign-in page and then redirected back to the original resource. 

The app persists the user's selected culture via a redirect to a controller. The controller sets the user's selected culture into a cookie and redirects the user back to the original URI.

Establish an HTTP endpoint on the server to set the user's selected culture in a cookie and perform the redirect back to the original URI:

```csharp
[Route("[controller]/[action]")]
public class CultureController : Controller
{
    public IActionResult SetCulture(string culture, string redirectUri)
    {
        if (culture != null)
        {
            HttpContext.Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(
                    new RequestCulture(culture)));
        }

        return LocalRedirect(redirectUri);
    }
}
```

> [!WARNING]
> Use the `LocalRedirect` action result to prevent open redirect attacks. For more information, see <xref:security/preventing-open-redirects>.

The following component shows an example of how to perform the initial redirection when the user selects a culture:

```razor
@inject NavigationManager NavigationManager

<h3>Select your language</h3>

<select @onchange="OnSelected">
    <option>Select...</option>
    <option value="en-US">English</option>
    <option value="fr-FR">Français</option>
</select>

@code {
    private double textNumber;

    private void OnSelected(ChangeEventArgs e)
    {
        var culture = (string)e.Value;
        var uri = new Uri(NavigationManager.Uri())
            .GetComponents(UriComponents.PathAndQuery, UriFormat.Unescaped);
        var query = $"?culture={Uri.EscapeDataString(culture)}&" +
            $"redirectUri={Uri.EscapeDataString(uri)}";

        NavigationManager.NavigateTo("/Culture/SetCulture" + query, forceLoad: true);
    }
}
```

### Use .NET localization scenarios in Blazor apps

Inside Blazor apps, the following .NET localization and globalization scenarios are available:

* .NET's resources system
* Culture-specific number and date formatting

Blazor's `@bind` functionality performs globalization based on the user's current culture. For more information, see the [Data binding](#data-binding) section.

A limited set of ASP.NET Core's localization scenarios are currently supported:

* `IStringLocalizer<>` *is supported* in Blazor apps.
* `IHtmlLocalizer<>`, `IViewLocalizer<>`, and Data Annotations localization are ASP.NET Core MVC scenarios and **not supported** in Blazor apps.

For more information, see <xref:fundamentals/localization>.

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

However, inline SVG markup isn't supported in all scenarios. If you place an `<svg>` tag directly into a component file (*.razor*), basic image rendering is supported but many advanced scenarios aren't yet supported. For example, `<use>` tags aren't currently respected, and `@bind` can't be used with some SVG tags. We expect to address these limitations in a future release.

## Additional resources

* <xref:security/blazor/server> &ndash; Includes guidance on building Blazor Server apps that must contend with resource exhaustion.
