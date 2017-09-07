---
title: Custom Policy-Based Authorization
author: rick-anderson
description: 
keywords: ASP.NET Core,
ms.author: riande
manager: wpickett
ms.date: 10/14/2016
ms.topic: article
ms.assetid: e422a1b2-dc4a-4bcc-b8d9-7ee62009b6a3
ms.technology: aspnet
ms.prod: asp.net-core
uid: security/authorization/policies
---
# Custom Policy-Based Authorization

<a name=security-authorization-policies-based></a>

Underneath the covers the [role authorization](roles.md#security-authorization-role-based) and [claims authorization](claims.md#security-authorization-claims-based) make use of a requirement, a handler for the requirement and a pre-configured policy. These building blocks allow you to express authorization evaluations in code, allowing for a richer, reusable, and easily testable authorization structure.

An authorization policy is made up of one or more requirements and registered at application startup as part of the Authorization service configuration, in `ConfigureServices` in the *Startup.cs* file.

<!-- literal_block {"ids": [], "names": [], "highlight_args": {}, "backrefs": [], "dupnames": [], "linenos": false, "classes": [], "xml:space": "preserve", "language": "c#"} -->

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();

    services.AddAuthorization(options =>
    {
        options.AddPolicy("Over21",
                          policy => policy.Requirements.Add(new MinimumAgeRequirement(21)));
    });
}
```

Here you can see an "Over21" policy is created with a single requirement, that of a minimum age, which is passed as a parameter to the requirement.

Policies are applied using the `Authorize` attribute by specifying the policy name, for example;

<!-- literal_block {"ids": [], "names": [], "highlight_args": {}, "backrefs": [], "dupnames": [], "linenos": false, "classes": [], "xml:space": "preserve", "language": "c#"} -->

```csharp
[Authorize(Policy="Over21")]
public class AlcoholPurchaseRequirementsController : Controller
{
    public ActionResult Login()
    {
    }

    public ActionResult Logout()
    {
    }
}
```

## Requirements

An authorization requirement is a collection of data parameters that a policy can use to evaluate the current user principal. In our Minimum Age policy the requirement we have is a single parameter, the minimum age. A requirement must implement `IAuthorizationRequirement`. This is an empty, marker interface. A parameterized minimum age requirement might be implemented as follows;

<!-- literal_block {"ids": [], "names": [], "highlight_args": {}, "backrefs": [], "dupnames": [], "linenos": false, "classes": [], "xml:space": "preserve", "language": "c#"} -->

```csharp
public class MinimumAgeRequirement : IAuthorizationRequirement
{
    public int MinimumAge { get; private set; }
    
    public MinimumAgeRequirement(int minimumAge)
    {
        MinimumAge = minimumAge;
    }
}
```

A requirement doesn't need to have data or properties.

<a name=security-authorization-policies-based-authorization-handler></a>

## Authorization Handlers

An authorization handler is responsible for the evaluation of any properties of a requirement. The  authorization handler must evaluate them against a provided `AuthorizationHandlerContext` to decide if authorization is allowed. A requirement can have [multiple handlers](policies.md#security-authorization-policies-based-multiple-handlers). Handlers must inherit `AuthorizationHandler<T>` where T is the requirement it handles.

<a name=security-authorization-handler-example></a>

The minimum age handler might look like this:

<!-- literal_block {"ids": [], "names": [], "highlight_args": {}, "backrefs": [], "dupnames": [], "linenos": false, "classes": [], "xml:space": "preserve", "language": "c#"} -->

```csharp
public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAgeRequirement requirement)
    {
        if (!context.User.HasClaim(c => c.Type == ClaimTypes.DateOfBirth &&
                                   c.Issuer == "http://contoso.com"))
        {
            // .NET 4.x -> return Task.FromResult(0);
            return Task.CompletedTask;
        }

        var dateOfBirth = Convert.ToDateTime(context.User.FindFirst(
            c => c.Type == ClaimTypes.DateOfBirth && c.Issuer == "http://contoso.com").Value);

        int calculatedAge = DateTime.Today.Year - dateOfBirth.Year;
        if (dateOfBirth > DateTime.Today.AddYears(-calculatedAge))
        {
            calculatedAge--;
        }

        if (calculatedAge >= requirement.MinimumAge)
        {
            context.Succeed(requirement);
        }
        return Task.CompletedTask;
    }
}
```

In the code above we first look to see if the current user principal has a date of birth claim which has been issued by an Issuer we know and trust. If the claim is missing we can't authorize so we return. If we have a claim, we figure out how old the user is, and if they meet the minimum age passed in by the requirement then authorization has been successful. Once authorization is successful we call `context.Succeed()` passing in the requirement that has been successful as a parameter.

<a name=security-authorization-policies-based-handler-registration></a>

Handlers must be registered in the services collection during configuration, for example;

<!-- literal_block {"ids": [], "names": [], "highlight_args": {}, "backrefs": [], "dupnames": [], "linenos": false, "classes": [], "xml:space": "preserve", "language": "c#"} -->

```csharp

