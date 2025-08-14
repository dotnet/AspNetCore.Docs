---
title: APIs overview
author: JeremyLikness
description: Learn how to build fast HTTP APIs with ASP.NET Core using Minimal APIs, the recommended approach for new projects.
ai-usage: ai-assisted
ms.author: jeliknes
ms.date: 01/16/2025
monikerRange: '>= aspnetcore-6.0'
uid: fundamentals/apis
---

# APIs overview

[!INCLUDE[](~/includes/not-latest-version.md)]

 :::moniker range=">= aspnetcore-7.0"

ASP.NET Core provides two approaches for building HTTP APIs: **Minimal APIs** and controller-based APIs. **For new projects, we recommend using Minimal APIs** as they provide a simplified, high-performance approach for building APIs with minimal code and configuration.

## Minimal APIs - Recommended for new projects

Minimal APIs are the recommended approach for building fast HTTP APIs with ASP.NET Core. They allow you to build fully functioning REST endpoints with minimal code and configuration. Skip traditional scaffolding and avoid unnecessary controllers by fluently declaring API routes and actions.

Here's a simple example that creates an API at the root of the web app:

```csharp
var app = WebApplication.Create(args);

app.MapGet("/", () => "Hello World!");

app.Run();
```

Most APIs accept parameters as part of the route:

```csharp 
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/users/{userId}/books/{bookId}", 
    (int userId, int bookId) => $"The user id is {userId} and book id is {bookId}");

app.Run();
```

Minimal APIs support the configuration and customization needed to scale to multiple APIs, handle complex routes, apply authorization rules, and control the content of API responses.

### Getting started with Minimal APIs

* **Tutorial**: <xref:tutorials/min-web-api>
* **Quick reference**: <xref:fundamentals/minimal-apis>
* **Examples**: For a full list of common scenarios with code examples, see <xref:fundamentals/minimal-apis>

## Controller-based APIs - Alternative approach

ASP.NET Core also supports a controller-based approach where controllers are classes that derive from <xref:Microsoft.AspNetCore.Mvc.ControllerBase>. This approach follows traditional object-oriented patterns and may be preferred for:

* Large applications with complex business logic
* Teams familiar with the MVC pattern
* Applications requiring specific MVC features

Here's sample code for an API based on controllers:

:::code language="csharp" source="~/fundamentals/apis/APIWithControllers/Program.cs":::

:::code language="csharp" source="~/fundamentals/apis/APIWithControllers/Controllers/WeatherForecastController.cs":::

The following code provides the same functionality using the recommended Minimal API approach:

:::code language="csharp" source="~/fundamentals/apis/MinimalAPI/Program.cs":::

Both API projects refer to the following class:

:::code language="csharp" source="~/fundamentals/apis/APIWithControllers/WeatherForecast.cs":::

## Choosing between approaches

**Start with Minimal APIs** for new projects. They offer:

* **Simpler syntax** - Less boilerplate code
* **Better performance** - Reduced overhead compared to controllers
* **Easier testing** - Simplified unit and integration testing
* **Modern approach** - Leverages the latest .NET features

**Consider controller-based APIs** if you need:

* Model binding extensibility (<xref:Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderProvider>, <xref:Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder>)
* Advanced validation features (<xref:Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidator>)
* [Application parts](xref:mvc/extensibility/app-parts) or the [application model](xref:mvc/controllers/application-model)
* [JsonPatch](https://www.nuget.org/packages/Microsoft.AspNetCore.JsonPatch/) support
* [OData](https://www.nuget.org/packages/Microsoft.AspNetCore.OData/) support

Most of these features can be implemented in Minimal APIs with custom solutions, but controllers provide them out of the box.

## See also

* <xref:tutorials/min-web-api> - Minimal API tutorial
* <xref:fundamentals/minimal-apis> - Minimal APIs quick reference
* <xref:web-api/index> - Controller-based APIs overview
* <xref:tutorials/first-web-api> - Controller-based API tutorial

:::moniker-end

:::moniker range="= aspnetcore-6.0"

ASP.NET Core provides two approaches for building HTTP APIs: **Minimal APIs** and controller-based APIs. **For new projects, we recommend using Minimal APIs** as they provide a simplified, high-performance approach for building APIs with minimal code and configuration.

## Minimal APIs - Recommended for new projects

Minimal APIs are the recommended approach for building fast HTTP APIs with ASP.NET Core. They allow you to build fully functioning REST endpoints with minimal code and configuration.

Here's a simple example:

```csharp
var app = WebApplication.Create(args);

app.MapGet("/", () => "Hello World!");

app.Run();
```

### Getting started with Minimal APIs

* **Tutorial**: <xref:tutorials/min-web-api>
* **Quick reference**: <xref:fundamentals/minimal-apis>

## Controller-based APIs - Alternative approach

Controllers are classes that derive from <xref:Microsoft.AspNetCore.Mvc.ControllerBase>. This approach follows traditional object-oriented patterns.

Here's sample code for an API based on controllers:

:::code language="csharp" source="~/fundamentals/apis/APIWithControllers/Program.cs":::

:::code language="csharp" source="~/fundamentals/apis/APIWithControllers/Controllers/WeatherForecastController.cs":::

The following code provides the same functionality using the recommended Minimal API approach:

:::code language="csharp" source="~/fundamentals/apis/MinimalAPI/Program.cs":::

Both API projects refer to the following class:

:::code language="csharp" source="~/fundamentals/apis/APIWithControllers/WeatherForecast.cs":::

## Choosing between approaches

**Start with Minimal APIs** for new projects. Consider controller-based APIs if you need:

* Model binding extensibility (<xref:Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderProvider>, <xref:Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder>)
* Form binding support, including <xref:Microsoft.AspNetCore.Http.IFormFile>
* Advanced validation features (<xref:Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidator>)
* [Application parts](xref:mvc/extensibility/app-parts) or the [application model](xref:mvc/controllers/application-model)
* [JsonPatch](https://www.nuget.org/packages/Microsoft.AspNetCore.JsonPatch/) support
* [OData](https://www.nuget.org/packages/Microsoft.AspNetCore.OData/) support

## See also

* <xref:tutorials/min-web-api> - Minimal API tutorial
* <xref:fundamentals/minimal-apis> - Minimal APIs quick reference
* <xref:web-api/index> - Controller-based APIs overview
* <xref:tutorials/first-web-api> - Controller-based API tutorial

:::moniker-end
