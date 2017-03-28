---
uid: web-pages/readme/overview
title: "WebMatrix Readme | Microsoft Docs"
author: rick-anderson
description: "WebMatrix and ASP.NET Web Pages (Razor) 1.0 Release Readme"
ms.author: aspnetcontent
manager: wpickett
ms.date: 01/06/2011
ms.topic: article
ms.assetid: 36c5beeb-45a7-48a0-9c30-f82cdf5c5f5f
ms.technology: dotnet-webpages
ms.prod: .net-framework
msc.legacyurl: /web-pages/readme
msc.type: content
---
WebMatrix Readme
====================
13 January 2011

## Contents

> [!NOTE]
> This readme applies to the 1.0 release of WebMatrix.


- [Overview](#Overview)
- [Installation](#Installation_Notes)
- [How to Publish Applications](#InstructionsForPublishingApplications)
- [Changes and Issues](#ChangesAndIssues)

    - [WebMatrix 1.0 Installation](#Known_Issues_Installation)
    - [ASP.NET Web Pages](#Known_Issues_ASPNET)
    - [WebMatrix](#Known_Issues_WebMatrix)
    - [IIS Express](#Known_Issues_IISExpress)
    - [SQL Server Compact](#Known_Issues_SQLServerCompact)
    - [Installing Applications](#Known_Issues_Installing_Applications)
    - [Publishing Applications](#Known_Issues_Publishing_Applications)
- [For More Information](#More_Info)

<a id="Overview"></a>

## Overview

> Microsoft WebMatrix 1.0 is a free web development stack that installs in minutes. It integrates a web server with database and programming frameworks to create a single, integrated experience. You can use WebMatrix to streamline the way you code, test, and publish your own ASP.NET or PHP website, or you can use WebMatrix to start a new website using popular open-source apps like DotNetNuke, Umbraco, WordPress, or Joomla. WebMatrix uses the same powerful web server, database engine, and frameworks environment that will run your website on the internet, which makes the transition from development to production smooth and seamless.


<a id="Installation_Notes"></a>

## Installation

> To install WebMatrix 1.0, you must first install the [Microsoft Web Platform Installer 3.0](https://go.microsoft.com/fwlink/?LinkID=194638). After you've installed the Web Platform Installer, you can use it to install WebMatrix.
> 
> If you have problems during installation, refer to [Troubleshooting Problems with Microsoft Web Platform Installer](https://go.microsoft.com/fwlink/?LinkId=196212).


<a id="InstructionsForPublishingApplications"></a>
## How to Publish Applications

> See [Step-by-Step Instructions for Publishing Applications](https://go.microsoft.com/fwlink/?LinkID=196149)


<a id="ChangesAndIssues"></a>

## Changes and Issues

<a id="Known_Issues_Installation"></a>

### WebMatrix 1.0 Installation Issues

#### Issue: WebMatrix 1.0 is available only on platforms that support Microsoft .NET Framework 4

> The .NET Framework version 4 is required for WebMatrix. In certain cases, the WebMatrix 1.0 installer will let you try to install on a platform that is not part of the supported configuration set. In particular, Windows Vista without the SP1 update will let you begin the installation of WebMatrix, but the .NET Framework 4 component will fail and block your installation.
> 
> **Workaround**  
> Install on a supported platform, which includes:
> 
> - Windows 7
> - Windows Server 2008
> - Windows Server 2008 R2
> - Windows Vista SP1 or later
> - Windows XP SP3
> - Windows Server 2003 SP2


#### Issue: Cannot install WebMatrix 1.0 if Microsoft Visual Studio 2008 is installed without Microsoft Visual Studio 2008 SP1

> **Workaround**  
> Install [Microsoft Visual Studio 2008 SP1](https://www.microsoft.com/downloads/details.aspx?FamilyId=FBEE1648-7106-44A7-9649-6D9F6D58056E&amp;displaylang=en) from the Microsoft Download Center.


#### Issue: Some assemblies for SQL Server Compact 4.0 are not installed in the GAC

> The managed assemblies for SQL Server Compact 4.0 are not placed in the global assembly cache (GAC) when you install SQL Server Compact 4.0 on a 64-bit computer and the computer has only the .NET Framework 3.5 SP1 Client Profile installed. The managed assemblies that are not installed in the GAC are:
> 
> - *System.Data.SqlServerCe.dll* (ADO.NET provider)
> - *System.Data.SqlServerCe.Entity.dll* (ADO.NET Entity Framework )
> 
> **Workaround**  
> Uninstall SQL Server Compact 4.0. Download and install the full version of .NET Framework 3.5 SP1 from the following location:  
>   
> [Microsoft .NET Framework 3.5 Service pack 1 (Full Package)](https://go.microsoft.com/fwlink/?LinkId=194828)  
>   
> Then reinstall SQL Server Compact 4.0.


#### Issue: Cannot uninstall SQL Server Compact using the command line

> Uninstallation of SQL Server Compact using command-line options does not work in this release.
> 
> **Workaround**  
> Use *Programs and Features* in the Windows Control Panel to uninstall Microsoft SQL Server Compact 4.0.


<a id="Known_Issues_ASPNET"></a>

### ASP.NET Web Pages

This section of the document describes new features, changes, and known issues with the 1.0 release of ASP.NET Web Pages with Razor syntax.

- [New features](#NewFeatures)
- [Changes](#Changes)
- [Issues](#Issues)

#### <a id="NewFeatures"></a>  New Features

#### New: Configuration setting added to disable the package manager

> A new `asp:AdminManagerEnabled` key is available for the `<appSettings>` element in the *web.config* file, which lets you completely disable the package manager. The default value for this element is true, meaning that if it is not included in the *web.config* file, the package manager is enabled. To disable the package manager, add the following element to the *web.config* file in the root of the website:
> 
> [!code-xml[Main](overview/samples/sample1.xml)]


#### <a id="Changes"></a>  Changes

#### Change: "webPages:AdminFolderVirtualPath" key renamed to "asp:AdminFolderVirtualPath"

> The `webPages:AdminFolderVirtualPath` key that can be added to the *web.config* file to specify the location of the package manager has been renamed to use the `asp:` namespace instead of the `webPages` namespace. If you have used this element, you must rename it in the configuration file.


#### <a id="Issues"></a>  Known Issues

#### Issue: Passwords for membership users no longer recognized

> The algorithm for creating and storing membership (login) passwords has been changed to be more secure. As a result, the passwords stored for members (users) created in Beta versions of ASP.NET Razor will not be recognized. 
> 
> **Workaround** If the site has not yet been put into production, remove the user records from the membership database. If database is live, programmatically regenerate existing passwords in the membership database.


#### Issue: Unexpected behavior when using a custom user table for membership

> To initialize the membership provider for an ASP.NET Razor website, you call the `WebSecurity.InitializeDatabaseConnection` method. (In WebMatrix, the Starter Site template includes a call to this method in the *\_AppStart.cshtml* file.) If the `autoCreateTables` parameter of this method is set to true (by default, it is set to true in the Starter Site template), and if an unrecognized table name is passed to the method (the second parameter), the method does not throw an error. Instead, it automatically creates the table.
> 
> This can be a problem if you intend to use a custom user table for membership but pass the wrong table name to the `WebSecurity.InitializeDatabaseConnection` method. Because the method does not by default raise an error if the table you specify does not exist, and because it instead creates a new table, the application can appear to be working. However, application code that relies on your custom user table (and on fields in it) can eventually fail with unexpected errors.
> 
> **Workaround**  
> Make sure that the name passed in the `InitializeDatabaseConnection` method matches the user profile table in the membership database, or make sure that the `autoCreateTables` parameter is set to false.


#### Issue: Error message "The Admin Module requires access to ~/App\_Data"

> Under some circumstances, trying to create users or otherwise work with the ASP.NET membership system can cause the page to display the error *The Admin Module requires access to ~/App\_Data*. This occurs if the account that IIS or IIS Express is running under does not have permissions to create and write to the *App\_Data* folder under the website root. 
> 
> **Workaround** Manually create an *App\_Data* folder for the website. Then make sure that the Windows account that the application runs under (typically NETWORK SERVICE) has read/write permissions for root folders of the application and for subfolders such as App\_Data. More detailed information is available in the KnowledgeBase article [Problems with SQL Server Express user instancing and ASP.net Web Application Projects](https://support.microsoft.com/kb/2002980).


#### Issue: "Failed to generate a user instance of SQL Server" error

> If a WebMatrix Web application uses SQL Server Express and is running IIS 7.5 on Windows 7 or Windows Server 2008 R2, you might see an error that indicates that SQL Server cannot retrieve the user's local application path at run time.
> 
> **Workaround** Make sure that the Windows account that the application runs under (typically NETWORK SERVICE) has read/write permissions for root folders of the application and for subfolders such as *App\_Data*. More detailed information is available in the KnowledgeBase article [Problems with SQL Server Express user instancing and ASP.net Web Application Projects](https://support.microsoft.com/kb/2002980).


#### Issue: Files that contains package-manager resources or package-manager passwords are servable under IIS 6.0 and earlier

> If you deploy an ASP.NET Web Pages (Razor) application that was built using the RC2 release, and if the application contains a *password.txt* or *packagesources.txt* file under */App\_Data/admin*, IIS 6.0 will serve the file if requested, potentially exposing the passwords for your package manager instance. 
> 
> **Workaround** Rename the *password.txt* or *packagesources.txt* file to *password.config* or *packagesources.config*. By default, IIS 6.0 does not serve files that have the *.config* extension. (In IIS 7, no files in the *App\_Data* folder are served, so you do not need to rename the files.)


#### Issue: Uninstalling packages installed using the Beta 3 release does not completely remove package components

> If you installed a package using the package manager in the Beta 3 release and then try to uninstall it using the current release, the package is not completely uninstalled. Using the package manager's **Uninstall** button removes some components, but leaves the package's library code and does not update the *package.config* file.
> 
> **Workaround**   
> Perform these steps:  
> 1. Delete the *App\_Data\packages* folder. This removes all packages.   
> 2. Delete the *packages.config* file in the root of the website.


#### Issue: In Visual Studio, invoking the web-based package manager takes the application offline

> If you are working in Visual Studio (not WebMatrix) and use the *\_admin* functionality to start the package manager, Visual Studio takes the application offline and posts the *app\_offline.htm* into the website root, which disrupts your ability to use the package manager.
> 
> [!NOTE]
> Although you would most typically see this behavior when using the web-based package manager interface, the same behavior occurs if you add, remove, or modify any files in the *App\_Data* folder.
> 
> **Workaround**   
> To work with packages in Visual Studio, use the NuGet extension instead of the web-based package manager. For information, see the [NuGet documentation](http://nuget.codeplex.com/documentation?title=Getting%20Started). If you are working with other files in the *App\_Data* folder, consider keeping the files elsewhere to avoid this issue. If that's not practical, delete the *app\_offline.htm* file manually or wait until the site comes back online automatically (by default, after 30 seconds).


#### Issue: Visual Studio IntelliSense and project templates available only in ASP.NET MVC version 3

> Installing ASP.NET Web Pages does not also install tools for Visual Studio such as IntelliSense and project templates for ASP.NET Web Pages applications.
> 
> **Workaround** To use IntelliSense and project templates for ASP.NET Web Pages applications in Visual Studio, install ASP.NET MVC 3 RC either through the Web Platform Installer or the [stand-alone installer](https://go.microsoft.com/fwlink/?LinkID=191797).


#### Issue: Reading feeds or other external data via a proxy server

> If the server running the site is behind a proxy server, you might need to configure proxy information in the *web.config* file in order to be able to read information that comes from outside your site. For example, if you use the `ReCaptcha` helper, the helper communicates with the reCAPTCHA service, but might be blocked by your proxy server. Similarly, feeds that are used in ASP.NET Web Pages, such as the feed used by the package manager, might require proxy configuration.
> 
> If you experience problems in working with an external service or working with the package feed, put the following elements into your application's root *web.config* file:
> 
> [!code-xml[Main](overview/samples/sample2.xml)]
> 
> For more information about configuring a proxy server, see [&lt;proxy&gt; Element (Network Settings)](https://msdn.microsoft.com/en-us/library/sa91de1e.aspx) on the MSDN Web site.


#### Issue: Uninstalling the .NET Framework version 4 disables ASP.NET Web Pages with Razor Syntax

> If you uninstall the .NET Framework version 4 and then reinstall it, ASP.NET Web Pages with Razor syntax is disabled. Pages with the *.cshtml* extension do not run correctly. ASP.NET Web Pages registers an assembly in the machine root *web.config* file, and removing the .NET Framework removes that file. Reinstalling the .NET Framework installs a new version of the configuration file, but does not add the reference for the ASP.NET Web Pages assembly.
> 
> **Workaround** After reinstalling the .NET Framework, reinstall ASP.NET Web Pages with Razor syntax. This adds the following element to the *web.config* file in the machine root, which is typically in the following location:  
>   
> `C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config (32-bit)`  
> `C:\Windows\Microsoft.NET\Framework64\v4.0.30319\Config (64-bit)`
> 
> [!code-xml[Main](overview/samples/sample3.xml)]


#### Issue: Extensionless URLs do not find .cshtml/.vbhtml files on IIS 7 or IIS 7.5

> On IIS 7 or IIS 7.5, requests with a URL like the following are not able to find pages that have the *.cshtml* or *.vbhtml* extension:  
>   
> `http://www.example.com/ExampleSite/ExampleFile`  
>   
> The issue arises because URL rewriting is not enabled by default for IIS 7 or IIS 7.5. The likeliest scenario is that you do not see the problem when testing locally using IIS Express, but you experience it when you deploy your website to a hosting website.
> 
> **Workaround**
> 
> - If you have control over the server computer, on the server computer install the update that is described in [A update is available that enables certain IIS 7.0 or IIS 7.5 handlers to handle requests whose URLs do not end with a period](https://support.microsoft.com/kb/980368).
> - If you do not have control over the server computer (for example, you are deploying to a hosting website), add the following to the website's *web.config* file: 
> 
>     [!code-xml[Main](overview/samples/sample4.xml)]


#### Issue: Deploying an application to a computer that does not have SQL Server Compact installed

> Applications that include SQL Server Compact databases can run on a computer where SQL Server Compact is not installed. Microsoft WebMatrix 1.0 automatically copies these binaries for you and performs the appropriate *web.config* file transforms.
> 
> **Workaround** If you need to copy these files and make the *web.config* file changes manually, do the following:
> 
> 1. Copy the database engine assemblies to the *Bin* folder (and subfolders) of the application on the target computer:  
> 
>     - Copy *C:\Program Files\Microsoft SQL Server Edition\v4.0\Desktop\System.Data.SqlServerCe.dll*   
>         **to** *\Bin*
>     - Copy *C:\Program Files\Microsoft SQL Server Compact Edition\v4.0\Private\x86\\****to***\Bin\x86*
>     - Copy *C:\Program Files\Microsoft SQL Server Compact Edition\v4.0\Private\amd64\\** **to***\Bin\amd64*
> 2. In the root folder of the website, create or open a *web.config* file. (In WebMatrix 1.0, this file type is available if you click **All** in the **Choose a File Type** dialog box.)
> 3. Add the following element as a child of the `<configuration>` element (not inside the `<system.web>` element):
> 
>     [!code-xml[Main](overview/samples/sample5.xml)]


#### Issue: "Database" and "WebGrid" helpers do not work in Medium Trust in Visual Basic

> If you are using Visual Basic (creating *.vbhtml* files), the `Database` and `WebGrid` helpers will not work if the application is set to use Medium Trust.
> 
> **Workaround**  
> If you use Visual Studio 2010, you can resolve this problem by installing the Service Pack 1 release. Until the final version of the SP1 release is available, you can download the Beta version of SP1 from the [Microsoft Visual Studio 2010 Service Pack 1 Beta](https://www.microsoft.com/downloads/en/details.aspx?FamilyID=11ea69cb-cf12-4842-a3d7-b32a1e5642e2&amp;displaylang=en) page on the Microsoft Download Center.   
>   
> If this is not practical, or if you do not use Visual Studio 2010, you can temporarily set the application to use Full Trust.


#### Issue: "ApplicationPart" resources are externally accessible

> If an assembly contains objects that derives from the `ApplicationPart` class, that assembly's resources are exposed by the `ResourceRouteHandler` class. For example, consider the following URL:  
>   
> `~/r.ashx/System.Web.WebPages.Administration/Resources/AdminResources.resources`  
>   
> This request downloads all of the resource strings in the *System.Web.WebPages.Administration.dll* assembly. All of the embedded resources (even those that are not intended to be served as static content) are downloaded. If the embedded resources contain sensitive information, this can represent a security risk. 
> 
> **Workaround**   
> If you create an **ApplicationPart** object, make sure that the embedded resources associated with that **ApplicationPart** object's assembly do not contain sensitive information.


<a id="Known_Issues_WebMatrix"></a>

### WebMatrix

> [!NOTE]
> For information about installation issues for WebMatrix, see [WebMatrix Installation Issues](#Known_Issues_Installation) earlier in this document.


This section of the document describes known issues for the WebMatrix development environment.

#### Issue: Changes in the username or password of a database connection string in a web.config file are not reflected in the Databases workspace

> **Workaround**  
> 
> 1. In the *web.config* file, change the database name in the connection string (for example, add "1" to it).
> 2. Save the *web.config* file.
> 3. Click **Databases** and refresh.
> 4. Change the database name in the connection string in the *web.config* file back to the original database name.
> 5. Save the *web.config* file.
> 6. Click **Databases** and refresh.


#### Issue: Folders created by WebMatrix cannot be deleted

> If WebMatrix is running using elevated permissions (that is, you started WebMatrix using the **Run as Administrator** option in Windows), folders that are created by WebMatrix cannot be deleted using Windows Explorer.
> 
> **Workaround**  
> Run Windows Explorer using elevated permissions. Follow these steps:  
> 
> 1. In Windows, click **Start**.
> 2. Enter "Windows Explorer" and right-click the entry for **Windows Explorer**.
> 3. Click **Run as Administrator**. You can then delete the folders.


#### Issue: WebMatrix 1.0 is unable to perform certain tasks that require elevation

> WebMatrix 1.0 is unable to perform certain tasks that require elevation, such as installing additional components in the following situations:
> 
> - On Windows Vista or Windows 7, you are logged in with an account that does not have administrative privileges and User Account Control (UAC) is disabled.
> - You are using Microsoft Windows XP or Microsoft Windows Server 2003.
> 
> **Workaround**  
> Most tasks in WebMatrix 1.0 do not require administrative permission. For those that do, you can perform the operation as an administrator, or follow these steps:
> 
> - On Windows Vista or Windows 7, enable UAC.
> - On Windows XP, add the user to the Administrators security group.


#### Issue: "Site from Web Gallery" is disabled

> The **Site from Web Gallery** option is disabled if the Web Platform Installer 3.0 is not installed.
> 
> **Workaround**  
> Install the [Microsoft Web Platform Installer 3.0](https://go.microsoft.com/fwlink/?LinkID=194638).


#### Issue: Google Chrome is not available as a Run option

> Google Chrome is not displayed in the list of browsers under **Run** on the **Home** tab.
> 
> **Workaround**  
> Some versions of Google Chrome do not register themselves correctly with the Default Programs feature in Windows. As a workaround, start Google Chrome, click the *Customize and control Google Chrome* menu, click *Options*, and then click *Make Google Chrome my default browser*.


#### Issue: The "Foreign Key" dialog box doesn't allow entering a primary key

> The **Foreign Key** dialog box does not allow you to enter the primary key name from the primary key table.
> 
> **Workaround**  
> This is intentional. You do not need to enter the name of the primary key from the primary key table.


#### Issue: IntelliSense is not available in WebMatrix for Razor syntax, C#, or Visual Basic

> IntelliSense is supported in WebMatrix for HTML and CSS. However, it is not available for other languages. 
> 
> **Workaround**   
> None.


#### Issue: IntelliSense for HTML and CSS suggests elements that are not contextually appropriate

> IntelliSense for markup in WebMatrix supports HTML using the [XHTML 1.0 Transitional schema](http://www.w3.org/TR/2002/NOTE-xhtml1-schema-20020902/#xhtml1-transitional) and CSS using the [CSS 2.1 schema](http://www.w3.org/TR/CSS2/). Because IntelliSense is based on these specific schemas, certain tags, attributes, or properties might be suggested that are not appropriate for the current page or style definition. For HTML, it can also lead to unexpected suggestions in content that might be interpreted as malformed XHTML (for example, when tags are not closed). This issue might be more noticeable if the insertion point is inside an incomplete tag; in that case, IntelliSense might suggest new opening tags or offer other incorrect suggestions. 
> 
> **Workaround**   
> For HTML, make sure that you are working within a well-formed, complete XHTML page. For CSS, there is no workaround.


#### Issue: IntelliSense is not invoked while you type

> At times, IntelliSense might not be invoked as HTML or CSS is being entered in the editor. In particular, this might happen when the insertion point is directly next to another element or at the end of a file. 
> 
> **Workaround**   
> Make sure that there is whitespace around the insertion point and that the insertion point is not at the end of a file. You can also invoke IntelliSense manually by pressing Ctrl+Space.


#### Issue: No UI is available for disabling IntelliSense

> WebMatrix 1.0 provides no UI or gesture for disabling IntelliSense. 
> 
> **Workaround**   
> Start WebMatrix using the following command, which includes a switch that disables IntelliSense:  
>   
> `WebMatrix.exe #ExecuteCommand# EditorIntelliSense off`


<a id="Known_Issues_IISExpress"></a>
### IIS Express

IIS Express has its own readme file, which is available at the following URL:

[https://go.microsoft.com/fwlink/?LinkID=207675&amp;clcid=0x409](https://go.microsoft.com/fwlink/?LinkID=207675&amp;clcid=0x409)

<a id="Known_Issues_SQLServerCompact"></a>

### SQL Server Compact

SQL Server Compact has its own readme file, which is available at the following URL:

[https://go.microsoft.com/fwlink/?LinkID=208545](https://go.microsoft.com/fwlink/?LinkID=208545&amp;clcid=0x409)

For information about issues that involve installing SQL Server Compact as part of WebMatrix, see [WebMatrix Installation Issues](#Known_Issues_Installation) earlier in this document.

### <a id="Known_Issues_Installing_Applications"></a>  Installing Applications

#### Issue: Installing an application can take a long time if the user's My Documents folder is redirected to a network share

> **Workaround**  
> None. The application might take a while to install, but will install correctly.


### <a id="Known_Issues_Publishing_Applications"></a>  Publishing Applications

#### Issue: "Required permissions cannot be acquired" error when publishing a SQL Compact Database

> WebMatrix does not fully support deploying supporting binaries for SQL Server Compact to a server that is running .NET Framework version 3.5 with a medium trust configuration.
> 
> **Workaround**  
> The preferred workaround is to install the .NET Framework 4 on the server. Alternatively, do the following:
> 
> 1. Add the following elements to the `SecurityClasses` section in *Web\_MediumTrust.config* file:
> 
>     [!code-html[Main](overview/samples/sample6.html)]
> 2. Create a new permission set in the *Web\_MediumTrust.config* file with the following required permissions:
> 
>     [!code-html[Main](overview/samples/sample7.html)]
> 3. Apply the permission set to SQL Server Compact by putting the following elements in the *Web\_MediumTrust.config* file:
> 
>     [!code-html[Main](overview/samples/sample8.html)]


#### Issue: Gallery and PhpBB web applications display a "Service is unavailable" error after publishing

> Under some circumstances, publishing an application causes a "service is unavailable" error.
> 
> **Workaround**  
> In WebMatrix, add a backslash (\) to the end of the server name in the **Publish Settings** window and then publish the application again.


#### Issue: Moodle website layout and links are broken after publishing

> After you publish a Moodle application, the application does not work correctly.
> 
> **Workaround**  
> In WebMatrix, add a slash (/) to the end of the **Site Name** field in the **Publish Settings** window and then publish the application again.


#### Issue: Publishing nopCommerce fails with a database error

> Publishing nopCommerce fails and reports a database error like "Insert into the nop\_log table failed."
> 
> **Workaround**  
> 
> 1. In WebMatrix, click **Run** to launch nopCommerce locally.
> 2. Log into the administration page.
> 3. Click the **System** menu.
> 4. Click the **Log** option.
> 5. Click the **Clear Log** button.
> 6. Publish nopCommerce again.


#### Issue: Silverstripe CMS displays a "HTTP 500 PHP FCGI Error" when you download a published site

> **Workaround**  
> After you click **Download published site**, skip `silverstripe-cache/manifest_main` in **Publish Preview**. This file is used for caching purposes and is specific to each computer.


#### Issue: Subtext displays "Server Error in '/' Application" when you download a published site

> **Workaround**  
> Open the site's *web.config* file and replace the user ID and password in the database connection string with the SQL Server administrator credentials (the "sa" credentials).
> 
> Alternatively, follow these steps in order to give the user account you are logged in with `db_owner` permissions:
> 
> 1. Install SQL Server Management Studio using the Web Platform Installer.
> 2. Connect to the local SQL Server Express instance (by default, `.\SQLEXPRESS`).
> 3. Click **Databases** &gt; *[localSubtextDatabase]* &gt; **Security** &gt; **Users** &gt; *[localSubtextUser*] (default is `subtextuser`], right-click, and click **Properties**.
> 4. Select **db\_owner** in the role membership section.


#### Issue: Site might not work after publishing if the "Destination URL" field is not prefixed with http:// or https://

> In the **Publishing Settings** dialog box, if the destination URL does not begin with `http://` or `https://`, the site might not work after deployment.
> 
> **Workaround**  
> Make sure that before you publish a site, the destination URL in the **Publish Settings** dialog box starts with `http://` or `https://`.


#### Issue: Publishing a MySQL database fails with the error "Failed to publish the database. This can happen if the remote database cannot run the script."

> The error can occur for a number of reasons. One reason you can see this error is if the database script contains a single quotation character (') and the destination MySQL database's default character set is not to UTF-8.
> 
> **Workaround**  
> Set the default character set for the remote MySQL database to UTF-8.


#### Issue: Some links are not visible in DotNetNuke after publishing or downloading the site

> If you publish or download a DotNetNuke site, you might need to clear the cache to get the new links to appear on the site.
> 
> **Workaround**
> 
> 1. Log in as "Host".
> 2. Go to the host menu and select **Host Settings**.
> 3. Scroll down and under **Advanced Settings**, expand **Performance Settings**.
> 4. Click the **Clear Cache** link for pages.
> 5. Go to the bottom of the page and restart the application.


#### Issue: Some links in AtomSite are broken after you download a published site

> **Workaround**  
> In the *service.config* file, *users.config* file, and all *.xml* files, replace the URL string (for example, `http://myhost.com/atomsite`) with the local one (for example, `http://localhost:1239`).


#### Issue: MySQL-based applications like WordPress fail to publish and report a database error

> By default, WebMatrix installs MySQL with the UTF-8 character set. If you install MySQL on your own, and the character set is not UTF-8 (for example, it is Latin1), the publish process for databases might fail.
> 
> **Workaround**
> 
> 1. Change the character set for MySQL to UTF-8. (For details, see [Server Character Set and Collation](http://dev.mysql.com/doc/refman/5.0/en/charset-server.html) on the MySQL website.)
> 2. Reinstall the application.
> 3. Republish the application.


#### Issue: "Download published site" fails for applications that have browser-based setup

> Some applications (for example, Kentico CMS) require you to launch them in the browser in order to perform post-installation setup such as creating a database. If you publish an application like this without completing the browser-based setup, attempting to download the same site from a remote server will fail.
> 
> **Workaround**  
> Finish browser-based setup before publishing the site.


#### Issue: "Download published site" fails with a database error for DotNetNuke and Kooboo CMS

> If you try to download an application from a server and you have administrator credentials in the database connection string in the **Publish Settings** dialog, you might see the following error in the publish log:
> 
> [!code-console[Main](overview/samples/sample9.cmd)]
> 
> **Workaround**  
> If practical, republish the site (or have it published) using non-administrator credentials for the database.


<a id="More_Info"></a>

## For More Information

For more information about WebMatrix 1.0, see the following websites:

- [IIS.net](http://iis.net/)
- [ASP.NET](https://asp.net/webmatrix)
- [Microsoft.com/web](https://www.microsoft.com/web)

© 2011 Microsoft Corporation. All Rights Reserved. [Terms of Use](https://msdn.microsoft.com/en-us/cc300389.aspx).