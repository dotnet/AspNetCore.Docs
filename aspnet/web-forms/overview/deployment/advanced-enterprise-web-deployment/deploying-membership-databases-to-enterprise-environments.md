---
uid: web-forms/overview/deployment/advanced-enterprise-web-deployment/deploying-membership-databases-to-enterprise-environments
title: "Deploying Membership Databases to Enterprise Environments | Microsoft Docs"
author: jrjlee
description: "This topic explains the key considerations and challenges you'll need to overcome when you provision ASP.NET application services databases (more common..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 05/04/2012
ms.topic: article
ms.assetid: 3cf765df-d311-4f68-a295-c9685ceea830
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/deployment/advanced-enterprise-web-deployment/deploying-membership-databases-to-enterprise-environments
msc.type: authoredcontent
---
Deploying Membership Databases to Enterprise Environments
====================
by [Jason Lee](https://github.com/jrjlee)

[Download PDF](https://msdnshared.blob.core.windows.net/media/MSDNBlogsFS/prod.evol.blogs.msdn.com/CommunityServer.Blogs.Components.WeblogFiles/00/00/00/63/56/8130.DeployingWebAppsInEnterpriseScenarios.pdf)

> This topic explains the key considerations and challenges you'll need to overcome when you provision ASP.NET application services databases (more commonly referred to as membership databases) in test, staging, or production environments. It also describes approaches you can use to meet these challenges.


This topic forms part of a series of tutorials based around the enterprise deployment requirements of a fictional company named Fabrikam, Inc. This tutorial series uses a sample solution&#x2014;the [Contact Manager solution](../web-deployment-in-the-enterprise/the-contact-manager-solution.md)&#x2014;to represent a web application with a realistic level of complexity, including an ASP.NET MVC 3 application, a Windows Communication Foundation (WCF) service, and a database project.

The deployment method at the heart of these tutorials is based on the split project file approach described in [Understanding the Project File](../web-deployment-in-the-enterprise/understanding-the-project-file.md), in which the build process is controlled by two project files&#x2014;one containing build instructions that apply to every destination environment, and one containing environment-specific build and deployment settings. At build time, the environment-specific project file is merged into the environment-agnostic project file to form a complete set of build instructions.

## What Are the Issues When You Deploy a Membership Database?

In most cases, when you devise a deployment strategy for a database, the first thing you need to consider is what data you want to deploy. In a development or test environment, you might want to deploy user account data to facilitate quick and easy testing. In a staging or production environment, it's very unlikely that you'd want to deploy user account data.

Unfortunately, ASP.NET membership databases introduce some specific challenges that make this decision a lot more complex:

- A schema-only deployment will leave the membership database in a non-operational state. This is because the membership database includes some configuration data (in the **aspnet\_SchemaVersions** table) that the database requires in order to function. As such, if you perform a schema-only deployment of your membership database in order to exclude user account data, you'll need to run a post-deployment script to add the essential configuration data.
- Depending on how your membership database is configured, the membership provider may use the machine key to encrypt passwords and store them in the database. In this case, any user account data you deploy with the database will become unusable on the destination server. For this reason, deploying user account data is not a supported scenario.

## Choosing a Membership Database Strategy

Use these guidelines when you choose how to provision a membership database in an enterprise server environment:

- Wherever possible, do not deploy membership databases. Instead, create the membership database manually on the target database server. If you haven't customized your membership database schema, you can simply create a new one in situ at the destination using the [ASP.NET SQL Server Registration Tool (aspnet\_regsql.exe)](https://msdn.microsoft.com/en-us/library/ms229862(v=vs.100).aspx).
- If you have no option but to deploy a membership database&#x2014;for example, if you've made extensive modifications to the database schema&#x2014;you should perform a schema-only deployment of the membership database, to exclude user account data, and then run a post-deployment script to add any required configuration data. You can find broad guidance on these approaches in [How to: Deploy the ASP.NET Membership Database Without Including User Accounts](https://msdn.microsoft.com/en-us/library/ff361972(v=vs.100).aspx).

It's important to remember that *the schema of your membership database is likely to be fairly static*. Even if you've customized the membership database, it's unlikely that you'll need to update the schema on a regular basis&#x2014;it's not going to change with the same frequency as the code in a web application or a database project. As such, you shouldn't need to include the membership database in any automated or single-step deployment processes.

## Using VSDBCMD to Update a Membership Database Schema

If you modify the structure of your membership database after your first deployment, you may not want to use the Internet Information Services (IIS) Web Deployment Tool (Web Deploy) to redeploy the database. The database deployment functionality in Web Deploy doesn't include the capability to make differential updates to a destination database&#x2014;instead, Web Deploy must drop and re-create the database. This means that you lose any existing user account data, which is typically undesirable in staging or production environments.

The alternative is to use the VSDBCMD utility to update the schema of your destination database. VSDBCMD includes two important capabilities. First, it can import the schema of an existing database into a .dbschema file. Second, it can deploy a .dbschema file to an existing database as a differential update, which means that it only makes the changes required to bring the target database up to date and you don't lose any data.

You can use these high-level steps to update a membership database schema:

1. Use the VSDBCMD **Import** action to generate a .dbschema file for your source membership database. This procedure is described in [How to: Import a Schema from a Command Prompt](https://msdn.microsoft.com/en-us/library/dd172135.aspx).
2. Use the VSDBCMD **Deploy** action to deploy the .dbschema file to your destination membership database. This procedure is described in [Command-Line Reference for VSDBCMD.EXE (Deployment and Schema Import)](https://msdn.microsoft.com/en-us/library/dd193283.aspx).

## Conclusion

This topic described some of the challenges you may face when you need to provision ASP.NET membership databases in various target environments. In particular, it explained why schema-only deployments will leave the membership database in a non-operational state and why deploying user account data is not supported. The topic also presented guidance on how to provision, deploy, and update membership databases in different scenarios.

## Further Reading

For more guidance and examples of how to use VSDBCMD, see [Command-Line Reference for VSDBCMD.EXE (Deployment and Schema Import)](https://msdn.microsoft.com/en-us/library/dd193283.aspx) and [How to: Import a Schema from a Command Prompt](https://msdn.microsoft.com/en-us/library/dd172135.aspx). For more information on using aspnet\_regsql.exe to create membership databases, see [ASP.NET SQL Server Registration Tool (aspnet\_regsql.exe)](https://msdn.microsoft.com/en-us/library/ms229862(v=vs.100).aspx). For more general guidance on deploying membership databases, see [How to: Deploy the ASP.NET Membership Database Without Including User Accounts](https://msdn.microsoft.com/en-us/library/ff361972(v=vs.100).aspx).

>[!div class="step-by-step"]
[Previous](deploying-database-role-memberships-to-test-environments.md)
[Next](excluding-files-and-folders-from-deployment.md)