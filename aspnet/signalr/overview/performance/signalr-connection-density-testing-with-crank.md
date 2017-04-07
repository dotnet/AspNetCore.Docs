---
uid: signalr/overview/performance/signalr-connection-density-testing-with-crank
title: "SignalR Connection Density Testing with Crank | Microsoft Docs"
author: tfitzmac
description: "SignalR Connection Density Testing with Crank"
ms.author: aspnetcontent
manager: wpickett
ms.date: 02/22/2015
ms.topic: article
ms.assetid: 148d9ca7-1af1-44b6-a9fb-91e261b9b463
ms.technology: dotnet-signalr
ms.prod: .net-framework
msc.legacyurl: /signalr/overview/performance/signalr-connection-density-testing-with-crank
msc.type: authoredcontent
---
SignalR Connection Density Testing with Crank
====================
by [Tom FitzMacken](https://github.com/tfitzmac)

> This article describes how to use the Crank tool to test an application with multiple simulated clients.


Once your application is running in its hosting environment (either an Azure web role, IIS, or self-hosted using Owin), you can test application's response to a high level of connection density using the Crank tool. The hosting environment can be an Internet Information Services (IIS) server, an Owin host, or an Azure web role. (Note: Performance counters are not available on Azure App Service Web Apps, so you will not be able to get performance data from a connection density test.)

Connection Density refers to the number of simultaneous TCP connections that can be established on a server. Each TCP connection incurs its own overhead, and opening a large number of idle connections will eventually create a memory bottleneck.

[The SignalR codebase](https://github.com/signalr/signalr) includes a load-testing tool called **Crank**. The latest version of Crank can be found in [the Dev branch](https://github.com/SignalR/signalr/tree/dev) on GitHub. You can download a Zip archive of the Dev branch of the SignalR codebase [here](https://github.com/SignalR/SignalR/archive/dev.zip).

Crank may be used to fully saturate the server's memory in order to calculate the total number of idle connections possible on the server hardware. Alternatively, you may also use Crank to load test the server under a certain amount of memory pressure, by ramping up connections until a specific count or a specific memory threshold is reached.

When testing, it is important to use remote client(s) to avoid any competition for resources (i.e., TCP connections and memory). Monitor the client(s) to ensure that they are not hitting any bottlenecks that may prevent the server from reaching its full capacity (memory or CPU). You may need to increase the number of clients in order to fully load the server.

### Running a Connection Density Test

This section describes the steps needed to run a connection density test on a SignalR application.

1. Download and build the [Dev branch of the SignalR codebase](https://github.com/SignalR/SignalR/archive/dev.zip). In a command prompt, navigate to &lt;project directory&gt;\src\Microsoft.AspNet.SignalR.Crank\bin\debug.
2. Deploy your application to its intended hosting environment. Make a note of the endpoint that your application uses; for example, in the application created in the [Getting Started tutorial](../getting-started/tutorial-getting-started-with-signalr.md), the endpoint is `http://<yourhost>:8080/signalr`.
3. Install [SignalR performance counters](signalr-performance.md#perfcounters) on the server. If your application is running on Azure, see [Using SignalR Performance Counters in an Azure Web Role](using-signalr-performance-counters-in-an-azure-web-role.md).

Once you've downloaded and built the codebase, and installed performance counters on your host, the Crank command-line tool can be found in the `src\Microsoft.AspNet.SignalR.Crank\bin\Debug` folder.

Available options for the Crank tool include:

- **/?**: Shows the help screen. The available options are also displayed if the **Url** parameter is omitted.
- **/Url**: The URL for SignalR connections. This parameter is required. For a SignalR application using the default mapping, the path will end in "/signalr".
- **/Transport**: The name of the transport used. The default is `auto`, which will select the best available protocol. Options include `WebSockets`, `ServerSentEvents`, and `LongPolling` (`ForeverFrame` is not an option for Crank, since the .NET client rather than Internet Explorer is used). For more information on how SignalR selects transports, see [Transports and Fallbacks](../getting-started/introduction-to-signalr.md#transports).
- **/BatchSize**: The number of clients added in each batch. The default is 50.
- **/ConnectInterval**: The interval in milliseconds between adding connections. The default is 500.
- **/Connections**: The number of connections used to load-test the application. The default is 100,000.
- **/ConnectTimeout**: The timeout in seconds before aborting the test. The default is 300.
- **MinServerMBytes**: The minimum server megabytes to reach. The default is 500.
- **SendBytes**: The size of the payload sent to the server in bytes. The default is 0.
- **SendInterval**: The delay in milliseconds between messages to the server. The default is 500.
- **SendTimeout**: The timeout in milliseconds for messages to the server. The default is 300.
- **ControllerUrl**: The Url where one client will host a controller hub. The default is null (no controller hub). The controller hub is started when the Crank session starts; no further contact between the controller hub and Crank is made.
- **NumClients**: The number of simulated clients to connect to the application. The default is one.
- **Logfile**: The filename for the logfile for the test run. The default is `crank.csv`.
- **SampleInterval**: The time in milliseconds between performance counter samples. The default is 1000.
- **SignalRInstance**: The instance name for the performance counters on the server. The default is to use the client connection state.

### Example

The following command will test a site called `pfsignalr` on Azure that hosts an application on port 8080 with a hub named "MyHub", using 100 connections.

`crank /Connections:100 /Url:http://pfsignalr.cloudapp.net:8080/signalr`