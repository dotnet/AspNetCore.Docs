---
uid: mobile/device-simulators
title: "Simulate Popular Mobile Devices for Testing | Microsoft Docs"
author: rick-anderson
description: "You can download emulators for popular mobile devices and browsers by following these links"
ms.author: aspnetcontent
manager: wpickett
ms.date: 01/28/2011
ms.topic: article
ms.assetid: bfb5612e-c3ec-4f28-b43b-63d781aa2272
ms.technology: 
ms.prod: .net-framework
msc.legacyurl: /mobile/device-simulators
msc.type: content
---
Simulate Popular Mobile Devices for Testing
====================
> You can download emulators for popular mobile devices and browsers by following these links


| Device or Browser | Emulator / Simulator |
| --- | --- |
| BrowserStack Hosted Browser Virtualization ![BrowserStack Hosted Browser Virtualization](device-simulators/_static/image1.png) | [BrowserStack Hosted Browser Virtualization](http://browserstack.com) Test your local or production environment in any browser on any platform. You can create a tunnel between your machine and the BrowserStack network in your own hosted virtual machine. Make sure to get the [BrowserStack Visual Studio Extension](https://visualstudiogallery.msdn.microsoft.com/2dfa32b1-3c47-439d-b1c5-9e28be18b81c) for an even more seamless experience. |
| Windows Phone | [Windows Phone SDK Downloads](https://dev.windowsphone.com/en-us/downloadsdk) The Windows Phone Software Development Kit (SDK) includes all of the tools that you need to develop apps and games for Windows Phone |
| iPhone / iPod / iPad | [Electric Plum](http://www.electricplum.com/studio.aspx) iPhone and iPad Simulators for Windows, as well as a Responsive design tool. Can integrate with VS 2012 "Browse With.." option. |
| Android | [Android SDK homepage](https://developer.android.com/sdk) |
| Opera Mobile / Opera Mini | Latest versions: [Opera Developer Tools home](http://www.opera.com/developer/tools/) Opera Mini 4.2: [Online Java-based simulator](http://www.opera.com/mobile/demo/?ver=4) |
| Windows Mobile 6.5.3 | [Windows Mobile 6.5.3 Developer Tool Kit](https://www.microsoft.com/downloads/en/details.aspx?FamilyID=c0213f68-2e01-4e5c-a8b2-35e081dcf1ca&amp;displaylang=en) Note that to give the phone network access, you also need the VPC Network Adaptor included in [Virtual PC 2007](https://www.microsoft.com/downloads/en/details.aspx?FamilyID=04d26402-3199-48a3-afa2-2dc0b40a73b6&amp;DisplayLang=en). To connect IE on the phone to your Visual Studio development server, see [Kiran Patil's blog post](http://kiranpatils.wordpress.com/2009/11/19/access-internetlocal-website-from-your-windows-mobile-device-emulators/). |
| Windows Mobile 6.1 | [Emulator images for Visual Studio 2005/2008](https://www.microsoft.com/downloads/en/details.aspx?FamilyID=3d6f581e-c093-4b15-ab0c-a2ce5bffdb47) |

Note that if you want to view your application on a real mobile device (which is the only option for fully testing iPhone or iPad, since there's no true emulator for Windows) you'll need to host your application in IIS or IIS Express. You can't easily use Visual Studio's built-in web server for this, because it won't respond to requests from other machines.