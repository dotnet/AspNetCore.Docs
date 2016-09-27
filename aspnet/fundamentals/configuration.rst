.. _fundamentals-configuration:

.. @svick  @pranavkm please review

Configuration
=============
`Rick Anderson`_, `Mark Michaelis <https://twitter.com/MarkMichaelis/>`__, `Steve Smith`_, `Daniel Roth`_

The configuration API reads lists of name-value pairs, which can be grouped into a multi-level hierarchy. For example, you could have the setting "SampleApp:AllUsers:Default:ShowWidgets" and "SampleApp:PowerUsers:MaxWidgets". There are configuration providers for file formats (INI, JSON, and XML), command-line arguments, environment variables, in-memory .NET objects, an encrypted user store, and custom provider you install or create.

.. contents:: Sections:
  :local:
  :depth: 1

`View or download sample code <https://github.com/aspnet/docs/tree/master/aspnet/fundamentals/configuration/sample>`__

.. TODO needs better title

Getting and setting configuration settings
------------------------------------------

The following console app uses the JSON configuration provider:

.. literalinclude:: configuration/sample/JsonConfig/Program.cs

The app reads and displays the following configuation settings:

.. literalinclude:: configuration/sample/JsonConfig/appsettings.json
  :language: json


.. The following console app uses the in-memory provider to read configuration settings:

.. move to the appropriate place: Applications access configuration settings in a strongly typed fashion using the :ref:`Options pattern <options-config-objects>`. We recommended that you instantiate a ``Configuration`` object in your apps's ``Startup`` class and use the :ref:`Options pattern <options-config-objects>` to access individual settings.

Name/value pairs written to the built in ``Configuration`` providers are **not** persisted, however, you can create a custom provider that saves values. See :ref:`custom configuration provider <custom-config-providers>`.

The sample above uses the configuation indexer to read values. In ASP.NET Core applications, we recommend you use the :ref:`options pattern <options-config-objects>` rather than the indexer to read configuration values. We'll demonstrate that later in this document.

.. The mechanism to read your app settings can be decoupled from the app by using the :ref:`options pattern <options-config-objects>`. With the options pattern you create an options class (probably several different classes, corresponding to different cohesive groups of settings) that you inject into your app using an options service. 

It's typical to have different configuration settings for different environments, for example, developement, test and production. The following highlighted code shows how to read a file in the content root directory named *appsettings.<EnvironmentName>.json*, where ``<EnvironmentName>`` is the name of the environment.

.. literalinclude:: configuration/sample/src/UsingOptions/Startup4.cs
  :language: none
  :start-after: snippet1
  :end-before: #endregion
  :dedent: 4
  :emphasize-lines: 5-7

Configuration sources are read in the order they are specified. In the code above, the *appsettings.json* file would be read first, followed by the *appsettings.[EnvironmentName].json* file. For any configuration values in both files, the settings in the last provider would be used (the last one "wins").

.. Tip:: A best practice is to specify environment variables last, so that the local environment can override anything set in deployed configuration files.

In the ``Development`` environment, the highlighted  code above would look for a file named *appsettings.Development.json*. Values read from *appsettings.Development.json* would overwrite those set in the *appsettings.json* file. See :doc:`environments`.

See :dn:method:`~Microsoft.Extensions.Configuration.JsonConfigurationExtensions.AddJsonFile` for an explaination of the parameters.


.. warning:: Never store passwords or other sensitive data in configuration provider code or in plain text configuration files. You also shouldn't use production secrets in your development or test environments. Instead, such secrets should be specified outside the project tree, so they cannot be accidentally committed into your repository. Learn more about :doc:`environments` and managing :doc:`/security/app-secrets`.

One way to leverage the order precedence of ``Configuration`` is to specify default values, which can be overridden. In the console application below, a default value for the ``username`` setting is specified in an in-memory collection, but this is overridden if a command line argument for ``username`` is passed to the application. You can see in the output how many different configuration sources are configured in the application at each stage of its execution.

.. literalinclude:: configuration/sample/src/ConfigConsole/Program.cs
  :emphasize-lines: 22,25
  :language: none

