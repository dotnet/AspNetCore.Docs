---
uid: web-forms/overview/deployment/configuring-server-environments-for-web-deployment/configuring-server-environments-for-web-deployment
title: "Configuring Server Environments for Web Deployment | Microsoft Docs"
author: jrjlee
description: "This tutorial will show you how to set up server environments to support one-click, or automated, website deployment and publishing in various different scen..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 05/04/2012
ms.topic: article
ms.assetid: 0bf0959b-4ca8-45de-bd13-b15347543b5a
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/deployment/configuring-server-environments-for-web-deployment/configuring-server-environments-for-web-deployment
msc.type: authoredcontent
---
Configuring Server Environments for Web Deployment
====================
by [Jason Lee](https://github.com/jrjlee)

[Download PDF](https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/00/63/56/8130.DeployingWebAppsInEnterpriseScenarios.pdf)

> This tutorial will show you how to set up server environments to support one-click, or automated, website deployment and publishing in various different scenarios. The tutorial includes topics to walk you through completing various tasks, like configuring a web server to support specific approaches to deployment and setting up a Web Farm Framework (WFF) server farm, together with scenario-based overviews that provide higher-level end-to-end guidance.
> 
> The tutorial uses the Fabrikam, Inc. deployment scenario described in [Enterprise Web Deployment: Scenario Overview](../deploying-web-applications-in-enterprise-scenarios/enterprise-web-deployment-scenario-overview.md) as a reference point for examples and network infrastructure.
> 
> For an Italian translation of these tutorials, visit [http://www.lucamorelli.it](http://www.lucamorelli.it).


This tutorial includes these topics:

- [Choosing the Right Approach to Web Deployment](choosing-the-right-approach-to-web-deployment.md)
- [Scenario: Configuring a Test Environment for Web Deployment](scenario-configuring-a-test-environment-for-web-deployment.md)
- [Scenario: Configuring a Staging Environment for Web Deployment](scenario-configuring-a-staging-environment-for-web-deployment.md)
- [Scenario: Configuring a Production Environment for Web Deployment](scenario-configuring-a-production-environment-for-web-deployment.md)
- [Configuring a Web Server for Web Deploy Publishing (Remote Agent)](configuring-a-web-server-for-web-deploy-publishing-remote-agent.md)
- [Configuring a Web Server for Web Deploy Publishing (Web Deploy Handler)](configuring-a-web-server-for-web-deploy-publishing-web-deploy-handler.md)
- [Configuring a Web Server for Web Deploy Publishing (Offline Deployment)](configuring-a-web-server-for-web-deploy-publishing-offline-deployment.md)
- [Configuring a Database Server for Web Deploy Publishing](configuring-a-database-server-for-web-deploy-publishing.md)
- [Creating a Server Farm with the Web Farm Framework](creating-a-server-farm-with-the-web-farm-framework.md)
- [Configuring Deployment Properties for a Target Environment](configuring-deployment-properties-for-a-target-environment.md)

The first topic, [Choosing the Right Approach to Web Deployment](choosing-the-right-approach-to-web-deployment.md), describes the main approaches you can use to publish web applications by using the Internet Information Services (IIS) Web Deployment Tool (Web Deploy) 2.0. It also identifies the scenarios that map to each approach. From here, each scenario topic provides a high-level overview of the tasks you need to complete and identifies the topics you'll need to work through to help you complete these tasks.

If you're using the split project file approach described in [Understanding the Build Process](../web-deployment-in-the-enterprise/understanding-the-build-process.md) to build and deploy your solution, the final topic, [Configuring Deployment Properties for a Target Environment](configuring-deployment-properties-for-a-target-environment.md), describes how to configure environment-specific project files for deployment to different destination environments.

## Key Technologies

This tutorial focuses on how to use these products and technologies to support web deployment:

- IIS 7.5
- Web Deploy 2.x
- WFF 2.x
- IIS Web Management Service (WMSvc)

The tutorial also touches on the use of Windows Server 2008 R2, SQL Server 2008 R2, ASP.NET 4.0, and ASP.NET MVC 3.

## Other Tutorials in This Series

This forms part of a series of five tutorials on enterprise-scale web deployment. These are the other tutorials in the series:

- [Deploying Web Applications in Enterprise Scenarios](../deploying-web-applications-in-enterprise-scenarios/deploying-web-applications-in-enterprise-scenarios.md). This introductory content provides the contextual background for the tutorial series. It describes the tutorial scenario, and it illustrates how the tasks and walkthroughs described throughout the series fit into a broader Application Lifecycle Management (ALM) process.
- [Web Deployment in the Enterprise](../web-deployment-in-the-enterprise/web-deployment-in-the-enterprise.md). This tutorial provides a conceptual introduction to Microsoft Build Engine (MSBuild) project files, the Web Publishing Pipeline, Web Deploy, and other related technologies. It explains how you can use these tools together to manage complex deployment processes.
- [Configuring Team Foundation Server for Web Deployment](../configuring-team-foundation-server-for-web-deployment/configuring-team-foundation-server-for-web-deployment.md). This tutorial describes how to configure Team Foundation Server (TFS) to support various deployment scenarios, including automated deployment as part of a continuous integration (CI) process and manually triggered deployments of specific builds.
- [Advanced Enterprise Web Deployment](../advanced-enterprise-web-deployment/advanced-enterprise-web-deployment.md). This tutorial describes how to accomplish various more advanced deployment tasks, like customizing database deployments for multiple environments, excluding files and folders from deployment, and taking web applications offline during the deployment process.

>[!div class="step-by-step"]
[Next](choosing-the-right-approach-to-web-deployment.md)