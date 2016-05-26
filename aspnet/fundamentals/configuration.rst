.. _fundamentals-configuration:

Configuration
=============
`Steve Smith`_, `Daniel Roth`_

ASP.NET Core supports a variety of different configuration options. Application configuration data can come from files using built-in support for JSON, XML, and INI formats, as well as from environment variables. You can also write your own :ref:`custom configuration source <custom-config-providers>`.

.. contents:: Sections:
  :local:
  :depth: 1

`View or download sample code <https://github.com/aspnet/docs/tree/master/aspnet/fundamentals/configuration/sample>`__

Getting and setting configuration settings
------------------------------------------

ASP.NET Core's configuration system has been re-architected from previous versions of ASP.NET, which relied on ``System.Configuration`` and XML configuration files like ``web.config``. The new configuration model provides streamlined access to key/value based settings that can be retrieved from a variety of sources. Applications and frameworks can then access configured settings using the new :ref:`Options pattern <options-config-objects>`

To work with settings in your ASP.NET application, it is recommended that you only instantiate a ``Configuration`` in your application's ``Startup`` class. Then, use the :ref:`Options pattern <options-config-objects>` to access individual settings.

At its simplest, ``Configuration`` is just a collection of ``Sources``, which provide the ability to read and write name/value pairs. You must configure at least one source in order for ``Configuration`` to function correctly. The following sample shows how to test working with ``Configuration`` as a key/value store:

.. code-block:: c#
  :linenos:

  // assumes using Microsoft.Framework.Configuration is specified
  var builder = new ConfigurationBuilder();
  builder.Add(new MemoryConfigurationSource());
  var config = builder.Build();
  config["somekey"] = "somevalue";

  // do some other work

  string setting2 = config["somekey"]; // also returns "somevalue"

.. note:: You must set at least one configuration source.

It's not unusual to store configuration values in a hierarchical structure, especially when using external files (e.g. JSON, XML, INI). In this case, configuration values can be retrieved using a ``:`` separated key, starting from the root of the hierarchy. For example, consider the following *appsettings.json* file:

.. _config-json:

.. literalinclude:: /../common/samples/WebApplication1/src/WebApplication1/appsettings.json
  :linenos:
  :language: json

The application uses configuration to configure the right connection string. Access to the ``DefaultConnection`` setting is achieved through this key: ``ConnectionStrings:DefaultConnection``.

The settings required by your application and the mechanism used to specify those settings (configuration being one example) can be decoupled using the :ref:`options pattern <options-config-objects>`. To use the options pattern you create your own settings class (probably several different classes, corresponding to different cohesive groups of settings) that you can inject into your application using an options service. You can then specify your settings using configuration or whatever mechanism you choose.

.. note:: You could store your ``Configuration`` instance as a service, but this would unnecessarily couple your application to a single configuration system and specific configuration keys. Instead, you can use the :ref:`Options pattern <options-config-objects>` to avoid these issues.

Using the built-in sources
--------------------------

The configuration framework has built-in support for JSON, XML, and INI configuration files, as well as support for in-memory configuration (directly setting values in code) and the ability to pull configuration from environment variables and command line parameters. Developers are not limited to using a single configuration source. In fact several may be set up together such that a default configuration is overridden by settings from another source if they are present.

Adding support for additional configuration sources is accomplished through extension methods. These methods can be called on a ``ConfigurationBuilder`` instance in a standalone fashion, or chained together as a fluent API, as shown.

.. _custom-config:

.. literalinclude:: configuration/sample/src/CustomConfigurationSource/Program.cs
  :linenos:
  :dedent: 12
  :language: c#
  :lines: 14-18

The order in which configuration sources are specified is important, as this establishes the precedence with which settings will be applied if they exist in multiple locations. In the example below, if the same setting exists in both *appsettings.json* and in an environment variable, the setting from the environment variable will be the one that is used. The last configuration source specified "wins" if a setting exists in more than one location. The ASP.NET team recommends specifying environment variables last, so that the local environment can override anything set in deployed configuration files.

