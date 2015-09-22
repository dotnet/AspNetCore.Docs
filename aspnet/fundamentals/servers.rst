Servers
=======

By `Steve Smith`_

ASP.NET 5 is completely decoupled from the web server environment that hosts the application. As released, ASP.NET 5 supports IIS and IIS Express, WebListener, and Kestrel web servers, which run on a variety of platforms. Developers and third party software vendors can create their own custom servers as well within which to host their ASP.NET 5 applications.

In this article:
	- `Servers and commands`_
	- `Supported features by server`_
	- `IIS and IIS Express`_
	- `WebListener`_
	- `Kestrel`_
	- `Choosing a server`_
	- `Custom Servers`_
	
`Browse or download samples on GitHub <https://github.com/aspnet/Docs/tree/master/docs/fundamentals/servers/sample>`_.

Servers and commands
--------------------

ASP.NET 5 is designed to decouple web applications from the underlying web server that hosts them. Traditionally, ASP.NET applications have been windows-only (unless `hosted via mono <http://www.mono-project.com/docs/web/aspnet/>`_) and hosted on the built-in web server for windows, Internet Information Server (IIS) (or a development server, like `IIS Express <http://www.iis.net/learn/extensions/introduction-to-iis-express/iis-express-overview>`_ or earlier development web servers). While IIS is still the recommended way to host production ASP.NET applications on Windows, the cross-platform nature of ASP.NET allows it to be hosted in any number of different web servers, on multiple operating systems.

ASP.NET 5 ships with support for 3 different servers:

- Microsoft.AspNet.Server.IIS
- Microsoft.AspNet.Server.WebListener (WebListener)
- Microsoft.AspNet.Server.Kestrel (Kestrel)

ASP.NET 5 does not directly listen for requests, but instead relies on the HTTP server implementation to surface the request to the application as a set of :doc:`feature interfaces <request-features>` composed into an HttpContext. Both IIS and WebListener are Windows-only; Kestrel is designed to run cross-platform. You can configure your application to be hosted by any or all of these servers by specifying commands in your ``project.json`` file. You can even specify an application entry point for your application, and run it as an executable (using ``dnx run``) rather than hosting it in a separate process.

The default web host for ASP.NET applications developed using Visual Studio 2015 is IIS / IIS Express. The "Microsoft.AspNet.Server.IIS" dependency is included in ``project.json`` by default, even with the Empty web site template. Visual Studio provides support for multiple profiles, associated with IIS Express and any other ``commands`` defined in ``project.json``. You can manage these profiles and their settings in the Debug tab of your web application project's Properties menu.

.. image:: /fundamentals/servers/_static/serverdemo-properties.png

.. note:: IIS doesn't support commands; Visual Studio launches IIS Express and loads your application into it when you choose its profile.

I've configured the sample project for this article to support each of the different server options in its ``project.json`` file:

.. literalinclude:: servers/sample/ServersDemo/src/ServersDemo/project.json
	:lines: 1-17
	:emphasize-lines: 12-14
	:linenos:
	:language: javascript
	:caption: project.json (truncated)

The ``run`` command will execute the application via its ``void main()`` method defined in ``program.cs``. In this case, this has been set up to configure and start an instance of ``WebListener``. This is not a typical means of launching a server, but is shown to demonstrate the possibility (the `Music Store sample application <https://github.com/aspnet/MusicStore>`_ also demonstrates this option).

.. literalinclude:: servers/sample/ServersDemo/src/ServersDemo/Program.cs
	:linenos:
	:emphasize-lines: 27-35
	:language: c#
	:caption: program.cs


Supported Features by Server
----------------------------

ASP.NET defines a number of :doc:`request-features` which may be supported on different server implementations. The following table lists the different features and the servers supporting them.

