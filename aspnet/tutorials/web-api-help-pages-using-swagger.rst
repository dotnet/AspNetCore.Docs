.. _web-api-help-pages-using-swagger:

ASP.NET Web API Help Pages using Swagger
========================================

By `Shayne Boyer`_

Understanding the various methods of an API can be a challenge for a developer when building a consuming application. 

Generating good documentation and help pages as a part of your Web API using `Swagger <a href="http://swagger.io/">`_ with the .NET Core implementation `Swashbuckle <a href="https://github.com/domaindrivendev/Ahoy">`_ is as easy as adding a couple of nuget packages and modifying the Startup.cs.

This tutorial builds on the sample on :doc:`first-web-api`. 

.. contents:: Sections:
  :local:
  :depth: 2

Getting Started
---------------
There are 2 core components to Swashbuckle 

- Swashbuckle.SwaggerGen - provides the functionality to scaffold your Web API and generate JSON Swagger documents that describe the objects, methods, return types, etc. 
- Swashbuckle.SwaggerUI - an embedded version of the Swagger UI tool which uses the above documents for a rich customizable experience for describing the Web API functionality. This also includes built in test harness capabilities for the public methods.

NuGet Packages
--------------

Getting the core components added to the project via nuget can be done using either the PowerShell command, modifying the package.json file directly, adding the package to the dependencies node, or by right clicking the references folder and selecting "Manage NuGet Packages" and searching for "Swashbuckle". Be sure to select the "Include Pre-Release" to get the latest version while in beta.

*Install using NuGet*

.. code-block:: bash

    Install=Package Swashbuckle -Pre
    
*Install by modifying project.json*

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


*Install via Manage NuGet Packages*

.. image:: web-api-help-pages-using-swagger/_static/manage-nuget-packages.png


*Manage NuGet Packages Tab*

.. image:: web-api-help-pages-using-swagger/_static/add-swagger.png


Adding Middleware
-----------------

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

In Visual Studio, press ^F5 to launch the app and navigate to ``http://localhost:<random_port>/swagger/v1/swagger.json`` to see the document generated that describes the endpoints.

.. note:: Microsoft Edge, Google Chrome and Firefox display JSON documents natively.  There are extensions for Chrome that will format the document for easier reading.

.. code-block:: javascript

    {
    "swagger": "2.0",
    "info": {
        "version": "v1",
        "title": "API V1"
    },
    "basePath": "/",
    "paths": {
        "/api/Todo": {
        "get": {
            "tags": [
            "Todo"
            ],
            "operationId": "ApiTodoGet",
            "consumes": [],
            "produces": [
            "text/plain",
            "application/json",
            "text/json"
            ],
            "responses": {
            "200": {
                "description": "OK",
                "schema": {
                "type": "array",
                "items": {
                    "$ref": "#/definitions/TodoItem"
                }
                }
            }
            },
            "deprecated": false
        },
        "post": {
            "tags": [
            "Todo"
            ],
            "operationId": "ApiTodoPost",
            "consumes": [
            "application/json",
            "text/json",
            "application/json-patch+json"
            ],
            "produces": [],
            "parameters": [
            {
                "name": "item",
                "in": "body",
                "required": false,
                "schema": {
                "$ref": "#/definitions/TodoItem"
                }
            }
            ],
            "responses": {
            "204": {
                "description": "No Content"
            }
            },
            "deprecated": false
        }
        },
        "/api/Todo/{id}": {
        "get": {
            "tags": [
            "Todo"
            ],
            "operationId": "ApiTodoByIdGet",
            "consumes": [],
            "produces": [],
            "parameters": [
            {
                "name": "id",
                "in": "path",
                "required": true,
                "type": "string"
            }
            ],
            "responses": {
            "204": {
                "description": "No Content"
            }
            },
            "deprecated": false
        },
        "put": {
            "tags": [
            "Todo"
            ],
            "operationId": "ApiTodoByIdPut",
            "consumes": [
            "application/json",
            "text/json",
            "application/json-patch+json"
            ],
            "produces": [],
            "parameters": [
            {
                "name": "id",
                "in": "path",
                "required": true,
                "type": "string"
            },
            {
                "name": "item",
                "in": "body",
                "required": false,
                "schema": {
                "$ref": "#/definitions/TodoItem"
                }
            }
            ],
            "responses": {
            "204": {
                "description": "No Content"
            }
            },
            "deprecated": false
        },
        "delete": {
            "tags": [
            "Todo"
            ],
            "operationId": "ApiTodoByIdDelete",
            "consumes": [],
            "produces": [],
            "parameters": [
            {
                "name": "id",
                "in": "path",
                "required": true,
                "type": "string"
            }
            ],
            "responses": {
            "204": {
                "description": "No Content"
            }
            },
            "deprecated": false
        }
        }
    },
    "definitions": {
        "TodoItem": {
        "type": "object",
        "properties": {
            "key": {
            "type": "string"
            },
            "name": {
            "type": "string"
            },
            "isComplete": {
            "type": "boolean"
            }
        }
        }
    },
    "securityDefinitions": {}
    }

