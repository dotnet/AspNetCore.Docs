---
uid: signalr/overview/getting-started/supported-platforms
title: "Supported Platforms | Microsoft Docs"
author: pfletcher
description: "This article describes what clients and servers are supported by SignalR."
ms.author: aspnetcontent
manager: wpickett
ms.date: 06/10/2014
ms.topic: article
ms.assetid: eac31beb-0f46-4afa-9def-e80904dea4f0
ms.technology: dotnet-signalr
ms.prod: .net-framework
msc.legacyurl: /signalr/overview/getting-started/supported-platforms
msc.type: authoredcontent
---
Supported Platforms
====================
by [Patrick Fletcher](https://github.com/pfletcher)

> This article describes what clients and servers are supported by SignalR. 
> 
> ## Questions and comments
> 
> Please leave feedback on how you liked this tutorial and what we could improve in the comments at the bottom of the page. If you have questions that are not directly related to the tutorial, you can post them to the [ASP.NET SignalR forum](https://forums.asp.net/1254.aspx/1?ASP+NET+SignalR) or [StackOverflow.com](http://stackoverflow.com/).


SignalR is supported under a variety of server and client configurations. In addition, each transport option has a set of requirements of its own; if the system requirements for a transport are not available, SignalR will gracefully failover to other transports. For more information on the transports that SignalR supports, see [Transports and Fallbacks](introduction-to-signalr.md#transports).

## Server system requirements

The SignalR server component can be hosted on a variety of server configurations. This section describes the supported versions of operating systems, .NET framework, Internet Information Server, and other components.

### Supported server operating systems

The SignalR server component can be hosted in the following server or client operating systems. Note that for SignalR to use WebSockets, Windows Server 2012 or Windows 8 is required (WebSocket can be used on Windows Azure Web Sites, as long as the site's .NET framework version is set to 4.5, and Web Sockets is enabled in the site's Configuration page).

- Windows Server 2012
- Windows Server 2008 r2
- Windows 8
- Windows 7
- Windows Azure

### Supported server .NET Framework version

SignalR 2 is only supported on .NET Framework 4.5. See the [Recommended Updates](#updates) section for updates that enhance reliability, compatibility, stability, and performance.

### Supported server IIS versions

When SignalR is hosted in IIS, the following versions are supported. Note that if a client operating system is used, such as for development (Windows 8 or Windows 7), full versions of IIS or Cassini should not be used, since there will be a limit of 10 simultaneous connections imposed, which will be reached very quickly since connections are transient, frequently re-established, and are not disposed immediately upon no longer being used. IIS Express should be used on client operating systems.

Also note that for SignalR to use WebSocket, IIS 8 or IIS 8 Express must be used, the server must be using Windows 8, Windows Server 2012, or later, and WebSocket must be enabled in IIS. For information on how to enable WebSocket in IIS, see [IIS 8.0 WebSocket Protocol Support](https://www.iis.net/learn/get-started/whats-new-in-iis-8/iis-80-websocket-protocol-support).

- IIS 8 or IIS 8 Express.
- IIS 7 and 7.5. Support for [extensionless URLs](https://support.microsoft.com/kb/980368) is required.
- IIS must be running in integrated mode; classic mode is not supported. Message delays of up to 30 seconds may be experienced if IIS is run in classic mode using the Server-Sent Events transport.
- The hosting application must be running in full trust mode.

## Client system requirements

SignalR can be used in a variety of client platforms. This section describes the system requirements for using SignalR in web browsers, Windows desktop applications, Silverlight applications, and mobile devices.

### Web browsers

SignalR can be used in a variety of web browsers, but typically, only the latest two versions are supported.

Applications that use SignalR in browsers must use jQuery version 1.6.4 or major later versions (such as 1.7.2, 1.8.2, or 1.9.1).

SignalR can be used in the following browsers:

- Microsoft Internet Explorer versions 8, 9, 10, and 11. Modern, Desktop, and Mobile versions are supported.
- Mozilla Firefox: current version - 1, both Windows and Mac versions.
- Google Chrome: current version - 1, both Windows and Mac versions.
- Safari: current version - 1, both Mac and iOS versions.
- Opera: current version - 1, Windows only.
- Android browser

In addition to requiring certain browsers, the various transports that SignalR uses have requirements of their own. The following transports are supported under the following configurations:

<a id="browser"></a>

**Web Browser Transport Requirements**

| Transport | Internet Explorer | Chrome (Windows or iOS) | Firefox | Safari (OSX or iOS) | Android |
| --- | --- | --- | --- | --- | --- |
| WebSockets | 10+ | current - 1 | current - 1 | current - 1 | N/A |
| Server-Sent Events | N/A | current - 1 | current - 1 | current - 1 | N/A |
| ForeverFrame | 8+ | N/A | N/A | N/A | 4.1 |
| Long Polling | 8+ | current - 1 | current - 1 | current - 1 | 4.1 |

\*: 6+ required for full functionality.

#### Unsupported Browsers

While SignalR *may* run without major issues in older browser versions, we do not actively test SignalR in them and generally do not fix bugs that may appear in them.

### Windows Desktop and Silverlight Applications

In addition to running in a web browser, SignalR can be hosted in standalone Windows client or Silverlight applications. Windows Desktop and Silverlight SignalR applications have the following system requirements.

- Applications using .NET 4 are supported on Windows XP SP3 or later.
- Applications using .NET Framework 4.5 are supported on Windows Vista or later.

In addition to operating system and .NET framework requirements, the transports available to SignalR have requirements of their own. The following transports are supported under the following configurations:

**Windows Desktop and Silverlight Transport Requirements**

| Transport | .NET application | Silverlight |
| --- | --- | --- |
| Web Sockets | Windows 8+ and .NET 4.5+ | N/A |
| Forever Frame | N/A | N/A |
| Server-Sent Events | .NET 4+ | 5+ |
| Long Polling | .NET 4+ | 5+ |

<a id="android"></a>

### Windows Store and Windows Phone Applications

SignalR can be used in Windows Store applications and Windows Phone 8 applications. The following transports are supported under the following configurations:

**Windows Store and Windows Phone Transport Requirements**

| Transport | Windows Store/ .NET | Windows Store/ JavaScript | Windows Phone/ IE | Windows Phone/ .NET |
| --- | --- | --- | --- | --- |
| WebSockets | N/A | Win8+ | 8+ | N/A |
| Forever Frame | N/A | Win8+ | 7.5+ | N/A |
| Server-Sent Events | Win8+ | N/A | N/A | 8+ |
| Long Polling | Win8+ | Win8+ | 7.5+ | 8+ |

<a id="updates"></a>

## Recommended Updates

The following updates are recommended for SignalR servers:

- An update for .NET Framework 4.5 is available [here](https://support.microsoft.com/kb/2750149).
- Microsoft will periodically release QFEs for ASP.NET. These should be applied as available.
