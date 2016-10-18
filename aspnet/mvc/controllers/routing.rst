Routing to Controller Actions
========================================

By `Ryan Nowak`_ and `Rick Anderson`_

ASP.NET Core MVC uses the Routing :doc:`middleware </fundamentals/middleware>` to match the URLs of incoming requests and map them to actions. Routes are defined in startup code or attributes. Routes describe how URL paths should be matched to actions. Routes are also used to generate URLs (for links) sent out in responses.

This document will explain the interactions between MVC and routing, and how typical MVC apps make use of routing features. See :doc:`Routing </fundamentals/routing>` for details on advanced routing.

.. contents:: Sections:
  :local:
  :depth: 1

Setting up Routing Middleware
------------------------------

In your `Configure` method you may see code similar to::

  app.UseMvc(routes =>
  {
     routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
  });

Inside the call to :dn:method:`~Microsoft.AspNetCore.Builder.MvcApplicationBuilderExtensions.UseMvc`, :dn:method:`~Microsoft.AspNetCore.Builder.MapRouteRouteBuilderExtensions.MapRoute` is used to create a single route, which we'll refer to as the ``default`` route. Most MVC apps will use a route with a template similar to the ``default`` route.

The route template ``"{controller=Home}/{action=Index}/{id?}"`` can match a URL path like ``/Products/Details/5`` and will extract the route values ``{ controller = Products, action = Details, id = 5 }`` by tokenizing the path. MVC will attempt to locate a controller named ``ProductsController`` and run the action ``Details``::

  public class ProductsController : Controller
  {
     public IActionResult Details(int id) { ... }
  }

Note that in this example, model binding would use the value of ``id = 5`` to set the ``id`` parameter to ``5`` when invoking this action. See the :doc:`/mvc/models/model-binding` for more details.

Using the ``default`` route::

   routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");

The route template:

- ``{controller=Home}`` defines ``Home`` as the default ``controller``
- ``{action=Index}`` defines ``Index`` as the default ``action``
- ``{id?}`` defines ``id`` as optional

Default and optional route parameters do not need to be present in the URL path for a match. See the  :doc:`Routing </fundamentals/routing>` for a detailed description of route template syntax.

``"{controller=Home}/{action=Index}/{id?}"`` can match the URL path ``/`` and will produce the route values ``{ controller = Home, action = Index }``. The values for ``controller`` and ``action`` make use of the default values, ``id`` does not produce a value since there is no corresponding segment in the URL path. MVC would use these route values to select the ``HomeController`` and ``Index`` action::

  public class HomeController : Controller
  {
    public IActionResult Index() { ... }
  }

Using this controller definition and route template, the ``HomeController.Index`` action would be executed for any of the following URL paths:

- ``/Home/Index/17``
- ``/Home/Index``
- ``/Home``
- ``/``

The convenience method :dn:method:`~Microsoft.AspNetCore.Builder.MvcApplicationBuilderExtensions.UseMvcWithDefaultRoute`::

  app.UseMvcWithDefaultRoute();

Can be used to replace::

  app.UseMvc(routes =>
  {
     routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
  });

``UseMvc`` and ``UseMvcWithDefaultRoute`` add an instance of :dn:cls:`~Microsoft.AspNetCore.Builder.RouterMiddleware` to the middleware pipeline. MVC doesn't interact directly with middleware, and uses routing to handle requests. MVC is connected to the routes through an instance of :dn:cls:`~Microsoft.AspNetCore.Mvc.Internal.MvcRouteHandler`. The code inside of ``UseMvc`` is similar to the following::

   var routes = new RouteBuilder(app);

   // Add connection to MVC, will be hooked up by calls to MapRoute.
   routes.DefaultHandler = new MvcRouteHandler(...);

   // Execute callback to register routes.
   // routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");

   // Create route collection and add the middleware.
   app.UseRouter(routes.Build());

:dn:method:`~Microsoft.AspNetCore.Builder.MvcApplicationBuilderExtensions.UseMvc` does not directly define any routes, it adds a placeholder to the route collection for the ``attribute`` route. The overload ``UseMvc(Action<IRouteBuilder>)`` lets you add your own routes and also supports attribute routing.  ``UseMvc`` and all of its variations adds a placeholder for the attribute route - attribute routing is always available regardless of how you configure ``UseMvc``. :dn:method:`~Microsoft.AspNetCore.Builder.MvcApplicationBuilderExtensions.UseMvcWithDefaultRoute` defines a default route and supports attribute routing. The :ref:`attribute-routing-ref-label` section includes more details on attribute routing.

.. _routing-conventional-ref-label:

Conventional routing
---------------------

The ``default`` route::

  routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");

