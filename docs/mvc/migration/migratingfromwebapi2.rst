Migrating From ASP.NET Web API 2 to MVC 6
=========================================
By :ref:`Steve Smith <migratingfromwebapi2-author>` | Originally Published: 28 April 2015 

ASP.NET Web API 2 was separate from ASP.NET MVC 5, with each using their own libraries for dependency resolution, among other things. In MVC 6, Web API has been merged with MVC, providing a single, consistent way of building web applications. In this article we demonstrate the steps required to migrate from an ASP.NET Web API 2 project to MVC 6.

In this article:
	- `Review Web API 2 Project`_
	- `Create the Destination Project`_
	- `Migrate Configuration`_
	- `Migrate Models and Controllers`_

You can view the finished source from the project created in this article `on GitHub <https://github.com/aspnet/Docs/tree/master/samples/WebAPIMigration>`_.

Review Web API 2 Project
------------------------

This article uses the sample project, ProductsApp, created in the article, `Getting Started with ASP.NET Web API 2 (C#) <http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api>`_ as its starting point. In that project, a simple Web API 2 project is configured as follows.

In Global.asax.cs, a call is made to WebApiConfig.Register:

.. literalinclude:: migratingfromwebapi2/sample/ProductsApp/Global.asax.cs
	:language: c#
	:emphasize-lines: 14
	:linenos:

WebApiConfig is defined in App_Start, and has just one static Register method:

.. literalinclude:: migratingfromwebapi2/sample/ProductsApp/App_Start/WebApiConfig.cs
	:language: c#
	:emphasize-lines: 15-20
	:linenos:

This class configures `attribute routing <http://www.asp.net/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2>`_, although it's not actually being used in the project, as well as the routing table that Web API 2 uses. In this case, Web API will expect URLs to match the format */api/{controller}/{id}*, with *{id}* being optional.

The ProductsApp project includes just one simple controller, which inherits from ApiController and exposes two methods:

.. literalinclude:: migratingfromwebapi2/sample/ProductsApp/Controllers/ProductsController.cs
	:language: c#
	:emphasize-lines: 19,24
	:linenos:

Finally, the model, Product, used by the ProductsApp, is a simple class:

.. literalinclude:: migratingfromwebapi2/sample/ProductsApp/Models/Product.cs
	:language: c#
	:linenos:

Now that we have a simple project from which to start, we can demonstrate how to migrate this Web API 2 project to ASP.NET MVC 6.
	
Create the Destination Project
------------------------------

Using Visual Studio 2015, create a new, empty solution, and add the existing ProductsApp project to it. Then, add a new Web Project to the solution. Name the new project 'ProductsDnx'.

.. image:: migratingfromwebapi2/_static/add-web-project.png

Next, choose the ASP.NET 5 Web API template project. We will migrate the ProductsApp contents to this new project.

.. image:: migratingfromwebapi2/_static/aspnet-5-webapi.png

Delete the Project_Readme.html file from the new project. Your solution should now look like this:

.. image:: migratingfromwebapi2/_static/webapimigration-solution.png

.. migrate-webapi-config:

Migrate Configuration
---------------------

ASP.NET 5 no longer uses global.asax, web.config, or App_Start folders. Instead, all startup tasks are done in Startup.cs in the root of the project, and static configuration files can be wired up from there if needed (Learn more about :ref:`ASP.NET 5 Application Startup <fundamentalconcepts-application-startup>`). Since Web API is now built into MVC 6, there is less need to configure it. Attribute-based routing is now included by default when UseMvc() is called, and this is the recommended approach for configuring Web API routes (and is how the Web API starter project handles routing).

.. literalinclude:: migratingfromwebapi2/sample/ProductsDnx/Startup.cs
	:language: c#
	:emphasize-lines: 27
	:linenos:
	
Assuming you want to use attribute routing in your project going forward, you don't need to do any additional configuration. You can simply apply the attributes as needed to your controllers and actions,, as is done in the sample ValuesController.cs class that is included in the Web API starter project:

.. literalinclude:: migratingfromwebapi2/sample/ProductsDnx/Controllers/ValuesController.cs
	:language: c#
	:emphasize-lines: 8,12,19,32,38
	:linenos:

Note the presence of *[controller]* on line 8. Attribute-based routing now supports certain tokens, such as *[controller]* and *[action]* that are replaced at runtime with the name of the controller or action to which the attribute has been applied. This serves to reduce the number of magic strings in the project, and ensures the routes will be kept synchronized with their corresponding controllers and actions when automatic rename refactorings are applied.

To migrate the Products API controller, we must first copy ProductsController to the new project. Then simply include the route attribute on the controller:

.. code-block:: c#

	[Route("api/[controller]")]

You also need to add the [HttpGet] attribute to the two methods, since they both should be called via HTTP Get. Include the expectation of an "id" parameter in the attribute for GetProduct():

.. code-block:: c#

	// /api/products
	[HttpGet]
	...
	
	// /api/products/1
	[HttpGet("{id}")]

At this point routing is configured correctly, but we can't yet test it because there are changes we must make before ProductsController will compile.

Migrate Models and Controllers
------------------------------

The last step in the migration process for this simple Web API project is to copy over the Controllers and any Models they use. In this case, simply copy Controllers/ProductsController.cs from the original project to the new one. Then, copy the entire Models folder from the original project to the new one. Adjust the namespaces to match the new project name (`ProductsDnx`).  At this point, you can build the application, and you will find a number of compilation errors. These should generally fall into three categories:

	- `ApiController` does not exist
	- `System.Web.Http` namespace does not exist
	- `IHttpActionResult` does not exist
	- `NotFound` does not exist
	- `Ok` does not exist
	
Fortunately, these are all very easy to correct:

	- Change `ApiController` to `Controller` (you may need to add `using Microsoft.AspNet.Mvc`)
	- Delete any using statement referring to `System.Web.Http`
	- Change any method returning `IHttpActionResult` to return a `IActionResult`
	- Change `NotFound` to `HttpNotFound`
	- Change `Ok(product)` to `new ObjectResult(product)`

Once these changes have been made and unused using statements removed, the migrated ProductsController class looks like this:

.. literalinclude:: migratingfromwebapi2/sample/ProductsDnx/Controllers/ProductsController.cs
	:language: c#
	:emphasize-lines: 1,2,6,8-9,27,32,34
	:linenos:
	
You should now be able to run the migrated project and browse to /api/products, and you should see the full list of 3 products. Browse to /api/products/1 and you should see the first product.

Summary
-------

Migrating a simple Web API 2 project to MVC 6 is fairly straightforward, thanks to the fact that Web API has been merged with MVC 6 in ASP.NET 5. The main pieces every Web API 2 project will need to migrate are routes, controllers, and models, along with updates to the types used by MVC 6 controllers and actions.

Related Resources
-----------------

`Create a Web API in MVC 6 <http://www.asp.net/vnext/overview/aspnet-vnext/create-a-web-api-with-mvc-6>`_

.. _migratingfromwebapi2-author:

.. include:: /_authors/steve-smith.txt
