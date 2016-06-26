:version: 1.0.0-rc2

Routing
=======
By `Steve Smith`_

Routing middleware is used to map requests to route handlers. Routes are configured when the application starts up, and can extract values from the URL that will be passed as arguments to route handlers. Routing functionality is also responsible for generating links that correspond to routes in ASP.NET apps.

.. contents:: Sections
  :local:
  :depth: 1

`View or download sample code <https://github.com/aspnet/Docs/tree/master/aspnet/fundamentals/routing/sample>`__

Routing Middleware
------------------
The routing :doc:`middleware <middleware>` uses *routes* to map requests to an ``IRouter`` instance. The ``IRouter`` instance chooses whether or not to handle the request, and how. The request is considered handled if its ``RouteContext.Handler`` property is set to a non-null value. If no route handler is found for a request, then the middleware calls *next* (and the next middleware in the request pipeline is invoked).

To use routing, add it to the **dependencies** in *project.json*:

.. literalinclude:: routing/sample/RoutingSample/project.json
  :dedent: 2
  :language: javascript
  :lines: 11-20
  :emphasize-lines: 7
  
Add routing to ``ConfigureServices`` in *Startup.cs*:

.. literalinclude:: routing/sample/RoutingSample/Startup.cs
  :dedent: 8
  :language: c#
  :lines: 14-17
  :emphasize-lines: 3


Configuring Routing
-------------------

Routing is enabled in the ``Configure`` method in the ``Startup`` class. Create an instance of :dn:cls:`~Microsoft.AspNetCore.Routing.RouteBuilder`, passing a reference to ``IApplicationBuilder``. You can optionally provide a :dn:prop:`~Microsoft.AspNetCore.Routing.RouteBuilder.DefaultHandler` as well. Add additional routes using ``MapRoute`` and when finished call ``app.UseRouter``.

.. literalinclude:: routing/sample/RoutingSample/Startup.cs
  :dedent: 8
  :lines: 20-38
  :emphasize-lines: 6-9,11,19
  
Pass ``UseRouter`` the result of the ``RouteBuilder.Build`` method.

.. tip:: If you are only configuring a single route, you can simply call ``app.UseRouter`` and pass in the ``IRouter`` instance you wish to use, bypassing the need to use a ``RouteBuilder``.

The ``defaultHandler`` route handler is used as the default for the ``RouteBuilder``. Calls to ``MapRoute`` will use this handler by default. A second handler is configured within the ``HelloRouter`` instance added by the ``AddHelloRoute`` extension method. This extension methods adds a new ``Route`` to the ``RouteBuilder``, passing in an instance of ``IRouter``, a template string, and an ``IInlineConstraintResolver`` (which is responsible for enforcing any route constraints specified):

.. literalinclude:: routing/sample/RoutingSample/HelloExtensions.cs
  :language: c#
  :lines: 9-17
  :dedent: 8
  :emphasize-lines: 5

``HelloRouter`` is a custom ``IRouter`` implementation. ``AddHelloRoute`` adds an instance of this router to the ``RouteBuilder`` using a template string, "hello/{name:alpha}". This template will only match requests of the form "hello/{name}" where `name` is constrained to be alphabetical. Matching requests will be handled by ``HelloRouter`` (which implements the ``IRouter`` interface), which responds to requests with a simple greeting.

.. literalinclude:: routing/sample/RoutingSample/HelloRouter.cs
  :emphasize-lines: 8,20-23

``HelloRouter`` checks to see if ``RouteData`` includes a value for the key ``name``. If not, it immediately returns without handling the request. Likewise, it checks to see if the request begins with "/hello". Otherwise, the ``Handler`` property is set to a delegate that responds with a greeting. Setting the ``Handler`` property prevents additional routes from handling the request. The ``GetVirtualPath`` method is used for :ref:`link generation <link-generation>`.

.. note:: Remember, it's possible for a particular route **template** to match a given request, but the associated route **handler** can still reject it, allowing a different route to handle the request.)

