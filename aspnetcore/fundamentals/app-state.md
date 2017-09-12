---
title: Session and application state in ASP.NET Core
author: rick-anderson
description: Approaches to preserving application and user (session) state between requests.
keywords: ASP.NET Core, Application state, session state, querystring, post
ms.author: riande
manager: wpickett
ms.date: 06/08/2017
ms.topic: article
ms.assetid: 18cda488-0769-4cb9-82f6-4c6685f2045d
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/app-state
ms.custom: H1Hack27Feb2017
---

# Introduction to session and application state in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT), [Steve Smith](https://ardalis.com/), and [Diana LaRose](https://github.com/DianaLaRose)

HTTP is a stateless protocol. A  web server treats each HTTP request as an independent request and does not retain user values from previous requests. This article discusses different ways to preserve application and session state between requests. 

## Session state

Session state is a feature in ASP.NET Core that you can use to save and store user data while the user browses your web app. Consisting of a dictionary or hash table on the server, session state persists data across requests from a browser. The session data is backed by a cache.

ASP.NET Core maintains session state by giving the client a cookie that contains the session ID, which is sent to the server with each request. The server uses the session ID to fetch the session data. Because the session cookie is specific to the browser, you cannot share sessions across browsers. Session cookies are deleted only when the browser session ends. If a cookie is received for an expired session, a new session that uses the same session cookie  is created. 

The server retains a session for a limited time after the last request. You can either set the session timeout or use the default value of 20 minutes. Session state is ideal for storing user data that is specific to a particular session but doesn’t need to be persisted permanently. Data is deleted from the backing store either when you call `Session.Clear` or when the session expires in the data store. The server does not know when the browser is closed or when the session cookie is deleted.

> [!WARNING]
> Do not store sensitive data in session. The client might not close the browser and clear the session cookie (and some browsers keep session cookies alive across windows). Also, a session might not be restricted to a single user; the next user might continue with the same session.

The in-memory session provider stores session data on the local server. If you plan to run your web app on a server farm, you must use sticky sessions to tie each session to a specific server. The Windows Azure Web Sites platform defaults to sticky sessions (Application Request Routing or ARR). However, sticky sessions can affect scalability and complicate web app updates. A better option is to use the Redis or SQL Server distributed caches, which don't require sticky sessions. For more information, see [Working with a Distributed Cache](xref:performance/caching/distributed). For details on setting up service providers, see [Configuring Session](#configuring-session) later in this article.

The remainder of this section describes the options for storing user data.

<a name="temp"></a>
### TempData

