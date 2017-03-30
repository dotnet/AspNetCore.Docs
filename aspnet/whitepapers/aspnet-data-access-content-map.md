---
uid: whitepapers/aspnet-data-access-content-map
title: "ASP.NET Data Access - Recommended Resources | Microsoft Docs"
author: rick-anderson
description: "This topic provides links to documentation resources about how to access data in ASP.NET web applications, primarily by using the Entity Framework and SQL Se..."
ms.author: aspnetcontent
manager: wpickett
ms.date: 07/25/2013
ms.topic: article
ms.assetid: f8157be1-4ab9-469e-ad3a-0ccc80b56c00
ms.technology: 
ms.prod: .net-framework
msc.legacyurl: /whitepapers/aspnet-data-access-content-map
msc.type: content
---
ASP.NET Data Access - Recommended Resources
====================
> This topic provides links to documentation resources about how to access data in ASP.NET web applications, primarily by using the Entity Framework and SQL Server.
> 
> If you know a great blog post, [stackoverflow](http://stackoverflow.com) thread, or any other link that would be useful, [send us an email](mailto:aspnetue@microsoft.com?subject=Data Access Content Map) with the link.
> 
> Last updated 4/3/2014


The topic contains the following sections:

- [Getting Started with Data Access in ASP.NET](#gettingstarted)
- [Using the Entity Framework](#ef)

    - [Using Entity Framework Code First](#cf)
    - [Using Entity Framework Code First Migrations](#efcfmigrations)
    - [Using Entity Framework Database First or Model First (the EF Designer)](#efdbf)
    - [Loading Related data in Entity Framework (Lazy Loading, Eager Loading, and Explicit Loading)](#efrelateddata)
    - [Optimizing Entity Framework Performance](#optimizingef)
    - [Handling Concurrency in an Entity Framework Application](#efconcurrency)
    - [Books about the Entity Framework](#efbooks)
    - [Additional Entity Framework resources](#otherefresources)
- [Data Binding in ASP.NET Web Forms Applications](#wfdatabinding)

    - [Using Web Forms Model Binding](#wfmodelbinding)
    - [Using Web Forms Data Source Controls](#wfdsc)
    - [Using Web Forms Data-Bound Controls and Data-Binding Expressions](#wfdbc)
- [Working with SQL Server Databases](#sqlserver)

    - [Working with SQL Server Express LocalDB Databases](#sslocaldb)
    - [Working with SQL Server Express Databases](#sse)
    - [Working with Windows Azure SQL Database](#ssdb)
    - [Choosing between SQL Server and Windows Azure SQL Database](#ssdbchoosing)
- [Working with NoSQL Database Management Systems](#nosql)
- [Using LINQ queries in ASP.NET Applications](#linq)
- [Using Dynamic Data scaffolding](#dd)
- [Securing Data Access](#securing)
- [Optimizing Data Access Performance](#optimizingdataaccess)
- [Deploying a Database](#deploying)
- [Accessing Data through a Web Service](#webservice)
- [Additional Resources](#additional)

<a id="gettingstarted"></a>

## Getting Started with Data Access in ASP.NET

- [Data Storage Options (Building Real-World Cloud Apps with Windows Azure)](../aspnet/overview/developing-apps-with-windows-azure/building-real-world-cloud-apps-with-windows-azure/data-storage-options.md). Chapter of an e-book about developing for the cloud. Introduces NoSQL databases as an alternative that many developers familiar with relational databases tend to overlook. Presents guidelines on what to think about when choosing relational or NoSQL, or choosing a particular platform.
- [ASP.NET Data Access Options](https://msdn.microsoft.com/en-us/library/ms178359.aspx) (MSDN). An introduction to data access options for relational databases for ASP.NET and guidance on how to choose platforms and access methods that are appropriate for your scenario.
- [Relational database](http://en.wikipedia.org/wiki/Relational_database). Wikipedia). If you haven't worked with relational databases, see this page for an introduction to relational database terminology and concepts. For an introduction to SQL Server in particular see [Working with SQL Server databases](#sqlserver) later in this topic.

<a id="ef"></a>

## Using the Entity Framework

- [Entity Framework Development Approaches](https://msdn.microsoft.com/en-us/library/ms178359.aspx#dbfmfcf) (MSDN). Guidance on how to choose an Entity Framework development approach Database First, Model First, or Code First.

<a id="cf"></a>

### Using Entity Framework Code First
  

The following tutorials offer downloadable sample applications:

- [Getting Started with EF 6 using MVC 5](../mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application.md). Covers a wide range of Entity Framework Code First scenarios, including Migrations and EF 6 features such as connection resiliency, command interception, and async. This is an updated version of the [EF 5 / MVC 4 series](../mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application.md). The earlier series includes a tutorial on the repository and unit-of-work patterns that is not included in the new series.
- [Introduction to ASP.NET MVC 5](../mvc/overview/getting-started/introduction/getting-started.md). Covers a narrower range of Entity Framework Code First scenarios but does a more comprehensive job of introducing MVC features.
- [Model Binding and Web Forms](https://go.microsoft.com/fwlink/?LinkId=286117). Uses Code First in a Web Forms application.
- [Getting Started with ASP.NET 4.5 Web Forms](../web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/introduction-and-overview.md). An introduction to Web Forms with some coverage of Code First. Uses Model Binding.
- [MVC Music Store](../mvc/overview/older-versions/mvc-music-store/mvc-music-store-part-1.md). Uses Code First in an e-commerce MVC 3 application that also implements membership and authorization. The MVC version and ASP.NET membership (authentication and authorization) system used here are outdated; for more up-to-date information on ASP.NET membership, see [https://asp.net/identity](https://asp.net/identity).

Other resources:

- [Entity Framework - Code First to an Existing Database](https://msdn.microsoft.com/en-us/data/jj200620). MSDN. Video and walkthrough that shows how to use Code First with an existing database.
- [Data Developer Center - Entity Framework](https://msdn.microsoft.com/data/ef). MSDN. For a guide to Entity Framework documentation that has been created and maintained by the Entity Framework team, see the [Get Started](https://msdn.microsoft.com/en-us/data/ee712907) link.

See also [Books about the Entity Framework](#efbooks) and [Additional Entity Framework Resources](#otherefresources) later in this topic.

<a id="efcfmigrations"></a>

### Using Entity Framework Code First Migrations
  

Most of the Code First tutorials listed above cover migrations. See also the following resources.

- [ASP.NET Web Deployment using Visual Studio](../web-forms/overview/deployment/visual-studio-web-deployment/introduction.md). 2-part tutorial series that shows how to use Code First Migrations to deploy a database.
- [Deploy a Secure ASP.NET MVC 5 app with Membership, OAuth, and SQL Database to a Windows Azure Web Site](https://www.windowsazure.com/en-us/documentation/articles/web-sites-dotnet-deploy-aspnet-mvc-app-membership-oauth-sql-database/). Microsoft Azure). How to use migrations to deploy membership and application data to Azure.
- [Web Deployment Overview for Visual Studio and ASP.NET](https://msdn.microsoft.com/en-us/library/dd394698.aspx#dbdeployment). See the **Configuring Database Deployment in Visual Studio** section for an explanation of how Code First Migrations is integrated into Visual Studio web deployment features.
- [Data Developer Center - Code First Migrations](https://msdn.microsoft.com/en-us/data/jj591621) (MSDN). The Entity Framework team's Migrations documentation.
- [Migrations Screencast Series](https://blogs.msdn.com/b/adonet/archive/2014/03/12/migrations-screencast-series.aspx). EF blog). Three videos on advanced topics in Code First Migrations.
- [Code First Migrations With ASP.NET Web Pages Sites](http://www.mikesdotnetting.com/Article/217/Code-First-Migrations-With-ASP.NET-Web-Pages-Sites). Mikesdotnetting blog). Shows how to use Code First migrations with an ASP.NET Web Pages site by putting the data context in a Visual Studio class library project.

<a id="efdbf"></a>

### Using Entity Framework Database First or Model First (the EF Designer)

- [Getting Started with Entity Framework 6 Database First using MVC 5](../mvc/overview/getting-started/database-first-development/setting-up-database.md). Run a script in Server Explorer to create a database, and then use the Entity Framework designer to create the data model. Shows how to create simple CRUD web pages, and for other data handling functions you can follow one of the Code First tutorials since all EF workflows use the same DbContext API.

The following resources are older. They are useful if you want to use version 4.0 of the Entity Framework, and you want to use a data source control for data binding in a Web Forms application.

- [Getting Started with the Entity Framework 4.0](../web-forms/overview/older-versions-getting-started/getting-started-with-ef/the-entity-framework-and-aspnet-getting-started-part-1.md). Shows how to use the **EntityDataSource** control.
- [Continuing with the Entity Framework](../web-forms/overview/older-versions-getting-started/continuing-with-ef/using-the-entity-framework-and-the-objectdatasource-control-part-1-getting-started.md)(Shows how to use the **ObjectDataSource** Control. Includes a tutorial on concurrency handling, a tutorial on EF performance, and a tutorial on what's new in EF 4.0.

<a id="efrelateddata"></a>

### Handling related data in Entity Framework (Lazy Loading, Eager Loading, and Explicit Loading)

- [Reading Related Data with the Entity Framework in an ASP.NET MVC Application](../mvc/overview/getting-started/getting-started-with-ef-using-mvc/reading-related-data-with-the-entity-framework-in-an-asp-net-mvc-application.md). Code First, MVC sample application. The methods shown apply also to Web Forms model binding and the Database First workflow.
- [Data Developer Center - Loading Related Entities](https://msdn.microsoft.com/en-us/data/jj574232) (MSDN). The Entity Framework team's documentation about loading related data.

<a id="optimizingef"></a>

### Optimizing Entity Framework performance

- [Advanced Entity Framework Scenarios for an ASP.NET Application](../mvc/overview/getting-started/getting-started-with-ef-using-mvc/advanced-entity-framework-scenarios-for-an-mvc-web-application.md). Shows how to execute your own SQL statements or call your own stored procedures, how to disable change detection, and how to disable validation when saving changes.
- [Performance Considerations for Entity Framework 5](https://msdn.microsoft.com/en-us/data/hh949853) (MSDN).
- [Performance Considerations (Entity Framework)](https://msdn.microsoft.com/en-us/library/cc853327) (MSDN).
- [Maximizing Performance with the Entity Framework in an ASP.NET Web Application](../web-forms/overview/older-versions-getting-started/continuing-with-ef/maximizing-performance-with-the-entity-framework-in-an-asp-net-web-application.md). Applies to Entity Framework 4.0.
- See also [Optimizing ASP.NET data access](#optimizingdataaccess) later in this topic.

<a id="efconcurrency"></a>

### Handling Concurrency in an Entity Framework Application

- [Handling Concurrency with the Entity Framework in an ASP.NET MVC Application](../mvc/overview/getting-started/getting-started-with-ef-using-mvc/handling-concurrency-with-the-entity-framework-in-an-asp-net-mvc-application.md). Code First, DbContext API, using an MVC sample application.
- [Data Developer Center – Optimistic Concurrency Patterns](https://msdn.microsoft.com/en-us/data/jj592904) (MSDN). The Entity Framework team's concurrency documentation.
- [Handling Concurrency with the Entity Framework in an ASP.NET Web Application](../web-forms/overview/older-versions-getting-started/continuing-with-ef/handling-concurrency-with-the-entity-framework-in-an-asp-net-web-application.md). Applies to Entity Framework 4.0. Database First, ObjectContext API, using a Web Forms sample application.

<a id="efrepository"></a><a id="efbooks"></a>

### Books about the Entity Framework

- [Programming Entity Framework: DbContext](http://shop.oreilly.com/product/0636920022237.do) by Julie Lerman and Rowan Miller.
- [Programming Entity Framework: Code First](http://shop.oreilly.com/product/0636920022220.do) by Julie Lerman and Rowan Miller.

Both of these books are up-to-date with current recommended techniques. They provide a more comprehensive yet easy-to-follow introduction to the Entity Framework than anything available on the Internet. Another book, [Programming Entity Framework](http://shop.oreilly.com/product/9780596807252.do) by Julie Lerman, is larger and more comprehensive but it is older and many of the techniques it covers are no longer the recommended way to use the Entity Framework. See also the list of books recommended by the Entity Framework team at [Data Developer Center - Books](https://msdn.microsoft.com/en-us/data/aa937716) on the MSDN site.

<a id="otherefresources"></a>

### Other Entity Framework Resources

- [Entity Framework (ADO.NET) team blog](https://blogs.msdn.com/b/adonet/). One of the best resources for the most current information and announcements of new enhancements. For other EF-related blogs, see the Blogroll at [Get Started with Entity Framework](https://msdn.microsoft.com/en-us/data/ee712907).
- [MSDN Magazine](https://msdn.microsoft.com/en-us/magazine/default.aspx). See the **Data Points** column, which is frequently about topics related to the Entity Framework.

<a id="wfdatabinding"></a>

## Data Binding in ASP.NET Web Forms Applications

- [ASP.NET Web Forms Data Access Options](https://msdn.microsoft.com/en-us/library/jj822927.aspx) (MSDN)<a id="wfmodelbinding"></a>.

<a id="wfmodelbinding"></a>

### Using Web Forms Model Binding

- [Model Binding and Web Forms](https://go.microsoft.com/fwlink/?LinkId=286117). Tutorial series using EF Code First.
- [Web Forms Model Binding Part 1: Selecting Data](https://weblogs.asp.net/scottgu/archive/2011/09/06/web-forms-model-binding-part-1-selecting-data-asp-net-vnext-series.aspx) (Scott Guthrie's blog). In these older blog posts, the property that is currently named ItemType was named ModelType, but otherwise the information they contain is valid.
- [Web Forms Model Binding Part 2: Filtering Data](https://weblogs.asp.net/scottgu/archive/2011/09/12/web-forms-model-binding-part-2-filtering-data-asp-net-vnext-series.aspx) (Scott Guthrie's blog).
- [Web Forms Model Binding Part 3: Updating and Validation](https://weblogs.asp.net/scottgu/archive/2011/10/30/web-forms-model-binding-part-3-updating-and-validation-asp-net-4-5-series.aspx) (Scott Guthrie's blog).
- [ASP.NET 4.5 Web Forms Model Binding](../web-forms/videos/aspnet-web-forms-vnext/aspnet-45-web-forms-model-binding.md). (video).
- [Model Binding Part 1 - Selecting Data](../web-forms/videos/aspnet-web-forms-vnext/aspnet-vnext-videos-model-binding-part-1-selecting-data.md) (video).
- [Model Binding Part 2 - Filtering](../web-forms/videos/aspnet-web-forms-vnext/aspnet-vnext-videos-model-binding-part-2-filtering.md) (video).
- [Getting Started with ASP.NET 4.5 Web Forms - Display Data Items and Details](../web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/display_data_items_and_details.md).

<a id="wfdsc"></a>

### Using Web Forms Data Source Controls

- [Data Source Web Server Controls](https://msdn.microsoft.com/en-us/library/ms247258.aspx) (MSDN).
- [Announcing the release of Dynamic Data provider and EntityDataSource control for Entity Framework 6](https://blogs.msdn.com/b/webdev/archive/2014/02/28/announcing-the-release-of-dynamic-data-provider-and-entitydatasource-control-for-entity-framework-6.aspx) (Microsoft Web Development blog).

<a id="wfdbc"></a>

### Using Web Forms Data-Bound Controls and Data-Binding Expressions

- [Model Binding and Web Forms](https://go.microsoft.com/fwlink/?LinkId=286117). Tutorial series that uses EF Code First.
- [Getting Started with ASP.NET 4.5 Web Forms - Display Data Items and Details](../web-forms/overview/getting-started/getting-started-with-aspnet-45-web-forms/display_data_items_and_details.md).
- [Strongly Typed Data Controls](https://weblogs.asp.net/scottgu/archive/2011/09/02/strongly-typed-data-controls-asp-net-vnext-series.aspx) (Scott Guthrie's blog).
- [Strongly Typed Data Controls](../web-forms/videos/aspnet-web-forms-vnext/aspnet-vnext-videos-strongly-typed-data-controls.md) (video).
- [ASP.NET 4.5 Web Forms Strong Typed Data Controls](../web-forms/videos/aspnet-web-forms-vnext/aspnet-vnext-videos-strongly-typed-data-controls.md) (video).
- [Data-Bound Web Server Controls](https://msdn.microsoft.com/en-us/library/ms228214.aspx) (MSDN).
- [Data-Binding Expressions Overview](https://msdn.microsoft.com/en-us/library/ms178366.aspx) (MSDN). This page only covers **Eval** and **Bind**; it has not been updated to include **Item** and **BindItem**.

<a id="sqlserver"></a>

## Working with SQL Server Databases

- [SQL Server Database Features](https://msdn.microsoft.com/en-us/library/hh230827.aspx) (MSDN). For a general introduction to a wide variety of SQL Server topics, see the entries under this one in the TOC.
- [SQL Server Editions](https://msdn.microsoft.com/en-us/library/ms178359.aspx#sqlserver) (MSDN). A summary of the available SQL Server editions, with links to more information about each one.)
- [SQL Server Connection Strings for ASP.NET Web Applications](https://msdn.microsoft.com/en-us/library/jj653752.aspx) (MSDN).
- [Using SQL Server Compact for ASP.NET Web Applications](https://msdn.microsoft.com/en-us/library/ms247257.aspx) (MSDN).
- [Microsoft SQL Server: Database Product Samples](https://go.microsoft.com/fwlink?linkid=117483) (CodePlex site). Sample AdventureWorks databases.
- [Installing Sample Databases](https://go.microsoft.com/fwlink/?linkid=142438) (CodePlex site). In addition to the methods shown here, you can also download one of the sample .mdf files to the App\_Data folder of a web project, convert the database to LocalDB, and create a LocalDB connection string. For information about how to do that, see [How to: Upgrade to LocalDB](https://msdn.microsoft.com/en-us/library/hh873188.aspx).

See also the following sections on working with SQL Server Express and LocalDB, and choosing between SQL Server and SQL Database.

<a id="sslocaldb"></a>

### Working with SQL Server Express LocalDB Databases

- [SQL Server Express 2012 LocalDB](https://msdn.microsoft.com/en-us/library/hh510202(v=sql.110).aspx) (MSDN). The official MSDN introduction to LocalDB.
- [SQL Server Connection Strings for ASP.NET Web Applications](https://msdn.microsoft.com/en-us/library/jj653752.aspx) (MSDN).
- [How to: Upgrade to LocalDB](https://msdn.microsoft.com/en-us/library/hh873188.aspx) (MSDN). How to migrate an .mdf file from an earlier version of SQL Server Express to LocalDB. You also have to go through this process if you download one of the [SQL Server 2012 sample databases](https://go.microsoft.com/fwlink/?linkid=117483).
- [Introducing LocalDB, an improved SQL Express](https://go.microsoft.com/fwlink/?LinkId=234375) (SQL Server Express blog). Has more background on why LocalDB was created than is included in MSDN.
- [LocalDB: Where is My Database?](https://go.microsoft.com/fwlink/?LinkId=234376) (SQL Server Express blog). Information about where LocalDB database files are created.
- [Using LocalDB with Full IIS, Part 1: User Profile](https://blogs.msdn.com/b/sqlexpress/archive/2011/12/09/using-localdb-with-full-iis-part-1-user-profile.aspx) (SQL Server Express blog). LocalDB is not designed to work with IIS. This series of blog posts explains the issues and some workarounds.

<a id="sse"></a>

### Working with SQL Server Express Databases

- [SQL Server Connection Strings for ASP.NET Web Applications](https://msdn.microsoft.com/en-us/library/jj653752.aspx) (MSDN). If you use the AttachDBFileName connection string setting with SQL Server Express, see especially the User Instance section of this page.
- [How to take ownership of your local SQL Server Express 2008](https://blogs.msdn.com/b/sqlexpress/archive/2010/02/23/how-to-take-ownership-of-your-local-sql-server-2008-express.aspx) (SQL Server Express blog). A common problem is not being able to work with SQL Server Express databases because you're not an administrator on the SQL Server Express instance. By default, only the person who installed SQL Server Express is an administrator. This blog explains how to make yourself a SQL Server Express administrator if you're an administrator on the computer.
- [Can my ASP.NET web application use a SQL Server Express database in production?](https://msdn.microsoft.com/en-us/library/jj653753.aspx#sql_express_in_production) (MSDN).

<a id="ssdb"></a>

### Working with Windows Azure SQL Database

- [Deploy a Secure ASP.NET MVC app with Membership, OAuth, and SQL Database to a Windows Azure Web Site](https://www.windowsazure.com/en-us/develop/net/tutorials/web-site-with-sql-database/) (Microsoft Azure site).
- [SQL Databases](https://www.windowsazure.com/en-us/manage/services/sql-databases/) (Microsoft Azure site). Getting started tutorials and how-to guides.
- [Windows Azure SQL Database](https://msdn.microsoft.com/en-us/library/windowsazure/ee336279.aspx) (MSDN). The top-level node of the table of contents for SQL Database in MSDN.
- [Windows Azure SQL Database TechNet Wiki Articles Index](https://social.technet.microsoft.com/wiki/contents/articles/2267.windows-azure-sql-database-technet-wiki-articles-index-en-us.aspx) (Microsoft TechNet site).
- [Transient Fault Handling Application Block](https://msdn.microsoft.com/en-us/library/hh680934(v=PandP.50).aspx). A framework that enables you to handle transient network faults and connection errors that result from throttling. Available in a NuGet package: [Enterprise Library 5.0 - Transient Fault Handling Application Block](http://nuget.org/packages/EnterpriseLibrary.WindowsAzure.TransientFaultHandling).
- [Getting Started with SQL Database and Entity Framework](https://msdn.microsoft.com/en-us/data/jj556244) (MSDN).
- [Windows Azure Training Kit](https://www.microsoft.com/en-us/download/details.aspx?id=8396) (Microsoft Download Center). Includes hands-on labs for SQL Database.
- [Windows Azure SQL Database Community Forum](https://social.msdn.microsoft.com/Forums/en-US/ssdsgetstarted/threads).
- [Moving to Windows Azure SQL Database](https://msdn.microsoft.com/en-us/library/ff803375.aspx) (MSDN). One chapter of a comprehensive end-to-end scenario by the Microsoft Patterns and Practices team. Covers why you might want to migrate and how to migrate from SQL Server to SQL Database.
- [Migrating SQL Server Databases to Windows Azure SQL Database](https://msdn.microsoft.com/en-us/library/windowsazure/jj156160.aspx) (MSDN).
- [SQL Database Migration Wizard](http://sqlazuremw.codeplex.com/). An open source tool for migrating databases to and from SQL Database.

<a id="ssdbchoosing"></a>

### Choosing between SQL Server and Windows Azure SQL Database

- [Compare SQL Server with Windows Azure SQL Database](https://social.technet.microsoft.com/wiki/contents/articles/996.compare-sql-server-with-windows-azure-sql-database-en-us.aspx) (Microsoft TechNet site).
- [Data Migration to Windows Azure SQL Database: Tools and Techniques](https://msdn.microsoft.com/en-us/library/windowsazure/hh694043.aspx) (MSDN). Includes sections that compare SQL Server to SQL Database and provide guidance on when to migrate from SQL Server to SQL Database.
- [Windows Azure SQL Database Delivery Guide](https://social.technet.microsoft.com/wiki/contents/articles/3398.windows-azure-sql-database-delivery-guide-en-us.aspx) (Microsoft TechNet site).
- [SQL Server Feature Limitations (Windows Azure SQL Database)](https://msdn.microsoft.com/en-us/library/windowsazure/ff394115.aspx) (MSDN).
- [Windows Azure Table Storage and Windows Azure SQL Database - Compared and Contrasted](https://msdn.microsoft.com/en-us/library/jj553018.aspx) (MSDN). For an application that you deploy to Windows Azure, Windows Azure Table storage might be an alternative to Windows Azure SQL Database. This topic helps you decide between these alternatives.
- [Windows Azure SQL Database](https://msdn.microsoft.com/en-us/library/windowsazure/ee336279) (MSDN).
- [Guidelines and Limitations (Windows Azure SQL Database)](https://msdn.microsoft.com/en-us/library/windowsazure/ff394102.aspx)

<a id="nosql"></a>

## Working with NoSQL Database Management Systems

- [Windows Azure Data Services](https://www.windowsazure.com/en-us/develop/net/data/) (Microsoft Azure site). See the [Table Service feature guide](https://www.windowsazure.com/en-us/develop/net/how-to-guides/table-services/) and the **Big Data** section of the page.
- [ASP.NET Multi-Tier Application Using Storage Tables, Queues, and Blobs](https://www.windowsazure.com/en-us/develop/net/tutorials/multi-tier-web-site/1-overview/) (Microsoft Azure site). End-to-end tutorial with downloadable sample application that uses Windows Azure storage NoSQL tables.

<a id="linq"></a>

## Using LINQ Queries in ASP.NET Applications

- [ASP.NET Data Access Options](https://msdn.microsoft.com/en-us/library/ms178359.aspx#linq) (MSDN). Includes an introduction to LINQ.
- [LINQ Training Videos](http://www.misfitgeek.com/windows-client-linq-training-videos-20/) (Joe Stagner's blog).
- [ASP.NET Forum thread with links to dynamic LINQ resources](https://forums.asp.net/p/1961037/5601994.aspx?Please+suggest+good+books+so+that+one+can+write+and+understand+dynamic+linq).

<a id="dd"></a>

## Using Dynamic Data Scaffolding

- [Dynamic Data Project Templates](https://msdn.microsoft.com/en-us/library/jj822927.aspx#dynamicdata) (MSDN). Guidance on when to use Dynamic Data projects.
- [ASP.NET Dynamic Data](https://msdn.microsoft.com/en-us/library/ee845452.aspx) (MSDN).

<a id="securing"></a>

## Securing Data Access

- [Securing Data Access in ASP.NET](https://msdn.microsoft.com/en-us/library/ms178375.aspx) (MSDN).
- [Security Considerations (Entity Framework)](https://msdn.microsoft.com/en-us/library/cc716760.aspx) (MSDN).
- [How To: Secure Connection Strings when Using Data Source Controls](https://msdn.microsoft.com/en-us/library/ms178372.aspx) (MSDN).

<a id="optimizingdataaccess"></a>

## Optimizing Data Access Performance

- [ASP.NET Performance Overview](https://msdn.microsoft.com/en-us/library/cc668225.aspx) (MSDN).
- [ASP.NET Caching](https://msdn.microsoft.com/en-us/library/xsbfdd8c.aspx) (MSDN).
- [Improving ASP.NET Performance](https://msdn.microsoft.com/en-us/library/ff647787) (MSDN). There is a "Retired Content" warning at the top of this page, but most of the information is still relevant and there is no comparable updated resource.
- [Improving SQL Server Performance](https://msdn.microsoft.com/en-us/library/ff647793) (MSDN). Same comment as the previous link.

See also [Optimizing Entity Framework performance](#optimizingef) earlier in this topic.

<a id="deploying"></a>

## Deploying a Database

- [ASP.NET Web Deployment - Recommended Resources](aspnet-web-deployment-content-map.md) (MSDN).

<a id="webservice"></a>

## Accessing Data through a Web Service

- [Accessing Data through a Web Service](https://msdn.microsoft.com/en-us/library/ms178359.aspx#webservice) (MSDN). Guidance on when to use Web API versus WCF.
- [Getting Started with ASP.NET Web API](../web-api/index.md).
- [WCF Data Services](https://msdn.microsoft.com/en-us/data/bb931106) (MSDN).

<a id="additional"></a>

## Additional Resources

- [ASP.NET Data Access FAQ](https://msdn.microsoft.com/en-us/library/jj653753.aspx) (MSDN).
- [ASP.NET Web Forms Tutorials - Data](../web-forms/overview/data-access/index.md). Most of these tutorials are relatively old; make sure you read  [ASP.NET Data Access Options](https://msdn.microsoft.com/en-us/library/ms178359.aspx) and [Data Storage Options (Building Real-World Cloud Apps with Windows Azure)](../aspnet/overview/developing-apps-with-windows-azure/building-real-world-cloud-apps-with-windows-azure/data-storage-options.md) first so that you don't get too far into a data access method that isn't right for your scenario.
- [ASP.NET MVC Content Map](../mvc/overview/getting-started/recommended-resources-for-mvc.md).
- [ASP.NET Web Pages Tutorials - Data](../web-pages/overview/data/index.md).
- [Accessing Data in Visual Studio](https://msdn.microsoft.com/en-us/library/wzabh8c4.aspx) (MSDN). Provides a list of links similar to this content map but with a focus on Visual Studio rather than ASP.NET.