---
title: Custom authorization policies with IAuthorizationRequirementData
author: rick-anderson
description: Learn how to add  custom authorization policies with IAuthorizationRequirementData.
ms.author: riande
monikerRange: '>= aspnetcore-8.0'
ms.date: 6/4/2023
uid: security/authorization/iard
---
# Custom authorization policies with IAuthorizationRequirementData

Consider the following sample that implements a custom `MinimumAgeAuthorizationHandler`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthRequirementsData/Program.cs" highlight="9":::

The `MinimumAgeAuthorizationHandler` class handles the single IAuthorizationRequirement provided by the MinimumAgeAuthorizeAttribute implementation of IAuthorizationRequirementData, as specified by the generic parameter MinimumAgeAuthorizeAttribute.

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthRequirementsData/Authorization/MinimumAgeAuthorizationHandler.cs" highlight="7,19":::

The `MinimumAgeAuthorizeAttribute` uses the <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirementData> interface that allows the attribute definition to specify the requirements associated with the authorization policy:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthRequirementsData/Authorization/MinimumAgeAuthorizeAttribute.cs" highlight="6,11":::

The `GreetingsController` displays the user's name when they satisfy the minimum age policy:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthRequirementsData/Controllers/GreetingsController.cs" highlight="10":::

The complete sample can be found in the [AuthRequirementsData](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/security/authorization/AuthRequirementsData) folder of the [AspNetCore.Docs.Samples](https://github.com/dotnet/AspNetCore.Docs.Samples) repository.

The sample can be tested with [`dotnet user-jwts`](xref:security/authentication/jwt) and curl:

* `dotnet user-jwts create --claim http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth=1989-01-01`
* `curl -i -H "Authorization: Bearer <token from dotnet user-jwts>" http://localhost:<port>/api/greetings/hello`
