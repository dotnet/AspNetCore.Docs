---
title: Scaffold Identity in ASP.NET Core projects
author: rick-anderson
description: Learn how to scaffold Identity in an ASP.NET Core project.
manager: wpickett
monikerRange: '>= aspnetcore-2.1'
ms.author: riande
ms.date: 5/15/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: security/authentication/scaffold-identity
---
# Scaffold Identity in ASP.NET Core projects

<!--
https://docs.microsoft.com/en-us/dotnet/api/
-->

By [Rick Anderson](https://twitter.com/RickAndMSFT)

ASP.NET Core 2.1 and later provides [ASP.NET Core Identity](xref:security/authentication/identity) as a [Razor Class Library](xref:mvc/razor-pages/ui-class). Applications that include Identity can apply the scaffolder to selectively add the source code contained on the Identity Razor Class Library (RCL). You might want to generate source code so you can modify the code and change the behavior. For example, you could instruct the scaffolder to generate the code used in registration. Generated code takes precedence over the same code in the Identity RCL.

Applications that do **not** include authentication can apply the scaffolder to add the RCL Identity package. You have the option of selecting Identity code to be generated.

Although the scaffolder generates most of the necessary code, you'll have to update your project to complete the process. This document explains the steps needed to complete an Identity scaffolding update.

We recommend using a source control system that shows changes and allows you to back out of changes. Inspect the changes after running the Identity scaffolder.

## Scaffold identity into an empty project

Verify the *Pages/Shared/_Layout.cshtml* file is backed up or can be restored from source control.

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg.md)]

Add the following calls to the `Startup` class:

[!code-csharp[Main](scaffold-identity/sample/StartupEmpty.cs?name=snippet1&highlight=5,20-23)]

[!INCLUDE[](~/includes/scaffold-identity/hsts.md)]

[!INCLUDE[](~/includes/scaffold-identity/migrations.md)]

## Scaffold identity into a Razor project without authorization

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg.md)]

Identity is configured in *Areas/Identity/IdentityHostingStartup.cs*. See [IHostingStartup](xref:host-and-deploy/platform-specific-configuration) for more information.

[!INCLUDE[](~/includes/scaffold-identity/migrations.md)]

In the `Configure` method of the `Startup` class, call [UseAuthentication](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.authappbuilderextensions.useauthentication?view=aspnetcore-2.0#Microsoft_AspNetCore_Builder_AuthAppBuilderExtensions_UseAuthentication_Microsoft_AspNetCore_Builder_IApplicationBuilder_) after `UseStaticFiles`:

[!code-csharp[Main](scaffold-identity/sample/StartupRPnoAuth.cs?name=snippet1&highlight=29)]

[!INCLUDE[](~/includes/scaffold-identity/hsts.md)]

### Layout changes

* Delete the generated *Pages/Shared/_Layout.cshtml* file and restore with the previous version. 
* Optional: Add the login partial (`_LoginPartial`) to the layout file:

[!code-html[Main](scaffold-identity/sample/_Layout.cshtml?highlight=37)]

## Scaffold identity into a Razor project with individual authorization

Verify the *Pages/Shared/_Layout.cshtml* file is backed up or can be restored from source control.

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg-auth.md)]

Delete the scaffolder generated  *Pages/Shared/_Layout.cshtml* file and restore the previous version.

Some Identity options are configured in *Areas/Identity/IdentityHostingStartup.cs*. See [IHostingStartup](xref:host-and-deploy/platform-specific-configuration) for more information.

## Scaffold identity into an MVC project without authorization

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg.md)]

Delete the *Pages/Shared/_Layout.cshtml* file.

Optional: Add the login partial (`_LoginPartial`) to the *Views/Shared/_Layout.cshtml* file:

* Move the *Pages/Shared/_LoginPartial.cshtml* file to *Views/Shared/_LoginPartial.cshtml*
* Add the _LoginPartial to the *Views/Shared/_Layout.cshtml* file:

[!code-html[Main](scaffold-identity/sample/_LayoutMvc.cshtml?highlight=37)]

Update the */Areas/Identity/Pages/_ViewStart.cshtml* to use the *Views* folder rather than the *Pages* folder:

```html
@{
    Layout = "/Views/Shared/_Layout.cshtml";
}
```

Identity is configured in *Areas/Identity/IdentityHostingStartup.cs*. See [IHostingStartup](xref:host-and-deploy/platform-specific-configuration) for more information.

[!INCLUDE[](~/includes/scaffold-identity/migrations.md)]

Call [UseAuthentication](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.builder.authappbuilderextensions.useauthentication?view=aspnetcore-2.0#Microsoft_AspNetCore_Builder_AuthAppBuilderExtensions_UseAuthentication_Microsoft_AspNetCore_Builder_IApplicationBuilder_) after `UseStaticFiles`:

[!code-csharp[Main](scaffold-identity/sample/StartupMvcNoAuth.cs?name=snippet1&highlight=23)]

[!INCLUDE[](~/includes/scaffold-identity/hsts.md)]

## Scaffold identity into an MVC project with individual authorization

Verify the *Areas/Identity/Pages/_ViewStart.cshtml* file is backed up or can be restored from source control.

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg-auth.md)]

Delete the *Pages/Shared* folder and the files in that folder.

Replace the *Areas/Identity/Pages/_ViewStart.cshtml* file with the pervious version (before scaffolding).