---
title: Build web APIs with ASP.NET Core
author: scottaddie
description: Learn the basics of writing web API code in ASP.NET Core.
ms.author: scaddie
ms.custom: mvc
ms.date: 04/11/2019
uid: web-api/index
---

# Build web APIs with ASP.NET Core

By [Scott Addie](https://github.com/scottaddie) and [Tom Dykstra](https://github.com/tdykstra)

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/web-api/index/samples). ([How to download](xref:index#how-to-download-a-sample)).

This article teaches the basics of building a web API in ASP.NET Core.

## What is a web API app

The main purpose of an ASP.NET Core web app is to respond to HTTP requests from browsers by returning HTML ready to be displayed. To handle the requests and responses, the app may use MVC controllers and views or Razor Pages. A Web API app also responds to HTTP requests, but from many kinds of clients and by returning data in a format such as JSON, not HTML. To handle requests and responses, a web API app uses MVC controllers without views.

Any given ASP.NET core app can use one or more of these modes of responding to HTTP requests. A single app can include MVC controllers and views, Razor Pages, and web API controllers.

## Derive from ControllerBase

Action methods in a web API controller class are responsible for handling HTTP requests. A web API controller class derives from <xref:Microsoft.AspNetCore.Mvc.ControllerBase>. For example:

[!code-csharp[](define-controller/samples/WebApiSample.Api.21/Controllers/PetsController.cs?name=snippet_PetsControllerInherit&highlight=3)]

(There is also a <xref:Microsoft.AspNetCore.Mvc.Controller> base class. That one derives from `ControllerBase` and adds support for views, so it's not needed if the intent is to handle web API requests.

The `ControllerBase` class provides a number of properties and methods that are useful for handling HTTP requests. For example, it provides methods that:

* Return specified status codes, such as <xref:Microsoft.AspNetCore.Mvc.ControllerBase.BadRequest(Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary)> for status code 400 and <xref:Microsoft.AspNetCore.Mvc.ControllerBase.CreatedAtAction(System.String,System.Object,System.Object)> for status code 201.
* Invoke model validation TryValidateModel
* Invoke model binding TryUpdateModel
* Get the result of model validation - <xref:Microsoft.AspNetCore.Mvc.ControllerBase.ModelState>.
* Redirect the request to a different endpoint RedirectToAction
* Return a file PhysicalFile and File

MVC namespace provides a number of attributes you can use to:

* Control model binding - FromBody, Bind, ModelBinder
* Select a specified HTTP method for an action method - HttpGet
* Specify an action name different than the C# method name - ActionName
* Specify API conventions - APIConventionMethod, ApiConventionType
* Specify data type accepted - Consumes
* Specify possible responses - Produces, ProducesDefaultResponseType, ProducesErrorResponseType
* Set request limits - RequestFormLimits, RequestSizeLimit
* Specify routing - Route 

[!code-csharp[](define-controller/samples/WebApiSample.Api.21/Controllers/PetsController.cs?name=snippet_400And201&highlight=8,13)]

## ApiController attribute

ASP.NET Core 2.1 introduces the [[ApiController]](xref:Microsoft.AspNetCore.Mvc.ApiControllerAttribute) attribute to denote a web API controller class. For example:

[!code-csharp[](define-controller/samples/WebApiSample.Api.21/Controllers/ProductsController.cs?name=snippet_ControllerSignature&highlight=2)]

A compatibility version of 2.1 or later, set via <xref:Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions.SetCompatibilityVersion*>, is required to use this attribute at the controller level. For example, the highlighted code in `Startup.ConfigureServices` sets the 2.1 compatibility flag:

[!code-csharp[](define-controller/samples/WebApiSample.Api.21/Startup.cs?name=snippet_SetCompatibilityVersion&highlight=2)]

For more information, see <xref:mvc/compatibility-version>.

The ApiController attribute provides the following behaviors:
* Automatic HTTP 400 responses
* binding source parameter inference
* Multipart/form-data request inference
* Attribute routing requirement
* Problem details for error status codes

Controllers intended for use as web API controllers should have the ApiController applied to them unless one or more of these behaviors won't work in a particular scenario.



## Apply ApiController to all controllers

In ASP.NET Core 2.2 or later, the `[ApiController]` attribute can be applied to an assembly. Annotation in this manner applies web API behavior to all controllers in the assembly. Beware that there's no way to opt out for individual controllers. As a recommendation, assembly-level attributes should be applied to the `Startup` class:

[!code-csharp[](define-controller/samples/WebApiSample.Api.22/Startup.cs?name=snippet_ApiControllerAttributeOnAssembly&highlight=1)]

A compatibility version of 2.2 or later, set via <xref:Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions.SetCompatibilityVersion*>, is required to use this attribute at the assembly level.

Another approach is to create a custom base controller class annotated with the `[ApiController]` attribute:

[!code-csharp[](define-controller/samples/WebApiSample.Api.21/Controllers/MyBaseController.cs?name=snippet_ControllerSignature)]

The following sections describe convenience features added by the attribute.

## ApiController - Automatic HTTP 400 responses

Model validation errors automatically trigger an HTTP 400 response. Consequently, the following code becomes unnecessary in your actions:

[!code-csharp[](define-controller/samples/WebApiSample.Api.Pre21/Controllers/PetsController.cs?name=snippet_ModelStateIsValidCheck)]

Use <xref:Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.InvalidModelStateResponseFactory> to customize the output of the resulting response.

Disabling the default behavior is useful when your action can recover from a model validation error. The default behavior is disabled when the <xref:Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.SuppressModelStateInvalidFilter> property is set to `true`. Add the following code in `Startup.ConfigureServices` after `services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_<version_number>);`:

[!code-csharp[](define-controller/samples/WebApiSample.Api.22/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=7)]

With a compatibility flag of 2.2 or later, the default response type for HTTP 400 responses is <xref:Microsoft.AspNetCore.Mvc.ValidationProblemDetails>. The `ValidationProblemDetails` type complies with the [RFC 7807 specification](https://tools.ietf.org/html/rfc7807). Set the `SuppressUseValidationProblemDetailsForInvalidModelStateResponses` property to `true` to instead return the ASP.NET Core 2.1 error format of <xref:Microsoft.AspNetCore.Mvc.SerializableError>. Add the following code in `Startup.ConfigureServices`:

```csharp
services.AddMvc()
    .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
    .ConfigureApiBehaviorOptions(options =>
    {
        options
          .SuppressUseValidationProblemDetailsForInvalidModelStateResponses = true;
    });
```

## ApiController - binding source parameter inference

A binding source attribute defines the location at which an action parameter's value is found. The following binding source attributes exist:

|Attribute|Binding source |
|---------|---------|
|**[[FromBody]](xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute)**     | Request body |
|**[[FromForm]](xref:Microsoft.AspNetCore.Mvc.FromFormAttribute)**     | Form data in the request body |
|**[[FromHeader]](xref:Microsoft.AspNetCore.Mvc.FromHeaderAttribute)** | Request header |
|**[[FromQuery]](xref:Microsoft.AspNetCore.Mvc.FromQueryAttribute)**   | Request query string parameter |
|**[[FromRoute]](xref:Microsoft.AspNetCore.Mvc.FromRouteAttribute)**   | Route data from the current request |
|**[[FromServices]](xref:mvc/controllers/dependency-injection#action-injection-with-fromservices)** | The request service injected as an action parameter |

> [!WARNING]
> Don't use `[FromRoute]` when values might contain `%2f` (that is `/`). `%2f` won't be unescaped to `/`. Use `[FromQuery]` if the value might contain `%2f`.

Without the `[ApiController]` attribute, binding source attributes are explicitly defined. Without `[ApiController]` or other binding source attributes like `[FromQuery]`, the ASP.NET Core runtime attempts to use the complex object model binder. The complex object model binder pulls data from value providers (which have a defined order). For instance, the 'body model binder' is always opt in.

In the following example, the `[FromQuery]` attribute indicates that the `discontinuedOnly` parameter value is provided in the request URL's query string:

[!code-csharp[](define-controller/samples/WebApiSample.Api.21/Controllers/ProductsController.cs?name=snippet_BindingSourceAttributes&highlight=3)]

Inference rules are applied for the default data sources of action parameters. These rules configure the binding sources you're otherwise likely to manually apply to the action parameters. The binding source attributes behave as follows:

* **[FromBody]** is inferred for complex type parameters. An exception to this rule is any complex, built-in type with a special meaning, such as <xref:Microsoft.AspNetCore.Http.IFormCollection> and <xref:System.Threading.CancellationToken>. The binding source inference code ignores those special types. `[FromBody]` isn't inferred for simple types such as `string` or `int`. Therefore, the `[FromBody]` attribute should be used for simple types when that functionality is needed. When an action has more than one parameter explicitly specified (via `[FromBody]`) or inferred as bound from the request body, an exception is thrown. For example, the following action signatures cause an exception:

    [!code-csharp[](define-controller/samples/WebApiSample.Api.21/Controllers/TestController.cs?name=snippet_ActionsCausingExceptions)]

    > [!NOTE]
    > In ASP.NET Core 2.1, collection type parameters such as lists and arrays are incorrectly inferred as [[FromQuery]](xref:Microsoft.AspNetCore.Mvc.FromQueryAttribute). [[FromBody]](xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute) should be used for these parameters if they are to be bound from the request body. This behavior is fixed in ASP.NET Core 2.2 or later, where collection type parameters are inferred to be bound from the body by default.

* **[FromForm]** is inferred for action parameters of type <xref:Microsoft.AspNetCore.Http.IFormFile> and <xref:Microsoft.AspNetCore.Http.IFormFileCollection>. It's not inferred for any simple or user-defined types.
* **[FromRoute]** is inferred for any action parameter name matching a parameter in the route template. When more than one route matches an action parameter, any route value is considered `[FromRoute]`.
* **[FromQuery]** is inferred for any other action parameters.

The default inference rules are disabled when the <xref:Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.SuppressInferBindingSourcesForParameters> property is set to `true`. Add the following code in `Startup.ConfigureServices` after `services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_<version_number>);`:

[!code-csharp[](define-controller/samples/WebApiSample.Api.22/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=6)]

## ApiController - Multipart/form-data request inference

When an action parameter is annotated with the [[FromForm]](xref:Microsoft.AspNetCore.Mvc.FromFormAttribute) attribute, the `multipart/form-data` request content type is inferred.

The default behavior is disabled when the <xref:Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.SuppressConsumesConstraintForFormFileParameters> property is set to `true`.

Add the following code in `Startup.ConfigureServices`:

[!code-csharp[](define-controller/samples/WebApiSample.Api.22/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=5)]
### ApiController - Attribute routing requirement

Attribute routing becomes a requirement. For example:

[!code-csharp[](define-controller/samples/WebApiSample.Api.21/Controllers/ProductsController.cs?name=snippet_ControllerSignature&highlight=1)]

Actions are inaccessible via [conventional routes](xref:mvc/controllers/routing#conventional-routing) defined in <xref:Microsoft.AspNetCore.Builder.MvcApplicationBuilderExtensions.UseMvc*> or by <xref:Microsoft.AspNetCore.Builder.MvcApplicationBuilderExtensions.UseMvcWithDefaultRoute*> in `Startup.Configure`.

### ApiController - Problem details for error status codes

In ASP.NET Core 2.2 or later, MVC transforms an error result (a result with status code 400 or higher) to a result with <xref:Microsoft.AspNetCore.Mvc.ProblemDetails>. `ProblemDetails` is:

* A type based on the [RFC 7807 specification](https://tools.ietf.org/html/rfc7807).
* A standardized format for specifying machine-readable error details in an HTTP response.

Consider the following code in a controller action:

[!code-csharp[](define-controller/samples/WebApiSample.Api.22/Controllers/ProductsController.cs?name=snippet_ProblemDetailsStatusCode)]

The HTTP response for `NotFound` has a 404 status code with a `ProblemDetails` body. For example:

```json
{
    type: "https://tools.ietf.org/html/rfc7231#section-6.5.4",
    title: "Not Found",
    status: 404,
    traceId: "0HLHLV31KRN83:00000001"
}
```

The problem details feature requires a compatibility flag of 2.2 or later. The default behavior is disabled when the `SuppressMapClientErrors` property is set to `true`. Add the following code in `Startup.ConfigureServices`:

[!code-csharp[](define-controller/samples/WebApiSample.Api.22/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=8)]

Use the `ClientErrorMapping` property to configure the contents of the `ProblemDetails` response. For example, the following code updates the `type` property for 404 responses:

[!code-csharp[](define-controller/samples/WebApiSample.Api.22/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=10-11)]

## Additional resources

* <xref:web-api/action-return-types>
* <xref:web-api/advanced/custom-formatters>
* <xref:web-api/advanced/formatting>
* <xref:tutorials/web-api-help-pages-using-swagger>
* <xref:mvc/controllers/routing>
