---
uid: mvc/overview/views/dynamic-v-strongly-typed-views
title: "Dynamic v. Strongly Typed Views | Microsoft Docs"
author: Rick-Anderson
description: ""
ms.author: aspnetcontent
manager: wpickett
ms.date: 01/27/2011
ms.topic: article
ms.assetid: 0cbd88da-0da6-4605-b222-2835c6478304
ms.technology: dotnet-mvc
ms.prod: .net-framework
msc.legacyurl: /mvc/overview/views/dynamic-v-strongly-typed-views
msc.type: authoredcontent
---
Dynamic v. Strongly Typed Views
====================
by [Rick Anderson](https://github.com/Rick-Anderson)

There are three ways to pass information from a controller to a view in ASP.NET MVC 3:

1. As a strongly typed model object.
2. As a dynamic type (using @model dynamic)
3. Using the ViewBag

I've written a simple MVC 3 Top Blog application to compare and contrast dynamic and strongly typed views. The controller starts out with a simple list of blogs:

[!code-csharp[Main](dynamic-v-strongly-typed-views/samples/sample1.cs)]

Right click in the IndexNotStonglyTyped() method and add a Razor view.

[![8475.NotStronglyTypedView[1]](dynamic-v-strongly-typed-views/_static/image2.png)](dynamic-v-strongly-typed-views/_static/image1.png)

Make sure the **Create a strongly-typed view** box is not checked. The resulting view doesn't contain much:

[!code-cshtml[Main](dynamic-v-strongly-typed-views/samples/sample2.cshtml)]

[!code-cshtml[Main](dynamic-v-strongly-typed-views/samples/sample3.cshtml)]

Because we're using a dynamic and not a strongly typed view, intellisense doesn't help us. The completed code is shown below:

[!code-cshtml[Main](dynamic-v-strongly-typed-views/samples/sample4.cshtml)]

[![6646.NotStronglyTypedView_5F00_IE[1]](dynamic-v-strongly-typed-views/_static/image4.png)](dynamic-v-strongly-typed-views/_static/image3.png)

Now we'll add a strongly typed view. Add the following code to the controller:

[!code-csharp[Main](dynamic-v-strongly-typed-views/samples/sample5.cs)]


Notice it's exactly the same return View(topBlogs); call as the non-strongly typed view. Right click inside of *StonglyTypedIndex()* and select **Add View**. This time select the **Blog** Model class and select **List** as the Scaffold template.

[![5658.StrongView[1]](dynamic-v-strongly-typed-views/_static/image6.png)](dynamic-v-strongly-typed-views/_static/image5.png)

Inside the new view template we get intellisense support.

[![7002.intellesince[1]](dynamic-v-strongly-typed-views/_static/image8.png)](dynamic-v-strongly-typed-views/_static/image7.png)

The c# project can be downloaded [here](https://blogs.msdn.com/cfs-file.ashx/__key/CommunityServer-Blogs-Components-WeblogFiles/00-00-01-11-73-SSMS/1817.Mvc3ViewDemo.zip).