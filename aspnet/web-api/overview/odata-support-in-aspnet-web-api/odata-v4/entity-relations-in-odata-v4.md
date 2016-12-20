---
title: "Entity Relations in OData v4 Using ASP.NET Web API 2.2 | Microsoft Docs"
author: MikeWasson
description: "Most data sets define relations between entities: Customers have orders; books have authors; products have suppliers. Using OData, clients can navigate over..."
ms.author: riande
manager: wpickett
ms.date: 06/26/2014
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/odata-support-in-aspnet-web-api/odata-v4/entity-relations-in-odata-v4
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\web-api\overview\odata-support-in-aspnet-web-api\odata-v4\entity-relations-in-odata-v4.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/58340) | [View dev content](http://docs.aspdev.net/tutorials/web-api/overview/odata-support-in-aspnet-web-api/odata-v4/entity-relations-in-odata-v4.html) | [View prod content](http://www.asp.net/web-api/overview/odata-support-in-aspnet-web-api/odata-v4/entity-relations-in-odata-v4) | Picker: 58358

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

> [!NOTE] The tutorial builds on the tutorial [Create an OData v4 Endpoint Using ASP.NET Web API 2](create-an-odata-v4-endpoint.md).


First, we need a related entity. Add a class named `Supplier` in the Models folder.

    using System.Collections.Generic;
    
    namespace ProductService.Models
    {
        public class Supplier
        {
            public int Id { get; set; }
            public string Name { get; set; }
    
            public ICollection<Product> Products { get; set; }
        }
    }

Add a navigation property to the `Product` class:

[!code[Main](entity-relations-in-odata-v4/samples/sample1.xml?highlight=13-15)]

Add a new **DbSet** to the `ProductsContext` class, so that Entity Framework will include the Supplier table in the database.

[!code[Main](entity-relations-in-odata-v4/samples/sample2.xml?highlight=10)]

In WebApiConfig.cs, add a &quot;Suppliers&quot; entity set to the entity data model:

[!code[Main](entity-relations-in-odata-v4/samples/sample3.xml?highlight=6)]

## Add a Suppliers Controller

Add a `SuppliersController` class to the Controllers folder.

    using ProductService.Models;
    using System.Linq;
    using System.Web.OData;
    
    namespace ProductService.Controllers
    {
        public class SuppliersController : ODataController
        {
            ProductsContext db = new ProductsContext();
    
            protected override void Dispose(bool disposing)
            {
                db.Dispose();
                base.Dispose(disposing);
            }
        }
    }

I won't show how to add CRUD operations for this controller. The steps are the same as for the Products controller (see [Create an OData v4 Endpoint](create-an-odata-v4-endpoint.md)).

## Getting Related Entities

To get the supplier for a product, the client sends a GET request:

    GET /Products(1)/Supplier

To support this request, add the following method to the `ProductsController` class:

    public class ProductsController : ODataController
    {
        // GET /Products(1)/Supplier
        [EnableQuery]
        public SingleResult<Supplier> GetSupplier([FromODataUri] int key)
        {
            var result = db.Products.Where(m => m.Id == key).Select(m => m.Supplier);
            return SingleResult.Create(result);
        }
     
       // Other controller methods not shown.
    }

This method uses a default naming convention

- Method name: GetX, where X is the navigation property.
- Parameter name: *key*

If you follow this naming convention, Web API automatically maps the HTTP request to the controller method.

Example HTTP request:

    GET http://myproductservice.example.com/Products(1)/Supplier HTTP/1.1
    User-Agent: Fiddler
    Host: myproductservice.example.com

Example HTTP response:

    HTTP/1.1 200 OK
    Content-Length: 125
    Content-Type: application/json; odata.metadata=minimal; odata.streaming=true
    Server: Microsoft-IIS/8.0
    OData-Version: 4.0
    Date: Tue, 08 Jul 2014 00:44:27 GMT
    
    {
      "@odata.context":"http://myproductservice.example.com/$metadata#Suppliers/$entity","Id":2,"Name":"Wingtip Toys"
    }

### Getting a related collection

In the previous example, a product has one supplier. A navigation property can also return a collection. The following code gets the products for a supplier:

    public class SuppliersController : ODataController
    {
        // GET /Suppliers(1)/Products
        [EnableQuery]
        public IQueryable<Product> GetProducts([FromODataUri] int key)
        {
            return db.Suppliers.Where(m => m.Id.Equals(key)).SelectMany(m => m.Products);
        }
    
        // Other controller methods not shown.
    }

In this case, the method returns an **IQueryable** instead of a **SingleResult&lt;T&gt;**

Example HTTP request:

    GET http://myproductservice.example.com/Suppliers(2)/Products HTTP/1.1
    User-Agent: Fiddler
    Host: myproductservice.example.com

Example HTTP response:

    HTTP/1.1 200 OK
    Content-Length: 372
    Content-Type: application/json; odata.metadata=minimal; odata.streaming=true
    Server: Microsoft-IIS/8.0
    OData-Version: 4.0
    Date: Tue, 08 Jul 2014 01:06:54 GMT
    
    {
      "@odata.context":"http://myproductservice.example.com/$metadata#Products","value":[
        {
          "Id":1,"Name":"Hat","Price":14.95,"Category":"Clothing","SupplierId":2
        },{
          "Id":2,"Name":"Socks","Price":6.95,"Category":"Clothing","SupplierId":2
        },{
          "Id":4,"Name":"Pogo Stick","Price":29.99,"Category":"Toys","SupplierId":2
        }
      ]
    }

## Creating a Relationship Between Entities

OData supports creating or removing relationships between two existing entities. In OData v4 terminology, the relationship is a &quot;reference&quot;. (In OData v3, the relationship was called a *link*. The protocol differences don't matter for this tutorial.)

A reference has its own URI, with the form `/Entity/NavigationProperty/$ref`. For example, here is the URI to address the reference between a product and its supplier:

    http:/host/Products(1)/Supplier/$ref

To add a relationship, the client sends a POST or PUT request to this address.

- PUT if the navigation property is a single entity, such as `Product.Supplier`.
- POST if the navigation property is a collection, such as `Supplier.Products`.

The body of the request contains the URI of the other entity in the relation. Here is an example request:

    PUT http://myproductservice.example.com/Products(6)/Supplier/$ref HTTP/1.1
    OData-Version: 4.0;NetFx
    OData-MaxVersion: 4.0;NetFx
    Accept: application/json;odata.metadata=minimal
    Accept-Charset: UTF-8
    Content-Type: application/json;odata.metadata=minimal
    User-Agent: Microsoft ADO.NET Data Services
    Host: myproductservice.example.com
    Content-Length: 70
    Expect: 100-continue
    
    {"@odata.id":"http://myproductservice.example.com/Suppliers(4)"}

In this example, the client sends a PUT request to `/Products(6)/Supplier/$ref`, which is the $ref URI for the `Supplier` of the product with ID = 6. If the request succeeds, the server sends a 204 (No Content) response:

    HTTP/1.1 204 No Content
    Server: Microsoft-IIS/8.0
    Date: Tue, 08 Jul 2014 06:35:59 GMT

Here is the controller method to add a relationship to a `Product`:

    public class ProductsController : ODataController
    {
        [AcceptVerbs("POST", "PUT")]
        public async Task<IHttpActionResult> CreateRef([FromODataUri] int key, 
            string navigationProperty, [FromBody] Uri link)
        {
            var product = await db.Products.SingleOrDefaultAsync(p => p.Id == key);
            if (product == null)
            {
                return NotFound();
            }
            switch (navigationProperty)
            {
                case "Supplier":
                    // Note: The code for GetKeyFromUri is shown later in this topic.
                    var relatedKey = Helpers.GetKeyFromUri<int>(Request, link);
                    var supplier = await db.Suppliers.SingleOrDefaultAsync(f => f.Id == relatedKey);
                    if (supplier == null)
                    {
                        return NotFound();
                    }
    
                    product.Supplier = supplier;
                    break;
    
                default:
                    return StatusCode(HttpStatusCode.NotImplemented);
            }
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
        }
    
        // Other controller methods not shown.
    }

The *navigationProperty* parameter specifies which relationship to set. (If there is more than one navigation property on the entity, you can add more `case` statements.)

The *link* parameter contains the URI of the supplier. Web API automatically parses the request body to get the value for this parameter.

To look up the supplier, we need the ID (or key), which is part of the *link* parameter. To do this, use the following helper method:

    using Microsoft.OData.Core;
    using Microsoft.OData.Core.UriParser;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http.Routing;
    using System.Web.OData.Extensions;
    using System.Web.OData.Routing;
    
    namespace ProductService
    {
        public static class Helpers
        {
            public static TKey GetKeyFromUri<TKey>(HttpRequestMessage request, Uri uri)
            {
                if (uri == null)
                {
                    throw new ArgumentNullException("uri");
                }
    
                var urlHelper = request.GetUrlHelper() ?? new UrlHelper(request);
    
                string serviceRoot = urlHelper.CreateODataLink(
                    request.ODataProperties().RouteName, 
                    request.ODataProperties().PathHandler, new List<ODataPathSegment>());
                var odataPath = request.ODataProperties().PathHandler.Parse(
                    request.ODataProperties().Model, 
                    serviceRoot, uri.LocalPath);
    
                var keySegment = odataPath.Segments.OfType<KeyValuePathSegment>().FirstOrDefault();
                if (keySegment == null)
                {
                    throw new InvalidOperationException("The link does not contain a key.");
                }
    
                var value = ODataUriUtils.ConvertFromUriLiteral(keySegment.Value, ODataVersion.V4);
                return (TKey)value;
            }
    
        }
    }

Basically, this method uses the OData library to split the URI path into segments, find the segment that contains the key, and convert the key into the correct type.

## Deleting a Relationship Between Entities

To delete a relationship, the client sends an HTTP DELETE request to the $ref URI:

    DELETE http://host/Products(1)/Supplier/$ref

Here is the controller method to delete the relationship between a Product and a Supplier:

    public class ProductsController : ODataController
    {
        public async Task<IHttpActionResult> DeleteRef([FromODataUri] int key, 
            string navigationProperty, [FromBody] Uri link)
        {
            var product = db.Products.SingleOrDefault(p => p.Id == key);
            if (product == null)
            {
                return NotFound();
            }
    
            switch (navigationProperty)
            {
                case "Supplier":
                    product.Supplier = null;
                    break;
    
                default:
                    return StatusCode(HttpStatusCode.NotImplemented);
            }
            await db.SaveChangesAsync();
    
            return StatusCode(HttpStatusCode.NoContent);
        }        
    
        // Other controller methods not shown.
    }

In this case, `Product.Supplier` is the &quot;1&quot; end of a 1-to-many relation, so you can remove the relationship just by setting `Product.Supplier` to `null`.

In the &quot;many&quot; end of a relationship, the client must specify which related entity to remove. To do so, the client sends the URI of the related entity in the query string of the request. For example, to remove "Product 1" from "Supplier 1":

[!code[Main](entity-relations-in-odata-v4/samples/sample4.xml?highlight=1)]

To support this in Web API, we need to include an extra parameter in the `DeleteRef` method. Here is the controller method to remove a product from the `Supplier.Products` relation.

    public class SuppliersController : ODataController
    {
        public async Task<IHttpActionResult> DeleteRef([FromODataUri] int key, 
            [FromODataUri] string relatedKey, string navigationProperty)
        {
            var supplier = await db.Suppliers.SingleOrDefaultAsync(p => p.Id == key);
            if (supplier == null)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
    
            switch (navigationProperty)
            {
                case "Products":
                    var productId = Convert.ToInt32(relatedKey);
                    var product = await db.Products.SingleOrDefaultAsync(p => p.Id == productId);
    
                    if (product == null)
                    {
                        return NotFound();
                    }
                    product.Supplier = null;
                    break;
                default:
                    return StatusCode(HttpStatusCode.NotImplemented);
    
            }
            await db.SaveChangesAsync();
    
            return StatusCode(HttpStatusCode.NoContent);
        }
    
        // Other controller methods not shown.
    }

The *key* parameter is the key for the supplier, and the *relatedKey* parameter is the key for the product to remove from the `Products` relationship. Note that Web API automatically gets the key from the query string.