---
title: ASP.NET Core Middleware
ai-usage: ai-assisted
author: tdykstra
description: Learn about ASP.NET Core middleware and the request pipeline.
monikerRange: '>= aspnetcore-3.0'
ms.author: tdykstra
ms.custom: mvc
ms.date: 01/20/2026
uid: fundamentals/middleware/index
---
# ASP.NET Core Middleware

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-8.0"

Middleware is software that's assembled into an app pipeline to handle requests and responses. Each middleware:

* Chooses whether to pass the request to the next middleware in the pipeline.
* Can perform work before and after the next middleware in the pipeline.

Request delegates are used to build the request pipeline. The request delegates handle each HTTP request.

Request delegates are configured using <xref:Microsoft.AspNetCore.Builder.RunExtensions.Run%2A>, <xref:Microsoft.AspNetCore.Builder.MapExtensions.Map%2A>, and <xref:Microsoft.AspNetCore.Builder.UseExtensions.Use%2A> extension methods. An individual request delegate can be specified inline as an anonymous method (called inline middleware) or defined in a reusable class. These inline anonymous methods or reusable classes are called *middleware* or *middleware components*. Each middleware in the request pipeline is responsible for invoking the next middleware in the pipeline or short-circuiting the pipeline. When a middleware short-circuits, it's called a *terminal middleware* because it prevents further middleware from processing the request.

For more information on the difference between request pipelines in ASP.NET Core and ASP.NET 4.x with additional middleware samples, see <xref:migration/fx-to-core/areas/http-modules>.

## Role of middleware by app type

Blazor Web Apps, Razor Pages, and MVC process browser requests on the server with middleware. The guidance in this article applies to these types of apps.

Standalone Blazor WebAssembly apps run entirely on the client and don't process requests with a middleware pipeline. The guidance in this article doesn't apply to standalone Blazor WebAssembly apps.

## Middleware code analysis

For more information on ASP.NET Core's compiler platform analyzers that inspect app code for quality, see <xref:diagnostics/code-analysis>.

## Create a middleware pipeline with `WebApplication`

The ASP.NET Core request pipeline consists of a sequence of request delegates, called one after the other. The following diagram demonstrates the concept. The thread of execution follows the black arrows.

![Request processing pattern showing a request arriving, processing through three middlewares, and the response leaving the app. Each middleware runs its logic and hands off the request to the next middleware at the next() statement. After the third middleware processes the request, the request passes back through the prior two middlewares in reverse order for additional processing after their next() statements before leaving the app as a response to the client.](~/fundamentals/middleware/index/_static/request-delegate-pipeline.png)

Each delegate can perform operations before and after the next delegate. Exception-handling delegates should be called early in the pipeline, so they can catch exceptions that occur in later stages of the pipeline.

> [!NOTE]
> To experiment locally with the code examples in this section, create an ASP.NET Core app using the **ASP.NET Core Empty** project template. If using the .NET CLI, the template short name is `web` (`dotnet new web`).

The simplest ASP.NET Core app calls <xref:Microsoft.AspNetCore.Builder.RunExtensions.Run%2A> to set up a single terminal middleware as an anonymous function request delegate to handle requests without a request pipeline.

In the following example:

* The call to <xref:Microsoft.AspNetCore.Builder.RunExtensions.Run%2A?displayProperty=nameWithType> is invoked on every request and writes ":::no-loc text="Hello world!":::" to the response.
* The call to <xref:Microsoft.AspNetCore.Builder.WebApplication.Run%2A?displayProperty=nameWithType> at the end of the code block runs the app and blocks the calling thread until host shutdown.

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello world!");
});

