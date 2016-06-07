Migrating from ASP.NET Web API
==============================

By `Steve Smith`_ and `Scott Addie`_

Web APIs are HTTP services that reach a broad range of clients, including browsers and mobile devices. ASP.NET Core MVC includes support for building Web APIs providing a single, consistent way of building web applications. In this article, we demonstrate the steps required to migrate a Web API implementation from ASP.NET Web API to ASP.NET Core MVC.

.. contents:: Sections::
  :local:
  :depth: 1

`View or download sample code <https://github.com/aspnet/Docs/tree/master/aspnet/migration/webapi/sample>`__

Review ASP.NET Web API Project
------------------------------

This article uses the sample project, *ProductsApp*, created in the article `Getting Started with ASP.NET Web API  <http://www.asp.net/web-api/overview/getting-started-with-aspnet-web-api/tutorial-your-first-web-api>`_ as its starting point. In that project, a simple ASP.NET Web API  project is configured as follows.

In *Global.asax.cs*, a call is made to ``WebApiConfig.Register``:

.. literalinclude:: webapi/sample/ProductsApp/Global.asax.cs
  :language: c#
  :emphasize-lines: 14
  :linenos:

``WebApiConfig`` is defined in *App_Start*, and has just one static ``Register`` method:

.. literalinclude:: webapi/sample/ProductsApp/App_Start/WebApiConfig.cs
  :language: c#
  :emphasize-lines: 15-20
  :linenos:

This class configures `attribute routing <http://www.asp.net/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2>`_, although it's not actually being used in the project. It also configures the routing table which is used by ASP.NET Web API. In this case, ASP.NET Web API will expect URLs to match the format */api/{controller}/{id}*, with *{id}* being optional.

The *ProductsApp* project includes just one simple controller, which inherits from ``ApiController`` and exposes two methods:

.. literalinclude:: webapi/sample/ProductsApp/Controllers/ProductsController.cs
  :language: c#
  :emphasize-lines: 19,24
  :linenos:

Finally, the model, *Product*, used by the *ProductsApp*, is a simple class:

.. literalinclude:: webapi/sample/ProductsApp/Models/Product.cs
  :language: c#
  :linenos:

Now that we have a simple project from which to start, we can demonstrate how to migrate this Web API project to ASP.NET Core MVC.
  
Create the Destination Project
------------------------------

Using Visual Studio, create a new, empty solution, and add the existing *ProductsApp* project to it. Then, add a new Web Project to the solution. Name the new project 'ProductsCore'.

.. image:: webapi/_static/add-web-project.png

Next, choose the ASP.NET Core Web API project template. We will migrate the *ProductsApp* contents to this new project.

.. image:: webapi/_static/aspnet-5-webapi.png

Delete the ``Project_Readme.html`` file from the new project. Your solution should now look like this:

.. image:: webapi/_static/webapimigration-solution.png

.. migrate-webapi-config:

Migrate Configuration
---------------------

ASP.NET Core no longer uses *Global.asax*, *web.config*, or *App_Start* folders. Instead, all startup tasks are done in *Startup.cs* in the root of the project (see :doc:`/fundamentals/startup`). In ASP.NET Core MVC attribute-based routing is now included by default when ``UseMvc()`` is called and this is the recommended approach for configuring Web API routes (and is how the Web API starter project handles routing).

.. literalinclude:: webapi/sample/ProductsCore/Startup.cs
  :language: c#
  :emphasize-lines: 43
  :linenos:

Assuming you want to use attribute routing in your project going forward, no additional configuration is needed. Simply apply the attributes as needed to your controllers and actions, as is done in the sample ``ValuesController`` class that is included in the Web API starter project:

.. literalinclude:: webapi/sample/ProductsCore/Controllers/ValuesController.cs
  :language: c#
  :emphasize-lines: 8,12,19,26,32,38
  :linenos:

Note the presence of *[controller]* on line 8. Attribute-based routing now supports certain tokens, such as *[controller]* and *[action]*. These tokens are replaced at runtime with the name of the controller or action, respectively, to which the attribute has been applied. This serves to reduce the number of magic strings in the project, and it ensures the routes will be kept synchronized with their corresponding controllers and actions when automatic rename refactorings are applied.

To migrate the Products API controller, we must first copy *ProductsController* to the new project. Then simply include the route attribute on the controller:

.. code-block:: c#

  [Route("api/[controller]")]

You also need to add the ``[HttpGet]`` attribute to the two methods, since they both should be called via HTTP Get. Include the expectation of an "id" parameter in the attribute for ``GetProduct()``:

.. code-block:: c#

  // /api/products
  [HttpGet]
  ...

  // /api/products/1
  [HttpGet("{id}")]

At this point, routing is configured correctly; however, we can't yet test it. Additional changes must be made before *ProductsController* will compile.

Migrate Models and Controllers
------------------------------

The last step in the migration process for this simple Web API project is to copy over the Controllers and any Models they use. In this case, simply copy *Controllers/ProductsController.cs* from the original project to the new one. Then, copy the entire Models folder from the original project to the new one. Adjust the namespaces to match the new project name (`ProductsCore`).  At this point, you can build the application, and you will find a number of compilation errors. These should generally fall into the following categories:

- `ApiController` does not exist
- `System.Web.Http` namespace does not exist
- `IHttpActionResult` does not exist
- `NotFound` does not exist
- `Ok` does not exist

Fortunately, these are all very easy to correct:

- Change `ApiController` to `Controller` (you may need to add `using Microsoft.AspNetCore.Mvc`)
- Delete any using statement referring to `System.Web.Http`
- Change any method returning `IHttpActionResult` to return a `IActionResult`
- Change `NotFound` to `HttpNotFound`
- Change `Ok(product)` to `new ObjectResult(product)`

Once these changes have been made and unused using statements removed, the migrated *ProductsController* class looks like this:

.. literalinclude:: webapi/sample/ProductsCore/Controllers/ProductsController.cs
  :language: c#
  :emphasize-lines: 1,2,6,8-9,27,32,34
  :linenos:

You should now be able to run the migrated project and browse to */api/products*; and, you should see the full list of 3 products. Browse to */api/products/1* and you should see the first product.

Summary
-------

Migrating a simple ASP.NET Web API project to ASP.NET Core MVC is fairly straightforward, thanks to the built-in support for Web APIs in ASP.NET Core MVC. The main pieces every ASP.NET Web API project will need to migrate are routes, controllers, and models, along with updates to the types used by  controllers and actions.

