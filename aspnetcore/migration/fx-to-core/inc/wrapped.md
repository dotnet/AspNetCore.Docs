---
title: Wrapped ASP.NET Core session state
description: Wrapped ASP.NET Core session state
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-6.0'
ms.date: 2/24/2025
ms.topic: article
uid: migration/fx-to-core/inc/wrapped
---

# Wrapped ASP.NET Core session state

The [AddWrappedAspNetCoreSession](https://github.com/dotnet/systemweb-adapters/blob/main/src/Microsoft.AspNetCore.SystemWebAdapters.CoreServices/SessionState/Wrapped/WrappedSessionExtensions.cs) implementation wraps the session provided on ASP.NET Core so that it can be used with the adapters. The session uses the same backing store as [`Microsoft.AspNetCore.Http.ISession`](/dotnet/api/microsoft.aspnetcore.http.isession) but provides strongly-typed access to its members.

Configuration for ASP.NET Core looks similar to the following:

:::code language="csharp" source="~/migration/fx-to-core/inc/samples/wrapped/Program.cs" id="snippet_WrapAspNetCoreSession" :::

The framework app doesn't need any changes to enable this behavior.

For more information, see the [AddWrappedAspNetCoreSession sample app](https://github.com/dotnet/systemweb-adapters/blob/main/samples/CoreApp/Program.cs)
