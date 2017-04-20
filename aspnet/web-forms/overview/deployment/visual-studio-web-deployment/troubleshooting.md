---
uid: web-forms/overview/deployment/visual-studio-web-deployment/troubleshooting
title: "ASP.NET Web Deployment using Visual Studio: Troubleshooting | Microsoft Docs"
author: tdykstra
description: "This tutorial series shows you how to deploy (publish) an ASP.NET web application to Azure App Service Web Apps or to a third-party hosting provider, by usin..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 06/01/2015
ms.topic: article
ms.assetid: c0090595-ab3b-4b9b-9e16-7a1891e8cb2f
ms.technology: dotnet-webforms
ms.prod: .net-framework
msc.legacyurl: /web-forms/overview/deployment/visual-studio-web-deployment/troubleshooting
msc.type: authoredcontent
---
ASP.NET Web Deployment using Visual Studio: Troubleshooting
====================
by [Tom Dykstra](https://github.com/tdykstra)

[Download Starter Project](http://go.microsoft.com/fwlink/p/?LinkId=282627)

> This tutorial series shows you how to deploy (publish) an ASP.NET web application to Azure App Service Web Apps or to a third-party hosting provider, by using Visual Studio 2012 or Visual Studio 2010. For information about the series, see [the first tutorial in the series](introduction.md).


This page describes some common problems that may arise when you deploy an ASP.NET web application by using Visual Studio. For each one, one or more possible causes and corresponding solutions are provided.

The scenarios shown apply to both Azure and third-party hosting providers. For more information about troubleshooting web apps in Azure App Service, see the following resources:

- [Troubleshoot a web app in Azure App Service using Visual Studio](https://azure.microsoft.com/en-us/documentation/articles/web-sites-dotnet-troubleshoot-visual-studio/)
- [Monitor Web Apps in Azure App Service](https://azure.microsoft.com/en-us/documentation/articles/web-sites-monitor//)
- [Announcing the release of Windows Azure SDK 2.0 for .NET](http://https://weblogs.asp.net/scottgu/announcing-the-release-of-windows-azure-sdk-2-0-for-net) (ScottGu's blog, shows how to get diagnostic logs in Visual Studio)

## Server Error in '/' Application - Current Custom Error Settings Prevent Details of the Error from Being Viewed Remotely

### Scenario

After deploying a site to a remote host, you get an error message that mentions the customErrors setting in the Web.config file but doesn't indicate what the actual cause of the error was:

[!code-xml[Main](troubleshooting/samples/sample1.xml)]

### Possible Cause and Solution

By default, ASP.NET shows detailed error information only when your web application is running on the local computer. Generally you don't want to display detailed error information when your web application is publicly available over the Internet, because hackers may be able to use this information to find vulnerabilities in the application. However, when you are deploying a site or updates to a site, sometimes something will go wrong and you need to get the actual error message.

To enable the application to display detailed error messages when it runs on the remote host, edit the Web.config file to set customErrors mode off, redeploy the application, and run the application again:

1. If the application Web.config file has acustomErrors element in thesystem.web element, change themode attribute to "off". Otherwise add acustomErrors element in thesystem.web element with themode attribute set to "off", as shown in the following example: 

    [!code-xml[Main](troubleshooting/samples/sample2.xml)]
2. Deploy the application.
3. Run the application and repeat whatever you did earlier that caused the error to occur. Now you can see what the actual error message is.
4. When you have resolved the error, restore the original customErrors setting and redeploy the application.

## Cannot create/shadow copy 'ContosoUniversity' when that file already exists.

### Scenario

When you try to run a project in Visual Studio you get an error page with a message like the following example:

Server Error in '/' Application. Cannot create/shadow copy 'ContosoUniversity' when that file already exists.

### Possible Cause and Solution

Wait a minute and refresh the browser, or recompile the site and try running it again.

## Access is Denied in a Web Page that Uses SQL Server Compact

### Scenario

When you deploy a site that uses SQL Server Compact and you run a page in the deployed site that accesses the database, you see the following error message:

Access is denied. (Exception from HRESULT: 0x80070005 (E\_ACCESSDENIED))

### Possible Cause and Solution

The NETWORK SERVICE account on the server needs to be able to read SQL Service Compact native binaries that are in the *bin\amd64* or *bin\x86* folder, but it does not have read permissions for those folders. Set read permission for NETWORK SERVICE on the *bin* folder, making sure to extend the permissions to subfolders.

## Cannot Read Configuration File Due to Insufficient Permissions

### Scenario

When you click the Visual Studio publish button to deploy an application to IIS on your local machine, publishing fails and the **Output** window shows an error message similar to this:

An error occurred when reading the IIS Configuration File 'MACHINE/REDIRECTION'. The identity performing this operation was ... Error: Cannot read configuration file due to insufficient permissions.

### Possible Cause and Solution

To use one-click publish to IIS on your local machine, you must be running Visual Studio with administrator permissions. Close Visual Studio and restart it with administrator permissions.

## Could Not Connect to the Destination Computer ... Using the Specified Process

### Scenario

When you click the Visual Studio publish button to deploy an application, publishing fails and the **Output** window shows an error message similar to this:

[!code-console[Main](troubleshooting/samples/sample3.cmd)]

### Possible Cause and Solution

A proxy server is interrupting communication with the destination server. From the Windows Control Panel or in Internet Explorer, select **Internet Options** and select the **Connections** tab. In the **Internet Properties** dialog box, click **LAN Settings**. In the **Local Area Network (LAN) Settings** dialog box, clear the **Automatically detect settings** checkbox. Then click the publish button again.

If the problem persists, contact your system administrator to determine what can be done with proxy or firewall settings. The problem happens because Web Deploy uses a non-standard port for Web Management Service deployment (8172); for other connections, Web Deploy uses port 80. When you are deploying to a third-party hosting provider, you are typically using the Web Management Service.

## Default .NET 4.0 Application Pool Does Not Exist

### Scenario

When you deploy an application that requires the .NET Framework 4, you see the following error message:

The default .NET 4.0 application pool does not exist or the application could not be added. Please verify that ASP.NET 4.0 is installed on this machine.

### Possible Cause and Solution

ASP.NET 4 is not installed in IIS. If the server you are deploying to is your development computer and has Visual Studio 2010 installed on it, ASP.NET 4 is installed on the computer but might not be installed in IIS. On the server that you are deploying to, open an elevated command prompt and install ASP.NET 4 in IIS by running the following commands:

[!code-console[Main](troubleshooting/samples/sample4.cmd)]

You might also need to manually set the .NET Framework version of the default application pool. For more information, see the Deploying to IIS as a Test Environment tutorial in this series.

## Format of the initialization string does not conform to specification starting at index 0.

### Scenario

After you deploy an application using one-click publish, when you run a page that accesses the database you get the following error message:

Format of the initialization string does not conform to specification starting at index 0.

### Possible Cause and Solution

Open the *Web.config* file in the deployed site and check to see whether the connection string values begin with $(ReplacableToken\_, as in the following example:

[!code-xml[Main](troubleshooting/samples/sample5.xml)]

If the connection strings look like this example, edit the project file and add the following property to the PropertyGroup element that is for all build configurations:

[!code-xml[Main](troubleshooting/samples/sample6.xml)]

Then redeploy the application.

## HTTP 500 Internal Server Error

### Scenario

When you run the deployed site, you see the following error message without specific information indicating the cause of the error:

HTTP Error 500 - Internal Server Error.

### Possible Cause and Solution

There are many causes of 500 errors, but one possible cause if you are following these tutorials is that you put an XML element in the wrong place in one of the Web.config transformation files. For example, you would get this error if you put the transformation that inserts a &lt;location&gt; element under &lt;system.web&gt; instead of directly under &lt;configuration&gt;. You can use the Web.config transform preview feature to verify that transformations are working as intended. The solution if you find a transform that was coded incorrectly is to correct the transformation file and redeploy. If an error isn't obvious, try commenting out transforms and redeploying to see which one is causing the 500 error.

## HTTP 500.21 Internal Server Error

### Scenario

When you run the deployed site, you see the following error message:

HTTP Error 500.21 - Internal Server Error. Handler "PageHandlerFactory-Integrated" has a bad module "ManagedPipelineHandler" in its module list.

### Possible Cause and Solution

The site you have deployed targets ASP.NET 4, but ASP.NET 4 is not registered in IIS on the server. On the server open an elevated command prompt and register ASP.NET 4 by running the following commands:

[!code-console[Main](troubleshooting/samples/sample7.cmd)]

You might also need to manually set the .NET Framework version of the default application pool. For more information, see the Deploying to IIS as a Test Environment tutorial in this series.

## Login Failed Opening SQL Server Express Database in App\_Data

### Scenario

You updated the *Web.config* file connection string to point to a SQL Server Express database as an *.mdf* file in your *App\_Data* folder, and the first time you run the application you see the following error message:

System.Data.SqlClient.SqlException: Cannot open database "DatabaseName" requested by the login. The login failed.

### Possible Cause and Solution

The name of the *.mdf* file cannot match the name of any SQL Server Express database that has ever existed on your computer, even if you deleted the *.mdf* file of the previously existing database. Change the name of the *.mdf* file to a name that has never been used as a database name and change the *Web.config* file to use the new name. As an alternative, you can use [SQL Server Management Studio Express](https://www.microsoft.com/en-us/download/details.aspx?displaylang=en&amp;id=7593) to delete previously existing SQL Server Express databases.

## Model Compatibility Cannot be Checked

### Scenario

You updated the *Web.config* file connection string to point to a new SQL Server Express database, and the first time you run the application you see the following error message:

Model compatibility cannot be checked because the database does not contain model metadata. Ensure that IncludeMetadataConvention has been added to the DbModelBuilder conventions.

### Possible Cause and Solution

If the database name you put in the Web.config file was ever used before on your computer, a database might already exist with some tables in it. Select a new name that has not been used on your computer before and change the *Web.config* file to point to use this new database name. As an alternative, you can use [SQL Server Express Utility](https://www.microsoft.com/en-us/download/details.aspx?DisplayLang=en&amp;id=3990) or [SQL Server Management Studio Express](https://www.microsoft.com/en-us/download/details.aspx?displaylang=en&amp;id=7593) to delete the existing database.

## SQL Error When a Script Attempts to Create Users or Roles

### Scenario

You are using database deployment configured on the **Package/Publish SQL** tab, SQL scripts that run during deployment include Create User or Create Role commands, and script execution fails when those commands are executed. You might see more detailed messages, such as the following:

[!code-console[Main](troubleshooting/samples/sample8.cmd)]

If this error occurs when you have configured database deployment in the **Publish Web** wizard rather than the **Package/Publish SQL** tab, create a thread in the [Configuration and Deployment](https://forums.asp.net/26.aspx/1?Configuration+and+Deployment) forum, and the solution will be added to this troubleshooting page.

### Possible Cause and Solution

The user account you are using to perform deployment does not have permission to create users or roles. For example, the hosting company might assign the db\_datareader, db\_datawriter, and db\_ddladmin roles to the user account that it sets up for you. These are sufficient for creating most database objects, but not for creating users or roles. One way to avoid the error is by excluding users and roles from database deployment. You can do this by editing the PreSource element for the database's automatically generated script so that it includes the following attributes:

[!code-console[Main](troubleshooting/samples/sample9.cmd)]

For information about how to edit the PreSource element in the project file, see [How to: Edit Deployment Settings in the Project File](https://msdn.microsoft.com/en-us/library/ff398069(v=vs.100).aspx). If the users or roles in your development database need to be in the destination database, contact your hosting provider for assistance.

## SQL Server Timeout Error When Running Custom Scripts During Deployment

### Scenario

You have specified custom SQL scripts to run during deployment, and when Web Deploy runs them, they time out.

### Possible Cause and Solution

Running multiple scripts that have different transaction modes can cause time-out errors. By default, automatically generated scripts run in a transaction, but custom scripts do not. If you select the **Pull data and/or schema from an existing database** option on the **Package/Publish SQL** tab, and if you add a custom SQL script, you must change transaction settings on some scripts so that all scripts use the same transaction settings. For more information, see [How to: Deploy a Database With a Web Application Project](https://msdn.microsoft.com/en-us/library/dd465343.aspx).

If you have configured transaction settings so that all are the same but still get this error, a possible workaround is to run the scripts separately. In the **Database Scripts** grid in the **Package/Publish** SQL tab, clear the **Include** check box for the script that causes the timeout error, then publish the project. Then go back into the **Database Scripts** grid, select that script's **Include** check box, and clear the **Include** check boxes for the other scripts. Then publish the project again. This time when you publish, only the selected custom script runs.

## Stream Data of Site Manifest Is Not Yet Available

### Scenario

When you are installing a package using the *deploy.cmd* file with the t (test) option, you see the following error message:

Error: The stream data of 'sitemanifest/dbFullSql[@path='C:\TEMP\AdventureWorksGrant.sql']/sqlScript' is not yet available.

### Possible Cause and Solution

The error message means that the command cannot produce a test report. However, the command might run if you use the y (actual installation) option. The message indicates only that there is a problem with running the command in test mode.

## This Application Requires ManagedRuntimeVersion v4.0

### Scenario

When you attempt to deploy, you see the following error message:

The application pool that you are trying to use has the 'managedRuntimeVersion' property set to 'v2.0'. This application requires 'v4.0'.

### Possible Cause and Solution

ASP.NET 4 is not installed in IIS. If the server you are deploying to is your development computer and has Visual Studio 2010 installed on it, ASP.NET 4 is installed on the computer but might not be installed in IIS. On the server that you are deploying to, open an elevated command prompt and install ASP.NET 4 in IIS by running the following commands:

[!code-console[Main](troubleshooting/samples/sample10.cmd)]

## Unable to cast Microsoft.Web.Deployment.DeploymentProviderOptions

### Scenario

When you are deploying a package, you see the following error message:

Unable to cast object of type 'Microsoft.Web.Deployment.DeploymentProviderOptions' to 'Microsoft.Web.Deployment.DeploymentProviderOptions'.

### Possible Cause and Solution

You are trying to deploy from IIS Manager using the Web Deploy 1.1 UI to a server that has Web Deploy 2.0 installed. If you are using the IIS Remote Administration Tool to deploy by importing a package, check the **New Features Available** dialog box when you establish the connection. (This dialog box might only be shown once when the connection is first established. To clear the connection and start over, close IIS Manager and start it up again by entering inetmgr /reset at the command prompt.) If one of the features listed is **Web Deploy UI**, and it has a version number lower than 8, the server you are deploying to might have both 1.1 and 2.0 versions of Web Deploy installed. To deploy from a client that has 2.0 installed, the server must have only Web Deploy 2.0 installed. You will have to contact your hosting provider to resolve this problem.

## Unable to load the native components of SQL Server Compact

### Scenario

When you run the deployed site, you see the following error message:

Unable to load the native components of SQL Server Compact corresponding to the ADO.NET provider of version 8482. Install the correct version of SQL Server Compact. Refer to KB article 974247 for more details.

### Possible Cause and Solution

The deployed site does not have *amd64* and *x86* subfolders with the native assemblies in them under the application's *bin* folder. On a computer that has SQL Server Compact installed, the native assemblies are located in *C:\Program Files\Microsoft SQL Server Compact Edition\v4.0\Private*. The best way to get the correct files into the correct folders in a Visual Studio project is to install the NuGet SqlServerCompact package. Package installation adds a post-build script to copy the native assemblies into *amd64* and *x86*. In order for these to be deployed, however, you have to manually include them in the project. For more information, see the [Deploying SQL Server Compact](../../older-versions-getting-started/deployment-to-a-hosting-provider/deployment-to-a-hosting-provider-deploying-sql-server-compact-databases-2-of-12.md) tutorial.

## "Path is not valid" error after deploying an Entity Framework Code First application

### Scenario

You deploy an application that uses Entity Framework Code First Migrations and a DBMS such as SQL Server Compact which stores its database in a file in the App\_Data folder. You have Code First Migrations configured to create the database after your first deployment. When you run the application you get an error message like the following example:

The path is not valid. Check the directory for the database. [Path = c:\inetpub\wwwroot\App\_Data\DatabaseName.sdf ]

### Possible Cause and Solution

Code First is attempting to create the database but the App\_Data folder does not exist. Either you didn't have any files in the *App\_Data* folder when you deployed, or you selected **Exclude App\_Data** on the **Package/Publish Web** tab of the Project Properties window. The deployment process won't create a folder on the server if there are no files in the folder to be copied to the server. If you already had the database set up in the site, the deployment process will delete the files and the *App\_Data* folder itself if you selected **Remove additional files at destination** in the publish profile. To solve the problem, put a placeholder file such as a .txt file in the *App\_Data* folder, make sure you do not have **Exclude App\_Data** selected, and redeploy.

## "COM object that has been separated from its underlying RCW cannot be used."

### Scenario

You have been successfully using one-click publish to deploy your application and then you start getting this error:

Web deployment task failed. (Could not complete the request to remote agent URL 'https://serverurl.com/msdeploy.axd?site=sitename'.)  
 Could not complete the request to remote agent URL 'https://url/msdeploy.axd?site=sitename'.  
The request was aborted: The request was canceled.  
COM object that has been separated from its underlying RCW cannot be used.

### Possible Cause and Solution

Closing and restarting Visual Studio is usually all that is required to resolve this error.

## Deployment Fails Because User Credentials Used for Publishing Don't Have setACL Authority

### Scenario

Publishing fails with an error that indicates you don't have authority to set folder permissions (the user account you are using doesn't have setACL authority).

### Possible Cause and Solution

By default, Visual Studio sets read permissions on the root folder of the site and write permissions on the App\_Data folder. If you know that the default permissions on site folders are correct and do not need to be set, you disable this behavior by adding **&lt;IncludeSetACLProviderOn Destination&gt;False&lt;/IncludeSetACLProviderOnDestination&gt;** to the publish profile file (to affect a single profile) or to the wpp.targets file (to affect all profiles). For information about how to edit these files, see [How to: Edit Deployment Settings in Profile (.pubxml) Files](https://msdn.microsoft.com/en-us/library/ff398069.aspx).

## Access Denied Errors when the Application Tries to Write to an Application Folder

### Scenario

Your application errors when it tries to create or edit a file in one of the application folders, because it does not have write authority for that folder.

### Possible Cause and Solution

By default, Visual Studio sets read permissions on the root folder of the site and write permissions on the App\_Data folder. If your application needs write access to a sub-folder, you can set permissions for that folder as shown in the Setting Folder Permissions and Deploying to the Production Environment tutorials in this series. If your application needs write access to the root folder of the site, you have to prevent it from setting read-only access on the root folder by adding **&lt;IncludeSetACLProviderOn Destination&gt;False&lt;/IncludeSetACLProviderOnDestination&gt;** to the publish profile file (to affect a single profile) or to the wpp.targets file (to affect all profiles). For information about how to edit these files, see [How to: Edit Deployment Settings in Profile (.pubxml) Files](https://msdn.microsoft.com/en-us/library/ff398069.aspx).

<a id="aspnet45error"></a>

## Configuration Error - targetFramework attribute references a version that is later than the installed version of the .NET Framework

### Scenario

You successfully published a web project that targets ASP.NET 4.5, but when you run the application (with the customErrors mode set to "off" in the Web.config file) you get the following error:

The 'targetFramework' attribute in the &lt;compilation&gt; element of the Web.config file is used only to target version 4.0 and later of the .NET Framework (for example, '&lt;compilation targetFramework="4.0"&gt;'). The 'targetFramework' attribute currently references a version that is later than the installed version of the .NET Framework. Specify a valid target version of the .NET Framework, or install the required version of the .NET Framework.

The Source Error box of the error page highlights the following line from Web.config as the cause of the error:

&lt;compilation targetFramework="4.5" /&gt;

### Possible Cause and Solution

The server does not support ASP.NET 4.5. Contact the hosting provider to determine when and if support for ASP.NET 4.5 can be added. If upgrading the server is not an option, you have to deploy a web project that targets ASP.NET 4 or earlier instead.

If you deploy an ASP.NET 4 or earlier web project to the same destination, select the **Remove additional files at destination** check box on the **Settings** tab of the **Publish Web** wizard. If you don't select **Remove additional files at destination**, you will continue to get the Configuration Error page.

The project **Properties** windows includes a Target framework drop-down list, but you can't resolve this problem by just changing that from **.NET Framework 4.5** to **.NET Framework 4**. If you change the target framework to an earlier framework version, the project will still have references to the later framework version's assemblies and will not run. You have to manually change those references or create a new project that targets .NET Framework 4 or earlier. For more information, see [.NET Framework Targeting for Web Sites](https://msdn.microsoft.com/en-us/library/bb398791(v=vs.100).aspx).

## Medium Trust Errors

### Scenario

When you run your application in production, it gets an error related to medium trust.

### Possible Cause and Solution

Many third-party hosting providers run your web site in medium trust, which means that there are some things it isn't allowed to do. For example, application code can't access the Windows registry and can't read or write files that are outside of your application's folder hierarchy. By default your application runs in *full trust* on your local computer, which means that the application might be able to do things that would fail when you deploy it to production.

You can configure the application to run in medium trust in the local IIS environment in order to troubleshoot. To do that, open the application *Web.config* file, and add a **trust** element in the **system.web** element, as shown in this example.

[!code-xml[Main](troubleshooting/samples/sample11.xml)]

The application will now run in medium trust in IIS even on your local computer.

Don't do this if you are deploying to Azure App Service, because Azure does not require medium trust. At the time this tutorial is being written in February, 2012, using this method to make your application run in medium trust will cause an error in Azure.

If you are using Entity Framework Code First Migrations and you are deploying to a hosting provider that runs your application in medium trust, make sure that you have version 5.0 or later installed. In Entity Framework version 4.3, Migrations requires full trust in order to update the database schema.

## HTTP 404.17 Not Found Error

### Scenario

When you run the deployed site on your development computer in IIS, you see the following error message reporting that the server can't process Default.aspx:

HTTP Error 404.17 - Not Found

The requested content appears to be script and will not be served by the static file handler.

### Possible Cause and Solution

ASP.NET 4.5 might not be installed on your computer. See the steps in the Deploying to IIS as a Test Environment tutorial in this series that explain how to install ASP.NET 4.5.

>[!div class="step-by-step"]
[Previous](deploying-extra-files.md)