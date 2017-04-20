---
uid: web-forms/overview/deployment/web-deployment-in-the-enterprise/web-deployment-in-the-enterprise
title: "Web Deployment in the Enterprise | Microsoft Docs"
author: jrjlee
description: "This tutorial describes how to meet lots of the challenges you'll encounter when you manage the deployment of enterprise-scale web applications to devel..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 05/04/2012
ms.topic: article
ms.assetid: b8283698-7b82-42a8-8d83-3aeb18ca7fcc
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/deployment/web-deployment-in-the-enterprise/web-deployment-in-the-enterprise
msc.type: authoredcontent
---
Web Deployment in the Enterprise
====================
by [Jason Lee](https://github.com/jrjlee)

[Download PDF](https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/00/63/56/8130.DeployingWebAppsInEnterpriseScenarios.pdf)

> This tutorial describes how to meet lots of the challenges you'll encounter when you manage the deployment of enterprise-scale web applications to development, test, staging, and production environments. The tutorial includes a reference solution together with a mixture of conceptual and task-oriented content to guide you through various common tasks and procedures.
> 
> For an Italian translation of these tutorials, visit [http://www.lucamorelli.it](http://www.lucamorelli.it).


## Enterprise Deployment Challenges

Organizations often encounter these challenges when they look to manage the deployment of complex, enterprise-scale solutions:

- You need to be able to deploy projects to multiple environments, like developer or test environments, staging platforms, and production servers. The solution needs to be deployed with different configuration settings for each environment.
- You need to deploy multiple dependent projects simultaneously as part of a single-step or automated build and deployment process.
- You need to be able to drive deployment from an automated process. For example, you want to use a continuous integration (CI) process to deploy web applications to a test environment when new code is checked in.
- You need to be able to control the deployment process and set deployment variables from outside Visual Studio, as developers are unlikely to have the correct configuration settings or the necessary credentials for every target environment.
- You need to deploy schema-based database projects and preserve existing data on subsequent deployments.
- You need to deploy membership databases on an ad hoc basis without deploying user account data. You may also need to update the schema of deployed membership databases without losing existing user account data.
- You need to exclude certain files or folders when you deploy content to various target environments.

## Overview of Approach

This tutorial, together with the other tutorials in this series, uses this high-level approach to meet the challenges described above.

- **Use custom Microsoft Build Engine (MSBuild) project files to control the overall build and deployment process.**
- This lets you build and deploy every project in the solution as part of a single, scriptable operation.
- Environment-specific settings are configured using simple environment-specific project files. In contrast to the Visual Studio–centric approach of using solution configurations and publish profiles to configure deployments for different environments, this approach lets you configure and manage the deployment process from outside Visual Studio. This means that developers don't need advance knowledge of connection strings, service endpoints, server credentials, and other deployment variables for destination environments.
- The custom project files can be invoked by Team Build as part of a Team Foundation Server (TFS) workflow. This lets you configure automated deployment for CI scenarios.

**Use the Internet Information Services (IIS) Web Deployment Tool (Web Deploy) to package and deploy web application projects.**

- Web Deploy provides a framework that lets you package and deploy your web application content to a destination IIS web server, together with dependencies, configuration settings, security settings, and any other requirements.
- You can control the entire packaging and deployment process from within your custom MSBuild project files. You can also manipulate the configuration settings that accompany your web deployment package, like connection strings, service endpoints, and IIS destination details.
- Web Deploy, together with the Web Publishing Pipeline, offers lots of extensibility points that let you customize your deployments. For example, it's easy to exclude unwanted files and folders from your web deployment packages.

**Use the VSDBCMD.exe utility to deploy and update database schemas.**

- VSDBCMD allows you to deploy databases from a database schema file (.dbschema), which is generated when you build a Visual Studio database project. In contrast, the database deployment functionality included in Web Deploy is more suited to deploying existing databases from a local SQL Server instance.
- Unlike Visual Studio's functionality for deploying database projects, VSDBCMD lets you deploy differential updates to an existing target database. This allows you to preserve any existing data while you upgrade the database schema.
- You can execute VSDBCMD commands from within your custom MSBuild project files.

## Content Map

This tutorial includes topics that fall into four main areas.

These topics introduce the reference solution&#x2014;the Contact Manager solution&#x2014;and describe how to download it and configure it on your local machine:

- [The Contact Manager Solution](the-contact-manager-solution.md)
- [Setting Up the Contact Manager Solution](setting-up-the-contact-manager-solution.md)

These topics introduce MSBuild project files, describe how you can create and use custom project files, and walk through the deployment process for the Contact Manager solution:

- [Understanding the Project File](understanding-the-project-file.md)
- [Understanding the Build Process](understanding-the-build-process.md)

These topics describe web application deployment, including how the build and packaging process works, how the build process integrates with the Web Publishing Pipeline, how to modify deployment parameters, and how to deploy web packages to destination environments:

- [Building and Packaging Web Application Projects](building-and-packaging-web-application-projects.md)
- [Configuring Parameters for Web Package Deployment](configuring-parameters-for-web-package-deployment.md)
- [Deploying Web Packages](deploying-web-packages.md)

- [Deploying Database Projects](deploying-database-projects.md) describes the different techniques you can use to deploy Visual Studio database projects, together with the advantages and disadvantages of each approach. [Creating and Running a Deployment Command File](creating-and-running-a-deployment-command-file.md) describes how to create a simple command file that encapsulates your deployment logic and lets you deploy complex solutions as a single-step process.
- Finally, [Manually Installing Web Packages](manually-installing-web-packages.md) concludes the tutorial by showing you to import web packages into IIS.

## Key Technologies

The topics in this tutorial primarily use these technologies to manage build and deployment:

- Visual Studio 2010
- MSBuild
- IIS 7.5
- Web Deploy 2.0
- The VSDBCMD.exe database deployment utility

## Other Tutorials in This Series

This forms part of a series of five tutorials on enterprise-scale web deployment. These are the other tutorials in the series:

- [Deploying Web Applications in Enterprise Scenarios](../deploying-web-applications-in-enterprise-scenarios/deploying-web-applications-in-enterprise-scenarios.md). This introductory content provides the contextual background for the tutorial series. It describes the tutorial scenario, and it illustrates how the tasks and walkthroughs described throughout the series fit into a broader Application Lifecycle Management (ALM) process.
- [Configuring Server Environments for Web Deployment](../configuring-server-environments-for-web-deployment/configuring-server-environments-for-web-deployment.md). This tutorial describes how to configure Windows servers to support various deployment scenarios, including remote web package deployment using the Web Deployment Agent Service (the remote agent) or the Web Deploy Handler and remote database deployment. It provides guidance on choosing the appropriate deployment method for your own environment, and it describes how to use the Web Farm Framework (WFF) to replicate deployed web applications across all the web servers in a server farm.
- [Configuring Team Foundation Server for Web Deployment](../configuring-team-foundation-server-for-web-deployment/configuring-team-foundation-server-for-web-deployment.md). This tutorial describes how to configure TFS to support various deployment scenarios, including automated deployment as part of a CI process and manually triggered deployments of specific builds.
- [Advanced Enterprise Web Deployment](../advanced-enterprise-web-deployment/advanced-enterprise-web-deployment.md). This tutorial describes how to accomplish various more advanced deployment tasks, like customizing database deployments for multiple environments, excluding files and folders from deployment, and taking web applications offline during the deployment process.

>[!div class="step-by-step"]
[Next](the-contact-manager-solution.md)