is an example of a *conventional routing*. We call this style *conventional routing* because it establishes a *convention* for URL paths:

-  the first path segment maps to the controller name
-  the second maps to the action name.
-  the third segment is used for an optional ``id`` used to map to a model entity

Using this ``default`` route, the URL path ``/Products/List`` maps to the ``ProductsController.List`` action, and ``/Blog/Article/17`` maps to ``BlogController.Article``. This mapping is based on the controller and action names **only** and is not based on namespaces, source file locations, or method parameters.

.. Tip:: Using conventional routing with the default route allows you to build the application quickly without having to come up with a new URL pattern for each action you define. For an application with CRUD style actions, having consistency for the URLs across your controllers can help simplify your code and make your UI more predictable.

.. warning:: The ``id`` is defined as optional by the route template, meaning that your actions can execute without the ID provided as part of the URL. Usually what will happen if ``id`` is omitted from the URL is that it will be set to ``0`` by model binding, and as a result no entity will be found in the database matching ``id == 0``. Attribute routing can give you fine-grained control to make the ID required for some actions and not for others. By convention the documentation will include optional parameters like ``id`` when they are likely to appear in correct usage.

Multiple Routes
-------------------

You can add multiple routes inside ``UseMvc`` by adding more calls to ``MapRoute``. Doing so allows you to define multiple conventions, or to add conventional routes that are dedicated to a specific action, such as::

   app.UseMvc(routes =>
   {
      routes.MapRoute("blog", "blog/{*article}",
               defaults: new { controller = "Blog", action = "Article" });
      routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
   }

The ``blog`` route here is a *dedicated conventional route*, meaning that it uses the conventional routing system, but is dedicated to a specific action. Since ``controller`` and ``action`` don't appear in the route template as parameters, they can only have the default values, and thus this route will always map to the action ``BlogController.Article``.

Routes in the route collection are ordered, and will be processed in the order they are added. So in this example, the ``blog`` route will be tried before the ``default`` route.

.. note:: *Dedicated conventional routes* often use catch-all route parameters like ``{*article}`` to capture the remaining portion of the URL path. This can make a route 'too greedy' meaning that it matches URLs that you intended to be matched by other routes. Put the 'greedy' routes later in the route table to solve this.

Fallback
^^^^^^^^^

As part of request processing, MVC will verify that the route values can be used to find a controller and action in your application. If the route values don't match an action then the route is not considered a match, and the next route will be tried. This is called *fallback*, and it's intended to simplify cases where conventional routes overlap.

Disambiguating Actions
^^^^^^^^^^^^^^^^^^^^^^^^

When two actions match through routing, MVC must disambiguate to choose the 'best' candidate or else throw an exception. For example::

   public class ProductsController : Controller
   {
      public IActionResult Edit(int id) { ... }

      [HttpPost]
      public IActionResult Edit(int id, Product product) { ... }
   }

This controller defines two actions that would match the URL path ``/Products/Edit/17`` and route data ``{ controller = Products, action = Edit, id = 17 }``. This is a typical pattern for MVC controllers where ``Edit(int)`` shows a form to edit a product, and ``Edit(int, Product)`` processes  the posted form. To make this possible MVC would need to choose ``Edit(int, Product)`` when the request is an HTTP ``POST`` and ``Edit(int)`` when the HTTP verb is anything else.

The :dn:cls:`~Microsoft.AspNetCore.Mvc.HttpPostAttribute` ( ``[HttpPost]`` ) is an implementation of :dn:iface:`~Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint` that will only allow the action to be selected when the HTTP verb is ``POST``. The presence of an ``IActionConstraint`` makes the ``Edit(int, Product)`` a 'better' match than ``Edit(int)``, so ``Edit(int, Product)`` will be tried first. See :ref:`iactionconstraint-ref-label` for details.

You will only need to write custom ``IActionConstraint`` implementations in specialized scenarios, but it's important to understand the role of attributes like ``HttpPostAttribute``  - similar attributes are defined for other HTTP verbs. In conventional routing it's common for actions to use the same action name when they are part of a ``show form -> submit form`` workflow. The convenience of this pattern will become more apparent after reviewing the :ref:`routing-url-gen-ref-label` section.

If multiple routes match, and MVC can't find a 'best' route, it will throw an :dn:cls:`~Microsoft.AspNetCore.Mvc.Internal.AmbiguousActionException`.

.. _routing-route-name-ref-label:

Route Names
^^^^^^^^^^^

The strings  ``"blog"`` and ``"default"`` in the following examples are route names::

  app.UseMvc(routes =>
  {
     routes.MapRoute("blog", "blog/{*article}",
                 defaults: new { controller = "Blog", action = "Article" });
     routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
  });

The route names give the route a logical name so that the named route can be used for URL generation. This greatly simplifies URL creation when the ordering of routes could make URL generation complicated. Routes names must be unique application-wide.

Route names have no impact on URL matching or handling of requests; they are used only for URL generation. :doc:`Routing </fundamentals/routing>` has more detailed information on URL generation including URL generation in MVC-specific helpers.

.. _attribute-routing-ref-label:

Attribute Routing
-------------------------

Attribute routing uses a set of attributes to map actions directly to route templates. In the following example, ``app.UseMvc();`` is used in the ``Configure`` method and no route is passed. The ``HomeController`` will match a set of URLs similar to what the default route ``{controller=Home}/{action=Index}/{id?}`` would match:

.. code-block:: c#

  public class HomeController : Controller
  {
     [Route("")]
     [Route("Home")]
     [Route("Home/Index")]
     public IActionResult Index()
     {
        return View();
     }
     [Route("Home/About")]
     public IActionResult About()
     {
        return View();
     }
     [Route("Home/Contact")]
     public IActionResult Contact()
     {
        return View();
     }
  }

The ``HomeController.Index()`` action will be executed for any of the URL paths ``/``, ``/Home``, or ``/Home/Index``.

.. note:: This example highlights a key programming difference between attribute routing and conventional routing. Attribute routing requires more input to specify a route; the conventional default route handles routes more succinctly. However, attribute routing allows (and requires) precise control of which route templates apply to each action.

With attribute routing the controller name and action names play **no** role in which action is selected. This example will match the same URLs as the previous example.

.. code-block:: c#

  public class MyDemoController : Controller
  {
     [Route("")]
     [Route("Home")]
     [Route("Home/Index")]
     public IActionResult MyIndex()
     {
        return View("Index");
     }
     [Route("Home/About")]
     public IActionResult MyAbout()
     {
        return View("About");
     }
     [Route("Home/Contact")]
     public IActionResult MyContact()
     {
        return View("Contact");
     }
  }

.. note:: The route templates  above doesn't define route parameters for ```action``, ``area``, and ``controller``. In fact, these route parameters are not allowed in attribute routes. Since the route template is already assocated with an action, it wouldn't make sense to parse the action name from the URL.

Attribute routing can also make use of the ``HTTP[Verb]`` attributes such as :dn:cls:`~Microsoft.AspNetCore.Mvc.HttpPostAttribute`. All of these attributes can accept a route template. This example shows two actions that match the same route template:

.. code-block:: c#

   [HttpGet("/products")]
   public IActionResult ListProducts()
   {
      // ...
   }

   [HttpPost("/products")]
   public IActionResult CreateProduct(...)
   {
      // ...
   }

For a URL path like ``/products`` the ``ProductsApi.ListProducts`` action will be executed when the HTTP verb is ``GET`` and ``ProductsApi.CreateProduct`` will be executed when the HTTP verb is ``POST``. Attribute routing first matches the URL against the set of route templates defined by route attributes. Once a route template matches,   :dn:iface:`~Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint` constraints are applied to determine which actions can be executed.

.. Tip:: When building a REST API, it's rare that you will want to use ``[Route(...)]`` on an action method. It's better to use the more specific ``Http*Verb*Attributes`` to be precise about what your API supports. Clients of REST APIs are expected to know what paths and HTTP verbs map to specific logical operations.

Since an attribute route applies to a specific action, it's easy to make parameters required as part of the route template definition. In this example, ``id`` is required as part of the URL path.

.. code-block:: c#

   public class ProductsApiController : Controller
   {
      [HttpGet("/products/{id}", Name = "Products_List")]
      public IActionResult GetProduct(int id) { ... }
   }

The ``ProductsApi.GetProducts(int)`` action will be executed for a URL path like ``/products/3`` but not for a URL path like ``/products``. See :doc:`Routing </fundamentals/routing>` for a full description of route templates and related options.

This route attribute also defines a *route name* of ``Products_List``. Route names can be used to generate a URL based on a specific route. Route names have no impact on the URL matching behavior of routing and are only used for URL generation. Route names must be unique application-wide.

.. note:: Contrast this with the conventional *default route*, which defines the ``id`` parameter as optional (``{id?}``). This ability to precisely specify APIs has advantages, such as  allowing ``/products`` and ``/products/5`` to be dispatched to different actions.

.. _routing-combining-ref-label:

Combining Routes
^^^^^^^^^^^^^^^^^

To make attribute routing less repetitive, route attributes on the controller are combined with route attributes on the individual actions. Any route templates defined on the controller are prepended to route templates on the actions. Placing a route attribute on the controller makes **all** actions in the controller use attribute routing.

.. code-block:: c#

   [Route("products")]
   public class ProductsApiController : Controller
   {
      [HttpGet]
      public IActionResult ListProducts() { ... }

      [HttpGet("{id}")]
      public ActionResult GetProduct(int id) { ... }
   }

In this example the URL path ``/products`` can match ``ProductsApi.ListProducts``, and the URL path ``/products/5`` can match ``ProductsApi.GetProduct(int)``. Both of these actions only match HTTP ``GET`` because they are decorated with the :dn:cls:`~Microsoft.AspNetCore.Mvc.HttpGetAttribute`.

Route templates applied to an action that begin with a ``/`` do not get combined with route templates applied to the controller. This example matches a set of URL paths similar to the *default route*.

.. literalinclude:: routing/sample/main/Controllers/HomeController.cs
  :language: c#
  :start-after: snippet
  :end-before: #endregion

.. _routing-ordering-ref-label:

Ordering attribute routes
^^^^^^^^^^^^^^^^^^^^^^^^^^

In contrast to conventional routes which execute in a defined order, attribute routing builds a tree and matches all routes simultaneously. This behaves as-if the route entries were placed in an ideal ordering; the most specific routes have a chance to execute before the more general routes.

For example, a route like ``blog/search/{topic}`` is more specific than a route like ``blog/{*article}``. Logically speaking the ``blog/search/{topic}`` route 'runs' first, by default, because that's the only sensible ordering. Using conventional routing, the developer is  responsible for placing routes in the desired order.

Attribute routes can configure an order, using the ``Order`` property of all of the framework provided route attributes. Routes are processed according to an ascending sort of the ``Order`` property. The default order is ``0``. Setting a route using ``Order = -1`` will run before routes that don't set an order. Setting a route using ``Order = 1`` will run after default route ordering.

.. Tip:: Avoid depending on ``Order``. If your URL-space requires explicit order values to route correctly, then it's likely confusing to clients as well. In general attribute routing will select the correct route with URL matching. If the default order used for URL generation isn't working, using route name as an override is usually simpler than applying the ``Order`` property.

.. _routing-token-replacement-templates-ref-label:

Token replacement in route templates ([controller], [action], [area])
-----------------------------------------------------------------------

For convenience, attribute routes support *token replacement* by enclosing a token in square-braces (``[``, ``]``]). The tokens ``[action]``, ``[area]``, and ``[controller]`` will be replaced with the values of the action name, area name, and controller name from the action where the route is defined. In this example the actions can match URL paths as described in the comments:

