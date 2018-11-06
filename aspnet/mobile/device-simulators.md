---
uid: mobile/device-simulators
title: "Simulate Popular Mobile Devices for Testing | Microsoft Docs"
author: rick-anderson
description: "You can download emulators for popular mobile devices and browsers by following these links"
ms.author: riande
ms.date: 10/11/2018
ms.assetid: bfb5612e-c3ec-4f28-b43b-63d781aa2272
msc.legacyurl: /mobile/device-simulators
msc.type: content
---
# Simulate Popular Mobile Devices for Testing

> You can download emulators for popular mobile devices and browsers by following these links.

| Device or Browser | Emulator / Simulator |
| --- | --- |
| BrowserStack Hosted Browser Virtualization ![BrowserStack Hosted Browser Virtualization](device-simulators/_static/image1.png) | [BrowserStack Hosted Browser Virtualization](http://browserstack.com) Test your local or production environment in any browser on any platform. You can create a tunnel between your machine and the BrowserStack network in your own hosted virtual machine. Make sure to get the [BrowserStack Visual Studio Extension](https://marketplace.visualstudio.com/items?itemName=browserstackcom.BrowserStack) for an even more seamless experience. |
| iPhone / iPod / iPad | [Electric Mobile Studio](http://www.electricplum.com/studio.aspx) iPhone and iPad Simulators for Windows, as well as a Responsive design tool. |
| Android | [Android Studio](https://developer.android.com/studio/) or [Visual Studio Emulator for Android](https://visualstudio.microsoft.com/vs/msft-android-emulator/) |
| Opera Mobile | [Opera Mobile Classic Emulator](https://www.opera.com/developer/mobile-emulator) |
| Windows Mobile 6.5.3 | [Windows Mobile 6.5.3 Developer Tool Kit](https://www.microsoft.com/downloads/en/details.aspx?FamilyID=c0213f68-2e01-4e5c-a8b2-35e081dcf1ca&amp;displaylang=en) Note that to give the phone network access, you also need the VPC Network Adaptor included in [Virtual PC 2007](https://www.microsoft.com/downloads/en/details.aspx?FamilyID=04d26402-3199-48a3-afa2-2dc0b40a73b6&amp;DisplayLang=en). To connect IE on the phone to your Visual Studio development server, see [Kiran Patil's blog post](http://kiranpatils.wordpress.com/2009/11/19/access-internetlocal-website-from-your-windows-mobile-device-emulators/). |

> [!NOTE]
> If you want to view your application on a real mobile device (which is the only option for fully testing iPhone or iPad, since there's no true emulator for Windows) you'll need to host your application in IIS or IIS Express. You can't easily use Visual Studio's built-in web server for this, because it won't respond to requests from other machines.