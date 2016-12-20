---
title: "Table Profile Provider Samples | Microsoft Docs"
author: rick-anderson
description: "The default SqlProfileProvider that ships with ASP.NET 2.0 “blobicizes” Profile data using string, XML or binary serialization prior to storing information i..."
ms.author: riande
manager: wpickett
ms.date: 04/04/2012
ms.topic: article
ms.assetid: 
ms.technology: 
ms.prod: .net-framework
msc.legacyurl: /downloads/sandbox/table-profile-provider-samples
---
[Edit .md file](C:\Projects\msc\dev\Msc.Www\Web.ASP\App_Data\github\downloads\sandbox\table-profile-provider-samples.md) | [Edit dev content](http://www.aspdev.net/umbraco#/content/content/edit/37854) | [View dev content](http://docs.aspdev.net/tutorials/downloads/sandbox/table-profile-provider-samples.html) | [View prod content](http://www.asp.net/downloads/sandbox/table-profile-provider-samples) | Picker: 37854

Table Profile Provider Samples
====================
> ![](table-profile-provider-samples/_static/image1.gif) The default SqlProfileProvider that ships with ASP.NET 2.0 "blobicizes" Profile data using string, XML or binary serialization prior to storing information in SQL Server. A frequent request from developers is the ability to store Profile data "in the clear" in the database so that the data is available for querying and use in stored procedures. The two samples in this download solve this problem.
> 
> - [Download Samples](https://download.microsoft.com/download/7/f/e/7fe795fb-d9aa-4625-a719-4d380ac99c57/ASP.NET 2.0 Table Profile Provider Samples.msi)
> - [Download Whitepaper](https://download.microsoft.com/download/a/0/2/a026c0fa-d655-4aa9-b605-88cca775f6ea/Sample Profile Providers (Table and Stored Procedure Based).doc)
> - [Discuss in the Web Forms Forum](https://forums.asp.net/18.aspx)


## Features

The first sample provider (SqlTableProfileProvider) stores each Profile property in a separate database column. Furthermore the provider stores the Profile data without serializing it, which means that the Profile property type needs to be compatible with the target database column.

The second sample provider (SqlStoredProcedureProfileProvider) maps each Profile property to a parameter on a custom stored procedure. Like the table based provider, this provider expects that each Profile property is of a type that is compatible with its corresponding stored procedure parameter. The powerful aspect of the stored procedure based provider is that other than the requirement to implement some stored procedures with a specific set of parameters, you can implement whatever business logic you need in the stored procedures to map the Profile data to your own database schema and database logic.

## Setup

The downloadable samples include walkthroughs for setting up and using both the table-based and the stored procedure based providers. To make use of the sample site:

- Copy the files in this sample to a virtual directory.
- Edit the web.config file to change the connection string so it points at your database and server.
- In the App\_Data directory there is a sample SQL script that you can use with the walkthrough document. You will need to change the database name and security accounts in the database script to match your database environment.

## About the Author

![Hao Kung](table-profile-provider-samples/_static/image1.jpg) Hao Kung is a Software Design Engineer working in the Microsoft ASP.NET team. He grew up in New Jersey, graduated from Cornell University in 2001, and joined Microsoft in 2003. He enjoys playing computer games, poker, and reading fantasy and sci-fi novels during his free time.