.. literalinclude:: routing/sample/main/Controllers/ProductsController.cs
  :language: c#
  :lines: 7-11,13-17,20-22
  :dedent: 4

Token replacement occurs as the last step of building the attribute routes. The above example will behave the same as the following code:

.. literalinclude:: routing/sample/main/Controllers/ProductsController2.cs
  :language: c#
  :lines: 7-11,13-17,20-22
  :dedent: 4

Attribute routes can also be combined with inheritance. This is particularly powerful combined with token replacement.

.. code-block:: c#

   [Route("api/[controller]")]
   public abstract class MyBaseController : Controller { ... }

   public class ProductsController : MyBaseController
   {
      [HttpGet] // Matches '/api/Products'
      public IActionResult List() { ... }

      [HttpPost("{id}")] // Matches '/api/Products/{id}'
      public IActionResult Edit(int id) { ... }
   }

Token replacement also applies to route names defined by attribute routes. ``[Route("[controller]/[action]", Name="[controller]_[action]")]`` will generate a unique route name for each action.

.. _routing-multiple-routes-ref-label:

Multiple Routes
^^^^^^^^^^^^^^^^

Attribute routing supports defining multiple routes that reach the same action. The most common usage of this is to mimic the behavior of the *default conventional route* as shown in the following example:

