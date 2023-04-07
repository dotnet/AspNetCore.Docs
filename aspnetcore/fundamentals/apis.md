---
title: "APIs overview"
author: tdykstra
description: Learn about differences between controller-based APIs and minimal APIs.
ms.author: tdykstra
ms.date: 4/10/2023
monikerRange: '>= aspnetcore-6.0'
uid: fundamentals/apis
---

# Choose between controller-based APIs and minimal APIs

[!INCLUDE[](~/includes/not-latest-version.md)]

 :::moniker range=">= aspnetcore-7.0"

ASP.NET Core supports two approaches to creating APIs: a controller-based approach and minimal APIs. *Controllers* in an API project are classes that derive from <xref:Microsoft.AspNetCore.Mvc.ControllerBase>. *Minimal APIs* define endpoints with logical handlers in lambdas or methods. This article points out differences between the two approaches.

The design of minimal APIs hides the host class by default and focuses on configuration and extensibility via extension methods that take functions as lambda expressions. Controllers are classes that can take dependencies via constructor injection or property injection, and generally follow object-oriented patterns. Minimal APIs support dependency injection through other approaches such as accessing the service provider.

Here's sample code for an API based on controllers:

:::code language="csharp" source="~/fundamentals/apis/APIWithControllers/Program.cs":::

:::code language="csharp" source="~/fundamentals/apis/APIWithControllers/Controllers/WeatherForecastController.cs":::

The following code provides the same functionality in a minimal API project. Notice that the minimal API approach involves including the related code in lambda expressions.

:::code language="csharp" source="~/fundamentals/apis/MinimalAPI/Program.cs":::

Both API projects refer to the following class:

:::code language="csharp" source="~/fundamentals/apis/APIWithControllers/WeatherForecast.cs":::

Minimal APIs have many of the same capabilities as controller-based APIs. They support the configuration and customization needed to scale to multiple APIs, handle complex routes, apply authorization rules, and control the content of API responses. There are a few capabilities available with controller-based APIs that are not yet supported or implemented by minimal APIs. These include:

- No built-in support for model binding (<xref:Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderProvider>, <xref:Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder>). Support can be added with a custom binding shim.
- No built-in support for validation (<xref:Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidator>).
- No support for [application parts](xref:mvc/extensibility/app-parts) or the [application model](xref:mvc/controllers/application-model). There's no way to apply or build your own conventions.
- No built-in view rendering support. We recommend using [Razor Pages](xref:tutorials/razor-pages/razor-pages-start) for rendering views.
- No support for [JsonPatch](https://www.nuget.org/packages/Microsoft.AspNetCore.JsonPatch/)
- No support for [OData](https://www.nuget.org/packages/Microsoft.AspNetCore.OData/)

## See also

* <xref:web-api/index>.
* <xref:tutorials/first-web-api>
* <xref:fundamentals/minimal-apis/overview>
* <xref:tutorials/min-web-api>

:::moniker-end

[!INCLUDE[](~/fundamentals/includes/apis6.md)]
