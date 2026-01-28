---
title: "IncludeOpenAPIAnalyzers property and MVC API analyzers are deprecated"
description: "Learn about the breaking change in ASP.NET Core 10 where the IncludeOpenAPIAnalyzers property and its associated MVC API analyzers are deprecated."
ms.date: 08/07/2025
ai-usage: ai-assisted
ms.custom: https://github.com/aspnet/Announcements/issues/521
---

# IncludeOpenAPIAnalyzers property and MVC API analyzers are deprecated

The `IncludeOpenAPIAnalyzers` MSBuild property and its associated MVC API analyzers are deprecated and will be removed in a future release. When `IncludeOpenAPIAnalyzers` is set to `true`, the build now emits warning `ASPDEPR007`.

## Version introduced

.NET 10 Preview 7

## Previous behavior

Previously, you could set `<IncludeOpenAPIAnalyzers>true</IncludeOpenAPIAnalyzers>` in your Web SDK projects to enable MVC API analyzers without any warnings or deprecation notices.

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">
  <PropertyGroup>
    <TargetFramework>net9.0</TargetFramework>
    <IncludeOpenAPIAnalyzers>true</IncludeOpenAPIAnalyzers>
  </PropertyGroup>
</Project>
```

Such a project built successfully without any deprecation warnings.

## New behavior

Starting in .NET 10, when `IncludeOpenAPIAnalyzers` is set to `true`, the build emits warning `ASPDEPR007`:

> warning ASPDEPR007: The IncludeOpenAPIAnalyzers property and its associated MVC API analyzers are deprecated and will be removed in a future release.

The analyzers continue to function, but developers receive this deprecation warning during compilation.

## Type of breaking change

This change can affect [source compatibility](/dotnet/core/compatibility/categories#source-compatibility).

## Reason for change

The MVC API analyzers were originally introduced to help keep return types and attributes in sync for API controllers, ensuring consistency between method signatures and their corresponding OpenAPI documentation. These analyzers provided compile-time validation to catch mismatches between declared return types and the actual types returned by controller actions.

However, with the introduction of Minimal APIs and the <xref:Microsoft.AspNetCore.Http.TypedResults> pattern, the .NET ecosystem has evolved toward a more type-safe approach for API development. `TypedResults` provides compile-time guarantees about response types without requiring additional analyzers, making the MVC API analyzers redundant for modern .NET applications. In .NET 10, `TypedResults` are supported in controller-based APIs.

Previous approach with MVC API analyzers:

```csharp
[HttpGet]
[ProducesResponseType<Product>(200)]
[ProducesResponseType(404)]
public async Task<ActionResult> GetProduct(int id)
{
    var product = await _productService.GetByIdAsync(id);
    if (product == null)
        return NotFound(); // Analyzer ensures this matches ProducesResponseType(404)

    return Ok(product); // Analyzer ensures this matches ProducesResponseType<Product>(200)
}
```

Modern approach with `TypedResults`:

```csharp
[HttpGet("{id}")]
public async Task<Results<Ok<Product>, NotFound>> GetProduct(int id)
{
    var product = await _productService.GetByIdAsync(id);
    return product == null
        ? TypedResults.NotFound()
        : TypedResults.Ok(product);
}
```

The `TypedResults` pattern eliminates the need for separate analyzers because the return type itself (`Results<Ok<Product>, NotFound>`) explicitly declares all possible response types at compile time. This approach is more maintainable, provides better IntelliSense support, and automatically generates accurate OpenAPI documentation without additional tooling.

As the .NET ecosystem continues to embrace `TypedResults` as the recommended pattern for API development, the MVC API analyzers have become obsolete and are being deprecated to streamline the development experience.

## Recommended action

Developers should:

- Remove the deprecated property: Remove `<IncludeOpenAPIAnalyzers>true</IncludeOpenAPIAnalyzers>` from your project files to eliminate the warning.
- Migrate to `TypedResults`: Migrate to the `TypedResults` pattern to ensure better consistency between application behavior and OpenAPI documentation.

If you need to continue using the deprecated analyzers temporarily, you can suppress the warning:

```xml
<PropertyGroup>
  <NoWarn>$(NoWarn);ASPDEPR007</NoWarn>
</PropertyGroup>
```

## Affected APIs

- MSBuild property: `IncludeOpenAPIAnalyzers`.
- Associated MVC API analyzers included when `IncludeOpenAPIAnalyzers` is `true`.