.. code-block:: c#

   [Route("[controller]")]
   public class ProductsController : Controller
   {
      [Route("")]     // Matches 'Products'
      [Route("Index")] // Matches 'Products/Index'
      public IActionResult Index()
   }

Putting multiple route attributes on the controller means that each one will combine with each of the route attributes on the action methods.

.. code-block:: c#

   [Route("Store")]
   [Route("[controller]")]
   public class ProductsController : Controller
   {
      [HttpPost("Buy")]     // Matches 'Products/Buy' and 'Store/Buy'
      [HttpPost("Checkout")] // Matches 'Products/Checkout' and 'Store/Checkout'
      public IActionResult Buy()
   }

When multiple route attributes (that implement ``IActionConstraint``) are placed on an action, then each action constraint combines with the route template from the attribute that defined it.

.. code-block:: c#

   [Route("api/[controller]")]
   public class ProductsController : Controller
   {
      [HttpPut("Buy")]      // Matches PUT 'api/Products/Buy'
      [HttpPost("Checkout")] // Matches POST 'api/Products/Checkout'
      public IActionResult Buy()
   }

.. Tip:: While using multiple routes on actions can seem powerful, it's better to keep your application's URL space simple and well-defined. Use multiple routes on actions only where needed, for example to support existing clients.

