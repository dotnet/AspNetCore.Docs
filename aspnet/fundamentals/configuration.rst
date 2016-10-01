.. _fundamentals-configuration:

Configuration
=============
`Rick Anderson`_, `Mark Michaelis <http://intellitect.com/author/mark-michaelis/>`__, `Steve Smith`_, `Daniel Roth`_

The configuration API reads lists of name-value pairs, which can be grouped into a multi-level hierarchy. There are configuration providers for file formats (INI, JSON, and XML), command-line arguments, environment variables, in-memory .NET objects, an encrypted user store, and custom providers you install or create. Each configuration value maps to a string, and there’s built-in binding support to deserialize settings into a custom POCO object (.NET class). 

.. contents:: Sections:
  :local:
  :depth: 1

`View or download sample code <https://github.com/aspnet/docs/tree/master/aspnet/fundamentals/configuration/sample>`__


Simple configuration 
------------------------------------------

The following console app uses the JSON configuration provider:

.. literalinclude:: configuration/sample/src/ConfigJson/Program.cs

The app reads and displays the following configuration settings:

.. literalinclude:: configuration/sample/src/ConfigJson/appsettings.json
  :language: json

Configuration consists of a hierarchical list of name-value pairs in which the nodes are separated by a colon. To retrieve a particular value, you access the ``Configuration`` indexer with the corresponding item’s key::

  Console.WriteLine(
    $"option1 = {Configuration["subsection:suboption1"]}");

Name/value pairs written to the built in ``Configuration`` providers are **not** persisted, however, you can create a custom provider that saves values. See :ref:`custom configuration provider <custom-config-providers>`.

The sample above uses the configuration indexer to read values. In ASP.NET Core applications, we recommend you use the :ref:`options pattern <options-config-objects>` rather than the indexer to read configuration values. We'll demonstrate that later in this document.

.. The mechanism to read your app settings can be decoupled from the app by using the :ref:`options pattern <options-config-objects>`. With the options pattern you create an options class (probably several different classes, corresponding to different cohesive groups of settings) that you inject into your app using an options service. 

It's typical to have different configuration settings for different environments, for example, development, test and production. The following highlighted code hooks up two configuration providers to three sources:

#. JSON provider, reading *appsettings.json*
#. JSON provider, reading *appsettings.<EnvironmentName>.json*
#. Environment variables provider

.. literalinclude:: configuration/sample/src/UsingOptions/Startup4.cs
  :language: none
  :start-after: snippet1
  :end-before: #endregion
  :dedent: 4
  :emphasize-lines: 5-7

See :dn:method:`~Microsoft.Extensions.Configuration.JsonConfigurationExtensions.AddJsonFile` for an explanation of the parameters. Configuration sources are read in the order they are specified. In the code above, the environment variables are read last, any configuration values set through the environment would replace those set in the two previous providers.

The environment is typically set to one of ``Development``, ``Staging``, or ``Production``. See :doc:`environments` for more information.

.. note:: To override nested keys through environment variables in shells that don't support ``:`` in variable names, replace them with ``__`` (double underscore).

.. Tip:: A best practice is to specify environment variables last, so that the local environment can override anything set in deployed configuration files.

.. warning:: Never store passwords or other sensitive data in configuration provider code or in plain text configuration files. You also shouldn't use production secrets in your development or test environments. Instead, such secrets should be specified outside the project tree, so they cannot be accidentally committed into your repository. Learn more about :doc:`environments` and managing :doc:`/security/app-secrets`.

.. _options-config-objects:

Using Options and configuration objects
---------------------------------------

The options pattern enables using custom options classes to represent a group of related settings. We recommended that you create decoupled classes for each feature within your app. Decoupled classes follow:

- The `Interface Segregation Principle (ISP) <http://deviq.com/interface-segregation-principle/>`_ : Classes depend only on the configuration settings they use.
- `Separation of Concerns <http://deviq.com/separation-of-concerns/>`_ : Settings for disparate parts of your app are managed separately, and not dependent or coupled with one another.

The options class must be non-abstract with a public parameterless constructor. For example:

.. literalinclude:: configuration/sample/src/UsingOptions/Models/MyOptions.cs
  :language: c#
  :lines: 3-7
  :dedent: 4

.. _options-example:

In the code below, ``ConfigurationBuilder`` is initialized in the ``Startup`` class. In the ``ConfigureServices`` method, an ``IConfigurationRoot`` interface is passed to the to :dn:method:`~Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.Configure\<TOptions>`, which adds ``ConfigurationBuilder`` to the dependency injection container:

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

There is no limit to the number of ``IConfigureOptions<TOptions>`` services you can add. Each configuration service comes in a NuGet package. They are all applied in order they are registered. Each call to :dn:method:`~Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.Configure\<TOptions>` adds an :dn:iface:`~Microsoft.Extensions.Options.IConfigureOptions\<TOptions>` service to the service container. In the example above, the values of ``Option1`` and ``Option2`` are both specified in `appsettings.json`, but the value of ``Option1`` is overridden by the configured delegate in the highlighted code above. When more than one configuration service is enabled, the last configuration source specified “wins”. With the code above, the ``HomeController.Index`` method returns ``option1 = value1_from_action, option2 = 2``.

.. note:: Configuration keys are case insensitive.

When you bind options to configuration, each property in your options type is bound to a configuration key of the form ``property[:subproperty:]``. For example, the ``MyOptions.Option1`` property is bound to the key ``Option1``, which is read from the ``option1`` property in *appsettings.json*.

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

.. You can create a custom :dn:iface:`~Microsoft.Extensions.Options.IConfigureOptions\<TOptions>` service  (for example, to read settings from a database).  Use ``AddSingleton<IConfigureOptions<TOptions>>`` extension method to register a custom service.

