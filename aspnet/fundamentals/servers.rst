Servers
=======

By `Steve Smith`_

ASP.NET 5 is completely decoupled from the web server environment that hosts the application. As released, ASP.NET 5 supports hosting in IIS and IIS Express, and self-hosting scenarios using the Kestrel and WebListener http servers. Additonally, developers and third party software vendors can create their own custom servers within which to host their ASP.NET 5 applications.

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

ASP.NET 5 is designed to decouple web applications from the underlying web server that hosts them. Traditionally, ASP.NET applications have been windows-only (unless `hosted via mono <http://www.mono-project.com/docs/web/aspnet/>`_) and hosted on the built-in web server for windows, Internet Information Server (IIS) (or a development server, like `IIS Express <http://www.iis.net/learn/extensions/introduction-to-iis-express/iis-express-overview>`_ or earlier development web servers). The recommended way to run ASP.NET 5 applications on Windows is using IIS as a reverse-proxy server. The HttpPlatformHandler module in IIS manages and proxies requests to an http server hosted out-of-process. ASP.NET 5 ships with two different http servers:

- Microsoft.AspNet.Server.WebListener (WebListener)
- Microsoft.AspNet.Server.Kestrel (Kestrel)

ASP.NET 5 does not directly listen for requests, but instead relies on the HTTP server implementation to surface the request to the application as a set of :doc:`feature interfaces <request-features>` composed into an HttpContext. While WebListener is Windows-only; Kestrel is designed to run cross-platform. You can configure your application to be hosted by any or all of these servers by specifying commands in your ``project.json`` file. You can even specify an application entry point for your application, and run it as an executable (using ``dnx run``) rather than hosting it in a separate process.

The default web host for ASP.NET applications developed using Visual Studio 2015 is IIS / IIS Express as a reverse proxy server for Kestrel. The "Microsoft.AspNet.Server.Kestrel" and "Microsoft.AspNet.IISPlatformHandler" dependencies are included in ``project.json`` by default, even with the Empty web site template. Visual Studio provides support for multiple profiles, associated with IIS Express and any other ``commands`` defined in ``project.json``. You can manage these profiles and their settings in the Debug tab of your web application project's Properties menu or from the ``launchSettings.json`` file.

.. image:: /fundamentals/servers/_static/serverdemo-properties.png

.. note:: IIS doesn't support commands; Visual Studio launches IIS Express and loads your application into it when you choose its profile.

I've configured the sample project for this article to support each of the different server options in its ``project.json`` file:

.. literalinclude:: servers/sample/ServersDemo/src/ServersDemo/project.json
	:lines: 1-17
	:emphasize-lines: 12-13
	:linenos:
	:language: javascript
	:caption: project.json (truncated)

The ``run`` command will execute the application via its ``void main()`` method defined in ``program.cs``. In this case, this has been set up to configure and start an instance of ``Kestrel``.

.. literalinclude:: servers/sample/ServersDemo/src/ServersDemo/Program.cs
	:linenos:
	:emphasize-lines: 32-40
	:language: c#
	:caption: program.cs


Supported Features by Server
----------------------------

ASP.NET defines a number of :doc:`request-features` which may be supported on different server implementations. The following table lists the different features and the servers supporting them.

.. list-table::
	:header-rows: 1
	
	* - Feature
	  - WebListener
	  - Kestrel
	* - IHttpRequestFeature
	  - Yes
	  - Yes
	* - IHttpResponseFeature
	  - Yes
	  - Yes
	* - IHttpAuthenticationFeature
	  - Yes
	  - No
	* - IHttpUpgradeFeature
	  - Yes (with limits)
	  - Yes
	* - IHttpBufferingFeature
	  - Yes
	  - No
	* - IHttpConnectionFeature
	  - Yes
	  - Yes
	* - IHttpRequestLifetimeFeature
	  - Yes
	  - Yes
	* - IHttpSendFileFeature
	  - Yes
	  - No
	* - IHttpWebSocketFeature
	  - No*
	  - No*
	* - IRequestIdentifierFeature
	  - Yes
	  - No
	* - ITlsConnectionFeature
	  - Yes
	  - Yes
	* - ITlsTokenBindingFeature
	  - Yes
	  - No
	  
To add support for web sockets, use the `WebSocketMiddleware <https://github.com/aspnet/WebSockets/blob/1.0.0-rc1/src/Microsoft.AspNet.WebSockets.Server/WebSocketMiddleware.cs>`_

Configuration options
^^^^^^^^^^^^^^^^^^^^^

When launching a server, you can provide it with some configuration options. This can be done directly using command line parameters, or a configuration file containing the settings can be specified. The ``Microsoft.AspNet.Hosting`` command supports parameters for the server to use (such as ``Kestrel`` or ``WebListener``) as well as a ``server.urls`` configuration key, which should contain a semicolon-separated list of URL prefixes the server should handle.

The ``project.json`` file shown above demonstrates how to pass the ``server.urls`` parameter directly:

.. code-block:: javascript

	"web": "Microsoft.AspNet.Kestrel --server.urls http://localhost:5004"

Alternately, a configuration file can be referenced, instead:

.. code-block:: javascript

	"kestrel": "Microsoft.AspNet.Hosting"

Then, ``hosting.json`` can include the settings the server will use (including the server parameter, as well):

