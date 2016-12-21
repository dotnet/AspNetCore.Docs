---
title: "Using the Slider Control With Auto-Postback (C#) | Microsoft Docs"
author: wenz
description: "The Slider control in the AJAX Control Toolkit provides a graphical slider that can be controlled using the mouse. It is possible to make the slider autopost..."
ms.author: riande
manager: wpickett
ms.date: 06/02/2008
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/ajax-control-toolkit/slider/using-the-slider-control-with-auto-postback-cs
---
Using the Slider Control With Auto-Postback (C#)
====================
by [Christian Wenz](https://github.com/wenz)

[Download Code](http://download.microsoft.com/download/9/3/f/93f8daea-bebd-4821-833b-95205389c7d0/Slider1.cs.zip) or [Download PDF](http://download.microsoft.com/download/b/6/a/b6ae89ee-df69-4c87-9bfb-ad1eb2b23373/slider1CS.pdf)

> The Slider control in the AJAX Control Toolkit provides a graphical slider that can be controlled using the mouse. It is possible to make the slider autopostback once its value changes.


## Overview

The Slider control in the AJAX Control Toolkit provides a graphical slider that can be controlled using the mouse. It is possible to make the slider autopostback once its value changes.

## Steps

In order to make the slider automatically postback upon a change, both text boxes need the attribute `AutoPostBack="true"`: The text box that will become the slider itself, and the text box that holds the slider's position. Here is the required markup for that:

[!code[Main](using-the-slider-control-with-auto-postback-cs/samples/sample1.xml)]

The `SliderExtender` control from the ASP.NET AJAX Control Toolkit assigns the slider functionality to the two text boxes:

[!code[Main](using-the-slider-control-with-auto-postback-cs/samples/sample2.xml)]

An additional label element will later be used to inform the user of a postback:

[!code[Main](using-the-slider-control-with-auto-postback-cs/samples/sample3.xml)]

Finally, the `ScriptManager` control of ASP.NET AJAX loads the required JavaScript for the Control Toolkit to work:

[!code[Main](using-the-slider-control-with-auto-postback-cs/samples/sample4.xml)]

Now the slider is posting back; on the server-side, this event may be caught and acted upon:

[!code[Main](using-the-slider-control-with-auto-postback-cs/samples/sample5.xml)]


[![Moving the slider triggers a postback](using-the-slider-control-with-auto-postback-cs/_static/image2.png)](using-the-slider-control-with-auto-postback-cs/_static/image1.png)

Moving the slider triggers a postback ([Click to view full-size image](using-the-slider-control-with-auto-postback-cs/_static/image3.png))


[![Afterwards, the date of this change is written in the label](using-the-slider-control-with-auto-postback-cs/_static/image5.png)](using-the-slider-control-with-auto-postback-cs/_static/image4.png)

Afterwards, the date of this change is written in the label ([Click to view full-size image](using-the-slider-control-with-auto-postback-cs/_static/image6.png))

>[!div class="step-by-step"]
[Next](databinding-the-slider-control-cs.md)