.. _routing-cust-rt-attr-irt-ref-label:

Custom route attributes using :dn:iface:`~Microsoft.AspNetCore.Mvc.Routing.IRouteTemplateProvider`
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

All of the route attributes provided in the framework ( ``[Route(...)]``, ``[HttpGet(...)]`` , etc.) implement the :dn:iface:`~Microsoft.AspNetCore.Mvc.Routing.IRouteTemplateProvider`
interface. MVC looks for attributes on controller classes and action methods when the app starts and uses the ones that implement ``IRouteTemplateProvider`` to build the initial set of routes.

You can implement ``IRouteTemplateProvider`` to define your own route attributes. Each ``IRouteTemplateProvider`` allows you to define a single route with a custom route template, order, and name:

.. code-block:: c#

  public class MyApiControllerAttribute : Attribute, IRouteTemplateProvider
  {
     public string Template => "api/[controller]";

     public int? Order { get; set; }

     public string Name { get; set; }
  }

The attribute from the above example automatically sets the ``Template`` to ``"api/[controller]"`` when ``[MyApiController]`` is applied.

.. _routing-app-model-ref-label:

Using Application Model to customize attribute routes
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The *application model* is an object model created at startup with all of the metadata used by MVC to route and execute your actions. The *application model* includes all of the data gathered from route attributes (through ``IRouteTemplateProvider``). You can write *conventions* to modify the application model at startup time to customize how routing behaves. This section shows a simple example of customizing routing using application model.

.. literalinclude:: routing/sample/main/NamespaceRoutingConvention.cs
  :language: c#

.. _routing-mixed-ref-label:

Mixed Routing
--------------

MVC applications can mix the use of conventional routing and attribute routing. It's typical to use conventional routes for controllers serving HTML pages for browsers, and attribute routing for controllers serving REST APIs.

Actions are either conventionally routed or attribute routed. Placing a route on the controller or the action makes it attribute routed. Actions that define attribute routes cannot be reached through the conventional routes and vice-versa. **Any** route attribute on the controller makes all actions in the controller attribute routed.

.. Note:: What distinguishes the two types of routing systems is the process applied after a URL matches a route template. In conventional routing, the route values from the match are used to choose the action and controller from a lookup table of all conventional routed actions. In attribute routing, each template is already associated with an action, and no further lookup is needed.

.. _routing-url-gen-ref-label:

URL Generation
---------------

MVC applications can use routing's URL generation features to generate URL links to actions. Generating URLs eliminates hardcoding URLs, making your code more robust and maintainable. This section focuses on the URL generation features provided by MVC and will only cover basics of how URL generation works. See :doc:`Routing </fundamentals/routing>` for a detailed description of URL generation.

The :dn:iface:`~Microsoft.AspNetCore.Mvc.IUrlHelper` interface is the underlying piece of infrastructure between MVC and routing for URL generation. You'll find an instance of ``IUrlHelper`` available through the ``Url`` property in controllers, views, and view components.

In this example, the ``IUrlHelper`` interface is used through the ``Controller.Url`` property to generate a URL to another action.

.. literalinclude:: routing/sample/main/Controllers/UrlGenerationController.cs
  :language: none
  :start-after: snippet_1
  :end-before: #endregion

If the application is using the default conventional route, the value of the ``url`` variable will be the URL path string ``/UrlGeneration/Destination``. This URL path is created by routing by combining the route values from the current request (ambient values), with the values passed to ``Url.Action`` and substituting those values into the route template::

   ambient values: { controller = "UrlGeneration", action = "Source" }
   values passed to Url.Action: { controller = "UrlGeneration", action = "Destination" }
   route template: {controller}/{action}/{id?}

   result: /UrlGeneration/Destination

Each route parameter in the route template has its value substituted by matching names with the values and ambient values. A route parameter that does not have a value can use a default value if it has one, or be skipped if it is optional (as in the case of ``id`` in this example). URL generation will fail if any required route parameter doesn't have a corresponding value. If URL generation fails for a route, the next route is tried until all routes have been tried or a match is found.

The example of ``Url.Action`` above assumes conventional routing, but URL generation works similarly with attribute routing, though the concepts are different. With conventional routing, the route values are used to expand a template, and the route values for ``controller`` and ``action`` usually appear in that template - this works because the URLs matched by routing adhere to a *convention*. In attribute routing, the route values for ``controller`` and ``action`` are not allowed to appear in the template - they are instead used to look up which template to use.

