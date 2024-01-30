---
title: Session in ASP.NET Core
author: tdykstra
description: Discover approaches to preserve session between requests.
ms.author: riande
ms.custom: mvc
ms.date: 03/22/2022
uid: fundamentals/app-state
---
# Session and state management in ASP.NET Core

:::moniker range=">= aspnetcore-6.0"

By [Rick Anderson](https://twitter.com/RickAndMSFT), [Kirk Larkin](https://twitter.com/serpent5), and [Diana LaRose](https://github.com/DianaLaRose)

HTTP is a stateless protocol. By default, HTTP requests are independent messages that don't retain user values. This article describes several approaches to preserve user data between requests.

## State management

State can be stored using several approaches. Each approach is described later in this article.

| Storage approach | Storage mechanism |
| ---------------- | ----------------- |
| [Cookies](#cookies) | HTTP cookies. May include data stored using server-side app code. |
| [Session state](#session-state) | HTTP cookies and server-side app code |
| [TempData](#tempdata) | HTTP cookies or session state |
| [Query strings](#query-strings) | HTTP query strings |
| [Hidden fields](#hidden-fields) | HTTP form fields |
| [HttpContext.Items](#httpcontextitems) | Server-side app code |
| [Cache](#cache) | Server-side app code |

## SignalR/Blazor Server and HTTP context-based state management

[SignalR](xref:signalr/introduction) apps shouldn't use session state and other state management approaches that rely upon a stable HTTP context to store information. SignalR apps can store per-connection state in [`Context.Items` in the hub](xref:signalr/hubs). For more information and alternative state management approaches for Blazor Server apps, see <xref:blazor/state-management?pivots=server>. <!-- https://github.com/aspnet/SignalR/issues/2139 https://github.com/dotnet/AspNetCore.Docs/issues/27956 https://github.com/dotnet/AspNetCore.Docs/issues/14974 -->

## Cookies

Cookies store data across requests. Because cookies are sent with every request, their size should be kept to a minimum. Ideally, only an identifier should be stored in a cookie with the data stored by the app. Most browsers restrict cookie size to 4096 bytes. Only a limited number of cookies are available for each domain.

Because cookies are subject to tampering, they must be validated by the app. Cookies can be deleted by users and expire on clients. However, cookies are generally the most durable form of data persistence on the client.

Cookies are often used for personalization, where content is customized for a known user. The user is only identified and not authenticated in most cases. The cookie can store the user's name, account name, or unique user ID such as a GUID. The cookie can be used to access the user's personalized settings, such as their preferred website background color.

See the [European Union General Data Protection Regulations (GDPR)](https://ec.europa.eu/info/law/law-topic/data-protection) when issuing cookies and dealing with privacy concerns. For more information, see [General Data Protection Regulation (GDPR) support in ASP.NET Core](xref:security/gdpr).

## Session state

Session state is an ASP.NET Core scenario for storage of user data while the user browses a web app. Session state uses a store maintained by the app to persist data across requests from a client. The session data is backed by a cache and considered ephemeral data. The site should continue to function without the session data. Critical application data should be stored in the user database and cached in session only as a performance optimization.

Session isn't supported in [SignalR](xref:signalr/index) apps because a [SignalR Hub](xref:signalr/hubs) may execute independent of an HTTP context. For example, this can occur when a long polling request is held open by a hub beyond the lifetime of the request's HTTP context.

ASP.NET Core maintains session state by providing a cookie to the client that contains a session ID. The cookie session ID:

* Is sent to the app with each request.
* Is used by the app to fetch the session data.

Session state exhibits the following behaviors:

* The session cookie is specific to the browser. Sessions aren't shared across browsers.
* Session cookies are deleted when the browser session ends.
* If a cookie is received for an expired session, a new session is created that uses the same session cookie.
* Empty sessions aren't retained. The session must have at least one value set to persist the session across requests. When a session isn't retained, a new session ID is generated for each new request.
* The app retains a session for a limited time after the last request. The app either sets the session timeout or uses the default value of 20 minutes. Session state is ideal for storing user data:
  * That's specific to a particular session.
  * Where the data doesn't require permanent storage across sessions.
* Session data is deleted either when the <xref:Microsoft.AspNetCore.Http.ISession.Clear%2A?displayProperty=nameWithType> implementation is called or when the session expires.
* There's no default mechanism to inform app code that a client browser has been closed or when the session cookie is deleted or expired on the client.
* Session state cookies aren't marked essential by default. Session state isn't functional unless tracking is permitted by the site visitor. For more information, see <xref:security/gdpr#tempdata-provider-and-session-state-cookies-arent-essential>.
* **Note**: There is no replacement for the cookieless session feature from the ASP.NET Framework because it's considered insecure and can lead to session fixation attacks.

> [!WARNING]
> Don't store sensitive data in session state. The user might not close the browser and clear the session cookie. Some browsers maintain valid session cookies across browser windows. A session might not be restricted to a single user. The next user might continue to browse the app with the same session cookie.

The in-memory cache provider stores session data in the memory of the server where the app resides. In a server farm scenario:

* Use *sticky sessions* to tie each session to a specific app instance on an individual server. [Azure App Service](https://azure.microsoft.com/services/app-service/) uses [Application Request Routing (ARR)](/iis/extensions/planning-for-arr/using-the-application-request-routing-module) to enforce sticky sessions by default. However, sticky sessions can affect scalability and complicate web app updates. A better approach is to use a Redis or SQL Server distributed cache, which doesn't require sticky sessions. For more information, see <xref:performance/caching/distributed>.
* The session cookie is encrypted via <xref:Microsoft.AspNetCore.DataProtection.IDataProtector>. Data Protection must be properly configured to read session cookies on each machine. For more information, see <xref:security/data-protection/introduction> and [Key storage providers](xref:security/data-protection/implementation/key-storage-providers).

### Configure session state

Middleware for managing session state is included in the framework. To enable the session middleware, `Program.cs` must contain:

* Any of the <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> memory caches. The `IDistributedCache` implementation is used as a backing store for session. For more information, see <xref:performance/caching/distributed>.
* A call to <xref:Microsoft.Extensions.DependencyInjection.SessionServiceCollectionExtensions.AddSession%2A>
* A call to <xref:Microsoft.AspNetCore.Builder.SessionMiddlewareExtensions.UseSession%2A>

The following code shows how to set up the in-memory session provider with a default in-memory implementation of `IDistributedCache`:

[!code-csharp[](app-state/6.0samples/RazorPagesContacts/Program.cs?name=snippet_2&highlight=6,8-13,30)]

The preceding code sets a short timeout to simplify testing.

The order of middleware is important.  Call `UseSession` after `UseRouting` and before `MapRazorPages` and `MapDefaultControllerRoute` . See [Middleware Ordering](xref:fundamentals/middleware/index#order).

[HttpContext.Session](xref:Microsoft.AspNetCore.Http.HttpContext.Session) is available after session state is configured.

`HttpContext.Session` can't be accessed before `UseSession` has been called.

A new session with a new session cookie can't be created after the app has begun writing to the response stream. The exception is recorded in the web server log and not displayed in the browser.

### Load session state asynchronously

The default session provider in ASP.NET Core loads session records from the underlying <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> backing store asynchronously only if the <xref:Microsoft.AspNetCore.Http.ISession.LoadAsync%2A?displayProperty=nameWithType> method is explicitly called before the <xref:Microsoft.AspNetCore.Http.ISession.TryGetValue%2A>, <xref:Microsoft.AspNetCore.Http.ISession.Set%2A>, or <xref:Microsoft.AspNetCore.Http.ISession.Remove%2A> methods. If `LoadAsync` isn't called first, the underlying session record is loaded synchronously, which can incur a performance penalty at scale.

To have apps enforce this pattern, wrap the <xref:Microsoft.AspNetCore.Session.DistributedSessionStore> and <xref:Microsoft.AspNetCore.Session.DistributedSession> implementations with versions that throw an exception if the `LoadAsync` method isn't called before `TryGetValue`, `Set`, or `Remove`. Register the wrapped versions in the services container.

### Session options

To override session defaults, use <xref:Microsoft.AspNetCore.Builder.SessionOptions>.

| Option | Description |
| ------ | ----------- |
| <xref:Microsoft.AspNetCore.Builder.SessionOptions.Cookie> | Determines the settings used to create the cookie. <xref:Microsoft.AspNetCore.Http.CookieBuilder.Name> defaults to <xref:Microsoft.AspNetCore.Session.SessionDefaults.CookieName?displayProperty=nameWithType> (`.AspNetCore.Session`). <xref:Microsoft.AspNetCore.Http.CookieBuilder.Path> defaults to <xref:Microsoft.AspNetCore.Session.SessionDefaults.CookiePath?displayProperty=nameWithType> (`/`). <xref:Microsoft.AspNetCore.Http.CookieBuilder.SameSite> defaults to <xref:Microsoft.AspNetCore.Http.SameSiteMode.Lax?displayProperty=nameWithType> (`1`). <xref:Microsoft.AspNetCore.Http.CookieBuilder.HttpOnly> defaults to `true`. <xref:Microsoft.AspNetCore.Http.CookieBuilder.IsEssential> defaults to `false`. |
| <xref:Microsoft.AspNetCore.Builder.SessionOptions.IdleTimeout> | The `IdleTimeout` indicates how long the session can be idle before its contents are abandoned. Each session access resets the timeout. This setting only applies to the content of the session, not the cookie. The default is 20 minutes. |
| <xref:Microsoft.AspNetCore.Builder.SessionOptions.IOTimeout> | The maximum amount of time allowed to load a session from the store or to commit it back to the store. This setting may only apply to asynchronous operations. This timeout can be disabled using <xref:System.Threading.Timeout.InfiniteTimeSpan>. The default is 1 minute. |

Session uses a cookie to track and identify requests from a single browser. By default, this cookie is named `.AspNetCore.Session`, and it uses a path of `/`. Because the cookie default doesn't specify a domain, it isn't made available to the client-side script on the page (because <xref:Microsoft.AspNetCore.Http.CookieBuilder.HttpOnly> defaults to `true`).

To override cookie session defaults, use <xref:Microsoft.AspNetCore.Builder.SessionOptions>:

[!code-csharp[](app-state/6.0samples/RazorPagesContacts/Program.cs?name=snippet_or&highlight=8-13)]

The app uses the <xref:Microsoft.AspNetCore.Builder.SessionOptions.IdleTimeout> property to determine how long a session can be idle before its contents in the server's cache are abandoned. This property is independent of the cookie expiration. Each request that passes through the [Session Middleware](xref:Microsoft.AspNetCore.Session.SessionMiddleware) resets the timeout.

Session state is *non-locking*. If two requests simultaneously attempt to modify the contents of a session, the last request overrides the first. `Session` is implemented as a *coherent session*, which means that all the contents are stored together. When two requests seek to modify different session values, the last request may override session changes made by the first.

### Set and get Session values

Session state is accessed from a Razor Pages <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel> class or MVC <xref:Microsoft.AspNetCore.Mvc.Controller> class with <xref:Microsoft.AspNetCore.Http.HttpContext.Session?displayProperty=nameWithType>. This property is an <xref:Microsoft.AspNetCore.Http.ISession> implementation.

The `ISession` implementation provides several extension methods to set and retrieve integer and string values. The extension methods are in the <xref:Microsoft.AspNetCore.Http> namespace.

`ISession` extension methods:

* [Get(ISession, String)](xref:Microsoft.AspNetCore.Http.SessionExtensions.Get%2A)
* [GetInt32(ISession, String)](xref:Microsoft.AspNetCore.Http.SessionExtensions.GetInt32%2A)
* [GetString(ISession, String)](xref:Microsoft.AspNetCore.Http.SessionExtensions.GetString%2A)
* [SetInt32(ISession, String, Int32)](xref:Microsoft.AspNetCore.Http.SessionExtensions.SetInt32%2A)
* [SetString(ISession, String, String)](xref:Microsoft.AspNetCore.Http.SessionExtensions.SetString%2A)

The following example retrieves the session value for the `IndexModel.SessionKeyName` key (`_Name` in the sample app) in a Razor Pages page:

```csharp
@page
@using Microsoft.AspNetCore.Http
@model IndexModel

...

Name: @HttpContext.Session.GetString(IndexModel.SessionKeyName)
```

The following example shows how to set and get an integer and a string:

[!code-csharp[](app-state/6.0samples/SessionSample/Pages/Index.cshtml.cs?name=snippet1)]

The following markup displays the session values on a Razor Page:

[!code-cshtml[](app-state/6.0samples/SessionSample/Pages/Privacy.cshtml)]

All session data must be serialized to enable a distributed cache scenario, even when using the in-memory cache. String and integer serializers are provided by the extension methods of <xref:Microsoft.AspNetCore.Http.ISession>. Complex types must be serialized by the user using another mechanism, such as JSON.

Use the following sample code to serialize objects:

[!code-csharp[](app-state/6.0samples/SessionSample/Extensions/SessionExtensions.cs?name=snippet1)]

The following example shows how to set and get a serializable object with the `SessionExtensions` class:

[!code-csharp[](app-state/6.0samples/SessionSample/Pages/Index6.cshtml.cs)]

> [!WARNING]
> Storing a live object in the session should be used with caution, as there are many problems that can occur with serialized objects. For more information, see [Sessions should be allowed to store objects (dotnet/aspnetcore #18159)](https://github.com/dotnet/aspnetcore/issues/18159).

## TempData

ASP.NET Core exposes the Razor Pages [TempData](xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel.TempData) or Controller <xref:Microsoft.AspNetCore.Mvc.Controller.TempData>. This property stores data until it's read in another request. The [Keep(String)](xref:Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary.Keep*) and [Peek(string)](xref:Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary.Peek*) methods can be used to examine the data without deletion at the end of the request. [Keep](xref:Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary.Keep*) marks all items in the dictionary for retention. `TempData` is:

* Useful for redirection when data is required for more than a single request.
* Implemented by `TempData` providers using either cookies or session state.

## TempData samples

Consider the following page that creates a customer:

[!code-csharp[](app-state/3.0samples/RazorPagesContacts/Pages/Customers/Create.cshtml.cs?name=snippet&highlight=15-16,30)]

The following page displays `TempData["Message"]`:

[!code-cshtml[](app-state/3.0samples/RazorPagesContacts/Pages/Customers/IndexPeek.cshtml?range=1-14)]

In the preceding markup, at the end of the request, `TempData["Message"]` is **not** deleted because `Peek` is used. Refreshing the page displays the contents of `TempData["Message"]`.

The following markup is similar to the preceding code, but uses `Keep` to preserve the data at the end of the request:

[!code-cshtml[](app-state/6.0samples/RazorPagesContacts/Pages/Customers/IndexKeep.cshtml?range=1-14)]

Navigating between the *IndexPeek* and *IndexKeep* pages won't delete `TempData["Message"]`.

The following code displays `TempData["Message"]`, but at the end of the request, `TempData["Message"]` is deleted:

[!code-cshtml[](app-state/6.0samples/RazorPagesContacts/Pages/Customers/Index.cshtml?range=1-14)]

### TempData providers

The cookie-based TempData provider is used by default to store TempData in cookies.

The cookie data is encrypted using <xref:Microsoft.AspNetCore.DataProtection.IDataProtector>, encoded with <xref:Microsoft.AspNetCore.WebUtilities.Base64UrlTextEncoder>, then chunked. The maximum cookie size is less than [4096 bytes](http://www.faqs.org/rfcs/rfc2965.html) due to encryption and chunking. The cookie data isn't compressed because compressing encrypted data can lead to security problems such as the [CRIME](https://wikipedia.org/wiki/CRIME_(security_exploit)) and [BREACH](https://wikipedia.org/wiki/BREACH_(security_exploit)) attacks. For more information on the cookie-based TempData provider, see <xref:Microsoft.AspNetCore.Mvc.ViewFeatures.CookieTempDataProvider>.

### Choose a TempData provider

Choosing a TempData provider involves several considerations, such as:

* Does the app already use session state? If so, using the session state TempData provider has no additional cost to the app beyond the size of the data.
* Does the app use TempData only sparingly for relatively small amounts of data, up to 500 bytes? If so, the cookie TempData provider adds a small cost to each request that carries TempData. If not, the session state TempData provider can be beneficial to avoid round-tripping a large amount of data in each request until the TempData is consumed.
* Does the app run in a server farm on multiple servers? If so, there's no additional configuration required to use the cookie TempData provider outside of Data Protection. For more information, see <xref:security/data-protection/introduction> and [Key storage providers](xref:security/data-protection/implementation/key-storage-providers).

Most web clients such as web browsers enforce limits on the maximum size of each cookie and the total number of cookies. When using the cookie TempData provider, verify the app won't exceed [these limits](http://www.faqs.org/rfcs/rfc2965.html). Consider the total size of the data. Account for increases in cookie size due to encryption and chunking.

### Configure the TempData provider

The cookie-based TempData provider is enabled by default.

To enable the session-based TempData provider, use the <xref:Microsoft.Extensions.DependencyInjection.MvcViewFeaturesMvcBuilderExtensions.AddSessionStateTempDataProvider%2A> extension method. Only one call to `AddSessionStateTempDataProvider` is required:

[!code-csharp[](app-state/6.0samples/SessionSample/Program.cs?name=snippet&highlight=4,6,8,25)]

## Query strings

A limited amount of data can be passed from one request to another by adding it to the new request's query string. This is useful for capturing state in a persistent manner that allows links with embedded state to be shared through email or social networks. Because URL query strings are public, never use query strings for sensitive data.

In addition to unintended sharing, including data in query strings can expose the app to [Cross-Site Request Forgery (CSRF)](https://www.owasp.org/index.php/Cross-Site_Request_Forgery_(CSRF)) attacks. Any preserved session state must protect against CSRF attacks. For more information, see <xref:security/anti-request-forgery>.

## Hidden fields

Data can be saved in hidden form fields and posted back on the next request. This is common in multi-page forms. Because the client can potentially tamper with the data, the app must always revalidate the data stored in hidden fields.

## `HttpContext.Items`

The <xref:Microsoft.AspNetCore.Http.HttpContext.Items?displayProperty=nameWithType> collection is used to store data while processing a single request. The collection's contents are discarded after a request is processed. The `Items` collection is often used to allow components or middleware to communicate when they operate at different points in time during a request and have no direct way to pass parameters.

In the following example, [middleware](xref:fundamentals/middleware/index) adds `isVerified` to the `Items` collection:

[!code-csharp[](app-state/6.0samples/SessionSample/Program.cs?name=snippet_hci)]

For middleware that's only used in a single app, it's unlikely that using a fixed `string` key would cause a key collision. However, to avoid the possibility of a key collision altogether, an `object` can be used as an item key. This approach is particularly useful for middleware that's shared between apps and also has the advantage of eliminating the use of key strings in the code. The following example shows how to use an `object` key defined in a middleware class:

[!code-csharp[](app-state/6.0samples/SessionSample/Middleware/HttpContextItemsMiddleware.cs?name=snippet1&highlight=4,13)]

Other code can access the value stored in `HttpContext.Items` using the key exposed by the middleware class:

[!code-csharp[](app-state/6.0samples/SessionSample/Pages/Index2.cshtml.cs?name=snippet)]

## Cache

Caching is an efficient way to store and retrieve data. The app can control the lifetime of cached items. For more information, see <xref:performance/caching/response>.

Cached data isn't associated with a specific request, user, or session. **Do not cache user-specific data that may be retrieved by other user requests.**

To cache application wide data, see <xref:performance/caching/memory>.

## Checking session state

[ISession.IsAvailable](xref:Microsoft.AspNetCore.Http.ISession.IsAvailable) is intended to check for transient failures. Calling `IsAvailable` before the session middleware runs throws an `InvalidOperationException`.

Libraries that need to test session availability can use `HttpContext.Features.Get<ISessionFeature>()?.Session != null`.

## Common errors

* "Unable to resolve service for type 'Microsoft.Extensions.Caching.Distributed.IDistributedCache' while attempting to activate 'Microsoft.AspNetCore.Session.DistributedSessionStore'."

  This is typically caused by failing to configure at least one `IDistributedCache` implementation. For more information, see <xref:performance/caching/distributed> and <xref:performance/caching/memory>.

If the session middleware fails to persist a session:

* The middleware logs the exception and the request continues normally.
* This leads to unpredictable behavior.

The session middleware can fail to persist a session if the backing store isn't available. For example, a user stores a shopping cart in session. The user adds an item to the cart but the commit fails. The app doesn't know about the failure so it reports to the user that the item was added to their cart, which isn't true.

The recommended approach to check for errors is to call `await feature.Session.CommitAsync` when the app is done writing to the session. <xref:Microsoft.AspNetCore.Http.ISession.CommitAsync*> throws an exception if the backing store is unavailable. If `CommitAsync` fails, the app can process the exception. <xref:Microsoft.AspNetCore.Http.ISession.LoadAsync*> throws under the same conditions when the data store is unavailable.

## Additional resources

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/app-state/samples) ([how to download](xref:index#how-to-download-a-sample))

<xref:host-and-deploy/web-farm>

:::moniker-end

:::moniker range="< aspnetcore-6.0"

By [Rick Anderson](https://twitter.com/RickAndMSFT), [Kirk Larkin](https://twitter.com/serpent5), and [Diana LaRose](https://github.com/DianaLaRose)

HTTP is a stateless protocol. By default, HTTP requests are independent messages that don't retain user values. This article describes several approaches to preserve user data between requests.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/app-state/samples) ([how to download](xref:index#how-to-download-a-sample))

## State management

State can be stored using several approaches. Each approach is described later in this article.

| Storage approach | Storage mechanism |
| ---------------- | ----------------- |
| [Cookies](#cookies) | HTTP cookies. May include data stored using server-side app code. |
| [Session state](#session-state) | HTTP cookies and server-side app code |
| [TempData](#tempdata) | HTTP cookies or session state |
| [Query strings](#query-strings) | HTTP query strings |
| [Hidden fields](#hidden-fields) | HTTP form fields |
| [HttpContext.Items](#httpcontextitems) | Server-side app code |
| [Cache](#cache) | Server-side app code |

## SignalR/Blazor Server and HTTP context-based state management

[SignalR](xref:signalr/introduction) apps shouldn't use session state and other state management approaches that rely upon a stable HTTP context to store information. SignalR apps can store per-connection state in [`Context.Items` in the hub](xref:signalr/hubs). For more information and alternative state management approaches for Blazor Server apps, see <xref:blazor/state-management?pivots=server>. <!-- https://github.com/aspnet/SignalR/issues/2139 https://github.com/dotnet/AspNetCore.Docs/issues/27956 https://github.com/dotnet/AspNetCore.Docs/issues/14974 -->

## Cookies

Cookies store data across requests. Because cookies are sent with every request, their size should be kept to a minimum. Ideally, only an identifier should be stored in a cookie with the data stored by the app. Most browsers restrict cookie size to 4096 bytes. Only a limited number of cookies are available for each domain.

Because cookies are subject to tampering, they must be validated by the app. Cookies can be deleted by users and expire on clients. However, cookies are generally the most durable form of data persistence on the client.

Cookies are often used for personalization, where content is customized for a known user. The user is only identified and not authenticated in most cases. The cookie can store the user's name, account name, or unique user ID such as a GUID. The cookie can be used to access the user's personalized settings, such as their preferred website background color.

See the [European Union General Data Protection Regulations (GDPR)](https://ec.europa.eu/info/law/law-topic/data-protection) when issuing cookies and dealing with privacy concerns. For more information, see [General Data Protection Regulation (GDPR) support in ASP.NET Core](xref:security/gdpr).

## Session state

Session state is an ASP.NET Core scenario for storage of user data while the user browses a web app. Session state uses a store maintained by the app to persist data across requests from a client. The session data is backed by a cache and considered ephemeral data. The site should continue to function without the session data. Critical application data should be stored in the user database and cached in session only as a performance optimization.

Session isn't supported in [SignalR](xref:signalr/index) apps because a [SignalR Hub](xref:signalr/hubs) may execute independent of an HTTP context. For example, this can occur when a long polling request is held open by a hub beyond the lifetime of the request's HTTP context.

ASP.NET Core maintains session state by providing a cookie to the client that contains a session ID. The cookie session ID:

* Is sent to the app with each request.
* Is used by the app to fetch the session data.

Session state exhibits the following behaviors:

* The session cookie is specific to the browser. Sessions aren't shared across browsers.
* Session cookies are deleted when the browser session ends.
* If a cookie is received for an expired session, a new session is created that uses the same session cookie.
* Empty sessions aren't retained. The session must have at least one value set to persist the session across requests. When a session isn't retained, a new session ID is generated for each new request.
* The app retains a session for a limited time after the last request. The app either sets the session timeout or uses the default value of 20 minutes. Session state is ideal for storing user data:
  * That's specific to a particular session.
  * Where the data doesn't require permanent storage across sessions.
* Session data is deleted either when the <xref:Microsoft.AspNetCore.Http.ISession.Clear%2A?displayProperty=nameWithType> implementation is called or when the session expires.
* There's no default mechanism to inform app code that a client browser has been closed or when the session cookie is deleted or expired on the client.
* Session state cookies aren't marked essential by default. Session state isn't functional unless tracking is permitted by the site visitor. For more information, see <xref:security/gdpr#tempdata-provider-and-session-state-cookies-arent-essential>.

> [!WARNING]
> Don't store sensitive data in session state. The user might not close the browser and clear the session cookie. Some browsers maintain valid session cookies across browser windows. A session might not be restricted to a single user. The next user might continue to browse the app with the same session cookie.

The in-memory cache provider stores session data in the memory of the server where the app resides. In a server farm scenario:

* Use *sticky sessions* to tie each session to a specific app instance on an individual server. [Azure App Service](https://azure.microsoft.com/services/app-service/) uses [Application Request Routing (ARR)](/iis/extensions/planning-for-arr/using-the-application-request-routing-module) to enforce sticky sessions by default. However, sticky sessions can affect scalability and complicate web app updates. A better approach is to use a Redis or SQL Server distributed cache, which doesn't require sticky sessions. For more information, see <xref:performance/caching/distributed>.
* The session cookie is encrypted via <xref:Microsoft.AspNetCore.DataProtection.IDataProtector>. Data Protection must be properly configured to read session cookies on each machine. For more information, see <xref:security/data-protection/introduction> and [Key storage providers](xref:security/data-protection/implementation/key-storage-providers).

### Configure session state

The [Microsoft.AspNetCore.Session](https://www.nuget.org/packages/Microsoft.AspNetCore.Session/) package:

* Is included implicitly by the framework.
* Provides middleware for managing session state.

To enable the session middleware, `Startup` must contain:

* Any of the <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> memory caches. The `IDistributedCache` implementation is used as a backing store for session. For more information, see <xref:performance/caching/distributed>.
* A call to <xref:Microsoft.Extensions.DependencyInjection.SessionServiceCollectionExtensions.AddSession%2A> in `ConfigureServices`.
* A call to <xref:Microsoft.AspNetCore.Builder.SessionMiddlewareExtensions.UseSession%2A> in `Configure`.

The following code shows how to set up the in-memory session provider with a default in-memory implementation of `IDistributedCache`:

[!code-csharp[](app-state/samples/3.x/SessionSample/Startup4.cs?name=snippet1&highlight=12-19,45)]

The preceding code sets a short timeout to simplify testing.

The order of middleware is important.  Call `UseSession` after `UseRouting` and before `UseEndpoints`. See [Middleware Ordering](xref:fundamentals/middleware/index#order).

[HttpContext.Session](xref:Microsoft.AspNetCore.Http.HttpContext.Session) is available after session state is configured.

`HttpContext.Session` can't be accessed before `UseSession` has been called.

A new session with a new session cookie can't be created after the app has begun writing to the response stream. The exception is recorded in the web server log and not displayed in the browser.

### Load session state asynchronously

The default session provider in ASP.NET Core loads session records from the underlying <xref:Microsoft.Extensions.Caching.Distributed.IDistributedCache> backing store asynchronously only if the <xref:Microsoft.AspNetCore.Http.ISession.LoadAsync%2A?displayProperty=nameWithType> method is explicitly called before the <xref:Microsoft.AspNetCore.Http.ISession.TryGetValue%2A>, <xref:Microsoft.AspNetCore.Http.ISession.Set%2A>, or <xref:Microsoft.AspNetCore.Http.ISession.Remove%2A> methods. If `LoadAsync` isn't called first, the underlying session record is loaded synchronously, which can incur a performance penalty at scale.

To have apps enforce this pattern, wrap the <xref:Microsoft.AspNetCore.Session.DistributedSessionStore> and <xref:Microsoft.AspNetCore.Session.DistributedSession> implementations with versions that throw an exception if the `LoadAsync` method isn't called before `TryGetValue`, `Set`, or `Remove`. Register the wrapped versions in the services container.

### Session options

To override session defaults, use <xref:Microsoft.AspNetCore.Builder.SessionOptions>.

| Option | Description |
| ------ | ----------- |
| <xref:Microsoft.AspNetCore.Builder.SessionOptions.Cookie> | Determines the settings used to create the cookie. <xref:Microsoft.AspNetCore.Http.CookieBuilder.Name> defaults to <xref:Microsoft.AspNetCore.Session.SessionDefaults.CookieName?displayProperty=nameWithType> (`.AspNetCore.Session`). <xref:Microsoft.AspNetCore.Http.CookieBuilder.Path> defaults to <xref:Microsoft.AspNetCore.Session.SessionDefaults.CookiePath?displayProperty=nameWithType> (`/`). <xref:Microsoft.AspNetCore.Http.CookieBuilder.SameSite> defaults to <xref:Microsoft.AspNetCore.Http.SameSiteMode.Lax?displayProperty=nameWithType> (`1`). <xref:Microsoft.AspNetCore.Http.CookieBuilder.HttpOnly> defaults to `true`. <xref:Microsoft.AspNetCore.Http.CookieBuilder.IsEssential> defaults to `false`. |
| <xref:Microsoft.AspNetCore.Builder.SessionOptions.IdleTimeout> | The `IdleTimeout` indicates how long the session can be idle before its contents are abandoned. Each session access resets the timeout. This setting only applies to the content of the session, not the cookie. The default is 20 minutes. |
| <xref:Microsoft.AspNetCore.Builder.SessionOptions.IOTimeout> | The maximum amount of time allowed to load a session from the store or to commit it back to the store. This setting may only apply to asynchronous operations. This timeout can be disabled using <xref:System.Threading.Timeout.InfiniteTimeSpan>. The default is 1 minute. |

Session uses a cookie to track and identify requests from a single browser. By default, this cookie is named `.AspNetCore.Session`, and it uses a path of `/`. Because the cookie default doesn't specify a domain, it isn't made available to the client-side script on the page (because <xref:Microsoft.AspNetCore.Http.CookieBuilder.HttpOnly> defaults to `true`).

To override cookie session defaults, use <xref:Microsoft.AspNetCore.Builder.SessionOptions>:

[!code-csharp[](app-state/samples/3.x/SessionSample/Startup2.cs?name=snippet1&highlight=5-10)]

The app uses the <xref:Microsoft.AspNetCore.Builder.SessionOptions.IdleTimeout> property to determine how long a session can be idle before its contents in the server's cache are abandoned. This property is independent of the cookie expiration. Each request that passes through the [Session Middleware](xref:Microsoft.AspNetCore.Session.SessionMiddleware) resets the timeout.

Session state is *non-locking*. If two requests simultaneously attempt to modify the contents of a session, the last request overrides the first. `Session` is implemented as a *coherent session*, which means that all the contents are stored together. When two requests seek to modify different session values, the last request may override session changes made by the first.

### Set and get Session values

Session state is accessed from a Razor Pages <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel> class or MVC <xref:Microsoft.AspNetCore.Mvc.Controller> class with <xref:Microsoft.AspNetCore.Http.HttpContext.Session?displayProperty=nameWithType>. This property is an <xref:Microsoft.AspNetCore.Http.ISession> implementation.

The `ISession` implementation provides several extension methods to set and retrieve integer and string values. The extension methods are in the <xref:Microsoft.AspNetCore.Http> namespace.

`ISession` extension methods:

* [Get(ISession, String)](xref:Microsoft.AspNetCore.Http.SessionExtensions.Get%2A)
* [GetInt32(ISession, String)](xref:Microsoft.AspNetCore.Http.SessionExtensions.GetInt32%2A)
* [GetString(ISession, String)](xref:Microsoft.AspNetCore.Http.SessionExtensions.GetString%2A)
* [SetInt32(ISession, String, Int32)](xref:Microsoft.AspNetCore.Http.SessionExtensions.SetInt32%2A)
* [SetString(ISession, String, String)](xref:Microsoft.AspNetCore.Http.SessionExtensions.SetString%2A)

The following example retrieves the session value for the `IndexModel.SessionKeyName` key (`_Name` in the sample app) in a Razor Pages page:

```csharp
@page
@using Microsoft.AspNetCore.Http
@model IndexModel

...

Name: @HttpContext.Session.GetString(IndexModel.SessionKeyName)
```

The following example shows how to set and get an integer and a string:

[!code-csharp[](app-state/samples/3.x/SessionSample/Pages/Index.cshtml.cs?name=snippet1&highlight=18-19,22-23)]

All session data must be serialized to enable a distributed cache scenario, even when using the in-memory cache. String and integer serializers are provided by the extension methods of <xref:Microsoft.AspNetCore.Http.ISession>. Complex types must be serialized by the user using another mechanism, such as JSON.

Use the following sample code to serialize objects:

[!code-csharp[](app-state/samples/3.x/SessionSample/Extensions/SessionExtensions.cs?name=snippet1)]

The following example shows how to set and get a serializable object with the `SessionExtensions` class:

[!code-csharp[](app-state/samples/3.x/SessionSample/Pages/Index.cshtml.cs?name=snippet2)]

## TempData

ASP.NET Core exposes the Razor Pages [TempData](xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel.TempData) or Controller <xref:Microsoft.AspNetCore.Mvc.Controller.TempData>. This property stores data until it's read in another request. The [Keep(String)](xref:Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary.Keep*) and [Peek(string)](xref:Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary.Peek*) methods can be used to examine the data without deletion at the end of the request. [Keep](xref:Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataDictionary.Keep*) marks all items in the dictionary for retention. `TempData` is:

* Useful for redirection when data is required for more than a single request.
* Implemented by `TempData` providers using either cookies or session state.

## TempData samples

Consider the following page that creates a customer:

[!code-csharp[](app-state/3.0samples/RazorPagesContacts/Pages/Customers/Create.cshtml.cs?name=snippet&highlight=15-16,30)]

The following page displays `TempData["Message"]`:

[!code-cshtml[](app-state/3.0samples/RazorPagesContacts/Pages/Customers/IndexPeek.cshtml?range=1-14)]

In the preceding markup, at the end of the request, `TempData["Message"]` is **not** deleted because `Peek` is used. Refreshing the page displays the contents of `TempData["Message"]`.

The following markup is similar to the preceding code, but uses `Keep` to preserve the data at the end of the request:

[!code-cshtml[](app-state/3.0samples/RazorPagesContacts/Pages/Customers/IndexKeep.cshtml?range=1-14)]

Navigating between the *IndexPeek* and *IndexKeep* pages won't delete `TempData["Message"]`.

The following code displays `TempData["Message"]`, but at the end of the request, `TempData["Message"]` is deleted:

[!code-cshtml[](app-state/3.0samples/RazorPagesContacts/Pages/Customers/Index.cshtml?range=1-14)]

### TempData providers

The cookie-based TempData provider is used by default to store TempData in cookies.

The cookie data is encrypted using <xref:Microsoft.AspNetCore.DataProtection.IDataProtector>, encoded with <xref:Microsoft.AspNetCore.WebUtilities.Base64UrlTextEncoder>, then chunked. The maximum cookie size is less than [4096 bytes](http://www.faqs.org/rfcs/rfc2965.html) due to encryption and chunking. The cookie data isn't compressed because compressing encrypted data can lead to security problems such as the [CRIME](https://wikipedia.org/wiki/CRIME_(security_exploit)) and [BREACH](https://wikipedia.org/wiki/BREACH_(security_exploit)) attacks. For more information on the cookie-based TempData provider, see <xref:Microsoft.AspNetCore.Mvc.ViewFeatures.CookieTempDataProvider>.

### Choose a TempData provider

Choosing a TempData provider involves several considerations, such as:

* Does the app already use session state? If so, using the session state TempData provider has no additional cost to the app beyond the size of the data.
* Does the app use TempData only sparingly for relatively small amounts of data, up to 500 bytes? If so, the cookie TempData provider adds a small cost to each request that carries TempData. If not, the session state TempData provider can be beneficial to avoid round-tripping a large amount of data in each request until the TempData is consumed.
* Does the app run in a server farm on multiple servers? If so, there's no additional configuration required to use the cookie TempData provider outside of Data Protection (see <xref:security/data-protection/introduction> and [Key storage providers](xref:security/data-protection/implementation/key-storage-providers)).

Most web clients such as web browsers enforce limits on the maximum size of each cookie and the total number of cookies. When using the cookie TempData provider, verify the app won't exceed [these limits](http://www.faqs.org/rfcs/rfc2965.html). Consider the total size of the data. Account for increases in cookie size due to encryption and chunking.

### Configure the TempData provider

The cookie-based TempData provider is enabled by default.

To enable the session-based TempData provider, use the <xref:Microsoft.Extensions.DependencyInjection.MvcViewFeaturesMvcBuilderExtensions.AddSessionStateTempDataProvider%2A> extension method. Only one call to `AddSessionStateTempDataProvider` is required:

[!code-csharp[](app-state/samples/3.x/SessionSample/Startup3.cs?name=snippet1&highlight=4,6,8,30)]

## Query strings

A limited amount of data can be passed from one request to another by adding it to the new request's query string. This is useful for capturing state in a persistent manner that allows links with embedded state to be shared through email or social networks. Because URL query strings are public, never use query strings for sensitive data.

In addition to unintended sharing, including data in query strings can expose the app to [Cross-Site Request Forgery (CSRF)](https://www.owasp.org/index.php/Cross-Site_Request_Forgery_(CSRF)) attacks. Any preserved session state must protect against CSRF attacks. For more information, see <xref:security/anti-request-forgery>.

## Hidden fields

Data can be saved in hidden form fields and posted back on the next request. This is common in multi-page forms. Because the client can potentially tamper with the data, the app must always revalidate the data stored in hidden fields.

## HttpContext.Items

The <xref:Microsoft.AspNetCore.Http.HttpContext.Items?displayProperty=nameWithType> collection is used to store data while processing a single request. The collection's contents are discarded after a request is processed. The `Items` collection is often used to allow components or middleware to communicate when they operate at different points in time during a request and have no direct way to pass parameters.

In the following example, [middleware](xref:fundamentals/middleware/index) adds `isVerified` to the `Items` collection:

[!code-csharp[](app-state/samples/3.x/SessionSample/Startup.cs?name=snippet1)]

For middleware that's only used in a single app, fixed `string` keys are acceptable. Middleware shared between apps should use unique object keys to avoid key collisions. The following example shows how to use a unique object key defined in a middleware class:

[!code-csharp[](app-state/samples/3.x/SessionSample/Middleware/HttpContextItemsMiddleware.cs?name=snippet1&highlight=4,13)]

Other code can access the value stored in `HttpContext.Items` using the key exposed by the middleware class:

[!code-csharp[](app-state/samples/3.x/SessionSample/Pages/Index.cshtml.cs?name=snippet3)]

This approach also has the advantage of eliminating the use of key strings in the code.

## Cache

Caching is an efficient way to store and retrieve data. The app can control the lifetime of cached items. For more information, see <xref:performance/caching/response>.

Cached data isn't associated with a specific request, user, or session. **Do not cache user-specific data that may be retrieved by other user requests.**

To cache application wide data, see <xref:performance/caching/memory>.

## Common errors

* "Unable to resolve service for type 'Microsoft.Extensions.Caching.Distributed.IDistributedCache' while attempting to activate 'Microsoft.AspNetCore.Session.DistributedSessionStore'."

  This is typically caused by failing to configure at least one `IDistributedCache` implementation. For more information, see <xref:performance/caching/distributed> and <xref:performance/caching/memory>.

If the session middleware fails to persist a session:

* The middleware logs the exception and the request continues normally.
* This leads to unpredictable behavior.

The session middleware can fail to persist a session if the backing store isn't available. For example, a user stores a shopping cart in session. The user adds an item to the cart but the commit fails. The app doesn't know about the failure so it reports to the user that the item was added to their cart, which isn't true.

The recommended approach to check for errors is to call `await feature.Session.CommitAsync` when the app is done writing to the session. <xref:Microsoft.AspNetCore.Http.ISession.CommitAsync*> throws an exception if the backing store is unavailable. If `CommitAsync` fails, the app can process the exception. <xref:Microsoft.AspNetCore.Http.ISession.LoadAsync*> throws under the same conditions when the data store is unavailable.

## Additional resources

<xref:host-and-deploy/web-farm>
:::moniker-end
