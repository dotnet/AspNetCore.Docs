---
title: "Breaking change: OpenApiVersion defaults to OpenApi3_2"
ai-usage: ai-assisted
description: "Learn about the breaking change in ASP.NET Core 11 where OpenApiOptions.OpenApiVersion defaults to OpenApiSpecVersion.OpenApi3_2 instead of OpenApiSpecVersion.OpenApi3_1."
ms.date: 06/16/2026
---
# OpenApiVersion defaults to OpenApi3_2

The default value of <xref:Microsoft.AspNetCore.OpenApi.OpenApiOptions.OpenApiVersion> has changed from `OpenApiSpecVersion.OpenApi3_1` to `OpenApiSpecVersion.OpenApi3_2`. Apps that depend on OpenAPI 3.1 output without explicitly setting the version now produce OpenAPI 3.2 documents.

## Version introduced

.NET 11 Preview 6

## Previous behavior

Previously, `OpenApiOptions.OpenApiVersion` defaulted to `OpenApiSpecVersion.OpenApi3_1`. Calling <xref:Microsoft.Extensions.DependencyInjection.OpenApiServiceCollectionExtensions.AddOpenApi%2A> without explicitly setting a version produced an OpenAPI 3.1 document.

## New behavior

Starting in ASP.NET Core 11 Preview 6, `OpenApiOptions.OpenApiVersion` defaults to `OpenApiSpecVersion.OpenApi3_2`. Calling `AddOpenApi` without explicitly setting a version now produces an OpenAPI 3.2 document.

## Type of breaking change

This change is a [behavioral change](/dotnet/core/compatibility/categories#behavioral-change).

## Reason for change

ASP.NET Core's OpenAPI support aims to always use the latest released version of the specification by default so that apps automatically benefit from new capabilities.

## Recommended action

In most cases, no action is needed. If you use downstream tooling that doesn't yet support OpenAPI 3.2, configure the version explicitly:

```csharp
builder.Services.AddOpenApi(options =>
{
    options.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi3_1;
});
```

## Affected APIs

- <xref:Microsoft.AspNetCore.OpenApi.OpenApiOptions.OpenApiVersion>