.. _in-memory-provider:

In-memory provider and binding to a POCO class
------------------------------------------------

The following sample shows how to use the in-memory provider and bind to a class:

.. literalinclude:: configuration/sample/src/InMemory/Program.cs
  :language: none

.. literalinclude:: configuration/sample/src/InMemory/MyWindow.cs
  :language: none

Note the ConfigurationBinder’s ``GetValue<T>`` extension method allows you to specify a default value (80 in the sample)::

   var left = Configuration.GetValue<int>("AppConfiguration:MainWindow:Left", 80);

Configuration values are not limited to scalars. You can retrieve POCO objects or even entire object graphs. The following sample shows how to bind to the ``MyWindow`` class and use the options pattern with a ASP.NET Core MVC app:

.. literalinclude:: configuration/sample/src/WebConfigBind/MyWindow.cs
  :language: c#

.. literalinclude:: configuration/sample/src/WebConfigBind/appsettings.json
  :language: json

Bind the custom class in ``ConfigureServices`` in the ``Startup`` class:

.. literalinclude:: configuration/sample/src/WebConfigBind/Startup.cs
  :language: none
  :dedent: 8
  :start-after: snippet1
  :end-before: #endregion

Display the settings from the ``HomeController``:

.. literalinclude:: configuration/sample/src/WebConfigBind/Controllers/HomeController.cs
  :language: none

.. _custom-config-providers:

Note that Dependency Injection (DI) is not setup until after ``ConfigureServices`` is invoked and the configuration system is not DI aware.

Binding to an object graph
---------------------------

You can recursively bind to each object in a class. Consider the following ``AppOptions`` class:

.. literalinclude:: configuration\sample\src\ObjectGraph\AppOptions.cs
  :language: c#

The following sample binds to the ``AppOptions`` class:

.. literalinclude:: configuration\sample\src\ObjectGraph\Program.cs
  :language: none

Using the following *appsettings.json* file:

.. literalinclude:: configuration\sample\src\ObjectGraph\appsettings.json
  :language: json

The program displays ``Height 11``.

The following code can be used to unit test the configuration:

.. code-block:: c#

    [Fact]
    public void CanBindObjectTree()
    {
        var dict = new Dictionary<string, string>
                {
                    {"App:Profile:Machine", "Rick"},
                    {"App:Connection:Value", "connectionstring"},
                    {"App:Window:Height", "11"},
                    {"App:Window:Width", "11"}
                };
        var builder = new ConfigurationBuilder();
        builder.AddInMemoryCollection(dict);
        var config = builder.Build();

        var options = new AppOptions();
        config.GetSection("App").Bind(options);

        Assert.Equal("Rick", options.Profile.Machine);
        Assert.Equal(11, options.Window.Height);
        Assert.Equal(11, options.Window.Width);
        Assert.Equal("connectionstring", options.Connection.Value);
    }

Entity Framework custom provider
---------------------------------

In this section we'll create a simple configuration provider that reads name-value pairs from a database using EF.

Define a `ConfigurationValue`` entity for storing configuration values in the database:

.. literalinclude:: configuration/sample/src/CustomConfigurationProvider/ConfigurationValue.cs
  :language: c#

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

Create the custom configuration provider by inheriting from :dn:class:`~Microsoft.Extensions.Configuration.ConfigurationProvider`. The configuration data is loaded by overriding the ``Load`` method, which reads in all the configuration data from the configured database. For demonstration purposes, the configuration provider also takes care of initializing the database if it hasn't already been created and populated:

.. literalinclude:: configuration/sample/src/CustomConfigurationProvider/EntityFrameworkConfigurationProvider.cs
  :language: c#
  :emphasize-lines: 9,18-30,37-38

Note the values that are being stored in the database ("value_from_ef_1" and "value_from_ef_2"); these are displayed in the sample below to demonstrate the configuration is reading values from the DB.

You can also add an ``AddEntityFrameworkConfiguration`` extension method for adding the configuration source:

.. literalinclude:: configuration/sample/src/CustomConfigurationProvider/EntityFrameworkExtensions.cs
  :language: c#
  :emphasize-lines: 9

Create a :dn:class:`~Microsoft.Extensions.Configuration.ConfigurationBuilder` to set up your configuration sources. To add the ``EntityFrameworkConfigurationProvider``, specify the EF data provider and connection string. How should you configure the connection string? Using configuration of course! Add an *appsettings.json* file as a configuration source to bootstrap setting up the ``EntityFrameworkConfigurationProvider``. Note the sample adds the custom ``EntityFrameworkConfigurationProvider`` after the JSON provider, so any settings in the database will override settings in *appsettings.json*:

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

CommandLine configuration provider
----------------------------------

The following sample enables the CommandLine configuration provider last:

.. literalinclude:: configuration/sample/src/CommandLine/Program.cs
  :language: none

The following command uses the command line provided settings::

  dotnet run /Profile:MachineName=Bob /App:MainWindow:Left=1234

And displays::

   Hello Bob
   Left 1234

The ``GetSwitchMappings`` method allows you to use ``-`` rather than ``/`` and it strips the leading subkey prefixes. For example::

   dotnet run -MachineName=Bob -Left=7734

Displays::

   Hello Bob
   Left 7734

Command-line arguments must include a value (it can be null). For example::

   dotnet run /Profile:MachineName=

Is OK, but ::

   dotnet run /Profile:MachineName

results in an exception. An exception will be thrown if you specify a command-line switch prefix of - or -- for which there’s no corresponding switch mapping

Additional Resources
^^^^^^^^^^^^^^^^^^^^^

- :doc:`environments`
- :doc:`/security/app-secrets`
- :doc:`dependency-injection`