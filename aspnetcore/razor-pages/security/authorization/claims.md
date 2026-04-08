---
title: Claim-based authorization in ASP.NET Core Razor Pages
ai-usage: ai-assisted
author: wadepickett
description: Learn how to add claims checks for authorization in an ASP.NET Core Razor Pages app.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.date: 04/07/2026
uid: razor-pages/security/authorization/claims
---
# Claim-based authorization in ASP.NET Core Razor Pages

When an identity is created for an app user upon signing into an app, the identity provider may assign one or more [claims](xref:System.Security.Claims.Claim#remarks) to the user's identity. A claim is a name value pair that represents what the subject (a user, an app or service, or a device/computer) is, not what the subject can do. A claim can be evaluated by the app to determine access rights to data and other secured resources during the process of authorization and can also be used to make or express authentication decisions about a subject. An identity can contain multiple claims with multiple values and can contain multiple claims of the same type. This article explains how to add claims checks for authorization in an ASP.NET Core app.

This article uses Razor Pages examples and focuses on Razor Pages authorization scenarios. For Blazor and MVC guidance, see the following resources:

* <xref:security/authorization/claims>
* <xref:mvc/security/authorization/claims>

Examples throughout this article apply claim-based authorization via one or more [`[Authorize]` attributes](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) on `PageModel` classes. Alternatively, claim-based authorization can be applied using *conventions*. For more information, see <xref:razor-pages/razor-pages-conventions#page-model-action-conventions>.

## Sample app

The sample app for this article is the [`WebAll` sample app (`dotnet/AspNetCore.Docs.Samples` GitHub repository)](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/security/authorization/claims) ([how to download](xref:index#how-to-download-a-sample)). For more information, see the sample's README file (`README.md`).

## Add claim checks

Claim-based authorization checks:

* Are declarative.
* Are applied to Razor Pages, MVC controllers, or actions within a controller.
* Can't be applied at the Razor Page handler level. They must be applied to the page model class.

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

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/claims/7.x/WebAll/Pages/Index.cshtml.cs" id="snippet" highlight="1":::

Filter attributes, including the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute), can only be applied to the entire `PageModel` class and can't be applied to specific page handler methods. If you need to implement different authorization rules for different page handlers, adopt either of the following approaches.

* Use separate Razor Pages for operations requiring different authorization levels, using [partial views](xref:mvc/views/partial) for shared content.

* Inject <xref:Microsoft.AspNetCore.Authorization.IAuthorizationService> and manually check the authorization policy by calling <xref:Microsoft.AspNetCore.Authorization.IAuthorizationService.AuthorizeAsync%2A?displayProperty=nameWithType> within handler methods. If authorization fails, the handler returns a `Forbid` result (<xref:Microsoft.AspNetCore.Mvc.ForbidResult>).

  The following example demonstrates the approach:

  * The page's `OnGet` handler requires a Sid claim via the `RequireSidClaim` policy.
  * The page's `OnPostAsync` handler requires an email claim via the `RequireEmailClaim` policy.

  > [!NOTE]
  > Constructor injection of <xref:Microsoft.AspNetCore.Authorization.IAuthorizationService> in the following example is supported with [primary constructors](/dotnet/csharp/whats-new/tutorials/primary-constructors) in C# 12 (.NET 8) or later.

  ```csharp
  public class AuthPageHandlersExampleModel(
      IAuthorizationService authorizationService) : PageModel
  {
      public async Task<IActionResult> OnGet()
      {
          var authResult = 
              await authorizationService.AuthorizeAsync(User, "RequireSidClaim");

          if (!authResult.Succeeded)
          {
              return Forbid();
          }

          // Authorized logic

          return Page();
      }

      public async Task<IActionResult> OnPostAsync()
      {
          var authResult = 
              await authorizationService.AuthorizeAsync(User, "RequireEmailClaim");

          if (!authResult.Succeeded)
          {
              return Forbid();
          }

          // Authorized logic

          return Page();
      }
  }
  ```

  Alternatively, page handler methods can check claims directly by calling <xref:System.Security.Claims.ClaimsIdentity.HasClaim%2A>:

  ```csharp
  public IActionResult OnGet()
  {
      if (!User.HasClaim(c => c.Type == ClaimTypes.Sid))
      {
          return Forbid();
      }

      // Authorized logic

      return Page();
  }

  public IActionResult OnPostAsync()
  {
      if (!User.HasClaim(c => c.Type == ClaimTypes.Email))
      {
          return Forbid();
      }

      // Authorized logic

      return Page();
  }
  ```

  > [!NOTE]
  > <xref:System.Security.Claims.ClaimTypes> is in the <xref:System.Security.Claims?displayProperty=fullName> namespace.

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
    options.AddPolicy("Founders", policy =>
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

If multiple policies are applied at the controller and action levels, ***all*** policies must pass before access is granted. In the following sample, both page handler methods must fulfill *both* the `EmployeeOnly` policy and the `HumanResources` policy:

<!-- DOC AUTHOR NOTE: The following code snippet from the 7.x sample app covers all ASP.NET Core releases. -->

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/claims/7.x/WebAll/Pages/X/Salary.cshtml.cs" id="snippet" highlight="1,2":::

If you want more complicated policies, such as taking a date of birth claim, calculating an age from it then checking the age is 21 or older then you need to write [custom policy handlers](xref:security/authorization/policies).

## Claim case sensitivity

Claim *values* are compared using [`StringComparison.Ordinal`](xref:System.StringComparison?displayProperty=nameWithType). This means values such as `Admin` (uppercase `A`) and `admin` (lowercase `a`) are always treated as different claim values, regardless of which authentication handler created the identity.

Separately, claim *type* comparison (used to locate claims by type, such as `EmployeeNumber`, `department`, or `http://schemas.microsoft.com/ws/2008/06/identity/claims/role`) may be case-sensitive or case-insensitive depending on the <xref:System.Security.Claims.ClaimsIdentity> implementation. With `Microsoft.IdentityModel` in ASP.NET Core 8.0 or later (used by <xref:Microsoft.Extensions.DependencyInjection.JwtBearerExtensions.AddJwtBearer%2A>, <xref:Microsoft.Extensions.DependencyInjection.OpenIdConnectExtensions.AddOpenIdConnect%2A>, <xref:Microsoft.Extensions.DependencyInjection.WsFederationExtensions.AddWsFederation%2A>, and <xref:Microsoft.Identity.Web.AppBuilderExtension.AddMicrosoftIdentityWebApp%2A>/<xref:Microsoft.Identity.Web.AppBuilderExtension.AddMicrosoftIdentityWebApi%2A>), <xref:Microsoft.IdentityModel.Tokens.CaseSensitiveClaimsIdentity> is produced during token validation, which uses case-sensitive claim type matching.

The default <xref:System.Security.Claims.ClaimsIdentity> provided by the .NET runtime (used in most cases, including all cookie-based flows) still uses case-insensitive claim type matching.

In practice, this distinction rarely matters when the same claim types are issued and checked consistently. Role authorization follows the same rules because roles are represented as claims. Always use consistent casing for claim values and claim types to avoid subtle issues.
