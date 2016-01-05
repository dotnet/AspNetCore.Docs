Migrating Configuration From ASP.NET MVC 5 to MVC 6
===================================================

By `Steve Smith`_, `Scott Addie`_

In the previous article, we began :doc:`migrating an ASP.NET MVC 5 project to MVC 6 <migratingfrommvc5>`. In this article, we migrate the configuration feature from ASP.NET MVC 5 to ASP.NET MVC 6.

.. contents:: In this article:
  :local:
  :depth: 1
  
You can download the finished source from the project created in this article `here <https://github.com/aspnet/Docs/tree/master/mvc/migration/migratingconfig/samples>`_.

Setup Configuration
-------------------

ASP.NET 5 and ASP.NET MVC 6 no longer use the *Global.asax* and *web.config* files that previous versions of ASP.NET utilized. In earlier versions of ASP.NET, application startup logic was placed in an ``Application_StartUp`` method within *Global.asax*. Later, in ASP.NET MVC 5, a *Startup.cs* file was included in the root of the project; and, it was called using an ``OwinStartupAttribute`` when the application started. ASP.NET 5 (and ASP.NET MVC 6) have adopted this approach completely, placing all startup logic in the *Startup.cs* file.

The *web.config* file has also been replaced in ASP.NET 5. Configuration itself can now be configured, as part of the application startup procedure described in *Startup.cs*. Configuration can still utilize XML files, but typically ASP.NET 5 projects will place configuration values in a JSON-formatted file, such as *appsettings.json*. ASP.NET 5's configuration system can also easily access environment variables, which can provide a more secure and robust location for environment-specific values. This is especially true for secrets like connection strings and API keys that should not be checked into source control.

For this article, we are starting with the partially-migrated ASP.NET MVC 6 project from :doc:`the previous article <migratingfrommvc5>`. To setup configuration using the default MVC 6 settings, add the following constructor and property to the *Startup.cs* class located in the root of the project:

.. literalinclude:: migratingconfig/samples/WebApp1/src/WebApp1/Startup.cs
  :language: c#
  :linenos:
  :lines: 15-24
  :dedent: 8
  
Note that at this point the *Startup.cs* file will not compile, as we still need to add the following ``using`` statement:

.. code-block:: c#

	using Microsoft.Extensions.Configuration;

Add an *appsettings.json* file to the root of the project using the appropriate item template:

.. image:: migratingconfig/_static/add-appsettings-json.png
    :width: 955px

Migrate Configuration Settings from web.config
----------------------------------------------

Our ASP.NET MVC 5 project included the required database connection string in *web.config*, in the ``<connectionStrings>`` element. In our MVC 6 project, we are going to store this information in the *appsettings.json* file. Open *appsettings.json*, and note that it already includes the following:

.. literalinclude:: migratingconfig/samples/WebApp1/src/WebApp1/appsettings.json
  :language: json
  :emphasize-lines: 4
  :linenos:

In the highlighted line depicted above, change the name of the database from **_CHANGE_ME**. We are going to point to a new database, which will be named *NewMvc6Project* to match our migrated project name.

Summary
-------

ASP.NET 5 places all startup logic for the application in a single file, in which the necessary services and dependencies can be defined and configured. It replaces the *web.config* file with a flexible configuration feature that can leverage a variety of file formats, such as JSON, as well as environment variables.
