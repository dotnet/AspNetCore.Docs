---
uid: signalr/overview/getting-started/tutorial-getting-started-with-signalr-and-mvc
title: "Tutorial: Real-time chat with SignalR 2 and MVC 5 | Microsoft Docs"
author: pfletcher
description: "This tutorial shows how to use ASP.NET SignalR 2 to create a real-time chat application. You add SignalR to an MVC 5 application."
ms.author: riande
ms.date: 12/31/2018
ms.assetid: 80bfe5fb-bdfc-41fe-ac43-2132e5d69fac
msc.legacyurl: /signalr/overview/getting-started/tutorial-getting-started-with-signalr-and-mvc
msc.type: authoredcontent
ms.topic: tutorial
---

# Tutorial: Real-time chat with SignalR 2 and MVC 5

This tutorial shows how to use ASP.NET SignalR 2 to create a real-time chat application. You add SignalR to an MVC 5 application and create a chat view to send and display messages.

In this tutorial, you:

> [!div class="checklist"]
> * Set up the project
> * Run the sample
> * Examine the code

[!INCLUDE [Consider ASP.NET Core SignalR](~/includes/signalr/signalr-version-disambiguation.md)]

## Prerequisites

* [Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) with the **ASP.NET and web development** workload.

## Set up the Project

This section shows how to use Visual Studio 2017 and SignalR 2 to create an empty ASP.NET MVC 5 application, add the SignalR library, and create the chat application.

1. In Visual Studio, create a C# ASP.NET application that targets .NET Framework 4.5, name it SignalRChat, and click OK.

    ![Create web](tutorial-getting-started-with-signalr-and-mvc/_static/image1.png)

1. In **New ASP.NET Web Application - SignalRMvcChat**, select **MVC** and then select **Change Authentication**.

1. In **Change Authentication**, select **No Authentication** and click **OK**.

    ![Select No Authentication](tutorial-getting-started-with-signalr-and-mvc/_static/image2.png)

1. In **New ASP.NET Web Application - SignalRMvcChat**, select **OK**.

1. In **Solution Explorer**, right-click the project and select **Add** > **New Item**.

1. In **Add New Item - SignalRChat**, select **Installed** > **Visual C#** > **Web** > **SignalR**  and then select **SignalR Hub Class (v2)**.

1. Name the class *ChatHub* and add it to the project.

    This step creates the *ChatHub.cs* class file and adds a set of script files and assembly references that support SignalR to the project.

1. Replace the code in the new *ChatHub.cs* class file with this code:

    [!code-csharp[Main](tutorial-getting-started-with-signalr-and-mvc/samples/sample1.cs)]

1. In **Solution Explorer**, right-click the project and select **Add** > **Class**.

1. Name the new class *Startup* and add it to the project.

1. Replace the code in the *Startup.cs* class file with this code:

    [!code-csharp[Main](tutorial-getting-started-with-signalr-and-mvc/samples/sample2.cs)]

1. In **Solution Explorer**, select **Controllers** > **HomeController.cs**.

1. Add this method to the *HomeController.cs*.

    [!code-csharp[Main](tutorial-getting-started-with-signalr-and-mvc/samples/sample3.cs)]

    This method returns the **Chat** view that you create in a later step.

1. In **Solution Explorer**, right-click **Views** > **Home**, and select **Add** >  **View**.

1. In **Add View**, name the new view **Chat** and select **Add**.

1. Replace the contents of **Chat.cshtml** with this code:

    [!code-cshtml[Main](tutorial-getting-started-with-signalr-and-mvc/samples/sample4.cshtml)]

1. In **Solution Explorer**, expand **Scripts**.

    Script libraries for jQuery and SignalR are visible in the project.

    > [!IMPORTANT]
    > The package manager may have installed a later version of the SignalR scripts.

1. Check that the script references in the code block correspond to the versions of the script files in the project.

    Script references from the original code block:

    ```cshtml
    <!--Script references. -->
    <!--The jQuery library is required and is referenced by default in _Layout.cshtml. -->
    <!--Reference the SignalR library. -->
    <script src="~/Scripts/jquery.signalR-2.1.0.min.js"></script>
    ```

1. If they don't match, update the *.cshtml* file.

