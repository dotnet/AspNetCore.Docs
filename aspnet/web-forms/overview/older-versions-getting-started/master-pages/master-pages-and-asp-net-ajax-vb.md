---
uid: web-forms/overview/older-versions-getting-started/master-pages/master-pages-and-asp-net-ajax-vb
title: "Master Pages and ASP.NET AJAX (VB) | Microsoft Docs"
author: rick-anderson
description: "Discusses options for using ASP.NET AJAX and master pages. Looks at using the ScriptManagerProxy class; discusses how the various JS files are loaded dependi..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 07/11/2008
ms.topic: article
ms.assetid: 0ee9318c-29bb-4d58-b1dc-94e575b8ae10
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/older-versions-getting-started/master-pages/master-pages-and-asp-net-ajax-vb
msc.type: authoredcontent
---
Master Pages and ASP.NET AJAX (VB)
====================
by [Scott Mitchell](https://twitter.com/ScottOnWriting)

[Download Code](http://download.microsoft.com/download/1/8/4/184e24fa-fcc8-47fa-ac99-4b6a52d41e97/ASPNET_MasterPages_Tutorial_08_VB.zip) or [Download PDF](http://download.microsoft.com/download/e/b/4/eb4abb10-c416-4ba4-9899-32577715b1bd/ASPNET_MasterPages_Tutorial_08_VB.pdf)

> Discusses options for using ASP.NET AJAX and master pages. Looks at using the ScriptManagerProxy class; discusses how the various JS files are loaded depending on whether the ScriptManager is used in the Master page or Content page.


## Introduction

Over the past several years, more and more developers have been building AJAX-enabled web applications. An AJAX-enabled website uses a number of related web technologies to offer a more responsive user experience. Creating AJAX-enabled ASP.NET applications is amazingly easy thanks to Microsoft's ASP.NET AJAX framework. ASP.NET AJAX is built into ASP.NET 3.5 and Visual Studio 2008; it is also available as a separate download for ASP.NET 2.0 applications.

When building AJAX-enabled web pages with the ASP.NET AJAX framework, you must add precisely one ScriptManager control to each and every page that uses the framework. As its name implies, the ScriptManager manages the client-side script used in AJAX-enabled web pages. At a minimum, the ScriptManager emits HTML that instructs the browser to download the JavaScript files that makeup the ASP.NET AJAX Client Library. It can also be used to register custom JavaScript files, script-enabled web services, and custom application service functionality.

If your site uses master pages (as it should), you do not necessarily need to add a ScriptManager control to every single content page; rather, you can add a ScriptManager control to the master page. This tutorial shows how to add the ScriptManager control to the master page. It also looks at how to use the ScriptManagerProxy control to register custom scripts and script services in a specific content page.

> [!NOTE]
> This tutorial does not explore designing or building AJAX-enabled web applications with the ASP.NET AJAX framework. For more information on using AJAX consult the ASP.NET AJAX videos and tutorials, as well as those resources listed in the Further Reading section at the end of this tutorial.


## Examining the Markup Emitted by the ScriptManager Control

The ScriptManager control emits markup that instructs the browser to download the JavaScript files that makeup the ASP.NET AJAX Client Library. It also adds a bit of inline JavaScript to the page that initializes this library. The following markup shows the content that is added to the rendered output of a page that includes a ScriptManager control:


[!code-html[Main](master-pages-and-asp-net-ajax-vb/samples/sample1.html)]

The `<script src="url"></script>` tags instruct the browser to download and execute the JavaScript file at *url*. The ScriptManager emits three such tags; one references the file `WebResource.axd`, while the other two reference the file `ScriptResource.axd`. These files do not actually exist as files in your website. Instead, when a request for either one of these files arrives at the web server, the ASP.NET engine examines the querystring and returns the appropriate JavaScript content. The script provided by these three external JavaScript files constitute the ASP.NET AJAX framework's Client Library. The other `<script>` tags emitted by the ScriptManager include inline script that initializes this library.

The external script references and inline script emitted by the ScriptManager are essential for a page that uses the ASP.NET AJAX framework, but is not needed for pages that do not use the framework. Therefore, you might reason that it is ideal to only add a ScriptManager to those pages that use the ASP.NET AJAX framework. And this is sufficient, but if you have many pages that use the framework you'll end up adding the ScriptManager control to all pages - a repetitive task, to say the least. Alternatively, you can add a ScriptManager to the master page, which then injects this necessary script into all content pages. With this approach, you do not need to remember to add a ScriptManager to a new page that uses the ASP.NET AJAX framework because it is already included by the master page. Step 1 walks through adding a ScriptManager to the master page.

> [!NOTE]
> If you plan on including AJAX functionality within the user interface of your master page, then you have no choice in the matter - you must include the ScriptManager in the master page.


One downside of adding the ScriptManager to the master page is that the above script is emitted in *every* page, regardless of whether its needed. This clearly leads to wasted bandwidth for those pages that have the ScriptManager included (via the master page) yet don't use any features of the ASP.NET AJAX framework. But just how much bandwidth is wasted?

- The actual content emitted by the ScriptManager (shown above) totals a little over 1KB.
- The three external script files referenced by the `<script>` element, however, comprise roughly 450KB of data uncompressed; in a website that uses gzip compression, this total bandwidth can be reduced near 100KB. However, these script files are cached by the browser for one year, meaning that they only need to be downloaded once and then can be reused in other pages on the site.

In the best case, then, when the script files are cached, the total cost is 1KB, which is negligible. In the worst case, however - which is when the script files have not yet been downloaded and the web server is not using any form of compression - the bandwidth hit is around 450KB, which can add anywhere from a second or two over a broadband connection to up to a minute for users over dial-up modems. The good news is that because the external script files are cached by the browser, this worst case scenario occurs infrequently.

> [!NOTE]
> If you still feel uncomfortable placing the ScriptManager control in the master page, consider the Web Form (the `<form runat="server">` markup in the master page). Every ASP.NET page that uses the postback model must include precisely one Web Form. Adding a Web Form adds additional content: a number of hidden form fields, the `<form>` tag itself, and, if necessary, a JavaScript function for initiating a postback from script. This markup is unnecessary for pages that don't postback. This extraneous markup could be eliminated by removing the Web Form from the master page and manually adding it to each content page that needs one. However, the benefits of having the Web Form in the master page outweigh the disadvantages from having it added unnecessarily to certain content pages.


## Step 1: Adding a ScriptManager Control to the Master Page

Every web page that uses the ASP.NET AJAX framework must contain precisely one ScriptManager control. Because of this requirement, it usually makes sense to place a single ScriptManager control on the master page so that all content pages have the ScriptManager control automatically included. Furthermore, the ScriptManager must come before any of the ASP.NET AJAX server controls, such as the UpdatePanel and UpdateProgress controls. Therefore, it's best to put the ScriptManager before any ContentPlaceHolder controls within the Web Form.

Open the `Site.master` master page and add a ScriptManager control to the page within the Web Form, but before the `<div id="topContent">` element (see Figure 1). If you are using Visual Web Developer 2008 or Visual Studio 2008, the ScriptManager control is located in the Toolbox in the AJAX Extensions tab. If you are using Visual Studio 2005, you will need to first install the ASP.NET AJAX framework and add the controls to the Toolbox. Visit the ASP.NET AJAX download page to get the framework for ASP.NET 2.0.

After adding the ScriptManager to the page, change its `ID` from `ScriptManager1` to `MyManager`.


[![Add the ScriptManager to the Master Page](master-pages-and-asp-net-ajax-vb/_static/image2.png)](master-pages-and-asp-net-ajax-vb/_static/image1.png)

**Figure 01**: Add the ScriptManager to the Master Page  ([Click to view full-size image](master-pages-and-asp-net-ajax-vb/_static/image3.png))


## Step 2: Using the ASP.NET AJAX Framework from a Content Page

With the ScriptManager control added to the master page we can now add ASP.NET AJAX framework functionality to any content page. Let's create a new ASP.NET page that displays a randomly selected product from the Northwind database. We'll use the ASP.NET AJAX framework's Timer control to update this display every 15 seconds, showing a new product.

Start by creating a new page in the root directory named `ShowRandomProduct.aspx`. Don't forget to bind this new page to the `Site.master` master page.


[![Add a New ASP.NET Page to the Website](master-pages-and-asp-net-ajax-vb/_static/image5.png)](master-pages-and-asp-net-ajax-vb/_static/image4.png)

**Figure 02**: Add a New ASP.NET Page to the Website ([Click to view full-size image](master-pages-and-asp-net-ajax-vb/_static/image6.png))


Recall that in the Specifying the Title, Meta Tags, and Other HTML Headers in the Master Page[SKM1] tutorial we created a custom base page class named `BasePage` that generated the page's title if it was not explicitly set. Go to the `ShowRandomProduct.aspx` page's code-behind class and have it derive from `BasePage` (instead of from `System.Web.UI.Page`).

Finally, update the `Web.sitemap` file to include an entry for this lesson. Add the following markup beneath the `<siteMapNode>` for the Master to Content Page Interaction lesson:


[!code-xml[Main](master-pages-and-asp-net-ajax-vb/samples/sample2.xml)]

The addition of this `<siteMapNode>` element is reflected in the Lessons list (see Figure 5).

### Displaying a Randomly Selected Product

Return to `ShowRandomProduct.aspx`. From the Designer, drag an UpdatePanel control from the Toolbox into the `MainContent` Content control and set its `ID` property to `ProductPanel`. The UpdatePanel represents a region on the screen that can be asynchronously updated through a partial page postback.

Our first task is to display information about a randomly selected product within the UpdatePanel. Start by dragging a DetailsView control into the UpdatePanel. Set the DetailsView control's `ID` property to `ProductInfo` and clear out its `Height` and `Width` properties. Expand the DetailsView's smart tag and, from the Choose Data Source drop-down list, choose to bind the DetailsView to a new SqlDataSource control named `RandomProductDataSource`.


[![Bind the DetailsView to a New SqlDataSource Control](master-pages-and-asp-net-ajax-vb/_static/image8.png)](master-pages-and-asp-net-ajax-vb/_static/image7.png)

**Figure 03**: Bind the DetailsView to a New SqlDataSource Control  ([Click to view full-size image](master-pages-and-asp-net-ajax-vb/_static/image9.png))


Configure the SqlDataSource control to connect to the Northwind database via the `NorthwindConnectionString` (which we created in the Interacting with the Master Page from the Content Page[SKM2] tutorial). When configuring the select statement choose to specify a custom SQL statement and then enter the following query:


[!code-sql[Main](master-pages-and-asp-net-ajax-vb/samples/sample3.sql)]

The `TOP 1` keyword in the `SELECT` clause returns only the first record returned by the query. The `NEWID()` function generates a new globally unique identifier value (GUID) and can be used in an `ORDER BY` clause to return the table's records in a random order.


[![Configure the SqlDataSource to Return a Single, Randomly Selected Record](master-pages-and-asp-net-ajax-vb/_static/image11.png)](master-pages-and-asp-net-ajax-vb/_static/image10.png)

**Figure 04**: Configure the SqlDataSource to Return a Single, Randomly Selected Record  ([Click to view full-size image](master-pages-and-asp-net-ajax-vb/_static/image12.png))


After completing the wizard, Visual Studio creates a BoundField for the two columns returned by the above query. At this point your page's declarative markup should look similar to the following:


[!code-aspx[Main](master-pages-and-asp-net-ajax-vb/samples/sample4.aspx)]

Figure 5 shows the `ShowRandomProduct.aspx` page when viewed through a browser. Click your browser's Refresh button to reload the page; you should see the `ProductName` and `UnitPrice` values for a new randomly selected record.


[![A Random Product's Name and Price is Displayed](master-pages-and-asp-net-ajax-vb/_static/image14.png)](master-pages-and-asp-net-ajax-vb/_static/image13.png)

**Figure 05**: A Random Product's Name and Price is Displayed  ([Click to view full-size image](master-pages-and-asp-net-ajax-vb/_static/image15.png))


### Automatically Displaying a New Product Every 15 Seconds

The ASP.NET AJAX framework includes a Timer control that performs a postback at a specified time; on postback the Timer's `Tick` event is raised. If the Timer control is placed within an UpdatePanel it triggers a partial page postback, during which we can rebind the data to the DetailsView to display a new randomly selected product.

To accomplish this, drag a Timer from the Toolbox and drop it into the UpdatePanel. Change the Timer's `ID` from `Timer1` to `ProductTimer` and its `Interval` property from 60000 to 15000. The `Interval` property indicates the number of milliseconds between postbacks; setting it to 15000 causes the Timer to trigger a partial page postback every 15 seconds. At this point your Timer's declarative markup should look similar to the following:


[!code-aspx[Main](master-pages-and-asp-net-ajax-vb/samples/sample5.aspx)]

Create an event handler for the Timer's `Tick` event. In this event handler we need to rebind the data to the DetailsView by calling the DetailsView's `DataBind` method. Doing so instructs the DetailsView to re-retrieve the data from its data source control, which will select and display a new randomly selected record (just like when reloading the page by clicking the browser's Refresh button).


[!code-vb[Main](master-pages-and-asp-net-ajax-vb/samples/sample6.vb)]

That's all there is to it! Revisit the page through a browser. Initially, a random product's information is displayed. If you patiently watch the screen you'll notice that, after 15 seconds, information about a new product magically replaces the existing display.

To better see what's happening here, let's add a Label control to the UpdatePanel that displays the time the display was last updated. Add a Label Web control within the UpdatePanel, set its `ID` to `LastUpdateTime`, and clear its `Text` property. Next, create an event handler for the UpdatePanel's `Load` event and display the current time in the Label. (The UpdatePanel's `Load` event is fired on every full or partial page postback.)


[!code-vb[Main](master-pages-and-asp-net-ajax-vb/samples/sample7.vb)]

With this change complete, the page includes the time the currently displayed product was loaded. Figure 6 shows the page when first visited. Figure 7 shows the page 15 seconds later after the Timer control has "ticked" and the UpdatePanel has been refreshed to display information about a new product.


[![A Randomly Selected Product is Displayed on Page Load](master-pages-and-asp-net-ajax-vb/_static/image17.png)](master-pages-and-asp-net-ajax-vb/_static/image16.png)

**Figure 06**: A Randomly Selected Product is Displayed on Page Load  ([Click to view full-size image](master-pages-and-asp-net-ajax-vb/_static/image18.png))


[![Every 15 Seconds a New Randomly Selected Product is Displayed](master-pages-and-asp-net-ajax-vb/_static/image20.png)](master-pages-and-asp-net-ajax-vb/_static/image19.png)

**Figure 07**: Every 15 Seconds a New Randomly Selected Product is Displayed  ([Click to view full-size image](master-pages-and-asp-net-ajax-vb/_static/image21.png))


## Step 3: Using the ScriptManagerProxy Control

Along with including the necessary script for the ASP.NET AJAX framework Client Library, the ScriptManager can also register custom JavaScript files, references to script-enabled Web Services, and custom authentication, authorization, and profile services. Usually such customizations are specific to a certain page. However, if the custom script files, Web Service references, or authentication, authorization, or profile services are referenced in the ScriptManager in the master page then they are included in all pages in the website.

To add ScriptManager-related customizations on a page-by-page basis use the ScriptManagerProxy control. You can add a ScriptManagerProxy to a content page and then register the custom JavaScript file, Web Service reference, or authentication, authorization, or profile service from the ScriptManagerProxy; this has the effect of registering these services for the particular content page.

> [!NOTE]
> An ASP.NET page can only have no more than one ScriptManager control present. Therefore, you cannot add a ScriptManager control to a content page if the ScriptManager control is already defined in the master page. The sole purpose of the ScriptManagerProxy is to provide a way for developers to define the ScriptManager in the master page, but still have the ability to add ScriptManager customizations on a page-by-page basis.


To see the ScriptManagerProxy control in action, let's augment the UpdatePanel in `ShowRandomProduct.aspx` to include a button that uses client-side script to pause or resume the Timer control. The Timer control has three client-side methods that we can use to achieve this desired functionality:

- `_startTimer()` - starts the Timer control
- `_raiseTick()` - causes the Timer control to "tick," thereby posting back and raising its Tick event on the server
- `_stopTimer()` - stops the Timer control

Let's create a JavaScript file with a variable named `timerEnabled` and a function named `ToggleTimer`. The `timerEnabled` variable indicates whether the Timer control is currently enabled or disabled; it defaults to true. The `ToggleTimer` function accepts two input parameters: a reference to the Pause/Resume button and the client-side `id` value of the Timer control. This function toggles the value of `timerEnabled`, gets a reference to the Timer control, starts or stops the Timer (depending on the value of `timerEnabled`), and updates the button's display text to "Pause" or "Resume". This function will be called whenever the Pause/Resume button is clicked.

Start by creating a new folder in the website named `Scripts`. Next, add a new file to the Scripts folder named `TimerScript.js` of type JScript File.


[![Add a New JavaScript File to the Scripts Folder](master-pages-and-asp-net-ajax-vb/_static/image23.png)](master-pages-and-asp-net-ajax-vb/_static/image22.png)

**Figure 08**: Add a New JavaScript File to the `Scripts` Folder  ([Click to view full-size image](master-pages-and-asp-net-ajax-vb/_static/image24.png))


[![A New JavaScript File has been Added to the Website](master-pages-and-asp-net-ajax-vb/_static/image26.png)](master-pages-and-asp-net-ajax-vb/_static/image25.png)

**Figure 09**: A New JavaScript File has been Added to the Website ([Click to view full-size image](master-pages-and-asp-net-ajax-vb/_static/image27.png))


Next, add the following scrip to the `TimerScript.js` file:


[!code-csharp[Main](master-pages-and-asp-net-ajax-vb/samples/sample8.cs)]

We now need to register this custom JavaScript file in `ShowRandomProduct.aspx`. Return to `ShowRandomProduct.aspx` and add a ScriptManagerProxy control to the page; set its `ID` to `MyManagerProxy`. To register a custom JavaScript file select the ScriptManagerProxy control in the Designer and then go to the Properties window. One of the properties is titled Scripts. Selecting this property displays the ScriptReference Collection Editor shown in Figure 10. Click the Add button to include a new script reference and then enter the path to the script file in the Path property: `~/Scripts/TimerScript.js`.


[![Add a Script Reference to the ScriptManagerProxy Control](master-pages-and-asp-net-ajax-vb/_static/image29.png)](master-pages-and-asp-net-ajax-vb/_static/image28.png)

**Figure 10**: Add a Script Reference to the ScriptManagerProxy Control ([Click to view full-size image](master-pages-and-asp-net-ajax-vb/_static/image30.png))


After adding the script reference the ScriptManagerProxy control's declarative markup is updated to include a `<Scripts>` collection with a single `ScriptReference` entry, as the following snippet of markup illustrates:


[!code-aspx[Main](master-pages-and-asp-net-ajax-vb/samples/sample9.aspx)]

The `ScriptReference` entry instructs the ScriptManagerProxy to include a reference to the JavaScript file in its rendered markup. That is, by registering the custom script in the ScriptManagerProxy the `ShowRandomProduct.aspx` page's rendered output now includes another `<script src="url"></script>` tag: `<script src="Scripts/TimerScript.js" type="text/javascript"></script>`.

We can now call the `ToggleTimer` function defined in `TimerScript.js` from the client script in the `ShowRandomProduct.aspx` page. Add the following HTML within the UpdatePanel:


[!code-aspx[Main](master-pages-and-asp-net-ajax-vb/samples/sample10.aspx)]

This displays a button with the text "Pause". Whenever it is clicked, the JavaScript function `ToggleTimer` is called, passing in a reference to the button and the `id` value of the Timer control (`ProductTimer`). Note the syntax for obtaining the `id` value of the Timer control. `<%=ProductTimer.ClientID%>` emits the value of the `ProductTimer` Timer control's `ClientID` property. In the Control ID Naming in Content Pages[SKM3] tutorial we discussed the differences between the server-side `ID` value and the resulting client-side `id` value, and how `ClientID` returns the client-side `id`.

Figure 11 shows this page when first visited through a browser. The Timer is currently running and updates the displayed product information every 15 seconds. Figure 12 shows the screen after the Pause button has been clicked. Clicking the Pause button stops the Timer and updates the button's text to "Resume". The product information will refresh (and continue to refresh every 15 seconds) once the user clicks Resume.


[![Click the Pause Button to Stop the Timer Control](master-pages-and-asp-net-ajax-vb/_static/image32.png)](master-pages-and-asp-net-ajax-vb/_static/image31.png)

**Figure 11**: Click the Pause Button to Stop the Timer Control  ([Click to view full-size image](master-pages-and-asp-net-ajax-vb/_static/image33.png))


[![Click the Resume Button to Restart the Timer](master-pages-and-asp-net-ajax-vb/_static/image35.png)](master-pages-and-asp-net-ajax-vb/_static/image34.png)

**Figure 12**: Click the Resume Button to Restart the Timer  ([Click to view full-size image](master-pages-and-asp-net-ajax-vb/_static/image36.png))


## Summary

When building AJAX-enabled web applications using the ASP.NET AJAX framework it is imperative that every AJAX-enabled web page include a ScriptManager control. To facilitate this process, we can add a ScriptManager to the master page rather than having to remember to add a ScriptManager to each and every content page. Step 1 showed how to add the ScriptManager to the master page while Step 2 looked at implementing AJAX functionality in a content page.

If you need to add custom scripts, references to script-enabled Web Services, or customized authentication, authorization, or profile services to a particular content page, add a ScriptManagerProxy control to the content page and then configure the customizations there. Step 3 examined how to use the ScriptManagerProxy to register a custom JavaScript file in a specific content page.

Happy Programming!

### Further Reading

For more information on the topics discussed in this tutorial, refer to the following resources:

- [ASP.NET AJAX Framework](../../../../ajax/index.md)
- [ASP.NET AJAX Tutorials](../aspnet-ajax/understanding-partial-page-updates-with-asp-net-ajax.md)
- [ASP.NET AJAX Videos](../../../videos/aspnet-ajax/index.md)
- [Building Interactive User Interface with Microsoft ASP.NET AJAX](http://aspnet.4guysfromrolla.com/articles/101007-1.aspx)
- [Using NEWID to Randomly Sort Records](http://www.sqlteam.com/article/using-newid-to-randomly-sort-records)
- [Using the Timer Control](http://aspnet.4guysfromrolla.com/articles/061808-1.aspx)

### About the Author

[Scott Mitchell](http://www.4guysfromrolla.com/ScottMitchell.shtml), author of multiple ASP/ASP.NET books and founder of 4GuysFromRolla.com, has been working with Microsoft Web technologies since 1998. Scott works as an independent consultant, trainer, and writer. His latest book is [*Sams Teach Yourself ASP.NET 3.5 in 24 Hours*](https://www.amazon.com/exec/obidos/ASIN/0672329972/4guysfromrollaco). Scott can be reached at [mitchell@4GuysFromRolla.com](mailto:mitchell@4GuysFromRolla.com) or via his blog at [http://ScottOnWriting.NET](http://scottonwriting.net/).

### Special Thanks To

This tutorial series was reviewed by many helpful reviewers. Interested in reviewing my upcoming MSDN articles? If so, drop me a line at [mitchell@4GuysFromRolla.com](mailto:mitchell@4GuysFromRolla.com)

>[!div class="step-by-step"]
[Previous](interacting-with-the-content-page-from-the-master-page-vb.md)
[Next](specifying-the-master-page-programmatically-vb.md)