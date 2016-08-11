:version: 1.0.0

Overview of ASP.NET Core MVC
============================

By `Steve Smith`_

ASP.NET Core MVC is a rich framework for building web apps and APIs using the Model-View-Controller design pattern.

.. contents:: Sections:
  :local:
  :depth: 1

What is the MVC pattern?
------------------------

The Model-View-Controller (MVC) architectural pattern separates an application into three main groups of components: Models, Views, and Controllers. This pattern helps to achieve `separation of concerns <http://deviq.com/separation-of-concerns/>`_. Using this pattern, user requests are routed to a Controller which is responsible for working with the Model to perform user actions and/or retrieve results of queries. The Controller chooses the View to display to the user, and provides it with any Model data it requires.

The following diagram shows the three main components and which ones reference the others:

.. image:: overview/_static/mvc.png

This delineation of responsibilities helps you scale the application in terms of complexity because it’s much easier to code, debug, and test something (model, view, or controller) that has a single job rather than something that performs multiple tasks.

Kinds of Models
^^^^^^^^^^^^^^^

In simple applications, there may be just one kind of model class that is used by persistence, presentation, and any business logic. However, frequently this kind of one-size-fits-all approach doesn't scale to complex applications. In that case, it may make sense to have different model types (classes) with different responsibilities. Some MVC applications will include some combination of the following types of model objects.

Domain Model
############

Many developers choose to encapsulate complex business logic within a *domain model*, which doesn't depend on infrastructure concerns and is easily validated with :doc:`unit tests </testing/index>`. The domain model will often include abstractions and services that allow the Controller to operate at a higher level of abstraction, and keep low-level plumbing code from cluttering the Controller and making it harder to test.

Persistence Model
#################

Some applications have separate classes that map closely to how data is stored and retrieved from persistence. If you're using Entity Framework, it can usually map your domain model directly to persistence without the need for a separate persistence model.

View Model
##########

Many developers are familiar with the concept of a ViewModel, especially those who have used application frameworks that use the Model-View-ViewModel pattern. In an MVC web application, a ViewModel is a type that includes just the data a View requires for display (and perhaps sending back to the server). ViewModel types can also simplify `model binding`_. ViewModel types are generally just data containers; any logic they may have should be specific to helping the View render data.

Binding Model
############

Sometimes it may be worthwhile to create a type specifically for use with `model binding`_. These types are typically just data containers with no behavior.

.. note:: Using a binding model (or viewmodel) is recommended to avoid allowing a malicious user to set properties on the model that are not included in the UI, but are exposed via model binding.

API Model
#########

If your application exposes an API, the format of the data you expose to clients may be separated from your app's internal domain model by defining custom API model types. This allows you to change your internal model types without impacting clients that may be using your exposed APIs.

Controller Responsibilities
^^^^^^^^^^^^^^^^^^^^^^^^^^^

Controllers are the initial entry point for each request to an MVC app. Their primary responsibility is to work with the model to perform user commands and retrieve data in response to queries. The Controller then performs any necessary mapping from one model type to another (for instance creating a ViewModel needed for a particular View and populating it with results from the Domain Model), and then returns a particular View.

.. note:: It's not uncommon for controllers to become bloated with too many responsibilities. Try to follow the `Single Responsibility Principle <http://deviq.com/single-responsibility-principle/>`_ and push business logic out of the controller and into the domain model whenever possible.

.. tip:: If you find that your controller actions frequently perform the same kinds of actions, you can follow the `Don't Repeat Yourself principle <http://deviq.com/don-t-repeat-yourself/>`_ by moving these common actions into `filters`_.

View Responsibilities
^^^^^^^^^^^^^^^^^^^^^

Views are responsible for presenting content through the user interface. There should be minimal logic within views, and any logic in them should relate to presenting content. If you find the need to perform a great deal of logic in view files in order to display data from a complex model, consider using a ViewModel instead that is designed to suit the needs of the View.

What is ASP.NET Core MVC
------------------------

The ASP.NET Core MVC framework is a lightweight, open source, highly testable presentation framework optimized for use with ASP.NET Core. It is available in the "Microsoft.AspNetCore.Mvc" package, and is used by Visual Studio's "Web API" and "Web Application" ASP.NET Core Templates.

ASP.NET Core MVC gives you a powerful, patterns-based way to build dynamic websites that enables a clean separation of concerns and gives you full control over markup for enjoyable, agile development. ASP.NET Core MVC includes many features that enable fast, TDD-friendly development for creating sophisticated applications that use the latest web standards.

