---
title: "Open Types in OData v4 with ASP.NET Web API | Microsoft Docs"
author: microsoft
description: "In OData v4, an open type is a stuctured type that contains dynamic properties, in addition to any properties that are declared in the type definition. Open..."
ms.author: riande
manager: wpickett
ms.date: 09/15/2014
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/odata-support-in-aspnet-web-api/odata-v4/use-open-types-in-odata-v4
---
Open Types in OData v4 with ASP.NET Web API
====================
by [Microsoft](https://github.com/microsoft)

> In OData v4, an *open type* is a stuctured type that contains dynamic properties, in addition to any properties that are declared in the type definition. Open types let you add flexibility to your data models. This tutorial shows how to use open types in ASP.NET Web API OData.
> 
> This tutorial assumes that you already know how to create an OData endpoint in ASP.NET Web API. If not, start by reading [Create an OData v4 Endpoint](create-an-odata-v4-endpoint.md) first.
> 
> ## Software versions used in the tutorial
> 
> 
> - Web API OData 5.3
> - OData v4


First, some OData terminology:

- Entity type: A structured type with a key.
- Complex type: A structured type without a key.
- Open type: A type with dynamic properties. Both entity types and complex types can be open.

The value of a dynamic property can be a primitive type, complex type, or enumeration type; or a collection of any of those types. For more information about open types, see the [OData v4 specification](http://www.odata.org/documentation/odata-version-4-0/).

## Install the Web OData Libraries

Use NuGet Package Manager to install the latest Web API OData libraries. From the Package Manager Console window:

    Install-Package Microsoft.AspNet.OData
    Install-Package Microsoft.AspNet.WebApi.OData

## Define the CLR Types

Start by defining the EDM models as CLR types.

    public enum Category
    {
        Book,
        Magazine,
        EBook
    }
    
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
    }
    
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }
    
    public class Press
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Category Category { get; set; }
        public IDictionary<string, object> DynamicProperties { get; set; }
    }
    
    public class Book
    {
        [Key]
        public string ISBN { get; set; }
        public string Title { get; set; }
        public Press Press { get; set; }
        public IDictionary<string, object> Properties { get; set; }
    }

When the Entity Data Model (EDM) is created,

- `Category` is an enumeration type.
- `Address` is a complex type. (It does not have a key, so it is not an entity type.)
- `Customer` is an entity type. (It has a key.)
- `Press` is an open complex type.
- `Book` is an open entity type.

To create an open type, the CLR type must have a property of type `IDictionary<string, object>`, which holds the dynamic properties.

## Build the EDM Model

If you use **ODataConventionModelBuilder** to create the EDM, `Press` and `Book` are automatically added as open types, based on the presence of a `IDictionary<string, object>` property.

    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Book>("Books");
            builder.EntitySet<Customer>("Customers");
            var model = builder.GetEdmModel();
    
            config.MapODataServiceRoute(
                routeName: "ODataRoute",
                routePrefix: null,
                model: model);
    
        }
    }

You can also build the EDM explicitly, using **ODataModelBuilder**.

    ODataModelBuilder builder = new ODataModelBuilder();
    
      ComplexTypeConfiguration<Press> pressType = builder.ComplexType<Press>();
      pressType.Property(c => c.Name);
      // ...
      pressType.HasDynamicProperties(c => c.DynamicProperties);
    
      EntityTypeConfiguration<Book> bookType = builder.EntityType<Book>();
      bookType.HasKey(c => c.ISBN);
      bookType.Property(c => c.Title);
      // ...
      bookType.ComplexProperty(c => c.Press);
      bookType.HasDynamicProperties(c => c.Properties);
    
      // ...
      builder.EntitySet<Book>("Books");
      IEdmModel model = builder.GetEdmModel();

## Add an OData Controller

