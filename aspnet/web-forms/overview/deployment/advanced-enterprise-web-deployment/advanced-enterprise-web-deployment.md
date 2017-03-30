---
uid: web-forms/overview/deployment/advanced-enterprise-web-deployment/advanced-enterprise-web-deployment
title: "Advanced Enterprise Web Deployment | Microsoft Docs"
author: jrjlee
description: "This tutorial will show you how to perform various tasks that are required or desirable in a lot of enterprise deployment scenarios. For an Italian translati..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 05/04/2012
ms.topic: article
ms.assetid: 7dcaba80-f2ec-4db3-ad98-daadc3afdb49
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/deployment/advanced-enterprise-web-deployment/advanced-enterprise-web-deployment
msc.type: authoredcontent
---
Advanced Enterprise Web Deployment
====================
by [Jason Lee](https://github.com/jrjlee)

[Download PDF](https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/00/63/56/8130.DeployingWebAppsInEnterpriseScenarios.pdf)

> This tutorial will show you how to perform various tasks that are required or desirable in a lot of enterprise deployment scenarios.
> 
> For an Italian translation of these tutorials, visit [http://www.lucamorelli.it](http://www.lucamorelli.it).


This forms part of a series of tutorials based around the enterprise deployment requirements of a fictional company named Fabrikam, Inc. This tutorial series uses a sample solution&#x2014;the [Contact Manager](../web-deployment-in-the-enterprise/the-contact-manager-solution.md) solution&#x2014;to represent a web application with a realistic level of complexity, including an ASP.NET MVC 3 application, a Windows Communication Foundation (WCF) service, and a database project.

The deployment method at the heart of these tutorials is based on the split project file approach described in [Understanding the Build Process](../web-deployment-in-the-enterprise/understanding-the-build-process.md), in which the build process is controlled by two project files&#x2014;one containing build instructions that apply to every destination environment, and one containing environment-specific build and deployment settings. At build time, the environment-specific project file is merged into the environment-agnostic project file to form a complete set of build instructions.

## Scenario Overview

The high-level scenario for these tutorials is described in [Enterprise Web Deployment: Scenario Overview](../deploying-web-applications-in-enterprise-scenarios/enterprise-web-deployment-scenario-overview.md). We recommend that you review this topic before you get started on this tutorial.

## How to Use This Tutorial

- Each of the topics in this tutorial is self-contained and addresses a particular challenge or problem that occurs in enterprise deployment scenarios. You don't need to work through these topics in any particular order. However, this tutorial covers some advanced tasks. As such, you should familiarize yourself with the concepts and techniques that the [Web Deployment in the Enterprise](../web-deployment-in-the-enterprise/web-deployment-in-the-enterprise.md) tutorial covers in order to gain the most benefit from this content.
- This tutorial includes these topics:
- [Performing a "What If" Deployment](performing-a-what-if-deployment.md). In a lot of scenarios, you'll want to determine the impact of a proposed deployment on a target environment or any existing content before you actually make any changes. This topic describes how you can run a "what if" deployment to generate log files and database update scripts as if you had deployed content to a target environment, without actually making any changes. Analyzing these resources can help you to spot any potential problems in advance of a live deployment.
- [Customizing Database Deployments for Multiple Environments](customizing-database-deployments-for-multiple-environments.md). When you deploy a database project to multiple destinations, you'll often want to customize the deployment properties for each target environment. For example, in test environments you'd typically recreate the database on every deployment, whereas in staging or production environments you'd be a lot more likely to make incremental updates to preserve your data. This topic describes how you can incorporate these property changes into your deployment logic by creating an environment-specific deployment configuration (.sqldeployment) file for each target environment.
- Deploying Database Role Memberships to Test Environments. When you recreate a database on every deployment&#x2014;for example, as part of a continuous integration (CI) build and deploy to a test environment&#x2014;you'll typically need to configure database role memberships every time. For example, you'll usually need to grant permissions to the application pool identity associated with your web application. This topic describes how you can automate this process by adding a post-deployment SQL script to your deployment logic.
- [Deploying Membership Databases to Enterprise Environments](deploying-membership-databases-to-enterprise-environments.md). ASP.NET membership databases have various characteristics that can complicate the deployment process. For example, a schema-only deployment will leave the database in a non-operational state. In most scenarios, it's preferable to create a membership database directly in each destination environment. However, if you do have to deploy a membership database, this topic describes some of the approaches you can use to meet the inherent challenges.
- [Excluding Files and Folders from Deployment](excluding-files-and-folders-from-deployment.md). In some scenarios, you'll want to tailor the contents of your web package to specific destination environments. For example, you might want to include full versions of JavaScript libraries when you deploy to a test environment, to support client-side debugging, but use minified versions of the libraries when you deploy to a staging or production environment. This topic describes how you can exclude specific files and folders from the package creation process.
- [Taking Web Applications Offline with Web Deploy](taking-web-applications-offline-with-web-deploy.md). When you deploy solutions to a staging or production environment, you'll often want to take your web applications offline for the duration of the deployment process. This topic describes how you can add an *App\_offline.htm* file to your web application at the start of the deployment process and remove it at the end. While the *App\_offline.htm* file is in place, any users who browse to the web application are automatically redirected to the *App\_offline.htm* file.
- [Running Windows PowerShell Scripts from MSBuild](running-windows-powershell-scripts-from-msbuild-project-files.md). Many deployment scenarios require more complex post-deployment actions, like adding custom event sources to the registry or configuring replication between SQL Server instances. These actions are often accomplished through Windows PowerShell scripts. This topic describes how to run Windows PowerShell scripts from a Microsoft Build Engine (MSBuild) project file as part of the build and deployment process.
- [Troubleshooting the Packaging Process](troubleshooting-the-packaging-process.md). The Web Publishing Pipeline (WPP) defines an MSBuild property named **EnablePackageProcessLoggingAndAssert** that you can use to generate in-depth information about the packaging process for web application projects. This topic describes what the property does and how to use it.

## Key Technologies

This tutorial focuses on how to use these products and technologies to support automated build and web deployment:

- Visual Studio 2010 and Team Foundation Server (TFS) 2010
- MSBuild and TFS Team Build
- Internet Information Services (IIS) 7.5
- IIS Web Deployment Tool (Web Deploy) 2.1
- The VSDBCMD.exe database deployment utility

## Other Tutorials in This Series

This forms part of a series of five tutorials on enterprise-scale web deployment. These are other tutorials in the series:

- [Deploying Web Applications in Enterprise Scenarios](../deploying-web-applications-in-enterprise-scenarios/deploying-web-applications-in-enterprise-scenarios.md). This introductory content provides the contextual background for the tutorial series. It describes the tutorial scenario, and it illustrates how the tasks and walkthroughs described throughout the series fit into a broader Application Lifecycle Management (ALM) process.
- [Web Deployment in the Enterprise](../web-deployment-in-the-enterprise/web-deployment-in-the-enterprise.md). This tutorial provides a conceptual introduction to MSBuild project files, the WPP, Web Deploy, and other related technologies. It explains how you can use these tools together to manage complex deployment processes.
- [Configuring Server Environments for Web Deployment](../configuring-server-environments-for-web-deployment/configuring-server-environments-for-web-deployment.md). This tutorial describes how to configure Windows servers to support various deployment scenarios, including remote web package deployment using the Web Deployment Agent Service (the remote agent) or the Web Deploy Handler and remote database deployment. It provides guidance on choosing the appropriate deployment method for your own environment, and it describes how to use the Web Farm Framework (WFF) to replicate deployed web applications across all the web servers in a server farm.
- [Configuring Team Foundation Server for Web Deployment](../configuring-team-foundation-server-for-web-deployment/configuring-team-foundation-server-for-web-deployment.md). This tutorial describes how to configure TFS to support various deployment scenarios, including automated deployment as part of a CI process and manually triggered deployments of specific builds.

>[!div class="step-by-step"]
[Next](performing-a-what-if-deployment.md)