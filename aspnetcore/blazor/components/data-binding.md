---
title: ASP.NET Core Blazor data binding
author: guardrex
description: Learn about data binding features for Razor components and DOM elements in Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 01/16/2024
uid: blazor/components/data-binding
---
# ASP.NET Core Blazor data binding

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains data binding features for Razor components and DOM elements in Blazor apps.

[!INCLUDE[](~/blazor/includes/location-client-and-server-pre-net8.md)]

## Binding features

Razor components provide data binding features with the [`@bind`](xref:mvc/views/razor#bind) Razor directive attribute with a field, property, or Razor expression value.

The following example binds:

* An `<input>` element value to the C# `inputValue` field.
* A second `<input>` element value to the C# `InputValue` property.

When an `<input>` element loses focus, its bound field or property is updated.

`Bind.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Bind.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/data-binding/Bind.razor" highlight="4,8":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/data-binding/Bind.razor" highlight="4,8":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/data-binding/Bind.razor" highlight="4,8":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/data-binding/Bind.razor" highlight="4,8":::

:::moniker-end

The text box is updated in the UI only when the component is rendered, not in response to changing the field's or property's value. Since components render themselves after event handler code executes, field and property updates are usually reflected in the UI immediately after an event handler is triggered.

As a demonstration of how data binding composes in HTML, the following example binds the `InputValue` property to the second `<input>` element's `value` and `onchange` attributes ([`change`](https://developer.mozilla.org/docs/Web/API/HTMLElement/change_event)). *The second `<input>` element in the following example is a concept demonstration and isn't meant to suggest how you should bind data in Razor components.*

`BindTheory.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/BindTheory.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/data-binding/BindTheory.razor" highlight="12-14":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/data-binding/BindTheory.razor" highlight="12-14":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/data-binding/BindTheory.razor" highlight="12-14":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/data-binding/BindTheory.razor" highlight="12-14":::

:::moniker-end

When the `BindTheory` component is rendered, the `value` of the HTML demonstration `<input>` element comes from the `InputValue` property. When the user enters a value in the text box and changes element focus, the `onchange` event is fired and the `InputValue` property is set to the changed value. In reality, code execution is more complex because [`@bind`](xref:mvc/views/razor#bind) handles cases where type conversions are performed. In general, [`@bind`](xref:mvc/views/razor#bind) associates the current value of an expression with the `value` attribute of the `<input>` and handles changes using the registered handler.

Bind a property or field on other DOM events by including an `@bind:event="{EVENT}"` attribute with a DOM event for the `{EVENT}` placeholder. The following example binds the `InputValue` property to the `<input>` element's value when the element's `oninput` event ([`input`](https://developer.mozilla.org/docs/Web/API/HTMLElement/input_event)) is triggered. Unlike the `onchange` event ([`change`](https://developer.mozilla.org/docs/Web/API/HTMLElement/change_event)), which fires when the element loses focus, `oninput` ([`input`](https://developer.mozilla.org/docs/Web/API/HTMLElement/input_event)) fires when the value of the text box changes.

`Page/BindEvent.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/BindEvent.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/data-binding/BindEvent.razor" highlight="4":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/data-binding/BindEvent.razor" highlight="4":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/data-binding/BindEvent.razor" highlight="4":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/data-binding/BindEvent.razor" highlight="4":::

:::moniker-end

:::moniker range="< aspnetcore-7.0"

Razor attribute binding is case-sensitive:

* `@bind` and `@bind:event` are valid.
* `@Bind`/`@Bind:Event` (capital letters `B` and `E`) or `@BIND`/`@BIND:EVENT` (all capital letters) **are invalid**.

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

To execute asynchronous logic after binding, use `@bind:after="{EVENT}"` with a DOM event for the `{EVENT}` placeholder. An assigned C# method isn't executed until the bound value is assigned synchronously.

Using an [event callback parameter (`EventCallback`/`EventCallback<T>`)](xref:blazor/components/event-handling#eventcallback) with `@bind:after` isn't supported. Instead, pass a method that returns an <xref:System.Action> or <xref:System.Threading.Tasks.Task> to `@bind:after`.

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

`BindAfter.razor`:

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

For more information on the `InputText` component, see <xref:blazor/forms/input-components>.

Components support two-way data binding by defining a pair of parameters:

* `@bind:get`: Specifies the value to bind.
* `@bind:set`: Specifies a callback for when the value changes.

The `@bind:get` and `@bind:set` modifiers are always used together.

Using an event callback parameter with `@bind:set` (`[Parameter] public EventCallback<string> ValueChanged { get; set; }`) isn't supported. Instead, pass a method that returns an <xref:System.Action> or <xref:System.Threading.Tasks.Task> to `@bind:set`.

Examples

`BindGetSet.razor`:

```razor
@page "/bind-get-set"
@using Microsoft.AspNetCore.Components.Forms

<h1>Bind Get Set Examples</h1>

<h2>Elements</h2>

<input type="text" @bind:get="text" @bind:set="(value) => { text = value; }" />
<input type="text" @bind:get="text" @bind:set="Set" />
<input type="text" @bind:get="text" @bind:set="SetAsync" />

<h2>Components</h2>

<InputText @bind-Value:get="text" @bind-Value:set="(value) => { text = value; }" />
<InputText @bind-Value:get="text" @bind-Value:set="Set" />
<InputText @bind-Value:get="text" @bind-Value:set="SetAsync" />

@code {
    private string text = "";

    private void Set(string value)
    {
        text = value;
    }

    private Task SetAsync(string value)
    {
        text = value;
        return Task.CompletedTask;
    }
}
```

For more information on the `InputText` component, see <xref:blazor/forms/input-components>.

For another example use of `@bind:get` and `@bind:set`, see the [Bind across more than two components](#bind-across-more-than-two-components) section later in this article.

Razor attribute binding is case-sensitive:

* `@bind`, `@bind:event`, and `@bind:after` are valid.
* `@Bind`/`@bind:Event`/`@bind:aftEr` (capital letters) or `@BIND`/`@BIND:EVENT`/`@BIND:AFTER` (all capital letters) **are invalid**.

## Use `@bind:get`/`@bind:set` modifiers and avoid event handlers for two-way data binding

Two-way data binding isn't possible to implement with an event handler. Use `@bind:get`/`@bind:set` modifiers for two-way data binding.

<span aria-hidden="true">❌</span> Consider the following ***dysfunctional approach*** for two-way data binding using an event handler:

```razor
<p>
    <input value="@inputValue" @oninput="OnInput" />
</p>

<p>
    <code>inputValue</code>: @inputValue
</p>

@code {
    private string? inputValue;

    private void OnInput(ChangeEventArgs args)
    {
        var newValue = args.Value?.ToString() ?? string.Empty;

        inputValue = newValue.Length > 4 ? "Long!" : newValue;
    }
}
```

The `OnInput` event handler updates the value of `inputValue` to `Long!` after a fourth character is provided. However, the user can continue adding characters to the element value in the UI. The value of `inputValue` isn't bound back to the element's value with each keystroke. The preceding example is only capable of one-way data binding.

The reason for this behavior is that Blazor isn't aware that your code intends to modify the value of `inputValue` in the event handler. Blazor doesn't try to force DOM element values and .NET variable values to match unless they're bound with `@bind` syntax. In earlier versions of Blazor, two-way data binding is implemented by [binding the element to a property and controlling the property's value with its setter](#binding-to-a-property-with-c-get-and-set-accessors). In ASP.NET Core 7.0 or later, `@bind:get`/`@bind:set` modifier syntax is used to implement two-way data binding, as the next example demonstrates.

<span aria-hidden="true">✔️</span> Consider the following ***correct approach*** using `@bind:get`/`@bind:set` for two-way data binding:

```razor
<p>
    <input @bind:event="oninput" @bind:get="inputValue" @bind:set="OnInput" />
</p>

<p>
    <code>inputValue</code>: @inputValue
</p>

@code {
    private string? inputValue;

    private void OnInput(string value)
    {
        var newValue = value ?? string.Empty;

        inputValue = newValue.Length > 4 ? "Long!" : newValue;
    }
}
```

Using `@bind:get`/`@bind:set` modifiers both controls the underlying value of `inputValue` via `@bind:set` and binds the value of `inputValue` to the element's value via `@bind:get`. The preceding example demonstrates the correct approach for implementing two-way data binding.

:::moniker-end

## Binding to a property with C# `get` and `set` accessors

[C# `get` and `set` accessors](/dotnet/csharp/programming-guide/classes-and-structs/using-properties) can be used to create custom binding format behavior, as the following `DecimalBinding` component demonstrates. The component binds a positive or negative decimal with up to three decimal places to an `<input>` element by way of a `string` property (`DecimalValue`).

`DecimalBinding.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/DecimalBinding.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/data-binding/DecimalBinding.razor" highlight="7,21-31":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/data-binding/DecimalBinding.razor" highlight="7,21-31":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/data-binding/DecimalBinding.razor" highlight="7,21-31":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/data-binding/DecimalBinding.razor" highlight="7,21-31":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

> [!NOTE]
> Two-way binding to a property with `get`/`set` accessors requires discarding the <xref:System.Threading.Tasks.Task> returned by <xref:Microsoft.AspNetCore.Components.EventCallback.InvokeAsync%2A?displayProperty=nameWithType>. For two-way data binding, we recommend using `@bind:get`/`@bind:set` modifiers. For more information, see the `@bind:get`/`@bind:set` guidance in the earlier in this article.

:::moniker-end

:::moniker range="< aspnetcore-7.0"

> [!NOTE]
> Two-way binding to a property with `get`/`set` accessors requires discarding the <xref:System.Threading.Tasks.Task> returned by <xref:Microsoft.AspNetCore.Components.EventCallback.InvokeAsync%2A?displayProperty=nameWithType>. For two-way data binding in ASP.NET Core 7.0 or later, we recommend using `@bind:get`/`@bind:set` modifiers, which are described in 7.0 or later versions of this article.

:::moniker-end

:::moniker range=">= aspnetcore-6.0"

## Multiple option selection with `<select>` elements

Binding supports [`multiple`](https://developer.mozilla.org/docs/Web/HTML/Attributes/multiple) option selection with `<select>` elements. The [`@onchange`](xref:mvc/views/razor#onevent) event provides an array of the selected elements via [event arguments (`ChangeEventArgs`)](xref:blazor/components/event-handling#event-arguments). The value must be bound to an array type.

`BindMultipleInput.razor`:

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

:::moniker-end

## Binding `<select>` element options to C# object `null` values

There's no sensible way to represent a `<select>` element option value as a C# object `null` value, because:

* HTML attributes can't have `null` values. The closest equivalent to `null` in HTML is absence of the HTML `value` attribute from the `<option>` element.
* When selecting an `<option>` with no `value` attribute, the browser treats the value as the *text content* of that `<option>`'s element.

The Blazor framework doesn't attempt to suppress the default behavior because it would involve:

* Creating a chain of special-case workarounds in the framework.
* Breaking changes to current framework behavior.

The most plausible `null` equivalent in HTML is an *empty string* `value`. The Blazor framework handles `null` to empty string conversions for two-way binding to a `<select>`'s value.

## Unparsable values

When a user provides an unparsable value to a data-bound element, the unparsable value is automatically reverted to its previous value when the bind event is triggered.

Consider the following component, where an `<input>` element is bound to an `int` type with an initial value of `123`.

`UnparsableValues.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/UnparsableValues.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/data-binding/UnparsableValues.razor" highlight="4,12":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/data-binding/UnparsableValues.razor" highlight="4,12":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/data-binding/UnparsableValues.razor" highlight="4,12":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/data-binding/UnparsableValues.razor" highlight="4,12":::

:::moniker-end

By default, binding applies to the element's `onchange` event. If the user updates the value of the text box's entry to `123.45` and changes the focus, the element's value is reverted to `123` when `onchange` fires. When the value `123.45` is rejected in favor of the original value of `123`, the user understands that their value wasn't accepted.

For the `oninput` event (`@bind:event="oninput"`), a value reversion occurs after any keystroke that introduces an unparsable value. When targeting the `oninput` event with an `int`-bound type, a user is prevented from typing a dot (`.`) character. A dot (`.`) character is immediately removed, so the user receives immediate feedback that only whole numbers are permitted. There are scenarios where reverting the value on the `oninput` event isn't ideal, such as when the user should be allowed to clear an unparsable `<input>` value. Alternatives include:

* Don't use the `oninput` event. Use the default `onchange` event, where an invalid value isn't reverted until the element loses focus.
* Bind to a nullable type, such as `int?` or `string` and either use `@bind:get`/`@bind:set` modifiers (described earlier in this article) or [bind to a property with custom `get` and `set` accessor logic](#binding-to-a-property-with-c-get-and-set-accessors) to handle invalid entries.
* Use a [form validation component](xref:blazor/forms/validation), such as <xref:Microsoft.AspNetCore.Components.Forms.InputNumber%601> or <xref:Microsoft.AspNetCore.Components.Forms.InputDate%601>. Form validation components provide built-in support to manage invalid inputs. Form validation components:
  * Permit the user to provide invalid input and receive validation errors on the associated <xref:Microsoft.AspNetCore.Components.Forms.EditContext>.
  * Display validation errors in the UI without interfering with the user entering additional webform data.

## Format strings

Data binding works with a single <xref:System.DateTime> format string using `@bind:format="{FORMAT STRING}"`, where the `{FORMAT STRING}` placeholder is the format string. Other format expressions, such as currency or number formats, aren't available at this time but might be added in a future release.

`DateBinding.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/DateBinding.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/data-binding/DateBinding.razor" highlight="6":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/data-binding/DateBinding.razor" highlight="6":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/data-binding/DateBinding.razor" highlight="6":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/data-binding/DateBinding.razor" highlight="6":::

:::moniker-end

In the preceding code, the `<input>` element's field type (`type` attribute) defaults to `text`.

:::moniker range=">= aspnetcore-6.0"

Nullable <xref:System.DateTime?displayProperty=fullName> and <xref:System.DateTimeOffset?displayProperty=fullName> are supported:

```csharp
private DateTime? date;
private DateTimeOffset? dateOffset;
```

:::moniker-end

Specifying a format for the `date` field type isn't recommended because Blazor has built-in support to format dates. In spite of the recommendation, only use the `yyyy-MM-dd` date format for binding to function correctly if a format is supplied with the `date` field type:

```razor
<input type="date" @bind="startDate" @bind:format="yyyy-MM-dd">
```

## Binding with component parameters

A common scenario is binding a property of a child component to a property in its parent component. This scenario is called a *chained bind* because multiple levels of binding occur simultaneously.

[Component parameters](xref:blazor/components/index#component-parameters) permit binding properties of a parent component with `@bind-{PROPERTY}` syntax, where the `{PROPERTY}` placeholder is the property to bind.

You can't implement chained binds with [`@bind`](xref:mvc/views/razor#bind) syntax in the child component. An event handler and value must be specified separately to support updating the property in the parent from the child component.

The parent component still leverages the [`@bind`](xref:mvc/views/razor#bind) syntax to set up the databinding with the child component.

The following `ChildBind` component has a `Year` component parameter and an <xref:Microsoft.AspNetCore.Components.EventCallback%601>. By convention, the <xref:Microsoft.AspNetCore.Components.EventCallback%601> for the parameter must be named as the component parameter name with a "`Changed`" suffix. The naming syntax is `{PARAMETER NAME}Changed`, where the `{PARAMETER NAME}` placeholder is the parameter name. In the following example, the <xref:Microsoft.AspNetCore.Components.EventCallback%601> is named `YearChanged`.

<xref:Microsoft.AspNetCore.Components.EventCallback.InvokeAsync%2A?displayProperty=nameWithType> invokes the delegate associated with the binding with the provided argument and dispatches an event notification for the changed property.

`ChildBind.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/ChildBind.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/data-binding/ChildBind.razor" highlight="14-15,17-18,22":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/data-binding/ChildBind.razor" highlight="14-15,17-18,22":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/data-binding/ChildBind.razor" highlight="14-15,17-18,22":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/data-binding/ChildBind.razor" highlight="14-15,17-18,22":::

:::moniker-end

For more information on events and <xref:Microsoft.AspNetCore.Components.EventCallback%601>, see the *EventCallback* section of the <xref:blazor/components/event-handling#eventcallback> article.

In the following `Parent1` component, the `year` field is bound to the `Year` parameter of the child component. The `Year` parameter is bindable because it has a companion `YearChanged` event that matches the type of the `Year` parameter.

`Parent1.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Parent1.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/data-binding/Parent1.razor" highlight="9":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/data-binding/Parent1.razor" highlight="9":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/data-binding/Parent1.razor" highlight="9":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/data-binding/Parent1.razor" highlight="9":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

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

:::moniker-end

By convention, a property can be bound to a corresponding event handler by including an `@bind-{PROPERTY}:event` attribute assigned to the handler, where the `{PROPERTY}` placeholder is the property. `<ChildBind @bind-Year="year" />` is equivalent to writing:

```razor
<ChildBind @bind-Year="year" @bind-Year:event="YearChanged" />
```

In a more sophisticated and real-world example, the following `PasswordEntry` component:

* Sets an `<input>` element's value to a `password` field.
* Exposes changes of a `Password` property to a parent component with an [`EventCallback`](xref:blazor/components/event-handling#eventcallback) that passes in the current value of the child's `password` field as its argument.
* Uses the `onclick` event to trigger the `ToggleShowPassword` method. For more information, see <xref:blazor/components/event-handling>.

`PasswordEntry.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/PasswordEntry.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/data-binding/PasswordEntry.razor" highlight="7-10,13,23-24,26-27,36-39":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/data-binding/PasswordEntry.razor" highlight="7-10,13,23-24,26-27,36-39":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/data-binding/PasswordEntry.razor" highlight="7-10,13,23-24,26-27,36-39":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/data-binding/PasswordEntry.razor" highlight="7-10,13,23-24,26-27,36-39":::

:::moniker-end

The `PasswordEntry` component is used in another component, such as the following `PasswordBinding` component example.

`PasswordBinding.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/PasswordBinding.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/data-binding/PasswordBinding.razor" highlight="5":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/data-binding/PasswordBinding.razor" highlight="5":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/data-binding/PasswordBinding.razor" highlight="5":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/data-binding/PasswordBinding.razor" highlight="5":::

:::moniker-end

When the `PasswordBinding` component is initially rendered, the `password` value of `Not set` is displayed in the UI. After initial rendering, the value of `password` reflects changes made to the `Password` component parameter value in the `PasswordEntry` component.

> [!NOTE]
> The preceding example binds the password one-way from the child `PasswordEntry` component to the parent `PasswordBinding` component. Two-way binding isn't a requirement in this scenario if the goal is for the app to have a shared password entry component for reuse around the app that merely passes the password to the parent. For an approach that permits two-way binding without [writing directly to the child component's parameter](xref:blazor/components/overwriting-parameters), see the `NestedChild` component example in the [Bind across more than two components](#bind-across-more-than-two-components) section of this article.

Perform checks or trap errors in the handler. The following revised `PasswordEntry` component provides immediate feedback to the user if a space is used in the password's value.

`PasswordEntry.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/PasswordEntry2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/data-binding/PasswordEntry2.razor" highlight="35-46":::

In the following example, the `PasswordUpdated` method executes asynchronously after binding the `Password` component parameter:

```razor
<PasswordEntry @bind-Password="password" @bind-Password:after="PasswordUpdated" />
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/data-binding/PasswordEntry2.razor" highlight="35-46":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/data-binding/PasswordEntry2.razor" highlight="35-46":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/data-binding/PasswordEntry2.razor" highlight="35-46":::

:::moniker-end

## Bind across more than two components

You can bind parameters through any number of nested components, but you must respect the one-way flow of data:

* Change notifications *flow up the hierarchy*.
* New parameter values *flow down the hierarchy*.

A common and recommended approach is to only store the underlying data in the parent component to avoid any confusion about what state must be updated, as shown in the following example.

`Parent2.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Parent2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/data-binding/Parent2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Pages/data-binding/Parent2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Pages/data-binding/Parent2.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Pages/data-binding/Parent2.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

In the following `NestedChild` component, the `NestedGrandchild` component:

* Assigns the value of `ChildMessage` to `GrandchildMessage` with `@bind:get` syntax.
* Updates `GrandchildMessage` when `ChildMessageChanged` executes with `@bind:set` syntax.

:::moniker-end

`NestedChild.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/NestedChild.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/data-binding/NestedChild.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/data-binding/NestedChild.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/data-binding/NestedChild.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/data-binding/NestedChild.razor":::

:::moniker-end

:::moniker range="< aspnetcore-7.0"

> [!WARNING]
> Generally, avoid creating components that write directly to their own component parameters. The preceding `NestedChild` component makes use of a `BoundValue` property instead of writing directly to its `ChildMessage` parameter. For more information, see <xref:blazor/components/overwriting-parameters>.

:::moniker-end

`NestedGrandchild.razor`:

:::moniker range=">= aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/NestedGrandchild.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Shared/data-binding/NestedGrandchild.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="razor" source="~/../blazor-samples/6.0/BlazorSample_WebAssembly/Shared/data-binding/NestedGrandchild.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-5.0 < aspnetcore-6.0"

:::code language="razor" source="~/../blazor-samples/5.0/BlazorSample_WebAssembly/Shared/data-binding/NestedGrandchild.razor":::

:::moniker-end

:::moniker range="< aspnetcore-5.0"

:::code language="razor" source="~/../blazor-samples/3.1/BlazorSample_WebAssembly/Shared/data-binding/NestedGrandchild.razor":::

:::moniker-end

For an alternative approach suited to sharing data in memory and across components that aren't necessarily nested, see <xref:blazor/state-management>.

## Additional resources

* [Parameter change detection and additional guidance on Razor component rendering](xref:blazor/components/rendering)
* <xref:blazor/forms/index>
* [Binding to radio buttons in a form](xref:blazor/forms/binding#radio-buttons)
* [Binding `InputSelect` options to C# object `null` values](xref:blazor/forms/binding#binding-inputselect-options-to-c-object-null-values)
* [ASP.NET Core Blazor event handling: `EventCallback` section](xref:blazor/components/event-handling#eventcallback)
* [Blazor samples GitHub repository (`dotnet/blazor-samples`)](https://github.com/dotnet/blazor-samples)
