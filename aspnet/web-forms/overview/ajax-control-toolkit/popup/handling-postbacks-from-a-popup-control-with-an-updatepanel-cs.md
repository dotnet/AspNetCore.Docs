---
uid: web-forms/overview/ajax-control-toolkit/popup/handling-postbacks-from-a-popup-control-with-an-updatepanel-cs
title: "Handling Postbacks from A Popup Control With an UpdatePanel (C#) | Microsoft Docs"
author: wenz
description: "The PopupControl extender in the AJAX Control Toolkit offers an easy way to trigger a popup when any other control is activated. Special care has to be taken..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 06/02/2008
ms.topic: article
ms.assetid: 1f68f59d-9c1e-4cf3-b304-c13ae6b7203e
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/ajax-control-toolkit/popup/handling-postbacks-from-a-popup-control-with-an-updatepanel-cs
msc.type: authoredcontent
---
Handling Postbacks from A Popup Control With an UpdatePanel (C#)
====================
by [Christian Wenz](https://github.com/wenz)

[Download Code](http://download.microsoft.com/download/9/3/f/93f8daea-bebd-4821-833b-95205389c7d0/PopupControl2.cs.zip) or [Download PDF](http://download.microsoft.com/download/2/d/c/2dc10e34-6983-41d4-9c08-f78f5387d32b/popupcontrol2CS.pdf)

> The PopupControl extender in the AJAX Control Toolkit offers an easy way to trigger a popup when any other control is activated. Special care has to be taken when a postback occurs within such a popup.


## Overview

The PopupControl extender in the AJAX Control Toolkit offers an easy way to trigger a popup when any other control is activated. Special care has to be taken when a postback occurs within such a popup.

## Steps

When using a `PopupControl` with a postback, an `UpdatePanel` can prevent the page refresh caused by the postback. The following markup defines a couple of important elements:

- A `ScriptManager` control so that the ASP.NET AJAX Control Toolkit works
- Two `TextBox` controls which will both trigger a popup
- A `Panel` control that will serve as the popup
- Within the panel, a `Calendar` control is embedded within an `UpdatePanel` control
- Two `PopupControlExtender` controls that assign the panel to the text boxes

[!code-aspx[Main](handling-postbacks-from-a-popup-control-with-an-updatepanel-cs/samples/sample1.aspx)]

Note that the `OnSelectionChanged` attribute of the `Calendar` control is set. So when the user selects a date within the calendar, a postback occurs and the server-side method `c1_SelectionChanged()` is executed. Within that method, the current date must be retrieved and written back to the textbox.

The syntax for that is as follows: First of all, a proxy object for the `PopupControlExtender` on the page must be generated. The ASP.NET AJAX Control Toolkit offers the `GetProxyForCurrentPopup()` method. The object this method returns supports the `Commit()` method which sends a value back to the control that triggered the popup (not the control that triggered the method call!). The following code provides the selected date as the argument for the `Commit()` method, causing the code to write the selected date back to the text box:

[!code-aspx[Main](handling-postbacks-from-a-popup-control-with-an-updatepanel-cs/samples/sample2.aspx)]

Now whenever you click on a calendar date, the selected date appears in the associated text box, creating a date picker control that can currently be found on many websites.


[![The Calendar appears when the user clicks into the textbox](handling-postbacks-from-a-popup-control-with-an-updatepanel-cs/_static/image2.png)](handling-postbacks-from-a-popup-control-with-an-updatepanel-cs/_static/image1.png)

The Calendar appears when the user clicks into the textbox ([Click to view full-size image](handling-postbacks-from-a-popup-control-with-an-updatepanel-cs/_static/image3.png))


[![Clicking on a date puts it in the textbox](handling-postbacks-from-a-popup-control-with-an-updatepanel-cs/_static/image5.png)](handling-postbacks-from-a-popup-control-with-an-updatepanel-cs/_static/image4.png)

Clicking on a date puts it in the textbox ([Click to view full-size image](handling-postbacks-from-a-popup-control-with-an-updatepanel-cs/_static/image6.png))

>[!div class="step-by-step"]
[Previous](using-multiple-popup-controls-cs.md)
[Next](handling-postbacks-from-a-popup-control-without-an-updatepanel-cs.md)