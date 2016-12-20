---
title: "Enabling SignalR Tracing | Microsoft Docs"
author: tfitzmac
description: "This document describes how to enable and configure tracing for SignalR servers and clients. Tracing enables you to view diagnostic information about events..."
ms.author: riande
manager: wpickett
ms.date: 08/08/2014
ms.topic: article
ms.assetid: 
ms.technology: dotnet-signalr
ms.prod: .net-framework
msc.legacyurl: /signalr/overview/testing-and-debugging/enabling-signalr-tracing
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\signalr\overview\testing-and-debugging\enabling-signalr-tracing.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/59043) | [View dev content](http://docs.aspdev.net/tutorials/signalr/overview/testing-and-debugging/enabling-signalr-tracing.html) | [View prod content](http://www.asp.net/signalr/overview/testing-and-debugging/enabling-signalr-tracing) | Picker: 59950

Enabling SignalR Tracing
====================
by [Tom FitzMacken](https://github.com/tfitzmac)

> This document describes how to enable and configure tracing for SignalR servers and clients. Tracing enables you to view diagnostic information about events in your SignalR application.
> 
> This topic was originally written by Patrick Fletcher.
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
> ## Questions and comments
> 
> Please leave feedback on how you liked this tutorial and what we could improve in the comments at the bottom of the page. If you have questions that are not directly related to the tutorial, you can post them to the [ASP.NET SignalR forum](https://forums.asp.net/1254.aspx/1?ASP+NET+SignalR) or [StackOverflow.com](http://stackoverflow.com/).


When tracing is enabled, a SignalR application creates log entries for events. You can log events from both the client and the server. Tracing on the server logs connection, scaleout provider, and message bus events. Tracing on the client logs connection events. In SignalR 2.1 and later, tracing on the client logs the full content of hub invocation messages.

## Contents

- [Enabling tracing on the server](#server)

    - [Logging server events to text files](#server_text)
    - [Logging server events to the event log](#server_eventlog)
- [Enabling tracing in the .NET client (Windows Desktop apps)](#net_client)

    - [Logging Desktop client events to the console](#desktop_console)
    - [Logging Desktop client events to a text file](#desktop_text)
- [Enabling tracing in Windows Phone 8 clients](#phone)

    - [Logging Windows Phone client events to the UI](#phone_ui)
    - [Logging Windows Phone client events to the debug console](#phone_debug)
- [Enabling tracing in the JavaScript client](#javascript)

<a id="server"></a>
## Enabling tracing on the server

You enable tracing on the server within the application's configuration file (either App.config or Web.config depending on the type of project.) You specify which categories of events you want to log. In the configuration file, you also specify whether to log the events to a text file, the Windows event log, or a custom log using an implementation of [TraceListener](https://msdn.microsoft.com/en-us/library/system.diagnostics.tracelistener(v=vs.110).aspx).

The server event categories include the following sorts of messages:

| Source | Messages |
| --- | --- |
| SignalR.SqlMessageBus | SQL Message Bus scaleout provider setup, database operation, error, and timeout events |
| SignalR.ServiceBusMessageBus | Service bus scaleout provider topic creation and subscription, error, and messaging events |
| SignalR.RedisMessageBus | Redis scaleout provider connection, disconnection, and error events |
| SignalR.ScaleoutMessageBus | Scaleout messaging events |
| SignalR.Transports.WebSocketTransport | WebSocket transport connection, disconnection, messaging, and error events |
| SignalR.Transports.ServerSentEventsTransport | ServerSentEvents transport connection, disconnection, messaging, and error events |
| SignalR.Transports.ForeverFrameTransport | ForeverFrame transport connection, disconnection, messaging, and error events |
| SignalR.Transports.LongPollingTransport | LongPolling transport connection, disconnection, messaging, and error events |
| SignalR.Transports.TransportHeartBeat | Transport connection, disconnection, and keepalive events |
| SignalR.ReflectedHubDescriptorProvider | Hub discovery events |

<a id="server_text"></a>
### Logging server events to text files

The following code shows how to enable tracing for each category of event. This sample configures the application to log events to text files.

**XML server code for enabling tracing**

    <system.diagnostics>
        <sources> 
          <source name="SignalR.SqlMessageBus">
            <listeners>
              <add name="SignalR-Bus" />
            </listeners>
          </source>
          <source name="SignalR.ServiceBusMessageBus">
            <listeners>
              <add name="SignalR-Bus" />
            </listeners>
          </source>
          <source name="SignalR.RedisMessageBus">
            <listeners>
              <add name="SignalR-Bus" />
            </listeners>
          </source>
          <source name="SignalR.ScaleoutMessageBus">
            <listeners>
              <add name="SignalR-Bus" />
            </listeners>
          </source>
          <source name="SignalR.Transports.WebSocketTransport">
            <listeners>
              <add name="SignalR-Transports" />
            </listeners>
          </source>     
          <source name="SignalR.Transports.ServerSentEventsTransport">
            <listeners>
              <add name="SignalR-Transports" />
            </listeners>
          </source>
          <source name="SignalR.Transports.ForeverFrameTransport">
            <listeners>
              <add name="SignalR-Transports" />
            </listeners>
          </source>
          <source name="SignalR.Transports.LongPollingTransport">
            <listeners>
              <add name="SignalR-Transports" />
            </listeners>
          </source>
          <source name="SignalR.Transports.TransportHeartBeat">
            <listeners>
              <add name="SignalR-Transports" />
            </listeners>
          </source>
          <source name="SignalR.ReflectedHubDescriptorProvider">
            <listeners>
              <add name="SignalR-Init" />
            </listeners>
          </source>
        </sources>
        <!-- Sets the trace verbosity level -->
        <switches>
          <add name="SignalRSwitch" value="Verbose" />
        </switches>
        <!-- Specifies the trace writer for output -->
        <sharedListeners>
          <!-- Listener for transport events -->
          <add name="SignalR-Transports" type="System.Diagnostics.TextWriterTraceListener" initializeData="transports.log.txt" />
          <!-- Listener for scaleout provider events -->
          <add name="SignalR-Bus" type="System.Diagnostics.TextWriterTraceListener" initializeData="bus.log.txt" />
          <!-- Listener for hub discovery events -->
          <add name="SignalR-Init" type="System.Diagnostics.TextWriterTraceListener" initializeData="init.log.txt" />
        </sharedListeners>
        <trace autoflush="true" />
      </system.diagnostics>

In the code above, the `SignalRSwitch` entry specifies the [TraceLevel](https://msdn.microsoft.com/en-us/library/system.diagnostics.tracelevel(v=vs.110).aspx) used for events sent to the specified log. In this case, it is set to `Verbose` which means all debugging and tracing messages are logged.

The following output shows entries from the `transports.log.txt` file for an application using the above configuration file. It shows a new connection, a removed connection, and transport heartbeat events.

`SignalR.Transports.TransportHeartBeat Information: 0 : Connection 9aa62c9b-09b3-416c-b367-06520e24f780 is New. SignalR.Transports.TransportHeartBeat Verbose: 0 : KeepAlive(9aa62c9b-09b3-416c-b367-06520e24f780) SignalR.Transports.TransportHeartBeat Verbose: 0 : KeepAlive(9aa62c9b-09b3-416c-b367-06520e24f780) SignalR.Transports.TransportHeartBeat Verbose: 0 : KeepAlive(9aa62c9b-09b3-416c-b367-06520e24f780) SignalR.Transports.WebSocketTransport Information: 0 : CloseSocket(9aa62c9b-09b3-416c-b367-06520e24f780) SignalR.Transports.WebSocketTransport Information: 0 : Abort(9aa62c9b-09b3-416c-b367-06520e24f780) SignalR.Transports.TransportHeartBeat Information: 0 : Removing connection 9aa62c9b-09b3-416c-b367-06520e24f780 SignalR.Transports.WebSocketTransport Information: 0 : End(9aa62c9b-09b3-416c-b367-06520e24f780) SignalR.Transports.WebSocketTransport Verbose: 0 : DrainWrites(9aa62c9b-09b3-416c-b367-06520e24f780) SignalR.Transports.WebSocketTransport Information: 0 : CompleteRequest (9aa62c9b-09b3-416c-b367-06520e24f780)`

<a id="server_eventlog"></a>
### Logging server events to the event log

To log events to the event log rather than a text file, change the values for the entries in the `sharedListeners` node. The following code shows how to log server events to the event log:

**XML server code for logging events to the event log**

    <sharedListeners>
      <!-- Listener for transport events -->
      <add name="SignalR-Transports" type="System.Diagnostics.EventLogTraceListener" initializeData="SignalRScaleoutLog" />
      <!-- Listener for scaleout provider events -->
      <add name="SignalR-Bus" type="System.Diagnostics.EventLogTraceListener" initializeData="SignalRTransportLog" />
      <!-- Listener for hub discovery events -->
      <add name="SignalR-Init" type="System.Diagnostics.EventLogTraceListener" initializeData="SignalRInitLog" />
    </sharedListeners>

The events are logged in the Application log, and are available through the Event Viewer, as shown below:

![Event Viewer showing SignalR logs](enabling-signalr-tracing/_static/image1.png)

> [!NOTE] When using the event log, set the **TraceLevel** to **Error** to keep the number of messages manageable.

<a id="net_client"></a>
## Enabling tracing in the .NET client (Windows Desktop apps)

The .NET client can log events to the console, a text file, or to a custom log using an implementation of [TextWriter](https://msdn.microsoft.com/en-us/library/system.io.textwriter.aspx).

To enable logging in the .NET client, set the connection's `TraceLevel` property to a [TraceLevels](https://msdn.microsoft.com/en-us/library/microsoft.aspnet.signalr.client.tracelevels(v=vs.118).aspx) value, and the `TraceWriter` property to a valid [TextWriter](https://msdn.microsoft.com/en-us/library/system.io.textwriter.aspx) instance.

<a id="desktop_console"></a>
### Logging Desktop client events to the console

The following C# code shows how to log events in the .NET client to the console:

[!code[Main](enabling-signalr-tracing/samples/sample1.xml?highlight=2-3)]

<a id="desktop_text"></a>
### Logging Desktop client events to a text file

The following C# code shows how to log events in the .NET client to a text file:

[!code[Main](enabling-signalr-tracing/samples/sample2.xml?highlight=4-5)]

The following output shows entries from the `ClientLog.txt` file for an application using the above configuration file. It shows the client connecting to the server, and the hub invoking a client method called `addMessage`:

`19:41:39.9103763 - null - ChangeState(Disconnected, Connecting) 19:41:40.3750726 - dd61fd48-d796-4518-b36b-ec1dcb970d72 - WS Connecting to: ws://localhost:8080/signalr/signalr/connect?transport=webSockets&clientProtocol=1.4&connectionToken=AQAAANCMnd8BFdERjHoAwE%2FCl%2BsBAAAAh8Lp KH5%2FDkCQeR4ALAwR%2BAAAAAACAAAAAAADZgAAwAAAABAAAADHpCa7wm%2FbOhjluf%2Fm9GA9AAAAAASAAACgAAAAEA AAAEqRfJihLExRI6tZy7lWRwYoAAAApotSsJXW0OiwEgiUUi0pzhK6oKbz%2BkMeVbezuEDQLnJecM9otFe9PRQAAAAuHK BlOnPmXt%2FhXV%2Felr1QvC156Q%3D%3D&connectionData=[{"Name":"MyHub"}] 19:41:40.4442923 - dd61fd48-d796-4518-b36b-ec1dcb970d72 - WS: OnMessage({"C":"d-5196BF5C-A,0|B,0|C,1|D,0","S":1,"M":[]}) 19:41:40.4874324 - dd61fd48-d796-4518-b36b-ec1dcb970d72 - ChangeState(Connecting, Connected) 19:41:47.4511770 - dd61fd48-d796-4518-b36b-ec1dcb970d72 - WS: OnMessage({"C":"d-5196BF5C-A,1|B,0|C,1|D,0","M":[{"H":"MyHub","M":"addMessage","A":["User One","Hello!"]}]}) 19:41:47.4576968 - dd61fd48-d796-4518-b36b-ec1dcb970d72 - WS: OnMessage({"I":"0"}) 19:41:50.3959119 - dd61fd48-d796-4518-b36b-ec1dcb970d72 - WS: OnMessage({}) 19:41:50.8928084 - dd61fd48-d796-4518-b36b-ec1dcb970d72 - WS: OnMessage({"C":"d-5196BF5C-A,2|B,0|C,1|D,0","M":[{"H":"MyHub","M":"addMessage","A":["User Two","Hello!"]}]})`

<a id="phone"></a>
## Enabling tracing in Windows Phone 8 clients

SignalR applications for Windows Phone apps use the same .NET client as desktop apps, but [Console.Out](https://msdn.microsoft.com/en-us/library/system.console.out(v=vs.110).aspx) and writing to a file with [StreamWriter](https://msdn.microsoft.com/en-us/library/system.io.streamwriter(v=vs.110).aspx) are not available. Instead, you need to create a custom implementation of [TextWriter](https://msdn.microsoft.com/en-us/library/system.io.textwriter(v=vs.110).aspx) for tracing. 

<a id="phone_ui"></a>
### Logging Windows Phone client events to the UI

The [SignalR codebase](https://github.com/SignalR/SignalR/archive/master.zip) includes a Windows Phone sample that writes trace output to a [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) using a custom [TextWriter](https://msdn.microsoft.com/en-us/library/system.io.textwriter(v=vs.110).aspx) implementation called `TextBlockWriter`. This class can be found in the **samples/Microsoft.AspNet.SignalR.Client.WP8.Samples** project. When creating an instance of `TextBlockWriter`, pass in the current [SynchronizationContext](https://msdn.microsoft.com/en-us/library/system.threading.synchronizationcontext(v=vs.110).aspx), and a [StackPanel](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.stackpanel.aspx) where it will create a [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) to use for trace output:

    Connection = new HubConnection(ServerURI);
    var writer = new TextBlockWriter(SynchronizationContext.Current, StackPanelConsole);
    Connection.TraceWriter = writer;
    Connection.TraceLevel = TraceLevels.All;

The trace output will then be written to a new [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) created in the [StackPanel](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.controls.stackpanel.aspx) you passed in:

![](enabling-signalr-tracing/_static/image2.png)

<a id="phone_debug"></a>
### Logging Windows Phone client events to the debug console

To send output to the debug console rather than the UI, create an implementation of [TextWriter](https://msdn.microsoft.com/en-us/library/system.io.textwriter(v=vs.110).aspx) that writes to the debug window, and assign it to your connection's [TraceWriter](https://msdn.microsoft.com/en-us/library/microsoft.aspnet.signalr.client.connection.tracewriter(v=vs.118).aspx) property:

    Connection = new HubConnection(ServerURI);
    var writer = new DebugTextWriter();
    Connection.TraceWriter = writer;
    Connection.TraceLevel = TraceLevels.All;
    
    ...
    
    private class DebugTextWriter : TextWriter
    {
        private StringBuilder buffer;
    
        public DebugTextWriter()
        {
            buffer = new StringBuilder();
        }
    
        public override void Write(char value)
        {
            switch (value)
            {
                case '\n':
                    return;
                case '\r':
                    Debug.WriteLine(buffer.ToString());
                    buffer.Clear();
                    return;
                default:
                    buffer.Append(value);
                    break;
            }
        }
                
        public override void Write(string value)
        {
            Debug.WriteLine(value);
                    
        }
        #region implemented abstract members of TextWriter
        public override Encoding Encoding
        {
            get { throw new NotImplementedException(); }
        }
        #endregion
    }

Trace information will then be written to the debug window in Visual Studio:

![](enabling-signalr-tracing/_static/image3.png)

<a id="javascript"></a>
## Enabling tracing in the JavaScript client

To enable client-side logging on a connection, set the `logging` property on the connection object before you call the `start` method to establish the connection.

**Client JavaScript code for enabling tracing to the browser console (with the generated proxy)**

[!code[Main](enabling-signalr-tracing/samples/sample3.xml?highlight=1)]

**Client JavaScript code for enabling tracing to the browser console (without the generated proxy)**

[!code[Main](enabling-signalr-tracing/samples/sample4.xml?highlight=2)]

When tracing is enabled, the JavaScript client logs events to the browser console. To access the browser console, see [Monitoring Transports](../getting-started/introduction-to-signalr.md).

The following screenshot shows a SignalR JavaScript client with tracing enabled. It shows connection and hub invocation events in the browser console:

![SignalR tracing events in the browser console](enabling-signalr-tracing/_static/image4.png)