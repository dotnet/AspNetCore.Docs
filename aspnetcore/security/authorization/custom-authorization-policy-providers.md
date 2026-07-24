---
title: Custom authorization policy providers in ASP.NET Core
ai-usage: ai-assisted
author: mjrousos
description: Learn how to use a custom authorization policy provider (IAuthorizationPolicyProvider) in an ASP.NET Core app to dynamically generate authorization policies.
ms.author: wpickett
ms.date: 07/24/2026
uid: security/authorization/custom-authorization-policy-providers
---
# Custom authorization policy providers in ASP.NET Core

By [Mike Rousos](https://github.com/mjrousos)

This article describes how to implement the <xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider> interface to create a custom authorization policy provider, including how to create and apply a custom authorization attribute for the policy.

For a typical implementation of [policy-based authorization](xref:security/authorization/policies), policies are registered by calling <xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions.AddPolicy%2A?displayProperty=nameWithType> during authorization service configuration. Sometimes, it isn't possible or desirable to register many authorization policies in this manner. For example, an app might require policy-based checks for many building room numbers or many user ages, where it doesn't make sense to create and add a policy for each room number or each age with an <xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions.AddPolicy%2A> call. These scenarios are best implemented by passing a parameter to a custom `[Authorize]` attribute backed by a custom policy provider.

Other scenarios where a custom policy provider is useful include:

* When an external service is used to provide policy evaluation.
* To create policies at runtime based on information from an external data source, such as a database, or to dynamically determine authorization requirements through some other mechanism.

## Sample code

The Blazor Web App sample for this article is the [`BlazorWebAppAuthorization` sample app (`dotnet/AspNetCore.Docs.Samples` GitHub repository)](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/security/authorization/BlazorWebAppAuthorization) ([how to download](xref:index#how-to-download-a-sample)). The sample app uses seeded accounts to demonstrate the example in this article. For more information, see the sample's README file (`README.md`).

> [!CAUTION]
> This sample app uses an in-memory database to store user information, which isn't suitable for production scenarios. The sample app is intended for demonstration purposes only and shouldn't be used as a starting point for production apps.

> [!TIP]
> Use the [`git sparse-checkout` command](https://git-scm.com/docs/git-sparse-checkout) to download only the sample subfolder.

For an MVC sample, see the [`CustomPolicyProvider` sample in the `dotnet/aspnetcore` GitHub repository](https://github.com/dotnet/aspnetcore/tree/v3.1.3/src/Security/samples/CustomPolicyProvider).

## Customize policy retrieval

ASP.NET Core apps use an implementation of the <xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider> interface to retrieve authorization policies. By default, the <xref:Microsoft.AspNetCore.Authorization.DefaultAuthorizationPolicyProvider> class is registered and used. The class returns policies from the <xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions> provided in a call to the <xref:Microsoft.Extensions.DependencyInjection.AuthorizationServiceCollectionExtensions.AddAuthorization%2A> method.

Customize this behavior by registering a different policy provider implementation in the app's [dependency injection](xref:fundamentals/dependency-injection) container. 

Customize how authorization policies are provided by implementing the following APIs:

* The <xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider.GetPolicyAsync%2A> method returns an authorization policy for a given name.
* The <xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider.GetDefaultPolicyAsync%2A> method returns the default authorization policy, which is the policy used for `[Authorize]` attributes without a policy specified.
* The <xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider.GetFallbackPolicyAsync%2A> method returns the fallback authorization policy, which is the policy used by the authorization middleware without a policy specified.

## Custom authorization attribute

Start by implementing a strongly-typed <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute>. A custom implementation of the attribute, `MinimumAgeAuthorizeAttribute` in the following example, must map arguments into a string that are used to retrieve the corresponding authorization policy. To accomplish this goal, derive from <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute> and make the `Age` property wrap the <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Policy%2A?displayProperty=nameWithType> property. The attribute type has a policy string based on the hard-coded prefix ("`MinimumAge`") and an integer passed in via the constructor.

`Policies\Attributes\MinimumAgeAuthorizeAttribute.cs`:

XXXXXXXXXXX REPLACE WITH SAMPLE CROSSLINK XXXXXXXXXXXX

```csharp
using Microsoft.AspNetCore.Authorization;

namespace BlazorWebAppAuthorization.Policies.Attributes;

internal class MinimumAgeAuthorizeAttribute : AuthorizeAttribute
{
    const string POLICY_PREFIX = "MinimumAge";

    public MinimumAgeAuthorizeAttribute(int age) => Age = age;

    public int Age
    {
        get
        {
            if (int.TryParse(Policy.AsSpan(POLICY_PREFIX.Length), out var age))
            {
                return age;
            }

            return default;
        }
        set
        {
            Policy = $"{POLICY_PREFIX}{value}";
        }
    }
}
```

You can apply attribute the same way as other `Authorize` attributes are applied with an integer parameter for the minimum age, as the following Razor component demonstrates.

## Custom authorization policy provider

The [custom `MinimumAgeAuthorizeAttribute` implementation](#custom-authorization-attribute) makes it easy to request authorization policies for any minimum age desired. The next problem to solve is making sure the authorization policies are available for all of the ages. This stage in the development is where a custom policy provider is useful.

When you implement `MinimumAgeAuthorizeAttribute`, the authorization policy names follow the pattern `"MinimumAge" + Age`, so the custom policy provider should generate authorization policies by completing the following tasks:

* Parse the age from the policy name.
* Use `AuthorizationPolicyBuilder` to create a new `AuthorizationPolicy`.
* The `AuthorizationPolicyBuilder` should be constructed with at least one authorization scheme name or always succeed. Otherwise, there's no information on how to provide a challenge to the user and an exception is thrown.
* Add requirements to the policy based on the age with the `AuthorizationPolicyBuilder.AddRequirements` method. In other scenarios, you might instead use the `RequireClaim`, `RequireRole`, or `RequireUserName` methods.

In addition to providing named authorization policies, a custom policy provider should implement <xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider.GetDefaultPolicyAsync%2A> to provide an authorization policy for `[Authorize]` attributes without a policy name specified.

In many cases, this authorization attribute only requires an authenticated user, so you can make the necessary policy with a call to the <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireAuthenticatedUser%2A> method:

```csharp
public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => 
    Task.FromResult(
        new AuthorizationPolicyBuilder(
            CookieAuthenticationDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser().Build());
```

A custom policy provider can optionally implement the <xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider.GetFallbackPolicyAsync%2A> method to provide a policy to use when [combining policies](xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicy.Combine%2A) and when no policies are specified. If the method returns a non-null policy, the returned policy is used by the authorization middleware when no policies are specified for the request.

If no fallback policy is required, the provider can return `null` or defer to the fallback provider:

```csharp
public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() =>
    Task.FromResult<AuthorizationPolicy?>(null);
```

The following code shows the complete implementation from the sample app with a `null`-returning fallback policy. For information on how to include a backup fallback policy, see the [Defer to a backup policy provider](#defer-to-a-backup-policy-provider) section.

`Policies/Providers/MinimumAgePolicyProvider.cs`:

XXXXXXXXXXX REPLACE WITH SAMPLE CROSSLINK XXXXXXXXXXXX

```csharp
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using BlazorWebAppAuthorization.Policies.Requirements;

namespace BlazorWebAppAuthorization.Policies.Providers;

internal class MinimumAgePolicyProvider : IAuthorizationPolicyProvider
{
    const string POLICY_PREFIX = "MinimumAge";

    public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase) &&
            int.TryParse(policyName.AsSpan(POLICY_PREFIX.Length), out var age))
        {
            var policy = new AuthorizationPolicyBuilder(
                CookieAuthenticationDefaults.AuthenticationScheme);
            policy.AddRequirements(new MinimumAgeRequirement(age));

            return Task.FromResult<AuthorizationPolicy?>(policy.Build());
        }

        return Task.FromResult<AuthorizationPolicy?>(null);
    }

    public Task<AuthorizationPolicy> GetDefaultPolicyAsync() =>
        Task.FromResult<AuthorizationPolicy>(
            new AuthorizationPolicyBuilder(
                CookieAuthenticationDefaults.AuthenticationScheme)
            .RequireAuthenticatedUser().Build());

    public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() =>
        Task.FromResult<AuthorizationPolicy?>(null);
}
```

Use `CookieAuthenticationDefaults.AuthenticationScheme` with `using Microsoft.AspNetCore.Authentication.Cookies;` if the authentication scheme is cookie-based. Otherwise, use the appropriate scheme for your app. This sample app uses `IdentityConstants.ApplicationScheme`, which is the default if the authentication scheme is Identity-based.

## Defer to a backup policy provider

When using a custom policy provider, keep in mind that ASP.NET Core only uses one instance of <xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider>. If a custom provider can't provide authorization policies for all policy names to be used, it should defer to a backup provider. 

For example, consider an app that requires both custom age policies and more traditional role-based policy retrieval. Such an app could use a custom authorization policy provider that:

* Attempts to parse policy names.
* Calls into a different policy provider, such as `DefaultAuthorizationPolicyProvider`, if the policy name doesn't contain an age.

You can update the custom policy provider described earlier to use the `DefaultAuthorizationPolicyProvider` by creating a backup policy provider. The backup is available in case the policy name doesn't match its expected pattern of `"MinimumAge" + Age`.

In `Policies/Providers/MinimumAgePolicyProvider.cs`:

```diff
- internal class MinimumAgePolicyProviderWithBackupProvider() 
-     : IAuthorizationPolicyProvider
+ internal class MinimumAgePolicyProviderWithBackupProvider(
+     IOptions<AuthorizationOptions> options) : IAuthorizationPolicyProvider
```

Add the `DefaultAuthorizationPolicyProvider` to the class:

```csharp
private DefaultAuthorizationPolicyProvider BackupPolicyProvider { get; } = 
    new DefaultAuthorizationPolicyProvider(options);
```

Update the `GetPolicyAsync` method to use the `BackupPolicyProvider` instead of returning `null`:

```diff
- return Task.FromResult<AuthorizationPolicy?>(null);
+ return BackupPolicyProvider.GetPolicyAsync(policyName);
```

## Use policies from a custom policy provider

To use custom policies:

* As with all policy-based authorization scenarios, register the appropriate `AuthorizationHandler` types in the app's service container.

  For more information, see the parameterized `MinimumAgeRequirement` and `MinimumAgeHandler` example code in <xref:security/authorization/policies>, which work with the `MinimumAgePolicyProvider` demonstrated in this article.

:::moniker range=">= aspnetcore-6.0"

* Register the custom policy provider type in the service collection to replace the default policy provider.

  In the app's `Program` file:

  ```csharp
  builder.Services.AddSingleton<IAuthorizationPolicyProvider, MinimumAgePolicyProvider>();
  ```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

* Register the custom policy provider type in the service collection to replace the default policy provider.

  In `Startup.ConfigureServices` of the `Startup.cs` file:

  ```csharp
  services.AddSingleton<IAuthorizationPolicyProvider, MinimumAgePolicyProvider>();
  ```

:::moniker-end

Primarily only for demonstration purposes, an `AuthorizeView` component can specify the weakly-typed `MinimumAge21` (`"MinimumAge" + Age`) policy, as the following sample app component demonstrates. Using a weakly-typed policy name isn't the best approach for applying a custom authorization policy. After the following example, a strongly-typed <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute> is demonstrated using the [custom `MinimumAgeAuthorizeAttribute` implementation](#custom-authorization-attribute) described earlier in this article.

`Components/Pages/PassMinimumAge21Policy.razor`:

XXXXXXXXXXX REPLACE WITH SAMPLE CROSSLINK XXXXXXXXXXXX

```razor
@page "/pass-minimumage21-policy"

<h1>Pass 'MinimumAge21' policy with AuthorizeView</h1>

<AuthorizeView Policy="MinimumAge21">
    <Authorized>
        <p>You satisfy the 'MinimumAge21' policy.</p>
    </Authorized>
    <NotAuthorized>
        <p>You <b>don't</b> satisfy the 'MinimumAge21' policy.</p>
    </NotAuthorized>
</AuthorizeView>
```

The following components uses the [custom `MinimumAgeAuthorizeAttribute` implementation](#custom-authorization-attribute) described earlier in this article.

`Components/Pages/PassMinimumAge21PolicyWithAttribute.razor`:

```csharp
@page "/pass-minimumage21-policy-with-attribute"
@using BlazorWebAppAuthorization.Policies.Attributes
@attribute [MinimumAgeAuthorize(21)]

<h1>Pass 'MinimumAge21' policy</h1>

<p>You satisfy the 'MinimumAge21' policy.</p>
```

## Additional resources

* [Complete custom 'IAuthorizationPolicyProvider' sample (`dotnet/aspnetcore` GitHub repository)](https://github.com/dotnet/aspnetcore/tree/v3.1.3/src/Security/samples/CustomPolicyProvider)
* <xref:security/authorization/policies>
* <xref:razor-pages/security/authorization/policies>
* <xref:mvc/security/authorization/policies>
