---
title: Adding Search
author: rick-anderson
description: Shows how to add search to simple ASP.NET Core MVC app
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 03/07/2017
ms.topic: get-started-article
ms.assetid: d69e5529-8ef6-4628-855d-200206d962b9
ms.technology: aspnet
ms.prod: asp.net-core
uid: tutorials/first-mvc-app/search
---

[!INCLUDE[adding-model](../../includes/mvc-intro/search1.md)]

You can quickly rename the `searchString` parameter to `id` with the **rename** command. Right click on `searchString` **> Rename**.

![Contextual menu](search/_static/rename.png)

The rename targets are highlighted.

![Code editor showing the variable highlighted throughout the Index ActionResult method](search/_static/rename2.png)

Change the parameter to `id` and all occurrences of `searchString` change to `id`.

![Code editor showing the variable has been changed to id](search/_static/rename3.png)

[!INCLUDE[adding-model](../../includes/mvc-intro/search2.md)]

Notice how intelliSense helps us update the markup.

![Intellisense contextual menu with method selected in the list of attributes for the form element](search/_static/int_m.png)

![Intellisense contextual menu with get selected in the list of method attribute values](search/_static/int_get.png)

Notice the distinctive font in the `<form>` tag. That distinctive font indicates the tag is supported by [Tag Helpers](../../mvc/views/tag-helpers/intro.md).

![form tag with purple text](search/_static/th_font.png)

[!INCLUDE[adding-model](../../includes/mvc-intro/search3.md)]

>[!div class="step-by-step"]
[Previous](controller-methods-views.md)
[Next](new-field.md)  