ASP.NET Core MVC in ASP.NET Core includes support for building web pages and HTTP services in a single aligned framework that can be hosted in IIS or self-hosted in your own process.

Features
--------

ASP.NET Core MVC includes the following features:
  - `Routing`_
  - `Model binding`_
  - `Model validation`_
  - `Dependency injection`_
  - `Filters`_
  - `Areas`_
  - `Web APIs`_
  - `Testability`_
  - `Razor view engine`_
  - `Strongly typed views`_
  - `Mobile support`_

Routing
^^^^^^^

ASP.NET Core MVC is built on top of :doc:`ASP.NET Core's routing </fundamentals/routing>`, a powerful URL-mapping component that lets you build applications that have comprehensible and searchable URLs. This enables you to define your application's URL naming patterns that work well for search engine optimization (SEO) and for link generation, without regard for how the files on your web server are organized. You can define your routes using a convenient route template syntax that supports route value constraints, defaults and optional values.

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
^^^^^^^^^^^^^

ASP.NET Core MVC :doc:`model binding </mvc/models/model-binding>` converts client request data  (form values, route data, query string parameters, HTTP headers) into objects that the controller can handle. As a result, your controller logic doesn't have to do the work of figuring out the incoming request data; it simply has the data as parameters to its action methods.

.. code-block:: C#

  public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null) { ... }

Model validation
^^^^^^^^^^^^^^^^

In addition to binding request data to model objects, ASP.NET Core MVC provides a powerful :doc:`validation <mvc/models/validation>` system. Simply add validation attributes to your model types using data annotation attributes and then check for model errors in your controller action.

.. code-block:: c#
  :emphasize-lines: 4-5,8-9

  using System.ComponentModel.DataAnnotations;
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

A controller action:

.. code-block:: c#
  :emphasize-lines: 3
  
  public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
  {
      if (ModelState.IsValid)
      {
        // work with the model
      }
      // If we got this far, something failed, redisplay form
      return View(model);
  }

The framework will handle validating request data both on the client and on the server. Validation logic specified on model types is added to the rendered views as unobtrusive annotations and is enforced in the browser via `jQuery Validation <http://jqueryvalidation.org/>`__.

Dependency injection
^^^^^^^^^^^^^^^^^^^^

ASP.NET Core MVC leverages ASP.NET Core's built-in support for :doc:`dependency injection </fundamentals/dependency-injection>`. :doc:`Controllers </mvc/controllers/dependency-injection>` can request needed services through their constructors, allowing them to follow the `Explicit Dependencies Principle <http://deviq.com/explicit-dependencies-principle/>`_:

.. literalinclude:: /../common/samples/WebApplication1/src/WebApplication1/Controllers/AccountController.cs
  :lines: 17-38
  :emphasize-lines: 10-14
  :language: c#

Your app can also use :doc:`dependency injection in view files </mvc/views/dependency-injection>`, using the ``@inject`` directive:

.. code-block:: html
  :emphasize-lines: 1

  @inject SomeService ServiceName
  <!DOCTYPE html>
  <html>
  <head>
    <title>@ServiceName.GetTitle</title>
  </head>
  <body>
    <h1>@ServiceName.GetTitle</h1>
  </body>
  </html>

Filters
^^^^^^^

:doc:`Filters </mvc/controllers/filters>` help developers encapsulate cross-cutting concerns, like exception handling or authorization. Filters enable running custom pre- and post-processing logic for action methods, and can be configured to run at certain points within the execution pipeline for a given request. Filters can be applied to controllers or actions as attributes, and several filters (such as ``Authorize``) are included in the framework.

.. literalinclude:: /../common/samples/WebApplication1/src/WebApplication1/Controllers/AccountController.cs
  :lines: 17-19
  :emphasize-lines: 1
  :language: c#

Areas
^^^^^

:doc:`Areas </mvc/controllers/areas>` provide a way to separate a large app into related groups of models, views, and controllers. This can reduce the number of each of these types of objects that developers must work with as they develop a particular part of the app.

Web APIs
^^^^^^^^

In addition to being a great platform for building web sites, ASP.NET Core MVC has great support for building Web APIs. You can build services that can reach a broad range of clients including browsers and mobile devices.

The framework includes support for HTTP content-negotiation with built-in support for :doc:`formatting data </mvc/models/formatting>` as JSON or XML. Write :doc:`custom formatters </mvc/models/custom-formatters>` to add support for your own formats. 

