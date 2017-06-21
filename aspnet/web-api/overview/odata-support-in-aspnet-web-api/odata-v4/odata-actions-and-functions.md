---
uid: web-api/overview/odata-support-in-aspnet-web-api/odata-v4/odata-actions-and-functions
title: "Actions and Functions in OData v4 Using ASP.NET Web API 2.2 | Microsoft Docs"
author: MikeWasson
description: "In OData, actions and functions are a way to add server-side behaviors that are not easily defined as CRUD operations on entities. This tutorial shows how to..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 06/27/2014
ms.topic: article
ms.assetid: 0e6fb03c-b16d-4bb0-ab0b-552bd2b6ece1
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/odata-support-in-aspnet-web-api/odata-v4/odata-actions-and-functions
msc.type: authoredcontent
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

> [!NOTE]
> This tutorial builds on the tutorial [Create an OData v4 Endpoint Using ASP.NET Web API 2](create-an-odata-v4-endpoint.md)


First, add a `ProductRating` model to represent the ratings.

[!code-csharp[Main](odata-actions-and-functions/samples/sample1.cs)]

Also add a **DbSet** to the `ProductsContext` class, so that EF will create a Ratings table in the database.

[!code-csharp[Main](odata-actions-and-functions/samples/sample2.cs)]

### Add the Action to the EDM

In WebApiConfig.cs, add the following code:

[!code-csharp[Main](odata-actions-and-functions/samples/sample3.cs)]

The **EntityTypeConfiguration.Action** method adds an action to the entity data model (EDM). The **Parameter** method specifies a typed parameter for the action.

This code also sets the namespace for the EDM. The namespace matters because the URI for the action includes the fully-qualified action name:

[!code-console[Main](odata-actions-and-functions/samples/sample4.cmd)]

> [!NOTE]
> In a typical IIS configuration, the dot in this URL will cause IIS to return error 404. You can resolve this by adding the following section to your Web.Config file:

[!code-xml[Main](odata-actions-and-functions/samples/sample5.xml)]

### Add a Controller Method for the Action

To enable the &quot;Rate&quot; action, add the following method to `ProductsController`:

[!code-csharp[Main](odata-actions-and-functions/samples/sample6.cs)]

Notice that the method name matches the action name. The **[HttpPost]** attribute specifies the method is an HTTP POST method.

To invoke the action, the client sends an HTTP POST request like the following:

[!code-console[Main](odata-actions-and-functions/samples/sample7.cmd)]

The &quot;Rate&quot; action is bound to Product instances, so the URI for the action is the fully-qualified action name appended to the entity URI. (Recall that we set the EDM namespace to &quot;ProductService&quot;, so the fully-qualified action name is &quot;ProductService.Rate&quot;.)

The body of the request contains the action parameters as a JSON payload. Web API automatically converts the JSON payload to an **ODataActionParameters** object, which is just a dictionary of parameter values. Use this dictionary to access the parameters in your controller method.

If the client sends the action parameters in the wrong format, the value of **ModelState.IsValid** is false. Check this flag in your controller method and return an error if **IsValid** is false.

[!code-csharp[Main](odata-actions-and-functions/samples/sample8.cs)]

## Example: Adding a Function

Now let's add an OData function that returns the most expensive product. As before, the first step is adding the function to the EDM. In WebApiConfig.cs, add the following code.

[!code-csharp[Main](odata-actions-and-functions/samples/sample9.cs)]

In this case, the function is bound to the Products collection, rather than individual Product instances. Clients invoke the function by sending a GET request:

[!code-console[Main](odata-actions-and-functions/samples/sample10.cmd)]

Here is the controller method for this function:

[!code-csharp[Main](odata-actions-and-functions/samples/sample11.cs)]

Notice that the method name matches the function name. The **[HttpGet]** attribute specifies the method is an HTTP GET method.

Here is the HTTP response:

[!code-console[Main](odata-actions-and-functions/samples/sample12.cmd)]

## Example: Adding an Unbound Function

The previous example was a function bound to a collection. In this next example, we'll create an *unbound* function. Unbound functions are called as static operations on the service. The function in this example will return the sales tax for a given postal code.

In the WebApiConfig file, add the function to the EDM:

[!code-csharp[Main](odata-actions-and-functions/samples/sample13.cs)]

Notice that we are calling **Function** directly on the **ODataModelBuilder**, instead of the entity type or collection. This tells the model builder that the function is unbound.

Here is the controller method that implements the function:

[!code-csharp[Main](odata-actions-and-functions/samples/sample14.cs)]

It does not matter which Web API controller you place this method in. You could put it in `ProductsController`, or define a separate controller. The **[ODataRoute]** attribute defines the URI template for the function.

Here is an example client request:

[!code-console[Main](odata-actions-and-functions/samples/sample15.cmd)]

The HTTP response:

[!code-console[Main](odata-actions-and-functions/samples/sample16.cmd)]