---
title: Get started with incremental ASP.NET to ASP.NET Core migration
description: Get started with incremental ASP.NET to ASP.NET Core migration
author: rick-anderson
ms.author: riande
monikerRange: '>= aspnetcore-6.0'
ms.date: 11/9/2022
ms.topic: article
ms.prod: aspnet-core
uid: migration/inc/start
---

# Get started with incremental ASP.NET to ASP.NET Core migration

For a large migration, we recommend setting up a ASP.NET Core app that proxies to the original .NET Framework app. The new proxy enabled app is shown in the following image:

![start migrating routes](~/migration/inc/overview/static/nop.png)

To understand how this approach is helpful in the migration process, see [Incremental ASP.NET to ASP.NET Core migration](xref:migration/inc/overview). The rest of this article provides the steps to proceed with an incremental migration.

## Set up ASP.NET Core Project

For ASP.NET MVC and Web API apps, see <xref:migration/mvc>.
For ASP.NET Framework Web Forms apps, see <xref:migration/web_forms>.

## Upgrade supporting libraries

If you have supporting libraries in your solution that you will need to use, they should be upgraded to .NET Standard 2.0, if possible.  [Upgrade Assistant](https://github.com/dotnet/upgrade-assistant) is a great tool for this. If libraries are unable to target .NET Standard, you can target .NET 6 or later either along with the .NET Framework target in the original project or in a new project alongside the original.

The [adapters](xref:migration/inc/adapters) can be used in these libraries to enable support for `System.Web.HttpContext` usage in class libraries. In order to enable `System.Web.HttpContext` usage in a library:

1. Remove reference to `System.Web` in the project file
1. Add the `Microsoft.AspNetCore.SystemWebAdapters` package
1. Enable multi-targeting and add a .NET 6 target or later, or convert the project to .NET Standard 2.0.
1. Ensure the target framework supports .NET Core. Multi-targeting can be used if .NET Standard 2.0 is not sufficient

This step may require a number of projects to change depending on your solution structure. Upgrade Assistant can help you identify which ones need to change and automate a number of steps in the process.

## Enable Session Support

Session is a commonly used feature of ASP.NET that shares the name with a feature in ASP.NET Core the APIs are much different. See the documentation on [session support](xref:migration/inc/session).

## Enable shared authentication support

It is possible to share authentication between the original ASP.NET app and the new ASP.NET Core app by using the `System.Web` adapters remote authentication feature. This feature allows the ASP.NET Core app to defer authentication to the ASP.NET app. See the [remote app connection](xref:migration/inc/remote-app-setup) and [remote authentication](xref:migration/inc/remote-authentication) docs for more details.

## General Usage Guidance

There are a number of differences between ASP.NET and ASP.NET Core that the adapters are able to help update. However, there are some features that require an opt-in as they incur some cost. There are also behaviors that cannot be adapted. See [usage guidance](xref:migration/inc/usage_guidance) for a list of these.
