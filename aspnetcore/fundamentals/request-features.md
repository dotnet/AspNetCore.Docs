---
title: Request Features in ASP.NET Core
author: ardalis
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: d1fbd23c-2ff9-4216-b908-0201ff3afb7c
ms.technology: aspnet
ms.prod: asp.net-core
uid: fundamentals/request-features
---
# Request Features in ASP.NET Core

By [Steve Smith](https://ardalis.com/)

Web server implementation details related to HTTP requests and responses are defined in interfaces. These interfaces are used by server implementations and middleware to create and modify the application's hosting pipeline.

## Feature interfaces

ASP.NET Core defines a number of HTTP feature interfaces in `Microsoft.AspNetCore.Http.Features` which are used by servers to identify the features they support. The following feature interfaces handle requests and return responses:

`IHttpRequestFeature`
   Defines the structure of an HTTP request, including the protocol, path, query string, headers, and body.

`IHttpResponseFeature`
   Defines the structure of an HTTP response, including the status code, headers, and body of the response.

`IHttpAuthenticationFeature`
   Defines support for identifying users based on a `ClaimsPrincipal` and specifying an authentication handler.

`IHttpUpgradeFeature`
   Defines support for [HTTP Upgrades](https://tools.ietf.org/html/rfc2616.html#section-14.42), which allow the client to specify which additional protocols it would like to use if the server wishes to switch protocols.

`IHttpBufferingFeature`
   Defines methods for disabling buffering of requests and/or responses.

`IHttpConnectionFeature`
   Defines properties for local and remote addresses and ports.

`IHttpRequestLifetimeFeature`
   Defines support for aborting connections, or detecting if a request has been terminated prematurely, such as by a client disconnect.

`IHttpSendFileFeature`
   Defines a method for sending files asynchronously.

`IHttpWebSocketFeature`
   Defines an API for supporting web sockets.

`IHttpRequestIdentifierFeature`
   Adds a property that can be implemented to uniquely identify requests.

`ISessionFeature`
   Defines `ISessionFactory` and `ISession` abstractions for supporting user sessions.

`ITlsConnectionFeature`
   Defines an API for retrieving client certificates.

`ITlsTokenBindingFeature`
   Defines methods for working with TLS token binding parameters.

> [!NOTE]
> `ISessionFeature` is not a server feature, but is implemented by the `SessionMiddleware` (see [Managing Application State](app-state.md)).

## Feature collections

The `Features` property of `HttpContext` provides an interface for getting and setting the available HTTP features for the current request. Since the feature collection is mutable even within the context of a request, middleware can be used to modify the collection and add support for additional features.

## Middleware and request features

While servers are responsible for creating the feature collection, middleware can both add to this collection and consume features from the collection. For example, the `StaticFileMiddleware` accesses the `IHttpSendFileFeature` feature. If the feature exists, it is used to send the requested static file from its physical path. Otherwise, a slower alternative method is used to send the file. When available, the `IHttpSendFileFeature` allows the operating
system to open the file and perform a direct kernel mode copy to the network card.

Additionally, middleware can add to the feature collection established by the server. Existing features can even be replaced by middleware, allowing the middleware to augment the functionality of the server. Features added to the collection are available immediately to other middleware or the underlying application itself later in the request pipeline.

By combining custom server implementations and specific middleware enhancements, the precise set of features an application requires can be constructed. This allows missing features to be added without requiring a change in server, and ensures only the minimal amount of features are exposed, thus limiting attack surface area and improving performance.

## Summary

Feature interfaces define specific HTTP features that a given request may support. Servers define collections of features, and the initial set of features supported by that server, but middleware can be used to enhance these features.

## Additional Resources

* [Servers](servers/index.md)

* [Middleware](middleware.md)

* [Open Web Interface for .NET (OWIN)](owin.md)
