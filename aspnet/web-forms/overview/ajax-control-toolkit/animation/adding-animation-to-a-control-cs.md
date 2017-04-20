---
uid: web-forms/overview/ajax-control-toolkit/animation/adding-animation-to-a-control-cs
title: "Adding Animation to a Control (C#) | Microsoft Docs"
author: wenz
description: "The Animation control in the ASP.NET AJAX Control Toolkit is not just a control but a whole framework to add animations to a control. This tutorial shows how..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 06/02/2008
ms.topic: article
ms.assetid: 0f1fc1f5-9dbd-44e7-931e-387d42f0342b
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/ajax-control-toolkit/animation/adding-animation-to-a-control-cs
msc.type: authoredcontent
---
Adding Animation to a Control (C#)
====================
by [Christian Wenz](https://github.com/wenz)

[Download Code](http://download.microsoft.com/download/f/9/a/f9a26acd-8df4-4484-8a18-199e4598f411/Animation1.cs.zip) or [Download PDF](http://download.microsoft.com/download/6/7/1/6718d452-ff89-4d3f-a90e-c74ec2d636a3/animation1CS.pdf)

> The Animation control in the ASP.NET AJAX Control Toolkit is not just a control but a whole framework to add animations to a control. This tutorial shows how to set up such an animation.


## Overview

The Animation control in the ASP.NET AJAX Control Toolkit is not just a control but a whole framework to add animations to a control. This tutorial shows how to set up such an animation.

## Steps

The first step is as usual to include the `ScriptManager` in the page so that the ASP.NET AJAX library is loaded and the Control Toolkit can be used:

[!code-aspx[Main](adding-animation-to-a-control-cs/samples/sample1.aspx)]

The animation in this scenario will be applied to a panel of text which looks like this:

[!code-aspx[Main](adding-animation-to-a-control-cs/samples/sample2.aspx)]

The associated CSS class for the panel defines a background color and a width:

[!code-css[Main](adding-animation-to-a-control-cs/samples/sample3.css)]

Next up, we need the `AnimationExtender`. After providing an `ID` and the usual `runat="server"`, the `TargetControlID` attribute must be set to the control to animate in our case, the panel:

[!code-aspx[Main](adding-animation-to-a-control-cs/samples/sample4.aspx)]

The whole animation is applied declaratively, using an XML syntax, unfortunately currently not fully supported by Visual Studio's IntelliSense. The root node is `<Animations>;` within this node, several events are allowed which determine when the animation(s) take(s) place:

- `OnClick` (mouse click)
- `OnHoverOut` (when the mouse leaves a control)
- `OnHoverOver` (when the mouse hovers over a control, stopping the `OnHoverOut` animation)
- `OnLoad` (when the page has been loaded)
- `OnMouseOut` (when the mouse leaves a control)
- `OnMouseOver` (when the mouse hovers over a control, not stopping the `OnMouseOut` animation)

The framework comes with a set of animations, each one represented by its own XML element. Here is a selection:

- `<Color>` (changing a color)
- `<FadeIn>` (fading in)
- `<FadeOut>` (fading out)
- `<Property>` (changing a control's property)
- `<Pulse>` (pulsating)
- `<Resize>` (changing the size)
- `<Scale>` (proportionally changing the size)

In this example, the panel shall fade out. The animation shall take 1.5 seconds (`Duration` attribute), displaying 24 frames (animation steps) per second (`Fps` attributs). Here is the complete markup for the `AnimationExtender` control:

[!code-aspx[Main](adding-animation-to-a-control-cs/samples/sample5.aspx)]

When you run this script, the panel is displayed and fades out in one and a half seconds.


[![The panel is fading out](adding-animation-to-a-control-cs/_static/image2.png)](adding-animation-to-a-control-cs/_static/image1.png)

The panel is fading out ([Click to view full-size image](adding-animation-to-a-control-cs/_static/image3.png))

>[!div class="step-by-step"]
[Next](executing-several-animations-at-the-same-time-cs.md)