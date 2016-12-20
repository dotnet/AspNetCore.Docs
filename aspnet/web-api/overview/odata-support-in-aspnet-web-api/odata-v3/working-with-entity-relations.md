---
title: "Supporting Entity Relations in OData v3 with Web API 2 | Microsoft Docs"
author: MikeWasson
description: "Most data sets define relations between entities: Customers have orders; books have authors; products have suppliers. Using OData, clients can navigate over..."
ms.author: riande
manager: wpickett
ms.date: 02/26/2014
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/odata-support-in-aspnet-web-api/odata-v3/working-with-entity-relations
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\web-api\overview\odata-support-in-aspnet-web-api\odata-v3\working-with-entity-relations.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/44063) | [View dev content](http://docs.aspdev.net/tutorials/web-api/overview/odata-support-in-aspnet-web-api/odata-v3/working-with-entity-relations.html) | [View prod content](http://www.asp.net/web-api/overview/odata-support-in-aspnet-web-api/odata-v3/working-with-entity-relations) | Picker: 44062

Supporting Entity Relations in OData v3 with Web API 2
====================
by [Mike Wasson](https://github.com/MikeWasson)

[Download Completed Project](http://code.msdn.microsoft.com/ASPNET-Web-API-OData-cecdb524)

> Most data sets define relations between entities: Customers have orders; books have authors; products have suppliers. Using OData, clients can navigate over entity relations. Given a product, you can find the supplier. You can also create or remove relationships. For example, you can set the supplier for a product.
> 
> This tutorial shows how to support these operations in ASP.NET Web API. The tutorial builds on the tutorial [Creating an OData v3 Endpoint with Web API 2](creating-an-odata-endpoint.md).
> 
> ## Software versions used in the tutorial
> 
> 
> - Web API 2
> - OData Version 3
> - Entity Framework 6


## Add a Supplier Entity

First we need to add a new entity type to our OData feed. We'll add a `Supplier` class.

    using System.ComponentModel.DataAnnotations;
    
    namespace ProductService.Models
    {
        public class Supplier
        {
            [Key]
            public string Key { get; set; }
            public string Name { get; set; }
        }
    }

This class uses a string for the entity key. In practice, that might be less common than using an integer key. But it's worth seeing how OData handles other key types besides integers.

Next, we'll create a relation by adding a `Supplier` property to the `Product` class:

    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    
        // New code
        [ForeignKey("Supplier")]
        public string SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }

Add a new **DbSet** to the `ProductServiceContext` class, so that Entity Framework will include the `Supplier` table in the database.

[!code[Main](working-with-entity-relations/samples/sample1.xml?highlight=9)]

In WebApiConfig.cs, add a "Suppliers" entity to the EDM model:

[!code[Main](working-with-entity-relations/samples/sample2.xml?highlight=4)]

## Navigation Properties

To get the supplier for a product, the client sends a GET request:

    GET /Products(1)/Supplier

Here "Supplier" is a navigation property on the `Product` type. In this case, `Supplier` refers to a single item, but a navigation property can also return a collection (one-to-many or many-to-many relation).

To support this request, add the following method to the `ProductsController` class:

    // GET /Products(1)/Supplier
    public Supplier GetSupplier([FromODataUri] int key)
    {
        Product product = _context.Products.FirstOrDefault(p => p.ID == key);
        if (product == null)
        {
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
        return product.Supplier;
    }

The *key* parameter is the key of the product. The method returns the related entity&#8212in this case, a `Supplier` instance. The method name and parameter name are both important. In general, if the navigation property is named "X", you need to add a method named "GetX". The method must take a parameter named "*key*" that matches the data type of the parent's key.

It is also important to include the **[FromOdataUri]** attribute in the *key* parameter. This attribute tells Web API to use OData syntax rules when it parses the key from the request URI.

## Creating and Deleting Links

OData supports creating or removing relationships between two entities. In OData terminology, the relationship is a "link." Each link has a URI with the form *entity*/$links/*entity*. For example, the link from product to supplier looks like this:

    /Products(1)/$links/Supplier

To create a new link, the client sends a POST request to the link URI. The body of the request is the URI of the target entity. For example, suppose there is a supplier with the key "CTSO". To create a link from "Product(1)" to "Supplier('CTSO')", the client sends a request like the following:

    POST http://localhost/odata/Products(1)/$links/Supplier
    Content-Type: application/json
    Content-Length: 50
    
    {"url":"http://localhost/odata/Suppliers('CTSO')"}

To delete a link, the client sends a DELETE request to the link URI.

**Creating Links**

To enable a client to create product-supplier links, add the following code to the `ProductsController` class:

    [AcceptVerbs("POST", "PUT")]
    public async Task<IHttpActionResult> CreateLink([FromODataUri] int key, string navigationProperty, [FromBody] Uri link)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
                
        Product product = await db.Products.FindAsync(key);
        if (product == null)
        {
            return NotFound();
        }
                
        switch (navigationProperty)
        {
            case "Supplier":
                string supplierKey = GetKeyFromLinkUri<string>(link);
                Supplier supplier = await db.Suppliers.FindAsync(supplierKey);
                if (supplier == null)
                {
                    return NotFound();
                }
                product.Supplier = supplier;
                await db.SaveChangesAsync();
                return StatusCode(HttpStatusCode.NoContent);
    
            default:
                return NotFound();
        }
    }

This method takes three parameters:

- *key*: The key to the parent entity (the product)
- *navigationProperty*: The name of the navigation property. In this example, the only valid navigation property is "Supplier".
- *link*: The OData URI of the related entity. This value is taken from the request body. For example, the link URI might be "`http://localhost/odata/Suppliers('CTSO')`, meaning the supplier with ID = ‘CTSO'.

The method uses the link to look up the supplier. If the matching supplier is found, the method sets the `Product.Supplier` property and saves the result to the database.

The hardest part is parsing the link URI. Basically, you need to simulate the result of sending a GET request to that URI. The following helper method shows how to do this. The method invokes the Web API routing process and gets back an **ODataPath** instance that represents the parsed OData path. For a link URI, one of the segments should be the entity key. (If not, the client sent a bad URI.)

    // Helper method to extract the key from an OData link URI.
    private TKey GetKeyFromLinkUri<TKey>(Uri link)
    {
        TKey key = default(TKey);
    
        // Get the route that was used for this request.
        IHttpRoute route = Request.GetRouteData().Route;
    
        // Create an equivalent self-hosted route. 
        IHttpRoute newRoute = new HttpRoute(route.RouteTemplate, 
            new HttpRouteValueDictionary(route.Defaults), 
            new HttpRouteValueDictionary(route.Constraints),
            new HttpRouteValueDictionary(route.DataTokens), route.Handler);
    
        // Create a fake GET request for the link URI.
        var tmpRequest = new HttpRequestMessage(HttpMethod.Get, link);
    
        // Send this request through the routing process.
        var routeData = newRoute.GetRouteData(
            Request.GetConfiguration().VirtualPathRoot, tmpRequest);
    
        // If the GET request matches the route, use the path segments to find the key.
        if (routeData != null)
        {
            ODataPath path = tmpRequest.GetODataPath();
            var segment = path.Segments.OfType<KeyValuePathSegment>().FirstOrDefault();
            if (segment != null)
            {
                // Convert the segment into the key type.
                key = (TKey)ODataUriUtils.ConvertFromUriLiteral(
                    segment.Value, ODataVersion.V3);
            }
        }
        return key;
    }

**Deleting Links**

To delete a link, add the following code to the `ProductsController` class:

    public async Task<IHttpActionResult> DeleteLink([FromODataUri] int key, string navigationProperty)
    {
        Product product = await db.Products.FindAsync(key);
        if (product == null)
        {
            return NotFound();
        }
    
        switch (navigationProperty)
        {
            case "Supplier":
                product.Supplier = null;
                await db.SaveChangesAsync();
                return StatusCode(HttpStatusCode.NoContent);
    
            default:
                return NotFound();
    
        }
    }

In this example, the navigation property is a single `Supplier` entity. If the navigation property is a collection, the URI to delete a link must include a key for the related entity. For example:

    DELETE /odata/Customers(1)/$links/Orders(1)

This request removes order 1 from customer 1. In this case, the DeleteLink method will have the following signature:

    void DeleteLink([FromODataUri] int key, string relatedKey, string navigationProperty);

The *relatedKey* parameter gives the key for the related entity. So in your `DeleteLink` method, look up the primary entity by the *key* parameter, find the related entity by the *relatedKey* parameter, and then remove the association. Depending on your data model, you might need to implement both versions of `DeleteLink`. Web API will call the correct version based on the request URI.