Use link generation to enable support for hypermedia. Easily enable support for `cross-origin resource sharing (CORS) <http://www.w3.org/TR/cors/>`__ so that your Web APIs shared across multiple Web applications.

Testability
^^^^^^^^^^^

The framework's use of interfaces and dependency injection make it well-suited to unit testing, and the framework includes features (like a TestHost and InMemory provider for Entity Framework) that make :doc:`integration testing </testing/integration-testing>` quick and easy as well. Learn more about :doc:`testing controller logic </mvc/controllers/testing>`.

Razor view engine
^^^^^^^^^^^^^^^^^

:doc:`ASP.NET Core MVC views </mvc/views/overview>` use the the :doc:`Razor view engine </mvc/views/razor>` to render views. Razor is a compact, expressive and fluid template markup language for defining views using embedded .NET code. Razor is used to dynamically generate web content on the server. Unlike most template syntaxes, you do not need to interrupt your coding to explicitly denote server blocks within your HTML. The parser is smart enough to infer this from your code. This makes creating views in Razor clean, fast and fun!

.. code-block:: html

  <ul>
    @for (int i = 0; i < 5; i++) {
      <li>List item @i</li>
    }
  </ul>

Using the Razor view engine you can define :doc:`layouts </mvc/views/layout>`, :doc:`partial views </mvc/views/partial>` and replaceable sections.

Strongly typed views
^^^^^^^^^^^^^^^^^^^^

Razor views in MVC can be strongly typed based on your model. A strongly-typed view explicitly specifies the model type for the view. You can then leverage the compiler and IntelliSense to ensure that references to property names and types in your views are correct:

.. code-block:: html

  @model IEnumerable<Product>
  <ul> 
      @foreach (Product p in Model) 
      { 
          <li>@p.Name</li>
      }
  </ul>

Tag helpers
^^^^^^^^^^^

:doc:`Tag Helpers </mvc/views/tag-helpers/intro>` enable you to dynamically generate or modify the HTML returned to the client. You can use tag helpers to define custom tags or to modify the behavior of existing tags. Tag Helpers bind to specific elements based on the element name and its attributes. Tag Helpers give you all of the benefits of server-side rendering while still preserving an HTML editing experience.

For example, you can use the built-in ``LinkTagHelper`` to create a link to the ``Login`` action of your ``AccountsController``:

.. code-block:: html
  :emphasize-lines: 3
  
  <p>
      Thank you for confirming your email. 
      Please <a asp-controller="Account" asp-action="Login">Click here to Log in</a>.
  </p>

Or you can use the ``EnvironmentTagHelper`` to include different scripts in your views (for example, raw or minified) based on the runtime environment, such as Development, Staring, or Production:

.. code-block:: html
  :emphasize-lines: 1,3-4,9

  <environment names="Development">
      <script src="~/lib/jquery/dist/jquery.js"></script>
  </environment>
  <environment names="Staging,Production">
      <script src="https://ajax.aspnetcdn.com/ajax/jquery/jquery-2.1.4.min.js"
              asp-fallback-src="~/lib/jquery/dist/jquery.min.js"
              asp-fallback-test="window.jQuery">
      </script>
  </environment>

ASP.NET Core MVC includes a full set of built-in Tag Helpers that you can use or you can build your own.

View Components
^^^^^^^^^^^^^^^

:doc:`View Components </mvc/views/view-components>` are like :doc:`partial views </mvc/views/partial>` with associated application buisiness logic. View Components can have asynchronous logic and can be reused throughout your application's views.

HTML Helpers
^^^^^^^^^^^^

:doc:`HTML Helpers </mvc/views/html-helpers>` are .NET methods that you can use in Razor views to generate HTML. HTML Helpers help you generate views based on your model while handling concerns like HTML encoding for you. 

.. code-block:: html
  :emphasize-lines: 1

  @using (Html.BeginForm("Search", "Home", FormMethod.Get)) 
  {
      <input type="text" name="q" />
      <input type="submit" value="Search" />
  }

ASP.NET Core MVC includes a comprehensive set of HTML Helpers for generating forms, labels, input elements, validation messages and links. You can customize the behavior of HTML Helpers for specific types using editor and display templates.

Mobile support
^^^^^^^^^^^^^^

ASP.NET Core MVC has great support for mobile development, including the ability to create :doc:`mobile-specific views </mvc/views/mobile>` to give your users the best possible experience on their devices.
