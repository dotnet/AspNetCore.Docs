---
title: Custom Authorization Policy Providers in ASP.NET Core
author: mjrousos
description: Learn how to use a custom IAuthorizationPolicyProvider in an ASP.NET Core app to dynamically generate authorization policies.
manager: wpickett
ms.author: riande
ms.custom: mvc
ms.date: 05/02/2018
ms.prod: asp.net-core
ms.technology: aspnet
ms.topic: article
uid: security/authorization/iauthorizationpolicyprovider
---
# IAuthorizationPolicyProvider

By [Mike Rousos](https://github.com/mjrousos)

Typically when using [policy-based authorization](xref:security/authorization/policies), policies are registered by calling `AuthorizationOptions.AddPolicy` as part of authorization service configuration. In some scenarios, it may not be possible (or desirable) to register all authorization policies in this way. In those cases, you can use a custom `IAuthorizationPolicyProvider` to fully control how authorization policies are supplied.

Examples of scenarios where a custom `IAuthorizationPolicyProvider` may be useful include:

* Creating policies at runtime based on information in an external data source (like a database) or determining authorization requirements dynamically through some other mechanism.
* Using a large range of policies (for different room numbers or ages, for example), so it doesn’t make sense to add each individual authorization policy with an `AuthorizationOptions.AddPolicy` call.

## Customizing Policy Retrieval

ASP.NET Core apps use an implementation of the `IAuthorizationPolicyProvider` interface to retrieve authorization policies. By default, `DefaultAuthorizationPolicyProvider` is registered and used. `DefaultAuthorizationPolicyProvider` returns policies from the `AuthorizationOptions` provided in an `IServiceCollection.AddAuthorization` call.

You can customize this behavior by registering a different `IAuthorizationPolicyProvider` implementation in the app’s dependency injection container. 

The `IAuthorizationPolicyProvider` interface contains two APIs. `GetPolicyAsync(string policyName)` returns an authorization policy for a given name and `GetDefaultPolicyAsync` returns the default authorization policy (the policy used for `[Authorize]` attributes without a policy specified). By implementing these two APIs, it’s possible to customize how authorization policies are provided.

## Parameterized Authorize Attribute Example

One scenario where `IAuthorizationPolicyProvider` is useful is enabling custom `[Authorize]` attributes whose requirements depend on a parameter. For example, in [policy-based authorization](xref:security/authorization/policies) documentation, an age-based (“AtLeast21”) policy was used as a sample. If different controller actions in an application should be made available to users of *different* ages, though, it might be useful to have many different age-based policies. Instead of registering all the different age-based policies that the application will need individually, you can generate the policies dynamically with a custom `IAuthorizationPolicyProvider` and annotate actions with an authorization attribute like `[MinimumAgeAuthorize(20)]`.

## Custom Authorization Attributes

Authorization policies are always identified by their names, so the custom `MinimumAgeAuthorizeAttribute` described previously needs to map incoming parameters into a string that can be used to retrieve the corresponding authorization policy. You can do this by deriving from `AuthorizeAttribute` and making the `Age` property wrap 
`AuthorizeAttribute`'s `Policy` property.

```CSharp
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

You can apply it to actions in the same way as other `Authorize` attributes except that it takes an integer as a parameter.

```CSharp
[MinimumAgeAuthorize(10)]
public IActionResult RequiresMinimumAge10()
```

## Custom IAuthorizationPolicyProvider

The custom `MinimumAgeAuthorizeAttribute` makes it easy to request authorization policies for any minimum age desired. The next problem to solve is making sure that authorization policies are available for all of those different ages. This is where an `IAuthorizationPolicyProvider` is useful.

When using `MinimumAgeAuthorizationAttribute`, the authorizaton policy names will follow the pattern `"MinimumAge" + Age`, so the custom `IAuthorizationPolicyProvider` should generate authorization policies by parsing apart the policy name. The policy provider should create `AuthorizationPolicy` objects (using `AuthorizationPolicyBuilder`) and populate them with appropriate authorization requirements (using `AddRequirements` or, perhaps, `RequireClaim`, `RequireRole`, or `RequireUserName`).

```CSharp
internal class MinimumAgePolicyProvider : IAuthorizationPolicyProvider
{
    const string POLICY_PREFIX = "MinimumAge";

    // Policies are looked up by string name, so expect 'parameters' (like age)
    // to be embedded in the policy names. This is abstracted away from developers
    // by the more strongly-typed attributes derived from AuthorizeAttribute
    // (like [MinimumAgeAuthorize()] in this sample)
    public Task<AuthorizationPolicy> GetPolicyAsync(string policyName)
    {
        if (policyName.StartsWith(POLICY_PREFIX, StringComparison.OrdinalIgnoreCase) &&
            int.TryParse(policyName.Substring(POLICY_PREFIX.Length), out var age))
        {
            var policy = new AuthorizationPolicyBuilder();
            policy.AddRequirements(new MinimumAgeRequirement(age));
            return Task.FromResult(policy.Build());
        }

        return Task.FromResult<AuthorizationPolicy>(null);
    }
}
```

## Multiple Authorization Policy Providers

When using custom `IAuthorizationPolicyProvider` implementations, keep in mind that ASP.NET Core only uses one instance of `IAuthorizationPolicyProvider`. So if a custom provider isn't able to provide authorization policies for all policy names that will be used (including, potentially, a default policy for `[Authorize]` attributes without a name), it should fall back to a backup provider.

For example, if a particular application needed both custom age policies (as demonstrated previously) and more traditional role-based policy retrieval, the custom `IAuthorizationPolicyProvider` could attempt to create policies for a given policy name (again, as shown above) and then call `GetPolicyAsync` on an instance of `DefaultAuthorizationPolicyProvider` if that fails (instead of returning null).

## Default Policy

In addition to providing named authorization policies, a custom `IAuthorizationPolicyProvider` also needs to implement `GetDefaultPolicyAsync` to provide an authorization policy for `[Authorize]` attributes without a policy name specified.

In many cases, this authorization attribute only requires an authenticated user, so you can make the necessary policy with a call to `RequireAuthenticatedUser`:

```CSharp
public Task<AuthorizationPolicy> GetDefaultPolicyAsync() => 
    Task.FromResult(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build());
```

As with all aspects of custom `IAuthorizationPolicyProvider`s, though, you can customize this, as needed. In some cases, default authorization policies might not be used or retrieving the default policy can be delegated to a fallback `IAuthorizationPolicyProvider`.

## Using a Custom IAuthorizationPolicyProvider

A custom `IAuthorizationPolicyProvider` allows extensibility in how ASP.NET Core applications find authorization policies for given policy names. As with other policy-based authorization scenarios, the policies returned from a custom `IAuthorizationPolicyProvider` will need to have requirements and you will need to register appropriate `AuthorizationHandler`s with dependency injection (as described in [policy-based authorization](xref:security/authorization/policies#authorization-handlers) documentation).

You also need to register custom `IAuthorizationPolicyProvider` types in the application's dependency injection service collection (in `Startup.ConfigureServices`) to replace the default policy provider.

```CSharp
services.AddTransient<IAuthorizationPolicyProvider, MinimumAgePolicyProvider>();
```

A complete custom `IAuthorizationPolicyProvider` sample is available in the [aspnet/AuthSamples GitHub repository](https://github.com/aspnet/AuthSamples/tree/dev/samples/CustomPolicyProvider).
