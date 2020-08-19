---
title: ASP.NET Core Blazor data binding
author: guardrex
description: Learn about data binding features for components and DOM elements in Blazor apps.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 08/19/2020
no-loc: ["ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: blazor/components/data-binding
---
# ASP.NET Core Blazor data binding

By [Luke Latham](https://github.com/guardrex) and [Daniel Roth](https://github.com/danroth27)

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

When one of the elements looses focus, its bound field or property is updated.

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

Use `@bind-{ATTRIBUTE}` with `@bind-{ATTRIBUTE}:event` syntax to bind element attributes other than `value`. In the following example:

* The paragraph's style is **red** when the component loads (`style="color:red"`).
* The user changes the value of the text box to reflect a different CSS color style and changes the page's element focus. For example, the user changes the text box value to `color:blue` and presses the <kbd>Tab</kbd> key on the keyboard.
* When the element focus changes:
  * The value of `paragraphStyle` is assigned from the `<input>` element's value.
  * The paragraph style is updated to reflect the new style in `paragraphStyle`. If the style is updated to `color:blue`, the text color changes to **blue**.

```razor
<p>
    <input type="text" @bind="paragraphStyle" />
</p>

<p @bind-style="paragraphStyle" @bind-style:event="onchange">
    Blazorify the app!
</p>

@code {
    private string paragraphStyle = "color:red";
}
```

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

## Parent-to-child binding with component parameters

Component parameters permit binding properties and fields of a parent component with `@bind-{PROPERTY OR FIELD}` syntax.

The following `Child` component (`Child.razor`) has a `Year` component parameter and `YearChanged` callback:

```razor
<div class="card bg-light mt-3" style="width:18rem ">
    <div class="card-body">
        <h3 class="card-title">Child Component</h3>
        <p class="card-text">Child <code>Year</code>: @Year</p>
        <p>
            <button @onclick="UpdateYear">
                Update Child <code>Year</code> and call 
                <code>YearChanged.InvokeAsync(Year)</code>
            </button>
        </p>
    </div>
</div>

@code {
    private Random r = new Random();

    [Parameter]
    public int Year { get; set; }

    [Parameter]
    public EventCallback<int> YearChanged { get; set; }

    private Task UpdateYear()
    {
        Year = r.Next(10050, 12021);

        return YearChanged.InvokeAsync(Year);
    }
}
```

The callback (<xref:Microsoft.AspNetCore.Components.EventCallback%601>) must be named as the component parameter name followed by the "`Changed`" suffix (`{PARAMETER NAME}Changed`). In the preceding example, the callback is named `YearChanged`. For more information on <xref:Microsoft.AspNetCore.Components.EventCallback%601>, see <xref:blazor/components/event-handling#eventcallback>.

In the following `Parent` component (`Parent.razor`), the `year` field is bound to the `Year` parameter of the child component:

```razor
@page "/Parent"

<h1>Parent Component</h1>

<p>Parent <code>year</code>: @year</p>

<button @onclick="UpdateYear">Update Parent <code>year</code></button>

<Child @bind-Year="year" />

@code {
    private Random r = new Random();
    private int year = 1978;

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

## Child-to-parent binding with chained bind

A common scenario is chaining a data-bound parameter to a page element in the component's output. This scenario is called a *chained bind* because multiple levels of binding occur simultaneously.

A chained bind can't be implemented with [`@bind`](xref:mvc/views/razor#bind) syntax in the child component. The event handler and value must be specified separately. A parent component, however, can use [`@bind`](xref:mvc/views/razor#bind) syntax with the child component's parameter.

The following `PasswordField` component (`PasswordField.razor`):

* Sets an `<input>` element's value to a `Password` property.
* Exposes changes of the `Password` property to a parent component with an [`EventCallback`](xref:blazor/components/event-handling#eventcallback).
* Uses the `onclick` event to trigger the `ToggleShowPassword` method. For more information, see <xref:blazor/components/event-handling>.

```razor
<h1>Child Component</h1>

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
@page "/Parent"

<h1>Parent Component</h1>

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
<h1>Child Component</h1>

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

## Additional resources

* [Binding to radio buttons in a form](xref:blazor/forms-validation#radio-buttons)
* [Binding `<select>` element options to C# object `null` values in a form](xref:blazor/forms-validation#binding-select-element-options-to-c-object-null-values)
