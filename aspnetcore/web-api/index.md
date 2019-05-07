---
title: Create web APIs with ASP.NET Core
author: scottaddie
description: Learn the basics of creating a web API in ASP.NET Core.
monikerRange: '>= aspnetcore-2.1'
ms.author: scaddie
ms.custom: mvc
ms.date: 05/07/2019
uid: web-api/index
---

# Create web APIs with ASP.NET Core

By [Scott Addie](https://github.com/scottaddie) and [Tom Dykstra](https://github.com/tdykstra)

ASP.NET Core supports creating RESTful services, also known as web APIs, using C#. To handle requests, a web API uses controllers. *Controllers* in a web API are classes that derive from `ControllerBase`. This article shows how to use controllers for handling API requests.

[View or download sample code](https://github.com/aspnet/AspNetCore.Docs/tree/master/aspnetcore/web-api/index/samples). ([How to download](xref:index#how-to-download-a-sample)).

## ControllerBase class

A web API has one or more controller classes that derive from <xref:Microsoft.AspNetCore.Mvc.ControllerBase>. For example, the web API project template creates a Values controller:

[!code-csharp[](index/samples/2.x/Controllers/ValuesController.cs?name=snippet_Signature&highlight=3)]

Don't create a web API controller by deriving from the <xref:Microsoft.AspNetCore.Mvc.Controller> base class. `Controller` derives from `ControllerBase` and adds support for views, so it's for handling web pages, not web API requests.  There's an exception to this rule: if you plan to use the same controller for both views and APIs, derive it from `Controller`.

The `ControllerBase` class provides many properties and methods that are useful for handling HTTP requests. For example, `ControllerBase.CreatedAtAction` returns a 201 status code:

[!code-csharp[](index/samples/2.x/Controllers/PetsController.cs?name=snippet_400And201&highlight=8-9)]

 Here are some more examples of methods that `ControllerBase` provides.

|Method  |Notes  |
|---------|---------|
|<xref:Microsoft.AspNetCore.Mvc.ControllerBase.BadRequest*>| Returns 400 status code.|
|<xref:Microsoft.AspNetCore.Mvc.ControllerBase.NotFound*> |Returns 404 status code.|
|<xref:Microsoft.AspNetCore.Mvc.ControllerBase.PhysicalFile*>|Returns a file.|
|<xref:Microsoft.AspNetCore.Mvc.ControllerBase.TryUpdateModelAsync*>|Invokes [model binding](xref:mvc/models/model-binding).|
|<xref:Microsoft.AspNetCore.Mvc.ControllerBase.TryValidateModel*>|Invokes [model validation](xref:mvc/models/validation).|

For a list of all available methods and properties, see <xref:Microsoft.AspNetCore.Mvc.ControllerBase>.

## Attributes

The <xref:Microsoft.AspNetCore.Mvc> namespace provides attributes that can be used to configure the behavior of web API controllers and action methods. The following example uses attributes to specify the HTTP method accepted and the status codes returned:

[!code-csharp[](index/samples/2.x/Controllers/PetsController.cs?name=snippet_400And201&highlight=1-3)]

Here are some more examples of attributes that are available.

|Attribute|Notes|
|---------|-----|
|[[Route]](<xref:Microsoft.AspNetCore.Mvc.RouteAttribute>)      |Specifies URL pattern for a controller or action.|
|[[Bind]](<xref:Microsoft.AspNetCore.Mvc.BindAttribute>)        |Specifies prefix and properties to include for model binding.|
|[[HttpGet]](<xref:Microsoft.AspNetCore.Mvc.HttpGetAttribute>)  |Identifies an action that supports the HTTP GET method.|
|[[Consumes]](<xref:Microsoft.AspNetCore.Mvc.ConsumesAttribute>)|Specifies data types that an action accepts.|
|[[Produces]](<xref:Microsoft.AspNetCore.Mvc.ProducesAttribute>)|Specifies data types that an action returns.|

For a list that includes the available attributes, see the <xref:Microsoft.AspNetCore.Mvc> namespace.

## ApiController attribute

The [[ApiController]](xref:Microsoft.AspNetCore.Mvc.ApiControllerAttribute) attribute can be applied to a controller class to enable API-specific behaviors:

* [Attribute routing requirement](#attribute-routing-requirement)
* [Automatic HTTP 400 responses](#automatic-http-400-responses)
* [Binding source parameter inference](#binding-source-parameter-inference)
* [Multipart/form-data request inference](#multipartform-data-request-inference)
* [Problem details for error status codes](#problem-details-for-error-status-codes)

These features require a [compatibility version](<xref:mvc/compatibility-version>) of 2.1 or later.

### ApiController on specific controllers

The `[ApiController]` attribute can be applied to specific controllers, as in the following example from the project template:

[!code-csharp[](index/samples/2.x/Controllers/ValuesController.cs?name=snippet_Signature&highlight=2)]

### ApiController on multiple controllers

One approach to using the attribute on more than one controller is to create a custom base controller class annotated with the `[ApiController]` attribute. Here's an example showing a custom base class and a controller that derives from it:

[!code-csharp[](index/samples/2.x/Controllers/MyControllerBase.cs?name=snippet_MyControllerBase)]

[!code-csharp[](index/samples/2.x/Controllers/PetsController.cs?name=snippet_Inherit)]

### ApiController on an assembly

If [compatibility version](<xref:mvc/compatibility-version>) is set to 2.2 or later, the `[ApiController]` attribute can be applied to an assembly. Annotation in this manner applies web API behavior to all controllers in the assembly. There's no way to opt out for individual controllers. Apply the assembly-level attribute to the `Startup` class as shown in the following example:

```csharp
[assembly: ApiController]
namespace WebApiSample
{
    public class Startup
    {
        ...
    }
}
```

## Attribute routing requirement

The `ApiController` attribute makes attribute routing a requirement. For example:

[!code-csharp[](index/samples/2.x/Controllers/ValuesController.cs?name=snippet_Signature&highlight=1)]

Actions are inaccessible via [conventional routes](xref:mvc/controllers/routing#conventional-routing) defined by <xref:Microsoft.AspNetCore.Builder.MvcApplicationBuilderExtensions.UseMvc*> or <xref:Microsoft.AspNetCore.Builder.MvcApplicationBuilderExtensions.UseMvcWithDefaultRoute*> in `Startup.Configure`.

## Automatic HTTP 400 responses

The `ApiController` attribute makes model validation errors automatically trigger an HTTP 400 response. Consequently, the following code is unnecessary in an action method:

```csharp
if (!ModelState.IsValid)
{
    return BadRequest(ModelState);
}
```

### Default BadRequest response 

With a compatibility version of 2.2 or later, the default response type for HTTP 400 responses is <xref:Microsoft.AspNetCore.Mvc.ValidationProblemDetails>. The `ValidationProblemDetails` type complies with the [RFC 7807 specification](https://tools.ietf.org/html/rfc7807).

To change the default response to <xref:Microsoft.AspNetCore.Mvc.SerializableError>, set the `SuppressUseValidationProblemDetailsForInvalidModelStateResponses` property to `true` in `Startup.ConfigureServices`, as shown in the following example:

[!code-csharp[](index/samples/2.x/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=3,9)]

### Customize BadRequest response

To customize the response that results from a validation error, use <xref:Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.InvalidModelStateResponseFactory>. Add the following highlighted code after `services.AddMvc().SetCompatibilityVersion`:

[!code-csharp[](index/samples/2.x/Startup.cs?name=snippet_ConfigureBadRequestResponse&highlight=3-20)]

### Log automatic 400 responses

See [How to log automatic 400 responses on model validation errors (aspnet/AspNetCore.Docs #12157)](https://github.com/aspnet/AspNetCore.Docs/issues/12157).

### Disable automatic 400

To disable the automatic 400 behavior, set the <xref:Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.SuppressModelStateInvalidFilter> property to `true`. Add the following highlighted code in `Startup.ConfigureServices` after `services.AddMvc().SetCompatibilityVersion`:

[!code-csharp[](index/samples/2.x/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=3,7)]

## Binding source parameter inference

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

Without the `[ApiController]` attribute or binding source attributes like `[FromQuery]`, the ASP.NET Core runtime attempts to use the complex object model binder. The complex object model binder pulls data from value providers in a defined order.

In the following example, the `[FromQuery]` attribute indicates that the `discontinuedOnly` parameter value is provided in the request URL's query string:

[!code-csharp[](index/samples/2.x/Controllers/ProductsController.cs?name=snippet_BindingSourceAttributes&highlight=3)]

The `[ApiController]` attribute applies inference rules for the default data sources of action parameters. These rules save you from having to identify binding sources manually by applying attributes to the action parameters. The binding source inference rules behave as follows:

* `[FromBody]` is inferred for complex type parameters. An exception to the `[FromBody]` inference rule is any complex, built-in type with a special meaning, such as <xref:Microsoft.AspNetCore.Http.IFormCollection> and <xref:System.Threading.CancellationToken>. The binding source inference code ignores those special types. 
* `[FromForm]` is inferred for action parameters of type <xref:Microsoft.AspNetCore.Http.IFormFile> and <xref:Microsoft.AspNetCore.Http.IFormFileCollection>. It's not inferred for any simple or user-defined types.
* `[FromRoute]` is inferred for any action parameter name matching a parameter in the route template. When more than one route matches an action parameter, any route value is considered `[FromRoute]`.
* `[FromQuery]` is inferred for any other action parameters.

### FromBody inference notes

`[FromBody]` isn't inferred for simple types such as `string` or `int`. Therefore, the `[FromBody]` attribute should be used for simple types when that functionality is needed.

When an action has more than one parameter bound from the request body, an exception is thrown. For example, all of the following action method signatures cause an exception:

* `[FromBody]` inferred on both because they're complex types.

  ```csharp
  [HttpPost]
  public IActionResult Action1(Product product, Order order)
  ```

* `[FromBody]` attribute on one, inferred on the other because it's a complex type.

  ```csharp
  [HttpPost]
  public IActionResult Action2(Product product, [FromBody] Order order)
  ```

* `[FromBody]` attribute on both.

  ```csharp
  [HttpPost]
  public IActionResult Action3([FromBody] Product product, [FromBody] Order order)
  ```

> [!NOTE]
> In ASP.NET Core 2.1, collection type parameters such as lists and arrays are incorrectly inferred as `[FromQuery]`. The `[FromBody]` attribute should be used for these parameters if they are to be bound from the request body. This behavior is corrected in ASP.NET Core 2.2 or later, where collection type parameters are inferred to be bound from the body by default.

### Disable inference rules

To disable binding source inference, set <xref:Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.SuppressInferBindingSourcesForParameters> to `true`. Add the following code in `Startup.ConfigureServices` after `services.AddMvc().SetCompatibilityVersion`:

[!code-csharp[](index/samples/2.x/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=3,6)]

## Multipart/form-data request inference

The `[ApiController]` attribute applies an inference rule when an action parameter is annotated with the [[FromForm]](xref:Microsoft.AspNetCore.Mvc.FromFormAttribute) attribute: the `multipart/form-data` request content type is inferred.

To disable the default behavior, set <xref:Microsoft.AspNetCore.Mvc.ApiBehaviorOptions.SuppressConsumesConstraintForFormFileParameters>  to `true` in `Startup.ConfigureServices`, as shown in the following example:

[!code-csharp[](index/samples/2.x/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=3,5)]

## Problem details for error status codes

When the compatibility version is 2.2 or later, MVC transforms an error result (a result with status code 400 or higher) to a result with <xref:Microsoft.AspNetCore.Mvc.ProblemDetails>. The `ProblemDetails` type is based on the [RFC 7807 specification](https://tools.ietf.org/html/rfc7807) for providing machine-readable error details in an HTTP response.

Consider the following code in a controller action:

[!code-csharp[](index/samples/2.x/Controllers/PetsController.cs?name=snippet_ProblemDetailsStatusCode)]

The HTTP response for `NotFound` has a 404 status code with a `ProblemDetails` body. For example:

```json
{
    type: "https://tools.ietf.org/html/rfc7231#section-6.5.4",
    title: "Not Found",
    status: 404,
    traceId: "0HLHLV31KRN83:00000001"
}
```

### Customize ProblemDetails response

Use the `ClientErrorMapping` property to configure the contents of the `ProblemDetails` response. For example, the following code updates the `type` property for 404 responses:

[!code-csharp[](index/samples/2.x/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=10-11)]

### Disable ProblemDetails response

The automatic creation of `ProblemDetails` is disabled when the `SuppressMapClientErrors` property is set to `true`. Add the following code in `Startup.ConfigureServices`:

[!code-csharp[](index/samples/2.x/Startup.cs?name=snippet_ConfigureApiBehaviorOptions&highlight=3,8)]

## Additional resources 

* <xref:web-api/action-return-types>
* <xref:web-api/advanced/custom-formatters>
* <xref:web-api/advanced/formatting>
* <xref:tutorials/web-api-help-pages-using-swagger>
* <xref:mvc/controllers/routing>
