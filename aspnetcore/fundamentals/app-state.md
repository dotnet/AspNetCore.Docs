---
title: Session and application state | Microsoft Docs
author: rick-anderson
description: Approaches to preserving application and user (session) state between requests.
keywords: ASP.NET Core, Application state, session state, querystring, post
ms.author: riande
manager: wpickett
ms.date: 01/14/2017
ms.topic: article
ms.assetid: 18cda488-0769-4cb9-82f6-4c6685f2045d
ms.technology: aspnet
ms.prod: aspnet-core
uid: fundamentals/app-state
---

# Session and application state

By [Rick Anderson](https://twitter.com/RickAndMSFT) and [Steve Smith](http://ardalis.com)

HTTP is a stateless protocol; the Web server treats each HTTP request as an independent request. The server retains no knowledge of variable values that were used in previous requests. This article discusses various approaches to preserving application and user (session) state between requests. 

Application state, unlike session state, applies to all users and sessions.

## Session state

Session state is a feature in ASP.NET Core you can enable that allows you to save and store user data while the user browses your web app. Session data is stored in dictionary on the server and persists data across requests from a browser. A session ID is stored on the client in a cookie. The session ID cookie is sent to server with each request, and the server uses the session ID to fetch the session data. The session ID cookie is per browser, you cannot share session across browsers. Session cookies have no specified timeout, they are deleted when the browser session ends. If a cookie is received for an expired session, then a new session is created using the same Session cookie.

Session is retained by the server for a limited time after the last request. The default session timeout is 20 minutes, but you can configure session time out. The session data is backed by a cache. Session is ideal for storing user state that is specific to a particular session but which doesn’t need to be persisted permanently. Data is deleted from the backing store either when you call `Session.Clear` or when the session expires in the data store. The server does not know when the browser is closed or the Session cookie is deleted.

> [!WARNING]
> Sensitive data should never be stored in session. You can’t guarantee the client will close the browser and clear their session cookie (and some browsers keep them alive across windows). Consequently, you can’t assume that a session is restricted to a single user, the next user may continue with the same session.

The in-memory session provider stores session data on the server, which can impact scale out. If you run your web app on a server farm, you’ll need to enable sticky sessions to tie each session to a specific server.  Windows Azure Web Sites defaults to sticky sessions (Application Request Routing or ARR). Sticky session can impact scalability and complicate updating your web app. The Redis and SQL Server distributed caches don't require sticky sessions and are the preferred approach to multi-server caching. See [Working with a Distributed Cache](xref:performance/caching/distributed) for more information.

See [Installing and Configuring Session](#installing-and-configuring-session), below for more details.

### TempData

ASP.NET Core MVC exposes the [TempData](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.mvc.controller#Microsoft_AspNetCore_Mvc_Controller_TempData) property on a [Controller](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.mvc.controller). `TempData` can be used for storing transient data that only needs to be available for a single request after the current request. `TempData` is frequently useful for redirection, when data is needed for more than a single request. `TempData` is built on top of Session State.

### Cookie-based TempData provider (requires ASP.NET Core 1.1.0 and higher)

To enable the  Cookie-based TempData provider, register the `CookieTempDataProvider` service in `ConfigureServices`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();
    // Add CookieTempDataProvider after AddMvc and include ViewFeatures.
    // using Microsoft.AspNetCore.Mvc.ViewFeatures;
    services.AddSingleton<ITempDataProvider, CookieTempDataProvider>();
}
```

The cookie-based TempData provider does not use Session; data is stored in a cookie on the client. The cookie data is encoded with the [Base64UrlTextEncoder](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.authentication.base64urltextencoder). The cookie is encrypted and chunked, so the single cookie size limit does not apply. See [CookieTempDataProvider](https://github.com/aspnet/Mvc/blob/dev/src/Microsoft.AspNetCore.Mvc.ViewFeatures/ViewFeatures/CookieTempDataProvider.cs) for more information.

The cookie data is not compressed. Using compression with encryption can lead to security problems such as the [CRIME](https://en.wikipedia.org/wiki/CRIME_(security_exploit)) and [BREACH](https://en.wikipedia.org/wiki/BREACH_(security_exploit)) attacks.

### Query strings

State from one request can be provided to another request by adding values to the new request's query string. Query strings should never be used with sensitive data. It is also best used with small amounts of data.

Query strings are useful for capturing state in a persistent manner, allowing links with embedded state to be created and shared through email or social networks. However, no assumption can be made about the user making the request, since URLs with query strings can easily be shared. Care must also be taken to avoid [Cross-Site Request Forgery (CSRF)](https://www.owasp.org/index.php/Cross-Site_Request_Forgery_(CSRF)) attacks. An attacker could trick a user into visiting a malicious site while authenticated. CSRF are a major form of vulnerability that can be used to steal user data from your app, or take malicious actions on the behalf of the user. Any preserved application or session state needs to protect against CSRF attacks. See [Preventing Cross-Site Request Forgery (XSRF/CSRF) Attacks in ASP.NET Core](../security/anti-request-forgery.md)

### Post data and hidden fields

Data can be saved in hidden form fields and posted back on the next request. This is common in multi-page forms.  It’s insecure in that the client can tamper with the data so the server must always revalidate it.

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

- Add any of the [IDistributedCache](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.extensions.caching.distributed.idistributedcache) memory caches. The `IDistributedCache` implimentation is used as a backing store for session.
- Call [AddSession](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.extensions.dependencyinjection.sessionservicecollectionextensions#Microsoft_Extensions_DependencyInjection_SessionServiceCollectionExtensions_AddSession_Microsoft_Extensions_DependencyInjection_IServiceCollection_), which requires NuGet package "Microsoft.AspNetCore.Session".
- Call [UseSession](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.builder.sessionmiddlewareextensions#methods_).

The following code shows how to set up the in-memory session provider:

[!code-csharp[Main](app-state/sample/src/WebAppSession/Startup.cs?highlight=11-19,24)]

You can reference Session from `HttpContext` once it is installed and configured.

Note: Accessing `Session` before `UseSession` has been called throws`InvalidOperationException: Session has not been configured for this application or request.`

Attempting to create a new `Session` (that is, no session cookie has been created) after you have already begun writing to the `Response` stream throws `InvalidOperationException: The session cannot be established after the response has started`. The exception can be found in the web server log, it will **not** be displayed in the browser.

### Loading Session asynchronously 

The default session provider in ASP.NET Core will only load the session record from the underlying [IDistributedCache](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.extensions.caching.distributed.idistributedcache) store asynchronously if the [ISession.LoadAsync](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.http.isession#Microsoft_AspNetCore_Http_ISession_LoadAsync) method is explicitly called **before** calling the `TryGetValue`, `Set` or `Remove` methods. Failure to call `LoadAsync` first will result in the underlying session record being loaded synchronously, which could potentially impact the ability of the app to scale.

If applications wish to enforce this pattern, they could wrap the [DistributedSessionStore[(https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.session.distributedsessionstore) and [DistributedSession](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.aspnetcore.session.distributedsession) implementations with versions that throw if the `LoadAsync` method has not been called before calling `TryGetValue`, `Set` or `Remove`, and register the wrapped versions in the services container.

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

### Common errors when working with session

* "Unable to resolve service for type 'Microsoft.Extensions.Caching.Distributed.IDistributedCache' while attempting to activate 'Microsoft.AspNetCore.Session.DistributedSessionStore'."

   Commonly caused by not configuring at least one `IDistributedCache` implementation. See [Working with a Distributed Cache](xref:performance/caching/distributed) and [
In memory caching](xref:performance/caching/memory) for more information

### Additional Resources

* [Sample code used in this document](https://github.com/aspnet/Docs/tree/master/aspnet/fundamentals/app-state/sample)
