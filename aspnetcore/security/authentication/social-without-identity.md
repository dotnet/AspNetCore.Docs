---
title: Facebook, Google, and external provider authentication without ASP.NET Core Identity
author: rick-anderson
description: An explanation of using Google account user authentication without ASP.NET Core Identity.
ms.author: riande
ms.date: 05/11/2019
uid: security/authentication/social-without-identity
---
# Use Facebook, Google, and external provider authentication without ASP.NET Core Identity

[!code-csharp[](social-without-identity/sample/Startup.cs?name=snippet1)]

[!code-csharp[](social-without-identity/sample/Startup.cs?name=snippet2&highlight=17)]

[!code-csharp[](social-without-identity/sample/Pages/Index.cshtml.cs?highlight=10-16)]

[!code-csharp[](social-without-identity/sample/Pages/Index.cshtml.cs?highlight=18-22)]

[!code-csharp[](social-without-identity/sample/Pages/Privacy.cshtml.cs?highlight=6)]
