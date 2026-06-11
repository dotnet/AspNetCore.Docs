---
title: Policy-based authorization in ASP.NET Core
ai-usage: ai-assisted
author: wadepickett
description: Learn how to create and use authorization policy handlers for enforcing authorization requirements in an ASP.NET Core app.
monikerRange: '>= aspnetcore-3.1'
ms.author: wpickett
ms.custom: mvc
ms.date: 06/11/2026
uid: security/authorization/policies
---
# Policy-based authorization in ASP.NET Core

An ASP.NET Core authorization policy is a named set of one or more authorization requirements that the framework evaluates to decide whether a user is allowed to access a resource.

This article explains:

* Registering and applying policies.
* Authorization handlers for single and multiple requirement evaluation.
* How multiple requirements in a single policy are evaluated.

In practice, a policy is applied with `[Authorize(Policy = "...")]` or `RequireAuthorization(...)`, and the framework uses handlers to evaluate the requirements behind a policy. `IAuthorizationPolicyProvider` generates policies dynamically instead of registering them at app startup.

[Role-based authorization](xref:security/authorization/roles) and [claim-based authorization](xref:security/authorization/claims) use a requirement, a requirement handler, and a preconfigured authorization policy. These building blocks support the expression of authorization evaluations in code.

## Policy registration

:::moniker range=">= aspnetcore-6.0"

An authorization policy consists of one or more requirements. Register the policy as part of the authorization service configuration with <xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions.AddPolicy%2A?displayProperty=nameWithType> in the app's `Program` file. In the following example, the `AtLeast21` policy is created with a single requirement of a minimum age (`MinimumAgeRequirement`), which is supplied as a parameter to the requirement (`21`):

```csharp
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AtLeast21", policy =>
        policy.Requirements.Add(new MinimumAgeRequirement(21)));
});
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

An authorization policy consists of one or more requirements. Register the policy as part of the authorization service configuration with <xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions.AddPolicy%2A?displayProperty=nameWithType> in the `Startup.ConfigureServices` method. In the following example, the `AtLeast21` policy is created with a single requirement of a minimum age (`MinimumAgeRequirement`), which is supplied as a parameter to the requirement (`21`):

```csharp
services.AddAuthorization(options =>
{
    options.AddPolicy("AtLeast21", policy =>
        policy.Requirements.Add(new MinimumAgeRequirement(21)));
});
```

:::moniker-end

## `IAuthorizationService`

The primary service that determines if authorization is successful is <xref:Microsoft.AspNetCore.Authorization.IAuthorizationService>:

* `AuthorizeAsync(ClaimsPrincipal user, object resource, IEnumerable<IAuthorizationRequirement> requirements)`: Checks if a user meets a specific set of authorization requirements for a specified resource.
* `AuthorizeAsync(ClaimsPrincipal user, object resource, string policyName)`: Checks if a user meets a specific authorization policy for a specified resource.

If a resource isn't required for policy evaluation, pass `null` for the resource. Confirm that the resource is assigned when acting on a resource-focused policy.

These methods return `true` when authorization succeeds and `false` when it fails.

<xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirement> is a marker interface with no methods that serves as the mechanism for tracking whether authorization is successful.

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



The following code shows a typical authorization service configuration:

:::moniker range=">= aspnetcore-6.0"

```csharp
// Add all of your handlers to DI.
builder.Services.AddSingleton<IAuthorizationHandler, MyHandler1>();
// MyHandler2, ...

builder.Services.AddSingleton<IAuthorizationHandler, MyHandlerN>();

// Configure policies
builder.Services.AddAuthorization(options =>
      options.AddPolicy("Something",
      policy => policy.RequireClaim("Permission", "CanViewPage", "CanViewAnything")));
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
// Add all of your handlers to DI.
services.AddSingleton<IAuthorizationHandler, MyHandler1>();
// MyHandler2, ...

services.AddSingleton<IAuthorizationHandler, MyHandlerN>();

// Configure your policies
services.AddAuthorization(options =>
    options.AddPolicy("Something",
    policy => policy.RequireClaim("Permission", "CanViewPage", "CanViewAnything")));
