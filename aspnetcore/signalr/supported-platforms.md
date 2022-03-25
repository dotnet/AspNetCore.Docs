---
title: ASP.NET Core SignalR supported platforms
author: bradygaster
description: Learn about the supported platforms for ASP.NET Core SignalR.
monikerRange: '>= aspnetcore-3.1'
ms.author: bradyg
ms.custom: mvc, devx-track-js
ms.date: 09/15/2021
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: signalr/supported-platforms
---
# ASP.NET Core SignalR supported platforms

## Server system requirements

SignalR for ASP.NET Core supports any server platform that ASP.NET Core supports.

## JavaScript client

The [JavaScript client](xref:signalr/javascript-client) runs on the current [Node.js long-term support (LTS) release](https://nodejs.org/about/releases/) and the following browsers:

| Browser                          | Version         |
| -------------------------------- | --------------- |
| Apple Safari, including iOS      | Current&dagger; |
| Google Chrome, including Android | Current&dagger; |
| Microsoft Edge                   | Current&dagger; |
| Mozilla Firefox                  | Current&dagger; |

&dagger;*Current* refers to the latest version of the browser.

The JavaScript client doesn't support Internet Explorer and other older browsers. The client might have unexpected behavior and errors on unsupported browsers.

## .NET client

The [.NET client](xref:signalr/dotnet-client) runs on any platform supported by ASP.NET Core. For example, [Xamarin developers can use SignalR](https://github.com/aspnet/Announcements/issues/305) for building Android apps using Xamarin.Android 8.4.0.1 and later and iOS apps using Xamarin.iOS 11.14.0.4 and later.

If the server runs IIS, the WebSockets transport requires IIS 8.0 or later on Windows Server 2012 or later. Other transports are supported on all platforms.

## Java client

The [Java client](xref:signalr/java-client) supports Java 8 and later versions.

## Unsupported clients

The following clients are available but are experimental or unofficial. The following clients aren't currently supported and may never be supported:

* [C++ client](https://github.com/aspnet/SignalR-Client-Cpp)
* [Swift client](https://github.com/moozzyk/SignalR-Client-Swift)
