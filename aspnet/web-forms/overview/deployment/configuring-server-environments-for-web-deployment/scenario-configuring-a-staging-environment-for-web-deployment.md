---
uid: web-forms/overview/deployment/configuring-server-environments-for-web-deployment/scenario-configuring-a-staging-environment-for-web-deployment
title: "Scenario: Configuring a Staging Environment for Web Deployment | Microsoft Docs"
author: jrjlee
description: "This topic describes a typical web deployment scenario for a staging environment and explains the tasks you need to complete in order to set up a similar env..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 05/04/2012
ms.topic: article
ms.assetid: 5a8e49b7-5317-4125-b107-7e2466b47bb3
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/deployment/configuring-server-environments-for-web-deployment/scenario-configuring-a-staging-environment-for-web-deployment
msc.type: authoredcontent
---
Scenario: Configuring a Staging Environment for Web Deployment
====================
by [Jason Lee](https://github.com/jrjlee)

[Download PDF](https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/00/63/56/8130.DeployingWebAppsInEnterpriseScenarios.pdf)

> This topic describes a typical web deployment scenario for a staging environment and explains the tasks you need to complete in order to set up a similar environment.


Lots of organizations use staging environments to preview updates to web applications or websites. This gives people within the organization a chance to explore and review new functionality or content before the site "goes live," or in other words is deployed to a production environment. The staging environment is designed to replicate the production environment as closely as possible, in order to provide a realistic preview. This kind of staging environment typically has these characteristics:

- The environment consists of multiple load-balanced web servers and one or more database servers, often with failover clustering and database mirroring.
- Applications may be deployed manually by a development team or automatically by a Team Build server.
- The users or process accounts that deploy applications are unlikely to have administrator privileges on the staging servers.
- Changes to applications are deployed on a frequent basis, so the environment needs to support single-step or automated deployment.

> [!NOTE]
> Scaling out a database deployment across multiple servers is beyond the scope of this tutorial. For more information on this area, please consult [SQL Server Books Online](https://technet.microsoft.com/en-us/library/ms130214.aspx).


For example, in our [tutorial scenario](../deploying-web-applications-in-enterprise-scenarios/enterprise-web-deployment-scenario-overview.md), Team Foundation Server (TFS) manages the Contact Manager solution. The TFS administrator, Rob Walters, has created a build definition that lets developers trigger a deployment to the staging environment as required.

![](scenario-configuring-a-staging-environment-for-web-deployment/_static/image1.png)

Note that in most cases, you won't necessarily want to deploy the latest build to the staging environment. Instead, you're a lot more likely to want to deploy a specific build that has already undergone validation and verification in the test environment.

## Solution Overview

In this scenario, you can deduce these facts from an analysis of the deployment requirements:

- The user or process account that performs the deployment won't have administrator privileges on the staging servers, so the staging web servers must support non-administrator deployment. As such, you'll need to configure the staging web servers to use the Web Deploy Handler rather than the remote agent.
- The staging environment includes multiple web servers, but it needs to support one-click or automated deployment, so you'll need to use the Web Farm Framework (WFF) to create a server farm. Using this approach, you can deploy an application to one web server (the primary server), and WFF will replicate the deployment on all the other web servers in the staging environment.
- The user or process account that performs the deployment must have permissions to create databases. As such, you'll need to add the account to the **dbcreator** server role on the database server, in addition to configuring the database server to support remote access and deployment.

These topics provide all the information you need in order to complete these tasks:

- [Create a Server Farm with the Web Farm Framework](creating-a-server-farm-with-the-web-farm-framework.md). This topic describes how to create and configure a server farm using WFF, so that web platform products and components, configuration settings, and websites and applications are replicated across multiple load-balanced web servers.
- [Configure a Web Server for Web Deploy Publishing (Web Deploy Handler)](configuring-a-web-server-for-web-deploy-publishing-web-deploy-handler.md). This topic describes how to build a web server that supports Web Deploy publishing, using the remote agent approach, starting from a clean Windows Server 2008 R2 build.
- [Configure a Database Server for Web Deploy Publishing](configuring-a-database-server-for-web-deploy-publishing.md). This topic describes how to configure a database server to support remote access and deployment, starting from a default installation of SQL Server 2008 R2.

## Further Reading

For guidance on configuring a typical developer test environment, see [Scenario: Configuring a Test Environment for Web Deployment](scenario-configuring-a-test-environment-for-web-deployment.md). For guidance on configuring a typical production environment, see [Scenario: Configuring a Production Environment for Web Deployment](scenario-configuring-a-production-environment-for-web-deployment.md).

>[!div class="step-by-step"]
[Previous](scenario-configuring-a-test-environment-for-web-deployment.md)
[Next](scenario-configuring-a-production-environment-for-web-deployment.md)