```

:::moniker-end

Use <xref:Microsoft.AspNetCore.Authorization.IAuthorizationService> or `[Authorize(Policy = "Something")]` for authorization.

## Apply policies to MVC controllers

Apply policies to controllers by using the `[Authorize]` attribute with the policy name:

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/6.0/AuthorizationPoliciesSample/Controllers/AtLeast21Controller.cs" id="snippet" highlight="1":::

If multiple policies are applied at the controller and action levels, ***all*** policies must pass before access is granted:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/6.0/AuthorizationPoliciesSample/Controllers/AtLeast21Controller2.cs" id="snippet" highlight="1,4":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

Policies are applied to controllers by using the `[Authorize]` attribute with the policy name. For example:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/PoliciesAuthApp1/Controllers/AlcoholPurchaseController.cs" id="snippet_AlcoholPurchaseControllerClass" highlight="4":::

:::moniker-end

## Apply policies to Razor Pages

Apply policies to Razor Pages by using the `[Authorize]` attribute with the policy name. For example:

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/6.0/AuthorizationPoliciesSample/Pages/AtLeast21.cshtml.cs" highlight="6":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/PoliciesAuthApp2/Pages/AlcoholPurchase.cshtml.cs" id="snippet_AlcoholPurchaseModelClass" highlight="4":::

:::moniker-end

Policies can ***not*** be applied at the Razor Page handler level, they must be applied to the Page.

Policies can also be applied to Razor Pages by using an [authorization convention](xref:razor-pages/security/authorization/conventions).

## Apply policies to endpoints

Apply policies to endpoints by using <xref:Microsoft.AspNetCore.Builder.AuthorizationEndpointConventionBuilderExtensions.RequireAuthorization%2A> with the policy name. For example:

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/6.0/AuthorizationPoliciesSample/Program.cs" id="snippet_requireAuthorization":::

## Requirements

An authorization requirement is a collection of data parameters that a policy can use to evaluate the current user principal. In our "AtLeast21" policy, the requirement is a single parameter&mdash;the minimum age. A requirement implements <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirement>, which is an empty marker interface. A parameterized minimum age requirement could be implemented as follows:

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/6.0/AuthorizationPoliciesSample/Policies/Requirements/MinimumAgeRequirement.cs":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/PoliciesAuthApp1/Services/Requirements/MinimumAgeRequirement.cs" id="snippet_MinimumAgeRequirementClass":::

:::moniker-end

If an authorization policy contains multiple authorization requirements, all requirements must pass in order for the policy evaluation to succeed. In other words, multiple authorization requirements added to a single authorization policy are treated on an **AND** basis.

> [!NOTE]
> A requirement doesn't need to have data or properties.

## Authorization handlers

An authorization handler is responsible for the evaluation of a requirement's properties. The authorization handler evaluates the requirements against a provided <xref:Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext> to determine if access is allowed.

A requirement can have [multiple handlers](#why-would-i-want-multiple-handlers-for-a-requirement). A handler may inherit <xref:Microsoft.AspNetCore.Authorization.AuthorizationHandler%601>, where `TRequirement` is the requirement to be handled. Alternatively, a handler may implement <xref:Microsoft.AspNetCore.Authorization.IAuthorizationHandler> directly to handle more than one type of requirement.

### Use a handler for one requirement

The following example shows a one-to-one relationship in which a minimum age handler handles a single requirement:

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/6.0/AuthorizationPoliciesSample/Policies/Handlers/MinimumAgeHandler.cs":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/PoliciesAuthApp1/Services/Handlers/MinimumAgeHandler.cs" id="snippet_MinimumAgeHandlerClass":::

:::moniker-end

The preceding code determines if the current user principal has a date of birth claim that has been issued by a known and trusted Issuer. Authorization can't occur when the claim is missing, in which case a completed task is returned. When a claim is present, the user's age is calculated. If the user meets the minimum age defined by the requirement, authorization is considered successful. When authorization is successful, `context.Succeed` is invoked with the satisfied requirement as its sole parameter.

### Use a handler for multiple requirements

The following example shows a one-to-many relationship in which a permission handler can handle three different types of requirements:

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/6.0/AuthorizationPoliciesSample/Policies/Handlers/PermissionHandler.cs":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/PoliciesAuthApp1/Services/Handlers/PermissionHandler.cs" id="snippet_PermissionHandlerClass":::

:::moniker-end

The preceding code traverses <xref:Microsoft.AspNetCore.Authorization.AuthorizationHandlerContext.PendingRequirements%2A>&mdash;a property containing requirements not marked as successful. For a `ReadPermission` requirement, the user must be either an owner or a sponsor to access the requested resource. For an `EditPermission` or `DeletePermission` requirement, they must be an owner to access the requested resource.

### Handler registration

Register handlers in the services collection during configuration. For example:

:::moniker range=">= aspnetcore-6.0"

```csharp
builder.Services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
```

:::moniker-end

:::moniker range="< aspnetcore-6.0"

```csharp
services.AddSingleton<IAuthorizationHandler, MinimumAgeHandler>();
```

:::moniker-end

The preceding code registers `MinimumAgeHandler` as a singleton. Handlers can be registered using any of the built-in [service lifetimes](xref:fundamentals/dependency-injection#service-lifetimes).

It's possible to bundle both a requirement and a handler into a single class implementing both <xref:Microsoft.AspNetCore.Authorization.IAuthorizationRequirement> and <xref:Microsoft.AspNetCore.Authorization.IAuthorizationHandler>. This bundling creates a tight coupling between the handler and requirement and is only recommended for simple requirements and handlers. Creating a class that implements both interfaces removes the need to register the handler in DI because of the built-in <xref:Microsoft.AspNetCore.Authorization.Infrastructure.PassThroughAuthorizationHandler> that allows requirements to handle themselves.

See the implementation of the <xref:Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement> class for a good example where the <xref:Microsoft.AspNetCore.Authorization.Infrastructure.AssertionRequirement> is both a requirement and the handler in a fully self-contained class.

## What should a handler return?

Note that the `Handle` method in the [handler example](#use-a-handler-for-one-requirement) returns no value. How is a status of either success or failure indicated?

* A handler indicates success by calling `context.Succeed(IAuthorizationRequirement requirement)`, passing the requirement that has been successfully validated.

* A handler doesn't need to handle failures generally, as other handlers for the same requirement may succeed.

* To guarantee failure, even if other requirement handlers succeed, call `context.Fail`.

If a handler calls `context.Succeed` or `context.Fail`, all other handlers are still called. This allows requirements to produce side effects, such as logging, which takes place even if another handler has successfully validated or failed a requirement. When set to `false`, the <xref:Microsoft.AspNetCore.Authorization.AuthorizationOptions.InvokeHandlersAfterFailure%2A> property short-circuits the execution of handlers when `context.Fail` is called. `InvokeHandlersAfterFailure` defaults to `true`, in which case all handlers are called.

> [!NOTE]
> Authorization handlers are called even if authentication fails. Also handlers can execute in any order, so do ***not*** depend on them being called in any particular order.

## Why would I want multiple handlers for a requirement?

In cases where you want evaluation to be on an **OR** basis, implement multiple handlers for a single requirement. For example, Microsoft has doors that only open with key cards. If you leave your key card at home, the receptionist prints a temporary sticker and opens the door for you. In this scenario, you'd have a single requirement, *BuildingEntry*, but multiple handlers, each one examining a single requirement.

:::moniker range=">= aspnetcore-6.0"

`BuildingEntryRequirement.cs`

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/6.0/AuthorizationPoliciesSample/Policies/Requirements/BuildingEntryRequirement.cs":::

`BadgeEntryHandler.cs`

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/6.0/AuthorizationPoliciesSample/Policies/Handlers/BadgeEntryHandler.cs":::

`TemporaryStickerHandler.cs`

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/6.0/AuthorizationPoliciesSample/Policies/Handlers/TemporaryStickerHandler.cs":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

`BuildingEntryRequirement.cs`

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/PoliciesAuthApp1/Services/Requirements/BuildingEntryRequirement.cs" id="snippet_BuildingEntryRequirementClass":::

`BadgeEntryHandler.cs`

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/PoliciesAuthApp1/Services/Handlers/BadgeEntryHandler.cs" id="snippet_BadgeEntryHandlerClass":::

`TemporaryStickerHandler.cs`

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/PoliciesAuthApp1/Services/Handlers/TemporaryStickerHandler.cs" id="snippet_TemporaryStickerHandlerClass":::

:::moniker-end

Ensure that both handlers are [registered](xref:security/authorization/policies#handler-registration). If either handler succeeds when a policy evaluates the `BuildingEntryRequirement`, the policy evaluation succeeds.

## Use a func to fulfill a policy

There may be situations in which fulfilling a policy is simple to express in code. It's possible to supply a `Func<AuthorizationHandlerContext, bool>` when configuring a policy with the `RequireAssertion` policy builder.

For example, the previous `BadgeEntryHandler` could be rewritten as follows:

:::moniker range=">= aspnetcore-6.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/6.0/AuthorizationPoliciesSample/Program.cs" range="20-21,25-29":::

:::moniker-end

:::moniker range="< aspnetcore-6.0"

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/policies/3.0PoliciesAuthApp1/Startup.cs" range="42-43,47-53":::

:::moniker-end

## Access MVC request context in handlers

The `HandleRequirementAsync` method has two parameters: an `AuthorizationHandlerContext` and the `TRequirement` being handled. Frameworks such as MVC or SignalR are free to add any object to the `Resource` property on the `AuthorizationHandlerContext` to pass extra information.

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

For information on how to require authentication for all app users, see <xref:security/authorization/secure-data#require-authenticated-users>.

:::moniker range=">= aspnetcore-6.0"

## Authorization via an external service sample

The [Authorization via an external service sample (`dotnet/AspNetCore.Docs.Samples` GitHub repository)](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/security/authorization/AuthorizationExternalService) shows how to implement additional authorization requirements with an external authorization service. The solution's `Contoso.API` project is secured with [Microsoft Entra ID](/entra/fundamentals/what-is-entra). An additional authorization check from the `Contoso.Security.API` project returns a payload describing whether the `Contoso.API` client app can invoke the `GetWeather` API.

### Configure the sample

The following demonstration relies on using the Swagger UI or [cURL](https://curl.se/) in a command shell.

In the `Contoso.Security.API` project, configure the `AllowedClients` placeholder of `{CLIENT ID (FOR THE CLIENT CALLING CONTOSO.API)}` of the  with any test GUID value (for example, `00001111-aaaa-2222-bbbb-3333cccc4444`):

:::code language="csharp" source="~/../AspNetCore.Docs.Samples/security/authorization/AuthorizationExternalService/Contoso.Security.API/appsettings.json":::

Use [`dotnet user-jwts`](xref:security/authentication/jwt) to generate an access token with an `appid` claim for the client app's ID, which was created in the preceding step (for example, `00001111-aaaa-2222-bbbb-3333cccc4444`).

```dotnetcli
dotnet user-jwts create --claim appid={GUID}
```

Example:

```dotnetcli
dotnet user-jwts create --claim appid=00001111-aaaa-2222-bbbb-3333cccc4444
```

The output produces a token after "`Token:`" in the command shell:

```dotnetcli
New JWT saved with ID '{JWT ID}'.
Name: {USER}
Custom Claims: [appid=00001111-aaaa-2222-bbbb-3333cccc4444]

