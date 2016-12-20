---
title: "Using $select, $expand, and $value in ASP.NET Web API 2 OData | Microsoft Docs"
author: MikeWasson
description: ""
ms.author: riande
manager: wpickett
ms.date: 10/11/2013
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/odata-support-in-aspnet-web-api/using-select-expand-and-value
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\web-api\overview\odata-support-in-aspnet-web-api\using-select-expand-and-value.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/51294) | [View dev content](http://docs.aspdev.net/tutorials/web-api/overview/odata-support-in-aspnet-web-api/using-select-expand-and-value.html) | [View prod content](http://www.asp.net/web-api/overview/odata-support-in-aspnet-web-api/using-select-expand-and-value) | Picker: 51296

Using $select, $expand, and $value in ASP.NET Web API 2 OData
====================
by [Mike Wasson](https://github.com/MikeWasson)

Web API 2 adds support for the $expand, $select, and $value options in OData. These options allow a client to control the representation that it gets back from the server.

- **$expand** causes related entities to be included inline in the response.
- **$select** selects a subset of properties to include in the response.
- **$value** gets the raw value of a property.

## Example Schema

For this article, I'll use an OData service that defines three entities: Product, Supplier, and Category. Each product has one category and one supplier.

![](using-select-expand-and-value/_static/image1.png)

Here are the C# classes that define the entity models:

    public class Supplier
    {
        [Key]
        public string Key {get; set; }
        public string Name { get; set; }
    }
    public class Category
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
    
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    
        [ForeignKey("Supplier")]
        public string SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
    }

Notice that the `Product` class defines navigation properties for the `Supplier` and `Category`. The `Category` class defines a navigation property for the products in each category.

To create an OData endpoint for this schema, use the Visual Studio 2013 scaffolding, as described in [Creating an OData Endpoint in ASP.NET Web API](odata-v3/creating-an-odata-endpoint.md). Add separate controllers for Product, Category, and Supplier.

## Enabling $expand and $select

In Visual Studio 2013, the Web API OData scaffolding creates a controller that automatically supports $expand and $select. For reference, here are the requirements to support $expand and $select in a controller.

For collections, the controller's `Get` method must return an **IQueryable**.

    [Queryable]
    public IQueryable<Category> GetCategories()
    {
        return db.Categories;
    }

For single entities, return a **SingleResult&lt;T&gt;**, where T is an **IQueryable** that contains zero or one entities.

    [Queryable]
    public SingleResult<Category> GetCategory([FromODataUri] int key)
    {
        return SingleResult.Create(db.Categories.Where(c => c.ID == key));
    }

Also, decorate your `Get` methods with the **[Queryable]** attribute, as shown in the previous code snippets. Alternatively, call **EnableQuerySupport** on the **HttpConfiguration** object at startup. (For more information, see [Enabling OData Query Options](supporting-odata-query-options.md#enable).)

## Using $expand

When you query an OData entity or collection, the default response does not include related entities. For example, here is the default response for the Categories entity set:

    {
      "odata.metadata":"http://localhost/odata/$metadata#Categories",
      "value":[
        {"ID":1,"Name":"Apparel"},
        {"ID":2,"Name":"Toys"}
      ]
    }

As you can see, the response does not include any products, even though the Category entity has a Products navigation link. However, the client can use $expand to get the list of products for each category. The $expand option goes in the query string of the request:

    GET http://localhost/odata/Categories?$expand=Products

Now the server will include the products for each category, inline with the categories. Here is the response payload:

    {
      "odata.metadata":"http://localhost/odata/$metadata#Categories",
      "value":[
        {
          "Products":[
            {"ID":1,"Name":"Hat","Price":"15.00","CategoryId":1,"SupplierId":"CTSO"},
            {"ID":2,"Name":"Scarf","Price":"12.00","CategoryId":1,"SupplierId":"CTSO"},
            {"ID":3,"Name":"Socks","Price":"5.00","CategoryId":1,"SupplierId":"FBRK"}
          ],
          "ID":1,
          "Name":"Apparel"
        },
        {
          "Products":[
            {"ID":4,"Name":"Yo-yo","Price":"4.95","CategoryId":2,"SupplierId":"WING"},
            {"ID":5,"Name":"Puzzle","Price":"8.00","CategoryId":2,"SupplierId":"WING"}
          ],
          "ID":2,
          "Name":"Toys"
        }
      ]
    }

Notice that each entry in the "value" array contains a Products list.

The $expand option takes a comma-separated list of navigation properties to expand. The following request expands both the category and the supplier for a product.

    GET http://localhost/odata/Products(1)?$expand=Category,Supplier

Here is the response body:

    {
      "odata.metadata":"http://localhost/odata/$metadata#Products/@Element",
      "Category": {"ID":1,"Name":"Apparel"},
      "Supplier":{"Key":"CTSO","Name":"Contoso, Ltd."},
      "ID":1,
      "Name":"Hat",
      "Price":"15.00",
      "CategoryId":1,
      "SupplierId":"CTSO"
    }

You can expand more than one level of navigation property. The following example includes all the products for a category and also the supplier for each product.

    GET http://localhost/odata/Categories(1)?$expand=Products/Supplier

Here is the response body:

    {
      "odata.metadata":"http://localhost/odata/$metadata#Categories/@Element",
      "Products":[
        {
          "Supplier":{"Key":"CTSO","Name":"Contoso, Ltd."},
          "ID":1,"Name":"Hat","Price":"15.00","CategoryId":1,"SupplierId":"CTSO"
        },
        {
          "Supplier":{"Key":"CTSO","Name":"Contoso, Ltd."},
          "ID":2,"Name":"Scarf","Price":"12.00","CategoryId":1,"SupplierId":"CTSO"
        },{
          "Supplier":{
            "Key":"FBRK","Name":"Fabrikam, Inc."
          },"ID":3,"Name":"Socks","Price":"5.00","CategoryId":1,"SupplierId":"FBRK"
        }
      ],"ID":1,"Name":"Apparel"
    }

By default, Web API limits the maximum expansion depth to 2. That prevents the client from sending complex requests like `$expand=Orders/OrderDetails/Product/Supplier/Region`, which might be inefficient to query and create large responses. To override the default, set the **MaxExpansionDepth** property on the **[Queryable]** attribute.

    [Queryable(MaxExpansionDepth=4)]
    public IQueryable<Category> GetCategories()
    {
        return db.Categories;
    }

For more information about the $expand option, see [Expand System Query Option ($expand)](http://www.odata.org/documentation/odata-v2-documentation/uri-conventions/#46_Expand_System_Query_Option_expand) in the official OData documentation.

## Using $select

The $select option specifies a subset of properties to include in the response body. For example, to get only the name and price of each product, use the following query:

    GET http://localhost/odata/Products?$select=Price,Name

Here is the response body:

    {
      "odata.metadata":"http://localhost/odata/$metadata#Products&$select=Price,Name",
      "value":[
        {"Price":"15.00","Name":"Hat"},
        {"Price":"12.00","Name":"Scarf"},
        {"Price":"5.00","Name":"Socks"},
        {"Price":"4.95","Name":"Yo-yo"},
        {"Price":"8.00","Name":"Puzzle"}
      ]
    }

You can combine $select and $expand in the same query. Make sure to include the expanded property in the $select option. For example, the following request gets the product name and supplier.

    GET http://localhost/odata/Products?$select=Name,Supplier&$expand=Supplier

Here is the response body:

    {
      "odata.metadata":"http://localhost/odata/$metadata#Products&$select=Name,Supplier",
      "value":[
        {
          "Supplier":{"Key":"CTSO","Name":"Contoso, Ltd."},
          "Name":"Hat"
        },
        {
          "Supplier":{"Key":"CTSO","Name":"Contoso, Ltd."},
          "Name":"Scarf"
        },
        {
          "Supplier":{"Key":"FBRK","Name":"Fabrikam, Inc."},
          "Name":"Socks"
        },
        {
          "Supplier":{"Key":"WING","Name":"Wingtip Toys"},
          "Name":"Yo-yo"
        },
        {
          "Supplier":{"Key":"WING","Name":"Wingtip Toys"},
          "Name":"Puzzle"
       }
      ]
    }

You can also select the properties within an expanded property. The following request expands Products and selects category name plus product name.

    GET http://localhost/odata/Categories?$expand=Products&$select=Name,Products/Name

Here is the response body:

    {
      "odata.metadata":"http://localhost/odata/$metadata#Categories&$select=Name,Products/Name",
      "value":[ 
        {
          "Products":[ {"Name":"Hat"},{"Name":"Scarf"},{"Name":"Socks"} ],
          "Name":"Apparel"
        },
        {
          "Products":[ {"Name":"Yo-yo"},{"Name":"Puzzle"} ],
          "Name":"Toys"
        }
      ]
    }

For more information about the $select option, see [Select System Query Option ($select)](http://www.odata.org/documentation/odata-v2-documentation/uri-conventions/#48_Select_System_Query_Option_select) in the official OData documentation.

## Getting Individual Properties of an Entity ($value)

There are two ways for an OData client to get an individual property from an entity. The client can either get the value in OData format, or get the raw value of the property.

The following request gets a property in OData format.

    GET http://localhost/odata/Products(1)/Name

Here is an example response in JSON format:

    HTTP/1.1 200 OK
    Content-Type: application/json; odata=minimalmetadata; streaming=true; charset=utf-8
    DataServiceVersion: 3.0
    Content-Length: 90
    
    {
      "odata.metadata":"http://localhost:14239/odata/$metadata#Edm.String",
      "value":"Hat"
    }

To get the raw value of the property, append $value to the URI:

    GET http://localhost/odata/Products(1)/Name/$value

Here is the response. Notice that the content type is "text/plain", not JSON.

    HTTP/1.1 200 OK
    Content-Type: text/plain; charset=utf-8
    DataServiceVersion: 3.0
    Content-Length: 3
    
    Hat

To support these queries in your OData controller, add a method named `GetProperty`, where `Property` is the name of the property. For example, the method to get the Name property would be named `GetName`. The method should return the value of that property:

    public async Task<IHttpActionResult> GetName(int key)
    {
        Product product = await db.Products.FindAsync(key);
        if (product == null)
        {
            return NotFound();
        }
        return Ok(product.Name);
    }