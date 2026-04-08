---
title: Claim-based authorization in ASP.NET Core
ai-usage: ai-assisted
author: wadepickett
description: Learn how to add claims checks for authorization in an ASP.NET Core app.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.date: 04/07/2026
uid: security/authorization/claims
---
# Claim-based authorization in ASP.NET Core

When an identity is created for an app user upon signing into an app, the identity provider may assign one or more [claims](xref:System.Security.Claims.Claim#remarks) to the user's identity. A claim is a name value pair that represents what the subject (a user, an app or service, or a device/computer) is, not what the subject can do. A claim can be evaluated by the app to determine access rights to data and other secured resources during the process of authorization and can also be used to make or express authentication decisions about a subject. An identity can contain multiple claims with multiple values and can contain multiple claims of the same type. This article explains how to add claims checks for authorization in an ASP.NET Core app.

This article uses Razor component examples and focuses on Blazor authorization scenarios. For additional Blazor guidance, see the [Additional resources](#additional-resources) section. For Razor Pages and MVC guidance, see the following resources:

* <xref:razor-pages/security/authorization/claims>
* <xref:mvc/security/authorization/claims>

## Sample app

The Blazor Web App sample for this article is the [`BlazorWebAppAuthorization` sample app (`dotnet/AspNetCore.Docs.Samples` GitHub repository)](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/security/authorization/BlazorWebAppAuthorization) ([how to download](xref:index#how-to-download-a-sample)). The sample app uses seeded accounts with preconfigured claims to demonstrate most of the examples in this article. For more information, see the sample's README file (`README.md`).

> [!CAUTION]
> This sample app uses an in-memory database to store user information, which isn't suitable for production scenarios. The sample app is intended for demonstration purposes only and shouldn't be used as a starting point for production apps.

## Add claim checks

Claim-based authorization checks:

* Are declarative and specify claims via policies that the current user must present to access the requested resource.
* Are applied to Razor components (examples in this article), [Razor Pages](xref:razor-pages/security/authorization/claims), or [MVC controllers or actions within a controller](xref:mvc/security/authorization/claims).

The <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> component ([`AuthorizeView` component in Blazor documentation](xref:blazor/security/index#authorizeview-component)) supports *policy-based* authorization, where the policy requires one or more claims. Alternatively, a claims-based authorization via one or more policy checks can be set up using [`[Authorize]` attributes](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) in Razor components. The developer must build and register a policy expressing the claims requirements. This section covers basic concepts. For complete coverage, see <xref:blazor/security/index>.

The simplest type of claim policy looks for the presence of a claim and doesn't check the value.

:::moniker range=">= aspnetcore-8.0"

Registering the policy takes place as part of the Authorization service configuration in the app's `Program` file:

```csharp
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
```

> [!NOTE]
> `WebApplicationBuilder.ConfigureApplication` ([reference source](https://github.com/dotnet/aspnetcore/blob/main/src/DefaultBuilder/src/WebApplicationBuilder.cs)) automatically adds a call for <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A> when <xref:Microsoft.AspNetCore.Authorization.IAuthorizationHandlerProvider> is registered, which has been the behavior for ASP.NET Core since the release of .NET 8. Therefore, calling <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A> explicitly for server-side Blazor apps in .NET 8 or later is technically redundant, but the call isn't harmful. Calling it in developer code after it has already been called by the framework merely no-ops.

[!INCLUDE[](~/includes/aspnetcore-repo-ref-source-links.md)]

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-8.0"

Registering the policy takes place as part of the Authorization service configuration in the app's `Program` file:

```csharp
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("EmployeeOnly", policy => policy.RequireClaim("EmployeeNumber"));
```

In Blazor Server apps, call <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A> after the line that calls <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A> (if present):

```csharp
app.UseAuthentication(); // Only present if not called internally
app.UseAuthorization();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Registering the policy takes place as part of the Authorization service configuration in `Startup.ConfigureServices` (`Startup.cs`):

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("EmployeeOnly", policy =>
        policy.RequireClaim("EmployeeNumber"));
});
```

In Blazor Server apps, call <xref:Microsoft.AspNetCore.Builder.AuthorizationAppBuilderExtensions.UseAuthorization%2A> in `Startup.Configure` after the line that calls <xref:Microsoft.AspNetCore.Builder.AuthAppBuilderExtensions.UseAuthentication%2A> (if present):

```csharp
app.UseAuthentication(); // Only present if not called internally
app.UseAuthorization();
```

:::moniker-end

:::moniker range=">= aspnetcore-5.0"

Blazor WebAssembly apps call <xref:Microsoft.Extensions.DependencyInjection.AuthorizationServiceCollectionExtensions.AddAuthorizationCore%2A> in the `Program` file to add authorization services:

```csharp
builder.Services.AddAuthorizationCore();
```

:::moniker-end

Apply the policy using the `Policy` property on the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) to specify the policy name. In the following example, the `EmployeeOnly` policy checks for the presence of an `EmployeeNumber` claim on the current identity:

For policy-based authorization using an <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> component, use the <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView.Policy?displayProperty=nameWithType> parameter with a single policy name.

`Pages/PassEmployeeOnlyPolicyWithAuthorizeView.razor`:

```razor
@page "/pass-employeeonly-policy-with-authorizeview"

<h1>Pass 'EmployeeOnly' policy with AuthorizeView</h1>

<AuthorizeView Policy="EmployeeOnly">
    <Authorized>
        <p>You satisfy the 'EmployeeOnly' policy.</p>
    </Authorized>
    <NotAuthorized>
        <p>You <b>don't</b> satisfy the 'EmployeeOnly' policy.</p>
    </NotAuthorized>
</AuthorizeView>
```

Alternatively, apply the policy using the `Policy` property on the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) to specify the policy name. In the following example, the `EmployeeOnly` policy checks for the presence of an `EmployeeNumber` claim on the current identity:

`Pages/PassEmployeeOnlyPolicyWithAuthorizeAttribute.razor`:

```razor
@page "/pass-employeeonly-policy-with-authorize-attribute"
@using Microsoft.AspNetCore.Authorization
@attribute [Authorize(Policy = "EmployeeOnly")]

<h1>Pass 'EmployeeOnly' policy with [Authorize] attribute</h1>

<p>You satisfy the 'EmployeeOnly' policy.</p>
```

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

`Pages/PassFounderPolicyWithAuthorizeView.razor`:

```razor
@page "/pass-founder-policy-with-authorizeview"

<h1>Pass 'Founder' policy with AuthorizeView</h1>

<AuthorizeView Policy="Founder">
    <Authorized>
        <p>You satisfy the 'Founder' policy.</p>
    </Authorized>
    <NotAuthorized>
        <p>You <b>don't</b> satisfy the 'Founder' policy.</p>
    </NotAuthorized>
</AuthorizeView>
```

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

Multiple policies are applied via multiple <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> components. The inner component requires the user to pass its policy and every policy of parent <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> components.

The following example:

* Requires a `CustomerServiceMember` policy, which indicates that the user is in the organization's customer service department because they have a `Department` claim with a value of `Customer Service`.
* Also requires a `HumanResourcesMember` policy, which indicates that the user is in the organization's human resources department because they have a `Department` claim with a value of `Human Resources`.

:::moniker range=">= aspnetcore-7.0"

In the app's `Program` file:

```csharp
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("CustomerServiceMember", policy =>
        policy.RequireClaim("Department", "Customer Service"))
    .AddPolicy("HumanResourcesMember", policy =>
        policy.RequireClaim("Department", "Human Resources"));
```

:::moniker-end

:::moniker range=">= aspnetcore-6.0 < aspnetcore-7.0"

In the app's `Program` file:

```csharp
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CustomerServiceMember", policy =>
        policy.RequireClaim("Department", "Customer Service"));
    options.AddPolicy("HumanResourcesMember", policy =>
        policy.RequireClaim("Department", "Human Resources"));
});
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

In `Startup.ConfigureServices` (`Startup.cs`):

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("CustomerServiceMember", policy =>
        policy.RequireClaim("Department", "Customer Service"));
    options.AddPolicy("HumanResourcesMember", policy =>
        policy.RequireClaim("Department", "Human Resources"));
});
```

:::moniker-end

The following example uses <xref:Microsoft.AspNetCore.Components.Authorization.AuthorizeView> components.

`Pages/PassCustomerServiceMemberAndHumanResourcesMemberPoliciesWithAuthorizeViews.razor`:

```razor
@page "/pass-customerservicemember-and-humanresourcesmember-policies-with-authorizeviews"

<h1>Pass 'CustomerServiceMember' and 'HumanResourcesMember' policies with AuthorizeViews</h1>

<AuthorizeView Policy="CustomerServiceMember">
    <Authorized>
        <p>User: @context.User.Identity?.Name</p>
        <AuthorizeView Policy="HumanResourcesMember" Context="innerContext">
            <Authorized>
                <p>
                    You satisfy the 'CustomerServiceMember' and 'HumanResourcesMember' policies.
                </p>
            </Authorized>
            <NotAuthorized>
                <p>
                    You satisfy the 'CustomerServiceMember' policy, but you <b>don't</b> satisfy 
                    the 'HumanResourcesMember' policy.
                </p>
            </NotAuthorized>
        </AuthorizeView>
    </Authorized>
    <NotAuthorized>
        <p>
            You <b>don't</b> satisfy the 'CustomerServiceMember' policy.
        </p>
    </NotAuthorized>
</AuthorizeView>
```

The following example uses [`[Authorize]` attributes](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute).

`Pages/PassCustomerServiceMemberAndHumanResourcesMemberPoliciesWithAuthorizeAttributes.razor`:

```razor
@page "/pass-customerservicemember-and-humanresourcesmember-policies-with-authorize-attributes"
@using Microsoft.AspNetCore.Authorization
@attribute [Authorize(Policy = "CustomerServiceMember")]
@attribute [Authorize(Policy = "HumanResourcesMember")]

<h1>
    Pass 'CustomerServiceMember' and 'HumanResourcesMember' policies with [Authorize] attributes
</h1>

<p>
    You satisfy the 'CustomerServiceMember' and 'HumanResourcesMember' policies.
</p>
```

For more complicated policies, such as taking a date of birth claim, calculating an age from it, then checking that the age is 21 or older, use <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireAssertion%2A> or write [custom policy handlers](xref:security/authorization/policies). Custom policy handlers are useful when you need access to dependency-injected services or want a reusable, testable authorization component.

## Claim case sensitivity

Claim *values* are compared using [`StringComparison.Ordinal`](xref:System.StringComparison?displayProperty=nameWithType). This means `Admin` (uppercase `A`) and `admin` (lowercase `a`) are always treated as different roles, regardless of which authentication handler created the identity.

Separately, the claim *type* comparison (used to locate role claims by their claim type, such as `http://schemas.microsoft.com/ws/2008/06/identity/claims/role`) may be case-sensitive or case-insensitive depending on the <xref:System.Security.Claims.ClaimsIdentity> implementation. With `Microsoft.IdentityModel` in ASP.NET Core 8.0 or later (used by <xref:Microsoft.Extensions.DependencyInjection.JwtBearerExtensions.AddJwtBearer%2A>, <xref:Microsoft.Extensions.DependencyInjection.OpenIdConnectExtensions.AddOpenIdConnect%2A>, <xref:Microsoft.Extensions.DependencyInjection.WsFederationExtensions.AddWsFederation%2A>, and <xref:Microsoft.Identity.Web.AppBuilderExtension.AddMicrosoftIdentityWebApp%2A>/<xref:Microsoft.Identity.Web.AppBuilderExtension.AddMicrosoftIdentityWebApi%2A>), <xref:Microsoft.IdentityModel.Tokens.CaseSensitiveClaimsIdentity> is produced during token validation, which uses case-sensitive claim type matching.

The default <xref:System.Security.Claims.ClaimsIdentity> provided by the .NET runtime (used in most cases, including all cookie-based flows) still uses case-insensitive claim type matching.

In practice, this distinction rarely matters for role authorization because the role claim type is set once during identity creation and matched consistently. Always use consistent casing for role names and claim types to avoid subtle issues.

## Additional resources

* <xref:blazor/security/index>
* <xref:blazor/security/authentication-state>
* <xref:blazor/security/webassembly/additional-scenarios>
* <xref:blazor/security/webassembly/graph-api#customize-user-claims-using-the-graph-sdk>
* <xref:blazor/security/webassembly/index#establish-claims-for-users>
* <xref:razor-pages/security/authorization/claims>
* <xref:mvc/security/authorization/claims>
* [Extend or add custom claims, including role claims, using `IClaimsTransformation`](xref:security/authentication/claims#extend-or-add-custom-claims-using-iclaimstransformation)
