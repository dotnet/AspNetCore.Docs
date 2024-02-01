---
title: Minimal APIs quick reference
author: rick-anderson
description: Provides an overview of minimal APIs in ASP.NET Core
ms.author: riande
content_well_notification: AI-contribution
monikerRange: '>= aspnetcore-6.0'
ms.date: 10/23/2023
uid: fundamentals/minimal-apis
---

# Minimal APIs quick reference

:::moniker range=">= aspnetcore-8.0"

This document:

* Provides a quick reference for minimal APIs.
* Is intended for experienced developers. For an introduction, see <xref:tutorials/min-web-api>

The minimal APIs consist of:

* [WebApplication and WebApplicationBuilder](xref:fundamentals/minimal-apis/webapplication)
* [Route Handlers](xref:fundamentals/minimal-apis/route-handlers)

[!INCLUDE [WebApplication](~/fundamentals/minimal-apis/includes/webapplication8.md)]

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
| [Request Timeouts](xref:performance/timeouts) | Provides support for configuring request timeouts, global default and per endpoint. | `UseRequestTimeouts` |
| [W3C Request Logging](https://www.w3.org/TR/WD-logfile.html) | Provides support for logging HTTP requests and responses in the [W3C format](https://www.w3.org/TR/WD-logfile.html). | <xref:Microsoft.AspNetCore.Builder.HttpLoggingBuilderExtensions.UseW3CLogging%2A> |
| [Response Caching](xref:performance/caching/middleware) | Provides support for caching responses. | <xref:Microsoft.AspNetCore.Builder.ResponseCachingExtensions.UseResponseCaching%2A> |
| [Response Compression](xref:performance/response-compression) | Provides support for compressing responses. | <xref:Microsoft.AspNetCore.Builder.ResponseCompressionBuilderExtensions.UseResponseCompression%2A> |
| [Session](xref:fundamentals/app-state) | Provides support for managing user sessions. | <xref:Microsoft.AspNetCore.Builder.SessionMiddlewareExtensions.UseSession%2A> |
| [Static Files](xref:fundamentals/static-files) | Provides support for serving static files and directory browsing. | <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>, <xref:Microsoft.AspNetCore.Builder.FileServerExtensions.UseFileServer%2A> |
| [WebSockets](xref:fundamentals/websockets) | Enables the WebSockets protocol. | <xref:Microsoft.AspNetCore.Builder.WebSocketMiddlewareExtensions.UseWebSockets%2A> |

The following sections cover request handling: routing, parameter binding, and responses.

## Routing

A configured `WebApplication` supports `Map{Verb}` and <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapMethods%2A> where `{Verb}` is a camel-cased HTTP method like `Get`, `Post`, `Put` or `Delete`:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/WebMinAPIs/Program.cs?name=snippet_r1)]

The <xref:System.Delegate> arguments passed to these methods are called "route handlers".

### Route Handlers

[!INCLUDE [route handling](~/fundamentals/minimal-apis/includes/route-handlers.md)]

## Parameter binding

[!INCLUDE [](~/fundamentals/minimal-apis/includes/parameter-binding8.md)]

## Responses

Route handlers support the following types of return values:

1. `IResult` based - This includes `Task<IResult>` and `ValueTask<IResult>`
1. `string` - This includes `Task<string>` and `ValueTask<string>`
1. `T` (Any other type) - This includes `Task<T>` and `ValueTask<T>`

|Return value|Behavior|Content-Type|
|--|--|--|
|`IResult` | The framework calls [IResult.ExecuteAsync](xref:Microsoft.AspNetCore.Http.IResult.ExecuteAsync%2A)| Decided by the `IResult` implementation
|`string` | The framework writes the string directly to the response | `text/plain`
| `T` (Any other type) | The framework JSON-serializes the response| `application/json`

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

#### Return TypedResults

The following code returns a <xref:Microsoft.AspNetCore.Http.TypedResults>:

```csharp
app.MapGet("/hello", () => TypedResults.Ok(new Message() {  Text = "Hello World!" }));
```

Returning `TypedResults` is preferred to returning <xref:Microsoft.AspNetCore.Http.Results>. For more information, see [TypedResults vs Results](/aspnet/core/fundamentals/minimal-apis/responses#typedresults-vs-results).

#### IResult return values

```csharp
app.MapGet("/hello", () => Results.Ok(new { Message = "Hello World" }));
```

The following example uses the built-in result types to customize the response:

[!code-csharp[](~/fundamentals/minimal-apis/7.0-samples/todo/Program.cs?name=snippet_getCustom)]

#### JSON

```csharp
app.MapGet("/hello", () => Results.Json(new { Message = "Hello World" }));
```

#### Custom Status Code

```csharp
app.MapGet("/405", () => Results.StatusCode(405));
```

#### Text

```csharp
app.MapGet("/text", () => Results.Text("This is some text"));
```
<a name="stream7"></a>

#### Stream

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

#### Redirect

```csharp
app.MapGet("/old-path", () => Results.Redirect("/new-path"));
```

#### File

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

## ValidateScopes and ValidateOnBuild

<xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions.ValidateScopes> and <xref:Microsoft.Extensions.DependencyInjection.ServiceProviderOptions.ValidateOnBuild> are enabled by default in the [Development](xref:fundamentals/environments) environment but disabled in other environments.

When `ValidateOnBuild` is `true`, the DI container validates the service configuration at build time. If the service configuration is invalid, the build fails at app startup, rather than at runtime when the service is requested.

When `ValidateScopes` is `true`, the DI container validates that a scoped service isn't resolved from the root scope. Resolving a scoped service from the root scope can result in a memory leak because the service is retained in memory longer than the scope of the request.

`ValidateScopes` and `ValidateOnBuild` are false by default in non-Development modes for performance reasons.

The following code shows `ValidateScopes` is enabled by default in development mode but disabled in release mode:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/ValidateOnBuildWeb/Program.cs" id="snippet_1" highlight="3,16-25":::

The following code shows `ValidateOnBuild` is enabled by default in development mode but disabled in release mode:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/ValidateOnBuildWeb/Program.cs" id="snippet_vob" highlight="10":::

The following code disables `ValidateScopes` and `ValidateOnBuild` in `Development`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/fundamentals/minimal-apis/samples/ValidateOnBuildWeb/Program.cs" id="snippet_2":::

## See also

* <xref:fundamentals/minimal-apis>
* <xref:fundamentals/minimal-apis/openapi>
* <xref:fundamentals/minimal-apis/responses>
* <xref:fundamentals/minimal-apis/min-api-filters>
* <xref:fundamentals/minimal-apis/handle-errors>
* <xref:fundamentals/minimal-apis/security>
* <xref:fundamentals/minimal-apis/test-min-api>
* [Short-circuit routing](https://andrewlock.net/exploring-the-dotnet-8-preview-short-circuit-routing/)
* [Identity API endpoints](https://andrewlock.net/exploring-the-dotnet-8-preview-introducing-the-identity-api-endpoints/)
* [Keyed service dependency injection container support](https://andrewlock.net/exploring-the-dotnet-8-preview-keyed-services-dependency-injection-support/)
* [A look behind the scenes of minimal API endpoints](https://andrewlock.net/behind-the-scenes-of-minimal-apis-1-a-first-look-behind-the-scenes-of-minimal-api-endpoints/)
* [Organizing ASP.NET Core Minimal APIs](https://www.tessferrandez.com/blog/2023/10/31/organizing-minimal-apis.html)
* [Fluent validation discussion on GitHub](https://github.com/dotnet/aspnetcore/issues/51834#issuecomment-1837180853)

:::moniker-end

[!INCLUDE[](~/fundamentals/minimal-apis/includes/minimal-apis7.md)]
[!INCLUDE[](~/fundamentals/minimal-apis/includes/minimal-apis6.md)]
