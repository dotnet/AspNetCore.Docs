---
uid: mvc/overview/getting-started/introduction/getting-started
title: "Getting Started with ASP.NET MVC 5 | Microsoft Docs"
author: Rick-Anderson
ms.author: riande
ms.date: 10/04/2018
ms.assetid: f3d8adbe-55e7-4fd4-84a8-7155bc45c676
msc.legacyurl: /mvc/overview/getting-started/introduction/getting-started
msc.type: authoredcontent
---
Getting started with ASP.NET MVC 5
====================
by [Rick Anderson]((https://twitter.com/RickAndMSFT))

[!INCLUDE [consider RP](../../../../includes/razor.md)]

This tutorial teaches you the basics of building an ASP.NET MVC 5 web app using [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=button+cta&utm_content=download+vs2017). The final source code for the tutorial is located on [GitHub](https://github.com/aspnet/Docs/tree/master/aspnet/mvc/overview/getting-started/introduction/sample/MvcMovie/MvcMovie).

This tutorial was written by [Scott Guthrie](https://weblogs.asp.net/scottgu/) (twitter[@scottgu](https://twitter.com/scottgu) ), [Scott Hanselman](http://www.hanselman.com/blog/) (twitter: [@shanselman](https://twitter.com/shanselman) ), and [Rick Anderson](https://twitter.com/RickAndMSFT) ( [@RickAndMSFT](https://twitter.com/#!/RickAndMSFT) )

You need an Azure account to deploy this app to Azure:

- You can [open an Azure account for free](https://azure.microsoft.com/pricing/free-trial/?WT.mc_id=A443DD604) - You get credits you can use to try out paid Azure services, and even after they're used up you can keep the account and use free Azure services.
- You can [activate MSDN subscriber benefits](https://azure.microsoft.com/pricing/member-offers/msdn-benefits-details/?WT.mc_id=A443DD604) - Your MSDN subscription gives you credits every month that you can use for paid Azure services.

## Get started

Start by [installing Visual Studio 2017](https://visualstudio.microsoft.com/downloads/?utm_medium=microsoft&utm_source=docs.microsoft.com&utm_campaign=button+cta&utm_content=download+vs2017). Then, open Visual Studio.

Visual Studio is an IDE, or integrated development environment. Just like you use Microsoft Word to write documents, you'll use an IDE to create applications. In Visual Studio, there's a list along the bottom showing various options available to you. There's also a menu that provides another way to perform tasks in the IDE. For example, instead of selecting **New Project** on the **Start page**, you can use the menu bar and select **File** > **New Project**.

![](getting-started/_static/image1.png)

## Create your first app

On the **Start page**, select **New Project**. In the **New project** dialog box, select the **Visual C#** category on the left, then **Web**, and then select the **ASP.NET Web Application (.NET Framework)** project template. Name your project "MvcMovie" and then choose **OK**.

![](getting-started/_static/image2.png)

In the **New ASP.NET Web Application** dialog, choose **MVC** and then choose **OK**.

![](getting-started/_static/image3.png)

Visual Studio used a default template for the ASP.NET MVC project you just created, so you have a working application right now without doing anything! This is a simple "Hello World!" project, and it's a good place to start your application.

![](getting-started/_static/image4.png)

Press **F5** to start debugging. When you press **F5**, Visual Studio starts [IIS Express](/iis/extensions/introduction-to-iis-express/iis-express-overview) and runs your web app. Visual Studio then launches a browser and opens the application's home page. Notice that the address bar of the browser says `localhost:port#` and not something like `example.com`. That's because `localhost` always points to your own local computer, which in this case is running the application you just built. When Visual Studio runs a web project, a random port is used for the web server. In the image below, the port number is 1234. When you run the application, you'll see a different port number.

![](getting-started/_static/image5.png)

Right out of the box this default template gives you `Home`, `Contact`, and `About` pages. The image below doesn't show the **Home**, **About**, and **Contact** links. Depending on the size of your browser window, you might need to click the navigation icon to see these links.

![](getting-started/_static/image6.png)

The application also provides support to register and log in. The next step is to change how this application works and learn a little bit about ASP.NET MVC. Close the ASP.NET MVC application and let's change some code.

For a list of current tutorials, see [MVC recommended articles](../mvc-learning-sequence.md).

## See this app running on Azure

Would you like to see the finished site running as a live web app? You can deploy a complete version of the app to your Azure account by simply clicking the following button.

[![](https://azuredeploy.net/deploybutton.png)](https://azuredeploy.net/?repository=https://github.com/aspnet/Docs/tree/master/aspnet/mvc/overview/getting-started/introduction/sample/MvcMovie&amp;WT.mc_id=deploy_azure_aspnet)

You need an Azure account to deploy this solution to Azure. If you don't already have an account, use one of the following options to create one:

- [Open an Azure account for free](https://azure.microsoft.com/pricing/free-trial/?WT.mc_id=A443DD604) - You get credits you can use to try out paid Azure services, and even after they're used up you can keep the account and use free Azure services.
- [Activate Visual Studio subscriber benefits](https://azure.microsoft.com/pricing/member-offers/credit-for-visual-studio-subscribers) - Your Visual Studio subscription gives you credits every month that you can use for paid Azure services.

> [!div class="step-by-step"]
> [Next](adding-a-controller.md)
