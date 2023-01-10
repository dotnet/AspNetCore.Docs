---
title: "APIs overview"
author: tdykstra
description: Learn how to choose between controller-based APIs and minimal APIs.
ms.author: tdykstra
ms.date: 01/10/2023
uid: fundamentals/apis
---

# How to choose between controller-based APIs and minimal APIs

ASP.NET Core supports creating web APIs using controllers or using minimal APIs. *Controllers* in a web API project are classes that derive from <xref:Microsoft.AspNetCore.Mvc.ControllerBase>. *Minimal* refers to the minimal effort, code, and configuration that is required to build fully functioning REST endpoints. This article points out differences to be aware of when choosing between the two approaches.

The design of minimal hides the host class by default and focuses on configuration and extensibility via extension methods that take lambda expressions. Controllers are classes that can take dependencies via constructor injection, use property injection, and generally follow those patterns.

Here's sample code for an API based on controllers:

:::code language="csharp" source="~/fundamentals/apis/APIWithControllers/Program.cs":::

:::code language="csharp" source="~/fundamentals/apis/APIWithControllers/Controllers/WeatherForecastController.cs":::

And the following code provides the same functionality in a minimal API project. Notice that the minimal API puts code that  corresponds to the controller code in a lambda.

:::code language="csharp" source="~/fundamentals/apis/MinimalAPI/Program.cs":::

Both API projects refer to the following class:

:::code language="csharp" source="~/fundamentals/apis/APIWithControllers/WeatherForecast.cs":::

Minimal APIs have many of the same capabilities as controller-based APIs. They support the configuration and customization needed to scale to multiple APIs, handle complex routes, apply authorization rules, and control the content of API responses. There are a few capabilities that controller-based APIs have but minimal APIs lack:

- No built-in support for model binding (<xref:Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderProvider>, <xref:Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder>). Support can be added with a custom binding shim.
- No support for binding from forms. This includes binding <xref:Microsoft.AspNetCore.Http.IFormFile>.
- No built-in support for validation (<xref:Microsoft.AspNetCore.Mvc.ModelBinding.Validation.IModelValidator>).
- No support for [application parts](xref:mvc/extensibility/app-parts) or the [application model](xref:mvc/controllers/application-model). There's no way to apply or build your own conventions.
- No built-in view rendering support. We recommend using [Razor Pages](xref:tutorials/razor-pages/razor-pages-start) for rendering views.
- No support for [JsonPatch](https://www.nuget.org/packages/Microsoft.AspNetCore.JsonPatch/)
- No support for [OData](https://www.nuget.org/packages/Microsoft.AspNetCore.OData/)

## See also

<xref:tutorials/web-api/index>.
<xref:tutorials/first-web-api>
<xref:tutorials/fundamentals/minimal-apis/overview>
<xref:tutorials/min-web-api>
