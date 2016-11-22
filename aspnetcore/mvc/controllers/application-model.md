---
title: 🔧 Working with the Application Model | Microsoft Docs
author: ardalis
description: 
keywords: ASP.NET Core, ASP.NET Core MVC, application model
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: 4eb7e52f-5665-41a4-a3e3-e348d07237f2
ms.technology: aspnet
ms.prod: aspnet-core
uid: mvc/controllers/application-model
---
# Working with the Application Model

By [Steve Smith](http://ardalis.com)

ASP.NET Core MVC defines an *application model* representing the components your MVC app. You can read and manipulate this model to modify how MVC elements behave.

## Models and Conventions

The ASP.NET Core MVC application models include both abstract interfaces and concrete implementations that define how MVC behaves. This behavior includes how MVC works with controller names, action names, action parameters, routes, and filters. By working with the application model, you can modify your app to follow different conventions, or provide a mechanism to explore your app (for instance, to provide dynamic documentation of its API).

