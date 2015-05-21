Application Insights
====================
By :ref:`Steve Smith <appinsights-author>` | Originally Published: 8 May 2015 

`Application Insights <http://azure.microsoft.com/services/application-insights/>`_ provides development teams with a 360&deg; view across their live application's performance, availability, and usage. It can also `detect and diagnose issues and exceptions <http://azure.microsoft.com/documentation/articles/app-insights-detect-triage-diagnose/>`_ in these applications. Telemetry data may be collected from web servers and web clients, as well as desktop  and mobile applications.

In this article:
	- `Getting started`_
	- `Viewing activity`_
	
`View or download sample on GitHub <https://github.com/aspnet/Docs/tree/master/docs/fundamentals/application-insights>`_.

Getting started
---------------

*Application Insights, like ASP.NET 5, is in preview.*

To get started with Application Insights, you will need a subscription to Microsoft Azure. If your team or organization already has a subscription, you can ask the owner to add you to it using your Microsoft account.

Sign in to the `Azure portal <http://portal.azure.com/>`_ with your account and create a new Application Insights resource. 

.. image:: application-insights/_static/azure-create-appinsight.png

Choose ASP.NET as the application type. Note the *Instrumentation Key* (under Settings, Properties) associated with the Application Insights resource you've created (`see detailed instructions with more screenshots here <http://azure.microsoft.com/documentation/articles/app-insights-start-monitoring-app-health-usage/>`_). You will need the instrumentation key in a few moments when you configure your ASP.NET 5 application to use Application Insights.

Next, add Application Insights to your ASP.NET project. You can do so by right-clicking on the project in Solution Explorer and selecting ``Manage NuGet Packages``:

Next, update ``project.json`` to add a new reference to ``Microsoft.ApplicationInsights.AspNet``, as shown:

.. image:: application-insights/_static/manage-nuget-packages.png

Then be sure you have checked ``Include prerelease`` and that your package source is ``nuget.org``. Search for "ApplicationInsights.AspNet" and you should see ``Microsoft.ApplicationInsights.AspNet`` as one of the first choices. Click the ``Install`` button and accept the license agreement.

.. image:: application-insights/_static/nuget-package-manager.png

This will download and install a number of packages and may take a few minutes. When completed, you should see a new entry in your ``project.json`` file's ``dependencies`` section:

.. code-block:: javascript

	"Microsoft.ApplicationInsights.AspNet": "0.32.0-beta4"
	
.. note:: The actual package version may differ from the one shown.

Next, edit (or create) the ``config.json`` file, adding the instrumentation key you noted above from your Application Insights resource in Windows Azure. Specify an "ApplicationInsights" section with a key named "InstrumentationKey". Set its value to the instrumentation key.

.. literalinclude:: application-insights/sample/src/AppInsightsDemo/config.json
	:linenos:
	:emphasize-lines: 2-3
	
Next, in ``Startup.cs`` you need to configure Application Insights in a few places. In the constructor, where you configure ``Configuration``, add a block to configure Application Insights for development:

.. code-block:: c#

	if (env.IsEnvironment("Development"))
	{
		configuration.AddApplicationInsightsSettings(developerMode: true);
	}

Add the ``Microsoft.ApplicationInsights.AspNet`` namespace to your using list, and then add `` services.AddApplicationInsightsTelemetry(Configuration);`` to ``ConfigureServices()``.

Then, in the ``Configure()`` method add middleware to allow Application Insights to track exceptions and log information about individual requests. Note that the request tracking middleware should be as the first middleware in the pipeline, while the exception middleware should follow the configuration of error pages or other error handling middleware.

An edited ``Startup.cs`` is shown below, highlighting the necessary Application Insights code (`view full Startup.cs <https://github.com/aspnet/Docs/tree/master/docs/fundamentals/application-insights/sample/src/AppInsightsDemo/Startup.cs>`_):

.. literalinclude:: application-insights/sample/src/AppInsightsDemo/Startup.cs
	:linenos:
	:language: c#
	:caption: Startup.cs
	:lines: 16-31,33-37,39-40,44-45,79-80,82-108,134-135
	:emphasize-lines: 15,24-25,32-33,52-54
	
.. note:: Setting AppInsights in developerMode (``configuration.AddApplicationInsightsSettings(developerMode: true)``) will expedite your telemetry through the pipeline so that you can see results immediately (`learn more <http://azure.microsoft.com/documentation/articles/app-insights-api-custom-events-metrics/#debug>`_).

The last file that needs to be updated in order to finish setting up your ASP.NET 5 application to use Application Insights is ``_Layout.cshtml``. Add the following to the very top of the file:

.. code-block:: c#

	@inject Microsoft.ApplicationInsights.Extensibility.TelemetryConfiguration TelemetryConfiguration 

Then, add one line of code at the end of the ``<head>`` section:

.. code-block:: html

		@Html.ApplicationInsightsJavaScript(TelemetryConfiguration) 
	</head>

Viewing activity
----------------

You can view the activity from your site once it's been configured and you've made some requests to it by navigating to the Azure portal. There, you will find the Application Insights resource you configured previously, and you will be able to view charts showing performance and activity data:

.. image:: application-insights/_static/view-activity.png

In addition to tracking activity and performance data on every page, you can also track specific events. For instance, if you want to know any time a user completes a certain transaction, you can create and track such events individually. To do so, you should inject the TelemetryClient into the controller in question, and call its ``TrackEvent`` method. In the included sample, we've added event tracking for user registration and successful and failed login attempts. You can see the required code in the excerpt from AccountController.cs shown below:

.. literalinclude:: application-insights/sample/src/AppInsightsDemo/Controllers/AccountController.cs
	:linenos:
	:emphasize-lines: 9,16,20,24,55,68,107
	:lines: 1-115,451-
	:caption: AccountController.cs

With this in place, testing the application's registration and login feature results in the following activity available for analysis:

.. image:: application-insights/_static/view-custom-events.png

.. note:: Application Insights is still in development. To view the latest release notes and configuration instructions, please `refer to the project wiki <https://github.com/Microsoft/ApplicationInsights-aspnet5/wiki/Getting-Started>`_.

Summary
-------

Application Insights allows you to easily add application activity and performance tracking to any ASP.NET 5 app. With Application Insights in place, you can view live reports showing information about the users of your application and how it is performing, including both client and server performance information. In addition, you can track custom events, allowing to you capture user activities unique to your application.

Additional Resources
--------------------

- `Application Insights API for custom events and metrics <http://azure.microsoft.com/documentation/articles/app-insights-api-custom-events-metrics/>`_
- `Application Insights for ASP.NET 5 <http://blogs.msdn.com/b/webdev/archive/2015/05/19/application-insights-for-asp-net-5-you-re-in-control.aspx>`_

.. _appinsights-author:

.. include:: /_authors/steve-smith.txt