ASP.NET Core MVC exposes the [TempData](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.controller#Microsoft_AspNetCore_Mvc_Controller_TempData) property on a [controller](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.mvc.controller). This property stores data until it is read. The `Keep` and `Peek` methods can be used to examine the data without deletion. `TempData` is particularly useful for redirection, when data is needed for more than a single request. `TempData` is built on top of session state. 

## Cookie-based TempData provider 

In ASP.NET Core 1.1 and higher, you can use the cookie-based TempData provider to store a user's TempData in a cookie. To enable the  cookie-based TempData provider, register the `CookieTempDataProvider` service in `ConfigureServices`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();
    // Add CookieTempDataProvider after AddMvc and include ViewFeatures.
    // using Microsoft.AspNetCore.Mvc.ViewFeatures;
    services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
}
```

The cookie data is encoded with the [Base64UrlTextEncoder](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.authentication.base64urltextencoder). Because the cookie is encrypted and chunked, the single cookie size limit does not apply. The cookie data is not compressed, because compressing encryped data can lead to security problems such as the [CRIME](https://wikipedia.org/wiki/CRIME_(security_exploit)) and [BREACH](https://wikipedia.org/wiki/BREACH_(security_exploit)) attacks. For more information on the cookie-based TempData provider, see [CookieTempDataProvider](https://github.com/aspnet/Mvc/blob/dev/src/Microsoft.AspNetCore.Mvc.ViewFeatures/ViewFeatures/CookieTempDataProvider.cs).

### Query strings

You can pass a limited amount of data from one request to another by adding it to the new request’s query string. This is useful for capturing state in a persistent manner that allows links with embedded state to be shared through email or social networks. However, for this reason,  you should never use query strings for sensitive data. In addition to being easily shared, including data in query strings can create opportunities for [Cross-Site Request Forgery (CSRF)](https://www.owasp.org/index.php/Cross-Site_Request_Forgery_(CSRF)) attacks, which can trick users into visiting malicious sites while authenticated. Attackers can then steal user data from your app or take malicious actions on behalf of the user. Any preserved application or session state must protect against CSRF attacks. For more information on CSRF attacks, see [Preventing Cross-Site Request Forgery (XSRF/CSRF) Attacks in ASP.NET Core](../security/anti-request-forgery.md).

### Post data and hidden fields

Data can be saved in hidden form fields and posted back on the next request. This is common in multipage forms. However, because the  client can potentially tamper with the data, the server must always revalidate it. 

### Cookies

Cookies provide a way to store user-specific data in web applications. Because cookies are sent with every request, their size should be kept to a minimum. Ideally, only an identifier should be stored in a cookie with the actual data stored on the server. Most browsers restrict cookies to 4096 bytes. In addition, only a limited number of cookies are available for each domain.  

Because cookies are subject to tampering, they must be validated on the server. Although the durability of the cookie on a client is subject to user intervention and expiration, they are generally the most durable form of data persistence on the client.

Cookies are often used for personalization, where content is customized for a known user. Because the user is only identified and not authenticated in most cases, you can typically secure a cookie by storing the user name, account name, or a unique user ID (such as a GUID) in the cookie. You can then use the cookie to access the user personalization infrastructure of a site.

### HttpContext.Items

The `Items` collection is a good location to store data that is needed only while processing one particular request. The collection's contents are discarded after each request. The `Items` collection is best used as a way for components or middleware to communicate when they operate at different points in time during a request and have no direct way to pass parameters. For more information, see [Working with HttpContext.Items](#working-with-httpcontextitems), later in this article.

### Cache

Caching is an efficient way to store and retrieve data. You can control the lifetime of cached items based on time and other considerations. Learn more about [Caching](../performance/caching/index.md).

<a name=session></a>

## Configuring Session

The `Microsoft.AspNetCore.Session` package provides middleware for managing session state. To enable the session middleware, `Startup`must contain:

- Any of the [IDistributedCache](https://docs.microsoft.com/aspnet/core/api/microsoft.extensions.caching.distributed.idistributedcache) memory caches. The `IDistributedCache` implementation is used as a backing store for session.
- [AddSession](https://docs.microsoft.com/aspnet/core/api/microsoft.extensions.dependencyinjection.sessionservicecollectionextensions#Microsoft_Extensions_DependencyInjection_SessionServiceCollectionExtensions_AddSession_Microsoft_Extensions_DependencyInjection_IServiceCollection_) call, which requires NuGet package "Microsoft.AspNetCore.Session".
- [UseSession](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.builder.sessionmiddlewareextensions#methods_) call.

The following code shows how to set up the in-memory session provider.

[!code-csharp[Main](app-state/sample/src/WebAppSession/Startup.cs?highlight=11-19,24)]

You can reference Session from `HttpContext` once it is installed and configured.

If you try to access `Session` before `UseSession` has been called, the exception `InvalidOperationException: Session has not been configured for this application or request` is thrown.

If you try to create a new `Session` (that is, no session cookie has been created) after you have already begun writing to the `Response` stream, the exception `InvalidOperationException: The session cannot be established after the response has started` is thrown. The exception can be found in the web server log; it will not be displayed in the browser.

### Loading Session asynchronously 

The default session provider in ASP.NET Core loads the session record from the underlying [IDistributedCache](https://docs.microsoft.com/aspnet/core/api/microsoft.extensions.caching.distributed.idistributedcache) store asynchronously only if the [ISession.LoadAsync](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.http.isession#Microsoft_AspNetCore_Http_ISession_LoadAsync) method is explicitly called before  the `TryGetValue`, `Set`, or `Remove` methods. If `LoadAsync` is not called first, the underlying session record is loaded synchronously, which could potentially impact the ability of the app to scale.

To have applications enforce this pattern, wrap the [DistributedSessionStore](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.session.distributedsessionstore) and [DistributedSession](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.session.distributedsession) implementations with versions that throw an exception if the `LoadAsync` method is not called before `TryGetValue`, `Set`, or `Remove`. Register the wrapped versions in the services container.

### Implementation Details

Session uses a cookie to track and identify requests from a single browser. By default, this cookie is named ".AspNet.Session", and it uses a path of "/". Because the cookie default does not specify a domain, it is not made available to the client-side script on the page (because `CookieHttpOnly` defaults to `true`).

To override session defaults, use `SessionOptions`:

[!code-csharp[Main](app-state/sample/src/WebAppSession/StartupCopy.cs?name=snippet1&highlight=8-12)]

The server uses the `IdleTimeout` property to determine how long a session can be idle before its contents are abandoned. This property is independent of the cookie expiration. Each request that passes through the Session middleware (read from or written to) resets the timeout.

Because `Session` is *non-locking*, if two requests both attempt to modify the contents of session, the last one overrides the first. `Session` is implemented as a *coherent session*, which means that all the contents are stored together. Two requests that are modifying different parts of the session (different keys) might still impact each other.

## Setting and getting Session values

Session is accessed through the `Session` property on `HttpContext`. This property is an [ISession](https://docs.microsoft.com/aspnet/core/api/microsoft.aspnetcore.http.isession) implementation.

The following example shows setting and getting an int and a string:

[!code-csharp[Main](app-state/sample/src/WebAppSession/Controllers/HomeController.cs?name=snippet1)]

If you add the following extension methods, you can set and get serializable objects to Session:

[!code-csharp[Main](app-state/sample/src/WebAppSession/Extensions/SessionExtensions.cs)]

The following sample shows how to set and get a serializable object:

[!code-csharp[Main](app-state/sample/src/WebAppSession/Controllers/HomeController.cs?name=snippet2)]


## Working with HttpContext.Items

The `HttpContext` abstraction provides support for a dictionary collection of type `IDictionary<object, object>`, called `Items`. This collection is available from the start of an *HttpRequest* and is discarded at the end of each request. You can access it by  assigning a value to a keyed entry, or by requesting the value for a particular key.

In the sample below, [Middleware](middleware.md) adds `isVerified` to the `Items` collection.

```csharp
app.Use(async (context, next) =>
{
    // perform some verification
    context.Items["isVerified"] = true;
    await next.Invoke();
});
```

Later in the pipeline, another middleware could access it:

```csharp
app.Run(async (context) =>
{
    await context.Response.WriteAsync("Verified request? " + 
        context.Items["isVerified"]);
});
```

For middleware that will only be used by a single app, `string` keys are acceptable. However, middleware that will be shared between applications should use unique object keys to avoid any chance of key collisions. If you are developing middleware that must work across multiple applications, use a unique object key defined in your middleware class as shown below:

```csharp
public class SampleMiddleware
{
    public static readonly object SampleKey = new Object();

