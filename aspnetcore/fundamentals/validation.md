---
title: Validation in ASP.NET Core
ai-usage: ai-assisted
author: Youssef1313
description: Use Microsoft.Extensions.Validation in ASP.NET Core to validate models.
monikerRange: '>= aspnetcore-10.0'
ms.author: ygerges
ms.date: 08/17/2026
uid: fundamentals/validation
---
# Validation in ASP.NET Core

<xref:Microsoft.Extensions.Validation?displayProperty=fullName> supports complex model validation in Blazor and Minimal API projects.

Validation rules are declared the same way in both frameworks, using [data annotations attributes](xref:System.ComponentModel.DataAnnotations) on a model type, and this article describes the behavior that both frameworks share:

* Minimal APIs validate a request before the endpoint handler runs. For how validation is surfaced in an endpoint, see <xref:fundamentals/minimal-apis#validation-support-in-minimal-apis>.
* Blazor validates a form model through the <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component. For how validation is surfaced in a form, see <xref:blazor/forms/validation>.

While the API in the [`Microsoft.Extensions.Validation` NuGet package](https://www.nuget.org/packages/Microsoft.Extensions.Validation) can be used in scenarios outside ASP.NET Core, this article focuses on ASP.NET Core. The API isn't supported for MVC or Razor Pages. For validation guidance that applies to MVC and Razor Pages, see <xref:mvc/models/validation>.

## Enable validation

To enable validation, call <xref:Microsoft.Extensions.DependencyInjection.ValidationServiceCollectionExtensions.AddValidation%2A> on <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Services%2A?displayProperty=nameWithType> in the app's `Program` file:

```csharp
builder.Services.AddValidation();
```

For Minimal APIs, the implementation automatically discovers types that are defined in handlers or as base types of the types defined in handlers. An endpoint filter performs validation on these types and is added for each endpoint.

Validation uses a source generator that only discovers validatable types in the assembly where `AddValidation` is called. If Minimal API endpoints are defined in a referenced assembly rather than the assembly where `AddValidation` is called, register validation as shown in the [Register validation in multi-assembly apps](#register-validation-in-multi-assembly-apps) section.

### Validation when `AddValidation` isn't called

The consequence of omitting <xref:Microsoft.Extensions.DependencyInjection.ValidationServiceCollectionExtensions.AddValidation%2A>, or of calling it but not having a type discovered by the source generator, differs by framework:

:::moniker range=">= aspnetcore-11.0"

| Framework | Behavior without `Microsoft.Extensions.Validation` |
|---|---|
| Minimal APIs | No validation runs. Invalid requests reach the endpoint handler and return a `200 - OK` response instead of `400 - Bad Request`. |
| Blazor | The <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component falls back to <xref:System.ComponentModel.DataAnnotations.Validator?displayProperty=nameWithType>, which validates top-level properties only. Nested objects, collection items, and [localized messages](#localize-validation-messages) aren't supported on the fallback path. |

:::moniker-end

:::moniker range="< aspnetcore-11.0"

| Framework | Behavior without `Microsoft.Extensions.Validation` |
|---|---|
| Minimal APIs | No validation runs. Invalid requests reach the endpoint handler and return a `200 - OK` response instead of `400 - Bad Request`. |
| Blazor | The <xref:Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator> component falls back to <xref:System.ComponentModel.DataAnnotations.Validator?displayProperty=nameWithType>, which validates top-level properties only. Nested objects and collection items aren't validated on the fallback path. |

:::moniker-end

In both cases there's no build error, exception, or log entry indicating that a type isn't validated. If validation appears to be skipped, confirm all of the following:

* <xref:Microsoft.Extensions.DependencyInjection.ValidationServiceCollectionExtensions.AddValidation%2A> is called from the assembly that declares the validatable types. See [Register validation in multi-assembly apps](#register-validation-in-multi-assembly-apps).
* The model type is declared in a C# file (`.cs`), not in a Razor component file (`.razor`). See [Nested objects and collections](#nested-objects-and-collections).
* The root type is annotated with <xref:Microsoft.Extensions.Validation.ValidatableTypeAttribute> when the source generator can't reach it from an endpoint handler signature. See [Force-generate validatable type information](#force-generate-validatable-type-information).

## Validatable entities

Three types of entities can be validated:

* [Parameters](#parameter-validation) (specific to Minimal API endpoint parameters)
* [Types](#type-validation)
* [Properties](#property-validation)

### Parameter validation

Parameter validation is the first step in the validation pipeline for Minimal API endpoints. It involves the following steps:

1. Validate <xref:System.ComponentModel.DataAnnotations.ValidationAttribute> instances applied to the Minimal API parameter.
1. If the parameter type is `IEnumerable`, validate the type for all non-`null` elements. Otherwise, validate the type for the value.

:::moniker range="< aspnetcore-11.0"

> [!NOTE]
> Prior to the release of .NET 11, there's a known limitation where nullable value types declared as Minimal API parameters aren't validated. For more information, see [Validation attributes are ignored for nullable value types when passing a null value (`dotnet/aspnetcore` #67033)](https://github.com/dotnet/aspnetcore/issues/67033).

:::moniker-end

### Type validation

Type validation is the next step after parameter validation (and is the first step in Blazor). It involves the following steps:

1. Validate properties on the type. If any errors are found, the validation process stops.
1. Validate type-level <xref:System.ComponentModel.DataAnnotations.ValidationAttribute> instances. If any errors are found, the validation process stops.
1. Validate <xref:System.ComponentModel.DataAnnotations.IValidatableObject> implementations.

### Property validation

Property validation happens as part of the type validation as explained in the previous section. It involves the following steps:

1. Validate <xref:System.ComponentModel.DataAnnotations.ValidationAttribute> instances applied to the property.
1. If the property value is `IEnumerable`, perform type validation for all non-`null` elements. Otherwise, perform a single type validation for the value.

## Write custom validation rules

When the [built-in validation attributes](xref:mvc/models/validation#built-in-attributes) don't express a rule, write a custom <xref:System.ComponentModel.DataAnnotations.ValidationAttribute> or implement <xref:System.ComponentModel.DataAnnotations.IValidatableObject> on the model. Both are discovered and executed by <xref:Microsoft.Extensions.Validation?displayProperty=fullName> in Blazor and Minimal API apps.

### Custom validation attributes

Derive from <xref:System.ComponentModel.DataAnnotations.ValidationAttribute> and override <xref:System.ComponentModel.DataAnnotations.ValidationAttribute.IsValid%2A> to validate a single value.

Pass the validation context's <xref:System.ComponentModel.DataAnnotations.ValidationContext.MemberName> when creating the <xref:System.ComponentModel.DataAnnotations.ValidationResult>. Without a member name, the result isn't associated with a field, which prevents the error from being displayed next to the corresponding input in a Blazor form:

```csharp
using System.ComponentModel.DataAnnotations;

public class EvenNumberAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, 
        ValidationContext validationContext)
    {
        if (value is int number && number % 2 != 0)
        {
            return new ValidationResult(
                "The value must be an even number.",
                [ validationContext.MemberName! ]);
        }

        return ValidationResult.Success;
    }
}
```

Apply the attribute to a property in the same way as a built-in attribute:

```csharp
public class Order
{
    [EvenNumber]
    public int Quantity { get; set; }
}
```

### Resolve services in a validation attribute

A validation attribute obtains services from dependency injection (DI) through the validation context, which makes rules that require a database lookup or a configured option possible:

```csharp
protected override ValidationResult? IsValid(object? value, 
    ValidationContext validationContext)
{
    var catalog = validationContext.GetService<IProductCatalog>();

    ...
}
```

For a service that must be resolved, use <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderServiceExtensions.GetRequiredService%2A>. Services resolved this way must be registered in the app's service container.

### Class-level validation with `IValidatableObject`

Implement <xref:System.ComponentModel.DataAnnotations.IValidatableObject> for a rule that spans several properties, because an attribute applied to one property can't reliably observe the others. Class-level validation runs after property validation and only if property validation succeeds:

```csharp
using System.ComponentModel.DataAnnotations;

public class DateRange : IValidatableObject
{
    public DateOnly Start { get; set; }
    public DateOnly End { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (End < Start)
        {
            yield return new ValidationResult(
                "End date must fall on or after the start date.", 
                [ nameof(End) ]);
        }
    }
}
```

:::moniker range=">= aspnetcore-11.0"

For rules that require I/O, such as a database or web API call, see the [Asynchronous validation support](#asynchronous-validation-support) section instead.

:::moniker-end

> [!NOTE]
> In a Blazor form that uses static server-side rendering (static SSR), custom attributes aren't enforced by the browser unless the attribute also supplies a client-side rule. For more information, see <xref:blazor/forms/validation-client-side>.

:::moniker range=">= aspnetcore-11.0"

<!-- UPDATE 11.0 - API cross-links for the following section ...

                   <xref:System.ComponentModel.DataAnnotations.AsyncValidationAttribute>
                   <xref:System.ComponentModel.DataAnnotations.IAsyncValidatableObject>

-->

## Asynchronous validation support

<xref:Microsoft.Extensions.Validation?displayProperty=fullName> supports asynchronous validation. Apply custom implementations of `AsyncValidationAttribute` to parameters, types, or properties, and they're called asynchronously. In addition, types can implement `IAsyncValidatableObject` as well.

When validating properties on a type, all validation tasks are started concurrently. Similarly, elements of `IEnumerable` collections are validated concurrently.

`IAsyncValidatableObject` and `AsyncValidationAttribute` require synchronous **and** asynchronous validation logic. For example, the `Validate` and `ValidateAsync` methods of `IAsyncValidatableObject` must be implemented for objects that use the interface. However, validation never calls both methods. If validation is called through an asynchronous code path, only `ValidateAsync` is called. If validation is called through a synchronous code path, only `Validate` is called.

For Minimal API validation, <xref:Microsoft.Extensions.Validation?displayProperty=fullName> always calls the asynchronous path and never the synchronous path.

Blazor form validation calls the asynchronous path for per-field validation and when the form is validated with <xref:Microsoft.AspNetCore.Components.Forms.EditContext.ValidateAsync%2A?displayProperty=nameWithType>, which is what <xref:Microsoft.AspNetCore.Components.Forms.EditForm> uses on submit. The synchronous path is only reached through the <xref:Microsoft.AspNetCore.Components.Forms.EditContext.Validate%2A?displayProperty=nameWithType> method, which is obsolete as of .NET 11. Asynchronous rules therefore work in Blazor forms without additional configuration.

If your implementation can't support the synchronous path, throw <xref:System.InvalidOperationException>.

The following example demonstrates a validation class that implements the `IAsyncValidatableObject` interface. In the following scenario, validation requires an asynchronous call path to check a database for a valid email username via a hypothetical `IUserService` service. Because validation requires an asynchronous database call in this scenario, the synchronous `Validate` method, which is required by the interface's contract, shouldn't be called by developer code elsewhere and throws <xref:System.InvalidOperationException> if it ever is called.

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;

public class ValidateUser : IAsyncValidatableObject
{
    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    // Asynchronous validation path
    public async IAsyncEnumerable<ValidationResult> ValidateAsync(
        ValidationContext validationContext, 
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        var userService = validationContext.GetService<IUserService>();

        if (userService is not null)
        {
            // Asynchronous call that checks a database via a service
            if (await userService.IsEmailExistsAsync(Email, cancellationToken))
            {
                yield return new ValidationResult(
                    "Email is already registered.", new[] { nameof(Email) });
            }
        }
    }

    // Synchronous validation path that throws InvalidOperationException
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        throw new InvalidOperationException("Synchronous validation isn't supported.");
    }
}
```

:::moniker-end

## Nested objects and collections

Validation recurses into nested objects and collection items, so a rule declared on a property of a nested type is enforced when the root model is validated. This is one of the main reasons to adopt <xref:Microsoft.Extensions.Validation?displayProperty=fullName>: without it, only the top-level properties of a model are validated.

To validate a nested object graph:

1. Call <xref:Microsoft.Extensions.DependencyInjection.ValidationServiceCollectionExtensions.AddValidation%2A> in the `Program` file where services are registered.
1. Declare the model types in C# files (`.cs`), not in Razor component files (`.razor`).
1. Annotate the root model type with <xref:Microsoft.Extensions.Validation.ValidatableTypeAttribute> (`[ValidatableType]`). Types reachable from the root are discovered automatically.

In the following example, only the root `Order` type is annotated. The `Customer`, `ShippingAddress`, and `OrderItem` types are discovered from it, and their validation attributes are enforced when an `Order` is validated.

`Order.cs`:

```csharp
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Validation;

[ValidatableType]
public class Order
{
    public Customer Customer { get; set; } = new();
    public List<OrderItem> OrderItems { get; set; } = [];
}

public class Customer
{
    [Required(ErrorMessage = "Name is required.")]
    public string? FullName { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    public string? Email { get; set; }

    public ShippingAddress ShippingAddress { get; set; } = new();
}

public class ShippingAddress
{
    [Required(ErrorMessage = "Street is required.")]
    public string? Street { get; set; }

    [Required(ErrorMessage = "City is required.")]
    public string? City { get; set; }
}

public class OrderItem
{
    [Required(ErrorMessage = "Description is required.")]
    public string? Description { get; set; }

    [Range(1, 1000, ErrorMessage = "Quantity must be between 1 and 1,000.")]
    public int Quantity { get; set; }
}
```

Errors from nested members are reported with a path that identifies the member, such as `Customer.ShippingAddress.Street` or `OrderItems[0].Description`.

### Model types can't be declared in Razor component files

The requirement to declare model types outside of Razor components (`.razor`) exists because both the validation feature and the Razor compiler use source generators. Currently, the output of one source generator can't be used as the input to another source generator, so a type declared in a `.razor` file isn't discovered.

A model declared in a `.razor` file doesn't produce a build error. In a Blazor app, the form silently validates only the top-level properties of the model. For more information, see [Validation when `AddValidation` isn't called](#validation-when-addvalidation-isnt-called).

For model types defined in a class library or in the `.Client` project of a Blazor Web App, see [Register validation in multi-assembly apps](#register-validation-in-multi-assembly-apps).

:::moniker range=">= aspnetcore-11.0"

## Localize validation messages

Validation error messages and the display names of validated members are localized by <xref:Microsoft.Extensions.Validation?displayProperty=fullName>. The same rules apply wherever the model is validated, so a message localizes identically in a Minimal API endpoint and in a Blazor form.

### Activate localization

Localization activates automatically when an <xref:Microsoft.Extensions.Localization.IStringLocalizerFactory> is available in the service container. Call <xref:Microsoft.Extensions.DependencyInjection.LocalizationServiceCollectionExtensions.AddLocalization%2A> to register the standard localization services, then call <xref:Microsoft.Extensions.DependencyInjection.ValidationServiceCollectionExtensions.AddValidation%2A>:

```csharp
builder.Services.AddLocalization();
builder.Services.AddValidation();
```

There's no separate package or additional opt-in call. The validation source generator emits the localization lookup into the app's assembly.

```csharp
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Validation;

[ValidatableType]
public class CustomerModel
{
    // "CustomerName" is looked up as the resource key for the display name.
    [Display(Name = "CustomerName")]
    // "NameRequired" is looked up as the resource key for the error message.
    [Required(ErrorMessage = "NameRequired")]
    public string? Name { get; set; }
}
```

By default, keys are resolved against the resources of the type that declares the member. If a key doesn't resolve, the attribute's built-in error message is used, so a missing resource degrades to the non-localized message rather than surfacing the key to the user.

### Message lookup keys

When <xref:System.ComponentModel.DataAnnotations.ValidationAttribute.ErrorMessage> is set, its value is the lookup key and it takes precedence.

When `ErrorMessage` isn't set, conventional keys are tried in order from most to least specific:

1. `{DeclaringType}_{MemberName}_{AttributeType}_Error`
1. `{DeclaringType}_{AttributeType}_Error`
1. `{AttributeType}_Error`

For example, a <xref:System.ComponentModel.DataAnnotations.RequiredAttribute> on the `Name` property of `CustomerModel` is looked up as `CustomerModel_Name_RequiredAttribute_Error`, then `CustomerModel_RequiredAttribute_Error`, then `RequiredAttribute_Error`. If none resolve, the attribute's built-in message is used.

This makes it possible to translate or override the default message of an attribute across an entire app without setting `ErrorMessage` on every attribute instance:

```csharp
[ValidatableType]
public class CustomerModel
{
    // Resolves the localized string for 'RequiredAttribute_Error'.
    [Required]
    public string? Name { get; set; }
}
```

Two details affect key construction:

* The member segment is skipped for type-level attributes that report no member names.
* A nullable value type contributes its underlying type name.

### Use a shared resource file

To resolve keys from one resource file for every validated type instead of per-type resources, set `ValidationOptions.LocalizerProvider`:

```csharp
builder.Services.AddValidation(options =>
{
    options.LocalizerProvider = (_, factory) => factory.Create(typeof(ValidationMessages));
});
```

### Localize from a source other than resource files

To read localized strings from a database, JSON files, or another source, register a custom <xref:Microsoft.Extensions.Localization.IStringLocalizerFactory>. A user-registered factory takes precedence over the default resource file implementation:

```csharp
builder.Services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();
builder.Services.AddValidation();
```

### Attributes that localize themselves

Attributes that already perform their own resource lookup bypass this pipeline entirely, because they're localized before validation reports the message. This applies to <xref:System.ComponentModel.DataAnnotations.ValidationAttribute.ErrorMessageResourceType> and to <xref:System.ComponentModel.DataAnnotations.DisplayAttribute.ResourceType%2A?displayProperty=nameWithType>.

### Format a custom attribute's message

A custom attribute that substitutes its own values into a message template implements `IValidationMessageFormatter`. The framework calls `FormatMessage` with the culture, the localized template, and the resolved display name:

```csharp
using System.Globalization;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Validation;

public sealed class DivisibleByAttribute : ValidationAttribute, IValidationMessageFormatter
{
    public int Divisor { get; init; }

    // Fills {0} with the display name and {1} with the divisor.
    public string FormatMessage(CultureInfo culture, string template, string displayName) =>
        string.Format(culture, template, displayName, Divisor);
}
```

> [!NOTE]
> Localization requires <xref:Microsoft.Extensions.Validation?displayProperty=fullName>. A Blazor form whose model isn't discovered by the validation source generator falls back to <xref:System.ComponentModel.DataAnnotations.Validator?displayProperty=nameWithType>, which reports the attribute's raw `ErrorMessage` without localizing it. For more information, see [Validation when `AddValidation` isn't called](#validation-when-addvalidation-isnt-called).

:::moniker-end

## Explicit validation skipping

When needed, you can skip validation for a specific parameter, type, or property by applying the <xref:Microsoft.Extensions.Validation.SkipValidationAttribute>.

## Force-generate validatable type information

<xref:Microsoft.Extensions.Validation?displayProperty=fullName> works via a Roslyn source generator that detects the object graph and types for Minimal API endpoint parameters.

In some cases, not all of the types that are part of the object graph can be determined at compile time. In these cases, you can force the source generator to consider a type for validation by applying <xref:Microsoft.Extensions.Validation.ValidatableTypeAttribute> to the type.

## Register validation in multi-assembly apps

To validate types from separate assemblies:

* If the assembly is a plain class library (it isn't based on the `Microsoft.NET.Sdk.Web` or `Microsoft.NET.Sdk.Razor` SDKs), add a package reference to the project for the [`Microsoft.Extensions.Validation` NuGet package](https://www.nuget.org/packages/Microsoft.Extensions.Validation).
* Create an extension method in each external assembly that calls <xref:Microsoft.Extensions.DependencyInjection.ValidationServiceCollectionExtensions.AddValidation%2A>.
* Call each of those extension methods from the host app.

### Minimal API example

When endpoint handler types are defined for endpoints in a separate Minimal API assembly but <xref:Microsoft.Extensions.DependencyInjection.ValidationServiceCollectionExtensions.AddValidation%2A> is only called from the host app assembly, validation doesn't execute: Invalid requests are processed and return a `200 - OK` response instead of the expected `400 - Bad Request` response, even though `AddValidation` is registered and the request types use validation attributes.

Create a service collection extension method in an assembly that defines Minimal API endpoints and call it from the host app.

`ServiceCollectionExtensions.cs` in the assembly that defines the endpoints, which uses the example namespace `MinimalApisAssembly.Extensions`:

```csharp
namespace MinimalApisAssembly.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiValidation(
        this IServiceCollection services)
    {
        return services.AddValidation();
    }
}
```

In the host app's `Program` file, call the extension method instead of calling `AddValidation` directly:

```csharp
using MinimalApisAssembly.Extensions;

...

builder.Services.AddApiValidation();

...

var app = builder.Build();

app.MapApi();
```

In the preceding example, `MapApi` is an extension method defined in the endpoints assembly that maps the Minimal API endpoints. Define it alongside `AddApiValidation` so both the endpoint mappings and validation are registered from the same assembly.

### Blazor Web App example

When form model types are defined in a separate library or the `.Client` project of a Blazor Web App but <xref:Microsoft.Extensions.DependencyInjection.ValidationServiceCollectionExtensions.AddValidation%2A> is only called from the server app's assembly, form validation doesn't honor the validation attributes of the models.

Create a service collection extension method in the assembly that defines the validatable types and call it from the host app.

For model validation defined in the `.Client` project of a Blazor Web App:

* Create a method in the `.Client` project that receives an <xref:Microsoft.Extensions.DependencyInjection.IServiceCollection> instance as an argument and calls <xref:Microsoft.Extensions.DependencyInjection.ValidationServiceCollectionExtensions.AddValidation%2A> on it.
* In the app, call both the method and <xref:Microsoft.Extensions.DependencyInjection.ValidationServiceCollectionExtensions.AddValidation%2A>.

The preceding approach results in validation of the types from both assemblies.

In the following example, the `AddValidationForClientTypes` method is created for the `.Client` project of a Blazor Web App for validation using types defined in the `.Client` project.

`ServiceCollectionExtensions.cs` in the `.Client` project that defines validatable types, which uses the example namespace `BlazorSample.Client.Extensions`:

```csharp
namespace BlazorSample.Client.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddValidationForClientTypes(
        this IServiceCollection services)
    {
        return services.AddValidation();
    }
}
```

In the server project's `Program` file:

* Call the `.Client` project's service collection extension method to validate types in the `.Client` project.
* Call <xref:Microsoft.Extensions.DependencyInjection.ValidationServiceCollectionExtensions.AddValidation%2A> to validate types in the server project.

```csharp
using BlazorSample.Client.Extensions;

...

builder.Services.AddValidationForClientTypes();
builder.Services.AddValidation();
```

:::moniker range="= aspnetcore-10.0"

## Experimental API in apps that target .NET 10

Attributes from the [`Microsoft.Extensions.Validation` NuGet package](https://www.nuget.org/packages/Microsoft.Extensions.Validation) (<xref:Microsoft.Extensions.Validation.ValidatableTypeAttribute> and <xref:Microsoft.Extensions.Validation.SkipValidationAttribute>) are published as *experimental* in .NET 10. The package is intended to provide a new shared infrastructure for validation features across frameworks, and publishing experimental types provides greater flexibility for the final design of the public API for better support in consuming frameworks. As of .NET 11, the attributes are no longer experimental, so the guidance in this section doesn't apply to apps that target .NET 11 or later.

In Blazor apps, types are made available via a generated embedded attribute. If a web app project that uses the `Microsoft.NET.Sdk.Web` SDK (`<Project Sdk="Microsoft.NET.Sdk.Web">`) or an RCL that uses the `Microsoft.NET.Sdk.Razor` SDK (`<Project Sdk="Microsoft.NET.Sdk.Razor">`) contains Razor components (`.razor`), the framework automatically generates an internal attribute inside the project (`Microsoft.Extensions.Validation.Embedded.ValidatableType`, `Microsoft.Extensions.Validation.Embedded.SkipValidation`). These types are interchangeable with the actual attributes and not marked experimental. In the majority of cases, developers use the `[ValidatableType]`/`[SkipValidation]` attributes on their classes without concern over their source.

However, the preceding approach isn't viable in plain class libraries that use the `Microsoft.NET.Sdk` SDK (`<Project Sdk="Microsoft.NET.Sdk">`). Using the types in a plain class library results in a code analysis warning:

> :::no-loc text="ASP0029: 'Microsoft.Extensions.Validation.ValidatableTypeAttribute' is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.":::

The warning can be suppressed using any of the following approaches:

* A `<NoWarn>` property in the project file:

  ```xml
  <PropertyGroup>
    <NoWarn>$(NoWarn);ASP0029</NoWarn>
  </PropertyGroup>
  ```

* A [`pragma` directive](/cpp/preprocessor/pragma-directives-and-the-pragma-keyword) where the attribute is used:

  ```csharp
  #pragma warning disable ASP0029
  [Microsoft.Extensions.Validation.ValidatableType]
  #pragma warning restore ASP0029
  ```

* An [EditorConfig file (`.editorconfig`)](/visualstudio/ide/create-portable-custom-editor-options) rule:

  ```
  dotnet_diagnostic.ASP0029.severity = none
  ```

If suppressing the warning isn't acceptable, manually create the embedded attribute in the library that the Web and Razor SDKs generate automatically.

`ValidatableTypeAttribute.cs`:

```csharp
namespace Microsoft.Extensions.Validation.Embedded
{
    [AttributeUsage(AttributeTargets.Class)]
    internal sealed class ValidatableTypeAttribute : Attribute
    {
    }
}
```

Use the exact namespace (`Microsoft.Extensions.Validation.Embedded`) and class name (<xref:Microsoft.Extensions.Validation.ValidatableTypeAttribute>) in order for the validation source generator to detect and use the type. You can declare a global `using` statement for the namespace, either with a `global using Microsoft.Extensions.Validation.Embedded;` statement or with a `<Using Include="Microsoft.Extensions.Validation.Embedded" />` item in the library's project file.

Whichever approach is adopted, denote the presence of the workaround for a future update to your code when the app can target .NET 11 or later. At that time, you can remove your workarounds from the app.

:::moniker-end

## Additional resources

:::moniker range=">= aspnetcore-11.0"

* <xref:blazor/forms/validation>
  * <xref:blazor/forms/validation-client-side>
  * <xref:blazor/forms/validation-advanced>
* <xref:fundamentals/minimal-apis>
  * [Validation support in Minimal APIs](xref:fundamentals/minimal-apis#validation-support-in-minimal-apis)
* <xref:fundamentals/localization/make-content-localizable>
* <xref:mvc/models/validation>

:::moniker-end

:::moniker range="< aspnetcore-11.0"

* <xref:blazor/forms/validation>
* [Validation support in Minimal APIs](xref:fundamentals/minimal-apis#validation-support-in-minimal-apis)
* <xref:mvc/models/validation>

:::moniker-end

