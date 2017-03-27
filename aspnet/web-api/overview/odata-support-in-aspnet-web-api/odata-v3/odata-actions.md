---
uid: web-api/overview/odata-support-in-aspnet-web-api/odata-v3/odata-actions
title: "Supporting OData Actions in ASP.NET Web API 2 | Microsoft Docs"
author: MikeWasson
description: "In OData, actions are a way to add server-side behaviors that are not easily defined as CRUD operations on entities. Some uses for actions include: Implement..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/25/2014
ms.topic: article
ms.assetid: 2d7b3aa2-aa47-4e6e-b0ce-3d65a1c6fe02
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/odata-support-in-aspnet-web-api/odata-v3/odata-actions
msc.type: authoredcontent
---
Supporting OData Actions in ASP.NET Web API 2
====================
by [Mike Wasson](https://github.com/MikeWasson)

[Download Completed Project](http://code.msdn.microsoft.com/ASPNET-Web-API-OData-cecdb524)

> In OData, *actions* are a way to add server-side behaviors that are not easily defined as CRUD operations on entities. Some uses for actions include:
> 
> - Implementing complex transactions.
> - Manipulating several entities at once.
> - Allowing updates only to certain properties of an entity.
> - Sending information to the server that is not defined in an entity.
> 
> ## Software versions used in the tutorial
> 
> 
> - Web API 2
> - OData Version 3
> - Entity Framework 6


## Example: Rating a Product

In this example, we want to let users rate products, and then expose the average ratings for each product. On the database, we will store a list of ratings, keyed to products.

Here is the model we might use to represent the ratings in Entity Framework:

[!code-csharp[Main](odata-actions/samples/sample1.cs)]

But we don't want clients to POST a `ProductRating` object to a "Ratings" collection. Intuitively, the rating is associated with the Products collection, and the client should only need to post the rating value.

Therefore, instead of using the normal CRUD operations, we define an action that a client can invoke on a Product. In OData terminology, the action is *bound* to Product entities.

>Actions have side-effects on the server. For this reason, they are invoked using HTTP POST requests. Actions can have parameters and return types, which are described in the service metadata. The client sends the parameters in the request body, and the server sends the return value in the response body. To invoke the "Rate Product" action, the client sends a POST to a URI like the following:

[!code-console[Main](odata-actions/samples/sample2.cmd)]

The data in the POST request is simply the product rating:

[!code-console[Main](odata-actions/samples/sample3.cmd)]

## Declare the Action in the Entity Data Model

In your Web API configuration, add the action to the entity data model (EDM):

[!code-csharp[Main](odata-actions/samples/sample4.cs)]

This code defines "RateProduct" as an action that can be performed on Product entities. It also declares that the action takes an **int** parameter named "Rating", and returns an **int** value.

## Add the Action to the Controller

The "RateProduct" action is bound to Product entities. To implement the action, add a method named `RateProduct` to the Products controller:

[!code-csharp[Main](odata-actions/samples/sample5.cs)]

Notice that the method name matches the name of the action in the EDM. The method has two parameters:

- *key*: The key for the product to rate.
- *parameters*: A dictionary of action parameter values.

If you are using the default routing conventions, the key parameter must be named "key". It is also important to include the **[FromOdataUri]** attribute, as shown. This attribute tells Web API to use OData syntax rules when it parses the key from the request URI.

Use the *parameters* dictionary to get the action parameters:

[!code-csharp[Main](odata-actions/samples/sample6.cs)]

If the client sends the action parameters in the correct format, the value of **ModelState.IsValid** is true. In that case, you can use the **ODataActionParameters** dictionary to get the parameter values. In this example, the `RateProduct` action takes a single parameter named "Rating".

## Action Metadata

To view the service metadata, send a GET request to /odata/$metadata. Here is the portion of the metadata that declares the `RateProduct` action:

[!code-xml[Main](odata-actions/samples/sample7.xml)]

The **FunctionImport** element declares the action. Most of the fields are self-explanatory, but two are worth noting:

- **IsBindable** means the action can be invoked on the target entity, at least some of the time.
- **IsAlwaysBindable** means the action can always be invoked on the target entity.

The difference is that some actions are always available to clients, but other actions might depend on the state of the entity. For example, suppose you define a "Purchase" action. You can only purchase an item that is in stock. If the item is out of stock, a client cannot invoke that action.

When you define the EDM, the **Action** method creates an always-bindable action:

[!code-csharp[Main](odata-actions/samples/sample8.cs?highlight=1)]

I'll talk about not-always-bindable actions (also called *transient* actions) later in this topic.

## Invoking the Action

Now let's see how a client would invoke this action. Suppose the client wants to give a rating of 2 to the product with ID = 4. Here is an example request message, using JSON format for the request body:

[!code-console[Main](odata-actions/samples/sample9.cmd)]

Here is the response message:

[!code-console[Main](odata-actions/samples/sample10.cmd)]

## Binding an Action to an Entity Set

In the previous example, the action is bound to a single entity: The client rates a single product. You can also bind an action to a collection of entities. Just make the following changes:

In the EDM, add the action to the entity's **Collection** property.

[!code-csharp[Main](odata-actions/samples/sample11.cs?highlight=1)]

In the controller method, omit the *key* parameter.

[!code-csharp[Main](odata-actions/samples/sample12.cs)]

Now the client invokes the action on the Products entity set:

[!code-console[Main](odata-actions/samples/sample13.cmd)]

## Actions with Collection Parameters

Actions can have parameters that take a collection of values. In the EDM, use **CollectionParameter&lt;T&gt;** to declare the parameter.

[!code-csharp[Main](odata-actions/samples/sample14.cs)]

This declares a parameter named "Ratings" that takes a collection of **int** values. In the controller method, you still get the parameter value from the **ODataActionParameters** object, but now the value is an **ICollection&lt;int&gt;** value:

[!code-csharp[Main](odata-actions/samples/sample15.cs)]

## Transient Actions

In the "RateProduct" example, users can always rate a product, so the action is always available. But some actions depend on the state of the entity. For example, in a video rental service, the "CheckOut" action is not always available. (It depends whether a copy of that video is available.) This type of action is called a *transient* action.

In the service metadata, a transient action has **IsAlwaysBindable** equal to false. That's actually the default value, so the metadata will look like this:

[!code-xml[Main](odata-actions/samples/sample16.xml)]

Here's why this matters: If an action is transient, the server needs to tell the client when the action is available. It does this by including a link to the action in the entity. Here is an example for a Movie entity:

[!code-console[Main](odata-actions/samples/sample17.cmd)]

The "#CheckOut" property contains a link to the CheckOut action. If the action is not available, the server omits the link.

To declare a transient action in the EDM, call the **TransientAction** method:

[!code-csharp[Main](odata-actions/samples/sample18.cs)]

Also, you must provide a function that returns an action link for a given entity. Set this function by calling **HasActionLink**. You can write the function as a lambda expression:

[!code-csharp[Main](odata-actions/samples/sample19.cs)]

If the action is available, the lambda expression returns a link to the action. The OData serializer includes this link when it serializes the entity. When the action is not available, the function returns `null`.

## Additional Resources

[OData Actions Sample](http://aspnet.codeplex.com/sourcecontrol/latest#Samples/WebApi/OData/v3/ODataActionsSample/)