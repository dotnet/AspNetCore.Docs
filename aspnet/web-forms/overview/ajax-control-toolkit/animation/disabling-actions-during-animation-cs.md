---
title: "Disabling Actions during Animation (C#) | Microsoft Docs"
author: wenz
description: "The Animation control in the ASP.NET AJAX Control Toolkit is not just a control but a whole framework to add animations to a control. It also supports action..."
ms.author: riande
manager: wpickett
ms.date: 06/02/2008
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/ajax-control-toolkit/animation/disabling-actions-during-animation-cs
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\web-forms\overview\ajax-control-toolkit\animation\disabling-actions-during-animation-cs.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/24788) | [View dev content](http://docs.aspdev.net/tutorials/web-forms/overview/ajax-control-toolkit/animation/disabling-actions-during-animation-cs.html) | [View prod content](http://www.asp.net/web-forms/overview/ajax-control-toolkit/animation/disabling-actions-during-animation-cs) | Picker: 33088

Disabling Actions during Animation (C#)
====================
by [Christian Wenz](https://github.com/wenz)

[Download Code](http://download.microsoft.com/download/f/9/a/f9a26acd-8df4-4484-8a18-199e4598f411/Animation7.cs.zip) or [Download PDF](http://download.microsoft.com/download/6/7/1/6718d452-ff89-4d3f-a90e-c74ec2d636a3/animation7CS.pdf)

> The Animation control in the ASP.NET AJAX Control Toolkit is not just a control but a whole framework to add animations to a control. It also supports actions, like mouse clicks. However when a mouse click starts an animation, it is desirable to disable mouse clicks during the animation.


## Overview

The Animation control in the ASP.NET AJAX Control Toolkit is not just a control but a whole framework to add animations to a control. It also supports actions, like mouse clicks. However when a mouse click starts an animation, it is desirable to disable mouse clicks during the animation.

## Steps

First of all, include the `ScriptManager` in the page; then, the ASP.NET AJAX library is loaded, making it possible to use the Control Toolkit:

    <asp:ScriptManager ID="asm" runat="server" />

The animation will be applied to an HTML button like this:

    <input type="button" ID="Button1" runat="server" Value="Launch Animation" />

Note that an HTML Control is used instead of a Web Control since we do not want the button to create a postback; it shall just launch the client-side animation for us.

Then, add the `AnimationExtender` to the page, providing an `ID`, the `TargetControlID` attribute and the obligatory `runat="server"`:

    <ajaxToolkit:AnimationExtender ID="ae" runat="server" TargetControlID="Button1">

Within the `<Animations>` node, `<OnClick>` is the right element to handle the mouse click. However, the button could be clicked during the animation, as well. The `<EnableAction>` element can take care of that. Setting `Enabled="false"` disables the button as part of the animation. Since we are using several individual animations (disabling the button and the actual animations), the `<Parallel>` element is required to glue the single animations together into one. Here is the complete markup for `AnimationExtender`:

    <ajaxToolkit:AnimationExtender ID="ae" runat="server" TargetControlID="Button1">
     <Animations>
     <OnClick>
     <Parallel>
     <EnableAction Enabled="false" />
     <FadeOut Duration="1.5" Fps="24" />
     <Resize Width="1000" Height="150" Unit="px" />
     </Parallel>
     </OnClick>
     </Animations>
    </ajaxToolkit:AnimationExtender>

It would also be possible to re-enable to button after the animation, using the following XML element at the end of the list:

    <EnableAction Enabled="true" />

However in the given scenario this would be useless since the button fades out and is not visible at the end of the animation.


[![The button is disabled as soon as the animation runs](disabling-actions-during-animation-cs/_static/image2.png)](disabling-actions-during-animation-cs/_static/image1.png)

The button is disabled as soon as the animation runs ([Click to view full-size image](disabling-actions-during-animation-cs/_static/image3.png))

>[!div class="step-by-step"] [Previous](animating-in-response-to-user-interaction-cs.md) [Next](triggering-an-animation-in-another-control-cs.md)