Request Features
================

By `Steve Smith`_

Individual web server features related to how HTTP requests and responses are handled have been factored into separate interfaces, defined in the `HttpAbstractions <https://github.com/aspnet/HttpAbstractions>`_ package. These abstractions are used by individual server implementations and middleware to create and modify the application's hosting pipeline.

In this article:
	- `Feature interfaces`_
	- `Feature collections`_
	- `Middleware and request features`_
	
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

.. note:: ``ISessionFeature`` is not a server feature, but is implemented by `SessionMiddleware <https://github.com/aspnet/Session/blob/42321d243b1d4bea8e2677a8382a0f20737e4b3d/src/Microsoft.AspNet.Session/SessionMiddleware.cs>`_.
	
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

Middleware and request features
-------------------------------

While servers are responsible for creating the feature collection, middleware can both add to this collection and consume features from the collection. For example, the `StaticFileMiddleware  <https://github.com/aspnet/StaticFiles/blob/1.0.0-beta5/src/Microsoft.AspNet.StaticFiles/StaticFileMiddleware.cs>`_ accesses a feature (``IHttpSendFileFeature``) through the `StaticFileContext <https://github.com/aspnet/StaticFiles/blob/1.0.0-beta5/src/Microsoft.AspNet.StaticFiles/StaticFileContext.cs>`_:

.. code-block:: c#
	:caption: StaticFileContext.cs
	:emphasize-lines: 6

	public async Task SendAsync()
	{
		ApplyResponseHeaders(Constants.Status200Ok);

		string physicalPath = _fileInfo.PhysicalPath;
		var sendFile = _context.GetFeature<IHttpSendFileFeature>();
		if (sendFile != null && !string.IsNullOrEmpty(physicalPath))
		{
			await sendFile.SendFileAsync(physicalPath, 0, _length, _context.RequestAborted);
			return;
		}

		Stream readStream = _fileInfo.CreateReadStream();
		try
		{
			await StreamCopyOperation.CopyToAsync(readStream, _response.Body, _length, _context.RequestAborted);
		}
		finally
		{
			readStream.Dispose();
		}
	}

In the code above, the ``StaticFileContext`` class's ``SendAsync`` method accesses the server's implementation of the ``IHttpSendFileFeature`` feature (by calling ``GetFeature`` on `HttpContext <https://github.com/aspnet/HttpAbstractions/blob/master/src/Microsoft.AspNet.Http/DefaultHttpContext.cs>`_). If the feature exists, it is used to send the requested static file from its physical path. Otherwise, a much slower workaround method is used to send the file (when available, the ``IHttpSendFileFeature`` allows the operating system to open the file and perform a direct kernel mode copy to the network card).

.. note:: Use the pattern shown above for feature detection from middleware or within your application. Calls made to ``GetFeature`` will return an instance if the feature is supported, or ``null`` otherwise.

Additionally, middleware can add to the feature collection established by the server, by calling ``SetFeature<>``. Existing features can even be replaced by middleware, allowing the middleware to augment the functionality of the server. Features added to the collection are available immediately to other middleware or the underlying application itself later in the request pipeline.

The `WebSocketMiddleware <https://github.com/aspnet/WebSockets/blob/c86b157ad3cd00e8848c4895fe29de2f9d81a0b4/src/Microsoft.AspNet.WebSockets.Server/WebSocketMiddleware.cs>`_ follows this approach, first detecting if the server supports upgrading (``IHttpUpgradeFeature``), and then adding a new ``IHttpWebSocketFeature`` to the feature collection if it doesn't already exist. Alternately, if configured to replace the existing implementation (via ``_options.ReplaceFeature``), it will overwrite any existing implementation with its own.

.. code-block:: c#
	:emphasize-lines: 4,7,9-10

	public Task Invoke(HttpContext context)
	{
		// Detect if an opaque upgrade is available. If so, add a websocket upgrade.
		var upgradeFeature = context.GetFeature<IHttpUpgradeFeature>();
		if (upgradeFeature != null)
		{
			if (_options.ReplaceFeature || context.GetFeature<IHttpWebSocketFeature>() == null)
			{
				context.SetFeature<IHttpWebSocketFeature>(new UpgradeHandshake(context, 
					upgradeFeature, _options));
			}
		}

		return _next(context);
	}

By combining custom server implementations and specific middleware enhancements, the precise set of features an application requires can be constructed. This allows missing features to be added without requiring a change in server, and ensures only the minimal amount of features are exposed, thus limiting attack surface area and improving performance.

Summary
-------

Feature interfaces define specific HTTP features that a given request may support. Servers define collections of features, and the initial set of features supported by that server, but middleware can be used to enhance these features.
	
Additional Resources
--------------------

- :doc:`servers`
- :doc:`middleware`
- :doc:`owin`

	
	
	
	
	
	
	
	
	
	
	