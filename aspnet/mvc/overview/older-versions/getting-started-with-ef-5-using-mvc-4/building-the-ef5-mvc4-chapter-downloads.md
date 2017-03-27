---
uid: mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/building-the-ef5-mvc4-chapter-downloads
title: "Building the Chapter Downloads for the EF 5 MVC 4 Tutorials | Microsoft Docs"
author: Rick-Anderson
description: "The Contoso University sample web application demonstrates how to create ASP.NET MVC 4 applications using the Entity Framework 5 Code First and Visual Studio..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 07/30/2013
ms.topic: article
ms.assetid: d0a89089-eed8-4f61-a478-c5ffa30186f5
ms.technology: dotnet-mvc
ms.prod: .net-framework
msc.legacyurl: /mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/building-the-ef5-mvc4-chapter-downloads
msc.type: authoredcontent
---
Building the Chapter Downloads for the EF 5 MVC 4 Tutorials
====================
by [Rick Anderson](https://github.com/Rick-Anderson)

[Download Completed Project](http://code.msdn.microsoft.com/Getting-Started-with-dd0e2ed8)

> The Contoso University sample web application demonstrates how to create ASP.NET MVC 4 applications using the Entity Framework 5 Code First and Visual Studio 2012. For information about the tutorial series, see [the first tutorial in the series](creating-an-entity-framework-data-model-for-an-asp-net-mvc-application.md).


## Building the Chapter Downloads

1. Download and unzip the  project sample zip file. In the unzipped download package, you will find additional zip files, one for the completion of each chapter.
2. Right click on the desired zip file, click **Properties**, and click the **Unblock** button.  
  
    ![](building-the-ef5-mvc4-chapter-downloads/_static/image1.png)
3. Unzip the file.
4. Double-click the *CUx.sln* file to launch Visual Studio.
5. From the **Tools** menu, click **Library Package Manager**, then **Package Manager Console**.  
  
    ![](building-the-ef5-mvc4-chapter-downloads/_static/image2.png)
6. In the Package Manager Console (PMC), click **Restore**.  
  
    ![](building-the-ef5-mvc4-chapter-downloads/_static/image3.png)
7. Exit Visual Studio.
8. Restart Visual Studio, opening the solution file you closed in the step above.
9. In the Package Manager Console (PMC), enter the `Update-Database` command:  
  
    ![](building-the-ef5-mvc4-chapter-downloads/_static/image4.png)  

    > [!NOTE]
    > If you get the following error:  
    >   
    >  *The term 'Update-Database' is not recognized as the name of a cmdlet, function, script file, or operable program. Check the spelling of the name, or if a path was included, verify that the path is correct and try again.*  
    > Exit and restart Visual Studio.

    Each migration will run, then the seed method will run. You can now run the app.

    ![](building-the-ef5-mvc4-chapter-downloads/_static/image5.png)

>[!div class="step-by-step"]
[Previous](advanced-entity-framework-scenarios-for-an-mvc-web-application.md)