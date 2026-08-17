---
title: ASP.NET Core Blazor forms validation
ai-usage: ai-assisted
author: guardrex
description: Learn how to use validation in Blazor forms.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.date: 08/17/2026
uid: blazor/forms/validation
---
# ASP.NET Core Blazor forms validation

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how to validate user input in Blazor forms.

Blazor validates a form's model using [data annotations attributes](xref:System.ComponentModel.DataAnnotations), the same attributes used elsewhere in ASP.NET Core. Most forms only require adding a <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component to an <xref:Microsoft.AspNetCore.Components.Forms.EditForm> and annotating the model.

More advanced scenarios are covered in separate articles:

:::moniker range=">= aspnetcore-11.0"

* <xref:blazor/forms/validation-client-side>: How forms that use static server-side rendering (static SSR) are validated in the browser before submission.
* <xref:blazor/forms/validation-advanced>: Driving validation directly with <xref:Microsoft.AspNetCore.Components.Forms.EditContext>, writing validator components, and remote validation.
* <xref:fundamentals/validation>: Behavior shared with Minimal APIs, including writing custom rules, validating nested objects and collections, and localizing messages.

:::moniker-end

:::moniker range="= aspnetcore-10.0"

* <xref:blazor/forms/validation-advanced>: Driving validation directly with <xref:Microsoft.AspNetCore.Components.Forms.EditContext>, writing validator components, and remote validation.
* <xref:fundamentals/validation>: Behavior shared with Minimal APIs, including validating nested objects and collections.

:::moniker-end

:::moniker range="< aspnetcore-10.0"

* <xref:blazor/forms/validation-advanced>: Driving validation directly with <xref:Microsoft.AspNetCore.Components.Forms.EditContext>, writing validator components, and remote validation.

:::moniker-end

## Validate a form with data annotations

To validate a form:

1. Annotate the model's properties with [validation attributes](xref:mvc/models/validation#built-in-attributes).
1. Add a <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component inside the <xref:Microsoft.AspNetCore.Components.Forms.EditForm> component.
1. Display errors with <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> or <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessage%601> components.

The following model uses the <xref:System.ComponentModel.DataAnnotations.RequiredAttribute> and <xref:System.ComponentModel.DataAnnotations.RangeAttribute> attributes:

```csharp
using System.ComponentModel.DataAnnotations;

public class Starship
{
    [Required]
    public string? Identifier { get; set; }

    [Range(1, 10, ErrorMessage = "Accommodation must be between 1 and 10.")]
    public int MaximumAccommodation { get; set; }
}
```

The following form validates the model. The <xref:Microsoft.AspNetCore.Components.Forms.EditForm.OnValidSubmit%2A> callback is only invoked when validation passes:

```razor
<EditForm Model="Model" OnValidSubmit="Submit">
    <DataAnnotationsValidator />
    <ValidationSummary />

    <p>
        <label>
            Identifier:
            <InputText @bind-Value="Model!.Identifier" />
        </label>
        <ValidationMessage For="() => Model!.Identifier" />
    </p>
    <p>
        <label>
            Maximum Accommodation:
            <InputNumber @bind-Value="Model!.MaximumAccommodation" />
        </label>
        <ValidationMessage For="() => Model!.MaximumAccommodation" />
    </p>

    <button type="submit">Submit</button>
</EditForm>

@code {
    private Starship? Model { get; set; }

    protected override void OnInitialized() => Model ??= new();

    private void Submit() { /* Process the valid form. */ }
}
```

Without a <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component, the model's validation attributes have no effect on the form.

### When validation runs

Blazor performs two types of validation:

* *Field validation* runs when the user changes a field and moves out of it. The <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component associates all reported validation results with that field.
* *Model validation* runs when the form is submitted. The <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component determines the field for each result from the member name that the result reports. Results that aren't associated with an individual member are associated with the model rather than a field.

:::moniker range=">= aspnetcore-10.0"

## `DataAnnotationsValidator` validation behavior

The <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component has the same validation order and short-circuiting behavior as <xref:System.ComponentModel.DataAnnotations.Validator?displayProperty=nameWithType>. The following rules are applied when validating an instance of type `T`:

1. Member properties of `T` are validated, including recursively validating nested objects.
1. Type-level attributes of `T` are validated.
1. The <xref:System.ComponentModel.DataAnnotations.IValidatableObject.Validate%2A?displayProperty=nameWithType> method is executed, if `T` implements it.

If one of the preceding steps produces a validation error, the remaining steps are skipped.

:::moniker-end

## Data Annotations Validator component and custom validation

