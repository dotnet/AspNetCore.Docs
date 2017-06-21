---
uid: web-forms/overview/deployment/advanced-enterprise-web-deployment/deploying-database-role-memberships-to-test-environments
title: "Deploying Database Role Memberships to Test Environments | Microsoft Docs"
author: jrjlee
description: "This topic describes how to add user accounts to database roles as part of a solution deployment to a test environment. When you deploy a solution containing..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 05/04/2012
ms.topic: article
ms.assetid: 9b2af539-7ad9-47aa-b66e-873bd9906e79
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/deployment/advanced-enterprise-web-deployment/deploying-database-role-memberships-to-test-environments
msc.type: authoredcontent
---
Deploying Database Role Memberships to Test Environments
====================
by [Jason Lee](https://github.com/jrjlee)

[Download PDF](https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/00/63/56/8130.DeployingWebAppsInEnterpriseScenarios.pdf)

> This topic describes how to add user accounts to database roles as part of a solution deployment to a test environment.
> 
> When you deploy a solution containing a database project to a staging or production environment, you typically don't want the developer to automate the addition of user accounts to database roles. In most cases, the developer won't know which user accounts need to be added to which database roles, and these requirements could change at any time. However, when you deploy a solution containing a database project to a development or test environment, the situation is usually rather different:
> 
> - The developer typically re-deploys the solution on a regular basis, often several times a day.
> - The database is typically re-created on every deployment, which means that database users must be created and added to roles after every deployment.
> - The developer typically has full control over the target development or test environment.
> 
> In this scenario, it's often beneficial to automatically create database users and assign database role memberships as part of the deployment process.
> 
> The key factor is that this operation needs to be conditional based on the target environment. If you're deploying to a staging or a production environment, you want to skip the operation. If you're deploying to a developer or test environment, you want to deploy role memberships without further intervention. This topic describes one approach you can use to address this challenge.


This topic forms part of a series of tutorials based around the enterprise deployment requirements of a fictional company named Fabrikam, Inc. This tutorial series uses a sample solution&#x2014;the [Contact Manager solution](../web-deployment-in-the-enterprise/the-contact-manager-solution.md)&#x2014;to represent a web application with a realistic level of complexity, including an ASP.NET MVC 3 application, a Windows Communication Foundation (WCF) service, and a database project.

The deployment method at the heart of these tutorials is based on the split project file approach described in [Understanding the Project File](../web-deployment-in-the-enterprise/understanding-the-project-file.md), in which the build process is controlled by two project files&#x2014;one containing build instructions that apply to every destination environment, and one containing environment-specific build and deployment settings. At build time, the environment-specific project file is merged into the environment-agnostic project file to form a complete set of build instructions.

## Task Overview

This topic assumes that:

- You use the split project file approach to solution deployment, as described in [Understanding the Project File](../web-deployment-in-the-enterprise/understanding-the-project-file.md).
- You call VSDBCMD from the project file to deploy your database project, as described in [Understanding the Build Process](../web-deployment-in-the-enterprise/understanding-the-build-process.md).

To create database users and assign role memberships when you deploy a database project to a test environment, you'll need to:

- Create a Transact Structured Query Language (Transact-SQL) script that makes the necessary database changes.
- Create a Microsoft Build Engine (MSBuild) target that uses the sqlcmd.exe utility to run the SQL script.
- Configure your project files to invoke the target when you're deploying your solution to a test environment.

This topic will show you how to perform each of these procedures.

## Scripting the Database Role Memberships

You can create a Transact-SQL script in a lot of different ways, and in any location you choose. The easiest approach is to create the script within your solution in Visual Studio 2010.

**To create a SQL script**

1. In the **Solution Explorer** window, expand your database project node.
2. Right-click the **Scripts** folder, point to **Add**, and then click **New Folder**.
3. Type **Test** as the folder name, and then press Enter.
4. Right-click the **Test** folder, point to **Add**, and then click **Script**.
5. In the **Add New Item** dialog box, give your script a meaningful name (for example, **AddRoleMemberships.sql**), and then click **Add**.

    ![](deploying-database-role-memberships-to-test-environments/_static/image1.png)
6. In the *AddRoleMemberships.sql* file, add Transact-SQL statements that:

    1. Create a database user for the SQL Server login that will access your database.
    2. Add the database user to any required database roles.
7. The file should resemble this:

    [!code-sql[Main](deploying-database-role-memberships-to-test-environments/samples/sample1.sql)]
8. Save the file.

## Executing the Script on the Target Database

Ideally, you'd run any required Transact-SQL scripts as part of a post-deployment script when you deploy your database project. However, post-deployment scripts don't allow you to execute logic conditionally based on solution configurations or build properties. The alternative is to run your SQL scripts directly from the MSBuild project file, by creating a **Target** element that executes a sqlcmd.exe command. You can use this command to run your script on the target database:


[!code-console[Main](deploying-database-role-memberships-to-test-environments/samples/sample2.cmd)]


> [!NOTE]
> For more information on sqlcmd command-line options, see [sqlcmd Utility](https://msdn.microsoft.com/en-us/library/ms162773.aspx).


Before you embed this command in an MSBuild target, you need to consider under what conditions you want the script to run:

- The target database must exist before you change its role memberships. As such, you need to run this script *after* the database deployment.
- You need to include a condition so that the script is only executed for test environments.
- If you're running a "what if" deployment&#x2014;in other words, if you're generating deployment scripts but not actually running them&#x2014;you shouldn't run the SQL script.

If you're using the split project file approach described in [Understanding the Project File](../web-deployment-in-the-enterprise/understanding-the-project-file.md), as demonstrated by the Contact Manager sample solution, you can split the build instructions for your SQL script like this:

- Any required environment-specific properties, together with the property that determines whether to deploy permissions, should go in the environment-specific project file (for example, *Env-Dev.proj*).
- The MSBuild target itself, together with any properties that will not change between destination environments, should go in the universal project file (for example, *Publish.proj*).

In the environment-specific project file, you need to define the database server name, the target database name, and a Boolean property that lets the user specify whether to deploy role memberships.


[!code-xml[Main](deploying-database-role-memberships-to-test-environments/samples/sample3.xml)]


In the universal project file, you need to provide the location of the sqlcmd executable and the location of the SQL script you want to run. These properties will remain the same regardless of the destination environment. You also need to create an MSBuild target to execute the sqlcmd command.


[!code-xml[Main](deploying-database-role-memberships-to-test-environments/samples/sample4.xml)]


Notice that you add the location of the sqlcmd executable as a static property, as this could be useful to other targets. In contrast, you define the location of your SQL script and the syntax of the sqlcmd command as dynamic properties within the target, as they will not be required before the target is executed. In this case, the **DeployTestDBPermissions** target will only be executed if these conditions are met:

- The **DeployTestDBRoleMemberships** property is set to **true**.
- The user hasn't specified a **WhatIf=true** flag.

Finally, don't forget to invoke the target. In the *Publish.proj* file, you can do this by adding the target to the dependency list for the default **FullPublish** target. You need to ensure that the **DeployTestDBPermissions** target is not executed until the **PublishDbPackages** target has been executed.


[!code-xml[Main](deploying-database-role-memberships-to-test-environments/samples/sample5.xml)]


## Conclusion

This topic described one way in which you can add database users and role memberships as a post-deployment action when you deploy a database project. This is typically useful when you regularly re-create a database in a test environment, but it should usually be avoided when you deploy databases to staging or production environments. As such, you should ensure that you use the necessary conditional logic so that database users and role memberships are only created when it's appropriate to do so.

## Further Reading

For more information on using VSDBCMD to deploy database projects, see [Deploying Database Projects](../web-deployment-in-the-enterprise/deploying-database-projects.md). For guidance on customizing database deployments for different target environments, see [Customizing Database Deployments for Multiple Environments](customizing-database-deployments-for-multiple-environments.md). For more information on using custom MSBuild project files to control the deployment process, see [Understanding the Project File](../web-deployment-in-the-enterprise/understanding-the-project-file.md) and [Understanding the Build Process](../web-deployment-in-the-enterprise/understanding-the-build-process.md). For more information on sqlcmd command-line options, see [sqlcmd Utility](https://msdn.microsoft.com/en-us/library/ms162773.aspx).

>[!div class="step-by-step"]
[Previous](customizing-database-deployments-for-multiple-environments.md)
[Next](deploying-membership-databases-to-enterprise-environments.md)