.. list-table::
	:header-rows: 1
	
	* - Feature
	  - IIS
	  - WebListener
	  - Kestrel
	* - IHttpRequestFeature
	  - Yes
	  - Yes
	  - Yes
	* - IHttpResponseFeature
	  - Yes
	  - Yes
	  - Yes
	* - IHttpAuthenticationFeature
	  - Yes
	  - Yes
	  - No
	* - IHttpUpgradeFeature
	  - No
	  - Yes (with limits)
	  - Yes
	* - IHttpBufferingFeature
	  - Yes
	  - Yes
	  - No
	* - IHttpConnectionFeature
	  - Yes
	  - Yes
	  - No
	* - IHttpRequestLifetimeFeature
	  - Yes
	  - Yes
	  - No
	* - IHttpSendFileFeature
	  - Yes
	  - Yes
	  - No
	* - IHttpWebSocketFeature
	  - Yes
	  - Yes
	  - No*
	* - IRequestIdentifierFeature
	  - Yes
	  - Yes
	  - No
	* - ITlsConnectionFeature
	  - Yes
	  - Yes
	  - No
	* - ITlsTokenBindingFeature
	  - Yes
	  - Yes
	  - No
	  
To add support for web sockets in Kestrel, use the `WebSocketMiddleware <https://github.com/aspnet/WebSockets/blob/c86b157ad3cd00e8848c4895fe29de2f9d81a0b4/src/Microsoft.AspNet.WebSockets.Server/WebSocketMiddleware.cs>`_

Configuration options
^^^^^^^^^^^^^^^^^^^^^

When launching a server, you can provide it with some configuration options. This can be done directly using command line parameters, or a configuration file containing the settings can be specified. The ``Microsoft.AspNet.Hosting`` command supports parameters for the server to use (such as ``Kestrel`` or ``WebListener``) as well as a ``server.urls`` configuration key, which should contain a semicolon-separated list of URL prefixes the server should handle.

The ``project.json`` file shown above demonstrates how to pass the ``server.urls`` parameter directly:

.. code-block:: javascript

	"kestrel": "Microsoft.AspNet.Hosting --server Kestrel --server.urls http://localhost:5004"

Alternately, a configuration file can be referenced, instead:

.. code-block:: javascript

	"kestrel": "Microsoft.AspNet.Hosting --config hosting.ini"

Then, ``hosting.ini`` can include the settings the server will use (including the server parameter, as well):

.. code-block:: text

	server=Kestrel
	server.urls=http://localhost:5004

Programmatic configuration
^^^^^^^^^^^^^^^^^^^^^^^^^^

In addition to specifying configuration options, the server hosting the application can be referenced programmatically via the `IApplicationBuilder interface <https://github.com/aspnet/HttpAbstractions/blob/ed339a35d2a0ae6137c12e9bc8e8b037ed429bc1/src/Microsoft.AspNet.Http.Abstractions/IApplicationBuilder.cs>`_, available in the ``Configure`` method in ``Startup``. ``IApplicationBuilder`` exposes a Server property of type `ServerInformation <https://github.com/aspnet/Hosting/blob/62e534977386ebb02bfc351ec4a6bbea9ea7f635/src/Microsoft.AspNet.Hosting.Server.Abstractions/IServerInformation.cs>`_. ``IServerInformation`` only exposes a ``Name`` property, but different server implementations may expose additional functionality. For instance, WebListener exposes a ``Listener`` property that can be used to configure the server's authentication:

.. literalinclude:: servers/sample/ServersDemo/src/ServersDemo/Startup.cs
	:linenos:
	:lines: 29-45
	:emphasize-lines: 3,6-8,13
	:language: c#
	:dedent: 8

IIS and IIS Express
-------------------

Working with IIS as your server for your ASP.NET application is the default option, and should be familiar to ASP.NET developers who have worked with previous versions of the framework. IIS currently provides support for the largest number of features, and includes IIS management functionality and access to other IIS modules. Hosting ASP.NET 5 on IIS bypasses the legacy ``System.Web`` infrastructure used by prior versions of ASP.NET, providing a substantial performance gain. Most production ASP.NET web applications being deployed to Windows servers will run on IIS.

WebListener
-----------

WebListener is a Windows-only server that allows ASP.NET applications to be hosted outside of IIS. It runs directly on the `Http.Sys kernel driver <http://www.iis.net/learn/get-started/introduction-to-iis/introduction-to-iis-architecture>`_, and has very little overhead. It supports the same feature interfaces as IIS; in fact, you can think of WebListener as a library version of IIS.

You can add support for WebListener to your ASP.NET application by adding the "Microsoft.AspNet.Server.WebListener" dependency in project.json and the following command:

.. code-block:: javascript

	"web": "Microsoft.AspNet.Hosting --server Microsoft.AspNet.Server.WebListener --server.urls http://localhost:5000"

.. _kestrel:

Kestrel
-------

