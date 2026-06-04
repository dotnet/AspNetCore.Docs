---
title: "Breaking change: Microsoft.OpenApi upgraded to 3.x"
description: "Learn about the breaking change in ASP.NET Core 11 where Microsoft.AspNetCore.OpenApi takes a dependency on Microsoft.OpenApi 3.x. Document and operation transformers might need updates."
ms.date: 06/04/2026
ai-usage: ai-assisted
---

# Microsoft.OpenApi upgraded to 3.x

`Microsoft.AspNetCore.OpenApi` in ASP.NET Core 11 takes a dependency on `Microsoft.OpenApi` 3.x (currently 3.6.0). The previous release (.NET 10) depended on `Microsoft.OpenApi` 2.x. This is a major-version bump of a transitive dependency, and several types that document and operation transformers receive have changed shape.

## Version introduced

.NET 11 Preview 3

## Previous behavior

Previously, `Microsoft.AspNetCore.OpenApi` depended on `Microsoft.OpenApi` 2.x. Implementations of the document, operation, and schema transformer interfaces worked against the 2.x object model — for example, against the `OpenApiSchema` shape that exposed nested schemas, references, extensions, and parsing helpers as 2.x concrete types:

```csharp
using Microsoft.AspNetCore.OpenApi;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

builder.Services.AddOpenApi(options =>
{
    options.AddSchemaTransformer((schema, context, ct) =>
    {
        // Microsoft.OpenApi 2.x: OpenApiString was a concrete type in Microsoft.OpenApi.Any.
        schema.Extensions["x-schema-id"] = new OpenApiString(context.JsonTypeInfo.Type.Name);
        return Task.CompletedTask;
    });
});
```

## New behavior

Starting in ASP.NET Core 11, `Microsoft.AspNetCore.OpenApi` depends on `Microsoft.OpenApi` 3.x. The `IOpenApiDocumentTransformer`, `IOpenApiOperationTransformer`, and `IOpenApiSchemaTransformer` interface signatures still expose the concrete `OpenApiDocument`, `OpenApiOperation`, and `OpenApiSchema` parameter types, but the surface area of those types has changed:

- Several formerly concrete types that nested types expose are now interfaces (for example, `IOpenApiSchema`, `IOpenApiAny`).
- The 2.x `OpenApiAny` types (such as `OpenApiString`, `OpenApiInteger`) were removed in favor of <xref:System.Text.Json.Nodes.JsonNode>-based extension values.
- The `ParseNode` parsing infrastructure was removed in favor of visitor- and writer-based APIs.
- The `OpenApiReference` model was reshaped to better distinguish between local and external references.

Transformer code that does anything more than read-only inspection — sets extension values, walks nested schemas, or constructs new schemas — usually needs to be updated.

## Type of breaking change

This change can affect [source compatibility](/dotnet/core/compatibility/categories#source-compatibility), and also [binary compatibility](/dotnet/core/compatibility/categories#binary-compatibility) for libraries that were compiled against `Microsoft.OpenApi` 2.x and are loaded into an app that resolves the 3.x assembly at runtime.

## Reason for change

The new `Microsoft.OpenApi` 3.x release adds support for OpenAPI 3.1.0 and 3.2.0 specifications, fixes long-standing issues in the object model, and adopts interface-based abstractions that are easier to extend. For more information, see [dotnet/aspnetcore#65415](https://github.com/dotnet/aspnetcore/pull/65415) and [dotnet/aspnetcore#66998](https://github.com/dotnet/aspnetcore/pull/66998).

## Recommended action

Update any custom document, operation, or schema transformer to compile against `Microsoft.OpenApi` 3.x. The most common changes are:

- Replace 2.x `OpenApiAny` values such as `new OpenApiString("...")` with `JsonNode` values (`JsonValue.Create("...")`).
- Update code that walks nested schemas or references to handle the new interface-based abstractions (for example, `IOpenApiSchema`).
- Update code that used the removed `ParseNode` parsing infrastructure to use the new visitor- and writer-based APIs.
- Review use of `OpenApiReference`, which was reshaped to better distinguish between local and external references.

For the canonical migration notes for the 3.0, 3.1, 3.2, and later releases, see the [OpenAPI.NET release notes](https://github.com/microsoft/OpenAPI.NET/releases).

## Affected APIs

- <xref:Microsoft.AspNetCore.OpenApi.IOpenApiDocumentTransformer>
- <xref:Microsoft.AspNetCore.OpenApi.IOpenApiOperationTransformer>
- <xref:Microsoft.AspNetCore.OpenApi.IOpenApiSchemaTransformer>
- <xref:Microsoft.AspNetCore.OpenApi.OpenApiOptions>
