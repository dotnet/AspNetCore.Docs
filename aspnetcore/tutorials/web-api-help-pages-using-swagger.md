---
title: ASP.NET Web API Help Pages using Swagger | Microsoft Docs
author: spboyer
description: Walkthrough of adding Swagger to a Web API Application
keywords: ASP.NET Core, Swagger
ms.author: spboyer
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 54bb961d-29d9-4dee-8e2c-a93fc33c16f2
ms.technology: aspnet
ms.prod: aspnet-core
uid: tutorials/web-api-help-pages-using-swagger
---
# ASP.NET Web API Help Pages using Swagger

<a name=web-api-help-pages-using-swagger></a>

By [Shayne Boyer](https://twitter.com/spboyer)

Understanding the various methods of an API can be a challenge for a developer when building a consuming application.

Generating good documentation and help pages as a part of your Web API using [Swagger](http://swagger.io) with the .NET Core implementation [Swashbuckle](https://github.com/domaindrivendev/Ahoy) is as easy as adding a couple of NuGet packages and modifying the *Startup.cs*.

* [Swashbuckle](https://github.com/domaindrivendev/Ahoy) is an open source project for generating Swagger documents for Web APIs that are built with ASP.NET Core MVC.

* [Swagger](http://swagger.io) is a machine readable representation of a RESTful API that enables support for interactive documentation, client SDK generation and discoverability.

This tutorial builds on the sample on [Building Your First Web API with ASP.NET Core MVC and Visual Studio](first-web-api.md). If you'd like to follow along, download the sample at [https://github.com/aspnet/Docs/tree/master/aspnetcore/tutorials/first-web-api/sample](https://github.com/aspnet/Docs/tree/master/aspnetcore/tutorials/first-web-api/sample).

## Getting Started

There are two core components to Swashbuckle

* *Swashbuckle.SwaggerGen* : provides the functionality to generate JSON Swagger documents that describe the objects, methods, return types, etc.

* *Swashbuckle.SwaggerUI* : an embedded version of the Swagger UI tool which uses the above documents for a rich customizable experience for describing the Web API functionality and includes built in test harness capabilities for the public methods.

## NuGet Packages

You can add Swashbuckle with any of the following approaches:

* From the Package Manager Console:

```bash
Install-Package Swashbuckle -Pre
   ```

* In Visual Studio:

     * Right click your project in Solution Explorer > Manage NuGet Packages
     * Enter Swashbuckle in the search box
     * Check "Include prerelease"
     * Set the Package source to nuget.org
     * Tap the Swashbuckle package and then tap Install

## Add and configure Swagger to the middleware

Add SwaggerGen to the services collection in the Configure method, and in the ConfigureServices method, enable the middleware for serving generated JSON document and the SwaggerUI.

<!-- literal_block {"ids": [], "linenos": false, "xml:space": "preserve", "language": "csharp", "highlight_args": {"hl_lines": [12, 21, 24]}} -->

```csharp
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

// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
{
    app.UseMvcWithDefaultRoute();

    // Enable middleware to serve generated Swagger as a JSON endpoint
    app.UseSwagger();

    // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
    app.UseSwaggerUi();

}
```

In Visual Studio, press ^F5 to launch the app and navigate to `http://localhost:<random_port>/swagger/v1/swagger.json` to see the document generated that describes the endpoints.

> [!NOTE]
> Microsoft Edge, Google Chrome and Firefox display JSON documents natively.  There are extensions for Chrome that will format the document for easier reading. *Example below reduced for brevity.*

```javascript
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
   ```

This document is used to drive the Swagger UI which can be viewed by navigating to `http://localhost:<random_port>/swagger/ui`

![image](web-api-help-pages-using-swagger/_static/swagger-ui.png)

Each of the methods in the ToDo controller can be tested from the UI. Tap a method to expand the section, add any necessary parameters and tap "Try it out!".

![image](web-api-help-pages-using-swagger/_static/get-try-it-out.png)

## Customization & Extensibility

Swagger is not only a simple way to represent the API, but has options for documenting the object model, as well as customizing the interactive UI to match your look and feel or design language.

### API Info and Description

The `ConfigureSwaggerGen` method can be used to add information such as the author, license, description.

```csharp
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
   ```

The following image shows the Swagger UI displaying the version information added.

![image](web-api-help-pages-using-swagger/_static/custom-info.png)

### XML Comments

To enable XML comments, right click the project in Visual Studio and select **Properties** and then check the **XML Documentation file** box under the **Output Settings** section.

![image](web-api-help-pages-using-swagger/_static/swagger-xml-comments.png)

Configure Swagger to use the generated XML file.

> [!NOTE]
> For Linux or non-Windows operating systems, file names and paths can be case sensitive. So `ToDoApi.XML` would be found on Windows but not CentOS for example.

[!code-csharp[Main](../tutorials/web-api-help-pages-using-swagger/sample/src/TodoApi/Startup.cs?name=snippet_Configure&highlight=29,33)]

In the code above, ApplicationBasePath gets the base path of the app, which is needed to set the full path to the XML comments. `TodoApi.xml` only works for this example, the name of the generated XML comments file is based on the name of your application.

Adding the triple slash comments to the method enhances the Swagger UI by adding the description to the header of the section.

[!code-csharp[Main](../tutorials/web-api-help-pages-using-swagger/sample/src/TodoApi/Controllers/TodoController.cs?name=Delete_Method&highlight=2)]

![image](web-api-help-pages-using-swagger/_static/triple-slash-comments.png)

Note that the UI is driven by the generated JSON file, and these comments are also in that file as well.

<!-- literal_block {"ids": [], "linenos": false, "xml:space": "preserve", "language": "javascript", "highlight_args": {"hl_lines": [5]}} -->

```javascript
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
```

Here is a more robust example, adding `<remarks />` where the content can be just text or adding the JSON or XML object for further documentation of the method.

[!code-csharp[Main](../tutorials/web-api-help-pages-using-swagger/sample/src/TodoApi/Controllers/TodoController.cs?name=Create_Method&highlight=4-14)]

Notice the enhancement of the UI with these additional comments.

![image](web-api-help-pages-using-swagger/_static/xml-comments-extended.png)

### DataAnnotations

You can decorate the API controller with `System.ComponentModel.DataAnnotations` to help drive the Swagger UI components.

Adding the `[Required]` annotation to the `Name` property of the `TodoItem` class will change the ModelSchema information in the UI. `[Produces("application/json")]`, `RegularExpression` validators and more will further detail the information delivered in the generated page.  The more metadata that is in the code produces a more desciptive UI or API help page.  

[!code-csharp[Main](../tutorials/web-api-help-pages-using-swagger/sample/src/TodoApi/Models/TodoItem.cs?highlight=10)]


### Describing Response Types

Consuming developers are probably most concerned with what is returned; specifically response types, error codes (if not standard). These are handled in the XML comments and DataAnnotations.

Take the `Create()` method for example, currently it returns only "201 Created" response by default. That is of course if the item is in fact created, or a "204 No Content" if no data is passed in the POST Body.  However, there is no documentation to know that or any other response. That can be fixed by adding the following piece of code.

[!code-csharp[Main](../tutorials/web-api-help-pages-using-swagger/sample/src/TodoApi/Controllers/TodoController.cs?name=Create_Method&highlight=17,18,20,21)]

![image](web-api-help-pages-using-swagger/_static/data-annotations-response-types.png)

### Customizing the UI

The stock UI is very functional as well as presentable, however when building documentation pages for your API you want it to represent your brand or look and feel.

Accomplishing that task with the Swashbuckle components is simple but requires adding the resources to serve static files that would not normally be included in a Web API project and then building the folder structure to host those files.

Add the `"Microsoft.AspNetCore.StaticFiles": "1.0.0-*"` NuGet package to the project.

Enable static files middleware.

<!-- literal_block {"ids": [], "linenos": false, "xml:space": "preserve", "language": "csharp", "highlight_args": {"hl_lines": [4]}} -->

```csharp
// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
   public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
   {
       // Enable static files middleware.
       app.UseStaticFiles();

       app.UseMvcWithDefaultRoute();

       // Enable middleware to serve generated Swagger as a JSON endpoint
       app.UseSwagger();

       // Enable middleware to serve swagger-ui assets (HTML, JS, CSS etc.)
       app.UseSwaggerUi();
   }
   ```

Acquire the core *index.html* file used for the Swagger UI page from the `Github repository <https://github.com/domaindrivendev/Ahoy/tree/master/test/WebSites/CustomizedUi/wwwroot/swagger/ui>`_ and put that in the `wwwroot/swagger/ui` folder and also create a new `custom.css` file in the same folder.

![image](web-api-help-pages-using-swagger/_static/custom-files-folder-view.png)

Reference *custom.css* in the *index.html* file.

```html
<link href='custom.css' media='screen' rel='stylesheet' type='text/css' />
```

The following CSS provides a simple sample of a custom header title to the page.

*custom.css file*

[!code-css[Main](web-api-help-pages-using-swagger/sample/src/TodoApi/wwwroot/swagger/ui/custom.css)]

*index.html body*

```html
<body class="swagger-section">
   <div id="header">
    <h1>ToDo API Documentation</h1>
   </div>

   <div id="message-bar" class="swagger-ui-wrap" data-sw-translate>&nbsp;</div>
   <div id="swagger-ui-container" class="swagger-ui-wrap"></div>
</body>
```

![image](web-api-help-pages-using-swagger/_static/custom-header.png)

There is much more you can do with the page, see the full capabilities for the UI resources at the [Swagger UI Github repository](https://github.com/swagger-api/swagger-ui).
