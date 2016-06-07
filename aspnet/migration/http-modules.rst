Migrating HTTP Modules to Middleware
====================================

By `Matt Perdeck`_

This article shows how to migrate existing ASP.NET `HTTP modules and handlers <https://msdn.microsoft.com/en-us/library/bb398986.aspx>`_ to ASP.NET Core :ref:`middleware <fundamentals-middleware>`.

.. contents:: Sections:
  :local:
  :depth: 1

Handlers and modules revisited
------------------------------
Before proceeding to ASP.NET Core middleware, let's first recap how HTTP modules and handlers work: 

.. image:: http-modules/_static/moduleshandlers.png

Handlers are:
  * Classes that implement `IHttpHandler <https://msdn.microsoft.com/en-us/library/system.web.ihttphandler(v=vs.100).aspx>`_
  * Used to handle requests with a given file name or extension, such as *.report*
  * `Configured <https://msdn.microsoft.com/en-us/library/46c5ddfy(v=vs.100).aspx>`__ in *Web.config*

Modules are:
  * Classes that implement `IHttpModule <https://msdn.microsoft.com/en-us/library/system.web.ihttpmodule(v=vs.100).aspx>`_
  * Invoked for every request
  * Able to short-circuit (stop further processing of a request)
  * Able to add to the HTTP response, or create their own
  * `Configured <https://msdn.microsoft.com/en-us/library/ms227673(v=vs.100).aspx>`__ in *Web.config*

**The order in which modules process incoming requests is determined by:**

  1. The `application life cycle <https://msdn.microsoft.com/en-us/library/ms227673(v=vs.100).aspx>`_, which is a series events fired by ASP.NET: `BeginRequest <https://msdn.microsoft.com/en-us/library/system.web.httpapplication.beginrequest(v=vs.100).aspx>`_, `AuthenticateRequest <https://msdn.microsoft.com/en-us/library/system.web.httpapplication.authenticaterequest(v=vs.100).aspx>`_, etc. Each module can create a handler for one or more events.

  2. For the same event, the order in which they are configured in *Web.config*.

In addition to modules, you can add handlers for the life cycle events to your *Global.asax.cs* file. These handlers run after the handlers in the configured modules.

From handlers and modules to middleware
---------------------------------------
Middleware are simpler than HTTP modules and handlers:
    * Modules, handlers, *Global.asax.cs*, *Web.config* (except for IIS configuration) and the application life cycle are gone
    * The roles of both modules and handlers have been taken over by middleware
    * Middleware are configured using code rather than in *Web.config*
    * :ref:`Pipeline branching <middleware-run-map-use>` lets you send requests to specific middleware, based on not only the URL but also on request headers, query strings, etc.

Middleware are very similar to modules:
  * Invoked in principle for every request
  * Able to short-circuit a request, by :ref:`not passing the request to the next middleware <http-modules-shortcircuiting-middleware>`
  * Able to create their own HTTP response

Middleware and modules are processed in a different order:
    * Order of middleware is based on the order in which they are inserted into the request pipeline, while order of modules is mainly based on `application life cycle <https://msdn.microsoft.com/en-us/library/ms227673(v=vs.100).aspx>`_ events
    * Order of middleware for responses is the reverse from that for requests, while order of modules is the same for requests and responses
    * See `Creating a middleware pipeline with IApplicationBuilder <../fundamentals/middleware.html#creating-a-middleware-pipeline-with-iapplicationbuilder>`_

.. image:: http-modules/_static/middleware.png

Note how in the image above, the authentication middleware short-circuited the request.

Migrating module code to middleware
------------------------------------
An existing HTTP module will look similar to this:

.. literalinclude:: http-modules/sample/Asp.Net4/Asp.Net4/Modules/MyModule.cs
  :language: c#
  :linenos:
  :emphasize-lines: 6, 8, 24, 31

