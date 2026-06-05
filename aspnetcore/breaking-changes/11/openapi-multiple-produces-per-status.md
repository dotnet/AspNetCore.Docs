---
title: "Breaking change: OpenAPI document includes all ProducesResponseType entries per status code"
ai-usage: ai-assisted
description: "Learn about the breaking change in ASP.NET Core 11 where the generated OpenAPI document contains multiple response variants for a single status code instead of dropping all but the last declaration."
ms.date: 06/05/2026
---
# OpenAPI document includes all ProducesResponseType entries per status code

ASP.NET Core 11 changes how MVC's `ApiExplorer` and minimal API's metadata-collection step handle multiple `[ProducesResponseType]` or <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Produces%2A> declarations for the same status code. Previously, all but one declaration per status code were dropped before the OpenAPI document was generated. Starting in ASP.NET Core 11, all declarations are preserved, and the generated OpenAPI document reflects every declared content type and schema for each status code.

## Version introduced

.NET 11

## Previous behavior

For both MVC controllers and minimal APIs, only one `ApiResponseType` survived per status code. Additional `[ProducesResponseType]` attributes or `.Produces<T>(...)` calls with the same status code silently overwrote the previous entry. The generated OpenAPI document therefore contained a single response variant per status code, even when the developer declared several.

For example, with the following minimal API endpoint:

```csharp
app.MapGet("/items/{id}", (int id) => /* ... */)
    .Produces<Product>(200)
    .Produces<Customer>(200, "text/xml");
```

The generated OpenAPI document contained only the `Customer` variant for status `200`; the `Product` variant was silently dropped.

The same overwrite behavior applied to controllers:

```csharp
[ProducesResponseType(typeof(Foo), 200, "application/json")]
[ProducesResponseType(typeof(Bar), 200, "text/xml")]
public IActionResult Get() => /* ... */;
```

Only the `Bar` / `text/xml` variant survived in the OpenAPI document.

## New behavior

Starting in ASP.NET Core 11, all declared response types for the same status code are preserved and emitted to the generated OpenAPI document. For the minimal API example above, the `responses["200"]` entry now contains both the `application/json` schema (for `Product`) and the `text/xml` schema (for `Customer`). For the controller example, both the `application/json` schema (for `Foo`) and the `text/xml` schema (for `Bar`) are emitted.

When multiple declarations share the same status code *and* the same content type but declare different types, the OpenAPI document represents the response schema as a union of the declared types.

Controller-level `[Produces]` content types continue to apply as the shared default content type for entries that don't specify their own. Attribute-level declarations on an action take precedence over controller-level declarations with the same status code.

## Type of breaking change

This change is a [behavioral change](/dotnet/core/compatibility/categories#behavioral-change).

## Reason for change

Dropping all but one declared response variant produced incomplete OpenAPI documents and surprised users who expected each `[ProducesResponseType]` or `.Produces<T>(...)` call to be reflected in the generated schema. The new behavior matches the developer's stated intent and is consistent with how OpenAPI represents multiple content types per status code. For more information, see [dotnet/aspnetcore#65650](https://github.com/dotnet/aspnetcore/pull/65650).

## Recommended action

Most apps benefit from the new behavior with no code changes. Verify that:

- **Downstream OpenAPI consumers** (code generators such as NSwag, OpenAPI Generator, or Kiota; contract tests; client SDK builds) handle multiple response variants per status code. Most generators do, but the generated client code may now expose additional types or a union return type where it previously exposed a single type.
- **Snapshot tests against the generated OpenAPI document** are updated to expect the additional entries.
- **Duplicate or stale `[ProducesResponseType]` declarations** that were previously masked by the overwrite behavior are removed. Audit endpoints that have multiple declarations for the same status code and remove ones that no longer apply.

If you intentionally want the old single-variant shape for a specific endpoint, remove the redundant declarations from the endpoint instead of relying on the overwrite behavior.

## Affected APIs

- <xref:Microsoft.AspNetCore.Mvc.ProducesResponseTypeAttribute?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Mvc.ProducesAttribute?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.Produces%2A?displayProperty=fullName>
- <xref:Microsoft.AspNetCore.Http.OpenApiRouteHandlerBuilderExtensions.ProducesProblem%2A?displayProperty=fullName>
- Generated `responses` entries in the OpenAPI document produced by [`AddOpenApi`](/aspnet/core/fundamentals/openapi/aspnetcore-openapi).
