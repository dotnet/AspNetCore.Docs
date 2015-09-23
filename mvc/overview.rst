Overview of ASP.NET MVC
=======================
By `Tom Archer`_

.. image:: overview/_static/mvc.png
  :align: right

Based on the *MVC architectural pattern*, the ASP.NET MVC framework is a lightweight, cross-platform, highly testable application-development framework that separates an application into three main components: model, view, and controller:

- :doc:`Models </models/index>` are the parts of the application that implement the logic for the application's data domain. Often, model objects retrieve and store model state in a database. For example, a Product object might retrieve information from a database, operate on it, and then write updated information back to a Products table in a SQL Server database.

- :doc:`Views </views/index>` are responsible for displaying the application's user interface (UI). Typically, this UI is created from the model data. An example would be an edit view of a Products table that displays text boxes, drop-down lists, and check boxes based on the current state of the Product object being represented in the view.

- :doc:`Controllers </controllers/index>` process incoming requests, work with the model, and ultimately return a view to the client that displays the user interface.

This delineation of responsibilities – referred to as the *separation of concerns (SoC)*  - helps you scale the application in terms of complexity because it’s much easier to code, debug, and test something (model, view, or controller) that has a single job rather than something that performs multiple tasks.

Features of the ASP.NET MVC framework
-------------------------------------

The ASP.NET MVC framework provides the following features:

- `Routing`_

- `Tag Helpers`_

- `Model binding and formatting`_

- `View Components`_

- `Dependency Injection`_

- `Filters`_

- `Areas`_

- `Mobile development`_

- `Single unified framework for Web UI and Web APIs`_

- `Test-driven Development`_

- `Built on top of ASP.NET 5`_

Routing
-------

