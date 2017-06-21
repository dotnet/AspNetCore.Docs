---
uid: web-api/overview/data/using-web-api-with-entity-framework/part-8
title: "Display Item Details | Microsoft Docs"
author: MikeWasson
description: ""
ms.author: aspnetcontent
manager: wpickett
ms.date: 06/16/2014
ms.topic: article
ms.assetid: 75ef94b1-bbec-4681-9210-452dba816144
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/data/using-web-api-with-entity-framework/part-8
msc.type: authoredcontent
---
Display Item Details
====================
by [Mike Wasson](https://github.com/MikeWasson)

[Download Completed Project](https://github.com/MikeWasson/BookService)

In this section, you will add the ability to view details for each book. In app.js, add to the following code to the view model:

[!code-javascript[Main](part-8/samples/sample1.js)]

In Views/Home/Index.cshtml, add a data-bind element to the Details link:

[!code-html[Main](part-8/samples/sample2.html?highlight=5)]

This binds the click handler for the &lt;a&gt; element to the `getBookDetail` function on the view model.

In the same file, replace the following mark-up:

[!code-html[Main](part-8/samples/sample3.html)]

with this:

[!code-html[Main](part-8/samples/sample4.html)]

This markup creates a table that is data-bound to the properties of the `detail` observable in the view model.

The "&lt;!-- ko --&gt;&quot; syntax lets you include a Knockout binding outside of a DOM element. In this case, the `if` binding causes this section of markup to be displayed only when `details` is non-null.

[!code-html[Main](part-8/samples/sample5.html)]

Now if you run the app and click one of the &quot;Detail&quot; links, the app will display the book details.

[![](part-8/_static/image2.png)](part-8/_static/image1.png)

>[!div class="step-by-step"]
[Previous](part-7.md)
[Next](part-9.md)