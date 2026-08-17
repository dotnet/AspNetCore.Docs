---
title: ASP.NET Core Blazor client-side form validation in static SSR
ai-usage: ai-assisted
author: guardrex
description: Learn how Blazor validates static server-side rendered forms in the browser before they're submitted.
monikerRange: '>= aspnetcore-11.0'
ms.author: wpickett
ms.date: 08/17/2026
uid: blazor/forms/validation-client-side
---
# ASP.NET Core Blazor client-side form validation in static SSR

[!INCLUDE[](~/includes/not-latest-version.md)]

This article explains how Blazor validates forms in the browser when the form uses [static server-side rendering (static SSR)](xref:blazor/components/render-modes#static-server-side-rendering-static-ssr).

Forms that use an interactive render mode validate through the live <xref:Microsoft.AspNetCore.Components.Forms.EditContext> pipeline and don't use the feature described in this article. For validation that applies to every render mode, see <xref:blazor/forms/validation>.

## How client-side validation works

When a static SSR form contains a <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component, Blazor renders the form's validation rules into the page and enforces them in the browser before the form is submitted. The user sees validation errors without a round trip to the server.

Client-side validation activates automatically when both of the following conditions are met:

* The form's hosting component uses static SSR (no `@rendermode` directive applied to the component).
* The form contains a <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component.

No JavaScript configuration, additional package, or service registration is required.

> [!IMPORTANT]
> Client-side validation is a user experience improvement, not a security boundary. It can be bypassed by disabling or modifying the browser's JavaScript. Server-side validation runs after the form is posted and remains authoritative. Never rely on client-side validation to protect data integrity.

### The .NET model remains the source of truth

Validation rules aren't authored separately for the client. The server derives them from the data annotations attributes on the form's model and renders them into the page, so the client-side rules can't drift from the server-side rules.

The rules are carried in a single inert custom element that Blazor appends to the form:

```html
<blazor-client-validation-data data-rules='{"fields":[{"name":"Input.Email","rules":[{"name":"required","message":"Email is required."}]}]}'></blazor-client-validation-data>
```

Because the payload is held in an attribute rather than as element content, the element renders nothing and needs no CSS to remain hidden.

> [!NOTE]
> Although the carrier element is invisible, it's a real element in the DOM and is a child of the form. CSS selectors that depend on element position, such as `:last-child`, `:nth-child()`, and adjacent sibling combinators (`+`), can match differently in a form that has client-side validation enabled.

## Fields that receive client-side rules

Client-side rules are only emitted for fields that the server also validates when the form is submitted. A field that the server ignores never receives a client-side rule.

This matters for models with nested objects and collections. Validating nested members requires <xref:Microsoft.Extensions.Validation?displayProperty=fullName>, so:

* When the app calls <xref:Microsoft.Extensions.DependencyInjection.ValidationServiceCollectionExtensions.AddValidation%2A> and the model is discovered, nested members are validated on the server and receive client-side rules.
* Otherwise, only top-level properties are validated on the server, so only top-level properties receive client-side rules.

Adopting <xref:Microsoft.Extensions.Validation?displayProperty=fullName> therefore changes which fields are validated in the browser. For more information, see <xref:fundamentals/validation#nested-objects-and-collections>.

The rule prevents client-side validation from suggesting coverage that the authoritative server-side pass doesn't provide, which would give a false sense of security.

## Supported validation attributes

The following <xref:System.ComponentModel.DataAnnotations?displayProperty=fullName> attributes are enforced client-side, matching the server-side data annotations behavior:

* <xref:System.ComponentModel.DataAnnotations.RequiredAttribute>
* <xref:System.ComponentModel.DataAnnotations.StringLengthAttribute>
* <xref:System.ComponentModel.DataAnnotations.MinLengthAttribute>
* <xref:System.ComponentModel.DataAnnotations.MaxLengthAttribute>
* <xref:System.ComponentModel.DataAnnotations.RangeAttribute> (only when the operand type is numeric)
* <xref:System.ComponentModel.DataAnnotations.RegularExpressionAttribute>
* <xref:System.ComponentModel.DataAnnotations.EmailAddressAttribute>
* <xref:System.ComponentModel.DataAnnotations.UrlAttribute>
* <xref:System.ComponentModel.DataAnnotations.PhoneAttribute>
* <xref:System.ComponentModel.DataAnnotations.CreditCardAttribute>
* <xref:System.ComponentModel.DataAnnotations.CompareAttribute>
* <xref:System.ComponentModel.DataAnnotations.FileExtensionsAttribute>

Validation attributes that don't appear in this list, including custom <xref:System.ComponentModel.DataAnnotations.ValidationAttribute>-derived attributes, aren't enforced client-side. They continue to run server-side after the form is submitted. To supply a client-side rule for a custom attribute, see the [Custom client-side validation rules](#custom-client-side-validation-rules) section.

> [!NOTE]
> A <xref:System.ComponentModel.DataAnnotations.RangeAttribute> with a non-numeric operand type, such as a date range, doesn't produce a client-side rule. The range is still enforced server-side.

The <xref:System.ComponentModel.DataAnnotations.PhoneAttribute> and <xref:System.ComponentModel.DataAnnotations.CreditCardAttribute> client-side validators intentionally accept the same input as their .NET counterparts rather than applying stricter rules. Apps that require stricter checks can register a custom validator.

## Validation timing

A field is validated when its value is committed, which for text inputs occurs when the field loses focus and for checkboxes and dropdown lists occurs immediately on selection.

After a field has shown a validation error, or after the form has been submitted at least once, the field is validated again on every keystroke so that corrections are reflected immediately.

Submitting the form validates every tracked field. If any field is invalid, the submission is blocked and focus moves to the first invalid field.

## Validation messages and accessibility

The <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessage%601> and <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> components display client-side validation errors without any changes.

ARIA attributes on input elements and on validation message containers are managed by Blazor automatically, so assistive technologies announce validation errors without additional configuration.

## Validation state CSS classes

The client-side validation engine applies the same CSS classes as Blazor's interactive validation, so one stylesheet covers both:

| Element | Classes |
|---|---|
| Input | `valid` or `invalid`, plus `modified` once the user edits the field |
| Validation message | `validation-message` |
| Validation summary | `validation-summary-errors` or `validation-summary-valid` |

Because the class names match the interactive render modes, the stylesheet included in the Blazor project templates styles static SSR validation and interactive validation identically with no additional configuration.

Client-side validation also calls the browser's [Constraint Validation API](https://developer.mozilla.org/docs/Web/API/Constraint_validation), so the standard CSS pseudo-classes `:valid` and `:invalid` reflect each input's current validation state.

## Enhanced navigation

Client-side validation is preserved across [enhanced navigation](xref:blazor/fundamentals/navigation#enhanced-navigation-and-form-handling). When a user navigates to a page that contains a static SSR form, the form is wired up automatically, including when the page update replaces one form with another. Multiple forms on the same page validate independently of each other.

## Streaming rendering

Inputs added to a form by a later [streaming rendering](xref:blazor/components/rendering#streaming-rendering) update aren't covered by client-side validation. They're still validated on the server when the form is submitted.

A form that's delivered in a single streamed batch is covered normally. This limitation only applies when inputs are added to a form that has already rendered.

## Opt out of client-side validation

Server-side validation is unaffected by every option in this section. Only the in-browser check is disabled.

### Opt out for a single form

Set the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component's `DisableClientValidation` parameter to `true`:

```razor
<DataAnnotationsValidator DisableClientValidation="true" />
```

### Opt out for the entire app

Set `DisableClientValidation` on <xref:Microsoft.AspNetCore.Components.Endpoints.RazorComponentsServiceOptions> when Razor components services are registered in the `Program` file:

```csharp
builder.Services.AddRazorComponents(options =>
{
    options.DisableClientValidation = true;
});
```

The global option takes precedence. When it's set to `true`, no form emits client-side validation rules, and a form can't opt back in with `DisableClientValidation="false"` on its <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component.

### Opt out for a single submit button

Use the standard HTML `formnovalidate` attribute on the button. The form is posted without a client-side check, and server-side validation still runs after the post:

```razor
<button type="submit" formnovalidate>Save draft</button>
```

This is useful for a "save draft" or "back" button that shouldn't require a completely valid form.

## Localized validation messages

When validation localization is configured, error messages are localized on the server as the page is rendered, so client-side validation displays the same localized strings as the server-side experience.

Localization requires <xref:Microsoft.Extensions.Validation?displayProperty=fullName>. For more information, see <xref:fundamentals/validation#localize-validation-messages>.

## Custom client-side validation rules

A custom validation attribute isn't enforced in the browser by default because the framework has no way to execute arbitrary .NET validation logic on the client. To enforce a custom rule client-side, supply the rule on the server and register a matching validator function on the client. Both halves are required: a rule with no matching validator has no effect, and a validator with no matching rule is never called.

### Emit a rule from a validation attribute

Implement `IClientValidationRuleProvider` on the validation attribute and return one or more `ClientValidationRule` instances. The rule's `Name` identifies the client-side validator, and `Parameters` supplies values the validator needs.

The framework attaches each rule's resolved error message, including the localized message when localization is configured, so the attribute supplies only the rule's shape.

The following `StartsWithAttribute` validates server-side in `IsValid` and contributes a `startswith` client-side rule with a `prefix` parameter:

:::code language="csharp" source="~/../blazor-samples/11.0/BlazorSample_BlazorWebApp/Validation/StartsWithAttribute.cs":::

Apply the attribute to the model in the usual way:

:::code language="csharp" source="~/../blazor-samples/11.0/BlazorSample_BlazorWebApp/Validation/ShipModel.cs":::

### Register the matching client-side validator

Register a validator function with the same rule name using `addValidator`.

The `Blazor.formValidation` service is created while Blazor starts, so it isn't available to script that runs before start-up completes. Register the validator from a [JavaScript initializer](xref:blazor/fundamentals/startup#javascript-initializers), which receives the `Blazor` instance after start-up.

In a JavaScript initializer file named `{APP NAMESPACE}.lib.module.js` placed in the app's `wwwroot` folder, where the `{APP NAMESPACE}` placeholder is the app's namespace:

:::code language="javascript" source="~/../blazor-samples/11.0/BlazorSample_BlazorWebApp/wwwroot/BlazorSample.lib.module.js":::

Rule names are matched exactly, so the name passed to `addValidator` must match the `ClientValidationRule` `Name` value, including casing.

Registering the validator after start-up is sufficient even for a form that's already on the page. The rule is already present in the rendered metadata, and the engine resolves the validator function by name when validation runs.

The validator receives a context object with the following members:

| Member | Description |
|---|---|
| `value` | The field's current value as a string, or `null`/`undefined` when there's no value. |
| `element` | The `input`, `select`, or `textarea` element being validated. |
| `params` | The rule's `Parameters` as a string dictionary. |

The validator returns `{ success: true }` when the value is valid. Return `{ success: false }` to use the rule's server-supplied message, or `{ success: false, message: '...' }` to override the message for that call.

> [!NOTE]
> A validator function is synchronous. Client-side validation is intended for immediate feedback, so rules that require a network call or other asynchronous work should be validated on the server. For asynchronous validation in interactive render modes, see <xref:blazor/forms/validation-advanced>.

Empty values are conventionally treated as valid by rules other than `required`, which allows an optional field to remain empty while still being validated when a value is present.

### Validate programmatically

The `Blazor.formValidation` API also exposes methods for validating on demand:

| Method | Description |
|---|---|
| `addValidator(name, validator)` | Registers a custom validator for a rule name. |
| `validateField(element)` | Validates a single field element and updates its error display. Returns `true` when valid. |
| `validateForm(form)` | Validates every tracked field in a form. Returns `true` when all fields are valid. |

## Replace rule generation

To take complete control of the validation metadata rendered for a form, implement `ClientValidationProvider` and register it in the service container. The provider returns a <xref:Microsoft.AspNetCore.Components.RenderFragment> that renders the metadata for the fields that were rendered in the form, or `null` when there's nothing to emit.

This is an advanced extensibility point for scenarios such as sourcing rules from a system other than data annotations. Most apps use the built-in provider and, when a custom rule is needed, implement `IClientValidationRuleProvider` instead.

## Additional resources

* <xref:blazor/forms/validation>
* <xref:blazor/forms/validation-advanced>
* <xref:fundamentals/validation>
* <xref:blazor/components/render-modes>