app.Run();
```

Response when accessing the app in a browser at its launch URL:

> :::no-loc text="Hello world!":::

Chain multiple request delegates together with <xref:Microsoft.AspNetCore.Builder.UseExtensions.Use%2A>. The `next` parameter represents the next delegate in the pipeline. You can typically perform actions both before and after the `next` delegate.

The following example demonstrates:

* Two <xref:Microsoft.AspNetCore.Builder.UseExtensions.Use%2A> calls, each writing to the console:
  * Where work can be performed that can write to the response (`context.Response`, <xref:Microsoft.AspNetCore.Http.HttpResponse>).
  * Where work can be performed that doesn't write to the response after the `next` parameter is invoked.
* A terminal request delegate with a call to <xref:Microsoft.AspNetCore.Builder.RunExtensions.Run%2A?displayProperty=nameWithType> that writes ":::no-loc text="Hello world!":::" to the response.
* A final <xref:Microsoft.AspNetCore.Builder.UseExtensions.Use%2A> call, which never executes because it follows the <xref:Microsoft.AspNetCore.Builder.RunExtensions.Run%2A> terminal request delegate.
* A call to <xref:Microsoft.AspNetCore.Builder.WebApplication.Run%2A?displayProperty=nameWithType> at the end of the code block to run the app and block the calling thread until host shutdown.

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    Console.WriteLine("Work that can write to the response. (1)");
    await next.Invoke(context);
    Console.WriteLine("Work that doesn't write to the response. (1)");
});

app.Use(async (context, next) =>
{
    Console.WriteLine("Work that can write to the response. (2)");
    await next.Invoke(context);
    Console.WriteLine("Work that doesn't write to the response. (2)");
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello world!");
});

app.Use(async (context, next) =>
{
    Console.WriteLine("This statement isn't reached. (3)");
    await next.Invoke(context);
    Console.WriteLine("This statement isn't reached. (3)");
});

app.Run();
```

In the app's console window when the app is run:

<!-- DOC AUTHOR NOTE: Two spaces at the ends of the first three lines
                      for newlines in the rendered article. -->

> :::no-loc text="Work that can write to the response. (1)":::  
> :::no-loc text="Work that can write to the response. (2)":::  
> :::no-loc text="Work that doesn't write to the response. (2)":::  
> :::no-loc text="Work that doesn't write to the response. (1)":::

*Short-circuiting* the request pipeline is often desirable because it avoids unnecessary work. For example, [Static File Middleware](xref:fundamentals/static-files) can act as a *terminal middleware* by processing a request for a static file and short-circuiting the rest of the pipeline. Middleware added to the pipeline before the terminal middleware still processes code after their `next.Invoke` statements. If you don't plan to call `next.Invoke` because your goal is to terminate the pipeline, use a [`Run` delegate](#run-delegate) instead of calling the <xref:Microsoft.AspNetCore.Builder.UseExtensions.Use%2A> extension method.

Don't call `next.Invoke` during or after the response is sent to the client. After an <xref:Microsoft.AspNetCore.Http.HttpResponse> is started, changes result in an exception. For example, [setting headers or a response status code throw an exception](xref:fundamentals/best-practices#do-not-modify-the-status-code-or-headers-after-the-response-body-has-started) after the response starts. Writing to the response body after calling `next` may:

* Cause a protocol violation, such as writing more bytes to the response than the stated response's content length (`Content-Length` header value).
* Corrupt the body format, such as writing an HTML footer to a CSS file.

To determine if the response has started, check the value of <xref:Microsoft.AspNetCore.Http.HttpResponse.HasStarted%2A>.

For more information, see [Short-circuit middleware after routing](xref:fundamentals/routing#short-circuit-middleware-after-routing).

## `Run` delegate

A <xref:Microsoft.AspNetCore.Builder.RunExtensions.Run%2A> delegate doesn't receive a `next` parameter. The first `Run` delegate always terminates the pipeline. `Run` is also a convention, and some middleware may expose `Run` methods that execute at the end of the pipeline.

Any <xref:Microsoft.AspNetCore.Builder.UseExtensions.Use%2A> or <xref:Microsoft.AspNetCore.Builder.RunExtensions.Run%2A> delegates after the first <xref:Microsoft.AspNetCore.Builder.RunExtensions.Run%2A> delegate aren't called.

## Branch the middleware pipeline

<xref:Microsoft.AspNetCore.Builder.MapExtensions.Map%2A> extensions are used as a convention to branch the request processing pipeline. <xref:Microsoft.AspNetCore.Builder.MapExtensions.Map%2A> branches the request pipeline based on matches of the given request path. If the request path starts with the given path, the branch is executed.

In the following example, `HandleMap1` is called for requests to `/map1`, and `HandleMap2` is called for requests to `/map2`:

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/map1", HandleMap1);
app.Map("/map2", HandleMap2);

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from the non-Map delegate!");
});