:doc:`Routing </controllers/routing>` is a powerful URL-mapping component that lets you build applications that have comprehensible and searchable URLs. This enables you to define your application's URL naming patterns that work well for search engine optimization (SEO) and for link generation.

  - **Convention routing** enables you to define the URL formats that your application accepts and how each of those formats maps to a specific action method on given controller. When an incoming request is received, the routing engine parses the incoming URL and matches it to one of the defined URL formats, and calls the associated controller's action method.

   In the following example call to ``MapRoute``, the first argument - ``name`` - is the name of the route, and is used to distinguish this route from any other routes you define. The second argument - ``template`` - is where the magic happens. This is where you map the incoming URL segments to the appropriate controller and action.

   Looking at this route definition, we can see that if the user types in ``http://<yourAppName>/Product/Display/42``, the ``Display`` method on the ``ProductController`` controller will be called.

    .. code-block:: c#

      routes.MapRoute(
          name: "Product",
          template: "Product/Display");

  - **Attribute routing** enables you to specify routing information by decorating your controllers and actions with attributes that define your application's routes. This means that your route definitions are placed next to the controller and action with which they're associated.

    In the following example, I've taken the previous route definition and simply turned it into an attribute on the ``ProductController`` controller's ``Display`` action method. Note that the ``template`` value is exactly the same.

      .. code-block:: c#
        :emphasize-lines: 5

        public class ProductController : Controller
        {
          ...

          [Route("Product/Display")]
          public IActionResult Display()
          {
            ...

  - **Route tokens** enable you to future-proof your routes by allowing you to specify tokens - such as ``[controller]`` or ``[action]`` - instead of hard-coded literals representing specific controllers or action names. This way, if you change the name of your controller or action at some point, your routes will still work as your routing entry refers to the token and not the underlying string value.

    Taking the previous attribute routing example, we can ensure that any naming changes to the controller and action won't affect our routes by using the ``[controller]`` and ``[action]`` tokens instead of hard-coded names.

    .. code-block:: c#
      :emphasize-lines: 1,10

        [Route("[controller]")]
        public class ProductController : Controller
        {
            // GET: /<controller>/
            public IActionResult Index()
            {
              return View();
            }

            [Route("[action]")]
            public IActionResult Display()
            {
                return View();
            }
        }


  - Parameters, constraints, and optionality - MVC gives you complete control over how requests are mapped to routes. This includes the ability to use regular expressions in setting up constraints, defining default values, and specifying optional values.

    Defining parameters for an MVC route is done by utilizing the {} syntax. In the following example, a attribute route is defined as taking a single parameter called ``id``. The ``:int`` suffix to that parameter name indicates a constraint that the value *must* be an integer value. Finally, the ``?`` operator indicates that the value is optional.

    Using this route, the user can enter a URL of ``http://<yourApp>/Product/Display/42`` where the ``Display`` action method of the ``ProductController`` controller will be called with the ``id`` parameter being set to the user-passed value of ``42``.

    .. code-block:: c#
      :emphasize-lines: 10


        [Route("[controller]")]
        public class ProductController : Controller
        {
          // GET: /<controller>/
          public IActionResult Index()
          {
            return View();
            }

          [Route("[action]/{id:int?}")]
          public IActionResult Display(int id)
          {
            return View();
          }
        }

Tag Helpers
-----------
Similar to HTML Helpers, :doc:`Tag Helpers </views/tag-helpers/intro>` enable you to dynamically modify the HTML returned to the client based on input from the controller.

In the following example, you can see first an HTML Helper example of a simple input form that incorporates labels, text fields, and validation. Note the use of Razor C# syntax mixed in with the HTML markup.

HTML Helper example
^^^^^^^^^^^^^^^^^^^

.. code-block:: html

  @model MyStore.Models.Product

  @using (Html.BeginForm())
  {
      <div class="editor-label">
          @Html.LabelFor(m => m.Item)
      </div>
      <div class="editor-field">
          @Html.EditorFor(m => m.Item)
          @Html.ValidationMessageFor(m => m.Item)
      </div>

      <div class="editor-label">
          @Html.LabelFor(m => m.Price)
      </div>
      <div class="editor-field">
          @Html.EditorFor(m => m.Price)
          @Html.ValidationMessageFor(m => m.Price)
      </div>

      <button type="submit">Create</button>
  }

Now, let's see a version of the same form that uses Tag Helpers instead of HTML Helpers. As you can see, the code is much cleaner and easier to read.

Tag Helper example
^^^^^^^^^^^^^^^^^^^

.. code-block:: html

  @model MyStore.Models.Product

  @using (Html.BeginForm())
  {
      <div>
          <label asp-for="Name"></label>
          <input type="text" asp-for="Name"/>
          <span asp-validation-for="Name"></span>
      </div>

      <div>
          <label asp-for="Price"></label>
          <input type="text" asp-for="Price" />
          <span asp-validation-for="Price"></span>
      </div>

      <button type="submit">Create</button>
  }

Model binding and formatting
----------------------------

MVC :doc:`model binding and formatting </models/model-binding>` converts form (Web page) values and route data from the incoming HTTP request into objects that the controller can handle. As a result, your controller logic doesn't have to do the work of figuring out the incoming request data; it simply has the data as parameters to its action methods.

To see this in action, let's take a simple example of creating a new product. First the Model definition which, to keep things simple, has only two fields (``Name`` and ``Price``).

.. code-block:: c#

  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;
  using System.ComponentModel.DataAnnotations;

  namespace MyStore.Models
  {
      public class Product
      {
          [Required(ErrorMessage ="Enter a name for this product")]
          public string Name { get; set; }

          public decimal Price { get; set; }
      }
  }

Now, let's see the view and its layout. Note the model definition at the top of the view.

.. code-block:: html

  @model MyStore.Models.Product
  @{
      ViewBag.Title = "Create Product";
  }
  <h2>@ViewBag.Title</h2>
  @using (Html.BeginForm())
  {
      <div>
          <label asp-for="Name"></label>
          <input type="text" asp-for="Name"/>
          <span asp-validation-for="Name"></span>
      </div>

      <div>
          <label asp-for="Price"></label>
          <input type="text" asp-for="Price" />
          <span asp-validation-for="Price"></span>
      </div>

      <button type="submit">Create</button>
  }

And now, the controller logic.

.. code-block:: c#

  namespace MyStore.Controllers
  {
      [Route("[controller]")]
      public class ProductController : Controller
      {
          [Route("[action]")]
          public IActionResult Create()
          {
              return View();
          }

          [HttpPost]
          [Route("[action]")]
          public IActionResult Create(Product p)
          {
              if (ModelState.IsValid)
              {
                  return RedirectToAction("Index");
              }
              return View(p);
          }
      }
  }

As you can see, there are two ``ProductController.Create`` methods - one (the parameter-less version) that is called when the user browses to ``http://<yourApp>/Product/Create``, and another one (with the ``HttpPost`` attribute) that is called when the user submits the form via the ``Submit`` button.

Note that all the ``Create`` action method has to do is work with the incoming model object. That's because MVC model binding did the heavy lifting of retrieving the values that were POST-ed to your app, and mapped them into your model object for you.

For more advanced scenarios - such as custom model binding (enables you to specify how you want complex route data to appear to the controller) and content negotiation (enables you to specify what format will be used in the response), see the article on :doc:`model binding and formatting </models/model-binding>`.

View Components
---------------
Similar to partial views, :doc:`View Components </views/view-components>` include the same separation-of-concerns and testability benefits found between a controller and view that acts as a mini-controller capable of rendering a partial response to the client rather than a whole response.

Dependency Injection
--------------------

:doc:`Dependency Injection (DI) </views/dependency-injection>` is a software design pattern that implements the Inversion of Control (IoC) principle for resolving dependencies.

Filters
-------

:doc:`Filters </controllers/filters>` enables you to specify pre and post processing logic for control action methods.

  - Action filters - Performs additional processing, such as providing extra data to the action method, inspecting the return value, or canceling execution of the action method.
  - Action result filters - Performs additional processing of the result, such as modifying the HTTP response.
  - Authorization filters - Makes security decisions about whether to execute an action method, such as performing authentication or validating properties of the request.
  - Exception filters - Execute if there is an unhandled exception thrown from an action method, starting with the authorization filters and ending with the execution of the result. Exception filters can be used for tasks such as logging or displaying an error page.

Areas
-----

:doc:`Areas </controllers/areas>` provides a way to separate a large MVC application into semantically-related groups of models, views, and controllers.

Mobile Development
------------------

MVC has great support for :doc:`mobile development </views/mobile>`, including the ability to create mobile-specific views to give your customers the best possible experience on their devices.

Single Unified Framework for Web UI and Web APIs
------------------------------------------------

The following frameworks are now combined into a single framework making Web UI and Web API development easier than ever.

  - `MVC <http://asp.net/mvc>`_ is what you use for more sophisticated, complex applications that require more structure and the ability to easily unit test.
  - `Web API <http://asp.net/web-api>`_ is great for coding Web services where you want to target a variety of clients - such as browsers and mobile devices.
  - `Web Pages (future) <http://asp.net/web-pages>`_ is a lightweight framework for building UI. It's designed for being able to quickly and easily create a set of Web pages.

Test-driven Development
-----------------------

All core contracts in the MVC framework are interface-based and can be tested by using *mocking* - a process of creating simple substitute (mock) objects for the dependencies in a class so you can test the class without the dependencies.

Built on top of ASP.NET 5
-------------------------

MVC support ASP.NET features such as forms and Windows authentication, URL authorization, membership and roles, output and data caching, session and profile state management, health monitoring, and the configuration system.
