---
uid: web-forms/overview/ajax-control-toolkit/dynamicpopulate/dynamically-populating-a-control-cs
title: "Dynamically Populating a Control (C#) | Microsoft Docs"
author: wenz
description: "The DynamicPopulate control in the ASP.NET AJAX Control Toolkit calls a web service (or page method) and fills the resulting value into a target control on t..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 06/02/2008
ms.topic: article
ms.assetid: e1fec43e-1daf-49d2-b0c7-7f1b930455cc
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/ajax-control-toolkit/dynamicpopulate/dynamically-populating-a-control-cs
msc.type: authoredcontent
---
Dynamically Populating a Control (C#)
====================
by [Christian Wenz](https://github.com/wenz)

[Download Code](http://download.microsoft.com/download/d/8/f/d8f2f6f9-1b7c-46ad-9252-e1fc81bdea3e/dynamicpopulate0.cs.zip) or [Download PDF](http://download.microsoft.com/download/b/6/a/b6ae89ee-df69-4c87-9bfb-ad1eb2b23373/dynamicpopulate0CS.pdf)

> The DynamicPopulate control in the ASP.NET AJAX Control Toolkit calls a web service (or page method) and fills the resulting value into a target control on the page, without a page refresh.


## Overview

The `DynamicPopulate` control in the ASP.NET AJAX Control Toolkit calls a web service (or page method) and fills the resulting value into a target control on the page, without a page refresh. This tutorial shows how to set this up.

## Steps

First of all, you need an ASP.NET Web Service which implements the method to be called by `DynamicPopulate`. The web service class requires the `ScriptService` attribute which is defined within `Microsoft.Web.Script.Services`; otherwise ASP.NET AJAX cannot create the client-side JavaScript proxy for the web service which in turn is required by `DynamicPopulate`.

The web method must expect one argument of type string, called `contextKey`, since the `DynamicPopulate` control sends one piece of context information with each web service call. The following web service returns the current date in a format represented by the `contextKey` argument:

[!code-aspx[Main](dynamically-populating-a-control-cs/samples/sample1.aspx)]

The web service is then saved as `DynamicPopulate.cs.asmx`. Alternatively, you could implement the `getDate()` method as a page method within the actual ASP.NET page with the `DynamicPopulate` control.

In the next step, create a new ASP.NET file. As always, the first step is to include the `ScriptManager` in the current page to load the ASP.NET AJAX library and to make the Control Toolkit work:

[!code-aspx[Main](dynamically-populating-a-control-cs/samples/sample2.aspx)]

Then, add a label control (for instance using the HTML control of the same name, or the &lt;`asp:Label` /&gt; web control) which will later show the result of the web service call.

[!code-aspx[Main](dynamically-populating-a-control-cs/samples/sample3.aspx)]

An HTML button (as an HTML control, since we do not require a postback to the server) will then be used to trigger the dynamic population:

[!code-aspx[Main](dynamically-populating-a-control-cs/samples/sample4.aspx)]

Finally, we need the `DynamicPopulateExtender` control to wire things up. The following attributes will be set (apart from the obvious ones, `ID` and `runat`=`"server"`):

- `TargetControlID` where to put the result from the web service call
- `ServicePath` path to the web service (omit if you want to use a page method)
- `ServiceMethod` name of the web method or page method
- `ContextKey` context information to be sent to the web service
- `PopulateTriggerControlID` element which triggers the web service call
- `ClearContentsDuringUpdate` whether to empty the target element during the web service call

As you can see, the control requires some information but putting everything into place is quite straight-forward. Here is the markup for the `DynamicPopulateExtender` control in the current scenario:

[!code-aspx[Main](dynamically-populating-a-control-cs/samples/sample5.aspx)]

Run the ASP.NET page in the browser and click on the button; you will receive the current date in month-day-year format.


[![A click on the button retrieves the date from the server](dynamically-populating-a-control-cs/_static/image2.png)](dynamically-populating-a-control-cs/_static/image1.png)

A click on the button retrieves the date from the server ([Click to view full-size image](dynamically-populating-a-control-cs/_static/image3.png))

>[!div class="step-by-step"]
[Next](dynamically-populating-a-control-using-javascript-code-cs.md)