This example uses attribute routing:

.. literalinclude:: routing/sample/main/StartupUseMvc.cs
  :language: c#
  :start-after: snippet_1
  :end-before: #endregion

.. literalinclude:: routing/sample/main/Controllers/UrlGenerationControllerAttr.cs
  :language: none
  :start-after: snippet_1
  :end-before: #endregion

MVC builds a lookup table of all attribute routed actions and will match the ``controller`` and ``action`` values to select the route template to use for URL generation. In the sample above,   ``custom/url/to/destination`` is generated.

Generating URLs by action name
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

``Url.Action`` (:dn:iface:`~Microsoft.AspNetCore.Mvc.IUrlHelper` . :dn:method:`~Microsoft.AspNetCore.Mvc.IUrlHelper.Action`) and all related overloads all are based on that idea that you want to specify what you're linking to by specifying a controller name and action name.

.. note:: When using ``Url.Action``, the current route values for ``controller`` and ``action`` are specified for you - the value of ``controller`` and ``action`` are part of both *ambient values* **and** *values*. The method ``Url.Action``, always uses the current values of ``action`` and ``controller`` and will generate a URL path that routes to the current action.

Routing attempts to use the values in ambient values to fill in information that you didn't provide when generating a URL. Using a route like ``{a}/{b}/{c}/{d}`` and ambient values ``{ a = Alice, b = Bob, c = Carol, d = David }``, routing has enough information to generate a URL without any additional values - since all route parameters have a value. If you added the value ``{ d = Donovan }``, the value ``{ d = David }`` would be ignored, and the generated URL path would be ``Alice/Bob/Carol/Donovan``.

.. warning:: URL paths are hierarchical. In the example above, if you added the value ``{ c = Cheryl }``, both of the values ``{ c = Carol, d = David }`` would be ignored. In this case we no longer have a value for ``d`` and URL generation will fail. You would need to specify the desired value of ``c`` and ``d``.  You might expect to hit this problem with the default route (``{controller}/{action}/{id?}``) - but you will rarely encounter this behavior in practice as ``Url.Action`` will always explicitly specify a ``controller`` and ``action`` value.

Longer overloads of ``Url.Action`` also take an additional *route values* object to provide values for route parameters other than ``controller`` and ``action``. You will most commonly see this used with ``id`` like ``Url.Action("Buy", "Products", new { id = 17 })``. By convention the *route values* object is usually an object of anonymous type, but it can also be an ``IDictionary<>`` or a *plain old .NET object*. Any additional route values that don't match route parameters are put in the query string.

.. literalinclude:: routing/sample/main/Controllers/TestController.cs
  :language: c#

.. tip:: To create an absolute URL, use an overload that accepts a ``protocol``: ``Url.Action("Buy", "Products", new { id = 17 }, protocol: Request.Scheme)``

.. _routing-gen-urls-route-ref-label:

Generating URLs by route
^^^^^^^^^^^^^^^^^^^^^^^^^^

The code above demonstrated generating a URL by passing in the controller and action name. ``IUrlHelper`` also provides the ``Url.RouteUrl`` family of methods. These methods are similar to ``Url.Action``, but they do not copy the current values of ``action`` and ``controller`` to the route values. The most common usage is to specify a route name to use a specific route to generate the URL, generally *without* specifying a controller or action name.

.. literalinclude:: routing/sample/main/Controllers/UrlGenerationControllerRouting.cs
  :language: none
  :start-after: snippet_1
  :end-before: #endregion

.. _routing-gen-urls-html-ref-label:

Generating URLs in HTML
^^^^^^^^^^^^^^^^^^^^^^^^^^^

:dn:iface:`~Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper` provides the :dn:cls:`~Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper` methods ``Html.BeginForm`` and ``Html.ActionLink`` to generate ``<form>`` and ``<a>`` elements respectively. These methods use the ``Url.Action`` method to generate a URL and they accept similar arguments. The ``Url.RouteUrl`` companions for :dn:cls:`~Microsoft.AspNetCore.Mvc.ViewFeatures.HtmlHelper` are ``Html.BeginRouteForm`` and ``Html.RouteLink`` which have similar functionality. See :doc:`/mvc/views/html-helpers` for more details.

TagHelpers generate URLs through the ``form`` TagHelper and the ``<a>`` TagHelper. Both of these use ``IUrlHelper`` for their implementation. See :doc:`/mvc/views/working-with-forms` for more information.

Inside views, the :dn:iface:`~Microsoft.AspNetCore.Mvc.IUrlHelper` is available through the ``Url`` property for any ad-hoc URL generation not covered by the above.

