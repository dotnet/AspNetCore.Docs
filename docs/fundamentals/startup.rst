Application Startup
===================

By :ref:`Steve Smith <startup-author>` | Originally Published: 20 May 2015 

ASP.NET 5 provides complete control of how individual requests are handled by your application. The ``Startup`` class is the entry point to the application, setting up configuration and wiring up services the application will use. Developers configure a request pipeline in the ``Startup`` class that is used to handle all requests made to the application.

In this article:
	- `The Startup class`_
	- `Understanding request delegates`_
	- `Setting up your request pipeline`_
	- `Run, Map, and Use`_
	
`Browse or download samples on GitHub <https://github.com/aspnet/Docs/tree/master/docs/fundamentals/startup/sample>`_.

The Startup class
-----------------

In ASP.NET 5, the Startup class provides the entry point for an application. It's possible to have :doc:`environment-specific startup files <environments>`, but regardless, one Startup class will serve as the entry point for the application.

Understanding request delegates
-------------------------------

ASP.NET 5 implements the Open Web Interface for .NET (OWIN). OWIN provides a standardized way for web applications to communicate with web servers, and specifies request delegates that respond to web requests.


Setting up your request pipeline
--------------------------------

Run, Map, and Use
-----------------


Summary
-------

In ASP.NET 5, you can easily add error pages, view diagnostic information, or respond to requests with a simple welcome page by adding just one line to your app's ``Startup.cs`` class.

Additional Resources
--------------------

- :ref:`Using Application Insights <application-insights>` Collect detailed usage and diagnostic data for your application.

.. _startup-author:

.. include:: /_authors/steve-smith.txt