Token: {TOKEN}
```

Set the value of the token (where the `{TOKEN}` placeholder appears in the preceding output) aside for use later.

You can decode the token in an online JWT decoder, such as [`jwt.ms`](https://jwt.ms/) to see its contents, revealing that it contains an `appid` claim with the client app's ID:

```json
{
  "alg": "HS256",
  "typ": "JWT"
}.{
  "unique_name": "{USER}",
  "sub": "{USER}",
  "jti": "14ed7729",
  "appid": "9e7b23cf-2f98-48b5-a681-42cb4fb0df68",
  "aud": [
    "https://localhost:7250",
    "http://localhost:7251"
  ],
  "nbf": 1780660887,
  "exp": 1788609687,
  "iat": 1780660888,
  "iss": "dotnet-user-jwts"
}.[Signature]
```

Execute the command again with an incorrect client ID (`appid`) value:

```dotnetcli
dotnet user-jwts create --claim appid=aaaabbbb-0000-cccc-1111-dddd2222eeee
```

Set the value of second token aside.

Start both the `Contoso.API` and `Contoso.Security.API` projects in Visual Studio or with the `dotnet watch` command in a command shell:

```dotnetcli
dotnet watch
```

# [Swagger UI](#tab/swagger-ui)






# [cURL in a command shell](#tab/curl-command-shell)

In a command shell, use the .NET CLI to execute the following `curl.exe` command to request the `WeatherForecast` endpoint. Replace the `{TOKEN}` placeholder with the first JWT bearer token that you saved earlier:

```dotnetcli
curl.exe -i -H "Authorization: Bearer {TOKEN}" https://localhost:7250/WeatherForecast
```

The output indicates success because the user's birth date claim indicates that they're at least 21 years old:

```dotnetcli
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8
Date: Fri, 05 Jun 2026 12:48:58 GMT
Server: Kestrel
Transfer-Encoding: chunked

