Diagnostics
===========

By :ref:`Steve Smith <diagnostics-author>` | Originally Published: 5 May 2015 

ASP.NET 5 includes a number of new features that can assist with diagnosing problems. Configuring different handlers for application errors or to display additional information about the application can easily be achieved in the application's startup class.

In this article:
	- `Configuring an error handling page`_
	- `Using the error page during development`_
	- `The runtime info page`_
	- `The welcome page`_
	- `Using AppInsights`_
	
`Browse or download samples on GitHub <https://github.com/aspnet/Docs/tree/master/docs/fundamentals/diagnostics/sample>`_.

Configuring an error handling page
----------------------------------

In ASP.NET 5, you configure the pipeline for each request in the ``Startup`` class's ``Configure()`` method (learn more about `configuration <configuration>`_. In order to add a simple error handling page, all that's required is to add a dependency on Microsoft.AspNet.Diagnostics to the project (and a using statement to ``Startup.cs``), and then add one line to ``Configure()``:

.. literalinclude:: diagnostics/sample/src/DiagDemo/Startup.cs
	:language: csharp
	:linenos:
	:emphasize-lines: 2,18

The above code, which is built from the ASP.NET 5 Empty Application template, includes simple mechanism for creating an exception on line 22. If a request includes a non-empty querystring parameter for the variable ``throw``, an exception will be thrown. Comment out line 18 and trigger an exception, so you can see the default ASP.NET behavior (without an error page):

.. image:: diagnostics/_static/oops-500.png

Now, uncomment line 18 again, so you can see what the error page provides.

Using the error page during development
---------------------------------------

During development, when the application is compiled in Debug mode, the default error page will display some useful diagnostics information when an unhandled exception occurs within the web processing pipeline. The error page includes several tabs with information about the exception that was triggered and the request that was made. The first tab shows the stack trace:

.. image:: diagnostics/_static/errorpage-stack.png

The next tab shows the contents of the Querystring collection, if any:

.. image:: diagnostics/_static/errorpage-query.png



The runtime info page
---------------------

The welcome page
----------------

Using AppInsights
-----------------

Summary
-------

.. _diagnostics-author:

.. include:: /_authors/steve-smith.txt
