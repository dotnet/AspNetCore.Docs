---
title: Define a controller in ASP.NET Core Web API
author: scottaddie
description: Learn about the options for defining a controller class in an ASP.NET Core Web API and when it's most appropriate to use each.
manager: wpickett
ms.author: scaddie
ms.custom: mvc
ms.date: 04/18/2018
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: web-api/define-controller
---
# Define a controller in ASP.NET Core Web API

By [Scott Addie](https://github.com/scottaddie)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/web-api/define-controller/samples) ([how to download](xref:tutorials/index#how-to-download-a-sample))

ASP.NET Core offers the following options for creating a Web API controller:

::: moniker range="<= aspnetcore-2.0"
* [Derive class from Controller](#derive-class-from-controller)
* [Derive class from ControllerBase](#derive-class-from-controllerbase)
::: moniker-end
::: moniker range=">= aspnetcore-2.1"
* [Derive class from Controller](#derive-class-from-controller)
* [Derive class from ControllerBase](#derive-class-from-controllerbase)
* [Annotate class with ApiControllerAttribute](#annotate-class-with-apicontrollerattribute)
::: moniker-end

This document explains when it's most appropriate to use each option.

## Derive class from Controller

Inherit from the [Controller](/dotnet/api/microsoft.aspnetcore.mvc.controller) class when your controller needs to support presentation layer concerns in addition to Web API actions. Examples of presentation layer concerns include returning MVC views or [invoking view components](xref:mvc/views/view-components#invoking-a-view-component-directly-from-a-controller).

[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api.Pre21/Controllers/OrdersController.cs?name=snippet_OrdersController&highlight=1)]

In the preceding controller, the `Index` action returns a [ViewResult](/dotnet/api/microsoft.aspnetcore.mvc.viewresult) representing the associated MVC view at *Views/Orders/Index.cshtml*. The `GetById` and `CreateAsync` actions respond to HTTP GET and POST requests, respectively.

## Derive class from ControllerBase

Inherit from the [ControllerBase](/dotnet/api/microsoft.aspnetcore.mvc.controllerbase) class when your controller doesn't need to return MVC views or [invoke view components]((xref:mvc/views/view-components#invoking-a-view-component-directly-from-a-controller)). For example, the following controller only supports Web API actions:

[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api.Pre21/Controllers/PetsController.cs?name=snippet_PetsController&highlight=3)]

A benefit of deriving from `ControllerBase` instead of `Controller` is that IntelliSense displays only Web API-specific members.

::: moniker range=">= aspnetcore-2.1"
## Annotate class with ApiControllerAttribute

ASP.NET Core 2.1 introduces the `[ApiController]` attribute to denote a Web API controller class. For example:

[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api/Controllers/ProductsController.cs?name=snippet_ControllerSignature&highlight=2)]

This attribute is commonly coupled with either `ControllerBase` or `Controller` to gain access to useful methods and properties. `ControllerBase` provides access to methods such as [CreatedAtAction](/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.createdataction) and [File](/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.file). `Controller` provides access to methods such as [Json](/dotnet/api/microsoft.aspnetcore.mvc.controller.json) and [View](/dotnet/api/microsoft.aspnetcore.mvc.controller.view).

The following sections describe convenience features added by the attribute.

### Automatic HTTP 400 responses

Validation errors automatically trigger an HTTP 400 response. The following code becomes unnecessary in your actions:

[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api.Pre21/Controllers/PetsController.cs?range=46-49)]

This default behavior is disabled with the following code in *Startup.ConfigureServices*:

[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=5)]

### Binding source parameter inference

Inference rules are applied for the default data sources of action parameters. The binding source attributes behave as follows:

* **[[FromBody]](/dotnet/api/microsoft.aspnetcore.mvc.frombodyattribute)** is inferred for complex type parameters. An exception to this rule is any complex, built-in type with a special meaning, such as [IFormCollection](/dotnet/api/microsoft.aspnetcore.http.iformcollection) and [CancellationToken](/dotnet/api/system.threading.cancellationtoken). The binding source inference code ignores those special types. When an action has more than one parameter explicitly specified (via `[FromBody]`) or inferred as bound from the request body, an exception is thrown. For example, the following action signatures cause an exception:

[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api/Controllers/TestController.cs?name=snippet_ActionsCausingExceptions)]

* **[[FromForm]](/dotnet/api/microsoft.aspnetcore.mvc.fromformattribute)** is inferred for action parameters of type [IFormFile](/dotnet/api/microsoft.aspnetcore.http.iformfile) and [IFormFileCollection](/dotnet/api/microsoft.aspnetcore.http.iformfilecollection).
* **[[FromRoute]](/dotnet/api/microsoft.aspnetcore.mvc.fromrouteattribute)** is inferred for any action parameter name matching a parameter in the route template. When multiple routes match an action parameter, any route value is considered `[FromRoute]`.
* **[[FromQuery]](/dotnet/api/microsoft.aspnetcore.mvc.fromqueryattribute)** is inferred for anything else.

The default inference rules are disabled with the following code in *Startup.ConfigureServices*:

[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=4)]

### Multipart/form-data request inference

When an action parameter is annotated with the [[FromForm]](/dotnet/api/microsoft.aspnetcore.mvc.fromformattribute) attribute, the `multipart/form-data` request constraint is inferred.

The default behavior is disabled with the following code in *Startup.ConfigureServices*:

[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=3)]

### Attribute routing requirement

Attribute routing becomes a requirement. For example:

[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api/Controllers/ProductsController.cs?name=snippet_ControllerSignature&highlight=1)]

Actions are inaccessible via [conventional routes](xref:mvc/controllers/routing#conventional-routing) defined in [UseMvc](/dotnet/api/microsoft.aspnetcore.builder.mvcapplicationbuilderextensions.usemvc#Microsoft_AspNetCore_Builder_MvcApplicationBuilderExtensions_UseMvc_Microsoft_AspNetCore_Builder_IApplicationBuilder_System_Action_Microsoft_AspNetCore_Routing_IRouteBuilder__) or by [UseMvcWithDefaultRoute](/dotnet/api/microsoft.aspnetcore.builder.mvcapplicationbuilderextensions.usemvcwithdefaultroute#Microsoft_AspNetCore_Builder_MvcApplicationBuilderExtensions_UseMvcWithDefaultRoute_Microsoft_AspNetCore_Builder_IApplicationBuilder_) in *Startup.Configure*.
::: moniker-end

## Additional resources

::: moniker range=">= aspnetcore-2.1"
* [Controller action return types in ASP.NET Core Web API](xref:web-api/action-return-types)
* [Routing to controller actions in ASP.NET Core](xref:mvc/controllers/routing)
::: moniker-end

::: moniker range="<= aspnetcore-2.0"
* [Routing to controller actions in ASP.NET Core](xref:mvc/controllers/routing)
::: moniker-end