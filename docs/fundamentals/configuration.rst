Configuration
=============
By :ref:`Steve Smith <configuration-author>` | Originally Published: 6 May 2015

ASP.NET 5 supports a variety of different configuration options. Application configuration data can come from files using built-in support for JSON, XML, and INI formats, as well as from environment variables. Of course, developers can build their own custom configuration providers, as well.

In this article:
	- `Getting and setting configuration settings`_
	- `Using the built-in providers`_
	- `Writing custom providers`_
	
`Download sample from GitHub <https://github.com/aspnet/docs>`_.

Getting and setting configuration settings
------------------------------------------

ASP.NET 5's configuration system has been re-architected from previous versions of ASP.NET, which relied on ``System.Configuration`` and XML configuration files like ``web.config``. The new `configuration model <https://github.com/aspnet/Configuration>`_ provides streamlined access to key/value based settings that can be retrieved from a variety of sources.

To work with settings in your ASP.NET application, you can instantiate a new instance of ``Configuration`` anywhere you need one. However, it's recommended to do this once in your application's ``Startup``, and then inject an instance of ``IConfiguration`` into any controllers or services that need to access configuration. At its simplest, the ``Configuration`` class is just a name-value collection, which you can read from or write to however you wish. For instance, you could include the following code in any method in your ASP.NET application:

.. code-block:: c#
	:linenos:

	// assumes using Microsoft.Framework.ConfigurationModel is specified
	var config = new Configuration();
	config.Set("somekey", "somevalue");
	
	// do some other work
	
	var setting = config.Get("somekey); // returns "somevalue"
	// or
	var setting2 = config["somekey"]; // also returns "somevalue"

It's not unusual to store configuration values in a hierarchical structure, especially when using external files (e.g. JSON, XML, INI). In this case, configuration values can be retrieved using a ``:`` separated key, starting from the root of the hierarchy. For example, consider the following `config.json`` file:

.. literalinclude:: configuration/sample/src/ConfigDemo/config.json
	:linenos:
	:language: javascript

Access to the "SiteTitle" setting is done through a key of ``AppSettings:SiteTitle``. Similarly, access to the ``ConnectionString`` setting is achieved through this key: ``Data:DefaultConnection:ConnectionString``.

.. TODO: Show how to load POCOs using https://github.com/aspnet/Options/blob/dev/src/Microsoft.Framework.OptionsModel/ConfigurationBinder.cs

The recommended way to access configuration settings from within your application is to leverage the built-in support for `Dependency Injection <dependency-injection.html>`_ in ASP.NET 5. First, set up configuration in ``Startup.cs`` (we'll see how in the next section), and assign the ``Configuration`` instance to a property on ``Startup``.  Next, in ``ConfigureServices()``, add the ``Configuration`` property to the list of services ASP.NET manages, like so:

.. code-block:: c#

	// set this in Startup() constructor
	public IConfiguration Configuration { get; set; }

	// This method gets called by the runtime. Use this method to add services to the container.
	public void ConfigureServices(IServiceCollection services)
	{
		services.AddSingleton(_ => Configuration);
		// more code omitted
	}

Now with this in place, you can request an instance of ``IConfiguration`` in the constructor of any controller that needs access to configuration values.

.. literalinclude:: configuration/sample/src/ConfigDemo/Controllers/HomeController.cs
	:linenos:
	:language: c#
	:emphasize-lines: 12-16,20
	:lines: 1-17, 23-29, 42-

This approach provides several benefits. First, it follows the `Don't Repeat Yourself, or DRY, Principle <http://deviq.com/don-t-repeat-yourself/>`_, because the ``Configuration`` instance is only defined in one place in the application. The resulting code is also easier to test, since it doesn't have a dependency on creating a ``Configuration`` instance, and instead a fake or mock ``IConfiguration`` instance can be provided during testing.

Using the built-in providers
----------------------------

Content goes here.

Note that precedence is increasing with order of declaration - last one wins.

Cover JSON, XML, INI as well as in-memory, command-line, and env vars.

Note that Env Vars are a good option to keep secrets out of source control and easily enable production environments (or local dev machines) to use custom connection strings and other config settings independent of files.

Writing custom providers
------------------------

In addition to using the built-in providers, you can also write your own.
Content goes here.


Summary
-------

asdf


.. _configuration-author:

.. include:: /_authors/steve-smith.txt
