---
title: Migrate HTTP handlers to ASP.NET Core middleware
description: Migrate HTTP handlers to ASP.NET Core middleware
author: twsouthwick
ms.author: tasou
ms.date: 6/20/2025
uid: migration/fx-to-core/areas/http-handlers
---
# Migrate HTTP handlers to ASP.NET Core middleware

This article shows how to migrate existing ASP.NET [HTTP handlers from system.webserver](/iis/configuration/system.webserver/) to ASP.NET Core [middleware](xref:fundamentals/middleware/index).

## Handlers revisited

Before proceeding to ASP.NET Core middleware, let's first recap how HTTP handlers work:

![Modules Handler](_static/moduleshandlers.png)

**Handlers are:**

* Classes that implement <xref:System.Web.IHttpHandler>

* Used to handle requests with a given file name or extension, such as *.report*

* [Configured](/iis/configuration/system.webserver/handlers/) in *Web.config*

## From handlers to middleware

**Middleware are simpler than HTTP handlers:**

* Handlers, *Web.config* (except for IIS configuration) and the application life cycle are gone

* The roles of handlers have been taken over by middleware

* Middleware are configured using code rather than in *Web.config*

:::moniker range=">= aspnetcore-3.0"

* [Pipeline branching](xref:fundamentals/middleware/index#branch-the-middleware-pipeline) lets you send requests to specific middleware, based on not only the URL but also on request headers, query strings, etc.

:::moniker-end
:::moniker range="< aspnetcore-3.0"

* [Pipeline branching](xref:fundamentals/middleware/index#branch-the-middleware-pipeline) lets you send requests to specific middleware, based on not only the URL but also on request headers, query strings, etc.

:::moniker-end

**Middleware are very similar to handlers:**

* Able to create their own HTTP response

![Authorization Middleware short-circuits a request for a user who isn't authorized. A request for the Index page is permitted and processed by MVC Middleware. A request for a sales report is permitted and processed by a custom report Middleware.](_static/middleware.png)

## Migrating handler code to middleware

An HTTP handler looks something like this:

[!code-csharp[](./sample/Asp.Net4/Asp.Net4/HttpHandlers/ReportHandler.cs?highlight=5,7,13,14,15,16)]

In your ASP.NET Core project, you would translate this to a middleware similar to this:

[!code-csharp[](./sample/Asp.Net.Core/Middleware/ReportHandlerMiddleware.cs?highlight=7,9,13,20,21,22,23,40,42,44)]

This middleware is very similar to the middleware corresponding to modules. The only real difference is that here there's no call to `_next.Invoke(context)`. That makes sense, because the handler is at the end of the request pipeline, so there will be no next middleware to invoke.

## Migrating handler insertion into the request pipeline

Configuring an HTTP handler is done in *Web.config* and looks something like this:

[!code-xml[](./sample/Asp.Net4/Asp.Net4/Web.config?highlight=6&range=1-3,32,46-48,50,101)]

You could convert this by adding your new handler middleware to the request pipeline in your `Startup` class, similar to middleware converted from modules. The problem with that approach is that it would send all requests to your new handler middleware. However, you only want requests with a given extension to reach your middleware. That would give you the same functionality you had with your HTTP handler.

One solution is to branch the pipeline for requests with a given extension, using the `MapWhen` extension method. You do this in the same `Configure` method where you add the other middleware:

[!code-csharp[](./sample/Asp.Net.Core/Startup.cs?name=snippet_Configure&highlight=27-34)]

`MapWhen` takes these parameters:

1. A lambda that takes the `HttpContext` and returns `true` if the request should go down the branch. This means you can branch requests not just based on their extension, but also on request headers, query string parameters, etc.

2. A lambda that takes an `IApplicationBuilder` and adds all the middleware for the branch. This means you can add additional middleware to the branch in front of your handler middleware.

Middleware added to the pipeline before the branch will be invoked on all requests; the branch will have no impact on them.

## Loading middleware options using the options pattern

Some handlers have configuration options that are stored in *Web.config*. However, in ASP.NET Core a new configuration model is used in place of *Web.config*.

The new [configuration system](xref:fundamentals/configuration/index) gives you these options to solve this:

* Directly inject the options into the middleware, as shown in the [next section](#loading-middleware-options-through-direct-injection).

* Use the [options pattern](xref:fundamentals/configuration/options):

1. Create a class to hold your middleware options, for example:

   [!code-csharp[](sample/Asp.Net.Core/Middleware/MyMiddlewareWithParams.cs?name=snippet_Options)]

2. Store the option values

   The configuration system allows you to store option values anywhere you want. However, most sites use `appsettings.json`, so we'll take that approach:

   [!code-json[](sample/Asp.Net.Core/appsettings.json?range=1,14-18)]

   *MyMiddlewareOptionsSection* here is a section name. It doesn't have to be the same as the name of your options class.

3. Associate the option values with the options class

    The options pattern uses ASP.NET Core's dependency injection framework to associate the options type (such as `MyMiddlewareOptions`) with a `MyMiddlewareOptions` object that has the actual options.

    Update your `Startup` class:

   1. If you're using `appsettings.json`, add it to the configuration builder in the `Startup` constructor:

      [!code-csharp[](./sample/Asp.Net.Core/Startup.cs?name=snippet_Ctor&highlight=5-6)]

   2. Configure the options service:

      [!code-csharp[](./sample/Asp.Net.Core/Startup.cs?name=snippet_ConfigureServices&highlight=4)]

   3. Associate your options with your options class:

      [!code-csharp[](./sample/Asp.Net.Core/Startup.cs?name=snippet_ConfigureServices&highlight=6-8)]

4. Inject the options into your middleware constructor. This is similar to injecting options into a controller.

   [!code-csharp[](./sample/Asp.Net.Core/Middleware/MyMiddlewareWithParams.cs?name=snippet_MiddlewareWithParams&highlight=4,7,10,15-16)]

   The `UseMiddleware` extension method that adds your middleware to the `IApplicationBuilder` takes care of dependency injection.

   This isn't limited to `IOptions` objects. Any other object that your middleware requires can be injected this way.

## Loading middleware options through direct injection

The options pattern has the advantage that it creates loose coupling between options values and their consumers. Once you've associated an options class with the actual options values, any other class can get access to the options through the dependency injection framework. There's no need to pass around options values.

This breaks down though if you want to use the same middleware twice, with different options. For example an authorization middleware used in different branches allowing different roles. You can't associate two different options objects with the one options class.

The solution is to get the options objects with the actual options values in your `Startup` class and pass those directly to each instance of your middleware.

1. Add a second key to `appsettings.json`

   To add a second set of options to the `appsettings.json` file, use a new key to uniquely identify it:

   [!code-json[](sample/Asp.Net.Core/appsettings.json?range=1,10-18&highlight=2-5)]

2. Retrieve options values and pass them to middleware. The `Use...` extension method (which adds your middleware to the pipeline) is a logical place to pass in the option values: 

   [!code-csharp[](sample/Asp.Net.Core/Startup.cs?name=snippet_Configure&highlight=20-23)]

3. Enable middleware to take an options parameter. Provide an overload of the `Use...` extension method (that takes the options parameter and passes it to `UseMiddleware`). When `UseMiddleware` is called with parameters, it passes the parameters to your middleware constructor when it instantiates the middleware object.

   [!code-csharp[](./sample/Asp.Net.Core/Middleware/MyMiddlewareWithParams.cs?name=snippet_Extensions&highlight=9-14)]

   Note how this wraps the options object in an `OptionsWrapper` object. This implements `IOptions`, as expected by the middleware constructor.

## Migrating to the new HttpContext

The `Invoke` method in your middleware takes a parameter of type `HttpContext`:

```csharp
public async Task Invoke(HttpContext context)
```

`HttpContext` has significantly changed in ASP.NET Core. For detailed information on how to translate the most commonly used properties of `System.Web.HttpContext` to the new `Microsoft.AspNetCore.Http.HttpContext`, see [Migrate from ASP.NET Framework HttpContext to ASP.NET Core](httpcontext.md).

## Additional resources

* [HTTP Handlers and HTTP Modules Overview](/iis/configuration/system.webserver/)
* [Configuration](xref:fundamentals/configuration/index)
* [Application Startup](xref:fundamentals/startup)
* [Middleware](xref:fundamentals/middleware/index)
* [Migrate from ASP.NET Framework HttpContext to ASP.NET Core](httpcontext.md)
