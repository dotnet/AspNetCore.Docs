Request Features
================

By `Steve Smith`_

Individual web server features related to how HTTP requests and responses are handled have been factored into separate interfaces. These abstractions are used by individual server implementations and middleware to create and modify the application's hosting pipeline.

.. contents:: Sections:
  :local:
  :depth: 1

Feature interfaces
------------------

ASP.NET Core defines a number of `HTTP feature interfaces <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNet/Http/Features/index.html>`_, which are used by servers to identify which features they support. The most basic features of a web server are the ability to handle requests and return responses, as defined by the following feature interfaces:

`IHttpRequestFeature <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNet/Http/Features/IHttpRequestFeature/index.html>`_
  Defines the structure of an HTTP request, including the protocol, path, query string, headers, and body.

`IHttpResponseFeature <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNet/Http/Features/IHttpResponseFeature/index.html>`_
  Defines the structure of an HTTP response, including the status code, headers, and body of the response.

`IHttpAuthenticationFeature <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNet/Http/Features/Authentication/IHttpAuthenticationFeature/index.html>`_
  Defines support for identifying users based on a ``ClaimsPrincipal`` and specifying an authentication handler.

`IHttpUpgradeFeature <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNet/Http/Features/IHttpUpgradeFeature/index.html>`_
  Defines support for `HTTP Upgrades <http://tools.ietf.org/html/rfc2616#section-14.42>`_, which allow the client to specify which additional protocols it would like to use if the server wishes to switch protocols.

`IHttpBufferingFeature <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNet/Http/Features/IHttpBufferingFeature/index.html>`_
  Defines methods for disabling buffering of requests and/or responses.

`IHttpConnectionFeature <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNet/Http/Features/IHttpConnectionFeature/index.html>`_
  Defines properties for local and remote addresses and ports.

`IHttpRequestLifetimeFeature <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNet/Http/Features/IHttpRequestLifetimeFeature/index.html>`_
  Defines support for aborting connections, or detecting if a request has been terminated prematurely, such as by a client disconnect.

`IHttpSendFileFeature <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNet/Http/Features/IHttpSendFileFeature/index.html>`_
  Defines a method for sending files asynchronously.

`IHttpWebSocketFeature <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNet/Http/Features/IHttpWebSocketFeature/index.html>`_
  Defines an API for supporting web sockets.

`IHttpRequestIdentifierFeature <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNet/Http/Features/IHttpRequestIdentifierFeature/index.html>`_
  Adds a property that can be implemented to uniquely identify requests.

`ISessionFeature <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNet/Http/Features/ISessionFeature/index.html>`_
  Defines ``ISessionFactory`` and ``ISession`` abstractions for supporting user sessions.

`ITlsConnectionFeature <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNet/Http/Features/ITlsConnectionFeature/index.html>`_
  Defines an API for retrieving client certificates.

`ITlsTokenBindingFeature <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNet/Http/Features/ITlsTokenBindingFeature/index.html>`_
  Defines methods for working with TLS token binding parameters.

.. note:: ``ISessionFeature`` is not a server feature, but is implemented by the ``SessionMiddleware`` (see :doc:`/fundamentals/app-state`).
  
Feature collections
-------------------

The `HttpContext.Features <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNet/Http/HttpContext/index.html#prop-Microsoft.AspNet.Http.HttpContext.Features>`_ property provides an interface for getting and setting the available HTTP features for the current request. Since the feature collection is mutable even within the context of a request middleware can be used to modify the collection and add support for additional features.

Middleware and request features
-------------------------------

While servers are responsible for creating the feature collection, middleware can both add to this collection and consume features from the collection. For example, the `StaticFileMiddleware  <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNet/StaticFiles/StaticFileMiddleware/index.html>`__ accesses the ``IHttpSendFileFeature`` feature. If the feature exists, it is used to send the requested static file from its physical path. Otherwise, a much slower workaround method is used to send the file. When available, the ``IHttpSendFileFeature`` allows the operating system to open the file and perform a direct kernel mode copy to the network card.

Additionally, middleware can add to the feature collection established by the server. Existing features can even be replaced by middleware, allowing the middleware to augment the functionality of the server. Features added to the collection are available immediately to other middleware or the underlying application itself later in the request pipeline.

.. note:: Use the `FeatureCollectionExtensions <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNet/Http/Features/FeatureCollectionExtensions/index.html>`__ to easily get and set features on the ``HttpContext``.

By combining custom server implementations and specific middleware enhancements, the precise set of features an application requires can be constructed. This allows missing features to be added without requiring a change in server, and ensures only the minimal amount of features are exposed, thus limiting attack surface area and improving performance.

Summary
-------

Feature interfaces define specific HTTP features that a given request may support. Servers define collections of features, and the initial set of features supported by that server, but middleware can be used to enhance these features.

Additional Resources
--------------------

- :doc:`servers`
- :doc:`middleware`
- :doc:`owin`
