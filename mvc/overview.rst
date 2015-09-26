Overview of ASP.NET MVC
=======================
By `Tom Archer`_, `Daniel Roth`_

.. image:: overview/_static/mvc.png
  :align: right

ASP.NET MVC is a lightweight, cross-platform, highly testable Web application development framework that separates an application into three main components: model, view, and controller:

- :doc:`Models </models/index>` are the parts of the application that implement application's state. Often, model objects retrieve and store model state in a database. For example, a Product object might retrieve information from a database, operate on it, and then write updated information back to a Products table in a SQL Server database.

- :doc:`Views </views/index>` are responsible for displaying the application's user interface (UI). Typically, this UI is created from the model data. An example would be an edit view of a Products table that displays text boxes, drop-down lists, and check boxes based on the current state of the Product object being represented in the view.

- :doc:`Controllers </controllers/index>` process incoming requests, work with the model, and ultimately return a view to the client that displays the user interface.

This delineation of responsibilities helps you scale the application in terms of complexity because it’s much easier to code, debug, and test something (model, view, or controller) that has a single job rather than something that performs multiple tasks.

Features
--------

ASP.NET MVC provides the following features:
  - `Routing`_
  - `Model binding`_
  - `Request validation`_
  - `Razor view engine`_
  - `Strongly typed views`_
  - `HTML Helpers`_
  - `Tag Helpers`_
  - `View Components`_
  - `Dependency Injection`_
  - `Filters`_
  - `Areas`_
  - `Mobile development`_
  - `Web UI and Web APIs`_
  - `Test-driven Development`_
  - `Built on top of ASP.NET 5`_

Routing
-------

MVC is built on :doc:`ASP.NET Routing </controllers/routing>`, a powerful URL-mapping component that lets you build applications that have comprehensible and searchable URLs. This enables you to define your application's URL naming patterns that work well for search engine optimization (SEO) and for link generation. You can define your routes using a convenient route template syntax that supports route value constraints, defaults and optional values.

*Convention-based routing* enables you to globally define the URL formats that your application accepts and how each of those formats maps to a specific action method on given controller. When an incoming request is received, the routing engine parses the incoming URL and matches it to one of the defined URL formats, and calls the associated controller's action method. 

.. code-block:: c#

  routes.MapRoute(name: "Default", template: "{controller=Home}/{action=Index}/{id?}");

*Attribute routing* enables you to specify routing information by decorating your controllers and actions with attributes that define your application's routes. This means that your route definitions are placed next to the controller and action with which they're associated.

.. code-block:: c#
  :emphasize-lines: 1,4

  [Route("api/[controller]")]
  public class ProductsController : Controller
  {
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
      ...
    }
  }

Model binding
-------------

MVC :doc:`model binding </models/model-binding>` converts request data (form values, route data, query string parameters, HTTP headers) into objects that the controller can handle. As a result, your controller logic doesn't have to do the work of figuring out the incoming request data; it simply has the data as parameters to its action methods.

.. code-block:: C#

  public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null) { ... }

Request validation
------------------

MVC provides a powerful :doc:`validation <models/validation>` system for validating request data. Simply add validation logic to your model types using data annotation attributes:

.. code-block:: c#
  :emphasize-lines: 3-4,7-8

  public class LoginViewModel
  {
      [Required]
      [EmailAddress]
      public string Email { get; set; }

      [Required]
      [DataType(DataType.Password)]
      public string Password { get; set; }

      [Display(Name = "Remember me?")]
      public bool RememberMe { get; set; }
  }

MVC will handle validating request data both on the client and on the server. Validation logic specified on model types is added to the rendered views as unobtrusive annotations and is enforced in the browser via `jQuery Validation <http://jqueryvalidation.org/>`__.

Razor View Engine
-----------------

MVC uses the Razor view engine for rendering views. Razor is a compact, expressive and fluid template markup language for defining views using embedded .NET code. Razor is used to dynamically generate web content on the server. Unlike most template syntaxes, you do not need to interrupt your coding to explicitly denote server blocks within your HTML. The parser is smart enough to infer this from your code. This make creating views in Razor clean, fast and fun!

.. code-block:: html

  <ul>
    @for (int i = 0; i < 5; i++) {
      <li>List item @i</li>
    }
  </ul>

