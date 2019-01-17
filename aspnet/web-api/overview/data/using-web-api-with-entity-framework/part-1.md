---
uid: web-api/overview/data/using-web-api-with-entity-framework/part-1
title: "Using Web API 2 with Entity Framework 6 | Microsoft Docs"
author: MikeWasson
description: "This tutorial will teach you the basics of creating a web application with an ASP.NET Web API back end. The tutorial uses Entity Framework 6 for the data lay..."
ms.author: riande
ms.date: 01/17/2019
ms.assetid: e879487e-dbcd-4b33-b092-d67c37ae768c
msc.legacyurl: /web-api/overview/data/using-web-api-with-entity-framework/part-1
msc.type: authoredcontent
---
Using Web API 2 with Entity Framework 6
====================

[Download Completed Project](https://github.com/MikeWasson/BookService)

> This tutorial will teach you the basics of creating a web application with an ASP.NET Web API back end. The tutorial uses Entity Framework 6 for the data layer, and Knockout.js for the client-side JavaScript application. The tutorial also shows how to deploy the app to Azure App Service Web Apps.
>
> ## Software versions used in the tutorial
>
> - Web API 2.1
> - Visual Studio 2017 (download Visual Studio 2017 [here](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=button+cta&utm_content=download+vs2017))
> - Entity Framework 6
> - .NET 4.7
> - [Knockout.js](http://knockoutjs.com/) 3.1

This tutorial uses ASP.NET Web API 2 with Entity Framework 6 to create a web application that manipulates a back-end database. Here is a screen shot of the application that you will create.

[![](part-1/_static/image2.png)](part-1/_static/image1.png)

The app uses a single-page application (SPA) design. "Single-page application" is the general term for a web application that loads a single HTML page and then updates the page dynamically, instead of loading new pages. After the initial page load, the app talks with the server through AJAX requests. The AJAX requests return JSON data, which the app uses to update the UI.

AJAX isn't new, but today there are JavaScript frameworks that make it easier to build and maintain a large sophisticated SPA application. This tutorial uses [Knockout.js](http://knockoutjs.com/), but you can use any JavaScript client framework.

Here are the main building blocks for this app:

- ASP.NET MVC creates the HTML page.
- ASP.NET Web API handles the AJAX requests and returns JSON data.
- Knockout.js data-binds the HTML elements to the JSON data.
- Entity Framework talks to the database.

## See this app running on Azure

Would you like to see the finished site running as a live web app? You can deploy a complete version of the app to your Azure account by simply clicking the following button.

[![](http://azuredeploy.net/deploybutton.png)](https://azuredeploy.net/?WT.mc_id=deploy_azure_aspnet&repository=https://github.com/tfitzmac/BookService)

You need an Azure account to deploy this solution to Azure. If you do not already have an account, you have the following options:

- [Open an Azure account for free](https://azure.microsoft.com/pricing/free-trial/?WT.mc_id=A443DD604) - You get credits you can use to try out paid Azure services, and even after they're used up you can keep the account and use free Azure services.
- [Activate MSDN subscriber benefits](https://azure.microsoft.com/pricing/member-offers/msdn-benefits-details/?WT.mc_id=A443DD604) - Your MSDN subscription gives you credits every month that you can use for paid Azure services.

## Create the project

Open Visual Studio. From the **File** menu, select **New**, then select **Project**. (Or click **New Project** on the Start page.)

In the **New Project** dialog, click **Web** in the left pane and **ASP.NET Web Application (.NET Framework)** in the middle pane. Name the project **BookService** and click **OK**.

[![](part-1/_static/image11.png)](part-1/_static/image11.png)

In the **New ASP.NET Project** dialog, select the **Web API** template.

[![](part-1/_static/image12.png)](part-1/_static/image12.png)


Click **OK** to create the project.

## Configure Azure settings (optional)

After you create the project, you can choose to deploy to Azure App Service Web Apps at any time. 

1. In Solution Explorer, right-click on your project and select **Publish**.

2. In the window that appears, select **Start**. The **Pick a publish target** dialog box appears.

   [![](part-1/_static/image14.png)](part-1/_static/image14.png)

3. Select **Create Profile**. The **Create App Service** dialog box appears.

   [![](part-1/_static/image15.png)](part-1/_static/image15.png)

   Accept the defaults, or enter different values for the application name, resource group, hosting plan, Azure subscription, and geographical region. 

4. Select **Create a SQL database**. The **Configure SQL Server** dialog box appears. 

   [![](part-1/_static/image16.png)](part-1/_static/image16.png)

   Accept the defaults or enter different values. Enter an **Adminstrator Username** and **Administrator Password** for your new database. Select **OK** when you're done. You are retuned to the **Create App Service** page.

5. Click **Create** to create your profile. A message appears in the lower right indicating that deployment is in progress. After a short while, the **Publish** window reappears.

    [![](part-1/_static/image17.png)](part-1/_static/image17.png)
   
    The profile you created is now available to deploy the app. 


> [!div class="step-by-step"]
> [Next](part-2.md)
