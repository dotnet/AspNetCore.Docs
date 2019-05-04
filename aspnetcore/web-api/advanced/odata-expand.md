---
title: "OData Expand"
#author: 
description: Using OData expand to query related data
#ms.author: riande
ms.custom: mvc
ms.date: 4/5/2019
uid: web-api/advanced/odata-expand
---

# OData Expand

By [FIVIL](https://twitter.com/F_IVI_L) 

This tutorial demonstrates how you can query related entities using OData.

For this tutorial we use [ContosoUniversity sample](https://github.com/aspnet/AspNetCore.Docs/tree/master/aspnetcore/data/ef-rp/intro/samples/cu21) as a base project model.

## Configure middleware

Update the `Configure` method in *Startup.cs* with the following highlighted code:

 [!code-csharp[](odata-advanced/samples/odata-expand/Startup.cs?highlight=57-61]