The <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component attaches data annotations validation to a cascaded <xref:Microsoft.AspNetCore.Components.Forms.EditContext>. Enabling data annotations validation requires the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component. To use a different validation system than data annotations, use a custom implementation instead of the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component. The framework implementations for <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> are available for inspection in the reference source:

* [`DataAnnotationsValidator`](https://github.com/dotnet/AspNetCore/blob/main/src/Components/Forms/src/DataAnnotationsValidator.cs)
* [`EnableDataAnnotationsValidation`](https://github.com/dotnet/AspNetCore/blob/main/src/Components/Forms/src/EditContextDataAnnotationsExtensions.cs)

If you need to enable data annotations validation support for an <xref:Microsoft.AspNetCore.Components.Forms.EditContext> in code, call <xref:Microsoft.AspNetCore.Components.Forms.EditContextDataAnnotationsExtensions.EnableDataAnnotationsValidation%2A> with an injected <xref:System.IServiceProvider> (`@inject IServiceProvider ServiceProvider`) on the <xref:Microsoft.AspNetCore.Components.Forms.EditContext>. For an advanced example, see the [`NotifyPropertyChangedValidationComponent` component in the ASP.NET Core Blazor framework's `BasicTestApp` (`dotnet/aspnetcore` GitHub repository)](https://github.com/dotnet/aspnetcore/blob/main/src/Components/test/testassets/BasicTestApp/FormsTest/NotifyPropertyChangedValidationComponent.razor). In a production version of the example, replace the `new TestServiceProvider()` argument for the service provider with an injected <xref:System.IServiceProvider>.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

In custom validation scenarios:

* Validation manages a <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessageStore> for a form's <xref:Microsoft.AspNetCore.Components.Forms.EditContext>.
* The <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component is used to attach validation support to forms based on [validation attributes (data annotations)](xref:mvc/models/validation#validation-attributes).

Two general approaches are available for validation logic that isn't declared on the model, both described in <xref:blazor/forms/validation-advanced>:

* Manual validation using the <xref:Microsoft.AspNetCore.Components.Forms.EditContext.OnValidationRequested%2A> event: Manually validate a form's fields with data annotations validation and custom code for field checks when validation is requested via an event handler assigned to the event.
* Validator components: One or more custom validator components can be used to process validation for different forms on the same page or the same form at different steps of form processing (for example, client validation followed by server-side validation in a Blazor Web App).

## Validation Summary and Validation Message components

The <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> component summarizes all validation messages, which is similar to the [Validation Summary Tag Helper](xref:mvc/views/working-with-forms#the-validation-summary-tag-helper):

```razor
<ValidationSummary />
```

Output validation messages for a specific model with the `Model` parameter:
  
```razor
<ValidationSummary Model="Model" />
```

The <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessage%601> component displays validation messages for a specific field, which is similar to the [Validation Message Tag Helper](xref:mvc/views/working-with-forms#the-validation-message-tag-helper). Specify the field for validation with the <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessage%601.For%2A> attribute and a lambda expression naming the model property:

```razor
<ValidationMessage For="@(() => Model!.MaximumAccommodation)" />
```

The <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessage%601> and <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> components support arbitrary attributes. Any attribute that doesn't match a component parameter is added to the generated `<div>` or `<ul>` element. If a class attribute is supplied, its value replaces the component's default CSS class.

Control the style of validation messages in the app's stylesheet (`wwwroot/css/app.css` or `wwwroot/css/site.css`). The default `validation-message` class sets the text color of validation messages to red:

```css
.validation-message {
    color: red;
}
```

:::moniker range=">= aspnetcore-8.0"

## Determine if a form field is valid

Use <xref:Microsoft.AspNetCore.Components.Forms.EditContext.IsValid%2A?displayProperty=nameWithType> to determine if a field is valid without obtaining validation messages.

<span aria-hidden="true">❌</span> Supported, but not recommended:

```csharp
var isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();
```

<span aria-hidden="true">✔️</span> Recommended:

```csharp
var isValid = editContext.IsValid(fieldIdentifier);
```

:::moniker-end

## Choose the validation your form needs

The default configuration validates the top-level properties of the form's model. Some scenarios require additional setup. Use the following table to find the guidance for a goal:

:::moniker range=">= aspnetcore-11.0"

| Goal | What to do |
|---|---|
| Validate top-level properties with built-in attributes | Nothing further. Add a <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component to the form, as shown earlier in this article. |
| Express a rule that built-in attributes can't | Write a [custom validation attribute or implement `IValidatableObject`](xref:fundamentals/validation#write-custom-validation-rules). For validation logic that isn't declared on the model, see <xref:blazor/forms/validation-advanced>. |
| Validate properties of nested objects and collection items | Call `AddValidation` and annotate the root model type. See <xref:fundamentals/validation#nested-objects-and-collections>. |
| Validate against a database or web API | Use [asynchronous validation](xref:fundamentals/validation#asynchronous-validation-support), or a [validator component](xref:blazor/forms/validation-advanced). |
| Display error messages in the user's language | See [Localize validation messages](xref:fundamentals/validation#localize-validation-messages). |
| Give immediate feedback in a static SSR form | Supported automatically. See <xref:blazor/forms/validation-client-side>. |

:::moniker-end

:::moniker range="= aspnetcore-10.0"

| Goal | What to do |
|---|---|
| Validate top-level properties with built-in attributes | Nothing further. Add a <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component to the form, as shown earlier in this article. |
| Express a rule that built-in attributes can't | Write a [custom validation attribute](xref:mvc/models/validation#custom-attributes) or implement [`IValidatableObject`](xref:mvc/models/validation#ivalidatableobject). For validation logic that isn't declared on the model, see <xref:blazor/forms/validation-advanced>. |
| Validate properties of nested objects and collection items | Call `AddValidation` and annotate the root model type. See <xref:fundamentals/validation#nested-objects-and-collections>. |
| Validate against a database or web API | Use a [validator component](xref:blazor/forms/validation-advanced). |

:::moniker-end

:::moniker range="< aspnetcore-10.0"

| Goal | What to do |
|---|---|
| Validate top-level properties with built-in attributes | Nothing further. Add a <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component to the form, as shown earlier in this article. |
| Express a rule that built-in attributes can't | Write a [custom validation attribute](xref:mvc/models/validation#custom-attributes) or implement [`IValidatableObject`](xref:mvc/models/validation#ivalidatableobject). For validation logic that isn't declared on the model, see <xref:blazor/forms/validation-advanced>. |
| Validate properties of nested objects and collection items | See [Nested objects, collection types, and complex types](#nested-objects-collection-types-and-complex-types). |
| Validate against a database or web API | Use a [validator component](xref:blazor/forms/validation-advanced). |

:::moniker-end

:::moniker range=">= aspnetcore-10.0"

### Nested objects and collections require additional configuration

By default, the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component validates the top-level properties of the model. Validation attributes on the properties of a nested object, or on the items of a collection, aren't evaluated.

To validate a nested object graph, opt into <xref:Microsoft.Extensions.Validation?displayProperty=fullName> by calling <xref:Microsoft.Extensions.DependencyInjection.ValidationServiceCollectionExtensions.AddValidation%2A> and annotating the root model type with <xref:Microsoft.Extensions.Validation.ValidatableTypeAttribute>. The model types must be declared in C# files (`.cs`), not in Razor component files (`.razor`).

For the full guidance and an example, see <xref:fundamentals/validation#nested-objects-and-collections>.

> [!WARNING]
> A model that isn't discovered by the validation source generator doesn't produce a build error or a log entry. The form silently validates only the top-level properties, and validation messages are not localized. If nested validation or localization appears to have no effect, see [Validation when `AddValidation` isn't called](xref:fundamentals/validation#validation-when-addvalidation-isnt-called).

:::moniker-end

## Custom validation rules

When the built-in validation attributes can't express a rule, declare the rule on the model with a custom <xref:System.ComponentModel.DataAnnotations.ValidationAttribute> or by implementing <xref:System.ComponentModel.DataAnnotations.IValidatableObject>. Both are executed by the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component wherever the form runs.

:::moniker range=">= aspnetcore-10.0"

For guidance on writing these rules, which is shared with Minimal APIs, see <xref:fundamentals/validation#write-custom-validation-rules>.

:::moniker-end

:::moniker range="< aspnetcore-10.0"

For guidance on writing these rules, see [Custom attributes](xref:mvc/models/validation#custom-attributes) and [`IValidatableObject`](xref:mvc/models/validation#ivalidatableobject).

:::moniker-end

When validation logic can't be declared on the model, for example when messages come from a web API response, use a validator component or drive validation directly with <xref:Microsoft.AspNetCore.Components.Forms.EditContext>. See <xref:blazor/forms/validation-advanced>.

Of the [built-in data annotations validators](xref:mvc/models/validation#built-in-attributes), only the [`[Remote]` validation attribute](xref:mvc/models/validation#remote-attribute) isn't supported in Blazor.

### Associate a validation result with a field

To ensure that a validation result is correctly associated with a field when using a [custom validation attribute](xref:mvc/models/validation#custom-attributes), pass the validation context's <xref:System.ComponentModel.DataAnnotations.ValidationContext.MemberName> when creating the <xref:System.ComponentModel.DataAnnotations.ValidationResult>. Without a member name, the message is associated with the model rather than the field, so it doesn't appear in the field's <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessage%601> component.

`CustomValidator.cs`:

:::moniker range=">= aspnetcore-8.0"

```csharp
using System;
using System.ComponentModel.DataAnnotations;

public class CustomValidator : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, 
        ValidationContext validationContext)
    {
        ...

        return new ValidationResult("Validation message to user.",
            [ validationContext.MemberName! ]);
    }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

```csharp
using System;
using System.ComponentModel.DataAnnotations;

public class CustomValidator : ValidationAttribute
{
    protected override ValidationResult IsValid(object? value, 
        ValidationContext validationContext)
    {
        ...

        return new ValidationResult("Validation message to user.",
            new[] { validationContext.MemberName! });
    }
}
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
using System;
using System.ComponentModel.DataAnnotations;

public class CustomValidator : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, 
        ValidationContext validationContext)
    {
        ...

        return new ValidationResult("Validation message to user.",
            new[] { validationContext.MemberName });
    }
}
```

:::moniker-end

### Inject services into a custom validation attribute

Inject services into custom validation attributes through the <xref:System.ComponentModel.DataAnnotations.ValidationContext>. The following example demonstrates a salad chef form that validates user input with dependency injection (DI).

The `SaladChef` class indicates the approved starship ingredient list for a Ten Forward salad.

`SaladChef.cs`:

:::code language="csharp" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/SaladChef.cs":::

Register `SaladChef` in the app's DI container in the `Program` file:

```csharp
builder.Services.AddTransient<SaladChef>();
```

The `IsValid` method of the following `SaladChefValidatorAttribute` class obtains the `SaladChef` service from DI to check the user's input.

`SaladChefValidatorAttribute.cs`:

:::code language="csharp" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/SaladChefValidatorAttribute.cs":::

The following component validates user input by applying the `SaladChefValidatorAttribute` (`[SaladChefValidator]`) to the salad ingredient string (`SaladIngredient`).

`Starship12.razor`:

:::moniker range=">= aspnetcore-9.0"

:::code language="razor" source="~/../blazor-samples/9.0/BlazorSample_BlazorWebApp/Components/Pages/Starship12.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-9.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Starship12.razor":::

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@page "/starship-12"
@inject SaladChef SaladChef

<EditForm Model="this" autocomplete="off">
    <DataAnnotationsValidator />
    <p>
        <label>
            Salad topper (@saladToppers):
            <input @bind="SaladIngredient" />
        </label>
    </p>
    <button type="submit">Submit</button>
    <ul>
        @foreach (var message in context.GetValidationMessages())
        {
            <li class="validation-message">@message</li>
        }
    </ul>
</EditForm>

@code {
    private string? saladToppers;

    [SaladChefValidator]
    public string? SaladIngredient { get; set; }

    protected override void OnInitialized() => 
        saladToppers ??= string.Join(", ", SaladChef.SaladToppers);
}
```

:::moniker-end

## Class-level validation with `IValidatableObject`

[Class-level validation with `IValidatableObject`](xref:mvc/models/validation#ivalidatableobject) ([API documentation](xref:System.ComponentModel.DataAnnotations.IValidatableObject)) is supported for Blazor form models. <xref:System.ComponentModel.DataAnnotations.IValidatableObject> validation only executes when the form is submitted and only if all other validation succeeds.

:::moniker range="< aspnetcore-10.0"

## Nested objects, collection types, and complex types

> [!NOTE]
> For apps targeting .NET 10 or later, we no longer recommend using the [`Microsoft.AspNetCore.Components.DataAnnotations.Validation` *experimental* package](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.DataAnnotations.Validation) and approach described in this section. We recommend using the built-in validation features of the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component.

Blazor provides support for validating form input using data annotations with the built-in <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>. However, the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> in .NET 9 or earlier only validates top-level properties of the model bound to the form that aren't collection- or complex-type properties.

To validate the bound model's entire object graph, including collection- and complex-type properties, use the `ObjectGraphDataAnnotationsValidator` provided by the *experimental* [`Microsoft.AspNetCore.Components.DataAnnotations.Validation` package](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.DataAnnotations.Validation) in .NET 9 or earlier:

```razor
<EditForm ...>
    <ObjectGraphDataAnnotationsValidator />
    ...
</EditForm>
```

Annotate model properties with `[ValidateComplexType]`. In the following model classes, the `ShipDescription` class contains additional data annotations to validate when the model is bound to the form:

`Starship.cs`:

```csharp
using System;
using System.ComponentModel.DataAnnotations;

public class Starship
{
    ...

    [ValidateComplexType]
    public ShipDescription ShipDescription { get; set; } = new();

    ...
}
```

`ShipDescription.cs`:

```csharp
using System;
using System.ComponentModel.DataAnnotations;

public class ShipDescription
{
    [Required]
    [StringLength(40, ErrorMessage = "Description too long (40 char).")]
    public string? ShortDescription { get; set; }

    [Required]
    [StringLength(240, ErrorMessage = "Description too long (240 char).")]
    public string? LongDescription { get; set; }
}
```

:::moniker-end

:::moniker range="< aspnetcore-10.0"

## Blazor data annotations validation package

> [!NOTE]
> The [`Microsoft.AspNetCore.Components.DataAnnotations.Validation` package](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.DataAnnotations.Validation) is no longer recommended for apps that target .NET 10 or later. For more information, see the [Nested objects, collection types, and complex types](#nested-objects-collection-types-and-complex-types) section.

The [`Microsoft.AspNetCore.Components.DataAnnotations.Validation` package](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.DataAnnotations.Validation) fills validation experience gaps using the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component. The package is currently *experimental*.

> [!WARNING]
> The [`Microsoft.AspNetCore.Components.DataAnnotations.Validation` package](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.DataAnnotations.Validation) has a latest version of *release candidate* at [NuGet.org](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.DataAnnotations.Validation). Continue to use the *experimental* release candidate package at this time. Experimental features are provided for the purpose of exploring feature viability and may not ship in a stable version. Watch the [Announcements GitHub repository](https://github.com/aspnet/Announcements), the [`dotnet/aspnetcore` GitHub repository](https://github.com/dotnet/aspnetcore), or this topic section for further updates.

:::moniker-end

:::moniker range="< aspnetcore-6.0"

## `[CompareProperty]` attribute

The <xref:System.ComponentModel.DataAnnotations.CompareAttribute> doesn't work well with the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component because the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> doesn't associate the validation result with a specific member. This can result in inconsistent behavior between field-level validation and when the entire model is validated on a submit. The [`Microsoft.AspNetCore.Components.DataAnnotations.Validation` *experimental* package](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.DataAnnotations.Validation) introduces an additional validation attribute, `ComparePropertyAttribute`, that works around these limitations. In a Blazor app, `[CompareProperty]` is a direct replacement for the [`[Compare]` attribute](xref:System.ComponentModel.DataAnnotations.CompareAttribute).

:::moniker-end

:::moniker range=">= aspnetcore-11.0"

## Display pending and faulted validation state

Asynchronous validation, such as a uniqueness check against a database, doesn't complete immediately. Blazor tracks the state of in-flight validation per field so that the UI can show progress and report failures.

To author asynchronous validation rules, see <xref:fundamentals/validation#asynchronous-validation-support> for attribute-based rules, or <xref:blazor/forms/validation-advanced> for validator components.

While an async task is in flight, the field is *pending*. If an async task throws an exception other than <xref:System.OperationCanceledException>, the field is *faulted*. Each state has both a per-field and a form-level query:

| State    | Per-field                                          | Form-level (any field)           |
|----------|----------------------------------------------------|----------------------------------|
| Pending  | `EditContext.IsValidationPending(fieldIdentifier)` | `EditContext.IsValidationPending()` |
| Faulted  | `EditContext.IsValidationFaulted(fieldIdentifier)` | `EditContext.IsValidationFaulted()` |

The per-field overloads accept either a <xref:Microsoft.AspNetCore.Components.Forms.FieldIdentifier> or a `() => model.Property` lambda for convenient use in Razor markup:

```razor
<InputText @bind-Value="Model.Username" />
<ValidationMessage For="() => Model.Username" />

@if (EditContext.IsValidationPending(() => Model.Username))
{
    <span class="spinner" aria-live="polite">Checking&hellip;</span>
}
else if (EditContext.IsValidationFaulted(() => Model.Username))
{
    <span class="validation-faulted" aria-live="polite">
        Validation could not be completed.
    </span>
}
```

The form-level parameterless overloads return `true` when any field is currently pending or faulted. A common use is disabling the submit button while validation is in flight:

```razor
<button type="submit" disabled="@EditContext.IsValidationPending()">
    Register
</button>
```

<xref:Microsoft.AspNetCore.Components.Forms.InputBase%601> automatically adds the `pending` and `faulted` CSS classes to its rendered element while the bound field is in the corresponding state, in addition to the existing `modified` / `valid` / `invalid` classes. The classes compose, so unmodified pending styling and modified pending styling can be targeted independently:

```css
.pending {
    background-image: url('spinner.gif');
    background-repeat: no-repeat;
    background-position: right center;
}

.modified.pending {
    border-color: lightblue;
}

.modified.faulted {
    border-color: orange;
}
```

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

## Custom validation CSS class attributes

Custom validation CSS class attributes are useful when integrating with CSS frameworks, such as [Bootstrap](https://getbootstrap.com/).

To specify custom validation CSS class attributes, start by providing CSS styles for custom validation. In the following example, valid (`validField`) and invalid (`invalidField`) styles are specified.

Add the following CSS classes to the app's stylesheet:

```css
.validField {
    border-color: lawngreen;
}

.invalidField {
    background-color: tomato;
}
```

Create a class derived from <xref:Microsoft.AspNetCore.Components.Forms.FieldCssClassProvider> that checks for field validation messages and applies the appropriate valid or invalid style.

`CustomFieldClassProvider.cs`:

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

```csharp
using Microsoft.AspNetCore.Components.Forms;

public class CustomFieldClassProvider : FieldCssClassProvider
{
    public override string GetFieldCssClass(EditContext editContext, 
        in FieldIdentifier fieldIdentifier)
    {
        var isValid = editContext.IsValid(fieldIdentifier);

        return isValid ? "validField" : "invalidField";
    }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

```csharp
using Microsoft.AspNetCore.Components.Forms;

public class CustomFieldClassProvider : FieldCssClassProvider
{
    public override string GetFieldCssClass(EditContext editContext, 
        in FieldIdentifier fieldIdentifier)
    {
        var isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();

        return isValid ? "validField" : "invalidField";
    }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

<!--
:::code language="csharp" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/CustomFieldClassProvider.cs":::
-->

Set the `CustomFieldClassProvider` class as the Field CSS Class Provider on the form's <xref:Microsoft.AspNetCore.Components.Forms.EditContext> instance with <xref:Microsoft.AspNetCore.Components.Forms.EditContextFieldClassExtensions.SetFieldCssClassProvider%2A>.

`Starship13.razor`:

:::moniker-end

:::moniker range=">= aspnetcore-9.0"

:::code language="razor" source="~/../blazor-samples/9.0/BlazorSample_BlazorWebApp/Components/Pages/Starship13.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-9.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Starship13.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

```razor
@page "/starship-13"
@using System.ComponentModel.DataAnnotations
@inject ILogger<Starship13> Logger

<EditForm EditContext="editContext" OnValidSubmit="Submit">
    <DataAnnotationsValidator />
    <ValidationSummary />
    <InputText @bind-Value="Model!.Id" />
    <button type="submit">Submit</button>
</EditForm>

@code {
    private EditContext? editContext;

    public Starship? Model { get; set; }

    protected override void OnInitialized()
    {
        Model ??= new();
        editContext = new(Model);
        editContext.SetFieldCssClassProvider(new CustomFieldClassProvider());
    }

    private void Submit()
    {
        Logger.LogInformation("Submit called: Processing the form");
    }

    public class Starship
    {
        [Required]
        [StringLength(10, ErrorMessage = "Id is too long.")]
        public string? Id { get; set; }
    }
}
```

<!--
:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/forms-and-validation/Starship13.razor":::
-->

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

The preceding example checks the validity of all form fields and applies a style to each field. If the form should only apply custom styles to a subset of the fields, make `CustomFieldClassProvider` apply styles conditionally. The following `CustomFieldClassProvider2` example only applies a style to the `Name` field. For any fields with names not matching `Name`, `string.Empty` is returned, and no style is applied. Using [reflection](/dotnet/csharp/advanced-topics/reflection-and-attributes/), the field is matched to the model member's property or field name, not an `id` assigned to the HTML entity.

`CustomFieldClassProvider2.cs`:

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

```csharp
using Microsoft.AspNetCore.Components.Forms;

public class CustomFieldClassProvider2 : FieldCssClassProvider
{
    public override string GetFieldCssClass(EditContext editContext,
        in FieldIdentifier fieldIdentifier)
    {
        if (fieldIdentifier.FieldName == "Name")
        {
            var isValid = editContext.IsValid(fieldIdentifier);

            return isValid ? "validField" : "invalidField";
        }

        return string.Empty;
    }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

```csharp
using Microsoft.AspNetCore.Components.Forms;

public class CustomFieldClassProvider2 : FieldCssClassProvider
{
    public override string GetFieldCssClass(EditContext editContext,
        in FieldIdentifier fieldIdentifier)
    {
        if (fieldIdentifier.FieldName == "Name")
        {
            var isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();

            return isValid ? "validField" : "invalidField";
        }

        return string.Empty;
    }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

<!--
:::code language="csharp" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/CustomFieldClassProvider2.cs":::
-->

> [!NOTE]
> Matching the field name in the preceding example is case sensitive, so a model property member designated "`Name`" must match a conditional check on "`Name`":
>
> * <span aria-hidden="true">✔️</span><span class="visually-hidden">Correctly matches:</span> `fieldId.FieldName == "Name"`
> * <span aria-hidden="true">❌</span><span class="visually-hidden">Fails to match:</span> `fieldId.FieldName == "name"`
> * <span aria-hidden="true">❌</span><span class="visually-hidden">Fails to match:</span> `fieldId.FieldName == "NAME"`
> * <span aria-hidden="true">❌</span><span class="visually-hidden">Fails to match:</span> `fieldId.FieldName == "nAmE"`

Add an additional property to `Model`, for example:

```csharp
[StringLength(10, ErrorMessage = "Description is too long.")]
public string? Description { get; set; } 
```

Add the `Description` to the `CustomValidationForm` component's form:

```razor
<InputText @bind-Value="Model!.Description" />
```

Update the <xref:Microsoft.AspNetCore.Components.Forms.EditForm.EditContext%2A> instance in the component's `OnInitialized` method to use the new Field CSS Class Provider:

```csharp
editContext?.SetFieldCssClassProvider(new CustomFieldClassProvider2());
```

Because a CSS validation class isn't applied to the `Description` field, it isn't styled. However, field validation runs normally. If more than 10 characters are provided, the validation summary indicates the error:

> Description is too long.

In the following example:

* The custom CSS style is applied to the `Name` field.
* Any other fields apply logic similar to Blazor's default logic and using Blazor's default field CSS validation styles, `modified` with `valid` or `invalid`. Note that for the default styles, you don't need to add them to the app's stylesheet if the app is based on a Blazor project template. For apps not based on a Blazor project template, the default styles can be added to the app's stylesheet:

  ```css
  .valid.modified:not([type=checkbox]) {
      outline: 1px solid #26b050;
  }

  .invalid {
      outline: 1px solid red;
  }
  ```

`CustomFieldClassProvider3.cs`:

:::moniker-end

:::moniker range=">= aspnetcore-8.0"

```csharp
using Microsoft.AspNetCore.Components.Forms;

public class CustomFieldClassProvider3 : FieldCssClassProvider
{
    public override string GetFieldCssClass(EditContext editContext,
        in FieldIdentifier fieldIdentifier)
    {
        var isValid = editContext.IsValid(fieldIdentifier);

        if (fieldIdentifier.FieldName == "Name")
        {
            return isValid ? "validField" : "invalidField";
        }
        else
        {
            if (editContext.IsModified(fieldIdentifier))
            {
                return isValid ? "modified valid" : "modified invalid";
            }
            else
            {
                return isValid ? "valid" : "invalid";
            }
        }
    }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-7.0 < aspnetcore-8.0"

```csharp
using Microsoft.AspNetCore.Components.Forms;

public class CustomFieldClassProvider3 : FieldCssClassProvider
{
    public override string GetFieldCssClass(EditContext editContext,
        in FieldIdentifier fieldIdentifier)
    {
        var isValid = !editContext.GetValidationMessages(fieldIdentifier).Any();

        if (fieldIdentifier.FieldName == "Name")
        {
            return isValid ? "validField" : "invalidField";
        }
        else
        {
            if (editContext.IsModified(fieldIdentifier))
            {
                return isValid ? "modified valid" : "modified invalid";
            }
            else
            {
                return isValid ? "valid" : "invalid";
            }
        }
    }
}
```

:::moniker-end

:::moniker range=">= aspnetcore-7.0"

<!--
:::code language="csharp" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/CustomFieldClassProvider3.cs":::
-->

Update the <xref:Microsoft.AspNetCore.Components.Forms.EditForm.EditContext%2A> instance in the component's `OnInitialized` method to use the preceding Field CSS Class Provider:

```csharp
editContext.SetFieldCssClassProvider(new CustomFieldClassProvider3());
```

Using `CustomFieldClassProvider3`:

* The `Name` field uses the app's custom validation CSS styles.
* The `Description` field uses logic similar to Blazor's logic and Blazor's default field CSS validation styles.

:::moniker-end

## Enable the submit button based on form validation

To enable and disable the submit button based on form validation, the following example:

* Uses a shortened version of the earlier `Starfleet Starship Database` form (`Starship3` component) of the [Example form](xref:blazor/forms/input-components#example-form) section of the *Input components* article that only accepts a value for the ship's Id. The other `Starship` properties receive valid default values when an instance of the `Starship` type is created.
* Uses the form's <xref:Microsoft.AspNetCore.Components.Forms.EditContext> to assign the model when the component is initialized.
* Validates the form in the context's <xref:Microsoft.AspNetCore.Components.Forms.EditContext.OnFieldChanged> callback to enable and disable the submit button.
* Implements <xref:System.IDisposable> and unsubscribes the event handler in the `Dispose` method. For more information, see <xref:blazor/components/component-disposal>.

> [!NOTE]
> When assigning to the <xref:Microsoft.AspNetCore.Components.Forms.EditForm.EditContext?displayProperty=nameWithType>, don't also assign an <xref:Microsoft.AspNetCore.Components.Forms.EditForm.Model?displayProperty=nameWithType> to the <xref:Microsoft.AspNetCore.Components.Forms.EditForm>.

:::moniker range=">= aspnetcore-11.0"

> [!IMPORTANT]
> The synchronous <xref:Microsoft.AspNetCore.Components.Forms.EditContext.Validate%2A> method used by the following example is obsolete as of .NET 11. In new code, call `EditContext.ValidateAsync` and `await` the result, which also awaits any asynchronous validators registered for the form:
>
> ```csharp
> private async Task HandleFieldChanged(object? sender, FieldChangedEventArgs e)
> {
>     formInvalid = !await editContext!.ValidateAsync();
>     StateHasChanged();
> }
> ```
>
> For more information, see <xref:blazor/forms/validation-advanced>.

:::moniker-end

`Starship14.razor`:

:::moniker range=">= aspnetcore-9.0"

:::code language="razor" source="~/../blazor-samples/9.0/BlazorSample_BlazorWebApp/Components/Pages/Starship14.razor":::

:::moniker-end

:::moniker range=">= aspnetcore-8.0 < aspnetcore-9.0"

:::code language="razor" source="~/../blazor-samples/8.0/BlazorSample_BlazorWebApp/Components/Pages/Starship14.razor":::

:::moniker-end

:::moniker range="< aspnetcore-8.0"

```razor
@page "/starship-14"
@implements IDisposable
@inject ILogger<Starship14> Logger

<EditForm EditContext="editContext" OnValidSubmit="Submit">
    <DataAnnotationsValidator />
    <ValidationSummary />
    <div>
        <label>
            Identifier: 
            <InputText @bind-Value="Model!.Id" />
        </label>
    </div>
    <div>
        <button type="submit" disabled="@formInvalid">Submit</button>
    </div>
</EditForm>

@code {
    private bool formInvalid = false;
    private EditContext? editContext;

    private Starship? Model { get; set; }

    protected override void OnInitialized()
    {
        Model ??=
            new()
            {
                Id = "NCC-1701",
                Classification = "Exploration",
                MaximumAccommodation = 150,
                IsValidatedDesign = true,
                ProductionDate = new DateTime(2245, 4, 11)
            };
        editContext = new(Model);
        editContext.OnFieldChanged += HandleFieldChanged;
    }

    private void HandleFieldChanged(object? sender, FieldChangedEventArgs e)
    {
        if (editContext is not null)
        {
            formInvalid = !editContext.Validate();
            StateHasChanged();
        }
    }

    private void Submit()
    {
        Logger.LogInformation("Submit called: Processing the form");
    }

    public void Dispose()
    {
        if (editContext is not null)
        {
            editContext.OnFieldChanged -= HandleFieldChanged;
        }
    }
}
```

<!--
:::code language="razor" source="~/../blazor-samples/7.0/BlazorSample_WebAssembly/Pages/forms-and-validation/Starship14.razor":::
-->

:::moniker-end

If a form isn't preloaded with valid values and you wish to disable the **`Submit`** button on form load, set `formInvalid` to `true`.

A side effect of the preceding approach is that a validation summary (<xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> component) is populated with invalid fields after the user interacts with any one field. Address this scenario in either of the following ways:

* Don't use a <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> component on the form.
* Make the <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> component visible when the submit button is selected (for example, in a `Submit` method).

```razor
<EditForm ... EditContext="editContext" OnValidSubmit="Submit" ...>
    <DataAnnotationsValidator />
    <ValidationSummary style="@displaySummary" />

    ...

    <button type="submit" disabled="@formInvalid">Submit</button>
</EditForm>

@code {
    private string displaySummary = "display:none";

    ...

    private void Submit()
    {
        displaySummary = "display:block";
    }
}
```

## Additional resources

* <xref:blazor/forms/validation-advanced>
* <xref:blazor/forms/index>
* <xref:blazor/forms/input-components>
* <xref:mvc/models/validation>

:::moniker range=">= aspnetcore-10.0"

* <xref:fundamentals/validation>

:::moniker-end