app.Run();

private static void HandleMap1(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Map 1");
    });
}

private static void HandleMap2(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Map 2");
    });
}
```

The following table shows the requests and responses using the preceding code.

Request | Response
--- | ---
`/` | :::no-loc text="Hello from the non-Map delegate.":::
`/map1` | :::no-loc text="Map 1":::
`/map2` | :::no-loc text="Map 2":::
`/map3` | :::no-loc text="Hello from the non-Map delegate.":::

When <xref:Microsoft.AspNetCore.Builder.MapExtensions.Map%2A> is used, the matched path segments are removed from <xref:Microsoft.AspNetCore.Http.HttpRequest.Path%2A?displayProperty=nameWithType> and appended to <xref:Microsoft.AspNetCore.Http.HttpRequest.PathBase%2A?displayProperty=nameWithType> for each request.

<xref:Microsoft.AspNetCore.Builder.MapExtensions.Map%2A> can match multiple segments at once:

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/map1/segment1", HandleMultipleSegments);

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from the non-Map delegate.");
});

app.Run();

private static void HandleMultipleSegments(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Processing '/map1/segment1'");
    });
}
```

The following table shows the requests and responses using the preceding code.

Request | Response
--- | ---
`/` | :::no-loc text="Hello from the non-Map delegate.":::
`/map1/segment1` | :::no-loc text="Processing '/map1/segment1'":::

<xref:Microsoft.AspNetCore.Builder.MapExtensions.Map%2A> supports nesting:

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/level1", level1App => {
    level1App.Map("/level2a", level2AApp => {
        app.Run(async context =>
        {
            await context.Response.WriteAsync("Processing '/level1/level2a'");
        });
    });
    level1App.Map("/level2b", level2BApp => {
        app.Run(async context =>
        {
            await context.Response.WriteAsync("Processing '/level1/level2b'");
        });
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from the non-Map delegate!");
});

app.Run();
```

The following table shows the requests and responses using the preceding code.

Request | Response
--- | ---
`/` | :::no-loc text="Hello from the non-Map delegate.":::
`/level1/level2a` | :::no-loc text="Processing '/level1/level2a'":::
`/level1/level2b` | :::no-loc text="Processing '/level1/level2b'":::

<xref:Microsoft.AspNetCore.Builder.MapWhenExtensions.MapWhen%2A> branches the request pipeline based on the result of the given predicate. Any predicate of type `Func<HttpContext, bool>` can be used to map requests to a new branch of the pipeline. In the following example, a predicate is used to detect the presence of a query string variable named "`branch`":

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapWhen(context => context.Request.Query.ContainsKey("branch"), HandleBranch);

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from the non-Map delegate.");
});

app.Run();

private static void HandleBranch(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        var branchVer = context.Request.Query["branch"];
        await context.Response.WriteAsync($"Branch used = '{branchVer}'");
    });
}
```

The following table shows the requests and responses using the preceding code.

Request | Response
--- | ---
`/` | :::no-loc text="Hello from the non-Map delegate.":::
`/?branch=main` | :::no-loc text="Branch used = 'main'":::

<xref:Microsoft.AspNetCore.Builder.UseWhenExtensions.UseWhen%2A> can branch the request pipeline based on the result of the given predicate. Unlike <xref:Microsoft.AspNetCore.Builder.MapWhenExtensions.MapWhen%2A>, the branch is rejoined to the main pipeline if it doesn't contain a terminal middleware:

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseWhen(context => context.Request.Query.ContainsKey("branch"),
    appBuilder => HandleBranchAndRejoin(appBuilder));

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from the non-Map delegate.");
});

app.Run();

