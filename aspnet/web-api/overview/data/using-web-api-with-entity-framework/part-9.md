---
title: "Add a New Item to the Database | Microsoft Docs"
author: MikeWasson
description: ""
ms.author: riande
manager: wpickett
ms.date: 06/16/2014
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/data/using-web-api-with-entity-framework/part-9
---
Add a New Item to the Database
====================
by [Mike Wasson](https://github.com/MikeWasson)

[Download Completed Project](https://github.com/MikeWasson/BookService)

In this section, you will add the ability for users to create a new book. In app.js, add the following code to the view model:

[!code[Main](part-9/samples/sample1.xml)]

In Index.cshtml, replace the following markup:

[!code[Main](part-9/samples/sample2.xml)]

With:

[!code[Main](part-9/samples/sample3.xml)]

This markup creates a form for submitting a new author. The values for the author drop-down list are data-bound to the `authors` observable in the view model. For the other form inputs, the values are data-bound to the `newBook` property of the view model.

The submit handler on the form is bound to the `addBook` function:

[!code[Main](part-9/samples/sample4.xml)]

The `addBook` function reads the current values of the data-bound form inputs to create a JSON object. Then it POSTs the JSON object to `/api/books`.

>[!div class="step-by-step"]
[Previous](part-8.md)
[Next](part-10.md)