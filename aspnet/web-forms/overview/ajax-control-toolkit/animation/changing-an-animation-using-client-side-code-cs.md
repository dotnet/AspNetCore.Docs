---
uid: web-forms/overview/ajax-control-toolkit/animation/changing-an-animation-using-client-side-code-cs
title: "Changing an Animation Using Client-Side Code (C#) | Microsoft Docs"
author: wenz
description: "The Animation control in the ASP.NET AJAX Control Toolkit is not just a control but a whole framework to add animations to a control. The animation can also..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 06/02/2008
ms.topic: article
ms.assetid: 2bfbc5cc-f942-44b7-a62d-a29520f1da9a
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/ajax-control-toolkit/animation/changing-an-animation-using-client-side-code-cs
msc.type: authoredcontent
---
Changing an Animation Using Client-Side Code (C#)
====================
by [Christian Wenz](https://github.com/wenz)

[Download Code](http://download.microsoft.com/download/f/9/a/f9a26acd-8df4-4484-8a18-199e4598f411/Animation11.cs.zip) or [Download PDF](http://download.microsoft.com/download/6/7/1/6718d452-ff89-4d3f-a90e-c74ec2d636a3/animation11CS.pdf)

> The Animation control in the ASP.NET AJAX Control Toolkit is not just a control but a whole framework to add animations to a control. The animation can also be changed using custom client-side JavaScript code.


## Overview

The Animation control in the ASP.NET AJAX Control Toolkit is not just a control but a whole framework to add animations to a control. The animation can also be changed using custom client-side JavaScript code.

## Steps

First of all, include the `ScriptManager` in the page; then, the ASP.NET AJAX library is loaded, making it possible to use the Control Toolkit:

[!code-aspx[Main](changing-an-animation-using-client-side-code-cs/samples/sample1.aspx)]

The animation will be applied to a panel of text which looks like this:

[!code-aspx[Main](changing-an-animation-using-client-side-code-cs/samples/sample2.aspx)]

In the associated CSS class for the panel, define a nice background color and also set a fixed width for the panel:

[!code-css[Main](changing-an-animation-using-client-side-code-cs/samples/sample3.css)]

The actual animation is launched by an HTML button:

[!code-aspx[Main](changing-an-animation-using-client-side-code-cs/samples/sample4.aspx)]

Then, add the `AnimationExtender` to the page, providing an `ID`, the `TargetControlID` attribute and the obligatory `runat="server"`:

[!code-aspx[Main](changing-an-animation-using-client-side-code-cs/samples/sample5.aspx)]

Note that there is no `<Animations>` node within the `AnimationExtender` control. Custom JavaScript code is used to provide the animations to be used with the control.

As with the server API of `AnimationExtender`, there is no easy way to assign an animation to the extender yet. However the extender does expose several methods to read and write animations registered with the various events (`OnClick`, `OnLoad`, and so on). Here are some examples:

- `get_OnClick()`
- `set_OnClick()`
- `get_OnLoad()`
- `set_OnLoad()`
- `...`

The format of the return value of the `get_*()` functions and the format of the argument for the `set_*()` functions is a JSON string, providing an object representation of what the XML markup would be. Currently, there is no way to pass an object in, but it is possible to read an object from a given animation (`get_OnXXXBehavior()` methods).

Here is a JSON string (without the delimiting quotes and formatted nicely) representing an animation triggered by the button, but animating the panel by resizing it and fading it out at the same time:

[!code-json[Main](changing-an-animation-using-client-side-code-cs/samples/sample6.json)]

The following JavaScript code assigns this JSON descripting to the `OnClick` animation of the current extender and runs it:

[!code-html[Main](changing-an-animation-using-client-side-code-cs/samples/sample7.html)]


[![The animation runs immediately, without a mouse click (and with very little markup)](changing-an-animation-using-client-side-code-cs/_static/image2.png)](changing-an-animation-using-client-side-code-cs/_static/image1.png)

The animation runs immediately, without a mouse click (and with very little markup) ([Click to view full-size image](changing-an-animation-using-client-side-code-cs/_static/image3.png))

>[!div class="step-by-step"]
[Previous](executing-animations-using-client-side-code-cs.md)
[Next](animating-an-updatepanel-control-cs.md)