Using the MVC Razor view engine you can define layouts, partial views and replaceable sections.

Strongly typed views
--------------------

Razor views in MVC can be strongly typed based on your model. A strongly-typed view explicitly specifies the model type for the view. You can then leverage the compiler and IntelliSense to ensure that references to property names and types in your views are correct:

.. code-block:: html

  @model IEnumerable<MvcMusicStore.Models.Album>
  <ul> 
      @foreach (Album p in Model) 
      { 
          <li>@p.Title</li>
      }
  </ul>

HTML Helpers
------------

HTML Helpers are .NET methods that you can use in Razor views to generate HTML. HTML Helpers help you generate views based on your model while handling concerns like HTML encoding for you. 

.. code-block:: html
  :emphasize-lines: 1

  @using (Html.BeginForm("Search", "Home", FormMethod.Get)) 
  {
      <input type="text" name="q" />
      <input type="submit" value="Search" />
  }

MVC includes a comprehensive set of HTML Helpers for generating forms, labels, input elements, validation messages and links. You can customize the behavior of HTML Helpers for specific types using editor and display templates.

Tag Helpers
-----------
:doc:`Tag Helpers </views/tag-helpers/intro>` enable you to dynamically generate or modify the HTML returned to the client. You can use tag helpers to define custom tags or to modify the behavior existing tags. Tag Helpers bind to specific elements based on the element name and its attributes. Tag Helpers give you all of the benefits of server-side rendering while still preserving an HTML editing experience.

For example, you can use built-in ``LinkTagHelper`` to create a link to the ``Login`` action of your ``AccountsController`` like this:

.. code-block:: html
  :emphasize-lines: 3
  
  <p>
      Thank you for confirming your email. 
      Please <a asp-controller="Account" asp-action="Login">Click here to Log in</a>.
  </p>

Or you can use the ``EnvironmentTagHelper`` to include different scripts in your views (ex full vs minified) based on the runtime environment (i.e. Development vs Production):

.. code-block:: html

  <environment names="Development">
      <script src="~/lib/jquery/dist/jquery.js"></script>
  </environment>
  <environment names="Staging,Production">
      <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-2.1.4.min.js"
              asp-fallback-src="~/lib/jquery/dist/jquery.min.js"
              asp-fallback-test="window.jQuery">
      </script>
  </environment>

MVC includes a full set of built-in Tag Helpers that you can use or your can build your own.

View Components
---------------
:doc:`View Components </views/view-components>` are like partial views with associated application buisiness logic. View Components can have asynchronous logic and can be reused throughout your application views.

Dependency Injection
--------------------

MVC is built on the :ref:`dependency injection (DI) <aspnet:dependency-injection>` support in ASP.NET. Support for DI is plumbed throughout MVC. You can inject services into controllers, models, views, filters and View Components.

Filters
-------

:doc:`Filters </controllers/filters>` enable you to specify pre and post processing logic for control action methods. Use filters to handle cross-cutting concerns, like authorization and exception handling, without having to repeat the same logic across all of your controller actions.

Areas
-----

:doc:`Areas </controllers/areas>` provides a way to separate a large MVC application into semantically-related groups of models, views, and controllers.

Mobile Development
------------------

MVC has great support for :doc:`mobile development </views/mobile>`, including the ability to create mobile-specific views to give your customers the best possible experience on their devices.

Web UI and Web APIs
-------------------

In addition to being a great platform for build websites MVC has great support for building Web APIs. With MVC you can build RESTful services that can reach a broad ranch of clients including browsers and mobile devices. MVC includes support for HTTP content-negotiation with built-in support for form data, JSON and XML. Write custom formatters to add support for your own formats. Use link generation to enable support for hypermedia. Because MVC supports both Web UI and Web APIs as a unified framework you can leverage common infrastructure for model binding, request validation and handling cross-cutting concerns via filters.

Test-driven Development
-----------------------

All core contracts in the MVC framework are interface-based and can be tested by using *mocking* - a process of creating simple substitute (mock) objects for the dependencies in a class so you can test the class without the dependencies.

Built on top of ASP.NET 5
-------------------------

MVC is built on ASP.NET 5 and supports ASP.NET features such as forms and Windows authentication, URL authorization, membership and roles, output and data caching, session and profile state management, health monitoring, and the configuration system.
