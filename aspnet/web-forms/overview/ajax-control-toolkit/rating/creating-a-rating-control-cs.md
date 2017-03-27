---
uid: web-forms/overview/ajax-control-toolkit/rating/creating-a-rating-control-cs
title: "Creating a Rating Control (C#) | Microsoft Docs"
author: wenz
description: "Many websites, from e-commerce to community sites, offer their users to rate articles or items. This usually requires some coding effort, but we do have the..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 06/02/2008
ms.topic: article
ms.assetid: 969fb28f-2bff-4fc4-b24a-27f5e2534a37
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/ajax-control-toolkit/rating/creating-a-rating-control-cs
msc.type: authoredcontent
---
Creating a Rating Control (C#)
====================
by [Christian Wenz](https://github.com/wenz)

[Download Code](http://download.microsoft.com/download/9/3/f/93f8daea-bebd-4821-833b-95205389c7d0/rating0.cs.zip) or [Download PDF](http://download.microsoft.com/download/2/d/c/2dc10e34-6983-41d4-9c08-f78f5387d32b/rating0CS.pdf)

> Many websites, from e-commerce to community sites, offer their users to rate articles or items. This usually requires some coding effort, but we do have the Control Toolkit to our disposal.


## Overview

Many websites, from e-commerce to community sites, offer their users to rate articles or items. This usually requires some coding effort, but we do have the Control Toolkit to our disposal.

## Steps

First of all, you need (at least) two kinds of images: one for a filled out rating item, and one for an empty rating item. A rating item is usually a star or a smiley. For this scenario, you find three files, smiley.png and empty.png and smiley-done.png as part of the source code downloads for this tutorial.

Then, create a new ASP.NET file and start with adding a `ScriptManager` control to it:

[!code-aspx[Main](creating-a-rating-control-cs/samples/sample1.aspx)]

Then, add the `Rating` control from the ASP.NET AJAX Control Toolkit. The following attributes need to be set for this example:

- `CurrentRating` the initial rating to be used
- `MaxRating` the maximum rating
- `EmptyStarCssClass` the CSS class to use when a rating item ( star ) is empty
- `FilledStarCssClass` the CSS class to use when a rating item ( star ) is filled out
- `StarCssClass` the CSS class to use for a visible stat
- `WaitingStarCssClass` the CSS class to use while a star rating is sent back to the server

And here is the markup which creates a rating control with five items (smileys) of which none is filled out initially:

[!code-aspx[Main](creating-a-rating-control-cs/samples/sample2.aspx)]

The three referenced CSS classes now need to show the appropriate image files, which is easy to do using CSS:

[!code-css[Main](creating-a-rating-control-cs/samples/sample3.css)]

Make sure that you provide the width and height of the three images, otherwise the display may look a bit messed up.

Finally, the result of the rating should be displayed to the user (or, at least saved in a database). So add a label for the output of a text message and a submit button to post back the rating form to the server:

[!code-aspx[Main](creating-a-rating-control-cs/samples/sample4.aspx)]

In the server-side code, access the Rating control via its `ID` and then access its `CurrentRating` property which is the number of the selected rating items, in our example a value between 0 and 5.

[!code-aspx[Main](creating-a-rating-control-cs/samples/sample5.aspx)]

Save the page and load it into your browser. When you hover over the (initially empty) rating items, a JavaScript effect occurs: The rating changes. When you click on the set of stars, the current rating is retained. Finally, when you submit the form, the server-side code outputs the selected rating.


[![Creating a rating system with minimal code](creating-a-rating-control-cs/_static/image2.png)](creating-a-rating-control-cs/_static/image1.png)

Creating a rating system with minimal code ([Click to view full-size image](creating-a-rating-control-cs/_static/image3.png))

>[!div class="step-by-step"]
[Next](creating-a-rating-control-vb.md)