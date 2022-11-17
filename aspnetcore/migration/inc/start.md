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

In order to start a large migration, we recommend setting up a ASP.NET Core app that will proxy to the original .NET Framework app. This set up will look like this:

![final pic](~/migration/inc/overview/static/final.png)

To understand how this is helpful in the migration process, please refer to the [introduction](README.md). The rest of this document will provide the steps to set this up and how to proceed with an incremental migration.

## Set up ASP.NET Core Project

1. Install the [experimental Visual Studio extension](https://marketplace.visualstudio.com/items?itemName=WebToolsTeam.aspnetprojectmigrations) that helps configure the solution.
2. Right click the ASP.NET Framework app and select **Migrate Project**:
   ![Migrate Menu](~/migration/inc/start/static/migrate_menu.png)
1. This will open a menu that will offter to start a migration. Click the link to begin:
   ![Migrate Options](~/migration/inc/start/static/migrate_options.png)
1. A wizard will now appear that allows you to create a new project or select an existing project.
   ![Migrate Wizard](~/migration/inc/start/static/migrate_wizard.png)
1. After completing the wizard, you have an ASP.NET Core project that proxies requests that do not exist there onto the ASP.NET Framework app.

## Upgrade supporting libraries

If you have supporting libraries in your solution that you will need to use, they should be upgraded to support .NET 6 or later<!--Review -->. [Upgrade Assistant](https://github.com/dotnet/upgrade-assistant) is a great tool for this.

The adapters in this project can be used in these libraries to enable support for `System.Web.HttpContext` usage that you may have in class libraries. In order to enable this in a library:

1. Remove reference to `System.Web` in the project file
2. Add the `Microsoft.AspNetCore.SystemWebAdapters` package
3. Enable multi-targeting and add a .NET 6 target, or convert the project to .NET Standard

This step may require a number of projects to change depending on your solution structure. Upgrade Assistant can help you identify which ones need to change and automate a number of steps in the process.

## Enable Session Support

Session is a commonly used feature of ASP.NET that shares a name with a feature in ASP.NET Core but that's where the similarity ends. Please see the documentation on [session support](session-state/session.md) to understand how to use it.

## Enable shared authentication support

It is possible to share authentication between the original ASP.NET app and the new ASP.NET Core app by using the System.Web adapters remote authentication feature. This feature allows the ASP.NET Core app to defer authentication to the ASP.NET app. Please see the [remote app connection](remote-app-setup.md) and [remote authentication]((remote-authentication/remote-authentication.md)) docs for more details.

## General Usage Guidance

There are a number of differences between ASP.NET and ASP.NET Core that the adapters are able to smooth over. However, there are some features that require an opt-in as it will incur some cost. There are also behavior that cannot be adapted. Please see [usage guidance](usage_guidance.md) to see a list of these.