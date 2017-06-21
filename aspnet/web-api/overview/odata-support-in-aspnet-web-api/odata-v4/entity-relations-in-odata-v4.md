---
uid: web-api/overview/odata-support-in-aspnet-web-api/odata-v4/entity-relations-in-odata-v4
title: "Entity Relations in OData v4 Using ASP.NET Web API 2.2 | Microsoft Docs"
author: MikeWasson
description: "Most data sets define relations between entities: Customers have orders; books have authors; products have suppliers. Using OData, clients can navigate over..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 06/26/2014
ms.topic: article
ms.assetid: 72657550-ec09-4779-9bfc-2fb15ecd51c7
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/odata-support-in-aspnet-web-api/odata-v4/entity-relations-in-odata-v4
msc.type: authoredcontent
---
Entity Relations in OData v4 Using ASP.NET Web API 2.2
====================
by [Mike Wasson](https://github.com/MikeWasson)

> Most data sets define relations between entities: Customers have orders; books have authors; products have suppliers. Using OData, clients can navigate over entity relations. Given a product, you can find the supplier. You can also create or remove relationships. For example, you can set the supplier for a product.
> 
> This tutorial shows how to support these operations in OData v4 using ASP.NET Web API. The tutorial builds on the tutorial [Create an OData v4 Endpoint Using ASP.NET Web API 2](create-an-odata-v4-endpoint.md).
> 
> ## Software versions used in the tutorial
> 
> 
> - Web API 2.1
> - OData v4
> - [Visual Studio 2013 Update 2](https://www.visualstudio.com/downloads/download-visual-studio-vs)
> - Entity Framework 6
> - .NET 4.5
> 
> 
> ## Tutorial versions
> 
> For the OData Version 3, see [Supporting Entity Relations in OData v3](https://asp.net/web-api/overview/odata-support-in-aspnet-web-api/odata-v3/working-with-entity-relations).


## Add a Supplier Entity

> [!NOTE]
> The tutorial builds on the tutorial [Create an OData v4 Endpoint Using ASP.NET Web API 2](create-an-odata-v4-endpoint.md).


First, we need a related entity. Add a class named `Supplier` in the Models folder.

[!code-csharp[Main](entity-relations-in-odata-v4/samples/sample1.cs)]

Add a navigation property to the `Product` class:

[!code-csharp[Main](entity-relations-in-odata-v4/samples/sample2.cs?highlight=13-15)]

Add a new **DbSet** to the `ProductsContext` class, so that Entity Framework will include the Supplier table in the database.

[!code-csharp[Main](entity-relations-in-odata-v4/samples/sample3.cs?highlight=10)]

In WebApiConfig.cs, add a &quot;Suppliers&quot; entity set to the entity data model:

[!code-csharp[Main](entity-relations-in-odata-v4/samples/sample4.cs?highlight=6)]

## Add a Suppliers Controller

Add a `SuppliersController` class to the Controllers folder.

[!code-csharp[Main](entity-relations-in-odata-v4/samples/sample5.cs)]

I won't show how to add CRUD operations for this controller. The steps are the same as for the Products controller (see [Create an OData v4 Endpoint](create-an-odata-v4-endpoint.md)).

## Getting Related Entities

To get the supplier for a product, the client sends a GET request:

[!code-console[Main](entity-relations-in-odata-v4/samples/sample6.cmd)]

To support this request, add the following method to the `ProductsController` class:

[!code-csharp[Main](entity-relations-in-odata-v4/samples/sample7.cs)]

This method uses a default naming convention

- Method name: GetX, where X is the navigation property.
- Parameter name: *key*

If you follow this naming convention, Web API automatically maps the HTTP request to the controller method.

Example HTTP request:

[!code-console[Main](entity-relations-in-odata-v4/samples/sample8.cmd)]

Example HTTP response:

[!code-console[Main](entity-relations-in-odata-v4/samples/sample9.cmd)]

### Getting a related collection

In the previous example, a product has one supplier. A navigation property can also return a collection. The following code gets the products for a supplier:

[!code-csharp[Main](entity-relations-in-odata-v4/samples/sample10.cs)]

In this case, the method returns an **IQueryable** instead of a **SingleResult&lt;T&gt;**

Example HTTP request:

[!code-console[Main](entity-relations-in-odata-v4/samples/sample11.cmd)]

Example HTTP response:

[!code-console[Main](entity-relations-in-odata-v4/samples/sample12.cmd)]

## Creating a Relationship Between Entities

OData supports creating or removing relationships between two existing entities. In OData v4 terminology, the relationship is a &quot;reference&quot;. (In OData v3, the relationship was called a *link*. The protocol differences don't matter for this tutorial.)

A reference has its own URI, with the form `/Entity/NavigationProperty/$ref`. For example, here is the URI to address the reference between a product and its supplier:

[!code-console[Main](entity-relations-in-odata-v4/samples/sample13.cmd)]

To add a relationship, the client sends a POST or PUT request to this address.

- PUT if the navigation property is a single entity, such as `Product.Supplier`.
- POST if the navigation property is a collection, such as `Supplier.Products`.

The body of the request contains the URI of the other entity in the relation. Here is an example request:

[!code-console[Main](entity-relations-in-odata-v4/samples/sample14.cmd)]

In this example, the client sends a PUT request to `/Products(6)/Supplier/$ref`, which is the $ref URI for the `Supplier` of the product with ID = 6. If the request succeeds, the server sends a 204 (No Content) response:

[!code-console[Main](entity-relations-in-odata-v4/samples/sample15.cmd)]

Here is the controller method to add a relationship to a `Product`:

[!code-csharp[Main](entity-relations-in-odata-v4/samples/sample16.cs)]

The *navigationProperty* parameter specifies which relationship to set. (If there is more than one navigation property on the entity, you can add more `case` statements.)

The *link* parameter contains the URI of the supplier. Web API automatically parses the request body to get the value for this parameter.

To look up the supplier, we need the ID (or key), which is part of the *link* parameter. To do this, use the following helper method:

[!code-csharp[Main](entity-relations-in-odata-v4/samples/sample17.cs)]

Basically, this method uses the OData library to split the URI path into segments, find the segment that contains the key, and convert the key into the correct type.

## Deleting a Relationship Between Entities

To delete a relationship, the client sends an HTTP DELETE request to the $ref URI:

[!code-console[Main](entity-relations-in-odata-v4/samples/sample18.cmd)]

Here is the controller method to delete the relationship between a Product and a Supplier:

[!code-csharp[Main](entity-relations-in-odata-v4/samples/sample19.cs)]

In this case, `Product.Supplier` is the &quot;1&quot; end of a 1-to-many relation, so you can remove the relationship just by setting `Product.Supplier` to `null`.

In the &quot;many&quot; end of a relationship, the client must specify which related entity to remove. To do so, the client sends the URI of the related entity in the query string of the request. For example, to remove "Product 1" from "Supplier 1":

[!code-console[Main](entity-relations-in-odata-v4/samples/sample20.cmd?highlight=1)]

To support this in Web API, we need to include an extra parameter in the `DeleteRef` method. Here is the controller method to remove a product from the `Supplier.Products` relation.

[!code-csharp[Main](entity-relations-in-odata-v4/samples/sample21.cs)]

The *key* parameter is the key for the supplier, and the *relatedKey* parameter is the key for the product to remove from the `Products` relationship. Note that Web API automatically gets the key from the query string.