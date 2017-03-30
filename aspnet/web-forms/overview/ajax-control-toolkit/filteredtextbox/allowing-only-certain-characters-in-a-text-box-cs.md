---
uid: web-forms/overview/ajax-control-toolkit/filteredtextbox/allowing-only-certain-characters-in-a-text-box-cs
title: "Allowing Only Certain Characters in a Text Box (C#) | Microsoft Docs"
author: wenz
description: "ASP.NET validation controls can ensure that only certain characters are allowed in user input. However this still does not prevent users from typing invalid..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 06/02/2008
ms.topic: article
ms.assetid: fd2a1c52-d717-44af-8a61-67c8279bb26e
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/ajax-control-toolkit/filteredtextbox/allowing-only-certain-characters-in-a-text-box-cs
msc.type: authoredcontent
---
Allowing Only Certain Characters in a Text Box (C#)
====================
by [Christian Wenz](https://github.com/wenz)

[Download Code](http://download.microsoft.com/download/4/c/2/4c2def7a-0d23-4055-91f9-1f18504167d7/FilteredTextBox0.cs.zip) or [Download PDF](http://download.microsoft.com/download/b/6/a/b6ae89ee-df69-4c87-9bfb-ad1eb2b23373/filteredtextbox0CS.pdf)

> ASP.NET validation controls can ensure that only certain characters are allowed in user input. However this still does not prevent users from typing invalid characters and trying to submit the form.


## Overview

ASP.NET validation controls can ensure that only certain characters are allowed in user input. However this still does not prevent users from typing invalid characters and trying to submit the form.

## Steps

The ASP.NET AJAX Control Toolkit contains the `FilteredTextBox` control which extends a text box. Once activated, only a certain set of characters may be entered into the field.

For this to work, we first need as usual the ASP.NET AJAX `ScriptManager` which loads the JavaScript libraries which are also used by the ASP.NET AJAX Control Toolkit:

[!code-aspx[Main](allowing-only-certain-characters-in-a-text-box-cs/samples/sample1.aspx)]

Then, we need a text box:

[!code-aspx[Main](allowing-only-certain-characters-in-a-text-box-cs/samples/sample2.aspx)]

Finally, the `FilteredTextBoxExtender` control takes care of restricting the characters the user is allowed to type. First, set the `TargetControlID` attribute to the `ID` of the `TextBox` control. Then, choose one of the available `FilterType` values:

- `Custom` default; you have to provide a list of valid chars
- `LowercaseLetters` lowercase letters only
- `Numbers` digits only
- `UppercaseLetters` uppercase letters only

If the `Custom FilterType` is used, the `ValidChars` property must be set and provide a list of characters that may be typed. By the way: if you try to paste text into the text box, all invalid chars are removed.

Here is the markup for the `FilteredTextBoxExtender` control that only allows digits (something that would also have been possible with `FilterType="Numbers"`):

[!code-aspx[Main](allowing-only-certain-characters-in-a-text-box-cs/samples/sample3.aspx)]

Run the page and try to enter a letter if JavaScript is enabled, it will not work; digits however appear on the page. However note that the protection `FilteredTextBox` provides is not bullet-proof: If JavaScript is enabled, any data may be entered in the text box, so you have to use additional validation means, i.e. ASP.NET's validation controls.


[![Only digits may be entered](allowing-only-certain-characters-in-a-text-box-cs/_static/image2.png)](allowing-only-certain-characters-in-a-text-box-cs/_static/image1.png)

Only digits may be entered ([Click to view full-size image](allowing-only-certain-characters-in-a-text-box-cs/_static/image3.png))

>[!div class="step-by-step"]
[Next](allowing-only-certain-characters-in-a-text-box-vb.md)