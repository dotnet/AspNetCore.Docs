---
uid: mvc/overview/releases/how-to-upgrade-an-aspnet-mvc-4-and-web-api-project-to-aspnet-mvc-5-and-web-api-2
title: "How to Upgrade an ASP.NET MVC 4 and Web API Project to ASP.NET MVC 5 and Web API 2 | Microsoft Docs"
author: Rick-Anderson
description: "ASP.NET MVC 5 and Web API 2 bring a host of new features, including attribute routing, authentication filters, and much more."
ms.author: aspnetcontent
manager: wpickett
ms.date: 10/17/2013
ms.topic: article
ms.assetid: db0d02d9-58e8-4a0b-8d7d-b8df8ea97b88
ms.technology: dotnet-mvc
ms.prod: .net-framework
msc.legacyurl: /mvc/overview/releases/how-to-upgrade-an-aspnet-mvc-4-and-web-api-project-to-aspnet-mvc-5-and-web-api-2
msc.type: authoredcontent
---
How to Upgrade an ASP.NET MVC 4 and Web API Project to ASP.NET MVC 5 and Web API 2
====================
by [Rick Anderson](https://github.com/Rick-Anderson)

> ASP.NET MVC 5 and Web API 2 bring a host of new features, including attribute routing, authentication filters, and much more. See [https://www.asp.net/vnext](https://www.asp.net/core) for more details.
> 
> This walkthrough will guide you with the steps required to upgrade your application to the latest version.  
> 
> > [!NOTE]
> > Please see [ASP.NET and Web Tools for Visual Studio 2013 Release Notes](../../../visual-studio/overview/2013/release-notes.md) for information on breaking changes from MVC 4 and Web API to the next version.
> 
>   
> 
> This article was written by Youngjune Hong and Rick Anderson ( [@RickAndMSFT](https://twitter.com/#!/RickAndMSFT) )


## Upgrade Steps

1. Backup your project. This walkthrough will require you to make changes to your project file, package configuration, and web.config files.
2. For upgrading from Web API to Web API 2, in global.asax, change:

    [!code-csharp[Main](how-to-upgrade-an-aspnet-mvc-4-and-web-api-project-to-aspnet-mvc-5-and-web-api-2/samples/sample1.cs)]

 to

    [!code-csharp[Main](how-to-upgrade-an-aspnet-mvc-4-and-web-api-project-to-aspnet-mvc-5-and-web-api-2/samples/sample2.cs)]
3. Make sure all the packages that your projects use are compatible with MVC 5 and Web API 2. The following table shows the MVC 4 and Web API related packages than need to be changed. If you have a package that is dependent on one of the packages listed below, please contact the publishers to get the newer versions that are compatible with MVC 5 and Web API 2. If you have the source code for those packages, you should recompile them with the new assemblies of MVC 5 and Web API 2.   

    | **Package Id** | **Old version** | **New version** |
    | --- | --- | --- |
    | Microsoft.AspNet.Razor | 2.0.x.x | 3.0.0 |
    | Microsoft.AspNet.WebPages | 2.0.x.x | 3.0.0 |
    | Microsoft.AspNet.WebPages.WebData | 2.0.x.x | 3.0.0 |
    | Microsoft.AspNet.WebPages.OAuth | 2.0.x.x | 3.0.0 |
    | Microsoft.AspNet.Mvc | 4.0.x.x | 5.0.0 |
    | Microsoft.AspNet.Mvc.Facebook | 4.0.x.x | 5.0.0 |
    | Microsoft.AspNet.WebApi.Core | 4.0.x.x | 5.0.0 |
    | Microsoft.AspNet.WebApi.SelfHost | 4.0.x.x | 5.0.0 |
    | Microsoft.AspNet.WebApi.Client | 4.0.x.x | 5.0.0 |
    | Microsoft.AspNet.WebApi.OData | 4.0.x.x | 5.0.0 |
    | Microsoft.AspNet.WebApi | 4.0.x.x | 5.0.0 |
    | Microsoft.AspNet.WebApi.WebHost | 4.0.x.x | 5.0.0 |
    | Microsoft.AspNet.WebApi.Tracing | 4.0.x.x | 5.0.0 |
    | Microsoft.AspNet.WebApi.HelpPage | 4.0.x.x | 5.0.0 |
    | Microsoft.Net.Http | 2.0.x. | 2.2.x. |
    | Microsoft.Data.OData | 5.2.x | 5.6.x |
    | System.Spatial | 5.2.x | 5.6.x |
    | Microsoft.Data.Edm | 5.2.x | 5.6.x |
    | Microsoft.AspNet.Mvc.FixedDisplayModes | <o:p> </o:p> | Removed |
    | Microsoft.AspNet.WebPages.Administration | <o:p> </o:p> | Removed |
    | Microsoft-Web-Helpers | <o:p> </o:p> | Microsoft.AspNet.WebHelpers |

    > [!NOTE]
    > Microsoft-Web-Helpers has been replaced with Microsoft.AspNet.WebHelpers. You should remove the old package first, and then install the newer package.   
    >   
    > There is no cross version compatibility among major ASP.NET packages. For example, MVC 5 is compatible with only Razor 3, and not Razor 2.
4. Open your project in Visual Studio 2013.
5. Remove any of the following ASP.NET NuGet packages that are installed. You will remove these using the Package Manager Console (PMC). To open the PMC, select the **Tools** menu and then select **Library Package Manager,** then select **Package Manager Console**. Your project might not include all of these.

    1. `Microsoft.AspNet.WebPages.Administration`  
 This package is typically added when upgrading from MVC 3 to MVC 4. To remove it, run the following command in the PMC:  
        `Uninstall-Package -Id Microsoft.AspNet.WebPages.Administration`
    2. `Microsoft-Web-Helpers`   
 This package has been rebranded as `Microsoft.AspNet.WebHelpers`. To remove it, run the following command in the PMC:  
        `Uninstall-Package -Id Microsoft-Web-Helpers`
    3. `Microsoft.AspNet.Mvc.FixedDisplayMode`  
 This package contains a work around for a bug in MVC 4 that has been fixed in MVC 5. To remove it, run the following command in the PMC:  
        `Uninstall-Package -Id Microsoft.AspNet.Mvc.FixedDisplayModes`
6. Upgrade all the ASP.NET NuGet packages using the PMC. In the PMC, run the following command:  
    `Update-Package`  
 The `Update-Package` command without any parameters will update every package. You can update packages individually by using the ID argument. For more information about the update command, run     `get-help update-package` .

## Update the Application *web.config* File

Be sure to make these changes in the app *web.config* file, not the *web.config* file in the *Views* folder.

Locate the `<runtime>/<assemblyBinding>` section, and make the following changes:

1. In the elements with the name attribute "System.Web.Mvc", change the version number from "4.0.0.0" to "5.0.0.0". (Two changes in that element.)
2. In elements with the name attribute &quot;System.Web.Helpers" and &quot;System.Web.WebPages&quot; change the version number from "2.0.0.0" to "3.0.0.0". Four changes will occur, two in each of the elements.

    [!code-xml[Main](how-to-upgrade-an-aspnet-mvc-4-and-web-api-project-to-aspnet-mvc-5-and-web-api-2/samples/sample3.xml?highlight=6,10,14)]
3. Locate the `<appSettings>` section and update the webpages:version from 2.0.0.0.0 to 3.0.0.0 as shown below:

    [!code-xml[Main](how-to-upgrade-an-aspnet-mvc-4-and-web-api-project-to-aspnet-mvc-5-and-web-api-2/samples/sample4.xml?highlight=2)]
4. Remove any trust levels other than Full. For example:

    [!code-xml[Main](how-to-upgrade-an-aspnet-mvc-4-and-web-api-project-to-aspnet-mvc-5-and-web-api-2/samples/sample5.xml?highlight=2)]

## Update the *web.config* files under the Views folder

If your application is using areas, you will also need to update each *web.config* file in the *Views* sub-folder of each Area folder.

1. Update all elements that contain "System.Web.Mvc" from version "4.0.0.0" to version "5.0.0.0".  

    [!code-xml[Main](how-to-upgrade-an-aspnet-mvc-4-and-web-api-project-to-aspnet-mvc-5-and-web-api-2/samples/sample6.xml?highlight=2)]

    [!code-xml[Main](how-to-upgrade-an-aspnet-mvc-4-and-web-api-project-to-aspnet-mvc-5-and-web-api-2/samples/sample7.xml?highlight=4-6,8)]
2. Update all elements that contain "System.Web.WebPages.Razor" from version "2.0.0.0" to version"3.0.0.0". If this section contains "System.Web.WebPages", update those elements from version "2.0.0.0" to version"3.0.0.0"  

    [!code-xml[Main](how-to-upgrade-an-aspnet-mvc-4-and-web-api-project-to-aspnet-mvc-5-and-web-api-2/samples/sample8.xml?highlight=3-5)]
3. If you removed the `Microsoft-Web-Helpers` NuGet package in a previous step, install `Microsoft.AspNet.WebHelpers` with the following command in the PMC:  
    `Install-Package -Id Microsoft.AspNet.WebHelpers`
4. If your app uses the [User.IsInRole()](https://msdn.microsoft.com/en-us/library/system.web.security.roleprincipal.isinrole(v=vs.110).aspx) method, add the following to the *Web.config* file.

    [!code-xml[Main](how-to-upgrade-an-aspnet-mvc-4-and-web-api-project-to-aspnet-mvc-5-and-web-api-2/samples/sample9.xml)]

## Final Steps

Build and test the application.

Remove the MVC 4 project type GUID from the project files.

1. In Solution Explorer, right-click the project name and then select **Unload Project**.
2. Right-click the project and select Edit ProjectName.csproj.
3. Locate the `ProjectTypeGuids` element and then remove the MVC 4 project GUID, `{E3E379DF-F4C6-4180-9B81-6769533ABE47}`.
4. Save and close the open project file.
5. Right-click the project and select **Reload Project**.