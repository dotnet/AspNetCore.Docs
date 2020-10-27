---
title: ASP.NET Core Blazor data binding
author: guardrex
description: Learn about data binding features for components and DOM elements in Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 10/22/2020
no-loc: [appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/components/data-binding
---
# ASP.NET Core Blazor data binding

By [Luke Latham](https://github.com/guardrex), [Daniel Roth](https://github.com/danroth27), and [Steve Sanderson](https://github.com/SteveSandersonMS)

Razor components provide data binding features via an HTML element attribute named [`@bind`](xref:mvc/views/razor#bind) with a field, property, or Razor expression value.

The following example binds an `<input>` element to the `currentValue` field and an `<input>` element to the `CurrentValue` property:

```razor
<p>
    <input @bind="currentValue" /> Current value: @currentValue
</p>

<p>
    <input @bind="CurrentValue" /> Current value: @CurrentValue
</p>

@code {
    private string currentValue;

    private string CurrentValue { get; set; }
}
```

When one of the elements loses focus, its bound field or property is updated.

The text box is updated in the UI only when the component is rendered, not in response to changing the field's or property's value. Since components render themselves after event handler code executes, field and property updates are *usually* reflected in the UI immediately after an event handler is triggered.

Using [`@bind`](xref:mvc/views/razor#bind) with the `CurrentValue` property (`<input @bind="CurrentValue" />`) is essentially equivalent to the following:

```razor
<input value="@CurrentValue"
    @onchange="@((ChangeEventArgs __e) => CurrentValue = 
        __e.Value.ToString())" />

@code {
    private string CurrentValue { get; set; }
}
```

When the component is rendered, the `value` of the input element comes from the `CurrentValue` property. When the user types in the text box and changes element focus, the `onchange` event is fired and the `CurrentValue` property is set to the changed value. In reality, the code generation is more complex than that because [`@bind`](xref:mvc/views/razor#bind) handles cases where type conversions are performed. In principle, [`@bind`](xref:mvc/views/razor#bind) associates the current value of an expression with a `value` attribute and handles changes using the registered handler.

Bind a property or field on other events by also including an `@bind:event` attribute with an `event` parameter. The following example binds the `CurrentValue` property on the `oninput` event:

```razor
<input @bind="CurrentValue" @bind:event="oninput" />

@code {
    private string CurrentValue { get; set; }
}
```

Unlike `onchange`, which fires when the element loses focus, `oninput` fires when the value of the text box changes.

<!-- Hold location for resolution of https://github.com/dotnet/AspNetCore.Docs/issues/19721 -->

Attribute binding is case sensitive:

* `@bind` is valid.
* `@Bind` and `@BIND` are invalid.

## Unparsable values

When a user provides an unparsable value to a databound element, the unparsable value is automatically reverted to its previous value when the bind event is triggered.

Consider the following scenario:

* An `<input>` element is bound to an `int` type with an initial value of `123`:

  ```razor
  <input @bind="inputValue" />

  @code {
      private int inputValue = 123;
  }
  ```

* The user updates the value of the element to `123.45` in the page and changes the element focus.

In the preceding scenario, the element's value is reverted to `123`. When the value `123.45` is rejected in favor of the original value of `123`, the user understands that their value wasn't accepted.

By default, binding applies to the element's `onchange` event (`@bind="{PROPERTY OR FIELD}"`). Use `@bind="{PROPERTY OR FIELD}" @bind:event={EVENT}` to trigger binding on a different event. For the `oninput` event (`@bind:event="oninput"`), the reversion occurs after any keystroke that introduces an unparsable value. When targeting the `oninput` event with an `int`-bound type, a user is prevented from typing a `.` character. A `.` character is immediately removed, so the user receives immediate feedback that only whole numbers are permitted. There are scenarios where reverting the value on the `oninput` event isn't ideal, such as when the user should be allowed to clear an unparsable `<input>` value. Alternatives include:

* Don't use the `oninput` event. Use the default `onchange` event (only specify `@bind="{PROPERTY OR FIELD}"`), where an invalid value isn't reverted until the element loses focus.
* Bind to a nullable type, such as `int?` or `string` and provide custom logic to handle invalid entries.
* Use a [form validation component](xref:blazor/forms-validation), such as <xref:Microsoft.AspNetCore.Components.Forms.InputNumber%601> or <xref:Microsoft.AspNetCore.Components.Forms.InputDate%601>. Form validation components have built-in support to manage invalid inputs. For more information, see <xref:blazor/forms-validation>. Form validation components:
  * Permit the user to provide invalid input and receive validation errors on the associated <xref:Microsoft.AspNetCore.Components.Forms.EditContext>.
  * Display validation errors in the UI without interfering with the user entering additional webform data.

## Format strings

Data binding works with <xref:System.DateTime> format strings using `@bind:format`. Other format expressions, such as currency or number formats, aren't available at this time.

```razor
<input @bind="startDate" @bind:format="yyyy-MM-dd" />

@code {
    private DateTime startDate = new DateTime(2020, 1, 1);
}
```

In the preceding code, the `<input>` element's field type (`type`) defaults to `text`. `@bind:format` is supported for binding the following .NET types:

* <xref:System.DateTime?displayProperty=fullName>
* <xref:System.DateTime?displayProperty=fullName>?
* <xref:System.DateTimeOffset?displayProperty=fullName>
* <xref:System.DateTimeOffset?displayProperty=fullName>?

The `@bind:format` attribute specifies the date format to apply to the `value` of the `<input>` element. The format is also used to parse the value when an `onchange` event occurs.

Specifying a format for the `date` field type isn't recommended because Blazor has built-in support to format dates. In spite of the recommendation, only use the `yyyy-MM-dd` date format for binding to function correctly if a format is supplied with the `date` field type:

```razor
<input type="date" @bind="startDate" @bind:format="yyyy-MM-dd">
```

## Binding with component parameters

A common scenario is binding a property in a child component to a property in its parent. This scenario is called a *chained bind* because multiple levels of binding occur simultaneously.

Component parameters permit binding properties and fields of a parent component with `@bind-{PROPERTY OR FIELD}` syntax.

Chained binds can't be implemented with [`@bind`](xref:mvc/views/razor#bind) syntax in the child component. An event handler and value must be specified separately to support updating the property in the parent from the child component.

The parent component still leverages the [`@bind`](xref:mvc/views/razor#bind) syntax to set up the data-binding with the child component.

The following `Child` component (`Shared/Child.razor`) has a `Year` component parameter and `YearChanged` callback:

```razor
<div class="card bg-light mt-3" style="width:18rem ">
    <div class="card-body">
        <h3 class="card-title">Child Component</h3>
        <p class="card-text">Child <code>Year</code>: @Year</p>
    </div>
</div>

<button @onclick="UpdateYearFromChild">Update Year from Child</button>

@code {
    private Random r = new Random();

    [Parameter]
    public int Year { get; set; }

    [Parameter]
    public EventCallback<int> YearChanged { get; set; }

    private async Task UpdateYearFromChild()
    {
        await YearChanged.InvokeAsync(r.Next(1950, 2021));
    }
}
```

The callback (<xref:Microsoft.AspNetCore.Components.EventCallback%601>) must be named as the component parameter name followed by the "`Changed`" suffix (`{PARAMETER NAME}Changed`). In the preceding example, the callback is named `YearChanged`. <xref:Microsoft.AspNetCore.Components.EventCallback.InvokeAsync%2A?displayProperty=nameWithType> invokes the delegate associated with the binding with the provided argument and dispatches an event notification for the changed property.

In the following `Parent` component (`Parent.razor`), the `year` field is bound to the `Year` parameter of the child component:

```razor
@page "/Parent"

<h1>Parent Component</h1>

<p>Parent <code>year</code>: @year</p>

<button @onclick="UpdateYear">Update Parent <code>year</code></button>

<Child @bind-Year="year" />

@code {
    private Random r = new Random();
    private int year = 1979;

    private void UpdateYear()
    {
        year = r.Next(1950, 2021);
    }
}
```

The `Year` parameter is bindable because it has a companion `YearChanged` event that matches the type of the `Year` parameter.

By convention, a property can be bound to a corresponding event handler by including an `@bind-{PROPERTY}:event` attribute assigned to the handler. `<Child @bind-Year="year" />` is equivalent to writing:

```razor
<Child @bind-Year="year" @bind-Year:event="YearChanged" />
```

In a more sophisticated and real-world example, the following `PasswordField` component (`PasswordField.razor`):

* Sets an `<input>` element's value to a `password` field.
* Exposes changes of a `Password` property to a parent component with an [`EventCallback`](xref:blazor/components/event-handling#eventcallback) that passes in the current value of the child's `password` field as its argument.
* Uses the `onclick` event to trigger the `ToggleShowPassword` method. For more information, see <xref:blazor/components/event-handling>.

```razor
<h1>Provide your password</h1>

Password:

<input @oninput="OnPasswordChanged" 
       required 
       type="@(showPassword ? "text" : "password")" 
       value="@password" />

<button class="btn btn-primary" @onclick="ToggleShowPassword">
    Show password
</button>

@code {
    private bool showPassword;
    private string password;

    [Parameter]
    public string Password { get; set; }

    [Parameter]
    public EventCallback<string> PasswordChanged { get; set; }

    private async Task OnPasswordChanged(ChangeEventArgs e)
    {
        password = e.Value.ToString();

        await PasswordChanged.InvokeAsync(password);
    }

    private void ToggleShowPassword()
    {
        showPassword = !showPassword;
    }
}
```

The `PasswordField` component is used in another component:

```razor
@page "/Parent"

<h1>Parent Component</h1>

<PasswordField @bind-Password="password" />

@code {
    private string password;
}
```

Perform checks or trap errors in the method that invokes the binding's delegate. The following example provides immediate feedback to the user if a space is used in the password's value:

```razor
<h1>Child Component</h1>

Password: 

<input @oninput="OnPasswordChanged" 
       required 
       type="@(showPassword ? "text" : "password")" 
       value="@password" />

<button class="btn btn-primary" @onclick="ToggleShowPassword">
    Show password
</button>

<span class="text-danger">@validationMessage</span>

@code {
    private bool showPassword;
    private string password;
    private string validationMessage;

    [Parameter]
    public string Password { get; set; }

    [Parameter]
    public EventCallback<string> PasswordChanged { get; set; }

    private Task OnPasswordChanged(ChangeEventArgs e)
    {
        password = e.Value.ToString();

        if (password.Contains(' '))
        {
            validationMessage = "Spaces not allowed!";

            return Task.CompletedTask;
        }
        else
        {
            validationMessage = string.Empty;

            return PasswordChanged.InvokeAsync(password);
        }
    }

    private void ToggleShowPassword()
    {
        showPassword = !showPassword;
    }
}
```

For more information on <xref:Microsoft.AspNetCore.Components.EventCallback%601>, see <xref:blazor/components/event-handling#eventcallback>.

## Bind across more than two components

You can bind through any number of nested components, but you must respect the one-way flow of data:

* Change notifications *flow up the hierarchy*.
* New parameter values *flow down the hierarchy*.

A common and recommended approach is to only store the underlying data in the parent component to avoid any confusion about what state must be updated.

The following components demonstrate the preceding concepts:

`ParentComponent.razor`:

```razor
<h1>Parent Component</h1>

<p>Parent Property: <b>@parentValue</b></p>

<p>
    <button @onclick="ChangeValue">Change from Parent</button>
</p>

<ChildComponent @bind-Property="parentValue" />

@code {
    private string parentValue = "Initial value set in Parent";

    private void ChangeValue()
    {
        parentValue = $"Set in Parent {DateTime.Now}";
    }
}
```

`ChildComponent.razor`:

```razor
<div class="border rounded m-1 p-1">
    <h2>Child Component</h2>

    <p>Child Property: <b>@Property</b></p>

    <p>
        <button @onclick="ChangeValue">Change from Child</button>
    </p>

    <GrandchildComponent @bind-Property="BoundValue" />
</div>

@code {
    [Parameter]
    public string Property { get; set; }

    [Parameter]
    public EventCallback<string> PropertyChanged { get; set; }

    private string BoundValue
    {
        get => Property;
        set => PropertyChanged.InvokeAsync(value);
    }

    private async Task ChangeValue()
    {
        await PropertyChanged.InvokeAsync($"Set in Child {DateTime.Now}");
    }
}
```

`GrandchildComponent.razor`:

```razor
<div class="border rounded m-1 p-1">
    <h3>Grandchild Component</h3>

    <p>Grandchild Property: <b>@Property</b></p>

    <p>
        <button @onclick="ChangeValue">Change from Grandchild</button>
    </p>
</div>

@code {
    [Parameter]
    public string Property { get; set; }

    [Parameter]
    public EventCallback<string> PropertyChanged { get; set; }

    private async Task ChangeValue()
    {
        await PropertyChanged.InvokeAsync($"Set in Grandchild {DateTime.Now}");
    }
}
```

For an alternative approach suited to sharing data in-memory across components that aren't necessarily nested, see <xref:blazor/state-management#in-memory-state-container-service>.

## Additional resources

* [Binding to radio buttons in a form](xref:blazor/forms-validation#radio-buttons)
* [Binding `<select>` element options to C# object `null` values in a form](xref:blazor/forms-validation#binding-select-element-options-to-c-object-null-values)