This route was configured to use an :ref:`inline constraint <route-constraints>`, signified by the ``:alpha`` in the name route value. This constraint limits which requests this route will handle, in this case to alphabetical values for ``name``. Thus, a request for "/hello/steve" will be handled, but a request to "/hello/123" will not (instead, in this sample the request will not match any routes and will use the "app.Run" delegate).

Template Routes
---------------
The most common way to define routes is using ``TemplateRoute`` and route template strings. When a ``TemplateRoute`` matches, it calls its target ``IRouter`` handler. In a typical MVC app, you might use a default template route with a string like this one: 

.. image:: /fundamentals/routing/_static/default-mvc-routetemplate.png

This route template would be handled by the :dn:cls:`~Microsoft.AspNetCore.Mvc.Internal.MvcRouteHandler` ``IRouter`` instance. Tokens within curly braces (``{ }``) define `route value` parameters which will be bound if the route is matched. You can define more than one route value parameter in a route segment, but they must be separated by a literal value. For example ``{controller=Home}{action=Index}`` would not be a valid route, since there is no literal value between ``{controller}`` and ``{action}``. These route value parameters must have a name, and may have additional attributes specified.

You can use the ``*`` character as a prefix to a route value name to bind to the rest of the URI. For example, ``blog/{*slug}`` would match any URI that started with ``/blog/`` and had any value following it (which would be assigned to the ``slug`` route value).

Route value parameters may have *default values*, designated by specifying the default after the parameter name, separated by an ``=``. For example, ``controller=Home`` would define ``Home`` as the default value for ``controller``. The default value is used if no value is present in the URL for the parameter. In addition to default values, route parameters may be optional (specified by appending a ``?`` to the end of the parameter name, as in ``id?``). The difference between optional and "has default" is that a route parameter with a default value always produces a value; an optional parameter may not. Route parameters may also have constraints, which further restrict which routes the template will match.

The following table demonstrates some route template and their expected behavior.

.. list-table:: Route Template Values
  :header-rows: 1

  * - Route Template
    - Example Matching URL
    - Notes
  * - hello
    - /hello
    - Will only match the single path '/hello'
  * - {Page=Home}
    - /
    - Will match and set ``Page`` to ``Home``.
  * - {Page=Home}
    - /Contact
    - Will match and set ``Page`` to ``Contact``
  * - {controller}/{action}/{id?}
    - /Products/List
    - Will map to ``Products`` controller and ``List`` method; Since ``id`` was not supplied in the URL, it's ignored.
  * - {controller}/{action}/{id?}
    - /Products/Details/123
    - Will map to ``Products`` controller and ``Details`` method, with ``id`` set to ``123``.
  * - {controller=Home}/{action=Index}/{id?}
    - /
    - Will map to ``Home`` controller and ``Index`` method; ``id`` is ignored.

.. _route-constraints:

Route Constraints
^^^^^^^^^^^^^^^^^

Adding a colon ``:`` after the name allows additional inline constraints to be set on a route value parameter. Constraints with types always use the invariant culture - they assume the URL is non-localizable. Route constraints limit which URLs will match a route - URLs that do not match the constraint are ignored by the route.

