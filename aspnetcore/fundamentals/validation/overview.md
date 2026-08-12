---
title: Validation in ASP.NET Core
ai-usage: ai-assisted
author: Youssef1313
description: Use Microsoft.Extensions.Validation in ASP.NET Core to validate models.
monikerRange: '>= aspnetcore-10.0'
ms.author: ygerges
ms.date: 08/12/2026
uid: fundamentals/validation/index
---
# Validation in ASP.NET Core

<xref:Microsoft.Extensions.Validation?displayProperty=fullName> supports complex model validation in Blazor and Minimal API projects.

While the API in the [`Microsoft.Extensions.Validation` NuGet package](https://www.nuget.org/packages/Microsoft.Extensions.Validation) can be used in scenarios outside ASP.NET Core, this article focuses on ASP.NET Core. The API isn't supported for MVC and Razor Pages. For validation guidance that applies to MVC and Razor Pages, see <xref:mvc/models/validation>.

To enable validation, call <xref:Microsoft.Extensions.DependencyInjection.ValidationServiceCollectionExtensions.AddValidation%2A> on <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder.Services%2A?displayProperty=nameWithType> in the app's `Program` file:

```csharp
builder.Services.AddValidation();
```

For Minimal APIs, the implementation automatically discovers types that are defined in handlers or as base types of the types defined in handlers. An endpoint filter performs validation on these types and is added for each endpoint.

Validation uses a source generator that only discovers validatable types in the assembly where `AddValidation` is called. If Minimal API endpoints are defined in a referenced assembly rather than the assembly where `AddValidation` is called, register validation as shown in the [Register validation in multi-assembly apps](#register-validation-in-multi-assembly-apps) section.

## Register validation in multi-assembly apps

When endpoint handler types are defined in a referenced assembly but <xref:Microsoft.Extensions.DependencyInjection.ValidationServiceCollectionExtensions.AddValidation%2A> is called from the host app assembly, validation doesn't execute: Invalid requests are processed and return a `200 - OK` response instead of the expected `400 - Bad Request` response, even though `AddValidation` is registered and the request types use validation attributes, such as the [`[Required]` attribute](xref:System.ComponentModel.DataAnnotations.RequiredAttribute).

To validate types defined in a different assembly, call `AddValidation` from within that assembly. Create a service collection extension method in the assembly that defines the Minimal API endpoints and call it from the host app.

`ServiceCollectionExtensions.cs` in the assembly that defines the endpoints, which uses the example namespace `MinimalApisAssembly`:

```csharp
namespace MinimalApisAssembly;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiValidation(this IServiceCollection services)
    {
        return services.AddValidation();
    }
}
```

In the host app's `Program` file, call the extension method instead of calling `AddValidation` directly:

```csharp
using MinimalApisAssembly;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiValidation();

var app = builder.Build();

app.MapApi();

app.Run();
```

In the preceding example, `MapApi` is an extension method defined in the endpoints assembly that maps the Minimal API endpoints. Define it alongside `AddApiValidation` so both the endpoint mappings and validation are registered from the same assembly.

If types are validated in more than one assembly:

* Call `AddValidation` in each assembly that defines validatable types.
* Call each of those extension methods from the host app.

If validation silently doesn't execute, confirm that `AddValidation` is called from the same assembly that defines the Minimal API endpoint mappings and the validatable types.

:::moniker range="= aspnetcore-10.0"

## Experimental API in apps that target .NET 10

Attributes from the [`Microsoft.Extensions.Validation` NuGet package](https://www.nuget.org/packages/Microsoft.Extensions.Validation) (<xref:Microsoft.Extensions.Validation.ValidatableTypeAttribute> and <xref:Microsoft.Extensions.Validation.SkipValidationAttribute>) are published as *experimental* in .NET 10. The package is intended to provide a new shared infrastructure for validation features across frameworks, and publishing experimental types provides greater flexibility for the final design of the public API for better support in consuming frameworks. As of .NET 11, the attributes are no longer experimental, so the following guidance doesn't apply to apps that target .NET 11 or later.

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

## Explicit validation skipping

When needed, you can skip validation for a specific parameter, type, or property by applying the <xref:Microsoft.Extensions.Validation.SkipValidationAttribute>.

## Force-generate validatable type information

<xref:Microsoft.Extensions.Validation?displayProperty=fullName> works via a Roslyn source generator that detects the object graph and types for Minimal API endpoint parameters.

In some cases, not all of the types that are part of the object graph can be determined at compile time. In these cases, you can force the source generator to consider a type for validation by applying <xref:Microsoft.Extensions.Validation.ValidatableTypeAttribute> to the type.

:::moniker range=">= aspnetcore-11.0"

<!-- UPDATE 11.0 - API cross-links for the following section ...

                   <xref:System.ComponentModel.DataAnnotations.AsyncValidationAttribute>
                   <xref:System.ComponentModel.DataAnnotations.IAsyncValidatableObject>

-->

## Asynchronous validation support

<xref:Microsoft.Extensions.Validation?displayProperty=fullName> supports asynchronous validation. Apply custom implementations of `AsyncValidationAttribute` to parameters, types, or properties, and they're called asynchronously. In addition, types can implement `IAsyncValidatableObject` as well.

> [!IMPORTANT]
> Both `IAsyncValidatableObject` and `AsyncValidationAttribute` require you to implement the validation logic synchronously **and** asynchronously.
>
> For Minimal API validation, <xref:Microsoft.Extensions.Validation?displayProperty=fullName> always calls the asynchronous path and never the synchronous path.
>
> The asynchronous and synchronous paths are never intended to be called together. If your implementation can't support the synchronous path, throw <xref:System.InvalidOperationException>.

When validating properties on a type, all validation tasks are started concurrently. Similarly, elements of `IEnumerable` collections are validated concurrently.

:::moniker-end

## Additional resources

:::moniker range=">= aspnetcore-11.0"

* <xref:blazor/forms/validation>
  * [Use validation models from a different assembly](xref:blazor/forms/validation#use-validation-models-from-a-different-assembly)
  * [Localized validation messages](xref:blazor/forms/validation#localized-validation-messages)
  * [Nested objects and collection types](xref:blazor/forms/validation#nested-objects-and-collection-types)
* <xref:fundamentals/localization/make-content-localizable#dataannotations-localization-in-minimal-apis-and-blazor>
* <xref:fundamentals/minimal-apis>
  * [Validation support in Minimal APIs](xref:fundamentals/minimal-apis#validation-support-in-minimal-apis)
  * [Localizing validation messages](xref:fundamentals/minimal-apis#localizing-validation-messages)
* <xref:mvc/models/validation>

:::moniker-end

:::moniker range="< aspnetcore-11.0"

* <xref:blazor/forms/validation>
  * [Use validation models from a different assembly](xref:blazor/forms/validation#use-validation-models-from-a-different-assembly)
  * [Nested objects and collection types](xref:blazor/forms/validation#nested-objects-and-collection-types)
* [Validation support in Minimal APIs](xref:fundamentals/minimal-apis#validation-support-in-minimal-apis)
* <xref:mvc/models/validation>

:::moniker-end
