---
title: Configuration | Microsoft Docs
author: rick-anderson
description: Demonstrates the configuration API
keywords: ASP.NET Core, configuration, JSON
ms.author: riande
manager: wpickett
ms.date: 11/29/2016
ms.topic: article
ms.assetid: b3a5984d-e172-42eb-8a48-547e4acb6806
ms.technology: aspnet
ms.prod: aspnet-core
uid: fundamentals/configuration
---
<a name=fundamentals-configuration></a>

  # Configuration

[Rick Anderson](https://twitter.com/RickAndMSFT), [Mark Michaelis](http://intellitect.com/author/mark-michaelis/), [Steve Smith](http://ardalis.com), [Daniel Roth](https://github.com/danroth27)

<!-- SEE https://github.com/aspnet/Configuration/issues/532
-->

The configuration API reads lists of name-value pairs. The name-value pairs can be grouped into a multi-level hierarchy. There are configuration providers for:

* File formats (INI, JSON, and XML)
* Command-line arguments
* Environment variables
* In-memory .NET objects
* An encrypted user store
* Custom providers, which you install or create

Each configuration value maps to a string key. There’s built-in binding support to deserialize settings into a custom [POCO](https://en.wikipedia.org/wiki/Plain_Old_CLR_Object) object (.NET class).

[View or download sample code](https://github.com/aspnet/docs/tree/master/aspnetcore/fundamentals/configuration/sample)

  ## Simple configuration

The following console app uses the JSON configuration provider:

[!code-csharp[Main](configuration/sample/src/ConfigJson/Program.cs)]

The app reads and displays the following configuration settings:

[!code-json[Main](configuration/sample/src/ConfigJson/appsettings.json)]

Configuration consists of a hierarchical list of name-value pairs in which the nodes are separated by a colon. To retrieve a particular value, you access the `Configuration` indexer with the corresponding item’s key:

```
   Console.WriteLine(
     $"option1 = {Configuration["subsection:suboption1"]}");
   ```

Name/value pairs written to the built in `Configuration` providers are **not** persisted, however, you can create a custom provider that saves values. See [custom configuration provider](xref:fundamentals/configuration#custom-config-providers).

The sample above uses the configuration indexer to read values. In ASP.NET Core applications, we recommend you use the [options pattern](xref:fundamentals/configuration#options-config-objects) rather than the indexer to read configuration values. We'll show that later in this document.

It's typical to have different configuration settings for different environments, for example, development, test and production. The following highlighted code hooks up two configuration providers to three sources:

1. JSON provider, reading *appsettings.json*
2. JSON provider, reading *appsettings.\<EnvironmentName>.json*
3. Environment variables provider

[!code-csharp[Main](configuration/sample/src/WebConfigBind/Startup.cs?name=snippet2&highlight=7-9)]

See [AddJsonFile](https://docs.microsoft.com/aspnet/core/api/microsoft.extensions.configuration.jsonconfigurationextensions) for an explanation of the parameters. `reloadOnChange` is only supported in ASP.NET Core 1.1 and higher. 

Configuration sources are read in the order they are specified. In the code above, the environment variables are read last. Any configuration values set through the environment would replace those set in the two previous providers.

The environment is typically set to one of `Development`, `Staging`, or `Production`. See [Working with Multiple Environments](environments.md) for more information.

Configuration considerations:

* `IOptionsSnapshot` can reload configuration data when it changes. Use `IOptionsSnapshot` if you need to reload configuration data.  See [IOptionsSnapshot](#ioptionssnapshot) for more information.
* Configuration keys are case insensitive.
* A best practice is to specify environment variables last, so that the local environment can override anything set in deployed configuration files.
* **Never** store passwords or other sensitive data in configuration provider code or in plain text configuration files. You also shouldn't use production secrets in your development or test environments. Instead, specify secrets outside the project tree, so they cannot be accidentally committed into your repository. Learn more about [Working with Multiple Environments](environments.md) and managing [Safe storage of app secrets during development](../security/app-secrets.md).
* If `:` cannot be used in environment variables in your system,  replace `:`  with `__` (double underscore).

<a name=options-config-objects></a>

## Using Options and configuration objects

The options pattern uses custom options classes to represent a group of related settings. We recommended that you create decoupled classes for each feature within your app. Decoupled classes follow:

* The [Interface Segregation Principle (ISP)](http://deviq.com/interface-segregation-principle/) : Classes depend only on the configuration settings they use.
* [Separation of Concerns](http://deviq.com/separation-of-concerns/) : Settings for different parts of your app are not dependent or coupled with one another.

The options class must be non-abstract with a public parameterless constructor. For example:

[!code-csharp[Main](configuration/sample/src/UsingOptions/Models/MyOptions.cs)]

<a name=options-example></a>

In the following code, the JSON configuration provider is enabled. The `MyOptions` class is added to the service container and bound to configuration.

[!code-csharp[Main](configuration/sample/src/UsingOptions/Startup.cs?name=snippet1&highlight=8,20-22)]


The following [controller](../mvc/controllers/index.md)  uses [Dependency Injection](dependency-injection.md) on [`IOptions<TOptions>`](https://docs.microsoft.com/en-us/aspnet/core/api/microsoft.extensions.options.ioptions-1) to access settings:

[!code-csharp[Main](configuration/sample/src/UsingOptions/Controllers/HomeController.cs?name=snippet1)]

With the following *appsettings.json* file:

[!code[Main](configuration/sample/src/UsingOptions/appsettings1.json)]

The `HomeController.Index` method returns `option1 = value1_from_json, option2 = 2`.

Typical apps won't bind the entire configuration to a single options file. Later on I'll show how to use `GetSection` to bind to a section.

In the following code, a second `IConfigureOptions<TOptions>` service is added to the service container. It uses a delegate to configure the binding with `MyOptions`.

[!code-csharp[Main](configuration/sample/src/UsingOptions/Startup2.cs?name=snippet1&highlight=8-13)]

You can add multiple configuration providers. Configuration providers are available in NuGet packages. They are applied in order they are registered.

Each call to `Configure<TOptions>]` adds an `IConfigureOptions<TOptions>` service to the service container. In the example above, the values of `Option1` and `Option2` are both specified in *appsettings.json*, but the value of `Option1` is overridden by the configured delegate in the highlighted code above. 

When more than one configuration service is enabled, the last configuration source specified “wins”. With the code above, the `HomeController.Index` method returns `option1 = value1_from_action, option2 = 2`.

When you bind options to configuration, each property in your options type is bound to a configuration key of the form `property[:sub-property:]`. For example, the `MyOptions.Option1` property is bound to the key `Option1`, which is read from the `option1` property in *appsettings.json*. A sub-property sample is shown later in this article.

In the following code, a third `IConfigureOptions<TOptions>` service is added to the service container. It binds `MySubOptions` to the section `subsection` of the *appsettings.json* file:

[!code-csharp[Main](configuration/sample/src/UsingOptions/Startup3.cs?name=snippet1&highlight=16-17)]

Using the following *appsettings.json* file:

[!code[Main](configuration/sample/src/UsingOptions/appsettings.json)]

The `MySubOptions` class:

[!code-csharp[Main](configuration/sample/src/UsingOptions/Models/MySubOptions.cs)]

With the following `Controller`:

[!code-csharp[Main](configuration/sample/src/UsingOptions/Controllers/HomeController2.cs?name=snippet1)]

`subOption1 = subvalue1_from_json, subOption2 = 200` is returned.

<a name=in-memory-provider></a>

## IOptionsSnapshot

*Requires ASP.NET Core 1.1 or higher.*

`IOptionsSnapshot` supports reloading configuration data when the configuration file has changed.  It also has minimal overhead if you don't care about changes. Using `IOptionsSnapshot` with `reloadOnChange: true`, the options are bound to `IConfiguration` and reloaded when changed.

The following sample demonstrates how a new `IOptionsSnapshot` is created after *config.json* changes. Requests to server will return the same time when *config.json* has **not** changed. The first request after *config.json* changes will show a new time.

[!code-csharp[Main](configuration/sample/IOptionsSnapshot2/Startup.cs?name=snippet1&highlight=1-9,13-18,32,33,52,53)]

The following image shows the server output:

![browser image showing "Last Updated: 11/22/2016 4:43 PM"](configuration/_static/first.png)

Refreshing the browser doesn't change the message value or time displayed (when *config.json* has not changed).

Change and save the  *config.json* and then refresh the browser:

![browser image showing "Last Updated to,e: 11/22/2016 4:53 PM"](configuration/_static/change.png)

## In-memory provider and binding to a POCO class

The following sample shows how to use the in-memory provider and bind to a class:

[!code-csharp[Main](configuration/sample/src/InMemory/Program.cs)]

[!code-csharp[Main](configuration/sample/src/InMemory/MyWindow.cs)]

Configuration values are returned as strings, but binding enables the construction of objects. Bindling allows you to retrieve POCO objects or even entire object graphs. The following sample shows how to bind to the `MyWindow` class and use the options pattern with a ASP.NET Core MVC app:

[!code-csharp[Main](configuration/sample/src/WebConfigBind/MyWindow.cs)]

[!code-json[Main](configuration/sample/src/WebConfigBind/appsettings.json)]

Bind the custom class in `ConfigureServices` in the `Startup` class:

[!code-csharp[Main](configuration/sample/src/WebConfigBind/Startup.cs?name=snippet1&highlight=3)]

Display the settings from the `HomeController`:

[!code-json[Main](configuration/sample/src/WebConfigBind/Controllers/HomeController.cs)]

  ### GetValue

The following sample demonstrates the `GetValue<T>` extension method:

[!code-json[Main](configuration/sample/src/InMemoryGetValue/Program.cs?highlight=25-27)]

The ConfigurationBinder’s `GetValue<T>` method allows you to specify a default value (80 in the sample). `GetValue<T>()` is for simple scenarios and does not bind to entire sections. `GetValue<T>()` gets scalar values from `GetSection(key).Value` converted to a specific type.

  ## Binding to an object graph

You can recursively bind to each object in a class. Consider the following `AppOptions` class:

[!code-json[Main](configuration/sample/src/ObjectGraph/AppOptions.cs)]

The following sample binds to the `AppOptions` class:

[!code-json[Main](configuration/sample/src/ObjectGraph/Program.cs?highlight=18-20)]

Using the following *appsettings.json* file:

[!code-json[Main](configuration/sample/src/ObjectGraph/appsettings.json)]

The program displays `Height 11`.

The following code can be used to unit test the configuration:

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "highlight_args": {}, "names": []} -->

````c#

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
   ````

<a name=custom-config-providers></a>

  ## Entity Framework custom provider

In this section we'll create a simple configuration provider that reads name-value pairs from a database using EF.

Define a `ConfigurationValue` entity for storing configuration values in the database:

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/CustomConfigurationProvider/ConfigurationValue.cs", "highlight_args": {"linenostart": 1}, "names": []} -->

````c#

   public class ConfigurationValue
   {
       public string Id { get; set; }
       public string Value { get; set; }
   }
   ````

Add a `ConfigurationContext` to store and access the configured values:

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/CustomConfigurationProvider/ConfigurationContext.cs", "highlight_args": {"linenostart": 1, "hl_lines": [7]}, "names": []} -->

````c#

   public class ConfigurationContext : DbContext
   {
       public ConfigurationContext(DbContextOptions options) : base(options)
       {
       }

       public DbSet<ConfigurationValue> Values { get; set; }
   }

   ````

Create an `EntityFrameworkConfigurationSource` that inherits from [IConfigurationSource](http://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/Extensions/Configuration/IConfigurationSource/index.html.md#Microsoft.Extensions.Configuration.IConfigurationSource.md):

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/CustomConfigurationProvider/EntityFrameworkConfigurationSource.cs", "highlight_args": {"linenostart": 1, "hl_lines": [7, 16, 17, 18, 19]}, "names": []} -->

````c#

   using System;
   using Microsoft.EntityFrameworkCore;
   using Microsoft.Extensions.Configuration;

   namespace CustomConfigurationProvider
   {
       public class EntityFrameworkConfigurationSource : IConfigurationSource
       {
           private readonly Action<DbContextOptionsBuilder> _optionsAction;

           public EntityFrameworkConfigurationSource(Action<DbContextOptionsBuilder> optionsAction)
           {
               _optionsAction = optionsAction;
           }

           public IConfigurationProvider Build(IConfigurationBuilder builder)
           {
               return new EntityFrameworkConfigurationProvider(_optionsAction);
           }
       }
   }
   ````

Create the custom configuration provider by inheriting from [ConfigurationProvider](http://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/Extensions/Configuration/ConfigurationProvider/index.html.md#Microsoft.Extensions.Configuration.ConfigurationProvider.md). The configuration data is loaded by overriding the `Load` method, which reads in all the configuration data from the configured database. For demonstration purposes, the configuration provider also takes care of initializing the database if it hasn't already been created and populated:

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/CustomConfigurationProvider/EntityFrameworkConfigurationProvider.cs", "highlight_args": {"linenostart": 1, "hl_lines": [9, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 37, 38]}, "names": []} -->

````c#

   using System;
   using System.Collections.Generic;
   using System.Linq;
   using Microsoft.EntityFrameworkCore;
   using Microsoft.Extensions.Configuration;

   namespace CustomConfigurationProvider
   {
       public class EntityFrameworkConfigurationProvider : ConfigurationProvider
       {
           public EntityFrameworkConfigurationProvider(Action<DbContextOptionsBuilder> optionsAction)
           {
               OptionsAction = optionsAction;
           }

           Action<DbContextOptionsBuilder> OptionsAction { get; }

           public override void Load()
           {
               var builder = new DbContextOptionsBuilder<ConfigurationContext>();
               OptionsAction(builder);

               using (var dbContext = new ConfigurationContext(builder.Options))
               {
                   dbContext.Database.EnsureCreated();
                   Data = !dbContext.Values.Any()
                       ? CreateAndSaveDefaultValues(dbContext)
                       : dbContext.Values.ToDictionary(c => c.Id, c => c.Value);
               }
           }

           private static IDictionary<string, string> CreateAndSaveDefaultValues(
               ConfigurationContext dbContext)
           {
               var configValues = new Dictionary<string, string>
                   {
                       { "key1", "value_from_ef_1" },
                       { "key2", "value_from_ef_2" }
                   };
               dbContext.Values.AddRange(configValues
                   .Select(kvp => new ConfigurationValue { Id = kvp.Key, Value = kvp.Value })
                   .ToArray());
               dbContext.SaveChanges();
               return configValues;
           }
       }
   }

   ````

Note the values that are being stored in the database ("value_from_ef_1" and "value_from_ef_2"); these are displayed in the sample below to demonstrate the configuration is reading values from the DB.

You can also add an `AddEntityFrameworkConfiguration` extension method for adding the configuration source:

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/CustomConfigurationProvider/EntityFrameworkExtensions.cs", "highlight_args": {"linenostart": 1, "hl_lines": [9]}, "names": []} -->

````c#

   using System;
   using Microsoft.EntityFrameworkCore;
   using Microsoft.Extensions.Configuration;

   namespace CustomConfigurationProvider
   {
       public static class EntityFrameworkExtensions
       {
           public static IConfigurationBuilder AddEntityFrameworkConfig(
               this IConfigurationBuilder builder, Action<DbContextOptionsBuilder> setup)
           {
               return builder.Add(new EntityFrameworkConfigurationSource(setup));
           }
       }
   }
   ````

Create a [ConfigurationBuilder](http://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/Extensions/Configuration/ConfigurationBuilder/index.html.md#Microsoft.Extensions.Configuration.ConfigurationBuilder.md) to set up your configuration sources. To add the `EntityFrameworkConfigurationProvider`, specify the EF data provider and connection string. How should you configure the connection string? Using configuration of course! Add an *appsettings.json* file as a configuration source to bootstrap setting up the `EntityFrameworkConfigurationProvider`. Note the sample adds the custom `EntityFrameworkConfigurationProvider` after the JSON provider, so any settings in the database will override settings in *appsettings.json*:

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/CustomConfigurationProvider/Program.cs", "highlight_args": {"linenostart": 1, "hl_lines": [19, 20, 21, 22, 23]}, "names": []} -->

````c#

   using System;
   using System.IO;
   using Microsoft.EntityFrameworkCore;
   using Microsoft.Extensions.Configuration;
   using CustomConfigurationProvider;

   public static class Program
   {
       public static void Main()
       {
           var builder = new ConfigurationBuilder();
           builder.SetBasePath(Directory.GetCurrentDirectory());
           builder.AddJsonFile("appsettings.json");
           var connectionStringConfig = builder.Build();

           // Chain calls together as a fluent API.
           var config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .AddEntityFrameworkConfig(options =>
                   options.UseSqlServer(connectionStringConfig.GetConnectionString(
                       "DefaultConnection"))
               )
               .Build();

           Console.WriteLine("key1={0}", config["key1"]);
           Console.WriteLine("key2={0}", config["key2"]);
           Console.WriteLine("key3={0}", config["key3"]);
       }
   }

   ````

Using the following *appsettings.json* file:

<!-- literal_block {"xml:space": "preserve", "language": "json", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/CustomConfigurationProvider/appsettings.json", "highlight_args": {"linenostart": 1}, "names": []} -->

````json

   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=CustomConfigurationProvider;Trusted_Connection=True;MultipleActiveResultSets=true"
     },
     "key1": "value_from_json_1",
     "key2": "value_from_json_2",
     "key3": "value_from_json_3"
   }

   ````

The following displayed:

<!-- literal_block {"xml:space": "preserve", "dupnames": [], "classes": [], "ids": [], "backrefs": [], "names": []} -->

````

   key1=value_from_ef_1
   key2=value_from_ef_2
   key3=value_from_json_3
   ````

  ## CommandLine configuration provider

The following sample enables the CommandLine configuration provider last:

<!-- literal_block {"xml:space": "preserve", "language": "none", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/CommandLine/Program.cs", "highlight_args": {"linenostart": 1}, "names": []} -->

````none

   using Microsoft.Extensions.Configuration;
   using System;
   using System.Collections.Generic;
   using System.Linq;

   // Add NuGet  <package id="Microsoft.Extensions.Configuration.Binder"
   public class Program
   {
       static public IConfigurationRoot Configuration { get; set; }

       static public Dictionary<string, string> GetSwitchMappings(
       IReadOnlyDictionary<string, string> configurationStrings)
       {
           return configurationStrings.Select(item =>
               new KeyValuePair<string, string>(
                   "-" + item.Key.Substring(item.Key.LastIndexOf(':') + 1),
                   item.Key))
                   .ToDictionary(
                       item => item.Key, item => item.Value);
       }
       public static void Main(string[] args = null)
       {
           var dict = new Dictionary<string, string>
               {
                   {"Profile:MachineName", "Rick"},
                   {"App:MainWindow:Left", "11"}
               };

           var builder = new ConfigurationBuilder();
           builder.AddInMemoryCollection(dict)
                 .AddCommandLine(args, GetSwitchMappings(dict));
           Configuration = builder.Build();
           Console.WriteLine($"Hello {Configuration["Profile:MachineName"]}");

           // Set the default value to 80
           var left = Configuration.GetValue<int>("App:MainWindow:Left", 80);
           Console.WriteLine($"Left {left}");
       }
   }
   ````

Use the following to pass in configuration settings:

<!-- literal_block {"xml:space": "preserve", "dupnames": [], "classes": [], "ids": [], "backrefs": [], "names": []} -->

````

   dotnet run /Profile:MachineName=Bob /App:MainWindow:Left=1234
   ````

Which displays:

<!-- literal_block {"xml:space": "preserve", "dupnames": [], "classes": [], "ids": [], "backrefs": [], "names": []} -->

````

   Hello Bob
   Left 1234
   ````

The `GetSwitchMappings` method allows you to use `-` rather than `/` and it strips the leading subkey prefixes. For example:

<!-- literal_block {"xml:space": "preserve", "dupnames": [], "classes": [], "ids": [], "backrefs": [], "names": []} -->

````

   dotnet run -MachineName=Bob -Left=7734
   ````

Displays:

<!-- literal_block {"xml:space": "preserve", "dupnames": [], "classes": [], "ids": [], "backrefs": [], "names": []} -->

````

   Hello Bob
   Left 7734
   ````

Command-line arguments must include a value (it can be null). For example:

<!-- literal_block {"xml:space": "preserve", "dupnames": [], "classes": [], "ids": [], "backrefs": [], "names": []} -->

````

   dotnet run /Profile:MachineName=
   ````

Is OK, but

<!-- literal_block {"xml:space": "preserve", "dupnames": [], "classes": [], "ids": [], "backrefs": [], "names": []} -->

````

   dotnet run /Profile:MachineName
   ````

results in an exception. An exception will be thrown if you specify a command-line switch prefix of - or -- for which there’s no corresponding switch mapping.

  ## The *web.config* file

*web.config* is required when you host the app in IIS or IIS-Express. It turns on the AspNetCoreModule in IIS to launch your app. It may also be used to configure other IIS settings and modules.If you are using Visual Studio and delete *web.config*, Visual Studio will create a new one.

  ### Additional notes

* Dependency Injection (DI) is not setup until after `ConfigureServices` is invoked and the configuration system is not DI aware

* `IConfiguration` has two specializations:

  * `IConfigurationRoot`  Used for the root node. Can trigger a reload.

  * `IConfigurationSection`  Represents a section of configuration values. The `GetSection` and `GetChildren` methods return an `IConfigurationSection`

  ### Additional Resources

* [Working with Multiple Environments](environments.md)

* [Safe storage of app secrets during development](../security/app-secrets.md)

* [Dependency Injection](dependency-injection.md)
