---
title: Articles based on projects created with individual user accounts
author: rick-anderson
description: This document lists articles based on projects created with individual user accounts.
ms.author: riande
manager: wpickett
ms.date: 11/30/2017
ms.topic: article
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/authentication/individual
---
# Articles based on projects created with individual user accounts

ASP.NET Core Identity is included in project templates in Visual Studio with the "Individual User Accounts" option.

The authentication templates are available in .NET Core CLI with `-au Individual`:

```console
dotnet new mvc -au Individual
dotnet new webapi -au Individual
dotnet new razor -au Individual
```

The following articles show how to use the code generated in ASP.NET Core templates that use individual user accounts:

* [Two-factor authentication with SMS](xref:security/authentication/2fa)
* [Account confirmation and password recovery in ASP.NET Core](xref:security/authentication/accconfirm)
* [Create an ASP.NET Core app with user data protected by authorization](xref:security/authorization/secure-data)
