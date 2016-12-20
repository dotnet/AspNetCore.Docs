---
title: "Using Multiple Popup Controls (C#) | Microsoft Docs"
author: wenz
description: "The PopupControl extender in the AJAX Control Toolkit offers an easy way to trigger a popup when any other control is activated. It is also possible to use m..."
ms.author: riande
manager: wpickett
ms.date: 06/02/2008
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/ajax-control-toolkit/popup/using-multiple-popup-controls-cs
---
Using Multiple Popup Controls (C#)
====================
by [Christian Wenz](https://github.com/wenz)

[Download Code](http://download.microsoft.com/download/9/3/f/93f8daea-bebd-4821-833b-95205389c7d0/PopupControl1.cs.zip) or [Download PDF](http://download.microsoft.com/download/2/d/c/2dc10e34-6983-41d4-9c08-f78f5387d32b/popupcontrol1CS.pdf)

> The PopupControl extender in the AJAX Control Toolkit offers an easy way to trigger a popup when any other control is activated. It is also possible to use more than one popup control on one page.


## Overview

The PopupControl extender in the AJAX Control Toolkit offers an easy way to trigger a popup when any other control is activated. It is also possible to use more than one popup control on one page.

## Steps

In order to activate the functionality of ASP.NET AJAX and the Control Toolkit, the `ScriptManager` control must be put anywhere on the page (but within the `<form>` element):

    <asp:ScriptManager ID="asm" runat="server" />

Next, add a panel which serves as the popup. In the current scenario, the panel contains a `Calendar` control. In order to avoid the page refreshes caused by the Calendar's postbacks, the panel is put within an `UpdatePanel` control:

    <asp:Panel ID="pnlCalendar" runat="server">
     <asp:UpdatePanel ID="up1" runat="server">
     <ContentTemplate>
     <asp:Calendar ID="c1" runat="server" />
     </ContentTemplate>
     </asp:UpdatePanel>
    </asp:Panel>

The page also contains two text boxes. For each text box, the calendar popup shall appear once the text box is activated.

    <div>
     Departure date: <asp:TextBox ID="tbDeparture" runat="server" />
     Return date: <asp:TextBox ID="tbReturn" runat="server" />
    </div>

Now extend each of the two text boxes with a `PopupControlExtender`. The `TargetControlID` attribute provides the ID of the control tied to the extender. The `PopupControlID` attribute contains the ID of the popup panel. In this case, both extenders show the same panel, but different panels are possible, as well.

    <ajaxToolkit:PopupControlExtender ID="pce1" runat="server"
     TargetControlID="tbDeparture" PopupControlID="pnlCalendar" Position="Bottom" />
    <ajaxToolkit:PopupControlExtender ID="pce2" runat="server"
     TargetControlID="tbReturn" PopupControlID="pnlCalendar" Position="Bottom" />

Now whenever you click within a text field, a calendar appears below the field, allowing you to select a date. (Getting the selected date back into the text boxes will be covered in a different tutorial.)


[![The Calendar appears when the user clicks into the textbox](using-multiple-popup-controls-cs/_static/image2.png)](using-multiple-popup-controls-cs/_static/image1.png)

The Calendar appears when the user clicks into the textbox ([Click to view full-size image](using-multiple-popup-controls-cs/_static/image3.png))

>[!div class="step-by-step"] [Next](handling-postbacks-from-a-popup-control-with-an-updatepanel-cs.md)