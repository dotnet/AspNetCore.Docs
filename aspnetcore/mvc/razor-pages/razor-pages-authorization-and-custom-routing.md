---
title: Razor Pages authorization conventions in ASP.NET Core
author: guardrex
description: Learn how to control access to pages with conventions at startup that authorize users and allow anonymous users to access individual pages or folders of pages.
keywords: ASP.NET Core,Razor Pages,authorization,AllowAnonymousToPage,AllowAnonymousToFolder,AuthorizePage,AuthorizeFolder
ms.author: riande
manager: wpickett
ms.date: 10/23/2017
ms.topic: article
ms.assetid: f65ad22d-9472-478a-856c-c59c8681fa71
ms.technology: aspnet
ms.prod: asp.net-core
uid: mvc/razor-pages/razor-pages-authorization-conventions
---
# Razor Pages authorization conventions in ASP.NET Core

By [Luke Latham](https://github.com/guardrex)

To control access to the pages in your Razor Pages app, use conventions at startup to authorize users and allow anonymous users to access individual pages or folders of pages. The conventions described in this topic automatically apply [filters](xref:mvc/controllers/filters) to control access.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/mvc/razor-pages/razor-pages-authorization-conventions/sample) ([how to download](xref:tutorials/index#how-to-download-a-sample))

## Require authorization to access a page

Use the [AuthorizePage](/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.authorizepage) convention via [AddRazorPagesOptions](/dotnet/api/microsoft.extensions.dependencyinjection.mvcrazorpagesmvcbuilderextensions.addrazorpagesoptions) to add an [AuthorizeFilter](/dotnet/api/microsoft.aspnetcore.mvc.authorization.authorizefilter) to the page at the specified path:

[!code-csharp[Main](razor-pages-authorization-conventions/sample/Startup.cs?name=snippet1&highlight=2,4)]

An [AuthorizePage overload](/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.authorizepage#Microsoft_Extensions_DependencyInjection_PageConventionCollectionExtensions_AuthorizePage_Microsoft_AspNetCore_Mvc_ApplicationModels_PageConventionCollection_System_String_System_String_) is available if you need to specify an authorization policy.

## Require authorization to access a folder of pages

Use the [AuthorizeFolder](/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.authorizefolder) convention via [AddRazorPagesOptions](/dotnet/api/microsoft.extensions.dependencyinjection.mvcrazorpagesmvcbuilderextensions.addrazorpagesoptions) to add an [AuthorizeFilter](/dotnet/api/microsoft.aspnetcore.mvc.authorization.authorizefilter) to all of the pages in a folder at the specified path:

[!code-csharp[Main](razor-pages-authorization-conventions/sample/Startup.cs?name=snippet1&highlight=2,5)]

An [AuthorizeFolder overload](/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.authorizefolder#Microsoft_Extensions_DependencyInjection_PageConventionCollectionExtensions_AuthorizeFolder_Microsoft_AspNetCore_Mvc_ApplicationModels_PageConventionCollection_System_String_System_String_) is available if you need to specify an authorization policy.

## Allow anonymous access to a page

Use the [AllowAnonymousToPage](/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.allowanonymoustopage) convention via [AddRazorPagesOptions](/dotnet/api/microsoft.extensions.dependencyinjection.mvcrazorpagesmvcbuilderextensions.addrazorpagesoptions) to add an [AllowAnonymousFilter](/dotnet/api/microsoft.aspnetcore.mvc.authorization.allowanonymousfilter) to a page at the specified path:

[!code-csharp[Main](razor-pages-authorization-conventions/sample/Startup.cs?name=snippet1&highlight=2,6)]

## Allow anonymous access to a folder of pages

Use the [AllowAnonymousToFolder](/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.allowanonymoustofolder) convention via [AddRazorPagesOptions](/dotnet/api/microsoft.extensions.dependencyinjection.mvcrazorpagesmvcbuilderextensions.addrazorpagesoptions) to add an [AllowAnonymousFilter](/dotnet/api/microsoft.aspnetcore.mvc.authorization.allowanonymousfilter) to all of the pages in a folder at the specified path:

[!code-csharp[Main](razor-pages-authorization-conventions/sample/Startup.cs?name=snippet1&highlight=2,7)]

## Note on combining authorized and anonymous access

It's perfectly valid to specify that a folder of pages require authorization and specify that a page within that folder allows anonymous access:

```csharp
// This works.
.AuthorizeFolder("/Private").AllowAnonymousToPage("/Public")
```

The reverse, however, isn't true. You can't declare a folder of pages for anonymous access and specify a page within for authorization:

```csharp
// This doesn't work!
.AllowAnonymousToFolder("/Public").AuthorizePage("/Private") 
```

Requiring authorization on the Private page won't work because when both the `AllowAnonymousFilter` and `AuthorizeFilter` filters are applied to the page, the `AllowAnonymousFilter` wins and controls access.

## See also

* [PageConventionCollection](/dotnet/api/microsoft.aspnetcore.mvc.applicationmodels.pageconventioncollection) class
