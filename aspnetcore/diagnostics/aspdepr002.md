---
title: "ASPDEPR002: WithOpenApi is deprecated"
description: "Learn about diagnostic ASPDEPR002: The WithOpenApi extension methods are deprecated."
ai-usage: ai-assisted
author: tdykstra
monikerRange: '>= aspnetcore-10.0'
ms.author: tdykstra
ms.date: 03/03/2026
uid: diagnostics/aspdepr002
---
# ASPDEPR002: `WithOpenApi` is deprecated

|                                     | Value        |
| -                                   | -            |
| **Rule ID**                         | ASPDEPR002   |
| **Category**                        | Deprecation  |
| **Fix is breaking or non-breaking** | Non-breaking |

## Cause

The <xref:Microsoft.AspNetCore.Builder.OpenApiEndpointConventionBuilderExtensions.WithOpenApi*> extension methods are deprecated. Using these methods produces the `ASPDEPR002` diagnostic.

## Rule description

The `WithOpenApi` extension methods were deprecated in .NET 10. The functionality they provided is now available through the built-in OpenAPI document generation pipeline. Calling these methods produces the following compile-time warning:

> WithOpenApi is deprecated and will be removed in a future release. For more information, visit <https://aka.ms/aspnet/deprecate/002>.

For example, the following code generates the `ASPDEPR002` warning:

```csharp
app.MapGet("/weather", () => ...)
   .WithOpenApi();   // Warning ASPDEPR002
```

## How to fix violations

Remove `.WithOpenApi()` calls from your code.

- If you used `Microsoft.AspNetCore.OpenApi` for document generation, use the `AddOpenApiOperationTransformer` extension method instead.

  Before:

  ```csharp
  using Microsoft.AspNetCore.OpenApi;

  var builder = WebApplication.CreateBuilder();
  var app = builder.Build();

  app.MapGet("/weather", () => ...)
     .WithOpenApi(operation =>
     {
         // Per-endpoint tweaks
         operation.Summary = "Gets the current weather report.";
         operation.Description = "Returns a short description and emoji.";
         return operation;
     });

  app.Run();
  ```

  After:

  ```csharp
  using Microsoft.AspNetCore.OpenApi;

  var builder = WebApplication.CreateBuilder();
  var app = builder.Build();

  app.MapGet("/weather", () => ...)
     .AddOpenApiOperationTransformer((operation, context, ct) =>
     {
         // Per-endpoint tweaks
         operation.Summary = "Gets the current weather report.";
         operation.Description = "Returns a short description and emoji.";
         return Task.CompletedTask;
     });

  app.Run();
  ```

- If you used `Swashbuckle` for document generation, use the `IOperationFilter` API.
- If you used `NSwag` for document generation, use the `IOperationProcessor` API.

## When to suppress warnings

Suppress this warning only if you're unable to migrate away from `WithOpenApi` immediately. Note that these methods will be removed in a future release, so suppressing the warning is a temporary measure.

```csharp
#pragma warning disable ASPDEPR002
app.MapGet("/weather", () => ...).WithOpenApi();
#pragma warning restore ASPDEPR002
```

## Affected APIs

- <xref:Microsoft.AspNetCore.Builder.OpenApiEndpointConventionBuilderExtensions.WithOpenApi%2A?displayProperty=fullName>