.. _routing-gen-urls-action-ref-label:

Generating URLS in Action Results
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The examples above have shown using ``IUrlHelper`` in a controller, while the most common usage in a controller is to generate a URL as part of an action result.

The ``ControllerBase`` and ``Controller`` base classes provide convenience methods for action results that reference another action. One typical usage is to redirect after accepting user input.

.. code-block:: c#

   public Task<IActionResult> Edit(int id, Customer customer)
   {
       if (ModelState.IsValid)
       {
           // Update DB with new details.
           return RedirectToAction("Index");
       }
   }

The action results factory methods follow a similar pattern to the methods on :dn:iface:`~Microsoft.AspNetCore.Mvc.IUrlHelper`.

.. _routing-dedicated-ref-label:

Special case for dedicated conventional routes
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Conventional routing can use a special kind of route definition called a *dedicated conventional route*. In the example below, the route named ``blog`` is a dedicated conventional route.

.. code-block:: c#

    app.UseMvc(routes =>
    {
        routes.MapRoute("blog", "blog/{*article}",
            defaults: new { controller = "Blog", action = "Article" });
        routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
    });

Using these route definitions, ``Url.Action("Index", "Home")`` will generate the URL path ``/`` with the ``default`` route, but why? You might guess the route values ``{ controller = Home, action = Index }`` would be enough to generate a URL using ``blog``, and the result would be ``/blog?action=Index&controller=Home``.

Dedicated conventional routes rely on a special behavior of default values that don't have a corresponding route parameter that prevents the route from being "too greedy" with URL generation. In this case the default values are ``{ controller = Blog, action = Article }``, and neither ``controller`` nor ``action`` appears as a route parameter. When routing performs URL generation, the values provided must match the default values. URL generation using ``blog`` will fail because the values ``{ controller = Home, action = Index }`` don't match ``{ controller = Blog, action = Article }``. Routing then falls back to try ``default``, which succeeds.

.. _routing-areas-ref-label:

Areas
---------

:doc:`/mvc/controllers/areas` are an MVC feature used to organize related functionality into a group as a separate routing-namespace (for controller actions) and folder structure (for views). Using areas allows an application to have multiple controllers with the same name - as long as they have different *areas*. Using areas creates a hierarchy for the purpose of routing by adding another route parameter, ``area`` to ``controller`` and ``action``. This section will discuss how routing interacts with areas - see :doc:`/mvc/controllers/areas` for details about how areas are used with views.

The following example configures MVC to use the default conventional route and an *area route* for an area named ``Blog``:

.. literalinclude:: routing/sample/AreasRouting/Startup.cs
  :language: c#
  :start-after: snippet1
  :end-before: #endregion
  :dedent: 12

When matching a URL path like ``/Manage/Users/AddUser``, the first route will produce the route values ``{ area = Blog, controller = Users, action = AddUser }``. The ``area`` route value is produced by a default value for ``area``, in fact the route created by ``MapAreaRoute`` is equivalent to the following:


.. literalinclude:: routing/sample/AreasRouting/Startup.cs
  :language: c#
  :start-after: snippet2
  :end-before: #endregion
  :dedent: 12

:dn:method:`~Microsoft.AspNetCore.Builder.MvcAreaRouteBuilderExtensions.MapAreaRoute` creates a route using both a default value and constraint for ``area`` using the provided area name, in this case ``Blog``. The default value ensures that the route always produces ``{ area = Blog, ... }``, the constraint requires the value ``{ area = Blog, ... }`` for URL generation.

.. tip:: Conventional routing is order-dependent. In general, routes with areas should be placed earlier in the route table as they are more specific than routes without an area.

Using the above example, the route values would match the following action:

.. literalinclude:: routing/sample/AreasRouting/Areas/Blog/Controllers/UsersController.cs
  :language: c#

The :dn:cls:`~Microsoft.AspNetCore.Mvc.AreaAttribute` is what denotes a controller as part of an area, we say that this controller is in the ``Blog`` area. Controllers without an ``[Area]`` attribute are not members of any area, and will **not** match when the ``area`` route value is provided by routing. In the following example, only the first controller listed can match the route values ``{ area = Blog, controller = Users, action = AddUser }``.

.. literalinclude:: routing/sample/AreasRouting/Areas/Blog/Controllers/UsersController.cs
  :language: c#

.. literalinclude:: routing/sample/AreasRouting/Areas/Zebra/Controllers/UsersController.cs
  :language: c#

.. literalinclude:: routing/sample/AreasRouting/Controllers/UsersController.cs
  :language: c#

