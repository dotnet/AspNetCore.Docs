Request Features
================

By `Steve Smith`_

Individual web server features related to how HTTP requests and responses are handled have been factored into separate interfaces, defined in the `HttpAbstractions <https://github.com/aspnet/HttpAbstractions>`_ package. These abstractions are used by individual server implementations and middleware to create and modify the application's hosting pipeline.

In this article:
	- `Feature interfaces`_
	- `Feature collections`_
	
Feature interfaces
------------------

ASP.NET 5 defines a number of `Http Feature Interfaces <https://github.com/aspnet/HttpAbstractions/tree/dev/src/Microsoft.AspNet.Http.Features>`_, which are used by servers to identify which features they support. The most basic features of a web server are the ability to handle requests and return responses, as defined by the following feature interfaces:

`IHttpRequestFeature <https://github.com/aspnet/HttpAbstractions/blob/dev/src/Microsoft.AspNet.Http.Features/IHttpRequestFeature.cs>`_
	Defines the structure of an HTTP request, including the protocol, path, QueryString, headers, and body.

`IHttpResponseFeature <https://github.com/aspnet/HttpAbstractions/blob/dev/src/Microsoft.AspNet.Http.Features/IHttpResponseFeature.cs>`_
	Defines the structure of an HTTP response, including the status code, headers, and body of the response.

`IHttpAuthenticationFeature <https://github.com/aspnet/HttpAbstractions/blob/dev/src/Microsoft.AspNet.Http.Features/IHttpAuthenticationFeature.cs>`_
	Defines support for identifying users based on a ``ClaimsPrincipal`` and specifying an authentication handler.

`IHttpUpgradeFeature <https://github.com/aspnet/HttpAbstractions/blob/dev/src/Microsoft.AspNet.Http.Features/IHttpUpgradeFeature.cs>`_
	Defines support for `HTTP Upgrades <http://tools.ietf.org/html/rfc2616#section-14.42>`_, which allow the client to specify which additional protocols it would like to use if the server wishes to switch protocols.

`IHttpBufferingFeature <https://github.com/aspnet/HttpAbstractions/blob/dev/src/Microsoft.AspNet.Http.Features/IHttpBufferingFeature.cs>`_
	Defines methods for disabling buffering of requests and/or responses.

`IHttpConnectionFeature <https://github.com/aspnet/HttpAbstractions/blob/dev/src/Microsoft.AspNet.Http.Features/IHttpConnectionFeature.cs>`_
	Defines properties for local and remote addresses and ports.

`IHttpRequestLifetimeFeature <https://github.com/aspnet/HttpAbstractions/blob/dev/src/Microsoft.AspNet.Http.Features/IHttpRequestLifetimeFeature.cs>`_
	Defines support for aborting connections.

`IHttpSendFileFeature <https://github.com/aspnet/HttpAbstractions/blob/dev/src/Microsoft.AspNet.Http.Features/IHttpSendFileFeature.cs>`_
	Defines a method for sending files asynchronously.

`IHttpWebSocketFeature <https://github.com/aspnet/HttpAbstractions/blob/dev/src/Microsoft.AspNet.Http.Features/IHttpWebSocketFeature.cs>`_
	Defines an API for supporting web sockets.

`IRequestIdentifierFeature <https://github.com/aspnet/HttpAbstractions/blob/dev/src/Microsoft.AspNet.Http.Features/IRequestIdentifierFeature.cs>`_
	Adds a property that can be implemented to uniquely identify requests.

`ISessionFeature <https://github.com/aspnet/HttpAbstractions/blob/dev/src/Microsoft.AspNet.Http.Features/ISessionFeature.cs>`_
	Defines ``ISessionFactory`` and ``ISession`` abstractions for supporting user sessions.

`ITlsConnectionFeature <https://github.com/aspnet/HttpAbstractions/blob/dev/src/Microsoft.AspNet.Http.Features/ITlsConnectionFeature.cs>`_
	Defines an API for retrieving client certificates.

`ITlsTokenBindingFeature <https://github.com/aspnet/HttpAbstractions/blob/dev/src/Microsoft.AspNet.Http.Features/ITlsTokenBindingFeature.cs>`_
	Defines methods for working with TLS token binding parameters.
	
	
Feature collections
-------------------

The HttpAbstractions repository includes a FeatureModel package. Its main ingredient is the `FeatureCollection <https://github.com/aspnet/HttpAbstractions/blob/dev/src/Microsoft.AspNet.FeatureModel/FeatureCollection.cs>`_ type, which is used frequently by :doc:`servers` and their requests, as well as :doc:`middleware`, to identify which features they support. The `HttpContext <https://github.com/aspnet/HttpAbstractions/blob/dev/src/Microsoft.AspNet.Http.Abstractions/HttpContext.cs>`_ type defined in ``Microsoft.AspNet.Http.Abstractions`` (not to be confused with the ``HttpContext`` defined in ``System.Web``) provides an interface for getting and setting these features. The `OwinEnvironment <https://github.com/aspnet/HttpAbstractions/blob/5fe8037281bb826e0708abdcdafbc76571dc21f5/src/Microsoft.AspNet.Owin/OwinEnvironment.cs>`_ class provides some examples of how application code can verify the presence of needed features, and react accordingly.

.. code-block:: c#

	public OwinEnvironment(HttpContext context)
	{
		if (context.GetFeature<IHttpRequestFeature>() == null)
		{
			throw new ArgumentException("Missing required feature: " + 
				nameof(IHttpRequestFeature) + ".", nameof(context));
		}
		if (context.GetFeature<IHttpResponseFeature>() == null)
		{
			throw new ArgumentException("Missing required feature: " + 
				nameof(IHttpResponseFeature) + ".", nameof(context));
		}
		// Code removed for brevity
	}

In the example above, ``OwinEnvironment``'s constructor verifies that the ``HttpContext`` it is working with has, at a minimum, support for HTTP requests and responses, and throws an exception otherwise. Similarly, support for features can be specified, as is done in the default constructor for `DefaultHttpContext <https://github.com/aspnet/HttpAbstractions/blob/6407a1672d92d89c4140fd1e5c07052599d4b97e/src/Microsoft.AspNet.Http/DefaultHttpContext.cs#L33-L38>`_:

.. code-block:: c#

	public DefaultHttpContext()
		: this(new FeatureCollection())
	{
		SetFeature<IHttpRequestFeature>(new HttpRequestFeature());
		SetFeature<IHttpResponseFeature>(new HttpResponseFeature());
	}

Since feature collections are mutable, even within the context of a request, middleware can be used to modify the collection and add support for additional features.

Summary
-------
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	