This document is used to drive the Swagger UI which can be viewed by navigating to ``http://localhost:<random_port>/swagger/ui``

.. image:: web-api-help-pages-using-swagger/_static/swagger-ui.png

Each of the methods in the ``ToDo`` controller can be tested using the UI be clicking the method to expand the section, completing the parameters (if required) and clicking the "Try it out!" button to see the result.

.. image:: web-api-help-pages-using-swagger/_static/get-try-it-out.png

At this point, the basic implementation of the Swagger functionality is complete. However, there are many configuration and extensibility options available beyond the defaults. See below for more information.

Customization & Extensibility 
-----------------------------
Swagger is not only a simple way to represent the API, but has options for documenting the object model, supporting multiple versions, as well as customizing the interactive UI to match your look and feel or design language.

API Info and Description
''''''''''''''''''''''''
For adding additional information such as the author, license, description etc.; use the ``Swashbuckle.Swagger.Model.Info`` class and use the ``.ConfigureSwaggerGen()`` method.

.. code-block:: c#

    // Inject an implementation of ISwaggerProvider with defaulted settings applied
    services.AddSwaggerGen();
    
    // Add the detail Info for the API
    services.ConfigureSwaggerGen(options =>
    {
        options.SingleApiVersion(new Info
        {
            Version = "v1",
            Title = "ToDo API",
            Description = "A simple example ASP.NET Core Web API",
            TermsOfService = "None",
            Contact = new Contact { Name = "Shayne Boyer", Email = "", Url = "http://twitter.com/spboyer"},
            License = new License { Name = "Use under LICX", Url = "http://url.com" }
        });
        
    });

Then the Swagger UI produces the following more presentable information concering the API.

.. image:: web-api-help-pages-using-swagger/_static/custom-info.png

XML Comments
'''''''''''''
In order to enable the generation of xml comments, right click the project in Visual Studio and select "Properties" and check the ``XML Documentation file`` box under the Output Settings section.

.. image:: web-api-help-pages-using-swagger/_static/swagger-xml-comments.png

.. note:: If you are not using Visual Studio then you can enable the "XML documentation file" flag in the ``project.json`` file by setting the ``"xmlDoc": true`` in the ``buildOptions`` section.

Next, configure the OperationFilter to use the generated xml file. An additional item to point out here is the use of ``PlatformServices.Default.Application.ApplicationBasePath`` to access the executing location of the application. This is the location where the generated xml file will be placed. Notably it can vary depending on the .NET Framework used for the environment.

.. note:: For Linux or non Windows operating systems, file names and paths can be case sensitive. So ``ToDoApi.xml`` would be found on Windows but not Centos for example.

.. code-block:: c#
    :emphasize-lines: 8

    // Add the detail Info for the API
    services.ConfigureSwaggerGen(options =>
    {
        //determine base path for executing application
        var basePath = PlatformServices.Default.Application.ApplicationBasePath;

        //set the comments path for the swagger json and ui
        options.IncludeXmlComments(basePath + "\\TodoApi.xml");
    });

