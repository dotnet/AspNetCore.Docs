---
title: Minimal APIs quick reference
author: rick-anderson
description: Provides an overview of minimal APIs in ASP.NET Core
ms.author: riande
monikerRange: '>= aspnetcore-6.0'
ms.date: 10/24/2022
uid: fundamentals/minimal-apis
---

# Minimal APIs quick reference

:::moniker range=">= aspnetcore-7.0"

This document:

* Provides a quick reference for minimal APIs.
* Is intended for experienced developers. For an introduction, see <xref:tutorials/min-web-api>

The minimal APIs consist of:

* [WebApplication and WebApplicationBuilder](xref:fundamentals/minimal-apis/webapplication)
* [Route Handlers](xref:fundamentals/minimal-apis/route-handlers)

[!INCLUDE [WebApplication](~/fundamentals/minimal-apis/includes/webapplication.md)]

## ASP.NET Core Middleware

The following table lists some of the middleware frequently used with minimal APIs.

| Middleware | Description | API |
|--|--|--|
| [Authentication](xref:security/authentication/index?view=aspnetcore-6.0) | Provides authentication support. | <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A> |
| [Authorization](xref:security/authorization/introduction) | Provides authorization support. | <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A> |
| [CORS](xref:security/cors?view=aspnetcore-6.0) | Configures Cross-Origin Resource Sharing. | <xref:Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions.UseCors%2A> |
| [Exception Handler](xref:web-api/handle-errors?view=aspnetcore-6.0) | Globally handles exceptions thrown by the middleware pipeline. | <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A> |
| [Forwarded Headers](xref:fundamentals/middleware/index?view=aspnetcore-6.0#forwarded-headers-middleware-order) | Forwards proxied headers onto the current request. | <xref:Microsoft.AspNetCore.Builder.ForwardedHeadersExtensions.UseForwardedHeaders%2A> |
| [HTTPS Redirection](xref:security/enforcing-ssl?view=aspnetcore-6.0) | Redirects all HTTP requests to HTTPS. | <xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection%2A> |
| [HTTP Strict Transport Security (HSTS)](xref:fundamentals/middleware/index?view=aspnetcore-6.0#middleware-order) | Security enhancement middleware that adds a special response header. | <xref:Microsoft.AspNetCore.Builder.HstsBuilderExtensions.UseHsts%2A> |
| [Request Logging](xref:fundamentals/logging/index?view=aspnetcore-6.0) | Provides support for logging HTTP requests and responses. | <xref:Microsoft.AspNetCore.Builder.HttpLoggingBuilderExtensions.UseHttpLogging%2A> |
| [W3C Request Logging](https://www.w3.org/TR/WD-logfile.html) | Provides support for logging HTTP requests and responses in the [W3C format](https://www.w3.org/TR/WD-logfile.html). | <xref:Microsoft.AspNetCore.Builder.HttpLoggingBuilderExtensions.UseW3CLogging%2A> |
| [Response Caching](xref:performance/caching/middleware) | Provides support for caching responses. | <xref:Microsoft.AspNetCore.Builder.ResponseCachingExtensions.UseResponseCaching%2A> |
| [Response Compression](xref:performance/response-compression) | Provides support for compressing responses. | <xref:Microsoft.AspNetCore.Builder.ResponseCompressionBuilderExtensions.UseResponseCompression%2A> |
| [Session](xref:fundamentals/app-state) | Provides support for managing user sessions. | <xref:Microsoft.AspNetCore.Builder.SessionMiddlewareExtensions.UseSession%2A> |
| [Static Files](xref:fundamentals/static-files) | Provides support for serving static files and directory browsing. | <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>, <xref:Microsoft.AspNetCore.Builder.FileServerExtensions.UseFileServer%2A> |
| [WebSockets](xref:fundamentals/websockets) | Enables the WebSockets protocol. | <xref:Microsoft.AspNetCore.Builder.WebSocketMiddlewareExtensions.UseWebSockets%2A> |

## Request handling

The following sections cover routing, parameter binding, and responses.

### Routing

A configured `WebApplication` supports `Map{Verb}` and <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapMethods%2A>:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_r1)]

### Route Handlers

[!INCLUDE [route handling](~/fundamentals/minimal-apis/includes/route-handlers.md)]

### Parameter Binding

[!INCLUDE [parameter binding](~/fundamentals/minimal-apis/includes/parameter-binding.md)]

### Read the request body

Read the request body directly using a <xref:Microsoft.AspNetCore.Http.HttpContext> or <xref:Microsoft.AspNetCore.Http.HttpRequest> parameter:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_fileupload)]

The preceding code:

* Accesses the request body using <xref:Microsoft.AspNetCore.Http.HttpRequest.BodyReader?displayProperty=nameWithType>.
* Copies the request body to a local file.

## Responses

Route handlers support the following types of return values:

1. `IResult` based - This includes `Task<IResult>` and `ValueTask<IResult>`
1. `string` - This includes `Task<string>` and `ValueTask<string>`
1. `T` (Any other type) - This includes `Task<T>` and `ValueTask<T>`