.. code-block:: json

	{
	  "server": "Microsoft.AspNet.Server.Kestrel",
	  "server.urls": "http://localhost:5004/"
	}

Programmatic configuration
^^^^^^^^^^^^^^^^^^^^^^^^^^

In addition to specifying configuration options, the server hosting the application can be referenced programmatically via the `IApplicationBuilder interface <https://github.com/aspnet/HttpAbstractions/blob/1.0.0-rc1/src/Microsoft.AspNet.Http.Abstractions/IApplicationBuilder.cs>`_, available in the ``Configure`` method in ``Startup``. ``IApplicationBuilder`` exposes Server Features of type `IFeatureCollection <https://github.com/aspnet/HttpAbstractions/blob/1.0.0-rc1/src/Microsoft.AspNet.Http.Features/IFeatureCollection.cs>`_. ``IServerAddressesFeature`` only expose a ``Addresses`` property, but different server implementations may expose additional functionality. For instance, WebListener exposes ``AuthenticationManager`` that can be used to configure the server's authentication:

.. literalinclude:: servers/sample/ServersDemo/src/ServersDemo/Startup.cs
	:linenos:
	:lines: 37-54
	:emphasize-lines: 3,6-7,10,15
	:language: c#
	:dedent: 8


IIS and IIS Express
-------------------

Working with IIS as your server for your ASP.NET application is the default option, and should be familiar to ASP.NET developers who have worked with previous versions of the framework. IIS currently provides support for the largest number of features, and includes IIS management functionality and access to other IIS modules. Hosting ASP.NET 5 on IIS bypasses the legacy ``System.Web`` infrastructure used by prior versions of ASP.NET, providing a substantial performance gain.

HTTPPlatformHandler
^^^^^^^^^^^^^^^^^^^

In ASP.NET 5, the web application is hosted by an external process outside of IIS. The HTTP Platform Handler is an IIS 7.5+ module which is responsible for process management of http listeners and to proxy requests to processes that it manages.

WebListener
-----------

WebListener is a Windows-only http server for ASP.NET 5. It runs directly on the `Http.Sys kernel driver <http://www.iis.net/learn/get-started/introduction-to-iis/introduction-to-iis-architecture>`_, and has very little overhead.

You can add support for WebListener to your ASP.NET application by adding the "Microsoft.AspNet.Server.WebListener" dependency in project.json and the following command:

.. code-block:: javascript

	"web": "Microsoft.AspNet.Hosting --server Microsoft.AspNet.Server.WebListener --server.urls http://localhost:5000"

.. _kestrel:

Kestrel
-------

Kestrel is a cross-platform web server based on `libuv <https://github.com/libuv/libuv>`_, a cross-platform asynchronous I/O library. Kestrel is open-source, and you can `view the Kestrel source on GitHub <https://github.com/aspnet/KestrelHttpServer>`_. You add support for Kestrel by including "Kestrel" in your project's dependencies listed in ``project.json``.

Learn more about working with Kestrel to create :doc:`/tutorials/your-first-mac-aspnet`.

Choosing a server
-----------------

If you intend to deploy your application on a Windows server, you should run IIS as a reverse proxy server that manages and proxies requests to Kestrel. If deploying on Linux, you should run a comparable reverse proxy server such as Apache or Nginx to proxy requests to Kestrel.

For self-hosting scenarios, such as WCF services or `Service Fabric <https://azure.microsoft.com/en-us/services/service-fabric/>`_, we recommend using Kestrel without IIS. However, if you require Windows Authentication in a self-hosting scenario, you should choose WebListener.

Custom Servers
--------------

In addition to the options listed above, you can create your own server in which to host your ASP.NET application, or use other open source servers. Forking and modifying the KestrelHttpServer is one way to quickly create your own custom server. When implementing your own server, you're free to implement just the feature interfaces your application needs, though at a minimum you must support ``IHttpRequestFeature`` and ``IHttpResponseFeature``.

Since Kestrel is open source, it makes an excellent starting point if you need to implement your own custom server. In fact, like all of ASP.NET 5, you're welcome to `contribute <https://github.com/aspnet/KestrelHttpServer/blob/dev/CONTRIBUTING.md>`_ any improvements you make back to the project.

Kestrel currently supports a limited number of `feature interfaces <https://github.com/aspnet/KestrelHttpServer/blob/1.0.0-rc1/src/Microsoft.AspNet.Server.Kestrel/Http/Frame.FeatureCollection.cs#L16>`_, but additional features will be added in the future. You can see how these interfaces are implemented and supported by Kestrel in its ``Frame`` class. For example, the ``IHttpUpgradeFeature`` interface consists of only one property and one method. You can look at Kestrel's implementation `here <https://github.com/aspnet/KestrelHttpServer/blob/1.0.0-rc1/src/Microsoft.AspNet.Server.Kestrel/Http/Frame.FeatureCollection.cs#L265-L280>`_.

Summary
-------

Because ASP.NET 5 has completely decoupled ASP.NET applications from the underlying server, it's now possible to host ASP.NET applications on a number of different servers. ASP.NET supports Kestrel, WebListener, and any custom server that you may implement, which provides great options for Windows, Mac, and Linux.

Additional Reading
------------------

- :doc:`request-features`
- :doc:`hosting`