---
title: Razor Pages authorization conventions in ASP.NET Core
author: wadepickett
description: Learn how to control access to pages with conventions that authorize users and allow anonymous users to access pages or folders of pages.
monikerRange: '>= aspnetcore-2.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 03/25/2026
uid: razor-pages/security/authorization/conventions
---
# Razor Pages authorization conventions in ASP.NET Core

One way to control access in a Razor Pages app is to use authorization conventions at startup. These conventions allow the app to authorize users and allow anonymous users to access individual pages or folders of pages. The conventions described in this article automatically apply [authorization filters](xref:mvc/controllers/filters#authorization-filters) to control access.

[View or download sample code](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/security/authorization/RazorPagesAuthorization) ([how to download](xref:fundamentals/index#how-to-download-a-sample))

The sample app uses [cookie authentication without ASP.NET Core Identity](xref:security/authentication/cookie). To use ASP.NET Core Identity, follow the guidance in <xref:security/authentication/identity>.

## Require authorization to access a page

Use the <xref:Microsoft.Extensions.DependencyInjection.PageConventionCollectionExtensions.AuthorizePage%2A> convention to add an <xref:Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter> to the page at the specified path:

:::moniker range=">= aspnetcore-10.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/RazorPagesAuthorization/10.x/AuthorizationSample/Program.cs" id="snippet1" highlight="3":::

:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-10.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/RazorPagesAuthorization/3.x/AuthorizationSample/Startup.cs" id="snippet1" highlight="3":::

:::moniker-end

:::moniker range="< aspnetcore-3.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/RazorPagesAuthorization/2.x/AuthorizationSample/Startup.cs" id="snippet1" highlight="2,4":::

:::moniker-end

The specified path is the View Engine path, which is the Razor Pages root relative path without an extension and containing only forward slashes.

To specify an [authorization policy](xref:security/authorization/policies), use an [`AuthorizePage` overload](xref:Microsoft.Extensions.DependencyInjection.PageConventionCollectionExtensions.AuthorizePage%2A):

```csharp
options.Conventions.AuthorizePage("/Contact", "AtLeast21");
```

> [!NOTE]
> An <xref:Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter> can be applied to a page model class with the `[Authorize]` filter attribute. For more information, see <xref:razor-pages/filter#authorize-filter-attribute>.

## Require authorization to access a folder of pages

Use the <xref:Microsoft.Extensions.DependencyInjection.PageConventionCollectionExtensions.AuthorizeFolder%2A> convention to add an <xref:Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter> to all of the pages in a folder at the specified path:

:::moniker range=">= aspnetcore-10.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/RazorPagesAuthorization/10.x/AuthorizationSample/Program.cs" id="snippet1" highlight="4":::

:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-10.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/RazorPagesAuthorization/3.x/AuthorizationSample/Startup.cs" id="snippet1" highlight="4":::

:::moniker-end

:::moniker range="< aspnetcore-3.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/RazorPagesAuthorization/2.x/AuthorizationSample/Startup.cs" id="snippet1" highlight="2,5":::

:::moniker-end

The specified path is the View Engine path, which is the Razor Pages root relative path containing only forward slashes.

To specify an [authorization policy](xref:security/authorization/policies), use an [`AuthorizeFolder` overload](xref:Microsoft.Extensions.DependencyInjection.PageConventionCollectionExtensions.AuthorizeFolder%2A):

```csharp
options.Conventions.AuthorizeFolder("/Private", "AtLeast21");
```

## Require authorization to access an area page

Use the <xref:Microsoft.Extensions.DependencyInjection.PageConventionCollectionExtensions.AuthorizeAreaPage%2A> convention to add an <xref:Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter> to the area page at the specified path:

```csharp
options.Conventions.AuthorizeAreaPage("Identity", "/Manage/Accounts");
```

The page name is the path of the file without an extension relative to the pages root directory for the specified area. For example, the page name for the file `Areas/Identity/Pages/Manage/Accounts.cshtml` is `/Manage/Accounts`.

To specify an [authorization policy](xref:security/authorization/policies), use an [`AuthorizeAreaPage` overload](xref:Microsoft.Extensions.DependencyInjection.PageConventionCollectionExtensions.AuthorizeAreaPage%2A):

```csharp
options.Conventions.AuthorizeAreaPage("Identity", "/Manage/Accounts", "AtLeast21");
```

## Require authorization to access a folder of areas

Use the <xref:Microsoft.Extensions.DependencyInjection.PageConventionCollectionExtensions.AuthorizeAreaFolder%2A> convention to add an <xref:Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter> to all of the areas in a folder at the specified path:

```csharp
options.Conventions.AuthorizeAreaFolder("Identity", "/Manage");
```

The folder path is the path of the folder relative to the pages root directory for the specified area. For example, the folder path for the files under `Areas/Identity/Pages/Manage/` is `/Manage`.

To specify an [authorization policy](xref:security/authorization/policies), use an [`AuthorizeAreaFolder` overload](xref:Microsoft.Extensions.DependencyInjection.PageConventionCollectionExtensions.AuthorizeAreaFolder%2A):

```csharp
options.Conventions.AuthorizeAreaFolder("Identity", "/Manage", "AtLeast21");
```

## Allow anonymous access to a page

Use the <xref:Microsoft.Extensions.DependencyInjection.PageConventionCollectionExtensions.AllowAnonymousToPage%2A> convention to add an <xref:Microsoft.AspNetCore.Mvc.Authorization.AllowAnonymousFilter> to a page at the specified path:

:::moniker range=">= aspnetcore-10.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/RazorPagesAuthorization/10.x/AuthorizationSample/Program.cs" id="snippet1" highlight="5":::

:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-10.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/RazorPagesAuthorization/3.x/AuthorizationSample/Startup.cs" id="snippet1" highlight="5":::

:::moniker-end

:::moniker range="< aspnetcore-3.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/RazorPagesAuthorization/2.x/AuthorizationSample/Startup.cs" id="snippet1" highlight="2,6":::

:::moniker-end

The specified path is the View Engine path, which is the Razor Pages root relative path without an extension and containing only forward slashes.

## Allow anonymous access to a folder of pages

Use the <xref:Microsoft.Extensions.DependencyInjection.PageConventionCollectionExtensions.AllowAnonymousToFolder%2A> convention to add an <xref:Microsoft.AspNetCore.Mvc.Authorization.AllowAnonymousFilter> to all of the pages in a folder at the specified path:

:::moniker range=">= aspnetcore-10.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/RazorPagesAuthorization/10.x/AuthorizationSample/Program.cs" id="snippet1" highlight="6":::

:::moniker-end

:::moniker range=">= aspnetcore-3.0 < aspnetcore-10.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/RazorPagesAuthorization/3.x/AuthorizationSample/Startup.cs" id="snippet1" highlight="6":::

:::moniker-end

:::moniker range="< aspnetcore-3.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/RazorPagesAuthorization/2.x/AuthorizationSample/Startup.cs" id="snippet1" highlight="2,7":::

:::moniker-end

The specified path is the View Engine path, which is the Razor Pages root relative path without an extension and containing only forward slashes.

## Note on combining authorized and anonymous access

The app can specify that a folder of pages requires authorization and that a page within that folder allows anonymous access:

```csharp
// This works.
.AuthorizeFolder("/Private").AllowAnonymousToPage("/Private/Public")
```

The reverse, however, isn't valid. The app can't declare a folder of pages for anonymous access and specify a page within that folder that requires authorization:

```csharp
// This doesn't work!
.AllowAnonymousToFolder("/Public").AuthorizePage("/Public/Private")
```

Requiring authorization on the Private page fails. When both the <xref:Microsoft.AspNetCore.Mvc.Authorization.AllowAnonymousFilter> and <xref:Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter> are applied to the page, the <xref:Microsoft.AspNetCore.Mvc.Authorization.AllowAnonymousFilter> takes precedence and controls access.

## Additional resources

* <xref:razor-pages/razor-pages-conventions>
* <xref:Microsoft.AspNetCore.Mvc.ApplicationModels.PageConventionCollection>
