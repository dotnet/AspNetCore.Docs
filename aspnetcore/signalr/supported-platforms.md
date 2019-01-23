---
title: ASP.NET Core SignalR supported platforms
author: bradygaster
description: Learn about the supported platforms for ASP.NET Core SignalR.
monikerRange: '>= aspnetcore-2.1'
ms.author: bradyg
ms.custom: mvc
ms.date: 11/12/2018
uid: signalr/supported-platforms
---
# ASP.NET Core SignalR supported platforms

## Server system requirements

SignalR for ASP.NET Core supports any server platform that ASP.NET Core supports.

## JavaScript client

The [JavaScript client](https://www.npmjs.com/package/@aspnet/signalr) runs on NodeJS 8 and later versions and the following browsers:

| Browser                         | Version |
| ------------------------------- | ------- |
| Microsoft Edge                  | current |
| Mozilla Firefox                 | current |
| Google Chrome; includes Android | current |
| Safari; includes iOS            | current |
| Microsoft Internet Explorer     | 11      |
 
## .NET client

The [.NET client](https://www.nuget.org/packages/Microsoft.AspNetCore.SignalR/) runs on any platform supported by ASP.NET Core. For example, [Xamarin developers can use SignalR](https://github.com/aspnet/Announcements/issues/305) for building Android apps using Xamarin.Android 8.4.0.1 and later and iOS apps using Xamarin.iOS 11.14.0.4 and later.

If the server runs IIS, the WebSockets transport requires IIS 8.0 or higher on Windows Server 2012 or higher. Other transports are supported on all platforms.

## Java client

The [Java client](https://search.maven.org/artifact/com.microsoft.aspnet/signalr) supports Java 8 and later versions.

## Unsupported clients

The following clients are available but are experimental or unofficial. They aren't currently supported and may never be.

* [C++ client](https://github.com/aspnet/SignalR/tree/master/clients/cpp)

* [Swift client](https://github.com/moozzyk/SignalR-Client-Swift)
