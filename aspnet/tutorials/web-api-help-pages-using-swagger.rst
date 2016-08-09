.. _web-api-help-pages-using-swagger:

ASP.NET Web API Help Pages using Swagger
========================================

By `Shayne Boyer`_

Understanding the various methods of an API can be a challenge for a developer when building a consuming application. 

Generating good documentation and help pages as a part of your Web API using `Swagger <a href="http://swagger.io/">`_ with the .NET Core implementation `Swashbuckle <a href="https://github.com/domaindrivendev/Ahoy">`_ is as easy as adding a couple of NuGet packages and modifying the Startup.cs.

This tutorial builds on the sample on :doc:`first-web-api`. 

.. contents:: Sections:
  :local:
  :depth: 2

Getting Started
---------------
There are two core components to Swashbuckle 

- *Swashbuckle.SwaggerGen* : provides the functionality to scaffold your Web API and generate JSON Swagger documents that describe the objects, methods, return types, etc. 
- *Swashbuckle.SwaggerUI* : an embedded version of the Swagger UI tool which uses the above documents for a rich customizable experience for describing the Web API functionality and includes built in test harness capabilities for the public methods.

NuGet Packages
--------------
You can add Swashbuckle with any of the following approaches:

- From the Package Manager Console: 

.. code-block:: bash

    Install=Package Swashbuckle -Pre

- Add Swashbuckle to project.json:

.. code-block:: javascript

    "Swashbuckle": "6.0.0-"

- In Visual Studio:
	- Right click yur project in Solution Explorer > Manage NuGet Packages 
	- Enter Swashbukle in the search box
	- Check Includeprerelease 
	- Set the Package source to nuget.org 
	- Tap the Swashuckle package and then tap Install 



Add and configure Swagger to the middleware
-------------------------------------------

Add SwaggerGen to the services collection in the Configure method, and in the ConfigureServices method, enable the middleware for serving generated JSON document and the SwaggerUI. 

.. literalinclude:: web-api-help-pages-using-swagger/sample/src/TodoApi/Startup.cs
    :language: c#
    :start-after: snippet_Configure
    :end-before: #endregion
    :dedent: 8
    :emphasize-lines: 13,44,47


In Visual Studio, press ^F5 to launch the app and navigate to ``http://localhost:<random_port>/swagger/v1/swagger.json`` to see the document generated that describes the endpoints. 

.. note:: Microsoft Edge, Google Chrome and Firefox display JSON documents natively.  There are extensions for Chrome that will format the document for easier reading. *Example below reduced for brevity.*

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
            ...
        }
        },
        "/api/Todo/{id}": {
        "get": {
            ...
        },
        "put": {
            ...
        },
        "delete": {
            ...
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
Swagger is not only a simple way to represent the API, but has options for documenting the object model, as well as customizing the interactive UI to match your look and feel or design language.

API Info and Description
''''''''''''''''''''''''
For adding additional information such as the author, license, description etc.; use the ``Swashbuckle.Swagger.Model.Info`` class and use the ``.ConfigureSwaggerGen()`` method.

.. literalinclude:: web-api-help-pages-using-swagger/sample/src/TodoApi/Startup.cs
    :language: c#
    :start-after: snippet_Configure
    :end-before: #endregion
    :dedent: 8
    :emphasize-lines: 16-26

Then the Swagger UI produces the following more presentable information concerning the API.

.. image:: web-api-help-pages-using-swagger/_static/custom-info.png

XML Comments
'''''''''''''
In order to enable the generation of xml comments, right click the project in Visual Studio and select "Properties" and check the ``XML Documentation file`` box under the Output Settings section.

.. image:: web-api-help-pages-using-swagger/_static/swagger-xml-comments.png

.. note:: If you are not using Visual Studio then you can enable the "XML documentation file" flag in the ``project.json`` file by setting the ``"xmlDoc": true`` in the ``buildOptions`` section.

Configure the OperationFilter to use the generated xml file. An additional item to point out here is the use of ``PlatformServices.Default.Application.ApplicationBasePath`` to access the executing location of the application. This is the location where the generated xml file will be placed. Notably it can vary depending on the .NET Framework used for the environment.

.. note:: For Linux or non Windows operating systems, file names and paths can be case sensitive. So ``ToDoApi.xml`` would be found on Windows but not Centos for example.

.. literalinclude:: web-api-help-pages-using-swagger/sample/src/TodoApi/Startup.cs
    :language: c#
    :start-after: snippet_Configure
    :end-before: #endregion
    :dedent: 8
    :emphasize-lines: 29,32

Adding the triple slash comments to the method enhances the Swagger UI by adding the description to the header of the section.

.. literalinclude:: web-api-help-pages-using-swagger/sample/src/TodoApi/Controllers/TodoController.cs
    :language: c#
    :start-after: Delete_Method
    :end-before: #endregion
    :dedent: 8
    :emphasize-lines: 2

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

.. literalinclude:: web-api-help-pages-using-swagger/sample/src/TodoApi/Controllers/TodoController.cs
    :language: c#
    :start-after: Create_Method
    :end-before: #endregion
    :dedent: 8
    :emphasize-lines: 4-14

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


.. literalinclude:: web-api-help-pages-using-swagger/sample/src/TodoApi/Controllers/TodoController.cs
    :language: c#
    :start-after: Create_Method
    :end-before: #endregion
    :dedent: 8
    :emphasize-lines: 17,18,20,21

.. image:: web-api-help-pages-using-swagger/_static/data-annotations-response-types.png

Customizing the UI
''''''''''''''''''
The stock UI is very functional as well as presentable, however when building documentation pages for your API you want it to represent your brand or look and feel. 

Accomplishing that task with the Swashbuckle components is simple but requires adding the resources to serve static files that would not normally be included in a Web API project and then building the folder structure to host those files.

Add the ``"Microsoft.AspNetCore.StaticFiles": "1.0.0-*"`` NuGet package to the project either using one of the methods mentioned prior in this tutorial and then open the *Startup.cs* file to add the necessary code for the static file middleware.

.. code-block:: c#
    :emphasize-lines: 4

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();

            // Enable middleware to serve generated Swagger as a JSON endpoint
            app.UseSwagger();

            // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
            app.UseSwaggerUi();
            
        }

Acquire the core *index.html* file used for the Swagger UI page from the `Github repository <a href="https://github.com/swagger-api/swagger-ui/blob/master/src/main/html/index.html">`_ and put that in the ``wwwroot/swagger/ui`` folder and also create a new ``custom.css`` file in the same folder.

.. image:: web-api-help-pages-using-swagger/_static/custom-files-folder-view.png

In the *index.html* file be sure to reference the *custom.css* file 

.. code-block:: html

    <link href='custom.css' media='screen' rel='stylesheet' type='text/css' />

Then for a simple example, here is a cutom header to add a header title to the page.

*custom.css file*

.. literalinclude:: web-api-help-pages-using-swagger/sample/src/TodoApi/wwwroot/swagger/ui/custom.css
  :language: css

*index.html body*

.. code-block:: html

    <body class="swagger-section">
       <div id="header">
        <h1>ToDo API Documentation</h1>
       </div>
    
       <div id="message-bar" class="swagger-ui-wrap" data-sw-translate>&nbsp;</div>
       <div id="swagger-ui-container" class="swagger-ui-wrap"></div>
    </body>
    

.. image:: web-api-help-pages-using-swagger/_static/custom-header.png

There is much more you can do with the page, see the full capabilities for the UI resources at the `Swagger UI Github repository <a href="https://github.com/swagger-api/swagger-ui">`_ . 



