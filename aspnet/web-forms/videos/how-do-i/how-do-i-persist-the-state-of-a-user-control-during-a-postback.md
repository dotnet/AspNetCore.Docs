---
title: "[How Do I]: Persist the State of a User Control During a Postback | Microsoft Docs"
author: rick-anderson
description: "In this video Chris Pels shows how to persist the state of one or more objects in a user control. First, a user control is created that represents the abilit..."
ms.author: riande
manager: wpickett
ms.date: 04/02/2009
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/videos/how-do-i/how-do-i-persist-the-state-of-a-user-control-during-a-postback
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\web-forms\videos\how-do-i\how-do-i-persist-the-state-of-a-user-control-during-a-postback.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/26506) | [View dev content](http://docs.aspdev.net/tutorials/web-forms/videos/how-do-i/how-do-i-persist-the-state-of-a-user-control-during-a-postback.html) | [View prod content](http://www.asp.net/web-forms/videos/how-do-i/how-do-i-persist-the-state-of-a-user-control-during-a-postback) | Picker: 33529

[How Do I]: Persist the State of a User Control During a Postback
====================
by [Chris Pels](https://twitter.com/chrispels)

In this video Chris Pels shows how to persist the state of one or more objects in a user control. First, a user control is created that represents the ability for a user to specify filter criteria for a search. In addition, a companion Filter class is created to store the filter information. Several user interface elements are added to the filter control along with some methods and properties to store the current filter information in the Filter class instance. Next, the user control persistence is implemented using the RegisterRequiresControlState method and associated Save/Restore methods. These methods store the instance of the filter class and its data during page postbacks. Finally, there is a discussion of how to store multiple objects in control state implementation.

[&#9654; Watch video (23 minutes)](https://channel9.msdn.com/Blogs/ASP-NET-Site-Videos/how-do-i-persist-the-state-of-a-user-control-during-a-postback)