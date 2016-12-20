---
title: "Actions and Functions in OData v4 Using ASP.NET Web API 2.2 | Microsoft Docs"
author: MikeWasson
description: "In OData, actions and functions are a way to add server-side behaviors that are not easily defined as CRUD operations on entities. This tutorial shows how to..."
ms.author: riande
manager: wpickett
ms.date: 06/27/2014
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/odata-support-in-aspnet-web-api/odata-v4/odata-actions-and-functions
---
Actions and Functions in OData v4 Using ASP.NET Web API 2.2
====================
by [Mike Wasson](https://github.com/MikeWasson)

> In OData, actions and functions are a way to add server-side behaviors that are not easily defined as CRUD operations on entities. This tutorial shows how to add actions and functions to an OData v4 endpoint, using Web API 2.2. The tutorial builds on the tutorial [Create an OData v4 Endpoint Using ASP.NET Web API 2](create-an-odata-v4-endpoint.md)
> 
> ## Software versions used in the tutorial
> 
> 
> - Web API 2.2
> - OData v4
> - [Visual Studio 2013 Update 2](https://www.visualstudio.com/downloads/download-visual-studio-vs)
> - .NET 4.5
> 
> 
> ## Tutorial versions
> 
> For OData Version 3, see [OData Actions in ASP.NET Web API 2](../odata-v3/odata-actions.md).


The difference between *actions* and *functions* is that actions can have side effects, and functions do not. Both actions and functions can return data. Some uses for actions include:

- Complex transactions.
- Manipulating several entities at once.
- Allowing updates only to certain properties of an entity.
- Sending data that is not an entity.

Functions are useful for returning information that does not correspond directly to an entity or collection.

An action (or function) can target a single entity or a collection. In OData terminology, this is the *binding*. You can also have &quot;unbound&quot; actions/functions, which are called as static operations on the service.

## Example: Adding an Action

Let's define an action to rate a product.

> [!NOTE] This tutorial builds on the tutorial [Create an OData v4 Endpoint Using ASP.NET Web API 2](create-an-odata-v4-endpoint.md)


First, add a `ProductRating` model to represent the ratings.

    namespace ProductService.Models
    {
        public class ProductRating
        {
            public int ID { get; set; }
            public int Rating { get; set; }
            public int ProductID { get; set; }
            public virtual Product Product { get; set; }  
        }
    }

Also add a **DbSet** to the `ProductsContext` class, so that EF will create a Ratings table in the database.

    public class ProductsContext : DbContext
    {
        public ProductsContext() 
                : base("name=ProductsContext")
        {
        }
    
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        // New code:
        public DbSet<ProductRating> Ratings { get; set; }
    }

### Add the Action to the EDM

In WebApiConfig.cs, add the following code:

    ODataModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Product>("Products");
    
    // New code:
    builder.Namespace = "ProductService";
    builder.EntityType<Product>()
        .Action("Rate")
        .Parameter<int>("Rating");

The **EntityTypeConfiguration.Action** method adds an action to the entity data model (EDM). The **Parameter** method specifies a typed parameter for the action.

This code also sets the namespace for the EDM. The namespace matters because the URI for the action includes the fully-qualified action name:

    http://localhost/Products(1)/ProductService.Rate

> [!NOTE] In a typical IIS configuration, the dot in this URL will cause IIS to return error 404. You can resolve this by adding the following section to your Web.Config file:

    <system.webServer>
        <handlers>
          <clear/>
          <add name="ExtensionlessUrlHandler-Integrated-4.0" path="/*" 
              verb="*" type="System.Web.Handlers.TransferRequestHandler" 
              preCondition="integratedMode,runtimeVersionv4.0" />
        </handlers>
    </system.webServer>

### Add a Controller Method for the Action

To enable the &quot;Rate&quot; action, add the following method to `ProductsController`:

    [HttpPost]
    public async Task<IHttpActionResult> Rate([FromODataUri] int key, ODataActionParameters parameters)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
    
        int rating = (int)parameters["Rating"];
        db.Ratings.Add(new ProductRating
        {
            ProductID = key,
            Rating = rating
        });
    
        try
        {
            await db.SaveChangesAsync();
        }
        catch (DbUpdateException e)
        {
            if (!ProductExists(key))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
    
        return StatusCode(HttpStatusCode.NoContent);
    }

Notice that the method name matches the action name. The **[HttpPost]** attribute specifies the method is an HTTP POST method.

To invoke the action, the client sends an HTTP POST request like the following:

    POST http://localhost/Products(1)/ProductService.Rate HTTP/1.1
    Content-Type: application/json
    Content-Length: 12
    
    {"Rating":5}

The &quot;Rate&quot; action is bound to Product instances, so the URI for the action is the fully-qualified action name appended to the entity URI. (Recall that we set the EDM namespace to &quot;ProductService&quot;, so the fully-qualified action name is &quot;ProductService.Rate&quot;.)

The body of the request contains the action parameters as a JSON payload. Web API automatically converts the JSON payload to an **ODataActionParameters** object, which is just a dictionary of parameter values. Use this dictionary to access the parameters in your controller method.

If the client sends the action parameters in the wrong format, the value of **ModelState.IsValid** is false. Check this flag in your controller method and return an error if **IsValid** is false.

    if (!ModelState.IsValid)
    {
        return BadRequest();
    }

## Example: Adding a Function

Now let's add an OData function that returns the most expensive product. As before, the first step is adding the function to the EDM. In WebApiConfig.cs, add the following code.

    ODataModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Product>("Products");
    builder.EntitySet<Supplier>("Suppliers");
    
    // New code:
    builder.Namespace = "ProductService";
    builder.EntityType<Product>().Collection
        .Function("MostExpensive")
        .Returns<double>();

In this case, the function is bound to the Products collection, rather than individual Product instances. Clients invoke the function by sending a GET request:

    GET http://localhost:38479/Products/ProductService.MostExpensive

Here is the controller method for this function:

    public class ProductsController : ODataController
    {
        [HttpGet]
        public IHttpActionResult MostExpensive()
        {
            var product = db.Products.Max(x => x.Price);
            return Ok(product);
        }
    
        // Other controller methods not shown.
    }

Notice that the method name matches the function name. The **[HttpGet]** attribute specifies the method is an HTTP GET method.

Here is the HTTP response:

    HTTP/1.1 200 OK
    Content-Type: application/json; odata.metadata=minimal; odata.streaming=true
    OData-Version: 4.0
    Date: Sat, 28 Jun 2014 00:44:07 GMT
    Content-Length: 85
    
    {
      "@odata.context":"http://localhost:38479/$metadata#Edm.Decimal","value":50.00
    }

## Example: Adding an Unbound Function

The previous example was a function bound to a collection. In this next example, we'll create an *unbound* function. Unbound functions are called as static operations on the service. The function in this example will return the sales tax for a given postal code.

In the WebApiConfig file, add the function to the EDM:

    ODataModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Product>("Products");
    
    // New code:
    builder.Function("GetSalesTaxRate")
        .Returns<double>()
        .Parameter<int>("PostalCode");

Notice that we are calling **Function** directly on the **ODataModelBuilder**, instead of the entity type or collection. This tells the model builder that the function is unbound.

Here is the controller method that implements the function:

    [HttpGet]
    [ODataRoute("GetSalesTaxRate(PostalCode={postalCode})")]
    public IHttpActionResult GetSalesTaxRate([FromODataUri] int postalCode)
    {
        double rate = 5.6;  // Use a fake number for the sample.
        return Ok(rate);
    }

It does not matter which Web API controller you place this method in. You could put it in `ProductsController`, or define a separate controller. The **[ODataRoute]** attribute defines the URI template for the function.

Here is an example client request:

    GET http://localhost:38479/GetSalesTaxRate(PostalCode=10) HTTP/1.1

The HTTP response:

    HTTP/1.1 200 OK
    Content-Type: application/json; odata.metadata=minimal; odata.streaming=true
    OData-Version: 4.0
    Date: Sat, 28 Jun 2014 01:05:32 GMT
    Content-Length: 82
    
    {
      "@odata.context":"http://localhost:38479/$metadata#Edm.Double","value":5.6
    }