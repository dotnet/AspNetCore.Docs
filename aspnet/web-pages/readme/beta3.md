---
uid: web-pages/readme/beta3
title: "Web Matrix and ASP.NET Web Pages (Razor) Beta 3 Release Readme | Microsoft Docs"
author: rick-anderson
description: "Web Matrix and ASP.NET Web Pages (Razor) Beta 3 Release Readme"
ms.author: aspnetcontent
manager: wpickett
ms.date: 01/10/2011
ms.topic: article
ms.assetid: ffa3d5c9-91e5-4da3-b409-560b0c7fbbf0
ms.technology: dotnet-webpages
ms.prod: .net-framework
msc.legacyurl: /web-pages/readme/beta3
msc.type: content
---
Web Matrix and ASP.NET Web Pages (Razor) Beta 3 Release Readme
====================
> Web Matrix and ASP.NET Web Pages (Razor) Beta 3 Release Readme

9 November 2010

## Contents

- [Overview](#Overview)
- [Installation](#Installation_Notes)
- [New Features, Changes, and Known Issues in the Beta 3 release](#Known_Issues)

    - [WebMatrix Installation Issues](#Known_Issues_Installation)
    - [ASP.NET Web Pages](#Known_Issues_ASPNET)
    - [SQL Server Compact](#Known_Issues_SQL_Server_Compact)
    - [Installing Applications](#Known_Issues_Installing_Applications)
    - [Publishing Applications](#Known_Issues_Publishing_Applications)
    - [Other Issues](#Known_Issues_Other_Issues)
- [For More Information](#More_Info)

<a id="Overview"></a>

## Overview

> Microsoft WebMatrix Beta is a free web development stack that installs in minutes. It integrates a web server with database and programming frameworks to create a single, integrated experience. You can use WebMatrix Beta to streamline the way you code, test, and publish your own ASP.NET or PHP website, or you can use WebMatrix Beta to start a new website using popular open-source apps like DotNetNuke, Umbraco, WordPress, or Joomla. WebMatrix Beta uses the same powerful web server, database engine, and frameworks environment that will run your website on the internet, which makes the transition from development to production smooth and seamless.


<a id="Installation_Notes"></a>

## Installation

> To install WebMatrix Beta 3, you use [Microsoft Web Platform Installer 3.0](https://go.microsoft.com/fwlink/?LinkID=194638). After you've installed the Web Platform Installer, you can use it to install WebMatrix Beta 3.
> 
> If you have problems during installation, refer to [Troubleshooting Problems with Microsoft Web Platform Installer](https://go.microsoft.com/fwlink/?LinkId=196212).


<a id="Installation_Notes0"></a>

## Instructions for Publishing Applications

> See [Step-by-Step Instructions for Publishing Applications](https://go.microsoft.com/fwlink/?LinkID=196149)


<a id="Known_Issues"></a>

## New Features, Changes, andKnown Issues

<a id="Known_Issues_Installation"></a>

### WebMatrix Beta 3 Installation

#### Issue: WebMatrix Beta 3 is only available on platforms that support Microsoft .NET Framework 4

> The .NET Framework version 4 is required for WebMatrix Beta. In certain cases, the WebMatrix Beta installer will let you try to install on a platform that is not part of the supported configuration set. In particular, Windows Vista without the SP1 update will let you begin the installation of WebMatrix Beta, but the .NET Framework 4 component will fail and block your installation.
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


#### Issue: Cannot install WebMatrix Beta 3 if Microsoft Visual Studio 2008 is installed without Microsoft Visual Studio 2008 SP1

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

This section of the document describes new features, changes, and known issues with the Beta 3 release of ASP.NET Web Pages with Razor syntax.

- [New features](#NewFeatures)
- [Changes](#Changes)
- [Issues](#Issues)

<a id="NewFeatures"></a>

#### New Features in Beta 3 for ASP.NET Web Pages with Razor Syntax

#### New: "Html.Raw" method renders unencoded markup

> The new `Html.Raw` method lets you render HTML markup as markup instead of rendering encoded output. (By default, ASP.NET Razor encodes strings before rendering them.) The syntax is:
> 
> `Html.Raw(value)`
> 
> The following example shows how to use `Html.Raw`:
> 
> [!code-cshtml[Main](beta3/samples/sample1.cshtml)]


<a id="Changes"></a>

#### Changes in Beta 3 for ASP.NET Web Pages with Razor Syntax

#### Change: "HrefAttribute" method removed

> The `HrefAttribute` method of the `WebPage` class has been removed. This helper was used to encode unsafe characters in URLs. It is no longer required because ASP.NET Razor automatically encodes strings. (Use the new `Html.Raw` method to render unencoded strings.)


#### Change: Syntax for declarative "@helper" helpers changed

> In the Beta 3 release, ASP.NET changes how it parses helpers that are created using the `@helper` syntax. In essence, the `@helper` syntax is now parsed as a code block instead of as a block of markup that can include code. Therefore, code inside the helper does not need to be enclosed in `@{ }` blocks. Conversely, markup inside the helper has to be explicitly included in HTML elements or in ASP.NET Razor `<text></text>` tags.
> 
> For example, the following `@helper` syntax works in the Beta 3 release:
> 
> [!code-cshtml[Main](beta3/samples/sample2.cshtml)]
> 
> In the Beta 3 release, this helper must be changed to look like the following example:
> 
> [!code-cshtml[Main](beta3/samples/sample3.cshtml)]
> 
> Notice that the `@{ }` characters around the initial code in the helper is no longer used. This is because the contents of the helpers are treated as a code block by default. The helper renders markup, which starts with the opening `<a>` tag. If the helper must render plain text or tags that do not include a closing tag (for example, `<meta>` tags), the content to be rendered must be in `<text></text>` tags.


#### Change: "WebPageContext.HttpContext" removed

> The `WebPageContext.HttpContext` property has been removed. Use `HttpContext.Current` instead. (The `WebPageContext.HttpContext` property simply wrapped this.)


#### Change: "Facebook" helper moved to new package

> The `Facebook` helper has been moved to the *Facebook.Helper* library, which includes the `Facebook` helper and additional functionality. You must install this library as a separate package, as described in "Installing Helpers with Package Manager" in the tutorial [Getting Started with ASP.NET Pages](https://go.microsoft.com/fwlink/?LinkId=202889).


#### Change: Membership, Role, and Security types moves to new assembly

> The following types were moved to the `WebMatrix.WebData` assembly:
> 
> - `ExtendedMembershipProvider`
> - `SimpleMembershipProvider`
> - `SimpleRoleProvider`
> - `WebSecurity`


#### Change: "TagBuilder" class moved to System.Web.WebPages.dll assembly

> The `TagBuilde` r class has been moved to the System.Web.WebPages.dll assembly. Previously, this was in an assembly that was part of ASP.NET MVC. This change means that you do not have to install ASP.NET MVC in order to use the `TagBuilder` class.
> 
> However, the class is still in the `System.Web.Mvc` namespace. In order to use the `TagBuilder` class (for example, in a custom ASP.NET Razor helper), you must reference the namespace (for example, by adding `@using System.Web.Mvc` to your code).


#### Change: Request validation syntax changed; "Validation" class removed

> In the Beta 3 release, to disable validation for an individual field or set of fields, you can call the `Validation.Exclude` method, passing in the name or names of the fields to exclude from validation. A new syntax is available in the Beta 3 release for bypassing validation. The `Validation` method used in Beta 3 has been removed.
> 
> > [!NOTE]
> > If you do not disable request validation, if users try to upload HTML markup (for example, by using a rich text editor on a page), the website will report an error like *A potentially dangerous Request.Form value was detected from the client* and the user input is not accepted. If you disable request validation, you must manually check user input to make sure that it does not contain potentially dangerous markup or script using something like the [Microsoft Anti-Cross Site Scripting Library V4.0](https://www.microsoft.com/downloads/en/details.aspx?FamilyID=f4cd231b-7e06-445b-bec7-343e5884e651).
> 
> 
> To disable automatic request validation, call the `Request.Unvalidated` method, passing it the name of the field or other post object that you want to bypass request validation for. You can use this method to bypass validation for any items in the `Form`, `QueryString`, `Cookies`, and `ServerVariables` collections. The following examples show how to use the `Unvalidated` method:
> 
> [!code-csharp[Main](beta3/samples/sample4.cs)]


<a id="Issues"></a>

#### Known Issues for ASP.NET Web Pages with Razor Syntax

#### Issue: Unexpected behavior when using a custom user table for membership

> To initialize the membership provider for an ASP.NET Razor website, you call the `WebSecurity.InitializeDatabaseConnection` method. (In WebMatrix, the Starter Site template includes a call to this method in the *\_AppStart.cshtml* file.) If the `autoCreateTables` parameter of this method is set to true (by default, it is set to true in the Starter Site template), and if an unrecognized table name is passed to the method (the second parameter), the method does not throw an error. Instead, it automatically creates the table.
> 
> This can be a problem if you intend to use a custom user table for membership but pass the wrong table name to the `WebSecurity.InitializeDatabaseConnection` method. Because the method does not by default raise an error if the table you specify does not exist, and because it instead creates a new table, the application can appear to be working. However, application code that relies on your custom user table (and on fields in it) can eventually fail with unexpected errors.
> 
> **Workaround**  
> Make sure that the name passed in the `InitializeDatabaseConnection` method matches the user profile table in the membership database, or make sure that the `autoCreateTables` parameter is set to false.


#### Issue: "Failed to generate a user instance of SQL Server" error

> If a WebMatrix Web application uses SQL Server Express and is running IIS 7.5 on Windows 7 or Windows Server 2008 R2, you might see an error that indicates that SQL Server cannot retrieve the user's local application path at run time.
> 
> **Workaround** Make sure that the Windows account that the application runs under (typically NETWORK SERVICE) has read/write permissions for root folders of the application and for subfolders such as *App\_Data*. More detailed information is available in the KnowledgeBase article [Problems with SQL Server Express user instancing and ASP.net Web Application Projects](https://support.microsoft.com/kb/2002980).


#### Issue: In Visual Studio, namespaces for custom assemblies (DLLs) are not imported automatically

> If you use custom assemblies in a project in Visual Studio, the namespaces declared in those assemblies are not automatically imported at design time. As a result, references to custom types might not be recognized at design time and are marked as not recognized in Visual Studio (using a "squiggle"). This problem occurs only at design time in Visual Studio; the application itself runs properly.
> 
> **Workaround**  
> Include a `using` statement (`imports` in Visual Basic) that references the entities that are not recognized at design time.


#### Issue: Visual Studio IntelliSense and project templates available only in ASP.NET MVC version 3

> Installing ASP.NET Web Pages does not also install tools for Visual Studio such as IntelliSense and project templates for ASP.NET Web Pages applications.
> 
> **Workaround** To use IntelliSense and project templates for ASP.NET Web Pages applications in Visual Studio, install ASP.NET MVC 3 RC either through the Web Platform Installer or the [stand-alone installer](https://go.microsoft.com/fwlink/?LinkID=191797).


#### Issue: "&lt;helper&gt; class cannot be found" error

> After you upgrade to Beta 3, you might see an error that a helper class (for example, the `Facebook` class) cannot not be found. Starting in Beta 2 and continuing in Beta 3, helpers have been moved to packages that you must explicitly install. Existing sites are not upgraded to include these packages; this includes sites in the *\My Documents\IISExpress* or *\My Documents\My Web Sites* folders. In particular, you will see this error if you use the default site in *My Sites* (WebSite1), which includes a reference to the `Twitter` helper.
> 
> **Workaround**  
> Comment out calls to any helpers in the site, run the *\_Admin* page, and install the package or packages that include the helpers that you want to use. After you've installed the package, you can uncomment the lines that reference helpers.


#### Issue: Deploying Beta 3 ASP.NET Razor assemblies to the Bin folder might not work on hosting sites

> If you deploy an ASP.NET Web Pages website to a hosting site, and if you deploy the ASP.NET Razor Beta 3 assemblies to the site's *Bin* folder, you might experience errors, including the following:
> 
> `Could not load type 'Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility' from assembly 'Microsoft.Web.Infrastructure, Version=1.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35'.`
> 
> This can happen if the hosting provider has installed the ASP.NET Web Pages Beta 1 assemblies into the server's global application cache (GAC). Assemblies in the GAC get precedence over assemblies installed locally in the *Bin* folder.
> 
> **Workaround** Contact your hosting provider to confirm that the errors you are seeing are due to a conflict between the provider's versions of the assemblies and yours. If so, request that the hosting provider update the assemblies in the server's GAC.


#### Issue: Reading feeds or other external data via a proxy server

> If the server running the site is behind a proxy server, you might need to configure proxy information in the *Web.config* file in order to be able to read information that comes from outside your site. For example, if you use the `ReCaptcha` helper, the helper communicates with the reCAPTCHA service, but might be blocked by your proxy server. Similarly, feeds that are used in ASP.NET Web Pages, such as the feed used by the package manager, might require proxy configuration.
> 
> If you experience problems in working with an external service or working with the package feed, put the following elements into your application's root *Web.config* file:
> 
> [!code-xml[Main](beta3/samples/sample5.xml)]
> 
> For more information about configuring a proxy server, see [&lt;proxy&gt; Element (Network Settings)](https://msdn.microsoft.com/en-us/library/sa91de1e.aspx) on the MSDN Web site.


#### Issue: "Microsoft.Web.Infrastructure.dll cannot be loaded" error

> If you previously installed the Beta 1 version of ASP.NET Web Pages with Razor syntax and then install the Beta 3 version, all appropriate assemblies are installed in the GAC except *Microsoft.Web.Infrastructure.dll*. As a consequence, when you run ASP.NET Razor pages, you see an error that indicates that *Microsoft.Web.Infrastructure.dll* could not be loaded.
> 
> This issue does not occur if you loaded the Beta 3 release on a clean computer.
> 
> **Workaround**  
> In Control Panel, uninstall ASP.NET Web Pages. Then reinstall the Beta 3 release.


#### Issue: Uninstalling the .NET Framework version 4 disables ASP.NET Web Pages with Razor Syntax

> If you uninstall the .NET Framework version 4 and then reinstall it, ASP.NET Web Pages with Razor syntax is disabled. Pages with the *.cshtml* extension do not run correctly. ASP.NET Web Pages registers an assembly in the machine root *Web.config* file, and removing the .NET Framework removes that file. Reinstalling the .NET Framework installs a new version of the configuration file, but does not add the reference for the ASP.NET Web Pages assembly.
> 
> **Workaround** After reinstalling the .NET Framework, reinstall ASP.NET Web Pages with Razor syntax. This adds the following element to the *Web.config* file in the machine root, which is typically in the following location:  
>   
> `C:\Windows\Microsoft.NET\Framework\v4.0.30319\Config (32-bit)`  
>   
> `C:\Windows\Microsoft.NET\Framework64\v4.0.30319\Config (64-bit)`
> 
> [!code-xml[Main](beta3/samples/sample6.xml)]


#### Issue: Applications previously deployed with ASP.NET assemblies in the Bin folder experience errors

> During deployment, copies of the ASP.NET Web Pages assemblies (for example, *Microsoft.WebPages.dll*) to the *Bin* folder of the website on the server. (This might have happened automatically during deployment or because the developer explicitly copied the assemblies.) However, when the Beta 3 release is installed, errors occurs, such as errors that certain types cannot be found. This occurs because a number of ASP.NET Web Pages types were moved into different namespaces for the Beta 3 release.
> 
> **Workaround**   
> Clear the *Bin* folder of the deployed application, copy the new assemblies to the folder (or redeploy the application), and then restart the application.


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
> - If you do not have control over the server computer (for example, you are deploying to a hosting website), add the following to the website's *Web.config* file:
> 
> 
> [!code-xml[Main](beta3/samples/sample7.xml)]


#### Issue: Using Web Application Project or ASP.NET MVC and ASP.NET Web pages in the same application

> If you were using ASP.NET Web Pages in a Web Application project or ASP.NET MVC application, you might see an error that *WebPageHttpApplication* cannot be found.
> 
> **Workaround**  
> If you get this error, change the base class from which the application derives. In the *Global.asax* file, change the following line:
> 
> [!code-csharp[Main](beta3/samples/sample8.cs)]
> 
> To this:
> 
> [!code-csharp[Main](beta3/samples/sample9.cs)]
> 
> This in effect reverses a change that was introduced for the Beta 1 release of ASP.NET Web Pages with Razor syntax.


#### Issue: Deploying an application to a computer that does not have SQL Server Compact installed

> Applications that include SQL Server Compact databases can run on a computer where SQL Server Compact is not installed. Microsoft WebMatrix Beta 3 automatically copies these binaries for you and performs the appropriate *Web.config* file transforms.
> 
> **Workaround** If you need to copy these files and make the *Web.config* file changes manually, do the following :
> 
> 1. Copy the database engine assemblies to the *Bin* folder (and subfolders) of the application on the target computer: 
> 
>     - Copy *C:\Program Files\Microsoft SQL Server Compact Edition\v4.0\Desktop\System.Data.SqlServerCe.dll* **to** *\Bin*
>     - Copy *C:\Program Files\Microsoft SQL Server Compact Edition\v4.0\Private\x86\\** **to** *\Bin\x86*
>     - Copy *C:\Program Files\Microsoft SQL Server Compact Edition\v4.0\Private\amd64\\** **to** *\Bin\amd64*
> 2. In the root folder of the website, create or open a *Web.config* file. (In WebMatrix Beta 3, this file type is available if you click **All** in the **Choose a File Type** dialog box.)
> 3. Add the following element as a child of the **&lt;configuration&gt;** element (not inside the **&lt;system.web&gt;** element):
> 
> 
> [!code-xml[Main](beta3/samples/sample10.xml)]


#### Issue: Database and WebGrid helpers do not work in Medium Trust in Visual Basic

> If you are using Visual Basic (creating *.vbhtml* files), the `Database` and `WebGrid` helpers will not work if the application is set to use Medium Trust.
> 
> **Workaround**  
> Temporarily set the application to use Full Trust.

<a id="Known_Issues_SQL_Server_Compact"></a>
### SQL Server Compact

#### Issue: "Encrypt" property is not recognized

> SQL Server Compact 4.0 does not recognize the `Encrypt` property of the `SqlCeConnection` class. You should not use this property to encrypt database files. The `Encrypt` property was deprecated in SQL Server Compact 3.5 release and was retained only for backward compatibility. 
> 
> **Workaround**  
> Use the `Encryption Mode` property of the `SqlCeConnection` class to encrypt SQL Server Compact 4.0 database files. The following example shows how to create an encrypted SQL Server Compact 4.0 database using the `Encryption Mode` property:
>  
> [!code-csharp[Main](beta3/samples/sample11.cs)]
>  
> [!code-vb[Main](beta3/samples/sample12.vb)]
> 
> To change the encryption mode of an existing SQL Server Compact 4.0 database, do the following:
>  
> [!code-csharp[Main](beta3/samples/sample13.cs)]
>  
> [!code-vb[Main](beta3/samples/sample14.vb)]
> 
> To encrypt an unencrypted SQL Server Compact 4.0 database, do the following:
>  
> [!code-csharp[Main](beta3/samples/sample15.cs)]
>  
> [!code-vb[Main](beta3/samples/sample16.vb)]


#### Issue: Microsoft Visual C++ 2008 runtime libraries are required

> The native DLLs of SQL Server Compact 4.0 need the Microsoft Visual C++ 2008 Runtime Libraries (x86, IA64, and x64), Service Pack 1.
> 
> **Workaround**  
> Install the .NET Framework 3.5 SP1. This also installs the Visual C++ 2008 Runtime Libraries SP1. You can download the libraries from the following location:   
>   
> [Microsoft Visual C++ 2008 Service Pack 1 Redistributable Package ATL Security Update](https://go.microsoft.com/fwlink/?LinkId=194827)
> 
> [!NOTE]
> Note that installing the .NET Framework 2.0, 3.0, or 4 does *not* install the Visual C++ 2008 Runtime Libraries SP1.


#### Issue: If SQL Server Compact is installed prior to installing .NET Framework on the computer, its provider invariant name is not registered in the .NET Framework machine.config file

> SQL Server Compact can be installed on a machine that does not have .NET Framework installed because SQL Server Compact does require the .NET framework. If neither .NET Framework version 3.5 nor 4 is installed before you install SQL Server Compact, the SQL Server Compact Setup does not register its provider invariant name in the *machine.config* file. Any application that relies on the SQL Server Compact entry in the *machine.config* file will fail. The invariant name registration entry in *machine.config* looks like the following example:
> 
> [!code-xml[Main](beta3/samples/sample17.xml)]
> 
> **Workaround**  
> Uninstall SQL Server Compact 4.0 CTP1. Download and install the full versions of the .NET Framework from the following location:
> 
> [Microsoft .NET Framework 3.5 Service pack 1 (Full Package)](https://go.microsoft.com/fwlink/?LinkId=194828)  
> [Microsoft .NET Framework 4.0 Release (Full Package)](https://www.microsoft.com/downloads/details.aspx?FamilyID=9cfb2d51-5ff4-4491-b0e5-b386f32c0992&amp;displaylang=en)
> 
> Then reinstall [SQL Server Compact 4.0 CTP1](https://www.microsoft.com/downloads/details.aspx?FamilyID=0d2357ea-324f-46fd-88fc-7364c80e4fdb&amp;displaylang=en).


<a id="Known_Issues_Installing_Applications"></a>

### Installing Applications

#### Issue: Installing an application can take a long time if the user's My Documents folder is redirected to a network share

> **Workaround**  
> None. The application might take a while to install, but will install correctly.


<a id="Known_Issues_Publishing_Applications"></a>

### Publishing Applications

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


<a id="Known_Issues_Other_Issues"></a>

### Other Issues

#### Issue: Search/Filter does not work in Reports for Group By: Issue Type

> When you run a report for a site, if you enter text in the *Filter by URL* box and click *Search*, nothing happens. This is because this control is not functional while the *Group By* state of the report is set to *Issue Type*, which is the default.
> 
> **Workaround** In the *Group By* tab of ribbon, click *URL* to group the entries by their source URL. The text box and button to filter the entries are functional while in this state.


#### Issue: WCF applications fail to run with IIS Express

> Browsing to a WCF application results in an error like the following one:
> 
> *Could not load file or assembly 'Microsoft.Web.Administration, Version=7.0.0.0, Culture=neutral,PublicKeyToken=31bf3856ad364e35' or one of its dependencies. The system cannot find the file specified.*
> 
> This occurs because IIS Express Beta release doesn't support WCF by default.
> 
> **Workaround** Use any one of the following workarounds (workaround #2 requires Microsoft Windows Vista or higher):
> 
> 
> 1. Copy the *Microsoft.Web.dll* and *Microsoft.Web.Administration.dll* assemblies from the WebMatrix installation location to the *bin* directory of the WCF application. By default, WebMatrix is installed in the *Microsoft WebMatrix* subfolder under the system's *Program Files* folder.
> 2. On Microsoft Windows Vista or higher, create a symlink to the assemblies in the *bin* directory using the following commands. (This approach has the advantage that it does not create a copy of the assemblies.)
> 
>     [!code-console[Main](beta3/samples/sample18.cmd)]
> 3. Install the two assemblies in the GAC. From an elevated prompt, run the following commands:
> 
>     [!code-console[Main](beta3/samples/sample19.cmd)]


#### Issue: WebMatrix Beta 3 is unable to perform certain tasks that require elevation

> WebMatrix Beta 3 is unable to perform certain tasks that require elevation, such as installing additional components in the following situations:
> 
> - On Windows Vista or Windows 7, you are logged in with an account that does not have administrative privileges and User Account Control (UAC) is disabled.
> - You are using Microsoft Windows XP or Microsoft Windows Server 2003.
> 
> **Workaround**  
> Most tasks in WebMatrix Beta 3 do not require administrative permission. For those that do, you can perform the operation as an administrator, or follow these steps:
> 
> - On Windows Vista or Windows 7, enable UAC.
> - On Windows XP, add the user to the Administrators security group.


#### Issue: "Site from Web Gallery" is disabled

> The **Site from Web Gallery** option is disabled if the Web Platform Installer 3.0 is not installed.
> 
> **Workaround**  
> Install the [Microsoft Web Platform Installer 3.0](https://go.microsoft.com/fwlink/?LinkID=194638).


#### Issue: On Windows Server 2003, IIS Express does not start for a non-administrative user

> On Windows Server 2003, when you launch a page or start IIS Express, IIS Express does not start. For Web pages, an error is displayed that indicates that the application has been started by a non-administrative user.
> 
> **Workaround**  
> Start WebMatrix Beta 3 as an administrative user. For more details, see the following KnowledgeBase article:  
>   
> [An application that is started by a non-administrative user cannot listen to the HTTP traffic of the computer on which the application is running in Windows Vista, Windows Server 2003, or Windows XP.](https://support.microsoft.com/kb/939786)


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


#### Issue: The "Relationships" button is disabled

> The **Relationships** button under the **Table** tab in the **Databases** workspace is disabled for SQL Server Compact databases.
> 
> **Workaround**  
> None. SQL Server Compact does not support relationships between tables.


#### Issue: Parameterized SQL queries throw exceptions

> In SQL Server Compact 4.0, if you do not specify a data type such as `SqlDbType` or `DbType` for parameters in parameterized queries, an exception is thrown when the query runs.
> 
> **Workaround**  
> Explicitly set the data type for parameters such as `SqlDbType` or `DbType`. This is critical in the case of BLOB data types (`image` and `ntext`). Use code like the following:
> 
> [!code-sql[Main](beta3/samples/sample20.sql)]
>  
> [!code-vb[Main](beta3/samples/sample21.vb)]


<a id="More_Info"></a>

## For More Information

For more information about WebMatrix Beta 3, see the following websites:

- [IIS.net](http://iis.net/)
- [ASP.NET](https://asp.net/webmatrix)
- [Microsoft.com/web](https://www.microsoft.com/web)

* * *

© 2010 Microsoft Corporation. All Rights Reserved. [Terms of Use](https://msdn.microsoft.com/en-us/cc300389.aspx).