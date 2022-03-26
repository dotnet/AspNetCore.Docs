---
title: Use the React-with-Redux project template with ASP.NET Core
author: SteveSandersonMS
description: Learn how to get started with the ASP.NET Core Single Page Application (SPA) project template for React with Redux and create-react-app.
monikerRange: '>= aspnetcore-3.1'
ms.author: scaddie
ms.custom: mvc
ms.date: 02/15/2022
no-loc: [".NET MAUI", "Mac Catalyst", "Blazor Hybrid", Home, Privacy, Kestrel, appsettings.json, "ASP.NET Core Identity", cookie, Cookie, Blazor, "Blazor Server", "Blazor WebAssembly", "Identity", "Let's Encrypt", Razor, SignalR]
uid: spa/react-with-redux
---
# Use the React-with-Redux project template with ASP.NET Core

:::moniker range=">= aspnetcore-6.0"

> [!IMPORTANT]
> As of ASP.NET Core 6.0, the React-with-Redux project template is no longer included. For more information, see [React Redux: Dropping support in ASP.NET Core 6.0 (aspnet/Announcements #465)](https://github.com/aspnet/Announcements/issues/465).

:::moniker-end

:::moniker range="< aspnetcore-6.0"

The updated React-with-Redux project template provides a convenient starting point for ASP.NET Core apps using React, Redux, and [create-react-app](https://github.com/facebookincubator/create-react-app) (CRA) conventions to implement a rich, client-side user interface (UI).

With the exception of the project creation command, all information about the React-with-Redux template is the same as the React template. To create this project type, run `dotnet new reactredux` instead of `dotnet new react`. For more information about the functionality common to both React-based templates, see [React template documentation](xref:spa/react).

For information on configuring a React-with-Redux sub-application in IIS, see [ReactRedux Template 2.1: Unable to use SPA on IIS (aspnet/Templating &num;555)](https://github.com/aspnet/Templating/issues/555).

[!INCLUDE[](~/includes/spa-proxy.md)]    

:::moniker-end