.. list-table:: Inline Route Constraints
  :header-rows: 1

  * - constraint
    - Example
    - Example Match
    - Notes
  * - ``int``
    - {id:int}
    - 123
    - Matches any integer
  * - ``bool``
    - {active:bool}
    - true
    - Matches ``true`` or ``false``
  * - ``datetime``
    - {dob:datetime}
    - 2016-01-01
    - Matches a valid ``DateTime`` value (in the invariant culture - see `options <http://msdn.microsoft.com/en-us/library/aszyst2c(v=vs.110).aspx>`_)
  * - ``decimal``
    - {price:decimal}
    - 49.99
    - Matches a valid ``decimal`` value
  * - ``double``
    - {price:double}
    - 4.234
    - Matches a valid ``double`` value
  * - ``float``
    - {price:float}
    - 3.14
    - Matches a valid ``float`` value
  * - ``guid``
    - {id:guid}
    - 7342570B-44E7-471C-A267-947DD2A35BF9
    - Matches a valid ``Guid`` value
  * - ``long``
    - {ticks:long}
    - 123456789
    - Matches a valid ``long`` value
  * - ``minlength(value)``
    - {username:minlength(5)}
    - steve
    - String must be at least 5 characters long.
  * - ``maxlength(value)``
    - {filename:maxlength(8)}
    - somefile
    - String must be no more than 8 characters long.
  * - ``length(min,max)``
    - {filename:length(4,16)}
    - Somefile.txt
    - String must be at least 8 and no more than 16 characters long.
  * - ``min(value)``
    - {age:min(18)}
    - 19
    - Value must be at least 18.
  * - ``max(value)``
    - {age:max(120)}
    - 91
    - Value must be no more than 120.
  * - ``range(min,max)``
    - {age:range(18,120)}
    - 91
    - Value must be at least 18 but no more than 120.
  * - ``alpha``
    - {name:alpha}
    - Steve
    - String must consist of alphabetical characters.
  * - ``regex(expression)``
    - {ssn:regex(\d{3}-\d{2}-\d{4})}
    - 123-45-6789
    - String must match the provided regular expression.
  * - ``required``
    - {name:required}
    - Steve
    - Used to enforce that a non-parameter value is present during during URL generation.

Inline constraints must match one of the above options, or an exception will be thrown.

.. tip:: To constrain a parameter to a known set of possible values, you can use a regex: ``{action:regex(list|get|create)}``. This would only match the ``action`` route value to ``list``, ``get``, or ``create``. If passed into the constraints dictionary, the string "list|get|create" would be equivalent. Constraints that are passed in the constraints dictionary (not inline within a template) that don't match one of the known constraints are also treated as regular expressions.

.. warning:: Avoid using constraints for **validation**, because doing so means that invalid input will result in a 404 (Not Found) instead of a 400 with an appropriate error message. Route constraints should be used to **disambiguate** between routes, not validate the inputs for a particular route.

Constraints can be *chained*. You can specify that a route value is of a certain type and also must fall within a specified range, for example: ``{age:int:range(1,120)}``.  Numeric constraints like ``min``, ``max``, and ``range`` will automatically convert the value to ``long`` before being applied unless another numeric type is specified.

Route templates must be unambiguous, or they will be ignored. For example, ``{id?}/{foo}`` is ambiguous, because it's not clear which route value would be bound to a request for "/bar". Similarly, ``{*everything}/{plusone}`` would be ambiguous, because the first route parameter would match everything from that part of the request on, so it's not clear what the ``plusone`` parameter would match.

.. note:: There is a special case route for filenames, such that you can define a route value like ``files/{filename}.{ext?}``. When both ``filename`` and ``ext`` exist, both values will be populated. However, if only ``filename`` exists in the URL, the trailing period ``.`` is also optional. Thus, these would both match: ``/files/foo.txt`` and ``/files/foo``.

.. tip:: Enable :doc:`logging` to see how the built in routing implementations, such as ``TemplateRoute``, match requests.

Route Builder Extensions
------------------------
Several `extension methods on RouteBuilder <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNetCore/Builder/MapRouteRouteBuilderExtensions/index.html>`_ are available for convenience. The most common of these is ``MapRoute``, which allows the specification of a route given a name and template, and optionally default values, constraints, and/or :ref:`data tokens <data-tokens>`. When using these extensions, you must have specified the ``DefaultHandler`` and ``ServiceProvider`` properties of the ``RouteBuilder`` instance to which you're adding the route. These ``MapRoute`` extensions add new ``TemplateRoute`` instances to the ``RouteBuilder`` that each target the ``IRouter`` configured as the ``DefaultHandler``.

.. note:: ``MapRoute`` doesn't take an ``IRouter`` parameter - it only adds routes that will be handled by the ``DefaultHandler``. Since the default handler is an ``IRouter``, it may decide not to handle the request. For example, MVC is typically configured as a default handler that only handles requests that match an available controller action.

