---
title: Session and application state in ASP.NET Core  | Microsoft Docs
author: rick-anderson
description: Approaches to preserving application and user (session) state between requests.
keywords: ASP.NET Core, Application state, session state, querystring, post
ms.author: riande
manager: wpickett
ms.date: 03/14/2017
ms.topic: article
ms.assetid: 18cda488-0769-4cb9-82f6-4c6685f2045d
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/app-state
ms.custom: H1Hack27Feb2017
---

# Introduction to session and application state in ASP.NET Core

By [Rick Anderson](https://twitter.com/RickAndMSFT), [Steve Smith](http://ardalis.com)  and [Diana LaRose](https://github.com/DianaLaRose)

HTTP is a stateless protocol. A  web server treats each HTTP request as an independent request and does not retain user values from previous requests. This article discusses different ways to preserve application and session state between requests. 

## Session state

Session state is a feature in ASP.NET Core that you can use to save and store user data while the user browses your web app. Consisting of a dictionary or hash table on the server, session state persists data across requests from a browser. The session data is backed by a cache.

ASP.NET Core maintains session state by giving the client a cookie that contains the session ID, which is sent to the server with each request. The server uses the session ID to fetch the session data. Because the session cookie is specific to the browser, you cannot share sessions across browsers. Session cookies are deleted only when the browser session ends. If a cookie is received for an expired session, a new session that uses the same session cookie  is created. 

The server retains a session for a limited time after the last request. You can either set the session timeout or use the default value of 20 minutes.  Session state is ideal for storing user data that is specific to a particular session but doesn’t need to be persisted permanently. Data is deleted from the backing store either when you call `Session.Clear` or when the session expires in the data store. The server does not know when the browser is closed or the session cookie is deleted.

> [!WARNING]
> Do not store sensitive data in session. The client might not close the browser and clear their session cookie (and some browsers keep session cookies alive across windows). Also, a session might not be restricted to a single user; the next user might continue with the same session.

The in-memory session provider stores session data on the local server. If you plan to run your web app on a server farm, you must use sticky sessions to tie each session to a specific server. The Windows Azure Web Sites platform defaults to sticky sessions (Application Request Routing or ARR). However, sticky sessions can affect scalability and complicate web app updates. A better option is to use the Redis or SQL Server distributed caches, which don't require sticky sessions. For more information, see [Working with a Distributed Cache](xref:performance/caching/distributed). For details on setting up service providers, see [Configuring Session](#configuring-session) later in this article.

The remainder of this section describes the options for storing user data.

### TempData

ASP.NET Core MVC exposes the [TempData](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.mvc.controller#Microsoft_AspNetCore_Mvc_Controller_TempData) property on a [controller](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.mvc.controller). This property stores data for only a single request after the current one.`TempData` is particularly useful for redirection, when data is needed for more than a single request. `TempData` is built on top of session state. 

## Cookie-based TempData provider 

In ASP.NET Core 1.1 and higher, you can use the cookie-based TempData provider to store a user's TempData in a cookie. To enable the  cdookie-based TempData provider, register the `CookieTempDataProvider` service in `ConfigureServices`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();
    // Add CookieTempDataProvider after AddMvc and include ViewFeatures.
    // using Microsoft.AspNetCore.Mvc.ViewFeatures;
    services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
}
```

The cookie data is encoded with the [Base64UrlTextEncoder](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.authentication.base64urltextencoder). Because the cookie is encrypted and chunked, the single cookie size limit does not apply. The cookie data is not compressed, because compressing encryped data can lead to security problems such as the [CRIME](https://en.wikipedia.org/wiki/CRIME_(security_exploit)) and [BREACH](https://en.wikipedia.org/wiki/BREACH_(security_exploit)) attacks. For more information on the cookie-based TempData provider, see [CookieTempDataProvider](https://github.com/aspnet/Mvc/blob/dev/src/Microsoft.AspNetCore.Mvc.ViewFeatures/ViewFeatures/CookieTempDataProvider.cs) for more information.



### Query strings

You can pass a limited amount of data from one request to another by adding it to the new request’s query string. This is useful for capturing state in a persistent manner that allows links with embedded state to be shared through email or social networks. However, for this reason,  you should never use query strings for sensitive data. In addition to being easily shared, including data in query strings can create opportunities for [Cross-Site Request Forgery (CSRF)](https://www.owasp.org/index.php/Cross-Site_Request_Forgery_(CSRF)) attacks, which can trick  users into visiting malicious sites while authenticated. Attackers can then steal user data from your app or take malicious actions on the behalf of the user. Any preserved application or session state must protect against CSRF attacks. For more information on protecting app or session state from CSRF attacks, see [Preventing Cross-Site Request Forgery (XSRF/CSRF) Attacks in ASP.NET Core](../security/anti-request-forgery.md)

### Post data and hidden fields

Data can be saved in hidden form fields and posted back on the next request. This is common in multipage forms. However, because the  client can potentially tamper with the data, the server must always revalidate it. 

### Cookies

Data can be stored in cookies. Cookies are sent with every request, so the size should be kept to a minimum. Ideally, only an identifier should be used, with the actual data stored somewhere on the server. Cookies are subject to tampering and therefore need to be validated on the server. Cookies are limited by most browsers to 4096 bytes and you have only a limited number of cookies per domain. Although the durability of the cookie on a client is subject to user intervention and expiration, cookies are generally the most durable form of data persistence on the client.

Cookies are often used for personalization, where content is customized for a known user. In most cases, identification is the issue rather than authentication. Thus, you can typically secure a cookie that is used for identification by storing the user name, account name, or a unique user ID (such as a GUID) in the cookie and then use the cookie to access the user personalization infrastructure of a site.

### HttpContext.Items

The `Items` collection is the good location to store data that is only needed while processing a given request. Its contents are discarded after each request. It is best used as a means of communicating between components or middleware that operate at different points in time during a request and have no direct way to pass parameters. See [Working with HttpContext.Items](#working-with-httpcontextitems), below.

### Cache

Caching provides a means of efficiently storing and retrieving data. It provides rules for expiring cached items based on time and other considerations. Learn more about [Caching](../performance/caching/index.md).

<a name=session></a>

## Configuring Session

The `Microsoft.AspNetCore.Session` package provides middleware for managing session state. Enabling the session middleware requires the following in `Startup`:

- Add any of the [IDistributedCache](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.extensions.caching.distributed.idistributedcache) memory caches. The `IDistributedCache` implementation is used as a backing store for session.
- Call [AddSession](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.extensions.dependencyinjection.sessionservicecollectionextensions#Microsoft_Extensions_DependencyInjection_SessionServiceCollectionExtensions_AddSession_Microsoft_Extensions_DependencyInjection_IServiceCollection_), which requires NuGet package "Microsoft.AspNetCore.Session".
- Call [UseSession](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.builder.sessionmiddlewareextensions#methods_).

The following code shows how to set up the in-memory session provider:

[!code-csharp[Main](app-state/sample/src/WebAppSession/Startup.cs?highlight=11-19,24)]

You can reference Session from `HttpContext` once it is installed and configured.

Note: Accessing `Session` before `UseSession` has been called throws`InvalidOperationException: Session has not been configured for this application or request.`

Attempting to create a new `Session` (that is, no session cookie has been created) after you have already begun writing to the `Response` stream throws `InvalidOperationException: The session cannot be established after the response has started`. The exception can be found in the web server log, it will **not** be displayed in the browser.

### Loading Session asynchronously 

The default session provider in ASP.NET Core will only load the session record from the underlying [IDistributedCache](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.extensions.caching.distributed.idistributedcache) store asynchronously if the [ISession.LoadAsync](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.http.isession#Microsoft_AspNetCore_Http_ISession_LoadAsync) method is explicitly called **before** calling the `TryGetValue`, `Set` or `Remove` methods. Failure to call `LoadAsync` first will result in the underlying session record being loaded synchronously, which could potentially impact the ability of the app to scale.

If applications wish to enforce this pattern, they could wrap the [DistributedSessionStore](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.session.distributedsessionstore) and [DistributedSession](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.session.distributedsession) implementations with versions that throw if the `LoadAsync` method has not been called before calling `TryGetValue`, `Set` or `Remove`, and register the wrapped versions in the services container.

### Implementation Details

Session uses a cookie to track and identify requests from the same browser. By default this cookie is named ".AspNet.Session" and uses a path of "/". The cookie default does not specify a domain. The cookie default is not made available to client-side script on the page (because `CookieHttpOnly` defaults to `true`).

Session defaults can be overridden by using `SessionOptions`:

[!code-csharp[Main](app-state/sample/src/WebAppSession/StartupCopy.cs?name=snippet1&highlight=8-12)]

The `IdleTimeout` is used by the server to determine how long a session can be idle before its contents are abandoned. `IdleTimeout` is independent of the cookie expiration. Each request that passes through the Session middleware (read from or written to) will reset the timeout.

Note: `Session` is *non-locking*, so if two requests both attempt to modify the contents of session, the last one will win. `Session` is implemented as a *coherent session*, which means that all of the contents are stored together. This means that if two requests are modifying different parts of the session (different keys), they may still impact each other.

## Setting and getting Session values

Session is accessed through the `Session` property on `HttpContext`. `Session` is an [ISession](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.http.isession) implementation.

The following example shows setting and getting an int and a string:

[!code-csharp[Main](app-state/sample/src/WebAppSession/Controllers/HomeController.cs?name=snippet1)]

If you add the following extension methods, you can set and get serializable objects to Session:

[!code-csharp[Main](app-state/sample/src/WebAppSession/Extensions/SessionExtensions.cs)]

The following sample shows how to set and get a serializable object:

[!code-csharp[Main](app-state/sample/src/WebAppSession/Controllers/HomeController.cs?name=snippet2)]


## Working with HttpContext.Items

The `HttpContext` abstraction provides support for a simple dictionary collection of type `IDictionary<object, object>`, called `Items`. This collection is available from the start of an *HttpRequest* and is discarded at the end of each request. You can access it by  assigning a value to a keyed entry, or by requesting the value for a given key.

In the sample below, [Middleware](middleware.md) adds `isVerified` to the `Items` collection:

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
    await context.Response.WriteAsync("Verified request? " + context.Items["isVerified"]);
});
```

Note: Since keys into `Items` are simple strings, if you are developing middleware that needs to work across many applications, you may wish to prefix your keys with a unique identifier to avoid key collisions (for example, "MyComponent.isVerified" instead of "isVerified").

<a name=appstate-errors></a>

## Application state data

Use [Dependency Injection](xref:fundamentals/dependency-injection) to make data available to all users.

1. Define a service containing the data (for example, a class named `MyAppData`).

```csharp
public class MyAppData
{
    // Declare properties/methods/etc.
} 
```
2. Add the service class to `ConfigureServices` (for example `services.AddSingleton<MyAppData>();`.
3. Consume the data service class in each controller:

```csharp
public class MyController : Controller
{
    public MyController(MyAppData myService)
    {
        // Do something with the service (read some data from it, 
        // store it in a private field/property, etc.
    }
    }
} 
```

### Common errors when working with session

* "Unable to resolve service for type 'Microsoft.Extensions.Caching.Distributed.IDistributedCache' while attempting to activate 'Microsoft.AspNetCore.Session.DistributedSessionStore'."

   Commonly caused by not configuring at least one `IDistributedCache` implementation. See [Working with a Distributed Cache](xref:performance/caching/distributed) and [
In memory caching](xref:performance/caching/memory) for more information

### Additional Resources


* [Sample code used in this document](https://github.com/aspnet/Docs/tree/master/aspnetcore/fundamentals/app-state/sample/src/WebAppSession)
