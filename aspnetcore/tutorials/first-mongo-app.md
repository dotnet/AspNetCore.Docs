---
title: Build web APIs with ASP.NET Core and MongoDB
author: pratik-khandelwal
description: This tutorial demonstrates how to build an ASP.NET Core web API using a MongoDB NoSQL database.
ms.author: scaddie
ms.custom: mvc
ms.date: 11/26/2018
uid: tutorials/first-mongo-app
---
# Create a web API with ASP.NET Core and MongoDB

By [Pratik Khandelwal](https://twitter.com/K2Prk) and [Scott Addie](https://twitter.com/Scott_Addie)

This tutorial creates a web API that performs Create, Read, Update, and Delete (CRUD) operations on a [MongoDB](https://www.mongodb.com/what-is-mongodb) database.

In this tutorial, you learn how to:

> [!div class="checklist"]
> * Configure MongoDB
> * Create a MongoDB database
> * Define a MongoDB collection and schema
> * Perform MongoDB CRUD operations from a web API

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/tutorials/first-mongo-app/sample) ([how to download](xref:index#how-to-download-a-sample))

## Prerequisites

* [.NET Core SDK 2.1 or later](https://www.microsoft.com/net/download/all)
* [MongoDB](https://docs.mongodb.com/manual/administration/install-community/)
* [Visual Studio 2017](https://www.visualstudio.com/downloads/) version 15.7.3 or later with the following workloads:
  * **.NET Core cross-platform development**
  * **ASP.NET and web development**

## Configure MongoDB

If using Windows, MongoDB is installed at *C:\Program Files\MongoDB* by default. Add *C:\Program Files\MongoDB\Server\<version_number>\bin* to the `Path` environment variable. This change enables MongoDB access from anywhere on your development machine.

To use MongoDB, create a database, make collections, and store documents in it:

1. Choose a folder on your development machine for storing the data. Note that the MongoDB CLI doesn't create new directories.
1. Open a command shell, and run the following to connect to MongoDB on port 27017:

    ```console
    mongod --dbpath <data_folder_path>
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

    ```json
    { "ok" : 1 }
    ```

1. Define a schema for the `Books` collection using the following command:

    ```console
    db.Books.insert({'BookId':1,'BookName':'Design Patterns','Price':3000,'Category':'Computers','Author':'Ralph Johnson'})
    ```

    The following result is displayed:

    ```console
    WriteResult({ "nInserted" : 1 })
    ```

1. View the entries in the database using the following command:

    ```console
    db.Books.find({})
    ```

    The following result is displayed:

    ```json
    { "_id" : ObjectId("5bfc4514d2c229b67213fd3b"), "BookId" : 1, "BookName" : "Design Patterns", "Price" : 3000, "Category" : "Computers", "Author" : "Ralph Johnson" }
    ```

    The schema adds an `_id` property. This property is an `ObjectId` and is generated automatically.

The database is ready. You can start creating the ASP.NET Core web API.

## Create the ASP.NET Core web API project

1. In Visual Studio, go to **File** > **New** > **Project**.
1. Select **ASP.NET Core Web Application**, name the project *BookMongo*, and click **OK**.
1. Select the **.NET Core** target framework and **ASP.NET Core 2.1**. Select the **API** project template, and click **OK**:
1. In the **Package Manager Console** window, navigate to the project root. Run the following command to install the .NET driver for MongoDB:

    ```powershell
    Install-Package MongoDB.Driver -Version 2.7.2
    ```

## Add a model

1. Add a *Models* folder to the project root.
1. Add a `Book` class to the *Models* folder with the following code:

    [!code-csharp[](first-mongo-app/sample/BookstoreAPI/Models/Book.cs)]

In the preceding class, the `Id` property is required for mapping the Common Language Runtime (CLR) object to the MongoDB collection. Other properties in the class are decorated with the `[BsonElement]` attribute. This represents the mapped property name in the MongoDB collection.

## Add a CRUD operations class

1. Add a *Services* folder to the project root.
1. Add a `BookService` class to the *Services* folder with the following code:

    [!code-csharp[](first-mongo-app/sample/BookstoreAPI/Services/BookService.cs?name=snippet_BookServiceClass)]

1. Add the MongoDB connection string to *appsettings.json*:

    [!code-csharp[](first-mongo-app/sample/BookstoreAPI/appsettings.json?highlight=2-4)]

    The preceding `BookstoreDb` property is accessed in the `BookService` class constructor.

1. In `Startup.ConfigureServices`, register the `BookService` class with the Dependency Injection system:

    [!code-csharp[](first-mongo-app/sample/BookstoreAPI/Startup.cs?name=snippet_ConfigureServices&highlight=3)]

    The preceding service registration is necessary to support constructor injection in consuming classes.

The `BookService` class uses the following `MongoDB.Driver` members to perform CRUD operations against the database:

* `MongoClient` &ndash; Reads the server instance for performing database operations. The constructor of this class is provided the MongoDB connection string:

    [!code-csharp[](first-mongo-app/sample/BookstoreAPI/Services/BookService.cs?name=snippet_BookServiceConstructor&highlight=3)]

* `IMongoDatabase` &ndash; Represents the Mongo database for performing operations. This tutorial uses the generic `GetCollection<T>(collection)` method on the interface to gain access to data in a specific collection. CRUD operations can be performed against the collection after this method is called. In the `GetCollection<T>(collection)` method call:
  * `collection` represents the collection name.
  * `T` represents the CLR object type stored in the collection.

`GetCollection<T>(collection)` returns a `MongoCollection` object representing the collection. In this tutorial, the following methods are invoked on the collection:

* `Find<T>` &ndash; Returns all documents in the collection matching the provided search criteria.
* `InsertOne` &ndash; Inserts the provided object as a new document in the collection.
* `ReplaceOne` &ndash; Replaces the single document matching the provided search criteria with the provided object.
* `DeleteOne` &ndash; Deletes a single document matching the provided search criteria.

## Add a controller

1. Right-click the *Controllers* folder in **Solution Explorer**. Select **Add** > **Controller**.
1. Choose the **API Controller - Empty** item template, and click **Add**.
1. Enter *BooksController* in the **Controller name** text box, and click **Add**.
1. Add the following code to *BooksController.cs*:

    [!code-csharp[](first-mongo-app/sample/BookstoreAPI/Controllers/BooksController.cs)]

    The preceding web API controller:

    * Uses the `BookService` class to perform CRUD operations.
    * Contains action methods to support GET, POST, PUT, and DELETE HTTP requests.
1. Build and run the app.
1. Navigate to `http://localhost:<random_port>/api/books` in your browser. The following JSON response is displayed:

    ```json
    [{"id":"5bfc4514d2c229b67213fd3b","bookId":1,"bookName":"Design Patterns","price":3000,"category":"Computers","author":"Ralph Johnson"}]
    ```

Using the Mongo C# Driver, one can easily connect to the MongoDB database and perform CRUD operations. Using ASP.NET Core, MongoDB data can be easily made available to various client apps for storing and reading data. This will provide you the power of ASP.NET Core with the flexibility of a MongoDB NoSQL database.
