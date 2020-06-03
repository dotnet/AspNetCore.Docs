---
title: ASP.NET Core SignalR supported platforms
author: bradygaster
description: Learn about the supported platforms for ASP.NET Core SignalR.
monikerRange: '>= aspnetcore-2.1'
ms.author: bradyg
ms.custom: mvc
ms.date: 01/16/2020
no-loc: [Blazor, "Identity", "Let's Encrypt", Razor, SignalR]
uid: signalr/supported-platforms
---
# ASP.NET Core SignalR supported platforms

## Server system requirements

SignalR for ASP.NET Core supports any server platform that ASP.NET Core supports.

## JavaScript client

The [JavaScript client](xref:signalr/javascript-client) runs on NodeJS 8 and later versions and the following browsers:

| Browser                         | Version         |
| ------------------------------- | --------------- |
| Microsoft Edge                  | Current&dagger; |
| Mozilla Firefox                 | Current&dagger; |
| Google Chrome; includes Android | Current&dagger; |
| Safari; includes iOS            | Current&dagger; |
| Microsoft Internet Explorer     | 11              |

&dagger;*Current* refers to the latest version of the browser.

## .NET client

The [.NET client](xref:signalr/dotnet-client) runs on any platform supported by ASP.NET Core. For example, [Xamarin developers can use SignalR](https://github.com/aspnet/Announcements/issues/305) for building Android apps using Xamarin.Android 8.4.0.1 and later and iOS apps using Xamarin.iOS 11.14.0.4 and later.

If the server runs IIS, the WebSockets transport requires IIS 8.0 or later on Windows Server 2012 or later. Other transports are supported on all platforms.

## Java client

The [Java client](xref:signalr/java-client) supports Java 8 and later versions.

## Unsupported clients

The following clients are available but are experimental or unofficial. They aren't currently supported and may never be.

* [C++ client](https://github.com/aspnet/SignalR-Client-Cpp)

* [Swift client](https://github.com/moozzyk/SignalR-Client-Swift)
