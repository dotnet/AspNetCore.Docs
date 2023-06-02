---
title: Custom authorization policies with IAuthorizationRequirementData
author: rick-anderson
description: Learn how to add  custom authorization policies with IAuthorizationRequirementData.
ms.author: riande
monikerRange: '>= aspnetcore-8.0'
ms.date: 5/30/2023
uid: security/authorization/iard
---
# Custom authorization policies with IAuthorizationRequirementData

The <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirementData> interface allows the attribute definition to also specify the requirements associated with the authorization policy:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthRequirementsData/Controllers/GreetingsController.cs" highlight="1":::

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthRequirementsData/Program.cs" highlight="1":::

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthRequirementsData/Authorization/MinimumAgeAuthorizationHandler.cs" highlight="1":::

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthRequirementsData/Authorization/MinimumAgeAuthorizeAttribute.cs" highlight="1":::

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthRequirementsData/Authorization/MinimumAgePolicyProvider.cs" highlight="1":::

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthRequirementsData/Authorization/MinimumAgeRequirement.cs" highlight="1":::

## What's new

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

Controller just adds `using AuthRequirementsData.Authorization;`

In the `MinimumAgeAuthorizationHandler.cs` class, `MinimumAgeRequirement` is replaced by `MinimumAgeAuthorizeAttribute`:

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
        // Log as a warning so that it's very clear in sample output which authorization
        // policies(and requirements/handlers) are in use
        _logger.LogWarning("Evaluating authorization requirement for age >= {age}",
                                                                    requirement.Age);


        // Check the user's age
        var dateOfBirthClaim = context.User.FindFirst(c => c.Type ==
                                                                 ClaimTypes.DateOfBirth);
        if (dateOfBirthClaim != null)
        {
            // If the user has a date of birth claim, check their age
            var dateOfBirth = Convert.ToDateTime(dateOfBirthClaim.Value,
                                                           CultureInfo.InvariantCulture);
            var age = DateTime.Now.Year - dateOfBirth.Year;
            if (dateOfBirth > DateTime.Now.AddYears(-age))
            {
                // Adjust age if the user hasn't had a birthday yet this year
                age--;
            }

            // If the user meets the age criterion, mark the authorization requirement
            // succeeded
            if (age >= requirement.Age)
            {
                _logger.LogInformation(
                    "Minimum age authorization requirement {age} satisfied",
                      requirement.Age);
                context.Succeed(requirement);
            }
            else
            {
                _logger.LogInformation("Current user's DateOfBirth claim ({dateOfBirth})" +
                    " does not satisfy the minimum age authorization requirement {age}",
                    dateOfBirthClaim.Value,
                    requirement.Age);
            }
        }
        else
        {
            _logger.LogInformation("No DateOfBirth claim present");
        }

        return Task.CompletedTask;
    }
}
```
