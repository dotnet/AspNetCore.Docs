---
uid: web-forms/overview/deployment/configuring-team-foundation-server-for-web-deployment/configuring-team-foundation-server-for-web-deployment
title: "Configuring Team Foundation Server for Web Deployment | Microsoft Docs"
author: jrjlee
description: "This tutorial will show you how to configure Team Foundation Server (TFS) 2010 to build solutions and deploy web content to various target environments. This..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 05/04/2012
ms.topic: article
ms.assetid: ff55233a-e795-4007-a4fc-861fe1bb590b
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/deployment/configuring-team-foundation-server-for-web-deployment/configuring-team-foundation-server-for-web-deployment
msc.type: authoredcontent
---
Configuring Team Foundation Server for Web Deployment
====================
by [Jason Lee](https://github.com/jrjlee)

[Download PDF](https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/00/63/56/8130.DeployingWebAppsInEnterpriseScenarios.pdf)

> This tutorial will show you how to configure Team Foundation Server (TFS) 2010 to build solutions and deploy web content to various target environments. This includes continuous integration (CI) scenarios, where you deploy content automatically every time a developer makes a change. It can also include manual trigger scenarios, where an administrator may want to trigger deployment of a specific build to a staging environment once the build has been verified and validated in the test environment. The topics in this tutorial will guide you through the entire configuration process, including:
> 
> - How to create a new team project in TFS.
> - How to add content to source control.
> - How to configure a build server to support CI and deployment.
> - How to create a build definition that includes deployment logic.
> - How to configure permissions for automated deployment.
> 
> For an Italian translation of these tutorials, visit [http://www.lucamorelli.it](http://www.lucamorelli.it).


This tutorial assumes that you have installed TFS 2010 and created a team project collection as part of the initial configuration process. The [Team Foundation Installation Guide for Visual Studio 2010](https://go.microsoft.com/?linkid=9805132) provides comprehensive guidance on these tasks.

## Context

This forms part of a series of tutorials based on the enterprise deployment requirements of a fictional company named Fabrikam, Inc. This tutorial series uses a sample solution&#x2014;the [Contact Manager](../web-deployment-in-the-enterprise/the-contact-manager-solution.md) solution&#x2014;to represent a web application with a realistic level of complexity, including an ASP.NET MVC 3 application, a Windows Communication Foundation (WCF) service, and a database project.

The deployment method at the heart of these tutorials is based on the split project file approach described in [Understanding the Build Process](../web-deployment-in-the-enterprise/understanding-the-build-process.md), in which the build process is controlled by two project files&#x2014;one containing build instructions that apply to every destination environment, and one containing environment-specific build and deployment settings. At build time, the environment-specific project file is merged into the environment-agnostic project file to form a complete set of build instructions.

## Scenario Overview

The high-level scenario for these tutorials is described in [Enterprise Web Deployment: Scenario Overview](../deploying-web-applications-in-enterprise-scenarios/enterprise-web-deployment-scenario-overview.md). We recommend that you review this topic before you get started on this tutorial.

## How to Use This Tutorial

If this is the first time you've performed the tasks described in this tutorial, or if you want to follow the examples using the sample solution, you should work through the tutorial topics in order. Alternatively, you can use individual topics as guidance for specific tasks. This tutorial includes these topics:

- [Creating a Team Project in TFS](creating-a-team-project-in-tfs.md). A team project is the core unit for source control, process management, and build in TFS. You need to create a team project before you can add content to source control or create build definitions.
- [Adding Content to Source Control](adding-content-to-source-control.md). Once you've created a team project, you can start adding content to source control. You'll need to add your projects and solutions, together with any external dependencies, before you can start configuring builds.
- [Configuring a TFS Build Server for Web Deployment](configuring-a-tfs-build-server-for-web-deployment.md). If you want to build your team project content, you'll need to configure a build server. In most cases, this should be on a separate machine from your TFS installation. To configure a build server, you need to install and configure the TFS build service, install Visual Studio 2010, create build controllers and build agents, install any products or components that your code needs in order to build successfully, and install the Internet Information Services (IIS) Web Deployment Tool (Web Deploy).
- [Creating a Build Definition That Supports Deployment](creating-a-build-definition-that-supports-deployment.md). Before you can start queuing or triggering builds in TFS, you need to create at least one build definition for your team project. The build definition defines every aspect of the build, including which things should be included in the build, what should trigger the build, and where Team Build should send the build outputs. You can configure a build definition to run custom Microsoft Build Engine (MSBuild) project files, which lets you include deployment logic in your automated builds.
- [Deploying a Specific Build](deploying-a-specific-build.md). In a lot of scenarios, you'll want to deploy a specific build, rather than the latest build, to a target environment. In this case, you can configure a build definition that deploys content from a specific drop folder.
- [Configuring Permissions for Team Build Deployment](configuring-permissions-for-team-build-deployment.md). If the build service is to deploy content as part of an automated build process, you need to grant various permissions to the build service account on any destination web servers and database servers.

## Key Technologies

This tutorial focuses on how to use these products and technologies to support automated build and web deployment:

- Visual Studio Team Foundation Server 2010
- Team Build and MSBuild
- Web Deploy

The tutorial also touches on the use of Windows Server 2008 R2, IIS 7.5, SQL Server 2008 R2, ASP.NET 4.0, and ASP.NET MVC 3.

## Other Tutorials in This Series

This forms part of a series of five tutorials on enterprise-scale web deployment. These are the other tutorials in the series:

- [Deploying Web Applications in Enterprise Scenarios](../deploying-web-applications-in-enterprise-scenarios/deploying-web-applications-in-enterprise-scenarios.md). This introductory content provides the contextual background for the tutorial series. It describes the tutorial scenario, and it illustrates how the tasks and walkthroughs described throughout the series fit into a broader Application Lifecycle Management (ALM) process.
- [Web Deployment in the Enterprise](../web-deployment-in-the-enterprise/web-deployment-in-the-enterprise.md). This tutorial provides a conceptual introduction to MSBuild project files, the Web Publishing Pipeline (WPP), Web Deploy, and other related technologies. It explains how you can use these tools together to manage complex deployment processes.
- [Configuring Server Environments for Web Deployment](../configuring-server-environments-for-web-deployment/configuring-server-environments-for-web-deployment.md). This tutorial describes how to configure Windows servers to support various deployment scenarios, including remote web package deployment using the Web Deployment Agent Service (the remote agent) or the Web Deploy Handler and remote database deployment. It provides guidance on choosing the appropriate deployment method for your own environment, and it describes how to use the Web Farm Framework (WFF) to replicate deployed web applications across all the web servers in a server farm.
- [Advanced Enterprise Web Deployment](../advanced-enterprise-web-deployment/advanced-enterprise-web-deployment.md). This tutorial describes how to accomplish various more advanced deployment tasks, like customizing database deployments for multiple environments, excluding files and folders from deployment, and taking web applications offline during the deployment process.

>[!div class="step-by-step"]
[Next](creating-a-team-project-in-tfs.md)