|Return value|Behavior|Content-Type|
|--|--|--|
|`IResult` | The framework calls [IResult.ExecuteAsync](xref:Microsoft.AspNetCore.Http.IResult.ExecuteAsync%2A)| Decided by the `IResult` implementation
|`string` | The framework writes the string directly to the response | `text/plain`
| `T` (Any other type) | The framework will JSON serialize the response| `application/json`

For a more in-depth guide to route handler return values see <xref:fundamentals/minimal-apis/responses>

### Example return values

#### string return values

```csharp
app.MapGet("/hello", () => "Hello World");
```

#### JSON return values

```csharp
app.MapGet("/hello", () => new { Message = "Hello World" });
```

#### IResult return values

```csharp
app.MapGet("/hello", () => Results.Ok(new { Message = "Hello World" }));
```

The following example uses the built-in result types to customize the response:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/todo/Program.cs?name=snippet_getCustom)]

##### JSON

```csharp
app.MapGet("/hello", () => Results.Json(new { Message = "Hello World" }));
```

##### Custom Status Code

```csharp
app.MapGet("/405", () => Results.StatusCode(405));
```

##### Text

```csharp
app.MapGet("/text", () => Results.Text("This is some text"));
```
<a name="stream7"></a>

##### Stream

```csharp
var proxyClient = new HttpClient();
app.MapGet("/pokemon", async () => 
{
    var stream = await proxyClient.GetStreamAsync("http://consoto/pokedex.json");
    // Proxy the response as JSON
    return Results.Stream(stream, "application/json");
});
```

See <xref:fundamentals/minimal-apis/responses#stream7> for more examples.

##### Redirect

```csharp
app.MapGet("/old-path", () => Results.Redirect("/new-path"));
```

##### File

```csharp
app.MapGet("/download", () => Results.File("myfile.text"));
```

<a name="binr7"></a>

### Built-in results

[!INCLUDE [results-helpers](~/fundamentals/minimal-apis/includes/results-helpers.md)]

### Customizing results

Applications can control responses by implementing a custom <xref:Microsoft.AspNetCore.Http.IResult> type. The following code is an example of an HTML result type:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/ResultsExtensions.cs)]

We recommend adding an extension method to <xref:Microsoft.AspNetCore.Http.IResultExtensions?displayProperty=fullName> to make these custom results more discoverable.

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_xtn)]

### Typed results

The <xref:Microsoft.AspNetCore.Http.IResult> interface can represent values returned from minimal APIs that don't utilize the implicit support for JSON serializing the returned object to the HTTP response. The static [Results](/dotnet/api/microsoft.aspnetcore.http.results) class is used to create varying `IResult` objects that represent different types of responses. For example, setting the response status code or redirecting to another URL.

The types implementing `IResult` are public, allowing for type assertions when testing. For example:

[!code-csharp[](~/fundamentals/minimal-apis/misc-samples/typedResults/TypedResultsApiWithTest/Test/WeatherApiTest.cs?name=snippet_1&highlight=7-8)]

You can look at the return types of the corresponding methods on the static [TypedResults](/dotnet/api/microsoft.aspnetcore.http.typedresults) class to find the correct public `IResult` type to cast to.

See <xref:fundamentals/minimal-apis/responses> for more examples.

## Filters

See <xref:fundamentals/minimal-apis/min-api-filters>

## Authorization

Routes can be protected using authorization policies. These can be declared via the [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute or by using the <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A> method:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebRPauth/Program.cs?name=snippet_auth1&highlight=7-8,22)]

The preceding code can be written with <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A>:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_auth2)]

The following sample uses [policy-based authorization](xref:security/authorization/policies):

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebRPauth/Program.cs?name=snippet_auth3&range=7-8,22-26)]

### Allow unauthenticated users to access an endpoint

The [`[AllowAnonymous]`](xref:Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute)
allows unauthenticated users to access endpoints:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_auth4)]

## CORS

Routes can be [CORS](xref:security/cors?view=aspnetcore-6.0) enabled using [CORS policies](xref:security/cors?view=aspnetcore-6.0#cors-policy-options). CORS can be declared via the [`[EnableCors]`](xref:Microsoft.AspNetCore.Cors.EnableCorsAttribute) attribute or by using the
<xref:Microsoft.AspNetCore.Builder.CorsEndpointConventionBuilderExtensions.RequireCors%2A> method. The following samples enable CORS:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_cors)]

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_cors2)]

For more information, see <xref:security/cors?view=aspnetcore-6.0>

<a name="openapi7"></a>

<!-- 
# Differences between minimal APIs and APIs with controllers

Moved to uid: tutorials/min-web-api
-->

## See also

[OpenAPI support in minimal APIs](xref:fundamentals/minimal-apis/openapi)

:::moniker-end

[!INCLUDE[](~/fundamentals/minimal-apis/includes/minimal-apis6.md)]
