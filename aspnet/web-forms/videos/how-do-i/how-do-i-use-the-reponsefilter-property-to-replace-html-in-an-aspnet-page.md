---
uid: web-forms/videos/how-do-i/how-do-i-use-the-reponsefilter-property-to-replace-html-in-an-aspnet-page
title: "[How Do I:] Use the Reponse.Filter Property to Replace HTML in an ASP.NET Page | Microsoft Docs"
author: rick-anderson
description: "In this video Chris Pels shows how to use the Reponse.Filter property to intercept and alter the HTML being sent to a page. First, a sample page is created w..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 01/29/2009
ms.topic: article
ms.assetid: 3e5ae74a-9798-47d8-a2b3-0d8ad42dd4bc
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/videos/how-do-i/how-do-i-use-the-reponsefilter-property-to-replace-html-in-an-aspnet-page
msc.type: video
---
[How Do I:] Use the Reponse.Filter Property to Replace HTML in an ASP.NET Page
====================
by [Chris Pels](https://twitter.com/chrispels)

In this video Chris Pels shows how to use the Reponse.Filter property to intercept and alter the HTML being sent to a page. First, a sample page is created with some simple text. Then, a custom Stream class is created which serves as the replacement stream for the current stream being sent to the user's browser. In that custom stream class the contents of the page are retrieved from the stream, altered, and then written out to the response stream. In this custom Stream class the Write method is customized to replace the HTML in the base Response stream, thereby altering what is sent to the user's browser. Finally, the new stream class is assigned to the Response.Filter property in the Page\_Load event, thereby, providing the mechanism for altering the page content.

[&#9654; Watch video (13 minutes)](https://channel9.msdn.com/Blogs/ASP-NET-Site-Videos/how-do-i-use-the-reponsefilter-property-to-replace-html-in-an-aspnet-page)