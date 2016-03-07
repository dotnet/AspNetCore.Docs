Servers
=======

By `Steve Smith`_

ASP.NET 5 is completely decoupled from the web server environment that hosts the application. ASP.NET 5 supports hosting in IIS and IIS Express, and self-hosting scenarios using the Kestrel and WebListener HTTP servers. Additionally, developers and third party software vendors can create custom servers to host their ASP.NET 5 apps.

Sections:
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

ASP.NET 5 was designed to decouple web applications from the underlying HTTP server. Traditionally, ASP.NET apps have been windows-only hosted on Internet Information Server (IIS). The recommended way to run ASP.NET 5 applications on Windows is using IIS as a reverse-proxy server. The HttpPlatformHandler module in IIS manages and proxies requests to an HTTP server hosted out-of-process. ASP.NET 5 ships with two different HTTP servers:

- Microsoft.AspNet.Server.WebListener (AKA WebListener, Windows-only)
- Microsoft.AspNet.Server.Kestrel (AKA Kestrel, cross-platform)

ASP.NET 5 does not directly listen for requests, but instead relies on the HTTP server implementation to surface the request to the application as a set of :doc:`feature interfaces <request-features>` composed into an HttpContext. While WebListener is Windows-only, Kestrel is designed to run cross-platform. You can configure your application to be hosted by any or all of these servers by specifying commands in your *project.json* file. You can even specify an application entry point for your application, and run it as an executable (using ``dotnet run``) rather than hosting it in a separate process.

The default web host for ASP.NET apps developed using Visual Studio 2015 is IIS Express functioning as a reverse proxy server for Kestrel. The "Microsoft.AspNet.Server.Kestrel" and "Microsoft.AspNet.IISPlatformHandler" dependencies are included in *project.json* by default, even with the Empty web site template. Visual Studio provides support for multiple profiles, associated with IIS Express and any other ``commands`` defined in *project.json*. You can manage these profiles and their settings in the **Debug** tab of your web application project's Properties menu or from the *launchSettings.json* file.

.. image:: /fundamentals/servers/_static/serverdemo-properties.png

.. note:: IIS doesn't support commands. Visual Studio launches IIS Express and loads the application with the selected profile.

The sample project for this article is configured to support each server option in the *project.json* file:

.. literalinclude:: servers/sample/ServersDemo/src/ServersDemo/project.json
	:lines: 1-17
	:emphasize-lines: 12-13
	:linenos:
	:language: javascript
	:caption: project.json (truncated)

The ``run`` command will launch the application from the ``void main`` method. The ``run`` command configures and starts an instance of ``Kestrel``.

.. literalinclude:: servers/sample/ServersDemo/src/ServersDemo/Program.cs
	:linenos:
	:emphasize-lines: 32-40
	:language: c#
	:caption: program.cs


Supported Features by Server
----------------------------

ASP.NET defines a number of :doc:`request-features`. The following table lists the WebListener and Kestrel support for request features.

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

You can provide configuration options (by command line parameters or a configuration file) that are read on server startup.

The ``Microsoft.AspNet.Hosting`` command supports server parameters (such as ``Kestrel`` or ``WebListener``) and a ``server.urls`` configuration key. The ``server.urls`` configuration key is a semicolon-separated list of URL prefixes that the server should handle.

The *project.json* file shown above demonstrates how to pass the ``server.urls`` parameter directly:

.. code-block:: javascript

	"web": "Microsoft.AspNet.Kestrel --server.urls http://localhost:5004"

Alternately, a  JSON configuration file can be used,

.. code-block:: javascript

	"kestrel": "Microsoft.AspNet.Hosting"

The ``hosting.json`` can include the settings the server will use (including the server parameter, as well):

.. code-block:: json

	{
	  "server": "Microsoft.AspNet.Server.Kestrel",
	  "server.urls": "http://localhost:5004/"
	}

Programmatic configuration
^^^^^^^^^^^^^^^^^^^^^^^^^^