void HandleBranchAndRejoin(IApplicationBuilder app)
{
    var logger = app.ApplicationServices.GetRequiredService<ILogger<Program>>(); 

    app.Use(async (context, next) =>
    {
        var branchVer = context.Request.Query["branch"];
        logger.LogInformation("Branch used = {branchVer}", branchVer.ToString());

        Console.WriteLine("Work that can write to the response.");
        await next.Invoke(context);
        Console.WriteLine("Work that doesn't write to the response.");
    });
}
```

In the preceding example, a response of ":::no-loc text="Hello from the non-Map delegate.":::" is written for all requests. If the request includes a query string variable named "`branch`," its value is logged before the main pipeline is rejoined.

## Middleware order

The order that middleware appears in the app's `Program` file defines the order in which middleware are invoked on a request with the reverse order for the response.

You have full control over the order of middleware and the ability to add custom middleware for request processing scenarios, keeping in mind that the order of middleware can be critical for security, performance, and functionality.

The following examples demonstrate middleware order for common app scenarios. Each middleware extension method is exposed on <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> through the <xref:Microsoft.AspNetCore.Builder?displayProperty=fullName> namespace:

1. Exception/error handling
   * When the app runs in the `Development` environment:
     * Developer Exception Page Middleware (<xref:Microsoft.AspNetCore.Builder.DeveloperExceptionPageExtensions.UseDeveloperExceptionPage%2A>) reports app runtime errors.
     * Database Error Page Middleware (<xref:Microsoft.AspNetCore.Builder.DatabaseErrorPageExtensions.UseDatabaseErrorPage%2A>) reports database runtime errors.
   * When the app runs in the `Production` environment:
     * Exception Handler Middleware (<xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A>) catches exceptions thrown in the following middlewares.
     * HTTP Strict Transport Security Protocol (HSTS) Middleware (<xref:Microsoft.AspNetCore.Builder.HstsBuilderExtensions.UseHsts%2A>) adds the `Strict-Transport-Security` header.
1. HTTPS Redirection Middleware (<xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection%2A>) redirects HTTP requests to HTTPS.
1. Static File Middleware (if required, <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>) returns static files and short-circuits further request processing.
1. Cookie Policy Middleware (<xref:Microsoft.AspNetCore.Builder.CookiePolicyAppBuilderExtensions.UseCookiePolicy%2A>) conforms the app to the EU General Data Protection Regulation (GDPR).
1. Routing Middleware (<xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A>) to route requests.
1. Authentication Middleware (<xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A>) attempts to authenticate the user before they're allowed access to secure resources.
1. Authorization Middleware (<xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A>) authorizes a user to access secure resources.
1. Antiforgery Middleware (<xref:Microsoft.AspNetCore.Builder.AntiforgeryApplicationBuilderExtensions.UseAntiforgery%2A>) adds antiforgery middleware to the pipeline <xref:Microsoft.AspNetCore.Builder.AntiforgeryApplicationBuilderExtensions.UseAntiforgery%2A> must be placed after calls to <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A> and <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A>.
1. Session Middleware (Razor Pages and MVC only, <xref:Microsoft.AspNetCore.Builder.SessionMiddlewareExtensions.UseSession%2A>) establishes and maintains session state. If the app uses session state, call Session Middleware after Cookie Policy Middleware and before Razor Pages/MVC Middleware.
1. Endpoint Routing Middleware
  * <xref:Microsoft.AspNetCore.Builder.RazorComponentsEndpointRouteBuilderExtensions.MapRazorComponents%2A> to add Razor component endpoints to the request pipeline.
  * <xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapRazorPages%2A> to add Razor Pages endpoints to the request pipeline.
  * <xref:Microsoft.AspNetCore.Builder.ControllerEndpointRouteBuilderExtensions.MapControllerRoute%2A> to add controller endpoints to the request pipeline.


Typical Blazor Web App middleware pipeline:

```csharp
app.UseWebAssemblyDebugging(); // Development environment with client-side rendering
app.UseMigrationsEndPoint(); // Development environment with ASP.NET Core Identity