When run, the program will display the default value unless a command line parameter overrides it.

.. image:: configuration/_static/config-console.png

.. _options-config-objects:

Using Options and configuration objects
---------------------------------------

The options pattern enables using custom options classes to represent a group of related settings. 

We recommended that you create decoupled classes for each feature within your app. Decoupled classes follows the `Interface Segregation Principle (ISP) <http://deviq.com/interface-segregation-principle/>`_ (classes depend only on the configuration settings they use) as well as `Separation of Concerns <http://deviq.com/separation-of-concerns/>`_ (settings for disparate parts of your app are managed separately, and not dependent or coupled with one another).

The options class must be non-abstract with a public parameterless constructor:

.. literalinclude:: configuration/sample/src/UsingOptions/Models/MyOptions.cs
  :language: c#
  :lines: 3-7
  :dedent: 4

.. _options-example:

In the code below, ``ConfigurationBuilder`` is initialized in the ``Startup`` class. In the ``ConfigureServices`` method, an ``IConfigurationRoot`` interface is passed to the  to the :dn:method:`~Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.Configure\<TOptions>`, which adds ``ConfigurationBuilder`` to the dependency injection container:

.. literalinclude:: configuration/sample/src/UsingOptions/Startup.cs
  :language: c#
  :start-after: snippet1
  :end-before: #endregion
  :dedent: 4
  :emphasize-lines: 5-8,10,13,15,17,18,20,21

The following :doc:`controller </mvc/controllers/index>`  uses :doc:`dependency-injection` on :dn:iface:`~Microsoft.Extensions.Options.IOptions\<TOptions>` to access settings:
 
.. literalinclude:: configuration/sample/src/UsingOptions/Controllers/HomeController.cs
  :language: none
  :start-after: snippet1
  :end-before: #endregion
  :dedent: 4

With the following *appsettings.json* file:

.. literalinclude:: configuration/sample/src/UsingOptions/appsettings1.json
  :language: json

The ``HomeController.Index`` method returns ``option1 = value1_from_json, option2 = 2``.

In the following code, a second :dn:iface:`~Microsoft.Extensions.Options.IConfigureOptions\<TOptions>` service is added to the service container. It uses a delegate to configure the binding with ``MyOptions``. 

.. literalinclude:: configuration/sample/src/UsingOptions/Startup2.cs
  :language: c#
  :start-after: snippet1
  :end-before: #endregion
  :dedent: 8
  :emphasize-lines: 9-13

You can add an arbitrary number of ``IConfigureOptions\<TOptions>`` services to the service container and they are all applied in order they are registered. Each call to :dn:method:`~Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.Configure\<TOptions>` adds an :dn:iface:`~Microsoft.Extensions.Options.IConfigureOptions\<TOptions>` service to the service container. In the example above, the values of ``Option1`` and ``Option2`` are both specified in `appsettings.json`, but the value of ``Option1`` is overridden by the configured delegate in the highlighted code above. When more than one configuration service is configured, the last configuration source specified “wins”. In the code above, ``HomeController.Index`` method returns ``option1 = value1_from_action, option2 = 2``.

.. note:: Configuration keys are case insensitive.

.. add back in: When you bind options to configuration, each property in your options type is bound to a configuration key of the form ``property:subproperty:...``. For example, the ``MyOptions.Option1`` property is bound to the key ``Option1``, which is read from the ``option1`` property in *appsettings.json*. Note that 

In the following code, a third :dn:iface:`~Microsoft.Extensions.Options.IConfigureOptions\<TOptions>` service is added to the service container. It binds ``MySubOptions`` to the section ``subsection`` of the *appsettings.json*:

.. literalinclude:: configuration/sample/src/UsingOptions/Startup3.cs
  :language: c#
  :start-after: snippet1
  :end-before: #endregion
  :dedent: 8
  :emphasize-lines: 15-16

Using the following *appsettings.json* file:

.. literalinclude:: configuration/sample/src/UsingOptions/appsettings.json
  :language: json

