---
title: Format response data in ASP.NET Core Web API
author: ardalis
description: Learn how to format response data in ASP.NET Core Web API.
ms.author: riande
ms.custom: H1Hack27Feb2017
ms.date: 4/22/2019
uid: web-api/advanced/formatting
---
# Format response data in ASP.NET Core Web API

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Steve Smith](https://ardalis.com/)

ASP.NET Core MVC has built-in support for formatting response data, using fixed formats or in response to client specifications.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/web-api/advanced/formatting/sample) ([how to download](xref:index#how-to-download-a-sample))

## Format-Specific Action Results

Some action result types are specific to a particular format, such as <xref:Microsoft.AspNetCore.Mvc.JsonResult> and <xref:Microsoft.AspNetCore.Mvc.ContentResult>. Actions can return specific results that are always formatted in a particular manner. For example, returning a `JsonResult` will return JSON-formatted data, regardless of client preferences. Returning a `ContentResult` will return plain-text-formatted string data. Returning a string returns plain-text-formatted string data.

An action isn't required to return any particular type. ASP.NET Core supports any object return value.  Results from actions that return objects that are not `IActionResult` types will be serialized using the appropriate `IOutputFormatter` implementation. See <xref:web-api/action-return-types> for more information.

The built-in helper method <xref:Microsoft.AspNetCore.Mvc.ControllerBase.Ok*> to returns JSON. The built-in helper method `Content` returns plain text.

`Ok` returns JSON-formatted data:
[!code-csharp[](./formatting/sample/Controllers/AuthorsController.cs?name=snippet_get)]

The sample download returns the list of authors. The F12 browser developer tools or [Postman](https://www.getpostman.com/tools) displays the response header contains **content-type: application/json; charset=utf-8**.

The F12 browser developer tools displays the request headers, such as the `Accept` header. The `Accept` header is ignored by the preceding code.

To return plain text formatted data, use `ContentResult` and the `Content` helper:

[!code-csharp[](./formatting/sample/Controllers/AuthorsController.cs?name=snippet_about)]

In the preceding code, the `Content-Type` returned is `text/plain`. Returning a string delivers `Content-Type` of `text/plain`:

[!code-csharp[](./formatting/sample/Controllers/AuthorsController.cs?name=snippet_string)]

For non-trivial actions with multiple return types or options (for example, different HTTP status codes based on the result of operations performed), prefer `IActionResult` as the return type.

## Content Negotiation

Content negotiation (*conneg* for short) occurs when the client specifies an [Accept header](https://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html). The default format used by ASP.NET Core is [JSON](http://json.org/). Content negotiation is implemented by `ObjectResult`. It's also built into the status code specific action results returned from the helper methods (which are all based on `ObjectResult`). You can also return a model type (a class you've defined as your data transfer type) and the framework will automatically wrap it in an `ObjectResult`.

The following action method uses the `Ok` and `NotFound` helper methods:

[!code-csharp[](./formatting/sample/Controllers/AuthorsController.cs?name=snippet_search)]

A JSON-formatted response will be returned unless another format was requested and the server can return the requested format. You can use a tool like [Fiddler](http://www.telerik.com/fiddler) or  [Postman](https://www.getpostman.com/tools) to create a request that includes an `Accept` header and specify another format. In that case, if the server has a *formatter* that can produce a response in the requested format, the result will be returned in the client-preferred format.

By default, ASP.NET Core only supports JSON, so even when another format is specified, the result returned is still JSON-formatted. You'll see how to add additional formatters in the next section.

Controller actions can return POCOs (Plain Old CLR Objects), in which case ASP.NET Core automatically creates an `ObjectResult` that wraps the object. The client gets the formatted serialized object. If the object being returned is `null`, a `204 No Content` response is returned.

Returning an object type:

[!code-csharp[](./formatting/sample/Controllers/AuthorsController.cs?name=snippet_alias)]

In the preceding code, a request for a valid author alias returns a `200 OK` response with the author's data. A request for an invalid alias returns a `204 No Content` response.

### Content negotiation

Content *negotiation* takes place when an `Accept` header appears in the request. When a request contains an accept header, the ASP.NET Core runtime:

* Enumerates the media types in the accept header in preference order.
* Tries to find a formatter that can produce a response in one of the formats specified.

If no formatter is found that can satisfy the client's request, ASP.NET Core:

* Returns `406 Not Acceptable` if `MvcOptions` has been set, or -
* Tries to find the first formatter that can produce a response.

If the request specifies XML, but the XML formatter has not been configured, the JSON formatter is used. More generally, if no formatter is configured that can provide the requested format, the first formatter that can format the object is used. If no header is given, the first formatter that can handle the object is used to serialize the response. In the no header case, there isn't any negotiation taking place - the server is determining what format it will use.

If the Accept header contains `*/*`, the Header will be ignored unless `RespectBrowserAcceptHeader` is set to true on `MvcOptions`.

### Browsers and Content Negotiation

Unlike typical API clients, web browsers tend to supply `Accept` headers that include a wide array of formats, including wildcards. By default, when the framework detects that the request is coming from a browser, it will ignore the `Accept` header and instead return the content in JSON (unless otherwise configured). This provides a more consistent experience across browsers when consuming APIs.

If you would prefer your application honor browser accept headers, you can configure this as part of MVC's configuration by setting `RespectBrowserAcceptHeader` to `true` in the `ConfigureServices` method in *Startup.cs*.

[!code-csharp[](./formatting/sample/StartupRespectBrowserAcceptHeader.cs?name=snippet)]

## Configuring Formatters

If your app needs to support additional formats beyond the default of JSON, you can add NuGet packages and configure ASP.NET Core to support them. There are separate formatters for input and output. Input formatters are used by [Model Binding](xref:mvc/models/model-binding); output formatters are used to format responses. You can also configure [Custom Formatters](xref:web-api/advanced/custom-formatters).

### Adding XML Format Support

To add support for XML formatting, install the `Microsoft.AspNetCore.Mvc.Formatters.Xml` NuGet package.

Add the XmlSerializerFormatters to MVC's configuration in `Startup`:

[!code-csharp[](./formatting/sample/StartupRespectBrowserAcceptHeader.cs?name=snippet)]

The preceding code serializes results using `System.Xml.Serialization.XmlSerializer`. The `System.Runtime.Serialization.DataContractSerializer` can be added by adding its associated formatter:

[!code-csharp[](./formatting/sample/StartUpDataContractSerializer.cs?name=snippet)]

When using the preceding code, controller methods should return the appropriate format based on the request's `Accept` header.

### Forcing a format

If you would like to restrict the response formats for a specific action you can, you can apply the `[Produces]` filter. The `[Produces]` filter specifies the response formats for a specific action (or controller). Like most [Filters](xref:mvc/controllers/filters), this can be applied at the action, controller, or global scope.

```csharp
[Produces("application/json")]
public class AuthorsController
```

The [`[Produces]`](xref:Microsoft.AspNetCore.Mvc.ProducesAttribute) filter:

* Forces all actions within the controller to return JSON-formatted responses.
* If other formatters are configured for the app and the client provided an `Accept` header requesting a different format, JSON is returned.

For more information, see [Filters](xref:mvc/controllers/filters).

### Special Case Formatters

Some special cases are implemented using built-in formatters. By default, `string` return types are formatted as *text/plain* (*text/html* if requested via the `Accept` header). This behavior can be deleted by removing the `TextOutputFormatter`. Formatters are removed in the `Configure` method. Actions that have a model object return type return a `204 No Content` response when returning `null`. This behavior can be deleted by removing the `HttpNoContentOutputFormatter`. The following code removes the `TextOutputFormatter` and `HttpNoContentOutputFormatter`.

[!code-csharp[](./formatting/sample/StartupTextOutputFormatter.cs?name=snippet)]

Without the `TextOutputFormatter`, `string` return types return `406 Not Acceptable`. Note that if an XML formatter exists, it formats `string` return types if the `TextOutputFormatter` is removed.

Without the `HttpNoContentOutputFormatter`, null objects are formatted using the configured formatter. For example:

* The JSON formatter returns a response with a body of `null`.
* The XML formatter returns an empty XML element with the attribute `xsi:nil="true"` set.

## Response format URL mappings

Clients can request a particular format as part of the URL, for example:

* In the query string or part of the path.
* By using a format-specific file extension such as .xml or .json. 

The mapping from request path should be specified in the route the API is using. For example:

[!code-csharp[](./formatting/sample/Controllers/ProductsController.cs?name=snippet)]

The preceding route allows the requested format to be specified as an optional file extension. The [`[FormatFilter]`](xref:Microsoft.AspNetCore.Mvc.FormatFilterAttribute) attribute checks for the existence of the format value in the `RouteData` and maps the response format to the appropriate formatter when the response is created.

|           Route            |             Formatter              |
|----------------------------|------------------------------------|
|   `/products/GetById/5`    |    The default output formatter    |
| `/products/GetById/5.json` | The JSON formatter (if configured) |
| `/products/GetById/5.xml`  | The XML formatter (if configured)  |