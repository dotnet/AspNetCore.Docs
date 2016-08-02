.. _web-api-help-pages-using-swagger:

ASP.NET Web API Help Pages using Swagger
========================================

By `Shayne Boyer`_

Understanding the various methods of an API can be a challenge for a developer when building a consuming application. 

Generating good documentation and help pages as a part of your Web API using `Swagger <a href="http://swagger.io/">`_ with the .NET Core implementation `Swashbuckle <a href="https://github.com/domaindrivendev/Ahoy">`_ is as easy as adding a couple of nuget packages and modifying the Startup.cs.

This tutorial builds on the sample on :doc:`first-web-api`. 

.. contents:: Sections:
  :local:
  :depth: 1

Getting Started
---------------
There are 2 core components to Swashbuckle 

- Swashbuckle.SwaggerGen - provides the functionality to scaffold your Web API and generate JSON Swagger documents that describe the objects, methods, return types, etc. 
- Swashbuckle.SwaggerUI - an embedded version of the Swagger UI tool which uses the above documents for a rich customizable experience for describing the Web API functionality. This also includes built in test harness capabilities for the public methods.

NuGet Packages
''''''''''''''

Getting the core components added to the project via nuget can be done using either the PowerShell command,

.. code-block:: bash

    Install=Package Swashbuckle -Pre

modifying the package.json file directly, adding the package to the dependencies node

.. code-block:: javascript
   :emphasize-lines: 17

    "dependencies": {
      "Microsoft.NETCore.App": {
        "version": "1.0.0",
        "type": "platform"
      },
      "Microsoft.ApplicationInsights.AspNetCore": "1.0.0",
      "Microsoft.AspNetCore.Mvc": "1.0.0",
      "Microsoft.AspNetCore.Server.IISIntegration": "1.0.0",
      "Microsoft.AspNetCore.Server.Kestrel": "1.0.0",
      "Microsoft.Extensions.Configuration.EnvironmentVariables": "1.0.0",
      "Microsoft.Extensions.Configuration.FileExtensions": "1.0.0",
      "Microsoft.Extensions.Configuration.Json": "1.0.0",
      "Microsoft.Extensions.Logging": "1.0.0",
      "Microsoft.Extensions.Logging.Console": "1.0.0",
      "Microsoft.Extensions.Logging.Debug": "1.0.0",
      "Microsoft.Extensions.Options.ConfigurationExtensions": "1.0.0",
      "Swashbuckle": "6.0.0-beta901"

or by right clicking the references folder and selecting "Manage NuGet Packages",

.. image:: web-api-help-pages-using-swagger/_static/manage-nuget-packages.png

and searching for "Swashbuckle". Be sure to select the "Include Pre-Release" to get the latest version while in beta.

.. image:: web-api-help-pages-using-swagger/_static/add-swagger.png


Adding Middleware
'''''''''''''''''

After adding the NuGet package to the project, the Startup.cs class needs to modified for the Swagger components to available for use.

First, add SwaggerGen to the services collection in the Configure method.

.. code-block:: c#
   :emphasize-lines: 12

    public void ConfigureServices(IServiceCollection services)
    {
        // Add framework services.
        services.AddMvc();

        services.AddLogging();

        // Add our repository type
        services.AddSingleton<ITodoRepository, TodoRepository>();

        // Inject an implementation of ISwaggerProvider with defaulted settings applied
        services.AddSwaggerGen();
    }

Next, in the Configure method, enable the middleware for serving generated JSON document and the SwaggerUI. 

.. code-block:: c#
   :emphasize-lines: 6,9

    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
        app.UseMvcWithDefaultRoute();

        // Enable middleware to serve generated Swagger as a JSON endpoint
        app.UseSwagger();

        // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
        app.UseSwaggerUi();
        
    }

In Visual Studio, press ^F5 to launch the app and navigate to ``http://localhost:<random_port>/swagger/v1/swagger.json`` to see the document generated that describes the ``todo`` API endpoint.

.. note:: Microsoft Edge, Google Chrome and Firefox display JSON documents natively.  There are extensions for Chrome that will format the document for easier reading.

.. code-block:: javascript



Basic Example
-------------



Test
'''''


