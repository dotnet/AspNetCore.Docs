---
title: Razor Pages authorization conventions in ASP.NET Core
author: guardrex
description: Learn how to control access to pages with conventions that authorize users and allow anonymous users to access pages or folders of pages.
ms.author: riande
ms.custom: mvc
ms.date: 10/27/2017
uid: security/authorization/razor-pages-authorization
---
# Razor Pages authorization conventions in ASP.NET Core

By [Luke Latham](https://github.com/guardrex)

One way to control access in your Razor Pages app is to use authorization conventions at startup. These conventions allow you to authorize users and allow anonymous users to access individual pages or folders of pages. The conventions described in this topic automatically apply [authorization filters](xref:mvc/controllers/filters#authorization-filters) to control access.

[View or download sample code](https://github.com/aspnet/Docs/tree/master/aspnetcore/security/authorization/razor-pages-authorization/samples) ([how to download](xref:tutorials/index#how-to-download-a-sample))

The sample app uses [Cookie authentication without ASP.NET Core Identity](xref:security/authentication/cookie). The user account for the hypothetical user, Maria Rodriguez, is hardcoded into the app. Use the Email username "maria.rodriguez@contoso.com" and any password to sign in the user. The user is authenticated in the `AuthenticateUser` method in the *Pages/Account/Login.cshtml.cs* file. In a real-world example, the user would be authenticated against a database. To use ASP.NET Core Identity, follow the guidance in the [Introduction to Identity on ASP.NET Core](xref:security/authentication/identity) topic. The concepts and examples shown in this topic apply equally to apps that use ASP.NET Core Identity.

## Require authorization to access a page

Use the [AuthorizePage](/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.authorizepage) convention via [AddRazorPagesOptions](/dotnet/api/microsoft.extensions.dependencyinjection.mvcrazorpagesmvcbuilderextensions.addrazorpagesoptions) to add an [AuthorizeFilter](/dotnet/api/microsoft.aspnetcore.mvc.authorization.authorizefilter) to the page at the specified path:

[!code-csharp[](razor-pages-authorization/samples/2.x/AuthorizationSample/Startup.cs?name=snippet1&highlight=2,4)]

The specified path is the View Engine path, which is the Razor Pages root relative path without an extension and containing only forward slashes.

An [AuthorizePage overload](/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.authorizepage#Microsoft_Extensions_DependencyInjection_PageConventionCollectionExtensions_AuthorizePage_Microsoft_AspNetCore_Mvc_ApplicationModels_PageConventionCollection_System_String_System_String_) is available if you need to specify an authorization policy.

::: moniker range=">= aspnetcore-2.1"

> [!NOTE]
> An `AuthorizeFilter` can be applied to a page model class with the `[Authorize]` filter attribute. For more information, see [Authorize filter attribute](xref:razor-pages/filter#authorize-filter-attribute).

::: moniker-end

## Require authorization to access a folder of pages

Use the [AuthorizeFolder](/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.authorizefolder) convention via [AddRazorPagesOptions](/dotnet/api/microsoft.extensions.dependencyinjection.mvcrazorpagesmvcbuilderextensions.addrazorpagesoptions) to add an [AuthorizeFilter](/dotnet/api/microsoft.aspnetcore.mvc.authorization.authorizefilter) to all of the pages in a folder at the specified path:

[!code-csharp[](razor-pages-authorization/samples/2.x/AuthorizationSample/Startup.cs?name=snippet1&highlight=2,5)]

The specified path is the View Engine path, which is the Razor Pages root relative path.

An [AuthorizeFolder overload](/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.authorizefolder#Microsoft_Extensions_DependencyInjection_PageConventionCollectionExtensions_AuthorizeFolder_Microsoft_AspNetCore_Mvc_ApplicationModels_PageConventionCollection_System_String_System_String_) is available if you need to specify an authorization policy.

::: moniker range=">= aspnetcore-2.1"

## Require authorization to access an area page

Use the [AuthorizeAreaPage](/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.authorizeareapage) convention via [AddRazorPagesOptions](/dotnet/api/microsoft.extensions.dependencyinjection.mvcrazorpagesmvcbuilderextensions.addrazorpagesoptions) to add an [AuthorizeFilter](/dotnet/api/microsoft.aspnetcore.mvc.authorization.authorizefilter) to the area page at the specified path:

```csharp
options.Conventions.AuthorizeAreaPage("Identity", "/Manage/Accounts");
```

The page name is the path of the file without an extension relative to the pages root directory for the specified area. For example, the page name for the file *Areas/Identity/Pages/Manage/Accounts.cshtml* is */Manage/Accounts*.

An [AuthorizeAreaPage overload](/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.authorizeareapage#Microsoft_Extensions_DependencyInjection_PageConventionCollectionExtensions_AuthorizeAreaPage_Microsoft_AspNetCore_Mvc_ApplicationModels_PageConventionCollection_System_String_System_String_System_String_) is available if you need to specify an authorization policy.

## Require authorization to access a folder of areas

Use the [AuthorizeAreaFolder](/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.authorizeareafolder) convention via [AddRazorPagesOptions](/dotnet/api/microsoft.extensions.dependencyinjection.mvcrazorpagesmvcbuilderextensions.addrazorpagesoptions) to add an [AuthorizeFilter](/dotnet/api/microsoft.aspnetcore.mvc.authorization.authorizefilter) to all of the areas in a folder at the specified path:

```csharp
options.Conventions.AuthorizeAreaFolder("Identity", "/Manage");
```

The folder path is the path of the folder relative to the pages root directory for the specified area. For example, the folder path for the files under *Areas/Identity/Pages/Manage/* is */Manage*.

An [AuthorizeAreaFolder overload](/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.authorizeareafolder#Microsoft_Extensions_DependencyInjection_PageConventionCollectionExtensions_AuthorizeAreaFolder_Microsoft_AspNetCore_Mvc_ApplicationModels_PageConventionCollection_System_String_System_String_System_String_) is available if you need to specify an authorization policy.

::: moniker-end

## Allow anonymous access to a page

Use the [AllowAnonymousToPage](/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.allowanonymoustopage) convention via [AddRazorPagesOptions](/dotnet/api/microsoft.extensions.dependencyinjection.mvcrazorpagesmvcbuilderextensions.addrazorpagesoptions) to add an [AllowAnonymousFilter](/dotnet/api/microsoft.aspnetcore.mvc.authorization.allowanonymousfilter) to a page at the specified path:

[!code-csharp[](razor-pages-authorization/samples/2.x/AuthorizationSample/Startup.cs?name=snippet1&highlight=2,6)]

The specified path is the View Engine path, which is the Razor Pages root relative path without an extension and containing only forward slashes.

## Allow anonymous access to a folder of pages

Use the [AllowAnonymousToFolder](/dotnet/api/microsoft.extensions.dependencyinjection.pageconventioncollectionextensions.allowanonymoustofolder) convention via [AddRazorPagesOptions](/dotnet/api/microsoft.extensions.dependencyinjection.mvcrazorpagesmvcbuilderextensions.addrazorpagesoptions) to add an [AllowAnonymousFilter](/dotnet/api/microsoft.aspnetcore.mvc.authorization.allowanonymousfilter) to all of the pages in a folder at the specified path:

[!code-csharp[](razor-pages-authorization/samples/2.x/AuthorizationSample/Startup.cs?name=snippet1&highlight=2,7)]

The specified path is the View Engine path, which is the Razor Pages root relative path.

## Note on combining authorized and anonymous access

It's perfectly valid to specify that a folder of pages require authorization and specify that a page within that folder allows anonymous access:

```csharp
// This works.
.AuthorizeFolder("/Private").AllowAnonymousToPage("/Private/Public")
```

The reverse, however, isn't true. You can't declare a folder of pages for anonymous access and specify a page within for authorization:

```csharp
// This doesn't work!
.AllowAnonymousToFolder("/Public").AuthorizePage("/Public/Private") 
```

Requiring authorization on the Private page won't work because when both the `AllowAnonymousFilter` and `AuthorizeFilter` filters are applied to the page, the `AllowAnonymousFilter` wins and controls access.

## Additional resources

* [Razor Pages custom route and page model providers](xref:razor-pages/razor-pages-conventions)
* [PageConventionCollection](/dotnet/api/microsoft.aspnetcore.mvc.applicationmodels.pageconventioncollection) class