As shown in the :doc:`../fundamentals/middleware` page,
an ASP.NET Core middleware is simply a class that exposes an ``Invoke`` method taking an ``HttpContext`` and returning a ``Task``. Your new middleware will look like this:

.. _http-modules-usemiddleware:

.. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/MyMiddleware.cs
  :language: c#
  :linenos:
  :emphasize-lines: 9, 13, 20, 24, 28, 30, 32

The above middleware template was taken from the section on 
:ref:`writing middleware <middleware-writing-middleware>`.

The `MyMiddlewareExtensions` helper class makes it easier to configure your middleware in your ``Startup`` class. 
The ``UseMyMiddleware`` method adds your middleware class to the request pipeline. Services required by the middleware get injected in the middleware's constructor.

.. _http-modules-shortcircuiting-middleware:

Your module might terminate a request, for example if the user is not authorized:

.. literalinclude:: http-modules/sample/Asp.Net4/Asp.Net4/Modules/MyTerminatingModule.cs
  :language: c#
  :linenos:
  :emphasize-lines: 9-13
  :lines: 18-31
  :dedent: 8

A middleware handles this by simply not calling ``Invoke`` on the next middleware in the pipeline. Keep in mind that this does not 
fully terminate the request, because previous middlewares will still be invoked when the response makes its way back through the pipeline.

.. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/MyTerminatingMiddleware.cs
  :language: c#
  :linenos:
  :emphasize-lines: 7, 8
  :lines: 16-26
  :dedent: 8

When you migrate your module's functionality to your new middleware, you may find that your code doesn't compile because the ``HttpContext`` class 
has significantly changed in ASP.NET Core. `Later on <#migrating-to-the-new-httpcontext>`_, you'll see how to migrate to the new ASP.NET Core HttpContext.

Migrating module insertion into the request pipeline
-----------------------------------------------------
HTTP modules are typically added to the request pipeline using *Web.config*:

.. literalinclude:: http-modules/sample/Asp.Net4/Asp.Net4/Web.config
  :language: xml
  :linenos:
  :emphasize-lines: 6
  :lines: 1-3, 29-30, 33, 40, 48, 105

Convert this by `adding your new middleware <../fundamentals/middleware.html#creating-a-middleware-pipeline-with-iapplicationbuilder>`_
to the request pipeline in your ``Startup`` class:

.. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Startup.cs
  :language: c#
  :linenos:
  :lines: 1-2, 12-15, 46-48, 54-58, 105, 109, 110
  :emphasize-lines: 12

The exact spot in the pipeline where you insert your new middleware depends on the event 
that it handled as a module (``BeginRequest``, ``EndRequest``, etc.) and its order in your list of modules in *Web.config*.

As previously stated, there is no more application life cycle in ASP.NET Core and the order in which responses are processed by middleware differs from the order used by modules. This could make your ordering decision more  challenging.

If ordering becomes a problem, you could split your module into multiple middleware that can be ordered independently.

Migrating handler code to middleware
-------------------------------------
An HTTP handler looks something like this:

.. literalinclude:: http-modules/sample/Asp.Net4/Asp.Net4/HttpHandlers/ReportHandler.cs
  :language: c#
  :linenos:
  :emphasize-lines: 5, 7, 13-16
  :lines: 1-19, 31-32

In your ASP.NET Core project, you would translate this to a middleware similar to this:

.. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/ReportHandlerMiddleware.cs
  :language: c#
  :linenos:
  :emphasize-lines: 7,9,13, 20-23, 29, 31, 33
  :lines: 1-26, 38-47

This middleware is very similar to the middleware corresponding to modules. The only real difference is that here there is no
call to ``_next.Invoke(context)``. That makes sense, because the handler is at the end of the request pipeline, so there will be no next middleware to invoke.

Migrating handler insertion into the request pipeline
------------------------------------------------------
Configuring an HTTP handler is done in *Web.config* and looks something like this:

