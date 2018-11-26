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

By [Pratik Khandelwal](https://twitter.com/K2Prk)

This tutorial creates a web API app that performs CRUD operations on a [MongoDB](https://www.mongodb.com/what-is-mongodb).

### Prerequisites

[Visual Studio 2017 version 15.7.3 or later](https://visualstudio.microsoft.com/downloads/) with the following workloads:

* ASP.NET and web development
* .NET Core cross-platform development
* [MongoDB](https://www.mongodb.com/what-is-mongodb)
* A the MongoDB installation directory to the Path environment variable. Windows default to C:/Program Files/MongoDB/Server/3.4/bin

[.NET Core 2.1 SDK or later](https://www.microsoft.com/net/download)

### MongoDB implementation

To use MongoDB, we have to create a database, make collections, and store documents in it. To do that, create a a data folder where your data will be stored. You can choose any location on your system as the data folder. (Keep note that the MongoDB CLI doesn't create new directories).

Open a command shell:

```console
mongod --dbpath <enter-the-path>
```

This will connect to MongoDB on port 27017.

Open another command shell instance and run the following:	

```console
mongo
```

The preceding command connects to the default test database.

```console
useBookstoreDb
```

If it doesn't exist, a database named *BookstoreDb* is created. If the database does exist, its connection is opened for transactions.

Create a collection using following command:

```console
db.createCollection('Books')
```

The schema for the `Books` collection can be defined with the following command:

```console
db.Books.insert({'BookId':1,'BookName':'Design Patterns','Price':3000,'Category':'Computers', 'Author':' Ralph Johnson'})
```

To see the entries in the database, use the following command:

```console
db.Books.find({})
```

The preceding command displays the following:

```console
db.Books.find({})
{ "_id" : ObjectId("5ad08f91a4f1c236ef1b4fff"), "BookId" : 1, "BookName" : "Design Patterns", "Price" : 3000, "Category" : "Computers", "Author" : " Ralph Johnson" }
```

The schema will add `_id` property. This property will be an `ObjectId` which will be generated automatically.

### Create the ASP.NET Core web API Project

Follow these steps in Visual Studio:

* From the **File** menu, select **New** > **Project**.
* Select the **ASP.NET Core Web Application** template. Name the project *BookMongo* and click **OK**.
* In the **New ASP.NET Core Web Application - BookMongo** dialog, choose the ASP.NET Core version. Select the **API** template and click **OK**. Do not select **Enable Docker Support**.


Right-click the project in Solution Explorer and select Manage NuGet Packages.

Search for *MongoDB.Driver* and install the package.

![Package Manager](~/tutorials/first-mongo-app/_static/MongoDriver.png)

### Add a model

* Add a Models folder.
* Add Models/Book.cs with the following code:

[!code-csharp[](~/tutorials/first-mongo-app/sample/BookstoreAPI/Models/Book.cs?name=snippet_1)]

The preceding class contains:

* The Id property, which is required to map a Book to a MongoDB Collection.
* Properties with the BsonElement attribute. The BsonElement attribute is required to map properties in a MongoDB collection.

### Write a class for CRUD operations

Add a *DataAccess.cs* class file in the *Models* folder with the following code:

[!code-csharp[](~/tutorials/first-mongo-app/sample/BookstoreAPI/Models/DataAccess.cs?name=snippet_1)]

The preceding code uses the following classes:

**MongoServer** - This represents an instance of the MongoDB Server.

**MongoClient** - This class is used to read the server instance for performing operations on the database. The constructor of this class is passed with the MongoDB Connection string as shown in the following box:

```console
"mongodb://localhost:27017"
```

**MongoDatabase** - This represents Mongo Database for performing operations. This class provides following methods:

GetCollection<T>(*collection*) => T is the CLR object to be *collection*. The method returns a *MongoCollection*.

**FindAll()** - Returns all documents in collection()

**FindOne()** - Returns a single document based on Mongo Query object generated based on `_id`.

**Save()** - Save a new document in collection.

**Update()** - Update a document.

**Remove()** - Remove a document.

Our code in *DataAccess.cs* uses all these methods for performing CRUD operations on the data stored in the MongoDB server.

### Add a controller

Click right on the *Controllers* folder and add a controller

![Add Controller](~/tutorials/first-mongo-app/_static/addController.png)

Choose the *API Controller - Empty* to scaffold and name it *BooksController*.

In the controller class, add the following code:

[!code-csharp[](~/tutorials/first-mongo-app/sample/BookstoreAPI/Controllers/BooksController.cs?name=snippet_1)]

The preceding web API controller class uses DataAccess class for performing CRUD operations. The web API class contains GET, POST, PUT, DELETE methods for HTTP operations.

Build and run the app. Call the API from your browser. 
(localhost:port/api/controllerName)

```console
http://localhost:51496/api/Books
```

You will receive a similar JSON response depending on your data.

![Response](~/tutorials/first-mongo-app/_static/jsonResponse.png)

Using Mongo C# Driver, one can easily connect to the MongoDB database and perform CRUD operations. Using ASP.NET Core, MongoDB data can be easily made available to various client apps for storing and reading data. This will provide you the power of .NET Core with flexibility of MongoDB NoSQL database.

