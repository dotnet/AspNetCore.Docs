---
uid: web-forms/overview/ajax-control-toolkit/confirmbutton/using-a-confirmbutton-in-a-repeater-cs
title: "Using a ConfirmButton In a Repeater (C#) | Microsoft Docs"
author: wenz
description: "The ConfirmButton extender in the AJAX Control Toolkit creates a Yes/No popup when the user clicks on a button (including LinkButton control). Only if Yes is..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 06/02/2008
ms.topic: article
ms.assetid: a973ed3e-400c-4925-ace2-0b086b479301
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/ajax-control-toolkit/confirmbutton/using-a-confirmbutton-in-a-repeater-cs
msc.type: authoredcontent
---
Using a ConfirmButton In a Repeater (C#)
====================
by [Christian Wenz](https://github.com/wenz)

[Download Code](http://download.microsoft.com/download/8/6/d/86dea6c6-bb92-4fa6-aa14-f8c0f82100f5/ConfirmButton1.cs.zip) or [Download PDF](http://download.microsoft.com/download/b/6/a/b6ae89ee-df69-4c87-9bfb-ad1eb2b23373/confirmbutton1CS.pdf)

> The ConfirmButton extender in the AJAX Control Toolkit creates a Yes/No popup when the user clicks on a button (including LinkButton control). Only if Yes is clicked, the button's action is executed, otherwise cancelled. This is also possible in a repeater.


## Overview

The ConfirmButton extender in the AJAX Control Toolkit creates a Yes/No popup when the user clicks on a button (including LinkButton control). Only if Yes is clicked, the button's action is executed, otherwise cancelled. This is also possible in a repeater.

## Steps

First of all, a data source is required. This sample uses the AdventureWorks database and the Microsoft SQL Server 2005 Express Edition. The database is an optional part of a Visual Studio installation (including express edition) and is also available as a separate download under [https://go.microsoft.com/fwlink/?LinkId=64064](https://go.microsoft.com/fwlink/?LinkId=64064). The AdventureWorks database is part of the SQL Server 2005 Samples and Sample Databases (download at [https://www.microsoft.com/downloads/details.aspx?FamilyID=e719ecf7-9f46-4312-af89-6ad8702e4e6e&amp;DisplayLang=en](https://www.microsoft.com/downloads/details.aspx?FamilyID=e719ecf7-9f46-4312-af89-6ad8702e4e6e&amp;DisplayLang=en)). The easiest way to set the database up is to use the Microsoft SQL Server Management Studio Express ([https://www.microsoft.com/downloads/details.aspx?FamilyID=c243a5ae-4bd1-4e3d-94b8-5a0f62bf7796&amp;DisplayLang=en](https://www.microsoft.com/downloads/details.aspx?FamilyID=c243a5ae-4bd1-4e3d-94b8-5a0f62bf7796&amp;DisplayLang=en)) and attach the `AdventureWorks.mdf` database file.

For this sample, we assume that the instance of the SQL Server 2005 Express Edition is called `SQLEXPRESS` and resides on the same machine as the web server; this is also the default setup. If your setup differs, you have to adapt the connection information for the database.

In order to activate the functionality of ASP.NET AJAX and the Control Toolkit, the `ScriptManager` control must be put anywhere on the page (but within the `<form>` element):

[!code-aspx[Main](using-a-confirmbutton-in-a-repeater-cs/samples/sample1.aspx)]

Then, a data source is required. For the sake of simplicity, only the first five entries in AdventureWorks' Vendors table are retrieved. Note that when using the Visual Studio wizard to create the data source, the table name (`Vendors`) is currently not correctly prefixed with `Purchasing`. The following markup is the correct one:

[!code-aspx[Main](using-a-confirmbutton-in-a-repeater-cs/samples/sample2.aspx)]

This data source can then be used within a repeater. As usual, the `DataBinder.Eval()` method retrieves data from the data source. The `ConfirmButtonExtender` control must then be placed within the `<ItemTemplate>` section of the repeater so that it appears for every entry in the data source.

[!code-aspx[Main](using-a-confirmbutton-in-a-repeater-cs/samples/sample3.aspx)]


[![The confirm button appears next to each entry from the data source](using-a-confirmbutton-in-a-repeater-cs/_static/image2.png)](using-a-confirmbutton-in-a-repeater-cs/_static/image1.png)

The confirm button appears next to each entry from the data source ([Click to view full-size image](using-a-confirmbutton-in-a-repeater-cs/_static/image3.png))

>[!div class="step-by-step"]
[Next](using-a-confirmbutton-in-a-repeater-vb.md)