Working with Multiple Environments
==================================

By :ref:`Steve Smith <environments-author>` | Originally Published: 6 May 2015 

ASP.NET 5 introduces improved support for controlling application behavior across multiple environments, such as development, staging, and production. Environment variables are used to indicate which environment the application is running in, allowing the app to be configured appropriately.

In this article:
	- `Development, Staging, Production`_
	- `Startup conventions`_
	- `Environment variables`_

`Browse or download samples on GitHub <https://github.com/aspnet/Docs/tree/master/docs/fundamentals/environments/sample>`_.

Development, Staging, Production
--------------------------------

ASP.NET 5 references a particular `environment variable <https://github.com/aspnet/Home/wiki/Environment-Variables>`_, ``ASPNET_ENV``, to describe the environment the application is currently running in. This variable can be set to any value you like, but three values are used by convention: ``Development``, ``Staging``, and ``Production``. You will find these values used in the samples and templates provided with ASP.NET 5. Since ASP.NET 5 is open source, you can easily view all usages of these three environment names by `searching the source code on GitHub <https://github.com/search?utf8=%E2%9C%93&q=staging+development+production+user%3Aaspnet&type=Code&ref=searchresults>`_.

The current environment setting can be detected programmatically from within ASP.NET 5. In addition, ASP.NET MVC 6 introduces an `Environment Tag Helper <http://docs.asp.net/en/latest/mvc/views/tag-helpers/index.html>`_ that allows MVC Views to include certain sections based on the current application environment.

.. note:: Like all environment variables, these values are case-insensitive. Whether you set the variable to ``Development`` or ``development`` or ``DEVELOPMENT`` the results will be the same.

Development
^^^^^^^^^^^

This should be the default environment used when developing an application. When using Visual Studio 2015, this setting is specified by default in the project's properties for IIS Express, as shown here:

.. image:: environments/_static/project-properties-debug.png

You can manually add this value to other profiles, such as ``web`` (defined by default as a command in ``project.json``). Once you modify the default settings created with the project, your changes are persisted in ``launchSettings.json`` in the ``Properties`` folder. After adding the ``ASPNET_ENV`` variable to the ``web`` profile with a value of ``Staging``, the ``launchSettings.js`` file in our sample project is shown below:

.. literalinclude:: environments/sample/src/Environments/Properties/launchSettings.json
	:language: javascript
	:caption: launchSettings.json``
	:emphasize-lines: 7,13

.. note:: Changes made to project profiles or to ``launchSettings.json`` directly will not take effect until the web server being used is restarted.

Staging
^^^^^^^

By convention, a ``Staging`` environment is a pre-production environment used for final testing before deployment to production. Ideally, its physical characteristics should mirror that of production, so that any issues that may arise in production occur first in the staging environment, where they can be addressed without impact to users.

Production
^^^^^^^^^^

The ``Production`` environment is the environment in which the application runs when it is live and being used by end users. This environment should be configured to maximize security, performance, and application robustness. Some common settings that a production environment might have that would differ from development include:

- Turn on caching
- Ensure all client-side resources are bundled, minified, and potentially served from a CDN
- Turn off diagnostic ErrorPages
- Turn on friendly error pages
- Enable production logging and monitoring (e.g. AppInsights)

This is by no means meant to be a complete list. It's best to avoid scattering environment checks in many parts of your application. Instead, the recommended approach is to perform such checks within the application's ``Startup`` class(es) wherever possible

Startup conventions
-------------------

ASP.NET 5 supports a convention-based approach to configuring an application's startup based on the current environment.

Environment variables
---------------------



Summary
-------

ASP.NET 5 leverages the ``ASPNET_ENV`` environment variable to control how the application behaves in different environments. When publishing an application from development to staging to production, setting this variable appropriately for the environment allows for optimization of the application for debugging, testing, or production use, as appropriate.

Additional Resources
--------------------

- `Tag Helpers in ASP.NET MVC 6 <http://docs.asp.net/en/latest/mvc/views/tag-helpers/index.html>`_ including the Environment Tag Helper

.. _environments-author:

.. include:: /_authors/steve-smith.txt
