---
title: Create a web API with ASP.NET Core and MongoDB
author: prkhandelwal
description: This tutorial demonstrates how to create an ASP.NET Core web API using a MongoDB NoSQL database.
monikerRange: '>= aspnetcore-2.1'
ms.author: scaddie
ms.custom: "mvc, seodec18"
ms.date: 08/17/2019
no-loc: [Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: tutorials/first-mongo-app
---
# Create a web API with ASP.NET Core and MongoDB

By [Pratik Khandelwal](https://twitter.com/K2Prk) and [Scott Addie](https://twitter.com/Scott_Addie)

::: moniker range=">= aspnetcore-3.0"

This tutorial creates a web API that performs Create, Read, Update, and Delete (CRUD) operations on a [MongoDB](https://www.mongodb.com/what-is-mongodb) NoSQL database.

In this tutorial, you learn how to:

> [!div class="checklist"]
> * Configure MongoDB
> * Create a MongoDB database
> * Define a MongoDB collection and schema
> * Perform MongoDB CRUD operations from a web API
> * Customize JSON serialization

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/first-mongo-app/samples) ([how to download](xref:index#how-to-download-a-sample))

## Prerequisites

# [Visual Studio](#tab/visual-studio)

* [.NET Core SDK 3.0 or later](https://dotnet.microsoft.com/download/dotnet-core)
* [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019) with the **ASP.NET and web development** workload
* [MongoDB](https://docs.mongodb.com/manual/tutorial/install-mongodb-on-windows/)

# [Visual Studio Code](#tab/visual-studio-code)

* [.NET Core SDK 3.0 or later](https://dotnet.microsoft.com/download/dotnet-core)
* [Visual Studio Code](https://code.visualstudio.com/download)
* [C# for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
* [MongoDB](https://docs.mongodb.com/manual/administration/install-community/)

# [Visual Studio for Mac](#tab/visual-studio-mac)

* [.NET Core SDK 3.0 or later](https://dotnet.microsoft.com/download/dotnet-core)
* [Visual Studio for Mac version 7.7 or later](https://visualstudio.microsoft.com/downloads/)
* [MongoDB](https://docs.mongodb.com/manual/tutorial/install-mongodb-on-os-x/)

---

## Configure MongoDB

If using Windows, MongoDB is installed at *C:\\Program Files\\MongoDB* by default. Add *C:\\Program Files\\MongoDB\\Server\\\<version_number>\\bin* to the `Path` environment variable. This change enables MongoDB access from anywhere on your development machine.

Use the mongo Shell in the following steps to create a database, make collections, and store documents. For more information on mongo Shell commands, see [Working with the mongo Shell](https://docs.mongodb.com/manual/mongo/#working-with-the-mongo-shell).

1. Choose a directory on your development machine for storing the data. For example, *C:\\BooksData* on Windows. Create the directory if it doesn't exist. The mongo Shell doesn't create new directories.
1. Open a command shell. Run the following command to connect to MongoDB on default port 27017. Remember to replace `<data_directory_path>` with the directory you chose in the previous step.

   ```console
   mongod --dbpath <data_directory_path>
   ```

1. Open another command shell instance. Connect to the default test database by running the following command:

   ```console
   mongo
   ```

1. Run the following in a command shell:

   ```console
   use BookstoreDb
   ```

   If it doesn't already exist, a database named *BookstoreDb* is created. If the database does exist, its connection is opened for transactions.

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
   db.Books.insertMany([{'Name':'Design Patterns','Price':54.93,'Category':'Computers','Author':'Ralph Johnson'}, {'Name':'Clean Code','Price':43.15,'Category':'Computers','Author':'Robert C. Martin'}])
   ```

   The following result is displayed:

   ```console
   {
     "acknowledged" : true,
     "insertedIds" : [
       ObjectId("5bfd996f7b8e48dc15ff215d"),
       ObjectId("5bfd996f7b8e48dc15ff215e")
     ]
   }
   ```
  
   > [!NOTE]
   > The ID's shown in this article will not match the IDs when you run this sample.

1. View the documents in the database using the following command:

   ```console
   db.Books.find({}).pretty()
   ```

   The following result is displayed:

   ```console
   {
     "_id" : ObjectId("5bfd996f7b8e48dc15ff215d"),
     "Name" : "Design Patterns",
     "Price" : 54.93,
     "Category" : "Computers",
     "Author" : "Ralph Johnson"
   }
   {
     "_id" : ObjectId("5bfd996f7b8e48dc15ff215e"),
     "Name" : "Clean Code",
     "Price" : 43.15,
     "Category" : "Computers",
     "Author" : "Robert C. Martin"
   }
   ```

   The schema adds an autogenerated `_id` property of type `ObjectId` for each document.

The database is ready. You can start creating the ASP.NET Core web API.

## Create the ASP.NET Core web API project

# [Visual Studio](#tab/visual-studio)

1. Go to **File** > **New** > **Project**.
1. Select the **ASP.NET Core Web Application** project type, and select **Next**.
1. Name the project *BooksApi*, and select **Create**.
1. Select the **.NET Core** target framework and **ASP.NET Core 3.0**. Select the **API** project template, and select **Create**.
1. Visit the [NuGet Gallery: MongoDB.Driver](https://www.nuget.org/packages/MongoDB.Driver/) to determine the latest stable version of the .NET driver for MongoDB. In the **Package Manager Console** window, navigate to the project root. Run the following command to install the .NET driver for MongoDB:

   ```powershell
   Install-Package MongoDB.Driver -Version {VERSION}
   ```

# [Visual Studio Code](#tab/visual-studio-code)

1. Run the following commands in a command shell:

   ```dotnetcli
   dotnet new webapi -o BooksApi
   code BooksApi
   ```

   A new ASP.NET Core web API project targeting .NET Core is generated and opened in Visual Studio Code.

1. After the status bar's OmniSharp flame icon turns green, a dialog asks **Required assets to build and debug are missing from 'BooksApi'. Add them?**. Select **Yes**.
1. Visit the [NuGet Gallery: MongoDB.Driver](https://www.nuget.org/packages/MongoDB.Driver/) to determine the latest stable version of the .NET driver for MongoDB. Open **Integrated Terminal** and navigate to the project root. Run the following command to install the .NET driver for MongoDB:

   ```dotnetcli
   dotnet add BooksApi.csproj package MongoDB.Driver -v {VERSION}
   ```

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. In Visual Studio for Mac earlier than version 8.6, select **File** > **New Solution** > **.NET Core** > **App** from the sidebar. In version 8.6 or later, select **File** > **New Solution** > **Web and Console** > **App** from the sidebar.
1. Select the **ASP.NET Core** > **API** C# project template, and select **Next**.
1. Select **.NET Core 3.1** from the **Target Framework** drop-down list, and select **Next**.
1. Enter *BooksApi* for the **Project Name**, and select **Create**.
1. In the **Solution** pad, right-click the project's **Dependencies** node and select **Add Packages**.
1. Enter *MongoDB.Driver* in the search box, select the *MongoDB.Driver* package, and select **Add Package**.
1. Select the **Accept** button in the **License Acceptance** dialog.

---

## Add an entity model

1. Add a *Models* directory to the project root.
1. Add a `Book` class to the *Models* directory with the following code:

   ```csharp
   using MongoDB.Bson;
   using MongoDB.Bson.Serialization.Attributes;

   namespace BooksApi.Models
   {
       public class Book
       {
           [BsonId]
           [BsonRepresentation(BsonType.ObjectId)]
           public string Id { get; set; }

           [BsonElement("Name")]
           public string BookName { get; set; }

           public decimal Price { get; set; }

           public string Category { get; set; }

           public string Author { get; set; }
       }
   }
   ```

   In the preceding class, the `Id` property:

   * Is required for mapping the Common Language Runtime (CLR) object to the MongoDB collection.
   * Is annotated with [`[BsonId]`](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/T_MongoDB_Bson_Serialization_Attributes_BsonIdAttribute.htm) to designate this property as the document's primary key.
   * Is annotated with [`[BsonRepresentation(BsonType.ObjectId)]`](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/T_MongoDB_Bson_Serialization_Attributes_BsonRepresentationAttribute.htm) to allow passing the parameter as type `string` instead of an [ObjectId](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/T_MongoDB_Bson_ObjectId.htm) structure. Mongo handles the conversion from `string` to `ObjectId`.

   The `BookName` property is annotated with the [`[BsonElement]`](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/T_MongoDB_Bson_Serialization_Attributes_BsonElementAttribute.htm) attribute. The attribute's value of `Name` represents the property name in the MongoDB collection.

## Add a configuration model

1. Add the following database configuration values to *appsettings.json*:

   [!code-json[](first-mongo-app/samples/3.x/SampleApp/appsettings.json?highlight=2-6)]

1. Add a *BookstoreDatabaseSettings.cs* file to the *Models* directory with the following code:

   [!code-csharp[](first-mongo-app/samples/3.x/SampleApp/Models/BookstoreDatabaseSettings.cs)]

   The preceding `BookstoreDatabaseSettings` class is used to store the *appsettings.json* file's `BookstoreDatabaseSettings` property values. The JSON and C# property names are named identically to ease the mapping process.

1. Add the following highlighted code to `Startup.ConfigureServices`:

   [!code-csharp[](first-mongo-app/samples_snapshot/3.x/SampleApp/Startup.ConfigureServices.AddDbSettings.cs?highlight=3-8)]

   In the preceding code:

   * The configuration instance to which the *appsettings.json* file's `BookstoreDatabaseSettings` section binds is registered in the Dependency Injection (DI) container. For example, a `BookstoreDatabaseSettings` object's `ConnectionString` property is populated with the `BookstoreDatabaseSettings:ConnectionString` property in *appsettings.json*.
   * The `IBookstoreDatabaseSettings` interface is registered in DI with a singleton [service lifetime](xref:fundamentals/dependency-injection#service-lifetimes). When injected, the interface instance resolves to a `BookstoreDatabaseSettings` object.

1. Add the following code to the top of *Startup.cs* to resolve the `BookstoreDatabaseSettings` and `IBookstoreDatabaseSettings` references:

   [!code-csharp[](first-mongo-app/samples/3.x/SampleApp/Startup.cs?name=snippet_UsingBooksApiModels)]

## Add a CRUD operations service

1. Add a *Services* directory to the project root.
1. Add a `BookService` class to the *Services* directory with the following code:

   [!code-csharp[](first-mongo-app/samples/3.x/SampleApp/Services/BookService.cs?name=snippet_BookServiceClass)]

   In the preceding code, an `IBookstoreDatabaseSettings` instance is retrieved from DI via constructor injection. This technique provides access to the *appsettings.json* configuration values that were added in the [Add a configuration model](#add-a-configuration-model) section.

1. Add the following highlighted code to `Startup.ConfigureServices`:

   [!code-csharp[](first-mongo-app/samples_snapshot/3.x/SampleApp/Startup.ConfigureServices.AddSingletonService.cs?highlight=9)]

   In the preceding code, the `BookService` class is registered with DI to support constructor injection in consuming classes. The singleton service lifetime is most appropriate because `BookService` takes a direct dependency on `MongoClient`. Per the official [Mongo Client reuse guidelines](https://mongodb.github.io/mongo-csharp-driver/2.8/reference/driver/connecting/#re-use), `MongoClient` should be registered in DI with a singleton service lifetime.

1. Add the following code to the top of *Startup.cs* to resolve the `BookService` reference:

   [!code-csharp[](first-mongo-app/samples/3.x/SampleApp/Startup.cs?name=snippet_UsingBooksApiServices)]

The `BookService` class uses the following `MongoDB.Driver` members to perform CRUD operations against the database:

* [MongoClient](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/T_MongoDB_Driver_MongoClient.htm): Reads the server instance for performing database operations. The constructor of this class is provided the MongoDB connection string:

  [!code-csharp[](first-mongo-app/samples/3.x/SampleApp/Services/BookService.cs?name=snippet_BookServiceConstructor&highlight=3)]

* [IMongoDatabase](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/T_MongoDB_Driver_IMongoDatabase.htm): Represents the Mongo database for performing operations. This tutorial uses the generic [GetCollection\<TDocument>(collection)](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/M_MongoDB_Driver_IMongoDatabase_GetCollection__1.htm) method on the interface to gain access to data in a specific collection. Perform CRUD operations against the collection after this method is called. In the `GetCollection<TDocument>(collection)` method call:

  * `collection` represents the collection name.
  * `TDocument` represents the CLR object type stored in the collection.

`GetCollection<TDocument>(collection)` returns a [MongoCollection](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/T_MongoDB_Driver_MongoCollection.htm) object representing the collection. In this tutorial, the following methods are invoked on the collection:

* [DeleteOne](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/M_MongoDB_Driver_IMongoCollection_1_DeleteOne.htm): Deletes a single document matching the provided search criteria.
* [Find\<TDocument>](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/M_MongoDB_Driver_IMongoCollectionExtensions_Find__1_1.htm): Returns all documents in the collection matching the provided search criteria.
* [InsertOne](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/M_MongoDB_Driver_IMongoCollection_1_InsertOne.htm): Inserts the provided object as a new document in the collection.
* [ReplaceOne](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/M_MongoDB_Driver_IMongoCollection_1_ReplaceOne.htm): Replaces the single document matching the provided search criteria with the provided object.

## Add a controller

Add a `BooksController` class to the *Controllers* directory with the following code:

[!code-csharp[](first-mongo-app/samples/3.x/SampleApp/Controllers/BooksController.cs)]

The preceding web API controller:

* Uses the `BookService` class to perform CRUD operations.
* Contains action methods to support GET, POST, PUT, and DELETE HTTP requests.
* Calls <xref:System.Web.Http.ApiController.CreatedAtRoute*> in the `Create` action method to return an [HTTP 201](https://www.w3.org/Protocols/rfc2616/rfc2616-sec10.html) response. Status code 201 is the standard response for an HTTP POST method that creates a new resource on the server. `CreatedAtRoute` also adds a `Location` header to the response. The `Location` header specifies the URI of the newly created book.

## Test the web API

1. Build and run the app.

1. Navigate to `http://localhost:<port>/api/books` to test the controller's parameterless `Get` action method. The following JSON response is displayed:

   ```json
   [
     {
       "id":"5bfd996f7b8e48dc15ff215d",
       "bookName":"Design Patterns",
       "price":54.93,
       "category":"Computers",
       "author":"Ralph Johnson"
     },
     {
       "id":"5bfd996f7b8e48dc15ff215e",
       "bookName":"Clean Code",
       "price":43.15,
       "category":"Computers",
       "author":"Robert C. Martin"
     }
   ]
   ```

1. Navigate to `http://localhost:<port>/api/books/{id here}` to test the controller's overloaded `Get` action method. The following JSON response is displayed:

   ```json
   {
     "id":"{ID}",
     "bookName":"Clean Code",
     "price":43.15,
     "category":"Computers",
     "author":"Robert C. Martin"
   }
   ```

## Configure JSON serialization options

There are two details to change about the JSON responses returned in the [Test the web API](#test-the-web-api) section:

* The property names' default camel casing should be changed to match the Pascal casing of the CLR object's property names.
* The `bookName` property should be returned as `Name`.

To satisfy the preceding requirements, make the following changes:

1. Json.NET has been removed from ASP.NET shared framework. Add a package reference to [`Microsoft.AspNetCore.Mvc.NewtonsoftJson`](https://nuget.org/packages/Microsoft.AspNetCore.Mvc.NewtonsoftJson).

1. In `Startup.ConfigureServices`, chain the following highlighted code on to the `AddControllers` method call:

   [!code-csharp[](first-mongo-app/samples/3.x/SampleApp/Startup.cs?name=snippet_ConfigureServices&highlight=12)]

   With the preceding change, property names in the web API's serialized JSON response match their corresponding property names in the CLR object type. For example, the `Book` class's `Author` property serializes as `Author`.

1. In *Models/Book.cs*, annotate the `BookName` property with the following [`[JsonProperty]`](https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonPropertyAttribute.htm) attribute:

   [!code-csharp[](first-mongo-app/samples/3.x/SampleApp/Models/Book.cs?name=snippet_BookNameProperty&highlight=2)]

   The `[JsonProperty]` attribute's value of `Name` represents the property name in the web API's serialized JSON response.

1. Add the following code to the top of *Models/Book.cs* to resolve the `[JsonProperty]` attribute reference:

   [!code-csharp[](first-mongo-app/samples/3.x/SampleApp/Models/Book.cs?name=snippet_NewtonsoftJsonImport)]

1. Repeat the steps defined in the [Test the web API](#test-the-web-api) section. Notice the difference in JSON property names.

::: moniker-end

::: moniker range="< aspnetcore-3.0"

This tutorial creates a web API that performs Create, Read, Update, and Delete (CRUD) operations on a [MongoDB](https://www.mongodb.com/what-is-mongodb) NoSQL database.

In this tutorial, you learn how to:

> [!div class="checklist"]
> * Configure MongoDB
> * Create a MongoDB database
> * Define a MongoDB collection and schema
> * Perform MongoDB CRUD operations from a web API
> * Customize JSON serialization

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/tutorials/first-mongo-app/samples) ([how to download](xref:index#how-to-download-a-sample))

## Prerequisites

# [Visual Studio](#tab/visual-studio)

* [.NET Core SDK 2.2](https://dotnet.microsoft.com/download/dotnet-core)
* [Visual Studio 2019](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=inline+link&utm_content=download+vs2019) with the **ASP.NET and web development** workload
* [MongoDB](https://docs.mongodb.com/manual/tutorial/install-mongodb-on-windows/)

# [Visual Studio Code](#tab/visual-studio-code)

* [.NET Core SDK 2.2](https://dotnet.microsoft.com/download/dotnet-core)
* [Visual Studio Code](https://code.visualstudio.com/download)
* [C# for Visual Studio Code](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
* [MongoDB](https://docs.mongodb.com/manual/administration/install-community/)

# [Visual Studio for Mac](#tab/visual-studio-mac)

* [.NET Core SDK 2.2](https://dotnet.microsoft.com/download/dotnet-core)
* [Visual Studio for Mac version 7.7 or later](https://visualstudio.microsoft.com/downloads/)
* [MongoDB](https://docs.mongodb.com/manual/tutorial/install-mongodb-on-os-x/)

---

## Configure MongoDB

If using Windows, MongoDB is installed at *C:\\Program Files\\MongoDB* by default. Add *C:\\Program Files\\MongoDB\\Server\\\<version_number>\\bin* to the `Path` environment variable. This change enables MongoDB access from anywhere on your development machine.

Use the mongo Shell in the following steps to create a database, make collections, and store documents. For more information on mongo Shell commands, see [Working with the mongo Shell](https://docs.mongodb.com/manual/mongo/#working-with-the-mongo-shell).

1. Choose a directory on your development machine for storing the data. For example, *C:\\BooksData* on Windows. Create the directory if it doesn't exist. The mongo Shell doesn't create new directories.
1. Open a command shell. Run the following command to connect to MongoDB on default port 27017. Remember to replace `<data_directory_path>` with the directory you chose in the previous step.

   ```console
   mongod --dbpath <data_directory_path>
   ```

1. Open another command shell instance. Connect to the default test database by running the following command:

   ```console
   mongo
   ```

1. Run the following in a command shell:

   ```console
   use BookstoreDb
   ```

   If it doesn't already exist, a database named *BookstoreDb* is created. If the database does exist, its connection is opened for transactions.

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
   db.Books.insertMany([{'Name':'Design Patterns','Price':54.93,'Category':'Computers','Author':'Ralph Johnson'}, {'Name':'Clean Code','Price':43.15,'Category':'Computers','Author':'Robert C. Martin'}])
   ```

   The following result is displayed:

   ```console
   {
     "acknowledged" : true,
     "insertedIds" : [
       ObjectId("5bfd996f7b8e48dc15ff215d"),
       ObjectId("5bfd996f7b8e48dc15ff215e")
     ]
   }
   ```
  
   > [!NOTE]
   > The ID's shown in this article will not match the IDs when you run this sample.

1. View the documents in the database using the following command:

   ```console
   db.Books.find({}).pretty()
   ```

   The following result is displayed:

   ```console
   {
     "_id" : ObjectId("5bfd996f7b8e48dc15ff215d"),
     "Name" : "Design Patterns",
     "Price" : 54.93,
     "Category" : "Computers",
     "Author" : "Ralph Johnson"
   }
   {
     "_id" : ObjectId("5bfd996f7b8e48dc15ff215e"),
     "Name" : "Clean Code",
     "Price" : 43.15,
     "Category" : "Computers",
     "Author" : "Robert C. Martin"
   }
   ```

   The schema adds an autogenerated `_id` property of type `ObjectId` for each document.

The database is ready. You can start creating the ASP.NET Core web API.

## Create the ASP.NET Core web API project

# [Visual Studio](#tab/visual-studio)

1. Go to **File** > **New** > **Project**.
1. Select the **ASP.NET Core Web Application** project type, and select **Next**.
1. Name the project *BooksApi*, and select **Create**.
1. Select the **.NET Core** target framework and **ASP.NET Core 2.2**. Select the **API** project template, and select **Create**.
1. Visit the [NuGet Gallery: MongoDB.Driver](https://www.nuget.org/packages/MongoDB.Driver/) to determine the latest stable version of the .NET driver for MongoDB. In the **Package Manager Console** window, navigate to the project root. Run the following command to install the .NET driver for MongoDB:

   ```powershell
   Install-Package MongoDB.Driver -Version {VERSION}
   ```

# [Visual Studio Code](#tab/visual-studio-code)

1. Run the following commands in a command shell:

   ```dotnetcli
   dotnet new webapi -o BooksApi
   code BooksApi
   ```

   A new ASP.NET Core web API project targeting .NET Core is generated and opened in Visual Studio Code.

1. After the status bar's OmniSharp flame icon turns green, a dialog asks **Required assets to build and debug are missing from 'BooksApi'. Add them?**. Select **Yes**.
1. Visit the [NuGet Gallery: MongoDB.Driver](https://www.nuget.org/packages/MongoDB.Driver/) to determine the latest stable version of the .NET driver for MongoDB. Open **Integrated Terminal** and navigate to the project root. Run the following command to install the .NET driver for MongoDB:

   ```dotnetcli
   dotnet add BooksApi.csproj package MongoDB.Driver -v {VERSION}
   ```

# [Visual Studio for Mac](#tab/visual-studio-mac)

1. In Visual Studio for Mac earlier than version 8.6, select **File** > **New Solution** > **.NET Core** > **App** from the sidebar. In version 8.6 or later, select **File** > **New Solution** > **Web and Console** > **App** from the sidebar.
1. Select the **ASP.NET Core Web API** C# project template, and select **Next**.
1. Select **.NET Core 2.2** from the **Target Framework** drop-down list, and select **Next**.
1. Enter *BooksApi* for the **Project Name**, and select **Create**.
1. In the **Solution** pad, right-click the project's **Dependencies** node and select **Add Packages**.
1. Enter *MongoDB.Driver* in the search box, select the *MongoDB.Driver* package, and select **Add Package**.
1. Select the **Accept** button in the **License Acceptance** dialog.

---

## Add an entity model

1. Add a *Models* directory to the project root.
1. Add a `Book` class to the *Models* directory with the following code:

   ```csharp
   using MongoDB.Bson;
   using MongoDB.Bson.Serialization.Attributes;

   namespace BooksApi.Models
   {
       public class Book
       {
           [BsonId]
           [BsonRepresentation(BsonType.ObjectId)]
           public string Id { get; set; }

           [BsonElement("Name")]
           public string BookName { get; set; }

           public decimal Price { get; set; }

           public string Category { get; set; }

           public string Author { get; set; }
       }
   }
   ```

   In the preceding class, the `Id` property:

   * Is required for mapping the Common Language Runtime (CLR) object to the MongoDB collection.
   * Is annotated with [`[BsonId]`](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/T_MongoDB_Bson_Serialization_Attributes_BsonIdAttribute.htm) to designate this property as the document's primary key.
   * Is annotated with [`[BsonRepresentation(BsonType.ObjectId)]`](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/T_MongoDB_Bson_Serialization_Attributes_BsonRepresentationAttribute.htm) to allow passing the parameter as type `string` instead of an [ObjectId](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/T_MongoDB_Bson_ObjectId.htm) structure. Mongo handles the conversion from `string` to `ObjectId`.

   The `BookName` property is annotated with the [`[BsonElement]`](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/T_MongoDB_Bson_Serialization_Attributes_BsonElementAttribute.htm) attribute. The attribute's value of `Name` represents the property name in the MongoDB collection.

## Add a configuration model

1. Add the following database configuration values to *appsettings.json*:

   [!code-json[](first-mongo-app/samples/2.x/SampleApp/appsettings.json?highlight=2-6)]

1. Add a *BookstoreDatabaseSettings.cs* file to the *Models* directory with the following code:

   [!code-csharp[](first-mongo-app/samples/2.x/SampleApp/Models/BookstoreDatabaseSettings.cs)]

   The preceding `BookstoreDatabaseSettings` class is used to store the *appsettings.json* file's `BookstoreDatabaseSettings` property values. The JSON and C# property names are named identically to ease the mapping process.

1. Add the following highlighted code to `Startup.ConfigureServices`:

   [!code-csharp[](first-mongo-app/samples_snapshot/2.x/SampleApp/Startup.ConfigureServices.AddDbSettings.cs?highlight=3-7)]

   In the preceding code:

   * The configuration instance to which the *appsettings.json* file's `BookstoreDatabaseSettings` section binds is registered in the Dependency Injection (DI) container. For example, a `BookstoreDatabaseSettings` object's `ConnectionString` property is populated with the `BookstoreDatabaseSettings:ConnectionString` property in *appsettings.json*.
   * The `IBookstoreDatabaseSettings` interface is registered in DI with a singleton [service lifetime](xref:fundamentals/dependency-injection#service-lifetimes). When injected, the interface instance resolves to a `BookstoreDatabaseSettings` object.

1. Add the following code to the top of *Startup.cs* to resolve the `BookstoreDatabaseSettings` and `IBookstoreDatabaseSettings` references:

   [!code-csharp[](first-mongo-app/samples/2.x/SampleApp/Startup.cs?name=snippet_UsingBooksApiModels)]

## Add a CRUD operations service

1. Add a *Services* directory to the project root.
1. Add a `BookService` class to the *Services* directory with the following code:

   [!code-csharp[](first-mongo-app/samples/2.x/SampleApp/Services/BookService.cs?name=snippet_BookServiceClass)]

   In the preceding code, an `IBookstoreDatabaseSettings` instance is retrieved from DI via constructor injection. This technique provides access to the *appsettings.json* configuration values that were added in the [Add a configuration model](#add-a-configuration-model) section.

1. Add the following highlighted code to `Startup.ConfigureServices`:

   [!code-csharp[](first-mongo-app/samples_snapshot/2.x/SampleApp/Startup.ConfigureServices.AddSingletonService.cs?highlight=9)]

   In the preceding code, the `BookService` class is registered with DI to support constructor injection in consuming classes. The singleton service lifetime is most appropriate because `BookService` takes a direct dependency on `MongoClient`. Per the official [Mongo Client reuse guidelines](https://mongodb.github.io/mongo-csharp-driver/2.8/reference/driver/connecting/#re-use), `MongoClient` should be registered in DI with a singleton service lifetime.

1. Add the following code to the top of *Startup.cs* to resolve the `BookService` reference:

   [!code-csharp[](first-mongo-app/samples/2.x/SampleApp/Startup.cs?name=snippet_UsingBooksApiServices)]

The `BookService` class uses the following `MongoDB.Driver` members to perform CRUD operations against the database:

* [MongoClient](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/T_MongoDB_Driver_MongoClient.htm): Reads the server instance for performing database operations. The constructor of this class is provided with the MongoDB connection string:

  [!code-csharp[](first-mongo-app/samples/2.x/SampleApp/Services/BookService.cs?name=snippet_BookServiceConstructor&highlight=3)]

* [IMongoDatabase](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/T_MongoDB_Driver_IMongoDatabase.htm): Represents the Mongo database for performing operations. This tutorial uses the generic [GetCollection\<TDocument>(collection)](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/M_MongoDB_Driver_IMongoDatabase_GetCollection__1.htm) method on the interface to gain access to data in a specific collection. Perform CRUD operations against the collection after this method is called. In the `GetCollection<TDocument>(collection)` method call:

  * `collection` represents the collection name.
  * `TDocument` represents the CLR object type stored in the collection.

`GetCollection<TDocument>(collection)` returns a [MongoCollection](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/T_MongoDB_Driver_MongoCollection.htm) object representing the collection. In this tutorial, the following methods are invoked on the collection:

* [DeleteOne](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/M_MongoDB_Driver_IMongoCollection_1_DeleteOne.htm): Deletes a single document matching the provided search criteria.
* [Find\<TDocument>](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/M_MongoDB_Driver_IMongoCollectionExtensions_Find__1_1.htm): Returns all documents in the collection matching the provided search criteria.
* [InsertOne](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/M_MongoDB_Driver_IMongoCollection_1_InsertOne.htm): Inserts the provided object as a new document in the collection.
* [ReplaceOne](https://mongodb.github.io/mongo-csharp-driver/2.11/apidocs/html/M_MongoDB_Driver_IMongoCollection_1_ReplaceOne.htm): Replaces the single document matching the provided search criteria with the provided object.

## Add a controller

Add a `BooksController` class to the *Controllers* directory with the following code:

[!code-csharp[](first-mongo-app/samples/2.x/SampleApp/Controllers/BooksController.cs)]

The preceding web API controller:

* Uses the `BookService` class to perform CRUD operations.
* Contains action methods to support GET, POST, PUT, and DELETE HTTP requests.
* Calls <xref:System.Web.Http.ApiController.CreatedAtRoute*> in the `Create` action method to return an [HTTP 201](https://www.w3.org/Protocols/rfc2616/rfc2616-sec10.html) response. Status code 201 is the standard response for an HTTP POST method that creates a new resource on the server. `CreatedAtRoute` also adds a `Location` header to the response. The `Location` header specifies the URI of the newly created book.

## Test the web API

1. Build and run the app.

1. Navigate to `http://localhost:<port>/api/books` to test the controller's parameterless `Get` action method. The following JSON response is displayed:

   ```json
   [
     {
       "id":"5bfd996f7b8e48dc15ff215d",
       "bookName":"Design Patterns",
       "price":54.93,
       "category":"Computers",
       "author":"Ralph Johnson"
     },
     {
       "id":"5bfd996f7b8e48dc15ff215e",
       "bookName":"Clean Code",
       "price":43.15,
       "category":"Computers",
       "author":"Robert C. Martin"
     }
   ]
   ```

1. Navigate to `http://localhost:<port>/api/books/{id here}` to test the controller's overloaded `Get` action method. The following JSON response is displayed:

   ```json
   {
     "id":"{ID}",
     "bookName":"Clean Code",
     "price":43.15,
     "category":"Computers",
     "author":"Robert C. Martin"
   }
   ```

## Configure JSON serialization options

There are two details to change about the JSON responses returned in the [Test the web API](#test-the-web-api) section:

* The property names' default camel casing should be changed to match the Pascal casing of the CLR object's property names.
* The `bookName` property should be returned as `Name`.

To satisfy the preceding requirements, make the following changes:

1. In `Startup.ConfigureServices`, chain the following highlighted code on to the `AddMvc` method call:

   [!code-csharp[](first-mongo-app/samples/2.x/SampleApp/Startup.cs?name=snippet_ConfigureServices&highlight=12)]

   With the preceding change, property names in the web API's serialized JSON response match their corresponding property names in the CLR object type. For example, the `Book` class's `Author` property serializes as `Author`.

1. In *Models/Book.cs*, annotate the `BookName` property with the following [`[JsonProperty]`](https://www.newtonsoft.com/json/help/html/T_Newtonsoft_Json_JsonPropertyAttribute.htm) attribute:

   [!code-csharp[](first-mongo-app/samples/2.x/SampleApp/Models/Book.cs?name=snippet_BookNameProperty&highlight=2)]

   The `[JsonProperty]` attribute's value of `Name` represents the property name in the web API's serialized JSON response.

1. Add the following code to the top of *Models/Book.cs* to resolve the `[JsonProperty]` attribute reference:

   [!code-csharp[](first-mongo-app/samples/2.x/SampleApp/Models/Book.cs?name=snippet_NewtonsoftJsonImport)]

1. Repeat the steps defined in the [Test the web API](#test-the-web-api) section. Notice the difference in JSON property names.

::: moniker-end

## Add authentication support to a web API

::: moniker range=">= aspnetcore-6.0"

[!INCLUDE[](~/includes/DuendeIdentityServer.md)]

::: moniker-end

::: moniker range="< aspnetcore-6.0"

[!INCLUDE[](~/includes/IdentityServer4.md)]

::: moniker-end

## Next steps

For more information on building ASP.NET Core web APIs, see the following resources:

* [YouTube version of this article](https://www.youtube.com/watch?v=7uJt_sOenyo&feature=youtu.be)
* <xref:web-api/index>
* <xref:web-api/action-return-types>
* [Microsoft Learn: Create a web API with ASP.NET Core](/learn/modules/build-web-api-aspnet-core/)
