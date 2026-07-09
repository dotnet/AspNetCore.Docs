---
title: Validation in ASP.NET Core
author: Youssef1313
description: Use Microsoft.Extensions.Validation in ASP.NET Core to validate models.
ms.author: ygerges
ms.date: 07/09/2026
monikerRange: '>= aspnetcore-10.0'
uid: validation/index

# customer intent: As an ASP.NET developer, I want to have automatic validation of models.
---

# Validation in ASP.NET Core

In .NET 10, Microsoft.Extensions.Validation was introduced to support complex model validation.

While the Microsoft.Extensions.Validation NuGet package can be used in scenarios outside ASP.NET Core, this article focuses on ASP.NET Core.

To enable validation, call `AddValidation` on the `IServiceCollection` instance in the web application entry point.

```csharp
builder.Services.AddValidation();
```

> [!NOTE]
> ASP.NET Core has built-in support for Microsoft.Extensions.Validation for both minimal APIs and Blazor scenarios. It's not supported by default in MVC.

## Validatable entities

Three types of entities can be validated:

- Parameters (specific to minimal API endpoint parameters)
- Types
- Properties

### Parameter validation

Parameter validation is the first step in the validation pipeline in minimal API endpoints. It involves the following steps:

1. Validate `ValidationAttribute`s applied to the minimal API parameter.
1. If the parameter type is `IEnumerable`, validate the type for all non-null elements. Otherwise, validate the type for the value.

> [!NOTE]
> There's a known limitation where nullable value types declared as minimal API parameters aren't validated.
> For more information, see [dotnet/aspnetcore#67033](https://github.com/dotnet/aspnetcore/issues/67033).

If the minimal API parameter type is `IEnumerable`, a type validation for all non-null elements happens. Otherwise, a single type validation for the value happens.

### Type validation

Type validation is the next step after parameter validation (and is the first step in Blazor). It involves the following steps:

1. Validate properties on the type. If any errors are found, the validation process stops.
1. Validate type-level `ValidationAttribute`s. If any errors are found, the validation process stops.
1. Validate `IValidatableObject`, if it's implemented.

### Property validation

Property validation happens as part of the type validation as explained in the previous section. It involves the following steps:

1. Validate `ValidationAttribute`s applied on the property.
1. If the property value is `IEnumerable`, perform type validation for all non-null elements. Otherwise, perform a single type validation for the value.

## Explicit validation skipping

When needed, you can skip validation for a specific parameter, type, or property by applying the `SkipValidationAttribute`.

## Force-generate validatable type information

The Microsoft.Extensions.Validation package works via a Roslyn source generator that detects the object graph and types for minimal API endpoint parameters.

In some cases, not all types that will be part of the object graph can be determined at compile time. In these cases, you can force the source generator to consider a type for validation by applying `ValidatableTypeAttribute` to that type.

## Async validation support

Starting in .NET 11, Microsoft.Extensions.Validation supports async validation. You can apply custom implementations of `AsyncValidationAttribute` to parameters, types, or properties, and they will be called asynchronously. In addition, types can implement `IAsyncValidatableObject` as well.

> [!IMPORTANT]
> Both `IAsyncValidatableObject` and `AsyncValidationAttribute` require you to implement the validation logic synchronously **and** asynchronously.
> For minimal API validation using `Microsoft.Extensions.Validation`, the framework always calls the async path and never the sync path.
> The sync and async paths are never intended to both be called together. If your implementation can't support the sync path, throw `InvalidOperationException`.

When validating properties on a type, we start all validation tasks concurrently. Similarly, when we validate `IEnumerable`s, we start validation tasks for elements concurrently.