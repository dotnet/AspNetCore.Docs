---
uid: web-forms/overview/deployment/deploying-web-applications-in-enterprise-scenarios/deploying-web-applications-in-enterprise-scenarios
title: "Deploying Web Applications in Enterprise Scenarios using Visual Studio 2010 | Microsoft Docs"
author: jrjlee
description: "This set of tutorials describes tools and techniques you can use to deploy web applications in various enterprise scenarios. It explains how to make best use..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 05/03/2012
ms.topic: article
ms.assetid: 48cfe378-d62a-48c6-a4db-6be3cead6898
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/deployment/deploying-web-applications-in-enterprise-scenarios/deploying-web-applications-in-enterprise-scenarios
msc.type: authoredcontent
---
Deploying Web Applications in Enterprise Scenarios using Visual Studio 2010
====================
by [Jason Lee](https://github.com/jrjlee)

[Download PDF](https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/00/63/56/8130.DeployingWebAppsInEnterpriseScenarios.pdf)

> This set of tutorials describes tools and techniques you can use to deploy web applications in various enterprise scenarios. It explains how to make best use of technologies like Visual Studio 2010, the Microsoft Build Engine (MSBuild), Internet Information Services (IIS) 7.5, the IIS Web Deployment Tool (Web Deploy), the Web Farm Framework (WFF), and utilities like VSDBCMD.exe to simplify and manage the deployment process. It includes conceptual overviews and task-oriented guidance that will help you to:
> 
> - Review and establish the deployment requirements for an enterprise-scale web application.
> - Configure test, staging, and production web server environments to support web deployment.
> - Configure Team Foundation Server (TFS) continuous integration (CI) processes to support automated web deployment.
> - Deploy enterprise-scale web applications to different server environments with varying requirements and restrictions.
> - Deploy changes to web applications that are running in different server environments.
> 
> > [!NOTE]
> > While these tutorials describe the use of TFS as a CI server, the guidance is easily adapted to any CI server. You don't need a detailed knowledge of TFS to understand and leverage the tutorials.
> 
> 
> For an Italian translation of these tutorials, visit [http://www.lucamorelli.it](http://www.lucamorelli.it).


## About the Authors

Jason Lee is a principal technologist with [Content Master](http://www.contentmaster.com/) where he has been working with Microsoft products and technologies, especially SharePoint and ASP.NET, for several years. Jason holds a PhD in computing and is currently MCPD and MCTS certified. You can read Jason's technical blog at [www.jrjlee.com](http://www.jrjlee.com/).

Benjamin Curry is a principal technologist with [Content Master](http://www.contentmaster.com/) who has written whitepapers, SDK documentation, PowerPoint presentations, and instructor-led and online training courses during his career. An original member of the ASP.NET documentation team, he has worked with Microsoft's web technologies for over a decade.

## Target Audience

This set of tutorials is for ASP.NET web application developers and solution architects who use Visual Studio 2010 to create enterprise-scale web applications. To get the most value from the content, you should be comfortable using Visual Studio 2010 and have a basic familiarity with TFS, together with an awareness of Microsoft web platform technologies like ASP.NET MVC 3, Windows Communication Foundation (WCF), IIS, SQL Server, and Visual Studio database projects. However, you do not need to be familiar with deployment tools and technologies or need to know how to set up CI systems.

## Requirements

To follow the walkthroughs and perform the tasks that these tutorials describe, you'll need to install this software on your development computer:

- Visual Studio 2010 Premium or Ultimate Edition with Service Pack 1
- .NET Framework 4.0
- .NET Framework 3.5 with Service Pack 1
- ASP.NET MVC 3.0
- IIS 7.5 Express
- SQL Server Express 2008 R2

To perform the deployment steps described throughout these walkthroughs, you'll need to have access to sample Web application deployment environments. For best results, these environments should reflect your organization's enterprise deployment pattern. You can then modify the walkthroughs provided in this documentation to reflect the deployment environments and requirements of your own organization.

## Series Contents

This introductory section consists of two further topics. These are designed to provide some broader context for the tutorials that follow:

- [Enterprise Web Deployment: Scenario Overview](enterprise-web-deployment-scenario-overview.md). This topic describes the scenario that underpins each of the tutorials in this series. The scenario focuses on the Application Lifecycle Management (ALM) requirements of a fictional company named Fabrikam, Inc. as it develops an enterprise-scale web application.
- [Application Lifecycle Management: From Development to Production](application-lifecycle-management-from-development-to-production.md). This topic provides a high-level, end-to-end overview of a deployment process. It illustrates how Fabrikam,Inc. moves an enterprise-scale ASP.NET web application through test, staging, and production environments as part of a continuous development process.

The series includes four tutorial sets. Each focuses on different aspects of web deployment:

- [Web Deployment in the Enterprise](../web-deployment-in-the-enterprise/web-deployment-in-the-enterprise.md). This tutorial provides a conceptual introduction to MSBuild project files, the Web Publishing Pipeline, Web Deploy, and other related technologies. It explains how you can use these tools together to manage complex deployment processes.
- [Configuring Server Environments for Web Deployment](../configuring-server-environments-for-web-deployment/configuring-server-environments-for-web-deployment.md). This tutorial describes how to configure Windows servers to support various deployment scenarios, including remote web package deployment using the Web Deployment Agent Service (the "remote agent") or the Web Deploy Handler and remote database deployment. It provides guidance on choosing the appropriate deployment method for your own environment, and it describes how to use the WFF to replicate deployed web applications across all the web servers in a server farm.
- [Configuring Team Foundation Server for Web Deployment](../configuring-team-foundation-server-for-web-deployment/configuring-team-foundation-server-for-web-deployment.md). This tutorial describes how to configure TFS to support various deployment scenarios, including automated deployment as part of a CI process and manually triggered deployments of specific builds.
- [Advanced Enterprise Web Deployment](../advanced-enterprise-web-deployment/advanced-enterprise-web-deployment.md). This tutorial describes how to accomplish various more advanced deployment tasks, like customizing database deployments for multiple environments, excluding files and folders from deployment, and taking web applications offline during the deployment process.

## Where to Start

This set of tutorials uses a sample solution with a realistic level of complexity, together with a fictional enterprise deployment scenario, to provide a reference implementation and to give the tasks and walkthroughs a common context. The next topic, [Enterprise Web Deployment: Scenario Overview](enterprise-web-deployment-scenario-overview.md), introduces the scenario and the sample solution. From there you can work through the tutorials and topics that most closely match your needs.

>[!div class="step-by-step"]
[Next](enterprise-web-deployment-scenario-overview.md)