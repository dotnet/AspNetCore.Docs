---
title: "Collapsing and Expanding a Panel from JavaScript (VB) | Microsoft Docs"
author: wenz
description: "The CollapsiblePanel control in the ASP.NET AJAX Control Toolkit extends a panel and provides it with the capability to collapse its contents and expand it a..."
ms.author: riande
manager: wpickett
ms.date: 06/02/2008
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/ajax-control-toolkit/collapsiblepanel/collapsing-and-expanding-a-panel-from-javascript-vb
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\web-forms\overview\ajax-control-toolkit\collapsiblepanel\collapsing-and-expanding-a-panel-from-javascript-vb.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/24807) | [View dev content](http://docs.aspdev.net/tutorials/web-forms/overview/ajax-control-toolkit/collapsiblepanel/collapsing-and-expanding-a-panel-from-javascript-vb.html) | [View prod content](http://www.asp.net/web-forms/overview/ajax-control-toolkit/collapsiblepanel/collapsing-and-expanding-a-panel-from-javascript-vb) | Picker: 33107

Collapsing and Expanding a Panel from JavaScript (VB)
====================
by [Christian Wenz](https://github.com/wenz)

[Download Code](http://download.microsoft.com/download/8/a/a/8aab3c3e-de6f-463f-805c-5fda567eef6e/CollapsiblePanel1.vb.zip) or [Download PDF](http://download.microsoft.com/download/b/6/a/b6ae89ee-df69-4c87-9bfb-ad1eb2b23373/collapsiblepanel1VB.pdf)

> The CollapsiblePanel control in the ASP.NET AJAX Control Toolkit extends a panel and provides it with the capability to collapse its contents and expand it again. These two actions can also be triggered from custom JavaScript code.


## Overview

The CollapsiblePanel control in the ASP.NET AJAX Control Toolkit extends a panel and provides it with the capability to collapse its contents and expand it again. These two actions can also be triggered from custom JavaScript code.

## Steps

First of all, create a new ASP.NET page and include the `ScriptManager` within the one `<form>` element. This loads the ASP.NET AJAX library which is required by the Control Toolkit:

    <asp:ScriptManager ID="asm" runat="server" />

Then, create a panel with some text so that the collapse/expand effect can be seen:

    <asp:Panel ID="Panel1" CssClass="panelClass" runat="server">
     ASP.NET AJAX is a free framework for quickly creating a new generation of more 
     efficient, more interactive and highly-personalized Web experiences that work 
     across all the most popular browsers.<br />
     ASP.NET AJAX is a free framework for quickly creating a new generation of more 
     efficient, more interactive and highly-personalized Web experiences that work 
     across all the most popular browsers.<br />
     ASP.NET AJAX is a free framework for quickly creating a new generation of more 
     efficient, more interactive and highly-personalized Web experiences that work 
     across all the most popular browsers.<br />
    </asp:Panel>

As you can see, the panel references a CSS class which is shown here (and basically defines a background color and the panel's width):

    <style type="text/css">
     .panelClass {background-color: lime; width: 300px;}
    </style>

The `CollapsiblePanelExtender` control requires the `TargetControlID` attribute so that the toolkit knows which panel to collapse or expand upon request:

    <ajaxToolkit:CollapsiblePanelExtender ID="cpe" runat="server"
     TargetControlID="Panel1" />

Unfortunately, the extender currently does not expose a specific API for collapsing or expanding the panel, but some undocumented methods will do. First of all, add three HTML buttons to the page which will then trigger the client-side JavaScript to collapse or expand the panel's contents:

    <input type="button" id="Button1" runat="server" value="Open" onclick="doOpen();" />
    <input type="button" id="Button2" runat="server" value="Close" onclick="doClose();" />
    <input type="button" id="Button3" runat="server" value="Toggle" onclick="doToggle();" />

In the client-side JavaScript code (started with `<script type="text/javascript">`), the `$find()` method needs to be used to access the `CollapsiblePanelExtender`. `$find("cpe")` will return a reference to it. From there on, specific methods will solve the task at hand.

The method for opening (expanding) the panel is called `_doOpen()`; the following code implements the `doOpen()` function called when the first button is clicked:

    function doOpen() 
    {
     $find("cpe")._doOpen();
    }

For closing, or collapsing the panel, the `_doClose()` method needs to be executed. So when the user clicks on the second button, the following JavaScript code is called:

    function doClose() 
    {
     $find("cpe")._doClose();
    }

The third button toggles the state of the panel: from collapsed to expanded, and vice versa. The `CollapsiblePanelExtender` exposes the `toggle()` method which does exactly that: reverses the state of the panel. However there is also another approach (which is internally used by the `toggle()` method): The `get_Collapsed()` method of the `CollapsiblePanelExtender()` tells us whether the panel is collapsed or not. Depending on the return value of this function, the panel is then either expanded (`_doOpen()` method) or collapsed (`_doClose()`) method:

    function doToggle() 
    {
     var cpe = $find("cpe");
     //cpe._toggle();
     if (cpe.get_Collapsed()) {
     cpe._doOpen();
     } else {
     cpe._doClose();
     }
    }


[![The third button changes the state of the panel: from collapsed to expanded and back](collapsing-and-expanding-a-panel-from-javascript-vb/_static/image2.png)](collapsing-and-expanding-a-panel-from-javascript-vb/_static/image1.png)

The third button changes the state of the panel: from collapsed to expanded and back ([Click to view full-size image](collapsing-and-expanding-a-panel-from-javascript-vb/_static/image3.png))

>[!div class="step-by-step"] [Previous](collapsing-and-expanding-a-panel-from-javascript-cs.md)