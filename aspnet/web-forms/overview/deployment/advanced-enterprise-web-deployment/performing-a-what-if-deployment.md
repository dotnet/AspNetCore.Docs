---
uid: web-forms/overview/deployment/advanced-enterprise-web-deployment/performing-a-what-if-deployment
title: "Performing a "What If" Deployment | Microsoft Docs"
author: jrjlee
description: "This topic describes how to perform 'what if' (or simulated) deployments using the Internet Information Services (IIS) Web Deployment Tool (Web Deploy) and V..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 05/04/2012
ms.topic: article
ms.assetid: c711b453-01ac-4e65-a48c-93d99bf22e58
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/deployment/advanced-enterprise-web-deployment/performing-a-what-if-deployment
msc.type: authoredcontent
---
Performing a "What If" Deployment
====================
by [Jason Lee](https://github.com/jrjlee)

[Download PDF](https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/00/63/56/8130.DeployingWebAppsInEnterpriseScenarios.pdf)

> This topic describes how to perform "what if" (or simulated) deployments using the Internet Information Services (IIS) Web Deployment Tool (Web Deploy) and VSDBCMD. This lets you determine the effects of your deployment logic on a particular target environment before you actually deploy your application.


This topic forms part of a series of tutorials based around the enterprise deployment requirements of a fictional company named Fabrikam, Inc. This tutorial series uses a sample solution&#x2014;the [Contact Manager solution](../web-deployment-in-the-enterprise/the-contact-manager-solution.md)&#x2014;to represent a web application with a realistic level of complexity, including an ASP.NET MVC 3 application, a Windows Communication Foundation (WCF) service, and a database project.

The deployment method at the heart of these tutorials is based on the split project file approach described in [Understanding the Project File](../web-deployment-in-the-enterprise/understanding-the-project-file.md), in which the build and deployment process is controlled by two project files&#x2014;one containing build instructions that apply to every destination environment, and one containing environment-specific build and deployment settings. At build time, the environment-specific project file is merged into the environment-agnostic project file to form a complete set of build instructions.

## Performing a "What If" Deployment for Web Packages

Web Deploy includes functionality that lets you perform deployments in "what if" (or trial) mode. When you deploy artifacts in "what if" mode, Web Deploy generates a log file as if you had performed the deployment, but it doesn't actually change anything on the destination server. Reviewing the log file can help you to understand what impact your deployment will have on the destination server, in particular:

- What will get added.
- What will get updated.
- What will get deleted.

Because a "what if" deployment doesn't actually change anything on the destination server, what it can't always do is predict whether a deployment will succeed.

As described in [Deploying Web Packages](../web-deployment-in-the-enterprise/deploying-web-packages.md), you can deploy web packages using Web Deploy in two ways&#x2014;by using the MSDeploy.exe command-line utility directly or by running the *.deploy.cmd* file that the build process generates.

If you're using MSDeploy.exe directly, you can run a "what if" deployment by adding the **–whatif** flag to your command. For example, to evaluate what would happen if you deployed the ContactManager.Mvc.zip package to a staging environment, the MSDeploy command should resemble this:


[!code-console[Main](performing-a-what-if-deployment/samples/sample1.cmd)]


When you're satisfied with the results of your "what if" deployment, you can remove the **–whatif** flag to run a live deployment.

> [!NOTE]
> For more information on command-line options for MSDeploy.exe, see [Web Deploy Operation Settings](https://technet.microsoft.com/en-us/library/dd569089(WS.10).aspx).


If you're using the *.deploy.cmd* file, you can run a "what if" deployment by including the **/t** flag (trial mode) flag instead of the **/y** flag ("yes," or update mode) in your command. For example, to evaluate what would happen if you deployed the ContactManager.Mvc.zip package by running the *.deploy.cmd* file, your command should resemble this:


[!code-console[Main](performing-a-what-if-deployment/samples/sample2.cmd)]


When you're satisfied with the results of your "trial mode" deployment, you can replace the **/t** flag with a **/y** flag to run a live deployment:


[!code-console[Main](performing-a-what-if-deployment/samples/sample3.cmd)]


> [!NOTE]
> For more information on command-line options for *.deploy.cmd* files, see [How to: Install a Deployment Package Using the deploy.cmd File](https://msdn.microsoft.com/en-us/library/ff356104.aspx). If you run the *.deploy.cmd* file without specifying any flags, the command prompt will display a list of available flags.


## Performing a "What If" Deployment for Databases

This section assumes that you're using the VSDBCMD utility to perform incremental, schema-based database deployment. This approach is described in more detail in [Deploying Database Projects](../web-deployment-in-the-enterprise/deploying-database-projects.md). We recommend that you familiarize yourself with this topic before you apply the concepts described here.

When you use VSDBCMD in **Deploy** mode, you can use the **/dd** (or **/DeployToDatabase**) flag to control whether VSDBCMD actually deploys the database or just generates a deployment script. If you're deploying a .dbschema file, this is the behavior:

- If you specify **/dd+** or **/dd**, VSDBCMD will generate a deployment script and deploy the database.
- If you specify **/dd-** or omit the switch, VSDBCMD will generate a deployment script only.

> [!NOTE]
> If you're deploying a .deploymanifest file rather than a .dbschema file, the behavior of the **/dd** switch is a lot more complicated. Essentially, VSDBCMD will ignore the value of the **/dd** switch if the .deploymanifest file includes a **DeployToDatabase** element with a value of **True**. [Deploying Database Projects](../web-deployment-in-the-enterprise/deploying-database-projects.md) describes this behavior in full.


For example, to generate a deployment script for the **ContactManager** database without actually deploying the database, your VSDBCMD command should resemble this:


[!code-console[Main](performing-a-what-if-deployment/samples/sample4.cmd)]


VSDBCMD is a differential database deployment tool, and as such the deployment script is dynamically generated to contain all the SQL commands necessary to update the current database, if one exists, to the specified schema. Reviewing the deployment script is a useful way to determine what impact your deployment will have on the current database and the data it contains. For example, you might want to determine:

- Whether any existing tables will be removed, and whether that will result in data loss.
- Whether the order of operations carries a risk of data loss, for example, if you're splitting or merging tables.

If you're happy with the deployment script, you can repeat the VSDBCMD with a **/dd+** flag to make the changes. Alternatively, you can edit the deployment script to meet your requirements and then execute it manually on the database server.

## Integrating "What If" Functionality into Custom Project Files

In more complex deployment scenarios, you'll want to use a custom Microsoft Build Engine (MSBuild) project file to encapsulate your build and deployment logic, as described in [Understanding the Project File](../web-deployment-in-the-enterprise/understanding-the-project-file.md). For example, in the [Contact Manager](../web-deployment-in-the-enterprise/the-contact-manager-solution.md) sample solution, the *Publish.proj* file:

- Builds the solution.
- Uses Web Deploy to package and deploy the ContactManager.Mvc application.
- Uses Web Deploy to package and deploy the ContactManager.Service application.
- Deploys the **ContactManager** database.

When you integrate the deployment of multiple web packages and/or databases into a single-step process in this way, you may also want the option of performing the entire deployment in a "what if" mode.

The *Publish.proj* file demonstrates how you can do this. First, you need to create a property to store the "what if" value:


[!code-xml[Main](performing-a-what-if-deployment/samples/sample5.xml)]


In this case, you've created a property named **WhatIf** with a default value of **false**. Users can override this value by setting the property to **true** in a command-line parameter, as you'll see shortly.

The next stage is to parameterize any Web Deploy and VSDBCMD commands so that the flags reflect the **WhatIf** property value. For example, the next target (taken from the *Publish.proj* file and simplified) runs the *.deploy.cmd* file to deploy a web package. By default, the command includes a **/Y** switch ("yes," or update mode). If **WhatIf** is set to **true**, this is replaced by a **/T** switch (trial, or "what if" mode).


[!code-xml[Main](performing-a-what-if-deployment/samples/sample6.xml)]


Similarly, the next target uses the VSDBCMD utility to deploy a database. By default, a **/dd** switch is not included. This means that VSDBCMD will generate a deployment script but will not deploy the database&#x2014;in other words, a "what if" scenario. If the **WhatIf** property is not set to **true**, a **/dd** switch is added and VSDBCMD will deploy the database.


[!code-xml[Main](performing-a-what-if-deployment/samples/sample7.xml)]


You can use the same approach to parameterize all the relevant commands in your project file. When you want to run a "what if" deployment, you can then simply provide a **WhatIf** property value from the command line:


[!code-console[Main](performing-a-what-if-deployment/samples/sample8.cmd)]


In this way, you can run a "what if" deployment for all your project components in a single step.

## Conclusion

This topic described how to run "what if" deployments using Web Deploy, VSDBCMD, and MSBuild. A "what if" deployment lets you evaluate the impact of a proposed deployment before you actually make any changes to the destination environment.

## Further Reading

For more information on Web Deploy command-line syntax, see [Web Deploy Operation Settings](https://technet.microsoft.com/en-us/library/dd569089(WS.10).aspx). For guidance on command-line options when you use the *.deploy.cmd* file, see [How to: Install a Deployment Package Using the deploy.cmd File](https://msdn.microsoft.com/en-us/library/ff356104.aspx). For guidance on VSDBCMD command-line syntax, see [Command-Line Reference for VSDBCMD.EXE (Deployment and Schema Import)](https://msdn.microsoft.com/en-us/library/dd193283.aspx).

>[!div class="step-by-step"]
[Previous](advanced-enterprise-web-deployment.md)
[Next](customizing-database-deployments-for-multiple-environments.md)