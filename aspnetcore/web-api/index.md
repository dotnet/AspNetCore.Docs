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

This article shows how to use web API features in ASP.NET Core MVC controllers.

## What is a web API app

ASP.NET Core can be used to build web apps and web API apps. A web app responds to HTTP requests from browsers by returning HTML ready to be displayed. To handle the requests and responses, the app may use MVC controllers and views or Razor Pages. A web API app also responds to HTTP requests, but from many kinds of clients and by returning data in a format such as JSON, not HTML. To handle requests and responses, a web API app uses MVC controllers without views.

Any given ASP.NET core app can use one or more of these modes of responding to HTTP requests. A single app can include MVC controllers and views, Razor Pages, and web API controllers.

## ControllerBase

A web API app has one or more controller classes that derive from <xref:Microsoft.AspNetCore.Mvc.ControllerBase>. For example, the web API project template creates a Values controller:

[!code-csharp[](index/samples/2.x/Controllers/ValuesController.cs?name=snippet_Signature&highlight=3)]

(The <xref:Microsoft.AspNetCore.Mvc.Controller> base class is not used for web API controllers.  `Controller` derives from `ControllerBase` and adds support for views, so it's not needed for handling web API requests.)

The `ControllerBase` class provides many properties and methods that are useful for handling HTTP requests. For example, `ControllerBase.CreatedAtAction` returns a 201 status code:

[!code-csharp[](index/samples/2.x/Controllers/PetsController.cs?name=snippet_400And201&highlight=8-9)]

 Here are some more examples of methods that `ControllerBase` provides.

|Method  |Notes  |
|---------|---------|
| <xref:Microsoft.AspNetCore.Mvc.ControllerBase.BadRequest*>| Returns 400 status code
|<xref:Microsoft.AspNetCore.Mvc.ControllerBase.NotFound*> |Returns 404 status code|
|<xref:Microsoft.AspNetCore.Mvc.ControllerBase.PhysicalFile*>|Returns a file|
|<xref:Microsoft.AspNetCore.Mvc.ControllerBase.TryUpdateModelAsync*>||
|<xref:System.Web.Mvc.ControllerBase.TryValidateModel*>||

For a list of all available methods and properties, see <xref:Microsoft.AspNetCore.Mvc.ControllerBase>.

## Attributes

The MVC namespace provides attributes that can be used on web API controllers and action methods. The following example action method uses attributes to specify the HTTP method accepted and the status codes returned:

[!code-csharp[](index/samples/2.x/Controllers/PetsController.cs?name=snippet_400And201&highlight=1-3)]

Here are some more examples of attributes that are available.

|Attribute |Notes|
|-----|-------------|
|<xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute>||
|<xref:System.Web.Mvc.BindAttribute>||
|<xref:Microsoft.AspNetCore.Mvc.ModelBinderAttribute>||
|<xref:System.Web.Mvc.HttpGetAttribute>|Select HTTP method for an action method|
|<xref:System.Web.Mvc.HttpPostAttribute>||
|<xref:System.Web.Mvc.ActionNameAttribute>|Specify an action name not the C# method name|
|<xref:Microsoft.AspNetCore.Mvc.ApiConventionMethodAttribute>||
|<xref:Microsoft.AspNetCore.Mvc.ApiConventionTypeAttribute>||
|<xref:Microsoft.AspNetCore.Mvc.ConsumesAttribute>|Specify data type accepted|
|<xref:Microsoft.AspNetCore.Mvc.ProducesAttribute>||
|<xref:Microsoft.AspNetCore.Mvc.ProducesDefaultResponseTypeAttribute>||
|<xref:Microsoft.AspNetCore.Mvc.ProducesErrorResponseTypeAttribute>||
|<xref:Microsoft.AspNetCore.Mvc.RequestFormLimitsAttribute>||
|<xref:Microsoft.AspNetCore.Mvc.RequestSizeLimitAttribute>||
|<xref:Microsoft.AspNetCore.Mvc.RouteAttribute>||

## ApiController attribute

The [[ApiController]](xref:Microsoft.AspNetCore.Mvc.ApiControllerAttribute) attribute denotes a web API controller class. For example:

[!code-csharp[](index/samples/2.x/Controllers/ValuesController.cs?name=snippet_Signature&highlight=2)]

A compatibility version of 2.1 or later, set via <xref:Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions.SetCompatibilityVersion*>, is required to use this attribute. For example, the highlighted code in `Startup.ConfigureServices` sets the compatibility flag:

[!code-csharp[](index/samples/2.x/Startup.cs?name=snippet_Compat)]

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

[!code-csharp[](index/samples/2.x/Startup.cs?name=snippet_Assembly&highlight=1)]

A compatibility version of 2.2 or later, set via <xref:Microsoft.Extensions.DependencyInjection.MvcCoreMvcBuilderExtensions.SetCompatibilityVersion*>, is required to use this attribute at the assembly level.

Another approach is to create a custom base controller class annotated with the `[ApiController]` attribute:

[!code-csharp[](index/samples/2.x/Controllers/MyControllerBase.cs?name=snippet_MyControllerBase)]

The following sections describe convenience features added by the attribute.

## ApiController - Automatic HTTP 400 responses

Model validation errors automatically trigger an HTTP 400 response. Consequently, the following code is unnecessary:

```csharp
if (!ModelState.IsValid)
{
    return BadRequest(ModelState);
}
```

Use <xref:Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.InvalidModelStateResponseFactory> to customize the output of the resulting response.

Disabling the default behavior is useful when your action can recover from a model validation error. The default behavior is disabled when the <xref:Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.SuppressModelStateInvalidFilter> property is set to `true`. Add the following code in `Startup.ConfigureServices` after `services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_<version_number>);`:

[!code-csharp[](index/samples/2.x/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=7)]

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
|[[FromBody]](xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute)     | Request body |
|[[FromForm]](xref:Microsoft.AspNetCore.Mvc.FromFormAttribute)     | Form data in the request body |
|[[FromHeader]](xref:Microsoft.AspNetCore.Mvc.FromHeaderAttribute) | Request header |
|[[FromQuery]](xref:Microsoft.AspNetCore.Mvc.FromQueryAttribute)   | Request query string parameter |
|[[FromRoute]](xref:Microsoft.AspNetCore.Mvc.FromRouteAttribute)   | Route data from the current request |
|[[FromServices]](xref:mvc/controllers/dependency-injection#action-injection-with-fromservices) | The request service injected as an action parameter |

> [!WARNING]
> Don't use `[FromRoute]` when values might contain `%2f` (that is `/`). `%2f` won't be unescaped to `/`. Use `[FromQuery]` if the value might contain `%2f`.

Without the `[ApiController]` attribute, binding source attributes are explicitly defined. Without `[ApiController]` or other binding source attributes like `[FromQuery]`, the ASP.NET Core runtime attempts to use the complex object model binder. The complex object model binder pulls data from value providers (which have a defined order). For instance, the 'body model binder' is always opt in.

In the following example, the `[FromQuery]` attribute indicates that the `discontinuedOnly` parameter value is provided in the request URL's query string:

[!code-csharp[](index/samples/2.x/Controllers/ProductsController.cs?name=snippet_BindingSourceAttributes&highlight=3)]

Inference rules are applied for the default data sources of action parameters. These rules configure the binding sources you're otherwise likely to manually apply to the action parameters. The binding source attributes behave as follows:

* `[FromBody]` is inferred for complex type parameters. An exception to this rule is any complex, built-in type with a special meaning, such as <xref:Microsoft.AspNetCore.Http.IFormCollection> and <xref:System.Threading.CancellationToken>. The binding source inference code ignores those special types. `[FromBody]` isn't inferred for simple types such as `string` or `int`. Therefore, the `[FromBody]` attribute should be used for simple types when that functionality is needed. When an action has more than one parameter explicitly specified (via `[FromBody]`) or inferred as bound from the request body, an exception is thrown. For example, the following action signatures cause an exception:

    [!code-csharp[](index/samples/2.x/Controllers/TestController.cs?name=snippet_ActionsCausingExceptions)]

    > [!NOTE]
    > In ASP.NET Core 2.1, collection type parameters such as lists and arrays are incorrectly inferred as [[FromQuery]](xref:Microsoft.AspNetCore.Mvc.FromQueryAttribute). [[FromBody]](xref:Microsoft.AspNetCore.Mvc.FromBodyAttribute) should be used for these parameters if they are to be bound from the request body. This behavior is fixed in ASP.NET Core 2.2 or later, where collection type parameters are inferred to be bound from the body by default.

* `[FromForm]` is inferred for action parameters of type <xref:Microsoft.AspNetCore.Http.IFormFile> and <xref:Microsoft.AspNetCore.Http.IFormFileCollection>. It's not inferred for any simple or user-defined types.
* `[FromRoute]` is inferred for any action parameter name matching a parameter in the route template. When more than one route matches an action parameter, any route value is considered `[FromRoute]`.
* `[FromQuery]` is inferred for any other action parameters.

The default inference rules are disabled when the <xref:Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.SuppressInferBindingSourcesForParameters> property is set to `true`. Add the following code in `Startup.ConfigureServices` after `services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_<version_number>);`:

[!code-csharp[](index/samples/2.x/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=6)]

## ApiController - Multipart/form-data request inference

When an action parameter is annotated with the [[FromForm]](xref:Microsoft.AspNetCore.Mvc.FromFormAttribute) attribute, the `multipart/form-data` request content type is inferred.

The default behavior is disabled when the <xref:Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.SuppressConsumesConstraintForFormFileParameters> property is set to `true`.

Add the following code in `Startup.ConfigureServices`:

[!code-csharp[](index/samples/2.x/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=7)]
### ApiController - Attribute routing requirement

Attribute routing becomes a requirement. For example:

[!code-csharp[](index/samples/2.x/Controllers/ProductsController.cs?name=snippet_ControllerSignature&highlight=1)]

Actions are inaccessible via [conventional routes](xref:mvc/controllers/routing#conventional-routing) defined in <xref:Microsoft.AspNetCore.Builder.MvcApplicationBuilderExtensions.UseMvc*> or by <xref:Microsoft.AspNetCore.Builder.MvcApplicationBuilderExtensions.UseMvcWithDefaultRoute*> in `Startup.Configure`.

### ApiController - Problem details for error status codes

In ASP.NET Core 2.2 or later, MVC transforms an error result (a result with status code 400 or higher) to a result with <xref:Microsoft.AspNetCore.Mvc.ProblemDetails>. `ProblemDetails` is:

* A type based on the [RFC 7807 specification](https://tools.ietf.org/html/rfc7807).
* A standardized format for specifying machine-readable error details in an HTTP response.

Consider the following code in a controller action:

[!code-csharp[](index/samples/2.x/Controllers/ProductsController.cs?name=snippet_ProblemDetailsStatusCode)]

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

[!code-csharp[](index/samples/2.x/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=8)]

Use the `ClientErrorMapping` property to configure the contents of the `ProblemDetails` response. For example, the following code updates the `type` property for 404 responses:

[!code-csharp[](index/samples/2.x/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=10-11)]

## Additional resources 

* <xref:web-api/action-return-types>
* <xref:web-api/advanced/custom-formatters>
* <xref:web-api/advanced/formatting>
* <xref:tutorials/web-api-help-pages-using-swagger>
* <xref:mvc/controllers/routing>