.. literalinclude:: http-modules/sample/Asp.Net4/Asp.Net4/Web.config
  :language: xml
  :linenos:
  :emphasize-lines: 7,8
  :lines: 1-3, 29, 42-46, 48, 105

You could convert this by adding your new handler middleware to the request pipeline in your ``Startup`` class, similar to middleware converted from modules. The problem with that approach; it would send all requests to your new handler middleware. However, you only want requests with a given extension to reach your middleware. That would give you the same functionality you had with your HTTP handler.

One solution is to branch the pipeline for requests with a given extension, using the ``MapWhen`` extension method.
You do this in the same ``Configure`` method where you add the other middleware:

.. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Startup.cs
  :language: c#
  :linenos:
  :lines: 1-2, 12-15, 46-48, 54-55, 82-87, 105, 109, 110
  :emphasize-lines: 12-17

``MapWhen`` takes these parameters:

1. A lambda that takes the ``HttpContext`` and returns ``true`` if the request should go down the branch.
   This means you can branch requests not just based on their extension, but also on request headers, query string parameters, etc.

2. A lambda that takes an ``IApplicationBuilder`` and adds all the middleware for the branch.
   This means you can add additional middleware to the branch in front of your handler middleware.

Middleware added to the pipeline before the branch will be invoked on all requests; the branch will have no impact on them.

Loading middleware options using the options pattern
----------------------------------------------------

Some modules and handlers have configuration options that are stored in *Web.config*.
However, in ASP.NET Core a new configuration model is used in place of *Web.config*.

The new :doc:`configuration system </fundamentals/configuration>` gives you these options to solve this:

* Directly inject the options into the middleware, as shown in the :ref:`next section <loading-middleware-options-through-direct-injection>`.
* Use the :ref:`options pattern <options-config-objects>`:

1. Create a class to hold your middleware options, for example:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/MyMiddlewareWithParams.cs
        :language: c#
        :linenos:
        :lines: 8-12
        :dedent: 4

2. Store the option values

    The new configuration system allows you to essentially store option values anywhere you want. However, most sites use
    *appsettings.json*, so we'll take that approach:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/appsettings.json
        :language: json
        :linenos:
        :lines: 1, 6-10

    *MyMiddlewareOptionsSection* here is simply a section name. It doesn't have to be the same as the name of your options class.

3. Associate the option values with the options class

    The options pattern uses ASP.NET Core's dependency injection framework to associate the options type (such as ``MyMiddlewareOptions``)
    with an ``MyMiddlewareOptions`` object that has the actual options.

    Update your ``Startup`` class:

        a. If you're using *appsettings.json*, add it to the configuration builder in the ``Startup`` constructor:

        .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Startup.cs
            :language: c#
            :linenos:
            :lines: 14-23, 106, 109
            :emphasize-lines: 7
            :dedent: 4

        b. Configure the options service:

        .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Startup.cs
            :language: c#
            :linenos:
            :lines: 14-15, 28-29, 31-33, 43, 109
            :emphasize-lines: 5
            :dedent: 4

        c. Associate your options with your options class:

        .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Startup.cs
            :language: c#
            :linenos:
            :lines: 14-15, 28-29, 31-32, 36-39, 43, 109
            :emphasize-lines: 7,8
            :dedent: 4

4. Inject the options into your middleware constructor. This is similar to injecting options into a controller.

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/MyMiddlewareWithParams.cs
        :language: c#
        :linenos:
        :lines: 6-7, 24-47
        :emphasize-lines: 7,10,13,19,24

    The `UseMiddleware <#http-modules-usemiddleware>`_ extension method that adds your middleware to the
    ``IApplicationBuilder`` takes care of dependency injection.

    This is not limited to ``IOptions`` objects. Any other object that your middleware requires can be injected this way.

.. _loading-middleware-options-through-direct-injection:

Loading middleware options through direct injection
---------------------------------------------------
The options pattern has the advantage that it creates loose coupling between options values and their consumers.
Once you've associated an options class with the actual options values, any other class can get access to the options
through the dependency injection framework. There is no need to pass around options values.

This breaks down though if you want to use the same middleware twice, with different options. For example an authorization middleware
used in different branches allowing different roles. You can't associate two different options objects with the one options class.

The solution is to get the options objects with the actual options values in your ``Startup`` class and pass those directly to each instance of your middleware.

1. Add a second key to *appsettings.json*

    To add a second set of options to the 
    *appsettings.json* file, simply use a new key to uniquely identify it:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/appsettings.json
        :language: json
        :linenos:
        :emphasize-lines: 2-5

2. Retrieve options values. The ``Get`` method on the ``Configuration`` property lets you retrieve options values:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Startup.cs
        :language: c#
        :linenos:
        :lines: 1-2, 12-15, 46-48, 54-55, 62-66, 67, 70, 71, 105, 109, 110
        :emphasize-lines: 12-16
 
3. Pass options values to middleware. The ``Use...`` extension method (which adds your middleware to the pipeline) is a logical place to pass in the option values:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Startup.cs
        :language: c#
        :linenos:
        :lines: 1-2, 12-15, 46-48, 54-55, 62-72, 105, 109, 110
        :emphasize-lines: 18-22

4. Enable middleware to take an options parameter. Provide an overload of the ``Use...`` extension method (that takes the options parameter and passes it to ``UseMiddleware``). When ``UseMiddleware`` is called with parameters, it passes the parameters to your middleware constructor when it instantiates the middleware object.

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/MyMiddlewareWithParams.cs
        :language: c#
        :linenos:
        :lines: 1-7, 48-64
        :emphasize-lines: 17-22

    Note how this wraps the options object in an ``OptionsWrapper`` object. This implements ``IOptions``, as expected by 
    the middleware constructor:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/MyMiddlewareWithParams.cs
        :language: c#
        :linenos:
        :lines: 14-23


Migrating to the new HttpContext
--------------------------------
You saw earlier that the ``Invoke`` method in your middleware takes a parameter of type ``HttpContext``:

.. code-block:: c#

    public async Task Invoke(HttpContext context)

``HttpContext`` has significantly changed in ASP.NET Core. This section shows how to translate the most commonly used properties of 
`System.Web.HttpContext <https://msdn.microsoft.com/en-us/library/system.web.httpcontext(v=vs.110).aspx>`__ to the 
new `Microsoft.AspNetCore.Http.HttpContext <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNetCore/Http/HttpContext/index.html>`__.


HttpContext
^^^^^^^^^^^
**HttpContext.Items** translates to:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs
        :start-after: //>01b
        :end-before: //<01b
        :language: c#
        :dedent: 12

**Unique request ID (no System.Web.HttpContext counterpart)**

Gives you a unique id for each request. Very useful to include in your logs.

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs
        :start-after: //>01
        :end-before: //<01
        :language: c#
        :dedent: 12

HttpContext.Request
^^^^^^^^^^^^^^^^^^^
**HttpContext.Request.HttpMethod** translates to:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs
        :start-after: //>02
        :end-before: //<02
        :language: c#
        :dedent: 12

**HttpContext.Request.QueryString** translates to:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs
        :start-after: //>03
        :end-before: //<03
        :language: c#
        :dedent: 12

**HttpContext.Request.Url and HttpContext.Request.RawUrl** translate to:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs
        :start-after: //>04
        :end-before: //<04
        :language: c#
        :dedent: 12

**HttpContext.Request.IsSecureConnection** translates to:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs
        :start-after: //>05
        :end-before: //<05
        :language: c#
        :dedent: 12

**HttpContext.Request.UserHostAddress** translates to:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs
        :start-after: //>06
        :end-before: //<06
        :language: c#
        :dedent: 12

