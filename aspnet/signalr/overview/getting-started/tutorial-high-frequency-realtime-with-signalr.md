---
uid: signalr/overview/getting-started/tutorial-high-frequency-realtime-with-signalr
title: "Create high-frequency real-time app with SignalR 2 | Microsoft Docs"
author: pfletcher
description: "This tutorial shows how to create a web application that uses ASP.NET SignalR to provide high-frequency messaging functionality."
ms.author: riande
ms.date: 12/28/2014
ms.assetid: 9f969dda-78ea-4329-b1e3-e51c02210a2b
msc.legacyurl: /signalr/overview/getting-started/tutorial-high-frequency-realtime-with-signalr
msc.type: authoredcontent
---

# Tutorial: Create high-frequency real-time app with SignalR 2

This tutorial shows how to create a web application that uses ASP.NET SignalR 2 to provide high-frequency messaging functionality. In this case, "high-frequency messaging" means the server sends updates at a fixed rate. We'll be sending up to 10 messages a second.

The application you'll create will display a shape that users can drag. The server will update the position of the shape in all connected browsers to match the position of the dragged shape using timed updates.

Concepts introduced in this tutorial have applications in real-time gaming and other simulation applications.

In this tutorial, you:

> [!div class="checklist"]
> * Set up the project
> * Create the base application
> * Map to the hub when app starts
> * Add the client
> * Run the app
> * Add the client loop
> * Add the server loop
> * Add smooth animation

[!INCLUDE [Consider ASP.NET Core SignalR](~/includes/signalr/signalr-version-disambiguation.md)]

## Prerequisites

### Visual Studio 2017

If you don't already have it, [download Visual Studio 2017](https://visualstudio.microsoft.com/downloads/) now.

### ASP.NET and web development workload

When Visual Studio Installer opens, make sure you install the **ASP.NET and web development** workload. It's under **Web & Cloud**.

### NuGet package source api

You'll need to set up the NuGet API to install the jQuery UI package.

1. When Visual Studio 2017 opens, select **Tools** > **Options**.

1. In **Options**, select **NuGet Package Manager** > **Package Sources**.

1. Next to **Available package sources**, select **+** and enter this information:

    | Setting | Value |
    | ------- | ----- |
    | Name | Enter *nuget.org* |
    | Source | Enter *https://api.nuget.org/v3/index.json* |

1. Select **OK**.

## Set up the project

In this section, we'll create the project in Visual Studio 2017.

This section shows how to use Visual Studio 2017 to create an empty ASP.NET Web Application and add the SignalR and jQuery.UI libraries.

1. In Visual Studio, create an ASP.NET Web Application.

    ![Create web](tutorial-high-frequency-realtime-with-signalr/_static/image1.png)

1. In the **New ASP.NET Web Application - MoveShapeDemo** window, leave **Empty** selected and select **OK**.

1. In **Solution Explorer**, right-click the project and select **Add** > **New Item**.

1. In **Add New Item - MoveShapeDemo**, select **Installed** > **Visual C#** > **Web** > **SignalR**  and then select **SignalR Hub Class (v2)**.

1. Name the class *MoveShapeHub* and add it to the project.

    This step creates the *MoveShapeHub.cs* class file. Simultaneously, it adds  a set of script files and assembly references that support SignalR to the project.

1. Select **Tools** > **NuGet Package Manager** > **Package Manager Console**.

1. In the package manager window, run the following command:

    ```console
    Install-Package jQuery.UI.Combined
    ```

    This command installs the jQuery UI library. You'll use it to animate the shape.

1. In **Solution Explorer**, expand the Scripts node.

    ![Script library references](tutorial-high-frequency-realtime-with-signalr/_static/image2.png)

    Script libraries for jQuery, jQueryUI, and SignalR are visible in the project.

## Create the base application

In this section, you'll create a browser application. The app sends the location of the shape to the server during each mouse move event. The server broadcasts this information to all other connected clients in real time. We'll expand on this application in later sections.

1. Open the *MoveShapeHub.cs* file.

