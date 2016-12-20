---
title: "Routing Conventions in ASP.NET Web API 2 Odata | Microsoft Docs"
author: MikeWasson
description: "This article describes the routing conventions that Web API uses for OData endpoints."
ms.author: riande
manager: wpickett
ms.date: 07/31/2013
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/odata-support-in-aspnet-web-api/odata-routing-conventions
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\web-api\overview\odata-support-in-aspnet-web-api\odata-routing-conventions.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/48216) | [View dev content](http://docs.aspdev.net/tutorials/web-api/overview/odata-support-in-aspnet-web-api/odata-routing-conventions.html) | [View prod content](http://www.asp.net/web-api/overview/odata-support-in-aspnet-web-api/odata-routing-conventions) | Picker: 48217

Routing Conventions in ASP.NET Web API 2 Odata
====================
by [Mike Wasson](https://github.com/MikeWasson)

> This article describes the routing conventions that Web API uses for OData endpoints.


When Web API gets an OData request, it maps the request to a controller name and an action name. The mapping is based on the HTTP method and the URI. For example, `GET /odata/Products(1)` maps to `ProductsController.GetProduct`.

In part 1 of this article, I describe the built-in OData routing conventions. These conventions are designed specifically for OData endpoints, and they replace the default Web API routing system. (The replacement happens when you call **MapODataRoute**.)

In part 2, I show how to add custom routing conventions. Currently the built-in conventions do not cover the entire range of OData URIs, but you can extend them to handle additional cases.

- [Built-in Routing Conventions](#conventions)
- [Custom Routing Conventions](#custom)

<a id="conventions"></a>
## Built-in Routing Conventions

Before I describe the OData routing conventions in Web API, it's helpful to understand OData URIs. An [OData URI](http://www.odata.org/documentation/odata-v3-documentation/url-conventions/) consists of:

- The service root
- The resource path
- Query options

![](odata-routing-conventions/_static/image1.png)

For routing, the important part is the resource path. The resource path is divided into segments. For example, `/Products(1)/Supplier` has three segments:

- `Products` refers to an entity set named "Products".
- `1` is an entity key, selecting a single entity from the set.
- `Supplier` is a navigation property that selects a related entity.

So this path picks out the supplier of product 1.

> [!NOTE] OData path segments do not always correspond to URI segments. For example, "1" is considered a path segment.


**Controller Names.** The controller name is always derived from the entity set at the root of the resource path. For example, if the resource path is `/Products(1)/Supplier`, Web API looks for a controller named `ProductsController`.

**Action Names.** Action names are derived from the path segments plus the entity data model (EDM), as listed in the following tables. In some cases, you have two choices for the action name. For example, "Get" or &quot;GetProducts&quot;.

**Querying Entities**

| Request | Example URI | Action Name | Example Action |
| --- | --- | --- | --- |
| GET /entityset | /Products | GetEntitySet or Get | GetProducts |
| GET /entityset(key) | /Products(1) | GetEntityType or Get | GetProduct |
| GET /entityset(key)/cast | /Products(1)/Models.Book | GetEntityType or Get | GetBook |

For more information, see [Create a Read-Only OData Endpoint](odata-v3/creating-an-odata-endpoint.md).

**Creating, Updating, and Deleting Entities**

| Request | Example URI | Action Name | Example Action |
| --- | --- | --- | --- |
| POST /entityset | /Products | PostEntityType or Post | PostProduct |
| PUT /entityset(key) | /Products(1) | PutEntityType or Put | PutProduct |
| PUT /entityset(key)/cast | /Products(1)/Models.Book | PutEntityType or Put | PutBook |
| PATCH /entityset(key) | /Products(1) | PatchEntityType or Patch | PatchProduct |
| PATCH /entityset(key)/cast | /Products(1)/Models.Book | PatchEntityType or Patch | PatchBook |
| DELETE /entityset(key) | /Products(1) | DeleteEntityType or Delete | DeleteProduct |
| DELETE /entityset(key)/cast | /Products(1)/Models.Book | DeleteEntityType or Delete | DeleteBook |

**Querying a Navigation Property**

| Request | Example URI | Action Name | Example Action |
| --- | --- | --- | --- |
| GET /entityset(key)/navigation | /Products(1)/Supplier | GetNavigationFromEntityType or GetNavigation | GetSupplierFromProduct |
| GET /entityset(key)/cast/navigation | /Products(1)/Models.Book/Author | GetNavigationFromEntityType or GetNavigation | GetAuthorFromBook |

For more information, see [Working with Entity Relations](odata-v3/working-with-entity-relations.md).

**Creating and Deleting Links**

| Request | Example URI | Action Name |
| --- | --- | --- |
| POST /entityset(key)/$links/navigation | /Products(1)/$links/Supplier | CreateLink |
| PUT /entityset(key)/$links/navigation | /Products(1)/$links/Supplier | CreateLink |
| DELETE /entityset(key)/$links/navigation | /Products(1)/$links/Supplier | DeleteLink |
| DELETE /entityset(key)/$links/navigation(relatedKey) | /Products/(1)/$links/Suppliers(1) | DeleteLink |

For more information, see [Working with Entity Relations](odata-v3/working-with-entity-relations.md).

**Properties**

*Requires Web API 2*

| Request | Example URI | Action Name | Example Action |
| --- | --- | --- | --- |
| GET /entityset(key)/property | /Products(1)/Name | GetPropertyFromEntityType or GetProperty | GetNameFromProduct |
| GET /entityset(key)/cast/property | /Products(1)/Models.Book/Author | GetPropertyFromEntityType or GetProperty | GetTitleFromBook |

**Actions**

| Request | Example URI | Action Name | Example Action |
| --- | --- | --- | --- |
| POST /entityset(key)/action | /Products(1)/Rate | ActionNameOnEntityType or ActionName | RateOnProduct |
| POST /entityset(key)/cast/action | /Products(1)/Models.Book/CheckOut | ActionNameOnEntityType or ActionName | CheckOutOnBook |

For more information, see [OData Actions](odata-v3/odata-actions.md).

**Method Signatures**

Here are some rules for the method signatures:

- If the path contains a key, the action should have a parameter named *key*.
- If the path contains a key into a navigation property, the action should have a parameter named *relatedKey*.
- Decorate *key* and *relatedKey* parameters with the **[FromODataUri]** parameter.
- POST and PUT requests take a parameter of the entity type.
- PATCH requests take a parameter of type **Delta&lt;T&gt;**, where *T* is the entity type.

For reference, here is an example that shows method signatures for every built-in OData routing convention.

    public class ProductsController : ODataController
    {
        // GET /odata/Products
        public IQueryable<Product> Get()
    
        // GET /odata/Products(1)
        public Product Get([FromODataUri] int key)
    
        // GET /odata/Products(1)/ODataRouting.Models.Book
        public Book GetBook([FromODataUri] int key)
    
        // POST /odata/Products 
        public HttpResponseMessage Post(Product item)
    
        // PUT /odata/Products(1)
        public HttpResponseMessage Put([FromODataUri] int key, Product item)
    
        // PATCH /odata/Products(1)
        public HttpResponseMessage Patch([FromODataUri] int key, Delta<Product> item)
    
        // DELETE /odata/Products(1)
        public HttpResponseMessage Delete([FromODataUri] int key)
    
        // PUT /odata/Products(1)/ODataRouting.Models.Book
        public HttpResponseMessage PutBook([FromODataUri] int key, Book item)
    
        // PATCH /odata/Products(1)/ODataRouting.Models.Book
        public HttpResponseMessage PatchBook([FromODataUri] int key, Delta<Book> item)
    
        // DELETE /odata/Products(1)/ODataRouting.Models.Book
        public HttpResponseMessage DeleteBook([FromODataUri] int key)
    
        //  GET /odata/Products(1)/Supplier
        public Supplier GetSupplierFromProduct([FromODataUri] int key)
    
        // GET /odata/Products(1)/ODataRouting.Models.Book/Author
        public Author GetAuthorFromBook([FromODataUri] int key)
    
        // POST /odata/Products(1)/$links/Supplier
        public HttpResponseMessage CreateLink([FromODataUri] int key, 
            string navigationProperty, [FromBody] Uri link)
    
        // DELETE /odata/Products(1)/$links/Supplier
        public HttpResponseMessage DeleteLink([FromODataUri] int key, 
            string navigationProperty, [FromBody] Uri link)
    
        // DELETE /odata/Products(1)/$links/Parts(1)
        public HttpResponseMessage DeleteLink([FromODataUri] int key, string relatedKey, string navigationProperty)
    
        // GET odata/Products(1)/Name
        // GET odata/Products(1)/Name/$value
        public HttpResponseMessage GetNameFromProduct([FromODataUri] int key)
    
        // GET /odata/Products(1)/ODataRouting.Models.Book/Title
        // GET /odata/Products(1)/ODataRouting.Models.Book/Title/$value
        public HttpResponseMessage GetTitleFromBook([FromODataUri] int key)
    }

<a id="custom"></a>
## Custom Routing Conventions

Currently the built-in conventions do not cover all possible OData URIs. You can add new conventions by implementing the **IODataRoutingConvention** interface. This interface has two methods:

    string SelectController(ODataPath odataPath, HttpRequestMessage request);
    string SelectAction(ODataPath odataPath, HttpControllerContext controllerContext, 
        ILookup<string, HttpActionDescriptor> actionMap);

- **SelectController** returns the name of the controller.
- **SelectAction** returns the name of the action.

For both methods, if the convention does not apply to that request, the method should return null.

The **ODataPath** parameter represents the parsed OData resource path. It contains a list of **[ODataPathSegment](https://msdn.microsoft.com/en-us/library/system.web.http.odata.routing.odatapathsegment.aspx)** instances, one for each segment of the resource path. **ODataPathSegment** is an abstract class; each segment type is represented by a class that derives from **ODataPathSegment**.

The **ODataPath.TemplatePath** property is a string that represents the concatenation all of the path segments. For example, if the URI is `/Products(1)/Supplier`, the path template is &quot;~/entityset/key/navigation&quot;. Notice that the segments don't correspond directly to URI segments. For example, the entity key (1) is represented as its own **ODataPathSegment**.

Typically, an implementation of **IODataRoutingConvention** does the following:

1. Compare the path template to see if this convention applies to the current request. If it does not apply, return null.
2. If the convention applies, use properties of the **ODataPathSegment** instances to derive controller and action names.
3. For actions, add any values to the route dictionary that should bind to the action parameters (typically entity keys).

Let's look at a specific example. The built-in routing conventions do not support indexing into a navigation collection. In other words, there is no convention for URIs like the following:

    /odata/Products(1)/Suppliers(1)

Here is a custom routing convention to handle this type of query.

    using Microsoft.Data.Edm;
    using System.Linq;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.OData.Routing;
    using System.Web.Http.OData.Routing.Conventions;
    
    namespace ODataRouting
    {
        public class NavigationIndexRoutingConvention : EntitySetRoutingConvention
        {
            public override string SelectAction(ODataPath odataPath, HttpControllerContext context, 
                ILookup<string, HttpActionDescriptor> actionMap)
            {
                if (context.Request.Method == HttpMethod.Get && 
                    odataPath.PathTemplate == "~/entityset/key/navigation/key")
                {
                    NavigationPathSegment navigationSegment = odataPath.Segments[2] as NavigationPathSegment;
                    IEdmNavigationProperty navigationProperty = navigationSegment.NavigationProperty.Partner;
                    IEdmEntityType declaringType = navigationProperty.DeclaringType as IEdmEntityType;
    
                    string actionName = "Get" + declaringType.Name;
                    if (actionMap.Contains(actionName))
                    {
                        // Add keys to route data, so they will bind to action parameters.
                        KeyValuePathSegment keyValueSegment = odataPath.Segments[1] as KeyValuePathSegment;
                        context.RouteData.Values[ODataRouteConstants.Key] = keyValueSegment.Value;
    
                        KeyValuePathSegment relatedKeySegment = odataPath.Segments[3] as KeyValuePathSegment;
                        context.RouteData.Values[ODataRouteConstants.RelatedKey] = relatedKeySegment.Value;
    
                        return actionName;
                    }
                }
                // Not a match.
                return null;
            }
        }
    }

Notes:

1. I derive from **EntitySetRoutingConvention**, because the **SelectController** method in that class is appropriate for this new routing convention. That means I don't need to re-implement **SelectController**.
2. The convention applies only to GET requests, and only when the path template is &quot;~/entityset/key/navigation/key&quot;.
3. The action name is &quot;Get{EntityType}&quot;, where *{EntityType}* is the type of the navigation collection. For example, &quot;GetSupplier&quot;. You can use any naming convention that you like &#8212; just make sure your controller actions match.
4. The action takes two parameters named *key* and *relatedKey*. (For a list of some predefined parameter names, see [ODataRouteConstants](https://msdn.microsoft.com/en-us/library/system.web.http.odata.routing.odatarouteconstants.aspx).)

The next step is adding the new convention to the list of routing conventions. This happens during configuration, as shown in the following code:

    using ODataRouting.Models;
    using System.Web.Http;
    using System.Web.Http.OData.Builder;
    using System.Web.Http.OData.Routing;
    using System.Web.Http.OData.Routing.Conventions;
    
    namespace ODataRouting
    {
        public static class WebApiConfig
        {
            public static void Register(HttpConfiguration config)
            {
                ODataModelBuilder modelBuilder = new ODataConventionModelBuilder();
                // Create EDM (not shown).
    
                // Create the default collection of built-in conventions.
                var conventions = ODataRoutingConventions.CreateDefault();
                // Insert the custom convention at the start of the collection.
                conventions.Insert(0, new NavigationIndexRoutingConvention());
    
                config.Routes.MapODataRoute(routeName: "ODataRoute",
                    routePrefix: "odata",
                    model: modelBuilder.GetEdmModel(),
                    pathHandler: new DefaultODataPathHandler(),
                    routingConventions: conventions);
    
            }
        }
    }

Here are some other sample routing conventions that be useful to study:

- [CompositeKeyRoutingConvention](http://aspnet.codeplex.com/sourcecontrol/latest#Samples/WebApi/ODataCompositeKeySample/ODataCompositeKeySample/Extensions/CompositeKeyRoutingConvention.cs)
- [CustomNavigationRoutingConvention](http://aspnet.codeplex.com/sourcecontrol/latest#Samples/WebApi/ODataServiceSample/ODataService/Extensions/CustomNavigationRoutingConvention.cs)
- [NonBindableActionRoutingConvention](http://aspnet.codeplex.com/sourcecontrol/latest#Samples/WebApi/ODataActionsSample/ODataActionsSample/NonBindableActionRoutingConvention.cs)
- [ODataVersionRouteConstraint](http://aspnet.codeplex.com/sourcecontrol/latest#Samples/WebApi/ODataVersioningSample/ODataVersioningSample/Extensions/ODataVersionRouteConstraint.cs)

And of course Web API itself is open-source, so you can see the [source code](http://aspnetwebstack.codeplex.com/) for the built-in routing conventions. These are defined in the **System.Web.Http.OData.Routing.Conventions** namespace.