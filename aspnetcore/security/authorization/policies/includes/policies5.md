:::moniker range="< aspnetcore-6.0"

Underneath the covers, [role-based authorization](xref:security/authorization/roles) and [claims-based authorization](xref:security/authorization/claims) use a requirement, a requirement handler, and a pre-configured policy. These building blocks support the expression of authorization evaluations in code. The result is a richer, reusable, testable authorization structure.

An authorization policy consists of one or more requirements. It's registered as part of the authorization service configuration, in the `Startup.ConfigureServices` method:

:::code language="csharp" source="~/security/authorization/policies/samples/3.0PoliciesAuthApp1/Startup.cs" range="31-32,39-40,42-45, 53, 58":::

In the preceding example, an "AtLeast21" policy is created. It has a single requirement&mdash;that of a minimum age, which is supplied as a parameter to the requirement.

## IAuthorizationService

The primary service that determines if authorization is successful is <xref:Microsoft.AspNetCore.Authorization.IAuthorizationService>:

:::code language="csharp" source="~/security/authorization/policies/samples/stubs/copy_of_IAuthorizationService.cs" id="snippet" highlight="24-25,48-49":::

The preceding code highlights the two methods of the [IAuthorizationService](https://github.com/dotnet/AspNetCore/blob/v2.2.4/src/Security/Authorization/Core/src/IAuthorizationService.cs).

<xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirement> is a marker service with no methods, and the mechanism for tracking whether authorization is successful.

Each <xref:Microsoft.AspNetCore.Authorization.IAuthorizationHandler> is responsible for checking if requirements are met:
<!--The following code is a copy/paste from 
https://github.com/dotnet/AspNetCore/blob/v2.2.4/src/Security/Authorization/Core/src/IAuthorizationHandler.cs -->

```csharp
/// <summary>
/// Classes implementing this interface are able to make a decision if authorization
/// is allowed.
/// </summary>
public interface IAuthorizationHandler
{
    /// <summary>
    /// Makes a decision if authorization is allowed.
    /// </summary>
    /// <param name="context">The authorization information.</param>
    Task HandleAsync(AuthorizationHandlerContext context);
}
```

The <xref:Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext> class is what the handler uses to mark whether requirements have been met:

```csharp
 context.Succeed(requirement)
```

The following code shows the simplified (and annotated with comments) default implementation of the authorization service:

```csharp
public async Task<AuthorizationResult> AuthorizeAsync(ClaimsPrincipal user, 
             object resource, IEnumerable<IAuthorizationRequirement> requirements)
{
    // Create a tracking context from the authorization inputs.
    var authContext = _contextFactory.CreateContext(requirements, user, resource);

    // By default this returns an IEnumerable<IAuthorizationHandlers> from DI.
    var handlers = await _handlers.GetHandlersAsync(authContext);

    // Invoke all handlers.
    foreach (var handler in handlers)
    {
        await handler.HandleAsync(authContext);
    }

    // Check the context, by default success is when all requirements have been met.
    return _evaluator.Evaluate(authContext);
}
```

The following code shows a typical `ConfigureServices`:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // Add all of your handlers to DI.
    services.AddSingleton<IAuthorizationHandler, MyHandler1>();
    // MyHandler2, ...

    services.AddSingleton<IAuthorizationHandler, MyHandlerN>();

    // Configure your policies
    services.AddAuthorization(options =>
          options.AddPolicy("Something",
          policy => policy.RequireClaim("Permission", "CanViewPage", "CanViewAnything")));


    services.AddControllersWithViews();
    services.AddRazorPages();
}
```

Use <xref:Microsoft.AspNetCore.Authorization.IAuthorizationService> or `[Authorize(Policy = "Something")]` for authorization.

<a name="apply-policies-to-mvc-controllers"></a>

## Apply policies to MVC controller

If you're using Razor Pages, see [Apply policies to Razor Pages](#apply-policies-to-razor-pages) in this document.

Policies are applied to controllers by using the `[Authorize]` attribute with the policy name. For example:

:::code language="csharp" source="~/security/authorization/policies/samples/PoliciesAuthApp1/Controllers/AlcoholPurchaseController.cs" id="snippet_AlcoholPurchaseControllerClass" highlight="4":::

## Apply policies to Razor Pages

Policies are applied to Razor Pages by using the `[Authorize]` attribute with the policy name. For example:

:::code language="csharp" source="~/security/authorization/policies/samples/PoliciesAuthApp2/Pages/AlcoholPurchase.cshtml.cs" id="snippet_AlcoholPurchaseModelClass" highlight="4":::

Policies can ***not*** be applied at the Razor Page handler level, they must be applied to the Page.

Policies can be applied to Razor Pages by using an [authorization convention](xref:security/authorization/razor-pages-authorization).

<a name="requirements"></a>

## Requirements

An authorization requirement is a collection of data parameters that a policy can use to evaluate the current user principal. In our "AtLeast21" policy, the requirement is a single parameter&mdash;the minimum age. A requirement implements <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>, which is an empty marker interface. A parameterized minimum age requirement could be implemented as follows:

:::code language="csharp" source="~/security/authorization/policies/samples/PoliciesAuthApp1/Services/Requirements/MinimumAgeRequirement.cs" id="snippet_MinimumAgeRequirementClass":::

If an authorization policy contains multiple authorization requirements, all requirements must pass in order for the policy evaluation to succeed. In other words, multiple authorization requirements added to a single authorization policy are treated on an **AND** basis.

> [!NOTE]
> A requirement doesn't need to have data or properties.

<a name="security-authorization-policies-based-authorization-handler"></a>

## Authorization handlers

An authorization handler is responsible for the evaluation of a requirement's properties. The authorization handler evaluates the requirements against a provided <xref:Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext> to determine if access is allowed.

A requirement can have [multiple handlers](#security-authorization-policies-based-multiple-handlers). A handler may inherit <xref:Microsoft.AspNetCore.Authorization.AuthorizationHandler%601>, where `TRequirement` is the requirement to be handled. Alternatively, a handler may implement <xref:Microsoft.AspNetCore.Authorization.IAuthorizationHandler> to handle more than one type of requirement.

### Use a handler for one requirement

<a name="security-authorization-handler-example"></a>

The following example shows a one-to-one relationship in which a minimum age handler utilizes a single requirement:

:::code language="csharp" source="~/security/authorization/policies/samples/PoliciesAuthApp1/Services/Handlers/MinimumAgeHandler.cs" id="snippet_MinimumAgeHandlerClass":::

The preceding code determines if the current user principal has a date of birth claim that has been issued by a known and trusted Issuer. Authorization can't occur when the claim is missing, in which case a completed task is returned. When a claim is present, the user's age is calculated. If the user meets the minimum age defined by the requirement, authorization is considered successful. When authorization is successful, `context.Succeed` is invoked with the satisfied requirement as its sole parameter.

### Use a handler for multiple requirements

The following example shows a one-to-many relationship in which a permission handler can handle three different types of requirements:

:::code language="csharp" source="~/security/authorization/policies/samples/PoliciesAuthApp1/Services/Handlers/PermissionHandler.cs" id="snippet_PermissionHandlerClass":::

The preceding code traverses <xref:Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.PendingRequirements%2A>&mdash;a property containing requirements not marked as successful. For a `ReadPermission` requirement, the user must be either an owner or a sponsor to access the requested resource. For an `EditPermission` or `DeletePermission` requirement, the user must be an owner to access the requested resource.

<a name="security-authorization-policies-based-handler-registration"></a>

### Handler registration

Handlers are registered in the services collection during configuration. For example:

:::code language="csharp" source="~/security/authorization/policies/samples/3.0PoliciesAuthApp1/Startup.cs" range="31-32,39-40,42-45,53-55,58":::

The preceding code registers `MinimumAgeHandler` as a singleton by invoking `services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();`. Handlers can be registered using any of the built-in [service lifetimes](xref:fundamentals/dependency-injection#service-lifetimes).

It's possible to bundle both a requirement and a handler in a single class implementing both <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirement> and <xref:Microsoft.AspNetCore.Authorization.IAuthorizationHandler>. This bundling creates a tight coupling between the handler and requirement and is only recommended for simple requirements and handlers. Creating a class that implements both interfaces removes the need to register the handler in DI because of the built-in [PassThroughAuthorizationHandler](https://github.com/dotnet/aspnetcore/blob/v5.0.7/src/Security/Authorization/Core/src/PassThroughAuthorizationHandler.cs) that allows requirements to handle themselves.

See the [AssertionRequirement class](https://github.com/dotnet/aspnetcore/blob/52eff90fbcfca39b7eb58baad597df6a99a542b0/src/Security/Authorization/Core/src/AssertionRequirement.cs#L13) for a good example where the `AssertionRequirement` is both a requirement and the handler in a fully self-contained class.

## What should a handler return?

Note that the `Handle` method in the [handler example](#security-authorization-handler-example) returns no value. How is a status of either success or failure indicated?

* A handler indicates success by calling `context.Succeed(IAuthorizationRequirement requirement)`, passing the requirement that has been successfully validated.

* A handler doesn't need to handle failures generally, as other handlers for the same requirement may succeed.

* To guarantee failure, even if other requirement handlers succeed, call `context.Fail`.

If a handler calls `context.Succeed` or `context.Fail`, all other handlers are still called. This allows requirements to produce side effects, such as logging, which takes place even if another handler has successfully validated or failed a requirement. When set to `false`, the <xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions.InvokeHandlersAfterFailure%2A> property short-circuits the execution of handlers when `context.Fail` is called. `InvokeHandlersAfterFailure` defaults to `true`, in which case all handlers are called.

> [!NOTE]
> Authorization handlers are called even if authentication fails.

<a name="security-authorization-policies-based-multiple-handlers"></a>

## Why would I want multiple handlers for a requirement?

In cases where you want evaluation to be on an **OR** basis, implement multiple handlers for a single requirement. For example, Microsoft has doors that only open with key cards. If you leave your key card at home, the receptionist prints a temporary sticker and opens the door for you. In this scenario, you'd have a single requirement, *BuildingEntry*, but multiple handlers, each one examining a single requirement.

`BuildingEntryRequirement.cs`

:::code language="csharp" source="~/security/authorization/policies/samples/PoliciesAuthApp1/Services/Requirements/BuildingEntryRequirement.cs" id="snippet_BuildingEntryRequirementClass":::

`BadgeEntryHandler.cs`

:::code language="csharp" source="~/security/authorization/policies/samples/PoliciesAuthApp1/Services/Handlers/BadgeEntryHandler.cs" id="snippet_BadgeEntryHandlerClass":::

`TemporaryStickerHandler.cs`

:::code language="csharp" source="~/security/authorization/policies/samples/PoliciesAuthApp1/Services/Handlers/TemporaryStickerHandler.cs" id="snippet_TemporaryStickerHandlerClass":::

Ensure that both handlers are [registered](xref:security/authorization/policies#security-authorization-policies-based-handler-registration). If either handler succeeds when a policy evaluates the `BuildingEntryRequirement`, the policy evaluation succeeds.

<a name="use-a-func-to-fulfill-a-policy"></a>

## Use a func to fulfill a policy

There may be situations in which fulfilling a policy is simple to express in code. It's possible to supply a `Func<AuthorizationHandlerContext, bool>` when configuring your policy with the `RequireAssertion` policy builder.

For example, the previous `BadgeEntryHandler` could be rewritten as follows:

:::code language="csharp" source="~/security/authorization/policies/samples/3.0PoliciesAuthApp1/Startup.cs" range="42-43,47-53":::

<a name="access-mvc-request-context-in-handlers"></a>

## Access MVC request context in handlers

The `HandleRequirementAsync` method you implement in an authorization handler has two parameters: an `AuthorizationHandlerContext` and the `TRequirement` you are handling. Frameworks such as MVC or SignalR are free to add any object to the `Resource` property on the `AuthorizationHandlerContext` to pass extra information.

When using endpoint routing, authorization is typically handled by the Authorization Middleware. In this case, the `Resource` property is an instance of <xref:Microsoft.AspNetCore.Http.HttpContext>. The context can be used to access the current endpoint, which can be used to probe the underlying resource to which you're routing. For example:

```csharp
if (context.Resource is HttpContext httpContext)
{
    var endpoint = httpContext.GetEndpoint();
    var actionDescriptor = endpoint.Metadata.GetMetadata<ControllerActionDescriptor>();
    ...
}
```

With traditional routing, or when authorization happens as part of MVC's authorization filter, the value of `Resource` is an <xref:Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext> instance. This property provides access to `HttpContext`, `RouteData`, and everything else provided by MVC and Razor Pages.

The use of the `Resource` property is framework-specific. Using information in the `Resource` property limits your authorization policies to particular frameworks. Cast the `Resource` property using the `is` keyword, and then confirm the cast has succeeded to ensure your code doesn't crash with an `InvalidCastException` when run on other frameworks:

```csharp
// Requires the following import:
//     using Microsoft.AspNetCore.Mvc.Filters;
if (context.Resource is AuthorizationFilterContext mvcContext)
{
    // Examine MVC-specific things like routing data.
}
```

## Globally require all users to be authenticated

[!INCLUDE[](~/includes/requireAuth.md)]

:::moniker-end
