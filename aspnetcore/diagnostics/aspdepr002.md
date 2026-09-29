---
title: ASPDEPR002 warning
description: Learn about the obsoletions that generate compile-time warning ASPDEPR002.
ai-usage: ai-assisted
monikerRange: '>= aspnetcore-10.0'
ms.date: 03/03/2026
uid: diagnostics/aspdepr002
f1_keywords:
  - aspdepr002
---
# ASPDEPR002: `WithOpenApi` is deprecated

The <xref:Microsoft.AspNetCore.Builder.OpenApiEndpointConventionBuilderExtensions.WithOpenApi*> extension methods are deprecated starting in .NET 10. Using these methods produces the `ASPDEPR002` diagnostic at compile time. The functionality they provided is now available through the built-in OpenAPI document generation pipeline.

## Workarounds

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

## Suppress a warning

If you must use the deprecated APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable ASPDEPR002

// Code that uses deprecated API.
// ...

// Re-enable the warning.
#pragma warning restore ASPDEPR002
```

To suppress all the `ASPDEPR002` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);ASPDEPR002</NoWarn>
  </PropertyGroup>
</Project>
```

## See also

- [Deprecation of WithOpenApi extension method](../breaking-changes/10/withopenapi-deprecated.md)