.. note:: To override nested keys through environment variables in shells that don't support ``:`` in variable names, replace them with ``__`` (double underscore).

It can be useful to have environment-specific configuration files. This can be achieved using the following:

.. literalinclude:: /../common/samples/WebApplication1/src/WebApplication1/Startup.cs
  :linenos:
  :dedent: 8
  :language: c#
  :lines: 20-35
  :emphasize-lines: 6

The ``IHostingEnvironment`` service is used to get the current environment. In the ``Development`` environment, the highlighted line of code above would look for a file named ``appsettings.Development.json`` and use its values, overriding any other values, if it's present. Learn more about :doc:`environments`.

.. warning:: You should never store passwords or other sensitive data in configuration source code or in plain text configuration files. You also shouldn't use production secrets in your development or test environments. Instead, such secrets should be specified outside the project tree, so they cannot be accidentally committed into the configuration source repository. Learn more about :doc:`environments` and managing :doc:`/security/app-secrets`.

One way to leverage the order precedence of ``Configuration`` is to specify default values, which can be overridden. In this simple console application, a default value for the ``username`` setting is specified in a ``MemoryConfigurationSource``, but this is overridden if a command line argument for ``username`` is passed to the application. You can see in the output how many configuration sources are configured at each stage of the program.

.. literalinclude:: configuration/sample/src/ConfigConsole/Program.cs
  :linenos:
  :language: c#

When run, the program will display the default value unless a command line parameter overrides it.

.. image:: configuration/_static/config-console.png

.. _options-config-objects:

Using Options and configuration objects
---------------------------------------

Using the options pattern you can easily convert any class (or POCO - Plain Old CLR Object) into a settings class. It's recommended that you create well-factored settings objects that correspond to certain features within your application, thus following the Interface Segregation Principle (ISP) (classes depend only on the configuration settings they use) as well as Separation of Concerns (settings for disparate parts of your app are managed separately, and thus are less likely to negatively impact one another).

A simple ``MyOptions`` class is shown here:

.. literalinclude:: configuration/sample/src/UsingOptions/Models/MyOptions.cs
  :linenos:
  :language: c#
  :lines: 3-7
  :dedent: 4

Options can be injected into your application using the ``IOptions<TOptions>`` service. For example, the following :doc:`controller </mvc/controllers/index>`  uses ``IOptions<MyOptions>`` to access the settings it needs to render the ``Index`` view:

.. literalinclude:: configuration/sample/src/UsingOptions/Controllers/HomeController.cs
  :linenos:
  :language: c#
  :lines: 9-20
  :dedent: 4

Learn more about :doc:`dependency-injection`.

To setup the ``IOptions<TOption>`` service you call the ``AddOptions()`` extension method during startup in your ``ConfigureServices`` method:

.. literalinclude:: configuration/sample/src/UsingOptions/Startup.cs
  :linenos:
  :language: c#
  :lines: 26-29,42
  :dedent: 8

.. _options-example:

The ``Index`` view displays the configured options:

.. image:: configuration/_static/index-view.png

You configure options using the ``Configure<TOption>`` extension method. You can configure options using a delegate or by binding your options to configuration:

.. literalinclude:: configuration/sample/src/UsingOptions/Startup.cs
  :language: c#
  :linenos:
  :lines: 26-42
  :dedent: 8
  :emphasize-lines: 7,10-13

When you bind options to configuration, each property in your options type is bound to a configuration key of the form ``property:subproperty:...``. For example, the ``MyOptions.Option1`` property is bound to the key ``Option1``, which is read from the ``option1`` property in *appsettings.json*. Note that configuration keys are case insensitive.