Adding the triple slash comments to the method enhances the Swagger UI by adding the decription to the header of the section.

.. code-block:: c#
    :emphasize-lines: 2

    /// <summary>
    /// Deletes a specific TodoItem
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public void Delete(string id)
    {
        TodoItems.Remove(id);
    }

.. image:: web-api-help-pages-using-swagger/_static/triple-slash-comments.png

Note that the UI is driven by the generated JSON file, and these comments are also in that file as well.

.. code-block:: javascript
    :emphasize-lines: 5

      "delete": {
        "tags": [
          "Todo"
        ],
        "summary": "Deletes a specific TodoItem",
        "operationId": "ApiTodoByIdDelete",
        "consumes": [],
        "produces": [],
        "parameters": [
          {
            "name": "id",
            "in": "path",
            "description": "",
            "required": true,
            "type": "string"
          }
        ],
        "responses": {
          "204": {
            "description": "No Content"
          }
        },
        "deprecated": false
      }

Here is a more robust example, adding ``<remarks />`` where the content can be just text or adding the JSON or xml object for further documentation of the method.

.. code-block:: c#

    /// <summary>
    /// Creates a TodoItem
    /// </summary>
    /// <remarks>
    /// Note that the key is a GUID and not an integer.
    ///  
    ///     POST /Todo
    ///     {
    ///        "key": "0e7ad584-7788-4ab1-95a6-ca0a5b444cbb",
    ///        "name": "Item1",
    ///        "isComplete": true
    ///     }
    /// 
    /// </remarks>
    /// <param name="item"></param>
    /// <returns></returns>
    [HttpPost]
    public IActionResult Create([FromBody, Required] TodoItem item)
    {
        if (item == null)
        {
            return BadRequest();
        }
        TodoItems.Add(item);
        return CreatedAtRoute("GetTodo", new { id = item.Key }, item);
    }

Notice the enhancement of the UI with these additional comments.

.. image:: web-api-help-pages-using-swagger/_static/xml-comments-extended.png


DataAnnotations
'''''''''''''''
Another supported feature is using the ``System.ComponentModel.DataAnnotations`` to decorate the API controller, methods and classes to help drive the Swagger components.

For example, adding the ``[Required]`` annotation to the ``Name`` property of the TodoItem class will change the ModelSchema information in the UI. Other DataAnnotations such as ``[Produces("application/json"]``, RegularExpression validators and more will further detail the information delivered in the generated page.  What is important is that the more information that is documented in the code, the more "auto" generated information is pushed to the consumer.


.. literalinclude:: web-api-help-pages-using-swagger/sample/src/TodoApi/Models/TodoItem.cs
  :language: c#
  :emphasize-lines: 10


Describing Response Types
'''''''''''''''''''''''''
Consuming developers are probably most concerned with what is returned; specifically response types, error codes (if not standard). These are handled in the xml comments and DataAnnotations.

Take the ``Create()`` method for example, currently it returns only "201 Created" response by default. That is of course if the item is in fact created, or a "204 No Content" if no data is passed in the POST Body.  However, there is no documentation to know that or any other response. That can be fixed by adding the following piece of code.


.. code-block:: c#
    :emphasize-lines: 2,3,5,6

    /// <returns>New Created Todo Item</returns>
    /// <response code="201">Todo Item created</response>
    /// <response code="400">Todo Item invalid</response>
    [HttpPost]
    [SwaggerResponse(HttpStatusCode.Created, "Returns the newly created Todo item.", typeof(TodoItem))]
    [SwaggerResponse(HttpStatusCode.BadRequest, "If the item is null", typeof(TodoItem))]
    public IActionResult Create([FromBody, Required] TodoItem item)
    {
        if (item == null)
        {
            return BadRequest();
        }
        TodoItems.Add(item);
        return CreatedAtRoute("GetTodo", new { id = item.Key }, item);
    }

.. image:: web-api-help-pages-using-swagger/_static/data-annotations-response-types.png

Customizing the UI
------------------

Multiple Versions
-----------------