    public async Task Invoke(HttpContext httpContext)
    {
        httpContext.Items[SampleKey] = "some value";
        // additional code omitted
    }
}
```

Other code can access the value stored in `HttpContext.Items` using the key exposed by the middleware class:

```csharp
public class HomeController : Controller
{
    public IActionResult Index()
    {
        string value = HttpContext.Items[SampleMiddleware.SampleKey];
    }
}
```

This approach also has the advantage of eliminating repetition of "magic strings" in multiple places in the code.

<a name=appstate-errors></a>

## Application state data

Use [Dependency Injection](xref:fundamentals/dependency-injection) to make data available to all users:

1. Define a service containing the data (for example, a class named `MyAppData`).

```csharp
public class MyAppData
{
    // Declare properties/methods/etc.
} 
```
2. Add the service class to `ConfigureServices` (for example `services.AddSingleton<MyAppData>();`).
3. Consume the data service class in each controller:

```csharp
public class MyController : Controller
{
    public MyController(MyAppData myService)
    {
        // Do something with the service (read some data from it, 
        // store it in a private field/property, etc.)
    }
} 
```

### Common errors when working with session

* "Unable to resolve service for type 'Microsoft.Extensions.Caching.Distributed.IDistributedCache' while attempting to activate 'Microsoft.AspNetCore.Session.DistributedSessionStore'."

  This is usually caused by failing to configure at least one `IDistributedCache` implementation. For more information, see [Working with a Distributed Cache](xref:performance/caching/distributed) and [In memory caching](xref:performance/caching/memory).

### Additional Resources


* [Sample code used in this document](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/app-state/sample/src/WebAppSession)
