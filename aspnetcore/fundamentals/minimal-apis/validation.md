---
title: Validation in Minimal API apps
author: Youssef1313
description: Use Microsoft.Extensions.Validation in Minimal API apps to validate API models.
ms.author: ygerges
ms.date: 07/08/2026
monikerRange: '>= aspnetcore-10.0'
uid: fundamentals/minimal-apis/validation

# customer intent: As an ASP.NET developer, I want to have automatic validation of models in Minimal API parameters.
---

# Validation in Minimal API apps

In .NET 10, Microsoft.Extensions.Validation was introduced to support complex model validation.

To enable validation, call `AddValidation` on the `IServiceCollection` instance in the web application entry point.

```csharp
builder.Services.AddValidation();
```

## Parameter validation

Parameter validation is the first step in the validation pipeline in minimal API endpoints. It involves the following steps:

1. Validate `ValidationAttribute`s applied to the minimal API parameter.
2. If the parameter type is `IEnumerable`, a type validation for all non-null elements happens. Otherwise, a single type validation for the parameter value happens.

> [!NOTE]
> There is a known limitation currently that nullable value types declared as minimal API parameters don't get validated.
> For more information, see [dotnet/aspnetcore#67033](https://github.com/dotnet/aspnetcore/issues/67033).

If the minimal API parameter type is `IEnumerable`, a type validation for all non-null elements happens. Otherwise, a single type validation for the value happens.

## Type validation

Type validation is the next step after parameter validation. It involves the following:

1. Validate properties on the type. If any errors are found in this step, the validation stops here.
2. Validate type-level `ValidationAttribute`s. If any errors are found in this step, the validation stops here.
3. Validate `IValidatableObject`, if it's implemented.

## Property validation

Property validation happens as part of the type validation as explained in the previous section. It involves the following steps:

1. Validate `ValidationAttribute`s applied on the property.
2. If the property value is `IEnumerable`, a type validation for all non-null elements happens. Otherwise, a single type validation for the value happens.

## Explicit validation skipping

When needed, you can skip validation for a specific parameter, type, or property by applying the `SkipValidationAttribute`.

## Force-generate validatable type information

The Microsoft.Extensions.Validation package works via a Roslyn source generator which detects the object graph and types for minimal API endpoint parameters.

In some cases, not all types that will be part of the object graph can be determined at compile time. In these cases, you can force the source generator to consider a type for validation by applying `ValidatableTypeAttribute` to that type.

## Async validation support

Starting in .NET 11, Microsoft.Extensions.Validation supports async validation. You can apply custom implementations of `AsyncValidationAttribute` to parameters, types, or properties, and they will be called asynchronously. In addition, types can implement `IAsyncValidatableObject` as well.

> [!IMPORTANT]
> Both `IAsyncValidatableObject` and `AsyncValidationAttribute` forces to implement the validation logic synchronously **and** asynchronously.
> For the case of minimal API validation using Microsoft.Extensions.Validation, we will always call the async path and never the sync path.
> The sync and async path are never intended to be both called together. If your implementation can't support the sync path, you can throw `InvalidOperationException`.

When validating properties on a type, we start all validation tasks concurrently. Similarly, when we validate `IEnumerable`s, we start validation tasks for elements concurrently.