[{ ... WEATHER DATA ... }]
```

Execute the command again using the second token with the invalid client ID (`appid`). The result indicates a policy failure:

```dotnetcli
HTTP/1.1 403 Forbidden
Content-Length: 0
Date: Fri, 05 Jun 2026 13:09:56 GMT
Server: Kestrel
```

You can add breakpoints in the `Contoso.Security.API.SecurityPolicyController` and observe the passed client ID (`appid`) is used to assert whether it is allowed to obtain weather data.

You can also send the client ID directly to the `Contoso.Security.API` either via the Swagger UI or cURL in a command shell (for example: ``) to see it return either `true` or `false` for `canGetWeather`

```dotnetcli
curl.exe -i -H "Authorization: Bearer {TOKEN}" https://localhost:7123/SecurityPolicy/9e7b23cf-2f98-48b5-a681-42cb4fb0df68
```

With the correct client ID (`appid`), `canGetWeather` is `true`:

```dotnetcli
HTTP/1.1 200 OK
Content-Type: application/json; charset=utf-8
Date: Fri, 05 Jun 2026 13:19:49 GMT
Server: Kestrel
Transfer-Encoding: chunked

{"canGetWeather":true}
```

---

## Additional resources

* [Quickstart: Configure an application to expose a web API](/entra/identity-platform/quickstart-configure-app-expose-web-apis)
* [Authorization via an external service sample (`dotnet/AspNetCore.Docs.Samples` GitHub repository)](https://github.com/dotnet/AspNetCore.Docs.Samples/tree/main/security/authorization/AuthorizationExternalService)

:::moniker-end