The server hosting the application can be referenced programmatically via the `IApplicationBuilder interface <https://github.com/aspnet/HttpAbstractions/blob/1.0.0-rc1/src/Microsoft.AspNet.Http.Abstractions/IApplicationBuilder.cs>`_, available in the ``Configure`` method in ``Startup``. ``IApplicationBuilder`` exposes Server Features of type `IFeatureCollection <https://github.com/aspnet/HttpAbstractions/blob/1.0.0-rc1/src/Microsoft.AspNet.Http.Features/IFeatureCollection.cs>`_. ``IServerAddressesFeature`` only expose a ``Addresses`` property, but different server implementations may expose additional functionality. For instance, WebListener exposes ``AuthenticationManager`` that can be used to configure the server's authentication:

.. literalinclude:: servers/sample/ServersDemo/src/ServersDemo/Startup.cs
	:linenos:
	:lines: 37-54
	:emphasize-lines: 3,6-7,10,15
	:language: c#
	:dedent: 8


IIS and IIS Express
-------------------

IIS is the most feature rich server, and includes IIS management functionality and access to other IIS modules. Hosting ASP.NET 5 no longer uses the ``System.Web`` infrastructure used by prior versions of ASP.NET.

HTTPPlatformHandler
^^^^^^^^^^^^^^^^^^^
In ASP.NET 5 on Windows, the web application is hosted by an external process outside of IIS. The HTTP Platform Handler is an IIS 7.5+ module which is responsible for process management of HTTP listeners and used to proxy requests to the processes that it manages.

WebListener
-----------

WebListener is a Windows-only HTTP server for ASP.NET 5. It runs directly on the `Http.Sys kernel driver <http://www.iis.net/learn/get-started/introduction-to-iis/introduction-to-iis-architecture>`_, and has very little overhead.

You can add support for WebListener to your ASP.NET application by adding the "Microsoft.AspNet.Server.WebListener" dependency in *project.json* and the following command:

.. code-block:: javascript

	"web": "Microsoft.AspNet.Hosting --server Microsoft.AspNet.Server.WebListener --server.urls http://localhost:5000"

.. _kestrel:

Kestrel
-------

Kestrel is a cross-platform web server based on `libuv <https://github.com/libuv/libuv>`_, a cross-platform asynchronous I/O library. Kestrel is open-source, and you can `view the Kestrel source on GitHub <https://github.com/aspnet/KestrelHttpServer>`_. You add support for Kestrel by including "Kestrel" in your project's dependencies listed in *project.json*.

Learn more about working with Kestrel to create :doc:`/tutorials/your-first-mac-aspnet`.

Choosing a server
-----------------

If you intend to deploy your application on a Windows server, you should run IIS as a reverse proxy server that manages and proxies requests to Kestrel. If deploying on Linux, you should run a comparable reverse proxy server such as Apache or Nginx to proxy requests to Kestrel.

For self-hosting scenarios, such as running in `Service Fabric <https://azure.microsoft.com/en-us/services/service-fabric/>`_, we recommend using Kestrel without IIS. However, if you require Windows Authentication in a self-hosting scenario, you should choose WebListener.

Custom Servers
--------------

You can create your own server in which to host ASP.NET apps, or use other open source servers. Forking and modifying the KestrelHttpServer is one way to quickly create your own custom server. When implementing your own server, you're free to implement just the feature interfaces your application needs, though at a minimum you must support ``IHttpRequestFeature`` and ``IHttpResponseFeature``.

Since Kestrel is open source, it makes an excellent starting point if you need to implement your own custom server. Like all of ASP.NET 5, you're welcome to `contribute <https://github.com/aspnet/KestrelHttpServer/blob/dev/CONTRIBUTING.md>`_ any improvements you make back to the project.

Kestrel currently supports a limited number of `feature interfaces <https://github.com/aspnet/KestrelHttpServer/blob/1.0.0-rc1/src/Microsoft.AspNet.Server.Kestrel/Http/Frame.FeatureCollection.cs#L16>`_, but additional features will be added in the future. You can see how these interfaces are implemented and supported by Kestrel in its ``Frame`` class. For example, the ``IHttpUpgradeFeature`` interface consists of only one property and one method. You can see Kestrel's implementation `here <https://github.com/aspnet/KestrelHttpServer/blob/1.0.0-rc1/src/Microsoft.AspNet.Server.Kestrel/Http/Frame.FeatureCollection.cs#L265-L280>`_.

Additional Reading
------------------

- :doc:`request-features`
