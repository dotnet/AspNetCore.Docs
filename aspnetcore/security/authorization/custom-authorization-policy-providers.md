---
title: Custom authorization policy providers in ASP.NET Core
ai-usage: ai-assisted
author: mjrousos
description: Learn how to use a custom authorization policy provider (IAuthorizationPolicyProvider) in an ASP.NET Core app to dynamically generate authorization policies.
ms.author: wpickett
ms.date: 07/27/2026
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

For an MVC sample, see the [`CustomPolicyProvider` sample in the `dotnet/aspnetcore` GitHub repository](https://github.com/dotnet/aspnetcore/tree/v3.1.3/src/Security/samples/CustomPolicyProvider).

> [!TIP]
> Use the [`git sparse-checkout` command](https://git-scm.com/docs/git-sparse-checkout) to download a single sample subfolder.

## Customize policy retrieval

ASP.NET Core apps use an implementation of the <xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider> interface to retrieve authorization policies. By default, the <xref:Microsoft.AspNetCore.Authorization.DefaultAuthorizationPolicyProvider> class is registered and used by the framework. The class returns policies from the <xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions> provided in a call to the <xref:Microsoft.Extensions.DependencyInjection.AuthorizationServiceCollectionExtensions.AddAuthorization%2A> method.

Customize this behavior by registering a different policy provider implementation in the app's [dependency injection](xref:fundamentals/dependency-injection) container.

First, the developer decides how custom policies are named, usually in a format that's easily processed to meet one or more requirements for each policy.

Next, the developer customizes how authorization policies are provided by implementing the following APIs in the custom policy provider:

* The <xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider.GetPolicyAsync%2A> method returns an authorization policy for a given name.
* The <xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider.GetDefaultPolicyAsync%2A> method returns the default authorization policy. The `DefaultPolicy` applies whenever authorization is required, but no specific policy is set. If an `[Authorize]` attribute is present without a policy name, the `DefaultPolicy` is used instead of the `FallbackPolicy`. This behavior ensures that endpoints explicitly requesting authorization (via `[Authorize]` or `RequireAuthorization()`) default to a secure policy.
* The <xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider.GetFallbackPolicyAsync%2A> method returns the fallback authorization policy when no authorization metadata (for example, no `[Authorize]` attribute or `RequireAuthorization()`) is explicitly provided for a resource. The `FallbackPolicy` only applies when there are no authorization attributes or explicit policies set. If a resource has an `[Authorize]` attribute (even without a policy name), the `DefaultPolicy` is used instead of the `FallbackPolicy`. This means `FallbackPolicy` is mainly relevant for middleware-based authorization flows where no per-endpoint authorization is specified. By default, `FallbackPolicy` is `null`, meaning it has no effect unless explicitly set.

## Custom authorization attribute

The recommended approach for applying policies in concert with a custom policy provider is to use a strongly-typed <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute> with the provider. A custom implementation of the attribute, `MinimumAgeAuthorizeAttribute` in the following example, must map arguments into a string that are used to retrieve a corresponding authorization policy. The following example derives from <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute> and makes the `Age` property wrap the <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Policy%2A?displayProperty=nameWithType> property. The attribute type has a policy string based on the hard-coded prefix ("`MinimumAge`") and an integer passed in via its constructor (`MinimumAge{AGE}`), where the `{AGE}` placeholder is the minimum age. The following attribute is used with the custom policy provider shown later in this article.

`Policies/Attributes/MinimumAgeAuthorizeAttribute.cs`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/BlazorWebAppAuthorization/Policies/Attributes/MinimumAgeAuthorizeAttribute.cs":::

<!-- DOC REVIEWER NOTE: The preceding cross-link inserts the following code.
                        The following code will be removed prior to merging
                        the PR.
-->

```csharp
using Microsoft.AspNetCore.Authorization;

namespace BlazorWebAppAuthorization.Policies.Attributes;

internal class MinimumAgeAuthorizeAttribute : AuthorizeAttribute
{
    private const string PolicyPrefix = "MinimumAge";

    public MinimumAgeAuthorizeAttribute(int age) => Age = age;

    public int Age
    {
        get
        {
            if (!string.IsNullOrEmpty(Policy) &&
                Policy.StartsWith(PolicyPrefix, 
                    StringComparison.OrdinalIgnoreCase) &&
                int.TryParse(Policy.AsSpan(PolicyPrefix.Length), out var age))
            {
                return age;
            }

            return default;
        }
        set
        {
            ArgumentOutOfRangeException.ThrowIfNegative(value);
            Policy = $"{PolicyPrefix}{value}";
        }
    }
}
```

You can apply attribute for any minimum age required for authorization with an integer parameter for the minimum age. Examples appear later in this article.

## Custom authorization policy provider

Create a custom authorization policy provider in a class by implementing <xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider> and specifying the `GetPolicyAsync` method to return an authorization policy for a given name. The general format of a custom provider that either returns a policy for a given matching name or no policy, including for `[Authorize]` attributes without a policy name, is similar to the following, where a single requirement is added to the policy:

```csharp
internal class CustomPolicyProvider() : IAuthorizationPolicyProvider
{
    public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        if ({IDENTIFY POLICY BY NAME})
        {
            var policy = new AuthorizationPolicyBuilder(
                IdentityConstants.ApplicationScheme);
            policy.AddRequirements(...);

            return Task.FromResult<AuthorizationPolicy?>(policy.Build());
        }

        return Task.FromResult<AuthorizationPolicy?>(null);
    }
}
```

Consider a situation where authorization is based on a user's minimum age and the authorization policy names follow the pattern `MinimumAge{AGE}`, where the `{AGE}` placeholder is a string representation of an integer age. The custom policy provider should generate authorization policies by completing the following tasks:

* Parse the age from the policy name.
* Use an authorization policy builder (<xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder>) to create a new <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicy>.
* The authorization policy builder should be constructed with at least one authorization scheme name or always succeed. Otherwise, there's no information on how to provide a challenge to the user and an exception is thrown.
* Add requirements to the policy based on the age with any of the following <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder> methods:
  * <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.AddRequirements%2A>
  * <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireClaim%2A>
  * <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireRole%2A>
  * <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireUserName%2A>
  * <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireAssertion%2A>
  * <xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder.RequireAuthenticatedUser%2A>

ASP.NET Core only uses one instance of <xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider>, which is the custom provider when its registered in the app's service container.

If a custom provider is able to explicitly match and return all of the authorization policies that the app uses, the provider can return `Task.FromResult<AuthorizationPolicy>(null)` from the `GetPolicyAsync` method when no policy name matches. However, most apps that implement a custom provider defer traditional policy retrieval, for example to handle role-based and claim-based policies, to a fallback policy provider. Such an app typically uses a custom provider that:

* Attempts to parse policy names, returning an authorization policy for a matching name with one or more requirements or assertions.
* Uses the framework's <xref:Microsoft.AspNetCore.Authorization.DefaultAuthorizationPolicyProvider> for any non-matching policies.

In addition to handling custom-named authorization policies, a custom provider should implement <xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider.GetDefaultPolicyAsync%2A> to provide an authorization policy for `[Authorize]` attributes that don't specify a policy name:

```csharp
public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => 
    DefaultPolicyProvider.GetDefaultPolicyAsync();
```

`Policies/Providers/MinimumAgePolicyProvider.cs`:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/BlazorWebAppAuthorization/Policies/Providers/MinimumAgePolicyProvider.cs":::

<!-- DOC REVIEWER NOTE: The preceding cross-link inserts the following code.
                        The following code will be removed prior to merging
                        the PR.
-->

```csharp
using BlazorWebAppAuthorization.Policies.Requirements;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace BlazorWebAppAuthorization.Policies.Providers;

public class MinimumAgePolicyProvider(IOptions<AuthorizationOptions> options) 
    : IAuthorizationPolicyProvider
{
    private const string PolicyPrefix = "MinimumAge";

    private DefaultAuthorizationPolicyProvider DefaultPolicyProvider { get; } = 
        new(options);

    public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        if (policyName.StartsWith(
                PolicyPrefix, StringComparison.OrdinalIgnoreCase) &&
            int.TryParse(policyName.AsSpan(PolicyPrefix.Length), out var age) &&
            age >= 0)
        {
            var policy = new AuthorizationPolicyBuilder(
                IdentityConstants.ApplicationScheme);
            policy.AddRequirements(new MinimumAgeRequirement(age));

            return Task.FromResult<AuthorizationPolicy?>(policy.Build());
        }

        return DefaultPolicyProvider.GetPolicyAsync(policyName);
    }

    public Task<AuthorizationPolicy> GetDefaultPolicyAsync() =>
        DefaultPolicyProvider.GetDefaultPolicyAsync();

    public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() =>
        DefaultPolicyProvider.GetFallbackPolicyAsync();
}
```

A custom policy provider can optionally implement the <xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider.GetFallbackPolicyAsync%2A> method to provide a policy to use when [combining policies](xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicy.Combine%2A) or for middleware-based authorization flows where no per-endpoint authorization is specified. In the following example, any the fallback policy combines a standard user policy that requires and authenticated user with a `Status` claim of `Active` with a manager policy that requires the `Manager` role with a `Department` claim of `Sales`:

```csharp
public Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
{
    var standardUserPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .RequireClaim("Status", "Active")
        .Build();

    var managerPolicy = new AuthorizationPolicyBuilder()
        .RequireRole("Manager")
        .RequireClaim("Department", "Sales")
        .Build();

    var combinedPolicy = AuthorizationPolicy.Combine(standardUserPolicy, managerPolicy);

    return Task.FromResult<AuthorizationPolicy?>(combinedPolicy);
}
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

For demonstration purposes, an `AuthorizeView` component can specify the weakly-typed `MinimumAge21` (`"MinimumAge" + Age`) policy, as the following sample app component demonstrates. Using a weakly-typed policy name isn't the best approach for applying a custom authorization policy. After the following example, a strongly-typed <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute> is demonstrated using the [`MinimumAgeAuthorizeAttribute` implementation](#custom-authorization-attribute) described earlier in this article.

`Components/Pages/PassMinimumAge21Policy.razor`:

:::code language="razor" source="~/../AspNetCore.Docs.Samples/security/authorization/BlazorWebAppAuthorization/Components/Pages/PassMinimumAge21Policy.razor":::

<!-- DOC REVIEWER NOTE: The preceding cross-link inserts the following code.
                        The following code will be removed prior to merging
                        the PR.
-->

```razor
@page "/pass-minimumage21-policy"

<h1>Pass 'MinimumAge21' policy (weakly-typed approach)</h1>

<p>
    Uses an AuthorizeView component to apply the policy using the policy's name. 
    This approach is shown for demonstration purposes and isn't recommended for 
    production code.
</p>

<AuthorizeView Policy="MinimumAge21">
    <Authorized>
        <p>You satisfy the 'MinimumAge21' policy.</p>
    </Authorized>
    <NotAuthorized>
        <p>You <b>don't</b> satisfy the 'MinimumAge21' policy.</p>
    </NotAuthorized>
</AuthorizeView>
```

The following component uses the [custom `MinimumAgeAuthorizeAttribute` implementation](#custom-authorization-attribute) described earlier in this article.

`Components/Pages/PassMinimumAge21PolicyWithAttribute.razor`:

:::code language="razor" source="~/../AspNetCore.Docs.Samples/security/authorization/BlazorWebAppAuthorization/Components/Pages/PassMinimumAge21PolicyWithAttribute.razor":::

<!-- DOC REVIEWER NOTE: The preceding cross-link inserts the following code.
                        The following code will be removed prior to merging
                        the PR.
-->

```csharp
@page "/pass-minimumage21-policy-with-attribute"
@using BlazorWebAppAuthorization.Policies.Attributes
@attribute [MinimumAgeAuthorize(21)]

<h1>Pass 'MinimumAge21' policy (strongly-typed approach)</h1>

<p>
    Applies the policy to the Razor component with a custom 
    [MinimumAgeAuthorize] attribute (derived from AuthorizeAttribute). 
    This approach is preferred for production code, as it's strongly-typed 
    and avoids the use of a string to set the policy and minimum age.
</p>

<p>You satisfy the 'MinimumAge21' policy.</p>
```

The same approach is useful for securing [Minimal API endpoints](xref:fundamentals/minimal-apis#authorization):

```csharp
app.MapGet("/must-be-21", [MinimumAgeAuthorize(21)] () => 
    "This endpoint requires a 21-year-old birthdate claim.");
```

## Additional resources

* [Complete custom 'IAuthorizationPolicyProvider' sample (`dotnet/aspnetcore` GitHub repository)](https://github.com/dotnet/aspnetcore/tree/v3.1.3/src/Security/samples/CustomPolicyProvider)
* <xref:security/authorization/policies>
* <xref:razor-pages/security/authorization/policies>
* <xref:mvc/security/authorization/policies>
