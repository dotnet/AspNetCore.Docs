---
title: ASP.NET Core Middleware
ai-usage: ai-assisted
author: tdykstra
description: Learn about ASP.NET Core middleware and the request pipeline.
monikerRange: '>= aspnetcore-3.0'
ms.author: tdykstra
ms.custom: mvc
ms.date: 01/14/2026
uid: fundamentals/middleware/index
---
# ASP.NET Core Middleware

[!INCLUDE[](~/includes/not-latest-version.md)]

:::moniker range=">= aspnetcore-8.0"

Middleware is software that's assembled into an app pipeline to handle requests and responses. Each middleware:

* Chooses whether to pass the request to the next middleware in the pipeline.
* Can perform work before and after the next middleware in the pipeline.

Request delegates are used to build the request pipeline. The request delegates handle each HTTP request.

Request delegates are configured using <xref:Microsoft.AspNetCore.Builder.RunExtensions.Run%2A>, <xref:Microsoft.AspNetCore.Builder.MapExtensions.Map%2A>, and <xref:Microsoft.AspNetCore.Builder.UseExtensions.Use%2A> extension methods. An individual request delegate can be specified in-line as an anonymous method (called in-line middleware), or it can be defined in a reusable class. These reusable classes and in-line anonymous methods are *middleware*, also called *middleware components* (not to be confused with [Razor components](xref:blazor/index#components)). Each middleware in the request pipeline is responsible for invoking the next middleware in the pipeline or short-circuiting the pipeline. When a middleware short-circuits, it's called a *terminal middleware* because it prevents further middleware from processing the request.

<xref:migration/fx-to-core/areas/http-modules> explains the difference between request pipelines in ASP.NET Core and ASP.NET 4.x and provides additional middleware samples.

## The role of middleware by app type

Blazor Web Apps, Razor Pages, and MVC process browser requests on the server with middleware. The guidance in this article applies to these types of apps.

Standalone Blazor WebAssembly apps run entirely on the client and don't process requests with a middleware pipeline. The guidance in this article doesn't apply to standalone Blazor WebAssembly apps.

## Middleware code analysis

ASP.NET Core includes many compiler platform analyzers that inspect application code for quality. For more information, see <xref:diagnostics/code-analysis>.

## Create a middleware pipeline with `WebApplication`

The ASP.NET Core request pipeline consists of a sequence of request delegates, called one after the other. The following diagram demonstrates the concept. The thread of execution follows the black arrows.

![Request processing pattern showing a request arriving, processing through three middlewares, and the response leaving the app. Each middleware runs its logic and hands off the request to the next middleware at the next() statement. After the third middleware processes the request, the request passes back through the prior two middlewares in reverse order for additional processing after their next() statements before leaving the app as a response to the client.](~/fundamentals/middleware/index/_static/request-delegate-pipeline.png)

Each delegate can perform operations before and after the next delegate. Exception-handling delegates should be called early in the pipeline, so they can catch exceptions that occur in later stages of the pipeline.

> [!NOTE]
> To experiment locally with the code examples in this section, create an ASP.NET Core app using the **ASP.NET Core Empty** project template. If using the .NET CLI, the template short name is `web` (`dotnet new web`).

The simplest possible ASP.NET Core app calls <xref:Microsoft.AspNetCore.Builder.RunExtensions.Run%2A> to set up a single terminal middleware request delegate that handles all requests. This case doesn't include an actual request pipeline. Instead, a single anonymous function is called in response to every HTTP request.

In the following example:

* The call to <xref:Microsoft.AspNetCore.Builder.RunExtensions.Run%2A?displayProperty=nameWithType> is invoked on every request and writes ':::no-loc text="Hello world!":::' to the response.
* The call to <xref:Microsoft.AspNetCore.Builder.WebApplication.Run%2A?displayProperty=nameWithType> runs the app and blocks the calling thread until host shutdown.

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

* Two <xref:Microsoft.AspNetCore.Builder.UseExtensions.Use%2A> calls, each writing to the console where work can be performed to write to the response and where work can be performed that doesn't write to the response.
* A terminal request delegate with a call to <xref:Microsoft.AspNetCore.Builder.RunExtensions.Run%2A?displayProperty=nameWithType> that writes ':::no-loc text="Hello world!":::' to the response.
* A final <xref:Microsoft.AspNetCore.Builder.UseExtensions.Use%2A> call, which never executes because it follows the <xref:Microsoft.AspNetCore.Builder.RunExtensions.Run%2A> terminal request delegate.

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use(async (context, next) =>
{
    Console.WriteLine("Work that can write to the response. (1)");
    await next.Invoke();
    Console.WriteLine("Work that doesn't write to the response. (1)");
});

app.Use(async (context, next) =>
{
    Console.WriteLine("Work that can write to the response. (2)");
    await next.Invoke();
    Console.WriteLine("Work that doesn't write to the response. (2)");
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello world!");
});

app.Use(async (context, next) =>
{
    Console.WriteLine("This statement isn't reached. (3)");
    await next.Invoke();
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

When a delegate doesn't pass a request to the next delegate, it's called *short-circuiting the request pipeline*. Short-circuiting is often desirable because it avoids unnecessary work. For example, [Static File Middleware](xref:fundamentals/static-files) can act as a *terminal middleware* by processing a request for a static file and short-circuiting the rest of the pipeline. Middleware added to the pipeline before the middleware that terminates further processing still processes code after their `next.Invoke` statements.

Don't call `next.Invoke` during or after the response has been sent to the client. After an <xref:Microsoft.AspNetCore.Http.HttpResponse> has started, changes result in an exception. For example, [setting headers or a response status code throw an exception](xref:fundamentals/best-practices#do-not-modify-the-status-code-or-headers-after-the-response-body-has-started) after the response starts. Writing to the response body after calling `next`:

* May cause a protocol violation, such as writing more bytes to the response than the stated response's content length (`Content-Length` header value).
* May corrupt the body format, such as writing an HTML footer to a CSS file.

<xref:Microsoft.AspNetCore.Http.HttpResponse.HasStarted%2A> is a useful hint to indicate if headers have been sent or the body has been written to.

For more information, see [Short-circuit middleware after routing](xref:fundamentals/routing#short-circuit-middleware-after-routing).

## `Run` delegates

<xref:Microsoft.AspNetCore.Builder.RunExtensions.Run%2A> delegates don't receive a `next` parameter. The first `Run` delegate always terminates the pipeline. `Run` is also a convention, and some middleware may expose `Run` methods that execute at the end of the pipeline.

Any <xref:Microsoft.AspNetCore.Builder.UseExtensions.Use%2A> or <xref:Microsoft.AspNetCore.Builder.RunExtensions.Run%2A> delegates after the first <xref:Microsoft.AspNetCore.Builder.RunExtensions.Run%2A> delegate aren't called.

## `Use` delegate overload that passes the `HttpContext` to `next` for performance

<!-- DOC AUTHOR NOTE: This section covers API for >=6.0. -->

Use the non-allocating&dagger; <xref:Microsoft.AspNetCore.Builder.IApplicationBuilder.Use%2A> extension method for a performance benefit:

* Requires passing the <xref:Microsoft.AspNetCore.Http.HttpContext> to `next`.
* Saves two internal per-request allocations that are required when using the overload without passing the <xref:Microsoft.AspNetCore.Http.HttpContext> to `next`.

> [!NOTE]
> &dagger;*Non-allocating* means that the framework avoids creating objects in memory during execution that must be disposed later.

```csharp
app.Use(async (context, next) =>
{
    Console.WriteLine("Work that doesn't write to the response.");
    await next.Invoke(context);
    Console.WriteLine("Work that doesn't write to the response.");
});
```

## Middleware order

The following diagram shows the complete request processing pipeline for ASP.NET Core MVC and Razor Pages apps. You can see how, in a typical app, existing middlewares are ordered and where custom middlewares are added. You have full control over how to reorder existing middlewares or inject new custom middlewares as necessary for your scenarios.

![ASP.NET Core middleware pipeline](~/fundamentals/middleware/index/_static/middleware-pipeline.svg)

<!-- 
See mermaid diagrams in https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/middleware/index/includes

Install CLI mermaid to make SVGs
npm install -g mermaid-cli

remove ```mermaid and closing ```
mermaid -s x.md
preceding creates the x.md.svg file

![ASP.NET SVG  middleware pipeline](~/fundamentals/middleware/index/includes/x.md.svg)
Line 85: [Warning] File 'fundamentals/middleware/index/includes/x.md.svg' referenced by link '~/fundamentals/middleware/index/includes/x.md.svg' will not be built because it is not included in build scope.
-->

Endpoint Middleware in the preceding diagram executes the filter pipeline for the corresponding app type&mdash;MVC or Razor Pages.

Routing Middleware in the preceding diagram is shown following Static File Middleware. This is the order that the project templates implement by explicitly calling <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A>. If you don't call <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A>, the Routing Middleware runs at the beginning of the pipeline by default. For more information, see <xref:fundamentals/routing>.

The order that middleware are added in the `Program.cs` file defines the order in which the middleware are invoked on requests and the reverse order for the response. The order is **critical** for security, performance, and functionality.

The following highlighted code in `Program.cs` adds security-related middleware in the typical recommended order:

```csharp
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebMiddleware.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
// app.UseCookiePolicy();

app.UseRouting();
// app.UseRateLimiter();
// app.UseRequestLocalization();
// app.UseCors();

app.UseAuthentication();
app.UseAuthorization();
// app.UseSession();
// app.UseResponseCompression();
// app.UseResponseCaching();

app.MapRazorPages();
app.MapDefaultControllerRoute();

app.Run();
```

In the preceding code:

* The commented out middleware isn't added when creating a new web app with [individual users accounts](xref:security/authentication/identity).
* Not every middleware appears in this exact order, but many do. For example:
  * CORS Middleware (<xref:Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions.UseCors%2A>), Authentication Middleware (<xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A>), and Authorization Middleware (<xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A>) must appear in the order shown.
  * CORS Middleware (<xref:Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions.UseCors%2A>) must appear before Response Caching Middleware (<xref:Microsoft.AspNetCore.Builder.ResponseCachingExtensions.UseResponseCaching%2A>) to add CORS headers on every request to include cached responses. For more information, see [It is not clear that UseCORS must come before UseResponseCaching (`dotnet/aspnetcore` #23218](https://github.com/dotnet/aspnetcore/issues/23218).
  * Request Localization Middleware (<xref:Microsoft.AspNetCore.Builder.ApplicationBuilderExtensions.UseRequestLocalization%2A>) must appear before any middleware that might check the request culture, for example, Static File Middleware (<xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>).
  * Rate Limiting Middleware (<xref:Microsoft.AspNetCore.Builder.RateLimiterApplicationBuilderExtensions.UseRateLimiter%2A>) must be called after Routing Middleware (<xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A>) when rate limiting endpoint specific APIs are used. For example, if the [`[EnableRateLimiting]` attribute](xref:Microsoft.AspNetCore.RateLimiting.EnableRateLimitingAttribute) is used, Rate Limiting Middleware must be called after Routing Middleware. When calling only global limiters, Rate Limiting Middleware can be called before Routing Middleware.

In some scenarios, middleware has different ordering. For example, caching and compression ordering is scenario specific, and there are multiple valid orderings. In the following order, CPU usage could be reduced by caching the compressed response, but the app might end up caching multiple representations of a resource using different compression algorithms, such as Gzip or Brotli:

```csharp
app.UseResponseCaching();
app.UseResponseCompression();
```

The following ordering includes Static File Middleware to allow caching compressed static files:

```csharp
app.UseResponseCaching();
app.UseResponseCompression();
app.UseStaticFiles();
```

The following example adds middleware for common app scenarios. Each middleware extension method is exposed on <xref:Microsoft.AspNetCore.Builder.WebApplicationBuilder> through the <xref:Microsoft.AspNetCore.Builder?displayProperty=fullName> namespace:

1. Exception/error handling
   * When the app runs in the `Development` environment:
     * Developer Exception Page Middleware (<xref:Microsoft.AspNetCore.Builder.DeveloperExceptionPageExtensions.UseDeveloperExceptionPage%2A>) reports app runtime errors.
     * Database Error Page Middleware (<xref:Microsoft.AspNetCore.Builder.DatabaseErrorPageExtensions.UseDatabaseErrorPage%2A>) reports database runtime errors.
   * When the app runs in the `Production` environment:
     * Exception Handler Middleware (<xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A>) catches exceptions thrown in the following middlewares.
     * HTTP Strict Transport Security Protocol (HSTS) Middleware (<xref:Microsoft.AspNetCore.Builder.HstsBuilderExtensions.UseHsts%2A>) adds the `Strict-Transport-Security` header.
1. HTTPS Redirection Middleware (<xref:Microsoft.AspNetCore.Builder.HttpsPolicyBuilderExtensions.UseHttpsRedirection%2A>) redirects HTTP requests to HTTPS.
1. Static File Middleware (<xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A>) returns static files and short-circuits further request processing.
1. Cookie Policy Middleware (<xref:Microsoft.AspNetCore.Builder.CookiePolicyAppBuilderExtensions.UseCookiePolicy%2A>) conforms the app to the EU General Data Protection Regulation (GDPR) regulations.
1. Routing Middleware (<xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A>) to route requests.
1. Authentication Middleware (<xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A>) attempts to authenticate the user before they're allowed access to secure resources.
1. Authorization Middleware (<xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A>) authorizes a user to access secure resources.
1. Session Middleware (<xref:Microsoft.AspNetCore.Builder.SessionMiddlewareExtensions.UseSession%2A>) establishes and maintains session state. If the app uses session state, call Session Middleware after Cookie Policy Middleware and before MVC Middleware.
1. Endpoint Routing Middleware (<xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseEndpoints%2A> with <xref:Microsoft.AspNetCore.Builder.RazorPagesEndpointRouteBuilderExtensions.MapRazorPages%2A>) to add Razor Pages endpoints to the request pipeline.

```csharp
if (env.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseDatabaseErrorPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();
app.MapRazorPages();
```

Static File Middleware is called early in the pipeline so that it can handle static file requests and short-circuit to avoid processing remaining middlewares. The Static File Middleware provides **no** authorization checks. Served files, including those under `wwwroot`, are publicly available. For an approach to secure static files, see <xref:fundamentals/static-files#static-file-authorization>.

If the request isn't handled by Static File Middleware, it's passed on to Authentication Middleware (<xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A>), which performs authentication. Authentication doesn't short-circuit unauthenticated requests. Although Authentication Middleware authenticates requests, authorization (and rejection) occurs only after Blazor selects a Razor component, Razor Pages page, or MVC controller and action are selected for execution/rendering.

The following example demonstrates a middleware order where requests for static files are handled by Static File Middleware before Response Compression Middleware, so static files aren't compressed. Static files aren't compressed with this middleware order. Response content after Response Compression Middleware can be compressed.

```csharp
app.UseStaticFiles();
app.UseRouting();
app.UseResponseCompression();
```

## `UseCors` and `UseStaticFiles` order

The order for calling <xref:Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions.UseCors%2A> and <xref:Microsoft.AspNetCore.Builder.StaticFileExtensions.UseStaticFiles%2A> depends on the app. For more information, see [`UseCors` and `UseStaticFiles` order](xref:security/cors#usecors-and-usestaticfiles-order).

### Forwarded Headers Middleware order

Run Forwarded Headers Middleware before other middleware to ensure that the middleware relying on forwarded headers information can consume the header values for processing. To run Forwarded Headers Middleware after Diagnostics and Error Handling Middleware, see [Forwarded Headers Middleware order](xref:host-and-deploy/proxy-load-balancer#forwarded-headers-middleware-order).

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

static void HandleMap1(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Map 1");
    });
}

static void HandleMap2(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Map 2");
    });
}
```

The following table shows the requests and responses using the preceding code.

Request   | Response
--------- | ----------------------------------------------------
`/`       | :::no-loc text="Hello from the non-Map delegate.":::
`/map1`   | :::no-loc text="Map 1":::
`/map2`   | :::no-loc text="Map 2":::
`/map3`   | :::no-loc text="Hello from the non-Map delegate.":::

When <xref:Microsoft.AspNetCore.Builder.MapExtensions.Map%2A> is used, the matched path segments are removed from <xref:Microsoft.AspNetCore.Http.HttpRequest.Path%2A?displayProperty=nameWithType> and appended to <xref:Microsoft.AspNetCore.Http.HttpRequest.PathBase%2A?displayProperty=nameWithType> for each request.

<xref:Microsoft.AspNetCore.Builder.MapExtensions.Map%2A> supports nesting, for example:

```csharp
app.Map("/level1", level1App => {
    level1App.Map("/level2a", level2AApp => {
        // "/level1/level2a" processing
    });
    level1App.Map("/level2b", level2BApp => {
        // "/level1/level2b" processing
    });
});
```

<xref:Microsoft.AspNetCore.Builder.MapExtensions.Map%2A> can also match multiple segments at once:

```csharp
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/map1/seg1", HandleMultiSeg);

app.Run(async context =>
{
    await context.Response.WriteAsync("Hello from the non-Map delegate.");
});

app.Run();

static void HandleMultiSeg(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        await context.Response.WriteAsync("Map 1 - Segment 1");
    });
}
```

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

static void HandleBranch(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        var branchVer = context.Request.Query["branch"];
        await context.Response.WriteAsync($"Branch used = {branchVer}");
    });
}
```

The following table shows the requests and responses using the previous code:

Request | Response
--- | ---
`/` | :::no-loc text="Hello from the non-Map delegate.":::
`/?branch=main` | :::no-loc text="Branch used = main":::

<xref:Microsoft.AspNetCore.Builder.UseWhenExtensions.UseWhen%2A> also branches the request pipeline based on the result of the given predicate. Unlike when calling <xref:Microsoft.AspNetCore.Builder.MapWhenExtensions.MapWhen%2A>, this branch is rejoined to the main pipeline if it doesn't contain a terminal middleware:

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
        logger.LogInformation("Branch used = {branchVer}", branchVer);

        Console.WriteLine("Work that can write to the response.");
        await next.Invoke();
        Console.WriteLine("Work that doesn't write to the response.");
    });
}
```

In the preceding example, a response of ':::no-loc text="Hello from the non-Map delegate.":::' is written for all requests. If the request includes a query string variable named "`branch`," its value is logged before the main pipeline is rejoined.

## Built-in middleware

ASP.NET Core ships with the following middleware. The *Order* column provides notes on middleware placement in the request processing pipeline and under what conditions the middleware may terminate request processing. When a middleware short-circuits the request processing pipeline and prevents further downstream middleware from processing a request, it's called a *terminal middleware*. For more information on short-circuiting, see the [Create a middleware pipeline with `WebApplication`](#create-a-middleware-pipeline-with-webapplication) section.

Middleware | Description | Order
--- | --- | ---
[Antiforgery](xref:security/anti-request-forgery) | Provides anti-request-forgery support. | After authentication and authorization, before endpoints.
[Authentication](xref:security/authentication/identity) | Provides authentication support. | Before `HttpContext.User` is needed. Terminal for OAuth callbacks.
[Authorization](xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A) | Provides authorization support. | Immediately after the Authentication Middleware.
[Cookie Policy](xref:security/gdpr) | Tracks consent from users for storing personal information and enforces minimum standards for cookie fields, such as `secure` and `SameSite`. | Before middleware that issues cookies. Examples: Authentication, Session, MVC (TempData).
[CORS](xref:security/cors) | Configures Cross-Origin Resource Sharing. | Before middleware that use CORS. <xref:Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions.UseCors%2A> must go before <xref:Microsoft.AspNetCore.Builder.ResponseCachingExtensions.UseResponseCaching%2A>. For more information, see [It is not clear that UseCORS must come before UseResponseCaching (`dotnet/aspnetcore` #23218](https://github.com/dotnet/aspnetcore/issues/23218).
[DeveloperExceptionPage](xref:Microsoft.AspNetCore.Diagnostics.DeveloperExceptionPageMiddleware) | Generates a page with error information that is intended for use only in the `Development` environment. | Before middleware that generate errors. The project templates automatically register this middleware as the first middleware in the pipeline when the environment is `Development`.
[Diagnostics](xref:fundamentals/error-handling) | Several separate middlewares that provide a developer exception page, exception handling, status code pages, and the default web page for new apps. | Before middleware that generate errors. Terminal for exceptions or serving the default web page for new apps.
[Forwarded Headers](xref:host-and-deploy/proxy-load-balancer) | Forwards proxied headers onto the current request. | Before middleware that consume the updated fields. Examples: scheme, host, client IP, method.
[Health Check](xref:host-and-deploy/health-checks) | Checks the health of an ASP.NET Core app and its dependencies, such as checking database availability. | Terminal if a request matches a health check endpoint.
[Header Propagation](xref:fundamentals/http-requests#header-propagation-middleware) | Propagates HTTP headers from the incoming request to the outgoing HTTP Client requests.
[HTTP Logging](xref:fundamentals/http-logging/index) | Logs HTTP Requests and Responses. | At the beginning of the middleware pipeline. 
[HTTP Method Override](xref:Microsoft.AspNetCore.Builder.HttpMethodOverrideExtensions) | Allows an incoming POST request to override the method. | Before middleware that consume the updated method.
[HTTPS Redirection](xref:security/enforcing-ssl#require-https) | Redirect all HTTP requests to HTTPS. | Before middleware that consume the URL.
[HTTP Strict Transport Security (HSTS)](xref:security/enforcing-ssl#http-strict-transport-security-protocol-hsts) | Security enhancement middleware that adds a special response header. | Before responses are sent and after middleware that modify requests. Examples: Forwarded Headers, URL Rewriting.
[MVC](xref:mvc/overview) | Processes requests with MVC/Razor Pages. | Terminal if a request matches a route.
[OWIN](xref:fundamentals/owin) | Interop with OWIN-based apps, servers, and middleware. | Terminal if the OWIN Middleware fully processes the request.
[Output Caching](xref:performance/caching/output) | Provides support for caching responses based on configuration. | Before middleware that require caching. <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A> must come before `UseOutputCaching`. <xref:Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions.UseCors%2A> must come before `UseOutputCaching`.
[Response Caching](xref:performance/caching/middleware) | Provides support for caching responses. This requires client participation to work. Use output caching for complete server control. | Before middleware that require caching. <xref:Microsoft.AspNetCore.Builder.CorsMiddlewareExtensions.UseCors%2A> must come before <xref:Microsoft.AspNetCore.Builder.ResponseCachingExtensions.UseResponseCaching%2A>. Response caching isn't typically beneficial for UI apps, such as Razor Pages, because browsers generally set request headers that prevent caching. [Output caching](xref:performance/caching/output) benefits UI apps.
[Request Decompression](xref:fundamentals/middleware/request-decompression) | Provides support for decompressing requests. | Before middleware that read the request body.
[Response Compression](xref:performance/response-compression) | Provides support for compressing responses. | Before middleware that require compression.
[Request Localization](xref:fundamentals/localization) | Provides localization support. | Before localization sensitive middleware. Must appear after Routing Middleware when using <xref:Microsoft.AspNetCore.Localization.Routing.RouteDataRequestCultureProvider>.
[Request Timeouts](xref:performance/timeouts) | Provides support for configuring request timeouts, global and per endpoint. | <xref:Microsoft.AspNetCore.Builder.RequestTimeoutsIApplicationBuilderExtensions.UseRequestTimeouts%2A> must come after <xref:Microsoft.AspNetCore.Builder.ExceptionHandlerExtensions.UseExceptionHandler%2A>, <xref:Microsoft.AspNetCore.Builder.DeveloperExceptionPageExtensions.UseDeveloperExceptionPage%2A>, and <xref:Microsoft.AspNetCore.Builder.EndpointRoutingApplicationBuilderExtensions.UseRouting%2A>.
[Endpoint Routing](xref:fundamentals/routing) | Defines and constrains request routes. | Terminal for matching routes.
[SPA](xref:Microsoft.AspNetCore.Builder.SpaApplicationBuilderExtensions.UseSpa%2A) | Handles all requests from this point in the middleware chain by returning the default page for the Single Page Application (SPA) | Appears late in the pipeline, so that other middleware for serving static files, such as MVC actions, take precedence.
[Session](xref:fundamentals/app-state) | Provides support for managing user sessions. | Before middleware that require Session.
[Static Files](xref:fundamentals/static-files) | Provides support for serving static files and directory browsing. | Terminal if a request matches a file.
[URL Rewrite](xref:fundamentals/url-rewriting) | Provides support for rewriting URLs and redirecting requests. | Before middleware that consume the URL.
[W3CLogging](xref:fundamentals/w3c-logger/index) | Generates server access logs in the [W3C Extended Log File Format](https://www.w3.org/TR/WD-logfile.html). | At the beginning of the middleware pipeline.
[WebSockets](xref:fundamentals/websockets) | Enables the WebSockets protocol. | Before middleware that are required to accept WebSocket requests.

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
