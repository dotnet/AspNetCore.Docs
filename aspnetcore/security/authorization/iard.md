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

The `MinimumAgeAuthorizationHandler` class:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthRequirementsData/Authorization/MinimumAgeAuthorizationHandler.cs" highlight="7,19":::

The custom `MinimumAgePolicyProvider`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthRequirementsData/Authorization/MinimumAgePolicyProvider.cs" id="snippet_all":::

ASP.NET Core only uses one authorization policy provider. If the custom implementation
doesn't handle all policies, including default policies, etc., it should fall back to an
alternate provider. In the preceding sample, a default authorization policy provider is:

* Constructed with options from the [dependency injection container](xref:fundamentals/dependency-injection).
* Used if this custom provider isn't able to handle a given policy name.

If a custom policy provider is able to handle all expected policy names, setting the fallback policy with <xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider.GetFallbackPolicyAsync> isn't required.

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthRequirementsData/Authorization/MinimumAgePolicyProvider.cs" id="snippet_1":::

Policies are looked up by string name, therefore parameters, for example, `age`, are embedded in the policy names. This is abstracted away from developers by the more strongly-typed attributes derived from <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute>. For example, the `[MinimumAgeAuthorize()]` attribute in this sample looks up policies by string name.

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthRequirementsData/Authorization/MinimumAgePolicyProvider.cs" id="snippet_2":::

The `MinimumAgeAuthorizeAttribute` uses the <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirementData> interface that allows the attribute definition to specify the requirements associated with the authorization policy:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthRequirementsData/Authorization/MinimumAgeAuthorizeAttribute.cs" highlight="6":::

The `GreetingsController` displays the user's name when they satisfy the minimum age policy:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthRequirementsData/Controllers/GreetingsController.cs" highlight="10":::

The complete sample can be found in the [AuthRequirementsData](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/security/authorization/AuthRequirementsData) folder of the [AspNetCore.Docs.Samples](https://github.com/dotnet/AspNetCore.Docs.Samples) repository.

The sample can be tested with [`dotnet user-jwts`](xref:security/authentication/jwt) and curl:

* `dotnet user-jwts create --claim http://schemas.xmlsoap.org/ws/2005/05/identity/claims/dateofbirth=1989-01-01`
* `curl -i -H "Authorization: Bearer <token from dotnet user-jwts>" http://localhost:<port>/api/greetings/hello`

<!-- This will be moved to What's new in 8.0 as soon as this PR merges (to avoid merge conflicts)


## IAuthorizationRequirementData

Prior to this preview, adding a parameterized authorization policy to an endpoint required implementing an:

* `AuthorizeAttribute` for each policy.
* `AuthorizationPolicyProvider` to process a custom policy from a string-based contract.
* `AuthorizationRequirement` for the policy.
* `AuthorizationHandler` for each requirement.

For example, consider the following sample written for ASP.NET Core 7.0:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/OldStyleAuthRequirements/Program.cs" highlight="9":::

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/OldStyleAuthRequirements/Controllers/GreetingsController.cs" :::

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/OldStyleAuthRequirements/Authorization/MinimumAgeAuthorizationHandler.cs" highlight="7,19":::

The complete sample is [here](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/security/authorization/OldStyleAuthRequirements) in the [AspNetCore.Docs.Samples](https://github.com/dotnet/AspNetCore.Docs.Samples) repository.

ASP.NET Core 8 introduces the <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirementData> interface. The `IAuthorizationRequirementData` interface allows the attribute definition to specify the requirements associated with the authorization policy. Using `IAuthorizationRequirementData`, the preceding custom authorization policy code can be written with fewer lines of code. The updated `Program.cs` file:

```diff
  using AuthRequirementsData.Authorization;
  using Microsoft.AspNetCore.Authorization;
  
  var builder = WebApplication.CreateBuilder();
  
  builder.Services.AddAuthentication().AddJwtBearer();
  builder.Services.AddAuthorization();
  builder.Services.AddControllers();
- builder.Services.AddSingleton<IAuthorizationPolicyProvider, MinimumAgePolicyProvider>();
  builder.Services.AddSingleton<IAuthorizationHandler, MinimumAgeAuthorizationHandler>();
  
  var app = builder.Build();
  
  app.MapControllers();
  
  app.Run();
```

The updated `MinimumAgeAuthorizationHandler`:

```diff
using Microsoft.AspNetCore.Authorization;
using System.Globalization;
using System.Security.Claims;

namespace AuthRequirementsData.Authorization;

- class MinimumAgeAuthorizationHandler : AuthorizationHandler<MinimumAgeRequirement>
+ class MinimumAgeAuthorizationHandler : AuthorizationHandler<MinimumAgeAuthorizeAttribute>
{
    private readonly ILogger<MinimumAgeAuthorizationHandler> _logger;

    public MinimumAgeAuthorizationHandler(ILogger<MinimumAgeAuthorizationHandler> logger)
    {
        _logger = logger;
    }

    // Check whether a given MinimumAgeRequirement is satisfied or not for a particular
    // context
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
-                                              MinimumAgeRequirement requirement)
+                                              MinimumAgeAuthorizeAttribute requirement)
    {
        // Remaining code omitted for brevity.
```

The complete updated sample can be found [here](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/security/authorization/AuthRequirementsData).

See <xref:security/authorization/iard> for a detailed examination of the new sample.

-->