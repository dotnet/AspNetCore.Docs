---
title: Format response data in ASP.NET Core Web API
author: ardalis
description: Learn how to format response data in ASP.NET Core Web API.
ms.author: riande
ms.custom: H1Hack27Feb2017
ms.date: 04/17/2020
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: web-api/advanced/formatting
---
# Format response data in ASP.NET Core Web API

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Steve Smith](https://ardalis.com/)

ASP.NET Core MVC has support for formatting response data. Response data can be formatted using specific formats or in response to client requested format.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/master/aspnetcore/web-api/advanced/formatting) ([how to download](xref:index#how-to-download-a-sample))

## Format-specific Action Results

Some action result types are specific to a particular format, such as <xref:Microsoft.AspNetCore.Mvc.JsonResult> and <xref:Microsoft.AspNetCore.Mvc.ContentResult>. Actions can return results that are formatted in a particular format, regardless of client preferences. For example, returning `JsonResult` returns JSON-formatted data. Returning `ContentResult` or a string returns plain-text-formatted string data.

An action isn't required to return any specific type. ASP.NET Core supports any object return value.  Results from actions that return objects that are not <xref:Microsoft.AspNetCore.Mvc.IActionResult> types are serialized using the appropriate <xref:Microsoft.AspNetCore.Mvc.Formatters.IOutputFormatter> implementation. For more information, see <xref:web-api/action-return-types>.

The built-in helper method <xref:Microsoft.AspNetCore.Mvc.ControllerBase.Ok*> returns JSON-formatted data:
[!code-csharp[](./formatting/sample/Controllers/AuthorsController.cs?name=snippet_get)]

The sample download returns the list of authors. Using the F12 browser developer tools or [Postman](https://www.getpostman.com/tools) with the previous code:

* The response header containing **content-type:** `application/json; charset=utf-8` is displayed.
* The request headers are displayed. For example, the `Accept` header. The `Accept` header is ignored by the preceding code.

To return plain text formatted data, use <xref:Microsoft.AspNetCore.Mvc.ContentResult.Content> and the <xref:Microsoft.AspNetCore.Mvc.ContentResult.Content> helper:

[!code-csharp[](./formatting/sample/Controllers/AuthorsController.cs?name=snippet_about)]

In the preceding code, the `Content-Type` returned is `text/plain`. Returning a string delivers `Content-Type` of `text/plain`:

[!code-csharp[](./formatting/sample/Controllers/AuthorsController.cs?name=snippet_string)]

For actions with multiple return types, return `IActionResult`. For example, returning different HTTP status codes based on the result of operations performed.

## Content negotiation

Content negotiation occurs when the client specifies an [Accept header](https://www.w3.org/Protocols/rfc2616/rfc2616-sec14.html). The default format used by ASP.NET Core is [JSON](https://json.org/). Content negotiation is:

* Implemented by <xref:Microsoft.AspNetCore.Mvc.ObjectResult>.
* Built into the status code-specific action results returned from the helper methods. The action results helper methods are based on `ObjectResult`.

When a model type is returned,  the return type is `ObjectResult`.

The following action method uses the `Ok` and `NotFound` helper methods:

[!code-csharp[](./formatting/sample/Controllers/AuthorsController.cs?name=snippet_search)]

By default, ASP.NET Core supports `application/json`, `text/json`, and `text/plain` media types. Tools such as [Fiddler](https://www.telerik.com/fiddler) or [Postman](https://www.getpostman.com/tools) can set the `Accept` request header to specify the return format. When the `Accept` header contains a type the server supports, that type is returned. The next section shows how to add additional formatters.

Controller actions can return POCOs (Plain Old CLR Objects). When a POCO is returned, the runtime automatically creates an `ObjectResult` that wraps the object. The client gets the formatted serialized object. If the object being returned is `null`, a `204 No Content` response is returned.

Returning an object type:

[!code-csharp[](./formatting/sample/Controllers/AuthorsController.cs?name=snippet_alias)]

In the preceding code, a request for a valid author alias returns a `200 OK` response with the author's data. A request for an invalid alias returns a `204 No Content` response.

### The Accept header

Content *negotiation* takes place when an `Accept` header appears in the request. When a request contains an accept header, ASP.NET Core:

* Enumerates the media types in the accept header in preference order.
* Tries to find a formatter that can produce a response in one of the formats specified.

If no formatter is found that can satisfy the client's request, ASP.NET Core:

* Returns `406 Not Acceptable` if <xref:Microsoft.AspNetCore.Mvc.MvcOptions> has been set, or -
* Tries to find the first formatter that can produce a response.

If no formatter is configured for the requested format, the first formatter that can format the object is used. If no `Accept` header appears in the request:

* The first formatter that can handle the object is used to serialize the response.
* There isn't any negotiation taking place. The server is determining what format to return.

If the Accept header contains `*/*`, the Header is ignored unless `RespectBrowserAcceptHeader` is set to true on <xref:Microsoft.AspNetCore.Mvc.MvcOptions>.

### Browsers and content negotiation

Unlike typical API clients, web browsers supply `Accept` headers. Web browser specify many formats, including wildcards. By default, when the framework detects that the request is coming from a browser:

* The `Accept` header is ignored.
* The content is returned in JSON, unless otherwise configured.

This provides a more consistent experience across browsers when consuming APIs.

To configure an app to honor browser accept headers, set
<xref:Microsoft.AspNetCore.Mvc.MvcOptions.RespectBrowserAcceptHeader> to `true`:

::: moniker range=">= aspnetcore-3.0"
[!code-csharp[](./formatting/3.0sample/StartupRespectBrowserAcceptHeader.cs?name=snippet)]
::: moniker-end
::: moniker range="< aspnetcore-3.0"
[!code-csharp[](./formatting/sample/StartupRespectBrowserAcceptHeader.cs?name=snippet)]
::: moniker-end

### Configure formatters

Apps that need to support additional formats can add the appropriate NuGet packages and configure support. There are separate formatters for input and output. Input formatters are used by [Model Binding](xref:mvc/models/model-binding). Output formatters are used to format responses. For information on creating a custom formatter, see [Custom Formatters](xref:web-api/advanced/custom-formatters).

::: moniker range=">= aspnetcore-3.0"

### Add XML format support

XML formatters implemented using <xref:System.Xml.Serialization.XmlSerializer> are configured by calling <xref:Microsoft.Extensions.DependencyInjection.MvcXmlMvcBuilderExtensions.AddXmlSerializerFormatters*>:

[!code-csharp[](./formatting/3.0sample/Startup.cs?name=snippet)]

The preceding code serializes results using `XmlSerializer`.

When using the preceding code, controller methods return the appropriate format based on the request's `Accept` header.

### Configure System.Text.Json-based formatters

Features for the `System.Text.Json`-based formatters can be configured using `Microsoft.AspNetCore.Mvc.JsonOptions.SerializerOptions`.

```csharp
services.AddControllers().AddJsonOptions(options =>
{
    // Use the default property (Pascal) casing.
    options.JsonSerializerOptions.PropertyNamingPolicy = null;

    // Configure a custom converter.
    options.JsonSerializerOptions.Converters.Add(new MyCustomJsonConverter());
});
```

Output serialization options, on a per-action basis, can be configured using `JsonResult`. For example:

```csharp
public IActionResult Get()
{
    return Json(model, new JsonSerializerOptions
    {
        options.WriteIndented = true,
    });
}
```

### Add Newtonsoft.Json-based JSON format support

Prior to ASP.NET Core 3.0, the default used JSON formatters implemented using the `Newtonsoft.Json` package. In ASP.NET Core 3.0 or later, the default JSON formatters are based on `System.Text.Json`. Support for `Newtonsoft.Json` based formatters and features is available by installing the [`Microsoft.AspNetCore.Mvc.NewtonsoftJson`](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson/) NuGet package and configuring it in `Startup.ConfigureServices`.

[!code-csharp[](./formatting/3.0sample/StartupNewtonsoftJson.cs?name=snippet)]

Some features may not work well with `System.Text.Json`-based formatters and require a reference to the `Newtonsoft.Json`-based formatters. Continue using the `Newtonsoft.Json`-based formatters if the app:

* Uses `Newtonsoft.Json` attributes. For example, `[JsonProperty]` or `[JsonIgnore]`.
* Customizes the serialization settings.
* Relies on features that `Newtonsoft.Json` provides.
* Configures `Microsoft.AspNetCore.Mvc.JsonResult.SerializerSettings`. Prior to ASP.NET Core 3.0, `JsonResult.SerializerSettings` accepts an instance of `JsonSerializerSettings` that is specific to `Newtonsoft.Json`.
* Generates [OpenAPI](<xref:tutorials/web-api-help-pages-using-swagger>) documentation.

Features for the `Newtonsoft.Json`-based formatters can be configured using `Microsoft.AspNetCore.Mvc.MvcNewtonsoftJsonOptions.SerializerSettings`:

```csharp
services.AddControllers().AddNewtonsoftJson(options =>
{
    // Use the default property (Pascal) casing
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();

    // Configure a custom converter
    options.SerializerSettings.Converters.Add(new MyCustomJsonConverter());
});
```

Output serialization options, on a per-action basis, can be configured using `JsonResult`. For example:

```csharp
public IActionResult Get()
{
    return Json(model, new JsonSerializerSettings
    {
        options.Formatting = Formatting.Indented,
    });
}
```

::: moniker-end

::: moniker range="<= aspnetcore-2.2"

### Add XML format support

XML formatting requires the [Microsoft.AspNetCore.Mvc.Formatters.Xml](https://www.nuget.org/packages/Microsoft.AspNetCore.Mvc.Formatters.Xml/) NuGet package.

XML formatters implemented using <xref:System.Xml.Serialization.XmlSerializer> are configured by calling <xref:Microsoft.Extensions.DependencyInjection.MvcXmlMvcBuilderExtensions.AddXmlSerializerFormatters*>:

[!code-csharp[](./formatting/sample/Startup.cs?name=snippet)]

The preceding code serializes results using `XmlSerializer`.

When using the preceding code, controller methods should return the appropriate format based on the request's `Accept` header.

::: moniker-end

### Specify a format

To restrict the response formats, apply the [`[Produces]`](xref:Microsoft.AspNetCore.Mvc.ProducesAttribute) filter. Like most [Filters](xref:mvc/controllers/filters), `[Produces]` can be applied at the action, controller, or global scope:

[!code-csharp[](./formatting/3.0sample/Controllers/WeatherForecastController.cs?name=snippet)]

The preceding [`[Produces]`](xref:Microsoft.AspNetCore.Mvc.ProducesAttribute) filter:

* Forces all actions within the controller to return JSON-formatted responses.
* If other formatters are configured and the client specifies a different format, JSON is returned.

For more information, see [Filters](xref:mvc/controllers/filters).

### Special case formatters

Some special cases are implemented using built-in formatters. By default, `string` return types are formatted as *text/plain* (*text/html* if requested via the `Accept` header). This behavior can be deleted by removing the <xref:Microsoft.AspNetCore.Mvc.Formatters.StringOutputFormatter>. Formatters are removed in the `ConfigureServices` method. Actions that have a model object return type return `204 No Content` when returning `null`. This behavior can be deleted by removing the <xref:Microsoft.AspNetCore.Mvc.Formatters.HttpNoContentOutputFormatter>. The following code removes the `StringOutputFormatter` and `HttpNoContentOutputFormatter`.

::: moniker range=">= aspnetcore-3.0"
[!code-csharp[](./formatting/3.0sample/StartupStringOutputFormatter.cs?name=snippet)]
::: moniker-end
::: moniker range="< aspnetcore-3.0"
[!code-csharp[](./formatting/sample/StartupStringOutputFormatter.cs?name=snippet)]
::: moniker-end

Without the `StringOutputFormatter`, the built-in JSON formatter formats `string` return types. If the built-in JSON formatter is removed and an XML formatter is available, the XML formatter formats `string` return types. Otherwise, `string` return types return `406 Not Acceptable`.

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

|           Route        |             Formatter              |
|------------------------|------------------------------------|
|   `/api/products/5`    |    The default output formatter    |
| `/api/products/5.json` | The JSON formatter (if configured) |
| `/api/products/5.xml`  | The XML formatter (if configured)  |
