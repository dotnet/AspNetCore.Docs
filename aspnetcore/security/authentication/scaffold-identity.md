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

By [Rick Anderson](https://twitter.com/RickAndMSFT)

ASP.NET Core 2.1 and later provides [ASP.NET Core Identity](xref:security/authentication/identity) as a [Razor Class Library](xref:mvc/razor-pages/ui-class). Applications that include Identity can apply the scaffolder to selectively add the source code contained on the Identity Razor Class Library (RCL). You might want to generate source code so you can modify the code and change the behavior. For example, you could instruct the scaffolder to generate the code used in registration. Generated code takes precedence over the same code in the Identity RCL.

Applications that do **not** include authentication can apply the scaffolder to add the RCL Identity package. You have the option of selecting Identity code to be generated.

Although the scaffolder generates most of the necessary code, you'll have to update your project to complete the process. This document explains the steps needed to complete an Identity scaffolding update.

We recommend using a source control system that shows changes. Inspect the changes after running the Identity scaffolder.

## Scaffold identity into an empty project

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg.md)]

Add the following calls to the `Startup` class:

[!code-csharp[Main](scaffold-identity/sample/StartupEmpty.cs?name=snippet1&highlight=5,20-23)]

The call to `UseHsts` is recommended but not required. See [HTTP Strict Transport Security Protocol](xref:security/enforcing-ssl#http-strict-transport-security-protocol-hsts) for more information.

[!INCLUDE[](~/includes/scaffold-identity/migrations.md)]

## Scaffold identity into a Razor project without authorization

[!INCLUDE[](~/includes/scaffold-identity/id-scaffold-dlg.md)]

Identity is configured in *Areas/Identity/IdentityHostingStartup.cs*.

[!INCLUDE[](~/includes/scaffold-identity/migrations.md)]

Add the UseAuthentication call to the `Startup` class:

[!code-csharp[Main](scaffold-identity/sample/StartupRPnoAuth.cs?name=snippet1&highlight=29)]

## Scaffold identity into a Razor project with individual authorization

# [Visual Studio](#tab/visual-studio) 


# [.NET Core CLI](#tab/netcore-cli)

TDB

------ 

## Scaffold identity into a MVC project without authorization

# [Visual Studio](#tab/visual-studio) 


# [.NET Core CLI](#tab/netcore-cli)

TDB

------ 

## Scaffold identity into a MVC project with individual authorization

# [Visual Studio](#tab/visual-studio) 


# [.NET Core CLI](#tab/netcore-cli)

TDB

------ 

