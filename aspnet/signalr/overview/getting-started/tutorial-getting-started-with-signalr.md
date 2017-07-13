---
uid: signalr/overview/getting-started/tutorial-getting-started-with-signalr
title: "Tutorial: Getting Started with SignalR 2 | Microsoft Docs"
author: pfletcher
description: "This tutorial shows how to use SignalR to create a real-time chat application. You will add SignalR to an empty ASP.NET web application and create an HTML pa..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 06/10/2014
ms.topic: article
ms.assetid: a8b3b778-f009-4369-85c7-e90f9878d8b4
ms.technology: dotnet-signalr
ms.prod: .net-framework
msc.legacyurl: /signalr/overview/getting-started/tutorial-getting-started-with-signalr
msc.type: authoredcontent
---
Tutorial: Getting Started with SignalR 2
====================
by [Patrick Fletcher](https://github.com/pfletcher)

[Download Completed Project](http://code.msdn.microsoft.com/SignalR-Getting-Started-b9d18aa9)

> This tutorial shows how to use SignalR to create a real-time chat application. You will add SignalR to an empty ASP.NET web application and create an HTML page to send and display messages. 
> 
> ## Software versions used in the tutorial
> 
> 
> - [Visual Studio 2013](https://www.microsoft.com/visualstudio/eng/2013-downloads)
> - .NET 4.5
> - SignalR version 2
>   
> 
> 
> ## Using Visual Studio 2012 with this tutorial
> 
> 
> To use Visual Studio 2012 with this tutorial, do the following:
> 
> - Update your [Package Manager](http://docs.nuget.org/docs/start-here/installing-nuget) to the latest version.
> - Install the [Web Platform Installer](https://www.microsoft.com/web/downloads/platform.aspx).
> - In the Web Platform Installer, search for and install **ASP.NET and Web Tools 2013.1 for Visual Studio 2012**. This will install Visual Studio templates for SignalR classes such as **Hub**.
> - Some templates (such as **OWIN Startup Class**) will not be available; for these, use a Class file instead.
> 
> 
> ## Tutorial versions
> 
> For information about earlier versions of SignalR, see [SignalR Older Versions](../older-versions/index.md).
> 
> ## Questions and comments
> 
> Please leave feedback on how you liked this tutorial and what we could improve in the comments at the bottom of the page. If you have questions that are not directly related to the tutorial, you can post them to the [ASP.NET SignalR forum](https://forums.asp.net/1254.aspx/1?ASP+NET+SignalR) or [StackOverflow.com](http://stackoverflow.com/).


## Overview

This tutorial introduces SignalR development by showing how to build a simple browser-based chat application. You will add the SignalR library to an empty ASP.NET web application, create a hub class for sending messages to clients, and create an HTML page that lets users send and receive chat messages. For a similar tutorial that shows how to create a chat application in MVC 5 using an MVC view, see [Getting Started with SignalR 2 and MVC 5](tutorial-getting-started-with-signalr-and-mvc.md).

> [!NOTE]
> This tutorial demonstrates how to create SignalR applications in version 2. For details on changes between SignalR 1.x and 2, see [Upgrading SignalR 1.x Projects](../releases/upgrading-signalr-1x-projects-to-20.md) and [Visual Studio 2013 Release Notes](../../../visual-studio/overview/2013/release-notes.md#TOC13).

SignalR is an open-source .NET library for building web applications that require live user interaction or real-time data updates. Examples include social applications, multiuser games, business collaboration, and news, weather, or financial update applications. These are often called real-time applications.

SignalR simplifies the process of building real-time applications. It includes an ASP.NET server library and a JavaScript client library to make it easier to manage client-server connections and push content updates to clients. You can add the SignalR library to an existing ASP.NET application to gain real-time functionality.

The tutorial demonstrates the following SignalR development tasks:

- Adding the SignalR library to an ASP.NET web application.
- Creating a hub class to push content to clients.
- Creating an OWIN startup class to configure the application.
- Using the SignalR jQuery library in a web page to send messages and display updates from the hub.

The following screen shot shows the chat application running in a browser. Each new user can post comments and see comments added after the user joins the chat.

![Chat instances](tutorial-getting-started-with-signalr/_static/image1.png)

Sections:

- [Set up the Project](#setup)
- [Run the Sample](#run)
- [Examine the Code](#code)
- [Next Steps](#next)

<a id="setup"></a>

## Set up the Project

This section shows how to use Visual Studio 2013 and SignalR version 2 to create an empty ASP.NET web application, add SignalR, and create the chat application.

Prerequisites:

- Visual Studio 2013. If you do not have Visual Studio, see [ASP.NET Downloads](https://www.asp.net/downloads) to get the free Visual Studio 2013 Express Development Tool.

The following steps use Visual Studio 2013 to create an ASP.NET Empty Web Application and add the SignalR library:

1. In Visual Studio, create an ASP.NET Web Application.

    ![Create web](tutorial-getting-started-with-signalr/_static/image2.png)
2. In the **New ASP.NET Project** window, leave **Empty** selected and click **Create Project**.

    ![Create empty web](tutorial-getting-started-with-signalr/_static/image3.png)
3. In **Solution Explorer**, right-click the project, select **Add | SignalR Hub Class (v2)**. Name the class **ChatHub.cs** and add it to the project. This step creates the **ChatHub** class and adds to the project a set of script files and assembly references that support SignalR.

    > [!NOTE]
    > You can also add SignalR to a project by opening the **Tools | Library Package Manager | Package Manager Console** and running a command:

    `install-package Microsoft.AspNet.SignalR`

    If you use the console to add SignalR, create the SignalR hub class as a separate step after you add SignalR.

    > [!NOTE]
    > If you are using Visual Studio 2012, the **SignalR Hub Class (v2)** template will not be available. You can add a plain **Class** called `ChatHub` instead.
4. In **Solution Explorer**, expand the Scripts node. Script libraries for jQuery and SignalR are visible in the project.
5. Replace the code in the new **ChatHub** class with the following code.

    [!code-csharp[Main](tutorial-getting-started-with-signalr/samples/sample1.cs)]
6. In **Solution Explorer**, right-click the project, then click **Add | OWIN Startup Class**. Name the new class `Startup` and click OK.

    > [!NOTE]
    > If you are using Visual Studio 2012, the **OWIN Startup Class** template will not be available. You can add a plain **Class** called `Startup` instead.
7. Change the contents of the new Startup class to the following.

    [!code-csharp[Main](tutorial-getting-started-with-signalr/samples/sample2.cs)]
8. In **Solution Explorer**, right-click the project, then click **Add | HTML Page**. Name the new page `index.html`.
    >[!NOTE]
    >You might need to change the version numbers for the references to JQuery and SignalR libraries
9. In **Solution Explorer**, right-click the HTML page you just created and click **Set as Start Page**.
10. Replace the default code in the HTML page with the following code.

    > [!NOTE]
    > A later version of the SignalR scripts may be installed by the package manager. Verify that the script references below correspond to the versions of the script files in the project (they will be different if you added SignalR using NuGet rather than adding a hub.)

    [!code-html[Main](tutorial-getting-started-with-signalr/samples/sample3.html)]
11. **Save All** for the project.

<a id="run"></a>

## Run the Sample

1. Press F5 to run the project in debug mode. The HTML page loads in a browser instance and prompts for a user name.

    ![Enter user name](tutorial-getting-started-with-signalr/_static/image4.png)
2. Enter a user name.
3. Copy the URL from the address line of the browser and use it to open two more browser instances. In each browser instance, enter a unique user name.
4. In each browser instance, add a comment and click **Send**. The comments should display in all browser instances.

    > [!NOTE]
    > This simple chat application does not maintain the discussion context on the server. The hub broadcasts comments to all current users. Users who join the chat later will see messages added from the time they join.

    The following screen shot shows the chat application running in three browser instances, all of which are updated when one instance sends a message:

    ![Chat browsers](tutorial-getting-started-with-signalr/_static/image5.png)
5. In **Solution Explorer**, inspect the **Script Documents** node for the running application. There is a script file named **hubs** that the SignalR library dynamically generates at runtime. This file manages the communication between jQuery script and server-side code.

    ![](tutorial-getting-started-with-signalr/_static/image6.png)

<a id="code"></a>

## Examine the Code

The SignalR chat application demonstrates two basic SignalR development tasks: creating a hub as the main coordination object on the server, and using the SignalR jQuery library to send and receive messages.

### SignalR Hubs

In the code sample the **ChatHub** class derives from the **Microsoft.AspNet.SignalR.Hub** class. Deriving from the **Hub** class is a useful way to build a SignalR application. You can create public methods on your hub class and then access those methods by calling them from scripts in a web page.

In the chat code, clients call the **ChatHub.Send** method to send a new message. The hub in turn sends the message to all clients by calling **Clients.All.broadcastMessage**.

The **Send** method demonstrates several hub concepts :

- Declare public methods on a hub so that clients can call them.
- Use the **Microsoft.AspNet.SignalR.Hub.Clients** dynamic property to access all clients connected to this hub.
- Call a function on the client (such as the `broadcastMessage` function) to update clients.

    [!code-csharp[Main](tutorial-getting-started-with-signalr/samples/sample4.cs)]

### SignalR and jQuery

The HTML page in the code sample shows how to use the SignalR jQuery library to communicate with a SignalR hub. The essential tasks in the code are declaring a proxy to reference the hub, declaring a function that the server can call to push content to clients, and starting a connection to send messages to the hub.

The following code declares a reference to a hub proxy.

[!code-javascript[Main](tutorial-getting-started-with-signalr/samples/sample5.js)]

> [!NOTE]
> In JavaScript the reference to the server class and its members is in camel case. The code sample references the C# **ChatHub** class in JavaScript as **chatHub**.


The following code is how you create a callback function in the script. The hub class on the server calls this function to push content updates to each client. The two lines that HTML encode the content before displaying it are optional and show a simple way to prevent script injection.

[!code-html[Main](tutorial-getting-started-with-signalr/samples/sample6.html)]

The following code shows how to open a connection with the hub. The code starts the connection and then passes it a function to handle the click event on the **Send** button in the HTML page.

> [!NOTE]
> This approach ensures that the connection is established before the event handler executes.


[!code-javascript[Main](tutorial-getting-started-with-signalr/samples/sample7.js)]

<a id="next"></a>

## Next Steps

You learned that SignalR is a framework for building real-time web applications. You also learned several SignalR development tasks: how to add SignalR to an ASP.NET application, how to create a hub class, and how to send and receive messages from the hub.

For a walkthrough on how to deploy the sample SignalR application to Azure, see [Using SignalR with Web Apps in Azure App Service](../deployment/using-signalr-with-azure-web-sites.md). For detailed information about how to deploy a Visual Studio web project to a Windows Azure Web Site, see [Create an ASP.NET web app in Azure App Service](https://azure.microsoft.com/en-us/documentation/articles/web-sites-dotnet-get-started/).

To learn more advanced SignalR developments concepts, visit the following sites for SignalR source code and resources:

- [SignalR Project](http://signalr.net)
- [SignalR Github and Samples](https://github.com/SignalR/SignalR)
- [SignalR Wiki](https://github.com/SignalR/SignalR/wiki)
