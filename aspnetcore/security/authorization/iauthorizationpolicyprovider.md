---
title: Custom Authorization Policy Providers
author: mjrousos
description: Learn how to use a custom IAuthorizationPolicyProvider in an ASP.NET Core app to dynamically generate authorization policies.
ms.author: wpickett
ms.custom: mvc
ms.date: 05/15/2026
uid: security/authorization/iauthorizationpolicyprovider

# customer intent: As an ASP.NET developer, I want to use a custom IAuthorizationPolicyProvider in my ASP.NET Core app, so I can dynamically generate authorization policies.
---
# Use custom authorization policy providers with IAuthorizationPolicyProvider in ASP.NET Core 

By [Mike Rousos](https://github.com/mjrousos)

In a typical implementation with [policy-based authorization](xref:security/authorization/policies), policies are registered by calling `AuthorizationOptions.AddPolicy` as part of authorization service configuration. Sometimes, it might not be possible (or desirable) to register all authorization policies in this manner. In these scenarios, you can [implement a custom IAuthorizationPolicyProvider](#use-a-custom-iauthorizationpolicyprovider) to control how authorization policies are provided.

Examples of scenarios where a custom <xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider> might be useful include:

* Use an external service to provide policy evaluation.

* Support a large range of policies (for different room numbers or ages, for example), where it doesn't make sense to add each individual authorization policy with an `AuthorizationOptions.AddPolicy` call.

* Create policies at runtime based on information in an external data source (like a database) or determine authorization requirements dynamically through another mechanism.

This article describes how to implement the `IAuthorizationPolicyProvider` interface to use a custom authorization policy provider for your ASP.NET Core app.

## Sample code

[View or download the sample code](https://github.com/dotnet/aspnetcore/tree/v3.1.3/src/Security/samples/CustomPolicyProvider) from the [AspNetCore GitHub repository](https://github.com/dotnet/AspNetCore).

Download the dotnet/AspNetCore repository ZIP file, and unzip the file. The sample code is located in the *src/Security/samples/CustomPolicyProvider* project folder.

## Customize policy retrieval

ASP.NET Core apps use an implementation of the `IAuthorizationPolicyProvider` interface to retrieve authorization policies. By default, the <xref:Microsoft.AspNetCore.Authorization.DefaultAuthorizationPolicyProvider> class is registered and used. `DefaultAuthorizationPolicyProvider` returns policies from the `AuthorizationOptions` provided in a call to the `IServiceCollection.AddAuthorization` method.

Customize this behavior by registering a different `IAuthorizationPolicyProvider` implementation in the app's [dependency injection](xref:fundamentals/dependency-injection) container. 

The `IAuthorizationPolicyProvider` interface contains three APIs:

* The <xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider.GetPolicyAsync%2A> method returns an authorization policy for a given name.
* The <xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider.GetDefaultPolicyAsync%2A> method returns the default authorization policy, which is the policy used for `[Authorize]` attributes without a policy specified.
* The <xref:Microsoft.AspNetCore.Authorization.IAuthorizationPolicyProvider.GetFallbackPolicyAsync%2A> method returns the fallback authorization policy, which is the policy used by the authorization middleware when no policy is specified.

By implementing these APIs, you can customize how authorization policies are provided.

## Parameterized authorize attribute example

One scenario where `IAuthorizationPolicyProvider` is useful is enabling custom `[Authorize]` attributes whose requirements depend on a parameter. For example, in [policy-based authorization](xref:security/authorization/policies) documentation, an age-based ("AtLeast21") policy is used as a sample. If different controller actions in an app are made available to users of *different* ages, it might be useful to have many different age-based policies. Rather than registering all the different age-based policies the app might need in the `AuthorizationOptions`, you can generate the policies dynamically with a custom `IAuthorizationPolicyProvider`. To make using the policies easier, you can annotate actions with custom authorization attribute like `[MinimumAgeAuthorize(20)]`.

## Custom authorization attributes

Authorization policies are identified by their names. A custom implementation of the `MinimumAgeAuthorizeAttribute` needs to map arguments into a string that can be used to retrieve the corresponding authorization policy. To accomplish this task, you can derive from `AuthorizeAttribute` and make the `Age` property wrap the `AuthorizeAttribute.Policy` property.

```csharp
internal class MinimumAgeAuthorizeAttribute : AuthorizeAttribute
{
    const string POLICY_PREFIX = "MinimumAge";

    public MinimumAgeAuthorizeAttribute(int age) => Age = age;

    // Get or set the Age property by manipulating the underlying Policy property
    public int Age
    {
        get
        {
            if (int.TryParse(Policy.Substring(POLICY_PREFIX.Length), out var age))
            {
                return age;
            }
            return default(int);
        }
        set
        {
            Policy = $"{POLICY_PREFIX}{value.ToString()}";
        }
    }
}
```

This attribute type has a `Policy` string based on the hard-coded prefix (`"MinimumAge"`) and an integer passed in via the constructor.

You can apply it to actions in the same way as other `Authorize` attributes except it takes an integer as a parameter.

```csharp
[MinimumAgeAuthorize(10)]
public IActionResult RequiresMinimumAge10()
```

## Custom IAuthorizationPolicyProvider

The custom `MinimumAgeAuthorizeAttribute` implementation makes it easy to request authorization policies for any minimum age desired. The next problem to solve is making sure the authorization policies are available for all different ages. This stage in the development is where an `IAuthorizationPolicyProvider` is useful.

When you implement `MinimumAgeAuthorizeAttribute`, the authorization policy names follow the pattern `"MinimumAge" + Age`, so the custom `IAuthorizationPolicyProvider` should generate authorization policies by completing the following tasks:

* Parse the age from the policy name.
* Use `AuthorizationPolicyBuilder` to create a new `AuthorizationPolicy`.
* This example and later examples assume the user is authenticated by using a cookie. As such, the `AuthorizationPolicyBuilder` should either be constructed with at least one authorization scheme name or always succeed. Otherwise, there's no information on how to provide a challenge to the user and an exception is thrown.
* Add requirements to the policy based on the age with the `AuthorizationPolicyBuilder.AddRequirements` method. In other scenarios, you might instead use the `RequireClaim`, `RequireRole`, or `RequireUserName` methods.

```csharp
internal class MinimumAgePolicyProvider : IAuthorizationPolicyProvider
{
    const string POLICY_PREFIX = "MinimumAge";

    // Policy lookup is by string name. Expect 'parameters' (like age) to be embedded in policy names.
    // The process is abstracted away from developers by the more strongly-typed attributes
    // derived from AuthorizeAttribute (like [MinimumAgeAuthorize()] in this sample).
    public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
    {
        if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase) &&
            int.TryParse(policyName.Substring(POLICY_PREFIX.Length), out var age))
        {
            var policy = new AuthorizationPolicyBuilder(CookieAuthenticationDefaults.AuthenticationScheme);
            policy.AddRequirements(new MinimumAgeRequirement(age));
            return Task.FromResult(policy.Build());
        }

        return Task.FromResult<AuthorizationPolicy>(null);
    }
}
```

## Multiple authorization policy providers

When using custom `IAuthorizationPolicyProvider` implementations, keep in mind that ASP.NET Core only uses one instance of `IAuthorizationPolicyProvider`. If a custom provider can't provide authorization policies for all policy names to be used, it should defer to a backup provider. 

For example, consider an application that needs both custom age policies and more traditional role-based policy retrieval. Such an app could use a custom authorization policy provider that:

* Attempts to parse policy names.
* Calls into a different policy provider (like `DefaultAuthorizationPolicyProvider`) if the policy name doesn't contain an age.

You can update the `IAuthorizationPolicyProvider` implementation described earlier to use the `DefaultAuthorizationPolicyProvider` by creating a backup policy provider in its constructor. The backup is available in case the policy name doesn't match its expected pattern of `"MinimumAge" + Age`.

```csharp
private DefaultAuthorizationPolicyProvider BackupPolicyProvider { get; }

public MinimumAgePolicyProvider(IOptions<AuthorizationOptions> options)
{
    // ASP.NET Core only uses one authorization policy provider.
    // If the custom implementation doesn't handle all policies,
    // it should fall back to an alternate provider.
    BackupPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
}
```

Then, the `GetPolicyAsync` method can be updated to use the `BackupPolicyProvider` instead of returning null:

```csharp
...
return BackupPolicyProvider.GetPolicyAsync(policyName);
```

## Default policy

In addition to providing named authorization policies, a custom `IAuthorizationPolicyProvider` needs to implement `GetDefaultPolicyAsync` to provide an authorization policy for `[Authorize]` attributes without a policy name specified.

In many cases, this authorization attribute only requires an authenticated user, so you can make the necessary policy with a call to the `RequireAuthenticatedUser` method:

```csharp
public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => 
    Task.FromResult(new AuthorizationPolicyBuilder(CookieAuthenticationDefaults.AuthenticationScheme).RequireAuthenticatedUser().Build());
```

As with all aspects of a custom `IAuthorizationPolicyProvider`, you can make customizations, as needed. In some cases, it might be desirable to retrieve the default policy from a fallback `IAuthorizationPolicyProvider`.

## Fallback policy

A custom `IAuthorizationPolicyProvider` can optionally implement the `GetFallbackPolicyAsync` method to provide a policy to use when [combining policies](xref:Microsoft.AspNetCore.Authorization.AuthorizationPolicy.Combine%2A) and when no policies are specified. If the `GetFallbackPolicyAsync` method returns a non-null policy, the returned policy is used by the authorization middleware when no policies are specified for the request.

If no fallback policy is required, the provider can return `null` or defer to the fallback provider:

```csharp
public Task<AuthorizationPolicy> GetFallbackPolicyAsync() => 
    Task.FromResult<AuthorizationPolicy>(null);
```

## Use a custom IAuthorizationPolicyProvider

To use custom policies from an `IAuthorizationPolicyProvider`, you ***must***:

* Register the appropriate `AuthorizationHandler` types with dependency injection (described in [policy-based authorization](xref:security/authorization/policies#security-authorization-policies-based-authorization-handler)), as with all policy-based authorization scenarios.

* Register the custom `IAuthorizationPolicyProvider` type in the application dependency injection service collection in `Startup.ConfigureServices` and replace the default policy provider.

  ```csharp
  services.AddSingleton<IAuthorizationPolicyProvider, MinimumAgePolicyProvider>();
  ```

## Related content

* [Complete custom 'IAuthorizationPolicyProvider' sample (GitHub)](https://github.com/dotnet/aspnetcore/tree/v3.1.3/src/Security/samples/CustomPolicyProvider)
* <xref:security/authorization/policies>
