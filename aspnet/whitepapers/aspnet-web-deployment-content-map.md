---
uid: whitepapers/aspnet-web-deployment-content-map
title: "ASP.NET Web Deployment - Recommended Resources | Microsoft Docs"
author: rick-anderson
description: "This topic provides links to documentation resources about how to deploy (publish) ASP.NET web applications to IIS by using Visual Studio 2010, Visual Web De..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 03/14/2014
ms.topic: article
ms.assetid: 58b583cd-c4ab-47a3-8527-8c92c298c91f
ms.technology: 
ms.prod: .net-framework
msc.legacyurl: /whitepapers/aspnet-web-deployment-content-map
msc.type: content
---
ASP.NET Web Deployment - Recommended Resources
====================
> This topic provides links to documentation resources about how to deploy (publish) ASP.NET web applications to IIS by using Visual Studio 2010, Visual Web Developer 2010, and later versions.
> 
> If you know a great blog post, [stackoverflow](http://stackoverflow.com) thread, or any other link that would be useful, [send us an email](mailto:aspnetue@microsoft.com?subject=Deployment Content Map) with the link.
> 
> > [!NOTE] 
> > 
> > Many of these resources describe deployment features that are available only if you install a recent release of the [Visual Studio Web Publish Update](https://go.microsoft.com/fwlink/?LinkID=208120). Some of the features are available only in Visual Studio 2012 or Visual Studio 2013.


This topic contains the following sections:

- [Understanding deployment options for web projects](#understanding)
- [Finding hosting providers for an ASP.NET application](#findinghosting)
- [Deploying a web application from Visual Studio](#fromvs)
- [Deploying a web application by creating and installing a web deployment package](#package)
- [Deploying a web application using a continuous integration (CI) process](#ci)
- [Using Web.config transformations to change settings in the destination Web.config file or app.config file during deployment](#transforms)
- [Using Web Deploy parameters to change settings in the destination web application during deployment](#webdeployparms)
- [Making sure an application is off-line during deployment](#appoffline)
- [Deploying a database or changes to a database as part of web application deployment](#databasewithweb)
- [Deploying a database separately from web application deployment](#databaseseparate)
- [Deploying a web application that uses ASP.NET application services such as membership and profiling](#aspnetmembership)
- [Precompiling for deployment](#precompiling)
- [Deploying an intranet web application](#intranet)
- [Automating common deployment tasks that are not automated out of the box](#automating)
- [Configuring web servers so that developers can deploy web applications to them using Web Deploy](#configuringservers)
- [Configuring servers for a hosting provider](#hostingprovider)
- [Troubleshooting deployment problems](#troubleshooting)
- [Getting help with a specific deployment question](#gettinghelp)
- [Additional Resources](#additional)


<a id="understanding"></a>


## Understanding deployment options for web projects

- [Web Deployment Overview for Visual Studio and ASP.NET](https://msdn.microsoft.com/en-us/library/dd394698.aspx) (MSDN).
- [How to Deploy a Windows Azure Web Site](https://www.windowsazure.com/en-us/documentation/articles/web-sites-deploy/). Explains options and links to resources for deploying web projects to Windows Azure Web Sites, including [continuous delivery](../aspnet/overview/developing-apps-with-windows-azure/building-real-world-cloud-apps-with-windows-azure/continuous-integration-and-continuous-delivery.md) (automated from [source control](../aspnet/overview/developing-apps-with-windows-azure/building-real-world-cloud-apps-with-windows-azure/source-control.md)) as well as using Visual Studio.
- [Visual Studio 2012 Web Publishing Improvements](../visual-studio/overview/2012/visual-studio-2012-web-publishing-improvements.md) (Video by Scott Hanselman).
- [Overview Post for Web Deployment in VS 2010](http://vishaljoshi.blogspot.com/2009/09/overview-post-for-web-deployment-in-vs.html) (Vishal Joshi's blog). An older blog post but some of the Visual Studio 2010 resources it links to have information that is still relevant for Visual Studio 2012.


<a id="findinghosting"></a>


## Finding hosting providers for an ASP.NET application

- [ASP.NET Hosting](https://asp.net/hosting)


<a id="fromvs"></a>


## Deploying a web application from Visual Studio

- [How to Deploy a Windows Azure Web Site](https://www.windowsazure.com/en-us/documentation/articles/web-sites-deploy/). Explains options and provides links to resources for deploying web projects to Windows Azure Web Sites. Includes a section about deploying from Visual Studio.
- [ASP.NET Web Deployment using Visual Studio](../web-forms/overview/deployment/visual-studio-web-deployment/introduction.md). 12-part tutorial series, shows how to deploy web applications with SQL Server databases. For database deployment uses both the dbDacFx provider and Entity Framework Code First Migrations. Also includes information about [Web.config file transformations](../web-forms/overview/deployment/visual-studio-web-deployment/web-config-transformations.md), [deploying individual files](../web-forms/overview/deployment/visual-studio-web-deployment/deploying-a-code-update.md#specificfiles), [command-line deployment](../web-forms/overview/deployment/visual-studio-web-deployment/command-line-deployment.md), and [how to customize the Visual Studio web publish pipeline by editing .pubxml files](../web-forms/overview/deployment/visual-studio-web-deployment/deploying-extra-files.md). Applies to all ASP.NET web projects, including Web Forms, MVC, and Web API.)
- [How to: Deploy a Web Project Using One-Click Publish in Visual Studio](https://msdn.microsoft.com/en-us/library/dd465337.aspx) (Reference information for the Visual Studio Web Publish wizard.)
- [Deploying an ASP.NET Web Application with SQL Server Compact using Visual Studio](../web-forms/overview/older-versions-getting-started/deployment-to-a-hosting-provider/deployment-to-a-hosting-provider-introduction-1-of-12.md). This is an earlier version of **ASP.NET Web Deployment using Visual Studio** listed at the top of this section. Mainly useful now for information about how to deploy SQL Server Compact databases and how to migrate from SQL Server Compact to a full edition of SQL Server.
- [.NET Multi-Tier Application Using Storage Tables, Queues, and Blobs](https://www.windowsazure.com/en-us/develop/net/tutorials/multi-tier-web-site/1-overview/) (Microsoft Azure site). 5-part tutorial series, shows how to create an MVC project and deploy it to a Windows Azure Cloud Service.


<a id="package"></a>
## Deploying a web application by creating and installing a web deployment package

- [How to: Create a Web Deployment Package in Visual Studio](https://msdn.microsoft.com/en-us/library/dd465323.aspx)  (MSDN).
- [How to: Install a Deployment Package Using the deploy.cmd File Created by Visual Studio](https://msdn.microsoft.com/en-us/library/ff356104.aspx) (MSDN).
- [Using a Web Deploy package to deploy to IIS on the dev box and to a third party host](http://sedodream.com/2011/11/08/UsingAWebDeployPackageToDeployToIISOnTheDevBoxAndToAThirdPartyHost.aspx) (Sayed Hashimi's blog). How to use IIS Manager to install a deployment package in IIS on the local computer and at a hosting company that supports IIS Manager for Remote Administration.
- [Building a Web Deploy Package From Visual Studio 2010](https://www.iis.net/learn/publish/using-web-deploy/building-a-web-deploy-package-from-visual-studio-2010) (IIS.NET web site). Includes instructions for command-line package creation and installation.
- [Package Once Publish Anywhere](http://sedodream.com/2012/03/14/PackageWebUpdatedAndVideoBelow.aspx) (Sayed Hashimi's blog). Introduces a NuGet package that automates the process of transforming the Web.config file for multiple destination environments, so that you can deploy one package to multiple servers. See also the [PackageWeb video](https://www.youtube.com/watch?v=-LvUJFI8CzM) by Sayed Hashimi.

See also the following section.


<a id="ci"></a>


## Deploying a web application using a continuous integration (CI) process

- [Continuous Integration and Continuous Delivery (Building Real-World Cloud Apps with Windows Azure).](../aspnet/overview/developing-apps-with-windows-azure/building-real-world-cloud-apps-with-windows-azure/continuous-integration-and-continuous-delivery.md) E-book chapter that introduces continuous integration and continuous delivery.
- [How to Deploy a Windows Azure Web Site](https://www.windowsazure.com/en-us/documentation/articles/web-sites-deploy/). Explains options and links to resources for deploying web projects to Windows Azure Web Sites. Includes a section about automating deployment from source control.
- [Deploying Web Applications in Enterprise Scenarios](../web-forms/overview/deployment/deploying-web-applications-in-enterprise-scenarios/deploying-web-applications-in-enterprise-scenarios.md). 40-part tutorial series, shows how to automate deployment in a CI process using Visual Studio 2010 and Team Foundation Server 2010.
- [Inside the Microsoft Build Engine: Using MSBuild and Team Foundation Build, by Sayed Hashimi and William Bartholomew](http://msbuildbook.com). This is a book, not a web resource, but it is an essential guide for learning how to configure MSBuild for continuous integration scenarios.
- [MSBuild Extension Pack](http://msbuildextensionpack.codeplex.com/) (CodePlex site). Includes deployment tasks.
- [Team Foundation Build Customization Guide](http://vsarbuildguide.codeplex.com/) (CodePlex site). Documentation by ALM Rangers on setting up Team Foundation Server covers web deployment and includes tutorials and videos.
- [SlowCheetah XML transforms from a CI server](http://sedodream.com/2011/12/12/SlowCheetahXMLTransformsFromACIServer.aspx) (Sayed Hashimi's blog). Explains how to use SlowCheetah, A Visual Studio add-in for transforming app.config and other XML files.

See also [Making sure an application is off-line during deployment](aspnet-web-deployment-content-map.md#appoffline) later in this page.


<a id="transforms"></a>


## Using Web.config transformations to change settings in the destination Web.config file or app.config file during deployment

- [Web.config File Transformations](../web-forms/overview/deployment/visual-studio-web-deployment/web-config-transformations.md).
- [Web.config Transformation Syntax for Web Project Deployment Using Visual Studio](https://msdn.microsoft.com/en-us/library/dd465326.aspx) (MSDN).
- [Web Tools 2012.2 - web.config transforms](https://www.youtube.com/watch?v=HdPK8mxpKEI) (YouTube video by Sayed Hashimi). Shows how to set up and preview Web.config transforms.
- [How do I disable Web.config transformation?](https://msdn.microsoft.com/en-us/library/ee942158.aspx#disable_web_config_transformation) (MSDN).
- [When should I use Web Deploy parameters instead of Web.config transformations?](https://msdn.microsoft.com/en-us/library/ee942158.aspx#web_deploy_parameters) (MSDN).
- [XDT (XML Document Transform) released on codeplex.com](https://blogs.msdn.com/b/webdev/archive/2013/04/23/xdt-xml-document-transform-released-on-codeplex-com.aspx) (.NET Web Development and Tools blog). Announces availability of the source code for the Web.config file transformation engine and lists some tools that use it.
- [Windows Azure Web Sites: How Application Strings and Connection Strings Work](https://blogs.msdn.com/b/windowsazure/archive/2013/07/17/windows-azure-web-sites-how-application-strings-and-connection-strings-work.aspx) (Microsoft Azure blog). An alternative to Web.config transforms if your destination environment is Windows Azure Web Sites and you want to transform `appSettings` or `connectionStrings`.


<a id="webdeployparms"></a>


## Using Web Deploy parameters to change settings in the destination web application during deployment

- [How to: Use Web Deploy Parameters in a Web Deployment Package](https://msdn.microsoft.com/en-us/library/ff398068.aspx) (MSDN).
- [MSDeploy: How to update app settings on publish based on the publish profile](http://sedodream.com/2013/03/02/MSDeployHowToUpdateAppSettingsOnPublishBasedOnThePublishProfile.aspx) (Sayed Hashimi's blog). Shows how to integrate Web deploy parameters into Visual Studio publish profiles.
- [Web Deploy Parameterization](https://www.iis.net/learn/publish/using-web-deploy/web-deploy-parameterization) (IIS.NET web site).
- [Web Deploy Parameterization in Action](http://vishaljoshi.blogspot.com/2010/07/web-deploy-parameterization-in-action.html) (Vishal Joshi's blog).
- [Web Deploy Parameterization vs. Web.config Transformation](http://vishaljoshi.blogspot.com/2010/06/parameterization-vs-webconfig.html) (Vishal Joshi's blog).
- [Windows Azure Web Sites: How Application Strings and Connection Strings Work](https://blogs.msdn.com/b/windowsazure/archive/2013/07/17/windows-azure-web-sites-how-application-strings-and-connection-strings-work.aspx) (Microsoft Azure blog). An alternative to Web deploy parameters if your destination environment is Windows Azure Web Sites and you want to parameterize `appSettings` or `connectionStrings`.


<a id="appoffline"></a>


## Making sure an application is off-line during deployment

- [ASP.NET Web Deployment using Visual Studio: Deploying a Code Update](../web-forms/overview/deployment/visual-studio-web-deployment/deploying-a-code-update.md). See the section **Take the application offline during deployment.**
- [Taking an Application Offline before Publishing](https://www.iis.net/learn/publish/deploying-application-packages/taking-an-application-offline-before-publishing) (IIS.net site). Explains a feature built into Web Deploy 3.0 that automates handling of an app\_offline.htm file. This feature does not work with custom app\_offline.htm files.
- [How to take your web app offline during publishing](http://sedodream.com/2012/01/08/HowToTakeYourWebAppOfflineDuringPublishing.aspx) (Sayed Hashimi's blog). How to automate the process of using a custom app\_offline.htm file.
- [Web publishing updates for app offline and usechecksum](https://blogs.msdn.com/b/webdev/archive/2013/10/30/web-publishing-updates-for-app-offline-and-usechecksum.aspx) (Microsoft Web Development blog). Another option for automating use of app\_offline.htm file.
- [Web Deploy 3.5 RTW](https://blogs.iis.net/msdeploy/archive/2013/07/09/webdeploy-3-5-rtw.aspx) (IIS.net site). New feature in Web Deploy 3.5 for custom app\_offline.htm files.


<a id="databasewithweb"></a>


## Deploying a database or changes to a database as part of web application deployment

- [Configuring Database Deployment in Visual Studio](https://msdn.microsoft.com/en-us/library/dd394698.aspx#dbdeployment) (MSDN). Overview of options for deploying a database with a web project.
- [ASP.NET Web Deployment using Visual Studio](../web-forms/overview/deployment/visual-studio-web-deployment/introduction.md). 12-part tutorial series, shows database deployment by using dbDacFx provider and Entity Framework Code First Migrations.
- [How to: Deploy a Web Project Using One-Click Publish in Visual Studio](https://msdn.microsoft.com/en-us/library/dd465337.aspx) (MSDN).
- [Deploy a Secure ASP.NET MVC 5 app with Membership, OAuth, and SQL Database to a Windows Azure Web Site](https://www.windowsazure.com/en-us/develop/net/tutorials/web-site-with-sql-database/). A long tutorial that builds and deploys an application that uses a single SQL Server database both for membership and application data.
- [Deploying an ASP.NET Web Application with SQL Server Compact using Visual Studio](../web-forms/overview/older-versions-getting-started/deployment-to-a-hosting-provider/deployment-to-a-hosting-provider-introduction-1-of-12.md). 12-part tutorial series, shows how to deploy SQL Server Compact databases and how to migrate from SQL Server Compact to a full edition of SQL Server.

See also  Deploying a web application by creating and installing a web deployment package and  Deploying a web application using a continuous integration (CI) process earlier in this page.


<a id="databaseseparate"></a>


## Deploying a database separately from web application deployment

- [SQL Server Data Tools](https://msdn.microsoft.com/en-us/library/hh272686(v=vs.103).aspx) (MSDN).
- [Including Data in a SQL Server Database Project](https://blogs.msdn.com/b/ssdt/archive/2012/02/02/including-data-in-an-sql-server-database-project.aspx) (SQL Server Data Tools team blog). How to deploy both schema and data when deploying a database.
- [How to Deploy a Database to Windows Azure](https://www.windowsazure.com/en-us/manage/services/sql-databases/how-to-deploy-a-sqldb/) (Microsoft Azure site)
- [Migrating Databases to Windows Azure SQL Database (formerly SQL Azure)](https://msdn.microsoft.com/en-us/library/windowsazure/ee730904.aspx) (MSDN).
- [Migrating a Database to SQL Azure using SSDT](https://blogs.msdn.com/b/ssdt/archive/2012/04/19/migrating-a-database-to-sql-azure-using-ssdt.aspx) (SQL Server Data Tools team blog).
- [Migrating Data-Centric Applications to Windows Azure](https://msdn.microsoft.com/en-us/library/jj156154.aspx) (MSDN).
- [Migrating SQL Server Databases to Windows Azure SQL Database](https://msdn.microsoft.com/en-us/library/windowsazure/jj156160.aspx) (MSDN).
- [SQL Database Migration Wizard](http://sqlazuremw.codeplex.com/) (CodePlex.) A tool for migrating to Windows Azure SQL Database.


<a id="aspnetmembership"></a>


## Deploying a web application that uses ASP.NET application services such as membership and profiling

- [Deploy a Secure ASP.NET MVC 5 app with Membership, OAuth, and SQL Database to a Windows Azure Web Site](https://www.windowsazure.com/en-us/develop/net/tutorials/web-site-with-sql-database/). A long tutorial that builds and deploys an application that uses a single SQL Server database both for membership and application data.
- [ASP.NET Identity](https://asp.net/identity/). Resources for ASP.NET Identity.
- [ASP.NET Web Deployment using Visual Studio](../web-forms/overview/deployment/visual-studio-web-deployment/introduction.md). 12-part tutorial series, shows how to deploy an ASP.NET membership database.
- [Configuring a Website that Uses Application Services](../web-forms/overview/older-versions-getting-started/deploying-web-site-projects/configuring-a-website-that-uses-application-services-cs.md). For web site projects but is also relevant for web application projects.
- [Users and Roles On The Production Website](../web-forms/overview/older-versions-getting-started/deploying-web-site-projects/users-and-roles-on-the-production-website-cs.md). For web site projects but is also relevant for web application projects.


<a id="precompiling"></a>


## Precompiling for deployment

- [ASP.NET Web Application Project Precompilation Overview](https://msdn.microsoft.com/en-us/library/aa983464.aspx) (MSDN).
- [Package/Publish Web Tab, Project Properties](https://msdn.microsoft.com/en-us/library/dd410108.aspx) (MSDN).
- [Advanced Precompile Settings Dialog Box](https://msdn.microsoft.com/en-us/library/hh475319.aspx) (MSDN).


<a id="intranet"></a>


## Deploying an intranet web application

- [Use the On-Premises Organizational Authentication Option (ADFS) With ASP.NET in Visual Studio 2013](http://www.cloudidentity.com/blog/2014/02/12/use-the-on-premises-organizational-authentication-option-adfs-with-asp-net-in-visual-studio-2013/) (Blog by Vittorio Bertocci.).
- [How to Create an Intranet Site Using ASP.NET MVC](https://msdn.microsoft.com/en-us/library/gg703322(VS.98).aspx) (MSDN). Older walkthrough writen for Visual Studio 2010, does not reflect major changes in intranet project templates introduced in Visual Studio 2013.


<a id="automating"></a>


## Automating common deployment tasks that are not automated out of the box

- [ASP.NET Web Deployment using Visual Studio: Deploying Extra Files](../web-forms/overview/deployment/visual-studio-web-deployment/deploying-extra-files.md).
- [Setting Folder Permissions on Web Publish](http://sedodream.com/2011/11/08/SettingFolderPermissionsOnWebPublish.aspx) (Sayed Hashimi's blog).
- [How to extend the targets file to include registry settings for a web project package](https://blogs.msdn.com/webdevtools/archive/2010/02/09/how-to-extend-target-file-to-include-registry-settings-for-web-project-package.aspx) (Web Development Tools blog).
- [Extending XML (Web.config) transformation](http://sedodream.com/2010/09/09/ExtendingXMLWebconfigConfigTransformation.aspx) (Sayed Hashimi's blog). Shows how to create custom XDT transforms.
- [Web Deployment Tool (MSDeploy) Custom Provider Take 1](http://sedodream.com/2010/03/11/WebDeploymentToolMSDeployCustomProviderTake1.aspx) (Sayed Hashimi's blog). Shows how to create a Web Deploy custom provider.
- [How to package and deploy COM components](https://blogs.msdn.com/webdevtools/archive/2010/03/03/how-to-package-and-deploy-com-component.aspx) (Web Development Tools blog).
- [How to package .NET assemblies](https://blogs.msdn.com/webdevtools/archive/2010/02/19/how-to-package-com-component.aspx) (Web Development Tools blog). How to deploy assemblies to the GAC.
- [Script Out Everything - Initialize Your Windows Azure VM for Your Web Server with IIS, Web Deploy and Other Stuff](http://www.tugberkugurlu.com/archive/script-out-everything-initialize-your-windows-azure-vm-for-your-web-server-with-iis-web-deploy-and-other-stuff) (Tugberk Ugurlu's blog).


<a id="configuringservers"></a>


## Configuring web servers so that developers can deploy web applications to them using Web Deploy

- [Installing and Configuring Web Deploy for Administrator and non-administrator Deployments](https://www.iis.net/learn/install/installing-publishing-technologies/installing-and-configuring-web-deploy) (IIS.net site).


<a id="hostingprovider"></a>


## Configuring servers for a hosting provider

- [Microsoft ASP.NET 4 Hosting Deployment Guide](https://go.microsoft.com/fwlink/?LinkId=191365) (Microsoft Download Center).
- [Generate a Profile XML File](https://www.iis.net/learn/web-hosting/joining-the-web-hosting-gallery/generate-a-profile-xml-file) (IIS.net site).


<a id="troubleshooting"></a>


## Troubleshooting deployment problems

- [Troubleshooting Windows Azure Web Sites in Visual Studio](https://www.windowsazure.com/en-us/documentation/articles/web-sites-dotnet-troubleshoot-visual-studio/) (Microsoft Azure site).
- [ASP.NET Web Deployment using Visual Studio: Troubleshooting](../web-forms/overview/deployment/visual-studio-web-deployment/troubleshooting.md).
- [Troubleshooting Common Problems With Web Deploy](https://www.iis.net/learn/publish/troubleshooting-web-deploy/troubleshooting-common-problems-with-web-deploy).
- [Web Deploy Error Codes](https://www.iis.net/learn/publish/troubleshooting-web-deploy/web-deploy-error-codes) (IIS.net site).
- [Web Deployment FAQ for Visual Studio and ASP.NET](https://msdn.microsoft.com/en-us/library/ee942158.aspx) (MSDN).
- [Core Differences Between IIS and the ASP.NET Development Server](../web-forms/overview/older-versions-getting-started/deploying-web-site-projects/core-differences-between-iis-and-the-asp-net-development-server-cs.md).
- [Common Configuration Differences Between Development and Production](../web-forms/overview/older-versions-getting-started/deploying-web-site-projects/common-configuration-differences-between-development-and-production-cs.md).
- [Hosting ASP.NET Applications in Medium Trust](http://www.4guysfromrolla.com/articles/100307-1.aspx) (4 Guys from Rolla site).


<a id="gettinghelp"></a>


## Getting help with a specific deployment question

- [ASP.NET Configuration and Deployment forum](https://forums.asp.net/26.aspx/1?Configuration and Deployment).
- [StackOverflow.com](http://www.StackOverflow.com).


<a id="additional"></a>


## Additional Resources

This section provides links to additional resources that are useful for learning more about how to use Visual Studio and IIS deployment tools.

The following blogs frequently contain information about Visual Studio web deployment:

- [Web Development Tools at Microsoft blog](https://blogs.msdn.com/b/webdevtools/).
- [Sayed Hashimi's blog](http://www.sedodream.com/).

The following resources provide documentation about Web Deploy, the IIS framework that Visual Studio uses to perform web application project deployment tasks. You can ask questions about Web Deploy in the [Web Deployment Tool forum](https://go.microsoft.com/fwlink/?LinkId=149411) on the IIS.net web site.

- [Introduction to Web Deploy](https://www.iis.net/learn/publish/using-web-deploy/introduction-to-web-deploy).
- [Installing and Configuring Web Deploy](https://www.iis.net/learn/install/installing-publishing-technologies/installing-and-configuring-web-deploy).
- [PowerShell Scripts for Automating Web Deploy Setup](https://www.iis.net/learn/publish/using-web-deploy/powershell-scripts-for-automating-web-deploy-setup).
- [Web Deployment Tool](https://go.microsoft.com/fwlink/?LinkId=151481). Top-level table of contents node for Web Deploy documentation on the TechNet site. Includes useful reference information but most of the TechNet pages have not been updated for years.
- [Microsoft.Web.Deployment Namespace](https://go.microsoft.com/fwlink/?LinkId=148630). API documentation, has not been updated since version 1.0.
- [The Microsoft Web Deployment Team blog](https://blogs.iis.net/msdeploy/default.aspx).
- [Publish tab in IIS.net web site](https://www.iis.net/learn/publish).