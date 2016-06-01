Request Features
================

By `Steve Smith`_

Individual web server features related to how HTTP requests and responses are handled have been factored into separate interfaces. These abstractions are used by individual server implementations and middleware to create and modify the application's hosting pipeline.

.. contents:: Sections:
  :local:
  :depth: 1

Feature interfaces
------------------

ASP.NET Core defines a number of HTTP feature interfaces in :dn:ns:`Microsoft.AspNetCore.Http.Features` which are used by servers to identify the features they support. The following feature interfaces handle requests and return responses:

:dn:iface:`~Microsoft.AspNetCore.Http.Features.IHttpRequestFeature`
  Defines the structure of an HTTP request, including the protocol, path, query string, headers, and body.

:dn:iface:`~Microsoft.AspNetCore.Http.Features.IHttpResponseFeature`
  Defines the structure of an HTTP response, including the status code, headers, and body of the response.

:dn:iface:`~Microsoft.AspNetCore.Http.Features.Authentication.IHttpAuthenticationFeature`
  Defines support for identifying users based on a ``ClaimsPrincipal`` and specifying an authentication handler.

:dn:iface:`~Microsoft.AspNetCore.Http.Features.IHttpUpgradeFeature`
  Defines support for :rfc:`HTTP Upgrades <2616#section-14.42>`, which allow the client to specify which additional protocols it would like to use if the server wishes to switch protocols.

:dn:iface:`~Microsoft.AspNetCore.Http.Features.IHttpBufferingFeature`
  Defines methods for disabling buffering of requests and/or responses.

:dn:iface:`~Microsoft.AspNetCore.Http.Features.IHttpConnectionFeature`
  Defines properties for local and remote addresses and ports.

:dn:iface:`~Microsoft.AspNetCore.Http.Features.IHttpRequestLifetimeFeature`
  Defines support for aborting connections, or detecting if a request has been terminated prematurely, such as by a client disconnect.

:dn:iface:`~Microsoft.AspNetCore.Http.Features.IHttpSendFileFeature`
  Defines a method for sending files asynchronously.

:dn:iface:`~Microsoft.AspNetCore.Http.Features.IHttpWebSocketFeature`
  Defines an API for supporting web sockets.

:dn:iface:`~Microsoft.AspNetCore.Http.Features.IHttpRequestIdentifierFeature`
  Adds a property that can be implemented to uniquely identify requests.

:dn:iface:`~Microsoft.AspNetCore.Http.Features.ISessionFeature`
  Defines ``ISessionFactory`` and ``ISession`` abstractions for supporting user sessions.

:dn:iface:`~Microsoft.AspNetCore.Http.Features.ITlsConnectionFeature`
  Defines an API for retrieving client certificates.

:dn:iface:`~Microsoft.AspNetCore.Http.Features.ITlsTokenBindingFeature`
  Defines methods for working with TLS token binding parameters.

.. note:: :dn:iface:`~Microsoft.AspNetCore.Http.Features.ISessionFeature` is not a server feature, but is implemented by the :dn:cls:`~Microsoft.AspNetCore.Session.SessionMiddleware` (see :doc:`/fundamentals/app-state`).
  
Feature collections
-------------------

The :dn:prop:`~Microsoft.AspNetCore.Http.HttpContext.Features` property of :dn:cls:`~Microsoft.AspNetCore.Http.HttpContext` provides an interface for getting and setting the available HTTP features for the current request. Since the feature collection is mutable even within the context of a request, middleware can be used to modify the collection and add support for additional features.

Middleware and request features
-------------------------------

While servers are responsible for creating the feature collection, middleware can both add to this collection and consume features from the collection. For example, the :dn:cls:`~Microsoft.AspNetCore.StaticFiles.StaticFileMiddleware` accesses the :dn:iface:`~Microsoft.AspNetCore.Http.Features.IHttpSendFileFeature` feature. If the feature exists, it is used to send the requested static file from its physical path. Otherwise, a slower alternative method is used to send the file. When available, the :dn:iface:`~Microsoft.AspNetCore.Http.Features.IHttpSendFileFeature` allows the operating system to open the file and perform a direct kernel mode copy to the network card.

Additionally, middleware can add to the feature collection established by the server. Existing features can even be replaced by middleware, allowing the middleware to augment the functionality of the server. Features added to the collection are available immediately to other middleware or the underlying application itself later in the request pipeline.

By combining custom server implementations and specific middleware enhancements, the precise set of features an application requires can be constructed. This allows missing features to be added without requiring a change in server, and ensures only the minimal amount of features are exposed, thus limiting attack surface area and improving performance.

Summary
-------

Feature interfaces define specific HTTP features that a given request may support. Servers define collections of features, and the initial set of features supported by that server, but middleware can be used to enhance these features.

Additional Resources
--------------------

- :doc:`servers`
- :doc:`middleware`
- :doc:`owin`