.. note:: The namespace of each controller is shown here for completeness - otherwise the controllers would have a naming conflict and generate a compiler error. Class namespaces have no effect on MVC's routing.

The first two controllers are members of areas, and only match when their respective area name is provided by the ``area`` route value. The third controller is not a member of any area, and can only match when no value for ``area`` is provided by routing.

.. note:: In terms of matching *no value*, the absence of the ``area`` value is the same as if the value for ``area`` were null or the empty string.

When executing an action inside an area, the route value for ``area`` will be available as an *ambient value* for routing to use for URL generation. This means that by default areas act *sticky* for URL generation as demonstrated by the following sample.

.. literalinclude:: routing/sample/AreasRouting/Startup.cs
  :language: c#
  :start-after: snippet3
  :end-before: #endregion
  :dedent: 12

.. literalinclude:: routing/sample/AreasRouting/Areas/Duck/Controllers/UsersController.cs
  :language: c#

.. _iactionconstraint-ref-label:

Understanding IActionConstraint
---------------------------------

.. note:: This section is a deep-dive on framework internals and how MVC chooses an action to execute. A typical application won't need a custom ``IActionConstraint``

You have likely already used :dn:iface:`~Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint` even if you're not familiar with the interface. The ``[HttpGet]`` Attribute and similar ``[Http-VERB]`` attributes implement ``IActionConstraint`` in order to limit the execution of an action method.

.. code-block:: c#

   public class ProductsController : Controller
   {
       [HttpGet]
       public IActionResult Edit() { }

       public IActionResult Edit(...) { }
   }

Assuming the default conventional route, the URL path ``/Products/Edit`` would produce the values ``{ controller = Products, action = Edit }``, which would match **both** of the actions shown here. In ``IActionConstraint`` terminology we would say that both of these actions are considered candidates - as they both match the route data.

When the :dn:cls:`~Microsoft.AspNetCore.Mvc.HttpGetAttribute` executes, it will say that `Edit()` is a match for `GET` and is not a match for any other HTTP verb. The ``Edit(...)`` action doesn't have any constraints defined, and so will match any HTTP verb. So assuming a ``POST`` - only ``Edit(...)`` matches. But, for a ``GET`` both actions can still match - however, an action with an ``IActionConstraint`` is always considered *better* than an action without. So because ``Edit()`` has ``[HttpGet]`` it is considered more specific, and will be selected if both actions can match.

Conceptually, ``IActionConstraint`` is a form of *overloading*, but instead of overloading methods with the same name, it is overloading between actions that match the same URL. Attribute routing also uses ``IActionConstraint`` and can result in actions from different controllers both being considered candidates.

.. _iactionconstraint-impl-ref-label:

Implementing IActionConstraint
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

The simplest way to implement an :dn:iface:`~Microsoft.AspNetCore.Mvc.ActionConstraints.IActionConstraint` is to create a class derived from ``System.Attribute`` and place it on your actions and controllers. MVC will automatically discover any ``IActionConstraint`` that are applied as attributes. You can use the application model to apply constraints, and this is probably the most flexible approach as it allows you to metaprogram how they are applied.

In the following example a constraint chooses an action based on a *country code* from the route data. The `full sample on GitHub <https://github.com/aspnet/Entropy/blob/dev/samples/Mvc.ActionConstraintSample.Web/CountrySpecificAttribute.cs>`__.

.. code-block:: c#

   public class CountrySpecificAttribute : Attribute, IActionConstraint
   {
       private readonly string _countryCode;

       public CountrySpecificAttribute(string countryCode)
       {
           _countryCode = countryCode;
       }

       public int Order
       {
           get
           {
               return 0;
           }
       }

       public bool Accept(ActionConstraintContext context)
       {
           return string.Equals(
               context.RouteContext.RouteData.Values["country"].ToString(),
               _countryCode,
               StringComparison.OrdinalIgnoreCase);
       }
   }

You are responsible for implementing the ``Accept`` method and choosing an 'Order' for the constraint to execute. In this case, the ``Accept`` method returns ``true`` to denote the action is a match when the ``country`` route value matches. This is different from a ``RouteValueAttribute`` in that it allows fallback to a non-attributed action. The sample shows that if you define an ``en-US`` action then a country code like ``fr-FR`` will fall back to a more generic controller that does not have ``[CountrySpecific(...)]`` applied.

The ``Order`` property decides which *stage* the constraint is part of. Action constraints run in groups based on the ``Order``. For example, all of the framework provided HTTP method attributes use the same ``Order`` value so that they run in the same stage. You can have as many stages as you need to implement your desired policies.

.. tip:: To decide on a value for ``Order`` think about whether or not your constraint should be applied before HTTP methods. Lower numbers run first.