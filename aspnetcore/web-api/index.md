---
title: Build web APIs with ASP.NET Core
author: scottaddie
description: Learn about the features available for building a web API in ASP.NET Core and when it's appropriate to use each feature.
manager: wpickett
ms.author: scaddie
ms.custom: mvc
ms.date: 04/23/2018
ms.prod: aspnet-core
ms.technology: aspnet
ms.topic: article
uid: web-api/index
---
# Build web APIs with ASP.NET Core

By [Scott Addie](https://github.com/scottaddie)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/web-api/define-controller/samples) ([how to download](xref:tutorials/index#how-to-download-a-sample))

ASP.NET Core offers the following options for creating a web API controller:

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

Inherit from the [Controller](/dotnet/api/microsoft.aspnetcore.mvc.controller) class in a controller that needs to support HTML and Razor in addition to web API actions. Examples that require `Controller` inheritance include returning MVC views or [invoking view components](xref:mvc/views/view-components#invoking-a-view-component-directly-from-a-controller).

::: moniker range=">= aspnetcore-2.1"
[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api/Controllers/OrdersController.cs?name=snippet_OrdersController&highlight=1)]
::: moniker-end
::: moniker range="<= aspnetcore-2.0"
[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api.Pre21/Controllers/OrdersController.cs?name=snippet_OrdersController&highlight=1)]
:::moniker-end

In the preceding controller, the `Index` action returns a [ViewResult](/dotnet/api/microsoft.aspnetcore.mvc.viewresult) representing the associated MVC view at *Views/Orders/Index.cshtml*. The `GetById` and `CreateAsync` actions respond to HTTP GET and POST requests, respectively.

## Derive class from ControllerBase

Inherit from the [ControllerBase](/dotnet/api/microsoft.aspnetcore.mvc.controllerbase) class in a controller that doesn't need to support HTML and Razor. For example, the following controller only supports Web API actions:

::: moniker range=">= aspnetcore-2.1"
[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api/Controllers/PetsController.cs?name=snippet_PetsController&highlight=3)]
::: moniker-end
::: moniker range="<= aspnetcore-2.0"
[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api.Pre21/Controllers/PetsController.cs?name=snippet_PetsController&highlight=3)]
::: moniker-end

A benefit of deriving from `ControllerBase` instead of `Controller` is that IntelliSense displays only web API-specific members.

::: moniker range=">= aspnetcore-2.1"
## Annotate class with ApiControllerAttribute

ASP.NET Core 2.1 introduces the `[ApiController]` attribute to denote a web API controller class. For example:

[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api/Controllers/ProductsController.cs?name=snippet_ControllerSignature&highlight=2)]

This attribute is commonly coupled with either `ControllerBase` or `Controller` to gain access to useful methods and properties. `ControllerBase` provides access to methods such as [CreatedAtAction](/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.createdataction) and [File](/dotnet/api/microsoft.aspnetcore.mvc.controllerbase.file). `Controller` provides access to methods such as [Json](/dotnet/api/microsoft.aspnetcore.mvc.controller.json) and [View](/dotnet/api/microsoft.aspnetcore.mvc.controller.view). Another approach is to create a custom base controller class annotated with the `[ApiController]` attribute.

The following sections describe convenience features added by the attribute.

### Automatic HTTP 400 responses

Validation errors automatically trigger an HTTP 400 response. The following code becomes unnecessary in your actions:

[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api.Pre21/Controllers/PetsController.cs?range=46-49)]

This default behavior is disabled with the following code in *Startup.ConfigureServices*:

[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=5)]

### Binding source parameter inference

A binding source attribute defines the location at which an action parameter's value is found. The following binding source attributes exist:

|Attribute|Binding source |
|---------|---------|
|**[[FromBody]](/dotnet/api/microsoft.aspnetcore.mvc.frombodyattribute)**     | Request body |
|**[[FromForm]](/dotnet/api/microsoft.aspnetcore.mvc.fromformattribute)**     | Form data in the request body |
|**[[FromHeader]](/dotnet/api/microsoft.aspnetcore.mvc.fromheaderattribute)** | Request header |
|**[[FromQuery]](/dotnet/api/microsoft.aspnetcore.mvc.fromqueryattribute)**   | Request query string parameter |
|**[[FromRoute]](/dotnet/api/microsoft.aspnetcore.mvc.fromrouteattribute)**   | Route data from the current request |
|**[[FromServices]](xref:mvc/controllers/dependency-injection#action-injection-with-fromservices)** | The request service injected as an action parameter |

Without the `[ApiController]` attribute, binding source attributes are explicitly defined. In the following example, the `[FromQuery]` attribute indicates that the `discontinuedOnly` parameter value is provided in the request URL's query string:

[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api/Controllers/ProductsController.cs?name=snippet_BindingSourceAttributes&highlight=3)]

Inference rules are applied for the default data sources of action parameters. These rules configure the binding sources you're otherwise likely to manually apply to the action parameters. The binding source attributes behave as follows:

* **[FromBody]** is inferred for complex type parameters. An exception to this rule is any complex, built-in type with a special meaning, such as [IFormCollection](/dotnet/api/microsoft.aspnetcore.http.iformcollection) and [CancellationToken](/dotnet/api/system.threading.cancellationtoken). The binding source inference code ignores those special types. When an action has more than one parameter explicitly specified (via `[FromBody]`) or inferred as bound from the request body, an exception is thrown. For example, the following action signatures cause an exception:

[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api/Controllers/TestController.cs?name=snippet_ActionsCausingExceptions)]

* **[FromForm]** is inferred for action parameters of type [IFormFile](/dotnet/api/microsoft.aspnetcore.http.iformfile) and [IFormFileCollection](/dotnet/api/microsoft.aspnetcore.http.iformfilecollection). It's not inferred for any simple or user-defined types.
* **[FromRoute]** is inferred for any action parameter name matching a parameter in the route template. When multiple routes match an action parameter, any route value is considered `[FromRoute]`.
* **[FromQuery]** is inferred for any other action parameters.

The default inference rules are disabled with the following code in *Startup.ConfigureServices*:

[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=4)]

### Multipart/form-data request inference

When an action parameter is annotated with the [[FromForm]](/dotnet/api/microsoft.aspnetcore.mvc.fromformattribute) attribute, the `multipart/form-data` request content type is inferred.

The default behavior is disabled with the following code in *Startup.ConfigureServices*:

[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=3)]

### Attribute routing requirement

Attribute routing becomes a requirement. For example:

[!code-csharp[](../web-api/define-controller/samples/WebApiSample.Api/Controllers/ProductsController.cs?name=snippet_ControllerSignature&highlight=1)]

Actions are inaccessible via [conventional routes](xref:mvc/controllers/routing#conventional-routing) defined in [UseMvc](/dotnet/api/microsoft.aspnetcore.builder.mvcapplicationbuilderextensions.usemvc#Microsoft_AspNetCore_Builder_MvcApplicationBuilderExtensions_UseMvc_Microsoft_AspNetCore_Builder_IApplicationBuilder_System_Action_Microsoft_AspNetCore_Routing_IRouteBuilder__) or by [UseMvcWithDefaultRoute](/dotnet/api/microsoft.aspnetcore.builder.mvcapplicationbuilderextensions.usemvcwithdefaultroute#Microsoft_AspNetCore_Builder_MvcApplicationBuilderExtensions_UseMvcWithDefaultRoute_Microsoft_AspNetCore_Builder_IApplicationBuilder_) in *Startup.Configure*.
::: moniker-end

## Additional resources

* [Controller action return types](xref:web-api/action-return-types)
* [Custom formatters](xref:web-api/advanced/custom-formatters)
* [Format response data](xref:web-api/advanced/formatting)
* [Help pages using Swagger](xref:tutorials/web-api-help-pages-using-swagger)
* [Routing to controller actions](xref:mvc/controllers/routing)