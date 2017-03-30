---
uid: web-api/overview/hosting-aspnet-web-api/use-owin-to-self-host-web-api
title: "Use OWIN to Self-Host ASP.NET Web API 2 | Microsoft Docs"
author: rick-anderson
description: "This tutorial shows how to host ASP.NET Web API in a console application, using OWIN to self-host the Web API framework. Open Web Interface for .NET (OWIN) d..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 07/09/2013
ms.topic: article
ms.assetid: a90a04ce-9d07-43ad-8250-8a92fb2bd3d5
ms.technology: dotnet-webapi
ms.prod: .net-framework
msc.legacyurl: /web-api/overview/hosting-aspnet-web-api/use-owin-to-self-host-web-api
msc.type: authoredcontent
---
Use OWIN to Self-Host ASP.NET Web API 2
====================
by [Kanchan Mehrotra](https://twitter.com/kanchanmeh)

> This tutorial shows how to host ASP.NET Web API in a console application, using OWIN to self-host the Web API framework.
> 
> [Open Web Interface for .NET](http://owin.org) (OWIN) defines an abstraction between .NET web servers and web applications. OWIN decouples the web application from the server, which makes OWIN ideal for self-hosting a web application in your own process, outside of IIS.
> 
> ## Software versions used in the tutorial
> 
> 
> - [Visual Studio 2013](https://www.microsoft.com/visualstudio/eng/2013-downloads) (also works with Visual Studio 2012)
> - Web API 2


> [!NOTE]
> You can find the complete source code for this tutorial at [aspnet.codeplex.com](https://aspnet.codeplex.com/SourceControl/latest#Samples/WebApi/OwinSelfhostSample/ReadMe.txt).


## Create a Console Application

On the **File** menu, click **New**, then click **Project**. From **Installed Templates**, under Visual C#, click **Windows** and then click **Console Application**. Name the project "OwinSelfhostSample" and click **OK**.

[![](use-owin-to-self-host-web-api/_static/image2.png)](use-owin-to-self-host-web-api/_static/image1.png)

## Add the Web API and OWIN Packages

From the **Tools** menu, click **Library Package Manager**, then click **Package Manager Console**. In the Package Manager Console window, enter the following command:

`Install-Package Microsoft.AspNet.WebApi.OwinSelfHost`

This will install the WebAPI OWIN selfhost package and all the required OWIN packages.

[![](use-owin-to-self-host-web-api/_static/image4.png)](use-owin-to-self-host-web-api/_static/image3.png)

## Configure Web API for Self-Host

In Solution Explorer, right click the project and select **Add** / **Class** to add a new class. Name the class `Startup`.

![](use-owin-to-self-host-web-api/_static/image5.png)

Replace all of the boilerplate code in this file with the following:

[!code-csharp[Main](use-owin-to-self-host-web-api/samples/sample1.cs)]

## Add a Web API Controller

Next, add a Web API controller class. In Solution Explorer, right click the project and select **Add** / **Class** to add a new class. Name the class `ValuesController`.

Replace all of the boilerplate code in this file with the following:

[!code-csharp[Main](use-owin-to-self-host-web-api/samples/sample2.cs)]

## Start the OWIN Host and Make a Request Using HttpClient

Replace all of the boilerplate code in the Program.cs file with the following:

[!code-csharp[Main](use-owin-to-self-host-web-api/samples/sample3.cs)]

## Running the Application

To run the application, press F5 in Visual Studio. The output should look like the following:

[!code-console[Main](use-owin-to-self-host-web-api/samples/sample4.cmd)]

![](use-owin-to-self-host-web-api/_static/image6.png)

## Additional Resources

[An Overview of Project Katana](../../../aspnet/overview/owin-and-katana/an-overview-of-project-katana.md)

[Host ASP.NET Web API in an Azure Worker Role](host-aspnet-web-api-in-an-azure-worker-role.md)