app.UseExceptionHandler("/Error", createScopeForErrors: true); // Non-Development environment
app.UseHsts(); // Non-Development environment with HTTPS protocol

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

app.UseHttpsRedirection(); // With HTTPS protocol

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>(); // With additional extension methods for render modes

app.MapAdditionalIdentityEndpoints(); // With ASP.NET Core Identity

app.Run();
```

Typical Razor Pages/MVC middleware pipeline:

```csharp
app.UseMigrationsEndPoint(); // Development environment with ASP.NET Core Identity

app.UseExceptionHandler("/Error"); // Non-Development environment
app.UseHsts(); // Non-Development environment with HTTPS protocol

app.UseHttpsRedirection(); // With HTTPS protocol

// app.UseCookiePolicy();
app.UseRouting(); // If not called, runs at the beginning of the pipeline by default
// app.UseRateLimiter();
// app.UseRequestLocalization();
// app.UseCors();

// app.UseAuthentication(); // Called internally for ASP.NET Core Identity
app.UseAuthorization();
// app.UseSession();
// app.UseResponseCompression();
// app.UseResponseCaching();

app.MapStaticAssets();

app.MapControllerRoute(...); // For MVC controllers

app.MapRazorPages(); // For Razor Pages pages

app.MapControllers(); // With authentication in a Razor Pages app