public void ConfigureServices(IServiceCollection services)
{
    services.AddMvc();

    services.AddAuthorization(options =>
    {
        options.AddPolicy("Over21",
                          policy => policy.Requirements.Add(new MinimumAgeRequirement(21)));
    });

    services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
}
```

Each handler is added to the services collection by using `services.AddSingleton<IAuthorizationHandler, YourHandlerClass>();` passing in your handler class.

## What should a handler return?

You can see in our [handler example](policies.md#security-authorization-handler-example) that the `Handle()` method has no return value, so how do we indicate success or failure?

* A handler indicates success by calling `context.Succeed(IAuthorizationRequirement requirement)`, passing the requirement that has been successfully validated.

* A handler does not need to handle failures generally, as other handlers for the same requirement may succeed.

* To guarantee failure even if other handlers for a requirement succeed, call `context.Fail`.

Regardless of what you call inside your handler all handlers for a requirement will be called when a policy requires the requirement. This allows requirements to have side effects, such as logging, which will always take place even if `context.Fail()` has been called in another handler.

<a name=security-authorization-policies-based-multiple-handlers></a>

## Why would I want multiple handlers for a requirement?

In cases where you want evaluation to be on an **OR** basis you implement multiple handlers for a single requirement. For example, Microsoft has doors which only open with key cards. If you leave your key card at home the receptionist prints a temporary sticker and opens the door for you. In this scenario you'd have a single requirement, *EnterBuilding*, but multiple handlers, each one examining a single requirement.

<!-- literal_block {"ids": [], "names": [], "highlight_args": {}, "backrefs": [], "dupnames": [], "linenos": false, "classes": [], "xml:space": "preserve", "language": "c#"} -->

```csharp
public class EnterBuildingRequirement : IAuthorizationRequirement
{
}

public class BadgeEntryHandler : AuthorizationHandler<EnterBuildingRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EnterBuildingRequirement requirement)
    {
        if (context.User.HasClaim(c => c.Type == ClaimTypes.BadgeId &&
                                       c.Issuer == "http://microsoftsecurity"))
        {
            context.Succeed(requirement);
        }
        return Task.CompletedTask;
    }
}

public class HasTemporaryStickerHandler : AuthorizationHandler<EnterBuildingRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EnterBuildingRequirement requirement)
    {
        if (context.User.HasClaim(c => c.Type == ClaimTypes.TemporaryBadgeId &&
                                       c.Issuer == "https://microsoftsecurity"))
        {
            // We'd also check the expiration date on the sticker.
            context.Succeed(requirement);
        }
        return Task.CompletedTask;
    }
}
```

Now, assuming both handlers are [registered](xref:security/authorization/policies#security-authorization-policies-based-handler-registration) when a policy evaluates the `EnterBuildingRequirement` if either handler succeeds the policy evaluation will succeed.

## Using a func to fulfill a policy

There may be occasions where fulfilling a policy is simple to express in code. It is possible to simply supply a `Func<AuthorizationHandlerContext, bool>` when configuring your policy with the `RequireAssertion` policy builder.

For example the previous `BadgeEntryHandler` could be rewritten as follows;

<!-- literal_block {"ids": [], "names": [], "highlight_args": {}, "backrefs": [], "dupnames": [], "linenos": false, "classes": [], "xml:space": "preserve", "language": "c#"} -->

```csharp
services.AddAuthorization(options =>
    {
        options.AddPolicy("BadgeEntry",
                          policy => policy.RequireAssertion(context =>
                                  context.User.HasClaim(c =>
                                     (c.Type == ClaimTypes.BadgeId ||
                                      c.Type == ClaimTypes.TemporaryBadgeId)
                                      && c.Issuer == "https://microsoftsecurity"));
                          }));
    }
 }
```

## Accessing MVC Request Context In Handlers

The `Handle` method you must implement in an authorization handler has two parameters, an `AuthorizationContext` and the `Requirement` you are handling. Frameworks such as MVC or Jabbr are free to add any object to the `Resource` property on the `AuthorizationContext` to pass through extra information.

For example MVC passes an instance of `Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext` in the resource property which is used to access HttpContext, RouteData and everything else MVC provides.

The use of the `Resource` property is framework specific. Using information in the `Resource` property will limit your authorization policies to particular frameworks. You should cast the `Resource` property using the `as` keyword, and then check the cast has succeed to ensure your code doesn't crash with `InvalidCastExceptions` when run on other frameworks;

<!-- literal_block {"ids": [], "names": [], "highlight_args": {}, "backrefs": [], "dupnames": [], "linenos": false, "classes": [], "xml:space": "preserve", "language": "c#"} -->

```csharp
if (context.Resource is Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext mvcContext)
{
    // Examine MVC specific things like routing data.
}
```
