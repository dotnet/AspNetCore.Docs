---
title: "Executing Several Animations after Each Other (C#) | Microsoft Docs"
author: wenz
description: "The Animation control in the ASP.NET AJAX Control Toolkit is not just a control but a whole framework to add animations to a control. It allows to run severa..."
ms.author: riande
manager: wpickett
ms.date: 06/02/2008
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/ajax-control-toolkit/animation/executing-several-animations-after-each-other-cs
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\web-forms\overview\ajax-control-toolkit\animation\executing-several-animations-after-each-other-cs.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/24780) | [View dev content](http://docs.aspdev.net/tutorials/web-forms/overview/ajax-control-toolkit/animation/executing-several-animations-after-each-other-cs.html) | [View prod content](http://www.asp.net/web-forms/overview/ajax-control-toolkit/animation/executing-several-animations-after-each-other-cs) | Picker: 33080

Executing Several Animations after Each Other (C#)
====================
by [Christian Wenz](https://github.com/wenz)

[Download Code](http://download.microsoft.com/download/f/9/a/f9a26acd-8df4-4484-8a18-199e4598f411/Animation3.cs.zip) or [Download PDF](http://download.microsoft.com/download/6/7/1/6718d452-ff89-4d3f-a90e-c74ec2d636a3/animation3CS.pdf)

> The Animation control in the ASP.NET AJAX Control Toolkit is not just a control but a whole framework to add animations to a control. It allows to run several animations one after the other.


The Animation control in the ASP.NET AJAX Control Toolkit is not just a control but a whole framework to add animations to a control. It allows to run several animations one after the other.

## Steps

First of all, include the `ScriptManager` in the page; then, the ASP.NET AJAX library is loaded, making it possible to use the Control Toolkit:

    <asp:ScriptManager ID="asm" runat="server" />

The animation will be applied to a panel of text which looks like this:

    <asp:Panel ID="panelShadow" runat="server" CssClass="panelClass">
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

In the associated CSS class for the panel, define a nice background color and also set a fixed width for the panel:

    <style type="text/css">
     .panelClass {background-color: lime; width: 300px;}
    </style>

Then, add the `AnimationExtender` to the page, providing an `ID`, the `TargetControlID` attribute and the obligatory `runat="server":`

    <ajaxToolkit:AnimationExtender ID="ae" runat="server" TargetControlID="Panel1">

Within the `<Animations>` node, use `<OnLoad>` to run the animations once the page has been fully loaded. Generally, `<OnLoad>` only accepts one animation. The Animation framework allows you to join several animations into one using the `<Sequence>` element. All animations within `<Sequence>` are executed one after the other. Here is the a possible markup for the `AnimationExtender` control, first making the panel wider and then decreasing its height:

    <ajaxToolkit:AnimationExtender ID="ae" runat="server" TargetControlID="Panel1">
     <Animations>
     <OnLoad>
     <Sequence>
     <Resize Width="1000" Unit="px" />
     <Resize Height="150" Unit="px" />
     </Sequence>
     </OnLoad>
     </Animations>
    </ajaxToolkit:AnimationExtender>

When you run this script, the panel first gets wider and then smaller.


[![First the width is increased](executing-several-animations-after-each-other-cs/_static/image2.png)](executing-several-animations-after-each-other-cs/_static/image1.png)

First the width is increased ([Click to view full-size image](executing-several-animations-after-each-other-cs/_static/image3.png))


[![Then the height is decreased](executing-several-animations-after-each-other-cs/_static/image5.png)](executing-several-animations-after-each-other-cs/_static/image4.png)

Then the height is decreased ([Click to view full-size image](executing-several-animations-after-each-other-cs/_static/image6.png))

>[!div class="step-by-step"] [Previous](executing-several-animations-at-the-same-time-cs.md) [Next](animation-depending-on-a-condition-cs.md)