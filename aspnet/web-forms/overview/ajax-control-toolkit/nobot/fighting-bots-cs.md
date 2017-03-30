---
uid: web-forms/overview/ajax-control-toolkit/nobot/fighting-bots-cs
title: "Fighting Bots (C#) | Microsoft Docs"
author: wenz
description: "Automated bots plaster weblogs and other websites with spam, submitting comment forms without any user interaction. The NoBot control in the ASP.NET AJAX Con..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 06/02/2008
ms.topic: article
ms.assetid: 0a1917e0-884a-4576-8e93-9ed660faae51
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/ajax-control-toolkit/nobot/fighting-bots-cs
msc.type: authoredcontent
---
Fighting Bots (C#)
====================
by [Christian Wenz](https://github.com/wenz)

[Download Code](http://download.microsoft.com/download/9/3/f/93f8daea-bebd-4821-833b-95205389c7d0/NoBot0.cs.zip) or [Download PDF](http://download.microsoft.com/download/b/6/a/b6ae89ee-df69-4c87-9bfb-ad1eb2b23373/nobot0CS.pdf)

> Automated bots plaster weblogs and other websites with spam, submitting comment forms without any user interaction. The NoBot control in the ASP.NET AJAX Control Toolkit can help fight those bots.


## Overview

Automated bots plaster weblogs and other websites with spam, submitting comment forms without any user interaction. The NoBot control in the ASP.NET AJAX Control Toolkit can help fight those bots.

## Steps

One common approach to defeat bots is to use CAPTCHAs Completely Automated Public Turing test to tell Computers and Humans Apart. A Turing test was originally a test where someone needed to decide whether a communication partner is a human or a machine. In the web, a CAPTCHA usually consists of an image with some distorted letters on it. The idea is that only a human can read the letters on the image, whereas OCR algorithms will fail.

There are several advantages and disadvantages to this approach, but a discussion of this is beyond the scope of this tutorial. There is however a control in the ASP.NET AJAX Control Toolkit which provides a similar approach: `NoBot`. It is easier to overcome than a CAPTCHA, but is very easy to use and fares extremely well on websites like blogs where it is considered a success if most spam attempts are defeated, which the `NoBot` control can do.

`NoBot` intercepts the postback of the current ASP.NET web form if at least one of these conditions is met:

- The browser fails to solve a JavaScript puzzle (for instance when JavaScript is deactivated)
- The user submitted the form to fast
- The client IP address submitted the form too often in a certain period of time.

In order to check for these conditions, the `NoBot` control requires these attributes (all of them optional):

- `ResponseMinimumDelaySeconds` minimum amount of seconds between postbacks
- `CutoffWindowSeconds` length of time interval in which postbacks from one IP are measures
- `CutoffMaximumInstances` maximum amount of seconds per time interval

The following markup demands that at least two seconds elapse between postbacks and that there are only five postbacks or less within a 30 seconds interval:

[!code-aspx[Main](fighting-bots-cs/samples/sample1.aspx)]

Then as usual make sure to include the `ScriptManager` in the page so that the ASP.NET AJAX library is loaded and the Control Toolkit can be used:

[!code-aspx[Main](fighting-bots-cs/samples/sample2.aspx)]

Since most of the checks `NoBot` is doing occur on the server side, you need to check the result of these validations. This can be done by calling `NoBot`'s `IsValid()` method. It has one argument (as an `out` parameter/`ByRef` parameter) which is of type `NoBotState`. Its string representation contains the reason when the check fails and `Valid` otherwise. The following code outputs a message according to `NoBot`'s result:

[!code-aspx[Main](fighting-bots-cs/samples/sample3.aspx)]

Finally, you need a form to submit and a label element to output the message, and you are done!

[!code-aspx[Main](fighting-bots-cs/samples/sample4.aspx)]

When you run this script and deactivate JavaScript or submit the form within the first two seconds or submit the form seven times within thirty seconds, you will get an error message. However use this control wisely, since only about 90-95% of users have JavaScript activated, therefore 5-10% of users will fail `NoBot`'s test.


[![This error message could have been caused by a bot](fighting-bots-cs/_static/image2.png)](fighting-bots-cs/_static/image1.png)

This error message could have been caused by a bot ([Click to view full-size image](fighting-bots-cs/_static/image3.png))

>[!div class="step-by-step"]
[Next](fighting-bots-vb.md)