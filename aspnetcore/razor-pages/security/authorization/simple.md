---
title: Simple authorization in ASP.NET Core Razor Pages
ai-usage: ai-assisted
author: tdykstra
description: Learn how to use the [Authorize] attribute to restrict access in ASP.NET Core Razor Pages apps.
ms.author: tdykstra
ms.date: 03/05/2026
uid: razor-pages/security/authorization/simple
---
# Simple authorization in ASP.NET Core Razor Pages

Authorization in ASP.NET Core is controlled with the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) and its various parameters. In its most basic form, applying the `[Authorize]` attribute to a Razor component, controller, action, or Razor Page, limits access to that component to authenticated users.

This article covers scenarios that pertain to Razor Pages apps. For more information, see <xref:security/authorization/simple>.

## `[Authorize]` attribute

Apply the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) to the page model class that derives from <xref:Microsoft.AspNetCore.Mvc.RazorPages.PageModel>. In the following example, only authenticated users can reach the `LogoutModel` page:

```csharp
[Authorize]
public class LogoutModel : PageModel
{
    public async Task OnGetAsync() { ... }
    public async Task<IActionResult> OnPostAsync() { ... }
}
```

The [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) also supports role-based or policy-based authorization. For role-based authorization, use the <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Roles> parameter. In the following example, the user can only access the page if they're in the `Admin` or `Superuser` role:

```csharp
[Authorize(Roles = "Admin, Superuser")]
public class OrderModel : PageModel
{
    ...
}
```

For policy-based authorization, use the <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Policy> parameter. In the following example, the user can only access the page if they satisfy the requirements of the `Over21` [authorization policy](xref:security/authorization/policies):

```csharp
[Authorize(Policy = "Over21")]
public class LicenseApplicationModel : PageModel
{
    ...
}
```

If neither <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Roles> nor <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute.Policy> is specified, [`[Authorize]`](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) uses the default policy:

* Authenticated (signed-in) users are authorized.
* Unauthenticated (signed-out) users are unauthorized.

For guidance on <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute> and Razor Page handlers, see the [`[Authorize]` attribute in Razor Pages apps](#authorize-attribute-in-razor-pages-apps) section.

Use the [`[AllowAnonymous]` attribute](xref:Microsoft.AspNetCore.Authorization.AllowAnonymousAttribute) to allow access by non-authenticated users to individual actions:

```csharp
[AllowAnonymous]
```

For information on how to require authentication for all app users, see <xref:security/authorization/secure-data#require-authenticated-users>.

## `[Authorize]` attribute in Razor Pages apps

The <xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute> can't be applied to Razor Page handlers. For example, the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) can't be applied to `OnGet`, `OnPost`, or any other page handler. In a Razor Pages app, consider using an ASP.NET Core MVC controller for pages with different authorization requirements for different handlers. Using a controller when different authorization requirements are required is the least complex approach we recommend.

If you decide not to use an MVC controller, the following two approaches can be used to apply authorization to Razor Page handler methods:

* Use separate pages for page handlers requiring different authorization. Move shared content into one or more [partial views](xref:mvc/views/partial). When possible, this is the recommended approach.
* For content that must share a common page, write a filter that performs authorization as part of <xref:Microsoft.AspNetCore.Mvc.Filters.IAsyncPageFilter.OnPageHandlerExecutionAsync%2A?displayProperty=nameWithType>. This approach is demonstrated by the following example.

The `AuthorizeIndexPageHandlerFilter` implements the authorization filter:

```csharp
public class AuthorizeIndexPageHandlerFilter(
    IAuthorizationPolicyProvider policyProvider,
    IPolicyEvaluator policyEvaluator) : IAsyncPageFilter, IOrderedFilter
{
    private readonly IAuthorizationPolicyProvider policyProvider = 
        policyProvider;
    private readonly IPolicyEvaluator policyEvaluator = policyEvaluator;

    // Run late in the execution pipeline
    public int Order => 10000;

    public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context,
        PageHandlerExecutionDelegate next)
    {
        var attribute = context.HandlerMethod?.MethodInfo?
            .GetCustomAttribute<AuthorizePageHandlerAttribute>();

        if (attribute is null)
        {
            await next();
            return;
        }

        var policy = await AuthorizationPolicy
            .CombineAsync(policyProvider, new[] { attribute });

        if (policy is null)
        {
            await next();
            return;
        }

        var httpContext = context.HttpContext;
        var authenticateResult = await policyEvaluator
            .AuthenticateAsync(policy, httpContext);
        var authorizeResult = await policyEvaluator
            .AuthorizeAsync(policy, authenticateResult, httpContext,
                context.ActionDescriptor);

        if (authorizeResult.Challenged)
        {
            context.Result = policy.AuthenticationSchemes.Count > 0
                ? new ChallengeResult(policy.AuthenticationSchemes.ToArray())
                : new ChallengeResult();

            return;
        }
        else if (authorizeResult.Forbidden)
        {
            context.Result = policy.AuthenticationSchemes.Count > 0
                ? new ForbidResult(policy.AuthenticationSchemes.ToArray())
                : new ForbidResult();

            return;
        }

        await next();
    }

    public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
        => Task.CompletedTask;
}
```

The `AuthorizePageHandlerAttribute` provides an `[AuthorizePageHandler]` attribute to the app:

```csharp
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class AuthorizePageHandlerAttribute(string policy = null) 
    : Attribute, IAuthorizeData
{
    public string Policy { get; set; } = policy;
    public string Roles { get; set; }
    public string AuthenticationSchemes { get; set; }
}
```

The `[AuthorizePageHandler]` attribute is applied to page handlers. In the following example, the attribute is set on the `OnPostAuthorized` page handler:

```csharp
[TypeFilter(typeof(AuthorizeIndexPageHandlerFilter))]
public class IndexModel : PageModel
{
    ...

    [AuthorizePageHandler]
    public void OnPostAuthorized() { ... }
}
```

> [!WARNING]
> The preceding approach does ***not***:
>
> * Compose with authorization attributes applied to the page, page model, or globally. Composing authorization attributes results in authentication and authorization executing multiple times when you have one more [`[Authorize]` attributes](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) or <xref:Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter> instances also applied to the page.
> * Work in conjunction with the rest of the ASP.NET Core authentication and authorization system. Verify that this approach works correctly for the app.

There are no plans to support the [`[Authorize]` attribute](xref:Microsoft.AspNetCore.Authorization.AuthorizeAttribute) on Razor Page handlers.

## Additional resources

* <xref:security/authorization/simple>
* <xref:mvc/security/authorization/simple>