**HttpContext.Request.Cookies** translates to:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs
        :start-after: //>07
        :end-before: //<07
        :language: c#
        :dedent: 12

**HttpContext.Request.Headers** translates to:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs
        :start-after: //>08
        :end-before: //<08
        :language: c#
        :dedent: 12

**HttpContext.Request.UserAgent** translates to:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs
        :start-after: //>12
        :end-before: //<12
        :language: c#
        :dedent: 12

**HttpContext.Request.UrlReferrer** translates to:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs
        :start-after: //>13
        :end-before: //<13
        :language: c#
        :dedent: 12

**HttpContext.Request.ContentType** translates to:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs
        :start-after: //>14
        :end-before: //<14
        :language: c#
        :dedent: 12

**HttpContext.Request.Form** translates to:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs
        :start-after: //>15
        :end-before: //<15
        :language: c#
        :dedent: 12

.. caution::
    Read form values only if the content sub type is *x-www-form-urlencoded* or *form-data*.

**HttpContext.Request.InputStream** translates to:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs
        :start-after: //>16
        :end-before: //<16
        :language: c#
        :dedent: 12

.. caution::
    Use this code only in a handler type middleware, at the end of a pipeline. 

    You can read the raw body as shown above only once per request. Middleware trying to read the body after the first read will read an empty body.

    This does not apply to reading a form as shown earlier, because that is done from a buffer.

**HttpContext.Request.RequestContext.RouteData** 

RouteData is not available in middleware in RC1.


HttpContext.Response
^^^^^^^^^^^^^^^^^^^^

**HttpContext.Response.Status and HttpContext.Response.StatusDescription** translate to:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs
        :start-after: //>30
        :end-before: //<30
        :language: c#
        :dedent: 12

**HttpContext.Response.ContentEncoding and HttpContext.Response.ContentType** translate to:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs
        :start-after: //>31
        :end-before: //<31
        :language: c#
        :dedent: 12

**HttpContext.Response.ContentType** on its own also translates to:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs
        :start-after: //>32
        :end-before: //<32
        :language: c#
        :dedent: 12

**HttpContext.Response.Output** translates to:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs
        :start-after: //>33
        :end-before: //<33
        :language: c#
        :dedent: 12

**HttpContext.Response.TransmitFile**

Serving up a file is discussed `here <../fundamentals/request-features.html#middleware-and-request-features>`_.

**HttpContext.Response.Headers**

Sending response headers is complicated by the fact that if you set them after anything has been written to the
response body, they will not be sent.

The solution is to set a callback method that will be called right before writing to the response starts. This is best done at the
start of the ``Invoke`` method in your middleware. It is this callback method that sets your response headers.

The following code sets a callback method called ``SetHeaders``:

    .. code-block:: c#

        public async Task Invoke(HttpContext httpContext)
        {
            // ...
            httpContext.Response.OnStarting(SetHeaders, state: httpContext);

The ``SetHeaders`` callback method would look like this:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs
        :start-after: //>41
        :end-before: //<41
        :language: c#
        :dedent: 8


**HttpContext.Response.Cookies**

Cookies travel to the browser in a *Set-Cookie* response header. As a result, sending cookies requires the same callback as used for sending response headers:

    .. code-block:: c#

            public async Task Invoke(HttpContext httpContext)
            {
                // ...
                httpContext.Response.OnStarting(SetCookies, state: httpContext);
                httpContext.Response.OnStarting(SetHeaders, state: httpContext);

The ``SetCookies`` callback method would look like the following:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs
        :start-after: //>42
        :end-before: //<42
        :language: c#
        :dedent: 8

Additional Resources
--------------------

* `HTTP Handlers and HTTP Modules Overview <https://msdn.microsoft.com/en-us/library/bb398986.aspx>`_
* :doc:`/fundamentals/configuration`
* :doc:`/fundamentals/startup`
* :doc:`/fundamentals/middleware`

