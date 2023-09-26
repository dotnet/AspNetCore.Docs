---
title: Wrapped ASP.NET Core session state
description: Wrapped ASP.NET Core session state
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-6.0'
ms.date: 11/9/2022
ms.topic: article
ms.prod: aspnet-core
uid: migration/inc/wrapped
---

# Wrapped ASP.NET Core session state

This implementation wraps the session provided on ASP.NET Core so that it can be used with the adapters. The session will be using the same backing store as `Microsoft.AspNetCore.Http.ISession` but will provide strongly-typed access to its members.

Configuration for ASP.NET Core would look similar to the following:

:::code language="csharp" source="~/migration/inc/samples/wrapped/Program.cs" id="snippet_WrapAspNetCoreSession" :::

The framework app would not need any changes to enable this behavior.