.. _data-tokens:

Data Tokens
^^^^^^^^^^^
Data tokens represent data that is carried along if the route matches. They're implemented as a property bag for developer-specified data. You can use data tokens to store data you want to associate with a route, when you don't want the semantics of defaults. Data tokens have no impact on the **behavior** of the route, while defaults do. Data tokens can also be any arbitrary types, while defaults really need to be things that can be converted to/from strings.

.. _link-generation:

Link Generation
---------------

Routing is also used to generate URLs based on route definitions. This is used by helpers to generate links to known actions on MVC :doc:`controllers </mvc/controllers/index>`, but can also be used independent of MVC. Given a set of route values, and optionally a route name, you can produce a ``VirtualPathContext`` object. Using the ``VirtualPathContext`` object along with a ``RouteCollection``, you can generate a ``VirtualPath``. ``IRouter`` implementations participate in link generation through the ``GetVirtualPath`` method.

.. tip:: Learn more about `UrlHelper <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNetCore/Mvc/Routing/UrlHelper/index.html?highlight=urlhelper>`_ and :doc:`Routing to Controller Actions </mvc/controllers/routing>`.

The example below shows how to generate a link to a route given a dictionary of route values and a ``RouteCollection``.

.. literalinclude:: routing/sample/RoutingSample/Startup.cs
  :language: c#
  :lines: 39-59
  :dedent: 12
  :emphasize-lines: 2-3,7,13-14,19-20

The ``VirtualPath`` generated at the end of the sample above is ``/package/create/123``.

The second parameter to the ``VirtualPathContext`` constructor is a collection of `ambient values`. Ambient values provide convenience by limiting the number of values a developer must specify within a certain request context. The current route values of the current request are considered ambient values for link generation. For example, in an MVC application if you are in the About action of the HomeController, you don't need to specify the controller route value to link to the Index action (the ambient value of Home will be used). 

Ambient values that don't match a parameter are ignored, and ambient values are also ignored when an explicitly-provided value overrides it, going from left to right in the URL.

Values that are explicitly provided but which don't match anything are added to the query string.

.. list-table:: Generating Links
  :header-rows: 1

  * - Matched Route
    - Ambient Values
    - Explicit Values
    - Result
  * - ``{controller}/{action}/{id?}``
    - controller="Home"
    - action="About"
    - ``/Home/About``
  * - ``{controller}/{action}/{id?}``
    - controller="Home"
    - controller="Order",action="About"
    - ``/Order/About``
  * - ``{controller}/{action}/{id?}``
    - controller="Home",color="Red"
    - action="About"
    - ``/Home/About``
  * - ``{controller}/{action}/{id?}``
    - controller="Home"
    - action="About",color="Red"
    - ``/Home/About?color=Red``

If a route has a default value that doesn't match a parameter and that value is explicitly provided, it must match the default value. For example:

.. code-block:: c#
  
  routes.MapRoute("blog_route", "blog/{*slug}", 
    defaults: new { controller = "Blog", action = "ReadPost" });

Link generation would only generate a link for this route when the matching values for controller and action are provided.

Recommendations
---------------

Routing is a powerful feature that is built into the default ASP.NET MVC project template such that most apps will be able to leverage it without having to customize its behavior. This is by design; customizing routing behavior is an advanced development approach. Keep in mind the following recommendations with regard to routing: 

  - Most apps shouldn't need custom routes. The default route will work in most cases.
  - Attribute routes should be used for all APIs.
  - Attribute routes are recommended for when you need complete control over your app's URLs.
  - Conventional routing is recommended for when **all** of your controllers/actions fit a uniform URL convention.
  - Don't use custom routes unless you understand them well and are sure you need them.
  - Routes can be tricky to test and debug.
  - Routes should not be used as a means of securing your controllers or their action methods.
  - Avoid building or changing route collections at runtime.
