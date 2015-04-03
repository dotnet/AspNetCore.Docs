Migrating From ASP.NET Web API 2 to ASP.NET 5
=============================================
By `Steve Smith`_ | Originally Published: 1 June 2015 

.. _`Steve Smith`: Author_

ASP.NET Web API 2 was separate from ASP.NET MVC 5, with each using their own libraries for dependency resolution, among other things. In ASP.NET 6, Web API has been merged with MVC, providing a single, consistent way of building web applications. In this article we demonstrate the steps required to migrate from an ASP.NET Web API 2 project to ASP.NET 5.

This article covers the following topics:
	- Review Web API 2 Project
	- Create the Destination Project
	- Migrate Configuration
	- Migrate Models and Controllers

You can view the finished source from the project created in this article `on GitHub <https://github.com/aspnet/Docs/tree/master/samples/WebAPIMigration>`_.

Review Web API 2 Project
^^^^^^^^^^^^^^^^^^^^^^^^

This article uses the sample project, ProductsApp, created in the article, `Getting Started with ASP.NET Web API 2 (C#) <http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api>`_ as its starting point.

In Global.asax.cs, a call is made to WebApiConfig.Register:

.. literalinclude:: ../../../samples/WebAPIMigration/ProductsApp/global.asax.cs
	:language: c#
	:emphasize-lines: 14
	:linenos:

WebApiConfig is defined in App_Start, and has just one static Register method:

.. literalinclude:: ../../../samples/WebAPIMigration/ProductsApp/App_Start/WebApiConfig.cs
	:language: c#
	:emphasize-lines: 15-20
	:linenos:

This class configures `attribute routing <http://www.asp.net/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2>`_, which isn't actually being used in this project, as well as the routing table that Web API 2 uses. In this case, Web API will expect URLs to match /api/{controller}/{id}, with {id} being optional.

The ProductsApp project includes just one simple controller, which inherits from ApiController and exposes two methods:

.. literalinclude:: ../../../samples/WebAPIMigration/ProductsApp/Controllers/ProductsController.cs
	:language: c#
	:emphasize-lines: 19,24
	:linenos:

Finally, the model, Product, used by the ProductsApp, is a simple class:

.. literalinclude:: ../../../samples/WebAPIMigration/ProductsApp/Models/Product.cs
	:language: c#
	:linenos:

Create the Destination Project
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^


Summary
^^^^^^^

ToDo

.. include:: /_authors/steve-smith.rst
