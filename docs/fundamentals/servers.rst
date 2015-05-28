Application Startup
===================

By `Steve Smith`_

ASP.NET 5 is completely decoupled from the web server environment that hosts the application. As released, ASP.NET 5 supports IIS and IIS Express, WebListener, and Kestrel web servers, which run on a variety of platforms. Developers and third party software vendors can create their own custom servers as well within which to host their ASP.NET 5 applications.

In this article:
	- `Servers and commands`_
	- `IIS and IIS Express`_
	- `WebListener`_
	- `Kestrel`_
	- `Custom Servers`_
	
`Browse or download samples on GitHub <https://github.com/aspnet/Docs/tree/master/docs/fundamentals/servers/sample>`_.

Servers and commands
--------------------

ASP.NET 5 is designed to decouple web applications from the underlying web server that hosts them. Traditionally, ASP.NET applications have been windows-only (unless `hosted via mono <http://www.mono-project.com/docs/web/aspnet/>`_) and hosted on the built-in web server for windows, Internet Information Server (IIS) (or a development server, like `IIS Express <http://www.iis.net/learn/extensions/introduction-to-iis-express/iis-express-overview>`_ or earlier development web servers). While IIS is still the recommended way to host production ASP.NET applications on Windows, the cross-platform nature of ASP.NET allows it to be hosted in any number of different web servers, on multiple operating systems.

ASP.NET 5 ships with support for 3 different servers:
- Microsoft.AspNet.Loader.IIS (Helios)
- Microsoft.AspNet.Server.WebListener (WebListener)
- Microsoft.AspNet.Server.Kestrel (Kestrel)

ASP.NET 5 does not directly listen for requests, but instead relies on the HTTP server implementation to surface the request to the application as a set of feature interfaces composed into an HttpContext. Both Helios and WebListener are Windows-only; Kestrel is designed to run cross-platform. You can configure your application to be hosted by any or all of these servers by specifying commands in your ``project.json`` file. You can even specify an application entry point for your application, and run it as an executable (using ``dnx . run``) rather than hosting it in a separate process.

I've configured the sample project for this article to support each of these hosting options as separate commands in ``project.json``:

.. literalinclude:: servers/sample/ServersDemo/src/ServersDemo/project.json
	:lines: 1-17
	:linenos:
	:language: javascript
	:caption: project.json (truncated)

IIS and IIS Express
-------------------

The default web host for ASP.NET applications developed using Visual Studio 2015 is IIS / IIS Express. The "Microsoft.AspNet.Server.IIS" dependency is include by default, even with the Empty web site template. Visual Studio provides support for multiple profiles, associated with IIS Express and any other ``commands`` defined in ``project.json``. You can manage these profiles and their settings in the Debug tab of your web application project's Properties menu.

Working with IIS as your server for your ASP.NET application is a great option. It provides the most features, integrating with IIS and providing access to other IIS modules. It bypasses the legacy System.Web infrastructure used by prior version of ASP.NET, providing a substantial performance gain. IIS has great support for static files and can also be used with the built-in Windows Authentication mechanism, too.



WebListener
-----------
Kestrel
-------
Custom Servers
--------------


