---
title: What's new in ASP.NET Core 7.0
author: rick-anderson
description: Learn about the new features in ASP.NET Core 7.0.
ms.author: riande
ms.custom: mvc
ms.date: 10/29/2021
uid: aspnetcore-7
---
# What's new in ASP.NET Core 7.0 preview

This article highlights the most significant changes in ASP.NET Core 7.0 with links to relevant documentation.

## API controllers

Parameter binding for API controller actions binds parameters through [dependency injection](xref:fundamentals/dependency-injection) when the type is configured as a service. This means it’s no longer required to explicitly apply the [`[FromServices]`](xref:Microsoft.AspNetCore.Mvc.FromServicesAttribute) attribute to a parameter. In the following code, both actions return the time:

[!code-csharp[](~/release-notes/aspnetcore-7/samples/ApiController/Controllers/MyController.cs?name=snippet)]

In rare cases, automatic DI can break apps that have a type in DI that is also accepted in an API controllers action methods. It's not common to have a type in DI and as an argument in an API controller action. To disable automatic binding of parameters, set `DisableImplicitFromServicesParameters = true`:

[!code-csharp[](~/release-notes/aspnetcore-7/samples/ApiController/Program.cs?name=snippet_dis&highlight=8-11)]

Prior to ASP.NET Core 7, one of the following approaches must be used to bind a source in API Controller action:

* The parameter must be decorated using an attribute that implements `IFromServiceMetadata`, for example `FromServicesAttribute`.
* The parameter is resolved from the request Body sent by the client.

In ASP.NET Core 7.0, types in DI are checked at app startup with <xref:System.IServiceProvider> to determine if an argument in an API controller action comes from DI or from the other sources.

The new mechanism to infer binding source of API Controller action parameters uses the following rules:

1. A previously specified [`BindingInfo.BindingSource`](xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingInfo.BindingSource) is never overwritten.
1. A complex type parameter, registered in the DI container, is assigned [`BindingSource.Services`](xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Services).
1. A complex type parameter, not registered in the DI container, is assigned [`BindingSource.Body`](xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Body).
1. Parameter with a name that appears as a route value in ***any*** route template is assigned [`BindingSource.Path`](xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Path).
1. All other parameters are [`BindingSource.Query`](xref:Microsoft.AspNetCore.Mvc.ModelBinding.BindingSource.Query.

## IIS

### Shadow copying in IIS

Shadow copying app assemblies to the [ASP.NET Core Module (ANCM)](xref:host-and-deploy/aspnet-core-module) for IIS can provide a better end user experience than stopping the app by deploying an [app offline file](xref:host-and-deploy/iis/app-offline).

For more information, see [](xref:host-and-deploy/iis/advanced?view=aspnetcore-7.0#shadow-copy)
