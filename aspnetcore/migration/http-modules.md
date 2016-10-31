---
title: Migrating HTTP Modules to Middleware
author: rick-anderson
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 9c826a76-fbd2-46b5-978d-6ca6df53531a
ms.prod: aspnet-core
uid: migration/http-modules
---
# Migrating HTTP Modules to Middleware

>[!WARNING]
> This page documents version 1.0.0-rc1 and has not yet been updated for version 1.0.0

By [Matt Perdeck](http://www.linkedin.com/in/mattperdeck)

This article shows how to migrate existing ASP.NET [HTTP modules and handlers](https://msdn.microsoft.com/en-us/library/bb398986.aspx) to ASP.NET Core [middleware](../fundamentals/middleware.md#fundamentals-middleware).

## Handlers and modules revisited

Before proceeding to ASP.NET Core middleware, let's first recap how HTTP modules and handlers work:

![image](http-modules/_static/moduleshandlers.png)

**Handlers are:**

   * Classes that implement [IHttpHandler](https://msdn.microsoft.com/en-us/library/system.web.ihttphandler(v=vs.100).aspx)

   * Used to handle requests with a given file name or extension, such as *.report*

   * [Configured](https://msdn.microsoft.com/en-us/library/46c5ddfy(v=vs.100).aspx) in *Web.config*

**Modules are:**

   * Classes that implement [IHttpModule](https://msdn.microsoft.com/en-us/library/system.web.ihttpmodule(v=vs.100).aspx)

   * Invoked for every request

   * Able to short-circuit (stop further processing of a request)

   * Able to add to the HTTP response, or create their own

   * [Configured](https://msdn.microsoft.com/en-us/library/ms227673(v=vs.100).aspx) in *Web.config*

**The order in which modules process incoming requests is determined by:**

   1. The [application life cycle](https://msdn.microsoft.com/en-us/library/ms227673(v=vs.100).aspx), which is a series events fired by ASP.NET: [BeginRequest](https://msdn.microsoft.com/en-us/library/system.web.httpapplication.beginrequest(v=vs.100).aspx), [AuthenticateRequest](https://msdn.microsoft.com/en-us/library/system.web.httpapplication.authenticaterequest(v=vs.100).aspx), etc. Each module can create a handler for one or more events.

   2. For the same event, the order in which they are configured in *Web.config*.

In addition to modules, you can add handlers for the life cycle events to your *Global.asax.cs* file. These handlers run after the handlers in the configured modules.

## From handlers and modules to middleware

**Middleware are simpler than HTTP modules and handlers:**

   * Modules, handlers, *Global.asax.cs*, *Web.config* (except for IIS configuration) and the application life cycle are gone

   * The roles of both modules and handlers have been taken over by middleware

   * Middleware are configured using code rather than in *Web.config*

   * [Pipeline branching](../fundamentals/middleware.md#middleware-run-map-use) lets you send requests to specific middleware, based on not only the URL but also on request headers, query strings, etc.

**Middleware are very similar to modules:**

   * Invoked in principle for every request

   * Able to short-circuit a request, by [not passing the request to the next middleware](xref:migration/http-modules#http-modules-shortcircuiting-middleware)

   * Able to create their own HTTP response

**Middleware and modules are processed in a different order:**

   * Order of middleware is based on the order in which they are inserted into the request pipeline, while order of modules is mainly based on [application life cycle](https://msdn.microsoft.com/en-us/library/ms227673(v=vs.100).aspx) events

   * Order of middleware for responses is the reverse from that for requests, while order of modules is the same for requests and responses

   * See [Creating a middleware pipeline with IApplicationBuilder](../fundamentals/middleware.md#creating-a-middleware-pipeline-with-iapplicationbuilder)

![image](http-modules/_static/middleware.png)

Note how in the image above, the authentication middleware short-circuited the request.

## Migrating module code to middleware

An existing HTTP module will look similar to this:

[!code-csharp[Main](../migration/http-modules/sample/Asp.Net4/Asp.Net4/Modules/MyModule.cs?highlight=6,8,24,31)]

As shown in the [Middleware](../fundamentals/middleware.md) page, an ASP.NET Core middleware is simply a class that exposes an `Invoke` method taking an `HttpContext` and returning a `Task`. Your new middleware will look like this:

<a name=http-modules-usemiddleware></a>

[!code-csharp[Main](../migration/http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/MyMiddleware.cs?highlight=9,13,20,24,28,30,32)]

The above middleware template was taken from the section on [writing middleware](../fundamentals/middleware.md#middleware-writing-middleware).

The *MyMiddlewareExtensions* helper class makes it easier to configure your middleware in your `Startup` class. The `UseMyMiddleware` method adds your middleware class to the request pipeline. Services required by the middleware get injected in the middleware's constructor.

<a name=http-modules-shortcircuiting-middleware></a>

Your module might terminate a request, for example if the user is not authorized:

[!code-csharp[Main](../migration/http-modules/sample/Asp.Net4/Asp.Net4/Modules/MyTerminatingModule.cs?highlight=9,10,11,12,13&range=18-31)]

A middleware handles this by simply not calling `Invoke` on the next middleware in the pipeline. Keep in mind that this does not fully terminate the request, because previous middlewares will still be invoked when the response makes its way back through the pipeline.

[!code-csharp[Main](../migration/http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/MyTerminatingMiddleware.cs?highlight=7,8&range=16-26)]

When you migrate your module's functionality to your new middleware, you may find that your code doesn't compile because the `HttpContext` class has significantly changed in ASP.NET Core. [Later on](#migrating-to-the-new-httpcontext), you'll see how to migrate to the new ASP.NET Core HttpContext.

## Migrating module insertion into the request pipeline

HTTP modules are typically added to the request pipeline using *Web.config*:

[!code-xml[Main](../migration/http-modules/sample/Asp.Net4/Asp.Net4/Web.config?highlight=6&range=1-3,32-33,36,43,50,101)]

Convert this by [adding your new middleware](../fundamentals/middleware.md#creating-a-middleware-pipeline-with-iapplicationbuilder) to the request pipeline in your `Startup` class:

[!code-csharp[Main](../migration/http-modules/sample/Asp.Net5/src/Asp.Net5/Startup.cs?highlight=12&range=1-2,12-15,46-48,54-58,105,109,110)]

The exact spot in the pipeline where you insert your new middleware depends on the event that it handled as a module (`BeginRequest`, `EndRequest`, etc.) and its order in your list of modules in *Web.config*.

As previously stated, there is no more application life cycle in ASP.NET Core and the order in which responses are processed by middleware differs from the order used by modules. This could make your ordering decision more  challenging.

If ordering becomes a problem, you could split your module into multiple middleware that can be ordered independently.

## Migrating handler code to middleware

An HTTP handler looks something like this:

[!code-csharp[Main](../migration/http-modules/sample/Asp.Net4/Asp.Net4/HttpHandlers/ReportHandler.cs?highlight=5,7,13,14,15,16&range=1-19,31-32)]

In your ASP.NET Core project, you would translate this to a middleware similar to this:

[!code-csharp[Main](../migration/http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/ReportHandlerMiddleware.cs?highlight=7,9,13,20,21,22,23,29,31,33&range=1-26,38-47)]

This middleware is very similar to the middleware corresponding to modules. The only real difference is that here there is no call to `_next.Invoke(context)`. That makes sense, because the handler is at the end of the request pipeline, so there will be no next middleware to invoke.

## Migrating handler insertion into the request pipeline

Configuring an HTTP handler is done in *Web.config* and looks something like this:

[!code-xml[Main](../migration/http-modules/sample/Asp.Net4/Asp.Net4/Web.config?highlight=6&range=1-3,32,46-48,50,101)]

You could convert this by adding your new handler middleware to the request pipeline in your `Startup` class, similar to middleware converted from modules. The problem with that approach is that it would send all requests to your new handler middleware. However, you only want requests with a given extension to reach your middleware. That would give you the same functionality you had with your HTTP handler.

One solution is to branch the pipeline for requests with a given extension, using the `MapWhen` extension method. You do this in the same `Configure` method where you add the other middleware:

[!code-csharp[Main](../migration/http-modules/sample/Asp.Net5/src/Asp.Net5/Startup.cs?highlight=12,13,14,15,16,17&range=1-2,12-15,46-48,54-55,82-87,105,109,110)]

`MapWhen` takes these parameters:

1. A lambda that takes the `HttpContext` and returns `true` if the request should go down the branch. This means you can branch requests not just based on their extension, but also on request headers, query string parameters, etc.

2. A lambda that takes an `IApplicationBuilder` and adds all the middleware for the branch. This means you can add additional middleware to the branch in front of your handler middleware.

Middleware added to the pipeline before the branch will be invoked on all requests; the branch will have no impact on them.

## Loading middleware options using the options pattern

Some modules and handlers have configuration options that are stored in *Web.config*. However, in ASP.NET Core a new configuration model is used in place of *Web.config*.

The new [configuration system](../fundamentals/configuration.md) gives you these options to solve this:

* Directly inject the options into the middleware, as shown in the [next section](xref:migration/http-modules#loading-middleware-options-through-direct-injection).

* Use the [options pattern](../fundamentals/configuration.md#options-config-objects):

1.  Create a class to hold your middleware options, for example:

    [!code-csharp[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/MyMiddlewareWithParams.cs?range=8-12)]

2.  Store the option values

    The new configuration system allows you to essentially store option values anywhere you want. However, most sites use *appsettings.json*, so we'll take that approach:

    [!code-json[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/appsettings.json?range=1,6-10)]

    *MyMiddlewareOptionsSection* here is simply a section name. It doesn't have to be the same as the name of your options class.

3. Associate the option values with the options class

    The options pattern uses ASP.NET Core's dependency injection framework to associate the options type (such as `MyMiddlewareOptions`) with an `MyMiddlewareOptions` object that has the actual options.

    Update your `Startup` class:

    1.  If you're using *appsettings.json*, add it to the configuration builder in the `Startup` constructor:

        [!code-csharp[Main](../migration/http-modules/sample/Asp.Net5/src/Asp.Net5/Startup.cs?highlight=7&range=14-23,106,109)]

    2.  Configure the options service:

        [!code-csharp[Main](../migration/http-modules/sample/Asp.Net5/src/Asp.Net5/Startup.cs?highlight=5&range=14-15,28-29,31-33,43,109)]

    3.  Associate your options with your options class:

        [!code-csharp[Main](../migration/http-modules/sample/Asp.Net5/src/Asp.Net5/Startup.cs?highlight=7,8&range=14-15,28-29,31-32,36-39,43,109)]

4.  Inject the options into your middleware constructor. This is similar to injecting options into a controller.

    [!code-csharp[Main](../migration/http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/MyMiddlewareWithParams.cs?highlight=7,10,13,19,24&range=6-7,24-47)]

    The [UseMiddleware](#http-modules-usemiddleware) extension method that adds your middleware to the `IApplicationBuilder` takes care of dependency injection.

    This is not limited to `IOptions` objects. Any other object that your middleware requires can be injected this way.

<a name=loading-middleware-options-through-direct-injection></a>

## Loading middleware options through direct injection

The options pattern has the advantage that it creates loose coupling between options values and their consumers. Once you've associated an options class with the actual options values, any other class can get access to the options through the dependency injection framework. There is no need to pass around options values.

This breaks down though if you want to use the same middleware twice, with different options. For example an authorization middleware used in different branches allowing different roles. You can't associate two different options objects with the one options class.

The solution is to get the options objects with the actual options values in your `Startup` class and pass those directly to each instance of your middleware.

1.  Add a second key to *appsettings.json*

    To add a second set of options to the *appsettings.json* file, simply use a new key to uniquely identify it:

    [!code-json[Main](../migration/http-modules/sample/Asp.Net5/src/Asp.Net5/appsettings.json?highlight=2,3,4,5)]

2.  Retrieve options values. The `Get` method on the `Configuration` property lets you retrieve options values:

    [!code-csharp[Main](../migration/http-modules/sample/Asp.Net5/src/Asp.Net5/Startup.cs?highlight=12,13,14,15,16&range=1-2,12-15,46-48,54-55,62-66,67,70,71,105,109,110)]

3.  Pass options values to middleware. The `Use...` extension method (which adds your middleware to the pipeline) is a logical place to pass in the option values: 

    [!code-csharp[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/Startup.cs?highlight=18-22&range=1-2,12-15,46-48,54-55,62-72,105,109,110)]

4.  Enable middleware to take an options parameter. Provide an overload of the `Use...` extension method (that takes the options parameter and passes it to `UseMiddleware`). When `UseMiddleware` is called with parameters, it passes the parameters to your middleware constructor when it instantiates the middleware object.

    [!code-csharp[Main](../migration/http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/MyMiddlewareWithParams.cs?highlight=17,18,19,20,21,22&range=1-7,48-64)]

    Note how this wraps the options object in an `OptionsWrapper` object. This implements `IOptions`, as expected by the middleware constructor:

    [!code-csharp[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/MyMiddlewareWithParams.cs?range=14-23)]

## Migrating to the new HttpContext

You saw earlier that the `Invoke` method in your middleware takes a parameter of type `HttpContext`:

````csharp
public async Task Invoke(HttpContext context)
````

`HttpContext` has significantly changed in ASP.NET Core. This section shows how to translate the most commonly used properties of [System.Web.HttpContext](https://msdn.microsoft.com/en-us/library/system.web.httpcontext(v=vs.110).aspx) to the new [`Microsoft.AspNetCore.Http.HttpContext`](https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNetCore/Http/HttpContext/index.html).

### HttpContext

**HttpContext.Items** translates to:

[!code-csharp[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs?range=51)]

**Unique request ID (no System.Web.HttpContext counterpart)**

Gives you a unique id for each request. Very useful to include in your logs.

[!code-csharp[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs?range=46)]

### HttpContext.Request

**HttpContext.Request.HttpMethod** translates to:

[!code-csharp[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs?range=59)]

**HttpContext.Request.QueryString** translates to:

[!code-csharp[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs?range=66-76)]

**HttpContext.Request.Url and HttpContext.Request.RawUrl** translate to:

[!code-csharp[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs?range=83-84)]

**HttpContext.Request.IsSecureConnection** translates to:

[!code-csharp[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs?range=89)]

**HttpContext.Request.UserHostAddress** translates to:

[!code-csharp[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs?range=96)]

**HttpContext.Request.Cookies** translates to:

[!code-csharp[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs?range=104-106)]

**HttpContext.Request.Headers** translates to:

[!code-csharp[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs?range=120-135)]

**HttpContext.Request.UserAgent** translates to:

[!code-csharp[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs?range=142)]

**HttpContext.Request.UrlReferrer** translates to:

[!code-csharp[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs?range=147)]

**HttpContext.Request.ContentType** translates to:

[!code-csharp[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs?range=152-159)]

**HttpContext.Request.Form** translates to:

[!code-csharp[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs?range=167-177)]

> [!WARNING]
> Read form values only if the content sub type is *x-www-form-urlencoded* or *form-data*.

**HttpContext.Request.InputStream** translates to:

[!code-csharp[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs?range=191-196)]

> [!WARNING]
> Use this code only in a handler type middleware, at the end of a pipeline.
>
>You can read the raw body as shown above only once per request. Middleware trying to read the body after the first read will read an empty body.
>
>This does not apply to reading a form as shown earlier, because that is done from a buffer.

**HttpContext.Request.RequestContext.RouteData**

RouteData is not available in middleware in RC1.

### HttpContext.Response

**HttpContext.Response.Status and HttpContext.Response.StatusDescription** translate to:

[!code-csharp[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs?range=208-209)]

**HttpContext.Response.ContentEncoding and HttpContext.Response.ContentType** translate to:

[!code-csharp[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs?range=214-217)]

**HttpContext.Response.ContentType** on its own also translates to:

[!code-csharp[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs?range=222)]

**HttpContext.Response.Output** translates to:

[!code-csharp[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs?range=229-230)]

**HttpContext.Response.TransmitFile**

Serving up a file is discussed [here](../fundamentals/request-features.md#middleware-and-request-features).

**HttpContext.Response.Headers**

Sending response headers is complicated by the fact that if you set them after anything has been written to the response body, they will not be sent.

The solution is to set a callback method that will be called right before writing to the response starts. This is best done at the start of the `Invoke` method in your middleware. It is this callback method that sets your response headers.

The following code sets a callback method called `SetHeaders`:

````csharp
public async Task Invoke(HttpContext httpContext)
{
    // ...
    httpContext.Response.OnStarting(SetHeaders, state: httpContext);
````

The `SetHeaders` callback method would look like this:

[!code-csharp[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs?range=235-266)]

**HttpContext.Response.Cookies**

Cookies travel to the browser in a *Set-Cookie* response header. As a result, sending cookies requires the same callback as used for sending response headers:

````csharp
public async Task Invoke(HttpContext httpContext)
{
    // ...
    httpContext.Response.OnStarting(SetCookies, state: httpContext);
    httpContext.Response.OnStarting(SetHeaders, state: httpContext);
````

The `SetCookies` callback method would look like the following:

[!code-csharp[Main](http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs?range=270-282)]

## Additional Resources

* [HTTP Handlers and HTTP Modules Overview](https://msdn.microsoft.com/en-us/library/bb398986.aspx)

* [Configuration](../fundamentals/configuration.md)

* [Application Startup](../fundamentals/startup.md)

* [Middleware](../fundamentals/middleware.md)
