---
title: What's new in ASP.NET Core 10.0
author: rick-anderson
description: Learn about the new features in ASP.NET Core 10.0.
ms.author: riande
ms.custom: mvc
ms.date: 2/12/2025
uid: aspnetcore-10
---
# What's new in ASP.NET Core 10.0

This article highlights the most significant changes in ASP.NET Core 10.0 with links to relevant documentation.

This article will be updated as new preview releases are made available. See the [Asp.Net Core announcement page](https://github.com/aspnet/announcements/issues?q=is%3Aopen+is%3Aissue+milestone%3A1.0.0-rc2) until this page is updated.

<!-- New content should be added to ~/aspnetcore-9/includes/newFeatureName.md files. This will help prevent merge conflicts in this file. -->

## Blazor

This section describes new features for Blazor.

[!INCLUDE[](~/release-notes/aspnetcore-10/includes/blazor.md)]

## SignalR

This section describes new features for SignalR.

## Minimal APIs

This section describes new features for minimal APIs.

## OpenAPI

This section describes new features for OpenAPI.

### Breaking changes

Support for OpenAPI 3.1 requires an update to the underlying OpenAPI.NET library to a new major version, 2.0.
This new version has some breaking changes from the previous version, and this may impact your applications
if you have any document, operation, or schema transformers.
Perhaps the most significant change is that the `OpenApiAny` class has been dropped in favor of using `JsonNode` directly.
If your transformers use `OpenApiAny`, you will need to update them to use `JsonNode` instead.
For example, a schema transformer to add an example in .NET 9 might look like this:

```csharp
    options.AddSchemaTransformer((schema, context, cancellationToken) =>
    {
        if (context.JsonTypeInfo.Type == typeof(WeatherForecast))
        {
            schema.Example = new OpenApiObject
            {
                ["date"] = new OpenApiString(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")),
                ["temperatureC"] = new OpenApiInteger(0),
                ["temperatureF"] = new OpenApiInteger(32),
                ["summary"] = new OpenApiString("Bracing"),
            };
        }
        return Task.CompletedTask;
    });
```

In .NET 10 the transformer to do the same task will look like this:

```csharp
    options.AddSchemaTransformer((schema, context, cancellationToken) =>
    {
        if (context.JsonTypeInfo.Type == typeof(WeatherForecast))
        {
            schema.Example = new JsonObject
            {
                ["date"] = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"),
                ["temperatureC"] = 0,
                ["temperatureF"] = 32,
                ["summary"] = "Bracing",
            };
        }
        return Task.CompletedTask;
    });
```

Note that these changes will be necessary even if you congfigure the OpenAPI version to 3.0.

## Authentication and authorization

This section describes new features for authentication and authorization.

## Miscellaneous

This section describes miscellaneous new features in ASP.NET Core 9.

## Related content
