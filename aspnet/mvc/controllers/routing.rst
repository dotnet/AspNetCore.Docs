Routing to Controller Actions
=============================

By `Rachel Appel`_

In this article:

.. contents:: Sections
  :local:
  :depth: 1

Relationship to middleware
--------------------------

In the early days of the web you didn’t think about routing, as most web sites or applications simply referenced folders and files on a disk. If you had a URL for ``http://contoso.com/movies/GoneWithTheWind.htm``, then there was a folder called ``movies`` with a file called ``GoneWithTheWind.htm`` on the disk. With modern web frameworks like MVC you do not have to structure our content or application exactly how the world will see it. You can present it however you choose, and organize your software in the way that makes sense. `Routing <https://docs.asp.net/en/latest/fundamentals/routing.html>`_ is what you use to connect our code to the URL and features our application exposes. 

Routing is part of ASP.NET Core middleware. Middleware is a component that is assembled into an application pipeline to handle requests and responses. It's the middleware that processes the request until it gets to routing, which then hands over the request to MVC. MVC then selects an action method based on data that comes from routing. After that point it's up to the developer to add code to the action method to retrieve and modify data, or call services. 

Startup code and relationship to MVC route handler
--------------------------------------------------

To configure routing, add the following code to the ``Configure`` method in the ``Startup.cs`` file. The code maps a route named ``default`` to a controller named ``Home`` and action method named ``Index``. You configure this by indicating which controllers, action methods, and parameters you want recognized as a route in the ``template`` argument of the ``MapRoute`` method, as shown below: 

.. code-block:: c# 

  app.UseMvc(routes =>
  {
    routes.MapRoute(
      name: "default",
      template: "{controller=Home}/{action=Index}/{id?}");
  });
  
The route template defines the route as well as default values, in this example, ``Home`` for the controller, ``Index`` for the action method, and optionally ``id`` as a URL parameter. Routes defined in the ``Startup.cs`` file are conventional routes. 

Conventional routing
--------------------

Routing first matches the URL to a route template, then selects a controller and action to route the request. You may define routes and route constraints on both controllers and actions. In conventional routing, you define a route that generates the action and controller tokens. The value of those tokens are used to select an action and controller by name. For example, the URL ending in ``/home/index/`` matches the route template for ``{controller}/{action}``. Conventional routing must be configured in the ``Startup`` class, as shown in the previous code sample. 

For most forms-over-data web applications that use standard controllers, conventional routes work nicely. Attribute routing is the recommended type of routing for use in APIs.

Attribute routing
-----------------

[Route],[Http*]
^^^^^^^^^^^^^^^

Rather having to rely on naming and conventions to figre out where to route the request, attribute routing enables you to use an attribute to route requests directly to the desired destination. You may apply attributes to either controllers or actions. Attribute routing is more direct because routes must match what is defined in the attribute in order to be processed. When an action method is decorated with the ``[Route]`` attribute, it can no longer be accessed through the convention-based routes, as the attribute takes precedence. 

.. code-block:: c#

  [Route("category/{movie}.rss", Order = 0, Name = "MovieCategoryFeed")]

A common scenario for using attribute routing in an API controller is having the same route behave differently depending upon which HTTP verb is used. For example, you might want a page that displays a movie by its id using the route ``/movies/1337``, but also on that page be able to purchase the movie, and send the results back to the server. To restrict the HTTP verb that is accepted, apply the ``[HttpGet]`` attribute to the ``GetMovie`` action:

.. code-block:: c#

  [HttpGet("{id}", Name = "GetMovie")]
  public IActionResult GetMovie([FromRoute] int id)

The order in which routes are processed is important, but you can control how it works. First, routing inspects the ``RouteOrder`` property of the ``[Route]`` attribute. 

Routes on controller vs actions
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Routes map URLs to actions in controllers. When at the action level, constraints may be applied to the actions to further restrict activity. 

Inheritance
^^^^^^^^^^^

The ``IRouteConstraint`` interface exposes a ``Match`` method that you can use to create your own route constraints via inheritance, as the code below demonstrates:

.. code-block:: c#

  public class RouteConstraint : IRouteConstraint
  {
    public bool Match(HttpContext httpContext, 
        IRouter route, string routeKey, 
        IDictionary<string, object> values, 
        RouteDirection routeDirection)
        {
          // code to build constraint
        }
  }

Notice that the ``Match`` method contains parameters that you can use to inspect the route and HTTP request.
  
Token replacement in route templates
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Since maintainability is important, you can use token replacements in route templates. Tokens are substitutions for actual route values at runtime, and you may define them during startup for conventional routes, or in attributes for attribute routes. You may use regular expressions to create route tokens. Consider the following route attribute:

.. code-block:: c#

  [Route("category/{movie}.rss", Order = 0, Name = "MovieCategoryFeed")]
  public IActionResult MovieRSS(string name)

The above creates a route that directs to the ``MovieRSS`` method, and looks something like the following:

.. code-block:: c#

  /category/GoneWithTheWind.rss 

You may create custom route templates if you can't find any other built-in solution. Generally, it is because you need to dynamically compute a route template. To do so, subclass any route attribute, or implement the ``IApplicationModelConvention`` interface. Keep the code in the custom attribute simple as a limited extensibility point.   

Using Application Model to customize attribute routes
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

Implement the ``Apply`` method of the ``IApplicationModelConvention`` interface to create an attribute route. For more information on the MVC application model, see the documentation on `ApplicationModel <https://docs.asp.net/en/latest/mvc/controllers/application-model.html>`_.

Action constraints
------------------

MVC provides a few ways to apply finer control over how it processes routes. For example, you might want to restrict URLs to a particular HTTP verb. Other times you might want to dynamically prepend or append strings to routes, such as "api" for routes that lead to an API action. Or perhaps you're working on a blog engine and want the publish date and SEO information in the URLs. Constraints are great for when you need to modify the default behavior of actions.
    
HTTP method constraints
^^^^^^^^^^^^^^^^^^^^^^^

MVC allows you to restrict routes so they only accept specific HTTP verbs. Below is a list of supported HTTP verb constraints: 

- ``[HttpDelete]``
- ``[HttpGet]``
- ``[HttpHead]``
- ``[HttpPatch]``
- ``[HttpPost]``
- ``[HttpPut]``

If you want to accept only ``HTTP GET`` requests that pass an integer to the ``GetMovie`` action, apply the ``[HttpGet]`` constraint to the ``GetMovie``, as shown here:

.. code-block:: c#

  [HttpGet("{id}", Name = "GetMovie")]
  public IActionResult GetMovie([FromRoute] int id)
  
The code also constrains the route so it accepts integers only. This means that the route ``/GetMovie/1337`` will work, but ``/GetMovie/GoneWithTheWind`` will not.  

Custom Constraints
^^^^^^^^^^^^^^^^^^
  
Constraints are configured by passing them as a parameter to the ``MapRoute`` method at startup, as shown in a previous sample. You can create a custom action constraint by implementing the ``IActionConstraint`` interface. It's an extensibility point to verify if an action can run for a given request. This enabes you to create a nice experience from the URL point of view in that you can keep your URLs short and simple.