---
title: Create a web API with ASP.NET Core and MongoDB
author: wadepickett
<!-- author: prkhandelwal -->
description: This tutorial demonstrates how to create an ASP.NET Core web API using a MongoDB NoSQL database.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc, sfi-ropc-nochange
ms.date: 09/17/2025
uid: tutorials/first-mongo-app
---
# Create a web API with ASP.NET Core and MongoDB

[!INCLUDE[](~/includes/not-latest-version.md)]

By [Pratik Khandelwal](https://twitter.com/K2Prk) and [Scott Addie](https://twitter.com/Scott_Addie)

:::moniker range=">= aspnetcore-9.0"

This tutorial creates a web API that runs Create, Read, Update, and Delete (CRUD) operations on a [MongoDB](https://www.mongodb.com/what-is-mongodb) NoSQL database.

In this tutorial, you learn how to:

> [!div class="checklist"]
> * Configure MongoDB
> * Create a MongoDB database
> * Define a MongoDB collection and schema
> * Perform MongoDB CRUD operations from a web API
> * Customize JSON serialization

## Prerequisites

* [MongoDB 6.0.5 or later](https://docs.mongodb.com/manual/tutorial/install-mongodb-on-windows/)
* [MongoDB Shell](https://www.mongodb.com/docs/mongodb-shell/install/)

# [Visual Studio](#tab/visual-studio)

[!INCLUDE[](~/includes/net-prereqs-vs-9.0.md)]

# [Visual Studio Code](#tab/visual-studio-code)

[!INCLUDE[](~/includes/net-prereqs-vsc-9.0.md)]

---

## Configure MongoDB


Enable MongoDB and MongoDB Shell access from anywhere on the development machine (Windows/Linux/macOS):

1. Download and Install MongoDB Shell:
   * macOS/Linux: Choose a directory to extract the MongoDB Shell to. Add the resulting path for `mongosh` to the `PATH` environment variable.
   * Windows: MongoDB Shell (mongosh.exe) is installed at *C:\\Users\\\<user>\\AppData\\Local\\Programs\\mongosh*. Add the resulting path for `mongosh.exe` to the `PATH` environment variable.
1. Download and Install MongoDB:
   * macOS/Linux: Verify the directory that MongoDB was installed at, usually in */usr/local/mongodb*. Add the resulting path for `mongodb` to the `PATH` environment variable.
   * Windows: MongoDB is installed at *C:\\Program Files\\MongoDB* by default. Add *C:\\Program Files\\MongoDB\\Server\\\<version_number>\\bin* to the `PATH` environment variable.
1. Choose a Data Storage Directory: Select a directory on your development machine for storing data. Create the directory if it doesn't exist. The MongoDB Shell doesn't create new directories:
   * macOS/Linux: For example, `/usr/local/var/mongodb`.
   * Windows: For example, `C:\\BooksData`.
1. In the OS command shell (not the MongoDB Shell), use the following command to connect to MongoDB on default port 27017. Replace `<data_directory_path>` with the directory chosen in the previous step.

   ```console
   mongod --dbpath <data_directory_path>
   ```

Use the previously installed MongoDB Shell in the following steps to create a database, make collections, and store documents. For more information on MongoDB Shell commands, see [`mongosh`](https://docs.mongodb.com/mongodb-shell/run-commands/).

1. Open a MongoDB command shell instance by launching `mongosh.exe`, or by running the following command in the command shell:

   ```console
   mongosh
   ```

1. In the command shell connect to the default test database by running:

   ```console
   use BookStore
   ```

   A database named *BookStore* is created if it doesn't already exist. If the database does exist, its connection is opened for transactions.

1. Create a `Books` collection using following command:

   ```console
   db.createCollection('Books')
   ```

   The following result is displayed:

   ```console
   { "ok" : 1 }
   ```

1. Define a schema for the `Books` collection and insert two documents using the following command:

   ```console
   db.Books.insertMany([{ "Name": "Design Patterns", "Price": 54.93, "Category": "Computers", "Author": "Ralph Johnson" }, { "Name": "Clean Code", "Price": 43.15, "Category": "Computers","Author": "Robert C. Martin" }])
   ```

   A result similar to the following is displayed:

   ```console
   {
       "acknowledged" : true,
       "insertedIds" : [
           ObjectId("61a6058e6c43f32854e51f51"),
           ObjectId("61a6058e6c43f32854e51f52")
        ]
    }
   ```
  
   > [!NOTE]
   > The `ObjectId`s shown in the preceding result won't match those shown in the command shell.

1. View the documents in the database using the following command:

   ```console
   db.Books.find().pretty()
   ```

   A result similar to the following is displayed:

   ```console
   {
        "_id" : ObjectId("61a6058e6c43f32854e51f51"),
        "Name" : "Design Patterns",
        "Price" : 54.93,
        "Category" : "Computers",
        "Author" : "Ralph Johnson"
    }
    {
        "_id" : ObjectId("61a6058e6c43f32854e51f52"),
        "Name" : "Clean Code",
        "Price" : 43.15,
        "Category" : "Computers",
        "Author" : "Robert C. Martin"
    }
   ```

   The schema adds an autogenerated `_id` property of type `ObjectId` for each document.

## Create the ASP.NET Core web API project

# [Visual Studio](#tab/visual-studio)

1. Go to **File** > **New** > **Project**.
1. Select the **ASP.NET Core Web API** project type, and select **Next**.
1. Name the project *BookStoreApi*, and select **Next**.
1. In the **Additional information** dialog:
  * Confirm the **Framework** is **.NET 9.0 (Standard Term Support)**.
  * Confirm the checkbox for **Use controllers** is checked.
  * Confirm the checkbox for **Enable OpenAPI support** is checked.
  * Select **Create**.
1. In the **Package Manager Console** window, navigate to the project root. Run the following command to install the .NET driver for MongoDB:

   ```powershell
   Install-Package MongoDB.Driver
   ```

# [Visual Studio Code](#tab/visual-studio-code)

1. Run the following commands in a command shell:

   ```dotnetcli
   dotnet new webapi -o BookStoreApi --use-controllers
   code BookStoreApi
   ```

   The preceding commands generate a new ASP.NET Core web API project and then open the project in Visual Studio Code.

1. Once the OmniSharp server starts up, a dialog asks **Required assets to build and debug are missing from 'BookStoreApi'. Add them?**. Select **Yes**.
1. Open the **Integrated Terminal** and run the following command to install the .NET driver for MongoDB:

   ```dotnetcli
   dotnet add package MongoDB.Driver
   ```

---

## Add an entity model

1. Add a *Models* directory to the project root.
1. Add a `Book` class to the *Models* directory with the following code:

   :::code language="csharp" source="first-mongo-app/samples_snapshot/9.x/Book.cs":::

   In the preceding class, the `Id` property is:

   * Required for mapping the Common Language Runtime (CLR) object to the MongoDB collection.
   * Annotated with [`[BsonId]`](https://mongodb.github.io/mongo-csharp-driver/2.14/apidocs/html/T_MongoDB_Bson_Serialization_Attributes_BsonIdAttribute.htm) to make this property the document's primary key.
   * Annotated with [`[BsonRepresentation(BsonType.ObjectId)]`](https://mongodb.github.io/mongo-csharp-driver/2.14/apidocs/html/T_MongoDB_Bson_Serialization_Attributes_BsonRepresentationAttribute.htm) to allow passing the parameter as type `string` instead of an [ObjectId](https://mongodb.github.io/mongo-csharp-driver/2.14/apidocs/html/T_MongoDB_Bson_ObjectId.htm) structure. Mongo handles the conversion from `string` to `ObjectId`.

   The `BookName` property is annotated with the [`[BsonElement]`](https://mongodb.github.io/mongo-csharp-driver/2.14/apidocs/html/T_MongoDB_Bson_Serialization_Attributes_BsonElementAttribute.htm) attribute. The attribute's value of `Name` represents the property name in the MongoDB collection.

## Add a configuration model

1. Add the following database configuration values to `appsettings.json`:

   :::code language="json" source="first-mongo-app/samples/9.x/BookStoreApi/appsettings.json" highlight="2-6":::

1. Add a `BookStoreDatabaseSettings` class to the *Models* directory with the following code:

   :::code language="csharp" source="first-mongo-app/samples/9.x/BookStoreApi/Models/BookStoreDatabaseSettings.cs":::

   The preceding `BookStoreDatabaseSettings` class is used to store the `appsettings.json` file's `BookStoreDatabase` property values. The JSON and C# property names are named identically to ease the mapping process.

1. Add the following highlighted code to `Program.cs`:

   :::code language="csharp" source="first-mongo-app/samples/9.x/BookStoreApi/Program.cs" id="snippet_BookStoreDatabaseSettings" highlight="4-5":::

   In the preceding code, the configuration instance to which the `appsettings.json` file's `BookStoreDatabase` section binds is registered in the Dependency Injection (DI) container. For example, the `BookStoreDatabaseSettings` object's `ConnectionString` property is populated with the `BookStoreDatabase:ConnectionString` property in `appsettings.json`.

1. Add the following code to the top of `Program.cs` to resolve the `BookStoreDatabaseSettings` reference:

   :::code language="csharp" source="first-mongo-app/samples/9.x/BookStoreApi/Program.cs" id="snippet_UsingModels":::

## Add a CRUD operations service

1. Add a *Services* directory to the project root.
1. Add a `BooksService` class to the *Services* directory with the following code:

   :::code language="csharp" source="first-mongo-app/samples/9.x/BookStoreApi/Services/BooksService.cs" id="snippet_File":::

   In the preceding code, a `BookStoreDatabaseSettings` instance is retrieved from DI via constructor injection. This technique provides access to the `appsettings.json` configuration values that were added in the [Add a configuration model](#add-a-configuration-model) section.

1. Add the following highlighted code to `Program.cs`:

   :::code language="csharp" source="first-mongo-app/samples/9.x/BookStoreApi/Program.cs" id="snippet_BooksService" highlight="7":::

   In the preceding code, the `BooksService` class is registered with DI to support constructor injection in consuming classes. The singleton service lifetime is most appropriate because `BooksService` takes a direct dependency on `MongoClient`. Per the official [Mongo Client reuse guidelines](https://mongodb.github.io/mongo-csharp-driver/2.14/reference/driver/connecting/#re-use), `MongoClient` should be registered in DI with a singleton service lifetime.

1. Add the following code to the top of `Program.cs` to resolve the `BooksService` reference:

   :::code language="csharp" source="first-mongo-app/samples/9.x/BookStoreApi/Program.cs" id="snippet_UsingServices":::

The `BooksService` class uses the following `MongoDB.Driver` members to run CRUD operations against the database:

* [MongoClient](https://mongodb.github.io/mongo-csharp-driver/2.14/apidocs/html/T_MongoDB_Driver_MongoClient.htm): Reads the server instance for running database operations. The constructor of this class is provided in the MongoDB connection string:

  :::code language="csharp" source="first-mongo-app/samples/9.x/BookStoreApi/Services/BooksService.cs" id="snippet_ctor" highlight="4-5":::

* [IMongoDatabase](https://mongodb.github.io/mongo-csharp-driver/2.14/apidocs/html/T_MongoDB_Driver_IMongoDatabase.htm): Represents the Mongo database for running operations. This tutorial uses the generic [GetCollection\<TDocument>(collection)](https://mongodb.github.io/mongo-csharp-driver/2.14/apidocs/html/M_MongoDB_Driver_IMongoDatabase_GetCollection__1.htm) method on the interface to gain access to data in a specific collection. Run CRUD operations against the collection after this method is called. In the `GetCollection<TDocument>(collection)` method call:

  * `collection` represents the collection name.
  * `TDocument` represents the CLR object type stored in the collection.

`GetCollection<TDocument>(collection)` returns a [MongoCollection](https://mongodb.github.io/mongo-csharp-driver/2.14/apidocs/html/T_MongoDB_Driver_MongoCollection.htm) object representing the collection. In this tutorial, the following methods are invoked on the collection:

* [DeleteOneAsync](https://mongodb.github.io/mongo-csharp-driver/2.14/apidocs/html/M_MongoDB_Driver_IMongoCollection_1_DeleteOneAsync_1.htm): Deletes a single document matching the provided search criteria.
* [Find\<TDocument>](https://mongodb.github.io/mongo-csharp-driver/2.14/apidocs/html/M_MongoDB_Driver_IMongoCollectionExtensions_Find__1.htm): Returns all documents in the collection matching the provided search criteria.
* [InsertOneAsync](https://mongodb.github.io/mongo-csharp-driver/2.14/apidocs/html/M_MongoDB_Driver_IMongoCollection_1_InsertOneAsync_1.htm): Inserts the provided object as a new document in the collection.
* [ReplaceOneAsync](https://mongodb.github.io/mongo-csharp-driver/2.14/apidocs/html/M_MongoDB_Driver_IMongoCollection_1_ReplaceOneAsync.htm): Replaces the single document matching the provided search criteria with the provided object.

## Add a controller

Add a `BooksController` class to the *Controllers* directory with the following code:

:::code language="csharp" source="first-mongo-app/samples/9.x/BookStoreApi/Controllers/BooksController.cs":::

The preceding web API controller:

* Uses the `BooksService` class to run CRUD operations.
* Contains action methods to support GET, POST, PUT, and DELETE HTTP requests.
* Calls <xref:Microsoft.AspNetCore.Mvc.ControllerBase.CreatedAtAction%2A> in the `Create` action method to return an [HTTP 201](https://www.rfc-editor.org/rfc/rfc9110#status.201) response. Status code 201 is the standard response for an HTTP POST method that creates a new resource on the server. `CreatedAtAction` also adds a `Location` header to the response. The `Location` header specifies the URI of the newly created book.

## Configure JSON serialization options

There are two details to change about the JSON responses returned in the [Test the web API](#test-the-web-api) section:

* The property names' default camel casing should be changed to match the Pascal casing of the CLR object's property names.
* The `bookName` property should be returned as `Name`.

To satisfy the preceding requirements, make the following changes:

1. In `Program.cs`, chain the following highlighted code on to the `AddControllers` method call:

   :::code language="csharp" source="first-mongo-app/samples/9.x/BookStoreApi/Program.cs" id="snippet_AddControllers" highlight="10-11":::

   With the preceding change, property names in the web API's serialized JSON response match their corresponding property names in the CLR object type. For example, the `Book` class's `Author` property serializes as `Author` instead of `author`.

1. In `Models/Book.cs`, annotate the `BookName` property with the [`[JsonPropertyName]`](xref:System.Text.Json.Serialization.JsonPropertyNameAttribute) attribute:

   :::code language="csharp" source="first-mongo-app/samples/9.x/BookStoreApi/Models/Book.cs" id="snippet_BookName" highlight="2":::

   The `[JsonPropertyName]` attribute's value of `Name` represents the property name in the web API's serialized JSON response.

1. Add the following code to the top of `Models/Book.cs` to resolve the `[JsonProperty]` attribute reference:

   :::code language="csharp" source="first-mongo-app/samples/9.x/BookStoreApi/Models/Book.cs" id="snippet_UsingSystemTextJsonSerialization":::

1. Repeat the steps defined in the [Test the web API](#test-the-web-api) section. Notice the difference in JSON property names.

## Test the web API

# [Visual Studio](#tab/visual-studio)

This tutorial uses [Endpoints Explorer and .http files](xref:test/http-files#use-endpoints-explorer) to test the API.

1. Build and run the app.

1. In **Endpoints Explorer**, right-click the first **GET** endpoint `/api/books`, and select **Generate request**.

   The following content is added to the `BookStoreApi.http` file.
   If this is the first time that a request is generated, the file is created in the project root.

   ```
   @BookStoreApi_HostAddress = https://localhost:<port>
    
   GET {{BookStoreApi_HostAddress}}/api/books
    
   ###
   ```

   The port number should already be set to the port used by the app, for example, `https://localhost:56874`.
   If that's not the case you can find your port number in the output window when you launch the app.

1. Select the **Send request** link above the new `GET` request line.

   The GET request is sent to the app and the response is displayed in the **Response** pane.

1. The response body shows the JSON result containing the book entries similar to the following:

   ```json
   [
     {
       "Id": "61a6058e6c43f32854e51f51",
       "Name": "Design Patterns",
       "Price": 54.93,
       "Category": "Computers",
       "Author": "Ralph Johnson"
     },
     {
       "Id": "61a6058e6c43f32854e51f52",
       "Name": "Clean Code",
       "Price": 43.15,
       "Category": "Computers",
       "Author": "Robert C. Martin"
     }
   ]
   ```

1. To retrieve a single book, right-click the `/api/books/{id}, params (string id)` **GET** endpoint in the **Endpoints Explorer**, and select **Generate request**.

   The following content is appended to the `BookStoreApi.http` file:

   ```
   @id=string
   GET {{BookStoreApi_HostAddress}}/api/books/{{id}}

   ###
   ```

1. Replace `id` variable with one of the IDs returned from the earlier request, for example:

   ```
   @id="61a6058e6c43f32854e51f52"
   GET {{BookStoreApi_HostAddress}}/api/books/{{id}}

   ###
   ```

1. Select the **Send request** link above the new `GET` request line.

   The GET request is sent to the app and the response is displayed in the **Response** pane.

1. The response body shows JSON similar to the following:

   ```json
   {
     "Id": "61a6058e6c43f32854e51f52",
     "Name": "Clean Code",
     "Price": 43.15,
     "Category": "Computers",
     "Author": "Robert C. Martin"
   }
   ```

1. To test the POST endpoint, right-click the `/api/books` **POST** endpoint and select **Generate request**.

   The following content is added to the `BookStoreApi.http` file:

   ```
   POST {{BookStoreApi_HostAddress}}/api/books
   Content-Type: application/json

   {
     //Book
   }
   
   ###
   ```

1. Replace the Book comment with a book object as the JSON request body:

   ```
   POST {{BookStoreApi_HostAddress}}/api/books
   Content-Type: application/json

    {
      "Name": "The Pragmatic Programmer",
      "Price": 49.99,
      "Category": "Computers",
      "Author": "Andy Hunt"
    }
   
   ###
   ```

1. Select the **Send request** link above the `POST` request line.

   The POST request is sent to the app, and the response is displayed in the **Response** pane. The response should include the newly created book with its assigned ID.

1. Lastly, to delete a book, right-click the `/api/books/{id}, params (string id)` **DELETE** endpoint and select **Generate request**.

   The following content is appended to the `BookStoreApi.http` file:

   ```
   DELETE {{BookStoreApi_HostAddress}}/api/Books/{{id}}
    
   ###
   ```

1. Replace the `id` variable with one of the IDs returned from the earlier request, and click **Send request**. For example:

   ```
   DELETE {{BookStoreApi_HostAddress}}/api/Books/67f417517ce1b36aeab71236

   ###
   ```

# [Visual Studio Code](#tab/visual-studio-code)

This tutorial uses the [OpenAPI specification (openapi.json) and Swagger UI](xref:tutorials/web-api-help-pages-using-swagger) to test the API.

1. Install Swagger UI by running the following command:

  ```dotnetcli
  dotnet add package NSwag.AspNetCore
  ```

The previous command adds the [NSwag.AspNetCore](https://www.nuget.org/packages/NSwag.AspNetCore/) package, which contains tools to generate Swagger documents and UI.
Because our project is using OpenAPI, we only use the NSwag package to generate the Swagger UI.

1. Configure Swagger middleware

In `Program.cs`, add the following highlighted code:

:::code language="csharp" source="first-mongo-app/samples/9.x/BookStoreApi/Program.cs" id="snippet_UseSwagger" highlight="6-9":::

The previous code enables the Swagger middleware for serving the generated JSON document using the Swagger UI. Swagger is only enabled in a development environment. Enabling Swagger in a production environment could expose potentially sensitive details about the API's structure and implementation.

The app uses the OpenAPI document generated by OpenApi, located at `/openapi/v1.json`, to generate the UI.
View the generated OpenAPI specification for the `WeatherForecast` API while the project is running by navigating to `https://localhost:<port>/openapi/v1.json` in your browser.

The OpenAPI specification is a document in JSON format that describes the structure and capabilities of your API, including endpoints, request/response formats, parameters, and more. It's essentially a blueprint of your API that can be used by various tools to understand and interact with your API.

1. Build and run the app.

1. Navigate to `https://localhost:<port>/swagger` in your browser. Swagger provides a UI to test all the API endpoints based on the OpenAPI document.

1. Expand the **GET /api/books** endpoint and click the **Try it out** button.

1. Click the **Execute** button to send the request to the API.

1. The **Response body** section displays a JSON array with books similar to the following:

   ```json
   [
     {
       "Id": "61a6058e6c43f32854e51f51",
       "Name": "Design Patterns",
       "Price": 54.93,
       "Category": "Computers",
       "Author": "Ralph Johnson"
     },
     {
       "Id": "61a6058e6c43f32854e51f52",
       "Name": "Clean Code",
       "Price": 43.15,
       "Category": "Computers",
       "Author": "Robert C. Martin"
     }
   ]
   ```

1. Next, expand the **GET /api/books/{id}** endpoint and click **Try it out**.

1. Enter one of the book IDs from the previous response in the **id** field, then click **Execute**.

1. The **Response body** section displays the JSON object for the specified book. For example, the result for the ID `61a6058e6c43f32854e51f52` is similar to the following:

   ```json
   {
     "Id": "61a6058e6c43f32854e51f52",
     "Name": "Clean Code",
     "Price": 43.15,
     "Category": "Computers",
     "Author": "Robert C. Martin"
   }
   ```

1. To test creating a new book, expand the **POST /api/books** endpoint and click **Try it out**.

1. Replace the default request body with a new book object:

   ```json
   {
     "Name": "The Pragmatic Programmer",
     "Price": 49.99,
     "Category": "Computers",
     "Author": "Andy Hunt"
   }
   ```

1. Click **Execute** to send the request.

1. The response should have a status code of 201 (Created) and include the newly created book with its assigned ID in the response body.

1. Lastly, to delete a book record, expand the **DELETE /api/books/{id}** endpoint, click **Try it out**, and enter one of the book IDs from the previous response in the **id** field. Click **Execute** to send the request.
 
1. The response should have a status code of 204 (No Content), indicating that the book was successfully deleted. 
---

## Add authentication support to a web API

[!INCLUDE[](~/includes/DuendeIdentityServer.md)]

## Additional resources

* [View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/first-mongo-app/samples/9.x/BookStoreApi) ([how to download](xref:fundamentals/index#how-to-download-a-sample))
* <xref:web-api/index>
* <xref:web-api/action-return-types>
* [Create a web API with ASP.NET Core](/training/modules/build-web-api-aspnet-core/)

:::moniker-end

[!INCLUDE[](~/tutorials/first-mongo-app/includes/first-mongo-app8.md)]

[!INCLUDE[](~/tutorials/first-mongo-app/includes/first-mongo-app7.md)]

[!INCLUDE[](~/tutorials/first-mongo-app/includes/first-mongo-app6.md)]

[!INCLUDE[](~/tutorials/first-mongo-app/includes/first-mongo-app3-5.md)]
