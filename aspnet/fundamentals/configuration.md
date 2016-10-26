---
title: Configuration
author: rick-anderson
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: f9bdbef5-e8a4-4e8d-a499-e59f30967995
ms.prod: aspnet-core
uid: fundamentals/configuration
---
<a name=fundamentals-configuration></a>

  # Configuration

[Rick Anderson](https://twitter.com/RickAndMSFT), [Mark Michaelis](http://intellitect.com/author/mark-michaelis/), [Steve Smith](http://ardalis.com), [Daniel Roth](https://github.com/danroth27)

The configuration API reads lists of name-value pairs, which can be grouped into a multi-level hierarchy. There are configuration providers for file formats (INI, JSON, and XML), command-line arguments, environment variables, in-memory .NET objects, an encrypted user store, and custom providers you install or create. Each configuration value maps to a string key, and there’s built-in binding support to deserialize settings into a custom POCO object (.NET class).

[View or download sample code](https://github.com/aspnet/docs/tree/master/aspnet/fundamentals/configuration/sample)

  ## Simple configuration

The following console app uses the JSON configuration provider:

<!-- literal_block {"xml:space": "preserve", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/ConfigJson/Program.cs", "highlight_args": {"linenostart": 1}, "names": []} -->

````

   using Microsoft.Extensions.Configuration;
   using System;
   using System.IO;

   // Add NuGet <package id="Microsoft.Extensions.Configuration" and
   // <package id="Microsoft.Extensions.Configuration.Json"
   public class Program
   {
       static public IConfigurationRoot Configuration { get; set; }
       public static void Main(string[] args = null)
       {
           var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
               // .Net 4.X requires parent.parent directory.
               //.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), @"..\.."))
               .AddJsonFile("appsettings.json");

           Configuration = builder.Build();

           Console.WriteLine($"option1 = {Configuration["option1"]}");
           Console.WriteLine($"option2 = {Configuration["option2"]}");
           Console.WriteLine(
               $"option1 = {Configuration["subsection:suboption1"]}");
       }
   }
   ````

The app reads and displays the following configuration settings:

<!-- literal_block {"xml:space": "preserve", "language": "json", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/ConfigJson/appsettings.json", "highlight_args": {"linenostart": 1}, "names": []} -->

````json

   {
     "option1": "value1_from_json",
     "option2": 2,

     "subsection": {
       "suboption1": "subvalue1_from_json"
     }
   }
   ````

Configuration consists of a hierarchical list of name-value pairs in which the nodes are separated by a colon. To retrieve a particular value, you access the `Configuration` indexer with the corresponding item’s key:

<!-- literal_block {"xml:space": "preserve", "dupnames": [], "classes": [], "ids": [], "backrefs": [], "names": []} -->

````

   Console.WriteLine(
     $"option1 = {Configuration["subsection:suboption1"]}");
   ````

Name/value pairs written to the built in `Configuration` providers are **not** persisted, however, you can create a custom provider that saves values. See [custom configuration provider](xref:fundamentals/configuration#custom-config-providers).

The sample above uses the configuration indexer to read values. In ASP.NET Core applications, we recommend you use the [options pattern](xref:fundamentals/configuration#options-config-objects) rather than the indexer to read configuration values. We'll demonstrate that later in this document.

It's typical to have different configuration settings for different environments, for example, development, test and production. The following highlighted code hooks up two configuration providers to three sources:

1. JSON provider, reading *appsettings.json*

2. JSON provider, reading *appsettings.<EnvironmentName>.json*

3. Environment variables provider

<!-- literal_block {"xml:space": "preserve", "language": "none", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/UsingOptions/Startup4.cs", "highlight_args": {"linenostart": 1, "hl_lines": [5, 6, 7]}, "names": []} -->

````none

   public Startup(IHostingEnvironment env)
   {
       var builder = new ConfigurationBuilder()
           .SetBasePath(env.ContentRootPath)
           .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
           .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
           .AddEnvironmentVariables();
       Configuration = builder.Build();
   }

   ````

See [AddJsonFile](http://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/Extensions/Configuration/JsonConfigurationExtensions/index.html.md#Microsoft.Extensions.Configuration.JsonConfigurationExtensions.AddJsonFile.md) for an explanation of the parameters. Configuration sources are read in the order they are specified. In the code above, the environment variables are read last, any configuration values set through the environment would replace those set in the two previous providers.

The environment is typically set to one of `Development`, `Staging`, or `Production`. See [Working with Multiple Environments](environments.md) for more information.

Configuration considerations:

* The built in configuration providers are not refreshed when the configuration data changes. If your configuration data changes, you'll need to restart your app to get the new data

* Configuration keys are case insensitive

* A best practice is to specify environment variables last, so that the local environment can override anything set in deployed configuration files

* **Never** store passwords or other sensitive data in configuration provider code or in plain text configuration files. You also shouldn't use production secrets in your development or test environments. Instead, such secrets should be specified outside the project tree, so they cannot be accidentally committed into your repository. Learn more about [Working with Multiple Environments](environments.md) and managing [Safe storage of app secrets during development](../security/app-secrets.md).

* To override nested keys through environment variables in shells that don't support `:` in variable names, replace `:`  with `__` (double underscore)

<a name=options-config-objects></a>

  ## Using Options and configuration objects

The options pattern uses custom options classes to represent a group of related settings. We recommended that you create decoupled classes for each feature within your app. Decoupled classes follow:

* The [Interface Segregation Principle (ISP)](http://deviq.com/interface-segregation-principle/) : Classes depend only on the configuration settings they use.

* [Separation of Concerns](http://deviq.com/separation-of-concerns/) : Settings for disparate parts of your app are managed separately, and not dependent on or coupled with one another.

The options class must be non-abstract with a public parameterless constructor. For example:

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/UsingOptions/Models/MyOptions.cs", "highlight_args": {"linenostart": 1}, "names": []} -->

````c#

   public class MyOptions
   {
       public MyOptions()
       {
           // Set default value.
           Option1 = "value1_from_ctor";
       }
       public string Option1 { get; set; }
       public int Option2 { get; set; } = 5;
   }
   ````

<a name=options-example></a>

In the following code, the JSON configuration provider is enabled and `MyOptions` class is added to the service container. The `MyOptions` class is bound to configuration.

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/UsingOptions/Startup.cs", "highlight_args": {"linenostart": 1, "hl_lines": [5, 6, 7, 8, 10, 13, 15, 17, 18, 20, 21]}, "names": []} -->

````c#

   public class Startup
   {
       public Startup(IHostingEnvironment env)
       {
           // Set up configuration sources.
           var builder = new ConfigurationBuilder()
               .SetBasePath(env.ContentRootPath)
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

           Configuration = builder.Build();
       }

       public IConfigurationRoot Configuration { get; set; }

       public void ConfigureServices(IServiceCollection services)
       {
           // Adds services required for using options.
           services.AddOptions();

           // Register the ConfigurationBuilder instance which MyOptions binds against.
           services.Configure<MyOptions>(Configuration);

           // Add framework services.
           services.AddMvc();
       }

   ````

The following [controller](../mvc/controllers/index.md)  uses [Dependency Injection](dependency-injection.md) on [IOptions<TOptions>](http://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/Extensions/Options/IOptions-TOptions/index.html.md#Microsoft.Extensions.Options.IOptions<TOptions>.md) to access settings:

<!-- literal_block {"xml:space": "preserve", "language": "none", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/UsingOptions/Controllers/HomeController.cs", "highlight_args": {"linenostart": 1}, "names": []} -->

````none

   public class HomeController : Controller
   {
       private readonly MyOptions _optionsAccessor;

       public HomeController(IOptions<MyOptions> optionsAccessor)
       {
           _optionsAccessor = optionsAccessor.Value;
       }

       public IActionResult Index()
       {
           var option1 = _optionsAccessor.Option1;
           var option2 = _optionsAccessor.Option2;
           return Content($"option1 = {option1}, option2 = {option2}");
       }
   }

   ````

With the following *appsettings.json* file:

<!-- literal_block {"xml:space": "preserve", "language": "json", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/UsingOptions/appsettings1.json", "highlight_args": {"linenostart": 1}, "names": []} -->

````json

   {
     "option1": "value1_from_json",
     "option2": 2
   }

   ````

The `HomeController.Index` method returns `option1 = value1_from_json, option2 = 2`.

In the following code, a second [IConfigureOptions<TOptions>](http://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/Extensions/Options/IConfigureOptions-TOptions/index.html.md#Microsoft.Extensions.Options.IConfigureOptions<TOptions>.md) service is added to the service container. It uses a delegate to configure the binding with `MyOptions`.

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/UsingOptions/Startup2.cs", "highlight_args": {"linenostart": 1, "hl_lines": [9, 10, 11, 12, 13]}, "names": []} -->

````c#

   public void ConfigureServices(IServiceCollection services)
   {
       // Adds services required for using options.
       services.AddOptions();

       // Register the ConfigurationBuilder instance which MyOptions binds against.
       services.Configure<MyOptions>(Configuration);

       // Registers the following lambda used to configure options.
       services.Configure<MyOptions>( myOptions =>
       {
           myOptions.Option1 = "value1_from_action";
       });

       // Add framework services.
       services.AddMvc();
   }

   ````

You can add multiple configuration providers. Configuration providers are available in NuGet packages. They are applied in order they are registered. Each call to [Configure<TOptions>](http://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/Extensions/DependencyInjection/OptionsServiceCollectionExtensions/index.html.md#Microsoft.Extensions.DependencyInjection.OptionsServiceCollectionExtensions.Configure<TOptions>.md) adds an [IConfigureOptions<TOptions>](http://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/Extensions/Options/IConfigureOptions-TOptions/index.html.md#Microsoft.Extensions.Options.IConfigureOptions<TOptions>.md) service to the service container. In the example above, the values of `Option1` and `Option2` are both specified in *appsettings.json*, but the value of `Option1` is overridden by the configured delegate in the highlighted code above. When more than one configuration service is enabled, the last configuration source specified “wins”. With the code
above, the `HomeController.Index` method returns `option1 = value1_from_action, option2 = 2`.

When you bind options to configuration, each property in your options type is bound to a configuration key of the form `property[:sub-property:]`. For example, the `MyOptions.Option1` property is bound to the key `Option1`, which is read from the `option1` property in *appsettings.json*. A sub-property sample is shown later in this article.

In the following code, a third [IConfigureOptions<TOptions>](http://docs.asp.net/projects/api/en/latest/autoapi/Microsoft/Extensions/Options/IConfigureOptions-TOptions/index.html.md#Microsoft.Extensions.Options.IConfigureOptions<TOptions>.md) service is added to the service container. It binds `MySubOptions` to the section `subsection` of the *appsettings.json* file:

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/UsingOptions/Startup3.cs", "highlight_args": {"linenostart": 1, "hl_lines": [15, 16]}, "names": []} -->

````c#

   public void ConfigureServices(IServiceCollection services)
   {
       // Adds services required for using options.
       services.AddOptions();

       // Configure with Microsoft.Extensions.Options.ConfigurationExtensions
       services.Configure<MyOptions>(Configuration);

       // Configure MyOptions using code.
       services.Configure<MyOptions>(myOptions =>
       {
           myOptions.Option1 = "value1_from_action";
       });

       // Configure using a sub-section of the appsettings.json file.
       services.Configure<MySubOptions>(Configuration.GetSection("subsection"));

       // Add framework services.
       services.AddMvc();
   }
   on
   // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
   public void Configure(IApplicationBuilder app,
       ILoggerFactory loggerFactory)
   {
       loggerFactory.AddConsole();

       app.UseDeveloperExceptionPage();
       app.UseMvcWithDefaultRoute();
   }



   ````

Using the following *appsettings.json* file:

<!-- literal_block {"xml:space": "preserve", "language": "json", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/UsingOptions/appsettings.json", "highlight_args": {"linenostart": 1}, "names": []} -->

````json

   {
     "option1": "value1_from_json-xx",
     "option2": -1,

     "subsection": {
   	  "suboption1": "subvalue1_from_json",
   	  "suboption2": 200
     }
   }

   ````

The `MySubOptions` class:

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/UsingOptions/Models/MySubOptions.cs", "highlight_args": {"linenostart": 1}, "names": []} -->

````c#

   public class MySubOptions
   {
       public MySubOptions()
       {
           // Set default values.
           SubOption1 = "value1_from_ctor";
           SubOption2 = 5;
       }
       public string SubOption1 { get; set; }
       public int SubOption2 { get; set; }
   }

   ````

With the following `Controller`:

<!-- literal_block {"xml:space": "preserve", "language": "none", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/UsingOptions/Controllers/HomeController2.cs", "highlight_args": {"linenostart": 1}, "names": []} -->

````none

   public class HomeController : Controller
   {
       private readonly MySubOptions _subOptionsAccessor;

       public HomeController(IOptions<MySubOptions> subOptionsAccessor)
       {
           _subOptionsAccessor = subOptionsAccessor.Value;
       }

       public IActionResult Index()
       {
           var subOption1 = _subOptionsAccessor.SubOption1;
           var subOption2 = _subOptionsAccessor.SubOption2;
           return Content($"subOption1 = {subOption1}, subOption2 = {subOption2}");
       }
   }

   ````

`subOption1 = subvalue1_from_json, subOption2 = 200` is returned.

<a name=in-memory-provider></a>

  ## In-memory provider and binding to a POCO class

The following sample shows how to use the in-memory provider and bind to a class:

<!-- literal_block {"xml:space": "preserve", "language": "none", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/InMemory/Program.cs", "highlight_args": {"linenostart": 1}, "names": []} -->

````none

   using Microsoft.Extensions.Configuration;
   using System;
   using System.Collections.Generic;

   // Add NuGet  <package id="Microsoft.Extensions.Configuration.Binder"
   public class Program
   {   
       static public IConfigurationRoot Configuration { get; set; }
       public static void Main(string[] args = null)
       {
           var dict = new Dictionary<string, string>
               {
                   {"Profile:MachineName", "Rick"},
                   {"App:MainWindow:Height", "11"},
                   {"App:MainWindow:Width", "11"},
                   {"App:MainWindow:Top", "11"},
                   {"App:MainWindow:Left", "11"}
               };

           var builder = new ConfigurationBuilder();
           builder.AddInMemoryCollection(dict);
           Configuration = builder.Build();
           Console.WriteLine($"Hello {Configuration["Profile:MachineName"]}");

           var window = new MyWindow();
           Configuration.GetSection("App:MainWindow").Bind(window);
           Console.WriteLine($"Left {window.Left}");
       }
   }
   ````

<!-- literal_block {"xml:space": "preserve", "language": "none", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/InMemory/MyWindow.cs", "highlight_args": {"linenostart": 1}, "names": []} -->

````none

   public class MyWindow
   {
       public int Height { get; set; }
       public int Width { get; set; }
       public int Top { get; set; }
       public int Left { get; set; }
   }
   ````

Configuration values are not limited to scalars. You can retrieve POCO objects or even entire object graphs. The following sample shows how to bind to the `MyWindow` class and use the options pattern with a ASP.NET Core MVC app:

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/WebConfigBind/MyWindow.cs", "highlight_args": {"linenostart": 1}, "names": []} -->

````c#

   public class MyWindow
   {
       public int Height { get; set; }
       public int Width { get; set; }
       public int Top { get; set; }
       public int Left { get; set; }
   }
   ````

<!-- literal_block {"xml:space": "preserve", "language": "json", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/WebConfigBind/appsettings.json", "highlight_args": {"linenostart": 1}, "names": []} -->

````json

   {
     "AppConfiguration": {
       "MainWindow": {
         "Height": "400",
         "Width": "600",
         "Top": "5",
         "Left": "11"
       }
     }
   }

   ````

Bind the custom class in `ConfigureServices` in the `Startup` class:

<!-- literal_block {"xml:space": "preserve", "language": "none", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/WebConfigBind/Startup.cs", "highlight_args": {"linenostart": 1}, "names": []} -->

````none

   public void ConfigureServices(IServiceCollection services)
   {
       services.Configure<MyWindow>(options => 
           Configuration.GetSection("AppConfiguration:MainWindow").Bind(options));
       services.AddMvc();
   }

   ````

Display the settings from the `HomeController`:

<!-- literal_block {"xml:space": "preserve", "language": "none", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/WebConfigBind/Controllers/HomeController.cs", "highlight_args": {"linenostart": 1}, "names": []} -->

````none

   using Microsoft.AspNetCore.Mvc;
   using Microsoft.Extensions.Options;

   public class HomeController : Controller
   {
       private readonly IOptions<MyWindow> _optionsAccessor;

       public HomeController(IOptions<MyWindow> optionsAccessor)
       {
           _optionsAccessor = optionsAccessor;
       }
       public IActionResult Index()
       {
           var height = _optionsAccessor.Value.Height;
           var width = _optionsAccessor.Value.Width;
           var left = _optionsAccessor.Value.Left;
           var top = _optionsAccessor.Value.Top;

           return Content($"height = {height}, width = {width}, "
                        + $"Left = {left}, Top = {top}");
       }
   }
   ````

<a name=custom-config-providers></a>

  ### GetValue

The following sample demonstrates the `GetValue<T>` extension method:

<!-- literal_block {"xml:space": "preserve", "language": "none", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/InMemoryGetValue/Program.cs", "highlight_args": {"linenostart": 1, "hl_lines": [25, 26, 27, 28, 29]}, "names": []} -->

````none

   using Microsoft.Extensions.Configuration;
   using System;
   using System.Collections.Generic;

   // Add NuGet  <package id="Microsoft.Extensions.Configuration.Binder"
   public class Program
   {   
       static public IConfigurationRoot Configuration { get; set; }
       public static void Main(string[] args = null)
       {
           var dict = new Dictionary<string, string>
               {
                   {"Profile:MachineName", "Rick"},
                   {"App:MainWindow:Height", "11"},
                   {"App:MainWindow:Width", "11"},
                   {"App:MainWindow:Top", "11"},
                   {"App:MainWindow:Left", "11"}
               };

           var builder = new ConfigurationBuilder();
           builder.AddInMemoryCollection(dict);
           Configuration = builder.Build();
           Console.WriteLine($"Hello {Configuration["Profile:MachineName"]}");

           // Show GetValue overload and set the default value to 80
           // You typically would set default values in the constructor.
           // Requires NuGet package "Microsoft.Extensions.Configuration.Binder"
           var left = Configuration.GetValue<int>("App:MainWindow:Left", 80);
           Console.WriteLine($"Left {left}");

           var window = new MyWindow();
           Configuration.GetSection("App:MainWindow").Bind(window);
           Console.WriteLine($"Left {window.Left}");
       }
   }
   ````

The ConfigurationBinder’s `GetValue<T>`  method allows you to specify a default value (80 in the sample). Default values are more easily set in the class constructor. `GetValue` is basically just syntax sugar for `GetSection(<key>).TypeConverter.Convert<T>`, it's not doing any binding.

  ## Binding to an object graph

You can recursively bind to each object in a class. Consider the following `AppOptions` class:

<!-- literal_block {"xml:space": "preserve", "language": "c#", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/ObjectGraph/AppOptions.cs", "highlight_args": {"linenostart": 1}, "names": []} -->

````c#

   public class AppOptions
   {
       public Window Window { get; set; }
       public Connection Connection { get; set; }
       public Profile Profile { get; set; }
   }

   public class Window
   {
       public int Height { get; set; }
       public int Width { get; set; }
   }

   public class Connection
   {
       public string Value { get; set; }
   }

   public class Profile
   {
       public string Machine { get; set; }
   }

   ````

The following sample binds to the `AppOptions` class:

<!-- literal_block {"xml:space": "preserve", "language": "none", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/ObjectGraph/Program.cs", "highlight_args": {"linenostart": 1}, "names": []} -->

````none

   using Microsoft.Extensions.Configuration;
   using System;
   using System.IO;

   // Add these NuGet packages:
   // "Microsoft.Extensions.Configuration.Binder"
   // "Microsoft.Extensions.Configuration.FileExtensions"
   // "Microsoft.Extensions.Configuration.Json": 
   public class Program
   {
       public static void Main(string[] args = null)
       {
           var builder = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json");

           var config = builder.Build();

           var appConfig = new AppOptions();
           config.GetSection("App").Bind(appConfig);

           Console.WriteLine($"Height {appConfig.Window.Height}");
       }
   }

   ````

Using the following *appsettings.json* file:

<!-- literal_block {"xml:space": "preserve", "language": "json", "dupnames": [], "linenos": false, "classes": [], "ids": [], "backrefs": [], "source": "/Users/shirhatti/src/Docs/aspnet/fundamentals/configuration/sample/src/ObjectGraph/appsettings.json", "highlight_args": {"linenostart": 1}, "names": []} -->

````json

   {
     "App": {
       "Profile": {
         "Machine": "Rick"
       },
       "Connection": {
         "Value": "connectionstring"
       },
       "Window": {
         "Height": "11",
         "Width": "11"
       }
     }
   }
   ````

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
