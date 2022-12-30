---
title: ASP.NET Core Blazor data binding
author: guardrex
description: Learn about data binding features for Razor components and Document Object Model (DOM) elements in Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 11/08/2022
uid: blazor/components/data-binding
---
# ASP.NET Core Blazor data binding

This article explains data binding features for Razor components and Document Object Model (DOM) elements in Blazor apps.

:::moniker range=">= aspnetcore-7.0"

Razor components provide data binding features with the [`@bind`](xref:mvc/views/razor#bind) Razor directive attribute with a field, property, or Razor expression value.

The following example binds:

* An `<input>` element value to the C# `inputValue` field.
* A second `<input>` element value to the C# `InputValue` property.

When an `<input>` element loses focus, its bound field or property is updated.

`Pages/Bind.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/data-binding/Bind.razor" highlight="4,8":::

The text box is updated in the UI only when the component is rendered, not in response to changing the field's or property's value. Since components render themselves after event handler code executes, field and property updates are usually reflected in the UI immediately after an event handler is triggered.

As a demonstration of how data binding composes in HTML, the following example binds the `InputValue` property to the second `<input>` element's `value` and `onchange` attributes ([`change`](https://developer.mozilla.org/docs/Web/API/HTMLElement/change_event)). *The second `<input>` element in the following example is a concept demonstration and isn't meant to suggest how you should bind data in Razor components.*

`Pages/BindTheory.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/data-binding/BindTheory.razor" highlight="12-14":::

When the `BindTheory` component is rendered, the `value` of the HTML demonstration `<input>` element comes from the `InputValue` property. When the user enters a value in the text box and changes element focus, the `onchange` event is fired and the `InputValue` property is set to the changed value. In reality, code execution is more complex because [`@bind`](xref:mvc/views/razor#bind) handles cases where type conversions are performed. In general, [`@bind`](xref:mvc/views/razor#bind) associates the current value of an expression with a `value` attribute and handles changes using the registered handler.

Bind a property or field on other [Document Object Model (DOM)](https://developer.mozilla.org/docs/Web/API/Document_Object_Model/Introduction) events by including an `@bind:event="{EVENT}"` attribute with a DOM event for the `{EVENT}` placeholder. The following example binds the `InputValue` property to the `<input>` element's value when the element's `oninput` event ([`input`](https://developer.mozilla.org/docs/Web/API/HTMLElement/input_event)) is triggered. Unlike the `onchange` event ([`change`](https://developer.mozilla.org/docs/Web/API/HTMLElement/change_event)), which fires when the element loses focus, `oninput` ([`input`](https://developer.mozilla.org/docs/Web/API/HTMLElement/input_event)) fires when the value of the text box changes.

`Page/BindEvent.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/data-binding/BindEvent.razor" highlight="4":::

To execute asynchronous logic after binding, use `@bind:after="{EVENT}"` with a DOM event for the `{EVENT}` placeholder. An assigned C# method isn't executed until the bound value is assigned synchronously.

> [!IMPORTANT]
> The `@bind:after` feature is receiving further updates at this time. To take advantage of the latest updates, confirm that you've installed the [latest SDK](https://dotnet.microsoft.com/download).
>
> Using an event callback parameter (`[Parameter] public EventCallback<string> ValueChanged { get; set; }`) isn't supported. Instead, pass an <xref:System.Action>-returning or <xref:System.Threading.Tasks.Task>-returning method to `@bind:after`.
>
> For more information, see the following resources:
>
> * [Blazor `@bind:after` not working on .NET 7 RTM release (dotnet/aspnetcore #44957)](https://github.com/dotnet/aspnetcore/issues/44957)
> * [`BindGetSetAfter701` sample app (javiercn/BindGetSetAfter701 GitHub repository)](https://github.com/javiercn/BindGetSetAfter701)

In the following example:

* The `<input>` element's `value` is bound to the value of `searchText` synchronously.
* After each keystroke (`onchange` event) in the field, the `PerformSearch` method executes asynchronously.
* `PerformSearch` calls a service with an asynchronous method (`FetchAsync`) to return search results.

```razor
@inject ISearchService SearchService

<input @bind="searchText" @bind:after="PerformSearch" />

@code {
    private string? searchText;
    private string[]? searchResult;

    private async Task PerformSearch()
    {
        searchResult = await SearchService.FetchAsync(searchText);
    }
}
```

Additional examples

`Pages/BindAfter.razor`:

```razor
@page "/bind-after"
@using Microsoft.AspNetCore.Components.Forms

<h1>Bind After Examples</h1>

<h2>Elements</h2>

<input type="text" @bind="text" @bind:after="() => { }" />

<input type="text" @bind="text" @bind:after="After" />

<input type="text" @bind="text" @bind:after="AfterAsync" />

<h2>Components</h2>

<InputText @bind-Value="text" @bind-Value:after="() => { }" />

<InputText @bind-Value="text" @bind-Value:after="After" />

<InputText @bind-Value="text" @bind-Value:after="AfterAsync" />

@code {
    private string text = "";

    private void After() {}
    private Task AfterAsync() { return Task.CompletedTask; }
}
```

For more information on the `InputText` component, see <xref:blazor/forms-and-input-components>.

Components support two-way data binding by defining a pair of parameters:

* `@bind:get`: Specifies the value to bind.
* `@bind:set`: Specifies a callback for when the value changes.

> [!IMPORTANT]
> The `@bind:get` and `@bind:set` features are receiving further updates at this time. To take advantage of the latest updates, confirm that you've installed the [latest SDK](/download/dotnet/7.0).
>
> Using an event callback parameter (`[Parameter] public EventCallback<string> ValueChanged { get; set; }`) isn't supported. Instead, pass an <xref:System.Action>-returning or <xref:System.Threading.Tasks.Task>-returning method to `@bind:set`.
>
> For more information, see the following resources:
>
> * [Blazor `@bind:after` not working on .NET 7 RTM release (dotnet/aspnetcore #44957)](https://github.com/dotnet/aspnetcore/issues/44957)
> * [`BindGetSetAfter701` sample app (javiercn/BindGetSetAfter701 GitHub repository)](https://github.com/javiercn/BindGetSetAfter701)

The `@bind:get` and `@bind:set` modifiers are always used together.

Examples

`Pages/BindGetSet.razor`:

```razor
@page "/bind-get-set"
@using Microsoft.AspNetCore.Components.Forms

<h1>Bind Get Set Examples</h1>

<h2>Elements</h2>

<input type="text" @bind:get="text" @bind:set="(value) => { }" />

<input type="text" @bind:get="text" @bind:set="Set" />

<input type="text" @bind:get="text" @bind:set="SetAsync" />

<h2>Components</h2>

<InputText @bind-Value:get="text" @bind-Value:set="(value) => { }" />

<InputText @bind-Value:get="text" @bind-Value:set="Set" />

<InputText @bind-Value:get="text" @bind-Value:set="SetAsync" />

@code {
    private string text = "";

    private void Set() {}
    private Task SetAsync(string value) { return Task.CompletedTask; }
}
```

For more information on the `InputText` component, see <xref:blazor/forms-and-input-components>.

<!-- For another example use of `@bind:get` and `@bind:set`, see the [Bind across more than two components](#bind-across-more-than-two-components) section later in this article. -->

Razor attribute binding is case-sensitive:

* `@bind`, `@bind:event`, and `@bind:after` are valid.
* `@Bind`/`@bind:Event`/`@bind:aftEr` (capital letters) or `@BIND`/`@BIND:EVENT`/`@BIND:AFTER` (all capital letters) **are invalid**.

## Use `@bind:get`/`@bind:set` modifiers and avoid event handlers for two-way data binding

Two-way data binding isn't possible to implement with an event handler.

<span aria-hidden="true">❌</span><span class="visually-hidden">Unsupported:</span> Consider the following dysfunctional approach using an event handler:

```razor
<p>
    <input value="@inputValue" @oninput="OnInput" />
</p>

<p>
    <code>inputValue</code>: @inputValue
</p>

@code {
    private string? inputValue;

    protected void OnInput(ChangeEventArgs args)
    {
        var newValue = args.Value?.ToString() ?? string.Empty;

        inputValue = newValue.Length > 4 ? "Long!" : inputValue = newValue;
    }
}
```

The `OnInput1` event handler in the preceding code updates the value of `inputValue` to `Too long!` after a fourth character is provided. However, the event handler doesn't prevent additional characters from being added to the `<input>` element that aren't reflected in the underlying value of `inputValue`, which remains `Too long!`. The preceding example is only capable of one-way data binding.

The reason for this behavior is that Blazor isn't aware that your code intends to modify the value of `inputValue` in the event handler. Blazor doesn't try to force Document Object Model (DOM) element values and the .NET variable values to match unless they're bound with `@bind` syntax. In earlier versions of Blazor, this problem was addressed by binding to a property and controlling the value with the property's setter. In ASP.NET Core 7.0 or later, new `@bind:get`/`@bind:set` modifier syntax is used to implement two-way data binding, as the next example demonstrates.

<span aria-hidden="true">✔️</span><span class="visually-hidden">Supported:</span> Consider the following correct approach using `@bind:get`/`@bind:set`:

```razor
<p>
    <input @bind:event="oninput" @bind:get="inputValue" @bind:set="OnInput" />
</p>

<p>
    <code>inputValue</code>: @inputValue
</p>

@code {
    private string? inputValue;

    protected void OnInput(string value)
    {
        var newValue = value ?? string.Empty;

        inputValue = newValue.Length > 4 ? "Long!" : inputValue = newValue;
    }
}
```

Using `@bind:get`/`@bind:set` attributes in the preceding example both controls the underlying value of `inputValue` via `@bind:set` and always reflects the current value of `inputValue` via `@bind:get` in the `<input>` element. The preceding example demonstrates the correct approach for implementing two-way data binding. The approach also has the benefit of binding to a field or avoiding logic in a property setter when a property is bound.

## Multiple option selection with `<select>` elements

Binding supports [`multiple`](https://developer.mozilla.org/docs/Web/HTML/Attributes/multiple) option selection with `<select>` elements. The [`@onchange`](xref:mvc/views/razor#onevent) event provides an array of the selected elements via [event arguments (`ChangeEventArgs`)](xref:blazor/components/event-handling#event-arguments). The value must be bound to an array type.

`Pages/BindMultipleInput.razor`:

```razor
@page "/bind-multiple-input"

<h1>Bind Multiple <code>input</code>Example</h1>

<p>
    <label>
        Select one or more cars: 
        <select @onchange="SelectedCarsChanged" multiple>
            <option value="audi">Audi</option>
            <option value="jeep">Jeep</option>
            <option value="opel">Opel</option>
            <option value="saab">Saab</option>
            <option value="volvo">Volvo</option>
        </select>
    </label>
</p>

<p>
    Selected Cars: @string.Join(", ", SelectedCars)
</p>

<p>
    <label>
        Select one or more cities: 
        <select @bind="SelectedCities" multiple>
            <option value="bal">Baltimore</option>
            <option value="la">Los Angeles</option>
            <option value="pdx">Portland</option>
            <option value="sf">San Francisco</option>
            <option value="sea">Seattle</option>
        </select>
    </label>
</p>

<span>
    Selected Cities: @string.Join(", ", SelectedCities)
</span>

@code {
    public string[] SelectedCars { get; set; } = new string[] { };
    public string[] SelectedCities { get; set; } = new[] { "bal", "sea" };

    private void SelectedCarsChanged(ChangeEventArgs e)
    {
        if (e.Value is not null)
        {
            SelectedCars = (string[])e.Value;
        }
    }
}
```

For information on how empty strings and `null` values are handled in data binding, see the [Binding `<select>` element options to C# object `null` values](#binding-select-element-options-to-c-object-null-values) section.

## Binding `<select>` element options to C# object `null` values

There's no sensible way to represent a `<select>` element option value as a C# object `null` value, because:

* HTML attributes can't have `null` values. The closest equivalent to `null` in HTML is absence of the HTML `value` attribute from the `<option>` element.
* When selecting an `<option>` with no `value` attribute, the browser treats the value as the *text content* of that `<option>`'s element.

The Blazor framework doesn't attempt to suppress the default behavior because it would involve:

* Creating a chain of special-case workarounds in the framework.
* Breaking changes to current framework behavior.

The most plausible `null` equivalent in HTML is an *empty string* `value`. The Blazor framework handles `null` to empty string conversions for two-way binding to a `<select>`'s value.

## Unparsable values

When a user provides an unparsable value to a databound element, the unparsable value is automatically reverted to its previous value when the bind event is triggered.

Consider the following component, where an `<input>` element is bound to an `int` type with an initial value of `123`.

`Pages/UnparsableValues.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/data-binding/UnparsableValues.razor" highlight="4,12":::

By default, binding applies to the element's `onchange` event. If the user updates the value of the text box's entry to `123.45` and changes the focus, the element's value is reverted to `123` when `onchange` fires. When the value `123.45` is rejected in favor of the original value of `123`, the user understands that their value wasn't accepted.

For the `oninput` event (`@bind:event="oninput"`), a value reversion occurs after any keystroke that introduces an unparsable value. When targeting the `oninput` event with an `int`-bound type, a user is prevented from typing a dot (`.`) character. A dot (`.`) character is immediately removed, so the user receives immediate feedback that only whole numbers are permitted. There are scenarios where reverting the value on the `oninput` event isn't ideal, such as when the user should be allowed to clear an unparsable `<input>` value. Alternatives include:

* Don't use the `oninput` event. Use the default `onchange` event, where an invalid value isn't reverted until the element loses focus.
* Bind to a nullable type, such as `int?` or `string` and provide [custom `get` and `set` accessor logic](#custom-binding-formats) to handle invalid entries.
* Use a [form validation component](xref:blazor/forms-and-input-components), such as <xref:Microsoft.AspNetCore.Components.Forms.InputNumber%601> or <xref:Microsoft.AspNetCore.Components.Forms.InputDate%601>. Form validation components provide built-in support to manage invalid inputs. Form validation components:
  * Permit the user to provide invalid input and receive validation errors on the associated <xref:Microsoft.AspNetCore.Components.Forms.EditContext>.
  * Display validation errors in the UI without interfering with the user entering additional webform data.

## Format strings

Data binding works with a single <xref:System.DateTime> format string using `@bind:format="{FORMAT STRING}"`, where the `{FORMAT STRING}` placeholder is the format string. Other format expressions, such as currency or number formats, aren't available at this time but might be added in a future release.

`Pages/DateBinding.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/data-binding/DateBinding.razor" highlight="6":::

In the preceding code, the `<input>` element's field type (`type` attribute) defaults to `text`.

Nullable <xref:System.DateTime?displayProperty=fullName> and <xref:System.DateTimeOffset?displayProperty=fullName> are supported:

```csharp
private DateTime? date;
private DateTimeOffset? dateOffset;
```

Specifying a format for the `date` field type isn't recommended because Blazor has built-in support to format dates. In spite of the recommendation, only use the `yyyy-MM-dd` date format for binding to function correctly if a format is supplied with the `date` field type:

```razor
<input type="date" @bind="startDate" @bind:format="yyyy-MM-dd">
```

## Custom binding formats

[C# `get` and `set` accessors](/dotnet/csharp/programming-guide/classes-and-structs/using-properties) can be used to create custom binding format behavior, as the following `DecimalBinding` component demonstrates. The component binds a positive or negative decimal with up to three decimal places to an `<input>` element by way of a `string` property (`DecimalValue`).

`Pages/DecimalBinding.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/data-binding/DecimalBinding.razor" highlight="7,21-31":::

## Binding with component parameters

A common scenario is binding a property of a child component to a property in its parent component. This scenario is called a *chained bind* because multiple levels of binding occur simultaneously.

[Component parameters](xref:blazor/components/index#component-parameters) permit binding properties of a parent component with `@bind-{PROPERTY}` syntax, where the `{PROPERTY}` placeholder is the property to bind.

You can't implement chained binds with [`@bind`](xref:mvc/views/razor#bind) syntax in the child component. An event handler and value must be specified separately to support updating the property in the parent from the child component.

The parent component still leverages the [`@bind`](xref:mvc/views/razor#bind) syntax to set up the databinding with the child component.

The following `ChildBind` component has a `Year` component parameter and an <xref:Microsoft.AspNetCore.Components.EventCallback%601>. By convention, the <xref:Microsoft.AspNetCore.Components.EventCallback%601> for the parameter must be named as the component parameter name with a "`Changed`" suffix. The naming syntax is `{PARAMETER NAME}Changed`, where the `{PARAMETER NAME}` placeholder is the parameter name. In the following example, the <xref:Microsoft.AspNetCore.Components.EventCallback%601> is named `YearChanged`.

<xref:Microsoft.AspNetCore.Components.EventCallback.InvokeAsync%2A?displayProperty=nameWithType> invokes the delegate associated with the binding with the provided argument and dispatches an event notification for the changed property.

`Shared/ChildBind.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/data-binding/ChildBind.razor" highlight="14-15,17-18,22":::

For more information on events and <xref:Microsoft.AspNetCore.Components.EventCallback%601>, see the *EventCallback* section of the <xref:blazor/components/event-handling#eventcallback> article.

In the following `Parent1` component, the `year` field is bound to the `Year` parameter of the child component. The `Year` parameter is bindable because it has a companion `YearChanged` event that matches the type of the `Year` parameter.

`Pages/Parent1.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/data-binding/Parent1.razor" highlight="9":::

Component parameter binding can also trigger `@bind:after` events. In the following example, the `YearUpdated` method executes asynchronously after binding the `Year` component parameter.

```razor
<ChildBind @bind-Year="year" @bind-Year:after="YearUpdated" />

@code {
    ...

    private async Task YearUpdated()
    {
        ... = await ...;
    }
}
```

By convention, a property can be bound to a corresponding event handler by including an `@bind-{PROPERTY}:event` attribute assigned to the handler, where the `{PROPERTY}` placeholder is the property. `<ChildBind @bind-Year="year" />` is equivalent to writing:

```razor
<ChildBind @bind-Year="year" @bind-Year:event="YearChanged" />
```

In a more sophisticated and real-world example, the following `PasswordEntry` component:

* Sets an `<input>` element's value to a `password` field.
* Exposes changes of a `Password` property to a parent component with an [`EventCallback`](xref:blazor/components/event-handling#eventcallback) that passes in the current value of the child's `password` field as its argument.
* Uses the `onclick` event to trigger the `ToggleShowPassword` method. For more information, see <xref:blazor/components/event-handling>.

`Shared/PasswordEntry.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/data-binding/PasswordEntry.razor" highlight="7-10,13,23-24,26-27,36-39":::

The `PasswordEntry` component is used in another component, such as the following `PasswordBinding` component example.

`Pages/PasswordBinding.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/data-binding/PasswordBinding.razor" highlight="5":::

When the `PasswordBinding` component is initially rendered, the `password` value of `Not set` is displayed in the UI. After initial rendering, the value of `password` reflects changes made to the `Password` component parameter value in the `PasswordEntry` component.

> [!NOTE]
> The preceding example binds the password one-way from the child `PasswordEntry` component to the parent `PasswordBinding` component. Two-way binding isn't a requirement in this scenario if the goal is for the app to have a shared password entry component for reuse around the app that merely passes the password to the parent. For an approach that permits two-way binding without [writing directly to the child component's parameter](xref:blazor/components/index#overwritten-parameters), see the `NestedChild` component example in the [Bind across more than two components](#bind-across-more-than-two-components) section of this article.

Perform checks or trap errors in the handler. The following revised `PasswordEntry` component provides immediate feedback to the user if a space is used in the password's value.

`Shared/PasswordEntry.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/data-binding/PasswordEntry2.razor" highlight="35-46":::

In the following example, the `PasswordUpdated` method executes asynchronously after binding the `Password` component parameter:

```razor
<PasswordEntry @bind-Password="password" @bind-Password:after="PasswordUpdated" />
```

## Bind across more than two components

<!-- HOLD: See https://github.com/dotnet/AspNetCore.Docs/issues/27848

> [!IMPORTANT]
> The `@bind:get` and `@bind:set` features demonstrated in this section are receiving further updates at this time. To take advantage of the latest updates, confirm that you've installed the [latest SDK](/download/dotnet/7.0).
>
> For more information, see the following resources:
>
> * [Blazor `@bind:after` not working on .NET 7 RTM release (dotnet/aspnetcore #44957)](https://github.com/dotnet/aspnetcore/issues/44957)
> * [`BindGetSetAfter701` sample app (javiercn/BindGetSetAfter701 GitHub repository)](https://github.com/javiercn/BindGetSetAfter701)
>
> To see a working version of the guidance in this section that doesn't rely on `@bind:get`/`@bind:set` modifiers, see the 6.0 version of this article.

You can bind parameters through any number of nested components, but you must respect the one-way flow of data:

* Change notifications *flow up the hierarchy*.
* New parameter values *flow down the hierarchy*.

A common and recommended approach is to only store the underlying data in the parent component to avoid any confusion about what state must be updated, as shown in the following example.

`Pages/Parent2.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/data-binding/Parent2.razor":::

In the following `NestedChild` component, the `NestedGrandchild` component:

* Assigns the value of `ChildMessage` to `GrandchildMessage` with `@bind:get` syntax.
* Updates `GrandchildMessage` when `ChildMessageChanged` executes with `@bind:set` syntax.

`Shared/NestedChild.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/data-binding/NestedChild.razor":::

`Shared/NestedGrandchild.razor`:

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/data-binding/NestedGrandchild.razor":::

For an alternative approach suited to sharing data in memory and across components that aren't necessarily nested, see <xref:blazor/state-management>.

-->

You can bind parameters through any number of nested components, but you must respect the one-way flow of data:

* Change notifications *flow up the hierarchy*.
* New parameter values *flow down the hierarchy*.

A common and recommended approach is to only store the underlying data in the parent component to avoid any confusion about what state must be updated, as shown in the following example.

`Pages/Parent2.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/data-binding/Parent2.razor":::

`Shared/NestedChild.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/data-binding/NestedChild.razor":::

> [!WARNING]
> Generally, avoid creating components that write directly to their own component parameters. The preceding `NestedChild` component makes use of a `BoundValue` property instead of writing directly to its `ChildMessage` parameter. For more information, see <xref:blazor/components/index#overwritten-parameters>.

`Shared/NestedGrandchild.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/data-binding/NestedGrandchild.razor":::

For an alternative approach suited to sharing data in memory and across components that aren't necessarily nested, see <xref:blazor/state-management>.

## Additional resources

* [Parameter change detection and additional guidance on Razor component rendering](xref:blazor/components/rendering)
* <xref:blazor/forms-and-input-components>
* [Binding to radio buttons in a form](xref:blazor/forms-and-input-components#radio-buttons)
* [Binding `InputSelect` options to C# object `null` values](xref:blazor/forms-and-input-components#binding-inputselect-options-to-c-object-null-values)
* [ASP.NET Core Blazor event handling: `EventCallback` section](xref:blazor/components/event-handling#eventcallback)
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

Razor components provide data binding features with the [`@bind`](xref:mvc/views/razor#bind) Razor directive attribute with a field, property, or Razor expression value.

The following example binds:

* An `<input>` element value to the C# `inputValue` field.
* A second `<input>` element value to the C# `InputValue` property.

When an `<input>` element loses focus, its bound field or property is updated.

`Pages/Bind.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/data-binding/Bind.razor" highlight="4,8":::

The text box is updated in the UI only when the component is rendered, not in response to changing the field's or property's value. Since components render themselves after event handler code executes, field and property updates are usually reflected in the UI immediately after an event handler is triggered.

As a demonstration of how data binding composes in HTML, the following example binds the `InputValue` property to the second `<input>` element's `value` and `onchange` attributes ([`change`](https://developer.mozilla.org/docs/Web/API/HTMLElement/change_event)). *The second `<input>` element in the following example is a concept demonstration and isn't meant to suggest how you should bind data in Razor components.*

`Pages/BindTheory.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/data-binding/BindTheory.razor" highlight="12-14":::

When the `BindTheory` component is rendered, the `value` of the HTML demonstration `<input>` element comes from the `InputValue` property. When the user enters a value in the text box and changes element focus, the `onchange` event is fired and the `InputValue` property is set to the changed value. In reality, code execution is more complex because [`@bind`](xref:mvc/views/razor#bind) handles cases where type conversions are performed. In general, [`@bind`](xref:mvc/views/razor#bind) associates the current value of an expression with a `value` attribute and handles changes using the registered handler.

Bind a property or field on other [Document Object Model (DOM)](https://developer.mozilla.org/docs/Web/API/Document_Object_Model/Introduction) events by including an `@bind:event="{EVENT}"` attribute with a DOM event for the `{EVENT}` placeholder. The following example binds the `InputValue` property to the `<input>` element's value when the element's `oninput` event ([`input`](https://developer.mozilla.org/docs/Web/API/HTMLElement/input_event)) is triggered. Unlike the `onchange` event ([`change`](https://developer.mozilla.org/docs/Web/API/HTMLElement/change_event)), which fires when the element loses focus, `oninput` ([`input`](https://developer.mozilla.org/docs/Web/API/HTMLElement/input_event)) fires when the value of the text box changes.

`Page/BindEvent.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/data-binding/BindEvent.razor" highlight="4":::

Razor attribute binding is case-sensitive:

* `@bind` and `@bind:event` are valid.
* `@Bind`/`@Bind:Event` (capital letters `B` and `E`) or `@BIND`/`@BIND:EVENT` (all capital letters) **are invalid**.

## Multiple option selection with `<select>` elements

Binding supports [`multiple`](https://developer.mozilla.org/docs/Web/HTML/Attributes/multiple) option selection with `<select>` elements. The [`@onchange`](xref:mvc/views/razor#onevent) event provides an array of the selected elements via [event arguments (`ChangeEventArgs`)](xref:blazor/components/event-handling#event-arguments). The value must be bound to an array type.

`Pages/BindMultipleInput.razor`:

```razor
@page "/bind-multiple-input"

<h1>Bind Multiple <code>input</code>Example</h1>

<p>
    <label>
        Select one or more cars: 
        <select @onchange="SelectedCarsChanged" multiple>
            <option value="audi">Audi</option>
            <option value="jeep">Jeep</option>
            <option value="opel">Opel</option>
            <option value="saab">Saab</option>
            <option value="volvo">Volvo</option>
        </select>
    </label>
</p>

<p>
    Selected Cars: @string.Join(", ", SelectedCars)
</p>

<p>
    <label>
        Select one or more cities: 
        <select @bind="SelectedCities" multiple>
            <option value="bal">Baltimore</option>
            <option value="la">Los Angeles</option>
            <option value="pdx">Portland</option>
            <option value="sf">San Francisco</option>
            <option value="sea">Seattle</option>
        </select>
    </label>
</p>

<span>
    Selected Cities: @string.Join(", ", SelectedCities)
</span>

@code {
    public string[] SelectedCars { get; set; } = new string[] { };
    public string[] SelectedCities { get; set; } = new[] { "bal", "sea" };

    private void SelectedCarsChanged(ChangeEventArgs e)
    {
        if (e.Value is not null)
        {
            SelectedCars = (string[])e.Value;
        }
    }
}
```

For information on how empty strings and `null` values are handled in data binding, see the [Binding `<select>` element options to C# object `null` values](#binding-select-element-options-to-c-object-null-values) section.

## Binding `<select>` element options to C# object `null` values

There's no sensible way to represent a `<select>` element option value as a C# object `null` value, because:

* HTML attributes can't have `null` values. The closest equivalent to `null` in HTML is absence of the HTML `value` attribute from the `<option>` element.
* When selecting an `<option>` with no `value` attribute, the browser treats the value as the *text content* of that `<option>`'s element.

The Blazor framework doesn't attempt to suppress the default behavior because it would involve:

* Creating a chain of special-case workarounds in the framework.
* Breaking changes to current framework behavior.

The most plausible `null` equivalent in HTML is an *empty string* `value`. The Blazor framework handles `null` to empty string conversions for two-way binding to a `<select>`'s value.

## Unparsable values

When a user provides an unparsable value to a databound element, the unparsable value is automatically reverted to its previous value when the bind event is triggered.

Consider the following component, where an `<input>` element is bound to an `int` type with an initial value of `123`.

`Pages/UnparsableValues.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/data-binding/UnparsableValues.razor" highlight="4,12":::

By default, binding applies to the element's `onchange` event. If the user updates the value of the text box's entry to `123.45` and changes the focus, the element's value is reverted to `123` when `onchange` fires. When the value `123.45` is rejected in favor of the original value of `123`, the user understands that their value wasn't accepted.

For the `oninput` event (`@bind:event="oninput"`), a value reversion occurs after any keystroke that introduces an unparsable value. When targeting the `oninput` event with an `int`-bound type, a user is prevented from typing a dot (`.`) character. A dot (`.`) character is immediately removed, so the user receives immediate feedback that only whole numbers are permitted. There are scenarios where reverting the value on the `oninput` event isn't ideal, such as when the user should be allowed to clear an unparsable `<input>` value. Alternatives include:

* Don't use the `oninput` event. Use the default `onchange` event, where an invalid value isn't reverted until the element loses focus.
* Bind to a nullable type, such as `int?` or `string` and provide [custom `get` and `set` accessor logic](#custom-binding-formats) to handle invalid entries.
* Use a [form validation component](xref:blazor/forms-and-input-components), such as <xref:Microsoft.AspNetCore.Components.Forms.InputNumber%601> or <xref:Microsoft.AspNetCore.Components.Forms.InputDate%601>. Form validation components provide built-in support to manage invalid inputs. Form validation components:
  * Permit the user to provide invalid input and receive validation errors on the associated <xref:Microsoft.AspNetCore.Components.Forms.EditContext>.
  * Display validation errors in the UI without interfering with the user entering additional webform data.

## Format strings

Data binding works with a single <xref:System.DateTime> format string using `@bind:format="{FORMAT STRING}"`, where the `{FORMAT STRING}` placeholder is the format string. Other format expressions, such as currency or number formats, aren't available at this time but might be added in a future release.

`Pages/DateBinding.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/data-binding/DateBinding.razor" highlight="6":::

In the preceding code, the `<input>` element's field type (`type` attribute) defaults to `text`.

Nullable <xref:System.DateTime?displayProperty=fullName> and <xref:System.DateTimeOffset?displayProperty=fullName> are supported:

```csharp
private DateTime? date;
private DateTimeOffset? dateOffset;
```

Specifying a format for the `date` field type isn't recommended because Blazor has built-in support to format dates. In spite of the recommendation, only use the `yyyy-MM-dd` date format for binding to function correctly if a format is supplied with the `date` field type:

```razor
<input type="date" @bind="startDate" @bind:format="yyyy-MM-dd">
```

## Custom binding formats

[C# `get` and `set` accessors](/dotnet/csharp/programming-guide/classes-and-structs/using-properties) can be used to create custom binding format behavior, as the following `DecimalBinding` component demonstrates. The component binds a positive or negative decimal with up to three decimal places to an `<input>` element by way of a `string` property (`DecimalValue`).

`Pages/DecimalBinding.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/data-binding/DecimalBinding.razor" highlight="7,21-31":::

## Binding with component parameters

A common scenario is binding a property of a child component to a property in its parent component. This scenario is called a *chained bind* because multiple levels of binding occur simultaneously.

[Component parameters](xref:blazor/components/index#component-parameters) permit binding properties of a parent component with `@bind-{PROPERTY}` syntax, where the `{PROPERTY}` placeholder is the property to bind.

You can't implement chained binds with [`@bind`](xref:mvc/views/razor#bind) syntax in the child component. An event handler and value must be specified separately to support updating the property in the parent from the child component.

The parent component still leverages the [`@bind`](xref:mvc/views/razor#bind) syntax to set up the databinding with the child component.

The following `ChildBind` component has a `Year` component parameter and an <xref:Microsoft.AspNetCore.Components.EventCallback%601>. By convention, the <xref:Microsoft.AspNetCore.Components.EventCallback%601> for the parameter must be named as the component parameter name with a "`Changed`" suffix. The naming syntax is `{PARAMETER NAME}Changed`, where the `{PARAMETER NAME}` placeholder is the parameter name. In the following example, the <xref:Microsoft.AspNetCore.Components.EventCallback%601> is named `YearChanged`.

<xref:Microsoft.AspNetCore.Components.EventCallback.InvokeAsync%2A?displayProperty=nameWithType> invokes the delegate associated with the binding with the provided argument and dispatches an event notification for the changed property.

`Shared/ChildBind.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/data-binding/ChildBind.razor" highlight="14-15,17-18,22":::

For more information on events and <xref:Microsoft.AspNetCore.Components.EventCallback%601>, see the *EventCallback* section of the <xref:blazor/components/event-handling#eventcallback> article.

In the following `Parent1` component, the `year` field is bound to the `Year` parameter of the child component. The `Year` parameter is bindable because it has a companion `YearChanged` event that matches the type of the `Year` parameter.

`Pages/Parent1.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/data-binding/Parent1.razor" highlight="9":::

By convention, a property can be bound to a corresponding event handler by including an `@bind-{PROPERTY}:event` attribute assigned to the handler, where the `{PROPERTY}` placeholder is the property. `<ChildBind @bind-Year="year" />` is equivalent to writing:

```razor
<ChildBind @bind-Year="year" @bind-Year:event="YearChanged" />
```

In a more sophisticated and real-world example, the following `PasswordEntry` component:

* Sets an `<input>` element's value to a `password` field.
* Exposes changes of a `Password` property to a parent component with an [`EventCallback`](xref:blazor/components/event-handling#eventcallback) that passes in the current value of the child's `password` field as its argument.
* Uses the `onclick` event to trigger the `ToggleShowPassword` method. For more information, see <xref:blazor/components/event-handling>.

`Shared/PasswordEntry.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/data-binding/PasswordEntry.razor" highlight="7-10,13,23-24,26-27,36-39":::

The `PasswordEntry` component is used in another component, such as the following `PasswordBinding` component example.

`Pages/PasswordBinding.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/data-binding/PasswordBinding.razor" highlight="5":::

When the `PasswordBinding` component is initially rendered, the `password` value of `Not set` is displayed in the UI. After initial rendering, the value of `password` reflects changes made to the `Password` component parameter value in the `PasswordEntry` component.

> [!NOTE]
> The preceding example binds the password one-way from the child `PasswordEntry` component to the parent `PasswordBinding` component. Two-way binding isn't a requirement in this scenario if the goal is for the app to have a shared password entry component for reuse around the app that merely passes the password to the parent. For an approach that permits two-way binding without [writing directly to the child component's parameter](xref:blazor/components/index#overwritten-parameters), see the `NestedChild` component example in the [Bind across more than two components](#bind-across-more-than-two-components) section of this article.

Perform checks or trap errors in the handler. The following revised `PasswordEntry` component provides immediate feedback to the user if a space is used in the password's value.

`Shared/PasswordEntry.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/data-binding/PasswordEntry2.razor" highlight="35-46":::

## Bind across more than two components

You can bind parameters through any number of nested components, but you must respect the one-way flow of data:

* Change notifications *flow up the hierarchy*.
* New parameter values *flow down the hierarchy*.

A common and recommended approach is to only store the underlying data in the parent component to avoid any confusion about what state must be updated, as shown in the following example.

`Pages/Parent2.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/data-binding/Parent2.razor":::

`Shared/NestedChild.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/data-binding/NestedChild.razor":::

> [!WARNING]
> Generally, avoid creating components that write directly to their own component parameters. The preceding `NestedChild` component makes use of a `BoundValue` property instead of writing directly to its `ChildMessage` parameter. For more information, see <xref:blazor/components/index#overwritten-parameters>.

`Shared/NestedGrandchild.razor`:

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/data-binding/NestedGrandchild.razor":::

For an alternative approach suited to sharing data in memory and across components that aren't necessarily nested, see <xref:blazor/state-management>.

## Additional resources

* [Parameter change detection and additional guidance on Razor component rendering](xref:blazor/components/rendering)
* <xref:blazor/forms-and-input-components>
* [Binding to radio buttons in a form](xref:blazor/forms-and-input-components#radio-buttons)
* [Binding `InputSelect` options to C# object `null` values](xref:blazor/forms-and-input-components#binding-inputselect-options-to-c-object-null-values)
* [ASP.NET Core Blazor event handling: `EventCallback` section](xref:blazor/components/event-handling#eventcallback)
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

Razor components provide data binding features with the [`@bind`](xref:mvc/views/razor#bind) Razor directive attribute with a field, property, or Razor expression value.

The following example binds:

* An `<input>` element value to the C# `inputValue` field.
* A second `<input>` element value to the C# `InputValue` property.

When an `<input>` element loses focus, its bound field or property is updated.

`Pages/Bind.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/data-binding/Bind.razor" highlight="4,8":::

The text box is updated in the UI only when the component is rendered, not in response to changing the field's or property's value. Since components render themselves after event handler code executes, field and property updates are usually reflected in the UI immediately after an event handler is triggered.

As a demonstration of how data binding composes in HTML, the following example binds the `InputValue` property to the second `<input>` element's `value` and `onchange` attributes ([`change`](https://developer.mozilla.org/docs/Web/API/HTMLElement/change_event)). *The second `<input>` element in the following example is a concept demonstration and isn't meant to suggest how you should bind data in Razor components.*

`Pages/BindTheory.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/data-binding/BindTheory.razor" highlight="12-14":::

When the `BindTheory` component is rendered, the `value` of the HTML demonstration `<input>` element comes from the `InputValue` property. When the user enters a value in the text box and changes element focus, the `onchange` event is fired and the `InputValue` property is set to the changed value. In reality, code execution is more complex because [`@bind`](xref:mvc/views/razor#bind) handles cases where type conversions are performed. In general, [`@bind`](xref:mvc/views/razor#bind) associates the current value of an expression with a `value` attribute and handles changes using the registered handler.

Bind a property or field on other [Document Object Model (DOM)](https://developer.mozilla.org/docs/Web/API/Document_Object_Model/Introduction) events by including an `@bind:event="{EVENT}"` attribute with a DOM event for the `{EVENT}` placeholder. The following example binds the `InputValue` property to the `<input>` element's value when the element's `oninput` event ([`input`](https://developer.mozilla.org/docs/Web/API/HTMLElement/input_event)) is triggered. Unlike the `onchange` event ([`change`](https://developer.mozilla.org/docs/Web/API/HTMLElement/change_event)), which fires when the element loses focus, `oninput` ([`input`](https://developer.mozilla.org/docs/Web/API/HTMLElement/input_event)) fires when the value of the text box changes.

`Page/BindEvent.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/data-binding/BindEvent.razor" highlight="4":::

Razor attribute binding is case-sensitive:

* `@bind` and `@bind:event` are valid.
* `@Bind`/`@Bind:Event` (capital letters `B` and `E`) or `@BIND`/`@BIND:EVENT` (all capital letters) **are invalid**.

## Binding `<select>` element options to C# object `null` values

There's no sensible way to represent a `<select>` element option value as a C# object `null` value, because:

* HTML attributes can't have `null` values. The closest equivalent to `null` in HTML is absence of the HTML `value` attribute from the `<option>` element.
* When selecting an `<option>` with no `value` attribute, the browser treats the value as the *text content* of that `<option>`'s element.

The Blazor framework doesn't attempt to suppress the default behavior because it would involve:

* Creating a chain of special-case workarounds in the framework.
* Breaking changes to current framework behavior.

The most plausible `null` equivalent in HTML is an *empty string* `value`. The Blazor framework handles `null` to empty string conversions for two-way binding to a `<select>`'s value.

## Unparsable values

When a user provides an unparsable value to a databound element, the unparsable value is automatically reverted to its previous value when the bind event is triggered.

Consider the following component, where an `<input>` element is bound to an `int` type with an initial value of `123`.

`Pages/UnparsableValues.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/data-binding/UnparsableValues.razor" highlight="4,12":::

By default, binding applies to the element's `onchange` event. If the user updates the value of the text box's entry to `123.45` and changes the focus, the element's value is reverted to `123` when `onchange` fires. When the value `123.45` is rejected in favor of the original value of `123`, the user understands that their value wasn't accepted.

For the `oninput` event (`@bind:event="oninput"`), a value reversion occurs after any keystroke that introduces an unparsable value. When targeting the `oninput` event with an `int`-bound type, a user is prevented from typing a dot (`.`) character. A dot (`.`) character is immediately removed, so the user receives immediate feedback that only whole numbers are permitted. There are scenarios where reverting the value on the `oninput` event isn't ideal, such as when the user should be allowed to clear an unparsable `<input>` value. Alternatives include:

* Don't use the `oninput` event. Use the default `onchange` event, where an invalid value isn't reverted until the element loses focus.
* Bind to a nullable type, such as `int?` or `string` and provide [custom `get` and `set` accessor logic](#custom-binding-formats) to handle invalid entries.
* Use a [form validation component](xref:blazor/forms-and-input-components), such as <xref:Microsoft.AspNetCore.Components.Forms.InputNumber%601> or <xref:Microsoft.AspNetCore.Components.Forms.InputDate%601>. Form validation components provide built-in support to manage invalid inputs. Form validation components:
  * Permit the user to provide invalid input and receive validation errors on the associated <xref:Microsoft.AspNetCore.Components.Forms.EditContext>.
  * Display validation errors in the UI without interfering with the user entering additional webform data.

## Format strings

Data binding works with a single <xref:System.DateTime> format string using `@bind:format="{FORMAT STRING}"`, where the `{FORMAT STRING}` placeholder is the format string. Other format expressions, such as currency or number formats, aren't available at this time but might be added in a future release.

`Pages/DateBinding.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/data-binding/DateBinding.razor" highlight="6":::

In the preceding code, the `<input>` element's field type (`type` attribute) defaults to `text`.

Nullable <xref:System.DateTime?displayProperty=fullName> and <xref:System.DateTimeOffset?displayProperty=fullName> are supported:

```csharp
private DateTime? date;
private DateTimeOffset? dateOffset;
```

Specifying a format for the `date` field type isn't recommended because Blazor has built-in support to format dates. In spite of the recommendation, only use the `yyyy-MM-dd` date format for binding to function correctly if a format is supplied with the `date` field type:

```razor
<input type="date" @bind="startDate" @bind:format="yyyy-MM-dd">
```

## Custom binding formats

[C# `get` and `set` accessors](/dotnet/csharp/programming-guide/classes-and-structs/using-properties) can be used to create custom binding format behavior, as the following `DecimalBinding` component demonstrates. The component binds a positive or negative decimal with up to three decimal places to an `<input>` element by way of a `string` property (`DecimalValue`).

`Pages/DecimalBinding.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/data-binding/DecimalBinding.razor" highlight="7,21-31":::

## Binding with component parameters

A common scenario is binding a property of a child component to a property in its parent component. This scenario is called a *chained bind* because multiple levels of binding occur simultaneously.

[Component parameters](xref:blazor/components/index#component-parameters) permit binding properties of a parent component with `@bind-{PROPERTY}` syntax, where the `{PROPERTY}` placeholder is the property to bind.

You can't implement chained binds with [`@bind`](xref:mvc/views/razor#bind) syntax in the child component. An event handler and value must be specified separately to support updating the property in the parent from the child component.

The parent component still leverages the [`@bind`](xref:mvc/views/razor#bind) syntax to set up the databinding with the child component.

The following `ChildBind` component has a `Year` component parameter and an <xref:Microsoft.AspNetCore.Components.EventCallback%601>. By convention, the <xref:Microsoft.AspNetCore.Components.EventCallback%601> for the parameter must be named as the component parameter name with a "`Changed`" suffix. The naming syntax is `{PARAMETER NAME}Changed`, where the `{PARAMETER NAME}` placeholder is the parameter name. In the following example, the <xref:Microsoft.AspNetCore.Components.EventCallback%601> is named `YearChanged`.

<xref:Microsoft.AspNetCore.Components.EventCallback.InvokeAsync%2A?displayProperty=nameWithType> invokes the delegate associated with the binding with the provided argument and dispatches an event notification for the changed property.

`Shared/ChildBind.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/data-binding/ChildBind.razor" highlight="14-15,17-18,22":::

For more information on events and <xref:Microsoft.AspNetCore.Components.EventCallback%601>, see the *EventCallback* section of the <xref:blazor/components/event-handling#eventcallback> article.

In the following `Parent1` component, the `year` field is bound to the `Year` parameter of the child component. The `Year` parameter is bindable because it has a companion `YearChanged` event that matches the type of the `Year` parameter.

`Pages/Parent1.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/data-binding/Parent1.razor" highlight="9":::

By convention, a property can be bound to a corresponding event handler by including an `@bind-{PROPERTY}:event` attribute assigned to the handler, where the `{PROPERTY}` placeholder is the property. `<ChildBind @bind-Year="year" />` is equivalent to writing:

```razor
<ChildBind @bind-Year="year" @bind-Year:event="YearChanged" />
```

In a more sophisticated and real-world example, the following `PasswordEntry` component:

* Sets an `<input>` element's value to a `password` field.
* Exposes changes of a `Password` property to a parent component with an [`EventCallback`](xref:blazor/components/event-handling#eventcallback) that passes in the current value of the child's `password` field as its argument.
* Uses the `onclick` event to trigger the `ToggleShowPassword` method. For more information, see <xref:blazor/components/event-handling>.

`Shared/PasswordEntry.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/data-binding/PasswordEntry.razor" highlight="7-10,13,23-24,26-27,36-39":::

The `PasswordEntry` component is used in another component, such as the following `PasswordBinding` component example.

`Pages/PasswordBinding.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/data-binding/PasswordBinding.razor" highlight="5":::

When the `PasswordBinding` component is initially rendered, the `password` value of `Not set` is displayed in the UI. After initial rendering, the value of `password` reflects changes made to the `Password` component parameter value in the `PasswordEntry` component.

> [!NOTE]
> The preceding example binds the password one-way from the child `PasswordEntry` component to the parent `PasswordBinding` component. Two-way binding isn't a requirement in this scenario if the goal is for the app to have a shared password entry component for reuse around the app that merely passes the password to the parent. For an approach that permits two-way binding without [writing directly to the child component's parameter](xref:blazor/components/index#overwritten-parameters), see the `NestedChild` component example in the [Bind across more than two components](#bind-across-more-than-two-components) section of this article.

Perform checks or trap errors in the handler. The following revised `PasswordEntry` component provides immediate feedback to the user if a space is used in the password's value.

`Shared/PasswordEntry.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/data-binding/PasswordEntry2.razor" highlight="35-46":::

## Bind across more than two components

You can bind parameters through any number of nested components, but you must respect the one-way flow of data:

* Change notifications *flow up the hierarchy*.
* New parameter values *flow down the hierarchy*.

A common and recommended approach is to only store the underlying data in the parent component to avoid any confusion about what state must be updated, as shown in the following example.

`Pages/Parent2.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/data-binding/Parent2.razor":::

`Shared/NestedChild.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/data-binding/NestedChild.razor":::

> [!WARNING]
> Generally, avoid creating components that write directly to their own component parameters. The preceding `NestedChild` component makes use of a `BoundValue` property instead of writing directly to its `ChildMessage` parameter. For more information, see <xref:blazor/components/index#overwritten-parameters>.

`Shared/NestedGrandchild.razor`:

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/data-binding/NestedGrandchild.razor":::

For an alternative approach suited to sharing data in memory and across components that aren't necessarily nested, see <xref:blazor/state-management>.

## Additional resources

* [Parameter change detection and additional guidance on Razor component rendering](xref:blazor/components/rendering)
* <xref:blazor/forms-and-input-components>
* [Binding to radio buttons in a form](xref:blazor/forms-and-input-components#radio-buttons)
* [Binding `InputSelect` options to C# object `null` values](xref:blazor/forms-and-input-components#binding-inputselect-options-to-c-object-null-values)
* [ASP.NET Core Blazor event handling: `EventCallback` section](xref:blazor/components/event-handling#eventcallback)
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)

:::moniker-end

:::moniker range="< aspnetcore-5.0"

Razor components provide data binding features with the [`@bind`](xref:mvc/views/razor#bind) Razor directive attribute with a field, property, or Razor expression value.

The following example binds:

* An `<input>` element value to the C# `inputValue` field.
* A second `<input>` element value to the C# `InputValue` property.

When an `<input>` element loses focus, its bound field or property is updated.

`Pages/Bind.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/data-binding/Bind.razor" highlight="4,8":::

The text box is updated in the UI only when the component is rendered, not in response to changing the field's or property's value. Since components render themselves after event handler code executes, field and property updates are usually reflected in the UI immediately after an event handler is triggered.

As a demonstration of how data binding composes in HTML, the following example binds the `InputValue` property to the second `<input>` element's `value` and `onchange` attributes ([`change`](https://developer.mozilla.org/docs/Web/API/HTMLElement/change_event)). *The second `<input>` element in the following example is a concept demonstration and isn't meant to suggest how you should bind data in Razor components.*

`Pages/BindTheory.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/data-binding/BindTheory.razor" highlight="12-14":::

When the `BindTheory` component is rendered, the `value` of the HTML demonstration `<input>` element comes from the `InputValue` property. When the user enters a value in the text box and changes element focus, the `onchange` event is fired and the `InputValue` property is set to the changed value. In reality, code execution is more complex because [`@bind`](xref:mvc/views/razor#bind) handles cases where type conversions are performed. In general, [`@bind`](xref:mvc/views/razor#bind) associates the current value of an expression with a `value` attribute and handles changes using the registered handler.

Bind a property or field on other [Document Object Model (DOM)](https://developer.mozilla.org/docs/Web/API/Document_Object_Model/Introduction) events by including an `@bind:event="{EVENT}"` attribute with a DOM event for the `{EVENT}` placeholder. The following example binds the `InputValue` property to the `<input>` element's value when the element's `oninput` event ([`input`](https://developer.mozilla.org/docs/Web/API/HTMLElement/input_event)) is triggered. Unlike the `onchange` event ([`change`](https://developer.mozilla.org/docs/Web/API/HTMLElement/change_event)), which fires when the element loses focus, `oninput` ([`input`](https://developer.mozilla.org/docs/Web/API/HTMLElement/input_event)) fires when the value of the text box changes.

`Page/BindEvent.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/data-binding/BindEvent.razor" highlight="4":::

Razor attribute binding is case-sensitive:

* `@bind` and `@bind:event` are valid.
* `@Bind`/`@Bind:Event` (capital letters `B` and `E`) or `@BIND`/`@BIND:EVENT` (all capital letters) **are invalid**.

## Binding `<select>` element options to C# object `null` values

There's no sensible way to represent a `<select>` element option value as a C# object `null` value, because:

* HTML attributes can't have `null` values. The closest equivalent to `null` in HTML is absence of the HTML `value` attribute from the `<option>` element.
* When selecting an `<option>` with no `value` attribute, the browser treats the value as the *text content* of that `<option>`'s element.

The Blazor framework doesn't attempt to suppress the default behavior because it would involve:

* Creating a chain of special-case workarounds in the framework.
* Breaking changes to current framework behavior.

The Blazor framework doesn't automatically handle `null` to empty string conversions when attempting two-way binding to a `<select>`'s value. For more information, see [Fix binding `<select>` to a null value (dotnet/aspnetcore #23221)](https://github.com/dotnet/aspnetcore/pull/23221).

## Unparsable values

When a user provides an unparsable value to a databound element, the unparsable value is automatically reverted to its previous value when the bind event is triggered.

Consider the following component, where an `<input>` element is bound to an `int` type with an initial value of `123`.

`Pages/UnparsableValues.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/data-binding/UnparsableValues.razor" highlight="4,12":::

By default, binding applies to the element's `onchange` event. If the user updates the value of the text box's entry to `123.45` and changes the focus, the element's value is reverted to `123` when `onchange` fires. When the value `123.45` is rejected in favor of the original value of `123`, the user understands that their value wasn't accepted.

For the `oninput` event (`@bind:event="oninput"`), a value reversion occurs after any keystroke that introduces an unparsable value. When targeting the `oninput` event with an `int`-bound type, a user is prevented from typing a dot (`.`) character. A dot (`.`) character is immediately removed, so the user receives immediate feedback that only whole numbers are permitted. There are scenarios where reverting the value on the `oninput` event isn't ideal, such as when the user should be allowed to clear an unparsable `<input>` value. Alternatives include:

* Don't use the `oninput` event. Use the default `onchange` event, where an invalid value isn't reverted until the element loses focus.
* Bind to a nullable type, such as `int?` or `string` and provide [custom `get` and `set` accessor logic](#custom-binding-formats) to handle invalid entries.
* Use a [form validation component](xref:blazor/forms-and-input-components), such as <xref:Microsoft.AspNetCore.Components.Forms.InputNumber%601> or <xref:Microsoft.AspNetCore.Components.Forms.InputDate%601>. Form validation components provide built-in support to manage invalid inputs. Form validation components:
  * Permit the user to provide invalid input and receive validation errors on the associated <xref:Microsoft.AspNetCore.Components.Forms.EditContext>.
  * Display validation errors in the UI without interfering with the user entering additional webform data.

## Format strings

Data binding works with a single <xref:System.DateTime> format string using `@bind:format="{FORMAT STRING}"`, where the `{FORMAT STRING}` placeholder is the format string. Other format expressions, such as currency or number formats, aren't available at this time but might be added in a future release.

`Pages/DateBinding.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/data-binding/DateBinding.razor" highlight="6":::

In the preceding code, the `<input>` element's field type (`type` attribute) defaults to `text`.

Nullable <xref:System.DateTime?displayProperty=fullName> and <xref:System.DateTimeOffset?displayProperty=fullName> are supported:

```csharp
private DateTime? date;
private DateTimeOffset? dateOffset;
```

Specifying a format for the `date` field type isn't recommended because Blazor has built-in support to format dates. In spite of the recommendation, only use the `yyyy-MM-dd` date format for binding to function correctly if a format is supplied with the `date` field type:

```razor
<input type="date" @bind="startDate" @bind:format="yyyy-MM-dd">
```

## Custom binding formats

[C# `get` and `set` accessors](/dotnet/csharp/programming-guide/classes-and-structs/using-properties) can be used to create custom binding format behavior, as the following `DecimalBinding` component demonstrates. The component binds a positive or negative decimal with up to three decimal places to an `<input>` element by way of a `string` property (`DecimalValue`).

`Pages/DecimalBinding.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/data-binding/DecimalBinding.razor" highlight="7,21-31":::

## Binding with component parameters

A common scenario is binding a property of a child component to a property in its parent component. This scenario is called a *chained bind* because multiple levels of binding occur simultaneously.

[Component parameters](xref:blazor/components/index#component-parameters) permit binding properties of a parent component with `@bind-{PROPERTY}` syntax, where the `{PROPERTY}` placeholder is the property to bind.

You can't implement chained binds with [`@bind`](xref:mvc/views/razor#bind) syntax in the child component. An event handler and value must be specified separately to support updating the property in the parent from the child component.

The parent component still leverages the [`@bind`](xref:mvc/views/razor#bind) syntax to set up the databinding with the child component.

The following `ChildBind` component has a `Year` component parameter and an <xref:Microsoft.AspNetCore.Components.EventCallback%601>. By convention, the <xref:Microsoft.AspNetCore.Components.EventCallback%601> for the parameter must be named as the component parameter name with a "`Changed`" suffix. The naming syntax is `{PARAMETER NAME}Changed`, where the `{PARAMETER NAME}` placeholder is the parameter name. In the following example, the <xref:Microsoft.AspNetCore.Components.EventCallback%601> is named `YearChanged`.

<xref:Microsoft.AspNetCore.Components.EventCallback.InvokeAsync%2A?displayProperty=nameWithType> invokes the delegate associated with the binding with the provided argument and dispatches an event notification for the changed property.

`Shared/ChildBind.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/data-binding/ChildBind.razor" highlight="14-15,17-18,22":::

For more information on events and <xref:Microsoft.AspNetCore.Components.EventCallback%601>, see the *EventCallback* section of the <xref:blazor/components/event-handling#eventcallback> article.

In the following `Parent1` component, the `year` field is bound to the `Year` parameter of the child component. The `Year` parameter is bindable because it has a companion `YearChanged` event that matches the type of the `Year` parameter.

`Pages/Parent1.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/data-binding/Parent1.razor" highlight="9":::

By convention, a property can be bound to a corresponding event handler by including an `@bind-{PROPERTY}:event` attribute assigned to the handler, where the `{PROPERTY}` placeholder is the property. `<ChildBind @bind-Year="year" />` is equivalent to writing:

```razor
<ChildBind @bind-Year="year" @bind-Year:event="YearChanged" />
```

In a more sophisticated and real-world example, the following `PasswordEntry` component:

* Sets an `<input>` element's value to a `password` field.
* Exposes changes of a `Password` property to a parent component with an [`EventCallback`](xref:blazor/components/event-handling#eventcallback) that passes in the current value of the child's `password` field as its argument.
* Uses the `onclick` event to trigger the `ToggleShowPassword` method. For more information, see <xref:blazor/components/event-handling>.

`Shared/PasswordEntry.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/data-binding/PasswordEntry.razor" highlight="7-10,13,23-24,26-27,36-39":::

The `PasswordEntry` component is used in another component, such as the following `PasswordBinding` component example.

`Pages/PasswordBinding.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/data-binding/PasswordBinding.razor" highlight="5":::

When the `PasswordBinding` component is initially rendered, the `password` value of `Not set` is displayed in the UI. After initial rendering, the value of `password` reflects changes made to the `Password` component parameter value in the `PasswordEntry` component.

> [!NOTE]
> The preceding example binds the password one-way from the child `PasswordEntry` component to the parent `PasswordBinding` component. Two-way binding isn't a requirement in this scenario if the goal is for the app to have a shared password entry component for reuse around the app that merely passes the password to the parent. For an approach that permits two-way binding without [writing directly to the child component's parameter](xref:blazor/components/index#overwritten-parameters), see the `NestedChild` component example in the [Bind across more than two components](#bind-across-more-than-two-components) section of this article.

Perform checks or trap errors in the handler. The following revised `PasswordEntry` component provides immediate feedback to the user if a space is used in the password's value.

`Shared/PasswordEntry.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/data-binding/PasswordEntry2.razor" highlight="35-46":::

## Bind across more than two components

You can bind parameters through any number of nested components, but you must respect the one-way flow of data:

* Change notifications *flow up the hierarchy*.
* New parameter values *flow down the hierarchy*.

A common and recommended approach is to only store the underlying data in the parent component to avoid any confusion about what state must be updated, as shown in the following example.

`Pages/Parent2.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/data-binding/Parent2.razor":::

`Shared/NestedChild.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/data-binding/NestedChild.razor":::

> [!WARNING]
> Generally, avoid creating components that write directly to their own component parameters. The preceding `NestedChild` component makes use of a `BoundValue` property instead of writing directly to its `ChildMessage` parameter. For more information, see <xref:blazor/components/index#overwritten-parameters>.

`Shared/NestedGrandchild.razor`:

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/data-binding/NestedGrandchild.razor":::

For an alternative approach suited to sharing data in memory and across components that aren't necessarily nested, see <xref:blazor/state-management>.

## Additional resources

* [Parameter change detection and additional guidance on Razor component rendering](xref:blazor/components/rendering)
* <xref:blazor/forms-and-input-components>
* [Binding to radio buttons in a form](xref:blazor/forms-and-input-components#radio-buttons)
* [Binding `InputSelect` options to C# object `null` values](xref:blazor/forms-and-input-components#binding-inputselect-options-to-c-object-null-values)
* [ASP.NET Core Blazor event handling: `EventCallback` section](xref:blazor/components/event-handling#eventcallback)
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)

:::moniker-end
