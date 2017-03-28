---
uid: web-api/overview/data/using-web-api-with-entity-framework/part-7
title: "Create the View (UI) | Microsoft Docs"
author: MikeWasson
description: ""
ms.author: aspnetcontent
manager: wpickett
ms.date: 06/16/2014
ms.topic: article
ms.assetid: b2445062-a1fe-4133-8994-f510280f6d9a
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/data/using-web-api-with-entity-framework/part-7
msc.type: authoredcontent
---
Create the View (UI)
====================
by [Mike Wasson](https://github.com/MikeWasson)

[Download Completed Project](https://github.com/MikeWasson/BookService)

In this section, you will start to define the HTML for the app, and add data binding between the HTML and the view model.

Open the file Views/Home/Index.cshtml. Replace the entire contents of that file with the following.

[!code-cshtml[Main](part-7/samples/sample1.cshtml)]

Most of the `div` elements are there for [Bootstrap](http://getbootstrap.com/) styling. The important elements are the ones with `data-bind` attributes. This attribute links the HTML to the view model.

For example:

[!code-html[Main](part-7/samples/sample2.html)]

In this example, the &quot;`text`&quot; binding causes the `<p>` element to show the value of the `error` property from the view model. Recall that `error` was declared as a `ko.observable`:

[!code-javascript[Main](part-7/samples/sample3.js)]

Whenever a new value is assigned to `error`, Knockout updates the text in the `<p>` element.

The `foreach` binding tells Knockout to loop through the contents of the `books` array. For each item in the array, Knockout creates a new &lt;li&gt; element. Bindings inside the context of the `foreach` refer to properties on the array item. For example:

[!code-html[Main](part-7/samples/sample4.html)]

Here the `text` binding reads the Author property of each book.

If you run the application now, it should look like this:

![](part-7/_static/image1.png)

The list of books loads asynchronously, after the page loads. Right now, the &quot;Details&quot; links are not functional. We'll add this functionality in the next section.

>[!div class="step-by-step"]
[Previous](part-6.md)
[Next](part-8.md)