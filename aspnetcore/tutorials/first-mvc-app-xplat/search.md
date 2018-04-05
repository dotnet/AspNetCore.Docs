---
title: Adding Search
author: rick-anderson
description: Shows how to add search to simple ASP.NET Core MVC app
manager: wpickett
ms.author: riande
ms.date: 04/07/2017
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: get-started-article
uid: tutorials/first-mvc-app-xplat/search
---

[!INCLUDE[adding-model](../../includes/mvc-intro/search1.md)]

Note: SQLlite is case sensitive, so you'll need to search for "Ghost" and not "ghost".

[!INCLUDE[adding-model](../../includes/mvc-intro/search2.md)]

Change the `<form>` tag in the *Views\movie\Index.cshtml* Razor view to specify `method="get"`:

```html
<form asp-controller="Movies" asp-action="Index" method="get">
```

[!INCLUDE[adding-model](../../includes/mvc-intro/search3.md)]

>[!div class="step-by-step"]
[Previous - Controller methods and views](controller-methods-views.md)
[Next - Add a field](new-field.md)  
