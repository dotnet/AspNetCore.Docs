---
title: Routing in ASP.NET Core
author: rick-anderson
description: Discover how ASP.NET Core routing is responsible for matching HTTP requests and dispatching to executable endpoints.
monikerRange: '>= aspnetcore-3.1'
ms.author: riande
ms.custom: mvc
ms.date: 04/11/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: fundamentals/routing
---
# Routing in ASP.NET Core

By [Ryan Nowak](https://github.com/rynowak), [Kirk Larkin](https://twitter.com/serpent5), and [Rick Anderson](https://twitter.com/RickAndMSFT)

:::moniker range=">= aspnetcore-6.0"

Routing is responsible for matching incoming HTTP requests and dispatching those requests to the app's executable endpoints. [Endpoints](#endpoints) are the app's units of executable request-handling code. Endpoints are defined in the app and configured when the app starts. The endpoint matching process can extract values from the request's URL and provide those values for request processing. Using endpoint information from the app, routing is also able to generate URLs that map to endpoints.

Apps can configure routing using:

* Controllers
* Razor Pages
* SignalR
* gRPC Services
* Endpoint-enabled [middleware](xref:fundamentals/middleware/index) such as [Health Checks](xref:host-and-deploy/health-checks).
* Delegates and lambdas registered with routing.

This article covers low-level details of ASP.NET Core routing. For information on configuring routing:

* For controllers, see <xref:mvc/controllers/routing>.
* For Razor Pages conventions, see <xref:razor-pages/razor-pages-conventions>.

## Routing basics

The following code shows a basic example of routing:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Program.cs" highlight="4":::

The preceding example includes a single endpoint using the <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapGet%2A> method:

* When an HTTP `GET` request is sent to the root URL `/`:
  * The request delegate executes.
  * `Hello World!` is written to the HTTP response.
* If the request method is not `GET` or the root URL is not `/`, no route matches and an HTTP 404 is returned.

Routing uses a pair of middleware, registered by <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A> and <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A>:

* `UseRouting` adds route matching to the middleware pipeline. This middleware looks at the set of endpoints defined in the app, and selects the [best match](#urlm) based on the request.
* `UseEndpoints` adds endpoint execution to the middleware pipeline. It runs the delegate associated with the selected endpoint.

Apps typically don't need to call `UseRouting` or `UseEndpoints`. <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> configures a middleware pipeline that wraps middleware added in `Program.cs` with `UseRouting` and `UseEndpoints`. However, apps can change the order in which `UseRouting` and `UseEndpoints` run by calling these methods explicitly. For example, the following code makes an explicit call to `UseRouting`:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Program.cs" id="snippet_UseRouting" highlight="7":::

In the preceding code:

* The call to `app.Use` registers a custom middleware that runs at the start of the pipeline.
* The call to `UseRouting` configures the route matching middleware to run *after* the custom middleware.
* The endpoint registered with `MapGet` runs at the end of the pipeline.

If the preceding example didn't include a call to `UseRouting`, the custom middleware would run *after* the route matching middleware.

### Endpoints

<a name="endpoint"></a>

The `MapGet` method is used to define an **endpoint**. An endpoint is something that can be:

* Selected, by matching the URL and HTTP method.
* Executed, by running the delegate.

Endpoints that can be matched and executed by the app are configured in `UseEndpoints`. For example, <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapGet%2A>, <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapPost%2A>, and [similar methods](xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions) connect request delegates to the routing system. Additional methods can be used to connect ASP.NET Core framework features to the routing system:

* [MapRazorPages for Razor Pages](xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapRazorPages%2A)
* [MapControllers for controllers](xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllers%2A)
* [MapHub\<THub> for SignalR](xref:Microsoft.AspNetCore.SignalR.HubRouteBuilder.MapHub%2A) 
* [MapGrpcService\<TService> for gRPC](xref:grpc/aspnetcore)

The following example shows routing with a more sophisticated route template:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Program.cs" id="snippet_RouteTemplate":::

The string `/hello/{name:alpha}` is a **route template**. A route template is used to configure how the endpoint is matched. In this case, the template matches:

* A URL like `/hello/Docs`
* Any URL path that begins with `/hello/` followed by a sequence of alphabetic characters. `:alpha` applies a route constraint that matches only alphabetic characters. [Route constraints](#route-constraints) are explained later in this article.

The second segment of the URL path, `{name:alpha}`:

* Is bound to the `name` parameter.
* Is captured and stored in <xref:Microsoft.AspNetCore.Http.HttpRequest.RouteValues%2A?displayProperty=nameWithType>.

The following example shows routing with [health checks](xref:host-and-deploy/health-checks) and authorization:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Program.cs" id="snippet_HealthChecksAuthz":::

The preceding example demonstrates how:

* The authorization middleware can be used with routing.
* Endpoints can be used to configure authorization behavior.

The <xref:Microsoft.AspNetCore.Builder.HealthCheckEndpointRouteBuilderExtensions.MapHealthChecks%2A> call adds a health check endpoint. Chaining <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A> on to this call attaches an authorization policy to the endpoint.

Calling <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A> and <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A> adds the authentication and authorization middleware. These middleware are placed between <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A> and `UseEndpoints` so that they can:

* See which endpoint was selected by `UseRouting`.
* Apply an authorization policy before <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A> dispatches to the endpoint.



<a name="metadata"></a>

### Endpoint metadata

In the preceding example, there are two endpoints, but only the health check endpoint has an authorization policy attached. If the request matches the health check endpoint, `/healthz`, an authorization check is performed. This demonstrates that endpoints can have extra data attached to them. This extra data is called endpoint **metadata**:

* The metadata can be processed by routing-aware middleware.
* The metadata can be of any .NET type.

## Routing concepts

The routing system builds on top of the middleware pipeline by adding the powerful **endpoint** concept. Endpoints represent units of the app's functionality that are distinct from each other in terms of routing, authorization, and any number of ASP.NET Core's systems.

<a name="endpoint"></a>

### ASP.NET Core endpoint definition

An ASP.NET Core endpoint is:

* Executable: Has a <xref:Microsoft.AspNetCore.Http.Endpoint.RequestDelegate>.
* Extensible: Has a [Metadata](xref:Microsoft.AspNetCore.Http.Endpoint.Metadata%2A) collection.
* Selectable: Optionally, has [routing information](xref:Microsoft.AspNetCore.Routing.RouteEndpoint.RoutePattern%2A).
* Enumerable: The collection of endpoints can be listed by retrieving the <xref:Microsoft.AspNetCore.Routing.EndpointDataSource> from [DI](xref:fundamentals/dependency-injection).

The following code shows how to retrieve and inspect the endpoint matching the current request:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Program.cs" id="snippet_InspectEndpointMiddleware":::

The endpoint, if selected, can be retrieved from the `HttpContext`. Its properties can be inspected. Endpoint objects are immutable and cannot be modified after creation. The most common type of endpoint is a <xref:Microsoft.AspNetCore.Routing.RouteEndpoint>. `RouteEndpoint` includes information that allows it to be selected by the routing system.

In the preceding code, [app.Use](xref:Microsoft.AspNetCore.Builder.UseExtensions.Use%2A) configures an inline [middleware](xref:fundamentals/middleware/index).

<a name="mt"></a>

The following code shows that, depending on where `app.Use` is called in the pipeline, there may not be an endpoint:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Program.cs" id="snippet_CurrentEndpointMiddlewareOrder":::

The preceding sample adds `Console.WriteLine` statements that display whether or not an endpoint has been selected. For clarity, the sample assigns a display name to the provided `/` endpoint.

The preceding sample also includes calls to `UseRouting` and `UseEndpoints` to control exactly when these middleware run within the pipeline.

Running this code with a URL of `/` displays:

```txt
1. Endpoint: (null)
2. Endpoint: Hello
3. Endpoint: Hello
```

Running this code with any other URL displays:

```txt
1. Endpoint: (null)
2. Endpoint: (null)
4. Endpoint: (null)
```

This output demonstrates that:

* The endpoint is always null before `UseRouting` is called.
* If a match is found, the endpoint is non-null between `UseRouting` and <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A>.
* The `UseEndpoints` middleware is **terminal** when a match is found. [Terminal middleware](#tm) is defined later in this article.
* The middleware after `UseEndpoints` execute only when no match is found.

The `UseRouting` middleware uses the <xref:Microsoft.AspNetCore.Http.EndpointHttpContextExtensions.SetEndpoint%2A> method to attach the endpoint to the current context. It's possible to replace the `UseRouting` middleware with custom logic and still get the benefits of using endpoints. Endpoints are a low-level primitive like middleware, and aren't coupled to the routing implementation. Most apps don't need to replace `UseRouting` with custom logic.

The `UseEndpoints` middleware is designed to be used in tandem with the `UseRouting` middleware. The core logic to execute an endpoint isn't complicated. Use <xref:Microsoft.AspNetCore.Http.EndpointHttpContextExtensions.GetEndpoint%2A> to retrieve the endpoint, and then invoke its <xref:Microsoft.AspNetCore.Http.Endpoint.RequestDelegate> property.

The following code demonstrates how middleware can influence or react to routing:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Program.cs" id="snippet_RequiresAudit":::
:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/RequiresAuditAttribute.cs" id="snippet_Class":::

The preceding example demonstrates two important concepts:

* Middleware can run before `UseRouting` to modify the data that routing operates upon.
  * Usually middleware that appears before routing modifies some property of the request, such as <xref:Microsoft.AspNetCore.Builder.RewriteBuilderExtensions.UseRewriter%2A>, <xref:Microsoft.AspNetCore.Builder.HttpMethodOverrideExtensions.UseHttpMethodOverride%2A>, or <xref:Microsoft.AspNetCore.Builder.UsePathBaseExtensions.UsePathBase%2A>.
* Middleware can run between `UseRouting` and <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A> to process the results of routing before the endpoint is executed.
  * Middleware that runs between `UseRouting` and `UseEndpoints`:
    * Usually inspects metadata to understand the endpoints.
    * Often makes security decisions, as done by `UseAuthorization` and `UseCors`.
  * The combination of middleware and metadata allows configuring policies per-endpoint.

The preceding code shows an example of a custom middleware that supports per-endpoint policies. The middleware writes an *audit log* of access to sensitive data to the console. The middleware can be configured to *audit* an endpoint with the `RequiresAuditAttribute` metadata. This sample demonstrates an *opt-in* pattern where only endpoints that are marked as sensitive are audited. It's possible to define this logic in reverse, auditing everything that isn't marked as safe, for example. The endpoint metadata system is flexible. This logic could be designed in whatever way suits the use case.

The preceding sample code is intended to demonstrate the basic concepts of endpoints. **The sample is not intended for production use**. A more complete version of an *audit log* middleware would:

* Log to a file or database.
* Include details such as the user, IP address, name of the sensitive endpoint, and more.

The audit policy metadata `RequiresAuditAttribute` is defined as an `Attribute` for easier use with class-based frameworks such as controllers and SignalR. When using *route to code*:

* Metadata is attached with a builder API.
* Class-based frameworks include all attributes on the corresponding method and class when creating endpoints.

The best practices for metadata types are to define them either as interfaces or attributes. Interfaces and attributes allow code reuse. The metadata system is flexible and doesn't impose any limitations.

<a name="tm"></a>

### Compare terminal middleware with routing

The following example demonstrates both terminal middleware and routing:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Program.cs" id="snippet_CompareTerminalMiddlewareRouting":::

The style of middleware shown with `Approach 1:` is **terminal middleware**. It's called terminal middleware because it does a matching operation:

* The matching operation in the preceding sample is `Path == "/"` for the middleware and `Path == "/Routing"` for routing.
* When a match is successful, it executes some functionality and returns, rather than invoking the `next` middleware.

It's called terminal middleware because it terminates the search, executes some functionality, and then returns.

The following list compares terminal middleware with routing:

* Both approaches allow terminating the processing pipeline:
  * Middleware terminates the pipeline by returning rather than invoking `next`.
  * Endpoints are always terminal.
* Terminal middleware allows positioning the middleware at an arbitrary place in the pipeline:
  * Endpoints execute at the position of <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A>.
* Terminal middleware allows arbitrary code to determine when the middleware matches:
  * Custom route matching code can be verbose and difficult to write correctly.
  * Routing provides straightforward solutions for typical apps. Most apps don't require custom route matching code.
* Endpoints interface with middleware such as `UseAuthorization` and `UseCors`.
  * Using a terminal middleware with `UseAuthorization` or `UseCors` requires manual interfacing with the authorization system.

An [endpoint](#endpoints) defines both:

* A delegate to process requests.
* A collection of arbitrary metadata. The metadata is used to implement cross-cutting concerns based on policies and configuration attached to each endpoint.

Terminal middleware can be an effective tool, but can require:

* A significant amount of coding and testing.
* Manual integration with other systems to achieve the desired level of flexibility.

Consider integrating with routing before writing a terminal middleware.

Existing terminal middleware that integrates with [Map](xref:fundamentals/middleware/index#branch-the-middleware-pipeline) or <xref:Microsoft.AspNetCore.Builder.MapWhenExtensions.MapWhen%2A> can usually be turned into a routing aware endpoint. [MapHealthChecks](https://github.com/dotnet/AspNetCore/blob/main/src/Middleware/HealthChecks/src/Builder/HealthCheckEndpointRouteBuilderExtensions.cs#L16) demonstrates the pattern for router-ware:

* Write an extension method on <xref:Microsoft.AspNetCore.Routing.IEndpointRouteBuilder>.
* Create a nested middleware pipeline using <xref:Microsoft.AspNetCore.Routing.IEndpointRouteBuilder.CreateApplicationBuilder%2A>.
* Attach the middleware to the new pipeline. In this case, <xref:Microsoft.AspNetCore.Builder.HealthCheckApplicationBuilderExtensions.UseHealthChecks%2A>.
* <xref:Microsoft.AspNetCore.Builder.IApplicationBuilder.Build%2A> the middleware pipeline into a <xref:Microsoft.AspNetCore.Http.RequestDelegate>.
* Call `Map` and provide the new middleware pipeline.
* Return the builder object provided by `Map` from the extension method.

The following code shows use of [MapHealthChecks](xref:host-and-deploy/health-checks):

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Program.cs" id="snippet_MapHealthChecks" highlight="4":::

The preceding sample shows why returning the builder object is important. Returning the builder object allows the app developer to configure policies such as authorization for the endpoint. In this example, the health checks middleware has no direct integration with the authorization system.

The metadata system was created in response to the problems encountered by extensibility authors using terminal middleware. It's problematic for each middleware to implement its own integration with the authorization system.

<a name="urlm"></a>

### URL matching

* Is the process by which routing matches an incoming request to an [endpoint](#endpoints).
* Is based on data in the URL path and headers.
* Can be extended to consider any data in the request.

When a routing middleware executes, it sets an `Endpoint` and route values to a [request feature](xref:fundamentals/request-features) on the <xref:Microsoft.AspNetCore.Http.HttpContext> from the current request:

* Calling [HttpContext.GetEndpoint](xref:Microsoft.AspNetCore.Http.EndpointHttpContextExtensions.GetEndpoint%2A) gets the endpoint.
* `HttpRequest.RouteValues` gets the collection of route values.

[Middleware](xref:fundamentals/middleware/index) running after the routing middleware can inspect the endpoint and take action. For example, an authorization middleware can interrogate the endpoint's metadata collection for an authorization policy. After all of the middleware in the request processing pipeline is executed, the selected endpoint's delegate is invoked.

The routing system in endpoint routing is responsible for all dispatching decisions. Because the middleware applies policies based on the selected endpoint, it's important that:

* Any decision that can affect dispatching or the application of security policies is made inside the routing system.

> [!WARNING]
> For backwards-compatibility, when a Controller or Razor Pages endpoint delegate is executed, the properties of <xref:Microsoft.AspNetCore.Routing.RouteContext.RouteData%2A?displayProperty=nameWithType> are set to appropriate values based on the request processing performed thus far.
>
> The `RouteContext` type will be marked obsolete in a future release:
>
> * Migrate `RouteData.Values` to `HttpRequest.RouteValues`.
> * Migrate `RouteData.DataTokens` to retrieve <xref:Microsoft.AspNetCore.Routing.IDataTokensMetadata> from the endpoint metadata.

URL matching operates in a configurable set of phases. In each phase, the output is a set of matches. The set of matches can be narrowed down further by the next phase. The routing implementation does not guarantee a processing order for matching endpoints. **All** possible matches are processed at once. The URL matching phases occur in the following order. ASP.NET Core:

1. Processes the URL path against the set of endpoints and their route templates, collecting **all** of the matches.
1. Takes the preceding list and removes matches that fail with route constraints applied.
1. Takes the preceding list and removes matches that fail the set of <xref:Microsoft.AspNetCore.Routing.MatcherPolicy> instances.
1. Uses the <xref:Microsoft.AspNetCore.Routing.Matching.EndpointSelector> to make a final decision from the preceding list.

The list of endpoints is prioritized according to:

* The <xref:Microsoft.AspNetCore.Routing.RouteEndpoint.Order%2A?displayProperty=nameWithType>
* The [route template precedence](#rtp)

All matching endpoints are processed in each phase until the <xref:Microsoft.AspNetCore.Routing.Matching.EndpointSelector> is reached. The `EndpointSelector` is the final phase. It chooses the highest priority endpoint from the matches as the best match. If there are other matches with the same priority as the best match, an ambiguous match exception is thrown.

The route precedence is computed based on a **more specific** route template being given a higher priority. For example, consider the templates `/hello` and `/{message}`:

* Both match the URL path `/hello`.
* `/hello` is more specific and therefore higher priority.

In general, route precedence does a good job of choosing the best match for the kinds of URL schemes used in practice. Use <xref:Microsoft.AspNetCore.Routing.RouteEndpoint.Order> only when necessary to avoid an ambiguity.

Due to the kinds of extensibility provided by routing, it isn't possible for the routing system to compute ahead of time the ambiguous routes. Consider an example such as the route templates `/{message:alpha}` and `/{message:int}`:

* The `alpha` constraint matches only alphabetic characters.
* The `int` constraint matches only numbers.
* These templates have the same route precedence, but there's no single URL they both match.
* If the routing system reported an ambiguity error at startup, it would block this valid use case.

> [!WARNING]
>
> The order of operations inside <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A> doesn't influence the behavior of routing, with one exception. <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A> and <xref:Microsoft.AspNetCore.Builder.MvcAreaRouteBuilderExtensions.MapAreaRoute%2A> automatically assign an order value to their endpoints based on the order they are invoked. This simulates long-time behavior of controllers without the routing system providing the same guarantees as older routing implementations.
>
> Endpoint routing in ASP.NET Core:
> 
> * Doesn't have the concept of routes.
> * Doesn't provide ordering guarantees. All endpoints are processed at once.

<a name="rtp"></a>

### Route template precedence and endpoint selection order

[Route template precedence](https://github.com/dotnet/aspnetcore/blob/main/src/Http/Routing/src/Template/RoutePrecedence.cs#L16) is a system that assigns each route template a value based on how specific it is. Route template precedence:

* Avoids the need to adjust the order of endpoints in common cases.
* Attempts to match the common-sense expectations of routing behavior.

For example, consider templates `/Products/List` and `/Products/{id}`. It would be reasonable to assume that `/Products/List` is a better match than `/Products/{id}` for the URL path `/Products/List`. This works because the literal segment `/List` is considered to have better precedence than the parameter segment `/{id}`.

The details of how precedence works are coupled to how route templates are defined:

* Templates with more segments are considered more specific.
* A segment with literal text is considered more specific than a parameter segment.
* A parameter segment with a constraint is considered more specific than one without.
* A complex segment is considered as specific as a parameter segment with a constraint.
* Catch-all parameters are the least specific. See **catch-all** in the [Route templates](#rtr) section for important information on catch-all routes.

<a name="lg"></a>

### URL generation concepts

URL generation:

* Is the process by which routing can create a URL path based on a set of route values.
* Allows for a logical separation between endpoints and the URLs that access them.

Endpoint routing includes the <xref:Microsoft.AspNetCore.Routing.LinkGenerator> API. `LinkGenerator` is a singleton service available from [DI](xref:fundamentals/dependency-injection). The `LinkGenerator` API can be used outside of the context of an executing request. [Mvc.IUrlHelper](xref:Microsoft.AspNetCore.Mvc.IUrlHelper) and scenarios that rely on <xref:Microsoft.AspNetCore.Mvc.IUrlHelper>, such as [Tag Helpers](xref:mvc/views/tag-helpers/intro), HTML Helpers, and [Action Results](xref:mvc/controllers/actions), use the `LinkGenerator` API internally to provide link generating capabilities.

The link generator is backed by the concept of an **address** and **address schemes**. An address scheme is a way of determining the endpoints that should be considered for link generation. For example, the route name and route values scenarios many users are familiar with from controllers and Razor Pages are implemented as an address scheme.

The link generator can link to controllers and Razor Pages via the following extension methods:

* <xref:Microsoft.AspNetCore.Routing.ControllerLinkGeneratorExtensions.GetPathByAction%2A>
* <xref:Microsoft.AspNetCore.Routing.ControllerLinkGeneratorExtensions.GetUriByAction%2A>
* <xref:Microsoft.AspNetCore.Routing.PageLinkGeneratorExtensions.GetPathByPage%2A>
* <xref:Microsoft.AspNetCore.Routing.PageLinkGeneratorExtensions.GetUriByPage%2A>

Overloads of these methods accept arguments that include the `HttpContext`. These methods are functionally equivalent to [Url.Action](xref:Microsoft.AspNetCore.Mvc.Routing.UrlHelper.Action%2A) and [Url.Page](xref:Microsoft.AspNetCore.Mvc.UrlHelperExtensions.Page%2A), but offer additional flexibility and options.

The `GetPath*` methods are most similar to `Url.Action` and `Url.Page`, in that they generate a URI containing an absolute path. The `GetUri*` methods always generate an absolute URI containing a scheme and host. The methods that accept an `HttpContext` generate a URI in the context of the executing request. The [ambient](#ambient) route values, URL base path, scheme, and host from the executing request are used unless overridden.

<xref:Microsoft.AspNetCore.Routing.LinkGenerator> is called with an address. Generating a URI occurs in two steps:

1. An address is bound to a list of endpoints that match the address.
1. Each endpoint's <xref:Microsoft.AspNetCore.Routing.RouteEndpoint.RoutePattern> is evaluated until a route pattern that matches the supplied values is found. The resulting output is combined with the other URI parts supplied to the link generator and returned.

The methods provided by <xref:Microsoft.AspNetCore.Routing.LinkGenerator> support standard link generation capabilities for any type of address. The most convenient way to use the link generator is through extension methods that perform operations for a specific address type:

| Extension Method                                                      | Description                                                         |
|-----------------------------------------------------------------------|---------------------------------------------------------------------|
| <xref:Microsoft.AspNetCore.Routing.LinkGenerator.GetPathByAddress%2A> | Generates a URI with an absolute path based on the provided values. |
| <xref:Microsoft.AspNetCore.Routing.LinkGenerator.GetUriByAddress%2A>  | Generates an absolute URI based on the provided values.             |

> [!WARNING]
> Pay attention to the following implications of calling <xref:Microsoft.AspNetCore.Routing.LinkGenerator> methods:
>
> * Use `GetUri*` extension methods with caution in an app configuration that doesn't validate the `Host` header of incoming requests. If the `Host` header of incoming requests isn't validated, untrusted request input can be sent back to the client in URIs in a view or page. We recommend that all production apps configure their server to validate the `Host` header against known valid values.
>
> * Use <xref:Microsoft.AspNetCore.Routing.LinkGenerator> with caution in middleware in combination with `Map` or `MapWhen`. `Map*` changes the base path of the executing request, which affects the output of link generation. All of the <xref:Microsoft.AspNetCore.Routing.LinkGenerator> APIs allow specifying a base path. Specify an empty base path to undo the `Map*` affect on link generation.

### Middleware example

In the following example, a middleware uses the <xref:Microsoft.AspNetCore.Routing.LinkGenerator> API to create a link to an action method that lists store products. Using the link generator by injecting it into a class and calling `GenerateLink` is available to any class in an app:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Middleware/ProductsMiddleware.cs" id="snippet_Class" highlight="12":::

<a name="rtr"></a>

## Route templates

Tokens within `{}` define route parameters that are bound if the route is matched. More than one route parameter can be defined in a route segment, but route parameters must be separated by a literal value. For example, `{controller=Home}{action=Index}` isn't a valid route, since there's no literal value between `{controller}` and `{action}`. Route parameters must have a name and may have additional attributes specified.

Literal text other than route parameters (for example, `{id}`) and the path separator `/` must match the text in the URL. Text matching is case-insensitive and based on the decoded representation of the URL's path. To match a literal route parameter delimiter `{` or `}`, escape the delimiter by repeating the character. For example `{{` or `}}`.

Asterisk `*` or double asterisk `**`:

* Can be used as a prefix to a route parameter to bind to the rest of the URI.
* Are called a **catch-all** parameters. For example, `blog/{**slug}`:
  * Matches any URI that starts with `blog/` and has any value following it.
  * The value following `blog/` is assigned to the [slug](https://developer.mozilla.org/docs/Glossary/Slug) route value.

[!INCLUDE[](~/includes/catchall.md)]

Catch-all parameters can also match the empty string.

The catch-all parameter escapes the appropriate characters when the route is used to generate a URL, including path separator `/` characters. For example, the route `foo/{*path}` with route values `{ path = "my/path" }` generates `foo/my%2Fpath`. Note the escaped forward slash. To round-trip path separator characters, use the `**` route parameter prefix. The route `foo/{**path}` with `{ path = "my/path" }` generates `foo/my/path`.

URL patterns that attempt to capture a file name with an optional file extension have additional considerations. For example, consider the template `files/{filename}.{ext?}`. When values for both `filename` and `ext` exist, both values are populated. If only a value for `filename` exists in the URL, the route matches because the trailing `.` is optional. The following URLs match this route:

* `/files/myFile.txt`
* `/files/myFile`

Route parameters may have **default values** designated by specifying the default value after the parameter name separated by an equals sign (`=`). For example, `{controller=Home}` defines `Home` as the default value for `controller`. The default value is used if no value is present in the URL for the parameter. Route parameters are made optional by appending a question mark (`?`) to the end of the parameter name. For example, `id?`. The difference between optional values and default route parameters is:

* A route parameter with a default value always produces a value.
* An optional parameter has a value only when a value is provided by the request URL.

Route parameters may have constraints that must match the route value bound from the URL. Adding `:` and constraint name after the route parameter name specifies an inline constraint on a route parameter. If the constraint requires arguments, they're enclosed in parentheses `(...)` after the constraint name. Multiple *inline constraints* can be specified by appending another `:` and constraint name.

The constraint name and arguments are passed to the <xref:Microsoft.AspNetCore.Routing.IInlineConstraintResolver> service to create an instance of <xref:Microsoft.AspNetCore.Routing.IRouteConstraint> to use in URL processing. For example, the route template `blog/{article:minlength(10)}` specifies a `minlength` constraint with the argument `10`. For more information on route constraints and a list of the constraints provided by the framework, see the [Route constraints](#route-constraints) section.

Route parameters may also have parameter transformers. Parameter transformers transform a parameter's value when generating links and matching actions and pages to URLs. Like constraints, parameter transformers can be added inline to a route parameter by adding a `:` and transformer name after the route parameter name. For example, the route template `blog/{article:slugify}` specifies a `slugify` transformer. For more information on parameter transformers, see the [Parameter transformers](#parameter-transformers) section.

The following table demonstrates example route templates and their behavior:

| Route Template                           | Example Matching URI    | The request URI&hellip;                                                      |
|------------------------------------------|-------------------------|------------------------------------------------------------------------------|
| `hello`                                  | `/hello`                | Only matches the single path `/hello`.                                       |
| `{Page=Home}`                            | `/`                     | Matches and sets `Page` to `Home`.                                           |
| `{Page=Home}`                            | `/Contact`              | Matches and sets `Page` to `Contact`.                                        |
| `{controller}/{action}/{id?}`            | `/Products/List`        | Maps to the `Products` controller and `List` action.                         |
| `{controller}/{action}/{id?}`            | `/Products/Details/123` | Maps to the `Products` controller and  `Details` action with`id` set to 123. |
| `{controller=Home}/{action=Index}/{id?}` | `/`                     | Maps to the `Home` controller and `Index` method. `id` is ignored.           |
| `{controller=Home}/{action=Index}/{id?}` | `/Products`             | Maps to the `Products` controller and `Index` method. `id` is ignored.       |

Using a template is generally the simplest approach to routing. Constraints and defaults can also be specified outside the route template.

### Complex segments

Complex segments are processed by matching up literal delimiters from right to left in a [non-greedy](#greedy) way. For example, `[Route("/a{b}c{d}")]` is a complex segment.
Complex segments work in a particular way that must be understood to use them successfully. The example in this section demonstrates why complex segments only really work well when the delimiter text doesn't appear inside the parameter values. Using a [regex](/dotnet/standard/base-types/regular-expressions) and then manually extracting the values is needed for more complex cases.

[!INCLUDE[](~/includes/regex.md)]

This is a summary of the steps that routing performs with the template `/a{b}c{d}` and the URL path `/abcd`. The `|` is used to help visualize how the algorithm works:

* The first literal, right to left, is `c`. So `/abcd` is searched from right and finds `/ab|c|d`.
* Everything to the right (`d`) is now matched to the route parameter `{d}`.
* The next literal, right to left, is `a`. So `/ab|c|d` is searched starting where we left off, then `a` is found `/|a|b|c|d`.
* The value to the right (`b`) is now matched to the route parameter `{b}`.
* There is no remaining text and no remaining route template, so this is a match.

Here's an example of a negative case using the same template `/a{b}c{d}` and the URL path `/aabcd`. The `|` is used to help visualize how the algorithm works. This case isn't a match, which is explained by the same algorithm:
* The first literal, right to left, is `c`. So `/aabcd` is searched from right and finds `/aab|c|d`.
* Everything to the right (`d`) is now matched to the route parameter `{d}`.
* The next literal, right to left, is `a`. So `/aab|c|d` is searched starting where we left off, then `a` is found `/a|a|b|c|d`.
* The value to the right (`b`) is now matched to the route parameter `{b}`.
* At this point there is remaining text `a`, but the algorithm has run out of route template to parse, so this is not a match.

Since the matching algorithm is [non-greedy](#greedy):

* It matches the smallest amount of text possible in each step.
* Any case where the delimiter value appears inside the parameter values results in not matching.

Regular expressions provide much more control over their matching behavior.

<a name="greedy"></a>

Greedy matching, also know as [lazy matching](https://wikipedia.org/wiki/Regular_expression#Lazy_matching), matches the largest possible string. Non-greedy matches the smallest possible string.

## Route constraints

Route constraints execute when a match has occurred to the incoming URL and the URL path is tokenized into route values. Route constraints generally inspect the route value associated via the route template and make a true or false decision about whether the value is acceptable. Some route constraints use data outside the route value to consider whether the request can be routed. For example, the <xref:Microsoft.AspNetCore.Routing.Constraints.HttpMethodRouteConstraint> can accept or reject a request based on its HTTP verb. Constraints are used in routing requests and link generation.

> [!WARNING]
> Don't use constraints for input validation. If constraints are used for input validation, invalid input results in a `404` Not Found response. Invalid input should produce a `400` Bad Request with an appropriate error message. Route constraints are used to disambiguate similar routes, not to validate the inputs for a particular route.

The following table demonstrates example route constraints and their expected behavior:

| constraint          | Example                                     | Example Matches                        | Notes                                                                                     |
|---------------------|---------------------------------------------|----------------------------------------|-------------------------------------------------------------------------------------------|
| `int`               | `{id:int}`                                  | `123456789`, `-123456789`              | Matches any integer                                                                       |
| `bool`              | `{active:bool}`                             | `true`, `FALSE`                        | Matches `true` or `false`. Case-insensitive                                               |
| `datetime`          | `{dob:datetime}`                            | `2016-12-31`, `2016-12-31 7:32pm`      | Matches a valid `DateTime` value in the invariant culture. See preceding warning.         |
| `decimal`           | `{price:decimal}`                           | `49.99`, `-1,000.01`                   | Matches a valid `decimal` value in the invariant culture. See preceding warning.          |
| `double`            | `{weight:double}`                           | `1.234`, `-1,001.01e8`                 | Matches a valid `double` value in the invariant culture. See preceding warning.           |
| `float`             | `{weight:float}`                            | `1.234`, `-1,001.01e8`                 | Matches a valid `float` value in the invariant culture. See preceding warning.            |
| `guid`              | `{id:guid}`                                 | `CD2C1638-1638-72D5-1638-DEADBEEF1638` | Matches a valid `Guid` value                                                              |
| `long`              | `{ticks:long}`                              | `123456789`, `-123456789`              | Matches a valid `long` value                                                              |
| `minlength(value)`  | `{username:minlength(4)}`                   | `Rick`                                 | String must be at least 4 characters                                                      |
| `maxlength(value)`  | `{filename:maxlength(8)}`                   | `MyFile`                               | String must be no more than 8 characters                                                  |
| `length(length)`    | `{filename:length(12)}`                     | `somefile.txt`                         | String must be exactly 12 characters long                                                 |
| `length(min,max)`   | `{filename:length(8,16)}`                   | `somefile.txt`                         | String must be at least 8 and no more than 16 characters long                             |
| `min(value)`        | `{age:min(18)}`                             | `19`                                   | Integer value must be at least 18                                                         |
| `max(value)`        | `{age:max(120)}`                            | `91`                                   | Integer value must be no more than 120                                                    |
| `range(min,max)`    | `{age:range(18,120)}`                       | `91`                                   | Integer value must be at least 18 but no more than 120                                    |
| `alpha`             | `{name:alpha}`                              | `Rick`                                 | String must consist of one or more alphabetical characters, `a`-`z` and case-insensitive. |
| `regex(expression)` | `{ssn:regex(^\\d{{3}}-\\d{{2}}-\\d{{4}}$)}` | `123-45-6789`                          | String must match the regular expression. See tips about defining a regular expression.   |
| `required`          | `{name:required}`                           | `Rick`                                 | Used to enforce that a non-parameter value is present during URL generation               |

[!INCLUDE[](~/includes/regex.md)]

Multiple, colon delimited constraints can be applied to a single parameter. For example, the following constraint restricts a parameter to an integer value of 1 or greater:

```csharp
[Route("users/{id:int:min(1)}")]
public User GetUserById(int id) { }
```

> [!WARNING]
> Route constraints that verify the URL and are converted to a CLR type always use the invariant culture. For example, conversion to the CLR type `int` or `DateTime`. These constraints assume that the URL is not localizable. The framework-provided route constraints don't modify the values stored in route values. All route values parsed from the URL are stored as strings. For example, the `float` constraint attempts to convert the route value to a float, but the converted value is used only to verify it can be converted to a float.

### Regular expressions in constraints

[!INCLUDE[](~/includes/regex.md)]

Regular expressions can be specified as inline constraints using the `regex(...)` route constraint. Methods in the <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A> family also accept an object literal of constraints. If that form is used, string values are interpreted as regular expressions.

The following code uses an inline regex constraint:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Program.cs" id="snippet_RegexMapGet":::

The following code uses an object literal to specify a regex constraint:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Program.cs" id="snippet_RegExMapControllerRoute" highlight="4":::

The ASP.NET Core framework adds `RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant` to the regular expression constructor. See <xref:System.Text.RegularExpressions.RegexOptions> for a description of these members.

Regular expressions use delimiters and tokens similar to those used by routing and the C# language. Regular expression tokens must be escaped. To use the regular expression `^\d{3}-\d{2}-\d{4}$` in an inline constraint, use one of the following:

* Replace `\` characters provided in the string as `\\` characters in the C# source file in order to escape the `\` string escape character.
* [Verbatim string literals](/dotnet/csharp/language-reference/keywords/string).

To escape routing parameter delimiter characters `{`, `}`, `[`, `]`, double the characters in the expression, for example, `{{`, `}}`, `[[`, `]]`. The following table shows a regular expression and its escaped version:

| Regular expression    | Escaped regular expression     |
| --------------------- | ------------------------------ |
| `^\d{3}-\d{2}-\d{4}$` | `^\\d{{3}}-\\d{{2}}-\\d{{4}}$` |
| `^[a-z]{2}$`          | `^[[a-z]]{{2}}$`               |

Regular expressions used in routing often start with the `^` character and match the starting position of the string. The expressions often end with the `$` character and match the end of the string. The `^` and `$` characters ensure that the regular expression matches the entire route parameter value. Without the `^` and `$` characters, the regular expression matches any substring within the string, which is often undesirable. The following table provides examples and explains why they match or fail to match:

| Expression   | String    | Match | Comment               |
| ------------ | --------- | :---: |  -------------------- |
| `[a-z]{2}`   | hello     | Yes   | Substring matches     |
| `[a-z]{2}`   | 123abc456 | Yes   | Substring matches     |
| `[a-z]{2}`   | mz        | Yes   | Matches expression    |
| `[a-z]{2}`   | MZ        | Yes   | Not case sensitive    |
| `^[a-z]{2}$` | hello     | No    | See `^` and `$` above |
| `^[a-z]{2}$` | 123abc456 | No    | See `^` and `$` above |

For more information on regular expression syntax, see [.NET Framework Regular Expressions](/dotnet/standard/base-types/regular-expression-language-quick-reference).

To constrain a parameter to a known set of possible values, use a regular expression. For example, `{action:regex(^(list|get|create)$)}` only matches the `action` route value to `list`, `get`, or `create`. If passed into the constraints dictionary, the string `^(list|get|create)$` is equivalent. Constraints that are passed in the constraints dictionary that don't match one of the known constraints are also treated as regular expressions. Constraints that are passed within a template that don't match one of the known constraints are not treated as regular expressions.

### Custom route constraints

Custom route constraints can be created by implementing the <xref:Microsoft.AspNetCore.Routing.IRouteConstraint> interface. The `IRouteConstraint` interface contains <xref:Microsoft.AspNetCore.Routing.IRouteConstraint.Match%2A>, which returns `true` if the constraint is satisfied and `false` otherwise.

Custom route constraints are rarely needed. Before implementing a custom route constraint, consider alternatives, such as model binding.

The ASP.NET Core [Constraints](https://github.com/dotnet/aspnetcore/tree/main/src/Http/Routing/src/Constraints) folder provides good examples of creating a constraints. For example, [GuidRouteConstraint](https://github.com/dotnet/aspnetcore/blob/main/src/Http/Routing/src/Constraints/GuidRouteConstraint.cs#L18).

To use a custom `IRouteConstraint`, the route constraint type must be registered with the app's <xref:Microsoft.AspNetCore.Routing.RouteOptions.ConstraintMap> in the service container. A `ConstraintMap` is a dictionary that maps route constraint keys to `IRouteConstraint` implementations that validate those constraints. An app's `ConstraintMap` can be updated in `Program.cs` either as part of an <xref:Microsoft.Extensions.DependencyInjection.RoutingServiceCollectionExtensions.AddRouting%2A> call or by configuring <xref:Microsoft.AspNetCore.Routing.RouteOptions> directly with `builder.Services.Configure<RouteOptions>`. For example:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Program.cs" id="snippet_AddRoutingConstraintMap":::

The preceding constraint is applied in the following code:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Controllers/NoZeroesController.cs" id="snippet_Class" highlight="5":::

The implementation of `NoZeroesRouteConstraint` prevents `0` being used in a route parameter:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Routing/NoZeroesRouteConstraint.cs" id="snippet_Class":::

[!INCLUDE[](~/includes/regex.md)]

The preceding code:

* Prevents `0` in the `{id}` segment of the route.
* Is shown to provide a basic example of implementing a custom constraint. It should not be used in a production app.

The following code is a better approach to preventing an `id` containing a `0` from being processed:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Controllers/BetterNoZeroesController.cs" id="snippet_Action":::

The preceding code has the following advantages over the `NoZeroesRouteConstraint` approach:

* It doesn't require a custom constraint.
* It returns a more descriptive error when the route parameter includes `0`.

## Parameter transformers

Parameter transformers:

* Execute when generating a link using <xref:Microsoft.AspNetCore.Routing.LinkGenerator>.
* Implement <xref:Microsoft.AspNetCore.Routing.IOutboundParameterTransformer?displayProperty=fullName>.
* Are configured using <xref:Microsoft.AspNetCore.Routing.RouteOptions.ConstraintMap>.
* Take the parameter's route value and transform it to a new string value.
* Result in using the transformed value in the generated link.

For example, a custom `slugify` parameter transformer in route pattern `blog\{article:slugify}` with `Url.Action(new { article = "MyTestArticle" })` generates `blog\my-test-article`.

Consider the following `IOutboundParameterTransformer` implementation:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Routing/SlugifyParameterTransformer.cs" id="snippet_Class":::

To use a parameter transformer in a route pattern, configure it using <xref:Microsoft.AspNetCore.Routing.RouteOptions.ConstraintMap> in `Program.cs`:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Program.cs" id="snippet_AddRouting":::

The ASP.NET Core framework uses parameter transformers to transform the URI where an endpoint resolves. For example, parameter transformers transform the route values used to match an `area`, `controller`, `action`, and `page`:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Program.cs" id="snippet_MapControllerRoute":::

With the preceding route template, the action `SubscriptionManagementController.GetAll` is matched with the URI `/subscription-management/get-all`. A parameter transformer doesn't change the route values used to generate a link. For example, `Url.Action("GetAll", "SubscriptionManagement")` outputs `/subscription-management/get-all`.

ASP.NET Core provides API conventions for using parameter transformers with generated routes:

* The <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.RouteTokenTransformerConvention?displayProperty=fullName> MVC convention applies a specified parameter transformer to all attribute routes in the app. The parameter transformer transforms attribute route tokens as they are replaced. For more information, see [Use a parameter transformer to customize token replacement](xref:mvc/controllers/routing#use-a-parameter-transformer-to-customize-token-replacement).
* Razor Pages uses the <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.PageRouteTransformerConvention> API convention. This convention applies a specified parameter transformer to all automatically discovered Razor Pages. The parameter transformer transforms the folder and file name segments of Razor Pages routes. For more information, see [Use a parameter transformer to customize page routes](xref:razor-pages/razor-pages-conventions#use-a-parameter-transformer-to-customize-page-routes).

<a name="ugr"></a>

## URL generation reference

This section contains a reference for the algorithm implemented by URL generation. In practice, most complex examples of URL generation use controllers or Razor Pages. See [routing in controllers](xref:mvc/controllers/routing) for additional information.

The URL generation process begins with a call to <xref:Microsoft.AspNetCore.Routing.LinkGenerator.GetPathByAddress%2A?displayProperty=nameWithType> or a similar method. The method is provided with an address, a set of route values, and optionally information about the current request from `HttpContext`.

The first step is to use the address to resolve a set of candidate endpoints using an <xref:Microsoft.AspNetCore.Routing.IEndpointAddressScheme%601> that matches the address's type.

Once the set of candidates is found by the address scheme, the endpoints are ordered and processed iteratively until a URL generation operation succeeds. URL generation does **not** check for ambiguities, the first result returned is the final result.

### Troubleshooting URL generation with logging

The first step in troubleshooting URL generation is setting the logging level of `Microsoft.AspNetCore.Routing` to `TRACE`. `LinkGenerator` logs many details about its processing which can be useful to troubleshoot problems.

See [URL generation reference](#ugr) for details on URL generation.

### Addresses

Addresses are the concept in URL generation used to bind a call into the link generator to a set of candidate endpoints.

Addresses are an extensible concept that come with two implementations by default:

* Using *endpoint name* (`string`) as the address:
  * Provides similar functionality to MVC's route name.
  * Uses the <xref:Microsoft.AspNetCore.Routing.IEndpointNameMetadata> metadata type.
  * Resolves the provided string against the metadata of all registered endpoints.
  * Throws an exception on startup if multiple endpoints use the same name.
  * Recommended for general-purpose use outside of controllers and Razor Pages.
* Using *route values* (<xref:Microsoft.AspNetCore.Routing.RouteValuesAddress>) as the address:
  * Provides similar functionality to controllers and Razor Pages legacy URL generation.
  * Very complex to extend and debug.
  * Provides the implementation used by `IUrlHelper`, Tag Helpers, HTML Helpers, Action Results, etc.

The role of the address scheme is to make the association between the address and matching endpoints by arbitrary criteria:

* The endpoint name scheme performs a basic dictionary lookup.
* The route values scheme has a complex best subset of set algorithm.

<a name="ambient"></a>

### Ambient values and explicit values

From the current request, routing accesses the route values of the current request `HttpContext.Request.RouteValues`. The values associated with the current request are referred to as the **ambient values**. For the purpose of clarity, the documentation refers to the route values passed in to methods as **explicit values**.

The following example shows ambient values and explicit values. It provides ambient values from the current request and explicit values:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Controllers/WidgetController.cs" id="snippet_ClassIndex":::

The preceding code:

* Returns `/Widget/Index/17`
* Gets <xref:Microsoft.AspNetCore.Routing.LinkGenerator> via [DI](xref:fundamentals/dependency-injection).

The following code provides only explicit values and no ambient values:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Controllers/WidgetController.cs" id="snippet_HomeSubscribe":::

The preceding method returns `/Home/Subscribe/17`

The following code in the `WidgetController` returns `/Widget/Subscribe/17`:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Controllers/WidgetController.cs" id="snippet_WidgetSubscribe":::

The following code provides the controller from ambient values in the current request and explicit values:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Controllers/GadgetController.cs" id="snippet_Class":::

In the preceding code:

* `/Gadget/Edit/17` is returned.
* <xref:Microsoft.AspNetCore.Mvc.ControllerBase.Url> gets the <xref:Microsoft.AspNetCore.Mvc.IUrlHelper>.
* <xref:Microsoft.AspNetCore.Mvc.UrlHelperExtensions.Action%2A> generates a URL with an absolute path for an action method. The URL contains the specified `action` name and `route` values.

The following code provides ambient values from the current request and explicit values:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Pages/Index.cshtml.cs" id="snippet_Class":::

The preceding code sets `url` to `/Edit/17` when the Edit Razor Page contains the following page directive:

`@page "{id:int}"`

If the Edit page doesn't contain the `"{id:int}"` route template, `url` is `/Edit?id=17`.

The behavior of MVC's <xref:Microsoft.AspNetCore.Mvc.IUrlHelper> adds a layer of complexity in addition to the rules described here:

* `IUrlHelper` always provides the route values from the current request as ambient values.
* [IUrlHelper.Action](xref:Microsoft.AspNetCore.Mvc.UrlHelperExtensions.Action%2A) always copies the current `action` and `controller` route values as explicit values unless overridden by the developer.
* [IUrlHelper.Page](xref:Microsoft.AspNetCore.Mvc.UrlHelperExtensions.Page%2A) always copies the current `page` route value as an explicit value unless overridden. <!--by the user-->
* `IUrlHelper.Page` always overrides the current `handler` route value with `null` as an explicit values unless overridden.

Users are often surprised by the behavioral details of ambient values, because MVC doesn't seem to follow its own rules. For historical and compatibility reasons, certain route values such as `action`, `controller`, `page`, and `handler` have their own special-case behavior.

The equivalent functionality provided by `LinkGenerator.GetPathByAction` and `LinkGenerator.GetPathByPage` duplicates these anomalies of `IUrlHelper` for compatibility.

### URL generation process

Once the set of candidate endpoints are found, the URL generation algorithm:

* Processes the endpoints iteratively.
* Returns the first successful result.

The first step in this process is called **route value invalidation**. Route value invalidation is the process by which routing decides which route values from the ambient values should be used and which should be ignored. Each ambient value is considered and either combined with the explicit values, or ignored.

The best way to think about the role of ambient values is that they attempt to save application developers typing, in some common cases. Traditionally, the scenarios where ambient values are helpful are related to MVC:

* When linking to another action in the same controller, the controller name doesn't need to be specified.
* When linking to another controller in the same area, the area name doesn't need to be specified.
* When linking to the same action method, route values don't need to be specified.
* When linking to another part of the app, you don't want to carry over route values that have no meaning in that part of the app.

Calls to `LinkGenerator` or `IUrlHelper` that return `null` are usually caused by not understanding route value invalidation. Troubleshoot route value invalidation by explicitly specifying more of the route values to see if that solves the problem.

Route value invalidation works on the assumption that the app's URL scheme is hierarchical, with a hierarchy formed from left-to-right. Consider the basic controller route template `{controller}/{action}/{id?}` to get an intuitive sense of how this works in practice. A **change** to a value **invalidates** all of the route values that appear to the right. This reflects the assumption about hierarchy. If the app has an ambient value for `id`, and the operation specifies a different value for the `controller`:

* `id` won't be reused because `{controller}` is to the left of `{id?}`.

Some examples demonstrating this principle:

* If the explicit values contain a value for `id`, the ambient value for `id` is ignored. The ambient values for `controller` and `action` can be used.
* If the explicit values contain a value for `action`, any ambient value for `action` is ignored. The ambient values for `controller` can be used. If the explicit value for `action` is different from the ambient value for `action`, the `id` value won't be used. If the explicit value for `action` is the same as the ambient value for `action`, the `id` value can be used.
* If the explicit values contain a value for `controller`, any ambient value for `controller` is ignored. If the explicit value for `controller` is different from the ambient value for `controller`, the `action` and `id` values won't be used. If the explicit value for `controller` is the same as the ambient value for `controller`, the `action` and `id` values can be used.

This process is further complicated by the existence of attribute routes and dedicated conventional routes. Controller conventional routes such as `{controller}/{action}/{id?}` specify a hierarchy using route parameters. For [dedicated conventional routes](xref:mvc/controllers/routing#dcr) and [attribute routes](xref:mvc/controllers/routing#ar) to controllers and Razor Pages:

* There is a hierarchy of route values.
* They don't appear in the template.

For these cases, URL generation defines the **required values** concept. Endpoints created by controllers and Razor Pages have required values specified that allow route value invalidation to work.

The route value invalidation algorithm in detail:

* The required value names are combined with the route parameters, then processed from left-to-right.
* For each parameter, the ambient value and explicit value are compared:
  * If the ambient value and explicit value are the same, the process continues.
  * If the ambient value is present and the explicit value isn't, the ambient value is used when generating the URL.
  * If the ambient value isn't present and the explicit value is, reject the ambient value and all subsequent ambient values.
  * If the ambient value and the explicit value are present, and the two values are different, reject the ambient value and all subsequent ambient values.

At this point, the URL generation operation is ready to evaluate route constraints. The set of accepted values is combined with the parameter default values, which is provided to constraints. If the constraints all pass, the operation continues.

Next, the **accepted values** can be used to expand the route template. The route template is processed:

* From left-to-right.
* Each parameter has its accepted value substituted.
* With the following special cases:
  * If the accepted values is missing a value and the parameter has a default value, the default value is used.
  * If the accepted values is missing a value and the parameter is optional, processing continues.
  * If any route parameter to the right of a missing optional parameter has a value, the operation fails.
  * <!-- review default-valued parameters optional parameters --> Contiguous default-valued parameters and optional parameters are collapsed where possible.

Values explicitly provided that don't match a segment of the route are added to the query string. The following table shows the result when using the route template `{controller}/{action}/{id?}`.

| Ambient Values                     | Explicit Values                        | Result                  |
|------------------------------------|----------------------------------------|-------------------------|
| controller = "Home"                | action = "About"                       | `/Home/About`           |
| controller = "Home"                | controller = "Order", action = "About" | `/Order/About`          |
| controller = "Home", color = "Red" | action = "About"                       | `/Home/About`           |
| controller = "Home"                | action = "About", color = "Red"        | `/Home/About?color=Red` |

### Problems with route value invalidation

The following code shows an example of a URL generation scheme that's not supported by routing:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Program.cs" id="snippet_RouteValueInvalidation":::

In the preceding code, the `culture` route parameter is used for localization. The desire is to have the `culture` parameter always accepted as an ambient value. However, the `culture` parameter is not accepted as an ambient value because of the way required values work:

* In the `"default"` route template, the `culture` route parameter is to the left of `controller`, so changes to `controller` won't invalidate `culture`.
* In the `"blog"` route template, the `culture` route parameter is considered to be to the right of `controller`, which appears in the required values.

## Parse URL paths with `LinkParser`

The <xref:Microsoft.AspNetCore.Routing.LinkParser> class adds support for parsing a URL path into a set of route values. The <xref:Microsoft.AspNetCore.Routing.LinkParserEndpointNameAddressExtensions.ParsePathByEndpointName%2A> method takes an endpoint name and a URL path, and returns a set of route values extracted from the URL path.

In the following example controller, the `GetProduct` action uses a route template of `api/Products/{id}` and has a <xref:Microsoft.AspNetCore.Mvc.RouteAttribute.Name%2A> of `GetProduct`: 

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Controllers/ProductsController.cs" id="snippet_ClassGet" highlight="2,5":::

In the same controller class, the `AddRelatedProduct` action expects a URL path, `pathToRelatedProduct`, which can be provided as a query-string parameter:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Controllers/ProductsController.cs" id="snippet_AddRelatedProduct":::

In the preceding example, the `AddRelatedProduct` action extracts the `id` route value from the URL path. For example, with a URL path of `/api/Products/1`, the `relatedProductId` value is set to `1`. This approach allows the API's clients to use URL paths when referring to resources, without requiring knowledge of how such a URL is structured.

## Configure endpoint metadata

The following links provide information on how to configure endpoint metadata:

* [Enable Cors with endpoint routing](xref:security/cors#enable-cors-with-endpoint-routing)
* [IAuthorizationPolicyProvider sample](https://github.com/dotnet/AspNetCore/tree/release/3.1/src/Security/samples/CustomPolicyProvider) using a custom `[MinimumAgeAuthorize]` attribute
* [Test authentication with the [Authorize] attribute](xref:security/authentication/identity#test-identity)
* <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A>
* [Selecting the scheme with the [Authorize] attribute](xref:security/authorization/limitingidentitybyscheme#selecting-the-scheme-with-the-authorize-attribute)
* [Apply policies using the [Authorize] attribute](xref:security/authorization/policies#apply-policies-to-mvc-controllers)
* <xref:security/authorization/roles>

<a name="hostmatch"></a>

## Host matching in routes with RequireHost

<xref:Microsoft.AspNetCore.Builder.RoutingEndpointConventionBuilderExtensions.RequireHost%2A> applies a constraint to the route which requires the specified host. The `RequireHost` or [[Host]](xref:Microsoft.AspNetCore.Routing.HostAttribute) parameter can be a:

* Host: `www.domain.com`, matches `www.domain.com` with any port.
* Host with wildcard: `*.domain.com`, matches `www.domain.com`, `subdomain.domain.com`, or `www.subdomain.domain.com` on any port.
* Port: `*:5000`, matches port 5000 with any host.
* Host and port: `www.domain.com:5000` or `*.domain.com:5000`, matches host and port.

Multiple parameters can be specified using `RequireHost` or `[Host]`. The constraint  matches hosts valid for any of the parameters. For example, `[Host("domain.com", "*.domain.com")]` matches `domain.com`, `www.domain.com`, and `subdomain.domain.com`.

The following code uses `RequireHost` to require the specified host on the route:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Program.cs" id="snippet_RequireHost":::

The following code uses the `[Host]` attribute on the controller to require any of the specified hosts:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Controllers/HostsController.cs" id="snippet_Class":::

When the `[Host]` attribute is applied to both the controller and action method:

* The attribute on the action is used.
* The controller attribute is ignored.

## Performance guidance for routing

When an app has performance problems, routing is often suspected as the problem. The reason routing is suspected is that frameworks like controllers and Razor Pages report the amount of time spent inside the framework in their logging messages. When there's a significant difference between the time reported by controllers and the total time of the request:

* Developers eliminate their app code as the source of the problem.
* It's common to assume routing is the cause.

Routing is performance tested using thousands of endpoints. It's unlikely that a typical app will encounter a performance problem just by being too large. The most common root cause of slow routing performance is usually a badly-behaving custom middleware.

This following code sample demonstrates a basic technique for narrowing down the source of delay:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Program.cs" id="snippet_StopwatchMiddleware":::

To time routing:

* Interleave each middleware with a copy of the timing middleware shown in the preceding code.
* Add a unique identifier to correlate the timing data with the code.

This is a basic way to narrow down the delay when it's significant, for example, more than `10ms`. Subtracting `Time 2` from `Time 1` reports the time spent inside the `UseRouting` middleware.

The following code uses a more compact approach to the preceding timing code:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/AutoStopwatch.cs" id="snippet_Class":::

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Snippets/Program.cs" id="snippet_StopwatchMiddlewareAuto":::

### Potentially expensive routing features

The following list provides some insight into routing features that are relatively expensive compared with basic route templates:

* Regular expressions: It's possible to write regular expressions that are complex, or have long running time with a small amount of input.
* Complex segments (`{x}-{y}-{z}`): 
  * Are significantly more expensive than parsing a regular URL path segment.
  * Result in many more substrings being allocated.
* Synchronous data access: Many complex apps have database access as part of their routing. Use extensibility points such as <xref:Microsoft.AspNetCore.Routing.MatcherPolicy> and <xref:Microsoft.AspNetCore.Routing.EndpointSelectorContext>, which are asynchronous.

<!-- TODO: This needs a better edit -->
### Guidance for large route tables

By default ASP.NET Core uses a routing algorithm that trades memory for CPU time. This has the nice effect that route matching time is dependent only on the length of the path to match and not the number of routes. However, this approach can be potentially problematic in some cases, when the app has a large number of routes (in the thousands) and there is a high amount of variable prefixes in the routes. For example, if the routes have parameters in early segments of the route, like `{parameter}/some/literal`.

It is unlikely for an app to run into a situation where this is a problem unless:

* There are a high number of routes in the app using this pattern.
* There is a large number of routes in in the app.

#### How to determine if an app is running into the large route table problem

* There are two symptoms to look for:
  * The app is slow to start on the first request.
    * Note that this is required but not sufficient. There are many other non-route problems than can cause slow app startup. Check for the condition below to accurately determine the app is running into this situation.
  * The app consumes a lot of memory during startup and a memory dump shows a large number of `Microsoft.AspNetCore.Routing.Matching.DfaNode` instances.

#### How to address this issue

There are several techniques and optimizations can be applied to routes that will largely improve this scenario:
* Apply route constraints to your parameters, for example `{parameter:int}`, `{parameter:guid}`, `{parameter:regex(\\d+)}`, etc. where possible.
  * This allows the routing algorithm to internally optimize the structures used for matching and drastically reduce the memory used.
  * In the vast majority of cases this will suffice to get back to an acceptable behavior.
* Change the routes to move parameters to later segments in the template.
  * This reduces the number of possible "paths" to match an endpoint given a path.
* Use a dynamic route and perform the mapping to a controller/page dynamically.
  * This can be achieved using `MapDynamicControllerRoute` and `MapDynamicPageRoute`.

## Guidance for library authors

This section contains guidance for library authors building on top of routing. These details are intended to ensure that app developers have a good experience using libraries and frameworks that extend routing.

### Define endpoints

To create a framework that uses routing for URL matching, start by defining a user experience that builds on top of <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A>.

**DO** build on top of <xref:Microsoft.AspNetCore.Routing.IEndpointRouteBuilder>. This allows users to compose your framework with other ASP.NET Core features without confusion. Every ASP.NET Core template includes routing. Assume routing is present and familiar for users.

```csharp
// Your framework
app.MapMyFramework(...);

app.MapHealthChecks("/healthz");
```

**DO** return a sealed concrete type from a call to `MapMyFramework(...)` that implements <xref:Microsoft.AspNetCore.Builder.IEndpointConventionBuilder>. Most framework `Map...` methods follow this pattern. The `IEndpointConventionBuilder` interface:

* Allows for metadata to be composed.
* Is targeted by a variety of extension methods.

Declaring your own type allows you to add your own framework-specific functionality to the builder. It's ok to wrap a framework-declared builder and forward calls to it.

```csharp
// Your framework
app.MapMyFramework(...)
    .RequireAuthorization()
    .WithMyFrameworkFeature(awesome: true);

app.MapHealthChecks("/healthz");
```

**CONSIDER** writing your own <xref:Microsoft.AspNetCore.Routing.EndpointDataSource>. `EndpointDataSource` is the low-level primitive for declaring and updating a collection of endpoints. `EndpointDataSource` is a powerful API used by controllers and Razor Pages.

The routing tests have a [basic example](https://github.com/dotnet/AspNetCore/blob/main/src/Http/Routing/test/testassets/RoutingSandbox/Framework/FrameworkEndpointDataSource.cs#L17) of a non-updating data source.

**DO NOT** attempt to register an `EndpointDataSource` by default. Require users to register your framework in <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A>. The philosophy of routing is that nothing is included by default, and that `UseEndpoints` is the place to register endpoints.

### Creating routing-integrated middleware

**CONSIDER** defining metadata types as an interface.

**DO** make it possible to use metadata types as an attribute on classes and methods.

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Routing/ICoolMetadata.cs" id="snippet_InterfaceAttribute":::

Frameworks like controllers and Razor Pages support applying metadata attributes to types and methods. If you declare metadata types:

* Make them accessible as [attributes](/dotnet/csharp/programming-guide/concepts/attributes/).
* Most users are familiar with applying attributes.

Declaring a metadata type as an interface adds another layer of flexibility:

* Interfaces are composable.
* Developers can declare their own types that combine multiple policies.

**DO** make it possible to override metadata, as shown in the following example:

:::code language="csharp" source="routing/samples/6.x/RoutingSample/Routing/ICoolMetadata.cs" id="snippet_SuppressController":::

The best way to follow these guidelines is to avoid defining **marker metadata**:

* Don't just look for the presence of a metadata type.
* Define a property on the metadata and check the property.

The metadata collection is ordered and supports overriding by priority. In the case of controllers, metadata on the action method is most specific.

**DO** make middleware useful with and without routing:

```csharp
app.UseAuthorization(new AuthorizationPolicy() { ... });

// Your framework
app.MapMyFramework(...).RequireAuthorization();
```

As an example of this guideline, consider the `UseAuthorization` middleware. The authorization middleware allows you to pass in a fallback policy. <!-- shown where?  (shown here) --> The fallback policy, if specified, applies to both:

* Endpoints without a specified policy.
* Requests that don't match an endpoint.

This makes the authorization middleware useful outside of the context of routing. The authorization middleware can be used for traditional middleware programming.

[!INCLUDE[](~/includes/dbg-route.md)]

## Additional resources

* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/routing/samples) ([how to download](xref:index#how-to-download-a-sample))

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Routing is responsible for matching incoming HTTP requests and dispatching those requests to the app's executable endpoints. [Endpoints](#endpoint) are the app's units of executable request-handling code. Endpoints are defined in the app and configured when the app starts. The endpoint matching process can extract values from the request's URL and provide those values for request processing. Using endpoint information from the app, routing is also able to generate URLs that map to endpoints.

Apps can configure routing using:

* Controllers
* Razor Pages
* SignalR
* gRPC Services
* Endpoint-enabled [middleware](xref:fundamentals/middleware/index) such as [Health Checks](xref:host-and-deploy/health-checks).
* Delegates and lambdas registered with routing.

This document covers low-level details of ASP.NET Core routing. For information on configuring routing:

* For controllers, see <xref:mvc/controllers/routing>.
* For Razor Pages conventions, see <xref:razor-pages/razor-pages-conventions>.

The endpoint routing system described in this document applies to ASP.NET Core 3.0 and later. For information on the previous routing system based on <xref:Microsoft.AspNetCore.Routing.IRouter>, select the ASP.NET Core 2.1 version using one of the following approaches:

* The version selector for a previous version.
* Select [ASP.NET Core 2.1 routing](?preserve-view=true&view=aspnetcore-2.1).

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/routing/samples/3.x) ([how to download](xref:index#how-to-download-a-sample))

The download samples for this document are enabled by a specific `Startup` class. To run a specific sample, modify `Program.cs` to call the desired `Startup` class.

## Routing basics

All ASP.NET Core templates include routing in the generated code. Routing is registered in the [middleware](xref:fundamentals/middleware/index) pipeline in `Startup.Configure`.

The following code shows a basic example of routing:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/Startup.cs" id="snippet" highlight="8,10":::

Routing uses a pair of middleware, registered by <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A> and <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A>:

* `UseRouting` adds route matching to the middleware pipeline. This middleware looks at the set of endpoints defined in the app, and selects the [best match](#urlm) based on the request.
* `UseEndpoints` adds endpoint execution to the middleware pipeline. It runs the delegate associated with the selected endpoint.

The preceding example includes a single *route to code* endpoint using the [MapGet](xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapGet%2A) method:

* When an HTTP `GET` request is sent to the root URL `/`:
  * The request delegate shown executes.
  * `Hello World!` is written to the HTTP response. By default, the root URL `/` is `https://localhost:5001/`.
* If the request method is not `GET` or the root URL is not `/`, no route matches and an HTTP 404 is returned.

### Endpoint

<a name="endpoint"></a>

The `MapGet` method is used to define an **endpoint**. An endpoint is something that can be:

* Selected, by matching the URL and HTTP method.
* Executed, by running the delegate.

Endpoints that can be matched and executed by the app are configured in `UseEndpoints`. For example, <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapGet%2A>, <xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions.MapPost%2A>, and [similar methods](xref:Microsoft.AspNetCore.Builder.EndpointRouteBuilderExtensions) connect request delegates to the routing system. Additional methods can be used to connect ASP.NET Core framework features to the routing system:

* [MapRazorPages for Razor Pages](xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapRazorPages%2A)
* [MapControllers for controllers](xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllers%2A)
* [MapHub\<THub> for SignalR](xref:Microsoft.AspNetCore.SignalR.HubRouteBuilder.MapHub%2A) 
* [MapGrpcService\<TService> for gRPC](xref:grpc/aspnetcore)

The following example shows routing with a more sophisticated route template:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/RouteTemplateStartup.cs" id="snippet":::

The string `/hello/{name:alpha}` is a **route template**. It is used to configure how the endpoint is matched. In this case, the template matches:

* A URL like `/hello/Ryan`
* Any URL path that begins with `/hello/` followed by a sequence of alphabetic characters.  `:alpha` applies a route constraint that matches only alphabetic characters. [Route constraints](#route-constraint-reference) are explained later in this document.

The second segment of the URL path, `{name:alpha}`:

* Is bound to the `name` parameter.
* Is captured and stored in [HttpRequest.RouteValues](xref:Microsoft.AspNetCore.Http.HttpRequest.RouteValues%2A).

The endpoint routing system described in this document is new as of ASP.NET Core 3.0. However, all versions of ASP.NET Core support the same set of route template features and route constraints.

The following example shows routing with [health checks](xref:host-and-deploy/health-checks) and authorization:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/AuthorizationStartup.cs" id="snippet":::

[!INCLUDE[request localized comments](~/includes/code-comments-loc.md)]

The preceding example demonstrates how:

* The authorization middleware can be used with routing.
* Endpoints can be used to configure authorization behavior.

The <xref:Microsoft.AspNetCore.Builder.HealthCheckEndpointRouteBuilderExtensions.MapHealthChecks%2A> call adds a health check endpoint. Chaining <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A> on to this call attaches an authorization policy to the endpoint.

Calling <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A> and <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A> adds the authentication and authorization middleware. These middleware are placed between <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A> and `UseEndpoints` so that they can:

* See which endpoint was selected by `UseRouting`.
* Apply an authorization policy before <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A> dispatches to the endpoint.

<a name="metadata"></a>

### Endpoint metadata

In the preceding example, there are two endpoints, but only the health check endpoint has an authorization policy attached. If the request matches the health check endpoint, `/healthz`, an authorization check is performed. This demonstrates that endpoints can have extra data attached to them. This extra data is called endpoint **metadata**:

* The metadata can be processed by routing-aware middleware.
* The metadata can be of any .NET type.

## Routing concepts

The routing system builds on top of the middleware pipeline by adding the powerful **endpoint** concept. Endpoints represent units of the app's functionality that are distinct from each other in terms of routing, authorization, and any number of ASP.NET Core's systems.

<a name="endpoint"></a>

### ASP.NET Core endpoint definition

An ASP.NET Core endpoint is:

* Executable: Has a <xref:Microsoft.AspNetCore.Http.Endpoint.RequestDelegate>.
* Extensible: Has a [Metadata](xref:Microsoft.AspNetCore.Http.Endpoint.Metadata%2A) collection.
* Selectable: Optionally, has [routing information](xref:Microsoft.AspNetCore.Routing.RouteEndpoint.RoutePattern%2A).
* Enumerable: The collection of endpoints can be listed by retrieving the <xref:Microsoft.AspNetCore.Routing.EndpointDataSource> from [DI](xref:fundamentals/dependency-injection).

The following code shows how to retrieve and inspect the endpoint matching the current request:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/EndpointInspectorStartup.cs" id="snippet":::

The endpoint, if selected, can be retrieved from the `HttpContext`. Its properties can be inspected. Endpoint objects are immutable and cannot be modified after creation. The most common type of endpoint is a <xref:Microsoft.AspNetCore.Routing.RouteEndpoint>. `RouteEndpoint` includes information that allows it to be selected by the routing system.

In the preceding code, [app.Use](xref:Microsoft.AspNetCore.Builder.UseExtensions.Use%2A) configures an in-line [middleware](xref:fundamentals/middleware/index).

<a name="mt"></a>

The following code shows that, depending on where `app.Use` is called in the pipeline, there may not be an endpoint:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/MiddlewareFlowStartup.cs" id="snippet":::

This preceding sample adds `Console.WriteLine` statements that display whether or not an endpoint has been selected. For clarity, the sample assigns a display name to the provided `/` endpoint.

Running this code with a URL of `/` displays:

```txt
1. Endpoint: (null)
2. Endpoint: Hello
3. Endpoint: Hello
```

Running this code with any other URL displays:

```txt
1. Endpoint: (null)
2. Endpoint: (null)
4. Endpoint: (null)
```

This output demonstrates that:

* The endpoint is always null before `UseRouting` is called.
* If a match is found, the endpoint is non-null between `UseRouting` and <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A>.
* The `UseEndpoints` middleware is **terminal** when a match is found. [Terminal middleware](#tm) is defined later in this document.
* The middleware after `UseEndpoints` execute only when no match is found.

The `UseRouting` middleware uses the [SetEndpoint](xref:Microsoft.AspNetCore.Http.EndpointHttpContextExtensions.SetEndpoint%2A) method to attach the endpoint to the current context. It's possible to replace the `UseRouting` middleware with custom logic and still get the benefits of using endpoints. Endpoints are a low-level primitive like middleware, and aren't coupled to the routing implementation. Most apps don't need to replace `UseRouting` with custom logic.

The `UseEndpoints` middleware is designed to be used in tandem with the `UseRouting` middleware. The core logic to execute an endpoint isn't complicated. Use <xref:Microsoft.AspNetCore.Http.EndpointHttpContextExtensions.GetEndpoint%2A> to retrieve the endpoint, and then invoke its <xref:Microsoft.AspNetCore.Http.Endpoint.RequestDelegate> property.

The following code demonstrates how middleware can influence or react to routing:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/IntegratedMiddlewareStartup.cs" id="snippet":::

The preceding example demonstrates two important concepts:

* Middleware can run before `UseRouting` to modify the data that routing operates upon.
  * Usually middleware that appears before routing modifies some property of the request, such as <xref:Microsoft.AspNetCore.Builder.RewriteBuilderExtensions.UseRewriter%2A>, <xref:Microsoft.AspNetCore.Builder.HttpMethodOverrideExtensions.UseHttpMethodOverride%2A>, or <xref:Microsoft.AspNetCore.Builder.UsePathBaseExtensions.UsePathBase%2A>.
* Middleware can run between `UseRouting` and <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A> to process the results of routing before the endpoint is executed.
  * Middleware that runs between `UseRouting` and `UseEndpoints`:
    * Usually inspects metadata to understand the endpoints.
    * Often makes security decisions, as done by `UseAuthorization` and `UseCors`.
  * The combination of middleware and metadata allows configuring policies per-endpoint.

The preceding code shows an example of a custom middleware that supports per-endpoint policies. The middleware writes an *audit log* of access to sensitive data to the console. The middleware can be configured to *audit* an endpoint with the `AuditPolicyAttribute` metadata. This sample demonstrates an *opt-in* pattern where only endpoints that are marked as sensitive are audited. It's possible to define this logic in reverse, auditing everything that isn't marked as safe, for example. The endpoint metadata system is flexible. This logic could be designed in whatever way suits the use case.

The preceding sample code is intended to demonstrate the basic concepts of endpoints. **The sample is not intended for production use**. A more complete version of an *audit log* middleware would:

* Log to a file or database.
* Include details such as the user, IP address, name of the sensitive endpoint, and more.

The audit policy metadata `AuditPolicyAttribute` is defined as an `Attribute` for easier use with class-based frameworks such as controllers and SignalR. When using *route to code*:

* Metadata is attached with a builder API.
* Class-based frameworks include all attributes on the corresponding method and class when creating endpoints.

The best practices for metadata types are to define them either as interfaces or attributes. Interfaces and attributes allow code reuse. The metadata system is flexible and doesn't impose any limitations.

<a name="tm"></a>

### Comparing a terminal middleware and routing

The following code sample contrasts using middleware with using routing:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/TerminalMiddlewareStartup.cs" id="snippet":::

The style of middleware shown with `Approach 1:` is **terminal middleware**. It's called terminal middleware because it does a matching operation:

* The matching operation in the preceding sample is `Path == "/"` for the middleware and `Path == "/Movie"` for routing.
* When a match is successful, it executes some functionality and returns, rather than invoking the `next` middleware.

It's called terminal middleware because it terminates the search, executes some functionality, and then returns.

Comparing a terminal middleware and routing:

* Both approaches allow terminating the processing pipeline:
  * Middleware terminates the pipeline by returning rather than invoking `next`.
  * Endpoints are always terminal.
* Terminal middleware allows positioning the middleware at an arbitrary place in the pipeline:
  * Endpoints execute at the position of <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A>.
* Terminal middleware allows arbitrary code to determine when the middleware matches:
  * Custom route matching code can be verbose and difficult to write correctly.
  * Routing provides straightforward solutions for typical apps. Most apps don't require custom route matching code.
* Endpoints interface with middleware such as `UseAuthorization` and `UseCors`.
  * Using a terminal middleware with `UseAuthorization` or `UseCors` requires manual interfacing with the authorization system.

An [endpoint](#endpoint) defines both:

* A delegate to process requests.
* A collection of arbitrary metadata. The metadata is used to implement cross-cutting concerns based on policies and configuration attached to each endpoint.

Terminal middleware can be an effective tool, but can require:

* A significant amount of coding and testing.
* Manual integration with other systems to achieve the desired level of flexibility.

Consider integrating with routing before writing a terminal middleware.

Existing terminal middleware that integrates with [Map](xref:fundamentals/middleware/index#branch-the-middleware-pipeline) or <xref:Microsoft.AspNetCore.Builder.MapWhenExtensions.MapWhen%2A> can usually be turned into a routing aware endpoint. [MapHealthChecks](https://github.com/dotnet/AspNetCore/blob/main/src/Middleware/HealthChecks/src/Builder/HealthCheckEndpointRouteBuilderExtensions.cs#L16) demonstrates the pattern for router-ware:

* Write an extension method on <xref:Microsoft.AspNetCore.Routing.IEndpointRouteBuilder>.
* Create a nested middleware pipeline using <xref:Microsoft.AspNetCore.Routing.IEndpointRouteBuilder.CreateApplicationBuilder%2A>.
* Attach the middleware to the new pipeline. In this case, <xref:Microsoft.AspNetCore.Builder.HealthCheckApplicationBuilderExtensions.UseHealthChecks%2A>.
* <xref:Microsoft.AspNetCore.Builder.IApplicationBuilder.Build%2A> the middleware pipeline into a <xref:Microsoft.AspNetCore.Http.RequestDelegate>.
* Call `Map` and provide the new middleware pipeline.
* Return the builder object provided by `Map` from the extension method.

The following code shows use of [MapHealthChecks](xref:host-and-deploy/health-checks):

:::code language="csharp" source="routing/samples/3.x/RoutingSample/AuthorizationStartup.cs" id="snippet":::

The preceding sample shows why returning the builder object is important. Returning the builder object allows the app developer to configure policies such as authorization for the endpoint. In this example, the health checks middleware has no direct integration with the authorization system.

The metadata system was created in response to the problems encountered by extensibility authors using terminal middleware. It's problematic for each middleware to implement its own integration with the authorization system.

<a name="urlm"></a>

### URL matching

* Is the process by which routing matches an incoming request to an [endpoint](#endpoint).
* Is based on data in the URL path and headers.
* Can be extended to consider any data in the request.

When a routing middleware executes, it sets an `Endpoint` and route values to a [request feature](xref:fundamentals/request-features) on the <xref:Microsoft.AspNetCore.Http.HttpContext> from the current request:

* Calling [HttpContext.GetEndpoint](xref:Microsoft.AspNetCore.Http.EndpointHttpContextExtensions.GetEndpoint%2A) gets the endpoint.
* `HttpRequest.RouteValues` gets the collection of route values.

[Middleware](xref:fundamentals/middleware/index) running after the routing middleware can inspect the endpoint and take action. For example, an authorization middleware can interrogate the endpoint's metadata collection for an authorization policy. After all of the middleware in the request processing pipeline is executed, the selected endpoint's delegate is invoked.

The routing system in endpoint routing is responsible for all dispatching decisions. Because the middleware applies policies based on the selected endpoint, it's important that:

* Any decision that can affect dispatching or the application of security policies is made inside the routing system.

> [!WARNING]
> For backwards-compatibility, when a Controller or Razor Pages endpoint delegate is executed, the properties of [RouteContext.RouteData](xref:Microsoft.AspNetCore.Routing.RouteContext.RouteData) are set to appropriate values based on the request processing performed thus far.
>
> The `RouteContext` type will be marked obsolete in a future release:
>
> * Migrate `RouteData.Values` to `HttpRequest.RouteValues`.
> * Migrate `RouteData.DataTokens` to retrieve [IDataTokensMetadata](xref:Microsoft.AspNetCore.Routing.IDataTokensMetadata) from the endpoint metadata.

URL matching operates in a configurable set of phases. In each phase, the output is a set of matches. The set of matches can be narrowed down further by the next phase. The routing implementation does not guarantee a processing order for matching endpoints. **All** possible matches are processed at once. The URL matching phases occur in the following order. ASP.NET Core:

1. Processes the URL path against the set of endpoints and their route templates, collecting **all** of the matches.
1. Takes the preceding list and removes matches that fail with route constraints applied.
1. Takes the preceding list and removes matches that fail the set of [MatcherPolicy](xref:Microsoft.AspNetCore.Routing.MatcherPolicy) instances.
1. Uses the [EndpointSelector](xref:Microsoft.AspNetCore.Routing.Matching.EndpointSelector) to make a final decision from the preceding list.

The list of endpoints is prioritized according to:

* The [RouteEndpoint.Order](xref:Microsoft.AspNetCore.Routing.RouteEndpoint.Order%2A)
* The [route template precedence](#rtp)

All matching endpoints are processed in each phase until the <xref:Microsoft.AspNetCore.Routing.Matching.EndpointSelector> is reached. The `EndpointSelector` is the final phase. It chooses the highest priority endpoint from the matches as the best match. If there are other matches with the same priority as the best match, an ambiguous match exception is thrown.

The route precedence is computed based on a **more specific** route template being given a higher priority. For example, consider the templates `/hello` and `/{message}`:

* Both match the URL path `/hello`.
* `/hello`  is more specific and therefore higher priority.

In general, route precedence does a good job of choosing the best match for the kinds of URL schemes used in practice. Use <xref:Microsoft.AspNetCore.Routing.RouteEndpoint.Order> only when necessary to avoid an ambiguity.

Due to the kinds of extensibility provided by routing, it isn't possible for the routing system to compute ahead of time the ambiguous routes. Consider an example such as the route templates `/{message:alpha}` and `/{message:int}`:

* The `alpha` constraint matches only alphabetic characters.
* The `int` constraint matches only numbers.
* These templates have the same route precedence, but there's no single URL they both match.
* If the routing system reported an ambiguity error at startup, it would block this valid use case.

> [!WARNING]
>
> The order of operations inside <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A> doesn't influence the behavior of routing, with one exception. <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A> and <xref:Microsoft.AspNetCore.Builder.MvcAreaRouteBuilderExtensions.MapAreaRoute%2A> automatically assign an order value to their endpoints based on the order they are invoked. This simulates long-time behavior of controllers without the routing system providing the same guarantees as older routing implementations.
>
> In the legacy implementation of routing, it's possible to implement routing extensibility that has a dependency on the order in which routes are processed. Endpoint routing in ASP.NET Core 3.0 and later:
> 
> * Doesn't have a concept of routes.
> * Doesn't provide ordering guarantees. All endpoints are processed at once.

<a name="rtp"></a>

### Route template precedence and endpoint selection order

[Route template precedence](https://github.com/dotnet/aspnetcore/blob/main/src/Http/Routing/src/Template/RoutePrecedence.cs#L16) is a system that assigns each route template a value based on how specific it is. Route template precedence:

* Avoids the need to adjust the order of endpoints in common cases.
* Attempts to match the common-sense expectations of routing behavior.

For example, consider templates `/Products/List` and `/Products/{id}`. It would be reasonable to assume that `/Products/List` is a better match than `/Products/{id}` for the URL path `/Products/List`. This works because the literal segment `/List` is considered to have better precedence than the parameter segment `/{id}`.

The details of how precedence works are coupled to how route templates are defined:

* Templates with more segments are considered more specific.
* A segment with literal text is considered more specific than a parameter segment.
* A parameter segment with a constraint is considered more specific than one without.
* A complex segment is considered as specific as a parameter segment with a constraint.
* Catch-all parameters are the least specific. See **catch-all** in the [Route template reference](#rtr) for important information on catch-all routes.

See the [source code on GitHub](https://github.com/dotnet/aspnetcore/blob/main/src/Http/Routing/src/Template/RoutePrecedence.cs#L189) for a reference of exact values.

<a name="lg"></a>

### URL generation concepts

URL generation:

* Is the process by which routing can create a URL path based on a set of route values.
* Allows for a logical separation between endpoints and the URLs that access them.

Endpoint routing includes the <xref:Microsoft.AspNetCore.Routing.LinkGenerator> API. `LinkGenerator` is a singleton service available from [DI](xref:fundamentals/dependency-injection). The `LinkGenerator` API can be used outside of the context of an executing request. [Mvc.IUrlHelper](xref:Microsoft.AspNetCore.Mvc.IUrlHelper) and scenarios that rely on <xref:Microsoft.AspNetCore.Mvc.IUrlHelper>, such as [Tag Helpers](xref:mvc/views/tag-helpers/intro), HTML Helpers, and [Action Results](xref:mvc/controllers/actions), use the `LinkGenerator` API internally to provide link generating capabilities.

The link generator is backed by the concept of an **address** and **address schemes**. An address scheme is a way of determining the endpoints that should be considered for link generation. For example, the route name and route values scenarios many users are familiar with from controllers and Razor Pages are implemented as an address scheme.

The link generator can link to controllers and Razor Pages via the following extension methods:

* <xref:Microsoft.AspNetCore.Routing.ControllerLinkGeneratorExtensions.GetPathByAction%2A>
* <xref:Microsoft.AspNetCore.Routing.ControllerLinkGeneratorExtensions.GetUriByAction%2A>
* <xref:Microsoft.AspNetCore.Routing.PageLinkGeneratorExtensions.GetPathByPage%2A>
* <xref:Microsoft.AspNetCore.Routing.PageLinkGeneratorExtensions.GetUriByPage%2A>

Overloads of these methods accept arguments that include the `HttpContext`. These methods are functionally equivalent to [Url.Action](xref:Microsoft.AspNetCore.Mvc.Routing.UrlHelper.Action%2A) and [Url.Page](xref:Microsoft.AspNetCore.Mvc.UrlHelperExtensions.Page%2A), but offer additional flexibility and options.

The `GetPath*` methods are most similar to `Url.Action` and `Url.Page`, in that they generate a URI containing an absolute path. The `GetUri*` methods always generate an absolute URI containing a scheme and host. The methods that accept an `HttpContext` generate a URI in the context of the executing request. The [ambient](#ambient) route values, URL base path, scheme, and host from the executing request are used unless overridden.

<xref:Microsoft.AspNetCore.Routing.LinkGenerator> is called with an address. Generating a URI occurs in two steps:

1. An address is bound to a list of endpoints that match the address.
1. Each endpoint's <xref:Microsoft.AspNetCore.Routing.RouteEndpoint.RoutePattern> is evaluated until a route pattern that matches the supplied values is found. The resulting output is combined with the other URI parts supplied to the link generator and returned.

The methods provided by <xref:Microsoft.AspNetCore.Routing.LinkGenerator> support standard link generation capabilities for any type of address. The most convenient way to use the link generator is through extension methods that perform operations for a specific address type:

| Extension Method                                                      | Description                                                         |
|-----------------------------------------------------------------------|---------------------------------------------------------------------|
| <xref:Microsoft.AspNetCore.Routing.LinkGenerator.GetPathByAddress%2A> | Generates a URI with an absolute path based on the provided values. |
| <xref:Microsoft.AspNetCore.Routing.LinkGenerator.GetUriByAddress%2A>  | Generates an absolute URI based on the provided values.             |

> [!WARNING]
> Pay attention to the following implications of calling <xref:Microsoft.AspNetCore.Routing.LinkGenerator> methods:
>
> * Use `GetUri*` extension methods with caution in an app configuration that doesn't validate the `Host` header of incoming requests. If the `Host` header of incoming requests isn't validated, untrusted request input can be sent back to the client in URIs in a view or page. We recommend that all production apps configure their server to validate the `Host` header against known valid values.
>
> * Use <xref:Microsoft.AspNetCore.Routing.LinkGenerator> with caution in middleware in combination with `Map` or `MapWhen`. `Map*` changes the base path of the executing request, which affects the output of link generation. All of the <xref:Microsoft.AspNetCore.Routing.LinkGenerator> APIs allow specifying a base path. Specify an empty base path to undo the `Map*` affect on link generation.

### Middleware example

In the following example, a middleware uses the <xref:Microsoft.AspNetCore.Routing.LinkGenerator> API to create a link to an action method that lists store products. Using the link generator by injecting it into a class and calling `GenerateLink` is available to any class in an app:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/Middleware/ProductsLinkMiddleware.cs" id="snippet":::

<a name="rtr"></a>

## Route template reference

Tokens within `{}` define route parameters that are bound if the route is matched. More than one route parameter can be defined in a route segment, but route parameters  must be separated by a literal value. For example, `{controller=Home}{action=Index}` isn't a valid route, since there's no literal value between `{controller}` and `{action}`.  Route parameters must have a name and may have additional attributes specified.

Literal text other than route parameters (for example, `{id}`) and the path separator `/` must match the text in the URL. Text matching is case-insensitive and based on the decoded representation of the URL's path. To match a literal route parameter delimiter `{` or `}`, escape the delimiter by repeating the character. For example `{{` or `}}`.

Asterisk `*` or double asterisk `**`:

* Can be used as a prefix to a route parameter to bind to the rest of the URI.
* Are called a **catch-all** parameters. For example, `blog/{**slug}`:
  * Matches any URI that starts with `/blog` and has any value following it.
  * The value following `/blog` is assigned to the [slug](https://developer.mozilla.org/docs/Glossary/Slug) route value.

[!INCLUDE[](~/includes/catchall.md)]

Catch-all parameters can also match the empty string.

The catch-all parameter escapes the appropriate characters when the route is used to generate a URL, including path separator `/` characters. For example, the route `foo/{*path}` with route values `{ path = "my/path" }` generates `foo/my%2Fpath`. Note the escaped forward slash. To round-trip path separator characters, use the `**` route parameter prefix. The route `foo/{**path}` with `{ path = "my/path" }` generates `foo/my/path`.

URL patterns that attempt to capture a file name with an optional file extension have additional considerations. For example, consider the template `files/{filename}.{ext?}`. When values for both `filename` and `ext` exist, both values are populated. If only a value for `filename` exists in the URL, the route matches because the trailing `.` is  optional. The following URLs match this route:

* `/files/myFile.txt`
* `/files/myFile`

Route parameters may have **default values** designated by specifying the default value after the parameter name separated by an equals sign (`=`). For example, `{controller=Home}` defines `Home` as the default value for `controller`. The default value is used if no value is present in the URL for the parameter. Route parameters are made optional by appending a question mark (`?`) to the end of the parameter name. For example, `id?`. The difference between optional values and default route parameters is:

* A route parameter with a default value always produces a value.
* An optional parameter has a value only when a value is provided by the request URL.

Route parameters may have constraints that must match the route value bound from the URL. Adding `:` and constraint name after the route parameter name specifies an inline constraint on a route parameter. If the constraint requires arguments, they're enclosed in parentheses `(...)` after the constraint name. Multiple *inline constraints* can be specified by appending another `:` and constraint name.

The constraint name and arguments are passed to the <xref:Microsoft.AspNetCore.Routing.IInlineConstraintResolver> service to create an instance of <xref:Microsoft.AspNetCore.Routing.IRouteConstraint> to use in URL processing. For example, the route template `blog/{article:minlength(10)}` specifies a `minlength` constraint with the argument `10`. For more information on route constraints and a list of the constraints provided by the framework, see the [Route constraint reference](#route-constraint-reference) section.

Route parameters may also have parameter transformers. Parameter transformers transform a parameter's value when generating links and matching actions and pages to URLs. Like constraints, parameter transformers can be added inline to a route parameter by adding a `:` and transformer name after the route parameter name. For example, the route template `blog/{article:slugify}` specifies a `slugify` transformer. For more information on parameter transformers, see the [Parameter transformer reference](#parameter-transformer-reference) section.

The following table demonstrates example route templates and their behavior:

| Route Template                           | Example Matching URI    | The request URI&hellip;                                                      |
|------------------------------------------|-------------------------|------------------------------------------------------------------------------|
| `hello`                                  | `/hello`                | Only matches the single path `/hello`.                                       |
| `{Page=Home}`                            | `/`                     | Matches and sets `Page` to `Home`.                                           |
| `{Page=Home}`                            | `/Contact`              | Matches and sets `Page` to `Contact`.                                        |
| `{controller}/{action}/{id?}`            | `/Products/List`        | Maps to the `Products` controller and `List` action.                         |
| `{controller}/{action}/{id?}`            | `/Products/Details/123` | Maps to the `Products` controller and  `Details` action with`id` set to 123. |
| `{controller=Home}/{action=Index}/{id?}` | `/`                     | Maps to the `Home` controller and `Index` method. `id` is ignored.           |
| `{controller=Home}/{action=Index}/{id?}` | `/Products`             | Maps to the `Products` controller and `Index` method. `id` is ignored.       |

Using a template is generally the simplest approach to routing. Constraints and defaults can also be specified outside the route template.

### Complex segments

Complex segments are processed by matching up literal delimiters from right to left in a [non-greedy](#greedy) way. For example, `[Route("/a{b}c{d}")]` is a complex segment.
Complex segments work in a particular way that must be understood to use them successfully. The example in this section demonstrates why complex segments only really work well when the delimiter text doesn't appear inside the parameter values. Using a [regex](/dotnet/standard/base-types/regular-expressions) and then manually extracting the values is needed for more complex cases.

[!INCLUDE[](~/includes/regex.md)]

This is a summary of the steps that routing performs with the template `/a{b}c{d}` and the URL path `/abcd`. The `|` is used to help visualize how the algorithm works:

* The first literal, right to left, is `c`. So `/abcd` is searched from right and finds `/ab|c|d`.
* Everything to the right (`d`) is now matched to the route parameter `{d}`.
* The next literal, right to left, is `a`. So `/ab|c|d` is searched starting where we left off, then `a` is found `/|a|b|c|d`.
* The value to the right (`b`) is now matched to the route parameter `{b}`.
* There is no remaining text and no remaining route template, so this is a match.

Here's an example of a negative case using the same template `/a{b}c{d}` and the URL path `/aabcd`. The `|` is used to help visualize how the algorithm works. This case isn't a match, which is explained by the same algorithm:
* The first literal, right to left, is `c`. So `/aabcd` is searched from right and finds `/aab|c|d`.
* Everything to the right (`d`) is now matched to the route parameter `{d}`.
* The next literal, right to left, is `a`. So `/aab|c|d` is searched starting where we left off, then `a` is found `/a|a|b|c|d`.
* The value to the right (`b`) is now matched to the route parameter `{b}`.
* At this point there is remaining text `a`, but the algorithm has run out of route template to parse, so this is not a match.

Since the matching algorithm is [non-greedy](#greedy):

* It matches the smallest amount of text possible in each step.
* Any case where the delimiter value appears inside the parameter values results in not matching.

Regular expressions provide much more control over their matching behavior.

<a name="greedy"></a>

Greedy matching, also know as [lazy matching](https://wikipedia.org/wiki/Regular_expression#Lazy_matching), matches the largest possible string. Non-greedy matches the smallest possible string.

## Route constraint reference

Route constraints execute when a match has occurred to the incoming URL and the URL path is tokenized into route values. Route constraints generally inspect the route value associated via the route template and make a true or false decision about whether the value is acceptable. Some route constraints use data outside the route value to consider whether the request can be routed. For example, the <xref:Microsoft.AspNetCore.Routing.Constraints.HttpMethodRouteConstraint> can accept or reject a request based on its HTTP verb. Constraints are used in routing requests and link generation.

> [!WARNING]
> Don't use constraints for input validation. If constraints are used for input validation, invalid input results in a `404` Not Found response. Invalid input should produce a `400` Bad Request with an appropriate error message. Route constraints are used to disambiguate similar routes, not to validate the inputs for a particular route.

The following table demonstrates example route constraints and their expected behavior:

| constraint          | Example                                     | Example Matches                        | Notes                                                                                     |
|---------------------|---------------------------------------------|----------------------------------------|-------------------------------------------------------------------------------------------|
| `int`               | `{id:int}`                                  | `123456789`, `-123456789`              | Matches any integer                                                                       |
| `bool`              | `{active:bool}`                             | `true`, `FALSE`                        | Matches `true` or `false`. Case-insensitive                                               |
| `datetime`          | `{dob:datetime}`                            | `2016-12-31`, `2016-12-31 7:32pm`      | Matches a valid `DateTime` value in the invariant culture. See preceding warning.         |
| `decimal`           | `{price:decimal}`                           | `49.99`, `-1,000.01`                   | Matches a valid `decimal` value in the invariant culture. See preceding warning.          |
| `double`            | `{weight:double}`                           | `1.234`, `-1,001.01e8`                 | Matches a valid `double` value in the invariant culture. See preceding warning.           |
| `float`             | `{weight:float}`                            | `1.234`, `-1,001.01e8`                 | Matches a valid `float` value in the invariant culture. See preceding warning.            |
| `guid`              | `{id:guid}`                                 | `CD2C1638-1638-72D5-1638-DEADBEEF1638` | Matches a valid `Guid` value                                                              |
| `long`              | `{ticks:long}`                              | `123456789`, `-123456789`              | Matches a valid `long` value                                                              |
| `minlength(value)`  | `{username:minlength(4)}`                   | `Rick`                                 | String must be at least 4 characters                                                      |
| `maxlength(value)`  | `{filename:maxlength(8)}`                   | `MyFile`                               | String must be no more than 8 characters                                                  |
| `length(length)`    | `{filename:length(12)}`                     | `somefile.txt`                         | String must be exactly 12 characters long                                                 |
| `length(min,max)`   | `{filename:length(8,16)}`                   | `somefile.txt`                         | String must be at least 8 and no more than 16 characters long                             |
| `min(value)`        | `{age:min(18)}`                             | `19`                                   | Integer value must be at least 18                                                         |
| `max(value)`        | `{age:max(120)}`                            | `91`                                   | Integer value must be no more than 120                                                    |
| `range(min,max)`    | `{age:range(18,120)}`                       | `91`                                   | Integer value must be at least 18 but no more than 120                                    |
| `alpha`             | `{name:alpha}`                              | `Rick`                                 | String must consist of one or more alphabetical characters, `a`-`z` and case-insensitive. |
| `regex(expression)` | `{ssn:regex(^\\d{{3}}-\\d{{2}}-\\d{{4}}$)}` | `123-45-6789`                          | String must match the regular expression. See tips about defining a regular expression.   |
| `required`          | `{name:required}`                           | `Rick`                                 | Used to enforce that a non-parameter value is present during URL generation               |

[!INCLUDE[](~/includes/regex.md)]

Multiple, colon delimited constraints can be applied to a single parameter. For example, the following constraint restricts a parameter to an integer value of 1 or greater:

```csharp
[Route("users/{id:int:min(1)}")]
public User GetUserById(int id) { }
```

> [!WARNING]
> Route constraints that verify the URL and are converted to a CLR type always use the invariant culture. For example, conversion to the CLR type `int` or `DateTime`. These constraints assume that the URL is not localizable. The framework-provided route constraints don't modify the values stored in route values. All route values parsed from the URL are stored as strings. For example, the `float` constraint attempts to convert the route value to a float, but the converted value is used only to verify it can be converted to a float.

### Regular expressions in constraints

[!INCLUDE[](~/includes/regex.md)]

Regular expressions can be specified as inline constraints using the `regex(...)` route constraint. Methods in the <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A> family also accept an object literal of constraints. If that form is used, string values are interpreted as regular expressions.

The following code uses an inline regex constraint:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/StartupRegex.cs" id="snippet":::

The following code uses an object literal to specify a regex constraint:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/StartupRegex2.cs" id="snippet":::

The ASP.NET Core framework adds `RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant` to the regular expression constructor. See <xref:System.Text.RegularExpressions.RegexOptions> for a description of these members.

Regular expressions use delimiters and tokens similar to those used by routing and the C# language. Regular expression tokens must be escaped. To use the regular expression `^\d{3}-\d{2}-\d{4}$` in an inline constraint, use one of the following:

* Replace `\` characters provided in the string as `\\` characters in the C# source file in order to escape the `\` string escape character.
* [Verbatim string literals](/dotnet/csharp/language-reference/keywords/string).

To escape routing parameter delimiter characters `{`, `}`, `[`, `]`, double the characters in the expression, for example, `{{`, `}}`, `[[`, `]]`. The following table shows a regular expression and its escaped version:

| Regular expression    | Escaped regular expression     |
| --------------------- | ------------------------------ |
| `^\d{3}-\d{2}-\d{4}$` | `^\\d{{3}}-\\d{{2}}-\\d{{4}}$` |
| `^[a-z]{2}$`          | `^[[a-z]]{{2}}$`               |

Regular expressions used in routing often start with the `^` character and match the starting position of the string. The expressions often end with the `$` character and match the end of the string. The `^` and `$` characters ensure that the regular expression matches the entire route parameter value. Without the `^` and `$` characters, the regular expression matches any substring within the string, which is often undesirable. The following table provides examples and explains why they match or fail to match:

| Expression   | String    | Match | Comment               |
| ------------ | --------- | :---: |  -------------------- |
| `[a-z]{2}`   | hello     | Yes   | Substring matches     |
| `[a-z]{2}`   | 123abc456 | Yes   | Substring matches     |
| `[a-z]{2}`   | mz        | Yes   | Matches expression    |
| `[a-z]{2}`   | MZ        | Yes   | Not case sensitive    |
| `^[a-z]{2}$` | hello     | No    | See `^` and `$` above |
| `^[a-z]{2}$` | 123abc456 | No    | See `^` and `$` above |

For more information on regular expression syntax, see [.NET Framework Regular Expressions](/dotnet/standard/base-types/regular-expression-language-quick-reference).

To constrain a parameter to a known set of possible values, use a regular expression. For example, `{action:regex(^(list|get|create)$)}` only matches the `action` route value to `list`, `get`, or `create`. If passed into the constraints dictionary, the string `^(list|get|create)$` is equivalent. Constraints that are passed in the constraints dictionary that don't match one of the known constraints are also treated as regular expressions. Constraints that are passed  within a template that don't match one of the known constraints are not treated as regular expressions.

### Custom route constraints

Custom route constraints can be created by implementing the <xref:Microsoft.AspNetCore.Routing.IRouteConstraint> interface. The `IRouteConstraint` interface contains <xref:Microsoft.AspNetCore.Routing.IRouteConstraint.Match%2A>, which returns `true` if the constraint is satisfied and `false` otherwise.

Custom route constraints are rarely needed. Before implementing a custom route constraint, consider alternatives, such as model binding.

The ASP.NET Core [Constraints](https://github.com/dotnet/aspnetcore/tree/main/src/Http/Routing/src/Constraints) folder provides good examples of creating a constraints. For example, [GuidRouteConstraint](https://github.com/dotnet/aspnetcore/blob/main/src/Http/Routing/src/Constraints/GuidRouteConstraint.cs#L18).

To use a custom `IRouteConstraint`, the route constraint type must be registered with the app's <xref:Microsoft.AspNetCore.Routing.RouteOptions.ConstraintMap> in the service container. A `ConstraintMap` is a dictionary that maps route constraint keys to `IRouteConstraint` implementations that validate those constraints. An app's `ConstraintMap` can be updated in `Startup.ConfigureServices` either as part of a [services.AddRouting](xref:Microsoft.Extensions.DependencyInjection.RoutingServiceCollectionExtensions.AddRouting%2A) call or by configuring <xref:Microsoft.AspNetCore.Routing.RouteOptions> directly with `services.Configure<RouteOptions>`. For example:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/StartupConstraint.cs" id="snippet":::

The preceding constraint is applied in the following code:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/Controllers/TestController.cs" id="snippet" highlight="6,13":::

[!INCLUDE[](~/includes/MyDisplayRouteInfo.md)]

The implementation of `MyCustomConstraint` prevents `0` being applied to a route parameter:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/StartupConstraint.cs" id="snippet2":::

[!INCLUDE[](~/includes/regex.md)]

The preceding code:

* Prevents `0` in the `{id}` segment of the route.
* Is shown to provide a basic example of implementing a custom constraint. It should not be used in a production app.

The following code is a better approach to preventing an `id` containing a `0` from being processed:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/Controllers/TestController.cs" id="snippet2":::

The preceding code has the following advantages over the `MyCustomConstraint` approach:

* It doesn't require a custom constraint.
* It returns a more descriptive error when the route parameter includes `0`.

## Parameter transformer reference

Parameter transformers:

* Execute when generating a link using <xref:Microsoft.AspNetCore.Routing.LinkGenerator>.
* Implement <xref:Microsoft.AspNetCore.Routing.IOutboundParameterTransformer?displayProperty=fullName>.
* Are configured using <xref:Microsoft.AspNetCore.Routing.RouteOptions.ConstraintMap>.
* Take the parameter's route value and transform it to a new string value.
* Result in using the transformed value in the generated link.

For example, a custom `slugify` parameter transformer in route pattern `blog\{article:slugify}` with `Url.Action(new { article = "MyTestArticle" })` generates `blog\my-test-article`.

Consider the following `IOutboundParameterTransformer` implementation:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/StartupConstraint2.cs" id="snippet2":::

To use a parameter transformer in a route pattern, configure it using <xref:Microsoft.AspNetCore.Routing.RouteOptions.ConstraintMap> in `Startup.ConfigureServices`:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/StartupConstraint2.cs" id="snippet":::

The ASP.NET Core framework uses parameter transformers to transform the URI where an endpoint resolves. For example, parameter transformers transform the route values used to match an `area`, `controller`, `action`, and `page`.

```csharp
routes.MapControllerRoute(
    name: "default",
    template: "{controller:slugify=Home}/{action:slugify=Index}/{id?}");
```

With the preceding route template, the action `SubscriptionManagementController.GetAll` is matched with the URI `/subscription-management/get-all`. A parameter transformer doesn't change the route values used to generate a link. For example, `Url.Action("GetAll", "SubscriptionManagement")` outputs `/subscription-management/get-all`.

ASP.NET Core provides API conventions for using parameter transformers with generated routes:

* The <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.RouteTokenTransformerConvention?displayProperty=fullName> MVC convention applies a specified parameter transformer to all attribute routes in the app. The parameter transformer transforms attribute route tokens as they are replaced. For more information, see [Use a parameter transformer to customize token replacement](xref:mvc/controllers/routing#use-a-parameter-transformer-to-customize-token-replacement).
* Razor Pages uses the <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.PageRouteTransformerConvention> API convention. This convention applies a specified parameter transformer to all automatically discovered Razor Pages. The parameter transformer transforms the folder and file name segments of Razor Pages routes. For more information, see [Use a parameter transformer to customize page routes](xref:razor-pages/razor-pages-conventions#use-a-parameter-transformer-to-customize-page-routes).

<a name="ugr"></a>

## URL generation reference

This section contains a reference for the algorithm implemented by URL generation. In practice, most complex examples of URL generation use controllers or Razor Pages. See  [routing in controllers](xref:mvc/controllers/routing) for additional information.

The URL generation process begins with a call to [LinkGenerator.GetPathByAddress](xref:Microsoft.AspNetCore.Routing.LinkGenerator.GetPathByAddress%2A) or a similar method. The method is provided with an address, a set of route values, and optionally information about the current request from `HttpContext`.

The first step is to use the address to resolve a set of candidate endpoints using an [`IEndpointAddressScheme<TAddress>`](xref:Microsoft.AspNetCore.Routing.IEndpointAddressScheme%601) that matches the address's type.

Once the set of candidates is found by the address scheme, the endpoints are ordered and processed iteratively until a URL generation operation succeeds. URL generation does **not** check for ambiguities, the first result returned is the final result.

### Troubleshooting URL generation with logging

The first step in troubleshooting URL generation is setting the logging level of `Microsoft.AspNetCore.Routing` to `TRACE`. `LinkGenerator` logs many details about its processing which can be useful to troubleshoot problems.

See [URL generation reference](#ugr) for details on URL generation.

### Addresses

Addresses are the concept in URL generation used to bind a call into the link generator to a set of candidate endpoints.

Addresses are an extensible concept that come with two implementations by default:

* Using *endpoint name* (`string`) as the address:
  * Provides similar functionality to MVC's route name.
  * Uses the <xref:Microsoft.AspNetCore.Routing.IEndpointNameMetadata> metadata type.
  * Resolves the provided string against the metadata of all registered endpoints.
  * Throws an exception on startup if multiple endpoints use the same name.
  * Recommended for general-purpose use outside of controllers and Razor Pages.
* Using *route values* (<xref:Microsoft.AspNetCore.Routing.RouteValuesAddress>) as the address:
  * Provides similar functionality to controllers and Razor Pages legacy URL generation.
  * Very complex to extend and debug.
  * Provides the implementation used by `IUrlHelper`, Tag Helpers, HTML Helpers, Action Results, etc.

The role of the address scheme is to make the association between the address and matching endpoints by arbitrary criteria:

* The endpoint name scheme performs a basic dictionary lookup.
* The route values scheme has a complex best subset of set algorithm.

<a name="ambient"></a>

### Ambient values and explicit values

From the current request, routing accesses the route values of the current request `HttpContext.Request.RouteValues`. The values associated with the current request are referred to as the **ambient values**. For the purpose of clarity, the documentation refers to the route values passed in to methods as **explicit values**.

The following example shows ambient values and explicit values. It provides ambient values from the current request and explicit values: `{ id = 17, }`:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/Controllers/WidgetController.cs" id="snippet":::

The preceding code:

* Returns `/Widget/Index/17`
* Gets <xref:Microsoft.AspNetCore.Routing.LinkGenerator> via [DI](xref:fundamentals/dependency-injection).

The following code provides no ambient values and explicit values: `{ controller = "Home", action = "Subscribe", id = 17, }`:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/Controllers/WidgetController.cs" id="snippet2":::

The preceding  method returns `/Home/Subscribe/17`

The following code in the `WidgetController` returns `/Widget/Subscribe/17`:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/Controllers/WidgetController.cs" id="snippet3":::

The following code provides the controller from ambient values in the current request and explicit values: `{ action = "Edit", id = 17, }`:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/Controllers/GadgetController.cs" id="snippet":::

In the preceding code:

* `/Gadget/Edit/17` is returned.
* <xref:Microsoft.AspNetCore.Mvc.ControllerBase.Url> gets the <xref:Microsoft.AspNetCore.Mvc.IUrlHelper>.
* <xref:Microsoft.AspNetCore.Mvc.UrlHelperExtensions.Action%2A> generates a URL with an absolute path for an action method. The URL contains the specified `action` name and `route` values.

The following code provides ambient values from the current request and explicit values: `{ page = "./Edit, id = 17, }`:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/Pages/Index.cshtml.cs" id="snippet":::

The preceding code sets `url` to  `/Edit/17` when the Edit Razor Page contains the following page directive:

`@page "{id:int}"`

If the Edit page doesn't contain the `"{id:int}"` route template, `url` is `/Edit?id=17`.

The behavior of MVC's <xref:Microsoft.AspNetCore.Mvc.IUrlHelper> adds a layer of complexity in addition to the rules described here:

* `IUrlHelper` always provides the route values from the current request as ambient values.
* [IUrlHelper.Action](xref:Microsoft.AspNetCore.Mvc.UrlHelperExtensions.Action%2A) always copies the current `action` and `controller` route values as explicit values unless overridden by the developer.
* [IUrlHelper.Page](xref:Microsoft.AspNetCore.Mvc.UrlHelperExtensions.Page%2A) always copies the current `page` route value as an explicit value unless overridden. <!--by the user-->
* `IUrlHelper.Page` always overrides the current `handler` route value with `null` as an explicit values unless overridden.

Users are often surprised by the behavioral details of ambient values, because MVC doesn't seem to follow its own rules. For historical and compatibility reasons, certain route values such as `action`, `controller`, `page`, and `handler` have their own special-case behavior.

The equivalent functionality provided by `LinkGenerator.GetPathByAction` and `LinkGenerator.GetPathByPage` duplicates these anomalies of `IUrlHelper` for compatibility.

### URL generation process

Once the set of candidate endpoints are found, the URL generation algorithm:

* Processes the endpoints iteratively.
* Returns the first successful result.

The first step in this process is called **route value invalidation**.  Route value invalidation is the process by which routing decides which route values from the ambient values should be used and which should be ignored. Each ambient value is considered and either combined with the explicit values, or ignored.

The best way to think about the role of ambient values is that they attempt to save application developers typing, in some common cases. Traditionally, the scenarios where ambient values are helpful are related to MVC:

* When linking to another action in the same controller, the controller name doesn't need to be specified.
* When linking to another controller in the same area, the area name doesn't need to be specified.
* When linking to the same action method, route values don't need to be specified.
* When linking to another part of the app, you don't want to carry over route values that have no meaning in that part of the app.

Calls to `LinkGenerator` or `IUrlHelper` that return `null` are usually caused by not understanding route value invalidation. Troubleshoot route value invalidation by explicitly specifying more of the route values to see if that solves the problem.

Route value invalidation works on the assumption that the app's URL scheme is hierarchical, with a hierarchy formed from left-to-right. Consider the basic controller route template `{controller}/{action}/{id?}` to get an intuitive sense of how this works in practice. A **change** to a value **invalidates** all of the route values that appear to the right. This reflects the assumption about hierarchy. If the app has an ambient value for `id`, and the operation specifies a different value for the `controller`:

* `id` won't be reused because `{controller}` is to the left of `{id?}`.

Some examples demonstrating this principle:

* If the explicit values contain a value for `id`, the ambient value for `id` is ignored. The ambient values for `controller` and `action` can be used.
* If the explicit values contain a value for `action`, any ambient value for `action` is ignored. The ambient values for `controller` can be used. If the explicit value for `action` is different from the ambient value for `action`, the `id` value won't be used.  If the explicit value for `action` is the same as the ambient value for `action`, the `id` value can be used.
* If the explicit values contain a value for `controller`, any ambient value for `controller` is ignored. If the explicit value for `controller` is different from the ambient value for `controller`, the `action` and `id` values won't be used. If the explicit value for `controller` is the same as the ambient value for `controller`, the `action` and `id` values can be used.

This process is further complicated by the existence of attribute routes and dedicated conventional routes. Controller conventional routes such as `{controller}/{action}/{id?}` specify a hierarchy using route parameters. For [dedicated conventional routes](xref:mvc/controllers/routing#dcr) and [attribute routes](xref:mvc/controllers/routing#ar) to controllers and Razor Pages:

* There is a hierarchy of route values.
* They don't appear in the template.

For these cases, URL generation defines the **required values** concept. Endpoints created by controllers and Razor Pages have required values specified that allow route value invalidation to work.

The route value invalidation algorithm in detail:

* The required value names are combined with the route parameters, then processed from left-to-right.
* For each parameter, the ambient value and explicit value are compared:
  * If the ambient value and explicit value are the same, the process continues.
  * If the ambient value is present and the explicit value isn't, the ambient value is used when generating the URL.
  * If the ambient value isn't present and the explicit value is, reject the ambient value and all subsequent ambient values.
  * If the ambient value and the explicit value are present, and the two values are different, reject the ambient value and all subsequent ambient values.

At this point, the URL generation operation is ready to evaluate route constraints. The set of accepted values is combined with the parameter default values, which is provided to constraints. If the constraints all pass, the operation continues.

Next, the **accepted values** can be used to expand the route template. The route template is processed:

* From left-to-right.
* Each parameter has its accepted value substituted.
* With the following special cases:
  * If the accepted values is missing a value and the parameter has a default value, the default value is used.
  * If the accepted values is missing a value and the parameter is optional, processing continues.
  * If any route parameter to the right of a missing optional parameter has a value, the operation fails.
  * <!-- review default-valued parameters optional parameters --> Contiguous default-valued parameters and optional parameters are collapsed where possible.

Values explicitly provided that don't match a segment of the route are added to the query string. The following table shows the result when using the route template `{controller}/{action}/{id?}`.

| Ambient Values                     | Explicit Values                        | Result                  |
|------------------------------------|----------------------------------------|-------------------------|
| controller = "Home"                | action = "About"                       | `/Home/About`           |
| controller = "Home"                | controller = "Order", action = "About" | `/Order/About`          |
| controller = "Home", color = "Red" | action = "About"                       | `/Home/About`           |
| controller = "Home"                | action = "About", color = "Red"        | `/Home/About?color=Red` |

### Problems with route value invalidation

As of ASP.NET Core 3.0, some URL generation schemes used in earlier ASP.NET Core versions don't work well with URL generation. The ASP.NET Core team plans to add features to address these needs in a future release. For now the best solution is to use legacy routing.

The following code shows an example of a URL generation scheme that's not supported by routing.

:::code language="csharp" source="routing/samples/3.x/RoutingSample/StartupUnsupported.cs" id="snippet":::

In the preceding code, the `culture` route parameter is used for localization. The desire is to have the `culture` parameter always accepted as an ambient value. However, the `culture` parameter is not accepted as an ambient value because of the way required values work:

* In the `"default"` route template, the `culture` route parameter is to the left of `controller`, so changes to `controller` won't invalidate `culture`.
* In the `"blog"` route template, the `culture` route parameter is considered to be to the right of `controller`, which appears in the required values.

## Configuring endpoint metadata

The following links provide information on configuring endpoint metadata:

* [Enable Cors with endpoint routing](xref:security/cors#enable-cors-with-endpoint-routing)
* [IAuthorizationPolicyProvider sample](https://github.com/dotnet/AspNetCore/tree/release/3.1/src/Security/samples/CustomPolicyProvider) using a custom `[MinimumAgeAuthorize]` attribute
* [Test authentication with the [Authorize] attribute](xref:security/authentication/identity#test-identity)
* <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A>
* [Selecting the scheme with the [Authorize] attribute](xref:security/authorization/limitingidentitybyscheme#selecting-the-scheme-with-the-authorize-attribute)
* [Apply policies using the [Authorize] attribute](xref:security/authorization/policies#apply-policies-to-mvc-controllers)
* <xref:security/authorization/roles>

<a name="hostmatch"></a>

## Host matching in routes with RequireHost

<xref:Microsoft.AspNetCore.Builder.RoutingEndpointConventionBuilderExtensions.RequireHost%2A> applies a constraint to the route which requires the specified host. The `RequireHost` or [[Host]](xref:Microsoft.AspNetCore.Routing.HostAttribute) parameter can be:

* Host: `www.domain.com`, matches `www.domain.com` with any port.
* Host with wildcard: `*.domain.com`, matches `www.domain.com`, `subdomain.domain.com`, or `www.subdomain.domain.com` on any port.
* Port: `*:5000`, matches port 5000 with any host.
* Host and port: `www.domain.com:5000` or `*.domain.com:5000`, matches host and port.

Multiple parameters can be specified using `RequireHost` or `[Host]`. The constraint  matches hosts valid for any of the parameters. For example, `[Host("domain.com", "*.domain.com")]` matches `domain.com`, `www.domain.com`, and `subdomain.domain.com`.

The following code uses `RequireHost` to require the specified host on the route:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/StartupRequireHost.cs" id="snippet":::

The following code uses the `[Host]` attribute on the controller to require any of the specified hosts:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/Controllers/ProductController.cs" id="snippet":::

When the `[Host]` attribute is applied to both the controller and action method:

* The attribute on the action is used.
* The controller attribute is ignored.

## Performance guidance for routing

Most of routing was updated in ASP.NET Core 3.0 to increase performance.

When an app has performance problems, routing is often suspected as the problem. The reason routing is suspected is that frameworks like controllers and Razor Pages report the amount of time spent inside the framework in their logging messages. When there's a significant difference between the time reported by controllers and the total time of the request:

* Developers eliminate their app code as the source of the problem.
* It's common to assume routing is the cause.

Routing is performance tested using thousands of endpoints. It's unlikely that a typical app will encounter a performance problem just by being too large. The most common root cause of slow routing performance is usually a badly-behaving custom middleware.

This following code sample demonstrates a basic technique for narrowing down the source of delay:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/StartupDelay.cs" id="snippet":::

To time routing:

* Interleave each middleware with a copy of the timing middleware shown in the preceding code.
* Add a unique identifier to correlate the timing data with the code.

This is a basic way to narrow down the delay when it's significant, for example, more than `10ms`.  Subtracting `Time 2` from `Time 1` reports the time spent inside the `UseRouting` middleware.

The following code uses a more compact approach to the preceding timing code:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/StartupSW.cs" id="snippetSW":::

:::code language="csharp" source="routing/samples/3.x/RoutingSample/StartupSW.cs" id="snippet":::

### Potentially expensive routing features

The following list provides some insight into routing features that are relatively expensive compared with basic route templates:

* Regular expressions: It's possible to write regular expressions that are complex, or have long running time with a small amount of input.
* Complex segments (`{x}-{y}-{z}`): 
  * Are significantly more expensive than parsing a regular URL path segment.
  * Result in many more substrings being allocated.
  * The complex segment logic was not updated in ASP.NET Core 3.0 routing performance update.
* Synchronous data access: Many complex apps have database access as part of their routing. ASP.NET Core 2.2 and earlier routing might not provide the right extensibility points to support database access routing. For example, <xref:Microsoft.AspNetCore.Routing.IRouteConstraint>, and <xref:Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint> are synchronous. Extensibility points such as <xref:Microsoft.AspNetCore.Routing.MatcherPolicy> and <xref:Microsoft.AspNetCore.Routing.EndpointSelectorContext> are asynchronous.

## Guidance for library authors

This section contains guidance for library authors building on top of routing. These details are intended to ensure that app developers have a good experience using libraries and frameworks that extend routing.

### Define endpoints

To create a framework that uses routing for URL matching, start by defining a user experience that builds on top of <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A>.

**DO** build on top of <xref:Microsoft.AspNetCore.Routing.IEndpointRouteBuilder>. This allows users to compose your framework with other ASP.NET Core features without confusion. Every ASP.NET Core template includes routing. Assume routing is present and familiar for users.

```csharp
app.UseEndpoints(endpoints =>
{
    // Your framework
    endpoints.MapMyFramework(...);

    endpoints.MapHealthChecks("/healthz");
});
```

**DO** return a sealed concrete type from a call to `MapMyFramework(...)` that implements <xref:Microsoft.AspNetCore.Builder.IEndpointConventionBuilder>. Most framework `Map...` methods follow this pattern. The `IEndpointConventionBuilder` interface:

* Allows composability of metadata.
* Is targeted by a variety of extension methods.

Declaring your own type allows you to add your own framework-specific functionality to the builder. It's ok to wrap a framework-declared builder and forward calls to it.

```csharp
app.UseEndpoints(endpoints =>
{
    // Your framework
    endpoints.MapMyFramework(...).RequireAuthorization()
                                 .WithMyFrameworkFeature(awesome: true);

    endpoints.MapHealthChecks("/healthz");
});
```

**CONSIDER** writing your own <xref:Microsoft.AspNetCore.Routing.EndpointDataSource>. `EndpointDataSource` is the low-level primitive for declaring and updating a collection of endpoints. `EndpointDataSource` is a powerful API used by controllers and Razor Pages.

The routing tests have a [basic example](https://github.com/dotnet/AspNetCore/blob/main/src/Http/Routing/test/testassets/RoutingSandbox/Framework/FrameworkEndpointDataSource.cs#L17) of a non-updating data source.

**DO NOT** attempt to register an `EndpointDataSource` by default. Require users to register your framework in <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A>. The philosophy of routing is that nothing is included by default, and that `UseEndpoints` is the place to register endpoints.

### Creating routing-integrated middleware

**CONSIDER** defining metadata types as an interface.

**DO** make it possible to use metadata types as an attribute on classes and methods.

:::code language="csharp" source="routing/samples/3.x/RoutingSample/ICoolMetadata.cs" id="snippet2":::

Frameworks like controllers and Razor Pages support applying metadata attributes to types and methods. If you declare metadata types:

* Make them accessible as [attributes](/dotnet/csharp/programming-guide/concepts/attributes/).
* Most users are familiar with applying attributes.

Declaring a metadata type as an interface adds another layer of flexibility:

* Interfaces are composable.
* Developers can declare their own types that combine multiple policies.

**DO** make it possible to override metadata, as shown in the following example:

:::code language="csharp" source="routing/samples/3.x/RoutingSample/ICoolMetadata.cs" id="snippet":::

The best way to follow these guidelines is to avoid defining **marker metadata**:

* Don't just look for the presence of a metadata type.
* Define a property on the metadata and check the property.

The metadata collection is ordered and supports overriding by priority. In the case of controllers, metadata on the action method is most specific.

**DO** make middleware useful with and without routing.

```csharp
app.UseRouting();

app.UseAuthorization(new AuthorizationPolicy() { ... });

app.UseEndpoints(endpoints =>
{
    // Your framework
    endpoints.MapMyFramework(...).RequireAuthorization();
});
```

As an example of this guideline, consider the `UseAuthorization` middleware. The authorization middleware allows you to pass in a fallback policy. <!-- shown where?  (shown here) --> The fallback policy, if specified, applies to both:

* Endpoints without a specified policy.
* Requests that don't match an endpoint.

This makes the authorization middleware useful outside of the context of routing. The authorization middleware can be used for traditional middleware programming.

[!INCLUDE[](~/includes/dbg-route.md)]

:::moniker-end
