Migrating HTTP Modules to Middleware
====================================

By `Matt Perdeck`_

This article shows how to migrate existing ASP.NET `HTTP modules and handlers <https://msdn.microsoft.com/en-us/library/bb398986.aspx>`_ to ASP.NET 5 :ref:`middleware <fundamentals-middleware>`.

.. contents:: In this article:
  :local:
  :depth: 1

Handlers and modules revisited
------------------------------
Before proceeding to ASP.NET 5 middleware, let's first recap how HTTP modules and handlers work: 

.. image:: http-modules/_static/moduleshandlers.png

Handlers are:
	* Classes that implement `IHttpHandler <https://msdn.microsoft.com/en-us/library/system.web.ihttphandler(v=vs.100).aspx>`_
	* Used to handle requests with a given file name or extension, such as *.report*
	* `Configured <https://msdn.microsoft.com/en-us/library/46c5ddfy(v=vs.100).aspx>`__ in the *web.config*

Modules are:
	* Classes that implement `IHttpModule <https://msdn.microsoft.com/en-us/library/system.web.ihttpmodule(v=vs.100).aspx>`_
	* Invoked for every request
	* Able to stop further processing of a request
	* Able to add to the HTTP response, or create their own
	* `Configured <https://msdn.microsoft.com/en-us/library/ms227673(v=vs.100).aspx>`__ in the web.config

**The order in which modules process incoming requests is determined by:**

	1.	The `application life cycle <https://msdn.microsoft.com/en-us/library/ms227673(v=vs.100).aspx>`_, 
		which is a series events fired by ASP.NET
		- 
		`BeginRequest <https://msdn.microsoft.com/en-us/library/system.web.httpapplication.beginrequest(v=vs.100).aspx>`_,
		`AuthenticateRequest <https://msdn.microsoft.com/en-us/library/system.web.httpapplication.authenticaterequest(v=vs.100).aspx>`_, etc.
		Each module can create a handler for one or more events.

	2. When handling the same event, the order in which they are configured in the web.config.

In addition to modules, you can add handlers for the life cycle events to your *Global.asax.cs* file. These handlers run after the handlers in the configured modules.

From handlers and modules to middleware
---------------------------------------
Middleware is simpler than HTTP modules and handlers:
    * Modules, handlers, Global.asax.cs, web.config (except for IIS configuration) and the application life cycle are gone
    * The roles of both modules and handlers have been taken over by middleware
    * Middleware is configured using code instead of in the web.config
    * `Pipeline branching <../fundamentals/middleware.html#run-map-and-use>`_ lets you send requests to specific middleware, based on not only the URL but also on request headers, etc.

Middleware is very similar to modules:
	* Invoked in principle for every request
	* Able to stop further processing of a request
	* Able to add to the HTTP response, or create their own

Middleware and modules are processed in a different order:
	* While the request is going up the pipeline, middleware is processed in the order in which it is inserted into the request pipeline, similar to modules
	* But while the response is going back to the browser, middleware is processed in the reverse order

.. image:: http-modules/_static/middleware.png

Migrating module code to middleware
------------------------------------
An existing HTTP module will look similar to this:

.. literalinclude:: http-modules/sample/Asp.Net4/Asp.Net4/Modules/MyModule.cs
	:language: c#
	:linenos:
	:emphasize-lines: 6, 8, 24, 31

As shown in the :ref:`introduction to middleware <fundamentals-middleware>`,
an ASP.NET 5 middleware is simply a class that exposes an ``Invoke`` method taking an ``HttpContext`` and returning a ``Task``. Your new middleware will look like this:

.. _http-modules-usemiddleware:

.. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/MyMiddleware.cs
	:language: c#
	:linenos:
	:emphasize-lines: 9, 13, 20, 24, 28, 30, 32

The middleware template used here is the same as that shown in the section on 
`writing middleware <../fundamentals/middleware.html#writing-middleware>`_.

The `MyMiddlewareExtensions` helper class makes it easier to configure your middleware in your ``Startup`` class. 
The ``UseMyMiddleware`` method adds your middleware class to the request pipeline. Services required by the middleware get injected in the middleware's constructor.

Maybe your module sometimes terminates the request, for example if the user is not authorized:

.. literalinclude:: http-modules/sample/Asp.Net4/Asp.Net4/Modules/MyTerminatingModule.cs
	:language: c#
	:linenos:
	:emphasize-lines: 9-13
	:lines: 18-31
	:dedent: 8

A middleware handles this by simply not calling ``Invoke`` on the next middleware in the pipeline. Keep in mind that this does not 
fully terminate the request, because previous middlewares will still be invoked when the response makes it way back through the pipeline
to the browser.

.. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/MyTerminatingMiddleware.cs
	:language: c#
	:linenos:
	:emphasize-lines: 7, 8
	:lines: 16-26
	:dedent: 8

When you migrate your module's functionality to your new middleware, you may find that your code doesn't compile because the ``HttpContext`` class 
has changed greatly in ASP.NET 5. `Later on <#migrating-to-the-new-httpcontext>`_, you'll see how to migrate to the new ASP.NET 5 HttpContext.

Migrating module insertion into the request pipeline
-----------------------------------------------------
HTTP modules are typically added to the request pipeline using web.config:

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
that it handled as a module (``BeginRequest``, ``EndRequest``, etc.) and its order in your list of modules in your web.config.

However, as you saw there is no more application life cycle in ASP.NET 5
and the order in which responses are processed by middleware differs from the order used by modules.
This could make your ordering decision more challenging.

If ordering becomes a problem, you could split your module into multiple middleware that can then be ordered separately.

Migrating handler code to middleware
-------------------------------------
An HTTP handler looks something like this:

.. literalinclude:: http-modules/sample/Asp.Net4/Asp.Net4/HttpHandlers/ReportHandler.cs
	:language: c#
	:linenos:
	:emphasize-lines: 5, 7, 13-16
	:lines: 1-19, 31-32

In your ASP.NET 5 project, you would translate this to a middleware similar to this:

.. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/ReportHandlerMiddleware.cs
	:language: c#
	:linenos:
	:emphasize-lines: 7,9,13, 20-23, 29, 31, 33
	:lines: 1-26, 38-47

This middleware is very similar to the middleware corresponding to modules. The only real difference is that here there is no
call to ``_next.Invoke(context)``. That makes sense, because the handler is at the end of the request pipeline, so there will be no next middleware to invoke.

Migrating handler insertion into the request pipeline
------------------------------------------------------
Configuring an HTTP handler is done in web.config and looks something like this:

.. literalinclude:: http-modules/sample/Asp.Net4/Asp.Net4/Web.config
	:language: xml
	:linenos:
	:emphasize-lines: 7,8
	:lines: 1-3, 29, 42-46, 48, 105

You could convert this by adding your new handler middleware to the request pipeline in your ``Startup`` class, similar to 
middleware converted from modules.

Problem is that this would send all requests to your new handler middleware. However, you only want requests with a given
extension to reach your middleware. That would give you the same situation you had with your HTTP handler.

A solution is to branch the pipeline for requests with a given extension, using the ``MapWhen`` extension method.
This happens in the same ``Configure`` method where you add the other middleware:

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

The middleware that was added to the pipeline before the branch will be invoked for both requests going down the branch
and for requests not going down the branch.

Loading middleware options using the options pattern
----------------------------------------------------

Some modules and handlers have configuration options, which would be stored in the web.config.
However, in ASP.NET 5 a new configuration model is used in place of web.config.

The new ASP.NET 5 :ref:`configuration system <fundamentals-configuration>` gives you these options to solve this:

* Use the `options pattern <../fundamentals/configuration.html#options-config-objects>`_, as used with MVC. This section shows how.
* Directly inject the options into the middleware, as shown in the `next section <#loading-middleware-options-through-direct-injection>`_.

1. Create a class to hold your middleware options
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

For example:

.. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/MyMiddlewareWithParams.cs
	:language: c#
	:linenos:
	:lines: 8-12
	:dedent: 4

2. Store the option values
^^^^^^^^^^^^^^^^^^^^^^^^^^
The new configuration system allows you to essentially store option values anywhere you want. However, most sites will use
*appsettings.json*, so lets use that here too:

.. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/appsettings.json
	:language: json
	:linenos:
	:lines: 1, 6-10

*MyMiddlewareOptionsSection* here is simply a section name. It doesn't have to be the same as the name of your options class.

3. Associate the option values with the options class
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
The options pattern uses ASP.NET 5's dependency injection framework to associate the options type (such as ``MyMiddlewareOptions``)
with an ``MyMiddlewareOptions`` object that has the actual options.

To make this work, update your ``Startup`` class:

	a. If you're using *appsettings.json*, make sure it is added to the configuration builder in the ``Startup`` constructor:

	.. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Startup.cs
		:language: c#
		:linenos:
		:lines: 14-23, 106, 109
		:emphasize-lines: 7
		:dedent: 4

	b. Make sure that the options service is configured:

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

4. Inject the options into your middleware constructor
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
Finally inject the options into your middleware's constructor. This is similar to injecting options into a controller.

.. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/MyMiddlewareWithParams.cs
	:language: c#
	:linenos:
	:lines: 6-7, 24-47
	:emphasize-lines: 7,10,13,19,24

This works, because the `UseMiddleware <#http-modules-usemiddleware>`_ extension method that adds your middleware to the
``IApplicationBuilder`` takes care of dependency injection.

This is not limited to ``IOptions`` objects. Any other object that your middleware requires can be injected this way.

Loading middleware options through direct injection
---------------------------------------------------
The options pattern has the advantage that it creates loose coupling between options values and their consumers.
Once you've associated an options class with the actual options values, any other class can get access to the options
through the dependency injection framework. So there is no need to pass around options values.

This breaks down though if you want to use the same middleware twice, with different options. For example an authorization middleware
used in different branches allowing different roles. You can't associate two different options objects with the one options class.

The solution is to get the options objects with the actual options values in your ``Startup`` class and pass those directly to each instance of your middleware.

1. Add a second key to appsettings.json
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
To add a second set of options to the 
*appsettings.json* file, simply use a new key to uniquely identify it:

.. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/appsettings.json
	:language: json
	:linenos:
	:emphasize-lines: 2-5

2. Retrieve options values
^^^^^^^^^^^^^^^^^^^^^^^^^^
In the ``Configure`` method in your ``Startup`` class, the ``Get`` method on the ``Configuration`` property lets you retrieve options values, like so:

.. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Startup.cs
	:language: c#
	:linenos:
	:lines: 1-2, 12-15, 46-48, 54-55, 62-66, 67, 70, 71, 105, 109, 110
	:emphasize-lines: 12-16
 
3. Pass options values to middleware
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
The ``Use...`` extension method with which you add your middleware to the pipeline would be the logical place
to pass in the option values:

.. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Startup.cs
	:language: c#
	:linenos:
	:lines: 1-2, 12-15, 46-48, 54-55, 62-72, 105, 109, 110
	:emphasize-lines: 18-22

4. Enable middleware to take options parameter
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
To make this work, you'll need an overload of your ``Use...`` extension method that takes the options parameter
and passes it to ``UseMiddleware``. When you call  
``UseMiddleware`` with parameters, it passes those to your middleware constructor when it instantiates the middleware object.

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

``HttpContext`` has significantly changed in ASP.NET 5. This section shows how to translate the most commonly used properties of 
`System.Web.HttpContext <https://msdn.microsoft.com/en-us/library/system.web.httpcontext(v=vs.110).aspx>`__ to the 
new `Microsoft.AspNet.Http.HttpContext <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNet/Http/HttpContext/index.html>`__.


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
    Only read form values if the content sub type is *x-www-form-urlencoded* or *form-data*.

**HttpContext.Request.InputStream** translates to:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs
        :start-after: //>16
        :end-before: //<16
        :language: c#
        :dedent: 12

.. caution::
    Only use this code in a handler type middleware, at the end of a pipeline. 

    You can read the raw body as shown here only once per request. If later on another middleware tries to read the raw body, it will read nothing.

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

Serving up a file is discussed `here <../fundamentals/request-features.html#middleware-and-request-features>`_.

**HttpContext.Response.Headers**

Sending response headers is complicated by the fact that if you set them after anything has been written to the
response body, they will not be sent.

The solution is to set a callback method that will be called right before writing to the response starts. This is best done at the
start of the ``Invoke`` method in your middleware. It is this callback method that sets your response headers.

This code sets a callback method called ``SetHeaders``:

    .. code-block:: c#

        public async Task Invoke(HttpContext httpContext)
        {
            // ...
            httpContext.Response.OnStarting(SetHeaders, state: httpContext);

Your ``SetHeaders`` callback method would look like this:

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

Your ``SetCookies`` callback method would look like this:

    .. literalinclude:: http-modules/sample/Asp.Net5/src/Asp.Net5/Middleware/HttpContextDemoMiddleware.cs
        :start-after: //>42
        :end-before: //<42
        :language: c#
        :dedent: 8

Additional Resources
--------------------

    * `ASP.NET 4 Modules and HTTP Handlers <https://msdn.microsoft.com/en-us/library/bb398986.aspx>`_
    * `ASP.NET 5 Configuration <../fundamentals/configuration.html>`_
    * `ASP.NET 5 Startup <../fundamentals/startup.html>`_
    * `ASP.NET 5 Middleware <../fundamentals/middleware.html>`_
    * `Sources of HttpRequest, HttpResponse, etc. <https://github.com/aspnet/HttpAbstractions>`_

