---
title: Define a controller in ASP.NET Core Web API
author: scottaddie
description: Learn about the options for defining a controller class in an ASP.NET Core Web API and when it's most appropriate to use each.
manager: wpickett
ms.author: scaddie
ms.custom: mvc
ms.date: 04/17/2018
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: web-api/define-controller
---
# Define a controller in ASP.NET Core Web API

By [Scott Addie](https://github.com/scottaddie)

::: moniker range=">= aspnetcore-2.1"
[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/web-api/define-controller/samples) ([how to download](xref:tutorials/index#how-to-download-a-sample))
::: moniker-end

ASP.NET Core offers the following options for creating a Web API controller:

::: moniker range="<= aspnetcore-2.0"
* [Derive class from Controller](#derive-class-from-controller)
* [Derive class from ControllerBase](#derive-class-from-controllerbase)
::: moniker-end
::: moniker range=">= aspnetcore-2.1"
* [Derive class from Controller](#derive-class-from-controller)
* [Derive class from ControllerBase](#derive-class-from-controllerbase)
* [Decorate class with ApiControllerAttribute](#decorate-class-with-apicontrollerattribute)
::: moniker-end

This document explains when it's most appropriate to use each option.

## Derive class from Controller

Inherit from the [Controller](/dotnet/api/microsoft.aspnetcore.mvc.controller) class when your controller needs to support MVC views in addition to Web API actions. For example:

```csharp
[Route("api/[controller]")]
public class ProductsController : Controller
{
}
```

## Derive class from ControllerBase

Inherit from the [ControllerBase](/dotnet/api/microsoft.aspnetcore.mvc.controllerbase) class when your controller doesn't need to support MVC views. For example:

```csharp
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
}
```

::: moniker range=">= aspnetcore-2.1"
## Decorate class with ApiControllerAttribute

ASP.NET Core 2.1 introduces the `[ApiController]` attribute to denote a Web API controller class. For example:

[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api/Controllers/ProductsController.cs?name=snippet_ControllerSignature&highlight=2)]

The following sections describe convenience features added by the attribute.

### Automatic HTTP 400 responses

Validation errors automatically trigger an HTTP 400 response. The following code becomes unnecessary:

```csharp
if (!ModelState.IsValid)
{
    return BadRequest(ModelState);
}
```

This default behavior is disabled with the following code in *Startup.ConfigureServices*:

[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=5)]

### Binding source parameter inference

Inference rules are applied for the default data sources of action parameters. The binding source attributes behave as follows:

* [[FromBody]](/dotnet/api/microsoft.aspnetcore.mvc.frombodyattribute) is inferred for complex type parameters. An exception to this rule is any complex, built-in type with a special meaning, such as [IFormCollection](/dotnet/api/microsoft.aspnetcore.http.iformcollection) and [CancellationToken](/dotnet/api/system.threading.cancellationtoken). The binding source inference code ignores those special types. If you decide to explicitly apply the `[FromBody]` attribute, multiple occurrences of it in the same action results in an exception.
* [[FromForm]](/dotnet/api/microsoft.aspnetcore.mvc.fromformattribute) is inferred for action parameters of type [IFormFile](/dotnet/api/microsoft.aspnetcore.http.iformfile) and [IFormFileCollection](/dotnet/api/microsoft.aspnetcore.http.iformfilecollection).
* [[FromRoute]](/dotnet/api/microsoft.aspnetcore.mvc.fromrouteattribute) is inferred for any action parameter name matching a parameter in the route template. When multiple routes match an action parameter, any route value is considered `[FromRoute]`.
* [[FromQuery]](/dotnet/api/microsoft.aspnetcore.mvc.fromqueryattribute) is inferred for anything else.

For example, the `[FromBody]` attribute is implied for the `Product` parameter:

[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api/Controllers/ProductsController.cs?name=snippet_CreateAsync)]

The preceding action requires access to the [CreatedAtAction](/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.createdataction#Microsoft_AspNetCore_Mvc_ControllerBase_CreatedAtAction_System_String_System_Object_System_Object_) method. For this reason only, the controller to which the action belongs inherits from `ControllerBase`.

The default inference rules are disabled with the following code in *Startup.ConfigureServices*:

[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=4)]

### Multipart/form-data request inference

When an action parameter is annotated with the [[FromForm]](/dotnet/api/microsoft.aspnetcore.mvc.fromformattribute) attribute, the `multipart/form-data` request format is inferred.

The default behavior is disabled with the following code in *Startup.ConfigureServices*:

[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=3)]

### Attribute routing requirement

Attribute routing becomes a requirement. For example:

[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api/Controllers/ProductsController.cs?name=snippet_ControllerSignature&highlight=1)]

Actions are inaccessible via convention-based routes defined via [UseMvc](/dotnet/api/microsoft.aspnetcore.builder.mvcapplicationbuilderextensions.usemvc#Microsoft_AspNetCore_Builder_MvcApplicationBuilderExtensions_UseMvc_Microsoft_AspNetCore_Builder_IApplicationBuilder_System_Action_Microsoft_AspNetCore_Routing_IRouteBuilder__) in *Startup.Configure*.
::: moniker-end

## Additional resources
