Diagnostics
===========

`Steve Smith`_

ASP.NET Core includes a number of new features that can assist with diagnosing problems. Configuring different handlers for application errors or to display additional information about the application can easily be achieved in the application's startup class.

.. contents:: Sections::
  :local:
  :depth: 1

`View or download sample code <https://github.com/aspnet/Docs/tree/master/aspnet/fundamentals/diagnostics/sample>`__

.. _configure-error-page:

Configuring an error handling page
----------------------------------

In ASP.NET Core, you configure the pipeline for each request in the ``Startup`` class's ``Configure()`` method (learn more about :doc:`configuration`). You can add a simple error page, meant only for use during development, very easily. All that's required is to add a dependency on ``Microsoft.AspNet.Diagnostics`` to the project (and a ``using`` statement to *Startup.cs*), and then add one line to ``Configure()`` in *Startup.cs*:

.. _diag-startup:

.. literalinclude:: diagnostics/sample/src/DiagDemo/Startup.cs
  :language: csharp
  :linenos:
  :emphasize-lines: 2,21

The above code, which is built from the ASP.NET Core Empty template, includes a simple mechanism for creating an exception on line 36. If a request includes a non-empty querystring parameter for the variable ``throw`` (e.g. a path of ``/?throw=true``), an exception will be thrown. Line 21 makes the call to ``UseDeveloperExceptionPage()`` to enable the error page middleware. 

Notice that the call to ``UseDeveloperExceptionPage()`` is wrapped inside an ``if`` condition that checks the current ``EnvironmentName``. This is a good practice, since you typically do not want to share detailed diagnostic information about your application publicly once it is in production. This check uses the ``ASPNET_ENV`` environment variable. If you are using Visual Studio, you can customize the environment variables used when the application runs in the web application project's properties, under the Debug tab, as shown here:

.. image:: diagnostics/_static/project-properties-env-vars.png

Setting the ``ASPNET_ENV`` variable to anything other than Development (e.g. Production) will cause the application not to call ``UseDeveloperExceptionPage()`` and only a HTTP 500 response code with no message details will be sent back to the browser, unless an exception handler is configured such as ``UseExceptionHandler()``.

We will cover the features provided by the error page in the next section (ensure ``ASPNET_ENV`` is reset to Development if you are following along).

Using the error page during development
---------------------------------------

The default error page will display some useful diagnostics information when an unhandled exception occurs within the web processing pipeline. The error page includes several tabs with information about the exception that was triggered and the request that was made. The first tab shows the stack trace:

.. image:: diagnostics/_static/errorpage-stack.png

The next tab shows the contents of the Querystring collection, if any:

.. image:: diagnostics/_static/errorpage-query.png

In this case, you can see the value of the ``throw`` parameter that was passed to this request. This request didn't have any cookies, but if it did, they would appear on the Cookies tab. You can see the headers that were passed, here:

.. image:: diagnostics/_static/errorpage-headers.png

HTTP 500 errors on Azure
-------------------------

If your app throws an exception before the ``Configure`` method in *Startup.cs* completes, the error page won't be configured. The app deployed to Azure (or another production server) will return an HTTP 500 error with no message details. ASP.NET Core uses a new configuration model that is not based on *web.config*, and when you create a new web app with Visual Studio, the project no longer contains a *web.config* file. See :doc:`/conceptual-overview/understanding-aspnetcore-apps`.

The publish wizard in Visual Studio creates a *web.config* file if you don't have one. If you have a *web.config* file in the *wwwroot* folder, deploy inserts the markup into the the *web.config* file it generates. 

To get detailed error messages on Azure, add the following *web.config* file to the *wwwroot* folder.

.. note:: Security warning: Enabling detailed error message can leak critical information from your app. You should never enable detailed error messages on a production app.

.. code-block:: html

  <configuration>
     <system.web>
      <customErrors mode="Off"/>
     </system.web>
  </configuration>

The runtime info page
---------------------

In addition to :ref:`configuring and displaying an error page <configure-error-page>`, you can also add a runtime info page by simply calling an extension method in *Startup.cs*. The following line, is used to enable this feature:

.. code-block:: c#

  app.UseRuntimeInfoPage(); // default path is /runtimeinfo

Once this is added to your ASP.NET application, you can browse to the specified path (``/runtimeinfo``) to see information about the runtime that is being used and the packages that are included in the application, as shown below:

.. image:: diagnostics/_static/runtimeinfo-page.png

The path for this page can be optionally specified in the call to ``UseRuntimeInfoPage()``. It accepts a `RuntimeInfoPageOptions <https://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/AspNet/Diagnostics/RuntimeInfoPageOptions/index.html>`_ instance as a parameter, which has a ``Path`` property. For example, to specify a path of ``/info`` you would call ``UseRuntimeInfoPage()`` as shown here:

.. code-block:: c#

  app.UseRuntimeInfoPage("/info");

As with ``UseDeveloperExceptionPage()``, it is a good idea to limit public access to diagnostic information about your application. As such, in our sample we are only implementing ``UseRuntimeInfoPage()`` when the EnvironmentName is set to Development.

.. note:: Remember that the ``Configure()`` method in *Startup.cs* is defining the pipeline that will be used by all requests to your application, which means the order is important. If for example you move the call to ``UseRuntimeInfoPage()`` after the call to ``app.Run()`` in the examples shown here, it will never be called because ``app.Run()`` will handle the request before it reaches the call to ``UseRuntimeInfoPage``.

The welcome page
----------------

Another extension method you may find useful, especially when you're first spinning up a new ASP.NET Core application, is the ``UseWelcomePage()`` method. Add it to ``Configure()`` like so:

.. code-block:: c#

    app.UseWelcomePage();

Once included, this will handle all requests (by default) with a cool hello world page that uses embedded images and fonts to display a rich view, as shown here:

.. image:: diagnostics/_static/welcome-page.png

You can optionally configure the welcome page to only respond to certain paths. The code shown below will configure the page to only be displayed for the ``/welcome`` path (other paths will be ignored, and will fall through to other handlers):

.. code-block:: c#

  app.UseWelcomePage("/welcome");

Configured in this manner, the :ref:`startup.cs <diag-startup>` shown above will respond to requests as follows:

.. list-table:: Requests
  :header-rows: 1

  * - Path
    - Result
  * - /runtimeinfo
    - ``UseRuntimeInfoPage`` will handle and display runtime info page
  * - /welcome
    - ``UseWelcomePage`` will handle and display welcome page
  * - paths without ``?throw=``
    - ``app.Run()`` will respond with "Hello World!"
  * - paths with ``?throw=``
    - ``app.Run()`` throws an exception; ``UseErrorPage`` handles, displays an error page

Summary
-------

In ASP.NET Core, you can easily add error pages, view diagnostic information, or respond to requests with a simple welcome page by adding just one line to your app's *Startup.cs* class.

Additional Resources
--------------------

- `Application Insights <https://azure.microsoft.com/en-us/documentation/articles/app-insights-asp-net-five/>`_
