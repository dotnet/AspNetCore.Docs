---
title: ASP.NET Core Blazor client-side form validation in static SSR
ai-usage: ai-assisted
author: guardrex
description: Learn how Blazor validates static server-side rendered forms in the browser before they're submitted.
monikerRange: '>= aspnetcore-11.0'
ms.author: wpickett
ms.date: 09/22/2026
uid: blazor/forms/validation-client-side
---
# ASP.NET Core Blazor client-side form validation in static SSR

<!-- UPDATE 11.0 - API Browser cross-links -->

This article explains how Blazor adds live client-side validation to forms that use [static server-side rendering (static SSR)](xref:blazor/components/render-modes#static-server-side-rendering-static-ssr). The browser validates individual fields as the user edits them and validates the full form before it's submitted. If the client-side check passes, the form is submitted and validated again on the server.

Forms that use an interactive render mode don't use the static SSR client-side validation feature described in this article. Both their per-field validation and full-form submit validation run in .NET through the form's <xref:Microsoft.AspNetCore.Components.Forms.EditContext>.

## How client-side validation works

When a static SSR form contains a <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component, Blazor renders the form's validation rules into the page and enforces them using JavaScript before the form is submitted. The user sees validation errors without a round trip to the server.

Client-side validation activates automatically when the following conditions are met:

* The form's hosting component uses static SSR (no `@rendermode` directive applied to the component).
* The form contains a <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component.
* The form's model uses <xref:System.ComponentModel.DataAnnotations> validation attributes.

For the built-in set of validation attributes, no JavaScript configuration, additional package, or service registration is required. The section [Custom client-side validation rules](#custom-client-side-validation-rules) describes how to add support for custom validation attributes.

> [!IMPORTANT]
> Client-side validation is a user experience improvement, not an authoritative validation pass. It can be bypassed by disabling or modifying the browser's JavaScript execution. Server-side validation runs after the form is posted and remains authoritative. Never rely on client-side validation to protect data integrity.

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

Validation attributes that don't appear in this list, including custom <xref:System.ComponentModel.DataAnnotations.ValidationAttribute>-derived attributes, aren't enforced client-side by default. They continue to run server-side after the form is submitted. To supply a client-side rule for a custom attribute, see the [Custom client-side validation rules](#custom-client-side-validation-rules) section.

## Validation timing

A field is validated when its value is committed. For text inputs (`<input>` elements), this occurs when the field loses focus. Checkboxes and dropdown lists are validated immediately after selection.

After a field has shown a validation error or after the form has been submitted at least once, the field is validated again on every keystroke so that corrections are reflected immediately.

Submitting the form validates every tracked field. If any field is invalid, the submission is blocked and focus moves to the first invalid field.

## Validation messages, localization, and accessibility

Client-side validation uses <xref:Microsoft.AspNetCore.Components.Forms.ValidationMessage%601> to display messages for individual fields and <xref:Microsoft.AspNetCore.Components.Forms.ValidationSummary> to display messages for the whole form, which is the same way that interactive validation reports messages to users.

When validation localization is configured, error messages are localized on the server as the page is rendered, so client-side validation displays the same localized strings as the server-side experience. Localization requires <xref:Microsoft.Extensions.Validation?displayProperty=fullName>. For more information, see <xref:fundamentals/validation#localize-validation-messages>.

ARIA attributes on input elements and validation message containers are managed by Blazor automatically, so assistive technologies announce validation errors without additional configuration.

## Validation state CSS classes

The client-side validation engine applies the same CSS classes as Blazor's interactive validation, which are shown in the following table.

Element | Classes
--- | ---
Input | `valid` or `invalid`, plus `modified` once the user edits the field
Validation message | `validation-message`
Validation summary | `validation-summary-errors` or `validation-summary-valid`

Client-side validation also calls the browser's [Constraint Validation API](https://developer.mozilla.org/docs/Web/API/Constraint_validation), so the standard CSS pseudo-classes `:valid` and `:invalid` reflect each input's current validation state.

## Opt out of client-side validation

The feature can be disabled at multiple levels. Server-side validation is unaffected by any of the options in this section.

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

The global option takes precedence. When it's set to `true`, forms don't emit client-side validation rules.

### Opt out for a single submit button

Use the standard HTML [`formnovalidate` attribute](https://developer.mozilla.org/docs/Web/API/HTMLInputElement/formNoValidate) on the button. The form is posted without a client-side check, and server-side validation still runs after the post:

```razor
<button type="submit" formnovalidate>Save draft</button>
```

This can be used to implement a "save draft" or "back" button that don't require a completely valid form for the submit to succeed.

## Custom client-side validation rules

Custom validation attributes continue to run on the server but don't have a client-side implementation by default. Enforcing a custom rule in the browser involves two steps: emitting the rule from the .NET attribute and registering a matching JavaScript validator. The server-side implementation remains authoritative.

### Emit the rule from .NET

Implement `IClientValidationRuleProvider` on the validation attribute and return one or more `ClientValidationRule` instances. The rule's `Name` identifies the client-side validator, and `Parameters` supplies values the validator needs.

The following `StartsWithAttribute` validates server-side in `IsValid` and contributes a `startswith` client-side rule with a `prefix` parameter:

:::code language="csharp" source="~/../blazor-samples/11.0/BlazorSample_BlazorWebApp/Validation/StartsWithAttribute.cs":::

Apply the attribute to the model in the usual way:

:::code language="csharp" source="~/../blazor-samples/11.0/BlazorSample_BlazorWebApp/Validation/ShipModel.cs":::

### Register the JavaScript validator

In JavaScript, call `Blazor.formValidation.addValidator(name, validator)` to associate a rule name with a validator function. The `name` must exactly match `ClientValidationRule.Name`, including casing. Registrations are app-wide, and registering the same name again replaces the previous validator.

> [!WARNING]
> If no JavaScript validator is registered for an emitted rule name, the rule is skipped in the browser. Server-side validation still runs when the form is posted.

Register custom validators once from app startup code. Choose the registration location based on how Blazor starts, as described in the following table.

Blazor startup | Registration location
--- | ---
Automatic startup (default) | A script immediately after `blazor.web.js`
Manual `Blazor.start()` | The continuation returned by `Blazor.start()`
Either startup style | A JavaScript initializer's `afterWebStarted` callback

A [JavaScript initializer](xref:blazor/fundamentals/startup#javascript-initializers) works with either startup style. In a file named `{ASSEMBLY NAME}.lib.module.js` in the app's `wwwroot` folder:

:::code language="javascript" source="~/../blazor-samples/11.0/BlazorSample_BlazorWebApp/wwwroot/BlazorSample.lib.module.js":::

With automatic startup, an app-specific validator script can instead be loaded immediately after `blazor.web.js`:

```razor
<script src="@Assets["_framework/blazor.web.js"]"></script>
<script src="@Assets["js/custom-validation.js"]"></script>
```

The second script can call `Blazor.formValidation.addValidator` directly.

With manual startup, define the registration in an app script:

:::code language="javascript" source="~/../blazor-samples/11.0/BlazorSample_BlazorWebApp/wwwroot/js/custom-validation.js":::

Load the scripts with automatic startup disabled, and register the validators after `Blazor.start()` completes:

:::code language="razor" source="~/../blazor-samples/11.0/BlazorSample_BlazorWebApp/Components/AppManualStartup.razor":::

> [!IMPORTANT]
> Register validators from app startup code, not from a page or form component. A component script can run before Blazor starts, and scripts added by enhanced navigation aren't executed. Static SSR components also can't use `IJSRuntime` because they don't have an interactive .NET runtime.

### Write JavaScript validator functions

The validator receives a context object with the following members, as shown in the following table.

Member | Description
--- | ---
`value` | The field's current value as a string, or `null`/`undefined` when there's no value.
`element` | The validated `input`, `select`, or `textarea` element.
`params` | The rule's `Parameters` as a string dictionary.

The validator is expected to return `{ success: true }` when the value is valid. Return `{ success: false }` to use the rule's server-supplied message, or you can return `{ success: false, message: '...' }` to override the message for that call.

Empty values should normally be treated as valid by rules other than `required`, allowing an optional field to remain empty while still validating values that are supplied.

Implement the same rule semantics in .NET and JavaScript, including case sensitivity, normalization, and empty-value handling. If the implementations differ, the browser and the authoritative server-side validation can produce different results.

## Validate form on demand

The `Blazor.formValidation` API also exposes JavaScript methods for validating on demand, as the following table shows.

Method | Description
--- | ---
`validateField(element)` | Validates a single field element and updates its error display. Returns `true` when valid.
`validateForm(form)` | Validates every tracked field in a form. Returns `true` when all fields are valid.

## Limitations

* Client-side rules are emitted only for fields included in server-side validation as well. Without <xref:Microsoft.Extensions.Validation?displayProperty=fullName>, only top-level model properties are validated. Validating nested objects and collections requires the app to call <xref:Microsoft.Extensions.DependencyInjection.ValidationServiceCollectionExtensions.AddValidation%2A> and the model to be discovered. For more information, see <xref:fundamentals/validation#nested-objects-and-collections>. Note that this limitation is an intentional feature to help prevent bugs where the authoritative server validation would be missing due to misconfiguration.
* Inputs added to an existing form by a later [streaming rendering](xref:blazor/components/rendering#streaming-rendering) update don't receive client-side validation. A form delivered in a single streamed batch is covered normally.
* Only the attributes listed in [Supported validation attributes](#supported-validation-attributes) have built-in client-side implementations. For example, a <xref:System.ComponentModel.DataAnnotations.RangeAttribute> with a non-numeric operand type is only enforced on the server. Other attributes require a [custom client-side validation rule](#custom-client-side-validation-rules).
* Custom JavaScript validators are synchronous. Rules that require a network call or other asynchronous work must run on the server or use asynchronous validation with an interactive render mode. For more information, see <xref:blazor/forms/validation-advanced>.

## Additional resources

* <xref:blazor/forms/validation>
* <xref:blazor/forms/validation-advanced>
* <xref:fundamentals/validation>
* <xref:blazor/components/render-modes>