1. Replace the code in the *MoveShapeHub.cs* file with this code:

    [!code-csharp[Main](tutorial-high-frequency-realtime-with-signalr/samples/sample1.cs)]

1. Save the file.

The `MoveShapeHub` class is an implementation of a SignalR hub. As in the [Getting Started with SignalR](tutorial-getting-started-with-signalr.md) tutorial, the hub has a method that the clients call directly. In this case, the client will send an object with the new X and Y coordinates of the shape to the server. Those coordinates get broadcasted to all other connected clients. SignalR will automatically serialize this object using JSON.

The app will send the `ShapeModel` object to the client. It has members to store the position of the shape. The version of the object on the server also has a member to track which client's data is being stored. This object prevents the server from sending a client's data back to itself. This member uses the `JsonIgnore` attribute to keep the application from serializing the data and sending it back to the client.

## Map to the hub when app starts

Next, you'll set up mapping to the hub when the application starts. In SignalR 2, adding an OWIN startup class creates the mapping.

1. In **Solution Explorer**, right-click the project and select **Add** > **New Item**.

1. In **Add New Item - MoveShapeDemo** select **Installed** > **Visual C#** > **Web** and then select **OWIN Startup Class**.

1. Name the class *Startup* and select **OK**.

1. Replace the default code in the *Startup.cs* file with this code:

    [!code-csharp[Main](tutorial-high-frequency-realtime-with-signalr/samples/sample2.cs)]

The OWIN startup class will call `MapSignalR` when the app executes the `Configuration` method. The app adds the class to OWIN's startup process using the `OwinStartup` assembly attribute.

## Add the client

Next, you'll add the HTML client.

1. In **Solution Explorer**, right-click the project and select **Add** > **HTML Page**.

1. Name the page **Default** and select **OK**.

1. In **Solution Explorer**, right-click *Default.html* and select **Set as Start Page**.

1. Replace the default code in the *Default.html* file with this code:

    [!code-html[Main](tutorial-high-frequency-realtime-with-signalr/samples/sample3.html?highlight=14-16)]

1. In **Solution Explorer**, expand **Scripts**.

    Script libraries for jQuery and SignalR are visible in the project.

    > [!IMPORTANT]
    > The package manager will install a later version of the SignalR scripts.

1. Update the script references in the code block correspond to the versions of the script files in the project.

This HTML and JavaScript code creates a red `div` called `shape`. It enables the shape's dragging behavior using the jQuery library and uses the `drag` event to send the shape's position to the server.

## Run the app

You can run the app to see it work. When you drag the shape around a browser window, the shape moves in the other browsers too.

1. In the toolbar, turn on **Script Debugging** and then select the play button to run the application in Debug mode.

    ![Screenshot of user turning on debugging mode and selecting play.](tutorial-high-frequency-realtime-with-signalr/_static/image3.png)

    A browser window will open with the red shape in the upper-right corner.

1. Copy the page's URL.

1. Open another browser and paste the URL into the address bar.

1. Drag the shape in one of the browser windows. The shape in the other browser window will follow.

    ![GIF of the app in action](tutorial-high-frequency-realtime-with-signalr/_static/move-shape-demo.gif)

While the application will function using this method, it's not a recommended programming model. There's no upper limit to the number of messages getting sent. As a result, the clients and server will get overwhelmed with messages and performance will degrade. Also, the app will display a disjointed animation on the client. This jerky animation happens because the shape moves instantly by each method. It's better if the shape moves smoothly to each new location. Let's learn how to fix those issues.

## Add the client loop

Sending the location of the shape on every mouse move event creates an unnecessary amount of network traffic. The app needs to throttle the messages from the client.

Use the javascript `setInterval` function to set up a loop that sends new position information to the server at a fixed rate. This loop is a basic representation of a "game loop." It's a repeatedly called function that drives all the functionality of a game.

1. Replace the client code in the Default.html file with this code:

    [!code-html[Main](tutorial-high-frequency-realtime-with-signalr/samples/sample4.html?highlight=14-16)]

    > [!IMPORTANT]
    > You have to replace the script references again. They must match the versions of the scripts in the project.

    This new code adds the `updateServerModel` function. It gets called on a fixed frequency. The function sends the position data to the server whenever the `moved` flag indicates that there's new position data to send.

