---
title: ASP.NET Core SignalR supported platforms
author: wadepickett
description: Learn about the supported platforms for ASP.NET Core SignalR.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc, devx-track-js
ms.date: 04/01/2025
uid: signalr/supported-platforms
---
# ASP.NET Core SignalR supported platforms

## Server system requirements

SignalR for ASP.NET Core supports any server platform that ASP.NET Core supports.

## JavaScript client

The [JavaScript client](xref:signalr/javascript-client) runs on the current [Node.js long-term support (LTS) release](https://nodejs.org/en/download) and the following browsers:

| Browser                          | Version         |
| -------------------------------- | --------------- |
| Apple Safari, including iOS      | Current&dagger; |
| Google Chrome, including Android | Current&dagger; |
| Microsoft Edge                   | Current&dagger; |
| Mozilla Firefox                  | Current&dagger; |

&dagger;*Current* refers to the latest version of the browser.

The JavaScript client doesn't support Internet Explorer and other older browsers. The client might have unexpected behavior and errors on unsupported browsers.

## .NET client

The [.NET client](xref:signalr/dotnet-client) runs on any platform supported by ASP.NET Core. For example, [.NET Multi-platform App UI (.NET MAUI) developers can use SignalR](https://github.com/aspnet/Announcements/issues/305) for building Android and iOS apps.

If the server runs IIS, the WebSockets transport requires IIS 8.0 or later on Windows Server 2012 or later. Other transports are supported on all platforms.

## Java client

The [Java client](xref:signalr/java-client) supports Java 8 or later versions.

## Swift client

The [Swift client](xref:signalr/swift-client) supports Swift >= 5.10

## Unsupported clients

The following client is available for experimentation only, isn't currently supported, and may never be supported:

* [C++ client](https://github.com/aspnet/SignalR-Client-Cpp)

[!INCLUDE[](~/includes/SignalR/es6.md)]
