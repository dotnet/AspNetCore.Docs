---
uid: whitepapers/aspnet-mvc2-upgrade-notes
title: "Upgrading an ASP.NET MVC 1.0 Application to ASP.NET MVC 2 | Microsoft Docs"
author: rick-anderson
description: "This document describes both how to upgrade manually and with a wizard an ASP.NET MVC 1.0 Application to ASP.NET MVC 2. This document is also available for d..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 04/08/2010
ms.topic: article
ms.assetid: f1a01759-d251-4b09-8835-e112e336c6dd
ms.technology: 
ms.prod: .net-framework
msc.legacyurl: /whitepapers/aspnet-mvc2-upgrade-notes
msc.type: content
---
Upgrading an ASP.NET MVC 1.0 Application to ASP.NET MVC 2
====================
> This document describes both how to upgrade manually and with a wizard an ASP.NET MVC 1.0 Application to ASP.NET MVC 2. This document is also available for [Download](https://download.microsoft.com/download/F/1/6/F16F9AF9-8EF4-4845-BC97-639791D5699C/MVC2-Upgrade-Notes.pdf)


## Introduction

ASP.NET MVC 2 can be installed side by side with ASP.NET MVC 1.0 on the same server. This gives application developers flexibility in choosing when to upgrade an ASP.NET MVC 1.0 application to ASP.NET MVC 2.

Visual Studio 2010 includes a wizard that upgrades existing ASP.NET MVC 1.0 projects built with Visual Studio 2008 to ASP.NET MVC 2. The upgrade wizard is initiated by opening an ASP.NET MVC 1.0 project in Visual Studio 2010.

## Upgrade Wizard for ASP.NET MVC 1.0 on Visual Studio 2008 SP1

To upgrade an ASP.NET MVC 1.0 application to ASP.NET MVC 2 in Visual Studio 2008 SP1, use the (unsupported) MvcAppConverter application. You can download this application from the following URL:

[https://go.microsoft.com/fwlink/?LinkID=185351](https://go.microsoft.com/fwlink/?LinkID=185351)

## Manually Upgrading an ASP.NET MVC 1.0 Project

To manually upgrade an existing ASP.NET MVC 1.0 application to version 2, follow these steps:

1. Make a backup of the existing project.
2. In a text editor, open the project file (the file with the .csproj or .vbproj file extension) and find the ProjectTypeGuid element. As the value of that element, replace the GUID {603c0e0b-db56-11dc-be95-000d561079b0} with {F85E285D-A4E0-4152-9332-AB1D724D3325}. When you are done, the value of that element should be as follows: 

    `{F85E285D-A4E0-4152-9332-AB1D724D3325};{349c5851-65df-11da-9384-00065b846f21};{fae04ec0-301f-11d3-bf4b-00c04f79efbc}`
3. In the Web application root folder, edit the Web.config file. Search for System.Web.Mvc, Version=1.0.0.0 and replace all instances with System.Web.Mvc, Version=2.0.0.0.
4. Repeat the previous step for the Web.config file located in the Views folder.
5. Open the project using Visual Studio, and in **Solution Explorer**, expand the **References** node. Delete the reference to System.Web.Mvc (which points to the version 1.0 assembly). Add a reference to System.Web.Mvc (v2.0.0.0).
6. Add the following bindingRedirect element to the Web.config file in the application root under the configuraton section:   

    [!code-xml[Main](aspnet-mvc2-upgrade-notes/samples/sample1.xml)]
7. Create a new empty ASP.NET MVC 2 application. Copy the files from the Scripts folder of the new application into the Scripts folder of the existing application.
8. Update the existing applicationâ€™s CSS file with the CSS style definitions in the Site.css file.
9. Compile the application and run it. If any errors occur, refer to the Breaking Changes section of the [What's New in ASP.NET MVC 2](https://go.microsoft.com/fwlink/?LinkID=185038) page.