Next, add an OData controller. For this tutorial, we'll use a simplified controller that just supports GET and POST requests, and uses an in-memory list to store entities.

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;
    using System.Web.OData;
    
    namespace MyApp.Controllers
    {
        public class BooksController : ODataController
        {
            private IList<Book> _books = new List<Book>
            {
                new Book
                {
                    ISBN = "978-0-7356-8383-9",
                    Title = "SignalR Programming in Microsoft ASP.NET",
                    Press = new Press
                    {
                        Name = "Microsoft Press",
                        Category = Category.Book
                    }
                },
    
                new Book
                {
                    ISBN = "978-0-7356-7942-9",
                    Title = "Microsoft Azure SQL Database Step by Step",
                    Press = new Press
                    {
                        Name = "Microsoft Press",
                        Category = Category.EBook,
                        DynamicProperties = new Dictionary<string, object>
                        {
                            { "Blog", "https://blogs.msdn.com/b/microsoft_press/" },
                            { "Address", new Address { 
                                  City = "Redmond", Street = "One Microsoft Way" }
                            }
                        }
                    },
                    Properties = new Dictionary<string, object>
                    {
                        { "Published", new DateTimeOffset(2014, 7, 3, 0, 0, 0, 0, new TimeSpan(0))},
                        { "Authors", new [] { "Leonard G. Lobel", "Eric D. Boyd" }},
                        { "OtherCategories", new [] {Category.Book, Category.Magazine}}
                    }
                }
            };
    
            [EnableQuery]
            public IQueryable<Book> Get()
            {
                return _books.AsQueryable();
            }
    
            public IHttpActionResult Get([FromODataUri]string key)
            {
                Book book = _books.FirstOrDefault(e => e.ISBN == key);
                if (book == null)
                {
                    return NotFound();
                }
    
                return Ok(book);
            }
    
            public IHttpActionResult Post(Book book)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                } 
                // For this sample, we aren't enforcing unique keys.
                _books.Add(book);
                return Created(book);
            }
        }
    }

Notice that the first `Book` instance has no dynamic properties. The second `Book` instance has the following dynamic properties:

- "Published": Primitive type
- "Authors": Collection of primitive types
- "OtherCategories": Collection of enumeration types.

Also, the `Press` property of that `Book` instance has the following dynamic properties:

- "Blog": Primitive type
- "Address": Complex type

## Query the Metadata

To get the OData metadata document, send a GET request to `~/$metadata`. The response body should look similar to this:

[!code[Main](use-open-types-in-odata-v4/samples/sample1.xml?highlight=5,21)]

From the metadata document, you can see that:

- For the `Book` and `Press` types, the value of the `OpenType` attribute is true. The `Customer` and `Address` types don't have this attribute.
- The `Book` entity type has three declared properties: ISBN, Title, and Press. The OData metadata does not include the `Book.Properties` property from the CLR class.
- Similarly, the `Press` complex type has only two declared properties: Name and Category. The metadata does not not include the `Press.DynamicProperties` property from the CLR class.

## Query an Entity

To get the book with ISBN equal to "978-0-7356-7942-9", send send a GET request to `~/Books('978-0-7356-7942-9')`. The response body should look similar to the following. (Indented to make it more readable.)

[!code[Main](use-open-types-in-odata-v4/samples/sample2.xml?highlight=8-13,15-23)]

Notice that the dynamic properties are included inline with the declared properties.

## POST an Entity

To add a Book entity, send a POST request to `~/Books`. The client can set dynamic properties in the request payload.

Here is an example request. Note the "Price" and "Published" properties.

[!code[Main](use-open-types-in-odata-v4/samples/sample3.xml?highlight=10)]

If you set a breakpoint in the controller method, you can see that Web API added these properties to the `Properties` dictionary.

![](use-open-types-in-odata-v4/_static/image1.png)

## Additional Resources

[OData Open Type Sample](http://aspnet.codeplex.com/sourcecontrol/latest#Samples/WebApi/OData/v4/ODataOpenTypeSample/ReadMe.txt)