With the following ``Controller``:

.. literalinclude:: configuration/sample/src/UsingOptions/Controllers/HomeController2.cs
  :language: none
  :start-after: snippet1
  :end-before: #endregion
  :dedent: 4

``subOption1 = subvalue1_from_json, subOption2 = 200`` is returned.

You can create a custom :dn:iface:`~Microsoft.Extensions.Options.IConfigureOptions\<TOptions>` service  (for example, to read settings from a database).  Use ``AddSingleton<IConfigureOptions<TOptions>>`` extension method to register a custom service.


.. _custom-config-providers:

.. Writing custom providers
  ------------------------
  In addition to using the built-in configuration providers, you can also write your own. To do so, you simply implement the :dn:iface:`~Microsoft.Extensions.Configuration.IConfigurationSource` interface, which exposes a :dn:method:`~Microsoft.Extensions.Configuration.IConfigurationSource.Build` method. The build method configures and returns an :dn:iface:`~Microsoft.Extensions.Configuration.IConfigurationProvider`.

Entity Framework custom provider
---------------------------------

We'll create a simple configuration provider that reads name-value pairs from a database using EF.

Define a simple ``ConfigurationValue`` entity for storing configuration values in the database:

.. literalinclude:: configuration/sample/src/CustomConfigurationProvider/ConfigurationValue.cs
  :language: c#
  :lines: 3-7
  :dedent: 4

Add a ``ConfigurationContext`` to store and access the configured values:

.. literalinclude:: configuration/sample/src/CustomConfigurationProvider/ConfigurationContext.cs
  :language: c#
  :start-after: snippet1
  :end-before: #endregion
  :dedent: 4
  :emphasize-lines: 7

Create an ``EntityFrameworkConfigurationSource`` that inherits from :dn:iface:`~Microsoft.Extensions.Configuration.IConfigurationSource`:

.. literalinclude:: configuration/sample/src/CustomConfigurationProvider/EntityFrameworkConfigurationSource.cs
  :language: c#
  :emphasize-lines: 7,16-19

Create the custom configuration provider by inheriting from :dn:class:`~Microsoft.Extensions.Configuration.ConfigurationProvider`. The configuration data is loaded by overriding the ``Load`` method, which reads in all of the configuration data from the configured database. For demonstration purposes, the configuration provider also takes care of initializing the database if it hasn't already been created and populated:

.. literalinclude:: configuration/sample/src/CustomConfigurationProvider/EntityFrameworkConfigurationProvider.cs
  :language: c#
  :emphasize-lines: 9,18-30,37-38

Note the values that are being stored in the database ("value_from_ef_1" and "value_from_ef_2"); these are displayed in the sample below to demonstrate the configuration is reading values from the DB.

You can also add an ``AddEntityFrameworkConfiguration`` extension method for adding the configuration source:

.. literalinclude:: configuration/sample/src/CustomConfigurationProvider/EntityFrameworkExtensions.cs
  :language: c#
  :emphasize-lines: 9

Create a :dn:class:`~Microsoft.Extensions.Configuration.ConfigurationBuilder` to set up your configuration sources. To add the ``EntityFrameworkConfigurationProvider``, you first need to specify the EF data provider and connection string. How should you configure the connection string? Using configuration of course! Add an *appsettings.json* file as a configuration source to bootstrap setting up the ``EntityFrameworkConfigurationProvider``. By adding the database settings to an existing configuration with other sources specified, any settings specified in the database will override settings specified in *appsettings.json*:

.. literalinclude:: configuration/sample/src/CustomConfigurationProvider/Program.cs
  :language: c#
  :emphasize-lines: 19-23

Using the following *appsettings.json* file:

.. literalinclude:: configuration/sample/src/CustomConfigurationProvider/appsettings.json
  :language: json

The following displayed::

  key1=value_from_ef_1
  key2=value_from_ef_2
  key3=value_from_json_3


ADD BACK INI
---------------

.. note:: To override nested keys through environment variables in shells that don't support ``:`` in variable names, replace them with ``__`` (double underscore).