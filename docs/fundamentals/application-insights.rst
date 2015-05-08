Application Insights
====================
By :ref:`Steve Smith <appinsights-author>` | Originally Published: 8 May 2015 

Visual Studio Application Insights allows developers to insert a few lines of code into their application in order to find out how users are interacting with the app. It can also `detect and diagnose performance issues and exceptions <http://azure.microsoft.com/en-us/documentation/articles/app-insights-detect-triage-diagnose/>`_ in your applications. You can send telemetry data from web servers as well as clients/browers, as well as desktop applications and mobile devices.

In this article:
	- `Getting started`_
	- `Running the Application`_
	
`View or download sample on GitHub <https://github.com/aspnet/Docs/tree/master/docs/fundamentals/application-insights>`_.

Getting started
---------------

*Application Insights, like ASP.NET 5, is in preview.*

To get started with Application Insights, you will need a subscription to Microsoft Azure. If your team or organization already has a subscription, you can ask the owner to add you to it using your Microsoft account.

Sign in to the `Azure portal <http://portal.azure.com/>`_ with your account and create a new Application Insights resource. 

.. image:: diagnostics/_static/azure-create-appinsight.png

Choose ASP.NET as the application type. Note the *Instrumentation Key* (under Settings, Properties) associated with the Application Insights resource you've created (`see detailed instructions with more screenshots here <http://azure.microsoft.com/en-us/documentation/articles/app-insights-start-monitoring-app-health-usage/>`_). You will need the instrumentation key in a few moments when you configure your ASP.NET 5 application to use Application Insights.

Next, add Application Insights to your ASP.NET project. You can do so by right-clicking on the project in Solution Explorer and selecting ``Manage NuGet Packages``:

Next, update ``project.json`` to add a new reference to ``Microsoft.ApplicationInsights.AspNet``, as shown:

.. image:: diagnostics/_static/manage-nuget-packages.png

Then be sure you have checked ``Include prerelease`` and that your package source is ``nuget.org``. Search for "Application" and you should see ``Microsoft.ApplicationInsights.Web as one of the first choices. Click the ``Install`` button and accept the license agreement.

.. image:: diagnostics/_static/nuget-package-manager.png

This will download and install a number of packages and may take a few minutes. When completed, you should see a new entry in your ``project.json`` file's ``dependencies`` section:

.. code-block:: javascript

	"Microsoft.ApplicationInsights.Web": "0.16.1-build00418"

Next, create or edit a ``config.json`` file, adding the instrumentation key you noted above from your Application Insights resource in Windows Azure. Specify an "ApplicationInsights" section with a key named "InstrumentationKey". Set its value to the instrumentation key.

.. image:: diagnostics/_static/config-json.png

	
.. _appinsights-author:

.. include:: /_authors/steve-smith.txt