1. From the menu bar, select **File** > **Save All**.

## Run the Sample

1. In the toolbar, turn on **Script Debugging** and then select the play button to run the sample in Debug mode.

    ![Enter user name](tutorial-getting-started-with-signalr-and-mvc/_static/image3.png)

1. When the browser opens, enter a name for your chat identity.

1. Copy the URL from the browser, open two other browsers, and paste the URLs into the address bars.

1. In each browser, enter a unique name.

1. Now, add a comment and select **Send**. Repeat that in the other browsers. The comments appear in real time.

    > [!NOTE]
    > This simple chat application does not maintain the discussion context on the server. The hub broadcasts comments to all current users. Users who join the chat later will see messages added from the time they join.

    See how the chat application runs in three different browsers. When Tom, Anand, and Susan send messages, all browsers update in real time:

    ![All three browsers display the same chat history](tutorial-getting-started-with-signalr-and-mvc/_static/image4.png)

1. In **Solution Explorer**, inspect the **Script Documents** node for the running application. There's a script file named *hubs* that the SignalR library generates at runtime. This file manages the communication between jQuery script and server-side code.

    ![autogenerated hubs script in the Script Documents node](tutorial-getting-started-with-signalr-and-mvc/_static/image5.png)

## Examine the Code

The SignalR chat application demonstrates two basic SignalR development tasks. It shows you how to create a hub. The server uses that hub as the main coordination object. The hub uses the SignalR jQuery library to send and receive messages.

### SignalR Hubs in the ChatHub.cs

In the code sample, the `ChatHub` class derives from the `Microsoft.AspNet.SignalR.Hub` class. Deriving from the `Hub` class is a useful way to build a SignalR application. You can create public methods on your hub class and then access those methods by calling them from scripts in a web page.

In the chat code, clients call the `ChatHub.Send` method to send a new message. The hub in turn sends the message to all clients by calling `Clients.All.addNewMessageToPage`.

The `Send` method demonstrates several hub concepts:

* Declare public methods on a hub so that clients can call them.

* Use the `Microsoft.AspNet.SignalR.Hub.Clients` dynamic property to communicate with all clients connected to this hub.

* Call a function on the client (like the `addNewMessageToPage` function) to update clients.

    [!code-csharp[Main](tutorial-getting-started-with-signalr-and-mvc/samples/sample5.cs)]

### SignalR and jQuery Chat.cshtml

The *Chat.cshtml* view file in the code sample shows how to use the SignalR jQuery library to communicate with a SignalR hub.  The code carries out many important tasks. It creates a reference to the autogenerated proxy for the hub, declares a function that the server can call to push content to clients, and it starts a connection to send messages to the hub.

[!code-javascript[Main](tutorial-getting-started-with-signalr-and-mvc/samples/sample6.js)]

> [!NOTE]
> In JavaScript, the reference to the server class and its members is in camelCase. The code sample references the C# `ChatHub` class in JavaScript as `chatHub`.

In this code block, you create a callback function in the script.

[!code-html[Main](tutorial-getting-started-with-signalr-and-mvc/samples/sample7.html)]

The hub class on the server calls this function to push content updates to each client. The optional call to the `htmlEncode` function shows a way to HTML encode the message content before displaying it in the page. It's a way to prevent script injection.

This code opens a connection with the hub.

[!code-javascript[Main](tutorial-getting-started-with-signalr-and-mvc/samples/sample8.js)]

> [!NOTE]
> This approach ensures that you establish a connection before the event handler executes.

The code starts the connection and then passes it a function to handle the click event on the **Send** button in the Chat page.

## Additional resources

For more about SignalR, see the following resources:

* [SignalR Project](http://signalr.net)

* [SignalR GitHub and Samples](https://github.com/SignalR/SignalR)

* [SignalR Wiki](https://github.com/SignalR/SignalR/wiki)

## Next steps

In this tutorial, you:

> [!div class="checklist"]
> * Set up the project
> * Ran the sample
> * Examined the code

Advance to the next article to learn how to create a web application that uses ASP.NET SignalR 2 to provide high-frequency messaging functionality.
> [!div class="nextstepaction"]
> [Web app with high-frequency messaging](tutorial-high-frequency-realtime-with-signalr.md)