Migrating Configuration From ASP.NET MVC 5 to MVC 6
===================================================
By :ref:`Steve Smith <migratingconfig-author>` | Originally Published: 28 April 2015 

In the previous article we began `migrating an ASP.NET MVC 5 project to MVC 6 </migrating/migratingfrommvc5/migratingfrommvc5>`_. In this article, we migrate the configuration feature from ASP.NET MVC 5 to ASP.NET MVC 6.

In this article:
	- Set up Configuration
	- Migrate Configuration Settings from web.config

You can download the finished source from the project created in this article HERE **(TODO)**.

Set up Configuration
--------------------

ASP.NET 5 and ASP.NET MVC 6 no longer use the Global.asax and Web.config files that previous versions of ASP.NET utilized. In earlier versions of ASP.NET, application startup logic was placed in an Application_StartUp() method within Global.asax. Later, in ASP.NET MVC 5, a Startup.cs file was included in the root of the project, and was called using an OwinStartupAttribute when the application started. ASP.NET 5 (and ASP.NET MVC 6) have adopted this approach completely, placing all startup logic in the Startup.cs file.

The web.config file has also been replaced in ASP.NET 5. Configuration itself can now be configured, as part of the application startup procedure described in Startup.cs. Configuration can still utilize XML files, if desired, but typically ASP.NET 5 projects will place configuration values in a JSON-formatted file, such as config.json. ASP.NET 5's configuration system can also easily access environment variables, which can provide a more secure and robust location for environment-specific values. This is especially true for secrets like connection strings and API keys that should not be checked into source control.

For this article, we are starting with the partially-migrated ASP.NET MVC 6 project from `the previous article <migratingfrommvc5>`_. To configure Configuration using the default MVC 6 settings, add the following constructor to the Startup.cs class in the root of the project:

.. code-block:: c#

	public IConfiguration Configuration { get; set; }

	public Startup(IHostingEnvironment env)
	{
		// Setup configuration sources.
		Configuration = new Configuration()
			.AddJsonFile("config.json")
			.AddEnvironmentVariables();
	}

Note that at this point the Startup.cs file will not compile, as we still need to add some using statements and pull in some dependencies. Add the following two using statements:

.. code-block:: c#

	using Microsoft.Framework.ConfigurationModel;
	using Microsoft.AspNet.Hosting;

Next, open project.json and add the Microsoft.Framework.ConfigurationModel.Json dependency:

.. code-block:: javascript

	{
		"webroot": "wwwroot",
		"version": "1.0.0-*",
		"dependencies": {
			"Microsoft.AspNet.Server.IIS": "1.0.0-beta3",
			"Microsoft.AspNet.Mvc": "6.0.0-beta3",
			"Microsoft.Framework.ConfigurationModel.Json": "1.0.0-beta3"
		},
		...
	}

Finally, add a config.json file to the root of the project.

.. image:: migratingconfig/_static/add-config-json.png

Migrate Configuration Settings from Web.config
----------------------------------------------

Our ASP.NET MVC 5 project included the required database connection string in Web.config, in the <connectionStrings> element. In our MVC 6 project, we are going to store this information in the config.json file. Open Config.json, and you should see that it already includes the following:

.. code-block:: javascript

	{
		"Data": {
			"DefaultConnection": { 
				"ConnectionString": "Server=(localdb)\\MSSQLLocalDB;Database=_CHANGE_ME;Trusted_Connection=True;"
			}
		}
	}

Change the name of the Database from _CHANGE_ME. In the case of this migration, we are going to point to a new database, which we'll name NewMvc6Project to match our migrated project name.

Summary
-------

ASP.NET 5 places all Startup logic for the application in a single file in which necessary services and dependencies can be defined and configured. It replaces the web.config file with a flexible configuration feature that can leverage a variety of file formats, such as JSON, as well as environment variables.

.. _migratingconfig-author:

.. include:: /_authors/steve-smith.rst
