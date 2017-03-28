---
uid: web-forms/overview/deployment/configuring-team-foundation-server-for-web-deployment/configuring-permissions-for-team-build-deployment
title: "Configuring Permissions for Team Build Deployment | Microsoft Docs"
author: jrjlee
description: "This topic describes how to configure permissions to enable your build server to deploy content to web servers and database servers as part of an automated b..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 05/04/2012
ms.topic: article
ms.assetid: 2488a91e-b0a8-465a-b874-3233f724b56b
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/deployment/configuring-team-foundation-server-for-web-deployment/configuring-permissions-for-team-build-deployment
msc.type: authoredcontent
---
Configuring Permissions for Team Build Deployment
====================
by [Jason Lee](https://github.com/jrjlee)

[Download PDF](https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/00/63/56/8130.DeployingWebAppsInEnterpriseScenarios.pdf)

> This topic describes how to configure permissions to enable your build server to deploy content to web servers and database servers as part of an automated build process.


This topic forms part of a series of tutorials based around the enterprise deployment requirements of a fictional company named Fabrikam, Inc. This tutorial series uses a sample solution&#x2014;the [Contact Manager solution](../web-deployment-in-the-enterprise/the-contact-manager-solution.md)&#x2014;to represent a web application with a realistic level of complexity, including an ASP.NET MVC 3 application, a Windows Communication Foundation (WCF) service, and a database project.

The deployment method at the heart of these tutorials is based on the split project file approach described in [Understanding the Project File](../web-deployment-in-the-enterprise/understanding-the-project-file.md), in which the build process is controlled by two project files&#x2014;one containing build instructions that apply to every destination environment, and one containing environment-specific build and deployment settings. At build time, the environment-specific project file is merged into the environment-agnostic project file to form a complete set of build instructions.

## Task Overview

When you install the Team Foundation Server (TFS) 2010 build service, you specify the identity with which you want the service to run. By default, this is the Network Service account. Alternatively, you can configure the build service to run using a domain account.

Any deployment tasks that require Windows authentication, and that you plan to automate using Team Build, will run using the build service identity. As such, you'll need to grant the build service identity any required permissions on your web servers and your database servers.

> [!NOTE]
> The Network Service account uses the machine account to authenticate to other computers. Machine accounts take the form *[domain name]\[machine name]***$**&#x2014;for example, **FABRIKAM\TFSBUILD$**. As such, if your build service runs using the Network Service identity, you should grant any required permissions to the machine account identity for your build server.


## Configuring Web Server Permissions

As described in [Choosing the Right Approach to Web Deployment](../configuring-server-environments-for-web-deployment/choosing-the-right-approach-to-web-deployment.md), there are two main approaches you can use if you want to deploy web packages to a remote web server:

- Deploy the application from a remote location by targeting the *Web Deployment Agent Service* (also known as the remote agent) on the destination server.
- Deploy the application from a remote location by targeting the *Internet Information Services* (*IIS) Web Deploy Handler* on the destination server.

The remote agent has two key limitations in this case:

- The remote agent supports only NTLM authentication. In other words, the deployment must use the build service identity&#x2014;you can't impersonate another account.
- To use the remote agent, the account that performs the deployment must be an administrator on the target server.

Together, these two limitations make the remote agent approach undesirable for an automated Team Build deployment. To use this approach, you'd need to make the build service account an administrator on any target web servers.

In contrast, the Web Deploy Handler approach offers various advantages:

- The Web Deploy Handler supports basic authentication over HTTPS, which allows you to pass the credentials of an alternative account to the IIS Web Deployment Tool (Web Deploy).
- You can configure target web servers to allow non-administrator users to deploy content to specific IIS websites using the Web Deploy Handler.

As a result, it's clearly preferable to target the Web Deploy Handler when you automate web package deployment from Team Build. This is the recommended process:

1. Create a low-privileged domain account to use for the deployment.
2. Configure the Web Deploy Handler and grant the account the required permissions to deploy content to a specific IIS website, as described in [Configuring a Web Server for Web Deploy Publishing (Web Deploy Handler)](../configuring-server-environments-for-web-deployment/configuring-a-web-server-for-web-deploy-publishing-web-deploy-handler.md).
3. Invoke Web Deploy and target the Web Deploy Handler, using basic authentication and supplying the credentials of the domain account you created, to perform the deployment.

In the [Contact Manager](../web-deployment-in-the-enterprise/the-contact-manager-solution.md) sample solution, you specify the authentication type (basic or NTLM), the Web Deploy credentials, and the endpoint address (remote agent or Web Deploy Handler) in the environment-specific project file. These values are used to formulate and run a Web Deploy command when the project file is executed. For more information, see [Deploying Web Packages](../web-deployment-in-the-enterprise/deploying-web-packages.md).

For more information on configuring the Web Deploy Handler, including how to configure permissions, see [Configuring a Web Server for Web Deploy Publishing (Web Deploy Handler)](../configuring-server-environments-for-web-deployment/configuring-a-web-server-for-web-deploy-publishing-web-deploy-handler.md). For more information on configuring the remote agent, see [Configuring a Web Server for Web Deploy Publishing (Remote Agent)](../configuring-server-environments-for-web-deployment/configuring-a-web-server-for-web-deploy-publishing-remote-agent.md).

## Configuring Database Server Permissions

To deploy a database to SQL Server, you must:

- Create a login for the deploying account on the SQL Server instance.
- Grant the login **DBCreator** permissions on the SQL Server instance.
- After the initial deployment, add the login to the **db\_owner** role on the target database. This is required because on subsequent deployments, you're modifying an existing database rather than creating a new database.

You can authenticate to a SQL Server instance using either NTLM authentication or SQL Server authentication:

- If you use NTLM authentication, you need to grant the permissions described above to the build service account.
- If you use SQL Server authentication, you need to grant the permissions described above to the SQL Server account. You also need to include the SQL Server user name and password in the connection string you use to deploy the database.

For step-by-step details on how to configure permissions for database deployment, see [Configuring a Database Server for Web Deploy Publishing](../configuring-server-environments-for-web-deployment/configuring-a-database-server-for-web-deploy-publishing.md).

## Conclusion

At this point, you should understand the permissions required, together with the authentication options open to you, when you automate web application and database deployments from Team Build. You should also be able to implement the necessary permissions on IIS web servers and SQL Server database servers.

## Further Reading

For more information on configuring Windows server environments to support remote deployment, see [Configuring Server Environments for Web Deployment](../configuring-server-environments-for-web-deployment/configuring-server-environments-for-web-deployment.md).

>[!div class="step-by-step"]
[Previous](deploying-a-specific-build.md)