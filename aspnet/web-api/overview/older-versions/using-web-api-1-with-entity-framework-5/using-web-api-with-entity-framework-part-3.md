---
title: "Part 3: Creating an Admin Controller | Microsoft Docs"
author: MikeWasson
description: ""
ms.author: riande
manager: wpickett
ms.date: 07/04/2012
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/older-versions/using-web-api-1-with-entity-framework-5/using-web-api-with-entity-framework-part-3
---
Part 3: Creating an Admin Controller
====================
by [Mike Wasson](https://github.com/MikeWasson)

[Download Completed Project](http://code.msdn.microsoft.com/ASP-NET-Web-API-with-afa30545)

## Add an Admin Controller

In this section, we'll add a Web API controller that supports CRUD (create, read, update, and delete) operations on products. The controller will use Entity Framework to communicate with the database layer. Only administrators will be able to use this controller. Customers will access the products through another controller.

In Solution Explorer, right-click the Controllers folder. Select **Add** and then **Controller**.

![](using-web-api-with-entity-framework-part-3/_static/image1.png)

In the **Add Controller** dialog, name the controller `AdminController`. Under **Template**, select &quot;API controller with read/write actions, using Entity Framework&quot;. Under **Model class**, select "Product (ProductStore.Models)". Under **Data Context**, select "&lt;New Data Context&gt;".

![](using-web-api-with-entity-framework-part-3/_static/image2.png)

> [!NOTE] If the **Model class** drop-down does not show any model classes, make sure you compiled the project. Entity Framework uses reflection, so it needs the compiled assembly.


Selecting "&lt;New Data Context&gt;" will open the **New Data Context** dialog. Name the data context `ProductStore.Models.OrdersContext`.

![](using-web-api-with-entity-framework-part-3/_static/image3.png)

Click **OK** to dismiss the **New Data Context** dialog. In the **Add Controller** dialog, click **Add**.

Here's what got added to the project:

- A class named `OrdersContext` that derives from **DbContext**. This class provides the glue between the POCO models and the database.
- A Web API controller named `AdminController`. This controller supports CRUD operations on `Product` instances. It uses the `OrdersContext` class to communicate with Entity Framework.
- A new database connection string in the Web.config file.

![](using-web-api-with-entity-framework-part-3/_static/image4.png)

Open the OrdersContext.cs file. Notice that the constructor specifies the name of the database connection string. This name refers to the connection string that was added to Web.config.

    public OrdersContext() : base("name=OrdersContext")

Add the following properties to the `OrdersContext` class:

    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

A **DbSet** represents a set of entities that can be queried. Here is the complete listing for the `OrdersContext` class:

    public class OrdersContext : DbContext
    {
        public OrdersContext() : base("name=OrdersContext")
        {
        }
    
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
    }

The `AdminController` class defines five methods that implement basic CRUD functionality. Each method corresponds to a URI that the client can invoke:

| Controller Method | Description | URI | HTTP Method |
| --- | --- | --- | --- |
| GetProducts | Gets all products. | api/products | GET |
| GetProduct | Finds a product by ID. | api/products/*id* | GET |
| PutProduct | Updates a product. | api/products/*id* | PUT |
| PostProduct | Creates a new product. | api/products | POST |
| DeleteProduct | Deletes a product. | api/products/*id* | DELETE |

Each method calls into `OrdersContext` to query the database. The methods that modify the collection (PUT, POST, and DELETE) call `db.SaveChanges` to persist the changes to the database. Controllers are created per HTTP request and then disposed, so it is necessary to persist changes before a method returns.

## Add a Database Initializer

Entity Framework has a nice feature that lets you populate the database on startup, and automatically recreate the database whenever the models change. This feature is useful during development, because you always have some test data, even if you change the models.

In Solution Explorer, right-click the Models folder and create a new class named `OrdersContextInitializer`. Paste in the following implementation:

    namespace ProductStore.Models
    {
        using System;
        using System.Collections.Generic;
        using System.Data.Entity;
    
        public class OrdersContextInitializer : DropCreateDatabaseIfModelChanges<OrdersContext>
        {
            protected override void Seed(OrdersContext context)
            {
                var products = new List<Product>()            
                {
                    new Product() { Name = "Tomato Soup", Price = 1.39M, ActualCost = .99M },
                    new Product() { Name = "Hammer", Price = 16.99M, ActualCost = 10 },
                    new Product() { Name = "Yo yo", Price = 6.99M, ActualCost = 2.05M }
                };
    
                products.ForEach(p => context.Products.Add(p));
                context.SaveChanges();
    
                var order = new Order() { Customer = "Bob" };
                var od = new List<OrderDetail>()
                {
                    new OrderDetail() { Product = products[0], Quantity = 2, Order = order},
                    new OrderDetail() { Product = products[1], Quantity = 4, Order = order }
                };
                context.Orders.Add(order);
                od.ForEach(o => context.OrderDetails.Add(o));
    
                context.SaveChanges();
            }
        }
    }

By inheriting from the **DropCreateDatabaseIfModelChanges** class, we are telling Entity Framework to drop the database whenever we modify the model classes. When Entity Framework creates (or recreates) the database, it calls the **Seed** method to populate the tables. We use the **Seed** method to add some example products plus an example order.

This feature is great for testing, but don't use the **DropCreateDatabaseIfModelChanges** class in production,, because you could lose your data if someone changes a model class.

Next, open Global.asax and add the following code to the **Application\_Start** method:

    System.Data.Entity.Database.SetInitializer(
        new ProductStore.Models.OrdersContextInitializer());

## Send a Request to the Controller

At this point, we haven't written any client code, but you can invoke the web API using a web browser or an HTTP debugging tool such as [Fiddler](http://www.fiddler2.com/fiddler2/). In Visual Studio, press F5 to start debugging. Your web browser will open to `http://localhost:*portnum*/`, where *portnum* is some port number.

Send an HTTP request to "`http://localhost:*portnum*/api/admin`. The first request may be slow to complete, because Entify Framework needs to create and seed the database. The response should something similar to the following:

    HTTP/1.1 200 OK
    Server: ASP.NET Development Server/10.0.0.0
    Date: Mon, 18 Jun 2012 04:30:33 GMT
    X-AspNet-Version: 4.0.30319
    Cache-Control: no-cache
    Pragma: no-cache
    Expires: -1
    Content-Type: application/json; charset=utf-8
    Content-Length: 175
    Connection: Close
    
    [{"Id":1,"Name":"Tomato Soup","Price":1.39,"ActualCost":0.99},{"Id":2,"Name":"Hammer",
    "Price":16.99,"ActualCost":10.00},{"Id":3,"Name":"Yo yo","Price":6.99,"ActualCost":
    2.05}]

>[!div class="step-by-step"] [Previous](using-web-api-with-entity-framework-part-2.md) [Next](using-web-api-with-entity-framework-part-4.md)