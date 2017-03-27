---
uid: web-api/overview/older-versions/using-web-api-1-with-entity-framework-5/using-web-api-with-entity-framework-part-5
title: "Part 5: Creating a Dynamic UI with Knockout.js | Microsoft Docs"
author: MikeWasson
description: ""
ms.author: aspnetcontent
manager: wpickett
ms.date: 07/04/2012
ms.topic: article
ms.assetid: 9d9cb3b0-f4a7-434e-a508-9fc0ad0eb813
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/older-versions/using-web-api-1-with-entity-framework-5/using-web-api-with-entity-framework-part-5
msc.type: authoredcontent
---
Part 5: Creating a Dynamic UI with Knockout.js
====================
by [Mike Wasson](https://github.com/MikeWasson)

[Download Completed Project](http://code.msdn.microsoft.com/ASP-NET-Web-API-with-afa30545)

## Creating a Dynamic UI with Knockout.js

In this section, we'll use Knockout.js to add functionality to the Admin view.

[Knockout.js](http://knockoutjs.com/) is a Javascript library that makes it easy to bind HTML controls to data. Knockout.js uses the Model-View-ViewModel (MVVM) pattern.

- The *model* is the server-side representation of the data in the business domain (in our case, products and orders).
- The *view* is the presentation layer (HTML).
- The *view-model* is a Javascript object that holds the model data. The view-model is a code abstraction of the UI. It has no knowledge of the HTML representation. Instead, it represents abstract features of the view, such as "a list of items".

The view is data-bound to the view-model. Updates to the view-model are automatically reflected in the view. The view-model also gets events from the view, such as button clicks, and performs operations on the model, such as creating an order.

![](using-web-api-with-entity-framework-part-5/_static/image1.png)

First we'll define the view-model. After that, we will bind the HTML markup to the view-model.

Add the following Razor section to Admin.cshtml:

[!code-cshtml[Main](using-web-api-with-entity-framework-part-5/samples/sample1.cshtml)]

You can add this section anywhere in the file. When the view is rendered, the section appears at the bottom of the HTML page, right before the closing &lt;/body&gt; tag.

All of the script for this page will go inside the script tag indicated by the comment:

[!code-html[Main](using-web-api-with-entity-framework-part-5/samples/sample2.html)]

First, define a view-model class:

[!code-javascript[Main](using-web-api-with-entity-framework-part-5/samples/sample3.js)]

**ko.observableArray** is a special kind of object in Knockout, called an *observable*. From the [Knockout.js documentation](http://knockoutjs.com/documentation/observables.html): An observable is a "JavaScript object that can notify subscribers about changes." When the contents of an observable change, the view is automatically updated to match.

To populate the `products` array, make an AJAX request to the web API. Recall that we stored the base URI for the API in the view bag (see [Part 4](using-web-api-with-entity-framework-part-4.md) of the tutorial).

[!code-javascript[Main](using-web-api-with-entity-framework-part-5/samples/sample4.js?highlight=5)]

Next, add functions to the view-model to create, update, and delete products. These functions submit AJAX calls to the web API and use the results to update the view-model.

[!code-javascript[Main](using-web-api-with-entity-framework-part-5/samples/sample5.js?highlight=7)]

Now the most important part: When the DOM is fulled loaded, call the **ko.applyBindings** function and pass in a new instance of the `ProductsViewModel`:

[!code-javascript[Main](using-web-api-with-entity-framework-part-5/samples/sample6.js)]

The **ko.applyBindings** method activates Knockout and wires up the view-model to the view.

Now that we have a view-model, we can create the bindings. In Knockout.js, you do this by adding `data-bind` attributes to HTML elements. For example, to bind an HTML list to an array, use the `foreach` binding:

[!code-html[Main](using-web-api-with-entity-framework-part-5/samples/sample7.html?highlight=1)]

The `foreach` binding iterates through the array and creates child elements for each object in the array. Bindings on the child elements can refer to properties on the array objects.

Add the following bindings to the "update-products" list:

[!code-html[Main](using-web-api-with-entity-framework-part-5/samples/sample8.html)]

The `<li>` element occurs within the scope of the **foreach** binding. That means Knockout will render the element once for each product in the `products` array. All of the bindings within the `<li>` element refer to that product instance. For example, `$data.Name` refers to the `Name` property on the product.

To set the values of the text inputs, use the `value` binding. The buttons are bound to functions on the model-view, using the `click` binding. The product instance is passed as a parameter to each function. For more information, the [Knockout.js documentation](http://knockoutjs.com/documentation/observables.html) has good descriptions of the various bindings.

Next, add a binding for the **submit** event on the Add Product form:

[!code-html[Main](using-web-api-with-entity-framework-part-5/samples/sample9.html)]

This binding calls the `create` function on the view-model to create a new product.

Here is the complete code for the Admin view:

[!code-cshtml[Main](using-web-api-with-entity-framework-part-5/samples/sample10.cshtml)]

Run the application, log in with the Administrator account, and click the "Admin" link. You should see the list of products, and be able to create, update, or delete products.

>[!div class="step-by-step"]
[Previous](using-web-api-with-entity-framework-part-4.md)
[Next](using-web-api-with-entity-framework-part-6.md)