Kestrel is a cross-platform web server based on `libuv <https://github.com/libuv/libuv>`_, a cross-platform asynchronous I/O library. Kestrel is open-source, and you can `view the Kestrel source on GitHub <https://github.com/aspnet/KestrelHttpServer>`_. Kestrel is a great option to at least include support for in your ASP.NET 5 projects so that your project can be easily run by developers on any of the supported platforms. You add support for Kestrel by including "Kestrel" in your project's dependencies listed in ``project.json``.

Learn more about working with Kestrel to create :doc:`/tutorials/your-first-mac-aspnet`.

Choosing a server
-----------------

If you intend to deploy your application on a Windows server, you should prefer the Windows optimized servers (IIS and WebListener). IIS remains the best choice for typical web application deployments on Windows servers, and provides the richest set of features. Choose WebListener instead of IIS only if you need to host your application within your own process or service. Use Kestrel if you intend to develop on or deploy to non-Windows environments.


Custom Servers
--------------

In addition to the options listed above, you can create your own server in which to host your ASP.NET application, or use other open source servers. Forking and modifying the KestrelHttpServer is one way to quickly create your own custom server, and at the time of this writing the KestrelHttpServer repository on GitHub has been forked 55 times. When implementing your own server, you're free to implement just the feature interfaces your application needs, though at a minimum you must support ``IHttpRequestFeature`` and ``IHttpResponseFeature``.

Since Kestrel is open source, it makes an excellent starting point if you need to implement your own custom server. In fact, like all of ASP.NET 5, you're welcome to `contribute <https://github.com/aspnet/KestrelHttpServer/blob/dev/CONTRIBUTING.md>`_ any improvements you make back to the project.

Kestrel currently supports a limited number of feature interfaces, including ``IHttpRequestFeature``, ``IHttpResponseFeature``, and ``IHttpUpgradeFeature``, but additional features will be added in the future. You can see how these interfaces are implemented and supported by Kestrel in its `ServerRequest class <https://github.com/aspnet/KestrelHttpServer/blob/dev/src/Kestrel/ServerRequest.cs>`_, a portion of which is shown below.

.. code-block:: c#
	:caption: Kestrel ServerRequest.cs class snippet

	using Microsoft.AspNet.FeatureModel;
	using Microsoft.AspNet.Http.Features;
	
	namespace Kestrel
	{
		public class ServerRequest : IHttpRequestFeature, 
						 IHttpResponseFeature, 
						 IHttpUpgradeFeature
		{
			private FeatureCollection _features;
			
			private void PopulateFeatures()
			{
				_features.Add(typeof(IHttpRequestFeature), this);
				_features.Add(typeof(IHttpResponseFeature), this);
				_features.Add(typeof(IHttpUpgradeFeature), this);
			}
		}
	}

The ``IHttpUpgradeFeature`` interface consists of only one property and one method. Kestrel's implementation of this interface is shown here for reference:

.. code-block:: c#
	:caption: Kestrel ServerRequest.cs IHttpUpgradeFeature implementation
	
	bool IHttpUpgradeFeature.IsUpgradableRequest
	{
		get
		{
			string[] values;
			if (_frame.RequestHeaders.TryGetValue("Connection", out values))
			{
				return values.Any(value => value.IndexOf("upgrade", 
					StringComparison.OrdinalIgnoreCase) != -1);
			}
			return false;
		}
	}

	async Task<Stream> IHttpUpgradeFeature.UpgradeAsync()
	{
		_frame.StatusCode = 101;
		_frame.ReasonPhrase = "Switching Protocols";
		_frame.ResponseHeaders["Connection"] = new string[] { "Upgrade" };
		if (!_frame.ResponseHeaders.ContainsKey("Upgrade"))
		{
			string[] values;
			if (_frame.RequestHeaders.TryGetValue("Upgrade", out values))
			{
				_frame.ResponseHeaders["Upgrade"] = values;
			}
		}
		_frame.ProduceStart();
		return _frame.DuplexStream;
	}

Summary
-------

Because ASP.NET 5 has completely decoupled ASP.NET applications from IIS or any other web server, it's now possible to host ASP.NET applications on any number of different servers. ASP.NET supports three: IIS, WebListener, and Kestrel, which provide two great options for Windows environments and a third, open-source option that can be used on several different operating systems.

Additional Reading
------------------

- :doc:`request-features`
- :doc:`hosting`