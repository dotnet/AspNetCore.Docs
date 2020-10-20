---
title: Request Features in ASP.NET Core
author: ardalis
description: Learn about web server implementation details related to HTTP requests and responses that are defined in interfaces for ASP.NET Core.
ms.author: riande
ms.date: 10/14/2016
no-loc: ["ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: fundamentals/request-features
---
# Request Features in ASP.NET Core

By [Steve Smith](https://ardalis.com/)

The `HttpContext` API that applications and middleware use to process requests has an abstraction layer undernieth it called feature interfaces. Each feature interface provides a granular subset of the functionality exposed by `HttpContext`. These interfaces can be added, modified, wrapped, replaced, or even removed by the server or middleware as the request is processed without having to re-implement the entire HttpContext. They can also be used to mock functionality when testing.

## Feature collections

The `Features` property of `HttpContext` provides access to the collection of feature interfaces for the current request. Since the feature collection is mutable even within the context of a request, middleware can be used to modify the collection and add support for additional features. Some advanced features are only available by accessing the associated interface through the feature collection.

## Feature interfaces

ASP.NET Core defines a number of common HTTP feature interfaces in `Microsoft.AspNetCore.Http.Features` which are shared by various servers and middleware to identify the features they support. Servers and middleware may also provide their own interfaces with additional functionality.

Most feature interfaces provide optional, light-up functionality and their associated `HttpCotext` APIs provide defaults if the feature is not preasent. A few interfaces are indicated below as required beacause the provide core request and response functionality and must be implemented in order to process the request.

The following feature interfaces are from `Microsoft.AspNetCore.Http.Features`:

`IHttpRequestFeature`
   Defines the structure of an HTTP request, including the protocol, path, query string, headers, and body. This feature is required in order to process requests.

`IHttpResponseFeature`
   Defines the structure of an HTTP response, including the status code, headers, and body of the response. This feature is required in order to process requests.

::: moniker range=">= aspnetcore-3.0"

 `IHttpResponseBodyFeature`
   Defines different ways of writing out the response body, using either a `Stream`, a `PipeWriter`, or a file. This feature is required in order to process requests. This replaces `IHttpResponseFeature.Body` and `IHttpSendFileFeature`.

::: moniker-end

`IHttpAuthenticationFeature`
   Holds the `ClaimsPrincipal` currently associated with the request.

`IFormFeature`
   Used to parse and cache incoming HTTP and multipart form submissions.

::: moniker range=">= aspnetcore-2.0"

`IHttpBodyControlFeature`
   Used to control if synchronous IO operations are allowed for the request or response bodies.

::: moniker-end
   
::: moniker range="< aspnetcore-3.0"

`IHttpBufferingFeature`
   Defines methods for disabling buffering of requests and/or responses.

::: moniker-end

`IHttpConnectionFeature`
   Defines properties for the connection id and local and remote addresses and ports.

::: moniker range=">= aspnetcore-2.0"

`IHttpMaxRequestBodySizeFeature`
   Controls the maximum allowed request body size for the current request.

::: moniker-end

::: moniker range=">= aspnetcore-5.0"

`IHttpRequestBodyDetectionFeature`
   Indicates if the request can have a body.

::: moniker-end

`IHttpRequestIdentifierFeature`
   Adds a property that can be implemented to uniquely identify requests.

`IHttpRequestLifetimeFeature`
   Defines support for aborting connections, or detecting if a request has been terminated prematurely, such as by a client disconnect.

::: moniker range=">= aspnetcore-3.0"

`IHttpRequestTrailersFeature`
   Provides access to the request trailer headers, if any.

`IHttpResetFeature`
   Used to send reset messages for protocols that support them such as HTTP/2 or HTTP/3.

::: moniker-end

::: moniker range=">= aspnetcore-2.2"

`IHttpResponseTrailersFeature`
   Enables the application to provide response trailer headers if supported.

::: moniker-end

::: moniker range="< aspnetcore-3.0"

`IHttpSendFileFeature`
   Defines a method for sending files asynchronously.

::: moniker-end

`IHttpUpgradeFeature`
   Defines support for [HTTP Upgrades](https://tools.ietf.org/html/rfc2616.html#section-14.42), which allow the client to specify which additional protocols it would like to use if the server wishes to switch protocols.

`IHttpWebSocketFeature`
   Defines an API for supporting web sockets.

::: moniker range=">= aspnetcore-3.0"

`IHttpsCompressionFeature`
   Controls if response compression should be used over https connections.

::: moniker-end

`IItemsFeature`
   Stores the Items collection for per request application state.

`IQueryFeature`
   Parses and caches the query string.
   
::: moniker range=">= aspnetcore-3.0"

`IRequestBodyPipeFeature`
   Represents the request body as a PipeReader.
 
::: moniker-end

`IRequestCookiesFeature`
   Parses and caches the request `Cookie` header values.

`IResponseCookiesFeature`
   Controls how response cookies are applied to the `Set-Cookie` header.

::: moniker range=">= aspnetcore-2.2"

`IServerVariablesFeature`
   This feature provides access to request server variables such as those provided by IIS.

::: moniker-end
   
`IServiceProvidersFeature`
   Provides access to an `IServiceProvider` with scoped request services.

`ISessionFeature`
   Defines `ISessionFactory` and `ISession` abstractions for supporting user sessions. `ISessionFeature` is implemented by the `SessionMiddleware` (see [Managing Application State](app-state.md)).

`ITlsConnectionFeature`
   Defines an API for retrieving client certificates.

`ITlsTokenBindingFeature`
   Defines methods for working with TLS token binding parameters.
   
::: moniker range=">= aspnetcore-2.2"
   
`ITrackingConsentFeature`
   Used to query, grant, and withdraw user consent regarding the storage of user information related to site activity and functionality.
   
::: moniker-end

## Summary

Feature interfaces define specific HTTP functionality that a given request may support. Servers define collections of features, and the initial set of features supported by that server, but middleware can be used to enhance these features.

## Additional resources

* [Servers](xref:fundamentals/servers/index)
* [Middleware](xref:fundamentals/middleware/index)
