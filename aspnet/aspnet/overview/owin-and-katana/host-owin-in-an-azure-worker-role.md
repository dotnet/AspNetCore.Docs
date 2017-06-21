---
uid: aspnet/overview/owin-and-katana/host-owin-in-an-azure-worker-role
title: "Host OWIN in an Azure Worker Role | Microsoft Docs"
author: MikeWasson
description: "This tutorial shows how to self-host OWIN in a Microsoft Azure worker role. Open Web Interface for .NET (OWIN) defines an abstraction between .NET web server..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 04/11/2014
ms.topic: article
ms.assetid: 07aa855a-92ee-4d43-ba66-5bfd7de20ee6
ms.technology: 
ms.prod: .net-framework
msc.legacyurl: /aspnet/overview/owin-and-katana/host-owin-in-an-azure-worker-role
msc.type: authoredcontent
---
Host OWIN in an Azure Worker Role
====================
by [Mike Wasson](https://github.com/MikeWasson)

> This tutorial shows how to self-host OWIN in a Microsoft Azure worker role.
> 
> [Open Web Interface for .NET](http://owin.org/) (OWIN) defines an abstraction between .NET web servers and web applications. OWIN decouples the web application from the server, which makes OWIN ideal for self-hosting a web application in your own process, outside of IIS–for example, inside an Azure worker role.
> 
> In this tutorial, you'll learn how to self-host an OWIN applications inside a Microsoft Azure worker role. To learn more about worker roles, see [Azure Execution Models](https://azure.microsoft.com/en-us/documentation/articles/fundamentals-application-models/#CloudServices).
> 
> ## Software versions used in the tutorial
> 
> 
> - [Visual Studio 2013](https://www.microsoft.com/visualstudio/eng/2013-downloads)
> - [Azure SDK for .NET 2.3](https://azure.microsoft.com/en-us/downloads/)
> - [Microsoft.Owin.Selfhost 2.1.0](http://www.nuget.org/packages/Microsoft.Owin.SelfHost/2.1.0)


## Create a Microsoft Azure Project

Start Visual Studio with administrator privileges. Administrator privileges are needed to debug the application locally, using the Azure compute emulator.

On the **File** menu, click **New**, then click **Project**. From **Installed Templates**, under Visual C#, click **Cloud** and then click **Windows Azure Cloud Service**. Name the project "AzureApp" and click **OK**.

[![](host-owin-in-an-azure-worker-role/_static/image2.png)](host-owin-in-an-azure-worker-role/_static/image1.png)

In the **New Windows Azure Cloud Service** dialog, double-click **Worker Role**. Leave the default name ("WorkerRole1"). This step adds a worker role to the solution. Click **OK**.

[![](host-owin-in-an-azure-worker-role/_static/image4.png)](host-owin-in-an-azure-worker-role/_static/image3.png)

The Visual Studio solution that is created contains two projects:

- &quot;AzureApp&quot; defines the roles and configuration for the Azure application.
- &quot;WorkerRole1&quot; contains the code for the worker role.

In general, an Azure application can contain multiple roles, although this tutorial uses a single role.

![](host-owin-in-an-azure-worker-role/_static/image5.png)

## Add the OWIN Self-Host Packages

From the **Tools** menu, click **Library Package Manager**, then click **Package Manager Console**.

In the Package Manager Console window, enter the following command:

[!code-console[Main](host-owin-in-an-azure-worker-role/samples/sample1.cmd)]

## Add an HTTP Endpoint

In Solution Explorer, expand the AzureApp project. Expand the Roles node, right-click WorkerRole1, and select **Properties**.

![](host-owin-in-an-azure-worker-role/_static/image6.png)

Click **Endpoints**, and then click **Add Endpoint**.

In the **Protocol** dropdown list, select "http". In **Public Port** and **Private Port**, type 80. These port numbers can be different. The public port is what clients use when they send a request to the role.

[![](host-owin-in-an-azure-worker-role/_static/image8.png)](host-owin-in-an-azure-worker-role/_static/image7.png)

## Create the OWIN Startup Class

In Solution Explorer, right click the WorkerRole1 project and select **Add** / **Class** to add a new class. Name the class `Startup`.

Replace all of the boilerplate code with the following:

[!code-csharp[Main](host-owin-in-an-azure-worker-role/samples/sample2.cs)]

The `UseWelcomePage` extension method adds a simple HTML page to your application, to verify the site is working.

## Start the OWIN Host

Open the WorkerRole.cs file. This class defines the code that runs when the worker role is started and stopped.

Add the following using statement:

[!code-csharp[Main](host-owin-in-an-azure-worker-role/samples/sample3.cs)]

Add an **IDisposable** member to the `WorkerRole` class:

[!code-csharp[Main](host-owin-in-an-azure-worker-role/samples/sample4.cs)]

In the `OnStart` method, add the following code to start the host:

[!code-csharp[Main](host-owin-in-an-azure-worker-role/samples/sample5.cs?highlight=5)]

The **WebApp.Start** method starts the OWIN host. The name of the `Startup` class is a type parameter to the method. By convention, the host will call the `Configure` method of this class.

Override the `OnStop` to dispose of the *\_app* instance:

[!code-csharp[Main](host-owin-in-an-azure-worker-role/samples/sample6.cs)]

Here is the complete code for WorkerRole.cs:

[!code-csharp[Main](host-owin-in-an-azure-worker-role/samples/sample7.cs)]

Build the solution, and press F5 to run the application locally in the Azure Compute Emulator. Depending on your firewall settings, you might need to allow the emulator through your firewall.

The compute emulator assigns a local IP address to the endpoint. You can find the IP address by viewing the Compute Emulator UI. Right-click the emulator icon in the task bar notification area, and select **Show Compute Emulator UI**.

[![](host-owin-in-an-azure-worker-role/_static/image10.png)](host-owin-in-an-azure-worker-role/_static/image9.png)

Find the IP address under Service Deployments, deployment [id], Service Details. Open a web browser and navigate to http://*address*, where *address* is the IP address assigned by the compute emulator; for example, `http://127.0.0.1:80`. You should see the OWIN welcome page:

![](host-owin-in-an-azure-worker-role/_static/image11.png)

## Deploy to Azure

For this step, you must have an Azure account. If you don't already have one, you can create a free trial account in just a couple of minutes. For details, see [Microsoft Azure Free Trial](https://azure.microsoft.com/en-us/pricing/free-trial/?WT.mc_id=A261C142F).

In Solution Explorer, right-click the AzureApp project. Select **Publish**.

![](host-owin-in-an-azure-worker-role/_static/image12.png)

If you are not signed in to your Azure account, click **Sign In**.

[![](host-owin-in-an-azure-worker-role/_static/image14.png)](host-owin-in-an-azure-worker-role/_static/image13.png)

After you are signed in, choose a subscription and click **Next**.

[![](host-owin-in-an-azure-worker-role/_static/image16.png)](host-owin-in-an-azure-worker-role/_static/image15.png)

Enter a name for the cloud service and choose a region. Click **Create**.

![](host-owin-in-an-azure-worker-role/_static/image17.png)

Click **Publish**.

[![](host-owin-in-an-azure-worker-role/_static/image19.png)](host-owin-in-an-azure-worker-role/_static/image18.png)

The Azure Activity Log window shows the progress of the deployment. When the app is deployed, browse to `http://appname.cloudapp.net/`, where *appname* is the name of your cloud service.

## Additional Resources

- [An Overview of Project Katana](an-overview-of-project-katana.md)
- [Katana Project on CodePlex](http://katanaproject.codeplex.com/)