app.Run();
```

In the preceding code:

* CORS Middleware (<xref:Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions.UseCors%2A>), Authentication Middleware (<xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A>), and Authorization Middleware (<xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A>) must appear in the order shown.
* CORS Middleware (<xref:Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions.UseCors%2A>) must appear before Response Caching Middleware (<xref:Microsoft.AspNetCore.Builder.ResponseCachingExtensions.UseResponseCaching%2A>) to add CORS headers on every request, including cached responses. For more information, see [It is not clear that UseCORS must come before UseResponseCaching (`dotnet/aspnetcore` #23218](https://github.com/dotnet/aspnetcore/issues/23218).
* Request Localization Middleware (<xref:Microsoft.AspNetCore.Builder.ApplicationBuilderExtensions.UseRequestLocalization%2A>) must appear before any middleware that might check the request culture, for example, Static File Middleware (<xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>).
* Rate Limiting Middleware (<xref:Microsoft.AspNetCore.Builder.RateLimiterApplicationBuilderExtensions.UseRateLimiter%2A>) must be called after Routing Middleware (<xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A>) when rate limiting endpoint-specific APIs are used. For example, if the [`[EnableRateLimiting]` attribute](xref:Microsoft.AspNetCore.RateLimiting.EnableRateLimitingAttribute) is used, Rate Limiting Middleware must be called after Routing Middleware. When calling only global limiters, Rate Limiting Middleware can be called before Routing Middleware.

In some scenarios, middleware has different ordering. For example, caching and compression ordering depends on the app's specification. In the following order, CPU usage might be reduced by caching the compressed response, but the app might end up caching multiple representations of a resource using different compression algorithms, such as Gzip or Brotli:

```csharp
app.UseResponseCaching();
app.UseResponseCompression();
```

Static assets are typically served early in the pipeline so that the app can short-circuit request processing to improve performance.

Authentication doesn't short-circuit unauthenticated requests. Although Authentication Middleware authenticates requests, authorization occurs after the framework selects a Razor component in a Blazor Web App, a page in a Razor Pages app, or a controller and action in an MVC app.

## `UseCors` and `UseStaticFiles` order

For more information on ordering <xref:Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions.UseCors%2A> and <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>, see <xref:security/cors#usecors-and-usestaticfiles-order>.

## Forwarded Headers Middleware order

Run Forwarded Headers Middleware before other middleware to ensure that the middleware relying on forwarded headers information can consume the header values for processing. To run Forwarded Headers Middleware after Diagnostics and Error Handling Middleware, see [Forwarded Headers Middleware order](xref:host-and-deploy/proxy-load-balancer#forwarded-headers-middleware-order).

## Built-in middleware

ASP.NET Core ships with the following middleware. The *UI stack* column indicates the typical UI stack where the middleware is used [All, Blazor Web App (BWA), Razor Pages and MVC (RP/MVC)]. The *Order* column provides notes on middleware placement in the request processing pipeline and under what conditions the middleware may terminate request processing. When a middleware short-circuits the request processing pipeline and prevents further downstream middleware from processing a request, it's called a *terminal middleware*. For more information on short-circuiting, see the [Create a middleware pipeline with `WebApplication`](#create-a-middleware-pipeline-with-webapplication) section.

<!-- REVIEWER NOTE: I have "All" for the *UI stack* entries except:
                    
                    MVC: RP/MVC
                    OWIN: RP/MVC
                    Output Caching: RP/MVC
                    Response Caching: RP/MVC
                    Session: RP/MVC
                    Blazor WebAssembly Debugging: Blazor Web App (CSR)
-->

Middleware | Description | UI stack | Order
--- | --- | --- | ---
[Antiforgery](xref:security/anti-request-forgery) | Provides anti-request-forgery support. | All | After authentication and authorization, before endpoints.
[Authentication](xref:security/authentication/identity) | Provides authentication support. | All | Before `HttpContext.User` is required. Terminal for OAuth callbacks.
[Authorization](xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A) | Provides authorization support. | All | Immediately after the Authentication Middleware.
[Cookie Policy](xref:security/gdpr) | Tracks consent from users for storing personal information and enforces minimum standards for cookie fields, such as `secure` and `SameSite`. | All | Before middleware that issues cookies. Examples: Authentication, Session, MVC (TempData).
[CORS](xref:security/cors) | Configures Cross-Origin Resource Sharing. | All | Before middleware that use CORS. <xref:Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions.UseCors%2A> must go before <xref:Microsoft.AspNetCore.Builder.ResponseCachingExtensions.UseResponseCaching%2A>. For more information, see [It is not clear that UseCORS must come before UseResponseCaching (`dotnet/aspnetcore` #23218](https://github.com/dotnet/aspnetcore/issues/23218).
[Developer Exception Page](xref:Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware) | Generates a page with error information that is intended for use only in the `Development` environment. | All | Before middleware that generate errors. The project templates automatically register this middleware as the first middleware in the pipeline when the environment is `Development`.
[Diagnostics](xref:fundamentals/error-handling) | Several separate middlewares that provide a developer exception page, exception handling, status code pages, and the default web page for new apps. | All | Before middleware that generate errors. Terminal for exceptions or serving the default web page for new apps.
[Forwarded Headers](xref:host-and-deploy/proxy-load-balancer) | Forwards proxied headers onto the current request. | All | Before middleware that consume the updated fields. Examples: scheme, host, client IP, method.
[Health Check](xref:host-and-deploy/health-checks) | Checks the health of an ASP.NET Core app and its dependencies, such as checking database availability. | All | Terminal if a request matches a health check endpoint.
[Header Propagation](xref:fundamentals/http-requests#header-propagation-middleware) | Propagates HTTP headers from the incoming request to the outgoing HTTP Client requests. | 
All | 
[HTTP Logging](xref:fundamentals/http-logging/index) | Logs HTTP Requests and Responses. | All | At the beginning of the middleware pipeline. 
[HTTP Method Override](xref:Microsoft.AspNetCore.Builder.HttpMethodOverrideExtensions) | Allows an incoming POST request to override the method. | All | Before middleware that consume the updated method.
[HTTPS Redirection](xref:security/enforcing-ssl#require-https) | Redirect all HTTP requests to HTTPS. | All | Before middleware that consume the URL.
[HTTP Strict Transport Security (HSTS)](xref:security/enforcing-ssl#http-strict-transport-security-protocol-hsts) | Security enhancement middleware that adds a special response header. | All | Before responses are sent and after middleware that modify requests. Examples: Forwarded Headers, URL Rewriting.
[MVC](xref:mvc/overview) | Processes requests with MVC/Razor Pages. | RP/MVC | Terminal if a request matches a route.
[OWIN](xref:fundamentals/owin) | Interop with OWIN-based apps, servers, and middleware. | RP/MVC | Terminal if the OWIN Middleware fully processes the request.
[Output Caching](xref:performance/caching/output) | Provides support for caching responses based on configuration. | RP/MVC | Before middleware that require caching. <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A> and <xref:Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions.UseCors%2A> must come before <xref:Microsoft.AspNetCore.Builder.OutputCacheApplicationBuilderExtensions.UseOutputCache%2A>.
[Response Caching](xref:performance/caching/middleware) | Provides support for caching responses. This requires client participation to work. Use output caching for complete server control. | RP/MVC | Before middleware that require caching. <xref:Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions.UseCors%2A> must come before <xref:Microsoft.AspNetCore.Builder.ResponseCachingExtensions.UseResponseCaching%2A>. Response caching isn't typically beneficial for UI apps, such as Razor Pages, because browsers generally set request headers that prevent caching. [Output caching](xref:performance/caching/output) benefits UI apps.
[Request Decompression](xref:fundamentals/middleware/request-decompression) | Provides support for decompressing requests. | All | Before middleware that read the request body.
[Response Compression](xref:performance/response-compression) | Provides support for compressing responses. | All | Before middleware that require compression.
[Request Localization](xref:fundamentals/localization) | Provides localization support. | All | Before localization sensitive middleware. Must appear after Routing Middleware when using <xref:Microsoft.AspNetCore.Localization.Routing.RouteDataRequestCultureProvider>.
[Request Timeouts](xref:performance/timeouts) | Provides support for configuring request timeouts, global and per endpoint. | All | <xref:Microsoft.AspNetCore.Builder.RequestTimeoutsIApplicationBuilderExtensions.UseRequestTimeouts%2A> must come after <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A>, <xref:Microsoft.AspNetCore.Builder.DeveloperExceptionPageExtensions.UseDeveloperExceptionPage%2A>, and <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A>.
[Endpoint Routing](xref:fundamentals/routing). | Defines and constrains request routes. | All | Terminal for matching routes.
[SPA](xref:Microsoft.AspNetCore.Builder.SpaApplicationBuilderExtensions.UseSpa%2A) | Handles all requests from this point in the middleware chain by returning the default page for the Single Page Application (SPA). | All | Appears late in the pipeline, so other middleware for serving static files, such as MVC actions, take precedence.
[Session](xref:fundamentals/app-state) | Provides support for managing user sessions. | RP/MVC | Before middleware that require Session.
[Static File](xref:fundamentals/static-files) | Provides support for serving static files and directory browsing. | All | Terminal if a request matches a file.
[URL Rewrite](xref:fundamentals/url-rewriting) | Provides support for rewriting URLs and redirecting requests. | All | Before middleware that consume the URL.
[W3C Logging](xref:fundamentals/w3c-logger/index) | Generates server access logs in the [W3C Extended Log File Format](https://www.w3.org/TR/WD-logfile.html). | All | At the beginning of the middleware pipeline.
[Blazor WebAssembly Debugging](xref:blazor/debug) | Debugging Blazor Web Apps that adopt client-side rendering (CSR) inside Chromium developer tools. | BWA | At the beginning of the middleware pipeline.
[WebSockets](xref:fundamentals/websockets) | Enables the WebSockets protocol. | All | Before middleware that are required to accept WebSocket requests.

## Additional resources

* [Lifetime and registration options (includes middleware sample)](xref:fundamentals/dependency-injection#lifetime-and-registration-options)
* <xref:fundamentals/middleware/write>
* <xref:test/middleware>
* [Configure gRPC-Web in ASP.NET Core](xref:grpc/browser#configure-grpc-web-in-aspnet-core)
* <xref:migration/fx-to-core/areas/http-modules>
* <xref:fundamentals/startup>
* <xref:fundamentals/request-features>
* <xref:fundamentals/middleware/extensibility>
* <xref:fundamentals/middleware/extensibility-third-party-container>

:::moniker-end

[!INCLUDE[](~/fundamentals/middleware/index/includes/index3-7.md)]