Each call to ``Configure<TOption>`` adds an ``IConfigureOptions<TOption>`` service to the service container that is used by the ``IOptions<TOption>`` service to provide the configured options to the application or framework. If you want to configure your options some other way (e.g. reading settings from a database) you can use the ``ConfigureOptions<TOptions>`` extension method to specify a custom ``IConfigureOptions<TOption>`` service directly. 

You can have multiple ``IConfigureOptions<TOption>`` services for the same option type and they are all applied in order. In the :ref:`example <options-example>` above, values of ``Option1`` and ``Option2`` are both specified in `appsettings.json`, but the value of ``Option1`` is overridden by the configured delegate.

.. _custom-config-providers:

Writing custom sources
----------------------

In addition to using the built-in configuration sources, you can also write your own. To do so, you inherit from ``ConfigurationProvider``, and populate the ``Data`` property with the settings from your configuration source. Then you also implement ``IConfigurationSource`` and use it to create the ``ConfigurationProvider``.

Example: Entity Framework Settings
^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

You may wish to store some of your application's settings in a database, and access them using Entity Framework (EF). There are many ways in which you could choose to store such values, ranging from a simple table with a column for the setting name and another column for the setting value, to having separate columns for each setting value. In this example, we're going to create a simple configuration source that reads name-value pairs from a database using EF.

To start off we'll define a simple ``ConfigurationValue`` entity for storing configuration values in the database:

.. literalinclude:: configuration/sample/src/CustomConfigurationSource/ConfigurationValue.cs
  :linenos:
  :language: c#
  :lines: 3-7
  :dedent: 4

We also need a ``ConfigurationContext`` to store and access the configured values using EF:

.. literalinclude:: configuration/sample/src/CustomConfigurationSource/ConfigurationContext.cs
  :linenos:
  :language: c#
  :lines: 5-12
  :dedent: 4

Next, we create a configuration provider by inheriting from ``ConfigurationProvider``. The configuration data is loaded by overriding the ``Load`` method, which reads in all of the configuration data from the configured database. For demonstration purposes, the configuration provider also takes care of initializing the database if it hasn't already been created and populated:

.. literalinclude:: configuration/sample/src/CustomConfigurationSource/EntityFrameworkConfigurationSource.cs
  :linenos:
  :language: c#
  :lines: 9-46
  :dedent: 4

Then we create the custom configuration source by implementing ``IConfigurationSource`` and returning a new instance of the configuration provider in the ``Build`` method:

.. literalinclude:: configuration/sample/src/CustomConfigurationSource/EntityFrameworkConfigurationSource.cs
  :linenos:
  :language: c#
  :lines: 48-59
  :dedent: 4

By convention we also add an ``AddEntityFramework`` extension method for adding the configuration source:

.. literalinclude:: configuration/sample/src/CustomConfigurationSource/EntityFrameworkConfigurationSource.cs
  :linenos:
  :language: c#
  :lines: 61-68
  :dedent: 4

You can see an example of how to use this custom configuration source in your application in the following example. Create a new ``ConfigurationBuilder`` to setup your configuration sources. To add the ``EntityFrameworkConfigurationSource`` you first need to specify the data provider and connection string. How should you configure the connection string? Using configuration of course! Add an *appsettings.json* file as a configuration source to bootstrap setting up the ``EntityFrameworkConfigurationSource``. By reusing the same ``ConfigurationBuilder``, any settings specified in the database will override settings specified in *appsettings.json*:

.. literalinclude:: configuration/sample/src/CustomConfigurationSource/Program.cs
  :linenos:
  :language: c#
  :lines: 7-26
  :dedent: 4

Run the application to see the configured values:

.. image:: configuration/_static/custom-config.png

Summary
-------

ASP.NET Core provides a very flexible configuration model that supports a number of different file-based options, as well as command-line, in-memory, and environment variables. It works seamlessly with the options model so that you can inject strongly typed settings into your application or framework. You can create your own custom configuration sources as well, which can work with or replace the built-in sources, allowing for extreme flexibility. 
