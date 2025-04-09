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

:::code language="csharp" source="~/../aspnetcore/src/Security/samples/CustomPolicyProvider/Startup.cs" highlight="23":::

The `MinimumAgeAuthorizationHandler` class:

:::code language="csharp" source="~/../aspnetcore/src/Security/samples/CustomPolicyProvider/Authorization/MinimumAgeAuthorizationHandler.cs" highlight="15,25":::

The custom `MinimumAgePolicyProvider`:

:::code language="csharp" source="~/../aspnetcore/src/Security/samples/CustomPolicyProvider/Authorization/MinimumAgePolicyProvider.cs":::

ASP.NET Core only uses one authorization policy provider. If the custom implementation
doesn't handle all policies, including default policies, etc., it should fall back to an
alternate provider. In the preceding sample, a default authorization policy provider is:

* Constructed with options from the [dependency injection container](xref:fundamentals/dependency-injection).
* Used if this custom provider isn't able to handle a given policy name.

If a custom policy provider is able to handle all expected policy names, setting the fallback policy with <xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider.GetFallbackPolicyAsync> isn't required.

Policies are looked up by string name, therefore parameters, for example, `age`, are embedded in the policy names. This is managed by the `MinimumAgeAuthorizeAttribute`, which allows developers to specify parameters like `age` and embeds them in the policy's name. For example, the `[MinimumAgeAuthorize()]` attribute in this sample looks up policies by string name.

The `MinimumAgeAuthorizeAttribute` derives from <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute> and adds support for specifying a minimum age. It generates a unique policy name by combining a constant prefix with the age. The MinimumAgePolicyProvider uses this name to create an authorization policy with the corresponding age requirement:

:::code language="csharp" source="~/../aspnetcore/src/Security/samples/CustomPolicyProvider/Authorization/MinimumAgeAuthorizeAttribute.cs":::

The `HomeController` enforces the minimum age requirement on each action using the MinimumAgeAuthorize attribute. The `MinimumAgeAuthorizationHandler` checks if the user's age, based on their `DateOfBirth` claim, meets the specified age before granting access.

:::code language="csharp" source="~/../aspnetcore/src/Security/samples/CustomPolicyProvider/Controllers/HomeController.cs" highlight="18":::

The complete sample can be found in the [CustomPolicyProvider](https://github.com/dotnet/aspnetcore/tree/main/src/Security/samples/CustomPolicyProvider) folder of the [aspnetcore](https://github.com/dotnet/aspnetcore) repository.
To test the sample, follow the instructions in the folder [readme.md](https://github.com/dotnet/aspnetcore/tree/main/src/Security/samples/CustomPolicyProvider).
