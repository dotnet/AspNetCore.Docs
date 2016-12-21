---
title: "Launching a Modal Popup Window from Server Code (C#) | Microsoft Docs"
author: wenz
description: "The ModalPopup control in the AJAX Control Toolkit offers a simple way to create a modal popup using client-side means. However some scenarios require that t..."
ms.author: riande
manager: wpickett
ms.date: 06/02/2008
ms.topic: article
ms.assetid: 
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/ajax-control-toolkit/modalpopup/launching-a-modal-popup-window-from-server-code-cs
---
Launching a Modal Popup Window from Server Code (C#)
====================
by [Christian Wenz](https://github.com/wenz)

[Download Code](http://download.microsoft.com/download/2/4/0/24052038-f942-4336-905b-b60ae56f0dd5/ModalPopup1.cs.zip) or [Download PDF](http://download.microsoft.com/download/b/6/a/b6ae89ee-df69-4c87-9bfb-ad1eb2b23373/modalpopup1CS.pdf)

> The ModalPopup control in the AJAX Control Toolkit offers a simple way to create a modal popup using client-side means. However some scenarios require that the opening of the modal popup is triggered on the server-side.


## Overview

The ModalPopup control in the AJAX Control Toolkit offers a simple way to create a modal popup using client-side means. However some scenarios require that the opening of the modal popup is triggered on the server-side.

## Steps

First of all, an ASP.NET Button web control is required to demonstrate how the ModalPopup control works. Add such a button within the &lt;form&gt; element on a new page:

[!code[Main](launching-a-modal-popup-window-from-server-code-cs/samples/sample1.xml)]

Then, you need the markup for the popup you want to create. Define it as an `<asp:Panel>` control and make sure that it includes a Button control. The ModalPopup control offers the functionality to make such a button close the popup; otherwise there is no easy way to let it vanish.

[!code[Main](launching-a-modal-popup-window-from-server-code-cs/samples/sample2.xml)]

Next add the ModalPopup control from the ASP.NET AJAX Toolkit to the page. Set properties for the button which loads the control, the button which makes it disappear, and the ID of the actual popup.

[!code[Main](launching-a-modal-popup-window-from-server-code-cs/samples/sample3.xml)]

As with all web pages based on ASP.NET AJAX; the Script Manager is required to load the necessary JavaScript libraries for the different target browsers:

[!code[Main](launching-a-modal-popup-window-from-server-code-cs/samples/sample4.xml)]

Run the example in the browser. When you click on the button, the modal popup appears. In order to achieve the same effect using server-side code, a new button is required:

[!code[Main](launching-a-modal-popup-window-from-server-code-cs/samples/sample5.xml)]

As you can see, a click on the button generates a postback and executes the `ServerButton_Click()` method on the server. In this method, a JavaScript function called `launchModal()` is executed to be exact, the JavaScript function will be executed once the page has been loaded:

[!code[Main](launching-a-modal-popup-window-from-server-code-cs/samples/sample6.xml)]

The job of `launchModal()` is to display the ModalPopup. The `launchModal()` function is executed once the complete HTML page has been loaded. At that moment, however, the ASP.NET AJAX framework has not been fully loaded yet. Therefore, the `launchModal()` function just sets a variable that the ModalPopup control must be shown later on:

[!code[Main](launching-a-modal-popup-window-from-server-code-cs/samples/sample7.xml)]

The `pageLoad()` JavaScript function is a special function that gets executed once ASP.NET AJAX has been fully loaded. Therefore we add code to this function to show the ModalPopup control, but only if `launchModal()` has been called before:

[!code[Main](launching-a-modal-popup-window-from-server-code-cs/samples/sample8.xml)]

The `$find()` function is looking for a named element on the page and expects the server-side ID as a parameter. Therefore, `$find("mpe")` returns the client representation of the ModalPopup control; its `show()` method lets the popup appear.


[![The modal popup appears when either of the buttons is clicked](launching-a-modal-popup-window-from-server-code-cs/_static/image2.png)](launching-a-modal-popup-window-from-server-code-cs/_static/image1.png)

The modal popup appears when either of the buttons is clicked ([Click to view full-size image](launching-a-modal-popup-window-from-server-code-cs/_static/image3.png))

>[!div class="step-by-step"] [Next](using-modalpopup-with-a-repeater-control-cs.md)