1. Select the play button to start the application

1. Copy the page's URL.

1. Open another browser and paste the URL into the address bar.

1. Drag the shape in one of the browser windows. The shape in the other browser window will follow.

Since the app throttles the number of messages that get sent to the server, the animation won't appear as smooth did at first.

## Add the server loop

In the current application, messages sent from the server to the client go out as often as they're received. This network traffic presents a similar problem as we see on the client.

The app can send messages more often than they're needed. The connection can become flooded as a result. This section describes how to update the server to add a timer that throttles the rate of the outgoing messages.

1. Replace the contents of `MoveShapeHub.cs` with this code:

    [!code-csharp[Main](tutorial-high-frequency-realtime-with-signalr/samples/sample5.cs)]

1. Select the play button to start the application

1. Copy the page's URL.

1. Open another browser and paste the URL into the address bar.

1. Drag the shape in one of the browser windows.

This code expands the client to add the `Broadcaster` class. The new class throttles the outgoing messages using the `Timer` class from the .NET framework.

It's good to learn that the hub itself is transitory. It's created every time it's needed. So the app creates the `Broadcaster` as a singleton. It uses lazy initialization to defer the `Broadcaster`'s creation until it's needed. That guarantees that the app creates the first hub instance completely before starting the timer.

The call to the clients' `UpdateShape` function is then moved out of the hub's `UpdateModel` method. It's no longer called immediately whenever the app receives incoming messages. Instead, the app sends the messages to the clients at a rate of 25 calls per second. The process is  managed by the `_broadcastLoop` timer from within the `Broadcaster` class.

Lastly, instead of calling the client method from the hub directly, the `Broadcaster` class needs to get a reference to the currently operating `_hubContext` hub. It gets the reference with the `GlobalHost`.

## Add smooth animation

The application is almost finished, but we could make one more improvement. The app moves the shape on the client in response to server messages. Instead of setting the position of the shape to the new location given by the server, lets' use the JQuery UI library's `animate` function. It can move the shape smoothly between its current and new position.

1. Update the client's `updateShape` method in the HTML page to look like the highlighted code:

    [!code-html[Main](tutorial-high-frequency-realtime-with-signalr/samples/sample6.html?highlight=33-40)]

1. Select the play button to start the application

1. Copy the page's URL.

1. Open another browser and paste the URL into the address bar.

1. Drag the shape in one of the browser windows.

The movement of the shape in the other window will appear less jerky. The app interpolates its movement over time rather than being set once per incoming message.

This code moves the shape from the old location to the new one. The server gives the position of the shape over the course of the animation interval. In this case, that's 100 milliseconds. The app clears any previous animation running on the shape before the new animation starts.

## Additional resources

The communication paradigm you just learned about is useful for developing online games and other simulations, like [the ShootR game created with SignalR](https://shootr.azurewebsites.net/).

For a walkthrough on how to deploy a SignalR application to Azure, see [Using SignalR with Web Apps in Azure App Service](../deployment/using-signalr-with-azure-web-sites.md). For detailed information about how to deploy a Visual Studio web project to a Windows Azure Web Site, see [Create an ASP.NET web app in Azure App Service](https://azure.microsoft.com/documentation/articles/web-sites-dotnet-get-started/).

For more information, see the following resources:

* [SignalR Project](http://signalr.net)

* [SignalR GitHub and Samples](https://github.com/SignalR/SignalR)

* [SignalR Wiki](https://github.com/SignalR/SignalR/wiki)

## Next steps

In this tutorial, you:

> [!div class="checklist"]
> * Set up the project
> * Created the base application
> * Mapped to the hub when app starts
> * Added the client
> * Ran the app
> * Added the client loop
> * Added the server loop
> * Added smooth animation

Advance to the next article to learn how to create a web application that uses ASP.NET SignalR 2 to provide server broadcast functionality.
> [!div class="nextstepaction"]
> [SignalR 2 and server broadcasting](tutorial-server-broadcast-with-signalr.md)