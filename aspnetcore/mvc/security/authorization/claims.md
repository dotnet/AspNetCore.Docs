---
title: Claim-based authorization in ASP.NET Core MVC
ai-usage: ai-assisted
author: wadepickett
description: Learn how to add claims checks for authorization in an ASP.NET Core MVC app.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.date: 04/07/2026
uid: mvc/security/authorization/claims
---
# Claim-based authorization in ASP.NET Core MVC

When an identity is created for an app user upon signing into an app, the identity provider may assign one or more [claims](xref:System.Security.Claims.Claim#remarks) to the user's identity. A claim is a name value pair that represents what the subject (a user, an app or service, or a device/computer) is, not what the subject can do. A claim can be evaluated by the app to determine access rights to data and other secured resources during the process of authorization and can also be used to make or express authentication decisions about a subject. An identity can contain multiple claims with multiple values and can contain multiple claims of the same type. This article explains how to add claims checks for authorization in an ASP.NET Core app.

This article uses MVC examples and focuses on MVC scenarios. For Blazor and Razor Pages guidance, see the following resources:

* <xref:security/authorization/claims>
* <xref:razor-pages/security/authorization/claims>

## Sample app

The sample app for this article is the [`WebAll` sample app (`dotnet/AspNetCore.Docs.Samples` GitHub repository)](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/security/authorization/claims) ([how to download](xref:index#how-to-download-a-sample)). For more information, see the sample's README file (`README.md`).

## Add claim checks

Claim-based authorization checks are declarative and applied to controllers or actions within a controller.

Claims in code specify claims which the current user must possess, and optionally the value the claim must hold to access the requested resource. Claims requirements are policy based. The developer must build and register a policy expressing the claims requirements.

The simplest type of claim policy looks for the presence of a claim and doesn't check the value.

:::moniker range=">= aspnetcore-7.0"

Build and register the policy and call <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A> (place the call after the line that calls <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A>). Registering the policy takes place as part of the Authorization service configuration, typically in the `Program` file:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/claims/7.x/WebAll/Program.cs" id="snippet" highlight="6-7,21":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

Build and register the policy and call <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A> (place the call after the line that calls <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A>). Registering the policy takes place as part of the Authorization service configuration, typically in the `Program` file:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/claims/6.x/WebAll/Program.cs" id="snippet" highlight="6-9,23":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Build and register the policy in `Startup.ConfigureServices` (`Startup.cs`) in the Authorization service's configuration:

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("EmployeeOnly", 
        policy => policy.RequireClaim("EmployeeNumber"));
});
```

Call <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A> in `Startup.Configure` (`Startup.cs`) immediately after <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A> is called:

```csharp
app.UseAuthorization();
```

:::moniker-end

Apply the policy using the `Policy` property on the [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) attribute to specify the policy name. In the following example, the `EmployeeOnly` policy checks for the presence of an `EmployeeNumber` claim on the current identity:

<!-- DOC AUTHOR NOTE: The following code snippet from the 7.x sample app covers all ASP.NET Core releases. -->

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/claims/7.x/WebAll/Controllers/Home2Controller.cs" id="snippet" highlight="1":::

The `[Authorize]` attribute can be applied to an entire controller, in which case only identities matching the policy are allowed access to any action on the controller:

<!-- DOC AUTHOR NOTE: The following code snippet from the 7.x sample app covers all ASP.NET Core releases. -->

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/claims/7.x/WebAll/Controllers/VacationController.cs" id="snippet" highlight="1":::

If you have a controller that's protected by the `[Authorize]` attribute but want to allow anonymous access to a particular action, apply the [`[AllowAnonymous]` attribute](xref:Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute):

<!-- DOC AUTHOR NOTE: The following code snippet from the 7.x sample app covers all ASP.NET Core releases. -->

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/claims/7.x/WebAll/Controllers/VacationController.cs" id="snippet" highlight="14":::

You can specify a list of allowed values when creating a policy. The following policy only passes for employees whose employee number is 1, 2, 3, 4, or 5:

:::moniker range=">= aspnetcore-7.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/claims/7.x/WebAll/Program.cs" id="snippet2" highlight="6-8":::

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/claims/6.x/WebAll/Program.cs" id="snippet2" highlight="6-10":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("Founder", policy =>
        policy.RequireClaim("EmployeeNumber", "1", "2", "3", "4", "5"));
});
```

:::moniker-end

### Add a generic claim check

If the claim value isn't a single value or you need more flexible claim evaluation logic, such as pattern matching, checking the claim issuer, or parsing complex claim values, use <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireAssertion%2A> with <xref:System.Security.Claims.ClaimsPrincipal.HasClaim%2A>. For example, the following policy requires that the user's `email` claim ends with a specific domain:

:::moniker range=">= aspnetcore-7.0"

```csharp
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("ContosoOnly", policy =>
        policy.RequireAssertion(context =>
            context.User.HasClaim(c =>
                c.Type == "email" &&
                c.Value.EndsWith("@contoso.com", StringComparison.OrdinalIgnoreCase))));
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

```csharp
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ContosoOnly", policy =>
        policy.RequireAssertion(context =>
            context.User.HasClaim(c =>
                c.Type == "email" &&
                c.Value.EndsWith("@contoso.com", StringComparison.OrdinalIgnoreCase))));
});
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("ContosoOnly", policy =>
        policy.RequireAssertion(context =>
            context.User.HasClaim(c =>
                c.Type == "email" &&
                c.Value.EndsWith("@contoso.com", StringComparison.OrdinalIgnoreCase))));
});
```

:::moniker-end

For more information, see <xref:security/authorization/policies#use-a-func-to-fulfill-a-policy>.

## Evaluate multiple policies

If multiple policies are applied at the controller and action levels, ***all*** policies must pass before access is granted:

<!-- DOC AUTHOR NOTE: The following code snippet from the 7.x sample app covers all ASP.NET Core releases. -->

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/claims/7.x/WebAll/Controllers/SalaryController.cs" id="snippet" highlight="1,14":::

In the preceding example, any identity that fulfills the `EmployeeOnly` policy can access the `Payslip` action, as that policy is enforced on the controller. However, in order to call the `UpdateSalary` action, the identity must fulfill *both* the `EmployeeOnly` policy and the `HumanResources` policy.

If you want more complicated policies, such as taking a date of birth claim, calculating an age from it then checking the age is 21 or older then you need to write [custom policy handlers](xref:security/authorization/policies).

## Claim case sensitivity

Claim *values* are compared using [`StringComparison.Ordinal`](xref:System.StringComparison?displayProperty=nameWithType). This means `Admin` (uppercase `A`) and `admin` (lowercase `a`) are always treated as different claim values, regardless of which authentication handler created the identity.

Separately, the claim *type* comparison (used to locate claims by their type, such as `email`) may be case-sensitive or case-insensitive depending on the <xref:System.Security.Claims.ClaimsIdentity> implementation. With `Microsoft.IdentityModel` in ASP.NET Core 8.0 or later (used by <xref:Microsoft.Extensions.DependencyInjection.JwtBearerExtensions.AddJwtBearer%2A>, <xref:Microsoft.Extensions.DependencyInjection.OpenIdConnectExtensions.AddOpenIdConnect%2A>, <xref:Microsoft.Extensions.DependencyInjection.WsFederationExtensions.AddWsFederation%2A>, and <xref:Microsoft.Identity.Web.AppBuilderExtension.AddMicrosoftIdentityWebApp%2A>/<xref:Microsoft.Identity.Web.AppBuilderExtension.AddMicrosoftIdentityWebApi%2A>), <xref:Microsoft.IdentityModel.Tokens.CaseSensitiveClaimsIdentity> is produced during token validation, which uses case-sensitive claim type matching.

The default <xref:System.Security.Claims.ClaimsIdentity> provided by the .NET runtime (used in most cases, including all cookie-based flows) still uses case-insensitive claim type matching.

In practice, this distinction rarely matters when the claim type is configured once during identity creation and matched consistently. This also applies to roles when they're represented as claims. Always use consistent casing for claim values and claim types to avoid subtle issues.
